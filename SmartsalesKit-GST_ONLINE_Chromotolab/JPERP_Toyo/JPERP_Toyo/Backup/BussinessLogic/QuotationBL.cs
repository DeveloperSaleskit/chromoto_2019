using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class QuotationBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public QuotationBL()
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

        public void Insert(long LeadId, DateTime SaleDate, Int64 SIID, decimal SalePrice, decimal AdvAmount, string Remarks, decimal ServiceAmount,
            decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount, decimal HEduCessAmount, decimal AmountAfterExcise, decimal CSTAmount,
            decimal VATAmount, decimal AVATAmount, decimal SBCessAmount, decimal ExtraTaxAmount, decimal Discount, decimal NetAmount, decimal PaidAmount, string XmlString, Int64 Cnt, string Refno,
            string TypeOfSale, string Code, DateTime Followup, string Reference, Int16 EmpID, Int16 EmpAllToID, string Remarks_Orignal, string CC, string BCC, bool Is_MailSend, int CompId
            , string ContactPerson, string ContactEmail, string ContactMobile, bool IsCustomer, string cmbCategory
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_LeadId", LeadId.ToString());
            para.Add("@i_QPrice", SalePrice.ToString());
            para.Add("@i_AdvAmount", AdvAmount.ToString());
            para.Add("@i_PaidAmount", AdvAmount.ToString());
            para.Add("@i_SIID", SIID.ToString());
            para.Add("@i_QDate", SaleDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", EduCessAmount.ToString());
            para.Add("@i_HCessAmount", HEduCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());

            para.Add("@i_SBCessAmount", SBCessAmount.ToString());
            para.Add("@i_ExtraTaxAmount", ExtraTaxAmount.ToString());
            para.Add("@i_cmbCategory", cmbCategory.ToString());
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_Refno", Refno.ToString());
            para.Add("@i_TypeOfSale", TypeOfSale.ToString());
            para.Add("@i_Code", Code.ToString());
            para.Add("@i_Reference", Reference.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_FollowupDate", Followup.ToString("MM/dd/yyyy"));
            para.Add("@i_EmpID", EmpID.ToString());
            para.Add("@i_EmpAllToID", EmpAllToID.ToString());
            para.Add("@i_Remarks_Orignal", Remarks_Orignal.ToString());
            para.Add("@i_CC", CC.ToString());
            para.Add("@i_BCC", BCC.ToString());
            para.Add("@i_Is_SendMail", Is_MailSend.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_ContactPerson", ContactPerson.ToString());
            para.Add("@i_ContactEmail", ContactEmail.ToString());
            para.Add("@i_ContactMobile", ContactMobile.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Quotation_Insert", para, true, ref mException, ref mErrorMsg, "Quotation - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void Update(long QuotationId, long LeadId, DateTime SaleDate, Int64 SIID, decimal SalePrice, decimal AdvAmount, string Remarks,
            decimal ServiceAmount, decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount, decimal HEduCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal SBCessAmount, decimal ExtraTaxAmount, decimal Discount, decimal NetAmount, decimal PaidAmount, string XmlString, Int64 Cnt,
            string Refno, string TypeOfSale, DateTime Followup, string Reference, Int16 EmpID, Int16 EmpAllToID, string Remarks_Orignal, string CC, string BCC, bool Is_MailSend, int CompId
             , string ContactPerson, string ContactEmail, string ContactMobile, bool IsCustomer, string  cmbCategory
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_QuotationId", QuotationId.ToString());
            para.Add("@i_LeadId", LeadId.ToString());
            para.Add("@i_QPrice", SalePrice.ToString());
            para.Add("@i_AdvAmount", AdvAmount.ToString());
            para.Add("@i_PaidAmount", AdvAmount.ToString());
            para.Add("@i_SIID", SIID.ToString());
            para.Add("@i_QDate", SaleDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", EduCessAmount.ToString());
            para.Add("@i_HCessAmount", HEduCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());

            para.Add("@i_cmbCategory", cmbCategory.ToString());
            para.Add("@i_SBCessAmount", SBCessAmount.ToString());
            para.Add("@i_ExtraTaxAmount", ExtraTaxAmount.ToString());

            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_Refno", Refno.ToString());
            para.Add("@i_TypeOfSale", TypeOfSale.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_FollowupDate", Followup.ToString("MM/dd/yyyy"));
            para.Add("@i_Reference", Reference.ToString());
            para.Add("@i_EmpID", EmpID.ToString());
            para.Add("@i_EmpAllToID", EmpAllToID.ToString());
            para.Add("@i_Remarks_Orignal", Remarks_Orignal.ToString());
            para.Add("@i_CC", CC.ToString());
            para.Add("@i_BCC", BCC.ToString());
            para.Add("@i_Is_SendMail", Is_MailSend.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_ContactPerson", ContactPerson.ToString());
            para.Add("@i_ContactEmail", ContactEmail.ToString());
            para.Add("@i_ContactMobile", ContactMobile.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Quotation_Update", para, false, ref mException, ref mErrorMsg, "Quotation - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void UpdateMail(bool Is_MailSend, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Is_SendMail", Is_MailSend.ToString());
            para.Add("@i_Code", Code);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_MailStatus", para, false, ref mException, ref mErrorMsg, "Quotation - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }




        public void InsertFollowUp(long QuotationID, DateTime FollowupDate, string Remarks, long UserID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_QuotationID", QuotationID.ToString());
            para.Add("@i_FollowupDate", FollowupDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_UserID", UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationFollowup_Insert", para, true, ref mException, ref mErrorMsg, "Quotation Follow Up- Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertQuotationPaymentDetail(long QuotationID, DateTime NextDate, decimal Payment, string Remarks)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_QuotationID", QuotationID.ToString());
            para.Add("@i_NextDate", NextDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Payment", Payment.ToString());
            para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationPaymentDetail_Insert", para, false, ref mException, ref mErrorMsg, "Quotation Payment- Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        //public void InsertTNC(string TNC_Sub, string TNC_Desc, string Code, int TNCID)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_TNC_Sub", TNC_Sub.ToString());
        //    para.Add("@i_TNC_Desc", TNC_Desc.ToString());
        //    para.Add("@i_Code", Code.ToString());
        //    para.Add("@i_TNCID", TNCID.ToString());
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_QuotationTNC_Insert", para, false, ref mException, ref mErrorMsg, "Quotation - Insert");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}

        public void InsertTNC(string TNC_Sub, string TNC_Desc, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub.ToString());
            para.Add("@i_TNC_Desc", TNC_Desc.ToString());
            para.Add("@i_Code", Code.ToString());
            //para.Add("@i_TNCID", TNCID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationTNC_Insert", para, false, ref mException, ref mErrorMsg, "Quotation - Insert");
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
            objDA.ExecuteSP("usp_QuotationTNC_Insert", para, false, ref mException, ref mErrorMsg, "Quotation - Insert");
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
            objDA.ExecuteSP("usp_QuotationTNC_Update", para, false, ref mException, ref mErrorMsg, "Quotation - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertTNC_Revised_NEW(string XmlString, Int64 Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_XmlString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            //para.Add("@i_TNCID", TNCID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationTNC_Revised_Insert", para, false, ref mException, ref mErrorMsg, "Revised Quotation - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void UpdateTNC_Revised_NEW(string code, string XmlString, Int64 Cnt)
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
            objDA.ExecuteSP("usp_QuotationTNC_Revised_Update", para, false, ref mException, ref mErrorMsg, "Revised Quotation - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        //public void UpdateTNC(string TNC_Sub, string TNC_Desc, string Code,int TNCID)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_TNC_Sub", TNC_Sub.ToString());
        //    para.Add("@i_TNC_Desc", TNC_Desc.ToString());
        //    para.Add("@i_Code", Code.ToString());
        //    para.Add("@i_TNCID", TNCID.ToString());
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_QuotationTNC_Update", para, false, ref mException, ref mErrorMsg, "Quotation - Update");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}

        public void DeleteTNC(string TNC_Sub, string TNC_Desc, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub.ToString());
            para.Add("@i_TNC_Desc", TNC_Desc.ToString());
            para.Add("@i_Code", Code.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationTNC_Delete", para, false, ref mException, ref mErrorMsg, "Quotation - Insert");
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
            objDA.ExecuteSP("usp_QuotationTNC_Delete_On_Close", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void DeleteQContact_On_Close(string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationQContact_Delete_On_Close", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        /*PromoMail*/
        public void InsertPromoMail(string CustomerName, string Email)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CustomerName", CustomerName.ToString());
            para.Add("@i_Email", Email.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationTNC_Insert", para, false, ref mException, ref mErrorMsg, "PromoMail - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        /*Insert Quotation Docs*/

        public void InsertQuotationDocument(long QuotationID, string DocName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_QuotationID", QuotationID.ToString());
            para.Add("@i_DocName", DocName);
            //para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_QuotationDocList_Insert", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        //public void InsertQuotationDocument(long QuotationID, string DocName, string Remarks)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_QuotationID", QuotationID.ToString());
        //    para.Add("@i_DocName", DocName);
        //    para.Add("@i_Remarks", Remarks);
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_QuotationDocList_Insert", para, false, ref mException, ref mErrorMsg, "Quotation - Insert");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}


    }
}
