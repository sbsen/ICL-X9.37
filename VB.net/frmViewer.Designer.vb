<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewer))
    Me.mnuMain = New System.Windows.Forms.MenuStrip
    Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
    Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuiCopy = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
    Me.mnuiOptions = New System.Windows.Forms.ToolStripMenuItem
    Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.ExportImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.tvX9 = New System.Windows.Forms.TreeView
    Me.ofdX9 = New System.Windows.Forms.OpenFileDialog
    Me.lblFile = New System.Windows.Forms.Label
    Me.tpImg = New System.Windows.Forms.TabPage
    Me.pbCheck = New System.Windows.Forms.PictureBox
    Me.cmsImg = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.CopyToClipboardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
    Me.pbFront = New System.Windows.Forms.PictureBox
    Me.pbBack = New System.Windows.Forms.PictureBox
    Me.tpData = New System.Windows.Forms.TabPage
    Me.Label1 = New System.Windows.Forms.Label
    Me.dgvFields = New System.Windows.Forms.DataGridView
    Me.fieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fieldValue = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fieldType = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.fieldDetail = New System.Windows.Forms.DataGridViewTextBoxColumn
    Me.lblPos = New System.Windows.Forms.Label
    Me.txtRec = New System.Windows.Forms.TextBox
    Me.tcX9 = New System.Windows.Forms.TabControl
    Me.sfdImg = New System.Windows.Forms.SaveFileDialog
    Me.progbLoad = New System.Windows.Forms.ProgressBar
    Me.lblLoad = New System.Windows.Forms.Label
    Me.ExportFrontImagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
    Me.mnuMain.SuspendLayout()
    Me.tpImg.SuspendLayout()
    CType(Me.pbCheck, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.cmsImg.SuspendLayout()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.pbFront, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pbBack, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tpData.SuspendLayout()
    CType(Me.dgvFields, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.tcX9.SuspendLayout()
    Me.SuspendLayout()
    '
    'mnuMain
    '
    Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem})
    Me.mnuMain.Location = New System.Drawing.Point(0, 0)
    Me.mnuMain.Name = "mnuMain"
    Me.mnuMain.Size = New System.Drawing.Size(917, 24)
    Me.mnuMain.TabIndex = 0
    Me.mnuMain.Text = "MenuStrip1"
    '
    'FileToolStripMenuItem
    '
    Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
    Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
    Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
    Me.FileToolStripMenuItem.Text = "&File"
    '
    'OpenToolStripMenuItem
    '
    Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
    Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
    Me.OpenToolStripMenuItem.Text = "&Open"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(108, 6)
    '
    'ExitToolStripMenuItem
    '
    Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
    Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(111, 22)
    Me.ExitToolStripMenuItem.Text = "E&xit"
    '
    'EditToolStripMenuItem
    '
    Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuiCopy, Me.ToolStripSeparator2, Me.mnuiOptions})
    Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
    Me.EditToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
    Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
    Me.EditToolStripMenuItem.Text = "&Edit"
    '
    'mnuiCopy
    '
    Me.mnuiCopy.Name = "mnuiCopy"
    Me.mnuiCopy.Size = New System.Drawing.Size(137, 22)
    Me.mnuiCopy.Text = "&Copy"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(134, 6)
    '
    'mnuiOptions
    '
    Me.mnuiOptions.Name = "mnuiOptions"
    Me.mnuiOptions.Size = New System.Drawing.Size(137, 22)
    Me.mnuiOptions.Text = "Options ..."
    '
    'ToolsToolStripMenuItem
    '
    Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.ExportImagesToolStripMenuItem, Me.ExportFrontImagesToolStripMenuItem})
    Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
    Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
    Me.ToolsToolStripMenuItem.Text = "&Tools"
    '
    'SearchToolStripMenuItem
    '
    Me.SearchToolStripMenuItem.Enabled = False
    Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
    Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
    Me.SearchToolStripMenuItem.Text = "&Search"
    '
    'ExportImagesToolStripMenuItem
    '
    Me.ExportImagesToolStripMenuItem.Name = "ExportImagesToolStripMenuItem"
    Me.ExportImagesToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
    Me.ExportImagesToolStripMenuItem.Text = "E&xport Images"
    '
    'AboutToolStripMenuItem
    '
    Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
    Me.AboutToolStripMenuItem.Text = "&About"
    '
    'tvX9
    '
    Me.tvX9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.tvX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.tvX9.HideSelection = False
    Me.tvX9.Location = New System.Drawing.Point(5, 55)
    Me.tvX9.Name = "tvX9"
    Me.tvX9.Size = New System.Drawing.Size(243, 489)
    Me.tvX9.TabIndex = 1
    '
    'ofdX9
    '
    Me.ofdX9.DefaultExt = "dat"
    Me.ofdX9.Filter = "X9 DAT files (*.dat)|*.dat|All files (*.*)|*.*"
    Me.ofdX9.Title = "Select X9 file to view"
    '
    'lblFile
    '
    Me.lblFile.AutoSize = True
    Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblFile.Location = New System.Drawing.Point(13, 29)
    Me.lblFile.Name = "lblFile"
    Me.lblFile.Size = New System.Drawing.Size(0, 13)
    Me.lblFile.TabIndex = 2
    '
    'tpImg
    '
    Me.tpImg.Controls.Add(Me.pbCheck)
    Me.tpImg.Controls.Add(Me.SplitContainer1)
    Me.tpImg.Location = New System.Drawing.Point(4, 22)
    Me.tpImg.Name = "tpImg"
    Me.tpImg.Padding = New System.Windows.Forms.Padding(3)
    Me.tpImg.Size = New System.Drawing.Size(659, 463)
    Me.tpImg.TabIndex = 1
    Me.tpImg.Text = "Check Image"
    Me.tpImg.UseVisualStyleBackColor = True
    '
    'pbCheck
    '
    Me.pbCheck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pbCheck.ContextMenuStrip = Me.cmsImg
    Me.pbCheck.Location = New System.Drawing.Point(3, 26)
    Me.pbCheck.Name = "pbCheck"
    Me.pbCheck.Size = New System.Drawing.Size(653, 304)
    Me.pbCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.pbCheck.TabIndex = 0
    Me.pbCheck.TabStop = False
    '
    'cmsImg
    '
    Me.cmsImg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToClipboardToolStripMenuItem, Me.SaveAsToolStripMenuItem})
    Me.cmsImg.Name = "cmsImg"
    Me.cmsImg.Size = New System.Drawing.Size(170, 48)
    '
    'CopyToClipboardToolStripMenuItem
    '
    Me.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem"
    Me.CopyToClipboardToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.CopyToClipboardToolStripMenuItem.Text = "&Copy to clipboard"
    '
    'SaveAsToolStripMenuItem
    '
    Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
    Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
    Me.SaveAsToolStripMenuItem.Text = "&Save As ..."
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.pbFront)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.pbBack)
    Me.SplitContainer1.Size = New System.Drawing.Size(659, 463)
    Me.SplitContainer1.SplitterDistance = 218
    Me.SplitContainer1.TabIndex = 3
    '
    'pbFront
    '
    Me.pbFront.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pbFront.ContextMenuStrip = Me.cmsImg
    Me.pbFront.Location = New System.Drawing.Point(3, -2)
    Me.pbFront.Name = "pbFront"
    Me.pbFront.Size = New System.Drawing.Size(653, 227)
    Me.pbFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.pbFront.TabIndex = 3
    Me.pbFront.TabStop = False
    '
    'pbBack
    '
    Me.pbBack.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pbBack.ContextMenuStrip = Me.cmsImg
    Me.pbBack.Location = New System.Drawing.Point(3, 9)
    Me.pbBack.Name = "pbBack"
    Me.pbBack.Size = New System.Drawing.Size(653, 224)
    Me.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.pbBack.TabIndex = 2
    Me.pbBack.TabStop = False
    '
    'tpData
    '
    Me.tpData.Controls.Add(Me.Label1)
    Me.tpData.Controls.Add(Me.dgvFields)
    Me.tpData.Controls.Add(Me.lblPos)
    Me.tpData.Controls.Add(Me.txtRec)
    Me.tpData.Location = New System.Drawing.Point(4, 22)
    Me.tpData.Name = "tpData"
    Me.tpData.Padding = New System.Windows.Forms.Padding(3)
    Me.tpData.Size = New System.Drawing.Size(659, 463)
    Me.tpData.TabIndex = 0
    Me.tpData.Text = "Data"
    Me.tpData.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 72)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(44, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Fields:"
    '
    'dgvFields
    '
    Me.dgvFields.AllowUserToAddRows = False
    Me.dgvFields.AllowUserToDeleteRows = False
    Me.dgvFields.AllowUserToOrderColumns = True
    Me.dgvFields.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.dgvFields.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.fieldName, Me.fieldValue, Me.fieldType, Me.fieldDetail})
    Me.dgvFields.Location = New System.Drawing.Point(6, 88)
    Me.dgvFields.Name = "dgvFields"
    Me.dgvFields.RowTemplate.Height = 52
    Me.dgvFields.Size = New System.Drawing.Size(645, 363)
    Me.dgvFields.TabIndex = 2
    '
    'fieldName
    '
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.fieldName.DefaultCellStyle = DataGridViewCellStyle1
    Me.fieldName.HeaderText = "Name"
    Me.fieldName.Name = "fieldName"
    '
    'fieldValue
    '
    Me.fieldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
    Me.fieldValue.HeaderText = "Value"
    Me.fieldValue.Name = "fieldValue"
    Me.fieldValue.ReadOnly = True
    Me.fieldValue.Width = 59
    '
    'fieldType
    '
    Me.fieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
    Me.fieldType.HeaderText = "Type"
    Me.fieldType.Name = "fieldType"
    Me.fieldType.ReadOnly = True
    Me.fieldType.Width = 56
    '
    'fieldDetail
    '
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
    DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.fieldDetail.DefaultCellStyle = DataGridViewCellStyle2
    Me.fieldDetail.FillWeight = 300.0!
    Me.fieldDetail.HeaderText = "Comments"
    Me.fieldDetail.Name = "fieldDetail"
    Me.fieldDetail.Width = 300
    '
    'lblPos
    '
    Me.lblPos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblPos.AutoSize = True
    Me.lblPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos.Location = New System.Drawing.Point(580, 59)
    Me.lblPos.Name = "lblPos"
    Me.lblPos.Size = New System.Drawing.Size(0, 13)
    Me.lblPos.TabIndex = 1
    '
    'txtRec
    '
    Me.txtRec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtRec.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtRec.Location = New System.Drawing.Point(6, 6)
    Me.txtRec.Multiline = True
    Me.txtRec.Name = "txtRec"
    Me.txtRec.Size = New System.Drawing.Size(645, 50)
    Me.txtRec.TabIndex = 0
    '
    'tcX9
    '
    Me.tcX9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tcX9.Controls.Add(Me.tpData)
    Me.tcX9.Controls.Add(Me.tpImg)
    Me.tcX9.Location = New System.Drawing.Point(250, 55)
    Me.tcX9.Name = "tcX9"
    Me.tcX9.SelectedIndex = 0
    Me.tcX9.Size = New System.Drawing.Size(667, 489)
    Me.tcX9.TabIndex = 3
    '
    'sfdImg
    '
    Me.sfdImg.DefaultExt = "tiff"
    Me.sfdImg.Filter = "Tiff Files (*.tif)|*.tif"
    Me.sfdImg.Title = "Save check image as"
    '
    'progbLoad
    '
    Me.progbLoad.Location = New System.Drawing.Point(341, 28)
    Me.progbLoad.Name = "progbLoad"
    Me.progbLoad.Size = New System.Drawing.Size(286, 23)
    Me.progbLoad.TabIndex = 4
    '
    'lblLoad
    '
    Me.lblLoad.AutoSize = True
    Me.lblLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblLoad.Location = New System.Drawing.Point(633, 34)
    Me.lblLoad.Name = "lblLoad"
    Me.lblLoad.Size = New System.Drawing.Size(0, 17)
    Me.lblLoad.TabIndex = 5
    '
    'ExportFrontImagesToolStripMenuItem
    '
    Me.ExportFrontImagesToolStripMenuItem.Name = "ExportFrontImagesToolStripMenuItem"
    Me.ExportFrontImagesToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
    Me.ExportFrontImagesToolStripMenuItem.Text = "Export Front images"
    '
    'frmViewer
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(917, 547)
    Me.Controls.Add(Me.lblLoad)
    Me.Controls.Add(Me.progbLoad)
    Me.Controls.Add(Me.tcX9)
    Me.Controls.Add(Me.lblFile)
    Me.Controls.Add(Me.tvX9)
    Me.Controls.Add(Me.mnuMain)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MainMenuStrip = Me.mnuMain
    Me.Name = "frmViewer"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "nsX9Viewer"
    Me.mnuMain.ResumeLayout(False)
    Me.mnuMain.PerformLayout()
    Me.tpImg.ResumeLayout(False)
    CType(Me.pbCheck, System.ComponentModel.ISupportInitialize).EndInit()
    Me.cmsImg.ResumeLayout(False)
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.pbFront, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pbBack, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tpData.ResumeLayout(False)
    Me.tpData.PerformLayout()
    CType(Me.dgvFields, System.ComponentModel.ISupportInitialize).EndInit()
    Me.tcX9.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
  Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents tvX9 As System.Windows.Forms.TreeView
  Friend WithEvents ofdX9 As System.Windows.Forms.OpenFileDialog
  Friend WithEvents lblFile As System.Windows.Forms.Label
  Friend WithEvents tpImg As System.Windows.Forms.TabPage
  Friend WithEvents tpData As System.Windows.Forms.TabPage
  Friend WithEvents tcX9 As System.Windows.Forms.TabControl
  Friend WithEvents lblPos As System.Windows.Forms.Label
  Friend WithEvents txtRec As System.Windows.Forms.TextBox
  Friend WithEvents pbCheck As System.Windows.Forms.PictureBox
  Friend WithEvents dgvFields As System.Windows.Forms.DataGridView
  Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents fieldName As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fieldValue As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fieldType As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents fieldDetail As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents cmsImg As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents CopyToClipboardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents sfdImg As System.Windows.Forms.SaveFileDialog
  Friend WithEvents progbLoad As System.Windows.Forms.ProgressBar
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuiCopy As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents mnuiOptions As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents lblLoad As System.Windows.Forms.Label
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents pbFront As System.Windows.Forms.PictureBox
  Friend WithEvents pbBack As System.Windows.Forms.PictureBox
  Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ExportImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ExportFrontImagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
