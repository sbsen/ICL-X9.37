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

	public partial class Closing : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer
		private System.ComponentModel.IContainer components;

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Closing));
            this.lblCleanup = new System.Windows.Forms.Label();
            this.pbCleanup = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblCleanup
            // 
            this.lblCleanup.AutoSize = true;
            this.lblCleanup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCleanup.ForeColor = System.Drawing.Color.Red;
            this.lblCleanup.Location = new System.Drawing.Point(0, 12);
            this.lblCleanup.Name = "lblCleanup";
            this.lblCleanup.Size = new System.Drawing.Size(244, 13);
            this.lblCleanup.TabIndex = 0;
            this.lblCleanup.Text = "Please wait cleaning up temporary files ...";
            // 
            // pbCleanup
            // 
            this.pbCleanup.Location = new System.Drawing.Point(12, 28);
            this.pbCleanup.Name = "pbCleanup";
            this.pbCleanup.Size = new System.Drawing.Size(563, 23);
            this.pbCleanup.TabIndex = 1;
            this.pbCleanup.UseWaitCursor = true;
            // 
            // Closing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 62);
            this.ControlBox = false;
            this.Controls.Add(this.pbCleanup);
            this.Controls.Add(this.lblCleanup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Closing";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTS.ICLViewer Closing ...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

	  }
	  internal System.Windows.Forms.Label lblCleanup;
	  internal System.Windows.Forms.ProgressBar pbCleanup;
	}

} //end of root namespace