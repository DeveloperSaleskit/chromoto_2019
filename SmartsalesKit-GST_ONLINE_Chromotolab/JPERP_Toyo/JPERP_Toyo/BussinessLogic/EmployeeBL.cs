using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.Specialized;
using Account.DataAccess;
using Account.Common;

namespace Account.BusinessLogic
{
    class EmployeeBL : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";

        public EmployeeBL()
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

        public void Insert(string EmpName, string Address, string PhoneNo, string Email, string Department, decimal Salary)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();


            para.Add("@i_EmpName", EmpName.ToString());
            para.Add("@i_Address", Address.ToString());
            para.Add("@i_PhoneNo", PhoneNo.ToString());
            para.Add("@i_Email", Email.ToString());
            para.Add("@i_Department", Department.ToString());
            para.Add("@i_Salary", Salary.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompanyID", CurrentCompany.CompId.ToString());
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Employee_Insert", para, true, ref mException, ref mErrorMsg, "Employee - Insert");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;
        }

        public void Update(long EmpId, string EmpName, string Address, string PhoneNo, string Email, string Department, decimal Salary)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();


            para.Add("@i_EmpId", EmpId.ToString());
            para.Add("@i_EmpName", EmpName);
            para.Add("@i_Address", Address);
            para.Add("@i_PhoneNo", PhoneNo);
            para.Add("@i_Email", Email);
            para.Add("@i_Department", Department);
            para.Add("@i_Salary", Salary.ToString());
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompanyID", CurrentCompany.CompId.ToString());

            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            objDA.ExecuteSP("usp_Employee_Update", para, true, ref mException, ref mErrorMsg, "Employee - Update");
            if (mException == null)
            {
                if (mErrorMsg != "")
                    this.ErrorMessage = mErrorMsg;
            }
            else
                this.Exception = mException;

        }
    }
}
