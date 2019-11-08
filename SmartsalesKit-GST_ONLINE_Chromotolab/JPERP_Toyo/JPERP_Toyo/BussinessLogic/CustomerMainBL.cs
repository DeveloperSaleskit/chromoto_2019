using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class CustomerMainBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public CustomerMainBL()
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
        public void Insert(string CustomerCode, string CustomerName, string Address, Int32 CityID, string Pincode, string Phone1, string MobileNo, string Email,
            string Name1, string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4, string Value5, string Value6,
            //string SourceOfLead, decimal CustomerBudget, string InterestLevel, DateTime NextFollowUpDate, 
            string Specification, string Remarks, string ContactPerson, int AreaID, string Website,
            string Category, int CompId, long AccountID, int IsAccount, int CreditDays,
            DateTime TransactionDate, decimal CRAmount, decimal DBAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            para.Add("@i_CustomerCode", CustomerCode);
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_Address", Address);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_AreaID", AreaID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_Email", Email);
            para.Add("@i_Website", Website);
            para.Add("@i_ContactPerson", ContactPerson);
            //para.Add("@i_EmpID", EmpID.ToString());
            //para.Add("@i_AllocatedToEmpID", AllocatedToEmpID.ToString());
            para.Add("@i_Category", Category);
            para.Add("@i_IsAccount", IsAccount.ToString());
            para.Add("@i_Specification", Specification);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_CreditDays", CreditDays.ToString());
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
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CRAmount", CRAmount.ToString());
            para.Add("@i_DBAmount", DBAmount.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Customer_Insert", para, true, ref mException, ref mErrorMsg, "Customer - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }




        public void InsertINQUARIEEEDATA(string custcode, string CustomerName, string Address, Int32 CityID, string Pincode, string Phone1, string MobileNo, string Email,
            string Name1, string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4, string Value5, string Value6,
            //string SourceOfLead, decimal CustomerBudget, string InterestLevel, DateTime NextFollowUpDate, 
            string Specification, string Remarks, string ContactPerson, int AreaID, string Website,
            string Category, int CompId, long AccountID, int IsAccount, int CreditDays,
            DateTime TransactionDate, decimal CRAmount, decimal DBAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();



            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            para.Add("@i_CustomerCode", custcode);
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_Address", Address);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_AreaID", AreaID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_Email", Email);
            para.Add("@i_Website", Website);
            para.Add("@i_ContactPerson", ContactPerson);
            //para.Add("@i_EmpID", EmpID.ToString());
            //para.Add("@i_AllocatedToEmpID", AllocatedToEmpID.ToString());
            para.Add("@i_Category", Category);
            para.Add("@i_IsAccount", IsAccount.ToString());
            para.Add("@i_Specification", Specification);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_CreditDays", CreditDays.ToString());
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
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CRAmount", CRAmount.ToString());
            para.Add("@i_DBAmount", DBAmount.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Customer_Insert", para, true, ref mException, ref mErrorMsg, "Customer - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }



        public void Update(long CustomerID, string CustomerName, string Address, Int32 CityID, string Pincode, string Phone1,
            string MobileNo, string Email,
            string Name1, string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4, string Value5, string Value6,
            //string SourceOfLead, decimal CustomerBudget, string InterestLevel, DateTime NextFollowUpDate,
            string Specification, string Remarks, string ContactPerson, int AreaID, string Website,
            string Category, int CompId, long AccountID, int IsAccount, int CreditDays,
            DateTime TransactionDate, decimal CRAmount, decimal DBAmount
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CustomerID", CustomerID.ToString());

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_AccountID", AccountID.ToString());
            //  para.Add("@i_CustomerCode", CustomerCode);
            para.Add("@i_CustomerName", CustomerName);
            para.Add("@i_Address", Address);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_AreaID", AreaID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_MobileNo", MobileNo);
            para.Add("@i_Email", Email);
            para.Add("@i_Website", Website);
            para.Add("@i_ContactPerson", ContactPerson);
            //para.Add("@i_EmpID", EmpID.ToString());
            //para.Add("@i_AllocatedToEmpID", AllocatedToEmpID.ToString());
            para.Add("@i_Category", Category);
            para.Add("@i_IsAccount", IsAccount.ToString());
            para.Add("@i_Specification", Specification);
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_CreditDays", CreditDays.ToString());
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
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CRAmount", CRAmount.ToString());
            para.Add("@i_DBAmount", DBAmount.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            ////para.Add("@i_CustomerCode", CustomerCode);
            //para.Add("@i_CustomerName", CustomerName.ToString());
            //para.Add("@i_Address", Address.ToString());
            //para.Add("@i_CityID", CityID.ToString());
            //para.Add("@i_AreaID", AreaID.ToString());
            //para.Add("@i_Pincode", Pincode.ToString());
            //para.Add("@i_Phone1", Phone1.ToString());
            //para.Add("@i_MobileNo", MobileNo.ToString());
            //para.Add("@i_Email", Email.ToString());
            //para.Add("@i_Website", Website.ToString());
            //para.Add("@i_ContactPerson", ContactPerson.ToString());
            ////para.Add("@i_EmpID", EmpID.ToString());
            ////para.Add("@i_AllocatedToEmpID", AllocatedToEmpID.ToString());
            //para.Add("@i_Category", Category.ToString());
            //para.Add("@i_IsAccount", IsAccount.ToString());
            //para.Add("@i_Specification", Specification.ToString());
            //para.Add("@i_Remarks", Remarks.ToString());
            //para.Add("@i_CreditDays", CreditDays.ToString());
            //para.Add("@i_Name1", Name1.ToString());
            //para.Add("@i_Name2", Name2.ToString());
            //para.Add("@i_Name3", Name3.ToString());
            //para.Add("@i_Name4", Name4.ToString());
            //para.Add("@i_Name5", Name5.ToString());
            //para.Add("@i_Name6", Name6.ToString());
            //para.Add("@i_Value1", Value1.ToString());
            //para.Add("@i_Value2", Value2.ToString());
            //para.Add("@i_Value3", Value3.ToString());
            //para.Add("@i_Value4", Value4.ToString());
            //para.Add("@i_Value5", Value5.ToString());
            //para.Add("@i_Value6", Value6.ToString());
            //para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            //para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            //para.Add("@i_CRAmount", CRAmount.ToString());
            //para.Add("@i_DBAmount", DBAmount.ToString());
            //para.Add("@i_UserID", CurrentUser.UserID.ToString());
            //para.Add("@i_FYID", CurrentUser.FYID.ToString());
            //para.Add("@i_AccountID", AccountID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Customer_Update", para, true, ref mException, ref mErrorMsg, "Customer - Update");
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

        public void UploadCustomer(string XMLString, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_XMLString", XMLString);
            para.Add("@i_Cnt", Cnt.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Customer_Upload", para, false, ref mException, ref mErrorMsg, "CustomerBL - UpdateRates");

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
