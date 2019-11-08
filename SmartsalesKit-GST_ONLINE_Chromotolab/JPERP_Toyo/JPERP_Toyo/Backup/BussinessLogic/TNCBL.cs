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
    class TNCBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public TNCBL()
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

        public void Insert(string TNC_Sub, string TNC_Desc, Int32 Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", TNC_Sub);
            para.Add("@i_ContactData", TNC_Desc);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_TNC_Insert", para, true, ref mException, ref mErrorMsg, "TNC - Insert");

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

        public void Update(long TNCID, string TNC_Sub, string TNC_Desc)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNCID", TNCID.ToString());
            para.Add("@i_TNC_Sub", TNC_Sub);
            para.Add("@i_TNC_Desc", TNC_Desc);
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_TNC_Update", para, true, ref mException, ref mErrorMsg, "TNC - Update");

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
