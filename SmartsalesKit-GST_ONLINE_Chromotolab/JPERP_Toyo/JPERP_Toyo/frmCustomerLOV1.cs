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
using Account.GUI.Customer;

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

        Int64 mCustomerID;
        string mCustomerCode;
        string mCustomerName, mEmail, mTypeOfSale, mContactPerson, mPhone1, mAddress;
        DateTime mSaleDate;
        Int64 mQuotationID;
        public NameValueCollection _para;
        public string _spName;
        public bool isFromService = false;
        #endregion

        #region "Public Property..."

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

        public Int64 QuotationID
        {
            get { return mQuotationID; }
            set { mQuotationID = value; }
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
            if (isFromService == false)
            {
                dgvLOV.Columns["CustomerCode"].HeaderText = "Customer Code";
                dgvLOV.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvLOV.Columns["CustomerID"].Visible = false;
                dgvLOV.Columns["Phone1"].Visible = false;
                dgvLOV.Columns["Address"].Visible = false;
                dgvLOV.Columns["ContactPerson"].Visible = false;
                if (_spName == "usp_Customer_Quotation_LOV")
                {
                    dgvLOV.Columns["Subject"].HeaderText = "Quotation Subject";
                    dgvLOV.Columns["QuotationID"].HeaderText = "QuotationID";
                    dgvLOV.Columns["email"].HeaderText = "EmailID";
                }
            }
            else
            {
                dgvLOV.Columns["CustomerName"].HeaderText = "Customer Name";
                dgvLOV.Columns["SalesDate"].HeaderText = "Sales Date";
                dgvLOV.Columns["SrNo"].HeaderText = "Sr No";
                dgvLOV.Columns["SIID"].Visible = false;
                dgvLOV.Columns["email"].HeaderText = "EmailID";
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
                }
                else
                {
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                    }

                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " SrNo Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                    }
                    if (txtSearch.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " TypeOfSale Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                    }
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

        public frmCustomerLOV(string SpName, NameValueCollection para)
        {
            InitializeComponent();
            _spName = SpName;
            _para = para;
        }

        private void frmCustomerLOV_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            LoadList();
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
                    if (isFromService == false)
                    {
                        CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["CustomerID"].Value.ToString());
                        CustomerCode = dgvLOV.CurrentRow.Cells["CustomerCode"].Value.ToString();
                        CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        Phone1 = dgvLOV.CurrentRow.Cells["Phone1"].Value.ToString();
                        ContactPerson = dgvLOV.CurrentRow.Cells["ContactPerson"].Value.ToString();
                        Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                        if (_spName == "usp_Customer_LOV")
                        {
                            SaleDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["LeadDate"].Value.ToString());
                        }
                        if (_spName == "usp_Customer_Quotation_LOV")
                        {
                            QuotationID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["QuotationID"].Value.ToString());
                            Email = dgvLOV.CurrentRow.Cells["email"].Value.ToString();
                        }
                    }
                    else
                    {
                        CustomerID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["SIID"].Value.ToString());
                        CustomerCode = dgvLOV.CurrentRow.Cells["SrNo"].Value.ToString();
                        CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                        SaleDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["SalesDate"].Value.ToString());
                        Email = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        TypeOfSale = dgvLOV.CurrentRow.Cells["TypeOfSale"].Value.ToString();
                    }
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerEntry fCustomer = new frmCustomerEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;
                fCustomer.ShowDialog();
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
