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
    public partial class frmVendorLOV : Account.GUIBase
    {

        #region "Variable Declarations..."

            DataTable dtblLOV = new DataTable();
            CommonListBL CommList = new CommonListBL();

            string StrFilter = "";
            DataView DV;

            Int16 Asci;

            Int64 mVendorID;
            string mVendorName;
            string mFax, mMobileNo;

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
                    NameValueCollection para = new NameValueCollection();

                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                    dtblLOV = CommList.ListOfRecord("usp_Vendor_LOV", para, "VendorLOV - LoadList");
                    if (CommList.Exception != null)
                    {
                        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dgvLOV.DataSource = dtblLOV;
                    ArrangeDataGridView();
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Vendor LOV", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            private void ArrangeDataGridView()
            {
                dgvLOV.Columns["VendorName"].HeaderText = "Vendor Name";

                dgvLOV.Columns["VendorID"].Visible = false;
                dgvLOV.Columns["Email"].Visible = true;
                dgvLOV.Columns["Mobile"].Visible = true;
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

            public frmVendorLOV()
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
                        Fax = dgvLOV.CurrentRow.Cells["Email"].Value.ToString();
                        MobileNo = dgvLOV.CurrentRow.Cells["Mobile"].Value.ToString();
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
