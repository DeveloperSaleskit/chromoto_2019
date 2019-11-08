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

    class AutheticationBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public AutheticationBL()
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
        
        public DataSet SignIN(int CompId,string UserName,string Password,long FYID, string Version, string SPName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CompId", CompId.ToString());          
            para.Add("@i_UserName", UserName);
            para.Add("@i_Password", Password);
            para.Add("@i_Version", Version);
            para.Add("@i_FYID", FYID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataSet ds = new DataSet();
            ds = null;
            ds = objDA.ExecuteDataSetSP(SPName, para, true, ref mException, ref mErrorMsg,"SignIN");
            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return ds;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return ds;
        }

        public DataTable GetPrivilegeList(long UserID, string SPName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataTable dt = new DataTable();
            dt = null;
            dt = objDA.ExecuteDataTableSP(SPName, para, false, ref mException, ref mErrorMsg ,"GetPrivilegeList");

            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return dt;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }

        public DataTable GetCompanyInfo()
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataTable dt = new DataTable();
            dt = null;
            dt = objDA.ExecuteDataTableSP("usp_CompanyInfo_Select", null, false, ref mException, ref mErrorMsg, "GetCompanyInfo");

            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return dt;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }

        public DataTable GetUserWisePrivilegeList(int UserID)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_UserID", UserID.ToString());
            DataTable dt = new DataTable();
            dt = null;
            dt = objDA.ExecuteDataTableSP("usp_GetUserWisePrivilege_List", para, false, ref mException, ref mErrorMsg, "GetUserWisePrivilegeList");

            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return dt;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }

        public void UpdateLogIn()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_LogIn", "1");
                DataAccess.DataAccess objDA = new DataAccess.DataAccess();
                objDA.ExecuteSP("usp_LogIN_Update", para, false, ref mException, ref mErrorMsg, "LogIn - Update");
                if (mException == null)
                {
                    if (mErrorMsg != "")
                    {

                    }
                }
                else
                {
                    this.Exception = mException;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("LogIn - Update", exc.StackTrace);
            }
        }

        public void UpdateLogOut()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_LogIn", "0");
                DataAccess.DataAccess objDA = new DataAccess.DataAccess();
                objDA.ExecuteSP("usp_LogIN_Update", para, false, ref mException, ref mErrorMsg, "LogIn - Update");
                if (mException == null)
                {
                    if (mErrorMsg != "")
                    {

                    }
                }
                else
                {
                    this.Exception = mException;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("LogIn - Update", exc.StackTrace);
            }
        }

        public string GetLogIn()
        {
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_LogIN_Fetch", para, true, ref mException, ref mErrorMsg, "LogIn - Fetch");
            string LogIn = "";
            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    LogIn = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return LogIn;
        }
    }
}
