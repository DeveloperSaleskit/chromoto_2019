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
    class POBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public POBL()
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
                            decimal NetAmount, decimal PaidAmount, string Narration, string XmlString, Int64 Cnt, int GodownID, string CC, string BCC, bool Is_MailSend, int CompId, string CustInvoiceNo)
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
            para.Add("@i_CC", CC.ToString());
            para.Add("@i_BCC", BCC.ToString());
            para.Add("@i_Is_SendMail", Is_MailSend.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CustInvoiceNo", CustInvoiceNo);

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_PO_Insert", para, true, ref mException, ref mErrorMsg, "PurchaseInvoice - Insert");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    if (Validator.DataValidator.IsNumeric(mErrorMsg))
                    {
                        POID = Convert.ToInt32(mErrorMsg);
                        this.ErrorMessage = mErrorMsg;
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
                            decimal NetAmount, decimal PaidAmount, string Narration, string XmlString, Int64 Cnt, int GodownID, string CC, string BCC, bool Is_MailSend, int CompId, string CustInvoiceNo)
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
            para.Add("@i_CC", CC.ToString());
            para.Add("@i_BCC", BCC.ToString());
            para.Add("@i_Is_SendMail", Is_MailSend.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CustInvoiceNo", CustInvoiceNo);

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_PO_Update", para, true, ref mException, ref mErrorMsg, "PurchaseInvoice - Update");

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

        public void InsertTNC(string TNC_Sub, string TNC_Desc, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub.ToString());
            para.Add("@i_TNC_Desc", TNC_Desc.ToString());
            para.Add("@i_Code", Code.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseTNC_Insert", para, false, ref mException, ref mErrorMsg, "Purchase - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertTNC_NEW(string XmlString, Int64 Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            //para.Add("@i_TNCID", TNCID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseTNC_Insert", para, false, ref mException, ref mErrorMsg, "Purchase - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void UpdateTNC_NEW(string code, string XmlString, Int64 Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            //para.Add("@i_TNCID", TNCID.ToString());
            para.Add("@i_Code", code.ToString());
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            //para.Add("@i_TNCID", TNCID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseTNC_Update", para, false, ref mException, ref mErrorMsg, "Purchase - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void DeleteTNC(string TNC_Sub, string TNC_Desc, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub.ToString());
            para.Add("@i_TNC_Desc", TNC_Desc.ToString());
            para.Add("@i_Code", Code.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseTNC_Delete", para, false, ref mException, ref mErrorMsg, "Purchase - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }
        public void DeleteTNC_On_Close(string TNC_Sub, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub.ToString());
            para.Add("@i_Code", Code.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseTNC_Delete_On_Close", para, false, ref mException, ref mErrorMsg, "Purchase - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        /*Insert Quotation Docs*/

        public void InsertPODocument(long QuotationID, string DocName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_POID", QuotationID.ToString());
            para.Add("@i_DocName", DocName);
            //para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PODocList_Insert", para, false, ref mException, ref mErrorMsg, "PO - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }
    }
}
