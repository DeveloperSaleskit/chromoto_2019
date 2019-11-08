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
    public partial class frmVendorReturnLOV : Account.GUIBase
    {

        #region "Variable Declarations..."

        DataTable dtblLOV = new DataTable();
        CommonListBL objList = new CommonListBL();

        string StrFilter = "";
        DataView DV;

        Int16 Asci;

        Int64 mCustomerID, mLeadID, mAccountID;
        string mCustomerCode;
        string mCustomerName, mEmail, mTypeOfSale, mContactPerson, mPhone1, mMobileNo, mAddress, mCategory, mEmpID, mAllocatedToEmpID;
        bool mIsCustomer;
        DateTime mSaleDate, mReminderDate;
        Int64 mQuotationID;
        Int64 mGodownID;
        public NameValueCollection _para;
        public string _spName;
        public bool isFromService = false;
        public bool isFromCustomerPayment = false;
        public bool isFromCreditNote = false;

        Int64 mVendorID;
        string mVendorName;
        string mFax;


        #endregion

        #region "Public Property..."

            public Int64 VendorID
            {
                get { return mVendorID; }
                set { mVendorID = value; }
            }

            public string VendorName
            {
                get { return mVendorName; }
                set { mVendorName = value; }
            }
            public string Fax
            {
                get { return mFax; }
                set { mFax = value; }
            }

            public string MobileNo
            {
                get { return mMobileNo; }
                set { mMobileNo = value; }
            }
        #endregion 

        #region "Private Methods..."

            public void LoadList()
            {
                try
                {

                    dtblLOV = objList.ListOfRecord(_spName, _para, "Vendor LOV - LoadList");
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
                dgvLOV.Columns["Name"].HeaderText = "Vendor Name";

                dgvLOV.Columns["VendorID"].Visible = false;
                dgvLOV.Columns["Phone1"].Visible = false;
                dgvLOV.Columns["Address"].Visible = false;
                //dgvLOV.Columns["ContactPerson"].Visible = false;
                //dgvLOV.Columns["Category"].Visible = false;
                //dgvLOV.Columns["EmpID"].Visible = false;
                dgvLOV.Columns["CompId"].Visible = false;
                //dgvLOV.Columns["AllocatedToEmpID"].Visible = false;
                dgvLOV.Columns["VendorID"].Visible = false;
                dgvLOV.Columns["AccountID"].Visible = false;
                dgvLOV.Columns["CompId"].Visible = false;
                dgvLOV.Columns["DNID"].Visible = false;
                dgvLOV.Columns["TotalAmount"].Visible = false;
                dgvLOV.Columns["NetAmount"].Visible = false;
                dgvLOV.Columns["FinalAmount"].Visible = false;
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

            public frmVendorReturnLOV(int CompId, string SpName, NameValueCollection para)
            {
                InitializeComponent();
                _spName = SpName;
                _para = para;
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
                        VendorName = dgvLOV.CurrentRow.Cells["Name"].Value.ToString();
                        //Fax = dgvLOV.CurrentRow.Cells["Fax"].Value.ToString();
                       // MobileNo = dgvLOV.CurrentRow.Cells["MobileNo"].Value.ToString();
                        this.Close();
                    }
                }
            }

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
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
