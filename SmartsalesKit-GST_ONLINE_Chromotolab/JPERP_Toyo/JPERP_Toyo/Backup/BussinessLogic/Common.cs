using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Specialized;
using Account.DataAccess;
using System.Windows.Forms;
using Account.Common;

namespace Account.BusinessLogic
{
    class Common : BusinessBase
    {
        Exception mException = null;
        string mErrorMsg = "";
        CommonListBL CommList = new CommonListBL();

        int _CompId = CurrentCompany.CompId;

        public Common()
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

        public void WriteExceptionLog(DateTime CurDate, string ErrMsg, string mModuleName)
        {
            SetDefaultException();
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            NameValueCollection paraList = new NameValueCollection();
            paraList.Add("@i_Date", CurDate.ToString("MM/dd/yyyy"));
            paraList.Add("@i_ErrorMsg", ErrMsg);
            paraList.Add("@i_Module", mModuleName);
            paraList.Add("@i_UserID", CurrentUser.UserID.ToString());
            if (mModuleName != "Common - WriteExceptionLog")
            {
                objDA.ExecuteSP("ExceptionLog_Insert", paraList, false, ref mException, ref mErrorMsg, "Common - WriteExceptionLog");
            }
            if (mException != null)
            {
                this.Exception = mException;
            }
        }

        public static DataTable ReadEnum(System.Type EnumType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("Value", typeof(int));
            int count = 0;
            string[] sText = Enum.GetNames(EnumType);
            foreach (string s in sText)
            {
                DataRow dr = dt.NewRow();
                dr["Text"] = s;
                dt.Rows.Add(dr);
            }
            foreach (int i in Enum.GetValues(EnumType))
            {
                dt.Rows[count]["Value"] = i;
                count = (count + 1);
            }
            return dt;
        }

        //Get Auto Number 
        public string AutoNumber(string ModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            string YearCode = CurrentUser.FYStartDate.ToString("yy") + '-' + CurrentUser.FYEndDate.ToString("yy");

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_YearCode", YearCode);
            para.Add("@i_Module", ModuleName);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataTable dt = new DataTable();
            dt = objDA.ExecuteDataTableSP("usp_Automatic_Number", para, false, ref mException, ref mErrorMsg, "Common - AutoNumber");

            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return dt.Rows[0][0].ToString();
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
            return "";
        }

        public string AutoNumberID(string ModuleName)
        {
            SetDefaultException();
            NameValueCollection para = new NameValueCollection();

            string YearCode = CurrentUser.FYStartDate.ToString("yy") + '-' + CurrentUser.FYEndDate.ToString("yy");

            para.Add("@i_FYID", CurrentUser.FYID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_YearCode", YearCode);
            para.Add("@i_Module", ModuleName);
            DataAccess.DataAccess objDA = new DataAccess.DataAccess();

            DataTable dt = new DataTable();
            dt = objDA.ExecuteDataTableSP("usp_Automatic_Number_ID", para, false, ref mException, ref mErrorMsg, "Common - AutoNumber");

            if (mException == null)
            {
                if (mErrorMsg == "")
                {
                    return dt.Rows[0][0].ToString();
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
            return "";
        }

        public void FillSourceOfLeadCombo(ComboBox cmb)
        {
            DataTable dtLead = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtLead = CommList.ListOfRecord("usp_SourceOfLead_DDL", para, "Common - FillSourceOfLeadCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtLead.NewRow();
                dr["SourceOfLead"] = "";
                dtLead.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtLead;
                cmb.DisplayMember = "SourceOfLead";
            }
        }

        public void FillVendorCategCombo(ComboBox cmb)
        {
            DataTable dtLead = new DataTable();


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtLead = CommList.ListOfRecord("usp_Vendor_category", para, "Common - FillVendorCategCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtLead.NewRow();
                dr["category"] = "";
                dtLead.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtLead;
                cmb.DisplayMember = "category";
            }
        }



        public void FillSourceOfREASONCombo(ComboBox cmb)
        {
            DataTable dtREASON = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtREASON = CommList.ListOfRecord("usp_MaterialIssue_Reason", para, "Common - FillSourceOfREASONCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtREASON.NewRow();
                dr["reason"] = "";
                dtREASON.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtREASON;
                cmb.DisplayMember = "reason";
            }
        }









        public void FillInqResponse(ComboBox cmb)
        {
            DataTable dtLead = new DataTable();


           

            dtLead = CommList.ListOfRecord("usp_InqResponse_DDL", null, "Common - FillInqResponseCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtLead.NewRow();
                dr["InqResponse"] = "";
                dtLead.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtLead;
                cmb.DisplayMember = "InqResponse";
            }
        }

        public void FillBankCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            dtCity = CommList.ListOfRecord("usp_Bank_DDL", para, "Common - FillBankCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["BankID"] = 0;
                dr["BankName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "BankName";
                cmb.ValueMember = "BankID";
            }
        }

        public void FillCompanyCombo(ComboBox cmb)
        {

            DataTable dtComp = new DataTable();

            

            dtComp = CommList.ListOfRecord("usp_Company_DDL", null, "Common - FillCompanyCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtComp.NewRow();
                dr["CompanyID"] = 0;
                dr["CompanyName"] = "--Select--";
                dtComp.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtComp;
                cmb.DisplayMember = "CompanyName";
                cmb.ValueMember = "CompanyID";
            }
        }

        public void FillCategoryCombo(ComboBox cmb)
        {
            DataTable dtLead = new DataTable();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            dtLead = CommList.ListOfRecord("usp_Category_DDL", para, "Common - FillCategoryCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtLead.NewRow();
                dr["Category"] = "";
                dtLead.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtLead;
                cmb.DisplayMember = "Category";
            }
        }

        public void FillTypeofcallCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();



            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtCity = CommList.ListOfRecord("usp_TypeOfCall_List", para, "Common - FillCityCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["CallID"] = 0;
                dr["Call_Name"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "Call_Name";
                cmb.ValueMember = "CallID";
            }
        }

        public void FillEmployeeCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtCity = CommList.ListOfRecord("usp_Employee_DDL", para, "Common - FillEmployeeCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["EmpID"] = 0;
                dr["EmpName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "EmpName";
                cmb.ValueMember = "EmpID";
            }
        }

        public void FillEmpAllocatedToCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            dtCity = CommList.ListOfRecord("usp_Employee_DDL", para, "Common - FillEmpAllocatedToCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["EmpID"] = 0;
                dr["EmpName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "EmpName";
                cmb.ValueMember = "EmpID";
            }
        }
        public void FillUserInfoCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            dtCity = CommList.ListOfRecord("usp_UserList_DDL", para, "Common - FillUserInfoCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["UserID"] = 0;
                dr["UserName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "UserName";
                cmb.ValueMember = "UserID";
            }
        }

        public void FillLeadStatusCombo(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();

            


            dtDataType = CommList.ListOfRecord("usp_LeadStatus_DDL", null, "FillLeadStatusCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["LeadStatusID"] = 0;
                dr["Status"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Status";
                cmb.ValueMember = "LeadStatusID";
            }
        }

        public void FillLead(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            NameValueCollection para1 = new NameValueCollection();
            //int _CompId = 0;
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para1.Add("@i_UserID", CurrentUser.UserID.ToString());


            dtDataType = CommList.ListOfRecord("usp_Lead_List", para1, "FillLead");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["LeadId"] = 0;
                dr["LeadName"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "LeadName";
                cmb.ValueMember = "LeadId";
            }
        }



        public void FillCourierNameDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_DocumentInward_CmbCourierName", null, "FillDDLCourierList");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["CourierName"] = 0;
                dr["CourierName"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "CourierName";
                cmb.ValueMember = "CourierName";
            }
        }


        public void FillHostCombo(ComboBox cmb)
        {
            cmb.Items.Add("smtp.gmail.com");
            cmb.Items.Add("smtp.mail.yahoo.com");
        }

        public void FillDepartmentCombo(ComboBox cmb)
        {
            DataTable dtDept = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            dtDept = CommList.ListOfRecord("usp_EmpDepartment_DDL", para, "Common - FillDepartmentCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDept.NewRow();
                dr["Department"] = "";
                dtDept.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDept;
                cmb.DisplayMember = "Department";
            }
        }

        public DataTable GetItemList()
        {
            DataTable dtblItem = new DataTable();
            CommonListBL objList = new CommonListBL();

            dtblItem = objList.ListOfRecord("usp_Item_DDL", null, "Item - LoadDDlList");
            if (objList.Exception != null)
            {
                MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return dtblItem;
        }

        public void FillFinancialYearCombo(ComboBox cmb)
        {
            DataTable dtFY = new DataTable();
            dtFY = CommList.ListOfRecord("usp_FYYear_DDL", null, "Common - FillFinancialYearCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtFY.NewRow();
                dr["FYID"] = 0;
                dr["FYYears"] = "--Select--";
                dtFY.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtFY;
                cmb.DisplayMember = "FYYears";
                cmb.ValueMember = "FYID";
            }
        }

        public void FillItemCategoryDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();

            dtDataType = CommList.ListOfRecord("usp_ItemCategory_DDL", null, "FillItemCategoryDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["CategoryID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "CategoryID";
            }
        }

        public void FillUOMDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtDataType = CommList.ListOfRecord("usp_UOM_DDL", para, "FillUOMDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["UOMID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "UOMID";
            }
        }

        public void FillItemClassDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();

            dtDataType = CommList.ListOfRecord("usp_ItemClass_DDL", null, "FillItemClassDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["ItemClassID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "ItemClassID";
            }
        }

        public void FillMachineCategoryDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_MachineCategory_DDL", null, "Common - FillMachineCategoryDDL");

            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["MachineCategoryID"] = 0;
                dr["CategoryName"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "CategoryName";
                cmb.ValueMember = "MachineCategoryID";
            }
        }

        public void FillAreaCombo(ComboBox cmb, int CityID)
        {
            //DataTable dtArea = new DataTable();
            DataSet dtArea = new DataSet();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CityID", CityID.ToString());
            dtArea = CommList.ListOfDataSetRecordwithPara("usp_Area_List", para, "Common - FillAreaCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtArea.Tables[0].NewRow();
                dr["AreaID"] = 0;
                dr["AreaName"] = "--Select--";
                dtArea.Tables[0].Rows.InsertAt(dr, 0);
                cmb.DataSource = dtArea.Tables[0];
                cmb.DisplayMember = "AreaName";
                cmb.ValueMember = "AreaID";
            }
        }

        public void FillCityCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtCity = CommList.ListOfRecord("usp_City_DDL", para, "Common - FillCityCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["CityID"] = 0;
                dr["CityName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "CityName";
                cmb.ValueMember = "CityID";
            }
        }

        public void FillStateCombo(ComboBox cmb)
        {
            DataTable dtState = new DataTable();
            dtState = CommList.ListOfRecord("usp_State_DDL", null, "Common - FillStateCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtState.NewRow();
                dr["StateID"] = 0;
                dr["StateName"] = "--Select--";
                dtState.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtState;
                cmb.DisplayMember = "StateName";
                cmb.ValueMember = "StateID";
            }
        }

        public void FillCountryCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();
            dtCity = CommList.ListOfRecord("usp_Country_DDL", null, "Common - FillCountryCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["CountryID"] = 0;
                dr["Name"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "CountryID";
            }
        }

        public void FillItemGroupDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();

            dtDataType = CommList.ListOfRecord("usp_ItemGroup_DDL", null, "FillItemGroupDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["ItemGroupID"] = 0;
                dr["ItemGroupName"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "ItemGroupName";
                cmb.ValueMember = "ItemGroupID";
            }
        }

        public void FillPriorityCombo(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt = ReadEnum(typeof(Constant.PRNPriority));
            DataRow dr;
            dr = dt.NewRow();
            dr["Text"] = "--Select--";
            dt.Rows.InsertAt(dr, 0);
            cmb.DataSource = dt;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";

        }

        public DataTable GetCityList()
        {
            DataTable dtblCity = new DataTable();
            CommonListBL objList = new CommonListBL();

            dtblCity = objList.ListOfRecord("usp_City_DDL", null, "City - LoadDDlList");
            if (objList.Exception != null)
            {
                MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return dtblCity;
        }



        public void FillRecievedDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_DocumentInward_CmbListRecieved", null, "FillDDLRecievedList");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["ReceivedFrom"] = 0;
                dr["ReceivedFrom"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "ReceivedFrom";
                cmb.ValueMember = "ReceivedFrom";
            }
        }

        public void FillSendToDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_DocumentInward_CmbListSendTo", null, "FillDDLSendToList");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["SendTo"] = 0;
                dr["SendTo"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "SendTo";
                cmb.ValueMember = "SendTo";
            }
        }

        public void FillStatusDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_PRNStatus_DDL", null, "FillStatusDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["StatusID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "StatusID";
            }
        }

        public void FillQuotationStatusDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_QuotationStatus_DDL", null, "FillQuotationStatusDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["StatusID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "StatusID";
            }
        }

        public void FillInquiryStatusDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_CustomerInquiryStatus_DDL", null, "FillInquiryStatusDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["StatusID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "StatusID";
            }
        }

        public void FillDocumentStatus(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt = ReadEnum(typeof(Constant.DocumentStatus));
            cmb.DataSource = dt;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";
        }

        public void FillLowStockDDL(ComboBox cmb)
        {
            cmb.Items.Add("--Select--");
            cmb.Items.Add("Current Stock Below Min. Level");
            cmb.Items.Add("Min. Level = 0");
            cmb.Items.Add("Max. Level = 0");
            cmb.Items.Add("Reorder Level = 0");
            cmb.Items.Add("Location not defined");
            cmb.SelectedIndex = 0;
        }

        public void FillPOStatusDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            dtDataType = CommList.ListOfRecord("usp_PurchaseInvoiceStatus_DDL", null, "FillPOStatusDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["StatusID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "StatusID";
            }
        }

        public void FillTaxClassCombo(ComboBox cmb)
        {
            DataTable dtTaxClass = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());


            dtTaxClass = CommList.ListOfRecord("usp_TaxClass_DDL", para, "Common - FillTaxClassCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtTaxClass.NewRow();
                dr["TaxClassID"] = 0;
                dr["TaxClass"] = "--Select--";
                dtTaxClass.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtTaxClass;
                cmb.DisplayMember = "TaxClass";
                cmb.ValueMember = "TaxClassID";
            }
        }

        //public void FillTNCSubCombo(ComboBox cmb , string TNC_Sub)
        //{
        //    DataTable dtTNCSub = new DataTable();
        //    NameValueCollection para = new NameValueCollection();
        //    //para.Add("@i_TNC_Sub", TNC_Sub);

        //    dtTNCSub = CommList.ListOfRecord("usp_TNCSub_DDL", para, "Common - FillTNCSubjectCombo");
        //    if (CommList.Exception != null)
        //    {
        //        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        DataRow dr;
        //        dr = dtTNCSub.NewRow();
        //        //dr["TaxClassID"] = 0;
        //      //  dr["TNC_Sub"] = "--Select--";
        //      //  dtTNCSub.Rows.InsertAt(dr, 0);
        //        cmb.DataSource = dtTNCSub;
        //        cmb.DisplayMember = "TNC_Sub";
        //        //cmb.ValueMember = "TaxClassID";
        //    }
        //}
        public void FillTNCSubCombo(ComboBox cmb)
        {
            DataTable dtTNCSub = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtTNCSub = CommList.ListOfRecord("usp_TNCSub_DDL", para, "Common - FillTNCSubjectCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtTNCSub.NewRow();
                //dr["TaxClassID"] = 0;
                dr["TNC_Sub"] = "--Select--";
                dtTNCSub.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtTNCSub;
                cmb.DisplayMember = "TNC_Sub";
                //cmb.ValueMember = "TaxClassID";
            }
        }


        public void FillTransportDDL(ComboBox cmb)
        {
            DataTable dtDataType = new DataTable();
            NameValueCollection para = new NameValueCollection();

            dtDataType = CommList.ListOfRecord("usp_Transport_DDL", null, "FillTransportDDL");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtDataType.NewRow();
                dr["TransportID"] = 0;
                dr["Name"] = "--Select--";
                dtDataType.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtDataType;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "TransportID";
            }
        }

        public void FillFollowUpMode(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt = ReadEnum(typeof(Constant.FollowUpMode));
            cmb.DataSource = dt;
            cmb.DisplayMember = "Text";
            cmb.ValueMember = "Value";
        }

        public void FillCustomerCombo(ComboBox cmb)
        {
            DataTable dtCustomber = new DataTable();
            dtCustomber = CommList.ListOfRecord("usp_Customer_DDL", null, "Common - FillCustomerCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCustomber.NewRow();
                dr["CustomerID"] = 0;
                dr["CustomerName"] = "--Select--";
                dtCustomber.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCustomber;
                cmb.DisplayMember = "CustomerName";
                cmb.ValueMember = "CustomerID";
            }
        }


        public void FillGodownCombo(ComboBox cmb)
        {
            DataTable dtgodown = new DataTable();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtgodown = CommList.ListOfRecord("usp_Godown_DDL", para, "Common - FillGodownCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtgodown.NewRow();
                dr["GodownID"] = 0;
                dr["Godown_name"] = "--Select--";
                dtgodown.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtgodown;
                cmb.DisplayMember = "Godown_name";
                cmb.ValueMember = "GodownID";
            }
        }

        public void FillItemCombo(ComboBox cmb)
        {
            DataTable dtgodown = new DataTable();
            dtgodown = CommList.ListOfRecord("usp_Item_DDL", null, "Common - FillItemCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtgodown.NewRow();
                dr["ItemID"] = 0;
                dr["Name"] = "--Select--";
                dtgodown.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtgodown;
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "ItemID";
            }
        }


        public void FillJobWorkerCombo(ComboBox cmb)
        {
            DataTable dtWeaver = new DataTable();
            dtWeaver = CommList.ListOfRecord("usp_Jobworker_DDL", null, "Common - FillJobworkerCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtWeaver.NewRow();
                dr["JobworkerID"] = 0;
                dr["JobworkerName"] = "--Select--";
                dtWeaver.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtWeaver;
                cmb.DisplayMember = "JobworkerName";
                cmb.ValueMember = "JobworkerID";
            }

        }

        public void FillCurrencyCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();

            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtCity = CommList.ListOfRecord("usp_Currency_DDL", para, "Common - FillCityCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["CurrencyID"] = 0;
                dr["Currency"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "Currency";
                cmb.ValueMember = "CurrencyID";
            }
        }

    }
}
