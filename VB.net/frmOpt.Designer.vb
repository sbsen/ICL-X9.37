<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpt
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
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.btnReset = New System.Windows.Forms.Button
    Me.OK_Button = New System.Windows.Forms.Button
    Me.tcOpt = New System.Windows.Forms.TabControl
    Me.tpColor = New System.Windows.Forms.TabPage
    Me.btnColor25 = New System.Windows.Forms.Button
    Me.Label5 = New System.Windows.Forms.Label
    Me.btnColor20 = New System.Windows.Forms.Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.btnColor10 = New System.Windows.Forms.Button
    Me.Label3 = New System.Windows.Forms.Label
    Me.btnColor01 = New System.Windows.Forms.Button
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.tpDisp = New System.Windows.Forms.TabPage
    Me.cbItemNumber = New System.Windows.Forms.CheckBox
    Me.cbFrontBack = New System.Windows.Forms.CheckBox
    Me.cbCheckImage = New System.Windows.Forms.CheckBox
    Me.colorRec = New System.Windows.Forms.ColorDialog
    Me.cbClosePrompt = New System.Windows.Forms.CheckBox
    Me.TableLayoutPanel1.SuspendLayout()
    Me.tcOpt.SuspendLayout()
    Me.tpColor.SuspendLayout()
    Me.tpDisp.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 3
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.btnReset, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(208, 190)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(167, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(113, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(51, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Cancel"
    '
    'btnReset
    '
    Me.btnReset.Location = New System.Drawing.Point(3, 3)
    Me.btnReset.Name = "btnReset"
    Me.btnReset.Size = New System.Drawing.Size(49, 23)
    Me.btnReset.TabIndex = 2
    Me.btnReset.Text = "&Reset"
    Me.btnReset.UseVisualStyleBackColor = True
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Location = New System.Drawing.Point(58, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(49, 23)
    Me.OK_Button.TabIndex = 0
    Me.OK_Button.Text = "OK"
    '
    'tcOpt
    '
    Me.tcOpt.Controls.Add(Me.tpColor)
    Me.tcOpt.Controls.Add(Me.tpDisp)
    Me.tcOpt.Location = New System.Drawing.Point(0, 0)
    Me.tcOpt.Name = "tcOpt"
    Me.tcOpt.SelectedIndex = 0
    Me.tcOpt.Size = New System.Drawing.Size(377, 183)
    Me.tcOpt.TabIndex = 1
    '
    'tpColor
    '
    Me.tpColor.Controls.Add(Me.btnColor25)
    Me.tpColor.Controls.Add(Me.Label5)
    Me.tpColor.Controls.Add(Me.btnColor20)
    Me.tpColor.Controls.Add(Me.Label4)
    Me.tpColor.Controls.Add(Me.btnColor10)
    Me.tpColor.Controls.Add(Me.Label3)
    Me.tpColor.Controls.Add(Me.btnColor01)
    Me.tpColor.Controls.Add(Me.Label2)
    Me.tpColor.Controls.Add(Me.Label1)
    Me.tpColor.Location = New System.Drawing.Point(4, 22)
    Me.tpColor.Name = "tpColor"
    Me.tpColor.Padding = New System.Windows.Forms.Padding(3)
    Me.tpColor.Size = New System.Drawing.Size(369, 157)
    Me.tpColor.TabIndex = 0
    Me.tpColor.Text = "Rec Type"
    Me.tpColor.UseVisualStyleBackColor = True
    '
    'btnColor25
    '
    Me.btnColor25.Location = New System.Drawing.Point(255, 110)
    Me.btnColor25.Name = "btnColor25"
    Me.btnColor25.Size = New System.Drawing.Size(75, 22)
    Me.btnColor25.TabIndex = 8
    Me.btnColor25.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(6, 115)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(142, 13)
    Me.Label5.TabIndex = 7
    Me.Label5.Text = "Check Records (25-69):"
    '
    'btnColor20
    '
    Me.btnColor20.Location = New System.Drawing.Point(255, 83)
    Me.btnColor20.Name = "btnColor20"
    Me.btnColor20.Size = New System.Drawing.Size(75, 22)
    Me.btnColor20.TabIndex = 6
    Me.btnColor20.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(6, 88)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(183, 13)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "Bundle Header/Footer (20/70):"
    '
    'btnColor10
    '
    Me.btnColor10.Location = New System.Drawing.Point(255, 55)
    Me.btnColor10.Name = "btnColor10"
    Me.btnColor10.Size = New System.Drawing.Size(75, 22)
    Me.btnColor10.TabIndex = 4
    Me.btnColor10.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(6, 60)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(209, 13)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "Cash Letter Header/Footer (10/90):"
    '
    'btnColor01
    '
    Me.btnColor01.Location = New System.Drawing.Point(255, 27)
    Me.btnColor01.Name = "btnColor01"
    Me.btnColor01.Size = New System.Drawing.Size(75, 22)
    Me.btnColor01.TabIndex = 2
    Me.btnColor01.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(6, 32)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(140, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Header/Footer (01/99):"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(6, 3)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(178, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Select colors for record types:"
    '
    'tpDisp
    '
    Me.tpDisp.Controls.Add(Me.cbClosePrompt)
    Me.tpDisp.Controls.Add(Me.cbItemNumber)
    Me.tpDisp.Controls.Add(Me.cbFrontBack)
    Me.tpDisp.Controls.Add(Me.cbCheckImage)
    Me.tpDisp.Location = New System.Drawing.Point(4, 22)
    Me.tpDisp.Name = "tpDisp"
    Me.tpDisp.Padding = New System.Windows.Forms.Padding(3)
    Me.tpDisp.Size = New System.Drawing.Size(369, 157)
    Me.tpDisp.TabIndex = 1
    Me.tpDisp.Text = "Display"
    Me.tpDisp.UseVisualStyleBackColor = True
    '
    'cbItemNumber
    '
    Me.cbItemNumber.AutoSize = True
    Me.cbItemNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cbItemNumber.Location = New System.Drawing.Point(8, 85)
    Me.cbItemNumber.Name = "cbItemNumber"
    Me.cbItemNumber.Size = New System.Drawing.Size(132, 17)
    Me.cbItemNumber.TabIndex = 2
    Me.cbItemNumber.Text = "Show &Item Number"
    Me.cbItemNumber.UseVisualStyleBackColor = True
    '
    'cbFrontBack
    '
    Me.cbFrontBack.AutoSize = True
    Me.cbFrontBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cbFrontBack.Location = New System.Drawing.Point(8, 54)
    Me.cbFrontBack.Name = "cbFrontBack"
    Me.cbFrontBack.Size = New System.Drawing.Size(227, 17)
    Me.cbFrontBack.TabIndex = 1
    Me.cbFrontBack.Text = "Show &both front and back of check"
    Me.cbFrontBack.UseVisualStyleBackColor = True
    '
    'cbCheckImage
    '
    Me.cbCheckImage.AutoSize = True
    Me.cbCheckImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cbCheckImage.Location = New System.Drawing.Point(8, 23)
    Me.cbCheckImage.Name = "cbCheckImage"
    Me.cbCheckImage.Size = New System.Drawing.Size(316, 17)
    Me.cbCheckImage.TabIndex = 0
    Me.cbCheckImage.Text = "Show check &image when I select any check record"
    Me.cbCheckImage.UseVisualStyleBackColor = True
    '
    'cbClosePrompt
    '
    Me.cbClosePrompt.AutoSize = True
    Me.cbClosePrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cbClosePrompt.Location = New System.Drawing.Point(8, 116)
    Me.cbClosePrompt.Name = "cbClosePrompt"
    Me.cbClosePrompt.Size = New System.Drawing.Size(232, 17)
    Me.cbClosePrompt.TabIndex = 3
    Me.cbClosePrompt.Text = "Prompt me before exiting application"
    Me.cbClosePrompt.UseVisualStyleBackColor = True
    '
    'frmOpt
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(387, 231)
    Me.Controls.Add(Me.tcOpt)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "frmOpt"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "nxX9viewer Options"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.tcOpt.ResumeLayout(False)
    Me.tpColor.ResumeLayout(False)
    Me.tpColor.PerformLayout()
    Me.tpDisp.ResumeLayout(False)
    Me.tpDisp.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents tcOpt As System.Windows.Forms.TabControl
  Friend WithEvents tpColor As System.Windows.Forms.TabPage
  Friend WithEvents tpDisp As System.Windows.Forms.TabPage
  Friend WithEvents colorRec As System.Windows.Forms.ColorDialog
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btnColor01 As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents btnColor10 As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btnColor25 As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents btnColor20 As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btnReset As System.Windows.Forms.Button
  Friend WithEvents cbCheckImage As System.Windows.Forms.CheckBox
  Friend WithEvents cbFrontBack As System.Windows.Forms.CheckBox
  Friend WithEvents cbItemNumber As System.Windows.Forms.CheckBox
  Friend WithEvents cbClosePrompt As System.Windows.Forms.CheckBox

End Class
