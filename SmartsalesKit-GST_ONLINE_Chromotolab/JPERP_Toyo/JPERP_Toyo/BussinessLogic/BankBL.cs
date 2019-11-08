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
    class BankBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public BankBL()
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

        public void Insert(string BankName, string Bankaddr, string IFSCcode,string AccNo,string PhNo)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_BankAddr", Bankaddr);
            para.Add("@i_IFSCcode", IFSCcode);
            para.Add("@i_BankName",BankName);
            para.Add("@i_AccNo", AccNo);
            para.Add("@i_PhNo", PhNo);
            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Bank_Insert", para, true, ref mException, ref mErrorMsg, "Bank - Insert");

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

        public void Update(long BankID, string BankName, string Bankaddr, string IFSCcode, string AccNo, string PhNo)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_BankID", BankID.ToString());
            para.Add("@i_BankAddr", Bankaddr);
            para.Add("@i_IFSCcode", IFSCcode);
            para.Add("@i_BankName", BankName);
            para.Add("@i_AccNo", AccNo);
            para.Add("@i_PhNo", PhNo);
            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Bank_Update", para, true, ref mException, ref mErrorMsg, "Bank - Update");

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
