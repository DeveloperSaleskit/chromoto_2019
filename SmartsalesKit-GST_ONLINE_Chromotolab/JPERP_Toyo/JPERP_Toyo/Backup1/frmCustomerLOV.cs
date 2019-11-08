using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
//using Account.GUI.Customer;

namespace Account
{
    public partial class frmCustomerLOV : Account.GUIBase
    {
        #region "Variable Declarations..."

        DataTable dtblLOV = new DataTable();
        CommonListBL objList = new CommonListBL();

        string StrFilter = "";
        DataView DV;

        Int16 Asci;

        Int64 mCustomerID, mLeadID, mAccountID, mAreaID;
        string mCustomerCode, mName1, mName2, mName3, mName4, mName5, mName6, mValue1, mValue2, mValue3, mValue4, mValue5, mValue6;
        string mState,mCustomerName,mcategorycust, mWebsite, mPinCode, mEmail, mTypeOfSale, mContactPerson, mPhone1, mMobileNo, mAddress, mEmpID, mAllocatedToEmpID;
        bool mIsCustomer;
        DateTime mSaleDate, mReminderDate;
        Int64 mQuotationID, mCategory, mCategory1, mcategoryid;
        Int64 mGodownID;
        Int64 mCityID;
        public NameValueCollection _para;
        string mcategoryname;
        public string _spName;
        public bool isFromService = false;
        public bool isFromCustomerPayment = false;
        public bool isFromCreditNote = false;
        #endregion




        #region "Public Property..."

        public string State
        {
            get { return mState; }
            set { mState = value; }
        }

        public string categoryname
        {
            get { return mcategoryname; }
            set { mcategoryname = value; }
        }

        public string categorycust
        {
            get { return mcategorycust; }
            set { mcategorycust = value; }
        }

        public string Name1
        {
            get { return mName1; }
            set { mName1 = value; }
        }

        public string Name2
        {
            get { return mName2; }
            set { mName2 = value; }
        }
        public string Name3
        {
            get { return mName3; }
            set { mName3 = value; }
        }
        public string Name4
        {
            get { return mName4; }
            set { mName4 = value; }
        }
        public string Name5
        {
            get { return mName5; }
            set { mName5 = value; }
        }
        public string Name6
        {
            get { return mName6; }
            set { mName6 = value; }
        }


        public string Value1
        {
            get { return mValue1; }
            set { mValue1 = value; }
        }

        public string Value2
        {
            get { return mValue2; }
            set { mValue2 = value; }
        }
        public string Value3
        {
            get { return mValue3; }
            set { mValue3 = value; }
        }
        public string Value4
        {
            get { return mValue4; }
            set { mValue4 = value; }
        }
        public string Value5
        {
            get { return mValue5; }
            set { mValue5 = value; }
        }
        public string Value6
        {
            get { return mValue6; }
            set { mValue6 = value; }
        }

        public Int64 AreaID
        {
            get { return mAreaID; }
            set { mAreaID = value; }
        }

        public Int64 categoryid
        {
            get { return mcategoryid; }
            set { mcategoryid = value; }
        }

        public Int64 CityID
        {
            get { return mCityID; }
            set { mCityID = value; }
        }


        public string WebSite
        {
            get { return mWebsite; }
            set { mWebsite = value; }
        }
        public string PinCode
        {
            get { return mPinCode; }
            set { mPinCode = value; }
        }
        public Int64 LeadID
        {
            get { return mLeadID; }
            set { mLeadID = value; }
        }

        public Int64 Category
        {
            get { return mCategory; }
            set { mCategory = value; }
        }
        public Int64 CustomerID
        {
            get { return mCustomerID; }
            set { mCustomerID = value; }
        }



        public DateTime SaleDate
        {
            get { return mSaleDate; }
            set { mSaleDate = value; }
        }
        public DateTime ReminderDate
        {
            get { return mReminderDate; }
            set { mReminderDate = value; }
        }
        public string CustomerCode
        {
            get { return mCustomerCode; }
            set { mCustomerCode = value; }
        }

        public string CustomerName
        {
            get { return mCustomerName; }
            set { mCustomerName = value; }
        }

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        public Int64 AccountID
        {
            get { return mAccountID; }
            set { mAccountID = value; }
        }

        //public string Category
        //{
        //    get { return mCategory; }
        //    set { mCategory = value; }
        //}

        public string EmpID
        {
            get { return mEmpID; }
            set { mEmpID = value; }
        }

        public string AllocatedToEmpID
        {
            get { return mAllocatedToEmpID; }
            set { mAllocatedToEmpID = value; }
        }

        public string ContactPerson
        {
            get { return mContactPerson; }
            set { mContactPerson = value; }
        }

        public string Phone1
        {
            get { return mPhone1; }
            set { mPhone1 = value; }
        }

        public string MobileNo
        {
            get { return mMobileNo; }
            set { mMobileNo = value; }
        }

        public Int64 QuotationID
        {
            get { return mQuotationID; }
            set { mQuotationID = value; }
        }

        public Int64 GodownID
        {
            get { return mGodownID; }
            set { mGodownID = value; }
        }

        public string Email
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        public string TypeOfSale
        {
            get { return mTypeOfSale; }
            set { mTypeOfSale = value; }
        }

        public bool IsCustomer
        {
            get { return mIsCustomer; }

            set { mIsCustomer = value; }
        }

        #endregion

        #region "Private Methods..."

        public void LoadList()
        {
            try
            {

                dtblLOV = objList.ListOfRecord(_spName, _para, "Customer LOV - LoadList");
                if (objList.Exception == null)
                {
                    // ArrangeDataGridView();
                    //dgvLOV.AutoGenerateColumns = false;
                    dgvLOV.DataSource = dtblLOV;
                    ArrangeDataGridView();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer LOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            if (isFromCustomerPayment == true)
            {
                // dgvLOV.Columns["CustomerCode"].HeaderText = "Customer Code";
                dgvLOV.Columns["CustomerName"].HeaderText = "CustomerName";
                dgvLOV.Columns["CustomerID"].Visible = false;
                dgvLOV.Columns["Phone1"].Visible = false;
                dgvLOV.Columns["Address"].Visible = false;
                dgvLOV.Columns["ContactPerson"].Visible = false;
                dgvLOV.Columns["Category"].Visible = false;
                dgvLOV.Columns["EmpID"].Visible = false;
                dgvLOV.Columns["CompId"].Visible = false;
                dgvLOV.Columns["AllocatedToEmpID"].Visible = false;
                dgvLOV.Columns["CustomerID"].Visible = false;
                dgvLOV.Columns["AccountID"].Visible = false;
                dgvLOV.Columns["CompId"].Visible = false;
                //dgvLOV.Columns["CNID"].Visible = false;
                //dgvLOV.Columns["TotalAmount"].Visible = false;
                //dgvLOV.Columns["NetAmount"].Visible = false;

                if (_spName == "usp_Customer_Quotation_LOV")
                {
                    dgvLOV.Columns["Subject"].HeaderText = "Quotation Subject";
                    dgvLOV.Columns["QuotationID"].HeaderText = "QuotationID";
                    dgvLOV.Columns["email"].HeaderText = "EmailID";
                    dgvLOV.Columns["QuotationID"].Visible = false;
                    dgvLOV.Columns["Code"].HeaderText = "Quotation Code";
                    dgvLOV.Columns["GodownID"].Visible = false;
                }
            }
            else if (isFromService == true)
            {
                dgvLOV.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvLOV.Columns["SalesDate"].HeaderText = "Sales Date";
                //  dgvLOV.Columns["CNID"].Visible = false;
                dgvLOV.Columns["email"].HeaderText = "EmailID";
                dgvLOV.Columns["CustomerID"].Visible = false;
                dgvLOV.Columns["CompId"].Visible = false;
                dgvLOV.Columns["EmpID"].Visible = false;
                dgvLOV.Columns["AllocatedToEmpID"].Visible = false;
                //dgvLOV.Columns["GodownID"].Visible = false;
            }
            else if (isFromCreditNote == true)
            {
                dgvLOV.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvLOV.Columns["CustomerID"].Visible = false;
                dgvLOV.Columns["Phone1"].Visible = false;
                dgvLOV.Columns["Address"].Visible = false;
                dgvLOV.Columns["ContactPerson"].Visible = false;
                dgvLOV.Columns["Category"].Visible = false;
                dgvLOV.Columns["EmpID"].Visible = false;
                dgvLOV.Columns["AllocatedToEmpID"].Visible = false;
                dgvLOV.Columns["specification"].Visible = false;
                dgvLOV.Columns["name1"].Visible = false;
                dgvLOV.Columns["name2"].Visible = false;
                dgvLOV.Columns["name3"].Visible = false;
                dgvLOV.Columns["name4"].Visible = false;
                dgvLOV.Columns["name5"].Visible = false;
                dgvLOV.Columns["name6"].Visible = false;
                dgvLOV.Columns["value1"].Visible = false;
                dgvLOV.Columns["value2"].Visible = false;
                dgvLOV.Columns["value3"].Visible = false;
                dgvLOV.Columns["value4"].Visible = false;
                dgvLOV.Columns["value5"].Visible = false;
                dgvLOV.Columns["value6"].Visible = false;
                dgvLOV.Columns["remarks"].Visible = false;

            }

            else
            {
                dgvLOV.Columns["CustomerCode"].HeaderText = "Cust Code";
                dgvLOV.Columns["CustomerName"].HeaderText = "Cust Name";
                dgvLOV.Columns["ContactPerson"].HeaderText = "Cont Person";
                dgvLOV.Columns["CustomerID"].Visible = false;
                dgvLOV.Columns["Phone1"].Visible = false;
                //dgvLOV.Columns["Address"].Visible = false;
                // dgvLOV.Columns["ContactPerson"].Visible = false;


                dgvLOV.Columns["CompId"].Visible = false;


                if (_spName == "usp_Customer_Quotation_LOV")
                {
                    dgvLOV.Columns["Subject"].HeaderText = "Quotation Subject";
                    dgvLOV.Columns["QuotationID"].HeaderText = "QuotationID";
                    dgvLOV.Columns["email"].HeaderText = "EmailID";
                    dgvLOV.Columns["QuotationID"].Visible = false;
                    dgvLOV.Columns["Code"].HeaderText = "Code";
                    dgvLOV.Columns["Category"].Visible = false;
                    dgvLOV.Columns["EmpID"].Visible = false;
                    dgvLOV.Columns["AllocatedToEmpID"].Visible = false;
                    dgvLOV.Columns["CompId"].Visible = false;
                    dgvLOV.Columns["IsCustomer"].Visible = false;
                    dgvLOV.Columns["Subject"].Visible = false;
                    dgvLOV.Columns["Category"].Visible = false;
                    dgvLOV.Columns["EmpID"].Visible = false;
                    dgvLOV.Columns["AllocatedToEmpID"].Visible = false;
                    dgvLOV.Columns["lId"].Visible = false;
                    dgvLOV.Columns["CityID"].Visible = false;
                    dgvLOV.Columns["CustomerCode"].Visible = false;

                    //dgvLOV.Columns["GodownID"].Visible = false;
                }
                if (_spName == "usp_Customer_Lead_LOV")
                {
                    //dgvLOV.Columns["Subject"].HeaderText = "Quotation Subject";
                    //dgvLOV.Columns["QuotationID"].HeaderText = "QuotationID";
                    //dgvLOV.Columns["email"].HeaderText = "EmailID";
                    //dgvLOV.Columns["QuotationID"].Visible = false;
                    //dgvLOV.Columns["Code"].HeaderText = "Quotation Code";
                    dgvLOV.Columns["AccountID"].Visible = false;
                }
            }
        }

        public void Load_Serach()
        {
            try
            {
                StrFilter = "";
                if (isFromService == false)
                {
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerCode Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }

                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " Email Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " Phone1 Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " ContactPerson Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }
                }
                else
                {
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " Email Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " Phone1 Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " ContactPerson Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }

                    //if (txtSearch.Text.Trim() != "")
                    //{
                    //    StrFilter = StrFilter + " SrNo Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                    //}
                    //if (txtSearch.Text.Trim() != "")
                    //{
                    //    StrFilter = StrFilter + " TypeOfSale Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                    //}
                }
                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }

                DV = dtblLOV.DefaultView;
                DV.RowFilter = StrFilter;

                dgvLOV.DataSource = DV.ToTable();
                ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer LOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Form Event..."

        public frmCustomerLOV(int CompId, string SpName, NameValueCollection para)
        {
            InitializeComponent();
            _spName = SpName;
            _para = para;
        }

        private void frmCustomerLOV_Load(object sender, EventArgs e)
        {

            //+9*-AddHandlers(this);
            //SetControlsDefaults(this);

            //LoadList();
            AddHandlers(this);
            SetControlsDefaults(this);

            LoadList();
            if (_spName == "usp_Customer_LOV_Payment")
            {
                btnNewCustomer.Visible = false;
            }
        }

        #endregion

        #region "Button Event..."

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvLOV.CurrentRow != null)
            {
                if (DialogResult == System.Windows.Forms.DialogResult.None)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    if (isFromCustomerPayment == true)
                    {
                        CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                        CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                        CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                        MobileNo = dgvLOV.CurrentRow.Cells["Mobile"].Value.ToString();
                        ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                        Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                        // Category = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();
                        //Category = Convert.ToInt64(dgvLOV.CurrentRow.Cells["Category"].Value.ToString());
                        EmpID = dgvLOV.CurrentRow.Cells["EmpID"].Value.ToString();
                        AllocatedToEmpID = dgvLOV.CurrentRow.Cells["AllocatedToEmpID"].Value.ToString();
                        AccountID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["AccountID"].Value.ToString());
                        // CityID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CityID"].Value.ToString());
                        //PinCode = dgvLOV.CurrentRow.Cells["Pincode"].Value.ToString();
                        // WebSite = dgvLOV.CurrentRow.Cells["Website"].Value.ToString();

                        if (_spName == "usp_Customer_LOV")
                        {
                            SaleDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["LeadDate"].Value.ToString());

                            if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                        }
                        if (_spName == "usp_Customer_Quotation_LOV")
                        {

                            QuotationID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["QuotationID"].Value.ToString());

                            Email = dgvLOV.CurrentRow.Cells["email"].Value.ToString();

                            if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                        }

                        if (_spName == "usp_Customer_LOV_Payment")
                        {

                            if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                        }

                        if (_spName == "usp_Customer_LOV_PaymentReturn")
                        {

                            if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                        }

                        //if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                        //{
                        //    IsCustomer = true;
                        //}
                        //else
                        //{
                        //    IsCustomer = false;
                        //}
                    }
                    else if (isFromService == true)
                    {
                        LeadID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                        CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["SIID"].Value.ToString());
                        // CustomerCode = dgvLOV.CurrentRow.Cells["Code"].Value.ToString();
                        CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                        SaleDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["SalesDate"].Value.ToString());
                        Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                        MobileNo = dgvLOV.CurrentRow.Cells["Mobile"].Value.ToString();
                        ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                        Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                        //Category = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();
                        //Category = Convert.ToInt64(dgvLOV.CurrentRow.Cells["Category"].Value.ToString());
                        EmpID = dgvLOV.CurrentRow.Cells["EmpID"].Value.ToString();
                        AllocatedToEmpID = dgvLOV.CurrentRow.Cells["AllocatedToEmpID"].Value.ToString();
                        ReminderDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["ReminderDate"].Value.ToString());

                        if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                        {
                            IsCustomer = true;
                        }
                        else
                        {
                            IsCustomer = false;
                        }
                    }

                    else if (isFromCreditNote == true)
                    {
                        CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                        CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                        CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                        ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                        Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                        // Category = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();
                        // Category = Convert.ToInt64(dgvLOV.CurrentRow.Cells["Category"].Value.ToString());

                        EmpID = dgvLOV.CurrentRow.Cells["EmpID"].Value.ToString();
                        AllocatedToEmpID = dgvLOV.CurrentRow.Cells["AllocatedToEmpID"].Value.ToString();
                        AccountID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["AccountID"].Value.ToString());

                        if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                        {
                            IsCustomer = true;
                        }
                        else
                        {
                            IsCustomer = false;
                        }
                    }

                    else
                    {
                        //CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                        //CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                        //CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        //Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        //Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                        //ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                        //Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                        //Category = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();
                        //EmpID = dgvLOV.CurrentRow.Cells["EmpID"].Value.ToString();
                        //AllocatedToEmpID = dgvLOV.CurrentRow.Cells["AllocatedToEmpID"].Value.ToString();
                        if (_spName == "usp_Customer_LOV")
                        {
                            CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                            CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                            CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                            Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                            Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                            MobileNo = dgvLOV.CurrentRow.Cells["Mobile"].Value.ToString();
                            ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                            Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                            categorycust = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();
                            // Category = Convert.ToInt64(dgvLOV.CurrentRow.Cells["Category"].Value.ToString());

                            EmpID = dgvLOV.CurrentRow.Cells["EmpID"].Value.ToString();
                            AllocatedToEmpID = dgvLOV.CurrentRow.Cells["AllocatedToEmpID"].Value.ToString();

                            // SaleDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["LeadDate"].Value.ToString());

                            if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                        }
                        if (_spName == "usp_Customer_Quotation_LOV")
                        {
                            CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                            CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                            CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                            Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                            Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                            MobileNo = dgvLOV.CurrentRow.Cells["Mobile"].Value.ToString();
                            ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                            Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                            // Category = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();
                            // Category = Convert.ToInt64(dgvLOV.CurrentRow.Cells["Category"].Value.ToString());
                            LeadID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["lID"].Value.ToString());
                            EmpID = dgvLOV.CurrentRow.Cells["EmpID"].Value.ToString();
                            AllocatedToEmpID = dgvLOV.CurrentRow.Cells["AllocatedToEmpID"].Value.ToString();

                            QuotationID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["QuotationID"].Value.ToString());
                            CityID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CityID"].Value.ToString());

                            Email = dgvLOV.CurrentRow.Cells["email"].Value.ToString();

                            if (dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("CUST") || dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString().Contains("INQ"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                            //GodownID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["GodownID"].Value.ToString());
                        }
                        if (_spName == "usp_Customer_Lead_LOV")
                        {
                            CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                            CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                            CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                            Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                            Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                            MobileNo = dgvLOV.CurrentRow.Cells["Mobile"].Value.ToString();
                            ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                            Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                            AccountID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["AccountID"].Value.ToString());
                            //QuotationID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["QuotationID"].Value.ToString());
                            //CityID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CityID"].Value.ToString());
                            CityID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CityID"].Value.ToString());
                            Email = dgvLOV.CurrentRow.Cells["email"].Value.ToString();
                            PinCode = dgvLOV.CurrentRow.Cells["Pincode"].Value.ToString();
                            WebSite = dgvLOV.CurrentRow.Cells["Website"].Value.ToString();
                            State = dgvLOV.CurrentRow.Cells["State"].Value.ToString();


                            AreaID = Convert.ToInt16(dgvLOV.CurrentRow.Cells["AreaID"].Value.ToString());
                            categoryname = dgvLOV.CurrentRow.Cells["Category"].Value.ToString();

                            Name1 = dgvLOV.CurrentRow.Cells["Name1"].Value.ToString();
                            Name2 = dgvLOV.CurrentRow.Cells["Name2"].Value.ToString();
                            Name3 = dgvLOV.CurrentRow.Cells["Name3"].Value.ToString();
                            Name4 = dgvLOV.CurrentRow.Cells["Name4"].Value.ToString();
                            Name5 = dgvLOV.CurrentRow.Cells["Name5"].Value.ToString();
                            Name6 = dgvLOV.CurrentRow.Cells["Name6"].Value.ToString();


                            Value1 = dgvLOV.CurrentRow.Cells["Value1"].Value.ToString();
                            Value2 = dgvLOV.CurrentRow.Cells["Value2"].Value.ToString();
                            Value3 = dgvLOV.CurrentRow.Cells["Value3"].Value.ToString();
                            Value4 = dgvLOV.CurrentRow.Cells["Value4"].Value.ToString();
                            Value5 = dgvLOV.CurrentRow.Cells["Value5"].Value.ToString();
                            Value6 = dgvLOV.CurrentRow.Cells["Value6"].Value.ToString();

                            //Category = Convert.ToInt64(dgvLOV.CurrentRow.Cells["Category"].Value.ToString());
                        }

                        //if (_spName == "usp_Customer_LOV_Payment")
                        //{
                        //    CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                        //    CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                        //    CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        //    Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        //    Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                        //    ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                        //    Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                        //    AccountID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["AccountID"].Value.ToString());

                        //    //QuotationID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["QuotationID"].Value.ToString());

                        //    Email = dgvLOV.CurrentRow.Cells["email"].Value.ToString();
                        //}
                    }
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                //GUI.Lead.frmLeadEntry fLead = new GUI.Lead.frmLeadEntry((int)Constant.Mode.Insert, 0);
                GUI.CustomerMain.frmCustomerMainEntry fcust = new GUI.CustomerMain.frmCustomerMainEntry((int)Constant.Mode.Insert, 0);
                fcust.ShowInTaskbar = false;
                fcust.ShowDialog();
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        #endregion

        #region "GridView Event..."

        private void dgvLOV_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void dgvLOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Asci = (Int16)e.KeyChar;
            if (Asci != 13 && Asci != 27)
            {
                btnSelect_Click(sender, e);
            }
            //else if (Asci == 27)
            //{
            //    this.Close();
            //}
        }

        private void dgvLOV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                GridDrawCustomHeaderColumns(dgvLOV, e, Properties.Resources.Button_Gray_Stripe_01_050);
            }
            if (e.ColumnIndex == -1)
            {
                GridDrawCustomHeaderColumns(dgvLOV, e, Properties.Resources.Button_Gray_Stripe_01_050);
            }
        }

        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                Load_Serach();
            }
            else
            {
                StrFilter = "";
                DV = dtblLOV.DefaultView;
                DV.RowFilter = StrFilter;
                dgvLOV.DataSource = DV.ToTable();
                ArrangeDataGridView();
            }
        }

        #region "Textbox Event..."


        #endregion
    }
}
