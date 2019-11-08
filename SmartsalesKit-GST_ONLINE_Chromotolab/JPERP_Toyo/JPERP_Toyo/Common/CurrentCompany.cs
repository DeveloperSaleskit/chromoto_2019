using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.Common
{
    class CurrentCompany
    {
        #region "Private Fields ..."

        private static string mCompanyCode;
        private static string mCompanyName;
        private static int mCompId;
       
        private static string mBusinessLine;
        private static string mAddress1;
        private static string mAddress2;
        private static string mCity;
        private static string mPincode;
        private static string mPhone1;
        private static string mPhone2;
        private static string mMobile;
        private static string mFax;
        private static string mEmail;
        private static string mWeb;
        private static string mPAN;
        private static string mRegNo;
        private static string mCST;
        private static string mECC;
        private static string mTIN;
        private static string mState;
        private static string mRegAddress1;
        private static string mRegAddress2;
        private static string mRegCity;
        private static string mRegPhone;
        private static string mRegFax;
        private static string mCon_Host;
        private static string mCon_Port;
        private static string mCon_SSL;
        private static string mUser_ssl;
        private static string mCon_Email;
        private static string mCompany_Email;
        private static string mUser_Email;
       
        private static string mCon_Password;
        private static string mHost;
        private static string mLogo;
        private static string mHeader;
        private static string mFooter;
        private static string mSign;
        private static string mName1;
        private static string mName2;
        private static string mName3;
        private static string mName4;
        private static string mName5;
        private static string mName6;
        private static string mValue1;
        private static string mValue2;
        private static string mValue3;
        private static string mValue4;
        private static string mValue5;
        private static string mValue6;
        private static string mCom_Profile;
        private static decimal mWastageFactor = 8;
        private static decimal mConversionCost = Convert.ToDecimal(2.5);
        private static decimal mFinancialCharge = Convert.ToDecimal(12.5);
        private static decimal mSalary = Convert.ToDecimal(3.5);
        private static decimal mPackingCharge = Convert.ToDecimal(1.5);
        private static decimal mTransportationCharge = 4;
        private static decimal mOtherCharge = 6;
        private static decimal mProfitRatio = 2;
        private static Int32 mGlobalSettingID = 0;
        private static int mIsApproval = 0;
        private static int mPort = 0;
        private static int mssl = 0;

        private static string mServerIP = "";
        private static string mUserName = "";
        private static string mPassword = "";
        private static string mFTPReportPath = "";
        private static string mDBName, mItemImage, mRevisedMode, mAutoMailPayQuo;
        #endregion

        #region "Public Properties ..."
        public static string Con_Host
        {
            get
            { return mCon_Host; }
            set
            { mCon_Host = value; }
        }
        public static string Con_Port
        {
            get
            { return mCon_Port; }
            set
            { mCon_Port = value; }
        }

        public static string Con_SSL
        {
            get
            { return mCon_SSL; }
            set
            { mCon_SSL = value; }
        }
        public static string User_ssl
        {
            get
            { return mUser_ssl; }
            set
            { mUser_ssl = value; }
        }

        public static string Con_Email
        {
            get
            { return mCon_Email; }
            set
            { mCon_Email = value; }
        }
        public static string Company_Email
        {
            get
            { return mCompany_Email; }
            set
            { mCompany_Email = value; }
        }
        public static string User_Email
        {
            get
            { return mUser_Email; }
            set
            { mUser_Email = value; }
        }

        public static string Con_Password
        {
            get
            { return mCon_Password; }
            set
            { mCon_Password = value; }
        }
        public static string CompanyCode
        {
            get
            { return mCompanyCode; }
            set
            { mCompanyCode = value; }
        }

        public static string CompanyName
        {
            get
            { return mCompanyName; }
            set
            { mCompanyName = value; }
        }
        public static int CompId
        {
            get
            { return mCompId; }
            set
            { mCompId = value; }
        }
      
        public static string BusinessLine
        {
            get
            { return mBusinessLine; }
            set
            { mBusinessLine = value; }
        }

        public static string Address1
        {
            get
            { return mAddress1; }
            set
            { mAddress1 = value; }
        }

        public static string Address2
        {
            get
            { return mAddress2; }
            set
            { mAddress2 = value; }
        }

        public static string City
        {
            get
            { return mCity; }
            set
            { mCity = value; }
        }

        public static string Pincode
        {
            get
            { return mPincode; }
            set
            { mPincode = value; }
        }

        public static string Phone1
        {
            get
            { return mPhone1; }
            set
            { mPhone1 = value; }
        }

        public static string Phone2
        {
            get
            { return mPhone2; }
            set
            { mPhone2 = value; }
        }

        public static string Mobile
        {
            get
            { return mMobile; }
            set
            { mMobile = value; }
        }

        public static string Fax
        {
            get
            { return mFax; }
            set
            { mFax = value; }
        }

        public static string Email
        {
            get
            { return mEmail; }
            set
            { mEmail = value; }
        }

        public static string Web
        {
            get
            { return mWeb; }
            set
            { mWeb = value; }
        }

        public static string PAN
        {
            get
            { return mPAN; }
            set
            { mPAN = value; }
        }

        public static string RegNo
        {
            get
            { return mRegNo; }
            set
            { mRegNo = value; }
        }

        public static string CST
        {
            get
            { return mCST; }
            set
            { mCST = value; }
        }

        public static string ECC
        {
            get
            { return mECC; }
            set
            { mECC = value; }
        }

        public static string TIN
        {
            get
            { return mTIN; }
            set
            { mTIN = value; }
        }

        public static string State
        {
            get
            { return mState; }
            set
            { mState = value; }

        }

        public static string RegAddress1
        {
            get
            { return mRegAddress1; }
            set
            { mRegAddress1 = value; }
        }

        public static string RegAddress2
        {
            get
            { return mRegAddress2; }
            set
            { mRegAddress2 = value; }
        }

        public static string RegCity
        {
            get
            { return mRegCity; }
            set
            { mRegCity = value; }
        }

        public static string RegPhone
        {
            get
            { return mRegPhone; }
            set
            { mRegPhone = value; }
        }

        public static string RegFax
        {
            get
            { return mRegFax; }
            set
            { mRegFax = value; }
        }

        public static decimal WastageFactor
        {
            get
            { return mWastageFactor; }
            set
            { mWastageFactor = value; }
        }

        public static decimal ConversionCost
        {
            get
            { return mConversionCost; }
            set
            { mConversionCost = value; }
        }

        public static decimal FinancialCharge
        {
            get
            { return mFinancialCharge; }
            set
            { mFinancialCharge = value; }
        }

        public static decimal Salary
        {
            get
            { return mSalary; }
            set
            { mSalary = value; }
        }

        public static decimal PackingCharge
        {
            get
            { return mPackingCharge; }
            set
            { mPackingCharge = value; }
        }

        public static decimal TransportationCharge
        {
            get
            { return mTransportationCharge; }
            set
            { mTransportationCharge = value; }
        }

        public static decimal OtherCharge
        {
            get
            { return mOtherCharge; }
            set
            { mOtherCharge = value; }
        }

        public static decimal ProfitRatio
        {
            get
            { return mProfitRatio; }
            set
            { mProfitRatio = value; }
        }

        public static Int32 GlobalSettingID
        {
            get { return mGlobalSettingID; }
            set { mGlobalSettingID = value; }
        }

        public static int IsApproval
        {
            get { return mIsApproval; }
            set { mIsApproval = value; }
        }

        public static int ssl
        {
            get { return mssl; }
            set { mssl = value; }
        }

        public static int Port
        {
            get { return mPort; }
            set { mPort = value; }
        }

        public static string Host
        {
            get
            { return mHost; }
            set
            { mHost = value; }
        }
        public static string Logo
        {
            get
            { return mLogo; }
            set
            { mLogo = value; }
        }
        public static string Header
        {
            get
            { return mHeader; }
            set
            { mHeader = value; }
        }
        public static string Footer
        {
            get
            { return mFooter; }
            set
            { mFooter = value; }
        }
        public static string Sign
        {
            get
            { return mSign; }
            set
            { mSign = value; }
        }
        public static string Name1
        {
            get
            { return mName1; }
            set
            { mName1 = value; }
        }
        public static string Name2
        {
            get
            { return mName2; }
            set
            { mName2 = value; }
        }
        public static string Name3
        {
            get
            { return mName3; }
            set
            { mName3 = value; }
        }
        public static string Name4
        {
            get
            { return mName4; }
            set
            { mName4 = value; }
        }
        public static string Name5
        {
            get
            { return mName5; }
            set
            { mName5 = value; }
        }
        public static string Name6
        {
            get
            { return mName6; }
            set
            { mName6 = value; }
        }

        public static string Value1
        {
            get
            { return mValue1; }
            set
            { mValue1 = value; }
        }

        public static string Value2
        {
            get
            { return mValue2; }
            set
            { mValue2 = value; }
        }

        public static string Value3
        {
            get
            { return mValue3; }
            set
            { mValue3 = value; }
        }
        public static string Value4
        {
            get
            { return mValue4; }
            set
            { mValue4 = value; }
        }

        public static string Value5
        {
            get
            { return mValue5; }
            set
            { mValue5 = value; }
        }

        public static string Value6
        {
            get
            { return mValue6; }
            set
            { mValue6 = value; }
        }

        public static string Com_Profile
        {
            get
            { return mCom_Profile; }
            set
            { mCom_Profile = value; }
        }

        public static string DBName
        {
            get
            { return mDBName; }
            set
            { mDBName = value; }
        }

        public static string ItemImage
        {
            get
            { return mItemImage; }
            set
            { mItemImage = value; }
        }

        public static string RevisedMode
        {
            get
            { return mRevisedMode; }
            set
            { mRevisedMode = value; }
        }

        public static string AutoMailPayQuo
        {
            get
            { return mAutoMailPayQuo; }
            set
            { mAutoMailPayQuo = value; }
        }


        public static string ServerIP
        {
            get
            { return mServerIP; }
            set
            { mServerIP = value; }
        }

        public static string UserName
        {
            get
            { return mUserName; }
            set
            { mUserName = value; }
        }

        public static string Password
        {
            get
            { return mPassword; }
            set
            { mPassword = value; }
        }

        public static string FTPReportPath
        {
            get
            { return mFTPReportPath; }
            set
            { mFTPReportPath = value; }
        }
        #endregion

    }
}
