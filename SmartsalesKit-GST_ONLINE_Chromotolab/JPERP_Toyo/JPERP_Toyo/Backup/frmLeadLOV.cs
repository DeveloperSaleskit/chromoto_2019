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

namespace Account
{
    public partial class frmLeadLOV : Account.GUIBase
    {
        #region "Variable Declarations..."

        DataTable dtblLOV = new DataTable();
        CommonListBL CommList = new CommonListBL();
        string StrFilter = "";
        DataView DV;
        Int16 Asci;
        bool _isForSale = false;
        Int64 mLeadID;
        string mCustomerName;
        DateTime mLeadDate;
        DateTime mWarrantyDate;
        string mLeadNo;
        string mEmailID;
        string mMobileNo;
        string mAddress;
        string mParentCatg;
        string mMainCatg;
        string mSubCatg;

        #endregion

        #region "Public Property..."

        public Int64 LeadID
        {
            get { return mLeadID; }
            set { mLeadID = value; }
        }

        public string LeadNo
        {
            get { return mLeadNo; }
            set { mLeadNo = value; }
        }

        public string ParentCategory
        {
            get { return mParentCatg; }
            set { mParentCatg = value; }
        }

        public string SubCategory
        {
            get { return mSubCatg; }
            set { mSubCatg = value; }
        }

        public string MainCategory
        {
            get { return mMainCatg; }
            set { mMainCatg = value; }
        }

        public string CustomerName
        {
            get { return mCustomerName; }
            set { mCustomerName = value; }
        }

        public string MobileNo
        {
            get { return mMobileNo; }
            set { mMobileNo = value; }
        }

        public string Address
        {
            get { return mAddress; }
            set { mAddress = value; }
        }

        public string EmailID
        {
            get { return mEmailID; }
            set { mEmailID = value; }
        }

        public DateTime LeadDate
        {
            get { return mLeadDate; }
            set { mLeadDate = value; }
        }

        public DateTime WarrantyDate
        {
            get { return mWarrantyDate; }
            set { mWarrantyDate = value; }
        }

        #endregion

        #region "Private Methods..."

        public void LoadList()
        {
            try
            {
                NameValueCollection Paralist = new NameValueCollection();
                Paralist.Add("@i_UserID", CurrentUser.UserID.ToString());
                if (_isForSale)
                {
                    dtblLOV = CommList.ListOfRecord("usp_Sale_LOV", null, "LeadLOV - LoadList");
                }
                else
                {
                    dtblLOV = CommList.ListOfRecord("usp_Lead_LOV", null, "LeadLOV - LoadList");
                }
                if (CommList.Exception != null)
                {
                    MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvLOV.DataSource = dtblLOV;
                ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead LOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            dgvLOV.Columns["LeadNo"].HeaderText = "Lead No";
            dgvLOV.Columns["CustomerName"].HeaderText = "Customer Name";
            if (_isForSale)
            {
              //  dgvLOV.Columns["SaleDate"].HeaderText = "Date";
               // dgvLOV.Columns["ArrivalDate"].HeaderText = "Warranty Date";

               // dgvLOV.Columns["SiteName"].HeaderText = "Main Category";
              //  dgvLOV.Columns["BuildingName"].HeaderText = "Parent Category";
              //  dgvLOV.Columns["BlockName"].HeaderText = "Sub Category";
             //   dgvLOV.Columns["Address"].HeaderText = "Address";
            }
            else
                dgvLOV.Columns["LeadDate"].HeaderText = "Date";
           
                dgvLOV.Columns["LeadID"].Visible = false;
            dgvLOV.Columns["MobileNo"].Visible = false;
            dgvLOV.Columns["Email"].Visible = false;
        }

        public void Load_Serach()
        {
            StrFilter = "";
            if (txtSearch.Text.Trim() != "")
            {
                StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
            }
            if (txtSearch.Text.Trim() != "")
            {
                StrFilter = StrFilter + " LeadNo Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
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

        #endregion

        #region "Form Load Events"

        public frmLeadLOV(bool isForSale)
        {
            InitializeComponent();
            _isForSale = isForSale;
            if (!_isForSale)
                btnNewCustomer.Visible = true;
        }

        private void frmLeadLOV_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
        }

        #endregion

        #region "Button events"

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvLOV.CurrentRow != null)
            {
                if (DialogResult == System.Windows.Forms.DialogResult.None)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    if (_isForSale)
                    {
                        LeadID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["LeadID"].Value.ToString());
                        LeadDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["LeadDate"].Value.ToString());
                     //   WarrantyDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["ArrivalDate"].Value.ToString());
                        Address = dgvLOV.CurrentRow.Cells["Address"].Value.ToString();
                    //    MainCategory = dgvLOV.CurrentRow.Cells["SiteName"].Value.ToString();
                     //   ParentCategory = dgvLOV.CurrentRow.Cells["BuildingName"].Value.ToString();
//SubCategory = dgvLOV.CurrentRow.Cells["BlockName"].Value.ToString();

                    }
                    else
                    {
                        LeadID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["LeadID"].Value.ToString());
                        LeadDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["LeadDate"].Value.ToString());
                    }
                    CustomerName = dgvLOV.CurrentRow.Cells["CustomerName"].Value.ToString();
                    LeadNo = dgvLOV.CurrentRow.Cells["LeadNo"].Value.ToString();

                    MobileNo = dgvLOV.CurrentRow.Cells["MobileNo"].Value.ToString();
                    EmailID = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
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
                Account.GUI.Lead.frmLeadEntry fCustomer = new Account.GUI.Lead.frmLeadEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;
                fCustomer.ShowDialog();
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "grid Event"

        private void dgvLOV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
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
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead LOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvLOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Asci = (Int16)e.KeyChar;
            if (Asci != 13 && Asci != 27)
            {
                btnSelect_Click(sender, e);
            }
        }

        private void dgvLOV_DoubleClick(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        #endregion

        #region "textbox event"

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Load_Serach();
        }
        #endregion


    }
}
