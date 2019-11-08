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
    class GodownBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public GodownBL()
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

        public void Insert(string Godown_name, string Godown_addr, Int32 CityID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Godown_name", Godown_name);
            para.Add("@i_Godown_addr", Godown_addr);
            para.Add("@i_CityID", CityID.ToString());
            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());



            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Godown_Insert", para, true, ref mException, ref mErrorMsg, "Godown - Insert");

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

        public void Update(long GodownID, string Godown_name, string Godown_addr, Int32 CityID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_Godown_name", Godown_name);
            para.Add("@i_Godown_addr", Godown_addr);
            para.Add("@i_CityID", CityID.ToString());

            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Godown_Update", para, true, ref mException, ref mErrorMsg, "Godown - Update");

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
