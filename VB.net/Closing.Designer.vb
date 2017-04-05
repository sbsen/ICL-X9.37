<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Closing
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
    Me.lblCleanup = New System.Windows.Forms.Label
    Me.pbCleanup = New System.Windows.Forms.ProgressBar
    Me.SuspendLayout()
    '
    'lblCleanup
    '
    Me.lblCleanup.AutoSize = True
    Me.lblCleanup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCleanup.ForeColor = System.Drawing.Color.Red
    Me.lblCleanup.Location = New System.Drawing.Point(0, 12)
    Me.lblCleanup.Name = "lblCleanup"
    Me.lblCleanup.Size = New System.Drawing.Size(244, 13)
    Me.lblCleanup.TabIndex = 0
    Me.lblCleanup.Text = "Please wait cleaning up temporary files ..."
    '
    'pbCleanup
    '
    Me.pbCleanup.Location = New System.Drawing.Point(12, 28)
    Me.pbCleanup.Name = "pbCleanup"
    Me.pbCleanup.Size = New System.Drawing.Size(563, 23)
    Me.pbCleanup.TabIndex = 1
    Me.pbCleanup.UseWaitCursor = True
    '
    'Closing
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(587, 62)
    Me.ControlBox = False
    Me.Controls.Add(Me.pbCleanup)
    Me.Controls.Add(Me.lblCleanup)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Closing"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "nsX9Viewer Closing ..."
    Me.TopMost = True
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblCleanup As System.Windows.Forms.Label
  Friend WithEvents pbCleanup As System.Windows.Forms.ProgressBar
End Class
