using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MTS.ICLViewer
{
    public class ICLBase<T> : List<T>
    {

    }
    public sealed class ICLFileSummary : ICLBase<ICLFileDetail>
    {

    }
    public sealed class ICLCashLetterSummary : ICLBase<ICLCashLetterDetail>
    {
        public Int64 TotalCashLetterAmount
        {
            get
            {
                Int64 _amt = 0;
                foreach (ICLCashLetterDetail cld in this)
                {
                    _amt += cld.CashLetterAmount;
                }
                return _amt;
            }
        }
    }
    
    public sealed class ICLCreditSummary : ICLBase<ICLCreditDetail>
    {
        public Int64 TotalCreditRecordAmount
        {
            get
            {
                Int64 _amt = 0;
                foreach (ICLCreditDetail Cd in this)
                {
                    _amt += Cd.CreditAmount;
                }
                return _amt;
            }
        }
    }
    
    public class ICLFileDetail
    {
        public string BankName { get; set; }
        public int TotalNumberofRecords { get; set; }
        public Int64 TotalFileAmount { get; set; }
        public string FileCreationDate { get; set; }
        public string FileCreationTime { get; set; }
    }
    
    public class ICLCashLetterDetail
    {
        public int CashLetterPosition { get; set; }
        public Int64 CashLetterAmount { get; set; }
    }
   
    public class ICLCreditDetail
    {
        public string PostingAccRT { get; set; }
        public string PostingAccBankOnUs { get; set; }
        public Int64 CreditAmount { get; set; }
    }
}
