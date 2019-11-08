using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class HRDetailBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public HRDetailBL()
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
        public void Insert(DateTime HrDate, long SiteID, string TypeOfLabour, decimal NoOfLabour, decimal AmountPerLabour, decimal TotalAmount, string Remarks)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_HrDate", String.Format("{0:MM/dd/yyyy}", HrDate));
            para.Add("@i_TypeOfLabour", TypeOfLabour);
            para.Add("@i_SiteID", SiteID.ToString());
            para.Add("@i_NoOfLabour", NoOfLabour.ToString());
            para.Add("@i_AmountPerLabour", AmountPerLabour.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_HrDetail_Insert", para, true, ref mException, ref mErrorMsg, "HRDetail - Insert");

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

        public void Update(long HRID, long SiteID, DateTime HrDate, string TypeOfLabour, decimal NoOfLabour, decimal AmountPerLabour, decimal TotalAmount, string Remarks)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_HRID", HRID.ToString());
            para.Add("@i_SiteID", SiteID.ToString());
            para.Add("@i_HrDate", String.Format("{0:MM/dd/yyyy}", HrDate));
            para.Add("@i_TypeOfLabour", TypeOfLabour);
            para.Add("@i_NoOfLabour", NoOfLabour.ToString());
            para.Add("@i_AmountPerLabour", AmountPerLabour.ToString());
            para.Add("@i_TotalAmount", TotalAmount.ToString());
            para.Add("@i_Remarks", Remarks);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_HrDetail_Update", para, true, ref mException, ref mErrorMsg, "HRDetail - Update");

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
