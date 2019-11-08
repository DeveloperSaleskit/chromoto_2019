using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;
using Account.BusinessLogic;
using Account.DataAccess;
using Account.Common;

namespace Utill.Common
{
    class ExceptionLogger 
    {

        public static void writeException(String module, String mesg)
        {

            Exception mException = null;
            string mErrorMsg = "";

            DataAccess objDA = new DataAccess();
            NameValueCollection paraList = new NameValueCollection();
            paraList.Add("@i_Date",DateTime.Now.ToString("MM/dd/yyyy"));
            paraList.Add("@i_ErrorMsg", mesg);
            paraList.Add("@i_Module", module);
            paraList.Add("@i_UserID", CurrentUser.UserID.ToString());
            if (module != "ExceptionLogger - WriteExceptionLog")
            {
                objDA.ExecuteSP("ExceptionLog_Insert", paraList, false, ref mException, ref mErrorMsg, "ExceptionLogger - WriteExceptionLog");
            }
             
        }

    }
}
