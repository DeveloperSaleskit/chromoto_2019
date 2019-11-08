using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using Account.DataAccess;

namespace Account.BusinessLogic
{
    class CommonListBL : BusinessBase
    {

        Exception mException = null;
        string mErrorMsg = "";

        public CommonListBL()
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
        public DataTable ListOfRecord(string SPName, NameValueCollection Paralist, string mModuleName)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            DataTable dt = new DataTable();
            dt = null;
            if (Paralist != null)
            {
                dt = objDA.ExecuteDataTableSP(SPName, Paralist, false, ref mException, ref mErrorMsg, mModuleName);
            }
            else
            {
                dt = objDA.ExecuteDataTableSP(SPName, null, false, ref mException, ref mErrorMsg, mModuleName);
            }
            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return dt;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return dt;
        }

        public DataSet ListOfDataSetRecord(string SPName, string mModuleName)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            DataSet ds = new DataSet();
            ds = null;
            ds = objDA.ExecuteDataSetSP(SPName, null, false, ref mException, ref mErrorMsg, mModuleName);
            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return ds;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return ds;
        }

        public DataSet ListOfDataSetRecordwithPara(string SPName,NameValueCollection para,string mModuleName)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            DataSet ds = new DataSet();
            ds = null;
            ds = objDA.ExecuteDataSetSP(SPName, para, false, ref mException, ref mErrorMsg, mModuleName);
            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return ds;
                }
                else
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = mException;
            }
            return ds;
        }
    }
}
