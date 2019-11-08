using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class PurchaseIndentBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public PurchaseIndentBL()
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
        public void Insert(string SrNo, DateTime IndentDate, string itemcode, string productcode, string itemDetails, decimal qtyreqd, decimal qtyinstock, decimal stockinhand,
            decimal unitprice, decimal totalcost,string itemused, string purchaseindent, string statuspo, string Remarks)
        {// bool Quotation_Send ,
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_SrNo", SrNo.ToString());
            para.Add("@i_IndentDate", IndentDate.ToString("MM/dd/yyyy"));
            para.Add("@i_itemcode", itemcode.ToString());
            para.Add("@i_productcode", productcode.ToString());
            para.Add("@i_itemDetails", itemDetails.ToString());
            para.Add("@i_qtyreqd", qtyreqd.ToString());
            para.Add("@i_qtyinstock", qtyinstock.ToString());
            para.Add("@i_stockinhand", stockinhand.ToString());
            para.Add("@i_unitprice", unitprice.ToString());
            para.Add("@i_totalcost", totalcost.ToString());
            para.Add("@i_itemused", itemused.ToString());
            para.Add("@i_purchaseindent", purchaseindent.ToString());
            para.Add("@i_statuspo", statuspo.ToString());
            para.Add("@i_Remarks", Remarks.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
           
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseIndent_Insert", para, true, ref mException, ref mErrorMsg, "Lead - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }


          public void Update(long ID,string SrNo, DateTime IndentDate, string itemcode, string productcode, string itemDetails, decimal qtyreqd, decimal qtyinstock, decimal stockinhand,
            decimal unitprice, decimal totalcost,string itemused, string purchaseindent, string statuspo, string Remarks)

            {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();


            para.Add("@i_ID", ID.ToString());
            para.Add("@i_SrNo", SrNo.ToString());
            para.Add("@i_IndentDate", IndentDate.ToString("MM/dd/yyyy"));
            para.Add("@i_itemcode", itemcode.ToString());
            para.Add("@i_productcode", productcode.ToString());
            para.Add("@i_itemDetails", itemDetails.ToString());
            para.Add("@i_qtyreqd", qtyreqd.ToString());
            para.Add("@i_qtyinstock", qtyinstock.ToString());
            para.Add("@i_stockinhand", stockinhand.ToString());
            para.Add("@i_unitprice", unitprice.ToString());
            para.Add("@i_totalcost", totalcost.ToString());
            para.Add("@i_itemused", itemused.ToString());
            para.Add("@i_purchaseindent", purchaseindent.ToString());
            para.Add("@i_statuspo", statuspo.ToString());
            para.Add("@i_Remarks", Remarks.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
           
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseIndent_Update", para, true, ref mException, ref mErrorMsg, "Lead - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }





      
       
        public void InsertLeadDocument(long LeadID, string DocName)
        {



            SetDefaultException();
            //NameValueCollection padoc = new NameValueCollection();
            //padoc.Add("@i_leaddocno", leaddocno.ToString());
            //DataAccess.DataAccess objleaddoc = new DataAccess.DataAccess();
            //objDA.ExecuteSP("usp_Leaddocno", padoc, false, ref mException, ref mErrorMsg, "Sale - Insert");

            //dtblLOV = objDA.ListOfRecord("usp_Customer_Lead_LOV", para, "Customer LOV - LoadList");


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_LeadID", LeadID.ToString());
            para.Add("@i_DocName", DocName);
            //para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PurchaseindentDocList_Insert", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }
    }
}

