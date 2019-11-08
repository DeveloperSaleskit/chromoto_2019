using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class AccountBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public AccountBL()
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

        public void Insert(string AccCode, string AccName, DateTime DOE, Decimal OpeningCrAmount, Decimal ClosingDBAmount)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection Para = new NameValueCollection();

            Para.Add("@i_FYID", CurrentUser.FYID.ToString());
            Para.Add("@i_AccountCode", AccCode);
            Para.Add("@i_AccountName", AccName);
            Para.Add("@i_AccCreatedDate", String.Format("{0:MM/dd/yyyy}", DOE));
            Para.Add("@i_OpeningCRAmount", OpeningCrAmount.ToString());
            Para.Add("@i_ClosingDBAmount", ClosingDBAmount.ToString());
            objDA.ExecuteSP("usp_Account_Insert", Para, true, ref mException, ref mErrorMsg, "Account - Insert");
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

        public void Update(long AccountID, string AccCode, string AccName, DateTime DOE, Decimal OpeningCrAmount, Decimal ClosingDBAmount)
        {

            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection Para = new NameValueCollection();

            Para.Add("@i_AccountID", AccountID.ToString());
            Para.Add("@i_FYID", CurrentUser.FYID.ToString());
            Para.Add("@i_AccountCode", AccCode);
            Para.Add("@i_AccountName", AccName);
            Para.Add("@i_AccCreatedDate", String.Format("{0:MM/dd/yyyy}", DOE));
            Para.Add("@i_OpeningCRAmount", OpeningCrAmount.ToString());
            Para.Add("@i_ClosingDBAmount", ClosingDBAmount.ToString());
            objDA.ExecuteSP("usp_Account_Update", Para, true, ref mException, ref mErrorMsg, "Account - Update");
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

        public void Delete(long RecID, string SPName, string mModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());
            para.Add("@i_IsDelete", 1.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteDeleteSP(SPName, para, true, ref mException, ref mErrorMsg, mModuleName);

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = null;
                CommonDeleteBL objCommDel = new CommonDeleteBL();
                this.ErrorMessage = objCommDel.PrepareMsg(mException, mModuleName);

            }
        }

    }
}
