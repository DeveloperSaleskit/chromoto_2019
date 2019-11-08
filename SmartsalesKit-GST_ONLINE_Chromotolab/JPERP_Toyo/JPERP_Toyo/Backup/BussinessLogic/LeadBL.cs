using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class LeadBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public LeadBL()
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
        public void Insert(string LeadNo, DateTime LeadDate, string CustomerName, string Address, Int32 CityID, string Pincode, string Phone1, string MobileNo, string Email,
            string Name1, string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4, string Value5, string Value6,
            string SourceOfLead, decimal CustomerBudget, string InterestLevel, DateTime NextFollowUpDate,
            string Specification, string Remarks, int LeadStatusID, string ContactPerson, int AreaID, int EmpID, string Website,
            string Category, int AllocatedToEmpID, bool Inquiry_AutoResponse, int CompId, long AccountID, string InqResponse, long CustomerId
            )
        {// bool Quotation_Send ,
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_LeadNo", LeadNo);
            para.Add("@i_LeadDate", LeadDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_Address", Address);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_Email", Email);
            para.Add("@i_Name1", Name1);
            para.Add("@i_Name2", Name2);
            para.Add("@i_Name3", Name3);
            para.Add("@i_Name4", Name4);
            para.Add("@i_Name5", Name5);
            para.Add("@i_Name6", Name6);
            para.Add("@i_Value1", Value1);
            para.Add("@i_Value2", Value2);
            para.Add("@i_Value3", Value3);
            para.Add("@i_Value4", Value4);
            para.Add("@i_Value5", Value5);
            para.Add("@i_Value6", Value6);
            para.Add("@i_SourceOfLead", SourceOfLead);
            para.Add("@i_CustomerBudget", CustomerBudget.ToString());
            para.Add("@i_InterestLevel", InterestLevel);
            para.Add("@i_NextFollowUpDate", NextFollowUpDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Specification", Specification);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_LeadStatusID", LeadStatusID.ToString());
            //   para.Add("@i_Quotation_Send", Quotation_Send.ToString());
            para.Add("@i_ContactPerson", ContactPerson);
            para.Add("@i_AreaID", AreaID.ToString());
            para.Add("@i_EmpID", EmpID.ToString());
            para.Add("@i_Website", Website);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_Category", Category);
            para.Add("@i_AllocatedToEmpID", AllocatedToEmpID.ToString());
            para.Add("@i_Inquiry_AutoResponse", Inquiry_AutoResponse.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            para.Add("@i_InqResponse", InqResponse);
            para.Add("@i_CustomerId", CustomerId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Lead_Insert", para, true, ref mException, ref mErrorMsg, "Lead - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void Update(long LeadID, DateTime LeadDate, string CustomerName, string Address, Int32 CityID, string Pincode, string Phone1,
            string MobileNo, string Email,
            string Name1, string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4, string Value5, string Value6,
            string SourceOfLead, decimal CustomerBudget, string InterestLevel, DateTime NextFollowUpDate,
            string Specification, string Remarks, int LeadStatusID, string ContactPerson, int AreaID, int EmpID, string Website,
            string Category, int AllocatedToEmpID, bool Inquiry_AutoResponse, int CompId, long AccountID, string InqResponse, long CustomerId
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_LeadID", LeadID.ToString());
            para.Add("@i_LeadDate", LeadDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_Address", Address);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_Email", Email);
            para.Add("@i_Name1", Name1);
            para.Add("@i_Name2", Name2);
            para.Add("@i_Name3", Name3);
            para.Add("@i_Name4", Name4);
            para.Add("@i_Name5", Name5);
            para.Add("@i_Name6", Name6);
            para.Add("@i_Value1", Value1);
            para.Add("@i_Value2", Value2);
            para.Add("@i_Value3", Value3);
            para.Add("@i_Value4", Value4);
            para.Add("@i_Value5", Value5);
            para.Add("@i_Value6", Value6);
            para.Add("@i_SourceOfLead", SourceOfLead);
            para.Add("@i_CustomerBudget", CustomerBudget.ToString());
            para.Add("@i_InterestLevel", InterestLevel);
            para.Add("@i_NextFollowUpDate", NextFollowUpDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Specification", Specification);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_LeadStatusID", LeadStatusID.ToString());
            //  para.Add("@i_Quotation_Send", Quotation_Send.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_ContactPerson", ContactPerson);
            para.Add("@i_AreaID", AreaID.ToString());
            para.Add("@i_EmpID", EmpID.ToString());
            para.Add("@i_Website", Website);
            para.Add("@i_Category", Category);
            para.Add("@i_AllocatedToEmpID", AllocatedToEmpID.ToString());
            para.Add("@i_Inquiry_AutoResponse", Inquiry_AutoResponse.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            para.Add("@i_InqResponse", InqResponse);
            para.Add("@i_CustomerId", CustomerId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Lead_Update", para, true, ref mException, ref mErrorMsg, "Lead - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }





        public void UpdateCUSTID(long CustomerId, long leadId, int CompId)

        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_leadId", leadId.ToString());
            para.Add("@i_CustomerId", CustomerId.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Lead_CUSTID_Update", para, true, ref mException, ref mErrorMsg, "Lead - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertFollowUp(long LeadID, DateTime NextFollowupDate, string Remarks, long UserID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_LeadID", LeadID.ToString());
            para.Add("@i_NextFollowupDate", NextFollowupDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_UserID", UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_LeadFollowUp_Insert", para, true, ref mException, ref mErrorMsg, "Lead Follow Up- Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertCustomerFollowUp(long LeadID, DateTime NextFollowupDate, string Remarks, long UserID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_LeadID", LeadID.ToString());
            para.Add("@i_NextFollowupDate", NextFollowupDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_UserID", UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_CustomerFollowUp_Insert", para, true, ref mException, ref mErrorMsg, "Customer Follow Up- Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void InsertLeadDocument(long LeadID, string DocName)
        {



            SetDefaultException();
            //NameValueCollection padoc = new NameValueCollection();
            //padoc.Add("@i_leaddocno", leaddocno.ToString());
            //DataAccess.DataAccess objleaddoc = new DataAccess.DataAccess();
            //objDA.ExecuteSP("usp_Leaddocno", padoc, false, ref mException, ref mErrorMsg, "Sale - Insert");

            //dtblLOV = objDA.ListOfRecord("usp_Customer_Lead_LOV", para, "Customer LOV - LoadList");


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_LeadID", LeadID.ToString());
            para.Add("@i_DocName", DocName);
            //para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_LeadDocList_Insert", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
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

