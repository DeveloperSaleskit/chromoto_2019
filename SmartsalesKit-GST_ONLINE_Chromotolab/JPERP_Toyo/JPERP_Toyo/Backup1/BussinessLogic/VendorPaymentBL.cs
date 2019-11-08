using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Collections.Specialized;

using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class VendorPaymentBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public VendorPaymentBL()
        {
            this.Exception = null;
            this.ErrorMessage = "";
            mException = null;
            mErrorMsg = "";
        }

        public void SetDefaultException()
        {
            this.Exception = null;
            this.ErrorMessage = "";
            mException = null;
            mErrorMsg = "";
        }

        public void Insert(string mode, string PaymentCode, DateTime Date, long VendorID, Decimal NetAmount, string Narration, string XmlString, int Cnt, string CustomerBankName, string BankName, string ChequeNo, string ChequeDate, long CurrencyID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_mode", mode);
            para.Add("@i_FYID", Account.Common.CurrentUser.FYID.ToString());
            para.Add("@i_PaymentCode", PaymentCode);
            para.Add("@i_PaymentDate", Date.ToString("MM/dd/yyyy"));
            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_CustomerBankName", CustomerBankName);
            para.Add("@i_BankName", BankName);
            if (ChequeDate != null && ChequeDate != "")
                para.Add("@i_ChequeDate", Convert.ToDateTime(ChequeDate).ToString("MM/dd/yyyy"));
            para.Add("@i_Narration", Narration);
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_CurrencyID", CurrencyID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_VendorPayment_Insert", para, true, ref mException, ref mErrorMsg, "Vendor Payment - Insert");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
        }

        public void Update(string mode, long PaymentID, string PaymentCode, DateTime Date, long VendorID, Decimal NetAmount, string Narration, string XmlString, int Cnt, string CustomerBankName, string BankName, string ChequeNo, string ChequeDate, long CurrencyID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_mode", mode);
            para.Add("@i_PaymentID", PaymentID.ToString());
            para.Add("@i_FYID", Account.Common.CurrentUser.FYID.ToString());
            para.Add("@i_PaymentCode", PaymentCode);
            para.Add("@i_PaymentDate", Date.ToString("MM/dd/yyyy"));
            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_CustomerBankName", CustomerBankName);
            para.Add("@i_BankName", BankName);
            if (ChequeDate != null && ChequeDate != "")
                para.Add("@i_ChequeDate", Convert.ToDateTime(ChequeDate).ToString("MM/dd/yyyy"));
            para.Add("@i_Narration", Narration);
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_CurrencyID", CurrencyID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_VendorPayment_Update", para, true, ref mException, ref mErrorMsg, "Vendor Payment - Update");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
        }

    }
}
