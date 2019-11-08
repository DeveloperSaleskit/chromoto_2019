using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.Common;

namespace Account.BusinessLogic
{
    class ItemGroupBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public ItemGroupBL()
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

        public void Insert(string ItemGroupName)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Name", ItemGroupName);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_ItemGroup_Insert", para, true, ref mException, ref mErrorMsg, "ItemGroupBL - Insert");
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

        public void Update(long ItemGroupID, string ItemGroupName)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_ItemGroupID", ItemGroupID.ToString());
            para.Add("@i_ItemGroupName", ItemGroupName);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemGroup_Update", para, true, ref mException, ref mErrorMsg, "ItemGroupBL - Upadte");

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
