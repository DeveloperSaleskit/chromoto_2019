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
    class TaxClassBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public TaxClassBL()
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
        public void Insert(string TaxClass, DateTime FromDate, decimal Excise, decimal VAT, decimal ServiceTax, decimal EduCess, decimal HEduCess, decimal CST, decimal AVAT, decimal SBCess, string ExtraTaxType, decimal ExtraTax)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TaxClass", TaxClass);
            para.Add("@i_FromDate", FromDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Excise", Excise.ToString());
            para.Add("@i_VAT", VAT.ToString());
            para.Add("@i_ServiceTax", ServiceTax.ToString());
            para.Add("@i_EduCess", EduCess.ToString());
            para.Add("@i_HEduCess", HEduCess.ToString());
            para.Add("@i_CST", CST.ToString());
            para.Add("@i_AVAT", AVAT.ToString());
            para.Add("@i_SBCess", SBCess.ToString());
            para.Add("@i_ExtraTaxType", ExtraTaxType);
            para.Add("@i_ExtraTax", ExtraTax.ToString());
            para.Add("@i_CreatedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());



            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_TaxClass_Insert", para, true, ref mException, ref mErrorMsg," Tax Class - Insert");

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

        public void Update(long TaxClassID, string TaxClass, DateTime FromDate, decimal Excise, decimal VAT, decimal ServiceTax, decimal EduCess, decimal HEduCess, decimal CST, decimal AVAT, decimal SBCess, string ExtraTaxType, decimal ExtraTax)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TaxClassID", TaxClassID.ToString());
            para.Add("@i_TaxClass", TaxClass);
            para.Add("@i_FromDate", FromDate.ToString("MM/dd/yyyy"));
            para.Add("@i_Excise", Excise.ToString());
            para.Add("@i_VAT", VAT.ToString());
            para.Add("@i_ServiceTax", ServiceTax.ToString());
            para.Add("@i_EduCess", EduCess.ToString());
            para.Add("@i_HEduCess", HEduCess.ToString());
            para.Add("@i_CST", CST.ToString());
            para.Add("@i_AVAT", AVAT.ToString());
            para.Add("@i_SBCess", SBCess.ToString());
            para.Add("@i_ExtraTaxType", ExtraTaxType);
            para.Add("@i_ExtraTax", ExtraTax.ToString());
            para.Add("@i_ModifiedBy", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteSP("usp_TaxClass_Update", para, true, ref mException, ref mErrorMsg,"Tax Class - Update");

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
