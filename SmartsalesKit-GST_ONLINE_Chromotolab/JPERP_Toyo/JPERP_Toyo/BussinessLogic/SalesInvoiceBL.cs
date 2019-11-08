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
    class SalesInvoiceBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public SalesInvoiceBL()
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
        public Int32 Insert(string SalesCode, DateTime SIDate, DateTime DCDate, long CustomerID, long DueDays, decimal ServiceAmount,
             decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount, decimal HEduCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal SBCessAmount, decimal ExtraTaxAmount, decimal Discount, decimal NetAmount, decimal PaidAmount, string Narration,
            string XmlString, Int64 Cnt, DateTime Installation, DateTime Reminder,
            decimal NoofServices, string XmlString1, Int64 Cnt1,
            Int16 AttendedBy, decimal ExtraCharges, string ExtraChargesType, string TIN, Int16 RecDay, string Type, string ShippingAdd, string ShippingotherAdd,
            string BONo, DateTime BODate, string DNote, DateTime DDate, string SONo, string DDNo, string DT, string Des, DateTime IssDate,
            string IssTime, DateTime RDate, string RTime,
            string CC, string BCC,string CustInvoiceNo,
            decimal ExtraCharges2, string ExtraChargesType2,
            decimal ExtraCharges3, string ExtraChargesType3,
            string ExtraReminder, DateTime dtExtraReminder, Int16 EmpAllToID, bool IsPaid, decimal TotalDiscAmt, int CompId, bool IsCustomer, string ChallanNo
            ,decimal CreditOutstanding, decimal RemainingCredit, decimal AdjustedCredit, string IsAgainstCredit
            , string BankName, string ChequeNo, DateTime ChequeDate,string CustomerBankName,
               string ContactPerson, string ContactEmail, string ContactMobile,string BusinessType,
               string SGSTAmount, string CGSTAmount, string IGSTAmount
            )
        {
            SetDefaultException();
            Int32 POID = 0;
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_SalesCode", SalesCode);

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_SalesDate", SIDate.ToString("MM/dd/yyyy"));

            para.Add("@i_DCDate", DCDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerID", CustomerID.ToString());
            para.Add("@i_DueDays", DueDays.ToString());

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
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_Narration", Narration);

            para.Add("@i_EmpID", AttendedBy.ToString());
            para.Add("@i_EmpAllToID", EmpAllToID.ToString());
            para.Add("@i_Installation", Installation.ToString("MM/dd/yyyy"));
            para.Add("@i_Reminder", Reminder.ToString("MM/dd/yyyy"));
            para.Add("@i_NoofServices", NoofServices.ToString());
            para.Add("@i_XMLString1", XmlString1);
            para.Add("@i_Cnt1", Cnt.ToString());
            para.Add("@i_ExtraCharges", Convert.ToDecimal(ExtraCharges).ToString());
            para.Add("@i_ExtraChargesType", ExtraChargesType);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_TIN", TIN);
            para.Add("@i_RecDay", RecDay.ToString());
            para.Add("@i_Type", Type);
            para.Add("@i_ShippingAdd", ShippingAdd);
            para.Add("@i_BONo", BONo);
            para.Add("@i_BODate", BODate.ToString("MM/dd/yyyy"));
            para.Add("@i_DNote", DNote);
            para.Add("@i_DNoteDate", DDate.ToString("MM/dd/yyyy"));
            para.Add("@i_SuRNo", SONo);
            para.Add("@i_DDNo", DDNo);
            para.Add("@i_DT", DT);
            para.Add("@i_D", Des);
            para.Add("@i_DtI", IssDate.ToString("MM/dd/yyyy"));
            para.Add("@i_TI", IssTime);
            para.Add("@i_DtR", RDate.ToString("MM/dd/yyyy"));
            para.Add("@i_TR", RTime);
            para.Add("@i_CC", CC.ToString());
            para.Add("@i_BCC", BCC.ToString());
            para.Add("@i_CustInvoiceNo", CustInvoiceNo.ToString());
            para.Add("@i_ExtraCharges2", Convert.ToDecimal(ExtraCharges2).ToString());
            para.Add("@i_ExtraChargesType2", ExtraChargesType2);
            para.Add("@i_ExtraCharges3", Convert.ToDecimal(ExtraCharges3).ToString());
            para.Add("@i_ExtraChargesType3", ExtraChargesType3);
            para.Add("@i_ExtraReminder", ExtraReminder);
            para.Add("@i_dtExtraReminder", dtExtraReminder.ToString("MM/dd/yyyy"));
            para.Add("@i_IsPaid", IsPaid.ToString());
            para.Add("@i_TotalDiscAmt", Discount.ToString());
            para.Add("@i_CompId",CurrentCompany.CompId.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            //para.Add("@i_GoDownID", GodownId.ToString());
            para.Add("@i_ChallanNo", ChallanNo.ToString());

            para.Add("@i_CreditOutstanding", CreditOutstanding.ToString());
            para.Add("@i_RemainingCredit", RemainingCredit.ToString());
            para.Add("@i_AdjustedCredit", AdjustedCredit.ToString());
            para.Add("@i_IsAgainstCredit", IsAgainstCredit.ToString());

            para.Add("@i_BankName", BankName);
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_ChequeDate", Convert.ToDateTime(ChequeDate).ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerBankName", CustomerBankName);
             para.Add("@i_ContactPerson", ContactPerson.ToString());
            para.Add("@i_ContactEmail", ContactEmail.ToString());
            para.Add("@i_ContactMobile", ContactMobile.ToString());
            para.Add("@i_ShippingotherAdd", ShippingotherAdd.ToString());
            para.Add("@i_BusinessType", BusinessType);
            para.Add("@i_SGSTAmount", SGSTAmount);
            para.Add("@i_CGSTAmount", CGSTAmount);
            para.Add("@i_IGSTAmount", IGSTAmount);

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_SalesInvoice_Insert", para, true, ref mException, ref mErrorMsg, "SalesInvoice - Insert");

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

        public void Update(long SIID, string SalesCode, DateTime SIDate, DateTime DCDate, long CustomerID, long DueDays, decimal ServiceAmount,
             decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount, decimal HEduCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal SBCessAmount, decimal ExtraTaxAmount, decimal Discount, decimal NetAmount, decimal PaidAmount, string Narration,
            string XmlString, Int64 Cnt, DateTime Installation, DateTime Reminder,
            decimal NoofServices, string XmlString1, Int64 Cnt1,
            Int16 AttendedBy, decimal ExtraCharges, string ExtraChargesType, string TIN, Int16 RecDay, string Type, string ShippingAdd, string ShippingotherAdd,
            string BONo, DateTime BODate, string DNote, DateTime DDate, string SONo, string DDNo, string DT, string Des, DateTime IssDate,
            string IssTime, DateTime RDate, string RTime,
            string CC, string BCC, string CustInvoiceNo,
            decimal ExtraCharges2, string ExtraChargesType2,
            decimal ExtraCharges3, string ExtraChargesType3,
            string ExtraReminder, DateTime dtExtraReminder, Int16 EmpAllToID, bool IsPaid, decimal TotalDiscAmt, int CompId, bool IsCustomer, string ChallanNo,
            decimal CreditOutstanding, decimal RemainingCredit, decimal AdjustedCredit, string IsAgainstCredit
            , string BankName, string ChequeNo, DateTime ChequeDate, string CustomerBankName,
             string ContactPerson, string ContactEmail, string ContactMobile, string BusinessType,
            string SGSTAmount,string CGSTAmount,string IGSTAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_SIID", SIID.ToString());
            para.Add("@i_SalesCode", SalesCode);

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_SalesDate", SIDate.ToString("MM/dd/yyyy"));

            para.Add("@i_DCDate", DCDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerID", CustomerID.ToString());
            para.Add("@i_DueDays", DueDays.ToString());

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
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_Narration", Narration);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            para.Add("@i_EmpID", AttendedBy.ToString());
            para.Add("@i_EmpAllToID", EmpAllToID.ToString());
            para.Add("@i_Installation", Installation.ToString("MM/dd/yyyy"));
            para.Add("@i_Reminder", Reminder.ToString("MM/dd/yyyy"));
            para.Add("@i_NoofServices", NoofServices.ToString());
            para.Add("@i_ExtraCharges", Convert.ToDecimal(ExtraCharges).ToString());
            para.Add("@i_ExtraChargesType", ExtraChargesType);
            para.Add("@i_TIN", TIN);
            para.Add("@i_RecDay", RecDay.ToString());
            para.Add("@i_Type", Type);
            para.Add("@i_ShippingAdd", ShippingAdd);
            para.Add("@i_BONo", BONo);
            para.Add("@i_BODate", BODate.ToString("MM/dd/yyyy"));
            para.Add("@i_DNote", DNote);
            para.Add("@i_DNoteDate", DDate.ToString("MM/dd/yyyy"));
            para.Add("@i_SuRNo", SONo);
            para.Add("@i_DDNo", DDNo);
            para.Add("@i_DT", DT);
            para.Add("@i_D", Des);
            para.Add("@i_DtI", IssDate.ToString("MM/dd/yyyy"));
            para.Add("@i_TI", IssTime);
            para.Add("@i_DtR", RDate.ToString("MM/dd/yyyy"));
            para.Add("@i_TR", RTime);
            para.Add("@i_CC", CC.ToString());
            para.Add("@i_BCC", BCC.ToString());
            para.Add("@i_CustInvoiceNo", CustInvoiceNo.ToString());
            para.Add("@i_ExtraCharges2", Convert.ToDecimal(ExtraCharges2).ToString());
            para.Add("@i_ExtraChargesType2", ExtraChargesType2);
            para.Add("@i_ExtraCharges3", Convert.ToDecimal(ExtraCharges3).ToString());
            para.Add("@i_ExtraChargesType3", ExtraChargesType3);
            para.Add("@i_ExtraReminder", ExtraReminder);
            para.Add("@i_dtExtraReminder", dtExtraReminder.ToString("MM/dd/yyyy"));
            para.Add("@i_XMLString1", XmlString1);
            para.Add("@i_Cnt1", Cnt1.ToString());

            para.Add("@i_IsPaid", IsPaid.ToString());
            para.Add("@i_TotalDiscAmt", Discount.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            //para.Add("@i_GoDownID", GodownId.ToString());
            para.Add("@i_ChallanNo", ChallanNo);

            para.Add("@i_CreditOutstanding", CreditOutstanding.ToString());
            para.Add("@i_RemainingCredit", RemainingCredit.ToString());
            para.Add("@i_AdjustedCredit", AdjustedCredit.ToString());
            para.Add("@i_IsAgainstCredit", IsAgainstCredit.ToString());

            para.Add("@i_BankName", BankName);
            para.Add("@i_ChequeNo", ChequeNo);
            para.Add("@i_ChequeDate", Convert.ToDateTime(ChequeDate).ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerBankName", CustomerBankName);

              para.Add("@i_ContactPerson", ContactPerson.ToString());
            para.Add("@i_ContactEmail", ContactEmail.ToString());
            para.Add("@i_ContactMobile", ContactMobile.ToString());
            para.Add("@i_ShippingotherAdd", ShippingotherAdd.ToString());
            para.Add("@i_BusinessType", BusinessType);
            para.Add("@i_SGSTAmount", SGSTAmount);
            para.Add("@i_CGSTAmount", CGSTAmount);
            para.Add("@i_IGSTAmount", IGSTAmount);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_SalesInvoice_Update", para, true, ref mException, ref mErrorMsg, "SalesInvoice - Update");

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


        public void InsertSaleDocument(long SaleID, string DocName, string Remarks)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_SaleID", SaleID.ToString());
            para.Add("@i_DocName", DocName);
            para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_SaleDocList_Insert", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertTNC(string TNC_Sub, string TNC_Desc, string Code)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub.ToString());
            para.Add("@i_TNC_Desc", TNC_Desc.ToString());
            para.Add("@i_Code", Code.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_SalesTNC_Insert", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
            objDA.ExecuteSP("usp_SalesTNC_Insert", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
            objDA.ExecuteSP("usp_SalesTNC_Update", para, false, ref mException, ref mErrorMsg, "Sales - Update");
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
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_SalesTNC_Delete", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
            objDA.ExecuteSP("usp_SalesTNC_Delete_On_Close", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
