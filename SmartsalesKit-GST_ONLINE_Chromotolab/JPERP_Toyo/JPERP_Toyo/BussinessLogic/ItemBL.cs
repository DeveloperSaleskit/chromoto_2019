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
    class ItemBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public ItemBL()
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

        public void Insert(string Code, string ItemName, string OtherName, string Specification, long CUOM,
           decimal Price, string ProductCode, string HSNCode, string XmlString,long Cnt,
            decimal QOH, decimal ReOrderLvl, string Location, string RackNo, int GodownID, string DocName, long CurrencyID
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code);
            para.Add("@i_ItemName", ItemName);
            para.Add("@i_OtherName", OtherName);
            para.Add("@i_Specification", Specification);
            para.Add("@i_CUOMID", CUOM.ToString());
            para.Add("@i_Price", Price.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_ProductCode", ProductCode.ToString());
            para.Add("@i_HSNCode", HSNCode.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_QOH", QOH.ToString());
            para.Add("@i_ReOrderLvl", ReOrderLvl.ToString());
            para.Add("@i_Location", Location);
            para.Add("@i_RackNo", RackNo);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_DocName", DocName);
            para.Add("@i_CurrencyID", CurrencyID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Item_Insert", para, true, ref mException, ref mErrorMsg, "ItemBL - Insert");

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

        public void Update(long ItemID, long StockID, string Code, string ItemName, string OtherName, string Specification, long CUOM,
            decimal Price, string ProductCode, string HSNCode,
            decimal QOH, decimal ReOrderLvl, string Location, string RackNo, int GodownID, string DocName, long CurrencyID
            )
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_StockID", StockID.ToString());
            para.Add("@i_Code", Code);
            para.Add("@i_ItemName", ItemName);
            para.Add("@i_OtherName", OtherName);
            para.Add("@i_Specification", Specification);
            para.Add("@i_CUOMID", CUOM.ToString());
            para.Add("@i_Price", Price.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_ProductCode", ProductCode.ToString());
            para.Add("@i_HSNCode", HSNCode.ToString());
            para.Add("@i_QOH", QOH.ToString());
            para.Add("@i_ReOrderLvl", ReOrderLvl.ToString());
            para.Add("@i_Location", Location);
            para.Add("@i_RackNo", RackNo);
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_DocName", DocName);
            para.Add("@i_CurrencyID", CurrencyID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Item_Update", para, true, ref mException, ref mErrorMsg, "ItemBL - Update");

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

        public void UpdateRates(DateTime Date, string XMLData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Date", Date.ToString("MM/dd/yyyy"));
            para.Add("@i_XmlData", XMLData);
            para.Add("@i_Cnt", Cnt.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Item_Rate_Insert", para, true, ref mException, ref mErrorMsg, "ItemBL - UpdateRates");

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

        public void UplodItem(string XMLString, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_XMLString", XMLString);
            para.Add("@i_Cnt", Cnt.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Item_Upload", para, false, ref mException, ref mErrorMsg, "ItemBL - UpdateRates");

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
