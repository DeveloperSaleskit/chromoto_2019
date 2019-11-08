using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class CommissionBL : BusinessBase
    {
          Exception mException = null;
        string mErrorMsg = "";

        public CommissionBL()
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

        public void Insert(long AccountID, DateTime DOE, Decimal CrAmount, Decimal DBAmount,string Narration)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection Para = new NameValueCollection();

            Para.Add("@i_FYID", CurrentUser.FYID.ToString());
            Para.Add("@i_AccountID", AccountID.ToString());
            Para.Add("@i_Date", String.Format("{0:MM/dd/yyyy}",DOE));
            Para.Add("@i_CRAmount", CrAmount.ToString());
            Para.Add("@i_DBAmount", DBAmount.ToString());
            Para.Add("@i_Narration", Narration);

            objDA.ExecuteSP("usp_Commission_Insert", Para, true, ref mException, ref mErrorMsg, "Account - Insert");
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
