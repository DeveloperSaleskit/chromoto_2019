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
    class TypeOfCallBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public TypeOfCallBL()
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

        public void Insert(string ConType_name, string Desc)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Call_Name", ConType_name);
            para.Add("@i_Desc", Desc);

            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_TypeOfCall_Insert", para, true, ref mException, ref mErrorMsg, "TypeOfCall - Insert");

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

        public void Update(long ConTypeID, string ConType_name, string Desc)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CallID", ConTypeID.ToString());
            para.Add("@i_Call_Name", ConType_name);
            para.Add("@i_Desc", Desc);


            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_TypeOfCall_Update", para, true, ref mException, ref mErrorMsg, "TypeOfCall - Update");

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
