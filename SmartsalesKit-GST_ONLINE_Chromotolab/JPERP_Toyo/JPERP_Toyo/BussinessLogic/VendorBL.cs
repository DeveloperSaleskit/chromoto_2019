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
    class VendorBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public VendorBL()
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
        public void Insert(string remarks,string category,string Code, string Name, string Address1, string Address2, long CityID, string Pincode, string Phone1, string Phone2, string Fax, string Mobile, string TinNo, string CSTNo, string PANo, string EccNo, Int64 CreditDays, string Range, string Division, DateTime TransactionDate, decimal CRAmount, decimal DBAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_Code", Code);
            para.Add("@i_Name", Name);

            para.Add("@i_remarks", remarks);
            para.Add("@i_category", category);

            para.Add("@i_Address1", Address1);
            para.Add("@i_Address2", Address2);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_Phone2", Phone2);
            para.Add("@i_Fax", Fax);
            para.Add("@i_Mobile", Mobile);
            para.Add("@i_TinNo", TinNo);
            para.Add("@i_CSTNo", CSTNo);
            para.Add("@i_PANo", PANo);
            para.Add("@i_EccNo", EccNo);
            para.Add("@i_CreditDays", CreditDays.ToString());
            para.Add("@i_Range", Range);
            para.Add("@i_Division", Division);
            para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CRAmount", CRAmount.ToString());
            para.Add("@i_DBAmount", DBAmount.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Vendor_Insert", para, true, ref mException, ref mErrorMsg, "Vendor - Insert");

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



        public void InsertFILE( string Code, string Name, string Address1, string Address2, long CityID, string Pincode, string Phone1, string Phone2, string Fax, string Mobile, string TinNo, string CSTNo, string PANo, string EccNo, Int64 CreditDays, string Range, string Division, DateTime TransactionDate, decimal CRAmount, decimal DBAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_Code", Code);
            para.Add("@i_Name", Name);

          
            para.Add("@i_Address1", Address1);
            para.Add("@i_Address2", Address2);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_Phone2", Phone2);
            para.Add("@i_Fax", Fax);
            para.Add("@i_Mobile", Mobile);
            para.Add("@i_TinNo", TinNo);
            para.Add("@i_CSTNo", CSTNo);
            para.Add("@i_PANo", PANo);
            para.Add("@i_EccNo", EccNo);
            para.Add("@i_CreditDays", CreditDays.ToString());
            para.Add("@i_Range", Range);
            para.Add("@i_Division", Division);
            para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CRAmount", CRAmount.ToString());
            para.Add("@i_DBAmount", DBAmount.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_remarks", "");
            para.Add("@i_category", "");
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Vendor_Insert", para, true, ref mException, ref mErrorMsg, "Vendor - Insert");

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


        public void Update(string remarks, string category, long VendorID, string Code, string Name, string Address1, string Address2, long CityID, string Pincode, string Phone1, string Phone2, string Fax, string Mobile, string TinNo, string CSTNo, string PANo, string EccNo, Int64 CreditDays, string Range, string Division, DateTime TransactionDate, decimal CRAmount, decimal DBAmount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_VendorID", VendorID.ToString());
            //para.Add("@i_FYID", CurrentUser.FYID.ToString());


            para.Add("@i_remarks", remarks);
            para.Add("@i_category", category);


            para.Add("@i_Code", Code);
            para.Add("@i_Name", Name);
            para.Add("@i_Address1", Address1);
            para.Add("@i_Address2", Address2);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_Phone2", Phone2);
            para.Add("@i_Fax", Fax);
            para.Add("@i_Mobile", Mobile);
            para.Add("@i_TinNo", TinNo);
            para.Add("@i_CSTNo", CSTNo);
            para.Add("@i_PANo", PANo);
            para.Add("@i_EccNo", EccNo);
            para.Add("@i_CreditDays", CreditDays.ToString());
            para.Add("@i_Range", Range);
            para.Add("@i_Division", Division);
            para.Add("@i_TransactionDate", TransactionDate.ToString("MM/dd/yyyy"));
            para.Add("@i_CRAmount", CRAmount.ToString());
            para.Add("@i_DBAmount", DBAmount.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Vendor_Update", para, true, ref mException, ref mErrorMsg, "Vendor - Update");

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

        public void AssignItem(long VendorID, string ItemData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_ItemData", ItemData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Vendor_AssignItem", para, true, ref mException, ref mErrorMsg, "Vendor - AssignItem");

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

        public void UpdatePrice(long VendorID, string ItemData, long Cnt, string StrDelete)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_ItemData", ItemData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_StrDelete", StrDelete);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_Vendor_UpdatePrice", para, true, ref mException, ref mErrorMsg, "Vendor - UpdatePrice");

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
        public void UploadVendor(string XMLString, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_XMLString", XMLString);
            para.Add("@i_Cnt", Cnt.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Vendor_Upload", para, false, ref mException, ref mErrorMsg, "CustomerBL - UpdateRates");

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