using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class ServiceModuleBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public ServiceModuleBL()
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

        public void Insert(string RequestNo, DateTime ServiceDate, string CustomerName, Int64 SIID, string Address, string MobileNo,
            string ModelNumber, string Problem, long AttendedBy, string JobComputed, string Remarks, string OtherRequirement, decimal Charges,
            decimal TotalAmount, decimal ServiceAmount, decimal ExciseAmount, decimal CessAmount, decimal HCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal SBCessAmount, decimal ExtraTaxAmount, decimal Discount,
            decimal NetAmount, decimal PaidAmount, string XmlString, Int64 Cnt, int GodownID, int TypeofCallID, string TypeOfSale, Int32 EmpAllToID, string Status, int CompId, long CustomerID, bool IsCustomer, string CC, string BCC
             , string ContactPerson, string ContactEmail, string ContactMobile
            )
        {
            Int32 ServiceID = 0;
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RequestNo", RequestNo);
            para.Add("@i_ServiceDate", ServiceDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerID", CustomerID.ToString());
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_SIID", SIID.ToString());
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_Address", Address);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_ModelNumber", ModelNumber);
            para.Add("@i_Problem", Problem);
            para.Add("@i_AttendedBy", AttendedBy.ToString());
            
            para.Add("@i_JobComputed", JobComputed);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_OtherRequirement", OtherRequirement);
            para.Add("@i_Charges", Charges.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", CessAmount.ToString());
            para.Add("@i_HCessAmount", HCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());

            para.Add("@i_SBCessAmount", SBCessAmount.ToString());
            para.Add("@i_ExtraTaxAmount", ExtraTaxAmount.ToString());


            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_CallID", TypeofCallID.ToString());
            para.Add("@i_TypeOfSale", TypeOfSale.ToString());
            para.Add("@i_EmpAllToID", EmpAllToID.ToString());
            para.Add("@i_Status", Status.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId",CurrentCompany.CompId.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            para.Add("@i_CC", CC);
            para.Add("@i_BCC", BCC);
            para.Add("@i_ContactPerson", ContactPerson.ToString());
            para.Add("@i_ContactEmail", ContactEmail.ToString());
            para.Add("@i_ContactMobile", ContactMobile.ToString());
            //para.Add("@i_Cnt1", Cnt1.ToString());
            //para.Add("@i_XMLString1", XmlString1);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_ServiceModule_Insert", para, true, ref mException, ref mErrorMsg, "ServiceModule - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;


                ServiceID = Convert.ToInt32(mErrorMsg);
                this.ErrorMessage = mErrorMsg;


            }
            else
                this.Exception = mException;
        }

        public void Update(long ServiceId, string RequestNo, DateTime ServiceDate, string CustomerName, Int64 SIID, string Address, string MobileNo,
                string ModelNumber, string Problem, long AttendedBy, string JobComputed, string Remarks, string OtherRequirement, decimal Charges,
            decimal TotalAmount, decimal ServiceAmount, decimal ExciseAmount, decimal CessAmount, decimal HCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal SBCessAmount, decimal ExtraTaxAmount, decimal Discount,
            decimal NetAmount, decimal PaidAmount, string XmlString, Int64 Cnt, int GodownID, int TypeofCallID, string TypeOfSale, Int32 EmpAllToID, string Status, int CompId, long CustomerID, bool IsCustomer, string CC, string BCC
               , string ContactPerson, string ContactEmail, string ContactMobile
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_ServiceId", ServiceId.ToString());
            para.Add("@i_RequestNo", RequestNo);
            para.Add("@i_ServiceDate", ServiceDate.ToString("MM/dd/yyyy"));
            para.Add("@i_SIID", SIID.ToString());
            para.Add("@i_CustomerID", CustomerID.ToString());
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_Address", Address);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_ModelNumber", ModelNumber);
            para.Add("@i_Problem", Problem);
            para.Add("@i_AttendedBy", AttendedBy.ToString());
            para.Add("@i_JobComputed", JobComputed);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_OtherRequirement", OtherRequirement);
            para.Add("@i_Charges", Charges.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", CessAmount.ToString());
            para.Add("@i_HCessAmount", HCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());

            para.Add("@i_SBCessAmount", SBCessAmount.ToString());
            para.Add("@i_ExtraTaxAmount", ExtraTaxAmount.ToString());

            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_PaidAmount", PaidAmount.ToString());
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_CallID", TypeofCallID.ToString());
            para.Add("@i_TypeOfSale", TypeOfSale.ToString());
            para.Add("@i_EmpAllToID", EmpAllToID.ToString());
            para.Add("@i_Status", Status.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId",CurrentCompany.CompId.ToString());
            para.Add("@i_IsCustomer", IsCustomer.ToString());
            para.Add("@i_CC", CC);
            para.Add("@i_BCC", BCC);

            para.Add("@i_ContactPerson", ContactPerson.ToString());
            para.Add("@i_ContactEmail", ContactEmail.ToString());
            para.Add("@i_ContactMobile", ContactMobile.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_ServiceModule_Update", para, true, ref mException, ref mErrorMsg, "ServiceModule - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }



        public void InsertServiceDocument(long ServiceID, string DocName, string Remarks)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_ServiceID", ServiceID.ToString());
            para.Add("@i_DocName", DocName);
            para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_ServiceDocList_Insert", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
            if (mException == null)
            {
                //if (mErrorMsg != "")
                this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void UpdateReminder(int SIID, int SRID, string ServiceId,int EmpID,string Problem,string Solution,int Mode)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_SIID", SIID.ToString());
            para.Add("@i_SRID", SRID.ToString());
            para.Add("@i_ServiceId", ServiceId.ToString());
            para.Add("@i_EmpID", EmpID.ToString());
            para.Add("@i_Problem", Problem.ToString());
            para.Add("@i_Solution", Solution.ToString());
            para.Add("@i_Mode", Mode.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_FYID", CurrentUser.FYID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Update_Reminder_Flag", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
            if (mException == null)
            {
                //if (mErrorMsg != "")
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
            objDA.ExecuteSP("usp_ServicesTNC_Insert", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
            objDA.ExecuteSP("usp_ServicesTNC_Insert", para, false, ref mException, ref mErrorMsg, "Service - Insert");
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
            objDA.ExecuteSP("usp_ServicesTNC_Update", para, false, ref mException, ref mErrorMsg, "Service - Update");
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
            objDA.ExecuteSP("usp_ServicesTNC_Delete", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
            objDA.ExecuteSP("usp_ServicesTNC_Delete_On_Close", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
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
