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
    class PurchaseInvoiceBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public PurchaseInvoiceBL()
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
        public Int32 Insert(string PurchaseCode, DateTime PIDate, string SrNo, string VoucherNo, DateTime VoucherDate, long VendorID, long DueDays,
                            DateTime DueDate, decimal ServiceAmount, decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount,
                            decimal HEduCessAmount, decimal AmountAfterExcise, decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal Discount,
                            decimal NetAmount, decimal PaidAmount, string Narration, string XmlString, Int64 Cnt, int GodownID, long PGID,Boolean AgainstCForm
                            , decimal DebitOutstanding, decimal RemainingDebit, decimal AdjustedDebit, string IsAgainstDebit
            , string BankName, string ChequeNo, DateTime ChequeDate
            ,string CustomerBankName,string SGSTAmount,string CGSTAmount,string IGSTAmount)
        {
            SetDefaultException();
            Int32 POID = 0;
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_PurchaseCode", PurchaseCode);
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_PurchaseDate", PIDate.ToString("MM/dd/yyyy"));
            para.Add("@i_SrNo", SrNo);
            para.Add("@i_VoucherNo", VoucherNo);
            para.Add("@i_VoucherDate", VoucherDate.ToString("MM/dd/yyyy"));
            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_DueDays", DueDays.ToString());
            para.Add("@i_DueDate", DueDate.ToString("MM/dd/yyyy"));
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", EduCessAmount.ToString());
            para.Add("@i_HCessAmount", HEduCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_Narration", Narration);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_PGID", PGID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_AgainstCForm", AgainstCForm.ToString());

            para.Add("@i_DebitOutstanding", DebitOutstanding.ToString());
            para.Add("@i_RemainingDebit", RemainingDebit.ToString());
            para.Add("@i_AdjustedDebit", AdjustedDebit.ToString());
            para.Add("@i_IsAgainstDebit", IsAgainstDebit.ToString());

            para.Add("@i_BankName", BankName);
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_ChequeDate", ChequeDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerBankName", CustomerBankName);

            para.Add("@i_SGSTAmount", SGSTAmount.ToString());
            para.Add("@i_CGSTAmount", CGSTAmount.ToString());
            para.Add("@i_IGSTAmount", IGSTAmount.ToString());

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Indent_Insert", para, true, ref mException, ref mErrorMsg, "PurchaseInvoice - Insert");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    if (Validator.DataValidator.IsNumeric(mErrorMsg))
                    {
                        POID = Convert.ToInt32(mErrorMsg);
                    }
                    else
                    {
                        this.ErrorMessage = mErrorMsg;
                    }
                }
            }
            else
            {
                this.Exception = mException;
            }
            return POID;
        }

        public void Update(long PIID, string PurchaseCode, DateTime PIDate, string SrNo, string VoucherNo, DateTime VoucherDate, long VendorID,
                            long DueDays, DateTime DueDate, decimal TotalAmount, decimal ServiceAmount, decimal ExciseAmount, decimal EduCessAmount,
                            decimal HEduCessAmount, decimal AmountAfterExcise, decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal Discount,
                            decimal NetAmount, decimal PaidAmount, string Narration, string XmlString, Int64 Cnt, int GodownID, decimal tempRecvQty, long PGID, Boolean AgainstCForm
            , decimal DebitOutstanding, decimal RemainingDebit, decimal AdjustedDebit, string IsAgainstDebit
            , string BankName, string ChequeNo, DateTime ChequeDate
            , string CustomerBankName, string SGSTAmount, string CGSTAmount, string IGSTAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_PIID", PIID.ToString());
            para.Add("@i_PurchaseCode", PurchaseCode);
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_PurchaseDate", PIDate.ToString("MM/dd/yyyy"));
            para.Add("@i_SrNo", SrNo);
            para.Add("@i_VoucherNo", VoucherNo);
            para.Add("@i_VoucherDate", VoucherDate.ToString("MM/dd/yyyy"));
            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_DueDays", DueDays.ToString());
            para.Add("@i_DueDate", DueDate.ToString("MM/dd/yyyy"));
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", EduCessAmount.ToString());
            para.Add("@i_HCessAmount", HEduCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_Narration", Narration);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_PGID", PGID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_tempQty", tempRecvQty.ToString());
            para.Add("@i_AgainstCForm", AgainstCForm.ToString());

            para.Add("@i_DebitOutstanding", DebitOutstanding.ToString());
            para.Add("@i_RemainingDebit", RemainingDebit.ToString());
            para.Add("@i_AdjustedDebit", AdjustedDebit.ToString());
            para.Add("@i_IsAgainstDebit", IsAgainstDebit.ToString());

            para.Add("@i_BankName", BankName);
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_ChequeDate", ChequeDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerBankName", CustomerBankName);

            para.Add("@i_SGSTAmount", SGSTAmount.ToString());
            para.Add("@i_CGSTAmount", CGSTAmount.ToString());
            para.Add("@i_IGSTAmount", IGSTAmount.ToString());

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Indent_Update", para, true, ref mException, ref mErrorMsg, "PurchaseInvoice - Update");

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
