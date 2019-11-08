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
    class ItemAdjustmentBL : BusinessBase
    {
         Exception mException = null;
        string mErrorMsg = "";

        public ItemAdjustmentBL()
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
        public void Insert(DateTime AdjustDate, long ItemID, decimal Qty, string Narration, int GodownID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_AdjustDate", AdjustDate.ToString("MM/dd/yyyy"));
            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_Qty", Qty.ToString());
            para.Add("@i_Narration", Narration);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompanyID", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemAdjustment_Insert", para, true, ref mException, ref mErrorMsg, "ItemAdjustment - Insert");

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

        public void Update(long AdjustmentID, DateTime AdjustDate, long ItemID, decimal Qty, string Narration, int GodownID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_AdjustmentID", AdjustmentID.ToString());           
            para.Add("@i_AdjustDate", AdjustDate.ToString("MM/dd/yyyy"));
            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_Qty", Qty.ToString());
            para.Add("@i_Narration", Narration);

            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompanyID", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemAdjustment_Update", para, true, ref mException, ref mErrorMsg, "ItemAdjustment - Update");

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

        public void Confirm(long AdjustmentID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_AdjustmentID", AdjustmentID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemAdjustment_Confirm", para, true, ref mException, ref mErrorMsg, "ItemAdjustment - Update");

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
