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
    class ItemStockBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public ItemStockBL()
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
        public void Insert(long ItemID, decimal QOH, decimal MinLevel, decimal MaxLevel, decimal ReOrderLvl, string Location, string RackNo, DateTime StockDate , int GodownID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_QOH", QOH.ToString());
            para.Add("@i_MinLevel", MinLevel.ToString());
            para.Add("@i_MaxLevel", MaxLevel.ToString());
            para.Add("@i_ReOrderLvl", ReOrderLvl.ToString());
            para.Add("@i_Location", Location);
            para.Add("@i_RackNo", RackNo);
            para.Add("@i_Date", StockDate.ToString("MM/dd/yyyy"));
           // para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_GodownID", GodownID.ToString());

          //  para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemStock_Insert", para, true, ref mException, ref mErrorMsg, "ItemStock - Insert");

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

        public void Update(long StockID, long ItemID, decimal QOH, decimal MinLevel, decimal MaxLevel, decimal ReOrderLvl, string Location, string RackNo,  DateTime StockDate , int GodownID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_StockID", StockID.ToString());
            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_QOH", QOH.ToString());
            para.Add("@i_MinLevel", MinLevel.ToString());
            para.Add("@i_MaxLevel", MaxLevel.ToString());
            para.Add("@i_ReOrderLvl", ReOrderLvl.ToString());
            para.Add("@i_Location", Location);
            para.Add("@i_RackNo", RackNo);
            para.Add("@i_Date", StockDate.ToString("MM/dd/yyyy"));
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemStock_Update", para, true, ref mException, ref mErrorMsg, "ItemStock - Update");

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

        public bool EnableEditDelete(long StockID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            DataTable dt = new DataTable();
            para.Add("@i_StockID", StockID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            dt = objDA.ExecuteDataTableSP("usp_ItemStock_Editable", para, false, ref mException, ref mErrorMsg, "ItemStock - EnableEditDelete");

            if (mException == null)
            {
                if (Convert.ToInt64( dt.Rows[0][0]) <= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                this.Exception = mException;
                return false;
            }
        }

        public void AdjustStock(DateTime AdjustDate, string Narration, string xmlData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_AdjustDate", AdjustDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Narration", Narration);
            para.Add("@i_xmlData", xmlData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ItemStock_AdjustStock", para, true, ref mException, ref mErrorMsg, "ItemStock - AdjustStock");

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
