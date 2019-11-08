
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.Common;

namespace Account.BusinessLogic
{
    class ItemClassBL : BusinessBase
    {
         Exception mException = null;
        string mErrorMsg = "";

        public ItemClassBL()
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

        public void Insert(string ItemClassName,string Description)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Name", ItemClassName);
            para.Add("@i_Description", Description);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemClass_Insert", para, true, ref mException, ref mErrorMsg, "ItemClassBL - Insert");
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

        public void Update(long ItemClassID, string ItemClassName,string Description)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_ItemClassID", ItemClassID.ToString());
            para.Add("@i_ItemClassName", ItemClassName);
            para.Add("@i_Description", Description);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemClass_Update", para, true, ref mException, ref mErrorMsg, "ItemClassBL - Upadte");

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
