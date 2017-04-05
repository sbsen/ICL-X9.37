namespace MTS.ICLViewer
{
    partial class Summary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary));
            this.pnlTree = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.trvSummary = new System.Windows.Forms.TreeView();
            this.pnlTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTree
            // 
            this.pnlTree.AutoScroll = true;
            this.pnlTree.Controls.Add(this.lblHeader);
            this.pnlTree.Controls.Add(this.trvSummary);
            this.pnlTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTree.Location = new System.Drawing.Point(0, 0);
            this.pnlTree.Name = "pnlTree";
            this.pnlTree.Size = new System.Drawing.Size(547, 483);
            this.pnlTree.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(17, 17);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(150, 20);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "ICL File Summary";
            // 
            // trvSummary
            // 
            this.trvSummary.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.trvSummary.Location = new System.Drawing.Point(12, 46);
            this.trvSummary.Name = "trvSummary";
            this.trvSummary.Size = new System.Drawing.Size(523, 425);
            this.trvSummary.TabIndex = 0;
            this.trvSummary.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.trvSummary_AfterExpand);
            this.trvSummary.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.trvSummary_DrawNode);
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(547, 483);
            this.Controls.Add(this.pnlTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Summary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ICL File - Summary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Summary_FormClosing);
            this.Load += new System.EventHandler(this.Summary_Load);
            this.pnlTree.ResumeLayout(false);
            this.pnlTree.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTree;
        private System.Windows.Forms.TreeView trvSummary;
        private System.Windows.Forms.Label lblHeader;

    }
}