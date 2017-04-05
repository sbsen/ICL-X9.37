Imports System.Windows.Forms

Public Class frmOpt

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    ' save options in settings
    My.Settings.color01 = btnColor01.BackColor
    My.Settings.color10 = btnColor10.BackColor
    My.Settings.color20 = btnColor20.BackColor
    My.Settings.color25 = btnColor25.BackColor
    My.Settings.checkImage = cbCheckImage.Checked
    My.Settings.frontAndBack = cbCheckImage.Checked
    My.Settings.showItemNumber = cbItemNumber.Checked
    My.Settings.ClosePrompt = cbClosePrompt.Checked
    Me.DialogResult = System.Windows.Forms.DialogResult.OK
    MessageBox.Show("Settings will be effective next time you open a file", "Options save", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Me.Close()
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub frmOpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LoadSettings()
  End Sub

  Private Sub btnColor01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnColor01.Click
    If colorRec.ShowDialog() = Windows.Forms.DialogResult.OK Then
      btnColor01.BackColor = colorRec.Color
    End If
  End Sub

  Private Sub btnColor10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor10.Click
    If colorRec.ShowDialog() = Windows.Forms.DialogResult.OK Then
      btnColor10.BackColor = colorRec.Color
    End If
  End Sub

  Private Sub btnColor20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor20.Click
    If colorRec.ShowDialog() = Windows.Forms.DialogResult.OK Then
      btnColor20.BackColor = colorRec.Color
    End If
  End Sub

  Private Sub btnColor25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColor25.Click
    If colorRec.ShowDialog() = Windows.Forms.DialogResult.OK Then
      btnColor25.BackColor = colorRec.Color
    End If
  End Sub

  Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
    My.Settings.Reset()
    LoadSettings()
  End Sub
  Private Sub LoadSettings()
    ' fill color options
    btnColor01.BackColor = My.Settings.color01
    btnColor10.BackColor = My.Settings.color10
    btnColor20.BackColor = My.Settings.color20
    btnColor25.BackColor = My.Settings.color25

    ' fill display options
    cbCheckImage.Checked = My.Settings.checkImage
    cbFrontBack.Checked = My.Settings.frontAndBack
    cbItemNumber.Checked = My.Settings.showItemNumber
    cbClosePrompt.Checked = My.Settings.ClosePrompt
  End Sub
End Class
