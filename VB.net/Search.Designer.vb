<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Search
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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.btnSearch = New System.Windows.Forms.Button
    Me.btnClose = New System.Windows.Forms.Button
    Me.rbGeneral = New System.Windows.Forms.RadioButton
    Me.rbTargetted = New System.Windows.Forms.RadioButton
    Me.Label1 = New System.Windows.Forms.Label
    Me.tbGenSearch = New System.Windows.Forms.TextBox
    Me.pnlTSearch = New System.Windows.Forms.Panel
    Me.tbTSearch = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.cboField = New System.Windows.Forms.ComboBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.cboRecType = New System.Windows.Forms.ComboBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1.SuspendLayout()
    Me.pnlTSearch.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.btnSearch, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.btnClose, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 274)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'btnSearch
    '
    Me.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnSearch.Location = New System.Drawing.Point(3, 3)
    Me.btnSearch.Name = "btnSearch"
    Me.btnSearch.Size = New System.Drawing.Size(67, 23)
    Me.btnSearch.TabIndex = 0
    Me.btnSearch.Text = "&Search"
    '
    'btnClose
    '
    Me.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnClose.Location = New System.Drawing.Point(76, 3)
    Me.btnClose.Name = "btnClose"
    Me.btnClose.Size = New System.Drawing.Size(67, 23)
    Me.btnClose.TabIndex = 1
    Me.btnClose.Text = "&Close"
    '
    'rbGeneral
    '
    Me.rbGeneral.AutoSize = True
    Me.rbGeneral.Checked = True
    Me.rbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbGeneral.Location = New System.Drawing.Point(12, 25)
    Me.rbGeneral.Name = "rbGeneral"
    Me.rbGeneral.Size = New System.Drawing.Size(113, 17)
    Me.rbGeneral.TabIndex = 1
    Me.rbGeneral.TabStop = True
    Me.rbGeneral.Text = "General Search"
    Me.rbGeneral.UseVisualStyleBackColor = True
    '
    'rbTargetted
    '
    Me.rbTargetted.AutoSize = True
    Me.rbTargetted.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.rbTargetted.Location = New System.Drawing.Point(12, 107)
    Me.rbTargetted.Name = "rbTargetted"
    Me.rbTargetted.Size = New System.Drawing.Size(124, 17)
    Me.rbTargetted.TabIndex = 2
    Me.rbTargetted.Text = "Targetted Search"
    Me.rbTargetted.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(33, 55)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(201, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Search for text in any record type:"
    '
    'tbGenSearch
    '
    Me.tbGenSearch.Location = New System.Drawing.Point(36, 71)
    Me.tbGenSearch.Name = "tbGenSearch"
    Me.tbGenSearch.Size = New System.Drawing.Size(387, 20)
    Me.tbGenSearch.TabIndex = 4
    '
    'pnlTSearch
    '
    Me.pnlTSearch.Controls.Add(Me.tbTSearch)
    Me.pnlTSearch.Controls.Add(Me.Label4)
    Me.pnlTSearch.Controls.Add(Me.cboField)
    Me.pnlTSearch.Controls.Add(Me.Label3)
    Me.pnlTSearch.Controls.Add(Me.cboRecType)
    Me.pnlTSearch.Controls.Add(Me.Label2)
    Me.pnlTSearch.Enabled = False
    Me.pnlTSearch.Location = New System.Drawing.Point(21, 130)
    Me.pnlTSearch.Name = "pnlTSearch"
    Me.pnlTSearch.Size = New System.Drawing.Size(399, 117)
    Me.pnlTSearch.TabIndex = 7
    '
    'tbTSearch
    '
    Me.tbTSearch.Location = New System.Drawing.Point(6, 82)
    Me.tbTSearch.Name = "tbTSearch"
    Me.tbTSearch.Size = New System.Drawing.Size(384, 20)
    Me.tbTSearch.TabIndex = 12
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(3, 66)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 13)
    Me.Label4.TabIndex = 11
    Me.Label4.Text = "Search Text:"
    '
    'cboField
    '
    Me.cboField.FormattingEnabled = True
    Me.cboField.Location = New System.Drawing.Point(93, 38)
    Me.cboField.Name = "cboField"
    Me.cboField.Size = New System.Drawing.Size(297, 21)
    Me.cboField.TabIndex = 10
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(3, 41)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(74, 13)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "Field Name:"
    '
    'cboRecType
    '
    Me.cboRecType.FormattingEnabled = True
    Me.cboRecType.Location = New System.Drawing.Point(93, 7)
    Me.cboRecType.Name = "cboRecType"
    Me.cboRecType.Size = New System.Drawing.Size(297, 21)
    Me.cboRecType.TabIndex = 8
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(3, 10)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(84, 13)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "Record Type:"
    '
    'Search
    '
    Me.AcceptButton = Me.btnSearch
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.btnClose
    Me.ClientSize = New System.Drawing.Size(435, 315)
    Me.Controls.Add(Me.pnlTSearch)
    Me.Controls.Add(Me.tbGenSearch)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.rbTargetted)
    Me.Controls.Add(Me.rbGeneral)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Search"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Search"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.pnlTSearch.ResumeLayout(False)
    Me.pnlTSearch.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents btnClose As System.Windows.Forms.Button
  Friend WithEvents rbGeneral As System.Windows.Forms.RadioButton
  Friend WithEvents rbTargetted As System.Windows.Forms.RadioButton
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents tbGenSearch As System.Windows.Forms.TextBox
  Friend WithEvents pnlTSearch As System.Windows.Forms.Panel
  Friend WithEvents tbTSearch As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents cboField As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cboRecType As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
