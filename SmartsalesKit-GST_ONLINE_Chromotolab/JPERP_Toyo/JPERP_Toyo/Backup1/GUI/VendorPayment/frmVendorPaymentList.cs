using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Collections.Specialized;
using Account.BusinessLogic;
using Account.Common;
using Account.Validator;
using System.Configuration;

namespace Account.GUI.VendorPayment
{
    public partial class frmVendorPaymentList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable ObjDataTable = new DataTable();
        DataTable ObjDataTableRegister = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;

        #endregion

        #region "Form load events"

        public frmVendorPaymentList()
        {
            InitializeComponent();
        }

        private void frmVendorPaymentList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9093#") != -1)
                    {
                        cmbreports.Items.Add("Vendor Payment");
                    }
                }
                else
                {
                    cmbreports.Items.Add("Vendor Payment");
                }
                cmbreports.SelectedIndex = 0;
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Vendor Payment");
                cmbreports.SelectedIndex = 0;
            }


            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9094#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9095#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9096#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                }
            }
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                //para.Add("@i_VendorID", CurrentUser.VendorID.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompanyID", CurrentCompany.CompId.ToString());
                ObjDataTable = objList.ListOfRecord("usp_VendorPayment_List", para, "Vendor Payment - List - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvVendorPayment.CurrentRow != null)
                    {
                        idgvPosition = dgvVendorPayment.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvVendorPayment.AutoGenerateColumns = false;
                    dgvVendorPayment.DataSource = ObjDataTable;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvVendorPayment.RowCount.ToString();
                    if (dgvVendorPayment.CurrentRow != null && idgvPosition <= dgvVendorPayment.RowCount)
                    {
                        if (dgvVendorPayment.Rows.Count - 1 < idgvPosition)
                        {
                            dgvVendorPayment.CurrentCell = dgvVendorPayment.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvVendorPayment.CurrentCell = dgvVendorPayment.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvVendorPayment.Columns["PaymentCode"].DataPropertyName = ObjDataTable.Columns["PaymentCode"].ToString();
                dgvVendorPayment.Columns["PaymentID"].DataPropertyName = ObjDataTable.Columns["PaymentID"].ToString();
                dgvVendorPayment.Columns["PaymentDate"].DataPropertyName = ObjDataTable.Columns["PaymentDate"].ToString();
                dgvVendorPayment.Columns["VendorCode"].DataPropertyName = ObjDataTable.Columns["VendorCode"].ToString();
                dgvVendorPayment.Columns["Vendor"].DataPropertyName = ObjDataTable.Columns["VendorName"].ToString();
                dgvVendorPayment.Columns["NetAmount"].DataPropertyName = ObjDataTable.Columns["NetAmount"].ToString();
                dgvVendorPayment.Columns["Narration"].DataPropertyName = ObjDataTable.Columns["Narration"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvVendorPayment.SortedColumn != null)
                {
                    sortedColumn = dgvVendorPayment.SortedColumn;
                    sortDirection = dgvVendorPayment.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();
                //btnApply_Click(sender, e);
                DV = ObjDataTable.DefaultView;
                DV.RowFilter = StrFilter;

                dgvVendorPayment.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvVendorPayment.RowCount.ToString();

                if (sortedColumn != null)
                {
                    ListSortDirection LSD;
                    if (sortDirection == SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvVendorPayment.Sort(dgvVendorPayment.Columns[sortedColumn.Name], LSD);
                }
                if (dgvVendorPayment.CurrentRow != null && idgvPosition <= dgvVendorPayment.RowCount)
                {
                    if (dgvVendorPayment.Rows.Count - 1 < idgvPosition)
                    {
                        dgvVendorPayment.CurrentCell = dgvVendorPayment.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvVendorPayment.CurrentCell = dgvVendorPayment.Rows[idgvPosition].Cells[0];
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button events"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = ObjDataTable.DefaultView;
            DV.RowFilter = StrFilter;
            dgvVendorPayment.DataSource = DV.ToTable();
            VendorPayment.frmVendorPaymentFilter filterSalesinvoice = new VendorPayment.frmVendorPaymentFilter(ObjDataTable);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvVendorPayment.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvVendorPayment.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";
                LoadList();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendorPaymentEntry fVendorPayment = new frmVendorPaymentEntry((int)Constant.Mode.Insert, 0);
                fVendorPayment.ShowInTaskbar = false;
                fVendorPayment.ShowDialog();
                btnClear_Click(sender, e);
                LoadList();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendorPayment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmVendorPaymentEntry fVendorPayment = new frmVendorPaymentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvVendorPayment.CurrentRow.Cells["PaymentID"].Value));
                    fVendorPayment.ShowInTaskbar = false;
                    fVendorPayment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendorPayment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmVendorPaymentEntry fVendorPayment = new frmVendorPaymentEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvVendorPayment.CurrentRow.Cells["PaymentID"].Value));
                    fVendorPayment.ShowInTaskbar = false;
                    fVendorPayment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Datagrid Event"

        private void dgvVendorPayment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvVendorPayment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvVendorPayment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox events"

        private void txtFromentryno_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-,.");
        }

        #endregion

        #region "Report Menu..."

        private void mnuDeliveryChallanRegister_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {

                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para.Add("@i_UserID", CurrentUser.UserID.ToString());

                    DataTable dtReport = new DataTable();

                    dtReport = objList.ListOfRecord("rpt_VendorPayment", para, "VendorPayment - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptVendorPaymentRegister.rpt"))
                        {
                            //dtblPurchaseInvoice .TableName = "PORegister";
                            //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptVendorPaymentRegister.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Vendor Payment Register", true, true, true, true, false, true, true, false, false, false, false);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Vendor Payment Register - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("File is not exist...");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Vendor Payment - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }


    }
}
