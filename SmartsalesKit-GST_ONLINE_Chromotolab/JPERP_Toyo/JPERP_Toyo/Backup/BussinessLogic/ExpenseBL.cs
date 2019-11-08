using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class ExpenseBL : BusinessBase
    {
          Exception mException = null;
        string mErrorMsg = "";

        public ExpenseBL()
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

        public void Insert(string ExpNo,DateTime DOE, Decimal Amount,string Narration)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection Para = new NameValueCollection();

            Para.Add("@i_FYID", CurrentUser.FYID.ToString());
            Para.Add("@i_ExpNo", ExpNo);
            Para.Add("@i_Date", String.Format("{0:MM/dd/yyyy}",DOE));
            Para.Add("@i_Amount", Amount.ToString());
            Para.Add("@i_Narration", Narration);
            objDA.ExecuteSP("usp_Expense_Insert", Para, true, ref mException, ref mErrorMsg, "Expense - Insert");
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

        public void Update(long ExpenseID, DateTime DOE, Decimal Amount, string Narration)
        {

            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection Para = new NameValueCollection();

            Para.Add("@i_FYID", CurrentUser.FYID.ToString());
            Para.Add("@i_ExpenseID", ExpenseID.ToString());
            Para.Add("@i_Date", String.Format("{0:MM/dd/yyyy}", DOE));
            Para.Add("@i_Amount", Amount.ToString());
            Para.Add("@i_Narration", Narration);

            objDA.ExecuteSP("usp_Expense_Update", Para, true, ref mException, ref mErrorMsg, "Expense - Update");
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
