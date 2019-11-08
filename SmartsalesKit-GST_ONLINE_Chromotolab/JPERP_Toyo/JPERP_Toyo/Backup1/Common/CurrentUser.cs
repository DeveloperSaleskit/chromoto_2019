using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Account.Common
{
    class CurrentUser
    {
        #region "Private Fields ..."
        private static long mUserID = 0;
        private static long mUnitID = 0;
        private static long mFYID = 0;
        private static long mVendorID = 0;
        private static string mUserName;
        private static string mDispUserName;
        private static string mUnitName;
        private static string mImagepath;
        private static string mReportpath;
        private static string mDocumentPath;
        private static string mDeptName;
        private static DateTime mFYStartDate;
        private static DateTime mFYEndDate;
        private static long mCompId = 0;
        private static string mPrivilegeStr;
       
        #endregion

        #region "Public Properties ..."

        public static long UserID
        {
            get
            { return mUserID; }
            set
            { mUserID = value; }
        }
        public static long VendorID
        {
            get
            { return mVendorID; }
            set
            { mVendorID = value; }
        }
        
        public static long CompId
        {
            get
            { return mCompId; }
            set
            { mCompId = value; }
        }

        public static long UnitID
        {
            get
            { return mUnitID; }
            set
            { mUnitID = value; }
        }
        public static string PrivilegeStr
        {
            get
            { return mPrivilegeStr; }
            set
            { mPrivilegeStr = value; }
        }

        public static long FYID
        {
            get { return mFYID; }
            set { mFYID = value; }
        }

        public static string UserName
        {
            get
            { return mUserName; }
            set
            { mUserName = value; }
        }

        public static string DepartmentName
        {
            get { return mDeptName; }
            set { mDeptName = value; }
        }

        public static DateTime FYStartDate
        {
            get { return mFYStartDate; }
            set { mFYStartDate = value; }
        }

        public static DateTime FYEndDate
        {
            get { return mFYEndDate; }
            set { mFYEndDate = value; }
        }

        public static string DispUserName
        {
            get
            { return mDispUserName; }
            set
            { mDispUserName = value; }
        }

        public static string UnitName
        {
            get
            { return mUnitName; }
            set
            { mUnitName = value; }
        }

        public static string ImagePath
        {
            get
            { return mImagepath; }
            set
            { mImagepath = value; }
        }

        public static string ReportPath
        {
            get { return mReportpath; }
            set { mReportpath = value; }
        }

        public static string DocumentPath
        {
            get { return mDocumentPath; }
            set { mDocumentPath = value; }
        }

     
        #endregion

        #region "Public methods ..."

        public static void AddReportParameters(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt, DataTable dt, string ReportName, bool CompanyName, bool Address1, bool Address2, bool City, bool PinCode, bool phone, bool Department, bool State, bool Phone2, bool Fax, bool Email)
        {
            rpt.SetDataSource(dt);           
            if (ReportName != "")
            {
                rpt.SetParameterValue("pReportName", ReportName);
            }
            if (CompanyName == true)
            {
                rpt.SetParameterValue("pCompanyName", CurrentCompany.CompanyName);
            }
            if (Address1 == true)
            {
                rpt.SetParameterValue("pAddress1", CurrentCompany.Address1);
            }
            if (Address2 == true)
            {
                rpt.SetParameterValue("pAddress2", CurrentCompany.Address2);
            }
            if (City == true)
            {
                rpt.SetParameterValue("pCity", CurrentCompany.City);
            }
            if (State == true)
            {
                rpt.SetParameterValue("pState", "");
            }
            if (PinCode == true)
            {
                rpt.SetParameterValue("pPinCode", CurrentCompany.Pincode);
            }
            if (phone == true)
            {
                rpt.SetParameterValue("pPhone", CurrentCompany.Phone1);
            }
            if (Phone2 == true)
            {
                rpt.SetParameterValue("pPhone2", CurrentCompany.Phone2);
            }
            if (Fax == true)
            {
                rpt.SetParameterValue("pFax", CurrentCompany.Fax);
            }
            if (Email == true)
            {
                rpt.SetParameterValue("pEmail", CurrentCompany.Email);
            }
        }

        public static void AddExtraParameter(CrystalDecisions.CrystalReports.Engine.ReportDocument rpt)
        {
            if (CurrentCompany.Name1 != null)
            {
                rpt.SetParameterValue("pName1", CurrentCompany.Name1);
            }
            else
            {
                rpt.SetParameterValue("pName1", "");
            }
            if (CurrentCompany.Name2 != null)
            {
                rpt.SetParameterValue("pName2", CurrentCompany.Name2);
            }
            else
            {
                rpt.SetParameterValue("pName2", "");
            }
            if (CurrentCompany.Name3 != null)
            {
                rpt.SetParameterValue("pName3", CurrentCompany.Name3);
            }
            else
            {
                rpt.SetParameterValue("pName3", "");
            }
            if (CurrentCompany.Name4 != null)
            {
                rpt.SetParameterValue("pName4", CurrentCompany.Name4);
            }
            else
            {
                rpt.SetParameterValue("pName4", "");
            }
            if (CurrentCompany.Name5 != null)
            {
                rpt.SetParameterValue("pName5", CurrentCompany.Name5);
            }
            else
            {
                rpt.SetParameterValue("pName5", "");
            }
            if (CurrentCompany.Name6 != null)
            {
                rpt.SetParameterValue("pName6", CurrentCompany.Name6);
            }
            else
            {
                rpt.SetParameterValue("pName6", "");
            }
            if (CurrentCompany.Value1 != null)
            {
                rpt.SetParameterValue("pValue1", CurrentCompany.Value1);
            }
            else
            {
                rpt.SetParameterValue("pValue1", "");
            }
            if (CurrentCompany.Value2 != null)
            {
                rpt.SetParameterValue("pValue2", CurrentCompany.Value2);
            }
            else
            {
                rpt.SetParameterValue("pValue2", "");
            }
            if (CurrentCompany.Value3 != null)
            {
                rpt.SetParameterValue("pValue3", CurrentCompany.Value3);
            }
            else
            {
                rpt.SetParameterValue("pValue3", "");
            }
            if (CurrentCompany.Value4 != null)
            {
                rpt.SetParameterValue("pValue4", CurrentCompany.Value4);
            }
            else
            {
                rpt.SetParameterValue("pValue4", "");
            }
            if (CurrentCompany.Value5 != null)
            {
                rpt.SetParameterValue("pValue5", CurrentCompany.Value5);
            }
            else
            {
                rpt.SetParameterValue("pValue5", "");
            }
            if (CurrentCompany.Value6 != null)
            {
                rpt.SetParameterValue("pValue6", CurrentCompany.Value6);
            }
            else
            {
                rpt.SetParameterValue("pValue6", "");
            }

          

            //if (CurrentCompany.Com_Profile != null)
            //{
            //    rpt.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
            //}
            //else
            //{
            //    rpt.SetParameterValue("pCompanyProfile", "");
            //}
        }


        #endregion
    }
}
