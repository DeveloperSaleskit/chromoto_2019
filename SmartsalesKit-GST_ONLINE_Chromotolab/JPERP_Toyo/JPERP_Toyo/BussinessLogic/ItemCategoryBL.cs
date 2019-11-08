using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.Common;

namespace Account.BusinessLogic
{
    class ItemCategoryBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public ItemCategoryBL()
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

        public void Insert(string ItemCategoryName,long ItemGroupID)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Name", ItemCategoryName);
            para.Add("@i_ItemGroupID", ItemGroupID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_ItemCategory_Insert", para, true, ref mException, ref mErrorMsg, "ItemCategoryBL - Insert");
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

        public void Update(long ItemCategoryID, string ItemCategoryName, long ItemGroupID)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_CategoryID", ItemCategoryID.ToString());
            para.Add("@i_ItemCategoryName", ItemCategoryName);
            para.Add("@i_ItemGroupID", ItemGroupID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemCategory_Update", para, true, ref mException, ref mErrorMsg, "ItemCategoryBL - Upadte");

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
