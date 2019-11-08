using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Account.Common;

namespace Account.BusinessLogic
{
    class UOMBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public UOMBL()
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

        public void Insert(string UOMName,string Abbreviation)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();
            
            para.Add("@i_UOMName", UOMName);
            para.Add("@i_Abbr", Abbreviation);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_UOM_Insert", para, true, ref mException, ref mErrorMsg, "UOMBL - Insert");
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

        public void Update(long UOMID, string UOMName, string Abbreviation)
        {
            SetDefaultException();

            NameValueCollection para = new NameValueCollection();

            para.Add("@i_UOMID", UOMID.ToString());
            para.Add("@i_UOMName",UOMName );
            para.Add("@i_Abbr", Abbreviation);
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_UOM_Update", para, true, ref mException, ref mErrorMsg, "UOMBL - Upadte");

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
