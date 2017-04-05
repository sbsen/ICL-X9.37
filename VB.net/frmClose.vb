Imports System.Windows.Forms

Public Class frmClose

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If cbClosePrompt.Checked Then
      My.Settings.ClosePrompt = False
    End If
    Me.DialogResult = System.Windows.Forms.DialogResult.Yes
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.No
    Me.Close()
  End Sub

End Class
