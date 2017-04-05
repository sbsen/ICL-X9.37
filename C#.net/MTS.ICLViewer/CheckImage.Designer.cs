namespace MTS.ICLViewer
{
    partial class CheckImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckImage));
            this.spcCheckImage = new System.Windows.Forms.SplitContainer();
            this.pfFront = new System.Windows.Forms.PictureBox();
            this.pfRear = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spcCheckImage)).BeginInit();
            this.spcCheckImage.Panel1.SuspendLayout();
            this.spcCheckImage.Panel2.SuspendLayout();
            this.spcCheckImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfFront)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfRear)).BeginInit();
            this.SuspendLayout();
            // 
            // spcCheckImage
            // 
            this.spcCheckImage.BackColor = System.Drawing.Color.Transparent;
            this.spcCheckImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcCheckImage.Location = new System.Drawing.Point(0, 0);
            this.spcCheckImage.Name = "spcCheckImage";
            this.spcCheckImage.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcCheckImage.Panel1
            // 
            this.spcCheckImage.Panel1.Controls.Add(this.pfFront);
            // 
            // spcCheckImage.Panel2
            // 
            this.spcCheckImage.Panel2.Controls.Add(this.pfRear);
            this.spcCheckImage.Size = new System.Drawing.Size(844, 445);
            this.spcCheckImage.SplitterDistance = 221;
            this.spcCheckImage.TabIndex = 0;
            // 
            // pfFront
            // 
            this.pfFront.BackColor = System.Drawing.Color.Transparent;
            this.pfFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pfFront.Location = new System.Drawing.Point(0, 0);
            this.pfFront.Name = "pfFront";
            this.pfFront.Size = new System.Drawing.Size(844, 221);
            this.pfFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pfFront.TabIndex = 0;
            this.pfFront.TabStop = false;
            // 
            // pfRear
            // 
            this.pfRear.BackColor = System.Drawing.Color.Transparent;
            this.pfRear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pfRear.Location = new System.Drawing.Point(0, 0);
            this.pfRear.Name = "pfRear";
            this.pfRear.Size = new System.Drawing.Size(844, 220);
            this.pfRear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pfRear.TabIndex = 0;
            this.pfRear.TabStop = false;
            // 
            // CheckImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 445);
            this.Controls.Add(this.spcCheckImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CheckImage";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckImage_FormClosing);
            this.spcCheckImage.Panel1.ResumeLayout(false);
            this.spcCheckImage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcCheckImage)).EndInit();
            this.spcCheckImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pfFront)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pfRear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcCheckImage;
        private System.Windows.Forms.PictureBox pfRear;
        protected internal System.Windows.Forms.PictureBox pfFront;
    }
}