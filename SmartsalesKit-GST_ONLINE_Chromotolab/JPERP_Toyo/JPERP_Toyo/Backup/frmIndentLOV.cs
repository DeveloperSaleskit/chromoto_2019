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
    public partial class frmIndentLOV : Account.GUIBase
    {

        #region "Variable Declarations..."

        DataTable dtblLOV = new DataTable();
        CommonListBL CommList = new CommonListBL();

        string StrFilter = "";
        DataView DV;

        Int16 Asci;
        DateTime mVoucherDate, mPurchaseDate;
        Int64 mVendorID, mPIID, mPIDetailID;
        string mVendorName, mPurchaseCode, mGodownName, mCreditDays,mMobile,mFax;
        string mVoucherNo;

        #endregion

        #region "Public Property..."

        public Int64 VendorID
        {
            get { return mVendorID; }
            set { mVendorID = value; }
        }

        public Int64 PIID
        {
            get { return mPIID; }
            set { mPIID = value; }
        }

        public Int64 PIDetailID
        {
            get { return mPIDetailID; }
            set { mPIDetailID = value; }
        }

        public string VendorName
        {
            get { return mVendorName; }
            set { mVendorName = value; }
        }
        public string PurchaseCode
        {
            get { return mPurchaseCode; }
            set { mPurchaseCode = value; }
        }
        public DateTime PurchaseDate
        {
            get { return mPurchaseDate; }
            set { mPurchaseDate = value; }
        }
        public string VoucherNo
        {
            get { return mVoucherNo; }
            set { mVoucherNo = value; }
        }
        public string GodownName
        {
            get { return mGodownName; }
            set { mGodownName = value; }
        }

        public string CreditDays
        {
            get { return mCreditDays; }
            set { mCreditDays = value; }
        }

        public DateTime VoucherDate
        {
            get { return mVoucherDate; }
            set { mVoucherDate = value; }
        }

        public string Mobile
        {
            get { return mMobile; }
            set { mMobile = value; }
        }


        public string Fax
        {
            get { return mFax; }
            set { mFax = value; }
        }

        #endregion

        #region "Private Methods..."

        public void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblLOV = CommList.ListOfRecord("usp_Indent_LOV", para, "Indent - LoadList");
                if (CommList.Exception != null)
                {
                    MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvLOV.DataSource = dtblLOV;
                ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Indent LOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            dgvLOV.Columns["VendorName"].HeaderText = "Vendor Name";
            dgvLOV.Columns["PurchaseCode"].HeaderText = "Purchase Code";
            dgvLOV.Columns["PurchaseDate"].HeaderText = "Purchase Date";
            dgvLOV.Columns["VoucherNo"].HeaderText = "Voucher No";
            dgvLOV.Columns["VendorName"].HeaderText = "Vendor Name";
            dgvLOV.Columns["VoucherDate"].HeaderText = "Voucher Date";
            dgvLOV.Columns["GodownName"].HeaderText = "Godown Name";
            dgvLOV.Columns["VendorID"].Visible = false;
            dgvLOV.Columns["PIID"].Visible = false;
            //dgvLOV.Columns["Fax"].Visible = false;


        }

        public void Load_Serach()
        {
            StrFilter = "";
            if (txtSearch.Text.Trim() != "")
            {
                StrFilter = StrFilter + " VendorName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' And ";
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

        public frmIndentLOV()
        {
            InitializeComponent();
        }

        private void frmVendorLOV_Load(object sender, EventArgs e)
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
                    VendorID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["VendorID"].Value.ToString());
                    VendorName = dgvLOV.CurrentRow.Cells["VendorName"].Value.ToString();
                    PurchaseCode = dgvLOV.CurrentRow.Cells["PurchaseCode"].Value.ToString();
                    PurchaseDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["PurchaseDate"].Value);
                    VoucherNo = dgvLOV.CurrentRow.Cells["VoucherNo"].Value.ToString();
                    VoucherDate = Convert.ToDateTime(dgvLOV.CurrentRow.Cells["VoucherDate"].Value);
                    GodownName = dgvLOV.CurrentRow.Cells["GodownName"].Value.ToString();
                    Fax = dgvLOV.CurrentRow.Cells["mobile"].Value.ToString();
                    Mobile = dgvLOV.CurrentRow.Cells["mobile"].Value.ToString();
                    Fax = dgvLOV.CurrentRow.Cells["fax"].Value.ToString();

                    CreditDays = dgvLOV.CurrentRow.Cells["CreditDays"].Value.ToString();
                    PIID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["PIID"].Value.ToString());

                    //PIDetailID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["PIDetailID"].Value.ToString());
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
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
                Utill.Common.ExceptionLogger.writeException("Vendor LOV", exc.StackTrace);
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
            if (txtSearch.Text.Trim() != "")
            {
                Load_Serach();
            }
        }
        #endregion

    }
}
