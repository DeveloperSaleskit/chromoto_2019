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
    class CustomerPaymentBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public CustomerPaymentBL()
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

        public void Insert(string ReceiptCode, DateTime Date, long CustomerID, Decimal NetAmount,
            string Narration, string CustomerBankName, string BankName, string ChequeNo, string ChequeDate, string XmlString, int Cnt, int CompId, long AccountID, bool IsCustomer, long CurrencyID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", Account.Common.CurrentUser.FYID.ToString());
            para.Add("@i_ReceiptCode", ReceiptCode);
            para.Add("@i_ReceiptDate", Date.ToString("MM/dd/yyyy"));
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_CustomerBankName", CustomerBankName);
            para.Add("@i_BankName", BankName);
            if (ChequeDate != null && ChequeDate != "")
                para.Add("@i_ChequeDate", Convert.ToDateTime(ChequeDate).ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerID", CustomerID.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_Narration", Narration);
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            para.Add("@i_CurrencyID", CurrencyID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_CustomerReceipt_Insert", para, true, ref mException, ref mErrorMsg, "Customer Payment - Insert");

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

        public void Update(long ReceiptID, string ReceiptCode, DateTime Date, long CustomerID, Decimal NetAmount, string Narration, string CustomerBankName, string BankName, string ChequeNo, string ChequeDate, string XmlString, int Cnt, int CompId, long AccountID, bool IsCustomer, long CurrencyID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_ReceiptID", ReceiptID.ToString());
            para.Add("@i_FYID", Account.Common.CurrentUser.FYID.ToString());
            para.Add("@i_ReceiptCode", ReceiptCode);
            para.Add("@i_ReceiptDate", Date.ToString("MM/dd/yyyy"));
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_CustomerBankName", CustomerBankName);
            para.Add("@i_BankName", BankName);
            if (ChequeDate != null && ChequeDate != "")
                para.Add("@i_ChequeDate", Convert.ToDateTime(ChequeDate).ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerID", CustomerID.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_Narration", Narration);
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            para.Add("@i_CurrencyID", CurrencyID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_CustomerReceipt_Update", para, true, ref mException, ref mErrorMsg, "Customer Payment - Update");

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
