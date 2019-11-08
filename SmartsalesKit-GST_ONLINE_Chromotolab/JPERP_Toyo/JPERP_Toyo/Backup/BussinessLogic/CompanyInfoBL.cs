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
    class CompanyInfoBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public CompanyInfoBL()
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
        public void Insert_CompanyInfo_Detail(string CompanyName, string BusinessLine, string Address1, string Address2, string State, string City,
           string Pincode, string Phone1, string Phone2, string Mobile, string Email, string Logo, string Header, string Footer, string Sign, string Name1,
           string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4,
           string Value5, string Value6, string Com_Profile, string RPath, string DPath)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CompanyName", CompanyName.ToString());
            para.Add("@i_BusinessLine", BusinessLine);
            para.Add("@i_Address1", Address1);
            para.Add("@i_Address2", Address2);
            para.Add("@i_State", State);
            para.Add("@i_CityName", City);
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_Phone2", Phone2);
            para.Add("@i_Mobile", Mobile);
            para.Add("@i_Email", Email);
            para.Add("@i_Logo", Logo);
            para.Add("@i_Header", Header);
            para.Add("@i_Footer", Footer);
            para.Add("@i_Sign", Sign);
            para.Add("@i_Name1", Name1);
            para.Add("@i_Name2", Name2);
            para.Add("@i_Name3", Name3);
            para.Add("@i_Name4", Name4);
            para.Add("@i_Name5", Name5);
            para.Add("@i_Name6", Name6);
            para.Add("@i_Value1", Value1);
            para.Add("@i_Value2", Value2);
            para.Add("@i_Value3", Value3);
            para.Add("@i_Value4", Value4);
            para.Add("@i_Value5", Value5);
            para.Add("@i_Value6", Value6);
            para.Add("@i_Com_Profile", Com_Profile);
            para.Add("@i_ReportPath", RPath);
            para.Add("@i_DocPath", DPath);

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_CompanyInfo_Insert", para, true, ref mException, ref mErrorMsg, "CompanyInfo - Update");

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

        public void Update_CompanyInfo_Detail(long CompId,string CompanyName, string BusinessLine, string Address1, string Address2, string State, string City,
            string Pincode, string Phone1, string Phone2, string Mobile, string Email, string Logo, string Header, string Footer,string Sign, string Name1,
            string Name2, string Name3, string Name4, string Name5, string Name6, string Value1, string Value2, string Value3, string Value4,
            string Value5, string Value6, string Com_Profile, string RPath, string DPath)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CompId", CompId.ToString());
            para.Add("@i_CompanyName", CompanyName.ToString());
            para.Add("@i_BusinessLine", BusinessLine);
            para.Add("@i_Address1", Address1);
            para.Add("@i_Address2", Address2);
            para.Add("@i_State", State);
            para.Add("@i_City", City);
            para.Add("@i_Pincode", Pincode);
            para.Add("@i_Phone1", Phone1);
            para.Add("@i_Phone2", Phone2);
            para.Add("@i_Mobile", Mobile);
            para.Add("@i_Email", Email);
            para.Add("@i_Logo", Logo);
            para.Add("@i_Header", Header);
            para.Add("@i_Footer", Footer);
            para.Add("@i_Sign", Sign);
            para.Add("@i_Name1", Name1);
            para.Add("@i_Name2", Name2);
            para.Add("@i_Name3", Name3);
            para.Add("@i_Name4", Name4);
            para.Add("@i_Name5", Name5);
            para.Add("@i_Name6", Name6);
            para.Add("@i_Value1", Value1);
            para.Add("@i_Value2", Value2);
            para.Add("@i_Value3", Value3);
            para.Add("@i_Value4", Value4);
            para.Add("@i_Value5", Value5);
            para.Add("@i_Value6", Value6);
            para.Add("@i_CProfile", Com_Profile);
            para.Add("@i_ReportPath", RPath);
            para.Add("@i_DocPath", DPath);

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_CompanyInfo_Detail_Update", para, false, ref mException, ref mErrorMsg, "CompanyInfo - Update");

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
