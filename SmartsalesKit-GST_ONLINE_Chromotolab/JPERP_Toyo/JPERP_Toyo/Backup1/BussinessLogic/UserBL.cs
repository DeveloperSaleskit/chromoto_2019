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
    class UserBL : BusinessBase
    {
        int _CompId = 0;
        Exception mException = null;
        string mErrorMsg = "";

        public UserBL()
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

        public void Insert(int CompId, string Company, string UserName, string Password, string Name, string Company_Email, string User_Email, string User_Password, string User_NPassword, string User_Host, string User_Port, string User_ssl, bool Mail_ByUser, string strPrivilegeList)
        {
            SetDefaultException();
           
            NameValueCollection para = new NameValueCollection();
           
           
            para.Add("@i_Company", Company);
            para.Add("@i_UserName", UserName);
            para.Add("@i_Password", Password);
            para.Add("@i_Name", Name);
            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_Company_Email",Company_Email.ToString());
            para.Add("@i_User_Email",User_Email.ToString());
            para.Add("@i_User_Password", User_Password);
            para.Add("@i_User_NPassword", User_NPassword);
            para.Add("@i_User_Host", User_Host);
            para.Add("@i_User_Port", User_Port);
            para.Add("@i_User_ssl", User_ssl);
            para.Add("@i_Mail_Send", Mail_ByUser.ToString());
            para.Add("@i_strPrivilegeList", strPrivilegeList);
         
            para.Add("@i_CompId", CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_User_Insert", para, true, ref mException, ref mErrorMsg,"User - Insert");

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

        public void Update(long UserID, int CompId, string Company, string UserName, string Password, string Name, string Company_Email, string User_Email, string User_Password, string User_NPassword, string User_Host, string User_Port, string User_ssl, bool Mail_ByUser, string strPrivilegeList)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", UserID.ToString());
            para.Add("@i_CompId", CompId.ToString());
            para.Add("@i_Company", Company);
            para.Add("@i_UserName", UserName);
            para.Add("@i_User_Password", User_Password);
            para.Add("@i_User_NPassword", User_NPassword);
            para.Add("@i_Name", Name);
            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_Company_Email", Company_Email.ToString());
            para.Add("@i_User_Email", User_Email.ToString());
            para.Add("@i_Password", Password);
            para.Add("@i_User_Port", User_Port);
            para.Add("@i_User_ssl", User_ssl);
            para.Add("@i_User_Host", User_Host);
            para.Add("@i_Mail_Send", Mail_ByUser.ToString());
            para.Add("@i_strPrivilegeList", strPrivilegeList);
           


            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_User_Update", para, true, ref mException, ref mErrorMsg,"User - Update");

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
        public DataTable GetUserPriviliegiesList()
        {
            SetDefaultException();
            DataTable dt = new DataTable();

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            dt = objDA.ExecuteDataTableSP("usp_GetPrivilege_List", null, false, ref mException, ref mErrorMsg, "User - GetUserPriviliegiesList");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
                else
                {
                    return dt;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }
        public DataTable GetUserParentPriviliegiesList(Int64 ParentID)
        {
            SetDefaultException();
            DataTable dt = new DataTable();
            NameValueCollection paralist = new NameValueCollection();
            paralist.Add("@i_ParentID", ParentID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            dt = objDA.ExecuteDataTableSP("usp_GetParentPrivilege_List", paralist, false, ref mException, ref mErrorMsg, "User - GetUserParentPriviliegiesList");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
                else
                {
                    return dt;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }
        public DataTable GetSelectedUserPriviliegiesList(Int64 UserID)
        {
            SetDefaultException();
            DataTable dt = new DataTable();
            NameValueCollection paralist = new NameValueCollection();
            paralist.Add("@i_UserID", UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            dt = objDA.ExecuteDataTableSP("usp_GetSelectedPrivilegeList", paralist, false, ref mException, ref mErrorMsg, "User - GetSelectedUserPriviliegiesList");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
                else
                {
                    return dt;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }


        public void Activate_DeactivateUser(Int64 UserID,long CompId, int ActivateID,string SPName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", UserID.ToString());
            para.Add("@i_ActivateID", ActivateID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP(SPName, para, false, ref mException, ref mErrorMsg, "User - Activate_DeactivateUser");

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

        public void ChangePassword(string OldPassword,string NewPassword,string SPName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_OldPassword", OldPassword);
            para.Add("@i_NewPassword", NewPassword);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP(SPName, para, true, ref mException, ref mErrorMsg, "User - ChangePassword");

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
        
       

        public DataTable GetColumnsList(NameValueCollection paralist,string SpName)
        {
            SetDefaultException();
            DataTable dt = new DataTable();          

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            dt = objDA.ExecuteDataTableSP(SpName, paralist, false, ref mException, ref mErrorMsg, "User - GetColumnsList");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
                else
                {
                    return dt;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }
    }
}
