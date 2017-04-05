Imports System.Windows.Forms
Imports System.Xml

Public Class Search

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Dim textFound As Boolean = False
    Me.Cursor = Cursors.WaitCursor
    If rbGeneral.Checked Then
      If tbGenSearch.Text.Trim.Length > 0 Then
        For i As Integer = If(frmViewer.tvX9.SelectedNode Is Nothing, 0, CInt(frmViewer.tvX9.SelectedNode.Name)) To frmViewer.x9Stuff.Count - 1
          If frmViewer.x9Stuff(i).recData.IndexOf(tbGenSearch.Text) >= 0 Then
            frmViewer.tvX9.SelectedNode = frmViewer.tvX9.Nodes.Find(i.ToString, True)(0)
            textFound = True
            Exit For
          End If
        Next
      End If
    Else
      If tbTSearch.Text.Trim.Length > 0 Then
        Dim rType As String = cboRecType.SelectedItem.Substring(0, cboRecType.SelectedItem.IndexOf(" "))
        Dim fNode As XmlNode = frmViewer.xmlFields.SelectSingleNode("records/record[@type='" & rType & "']/field[@name='" & cboField.SelectedItem & "']")
        Dim sField As String
        Dim fieldStart As Integer
        Dim fieldLen As Integer
        For i As Integer = If(frmViewer.tvX9.SelectedNode Is Nothing, 0, CInt(frmViewer.tvX9.SelectedNode.Name)) To frmViewer.x9Stuff.Count - 1
          If frmViewer.x9Stuff(i).recType = rType Then
            If fNode IsNot Nothing Then
              fieldStart = CInt(fNode.Attributes("start").Value) - 1
              fieldLen = CInt(fNode.Attributes("end").Value) - fieldStart
              sField = frmViewer.x9Stuff(i).recData.Substring(fieldStart, fieldLen)
              If sField.IndexOf(tbTSearch.Text) >= 0 Then
                frmViewer.tvX9.SelectedNode = frmViewer.tvX9.Nodes.Find(i.ToString, True)(0)
                textFound = True
                Exit For
              End If
            End If
          End If
        Next
      End If
    End If
    Me.Cursor = Cursors.Default
    If Not textFound Then
      MessageBox.Show("Search text not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub rbTargetted_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTargetted.CheckedChanged
    If rbTargetted.Checked Then
      pnlTSearch.Enabled = True
      Application.DoEvents()
      If cboRecType.Items.Count = 0 Then
        ' Load record types
        Dim xmlDoc As XmlDocument = frmViewer.xmlFields
        For Each n As XmlNode In xmlDoc.SelectNodes("records/record")
          cboRecType.Items.Add(n.Attributes("type").Value & " " & n.Attributes("name").Value)
        Next
        cboRecType.SelectedIndex = 0
        Application.DoEvents()
        loadFields()
        cboRecType.Focus()
      End If
    End If
  End Sub

  Private Sub loadFields()
    Dim xmlDoc As XmlDocument = frmViewer.xmlFields
    cboField.Items.Clear()
    If cboRecType.SelectedIndex >= 0 Then
      For Each n As XmlNode In xmlDoc.SelectNodes("records/record[@type='" & cboRecType.SelectedItem.Substring(0, cboRecType.SelectedItem.IndexOf(" ")) & "']/field")
        cboField.Items.Add(n.Attributes("name").Value)
      Next
    End If
  End Sub

  Private Sub cboRecType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecType.SelectedIndexChanged
    loadFields()
  End Sub

  Private Sub rbGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGeneral.CheckedChanged
    If rbGeneral.Checked Then
      pnlTSearch.Enabled = False
      tbGenSearch.Focus()
    End If
  End Sub
End Class
