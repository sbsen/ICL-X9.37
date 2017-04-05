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
	public partial class FrmOpt : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOpt));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.tcOpt = new System.Windows.Forms.TabControl();
            this.tpColor = new System.Windows.Forms.TabPage();
            this.btnColor25 = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.btnColor20 = new System.Windows.Forms.Button();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnColor10 = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnColor01 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.tpDisp = new System.Windows.Forms.TabPage();
            this.cbClosePrompt = new System.Windows.Forms.CheckBox();
            this.cbItemNumber = new System.Windows.Forms.CheckBox();
            this.cbFrontBack = new System.Windows.Forms.CheckBox();
            this.cbCheckImage = new System.Windows.Forms.CheckBox();
            this.colorRec = new System.Windows.Forms.ColorDialog();
            this.TableLayoutPanel1.SuspendLayout();
            this.tcOpt.SuspendLayout();
            this.tpColor.SuspendLayout();
            this.tpDisp.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 3;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 2, 0);
            this.TableLayoutPanel1.Controls.Add(this.btnReset, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(218, 250);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(167, 29);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(113, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(51, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(3, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(49, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(58, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(49, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "OK";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // tcOpt
            // 
            this.tcOpt.Controls.Add(this.tpColor);
            this.tcOpt.Controls.Add(this.tpDisp);
            this.tcOpt.Location = new System.Drawing.Point(0, 0);
            this.tcOpt.Name = "tcOpt";
            this.tcOpt.SelectedIndex = 0;
            this.tcOpt.Size = new System.Drawing.Size(377, 247);
            this.tcOpt.TabIndex = 1;
            // 
            // tpColor
            // 
            this.tpColor.Controls.Add(this.btnColor25);
            this.tpColor.Controls.Add(this.Label5);
            this.tpColor.Controls.Add(this.btnColor20);
            this.tpColor.Controls.Add(this.Label4);
            this.tpColor.Controls.Add(this.btnColor10);
            this.tpColor.Controls.Add(this.Label3);
            this.tpColor.Controls.Add(this.btnColor01);
            this.tpColor.Controls.Add(this.Label2);
            this.tpColor.Controls.Add(this.Label1);
            this.tpColor.Location = new System.Drawing.Point(4, 22);
            this.tpColor.Name = "tpColor";
            this.tpColor.Padding = new System.Windows.Forms.Padding(3);
            this.tpColor.Size = new System.Drawing.Size(369, 221);
            this.tpColor.TabIndex = 0;
            this.tpColor.Text = "Rec Type";
            this.tpColor.UseVisualStyleBackColor = true;
            this.tpColor.Click += new System.EventHandler(this.tpColor_Click);
            // 
            // btnColor25
            // 
            this.btnColor25.Location = new System.Drawing.Point(255, 110);
            this.btnColor25.Name = "btnColor25";
            this.btnColor25.Size = new System.Drawing.Size(75, 22);
            this.btnColor25.TabIndex = 8;
            this.btnColor25.UseVisualStyleBackColor = true;
            this.btnColor25.Click += new System.EventHandler(this.btnColor25_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(6, 115);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(142, 13);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Check Records (25-69):";
            // 
            // btnColor20
            // 
            this.btnColor20.Location = new System.Drawing.Point(255, 83);
            this.btnColor20.Name = "btnColor20";
            this.btnColor20.Size = new System.Drawing.Size(75, 22);
            this.btnColor20.TabIndex = 6;
            this.btnColor20.UseVisualStyleBackColor = true;
            this.btnColor20.Click += new System.EventHandler(this.btnColor20_Click);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(6, 88);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(183, 13);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Bundle Header/Footer (20/70):";
            // 
            // btnColor10
            // 
            this.btnColor10.Location = new System.Drawing.Point(255, 55);
            this.btnColor10.Name = "btnColor10";
            this.btnColor10.Size = new System.Drawing.Size(75, 22);
            this.btnColor10.TabIndex = 4;
            this.btnColor10.UseVisualStyleBackColor = true;
            this.btnColor10.Click += new System.EventHandler(this.btnColor10_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(6, 60);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(209, 13);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Cash Letter Header/Footer (10/90):";
            // 
            // btnColor01
            // 
            this.btnColor01.Location = new System.Drawing.Point(255, 27);
            this.btnColor01.Name = "btnColor01";
            this.btnColor01.Size = new System.Drawing.Size(75, 22);
            this.btnColor01.TabIndex = 2;
            this.btnColor01.UseVisualStyleBackColor = true;
            this.btnColor01.Click += new System.EventHandler(this.btnColor01_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(140, 13);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Header/Footer (01/99):";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 3);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(178, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Select colors for record types:";
            // 
            // tpDisp
            // 
            this.tpDisp.Controls.Add(this.cbClosePrompt);
            this.tpDisp.Controls.Add(this.cbItemNumber);
            this.tpDisp.Controls.Add(this.cbFrontBack);
            this.tpDisp.Controls.Add(this.cbCheckImage);
            this.tpDisp.Location = new System.Drawing.Point(4, 22);
            this.tpDisp.Name = "tpDisp";
            this.tpDisp.Padding = new System.Windows.Forms.Padding(3);
            this.tpDisp.Size = new System.Drawing.Size(369, 221);
            this.tpDisp.TabIndex = 1;
            this.tpDisp.Text = "Display";
            this.tpDisp.UseVisualStyleBackColor = true;
            // 
            // cbClosePrompt
            // 
            this.cbClosePrompt.AutoSize = true;
            this.cbClosePrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClosePrompt.Location = new System.Drawing.Point(8, 116);
            this.cbClosePrompt.Name = "cbClosePrompt";
            this.cbClosePrompt.Size = new System.Drawing.Size(232, 17);
            this.cbClosePrompt.TabIndex = 3;
            this.cbClosePrompt.Text = "Prompt me before exiting application";
            this.cbClosePrompt.UseVisualStyleBackColor = true;
            // 
            // cbItemNumber
            // 
            this.cbItemNumber.AutoSize = true;
            this.cbItemNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbItemNumber.Location = new System.Drawing.Point(8, 85);
            this.cbItemNumber.Name = "cbItemNumber";
            this.cbItemNumber.Size = new System.Drawing.Size(132, 17);
            this.cbItemNumber.TabIndex = 2;
            this.cbItemNumber.Text = "Show &Item Number";
            this.cbItemNumber.UseVisualStyleBackColor = true;
            // 
            // cbFrontBack
            // 
            this.cbFrontBack.AutoSize = true;
            this.cbFrontBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFrontBack.Location = new System.Drawing.Point(8, 54);
            this.cbFrontBack.Name = "cbFrontBack";
            this.cbFrontBack.Size = new System.Drawing.Size(227, 17);
            this.cbFrontBack.TabIndex = 1;
            this.cbFrontBack.Text = "Show &both front and back of check";
            this.cbFrontBack.UseVisualStyleBackColor = true;
            // 
            // cbCheckImage
            // 
            this.cbCheckImage.AutoSize = true;
            this.cbCheckImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCheckImage.Location = new System.Drawing.Point(8, 23);
            this.cbCheckImage.Name = "cbCheckImage";
            this.cbCheckImage.Size = new System.Drawing.Size(316, 17);
            this.cbCheckImage.TabIndex = 0;
            this.cbCheckImage.Text = "Show check &image when I select any check record";
            this.cbCheckImage.UseVisualStyleBackColor = true;
            // 
            // FrmOpt
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(397, 291);
            this.Controls.Add(this.tcOpt);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOpt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ICL viewer Options";
            this.Load += new System.EventHandler(this.frmOpt_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.tcOpt.ResumeLayout(false);
            this.tpColor.ResumeLayout(false);
            this.tpColor.PerformLayout();
            this.tpDisp.ResumeLayout(false);
            this.tpDisp.PerformLayout();
            this.ResumeLayout(false);

	  }
	  internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
	  internal System.Windows.Forms.Button OK_Button;
	  internal System.Windows.Forms.Button Cancel_Button;
	  internal System.Windows.Forms.TabControl tcOpt;
	  internal System.Windows.Forms.TabPage tpColor;
	  internal System.Windows.Forms.TabPage tpDisp;
	  internal System.Windows.Forms.ColorDialog colorRec;
	  internal System.Windows.Forms.Label Label1;
	  internal System.Windows.Forms.Button btnColor01;
	  internal System.Windows.Forms.Label Label2;
	  internal System.Windows.Forms.Button btnColor10;
	  internal System.Windows.Forms.Label Label3;
	  internal System.Windows.Forms.Button btnColor25;
	  internal System.Windows.Forms.Label Label5;
	  internal System.Windows.Forms.Button btnColor20;
	  internal System.Windows.Forms.Label Label4;
	  internal System.Windows.Forms.Button btnReset;
	  internal System.Windows.Forms.CheckBox cbCheckImage;
	  internal System.Windows.Forms.CheckBox cbFrontBack;
	  internal System.Windows.Forms.CheckBox cbItemNumber;
	  internal System.Windows.Forms.CheckBox cbClosePrompt;

	}

} //end of root namespace