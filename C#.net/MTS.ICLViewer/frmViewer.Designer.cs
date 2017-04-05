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

using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Xml;

namespace MTS.ICLViewer
{

	public partial class FrmViewer : System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmViewer));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSingleImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportFrontImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvX9 = new System.Windows.Forms.TreeView();
            this.ofdX9 = new System.Windows.Forms.OpenFileDialog();
            this.lblFile = new System.Windows.Forms.Label();
            this.cmsImg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpData = new System.Windows.Forms.TabPage();
            this.Label1 = new System.Windows.Forms.Label();
            this.dgvFields = new System.Windows.Forms.DataGridView();
            this.fieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPos = new System.Windows.Forms.Label();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.tcX9 = new System.Windows.Forms.TabControl();
            this.tpImg = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pbFront = new System.Windows.Forms.PictureBox();
            this.pbCheck = new System.Windows.Forms.PictureBox();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.sfdImg = new System.Windows.Forms.SaveFileDialog();
            this.progbLoad = new System.Windows.Forms.ProgressBar();
            this.lblLoad = new System.Windows.Forms.Label();
            this.SingleImageDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.mnuMain.SuspendLayout();
            this.cmsImg.SuspendLayout();
            this.tpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).BeginInit();
            this.tcX9.SuspendLayout();
            this.tpImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(917, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.ToolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenToolStripMenuItem.Text = "&Open";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(100, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuiCopy,
            this.ToolStripSeparator2,
            this.mnuiOptions});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.EditToolStripMenuItem.Text = "&Edit";
            // 
            // mnuiCopy
            // 
            this.mnuiCopy.Enabled = false;
            this.mnuiCopy.Name = "mnuiCopy";
            this.mnuiCopy.Size = new System.Drawing.Size(128, 22);
            this.mnuiCopy.Text = "&Copy";
            this.mnuiCopy.Click += new System.EventHandler(this.mnuiCopy_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // mnuiOptions
            // 
            this.mnuiOptions.Name = "mnuiOptions";
            this.mnuiOptions.Size = new System.Drawing.Size(128, 22);
            this.mnuiOptions.Text = "Options ...";
            this.mnuiOptions.Click += new System.EventHandler(this.mnuiOptions_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewImageToolStripMenuItem,
            this.toolStripSeparator5,
            this.SearchToolStripMenuItem,
            this.exportSingleImagesToolStripMenuItem,
            this.ExportFrontImagesToolStripMenuItem,
            this.ExportImagesToolStripMenuItem,
            this.toolStripSeparator3,
            this.summaryToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ToolsToolStripMenuItem.Text = "&Tools";
            // 
            // viewImageToolStripMenuItem
            // 
            this.viewImageToolStripMenuItem.Enabled = false;
            this.viewImageToolStripMenuItem.Name = "viewImageToolStripMenuItem";
            this.viewImageToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.viewImageToolStripMenuItem.Text = "&View Image";
            this.viewImageToolStripMenuItem.Click += new System.EventHandler(this.viewImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(241, 6);
            // 
            // SearchToolStripMenuItem
            // 
            this.SearchToolStripMenuItem.Enabled = false;
            this.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem";
            this.SearchToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.SearchToolStripMenuItem.Text = "&Search";
            this.SearchToolStripMenuItem.Click += new System.EventHandler(this.SearchToolStripMenuItem_Click_1);
            // 
            // exportSingleImagesToolStripMenuItem
            // 
            this.exportSingleImagesToolStripMenuItem.Enabled = false;
            this.exportSingleImagesToolStripMenuItem.Name = "exportSingleImagesToolStripMenuItem";
            this.exportSingleImagesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.exportSingleImagesToolStripMenuItem.Text = "&Export Images ";
            this.exportSingleImagesToolStripMenuItem.Click += new System.EventHandler(this.exportSingleImagesToolStripMenuItem_Click);
            // 
            // ExportFrontImagesToolStripMenuItem
            // 
            this.ExportFrontImagesToolStripMenuItem.Enabled = false;
            this.ExportFrontImagesToolStripMenuItem.Name = "ExportFrontImagesToolStripMenuItem";
            this.ExportFrontImagesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.ExportFrontImagesToolStripMenuItem.Text = "Export &Front Images As MultiTiff";
            this.ExportFrontImagesToolStripMenuItem.Visible = false;
            this.ExportFrontImagesToolStripMenuItem.Click += new System.EventHandler(this.ExportFrontImagesToolStripMenuItem_Click);
            // 
            // ExportImagesToolStripMenuItem
            // 
            this.ExportImagesToolStripMenuItem.Enabled = false;
            this.ExportImagesToolStripMenuItem.Name = "ExportImagesToolStripMenuItem";
            this.ExportImagesToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.ExportImagesToolStripMenuItem.Text = "E&xport Images As MultiTiff";
            this.ExportImagesToolStripMenuItem.Visible = false;
            this.ExportImagesToolStripMenuItem.Click += new System.EventHandler(this.ExportImagesToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(241, 6);
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Enabled = false;
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.summaryToolStripMenuItem.Text = "Summar&y";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // tvX9
            // 
            this.tvX9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvX9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvX9.HideSelection = false;
            this.tvX9.Location = new System.Drawing.Point(5, 55);
            this.tvX9.Name = "tvX9";
            this.tvX9.Size = new System.Drawing.Size(243, 489);
            this.tvX9.TabIndex = 1;
            this.tvX9.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvX9_AfterSelect);
            // 
            // ofdX9
            // 
            this.ofdX9.DefaultExt = "dat";
            this.ofdX9.Filter = "ICL File(*.ICL)|*.icl|X9 DAT files (*.dat)|*.dat";
            this.ofdX9.Title = "Select ICL file to view";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(13, 29);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(0, 13);
            this.lblFile.TabIndex = 2;
            // 
            // cmsImg
            // 
            this.cmsImg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyToClipboardToolStripMenuItem,
            this.SaveAsToolStripMenuItem});
            this.cmsImg.Name = "cmsImg";
            this.cmsImg.Size = new System.Drawing.Size(170, 48);
            // 
            // CopyToClipboardToolStripMenuItem
            // 
            this.CopyToClipboardToolStripMenuItem.Name = "CopyToClipboardToolStripMenuItem";
            this.CopyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.CopyToClipboardToolStripMenuItem.Text = "&Copy to clipboard";
            this.CopyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.CopyToClipboardToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.SaveAsToolStripMenuItem.Text = "&Save As ...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.Label1);
            this.tpData.Controls.Add(this.dgvFields);
            this.tpData.Controls.Add(this.lblPos);
            this.tpData.Controls.Add(this.txtRec);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(659, 463);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Data";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 72);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(44, 13);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Fields:";
            // 
            // dgvFields
            // 
            this.dgvFields.AllowUserToAddRows = false;
            this.dgvFields.AllowUserToDeleteRows = false;
            this.dgvFields.AllowUserToOrderColumns = true;
            this.dgvFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFields.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFields.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fieldName,
            this.fieldValue,
            this.fieldType,
            this.fieldDetail});
            this.dgvFields.Location = new System.Drawing.Point(6, 88);
            this.dgvFields.Name = "dgvFields";
            this.dgvFields.RowTemplate.Height = 52;
            this.dgvFields.Size = new System.Drawing.Size(645, 363);
            this.dgvFields.TabIndex = 2;
            // 
            // fieldName
            // 
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldName.DefaultCellStyle = dataGridViewCellStyle1;
            this.fieldName.HeaderText = "Name";
            this.fieldName.Name = "fieldName";
            // 
            // fieldValue
            // 
            this.fieldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fieldValue.HeaderText = "Value";
            this.fieldValue.Name = "fieldValue";
            this.fieldValue.ReadOnly = true;
            this.fieldValue.Width = 59;
            // 
            // fieldType
            // 
            this.fieldType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fieldType.HeaderText = "Type";
            this.fieldType.Name = "fieldType";
            this.fieldType.ReadOnly = true;
            this.fieldType.Width = 56;
            // 
            // fieldDetail
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.fieldDetail.FillWeight = 300F;
            this.fieldDetail.HeaderText = "Comments";
            this.fieldDetail.Name = "fieldDetail";
            this.fieldDetail.Width = 300;
            // 
            // lblPos
            // 
            this.lblPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPos.Location = new System.Drawing.Point(580, 59);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(0, 13);
            this.lblPos.TabIndex = 1;
            // 
            // txtRec
            // 
            this.txtRec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRec.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRec.Location = new System.Drawing.Point(6, 6);
            this.txtRec.Multiline = true;
            this.txtRec.Name = "txtRec";
            this.txtRec.Size = new System.Drawing.Size(645, 50);
            this.txtRec.TabIndex = 0;
            this.txtRec.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtRec_MouseClick);
            this.txtRec.GotFocus += new System.EventHandler(this.txtRec_GotFocus);
            this.txtRec.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRec_KeyUp);
            this.txtRec.LostFocus += new System.EventHandler(this.txtRec_LostFocus);
            // 
            // tcX9
            // 
            this.tcX9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcX9.Controls.Add(this.tpData);
            this.tcX9.Controls.Add(this.tpImg);
            this.tcX9.Location = new System.Drawing.Point(250, 55);
            this.tcX9.Name = "tcX9";
            this.tcX9.SelectedIndex = 0;
            this.tcX9.Size = new System.Drawing.Size(667, 489);
            this.tcX9.TabIndex = 3;
            // 
            // tpImg
            // 
            this.tpImg.Controls.Add(this.splitContainer1);
            this.tpImg.Location = new System.Drawing.Point(4, 22);
            this.tpImg.Name = "tpImg";
            this.tpImg.Padding = new System.Windows.Forms.Padding(3);
            this.tpImg.Size = new System.Drawing.Size(659, 463);
            this.tpImg.TabIndex = 1;
            this.tpImg.Text = "Check Image";
            this.tpImg.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbFront);
            this.splitContainer1.Panel1.Controls.Add(this.pbCheck);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pbBack);
            this.splitContainer1.Size = new System.Drawing.Size(653, 457);
            this.splitContainer1.SplitterDistance = 217;
            this.splitContainer1.TabIndex = 0;
            // 
            // pbFront
            // 
            this.pbFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFront.Location = new System.Drawing.Point(0, 0);
            this.pbFront.Name = "pbFront";
            this.pbFront.Size = new System.Drawing.Size(653, 217);
            this.pbFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFront.TabIndex = 0;
            this.pbFront.TabStop = false;
            // 
            // pbCheck
            // 
            this.pbCheck.Location = new System.Drawing.Point(222, 99);
            this.pbCheck.Name = "pbCheck";
            this.pbCheck.Size = new System.Drawing.Size(100, 50);
            this.pbCheck.TabIndex = 1;
            this.pbCheck.TabStop = false;
            // 
            // pbBack
            // 
            this.pbBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBack.Location = new System.Drawing.Point(0, 0);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(653, 236);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 0;
            this.pbBack.TabStop = false;
            // 
            // sfdImg
            // 
            this.sfdImg.DefaultExt = "tiff";
            this.sfdImg.Filter = "Tiff Files (*.tif)|*.tif";
            this.sfdImg.Title = "Save check image as";
            // 
            // progbLoad
            // 
            this.progbLoad.Location = new System.Drawing.Point(341, 28);
            this.progbLoad.Name = "progbLoad";
            this.progbLoad.Size = new System.Drawing.Size(286, 23);
            this.progbLoad.TabIndex = 4;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoad.Location = new System.Drawing.Point(633, 34);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(0, 17);
            this.lblLoad.TabIndex = 5;
            // 
            // FrmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 547);
            this.Controls.Add(this.lblLoad);
            this.Controls.Add(this.progbLoad);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.tvX9);
            this.Controls.Add(this.tcX9);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FrmViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MTS ICL Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewer_FormClosing);
            this.Load += new System.EventHandler(this.frmViewer_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.cmsImg.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.tpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFields)).EndInit();
            this.tcX9.ResumeLayout(false);
            this.tpImg.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	  }
	  internal System.Windows.Forms.MenuStrip mnuMain;
	  internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
	  internal System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
	  internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
	  internal System.Windows.Forms.TreeView tvX9;
	  internal System.Windows.Forms.OpenFileDialog ofdX9;
      internal System.Windows.Forms.Label lblFile;
      internal System.Windows.Forms.TabPage tpData;
	  internal System.Windows.Forms.Label lblPos;
      internal System.Windows.Forms.TextBox txtRec;
      internal System.Windows.Forms.DataGridView dgvFields;
	  internal System.Windows.Forms.Label Label1;
	  internal System.Windows.Forms.DataGridViewTextBoxColumn fieldName;
	  internal System.Windows.Forms.DataGridViewTextBoxColumn fieldValue;
	  internal System.Windows.Forms.DataGridViewTextBoxColumn fieldType;
	  internal System.Windows.Forms.DataGridViewTextBoxColumn fieldDetail;
	  internal System.Windows.Forms.ContextMenuStrip cmsImg;
	  internal System.Windows.Forms.ToolStripMenuItem CopyToClipboardToolStripMenuItem;
	  internal System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
	  internal System.Windows.Forms.SaveFileDialog sfdImg;
	  internal System.Windows.Forms.ProgressBar progbLoad;
	  internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
	  internal System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
	  internal System.Windows.Forms.ToolStripMenuItem mnuiCopy;
	  internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
	  internal System.Windows.Forms.ToolStripMenuItem mnuiOptions;
      internal System.Windows.Forms.Label lblLoad;
	  internal System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
	  internal System.Windows.Forms.ToolStripMenuItem SearchToolStripMenuItem;
	  internal System.Windows.Forms.ToolStripMenuItem ExportImagesToolStripMenuItem;
      internal System.Windows.Forms.ToolStripMenuItem ExportFrontImagesToolStripMenuItem;
      internal TabControl tcX9;
      internal TabPage tpImg;
      private SplitContainer splitContainer1;
      private PictureBox pbFront;
      private PictureBox pbCheck;
      private PictureBox pbBack;
      private ToolStripSeparator toolStripSeparator3;
      internal ToolStripMenuItem summaryToolStripMenuItem;
      private ToolStripMenuItem viewImageToolStripMenuItem;
      private ToolStripSeparator toolStripSeparator5;
      private ToolStripMenuItem exportSingleImagesToolStripMenuItem;
      private FolderBrowserDialog SingleImageDialog;
	}

} //end of root namespace