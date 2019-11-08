using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using Account.DataAccess;

namespace Account.BusinessLogic
{
    class CommonSelectBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public CommonSelectBL()
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
        public DataTable SelectRecord(long RecID, string SPName, string mModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataTable dt = new DataTable();
            dt = null;
            dt = objDA.ExecuteDataTableSP(SPName, para, false, ref mException, ref mErrorMsg, mModuleName);

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

        public DataSet SelectDataSetRecord(long RecID, string SPName, string mModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());
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

        public DataSet SelectDataSetRecord(NameValueCollection ParaList, string SPName, string mModuleName)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataSet ds = new DataSet();
            ds = null;
            ds = objDA.ExecuteDataSetSP(SPName, ParaList, false, ref mException, ref mErrorMsg, mModuleName);

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
