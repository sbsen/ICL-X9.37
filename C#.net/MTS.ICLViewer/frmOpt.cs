//INSTANT C# NOTE: Formerly VB.NET project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;

namespace MTS.ICLViewer
{
	public partial class FrmOpt
	{

		internal FrmOpt()
		{
			InitializeComponent();
		}
	  private void OK_Button_Click(object sender, System.EventArgs e)
	  {
		// save options in settings
		Properties.Settings.Default.color01 = btnColor01.BackColor;
		Properties.Settings.Default.color10 = btnColor10.BackColor;
		Properties.Settings.Default.color20 = btnColor20.BackColor;
		Properties.Settings.Default.color25 = btnColor25.BackColor;
		Properties.Settings.Default.checkImage = cbCheckImage.Checked;
		Properties.Settings.Default.frontAndBack = cbFrontBack.Checked;
		Properties.Settings.Default.showItemNumber = cbItemNumber.Checked;
		Properties.Settings.Default.ClosePrompt = cbClosePrompt.Checked;
		this.DialogResult = System.Windows.Forms.DialogResult.OK;
		MessageBox.Show("Settings will be effective next time you open a file", "Options save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Properties.Settings.Default.Save();
		this.Close();
	  }

	  private void Cancel_Button_Click(object sender, System.EventArgs e)
	  {
		this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.Close();
	  }

	  private void frmOpt_Load(object sender, System.EventArgs e)
	  {
		LoadSettings();
	  }

	  private void btnColor01_Click(object sender, System.EventArgs e)
	  {
		if (colorRec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
		  btnColor01.BackColor = colorRec.Color;
		}
	  }

	  private void btnColor10_Click(object sender, System.EventArgs e)
	  {
		if (colorRec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
		  btnColor10.BackColor = colorRec.Color;
		}
	  }

	  private void btnColor20_Click(object sender, System.EventArgs e)
	  {
		if (colorRec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
		  btnColor20.BackColor = colorRec.Color;
		}
	  }

	  private void btnColor25_Click(object sender, System.EventArgs e)
	  {
		if (colorRec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
		{
		  btnColor25.BackColor = colorRec.Color;
		}
	  }

	  private void btnReset_Click(object sender, System.EventArgs e)
	  {
		Properties.Settings.Default.Reset();
		LoadSettings();
	  }

	  private void LoadSettings()
	  {
		// fill color options
		btnColor01.BackColor = Properties.Settings.Default.color01;
		btnColor10.BackColor = Properties.Settings.Default.color10;
		btnColor20.BackColor = Properties.Settings.Default.color20;
		btnColor25.BackColor = Properties.Settings.Default.color25;

		// fill display options
		cbCheckImage.Checked = Properties.Settings.Default.checkImage;
		cbFrontBack.Checked = Properties.Settings.Default.frontAndBack;
		cbItemNumber.Checked = Properties.Settings.Default.showItemNumber;
		cbClosePrompt.Checked = Properties.Settings.Default.ClosePrompt;
	  }

      private void tpColor_Click(object sender, EventArgs e)
      {

      }
	}

} //end of root namespace