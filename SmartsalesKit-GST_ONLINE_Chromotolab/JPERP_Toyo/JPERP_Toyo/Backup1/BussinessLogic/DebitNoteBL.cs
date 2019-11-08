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
    class DebitNoteBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public DebitNoteBL()
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
        public Int32 Insert(string DNnumber, DateTime DNDate,  long VendorID,decimal ServiceAmount,
             decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount, decimal HEduCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal Discount, decimal NetAmount,
            string XmlString, Int64 Cnt, 
            
             
              decimal TotalDiscAmt, int CompId,
            string remark, decimal DebitNoteamount, decimal finalamount)
        {
            SetDefaultException();
            Int32 POID = 0;
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_DNnumber", DNnumber);

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_DNDate", DNDate.ToString("MM/dd/yyyy"));
            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", EduCessAmount.ToString());
            para.Add("@i_HCessAmount", HEduCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            //para.Add("@i_CC", CC.ToString());
            //para.Add("@i_BCC", BCC.ToString());
            
            para.Add("@i_TotalDiscAmt", Discount.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_remark", remark.ToString());
            para.Add("@i_Debitamount", DebitNoteamount.ToString());
            para.Add("@i_finalamount", finalamount.ToString());
            //para.Add("@i_GoDownID", GodownId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_DebitNote_Insert", para, true, ref mException, ref mErrorMsg, "DebitNote - Insert");

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    if (Validator.DataValidator.IsNumeric(mErrorMsg))
                    {
                        POID = Convert.ToInt32(mErrorMsg);
                        this.ErrorMessage = mErrorMsg;
                    }
                    else
                    {
                        this.ErrorMessage = mErrorMsg;
                    }
                }
            }
            else
            {
                this.Exception = mException;
            }
            return POID;
        }

        public void Update(long DNID, string DNnumber, DateTime DNDate, long VendorID, decimal ServiceAmount,
             decimal TotalAmount, decimal ExciseAmount, decimal EduCessAmount, decimal HEduCessAmount, decimal AmountAfterExcise,
            decimal CSTAmount, decimal VATAmount, decimal AVATAmount, decimal Discount, decimal NetAmount, 
            string XmlString, Int64 Cnt,
            
             
            decimal TotalDiscAmt, int CompId,
            string remark, decimal DebitNoteamount, decimal finalamount)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_DNID", DNID.ToString());
            para.Add("@i_DNnumber", DNnumber);

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_DNDate", DNDate.ToString("MM/dd/yyyy"));
            para.Add("@i_VendorID", VendorID.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_ServiceAmount", ServiceAmount.ToString());
            para.Add("@i_ExciseAmount", ExciseAmount.ToString());
            para.Add("@i_CessAmount", EduCessAmount.ToString());
            para.Add("@i_HCessAmount", HEduCessAmount.ToString());
            para.Add("@i_AmountAfterExcise", AmountAfterExcise.ToString());
            para.Add("@i_CSTAmount", CSTAmount.ToString());
            para.Add("@i_VATAmount", VATAmount.ToString());
            para.Add("@i_AVATAmount", AVATAmount.ToString());
            para.Add("@i_Discount", Discount.ToString());
            para.Add("@i_NetAmount", NetAmount.ToString());
            para.Add("@i_XMLString", XmlString);
            para.Add("@i_Cnt", Cnt.ToString());
            
            
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            //para.Add("@i_CC", CC.ToString());
            //para.Add("@i_BCC", BCC.ToString());
                
            para.Add("@i_TotalDiscAmt", Discount.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_remark", remark.ToString());
            para.Add("@i_Debitamount", DebitNoteamount.ToString());
            para.Add("@i_finalamount", finalamount.ToString());
            //para.Add("@i_GoDownID", GodownId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_DebitNote_Update", para, true, ref mException, ref mErrorMsg, "DebitNote - Update");

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


        //public void InsertSaleDocument(long SaleID, string DocName, string Remarks)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_SaleID", SaleID.ToString());
        //    para.Add("@i_DocName", DocName);
        //    para.Add("@i_Remarks", Remarks);
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_SaleDocList_Insert", para, false, ref mException, ref mErrorMsg, "Sale - Insert");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}

        //public void InsertTNC(string TNC_Sub, string TNC_Desc, string Code)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_TNC_Sub", TNC_Sub.ToString());
        //    para.Add("@i_TNC_Desc", TNC_Desc.ToString());
        //    para.Add("@i_Code", Code.ToString());
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_SalesTNC_Insert", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}

        //public void DeleteTNC(string TNC_Sub, string TNC_Desc, string Code)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_TNC_Sub", TNC_Sub.ToString());
        //    para.Add("@i_TNC_Desc", TNC_Desc.ToString());
        //    para.Add("@i_Code", Code.ToString());
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_SalesTNC_Delete", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}

        //public void DeleteTNC_On_Close(string TNC_Sub, string Code)
        //{
        //    SetDefaultException();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_TNC_Sub", TNC_Sub.ToString());
        //    para.Add("@i_Code", Code.ToString());
        //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        //    objDA.ExecuteSP("usp_SalesTNC_Delete_On_Close", para, false, ref mException, ref mErrorMsg, "Sales - Insert");
        //    if (mException == null)
        //    {
        //        if (mErrorMsg != "")
        //            this.ErrorMessage = mErrorMsg;
        //    }
        //    else
        //        this.Exception = mException;
        //}

    }
}
