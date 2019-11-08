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
    class MaterialReturnBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public MaterialReturnBL()
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
        public void Insert(long _MRID,  string code, long ItemID, int GodownID, int emp1, int emp2, string narration, string itemcode, decimal returnqty, decimal IssueQTY,decimal reamingqty)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_emp1", emp1.ToString());
            para.Add("@i_emp2", emp2.ToString());
            para.Add("@i_MRID", _MRID.ToString());
            para.Add("@i_narration", narration.ToString());

            para.Add("@i_Itemcode", itemcode.ToString());
            para.Add("@i_returnqty", returnqty.ToString());
            para.Add("@i_IssueQTY", IssueQTY.ToString());
            para.Add("@i_MaterialIssuecode", code.ToString());
            para.Add("@i_reamingqty", reamingqty.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_MatearialReturn_Insert", para, true, ref mException, ref mErrorMsg, "MatearialIssue - Insert");

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

        public void Update(long _MRID, long MaterialID, string code, long ItemID, int GodownID, int emp1, int emp2, string narration, string itemcode, decimal returnqty, decimal IssueQTY, decimal reamingqty)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_MaterialID", MaterialID.ToString());

            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_ItemID", ItemID.ToString());
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_emp1", emp1.ToString());
            para.Add("@i_emp2", emp2.ToString());
            para.Add("@i_MRID", _MRID.ToString());
            para.Add("@i_narration", narration.ToString());

            para.Add("@i_Itemcode", itemcode.ToString());
            para.Add("@i_returnqty", returnqty.ToString());
            para.Add("@i_IssueQTY", IssueQTY.ToString());
            para.Add("@i_MaterialIssuecode", code.ToString());
            para.Add("@i_reamingqty", reamingqty.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_MatearialReturn_Update", para, true, ref mException, ref mErrorMsg, "MatearialIssue - Update");


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
                if (Convert.ToInt64(dt.Rows[0][0]) <= 1)
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
