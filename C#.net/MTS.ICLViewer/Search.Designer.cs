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

using System.Xml;

namespace MTS.ICLViewer
{
	public partial class Search : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbGeneral = new System.Windows.Forms.RadioButton();
            this.rbTargetted = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.tbGenSearch = new System.Windows.Forms.TextBox();
            this.pnlTSearch = new System.Windows.Forms.Panel();
            this.tbTSearch = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboRecType = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            this.pnlTSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.btnSearch, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.btnClose, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(277, 274);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "&Search";
            this.btnSearch.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(76, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // rbGeneral
            // 
            this.rbGeneral.AutoSize = true;
            this.rbGeneral.Checked = true;
            this.rbGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGeneral.Location = new System.Drawing.Point(12, 25);
            this.rbGeneral.Name = "rbGeneral";
            this.rbGeneral.Size = new System.Drawing.Size(113, 17);
            this.rbGeneral.TabIndex = 1;
            this.rbGeneral.TabStop = true;
            this.rbGeneral.Text = "General Search";
            this.rbGeneral.UseVisualStyleBackColor = true;
            this.rbGeneral.CheckedChanged += new System.EventHandler(this.rbGeneral_CheckedChanged);
            // 
            // rbTargetted
            // 
            this.rbTargetted.AutoSize = true;
            this.rbTargetted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTargetted.Location = new System.Drawing.Point(12, 107);
            this.rbTargetted.Name = "rbTargetted";
            this.rbTargetted.Size = new System.Drawing.Size(124, 17);
            this.rbTargetted.TabIndex = 2;
            this.rbTargetted.Text = "Targetted Search";
            this.rbTargetted.UseVisualStyleBackColor = true;
            this.rbTargetted.CheckedChanged += new System.EventHandler(this.rbTargetted_CheckedChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(33, 55);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(201, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Search for text in any record type:";
            // 
            // tbGenSearch
            // 
            this.tbGenSearch.Location = new System.Drawing.Point(36, 71);
            this.tbGenSearch.Name = "tbGenSearch";
            this.tbGenSearch.Size = new System.Drawing.Size(387, 20);
            this.tbGenSearch.TabIndex = 4;
            // 
            // pnlTSearch
            // 
            this.pnlTSearch.Controls.Add(this.tbTSearch);
            this.pnlTSearch.Controls.Add(this.Label4);
            this.pnlTSearch.Controls.Add(this.cboField);
            this.pnlTSearch.Controls.Add(this.Label3);
            this.pnlTSearch.Controls.Add(this.cboRecType);
            this.pnlTSearch.Controls.Add(this.Label2);
            this.pnlTSearch.Enabled = false;
            this.pnlTSearch.Location = new System.Drawing.Point(21, 130);
            this.pnlTSearch.Name = "pnlTSearch";
            this.pnlTSearch.Size = new System.Drawing.Size(399, 117);
            this.pnlTSearch.TabIndex = 7;
            // 
            // tbTSearch
            // 
            this.tbTSearch.Location = new System.Drawing.Point(6, 82);
            this.tbTSearch.Name = "tbTSearch";
            this.tbTSearch.Size = new System.Drawing.Size(384, 20);
            this.tbTSearch.TabIndex = 12;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(3, 66);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(80, 13);
            this.Label4.TabIndex = 11;
            this.Label4.Text = "Search Text:";
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(93, 38);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(297, 21);
            this.cboField.TabIndex = 10;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(3, 41);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(74, 13);
            this.Label3.TabIndex = 9;
            this.Label3.Text = "Field Name:";
            // 
            // cboRecType
            // 
            this.cboRecType.FormattingEnabled = true;
            this.cboRecType.Location = new System.Drawing.Point(93, 7);
            this.cboRecType.Name = "cboRecType";
            this.cboRecType.Size = new System.Drawing.Size(297, 21);
            this.cboRecType.TabIndex = 8;
            this.cboRecType.SelectedIndexChanged += new System.EventHandler(this.cboRecType_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(3, 10);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(84, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Record Type:";
            // 
            // Search
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(435, 315);
            this.Controls.Add(this.pnlTSearch);
            this.Controls.Add(this.tbGenSearch);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.rbTargetted);
            this.Controls.Add(this.rbGeneral);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.pnlTSearch.ResumeLayout(false);
            this.pnlTSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

	  }
	  internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
	  internal System.Windows.Forms.Button btnSearch;
	  internal System.Windows.Forms.Button btnClose;
	  internal System.Windows.Forms.RadioButton rbGeneral;
	  internal System.Windows.Forms.RadioButton rbTargetted;
	  internal System.Windows.Forms.Label Label1;
	  internal System.Windows.Forms.TextBox tbGenSearch;
	  internal System.Windows.Forms.Panel pnlTSearch;
	  internal System.Windows.Forms.TextBox tbTSearch;
	  internal System.Windows.Forms.Label Label4;
	  internal System.Windows.Forms.ComboBox cboField;
	  internal System.Windows.Forms.Label Label3;
	  internal System.Windows.Forms.ComboBox cboRecType;
	  internal System.Windows.Forms.Label Label2;

	}

} //end of root namespace