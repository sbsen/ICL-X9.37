Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.Xml

Public Class frmViewer
  Public x9Stuff As New x9Recs
  Public xmlFields As New XmlDocument
  Dim allImgFile As String = Path.GetTempFileName()
  Dim checkImageFS As FileStream
  Dim checkImageBR As BinaryReader

  Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
    If ofdX9.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.Cursor = Cursors.WaitCursor
      progbLoad.Visible = True
      lblLoad.Visible = True
      x9Stuff.Clear()
      ShowX9File(ofdX9.FileName)
      progbLoad.Visible = False
      Me.Cursor = Cursors.Default
      lblFile.Text = ofdX9.FileName
    End If
  End Sub

  Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
    Me.Close()
  End Sub

  Sub ShowX9File(ByVal x9File As String)
    ' open x9.37 file from bank
    Dim fs As New FileStream(x9File, FileMode.Open, FileAccess.Read, FileShare.Read)
    'Dim ofs As New FileStream(allImgFile, FileMode.Create)
    Dim curPos As Integer = 0
    ' 37 is EBCDIC encoding
    Dim br As New BinaryReader(fs, System.Text.Encoding.GetEncoding(37))
    Dim reclenB(3) As Byte    ' to hold rec length in Big Endian byte order (motorola format) why Big Endian??
    Dim alImg As New ArrayList
    Dim imgNbr As Integer = 0
    'Dim imgCheck As Image
    'Dim loadStart As DateTime = Now
    'Dim loadEnd As DateTime
    'Dim loadElapsed As TimeSpan

    ' Read first record
    reclenB = br.ReadBytes(4)   ' first 4 bytes hold the record length
    curPos += 4
    Array.Reverse(reclenB)      ' this is 'cause the rec length is in Big Endian order why? (probably some wise ass)
    Dim reclen As Int32 = BitConverter.ToInt32(reclenB, 0)  ' convert rec length to integer

    ' variables to hold currect record
    Dim recB() As Byte
    Dim rec As String

    ' variables to hold various key lengths in the variable record type 53 which also holds the check image
    Dim refKeyLen, sigLen, imgLen As Integer

    ' counts
    Dim fileRecCount As Integer
    Dim checkCount As Integer = 0
    ' Flags for start and end of sections
    Dim fileStarted, clStarted, bundleStarted, fileEnded, clEnded, bundleEnded, checkStarted As Boolean
    Dim checkFront50, checkFront52, checkBack50, checkBack52 As Boolean
    fileStarted = False   ' Flag for header
    fileEnded = False     ' flag for footer
    clStarted = False     ' flag for cash letter header
    clEnded = False       ' flag for cash letter footer
    bundleStarted = False ' flag for bundle header
    bundleEnded = False   ' flage for bundle footer
    checkStarted = False
    checkFront50 = False
    checkFront52 = False

    Dim clNode, bundleNode, checkNode As TreeNode

    Application.DoEvents()
    Dim fileSize As Long = fs.Length
    Dim readSize As Long = 0
    lblFile.Text = "Loading ..."
    tvX9.Nodes.Clear()
    ' Loop thru the file
    Do While reclen > 0
      ReDim recB(reclen)
      recB = br.ReadBytes(reclen)
      readSize += reclen + 4
      curPos += reclen
      If fileRecCount Mod 100 = 0 Then
        progbLoad.Value = (readSize / fileSize) * 100
        lblLoad.Text = (readSize / 1024).ToString("###,###,###,###") & " KB of " & (fileSize / 1024).ToString("###,###,###,###") & " KB"
        Application.DoEvents()
      End If
      rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB))

      fileRecCount += 1
      Select Case rec.Substring(0, 2)
        Case "01" ' File Header record
          fileStarted = True
          tvX9.Nodes.Add(x9Stuff.Add(New x9Rec("01", rec, "")), "Header (01)").ForeColor = My.Settings.color01
        Case "10" ' cash file header
          If fileStarted Then
            If clStarted Then
              If clEnded Then
                clEnded = False
              Else
                MessageBox.Show("No Cash Letter Control record.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblFile.ForeColor = Color.Red
                lblFile.Text &= " - Invalid file"
                Exit Sub
              End If
            Else
              clStarted = True
            End If
            clNode = tvX9.Nodes(0).Nodes.Add(x9Stuff.Add(New x9Rec("10", rec, "")), "Cash Letter Header (10)")
            clNode.ForeColor = My.Settings.color10
          Else
            ' no file header yet
            MessageBox.Show("No File Header Record.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblFile.ForeColor = Color.Red
            lblFile.Text &= " - Invalid file"
            Exit Sub
          End If
        Case "20" ' bundle header record
          If fileStarted Then
            If clStarted Then
              If bundleStarted Then
                If bundleEnded Then
                  bundleEnded = False
                Else
                  MessageBox.Show("No Bundle Control record.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  lblFile.ForeColor = Color.Red
                  lblFile.Text &= " - Invalid file"
                  Exit Sub
                End If
              Else
                bundleStarted = True
              End If
            Else
              MessageBox.Show("No Cash Letter Header record.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
              lblFile.ForeColor = Color.Red
              lblFile.Text &= " - Invalid file"
              Exit Sub
            End If
          Else
            ' no file header yet
            MessageBox.Show("No File Header Record.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblFile.ForeColor = Color.Red
            lblFile.Text &= " - Invalid file"
            Exit Sub
          End If
          bundleNode = clNode.Nodes.Add(x9Stuff.Add(New x9Rec("20", rec, "")), "Bundle Header (20)")
          bundleNode.ForeColor = My.Settings.color20
        Case "25" ' check detail record
          If bundleStarted AndAlso Not bundleEnded Then
            If checkStarted Then
              ' make sure we got everything for previous check
              If Not checkFront50 Then
                ' no check front 50
                MessageBox.Show("No Check Image Detail Record 50 - Front.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblFile.ForeColor = Color.Red
                lblFile.Text &= " - Invalid file"
                Exit Sub
              End If
              If Not checkFront52 Then
                ' no check front 52
                MessageBox.Show("No Check Image Data Record 52 - Front.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblFile.ForeColor = Color.Red
                lblFile.Text &= " - Invalid file"
                Exit Sub
              End If
              If Not checkBack50 Then
                ' no check back 50
                MessageBox.Show("No Check Image Detail Record 50 - Back.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblFile.ForeColor = Color.Red
                lblFile.Text &= " - Invalid file"
                Exit Sub
              End If
              If Not checkBack52 Then
                ' no check back 52
                MessageBox.Show("No Check Image Data Record 52 - Back.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
                lblFile.ForeColor = Color.Red
                lblFile.Text &= " - Invalid file"
                Exit Sub
              End If
              checkBack50 = False
              checkBack52 = False
              checkFront50 = False
              checkFront52 = False
            Else
              checkStarted = True
            End If

          Else
            ' no bundle header yet
            MessageBox.Show("No Bundle Header Record.", "Error nsX9Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblFile.ForeColor = Color.Red
            lblFile.Text &= " - Invalid file"
            Exit Sub
          End If
          checkCount += 1
          If My.Settings.showItemNumber Then
            checkNode = bundleNode.Nodes.Add(x9Stuff.Add(New x9Rec("25", rec, "")), checkCount.ToString("#,###,###") & ": Check Detail (25)")
          Else
            checkNode = bundleNode.Nodes.Add(x9Stuff.Add(New x9Rec("25", rec, "")), "Check Detail (25)")
          End If
          checkNode.ForeColor = My.Settings.color25
        Case "26"
          checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("26", rec, "")), "Addendum A (26)").ForeColor = Color.Green
        Case "28"
          checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("28", rec, "")), "Addendum C (28)").ForeColor = Color.Green
        Case "31"
          checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("31", rec, "")), "Return (31)").ForeColor = Color.Green
        Case "32"
          checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("32", rec, "")), "Return Addendum A (32)").ForeColor = Color.Green
        Case "33"
          checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("33", rec, "")), "Return Addendum B (33)").ForeColor = Color.Green
        Case "35"
          checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("35", rec, "")), "Return Addendum D (35)").ForeColor = Color.Green
        Case "50"
          If checkStarted Then
            If checkFront50 Then
              ' back of check
              checkBack50 = True
              checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("50", rec, "")), "Image Detail Back (50)").ForeColor = Color.Green
            Else
              ' front of check
              checkFront50 = True
              checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("50", rec, "")), "Image Detail Front (50)").ForeColor = Color.Green
            End If
          End If
        Case "52"
          curPos -= reclen
          ' read first 105 characters
          rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB, 0, 105))
          ' get length of image reference key 102-105
          refKeyLen = Integer.Parse(rec.Substring(101))
          ' read image ref key and digital sig length
          rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB, 0, 105 + refKeyLen + 5))
          sigLen = Integer.Parse(rec.Substring(105 + refKeyLen))
          ' read everything except image
          rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB, 0, 105 + refKeyLen + 5 + sigLen + 7))
          curPos += 105 + refKeyLen + 5 + sigLen + 7
          imgLen = Integer.Parse(rec.Substring(rec.Length - 7))
          'Byte2Image(imgCheck, recB, rec.Length)
          'Dim oFileStream As System.IO.FileStream
          Dim outArr(recB.GetUpperBound(0) - rec.Length) As Byte
          Array.Copy(recB, rec.Length, outArr, 0, recB.Length - rec.Length)
          'If File.Exists("img" & imgNbr.ToString("0000000") & ".tif") Then
          '  File.Delete("img" & imgNbr.ToString("0000000") & ".tif")
          'End If
          'oFileStream = New System.IO.FileStream("img" & imgNbr.ToString("0000000") & ".tif", System.IO.FileMode.Create)
          'alImg.Add("img" & imgNbr.ToString("0000000") & ".tif")
          'oFileStream.Write(outArr, 0, outArr.Length)
          'oFileStream.Close()
          'ofs.Write(outArr, 0, outArr.Length)
          If checkStarted Then
            If checkFront52 Then
              ' back image of check
              checkBack52 = True
              checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("52", rec, curPos.ToString & "," & outArr.Length.ToString)), "Image Data Back (52)").ForeColor = Color.Green
            Else
              ' front image of check
              checkFront52 = True
              checkNode.Nodes.Add(x9Stuff.Add(New x9Rec("52", rec, curPos.ToString & "," & outArr.Length.ToString)), "Image Data Front (52)").ForeColor = Color.Green
            End If
          End If
          imgNbr += 1
          curPos += outArr.Length
        Case "70"
          bundleEnded = True
          bundleNode.Nodes.Add(x9Stuff.Add(New x9Rec("70", rec, "")), "Bundle Control (70)").ForeColor = My.Settings.color20
        Case "90"
          clEnded = True
          clNode.Nodes.Add(x9Stuff.Add(New x9Rec("90", rec, "")), "Cash Letter Control (90)").ForeColor = My.Settings.color10
        Case "99"
          fileEnded = True
          tvX9.Nodes.Add(x9Stuff.Add(New x9Rec("99", rec, "")), "File Control (99)").ForeColor = My.Settings.color01
      End Select
      reclenB = br.ReadBytes(4)
      curPos += 4
      If reclenB.Length = 4 Then
        Array.Reverse(reclenB)
        reclen = BitConverter.ToInt32(reclenB, 0)
      Else
        reclen = 0
      End If
    Loop

    br.Close()
    fs.Close()
    'ofs.Close()
    'checkImageFS = New FileStream(allImgFile, FileMode.Open, FileAccess.Read, FileShare.Read)
    checkImageFS = New FileStream(x9File, FileMode.Open, FileAccess.Read, FileShare.Read)
    checkImageBR = New BinaryReader(checkImageFS)

    SearchToolStripMenuItem.Enabled = True
    'loadEnd = Now
    'loadElapsed = loadEnd.Subtract(loadStart)
    'MsgBox("File loaded in " & loadElapsed.TotalSeconds.ToString("###,##0.00s"))
  End Sub

  Public Sub Byte2Image(ByRef NewImage As Image, ByVal ByteArr() As Byte, Optional ByVal startIndex As Integer = 0)
    '
    Dim ImageStream As MemoryStream
    Dim newArr(ByteArr.GetUpperBound(0) - startIndex) As Byte
    Array.Copy(ByteArr, startIndex, newArr, 0, ByteArr.Length - startIndex)
    Try
      If newArr.GetUpperBound(0) > 0 Then
        ImageStream = New MemoryStream(newArr)
        NewImage = Image.FromStream(ImageStream)
      Else
        NewImage = Nothing
      End If
    Catch ex As Exception
      NewImage = Nothing
    End Try
  End Sub

  ''' <summary>
  ''' This function will join the TIFF file with a specific compression format
  ''' </summary>
  ''' <param name="imageFiles">array list with source image files</param>
  ''' <param name="outFile">target TIFF file to be produced</param>
  ''' <param name="compressEncoder">compression codec enum</param>
  Public Sub JoinTiffImages(ByVal imageFiles As ArrayList, ByVal outFile As String, ByVal compressEncoder As EncoderValue)
    Try
      'If only one page in the collection, copy it directly to the target file.
      If imageFiles.Count = 1 Then
        File.Copy(DirectCast(imageFiles(0), String), outFile, True)
        Exit Sub
      End If

      'use the save encoder
      Dim enc As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.SaveFlag

      Dim ep As New EncoderParameters(2)
      ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
      ep.Param(1) = New EncoderParameter(System.Drawing.Imaging.Encoder.Compression, CLng(compressEncoder))

      Dim pages As Bitmap = Nothing
      Dim frame As Integer = 0
      Dim info As ImageCodecInfo = GetEncoderInfo("image/tiff")


      For Each strImageFile As String In imageFiles
        If frame = 0 Then
          pages = DirectCast(Image.FromFile(strImageFile), Bitmap)

          'save the first frame
          pages.Save(outFile, info, ep)
        Else
          'save the intermediate frames
          ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.FrameDimensionPage))

          Dim bm As Bitmap = DirectCast(Image.FromFile(strImageFile), Bitmap)
          pages.SaveAdd(bm, ep)
          bm.Dispose()
        End If

        If frame = imageFiles.Count - 1 Then
          'flush and close.
          ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.Flush))
          pages.SaveAdd(ep)
        End If

        frame += 1
      Next
    Catch ex As Exception
      Console.WriteLine(ex.Message)
    End Try

    Exit Sub
  End Sub

  Public Sub JoinTiffImages2(ByVal outFile As String, ByVal compressEncoder As EncoderValue)
    'use the save encoder
    Dim enc As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.SaveFlag

    Dim ep As New EncoderParameters(2)
    ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
    ep.Param(1) = New EncoderParameter(System.Drawing.Imaging.Encoder.Compression, CLng(compressEncoder))

    Dim pages As Bitmap = Nothing
    Dim frame As Integer = 0
    Dim info As ImageCodecInfo = GetEncoderInfo("image/tiff")
    Dim cImg As Image
    Dim startPos As Integer
    Dim imgLen As Integer
    Dim recB() As Byte

    Dim exporting As New Closing
    exporting.Text = "Exporting check images"
    exporting.lblCleanup.Text = "exporting check images to tiff..."
    exporting.Show()
    Me.Cursor = Cursors.WaitCursor
    Dim reccnt As Integer = 0
    Try
      For Each rec As x9Rec In x9Stuff
        If rec.recImage.Trim.Length > 0 Then
          startPos = CInt(rec.recImage.Substring(0, rec.recImage.IndexOf(",")))
          imgLen = CInt(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1))
          checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin)
          ReDim recB(imgLen)
          recB = checkImageBR.ReadBytes(imgLen)
          Byte2Image(cImg, recB, 0)
          If frame = 0 Then
            pages = DirectCast(cImg, Bitmap)

            'save the first frame
            pages.Save(outFile, info, ep)
          Else
            'save the intermediate frames
            ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.FrameDimensionPage))

            pages.SaveAdd(DirectCast(cImg, Bitmap), ep)
          End If

          frame += 1
        End If
        reccnt += 1
        exporting.pbCleanup.Value = (reccnt / x9Stuff.Count) * 100
        Application.DoEvents()
      Next
    Catch ex As Exception
      exporting.TopMost = False
      MessageBox.Show(ex.Message & " rec count=" & reccnt.ToString("###,###,###"), "Error Exporting", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
    'flush and close.
    If pages Is Nothing Then
      ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.Flush))
      pages.SaveAdd(ep)
    End If
    exporting.Close()
    Me.Cursor = Cursors.Default
  End Sub

  Public Sub JoinTiffImages3(ByVal outFile As String, ByVal compressEncoder As EncoderValue)
    'use the save encoder
    Dim enc As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.SaveFlag

    Dim ep As New EncoderParameters(2)
    ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.MultiFrame))
    ep.Param(1) = New EncoderParameter(System.Drawing.Imaging.Encoder.Compression, CLng(compressEncoder))

    Dim pages As Bitmap = Nothing
    Dim frame As Integer = 0
    Dim info As ImageCodecInfo = GetEncoderInfo("image/tiff")
    Dim cImg As Image
    Dim startPos As Integer
    Dim imgLen As Integer
    Dim recB() As Byte

    Dim exporting As New Closing
    Dim frontImage As Boolean = False
    exporting.Text = "Exporting check images"
    exporting.lblCleanup.Text = "exporting check images to tiff..."
    exporting.Show()
    Me.Cursor = Cursors.WaitCursor
    Dim reccnt As Integer = 0
    Try
      For Each rec As x9Rec In x9Stuff
        If rec.recType = 50 AndAlso rec.recData.Substring(31, 1) = "0" Then
          frontImage = True
        End If
        If rec.recImage.Trim.Length > 0 AndAlso frontImage Then
          frontImage = False
          startPos = CInt(rec.recImage.Substring(0, rec.recImage.IndexOf(",")))
          imgLen = CInt(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1))
          checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin)
          ReDim recB(imgLen)
          recB = checkImageBR.ReadBytes(imgLen)
          Byte2Image(cImg, recB, 0)
          If frame = 0 Then
            pages = DirectCast(cImg, Bitmap)

            'save the first frame
            pages.Save(outFile, info, ep)
          Else
            'save the intermediate frames
            ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.FrameDimensionPage))

            pages.SaveAdd(DirectCast(cImg, Bitmap), ep)
          End If

          frame += 1
        End If
        reccnt += 1
        exporting.pbCleanup.Value = (reccnt / x9Stuff.Count) * 100
        Application.DoEvents()
      Next
    Catch ex As Exception
      exporting.TopMost = False
      MessageBox.Show(ex.Message & " rec count=" & reccnt.ToString("###,###,###"), "Error Exporting", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
    'flush and close.
    If pages Is Nothing Then
      ep.Param(0) = New EncoderParameter(enc, CLng(EncoderValue.Flush))
      pages.SaveAdd(ep)
    End If
    exporting.Close()
    Me.Cursor = Cursors.Default
  End Sub

  ''' <summary>
  ''' Getting the supported codec info.
  ''' </summary>
  ''' <param name="mimeType">description of mime type</param>
  ''' <returns>image codec info</returns>
  Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
    Dim encoders As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
    For j As Integer = 0 To encoders.Length - 1
      If encoders(j).MimeType = mimeType Then
        Return encoders(j)
      End If
    Next

    Throw New Exception(mimeType & " mime type not found in ImageCodecInfo")
  End Function

  Private Sub tvX9_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvX9.AfterSelect
    Dim rec As x9Rec = x9Stuff(e.Node.Name)
    Static cur25Rec As Integer = 0
    txtRec.Text = rec.recData
    Dim iRecType As Integer
    Integer.TryParse(rec.recType, iRecType)
    dgvFields.Rows.Clear()
    Dim fieldNodes As XmlNodeList
    Dim fieldStart As Integer
    Dim fieldLen As Integer
    fieldNodes = xmlFields.SelectNodes("records/record[@type='" & rec.recType & "']/field")
    If fieldNodes IsNot Nothing Then
      For Each n As XmlNode In fieldNodes
        fieldStart = CInt(n.Attributes("start").Value) - 1
        fieldLen = CInt(n.Attributes("end").Value) - fieldStart
        dgvFields.Rows.Add(n.Attributes("name").Value, rec.recData.Substring(fieldStart, fieldLen), _
                           n.Attributes("type").Value, n.Attributes("comments").Value)
      Next
    End If
    If iRecType >= 25 And iRecType < 70 AndAlso My.Settings.checkImage Then
      Dim curRec As Integer
      Dim frontImg, backImg As String
      Integer.TryParse(e.Node.Name, curRec)
      Dim imgRec As x9Rec = x9Stuff(curRec)
      Do Until imgRec.recType = 25 OrElse curRec < 0
        curRec -= 1
        imgRec = x9Stuff(curRec)
      Loop
      If curRec < 0 Or curRec = cur25Rec Then
        Exit Sub
      End If
      If curRec >= 0 Then
        cur25Rec = curRec
        ' move forward to first 52
        Do Until imgRec.recType = 52 OrElse curRec > x9Stuff.Count
          curRec += 1
          imgRec = x9Stuff(curRec)
        Loop
        If curRec < x9Stuff.Count Then
          frontImg = imgRec.recImage
          ' move forward to second 52
          curRec += 1
          imgRec = x9Stuff(curRec)
          Do Until imgRec.recType = 52 OrElse curRec > x9Stuff.Count
            curRec += 1
            imgRec = x9Stuff(curRec)
          Loop
          If curRec < x9Stuff.Count Then
            backImg = imgRec.recImage
          End If
        End If
      End If
      If tcX9.TabPages.Count < 2 Then
        tcX9.TabPages.Add(tpImg)
      End If
      pbCheck.Visible = False
      pbFront.Visible = True
      Dim fImg, bImg As Image
      Dim startPos As Integer = CInt(frontImg.Substring(0, frontImg.IndexOf(",")))
      Dim imgLen As Integer = CInt(frontImg.Substring(frontImg.IndexOf(",") + 1))
      Dim recB(imgLen) As Byte
      checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin)
      recB = checkImageBR.ReadBytes(imgLen)
      Byte2Image(fImg, recB, 0)
      pbFront.Image = fImg
      'pbFront.ImageLocation = frontImg
      pbBack.Visible = True
      startPos = CInt(backImg.Substring(0, backImg.IndexOf(",")))
      imgLen = CInt(backImg.Substring(backImg.IndexOf(",") + 1))
      ReDim recB(imgLen)
      checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin)
      recB = checkImageBR.ReadBytes(imgLen)
      Byte2Image(bImg, recB, 0)
      pbBack.Image = bImg
    Else
      pbBack.Visible = False
      pbFront.Visible = False
      pbCheck.Visible = True
      If rec.recImage.Length = 0 Then
        If tcX9.TabPages.Count > 1 Then
          tcX9.TabPages.RemoveAt(1)
        End If
      Else
        If tcX9.TabPages.Count < 2 Then
          tcX9.TabPages.Add(tpImg)
        End If
        Dim cImg As Image
        Dim startPos As Integer = CInt(rec.recImage.Substring(0, rec.recImage.IndexOf(",")))
        Dim imgLen As Integer = CInt(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1))
        Dim recB(imgLen) As Byte
        checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin)
        recB = checkImageBR.ReadBytes(imgLen)
        Byte2Image(cImg, recB, 0)
        pbFront.Image = cImg
        'pbCheck.ImageLocation = rec.recImage
      End If
    End If
  End Sub

  Private Sub txtRec_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRec.GotFocus
    lblPos.Text = "column: " & (txtRec.SelectionStart + 1).ToString
  End Sub

  Private Sub txtRec_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRec.KeyUp
    lblPos.Text = "column: " & (txtRec.SelectionStart + 1).ToString
  End Sub

  Private Sub frmViewer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    'If My.Settings.ClosePrompt AndAlso MessageBox.Show("Close X9.37 viewer?", "nsX9Viewer Close", Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    If My.Settings.ClosePrompt = False OrElse (My.Settings.ClosePrompt AndAlso frmClose.ShowDialog() = Windows.Forms.DialogResult.Yes) Then
      Try
        Application.DoEvents()
        Dim cleanup As New Closing
        cleanup.Show()
        Dim ix As Integer = 0
        'For Each r As x9Rec In x9Stuff
        '  If r.recImage.Length > 0 Then
        '    If File.Exists(r.recImage) Then
        '      File.Delete(r.recImage)
        '    End If
        '  End If
        '  ix += 1
        '  If ix Mod 1000 = 0 Then
        '    cleanup.pbCleanup.Value = (ix / x9Stuff.Count) * 100
        '    Application.DoEvents()
        '  End If
        'Next
        checkImageBR.Close()
        checkImageFS.Close()
        File.Delete(allImgFile)
        cleanup.Close()
      Catch ex As Exception

      End Try
    Else
      e.Cancel = True
    End If
  End Sub

  Private Sub frmViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Me.Show()
    If ofdX9.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.Cursor = Cursors.WaitCursor
      progbLoad.Visible = True
      lblLoad.Visible = True
      ShowX9File(ofdX9.FileName)
      progbLoad.Visible = False
      lblLoad.Visible = False
      Me.Cursor = Cursors.Default
      lblFile.Text = ofdX9.FileName
    End If
    If File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "x9fields.xml")) Then
      xmlFields.Load(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "x9fields.xml"))
    End If
  End Sub

  Private Sub txtRec_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRec.LostFocus
    lblPos.Text = ""
  End Sub

  Private Sub txtRec_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtRec.MouseClick
    lblPos.Text = "column: " & (txtRec.SelectionStart + 1).ToString
  End Sub

  Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
    AboutBox.ShowDialog()
  End Sub

  Private Sub CopyToClipboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToClipboardToolStripMenuItem.Click
    Clipboard.SetImage(pbCheck.Image)
  End Sub

  Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
    If sfdImg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
      pbCheck.Image.Save(sfdImg.FileName)
    End If
  End Sub

  Private Sub mnuiCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuiCopy.Click
    My.Computer.Clipboard.Clear()
    If TypeOf ActiveControl Is TextBox Then
      My.Computer.Clipboard.SetText(CType(ActiveControl, TextBox).SelectedText)
    ElseIf TypeOf ActiveControl Is ComboBox Then
      My.Computer.Clipboard.SetText(CType(ActiveControl, ComboBox).Text)
    ElseIf TypeOf ActiveControl Is PictureBox Then
      My.Computer.Clipboard.SetImage(CType(ActiveControl, PictureBox).Image)
    ElseIf TypeOf ActiveControl Is ListBox Then
      My.Computer.Clipboard.SetText(CType(ActiveControl, ListBox).Text)
    ElseIf TypeOf ActiveControl Is TreeView Then
      My.Computer.Clipboard.SetText(CType(ActiveControl, TreeView).SelectedNode.Text)
    ElseIf TypeOf ActiveControl Is DataGridView Then
      My.Computer.Clipboard.SetDataObject(CType(ActiveControl, DataGridView).GetClipboardContent)
    Else
      ' No action makes sense for the other controls.
    End If
  End Sub

  Private Sub mnuiOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuiOptions.Click
    If frmOpt.ShowDialog = Windows.Forms.DialogResult.OK Then
      setNodeColor(tvX9.Nodes)
    End If
  End Sub

  Private Sub setNodeColor(ByVal tvNodes As TreeNodeCollection)
    For Each tn As TreeNode In tvNodes
      If tn.Text.EndsWith("(01)") OrElse tn.Text.EndsWith("(99)") Then
        tn.ForeColor = My.Settings.color01
      ElseIf tn.Text.EndsWith("(10)") OrElse tn.Text.EndsWith("(90)") Then
        tn.ForeColor = My.Settings.color10
      ElseIf tn.Text.EndsWith("(20)") OrElse tn.Text.EndsWith("(70)") Then
        tn.ForeColor = My.Settings.color20
      Else
        tn.ForeColor = My.Settings.color25
      End If
      If tn.Nodes.Count > 0 Then
        setNodeColor(tn.Nodes)
      End If
    Next
  End Sub

  Private Sub SearchToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    Search.TopMost = True
    Search.Show()
  End Sub

  Private Sub ExportImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportImagesToolStripMenuItem.Click
    If sfdImg.ShowDialog = Windows.Forms.DialogResult.OK Then
      JoinTiffImages2(sfdImg.FileName, EncoderValue.CompressionCCITT4)
    End If
  End Sub

  Private Sub SearchToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
    Search.TopMost = True
    Search.Show()
  End Sub

  Private Sub ExportFrontImagesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExportFrontImagesToolStripMenuItem.Click
    If sfdImg.ShowDialog = Windows.Forms.DialogResult.OK Then
      JoinTiffImages3(sfdImg.FileName, EncoderValue.CompressionCCITT4)
    End If
  End Sub
End Class
