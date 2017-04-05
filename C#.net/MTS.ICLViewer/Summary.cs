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
    public partial class Summary : Form
    {
        private static ICLFileSummary _objFileSummary;
        private static ICLCashLetterSummary _objCashLetterSummary;
        private static ICLCreditSummary _objCreditSummary;

        private static ICLFileDetail _ifd;
        private static ICLCashLetterDetail _icld;
        private static ICLCreditDetail _icrd;

        public Summary()
        {
            try
            {
                SetObjects();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetObjectsNewForm()
        {
            _ifd = new ICLFileDetail();
            _icld = new ICLCashLetterDetail();
            _icrd = new ICLCreditDetail();
            _objFileSummary = new ICLFileSummary();
            _objCashLetterSummary = new ICLCashLetterSummary();
            _objCreditSummary = new ICLCreditSummary();
            this.Refresh();
            trvSummary.Refresh();
        }
        public void SetObjects()
        {
            _ifd = _ifd == null ? new ICLFileDetail() : _ifd;
            _icld = _icld == null ? new ICLCashLetterDetail() : _icld;
            _icrd = _icrd == null ? new ICLCreditDetail() : _icrd;
            _objFileSummary = _objFileSummary == null ? new ICLFileSummary() : _objFileSummary;
            _objCashLetterSummary = _objCashLetterSummary == null ? new ICLCashLetterSummary() : _objCashLetterSummary;
            _objCreditSummary = _objCreditSummary == null ? new ICLCreditSummary() : _objCreditSummary;
        }

        private void CashLetterEnd()
        {
            _objCashLetterSummary.Add(_icld);
            _icld = new ICLCashLetterDetail();
        }

        private void BundleEnd()
        {
            if (_icrd != null && _icrd.CreditAmount > 0)
            {
                _objCreditSummary.Add(_icrd);
                _icrd = new ICLCreditDetail();
            }
        }

        public void FileSummary(string RecType, string RecData)
        {
            if (RecType == "01")
            {
                _ifd.BankName = RecData.Substring(36, 18);
                _ifd.FileCreationDate = RecData.Substring(23, 8);
                _ifd.FileCreationTime = RecData.Substring(31, 4);

            }
            if (RecType == "99")
            {
                _ifd.TotalFileAmount = Convert.ToInt64(RecData.Substring(24, 16));
                _ifd.TotalNumberofRecords = Convert.ToInt32(RecData.Substring(8, 8));
            }
        }
        public void CashLetterSummary(string RecType, string RecData)
        {
            if (RecType == "10" || RecType == "90")
            {
                if (RecType == "10")
                {
                    _icld.CashLetterPosition = Convert.ToInt32(RecData.Substring(44, 8));
                }
                if (RecType == "90")
                {
                    _icld.CashLetterAmount = Convert.ToInt64(RecData.Substring(16, 14));
                    CashLetterEnd();
                }
            }
        }
        public void BundleSummary(string RecType, string RecData)
        {
            if (RecType == "20" || RecType == "70")
            {
                if (RecType == "20")
                {
                }
                if (RecType == "70")
                {
                    BundleEnd();
                }
            }
        }

        public void CreditSummary(string RecType, string RecData)
        {
            if (RecType == "61")
            {
                _icrd.CreditAmount = Convert.ToInt64(RecData.Substring(48, 10));
                _icrd.PostingAccRT = RecData.Substring(19, 9);
                _icrd.PostingAccBankOnUs = RecData.Substring(28, 20);
            }
        }


        private void Summary_Load(object sender, EventArgs e)
        {
            try
            {
                CreateNodeValues();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateNodeValues()
        {
            lblHeader.Text = _ifd.BankName.Trim() + " - ICL File Summary";
            trvSummary.Nodes.Clear();
            trvSummary.Nodes.Add("File Total Amount ($) - " + _ifd.TotalFileAmount);
            trvSummary.Nodes[0].Nodes.Add("File Creation Date - " + _ifd.FileCreationDate);
            trvSummary.Nodes[0].Nodes.Add("Total No of Records - " + _ifd.TotalNumberofRecords);
            trvSummary.Nodes[0].Nodes.Add("Total No of Cash Letter - " + _objCashLetterSummary.Count);
            trvSummary.Nodes.Add("Total Cash Letter Amount ($) - " + _objCashLetterSummary.TotalCashLetterAmount);
            foreach (ICLCashLetterDetail icd in _objCashLetterSummary)
            {
                trvSummary.Nodes[1].Nodes.Add("Cash Letter " + icd.CashLetterPosition + " Amount ($) - " + icd.CashLetterAmount);
            }
            if (_objCreditSummary != null && _objCreditSummary.Count > 0)
            {
                trvSummary.Nodes[1].Nodes.Add("Total No of Credit Records - " + _objCreditSummary.Count);
                trvSummary.Nodes.Add("Total Credit Amount ($) - " + _objCreditSummary.TotalCreditRecordAmount);
                foreach (ICLCreditDetail crd in _objCreditSummary)
                {
                    trvSummary.Nodes[2].Nodes.Add(string.Format("Posting bank,{0},{1}", crd.PostingAccBankOnUs.Trim(), crd.CreditAmount));
                }
            }
        }

        private void trvSummary_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
            if (e.Node.Text.Contains("Posting bank"))
            {
                e.DrawDefault = false;
                string pbac = "Posting Bank On-Us ";
                string amt = "Amount ($) - ";
                string[] texts = e.Node.Text.Split(',');
                TextRenderer.DrawText(e.Graphics, pbac, this.Font, e.Bounds, Color.Black, Color.Empty, TextFormatFlags.VerticalCenter);
                using (Font font = new Font(this.Font, FontStyle.Regular))
                {
                    SizeF s = e.Graphics.MeasureString(pbac, font);
                    TextRenderer.DrawText(e.Graphics, texts[1], font, new Point(e.Bounds.Left + (int)s.Width, e.Bounds.Top + 10), Color.Red, Color.Empty, TextFormatFlags.VerticalCenter);
                    s = e.Graphics.MeasureString(pbac + texts[1], font);
                    TextRenderer.DrawText(e.Graphics, amt, this.Font, new Point(e.Bounds.Left + (int)s.Width, e.Bounds.Top + 10), Color.Black, Color.Empty, TextFormatFlags.VerticalCenter);
                    s = e.Graphics.MeasureString(pbac + texts[1] + amt, font);
                    TextRenderer.DrawText(e.Graphics, texts[2], font, new Point(e.Bounds.Left + (int)s.Width, e.Bounds.Top + 10), Color.Blue, Color.Empty, TextFormatFlags.VerticalCenter);
                }
            }
        }

        private void trvSummary_AfterExpand(object sender, TreeViewEventArgs e)
        {
            trvSummary.Refresh();
        }

        private void Summary_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            this.Parent = null;
        }
    }
}
