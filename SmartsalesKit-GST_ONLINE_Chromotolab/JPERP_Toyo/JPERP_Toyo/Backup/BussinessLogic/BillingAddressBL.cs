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
    class BillingAddressBL : BusinessBase
    {
         Exception mException = null;
        string mErrorMsg = "";

        public BillingAddressBL()
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
        public void Insert(int AddressType, long RefID, string AddressData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_AddressType", AddressType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_AddressData", AddressData);
            para.Add("@i_Cnt", Cnt.ToString());           
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_AddressDetail_Insert", para, true, ref mException, ref mErrorMsg, "BillingAddress - Insert");

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
