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
    class StateBL : BusinessBase 
    {
        Exception mException = null;
        string mErrorMsg = "";

        public StateBL()
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
        public void Insert(long CountryID,string StateName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CountryID", CountryID.ToString ());
            para.Add("@i_StateName", StateName);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_State_Insert", para, true, ref mException, ref mErrorMsg,"State - Insert");

            if (mException == null)
            {
                if (mErrorMsg !="")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
        }

        public void Update(long StateID,long CountryID,string StateName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_StateID", StateID.ToString());
            para.Add("@i_CountryID", CountryID.ToString());
            para.Add("@i_StateName", StateName);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_State_Update", para, true, ref mException, ref mErrorMsg, "State - Update");

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
