using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using System.Configuration;
using Account.Validator;
using Account.Properties;

namespace Account.DefaultLayout
{
    public partial class frmVendorPendingList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region "Variable Declaration...."

        DataTable dtblPI = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataView DV;
        int _CompId = 0;
        private Font NormalFont = new Font("Verdana", 8, FontStyle.Regular);
        #endregion

        #region "Form Event..."
        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#5062#") != -1)
                        { btnfollowup.Enabled = true; }
                        else { btnfollowup.Enabled = false; }
                    }
                }

                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para1.Add("@i_UserId", CurrentUser.UserID.ToString());

                dtblPI = objList.ListOfRecord("usp_Invoice_List", para1, "Invoice - LoadList");
                if (objList.Exception == null)
                {
                    ArrangeDataGridView();
                    dgvInvoice.AutoGenerateColumns = false;
                    dgvInvoice.DataSource = dtblPI;
                    ArrangeDataGridView();
                }

               


                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Invoice-LoadList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvInvoice.Columns["InvoiceID"].DataPropertyName = dtblPI.Columns["InvoiceID"].ToString();
                dgvInvoice.Columns["Type"].DataPropertyName = dtblPI.Columns["Type"].ToString();
                dgvInvoice.Columns["Code"].DataPropertyName = dtblPI.Columns["Code"].ToString();
                dgvInvoice.Columns["Date"].DataPropertyName = dtblPI.Columns["Date"].ToString();
                dgvInvoice.Columns["Party"].DataPropertyName = dtblPI.Columns["Party"].ToString();
                dgvInvoice.Columns["ContactPerson"].DataPropertyName = dtblPI.Columns["ContactPerson"].ToString();
                dgvInvoice.Columns["Phone1"].DataPropertyName = dtblPI.Columns["Phone1"].ToString();
                dgvInvoice.Columns["Specification"].DataPropertyName = dtblPI.Columns["Specification"].ToString();
                dgvInvoice.Columns["Remarks"].DataPropertyName = dtblPI.Columns["Remarks"].ToString();
                //dgvInvoice.Columns["NetAmount"].DataPropertyName = dtblPI.Columns["NetAmount"].ToString();
                //dgvInvoice.Columns["DueDays"].DataPropertyName = dtblPI.Columns["DueDays"].ToString();
                //dgvInvoice.Columns["DueDate"].DataPropertyName = dtblPI.Columns["DueDate"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Invoice-ArrangeGrid", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Form Event..."

        public frmVendorPendingList()
        {
            InitializeComponent();
        }

        private void frmContacts_Load(object sender, EventArgs e)
        {
            DataGridView t = ((DataGridView)dgvInvoice);
            t.ForeColor = Color.Black;
            t.BackgroundColor = Color.White;
            t.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            t.StandardTab = true;
            t.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            t.AllowUserToAddRows = false;
            t.AllowUserToDeleteRows = false;
            t.MultiSelect = false;
            t.ReadOnly = true;
            t.RowHeadersWidth = 25;
            t.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            t.ColumnHeadersDefaultCellStyle.Font = NormalFont;
            t.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
            t.RowsDefaultCellStyle.Font = NormalFont;
            t.RowsDefaultCellStyle.BackColor = Color.FromArgb(253, 253, 253);
            t.ColumnHeadersDefaultCellStyle.Font = NormalFont;
            t.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            t.RowsDefaultCellStyle.Font = NormalFont;
            t.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            t.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 225);

            //btnRefresh.BackgroundImage = Resources.stufftheme4;
            //btnRefresh.Text = "";
            //btnRefresh.Width = 26;
            //btnRefresh.Height = 30;

            //btnRefresh.BackgroundImage = Resources.stufftheme4;
            //btnRefresh.Text = "";
            //btnRefresh.Width = 26;
            //btnRefresh.Height = 30;
            //btnRefresh.FlatStyle = FlatStyle.Popup;


            btnfollowup.ForeColor = Color.Black;
            btnRefresh.ForeColor = Color.Black;         

            LoadList();
        }

        #endregion

        #region "GridView Event"

        private void dgvInvoice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Invoice Lead", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button's Event"

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        #endregion

        private void btnfollowup_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.CurrentRow != null)
                {

                    string CustName = dgvInvoice.CurrentRow.Cells["ContactPerson"].Value.ToString();
                    string LeadDate = Convert.ToDateTime(dgvInvoice.CurrentRow.Cells["Date"].Value.ToString()).ToShortDateString();
                    string folloupDate = Convert.ToDateTime(dgvInvoice.CurrentRow.Cells["Date"].Value.ToString()).ToShortDateString();
                    GUI.Lead.frmLeadFollowup fCustomer = new GUI.Lead.frmLeadFollowup((Int64)dgvInvoice.CurrentRow.Cells["InvoiceID"].Value, dgvInvoice.CurrentRow.Cells["Code"].Value.ToString(), LeadDate, CustName, folloupDate);
                    fCustomer.ShowInTaskbar = false;
                    fCustomer.ShowDialog();
                    ArrangeDataGridView();
                   
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

      



    }
}
