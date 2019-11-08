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
    class PromoMailSendBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public PromoMailSendBL()
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

        public void Insert(string PCustomerName, string PMail, string PCategory, string PMobile, string Subject, string Header, string Footer, string FileCount,int CompId)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_PCustomerName",PCustomerName);
            para.Add("@i_PMail", PMail);
            para.Add("@i_PCategory", PCategory);
            para.Add("@i_PMobile", PMobile);
            para.Add("@i_Subject", Subject);
            para.Add("@i_Header", Header);
            para.Add("@i_Footer", Footer);
            para.Add("@i_FileCount", FileCount);
            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId",CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PromoMail_Insert", para, true, ref mException, ref mErrorMsg, "PromoMail - Insert");

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

        public void Update(long PromoMail_ID, string PCustomerName, string PMail, string PCategory, string PMobile, string Subject, string Header, string Footer,string FileCount,int CompId)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_PromoMail_ID", PromoMail_ID.ToString());
            para.Add("@i_PCustomerName", PCustomerName);
            para.Add("@i_PMail", PMail);
            para.Add("@i_PCategory", PCategory);
            para.Add("@i_PMobile", PMobile);
            para.Add("@i_Subject", Subject);
            para.Add("@i_Header", Header);
            para.Add("@i_Footer", Footer);
            para.Add("@i_FileCount", FileCount);
            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PromoMail_Update", para, true, ref mException, ref mErrorMsg, "PromoMail - Update");

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


        public void Update_Email_Detail(string Con_Email, string Con_Password, string Con_Host, string Con_Port, string Con_SSL)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Con_Email", Con_Email.ToString());
            para.Add("@i_Con_Password", Con_Password);
            para.Add("@i_Con_Host", Con_Host);
            para.Add("@i_Con_Port", Con_Port);
            para.Add("@i_Con_SSL", Con_SSL);
            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Email_Detail_Update", para, false, ref mException, ref mErrorMsg, "Email - Update");

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

        public void InsertPMDocument(long PromoMail_ID, string DocName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_PromoMailID", PromoMail_ID.ToString());
            para.Add("@i_DocName", DocName);
            //para.Add("@i_Remarks", Remarks);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_PromoMailDocList_Insert", para, false, ref mException, ref mErrorMsg, "PromoMail - Insert");
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
