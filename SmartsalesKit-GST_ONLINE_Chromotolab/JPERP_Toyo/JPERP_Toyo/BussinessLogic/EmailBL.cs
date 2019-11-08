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
    class EmailBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public EmailBL()
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

        public void Insert(string Type, string Subject, string Header, string Footer, int CompId)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Type", Type);
            para.Add("@i_Subject", Subject);
            para.Add("@i_Header", Header);
            para.Add("@i_Footer", Footer);
            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Email_Insert", para, true, ref mException, ref mErrorMsg, "Godown - Insert");

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

        public void Update(long Email_ID, string Type, string Subject, string Header, string Footer, int CompId)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Email_ID", Email_ID.ToString());
            para.Add("@i_Type", Type);
            para.Add("@i_Subject", Subject);
            para.Add("@i_Header", Header);
            para.Add("@i_Footer", Footer);

            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Email_Update", para, true, ref mException, ref mErrorMsg, "Godown - Update");

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


        public void Update_Email_Detail(string Con_Email, string Con_Password, string Con_Host, string Con_Port, string Con_SSL,int CompId)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Con_Email", Con_Email.ToString());
            para.Add("@i_Con_Password", Con_Password);
            para.Add("@i_Con_Host",Con_Host );
            para.Add("@i_Con_Port",Con_Port);
            para.Add("@i_Con_SSL", Con_SSL);
            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId",CurrentCompany.CompId.ToString());

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




    }
}
