using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MTS.ICLViewer
{
    public partial class CheckImage : Form
    {
        public CheckImage()
        {
            InitializeComponent();
        }

        public void SetImage(Image fimage, Image rimage)
        {
            pfFront.Image = fimage;
            pfRear.Image = rimage;
            spcCheckImage.Refresh();
            pfFront.Refresh();
            pfRear.Refresh();
        }

        private void CheckImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }

    }
}
