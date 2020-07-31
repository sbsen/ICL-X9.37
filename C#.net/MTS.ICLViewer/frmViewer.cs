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
    #region delegate
    public delegate void OnSummary(string RecordType, string RecData);
    public delegate void OnObjectRefresh();
    public delegate void OnSetImage(Image fimage, Image rimage);
    #endregion

    public partial class FrmViewer : Form
    {
        private FrmClose frmClose;
        private FrmOpt frmOpt;
        //private Search search;
        #region Delegate Initialize
        private static OnSummary onFileSummary;
        private static OnSummary onCashLetterSummary;
        private static OnSummary onCreditSummary;
        private static OnSummary onBundleSummary;
        private static OnObjectRefresh onObjectRefresh;
        private static OnObjectRefresh onObjectInitial;
        private static OnObjectRefresh onCreateNodeValues;
        private static OnSetImage onSetImage;
        #endregion

        private static Summary _objSumary = new Summary();
        private static CheckImage _objCheckImage = new CheckImage();

        internal FrmViewer()
        {
            InitializeComponent();
            frmClose = new FrmClose();
            frmOpt = new FrmOpt();
            onFileSummary += new OnSummary(_objSumary.FileSummary);
            onCashLetterSummary += new OnSummary(_objSumary.CashLetterSummary);
            onCreditSummary += new OnSummary(_objSumary.CreditSummary);
            onBundleSummary += new OnSummary(_objSumary.BundleSummary);
            onObjectRefresh += new OnObjectRefresh(_objSumary.SetObjectsNewForm);
            onCreateNodeValues += new OnObjectRefresh(_objSumary.CreateNodeValues);
            onObjectInitial += new OnObjectRefresh(_objSumary.SetObjects);
            onSetImage += new OnSetImage(_objCheckImage.SetImage);
        }
        public x9Recs x9Stuff = new x9Recs();
        public XmlDocument xmlFields = new XmlDocument();
        private string allImgFile = Path.GetTempFileName();
        private FileStream checkImageFS;
        private BinaryReader checkImageBR;

        private static int tvX9_AfterSelect_cur25Rec = 0;

        private void OpenToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (ofdX9.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                onObjectRefresh();
                this.Cursor = Cursors.WaitCursor;
                progbLoad.Visible = true;
                lblLoad.Visible = true;
                x9Stuff.Clear();
                ShowX9File(ofdX9.FileName);
                progbLoad.Visible = false;
                this.Cursor = Cursors.Default;
                lblFile.Text = ofdX9.FileName;
                onCreateNodeValues();
                _objSumary.Refresh();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        public void ShowX9File(string x9File)
        {

            // open x9.37 file from bank
            FileStream fs = new FileStream(x9File, FileMode.Open, FileAccess.Read, FileShare.Read);
            //Dim ofs As New FileStream(allImgFile, FileMode.Create)
            int curPos = 0;
            // 37 is EBCDIC encoding
            BinaryReader br = new BinaryReader(fs, System.Text.Encoding.GetEncoding(37));
            byte[] reclenB = new byte[4]; // to hold rec length in Big Endian byte order (motorola format) why Big Endian??
            ArrayList alImg = new ArrayList();
            int imgNbr = 0;

            // Read first record
            reclenB = br.ReadBytes(4); // first 4 bytes hold the record length
            curPos += 4;
            Array.Reverse(reclenB); // this is 'cause the rec length is in Big Endian order why? (probably some wise ass)
            Int32 reclen = BitConverter.ToInt32(reclenB, 0); // convert rec length to integer

            // variables to hold currect record
            byte[] recB = null;
            string rec = null;

            // variables to hold various key lengths in the variable record type 53 which also holds the check image
            int refKeyLen = 0;
            int sigLen = 0;
            int imgLen = 0;

            // counts
            int fileRecCount = 0;
            int checkCount = 0;
            // Flags for start and end of sections
            bool fileStarted = false;
            bool clStarted = false;
            bool bundleStarted = false;
            bool fileEnded = false;
            bool clEnded = false;
            bool bundleEnded = false;
            bool checkStarted = false;
            bool checkFront50 = false;
            bool checkFront52 = false;
            bool checkBack50 = false;
            bool checkBack52 = false;
            bool useEbcidic = false;
            bool first = true;
            fileStarted = false; // Flag for header
            fileEnded = false; // flag for footer
            clStarted = false; // flag for cash letter header
            clEnded = false; // flag for cash letter footer
            bundleStarted = false; // flag for bundle header
            bundleEnded = false; // flage for bundle footer
            checkStarted = false;
            checkFront50 = false;
            checkFront52 = false;

            TreeNode clNode = null;
            TreeNode bundleNode = null;
            TreeNode checkNode = null;
            TreeNode creditNode = null;

            Application.DoEvents();
            long fileSize = fs.Length;
            long readSize = 0;
            lblFile.Text = "Loading ...";
            tvX9.Nodes.Clear();
            // Loop thru the file
            while (reclen > 0)
            {
                recB = new byte[reclen + 1];
                recB = br.ReadBytes(reclen);
                readSize += reclen + 4;
                curPos += reclen;
                if (fileRecCount % 100 == 0)
                {
                    progbLoad.Value = (int)(readSize / (double)fileSize) * 100;
                    lblLoad.Text = (readSize / 1024.0).ToString("###,###,###,###") + " KB of " + (fileSize / 1024.0).ToString("###,###,###,###") + " KB";
                    Application.DoEvents();
                }
                if (first)
                {
                    string asAscii = Encoding.ASCII.GetString(recB);
                    string asEbcidic = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB));
                    //if (Regex.IsMatch(asAscii, @"^[a-zA-Z 0-9]+$")) useEbcidic = false;
                    useEbcidic = asEbcidic.Replace(" ", "").All(Char.IsLetterOrDigit);
                    first = false;
                }
                if (useEbcidic) rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB));
                else rec = Encoding.ASCII.GetString(recB);

                rec = Encoding.ASCII.GetString(recB);
                fileRecCount += 1;
                switch (rec.Substring(0, 2))
                {
                    case "01": // File Header record
                        fileStarted = true;
                        tvX9.Nodes.Add(x9Stuff.Add(new x9Rec("01", rec, "")).ToString(), "Header (01)").ForeColor = Properties.Settings.Default.color01;
                        onFileSummary(rec.Substring(0, 2), rec);
                        break;
                    case "10": // cash file header
                        if (fileStarted)
                        {
                            if (clStarted)
                            {
                                if (clEnded)
                                {
                                    clEnded = false;
                                }
                                else
                                {
                                    MessageBox.Show("No Cash Letter Control record.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lblFile.ForeColor = Color.Red;
                                    lblFile.Text += " - Invalid file";
                                    return;
                                }
                            }
                            else
                            {
                                clStarted = true;
                            }
                            clNode = tvX9.Nodes[0].Nodes.Add(x9Stuff.Add(new x9Rec("10", rec, "")).ToString(), "Cash Letter Header (10)");
                            clNode.ForeColor = Properties.Settings.Default.color10;
                            onCashLetterSummary(rec.Substring(0, 2), rec);
                        }
                        else
                        {
                            // no file header yet
                            MessageBox.Show("No File Header Record.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblFile.ForeColor = Color.Red;
                            lblFile.Text += " - Invalid file";
                            return;
                        }
                        break;
                    case "20": // bundle header record
                        if (fileStarted)
                        {
                            if (clStarted)
                            {
                                if (bundleStarted)
                                {
                                    if (bundleEnded)
                                    {
                                        bundleEnded = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("No Bundle Control record.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        lblFile.ForeColor = Color.Red;
                                        lblFile.Text += " - Invalid file";
                                        return;
                                    }
                                }
                                else
                                {
                                    bundleStarted = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No Cash Letter Header record.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lblFile.ForeColor = Color.Red;
                                lblFile.Text += " - Invalid file";
                                return;
                            }
                        }
                        else
                        {
                            // no file header yet
                            MessageBox.Show("No File Header Record.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblFile.ForeColor = Color.Red;
                            lblFile.Text += " - Invalid file";
                            return;
                        }
                        bundleNode = clNode.Nodes.Add(x9Stuff.Add(new x9Rec("20", rec, "")).ToString(), "Bundle Header (20)");
                        bundleNode.ForeColor = Properties.Settings.Default.color20;
                        onBundleSummary(rec.Substring(0, 2), rec);
                        break;
                    case "25": // check detail record
                        if (bundleStarted && !bundleEnded)
                        {
                            if (checkStarted)
                            {
                                // make sure we got everything for previous check
                                if (!checkFront50)
                                {
                                    // no check front 50
                                    MessageBox.Show("No Check Image Detail Record 50 - Front.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lblFile.ForeColor = Color.Red;
                                    lblFile.Text += " - Invalid file";
                                    return;
                                }
                                if (!checkFront52)
                                {
                                    // no check front 52
                                    MessageBox.Show("No Check Image Data Record 52 - Front.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lblFile.ForeColor = Color.Red;
                                    lblFile.Text += " - Invalid file";
                                    return;
                                }
                                if (!checkBack50)
                                {
                                    // no check back 50
                                    MessageBox.Show("No Check Image Detail Record 50 - Back.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lblFile.ForeColor = Color.Red;
                                    lblFile.Text += " - Invalid file";
                                    return;
                                }
                                if (!checkBack52)
                                {
                                    // no check back 52
                                    MessageBox.Show("No Check Image Data Record 52 - Back.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    lblFile.ForeColor = Color.Red;
                                    lblFile.Text += " - Invalid file";
                                    return;
                                }
                                checkBack50 = false;
                                checkBack52 = false;
                                checkFront50 = false;
                                checkFront52 = false;
                            }
                            else
                            {
                                checkStarted = true;
                            }

                        }
                        else
                        {
                            // no bundle header yet
                            MessageBox.Show("No Bundle Header Record.", "Error MTS.ICLViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            lblFile.ForeColor = Color.Red;
                            lblFile.Text += " - Invalid file";
                            return;
                        }
                        checkCount += 1;
                        if (Properties.Settings.Default.showItemNumber)
                        {
                            checkNode = bundleNode.Nodes.Add(x9Stuff.Add(new x9Rec("25", rec, "")).ToString(), checkCount.ToString("#,###,###") + ": Check Detail (25)");
                        }
                        else
                        {
                            checkNode = bundleNode.Nodes.Add(x9Stuff.Add(new x9Rec("25", rec, "")).ToString(), "Check Detail (25)");
                        }
                        checkNode.ForeColor = Properties.Settings.Default.color25;
                        break;
                    case "26":
                        checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("26", rec, "")).ToString(), "Addendum A (26)").ForeColor = Color.Green;
                        break;
                    case "28":

                        checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("28", rec, "")).ToString(), "Addendum C (28)").ForeColor = Color.Green;
                        break;
                    case "31":
                        checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("31", rec, "")).ToString(), "Return (31)").ForeColor = Color.Green;
                        break;
                    case "32":
                        checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("32", rec, "")).ToString(), "Return Addendum A (32)").ForeColor = Color.Green;
                        break;
                    case "33":
                        checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("33", rec, "")).ToString(), "Return Addendum B (33)").ForeColor = Color.Green;
                        break;
                    case "35":
                        checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("35", rec, "")).ToString(), "Return Addendum D (35)").ForeColor = Color.Green;
                        break;
                    case "50":
                        if (checkStarted)
                        {
                            if (checkFront50)
                            {
                                // back of check
                                checkBack50 = true;
                                checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("50", rec, "")).ToString(), "Image Detail Back (50)").ForeColor = Properties.Settings.Default.color50;
                            }
                            else
                            {
                                // front of check
                                checkFront50 = true;
                                checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("50", rec, "")).ToString(), "Image Detail Front (50)").ForeColor = Properties.Settings.Default.color50;
                            }
                        }
                        break;
                    case "52":
                        curPos -= reclen;
                        // read first 105 characters
                        if (useEbcidic) rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB),0,105);
                        else rec = Encoding.ASCII.GetString(recB, 0, 105);
                        // get length of image reference key 102-105
                        refKeyLen = int.Parse(rec.Substring(101));
                        // read image ref key and digital sig length
                        if (useEbcidic) rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB), 0, 105 + refKeyLen + 5);
                        else rec = Encoding.ASCII.GetString(recB, 0, 105 + refKeyLen + 5);
                        sigLen = int.Parse(rec.Substring(105 + refKeyLen));
                        // read everything except image
                        if (useEbcidic) rec = Encoding.ASCII.GetString(Encoding.Convert(Encoding.GetEncoding(37), Encoding.GetEncoding("ASCII"), recB), 0, 105 + refKeyLen + 5 + sigLen + 7);
                        else rec = Encoding.ASCII.GetString(recB, 0, 105 + refKeyLen + 5 + sigLen + 7);
                        curPos += 105 + refKeyLen + 5 + sigLen + 7;
                        imgLen = int.Parse(rec.Substring(rec.Length - 7));
                        byte[] outArr = new byte[recB.GetUpperBound(0) - rec.Length + 1];
                        Array.Copy(recB, rec.Length, outArr, 0, recB.Length - rec.Length);
                        
                        if (checkStarted)
                        {
                            if (checkFront52)
                            {
                                // back image of check
                                checkBack52 = true;
                                checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("52", rec, curPos.ToString() + "," + outArr.Length.ToString())).ToString(), "Image Data Back (52)").ForeColor = Properties.Settings.Default.color52;
                            }
                            else
                            {
                                // front image of check
                                checkFront52 = true;
                                checkNode.Nodes.Add(x9Stuff.Add(new x9Rec("52", rec, curPos.ToString() + "," + outArr.Length.ToString())).ToString(), "Image Data Front (52)").ForeColor = Properties.Settings.Default.color52;
                            }
                        }
                        imgNbr += 1;
                        curPos += outArr.Length;
                        break;
                    case "61":
                        // read first 105 characters
                        if (bundleStarted && !bundleEnded)
                        {
                            checkNode = bundleNode.Nodes.Add(x9Stuff.Add(new x9Rec("61", rec, "")).ToString(), "Credit/Reconcilation Record (61)");
                            checkNode.ForeColor = Properties.Settings.Default.color61;
                            checkStarted = true;
                            onCreditSummary(rec.Substring(0, 2), rec);
                            checkBack50 = false;
                            checkBack52 = false;
                            checkFront50 = false;
                            checkFront52 = false;
                        }
                        break;
                    case "70":
                        bundleEnded = true;
                        bundleNode.Nodes.Add(x9Stuff.Add(new x9Rec("70", rec, "")).ToString(), "Bundle Control (70)").ForeColor = Properties.Settings.Default.color20;
                        onBundleSummary(rec.Substring(0, 2), rec);
                        break;
                    case "90":
                        clEnded = true;
                        clNode.Nodes.Add(x9Stuff.Add(new x9Rec("90", rec, "")).ToString(), "Cash Letter Control (90)").ForeColor = Properties.Settings.Default.color10;
                        onCashLetterSummary(rec.Substring(0, 2), rec);
                        break;
                    case "99":
                        fileEnded = true;
                        tvX9.Nodes.Add(x9Stuff.Add(new x9Rec("99", rec, "")).ToString(), "File Control (99)").ForeColor = Properties.Settings.Default.color01;
                        onFileSummary(rec.Substring(0, 2), rec);
                        break;
                }
                reclenB = br.ReadBytes(4);
                curPos += 4;
                if (reclenB.Length == 4)
                {
                    Array.Reverse(reclenB);
                    reclen = BitConverter.ToInt32(reclenB, 0);
                }
                else
                {
                    reclen = 0;
                }
            }

            br.Close();
            fs.Close();
            checkImageFS = new FileStream(x9File, FileMode.Open, FileAccess.Read, FileShare.Read);
            checkImageBR = new BinaryReader(checkImageFS);

            viewImageToolStripMenuItem.Enabled = true;
            SearchToolStripMenuItem.Enabled = true;
            exportSingleImagesToolStripMenuItem.Enabled = true;
            ExportFrontImagesToolStripMenuItem.Enabled = true;
            ExportImagesToolStripMenuItem.Enabled = true;
            summaryToolStripMenuItem.Enabled = true;
            mnuiCopy.Enabled = true;
        }


        public void Byte2Image(ref Image NewImage, byte[] ByteArr)
        {
            Byte2Image(ref NewImage, ByteArr, 0);
        }

        public void Byte2Image(ref Image NewImage, byte[] ByteArr, int startIndex)
        {
            MemoryStream ImageStream = null;
            byte[] newArr = new byte[ByteArr.GetUpperBound(0) - startIndex + 1];
            Array.Copy(ByteArr, startIndex, newArr, 0, ByteArr.Length - startIndex);
            try
            {
                if (newArr.GetUpperBound(0) > 0)
                {
                    ImageStream = new MemoryStream(newArr);
                    NewImage = Image.FromStream(ImageStream);
                }
                else
                {
                    NewImage = null;
                }
                ImageStream.Close();
            }
            catch (Exception ex)
            {
                NewImage = null;
            }
        }

        /// <summary>
        /// This function will join the TIFF file with a specific compression format
        /// </summary>
        /// <param name="imageFiles">array list with source image files</param>
        /// <param name="outFile">target TIFF file to be produced</param>
        /// <param name="compressEncoder">compression codec enum</param>
        public void JoinTiffImages(ArrayList imageFiles, string outFile, EncoderValue compressEncoder)
        {
            try
            {
                //If only one page in the collection, copy it directly to the target file.
                if (imageFiles.Count == 1)
                {
                    File.Copy((string)(imageFiles[0]), outFile, true);
                    return;
                }

                //use the save encoder
                System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;

                EncoderParameters ep = new EncoderParameters(2);
                ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.MultiFrame));
                ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, System.Convert.ToInt64(compressEncoder));

                Bitmap pages = null;
                int frame = 0;
                ImageCodecInfo info = GetEncoderInfo("image/tiff");


                foreach (string strImageFile in imageFiles)
                {
                    if (frame == 0)
                    {
                        pages = (Bitmap)(Image.FromFile(strImageFile));

                        //save the first frame
                        pages.Save(outFile, info, ep);
                    }
                    else
                    {
                        //save the intermediate frames
                        ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.FrameDimensionPage));

                        Bitmap bm = (Bitmap)(Image.FromFile(strImageFile));
                        pages.SaveAdd(bm, ep);
                        bm.Dispose();
                    }

                    if (frame == imageFiles.Count - 1)
                    {
                        //flush and close.
                        ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.Flush));
                        pages.SaveAdd(ep);
                    }

                    frame += 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return;
        }

        public void JoinTiffImages2(string outFile, EncoderValue compressEncoder)
        {
            //use the save encoder
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.MultiFrame));
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, System.Convert.ToInt64(compressEncoder));
            Bitmap singleTiff = null;
            Bitmap pages = null;
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo("image/tiff");
            Image cImg = null;
            int startPos = 0;
            int imgLen = 0;
            byte[] recB = null;

            Closing exporting = new Closing();
            exporting.Text = "Exporting check images";
            exporting.lblCleanup.Text = "exporting check images to tiff...";
            exporting.Show();
            this.Cursor = Cursors.WaitCursor;
            int reccnt = 0;
                       
            try
            {
                foreach (x9Rec rec in x9Stuff)
                {
                    if (rec.recImage.Trim().Length > 0)
                    {
                        startPos = System.Convert.ToInt32(rec.recImage.Substring(0, rec.recImage.IndexOf(",")));
                        imgLen = System.Convert.ToInt32(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1));
                        checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin);
                        recB = new byte[imgLen + 1];
                        recB = checkImageBR.ReadBytes(imgLen);
                        Byte2Image(ref cImg, recB, 0);                       
                        if (frame == 0)
                        {
                            pages = (Bitmap)cImg;

                            //save the first frame
                            pages.Save(outFile, info, ep);
                            singleTiff = (Bitmap)cImg;

                            singleTiff.Save(outFile, ImageFormat.Tiff);
                        }
                        else
                        {
                            //save the intermediate frames
                            ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.FrameDimensionPage));

                            pages.SaveAdd((Bitmap)cImg, ep);
                        }
                        cImg = null;
                        frame += 1;
                    }
                    reccnt += 1;
                    exporting.pbCleanup.Value = (int)(reccnt / (double)x9Stuff.Count) * 100;
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                exporting.TopMost = false;
                MessageBox.Show(ex.Message + " rec count=" + reccnt.ToString("###,###,###"), "Error Exporting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //flush and close.
            if (pages == null)
            {
                ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.Flush));
                pages.SaveAdd(ep);
            }
            exporting.Close();
            this.Cursor = Cursors.Default;
        }

        public void JoinTiffImages3(string outFile, EncoderValue compressEncoder)
        {
            //use the save encoder
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.MultiFrame));
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, System.Convert.ToInt64(compressEncoder));

            Bitmap pages = null;
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo("image/tiff");
            Image cImg = null;
            int startPos = 0;
            int imgLen = 0;
            byte[] recB = null;

            Closing exporting = new Closing();
            bool frontImage = false;
            exporting.Text = "Exporting check images";
            exporting.lblCleanup.Text = "exporting check images to tiff...";
            exporting.Show();
            this.Cursor = Cursors.WaitCursor;
            int reccnt = 0;
          
            try
            {
                foreach (x9Rec rec in x9Stuff)
                {
                    if (rec.recType == "50" && rec.recData.Substring(31, 1) == "0")
                    {
                        frontImage = true;
                    }
                    if (rec.recImage.Trim().Length > 0 && frontImage)
                    {
                        frontImage = false;
                        startPos = System.Convert.ToInt32(rec.recImage.Substring(0, rec.recImage.IndexOf(",")));
                        imgLen = System.Convert.ToInt32(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1));
                        checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin);
                        recB = new byte[imgLen + 1];
                        recB = checkImageBR.ReadBytes(imgLen);
                        Byte2Image(ref cImg, recB, 0);                      
                        if (frame == 0)
                        {
                            pages = (Bitmap)cImg;

                            //save the first frame
                            pages.Save(outFile, info, ep);
                        }
                        else
                        {
                            //save the intermediate frames
                            ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.FrameDimensionPage));

                            pages.SaveAdd((Bitmap)cImg, ep);
                        }

                        frame += 1;
                    }
                    reccnt += 1;
                    exporting.pbCleanup.Value = (int)(reccnt / (double)x9Stuff.Count) * 100;
                    Application.DoEvents();
                }
                
            }
            catch (Exception ex)
            {
                exporting.TopMost = false;
                MessageBox.Show(ex.Message + " rec count=" + reccnt.ToString("###,###,###"), "Error Exporting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //flush and close.
            if (pages == null)
            {
                ep.Param[0] = new EncoderParameter(enc, System.Convert.ToInt64(EncoderValue.Flush));
                pages.SaveAdd(ep);
            }            
            exporting.Close();
            this.Cursor = Cursors.Default;
        }


        public void SaveTiffintoSingle(string outFile, EncoderValue compressEncoder)
        {
            //use for save image as single tiff
            int frame = 0;
            int startPos = 0;
            int imgLen = 0;
            byte[] recB = null;

            Closing exporting = new Closing();
            bool frontImage = false;
            exporting.Text = "Exporting check images";
            exporting.lblCleanup.Text = "exporting check images to tiff...";
            exporting.Show();
            this.Cursor = Cursors.WaitCursor;
            int reccnt = 0;
            string SingleTiffImagePath = string.Empty;
            try
            {
                foreach (x9Rec rec in x9Stuff)
                {
                    if (rec.recType == "50" && rec.recData.Substring(31, 1) == "0")
                    {
                        frontImage = true;
                    }
                    else if (rec.recType == "50" && rec.recData.Substring(31, 1) == "1")
                    {
                        frontImage = false;
                    }
                    if (rec.recImage.Trim().Length > 0)
                    {
                        startPos = System.Convert.ToInt32(rec.recImage.Substring(0, rec.recImage.IndexOf(",")));
                        imgLen = System.Convert.ToInt32(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1));
                        checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin);
                        recB = new byte[imgLen + 1];
                        recB = checkImageBR.ReadBytes(imgLen);
                        if (!Directory.Exists(outFile))
                            Directory.CreateDirectory(outFile);
                        if (frontImage)
                            SingleTiffImagePath = frame + "F.tiff";
                        else
                        {
                            SingleTiffImagePath = frame + "R.tiff";
                            frame += 1;
                        }
                        if (File.Exists(Path.Combine(outFile, SingleTiffImagePath)))
                            File.Delete(Path.Combine(outFile, SingleTiffImagePath));
                        File.WriteAllBytes(Path.Combine(outFile, SingleTiffImagePath), recB);
                    }
                    reccnt += 1;
                    exporting.pbCleanup.Value = (int)(reccnt / (double)x9Stuff.Count) * 100;
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                exporting.TopMost = false;
                MessageBox.Show(ex.Message + " rec count=" + reccnt.ToString("###,###,###"), "Error Exporting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            exporting.Close();
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// Getting the supported codec info.
        /// </summary>
        /// <param name="mimeType">description of mime type</param>
        /// <returns>image codec info</returns>
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                {
                    return encoders[j];
                }
            }

            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }

        private void tvX9_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            x9Rec rec = x9Stuff[Convert.ToInt32(e.Node.Name)];
            tvX9_AfterSelect_cur25Rec = 0;
            txtRec.Text = rec.recData;
            int iRecType = 0;
            int.TryParse(rec.recType, out iRecType);
            dgvFields.Rows.Clear();
            XmlNodeList fieldNodes = null;
            int fieldStart = 0;
            int fieldLen = 0;
            fieldNodes = xmlFields.SelectNodes("records/record[@type='" + rec.recType + "']/field");
            if (fieldNodes != null)
            {
                foreach (XmlNode n in fieldNodes)
                {
                    fieldStart = System.Convert.ToInt32(n.Attributes["start"].Value) - 1;
                    fieldLen = System.Convert.ToInt32(n.Attributes["end"].Value) - fieldStart;
                    dgvFields.Rows.Add(n.Attributes["name"].Value, rec.recData.Substring(fieldStart, fieldLen), n.Attributes["type"].Value, n.Attributes["comments"].Value);
                }
                onSetImage(null, null);
            }
            if (iRecType >= 25 && iRecType < 70 && Properties.Settings.Default.checkImage)
            {
                int curRec = 0;
                string frontImg = null;
                string backImg = null;
                int.TryParse(e.Node.Name, out curRec);
                x9Rec imgRec = x9Stuff[curRec];
                while (!(imgRec.recType == "25" || imgRec.recType == "61" || curRec < 0))
                {
                    curRec -= 1;
                    imgRec = x9Stuff[curRec];
                }
                if (curRec < 0 || curRec == tvX9_AfterSelect_cur25Rec)
                {
                    return;
                }
                if (curRec >= 0)
                {
                    tvX9_AfterSelect_cur25Rec = curRec;
                    // move forward to first 52
                    while (!(imgRec.recType == "52" || curRec > x9Stuff.Count))
                    {
                        curRec += 1;
                        imgRec = x9Stuff[curRec];
                    }
                    if (curRec < x9Stuff.Count)
                    {
                        frontImg = imgRec.recImage;
                        // move forward to second 52
                        curRec += 1;
                        imgRec = x9Stuff[curRec];
                        while (!(imgRec.recType == "52" || curRec > x9Stuff.Count))
                        {
                            curRec += 1;
                            imgRec = x9Stuff[curRec];
                        }
                        if (curRec < x9Stuff.Count)
                        {
                            backImg = imgRec.recImage;
                        }
                    }
                }
                if (tcX9.TabPages.Count < 2)
                {
                    tcX9.TabPages.Add(tpImg);
                }
                pbCheck.Visible = false;
                pbFront.Visible = true;
                Image fImg = null;
                Image bImg = null;
                int startPos = System.Convert.ToInt32(frontImg.Substring(0, frontImg.IndexOf(",")));
                int imgLen = System.Convert.ToInt32(frontImg.Substring(frontImg.IndexOf(",") + 1));
                byte[] recB = new byte[imgLen + 1];
                checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin);
                recB = checkImageBR.ReadBytes(imgLen);
                Byte2Image(ref fImg, recB, 0);
                pbFront.Image = fImg;
                pbBack.Visible = true;
                startPos = System.Convert.ToInt32(backImg.Substring(0, backImg.IndexOf(",")));
                imgLen = System.Convert.ToInt32(backImg.Substring(backImg.IndexOf(",") + 1));
                recB = new byte[imgLen + 1];
                checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin);
                recB = checkImageBR.ReadBytes(imgLen);
                Byte2Image(ref bImg, recB, 0);
                pbBack.Image = bImg;
                onSetImage(fImg, bImg);
            }
            else
            {
                pbBack.Visible = false;
                pbFront.Visible = false;
                pbCheck.Visible = true;
                if (rec.recImage.Length == 0)
                {
                    if (tcX9.TabPages.Count > 1)
                    {
                        tcX9.TabPages.RemoveAt(1);
                    }
                }
                else
                {
                    if (tcX9.TabPages.Count < 2)
                    {
                        tcX9.TabPages.Add(tpImg);
                    }
                    Image cImg = null;
                    int startPos = System.Convert.ToInt32(rec.recImage.Substring(0, rec.recImage.IndexOf(",")));
                    int imgLen = System.Convert.ToInt32(rec.recImage.Substring(rec.recImage.IndexOf(",") + 1));
                    byte[] recB = new byte[imgLen + 1];
                    checkImageBR.BaseStream.Seek(startPos, SeekOrigin.Begin);
                    recB = checkImageBR.ReadBytes(imgLen);
                    Byte2Image(ref cImg, recB, 0);
                    pbFront.Image = cImg;
                }
            }
        }

        private void txtRec_GotFocus(object sender, System.EventArgs e)
        {
            lblPos.Text = "column: " + (txtRec.SelectionStart + 1).ToString();
        }

        private void txtRec_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            lblPos.Text = "column: " + (txtRec.SelectionStart + 1).ToString();
        }

        private void frmViewer_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.ClosePrompt == false || (Properties.Settings.Default.ClosePrompt && frmClose.ShowDialog() == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    Application.DoEvents();
                    Closing cleanup = new Closing();
                    cleanup.Show();
                    checkImageBR.Close();
                    checkImageFS.Close();
                    File.Delete(allImgFile);
                    cleanup.Close();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                e.Cancel = true;
            }
        }



        private void frmViewer_Load(object sender, System.EventArgs e)
        {
            this.Show();
            if (ofdX9.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                progbLoad.Visible = true;
                lblLoad.Visible = true;
                ShowX9File(ofdX9.FileName);
                progbLoad.Visible = false;
                lblLoad.Visible = false;
                this.Cursor = Cursors.Default;
                lblFile.Text = ofdX9.FileName;
            }
            if (File.Exists(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "x9fields.xml")))
            {
                xmlFields.Load(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "x9fields.xml"));
            }
        }

        private void txtRec_LostFocus(object sender, System.EventArgs e)
        {
            lblPos.Text = "";
        }

        private void txtRec_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            lblPos.Text = "column: " + (txtRec.SelectionStart + 1).ToString();
        }

        private void AboutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            //AboutBox.ShowDialog();
        }

        private void CopyToClipboardToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetImage(pbCheck.Image);
        }

        private void SaveAsToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (sfdImg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                pbCheck.Image.Save(sfdImg.FileName);
            }
        }

        private void mnuiCopy_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Clipboard.Clear();
            if (ActiveControl is TextBox)
            {
                System.Windows.Forms.Clipboard.SetText(((TextBox)ActiveControl).SelectedText);
            }
            else if (ActiveControl is ComboBox)
            {
                System.Windows.Forms.Clipboard.SetText(((ComboBox)ActiveControl).Text);
            }
            else if (ActiveControl is PictureBox)
            {
                System.Windows.Forms.Clipboard.SetImage(((PictureBox)ActiveControl).Image);
            }
            else if (ActiveControl is ListBox)
            {
                System.Windows.Forms.Clipboard.SetText(((ListBox)ActiveControl).Text);
            }
            else if (ActiveControl is TreeView)
            {
                if (((TreeView)ActiveControl).SelectedNode != null)
                    System.Windows.Forms.Clipboard.SetText(((TreeView)ActiveControl).SelectedNode.Text);
            }
            else if (ActiveControl is DataGridView)
            {
                System.Windows.Forms.Clipboard.SetDataObject(((DataGridView)ActiveControl).GetClipboardContent());
            }
            else
            {
                // No action makes sense for the other controls.
            }
        }

        private void mnuiOptions_Click(object sender, System.EventArgs e)
        {
            if (frmOpt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                setNodeColor(tvX9.Nodes);
            }
        }

        private void setNodeColor(TreeNodeCollection tvNodes)
        {
            foreach (TreeNode tn in tvNodes)
            {
                if (tn.Text.EndsWith("(01)") || tn.Text.EndsWith("(99)"))
                {
                    tn.ForeColor = Properties.Settings.Default.color01;
                }
                else if (tn.Text.EndsWith("(10)") || tn.Text.EndsWith("(90)"))
                {
                    tn.ForeColor = Properties.Settings.Default.color01;
                }
                else if (tn.Text.EndsWith("(20)") || tn.Text.EndsWith("(70)"))
                {
                    tn.ForeColor = Properties.Settings.Default.color10;
                }
                else
                {
                    tn.ForeColor = Properties.Settings.Default.color20;
                }
                if (tn.Nodes.Count > 0)
                {
                    setNodeColor(tn.Nodes);
                }
            }
        }
         

        private void ExportImagesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (sfdImg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                JoinTiffImages2(sfdImg.FileName, EncoderValue.CompressionCCITT4);
            }
        }

        private void SearchToolStripMenuItem_Click_1(object sender, System.EventArgs e)
        {
            Search search = new Search();
            search.frmViewer = this;
            search.TopMost = true;
            search.Show();
        }

        private void ExportFrontImagesToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (sfdImg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                JoinTiffImages3(sfdImg.FileName, EncoderValue.CompressionCCITT4);
            }
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                onObjectInitial();
                _objSumary.Show();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void viewImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _objCheckImage.Show();
        }

        private void exportSingleImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingleImageDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveTiffintoSingle(SingleImageDialog.SelectedPath, EncoderValue.CompressionCCITT4);
            }
        }
    }

} //end of root namespace
