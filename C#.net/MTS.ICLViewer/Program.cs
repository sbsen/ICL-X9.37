using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MTS.ICLViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        //public FrmViewer frmViewer;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //frmViewer = new FrmViewer();
            Application.Run(new FrmViewer());
        }
    }
}
