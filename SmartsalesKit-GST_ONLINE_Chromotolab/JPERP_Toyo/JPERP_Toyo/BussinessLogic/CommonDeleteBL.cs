using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using Account.DataAccess;

namespace Account.BusinessLogic
{
    class CommonDeleteBL:BusinessBase
    {
         Exception mException = null;
        string mErrorMsg = "";

        public CommonDeleteBL()
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
        public void DeleteRecord(long RecID, string SPName,string mModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteDeleteSP(SPName, para, true, ref mException, ref mErrorMsg, mModuleName);

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = null;
                this.ErrorMessage = PrepareMsg(mException,mModuleName);

            }
        }

        public void DeleteRecordWithBank(long RecID, string BankName, string SPName, string mModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());
            para.Add("@i_BankName", BankName);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteDeleteSP(SPName, para, true, ref mException, ref mErrorMsg, mModuleName);

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = null;
                this.ErrorMessage = PrepareMsg(mException, mModuleName);

            }
        }

        public string PrepareMsg(Exception Ex,string mModuleName)
        {
            string FinalMsg="";
            string str;
            string ExeMsg = Ex.Message;
            string[] SplitStr;
            string[] Msg;
            if (ExeMsg.StartsWith("The DELETE statement conflicted with the REFERENCE"))
            {
                if (Ex.ToString().IndexOf("FK_") > 0)
                {
                    str = Ex.ToString().Substring(Ex.ToString().IndexOf("FK_"), Ex.ToString().Length - Ex.ToString().IndexOf("FK_"));
                    SplitStr = str.Split('.');

                    str = SplitStr[0];
                    str = str.Substring(0, str.Length - 1);

                    Msg = str.Split('_');

                    FinalMsg = Msg[2].Replace('-', ' ') + " is associated with " + Msg[1].Replace('-', ' ');
                    FinalMsg =FinalMsg.Substring(0, 1) + FinalMsg.Substring(1,FinalMsg.Length -1).ToLower ();
                }
            }
            else
            {
                BusinessLogic.Common ObjComm = new Account.BusinessLogic.Common();
                ObjComm.WriteExceptionLog(DateTime.Now, ExeMsg, mModuleName);
            }
            return FinalMsg;            
        }

        public void DeleteRecordWithGodown(long RecID, string SPName, string mModuleName, Int16 GodownID)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());
            para.Add("@i_GodownID", GodownID.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteDeleteSP(SPName, para, true, ref mException, ref mErrorMsg, mModuleName);

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = null;
                this.ErrorMessage = PrepareMsg(mException, mModuleName);

            }
        }

        public void DeleteRecordWithGodowNBank(long RecID, string SPName, string mModuleName, Int16 GodownID,string BankName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_RecID", RecID.ToString());
            para.Add("@i_GodownID", GodownID.ToString());
            para.Add("@i_BankName", BankName);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            objDA.ExecuteDeleteSP(SPName, para, true, ref mException, ref mErrorMsg, mModuleName);

            if (mException == null)
            {
                if (mErrorMsg != "")
                {
                    this.ErrorMessage = mErrorMsg;
                }
            }
            else
            {
                this.Exception = null;
                this.ErrorMessage = PrepareMsg(mException, mModuleName);

            }
        }
    }
}
