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
    class ContactPersonBL : BusinessBase
    {
         Exception mException = null;
        string mErrorMsg = "";

        public ContactPersonBL()
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
        public void Insert(int ContactType, string RefID, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());           
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_ContactDetail_Insert", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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

        public void InsertQContact(int ContactType, string RefID, String Code, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_QContactDetail_Insert", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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

        public void UpdateQContact(int ContactType, string RefID, String Code, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_QContactDetail_Update", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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

        public void InsertSContact(int ContactType, string RefID, String Code, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_SContactDetail_Insert", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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

        public void UpdateSContact(int ContactType, string RefID, String Code, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_SContactDetail_Update", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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

        public void InsertSEContact(int ContactType, string RefID, String Code, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_SEContactDetail_Insert", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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

        public void UpdateSEContact(int ContactType, string RefID, String Code, string ContactData, long Cnt)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            para.Add("@i_Code", Code.ToString());
            para.Add("@i_ContactType", ContactType.ToString());
            para.Add("@i_RefID", RefID.ToString());
            para.Add("@i_ContactData", ContactData);
            para.Add("@i_Cnt", Cnt.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_SEContactDetail_Update", para, true, ref mException, ref mErrorMsg, "ContactPerson - Insert");

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
