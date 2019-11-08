using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class CurrencyBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public CurrencyBL()
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

        public void Insert(string CurrencyName, string Currency)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            
          
            para.Add("@i_CurrencyName", CurrencyName);
            para.Add("@i_Currency", Currency);
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Currency_Insert", para, true, ref mException, ref mErrorMsg, "Employee - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void Update(long CurrencyID, string CurrencyName, string Currency)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();


            para.Add("@i_CurrencyID", CurrencyID.ToString());
            para.Add("@i_CurrencyName", CurrencyName);
            para.Add("@i_Currency", Currency);
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

           
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Currency_Update", para, true, ref mException, ref mErrorMsg, "Employee - Update");
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
