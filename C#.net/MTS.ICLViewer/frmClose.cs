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
    public partial class FrmClose
    {

        internal FrmClose()
        {
            InitializeComponent();
        }
        private void OK_Button_Click(object sender, System.EventArgs e)
        {
            if (cbClosePrompt.Checked)
            {
                Properties.Settings.Default.ClosePrompt = false;
                Properties.Settings.Default.Save();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

    }

} //end of root namespace