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
using Account.Properties;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace Account.GUI.SalesInvoice
{
    public partial class frmSalesInvoiceList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblSalesInvoice = new DataTable();
        DataView DV;
        CommonListBL objList = new CommonListBL();
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        int idgvPosition = 0;
        string StrFilter = "";
        int _CompId = 0;

        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;
        bool valgrid = false;

        Exception mException = null;
        string mErrorMsg = "";
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();

        #endregion

        #region "Form Event"

        public frmSalesInvoiceList()
        {
            InitializeComponent();
        }

        private void frmSalesInvoiceList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {

                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {

                    //if (CurrentUser.PrivilegeStr.IndexOf("#1805#") != -1)
                    //{
                    //    cmbreports.Items.Add("Sales Invoice Register");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1806#") != -1)
                    //{
                    //    cmbreports.Items.Add("Sales Invoice Detail Register");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1807#") != -1)
                    //{
                    //    cmbreports.Items.Add("Retail Invoice");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1808#") != -1)
                    //{
                    //    cmbreports.Items.Add("Tax Invoice");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1809#") != -1)
                    //{
                    //    cmbreports.Items.Add("Estimate");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1810#") != -1)
                    //{
                    //    cmbreports.Items.Add("Delivery Challan");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1811#") != -1)
                    //{
                    //    cmbreports.Items.Add("Proforma Invoice");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1812#") != -1)
                    //{
                    //    cmbreports.Items.Add("Challan cum Tax Invoice");
                    //}


                    //if (CurrentUser.PrivilegeStr.IndexOf("#1805#") != -1)
                    //{
                    //    //cmbreports.Items.Add("Sales Invoice Register");
                    //    cmbreports.Items.Add("Retail Invoice");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1806#") != -1)
                    //{
                    //    //cmbreports.Items.Add("Sales Invoice Detail Register");
                    //    cmbreports.Items.Add("Retail Invoice WithoutHeader");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1807#") != -1)
                    //{
                    //    //cmbreports.Items.Add("Retail Invoice");
                    //    cmbreports.Items.Add("Tax Invoice");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1808#") != -1)
                    //{
                    //    cmbreports.Items.Add("Tax Invoice WithoutHeader");

                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1809#") != -1)
                    //{
                    //    cmbreports.Items.Add("Estimate");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1810#") != -1)
                    //{
                    //    //cmbreports.Items.Add("Delivery Challan");
                    //    cmbreports.Items.Add("Estimate WithoutHeader");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1811#") != -1)
                    //{
                    //    //cmbreports.Items.Add("Proforma Invoice");
                    //    cmbreports.Items.Add("Delivery Challan");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1812#") != -1)
                    //{
                    //    // cmbreports.Items.Add("Challan cum Tax Invoice");
                    //    cmbreports.Items.Add("Delivery Challan WithoutHeader");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1813#") != -1)
                    //{
                    //    cmbreports.Items.Add("Proforma Invoice");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1814#") != -1)
                    //{
                    //    cmbreports.Items.Add("Proforma Invoice WithoutHeader");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1815#") != -1)
                    //{
                    //    cmbreports.Items.Add("Sales Invoice Register");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1816#") != -1)
                    //{
                    //    cmbreports.Items.Add("Sales Invoice Detail Register");
                    //}
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1817#") != -1)
                    //{
                    //    cmbreports.Items.Add("Challan cum Tax Invoice");
                    //}




                    if (CurrentUser.PrivilegeStr.IndexOf("#1805#") != -1)
                    {
                        cmbreports.Items.Add("Retail Invoice");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1806#") != -1)
                    {
                        cmbreports.Items.Add("Tax Invoice");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1807#") != -1)
                    {
                        cmbreports.Items.Add("Estimate");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1808#") != -1)
                    {
                        cmbreports.Items.Add("Delivery Challan");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1809#") != -1)
                    {
                        cmbreports.Items.Add("Proforma Invoice");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1810#") != -1)
                    {
                        cmbreports.Items.Add("Retail Invoice WithoutHeader");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1811#") != -1)
                    {
                        cmbreports.Items.Add("Tax Invoice WithoutHeader");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1812#") != -1)
                    {
                        cmbreports.Items.Add("Estimate WithoutHeader");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1813#") != -1)
                    {
                        cmbreports.Items.Add("Delivery Challan WithoutHeader");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1814#") != -1)
                    {
                        cmbreports.Items.Add("Proforma Invoice WithoutHeader");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1815#") != -1)
                    {
                        cmbreports.Items.Add("Sales Invoice Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1816#") != -1)
                    {
                        cmbreports.Items.Add("Sales Invoice Detail Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#1817#") != -1)
                    {
                        cmbreports.Items.Add("Challan cum Tax Invoice");
                    }
                }
                else
                {

                    //cmbreports.Items.Add("Sales Invoice Register");
                    //cmbreports.Items.Add("Sales Invoice Detail Register");
                    //cmbreports.Items.Add("Retail Invoice");
                    //cmbreports.Items.Add("Tax Invoice");
                    //cmbreports.Items.Add("Estimate");
                    //cmbreports.Items.Add("Delivery Challan");
                    //cmbreports.Items.Add("Proforma Invoice");
                    //cmbreports.Items.Add("Challan cum Tax Invoice");

                    cmbreports.Items.Add("Retail Invoice");
                    cmbreports.Items.Add("Tax Invoice");
                    cmbreports.Items.Add("Estimate");
                    cmbreports.Items.Add("Delivery Challan");
                    cmbreports.Items.Add("Proforma Invoice");
                    cmbreports.Items.Add("Retail Invoice WithoutHeader");
                    cmbreports.Items.Add("Tax Invoice WithoutHeader");
                    cmbreports.Items.Add("Estimate WithoutHeader");
                    cmbreports.Items.Add("Delivery Challan WithoutHeader");
                    cmbreports.Items.Add("Proforma Invoice WithoutHeader");
                    cmbreports.Items.Add("Sales Invoice Register");
                    cmbreports.Items.Add("Sales Invoice Detail Register");
                    cmbreports.Items.Add("Challan cum Tax Invoice");
                }
            }

            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Retail Invoice");
                cmbreports.Items.Add("Tax Invoice");
                cmbreports.Items.Add("Estimate");
                cmbreports.Items.Add("Delivery Challan");
                cmbreports.Items.Add("Proforma Invoice");
                cmbreports.Items.Add("Retail Invoice WithoutHeader");
                cmbreports.Items.Add("Tax Invoice WithoutHeader");
                cmbreports.Items.Add("Estimate WithoutHeader");
                cmbreports.Items.Add("Delivery Challan WithoutHeader");
                cmbreports.Items.Add("Proforma Invoice WithoutHeader");
                cmbreports.Items.Add("Sales Invoice Register");
                cmbreports.Items.Add("Sales Invoice Detail Register");
                cmbreports.Items.Add("Challan cum Tax Invoice");
            }
            cmbreports.SelectedIndex = 0;

            dgvSalesInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();
            btnClear_Click(sender, e);
            DV = dtblSalesInvoice.DefaultView;
            DV.RowFilter = StrFilter;

            dgvSalesInvoice.DataSource = DV.ToTable();

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#1802#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1803#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1804#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                }
            }
            // txtNetAmt.Text = "0.00";
            TotalNetAmount();
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                _CompId = CurrentCompany.CompId;
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());

                dtblSalesInvoice = objList.ListOfRecord("usp_SalesInvoice_List", para, "SalesInvoice - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvSalesInvoice.CurrentRow != null)
                    {
                        idgvPosition = dgvSalesInvoice.CurrentRow.Index;
                    }

                    valgrid = false;
                    ArrangeDataGridView();
                    dgvSalesInvoice.AutoGenerateColumns = false;
                    dgvSalesInvoice.DataSource = dtblSalesInvoice;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSalesInvoice.RowCount.ToString();
                    if (dgvSalesInvoice.CurrentRow != null && idgvPosition <= dgvSalesInvoice.RowCount)
                    {
                        if (dgvSalesInvoice.Rows.Count - 1 < idgvPosition)
                        {
                            dgvSalesInvoice.CurrentCell = dgvSalesInvoice.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvSalesInvoice.CurrentCell = dgvSalesInvoice.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                    valgrid = true;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void
            ArrangeDataGridView()
        {
            try
            {
                dgvSalesInvoice.Columns["SIID"].DataPropertyName = dtblSalesInvoice.Columns["SIID"].ToString();



                dgvSalesInvoice.Columns["SalesCode"].DataPropertyName = dtblSalesInvoice.Columns["SalesCode"].ToString();
                dgvSalesInvoice.Columns["CustInvoiceNo"].DataPropertyName = dtblSalesInvoice.Columns["CustInvoiceNo"].ToString();
                dgvSalesInvoice.Columns["SalesDate"].DataPropertyName = dtblSalesInvoice.Columns["SalesDate"].ToString();
                dgvSalesInvoice.Columns["CustomerName"].DataPropertyName = dtblSalesInvoice.Columns["CustomerName"].ToString();
                dgvSalesInvoice.Columns["TotalAmount"].DataPropertyName = dtblSalesInvoice.Columns["TotalAmount"].ToString();
                dgvSalesInvoice.Columns["NetAmount"].DataPropertyName = dtblSalesInvoice.Columns["NetAmount"].ToString();
                dgvSalesInvoice.Columns["PaidAmount"].DataPropertyName = dtblSalesInvoice.Columns["PaidAmount"].ToString();
                dgvSalesInvoice.Columns["PendingAmount"].DataPropertyName = dtblSalesInvoice.Columns["PendingAmount"].ToString();

                dgvSalesInvoice.Columns["ContactPerson"].DataPropertyName = dtblSalesInvoice.Columns["ContactPerson"].ToString();
                dgvSalesInvoice.Columns["Mobile"].DataPropertyName = dtblSalesInvoice.Columns["Mobile"].ToString();
                dgvSalesInvoice.Columns["Phone1"].DataPropertyName = dtblSalesInvoice.Columns["Phone1"].ToString();
                dgvSalesInvoice.Columns["Email"].DataPropertyName = dtblSalesInvoice.Columns["Email"].ToString();
                dgvSalesInvoice.Columns["Category"].DataPropertyName = dtblSalesInvoice.Columns["Category"].ToString();
                dgvSalesInvoice.Columns["Status"].DataPropertyName = dtblSalesInvoice.Columns["Status"].ToString();
                dgvSalesInvoice.Columns["EmpName"].DataPropertyName = dtblSalesInvoice.Columns["EmpName"].ToString();
                dgvSalesInvoice.Columns["EmpAllTo"].DataPropertyName = dtblSalesInvoice.Columns["EmpAllTo"].ToString();
                dgvSalesInvoice.Columns["InstallationDate"].DataPropertyName = dtblSalesInvoice.Columns["InstallationDate"].ToString();
                dgvSalesInvoice.Columns["ReminderDate"].DataPropertyName = dtblSalesInvoice.Columns["ReminderDate"].ToString();
                dgvSalesInvoice.Columns["DCDate"].DataPropertyName = dtblSalesInvoice.Columns["DCDate"].ToString();
                dgvSalesInvoice.Columns["ExtraReminder"].DataPropertyName = dtblSalesInvoice.Columns["ExtraReminder"].ToString();
                dgvSalesInvoice.Columns["DtExtraReminder"].DataPropertyName = dtblSalesInvoice.Columns["dtExtraReminder"].ToString();
                dgvSalesInvoice.Columns["NoofServices"].DataPropertyName = dtblSalesInvoice.Columns["NoofServices"].ToString();
                dgvSalesInvoice.Columns["CompId"].DataPropertyName = dtblSalesInvoice.Columns["CompId"].ToString();
                //dgvSalesInvoice.Columns["CustomerID"].DataPropertyName = dtblSalesInvoice.Columns["CustomerID"].ToString();
                //dgvSalesInvoice.Columns["Code"].DataPropertyName = dtblSalesInvoice.Columns["Code"].ToString();

                //dgvSalesInvoice.Columns["DueDays"].DataPropertyName = dtblSalesInvoice.Columns["DueDays"].ToString();
                //dgvSalesInvoice.Columns["DueDate"].DataPropertyName = dtblSalesInvoice.Columns["DueDate"].ToString();
                //
                //
                //dgvSalesInvoice.Columns["Narration"].DataPropertyName = dtblSalesInvoice.Columns["Narration"].ToString();
                //dgvSalesInvoice.Columns["SrNo"].DataPropertyName = dtblSalesInvoice.Columns["SrNo"].ToString();
                //
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvSalesInvoice.SortedColumn != null)
                {
                    sortedColumn = dgvSalesInvoice.SortedColumn;
                    sortDirection = dgvSalesInvoice.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();
                DV = dtblSalesInvoice.DefaultView;
                DV.RowFilter = StrFilter;

                dgvSalesInvoice.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSalesInvoice.RowCount.ToString();

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

                    dgvSalesInvoice.Sort(dgvSalesInvoice.Columns[sortedColumn.Name], LSD);
                }
                if (dgvSalesInvoice.CurrentRow != null && idgvPosition <= dgvSalesInvoice.RowCount)
                {
                    if (dgvSalesInvoice.Rows.Count - 1 < idgvPosition)
                    {
                        dgvSalesInvoice.CurrentCell = dgvSalesInvoice.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvSalesInvoice.CurrentCell = dgvSalesInvoice.Rows[idgvPosition].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void TotalNetAmount()
        {
            txtNetAmt.Text = "0.00";
            if (dgvSalesInvoice.RowCount > 0)
            {
                for (int i = 0; i < dgvSalesInvoice.RowCount; i++)
                {
                    txtNetAmt.Text = (Convert.ToDecimal(txtNetAmt.Text) + Convert.ToDecimal(dgvSalesInvoice.Rows[i].Cells["NetAmount"].Value.ToString())).ToString("#.00");
                }
            }
        }

        #endregion

        #region "Button Event"

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //txtFromCode.Text = "";
                //txtFromDate.Text = "";
                //txtTodate.Text = "";
                //dtpFromDate.Value = DateTime.Now;
                //dtpTodate.Value = DateTime.Now;
                //txtSrNo.Text = "";
                //txtCompany.Text = "";
                StrFilter = "";
                LoadList();
                //txtNetAmt.Text = "0.00";
                TotalNetAmount();
                //btnApply_Click(sender, e);
                cmbreports.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmSalesInvoiceEntry fSalesInvoice = new frmSalesInvoiceEntry((int)Constant.Mode.Insert, 0);
                fSalesInvoice.ShowDialog();
                LoadList();

                DV = dtblSalesInvoice.DefaultView;
                DV.RowFilter = StrFilter;

                dgvSalesInvoice.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSalesInvoice.RowCount.ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesInvoice.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmSalesInvoiceEntry fSalesInvoice = new frmSalesInvoiceEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value));
                    fSalesInvoice.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnEdit.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesInvoice.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmSalesInvoiceEntry fSalesInvoice = new frmSalesInvoiceEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value));
                    fSalesInvoice.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnDelete.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvSalesInvoice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvSalesInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvSalesInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox KeyPress Event"

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtFromCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-");
        }

        #endregion

        #region "Report Menu"

        private void rptSalesInvoiceRegister_Click(object sender, EventArgs e)
        {

        }

        private void rptSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSalesInvoice.CurrentRow != null)
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_SIID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                    dtReport = objList.ListOfRecord("rpt_SalesInvoiceDetail", para, "SalesInvoice - Report");
                    DataView DVReport;
                    DVReport = dtReport.DefaultView;
                    DVReport.RowFilter = StrFilter;

                    dgvSalesInvoice.DataSource = DV.ToTable();
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoiceRegisterwithDetail.rpt"))
                        {
                            //dtblSalesInvoice .TableName = "PORegister";
                            //dtblSalesInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoiceRegisterwithDetail.rpt");
                            DataView dvReport = new DataView();
                            dvReport = dtReport.DefaultView;

                            //if (StrFilter != "")
                            //{                               
                            //    dvReport.RowFilter = StrFilter;
                            //}


                            CurrentUser.AddReportParameters(rptDoc, dvReport.ToTable(), "Sales Invoice Detail", true, true, true, true, false, true, true, false, false, false, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice Detail - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice - Detail Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }



        private void salesInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                // LogoBind(dt);
                if (dgvSalesInvoice.CurrentRow != null)
                {

                    DataTable dtTNC = new DataTable();
                    NameValueCollection para2 = new NameValueCollection();
                    para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                    para2.Add("@i_TNC_Sub", "SALES");
                    para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");

                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                    dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                        {
                            //dtReport.TableName = "PurchaseOrder";
                            //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                            rptDoc.Subreports[0].DataSourceConnections.Clear();
                            rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                            rptDoc.Database.Tables[1].SetDataSource(dt);
                            rptDoc.Refresh();

                            if (cbIsProCode.Checked)
                            {
                                //FOR SUPPERSS PRODUCT CODE

                                //suppress header and values
                                //rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = false;
                                //rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = false;

                                ////suppress lines
                                //rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = false;
                                //rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = false;
                                ////Enlarge right side header & values                            

                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 1920;
                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 4080;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 2040;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 3840;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Left = 2190;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Width = 3690;
                                rptDoc.ReportDefinition.ReportObjects["Boxheader"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                                rptDoc.ReportDefinition.ReportObjects["boxfotter"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["footer"].ObjectFormat.EnableSuppress = true;

                            }
                            else
                            {
                                //FOR SUPPERSS PRODUCT CODE

                                //suppress header and values
                                //rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = true;

                                ////suppress lines
                                //rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = true;
                                ////Enlarge right side header & values                            

                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 720;
                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 5280;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 840;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 5025;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Left = 975;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Width = 4905;


                                ////////////////////////header footer supress//////////////////////
                                rptDoc.ReportDefinition.ReportObjects["Boxheader"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                                rptDoc.ReportDefinition.ReportObjects["boxfotter"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["footer"].ObjectFormat.EnableSuppress = true;


                                ///////////////////////////////////////////////////////////////////
                            }



                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Retail Invoice", true, true, true, true, true, true, true, true, true, true, true);
                            CurrentUser.AddExtraParameter(rptDoc);
                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            }
        }


        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = new DataTable();
                LogoBind(dt);
                if (dgvSalesInvoice.CurrentRow != null)
                {

                    DataTable dtTNC = new DataTable();
                    NameValueCollection para2 = new NameValueCollection();
                    para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                    para2.Add("@i_TNC_Sub", "SALES");
                    para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");

                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                    dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                        {
                            //dtReport.TableName = "PurchaseOrder";
                            //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                            rptDoc.Subreports[0].DataSourceConnections.Clear();
                            rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                            rptDoc.Database.Tables[1].SetDataSource(dt);
                            rptDoc.Refresh();

                            if (cbIsProCode.Checked)
                            {
                                //FOR SUPPERSS PRODUCT CODE

                                //suppress header and values
                                //rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = false;
                                //rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = false;

                                //suppress lines
                                // rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = false;
                                // rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = false;
                                //Enlarge right side header & values                            

                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 1920;
                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 4080;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 2040;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 3840;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Left = 2190;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Width = 3690;
                            }
                            else
                            {
                                //FOR SUPPERSS PRODUCT CODE

                                //suppress header and values
                                //rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = true;

                                ////suppress lines
                                //rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = true;
                                ////Enlarge right side header & values                            

                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 720;
                                //((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 5280;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 840;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 5025;

                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Left = 975;
                                //((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemSSpec1"]).Width = 4905;
                            }



                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Retail Invoice", true, true, true, true, true, true, true, true, true, true, true);
                            CurrentUser.AddExtraParameter(rptDoc);
                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            }
        }

        private void salesInvoice2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvSalesInvoice.CurrentRow != null)
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                    dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice2.rpt"))
                        {
                            //dtblSalesInvoice .TableName = "PORegister";
                            //dtblSalesInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice2.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Sales Invoice", true, true, true, true, true, true, true, true, true, true, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice - [Page Size: A4]";
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
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void taxInvoiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                // LogoBind(dt);

                if (dgvSalesInvoice.CurrentRow != null)
                {
                    DataTable dtTNC = new DataTable();
                    NameValueCollection para2 = new NameValueCollection();
                    para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                    para2.Add("@i_TNC_Sub", "SALES");
                    para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");


                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                    dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                        {
                            //dtReport.TableName = "PurchaseOrder";
                            //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                            rptDoc.Subreports[0].DataSourceConnections.Clear();
                            rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                            rptDoc.Database.Tables[1].SetDataSource(dt);
                            rptDoc.Refresh();

                            //////////////////supress headear n fottr//////////////////////////////
                            rptDoc.ReportDefinition.ReportObjects["Boxheader"].ObjectFormat.EnableSuppress = true;
                            //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                            rptDoc.ReportDefinition.ReportObjects["boxfotter"].ObjectFormat.EnableSuppress = true;
                            ///////////////////////////////////////////////////////////
                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Tax Invoice", true, true, true, true, true, true, true, true, true, true, true);
                            CurrentUser.AddExtraParameter(rptDoc);
                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            }
        }


        private void taxInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                LogoBind(dt);

                if (dgvSalesInvoice.CurrentRow != null)
                {
                    DataTable dtTNC = new DataTable();
                    NameValueCollection para2 = new NameValueCollection();
                    para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                    para2.Add("@i_TNC_Sub", "SALES");
                    para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");


                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                    dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                        {
                            //dtReport.TableName = "PurchaseOrder";
                            //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                            rptDoc.Subreports[0].DataSourceConnections.Clear();
                            rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                            rptDoc.Database.Tables[1].SetDataSource(dt);
                            rptDoc.Refresh();
                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Tax Invoice", true, true, true, true, true, true, true, true, true, true, true);
                            CurrentUser.AddExtraParameter(rptDoc);
                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            }
        }

        #endregion

        #region "LOGOBIND"
        public void LogoBind(DataTable dt)
        {
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            // dt.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Header", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Footer", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Sign", System.Type.GetType("System.Byte[]"));
            //dt.TableName = "Logo";
            //dt.WriteXmlSchema(@"D:\ERP-CRM\CRM_ICON\Logo.xsd");
            drow = dt.Rows.Add();
            //FileStream logo;
            FileStream header;
            FileStream footer;
            FileStream sign;
            //BinaryReader brLogo;
            BinaryReader brHeader;
            BinaryReader brFooter;
            BinaryReader brSign;
            //string Logo = CurrentCompany.Logo;
            string Header = CurrentCompany.Header;
            string Footer = CurrentCompany.Footer;
            string Sign = CurrentCompany.Sign;
            //if (File.Exists(Logo))
            //{

            //    logo = new FileStream(Logo, FileMode.Open);
            //}
            //else
            //{
            //    logo = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Srinath.png", FileMode.Open);
            //}


            if (File.Exists(Header))
            {

                header = new FileStream(Header, FileMode.Open);
            }
            else
            {
                header = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Srinath.png", FileMode.Open);
            }

            if (File.Exists(Footer))
            {

                footer = new FileStream(Footer, FileMode.Open);
            }
            else
            {
                footer = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Srinath.png", FileMode.Open);
            }


            if (File.Exists(Sign))
            {

                sign = new FileStream(Sign, FileMode.Open);
            }
            else
            {
                sign = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Sign", FileMode.Open);
            }

            //brLogo = new BinaryReader(logo);
            //byte[] imgbyteLogo = new byte[logo.Length + 1];
            //imgbyteLogo = brLogo.ReadBytes(Convert.ToInt32((logo.Length)));
            //drow[0] = imgbyteLogo;
            //dt.NewRow();
            //brLogo.Close();
            //logo.Close();

            brHeader = new BinaryReader(header);
            byte[] imgbyteHeader = new byte[header.Length + 1];
            imgbyteHeader = brHeader.ReadBytes(Convert.ToInt32((header.Length)));
            drow[0] = imgbyteHeader;
            dt.NewRow();
            brHeader.Close();
            header.Close();


            brFooter = new BinaryReader(footer);
            byte[] imgbyteFooter = new byte[footer.Length + 1];
            imgbyteFooter = brFooter.ReadBytes(Convert.ToInt32((footer.Length)));
            drow[1] = imgbyteFooter;
            dt.NewRow();
            brFooter.Close();
            footer.Close();

            brSign = new BinaryReader(sign);
            byte[] imgbyteSign = new byte[sign.Length + 1];
            imgbyteSign = brSign.ReadBytes(Convert.ToInt32((sign.Length)));
            drow[2] = imgbyteSign;
            dt.NewRow();
            brSign.Close();
            sign.Close();
        }

        #endregion

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblSalesInvoice.DefaultView;
            DV.RowFilter = StrFilter;

            dgvSalesInvoice.DataSource = DV.ToTable();

            frmSalesInvoiceFilter filterSalesinvoice = new frmSalesInvoiceFilter(dtblSalesInvoice);
            filterSalesinvoice.ShowDialog();

            StrFilter = filterSalesinvoice.STRFILTER;
            dgvSalesInvoice.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSalesInvoice.RowCount.ToString();

            ArrangeDataGridView();
            TotalNetAmount();
            //if (grpFilter.Visible == false)
            //{
            //    grpFilter.Visible = true;
            //}
            //else
            //{
            //    grpFilter.Visible = false;
            //}
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////////////////retail invoice//////////////////
            if (cmbreports.SelectedIndex == 1)
            {
                if (dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString().Substring(0, 2) == "RI")
                {
                    salesInvoiceToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Retail Invoice not generated for this sale.");
                }

            }
            ////////////////RETAIL INVOICE WITHOUT HEADER////////////////
            else if (cmbreports.SelectedIndex == 6)
            {
                if (dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString().Substring(0, 2) == "RI")
                {
                    salesInvoiceToolStripMenuItem1_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Retail Invoice not generated for this sale.");
                }

            }
            ////////////////////////////////TAX INVOICE//////////////////////////////////
            else if (cmbreports.SelectedIndex == 2)
            {
                if (dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString().Substring(0, 2) == "TI")
                {
                    taxInvoiceToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Tax Invoice not generated for this sale.");
                }

            }

                /////////////////////////TAX WITHOUT///////////////////
            else if (cmbreports.SelectedIndex == 7)
            {
                if (dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString().Substring(0, 2) == "TI")
                {
                    taxInvoiceToolStripMenuItem1_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Tax Invoice not generated for this sale.");
                }

            }
            ///////////////////ESTIMATE INVOICEEE///////////////////
            else if (cmbreports.SelectedIndex == 3)
            {
                if (dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString().Substring(0, 2) == "ES")
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        LogoBind(dt);

                        if (dgvSalesInvoice.CurrentRow != null)
                        {
                            DataTable dtTNC = new DataTable();
                            NameValueCollection para2 = new NameValueCollection();
                            para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                            para2.Add("@i_TNC_Sub", "SALES");
                            para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                            dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");


                            DataTable dtReport = new DataTable();
                            NameValueCollection para = new NameValueCollection();
                            para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                            dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                            if (objList.Exception == null)
                            {
                                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                                {
                                    //dtReport.TableName = "PurchaseOrder";
                                    //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                                    rptDoc.Subreports[0].DataSourceConnections.Clear();
                                    rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                    rptDoc.Database.Tables[1].SetDataSource(dt);
                                    rptDoc.Refresh();
                                    CurrentUser.AddReportParameters(rptDoc, dtReport, "Estimate", true, true, true, true, true, true, true, true, true, true, true);
                                    CurrentUser.AddExtraParameter(rptDoc);
                                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                    fRptView.Text = "Estimate - [Page Size: A4]";
                                    fRptView.crViewer.ReportSource = rptDoc;
                                    fRptView.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                                }
                            }
                            else
                            {
                                MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
                    }
                }
                else
                {
                    MessageBox.Show("Estimate not generated for this sale.");
                }

            }


                ///////////////////ESTIMATE INVOICEEE WITHOUT///////////////////
            else if (cmbreports.SelectedIndex == 8)
            {
                if (dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString().Substring(0, 2) == "ES")
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        // LogoBind(dt);

                        if (dgvSalesInvoice.CurrentRow != null)
                        {
                            DataTable dtTNC = new DataTable();
                            NameValueCollection para2 = new NameValueCollection();
                            para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                            para2.Add("@i_TNC_Sub", "SALES");
                            para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                            dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");


                            DataTable dtReport = new DataTable();
                            NameValueCollection para = new NameValueCollection();
                            para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                            dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                            if (objList.Exception == null)
                            {
                                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                                {
                                    //dtReport.TableName = "PurchaseOrder";
                                    //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                    rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                                    rptDoc.Subreports[0].DataSourceConnections.Clear();
                                    rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                    rptDoc.Database.Tables[1].SetDataSource(dt);
                                    rptDoc.Refresh();
                                    rptDoc.ReportDefinition.ReportObjects["Boxheader"].ObjectFormat.EnableSuppress = true;
                                    //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                                    rptDoc.ReportDefinition.ReportObjects["boxfotter"].ObjectFormat.EnableSuppress = true;

                                    CurrentUser.AddReportParameters(rptDoc, dtReport, "Estimate", true, true, true, true, true, true, true, true, true, true, true);
                                    CurrentUser.AddExtraParameter(rptDoc);
                                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                    fRptView.Text = "Estimate - [Page Size: A4]";
                                    fRptView.crViewer.ReportSource = rptDoc;
                                    fRptView.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                                }
                            }
                            else
                            {
                                MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
                    }
                }
                else
                {
                    MessageBox.Show("Estimate not generated for this sale.");
                }

            }


                 ///////////////////////DELIVERY CHALLAN ///////////

            else if (cmbreports.SelectedIndex == 4)
            {
                try
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (dgvSalesInvoice.CurrentRow != null)
                    {

                        DataTable dtTNC = new DataTable();
                        NameValueCollection para2 = new NameValueCollection();
                        para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                        para2.Add("@i_TNC_Sub", "SALES");
                        para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                        dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");

                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptDeliveryChallan.rpt"))
                            {
                                //dtReport.TableName = "Logo";
                                //dtReport.WriteXmlSchema(@"D:\ERP-CRM\CRM_ICON\Logo.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptDeliveryChallan.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                //rptDoc.Refresh();
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();
                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Delivery Challan", true, true, true, true, true, true, true, true, true, true, true);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Delivery Challan - [Page Size: A4]";
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
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            ///////////////////////DELIVERY CHALLAN WITHOUT///////////
            else if (cmbreports.SelectedIndex == 9)
            {
                try
                {
                    DataTable dt = new DataTable();
                    //LogoBind(dt);
                    if (dgvSalesInvoice.CurrentRow != null)
                    {

                        DataTable dtTNC = new DataTable();
                        NameValueCollection para2 = new NameValueCollection();
                        para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                        para2.Add("@i_TNC_Sub", "SALES");
                        para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                        dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");

                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptDeliveryChallan.rpt"))
                            {
                                //dtReport.TableName = "Logo";
                                //dtReport.WriteXmlSchema(@"D:\ERP-CRM\CRM_ICON\Logo.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptDeliveryChallan.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                //rptDoc.Refresh();
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();

                                rptDoc.ReportDefinition.ReportObjects["headearbox"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                                rptDoc.ReportDefinition.ReportObjects["footerbox"].ObjectFormat.EnableSuppress = true;

                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Delivery Challan", true, true, true, true, true, true, true, true, true, true, true);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Delivery Challan - [Page Size: A4]";
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
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

                ///////////////////PERFOMA///////////////////
            else if (cmbreports.SelectedIndex == 5)
            {
                try
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (dgvSalesInvoice.CurrentRow != null)
                    {
                        DataTable dtTNC = new DataTable();
                        NameValueCollection para2 = new NameValueCollection();
                        para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                        para2.Add("@i_TNC_Sub", "SALES");
                        para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                        dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");


                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                            {
                                //dtReport.TableName = "PurchaseOrder";
                                //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();

                                //////////////////supress headear n fottr//////////////////////////////
                                rptDoc.ReportDefinition.ReportObjects["Boxheader"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                                rptDoc.ReportDefinition.ReportObjects["boxfotter"].ObjectFormat.EnableSuppress = true;
                                ///////////////////////////////////////////////////////////

                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Proforma Invoice", true, true, true, true, true, true, true, true, true, true, true);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Proforma Invoice - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                            }
                        }
                        else
                        {
                            MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
                }
            }

                 ///////////////////PERFOMA WITHOUT///////////////////
            else if (cmbreports.SelectedIndex == 10)
            {
                try
                {
                    DataTable dt = new DataTable();
                    //LogoBind(dt);
                    if (dgvSalesInvoice.CurrentRow != null)
                    {
                        DataTable dtTNC = new DataTable();
                        NameValueCollection para2 = new NameValueCollection();
                        para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                        para2.Add("@i_TNC_Sub", "SALES");
                        para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                        dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");


                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_SalesInvoice", para, "SalesInvoice - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                            {
                                //dtReport.TableName = "PurchaseOrder";
                                //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();

                                //////////////////supress headear n fottr//////////////////////////////
                                rptDoc.ReportDefinition.ReportObjects["Boxheader"].ObjectFormat.EnableSuppress = true;
                                //rptDoc.ReportDefinition.ReportObjects["Header1"].ObjectFormat.EnableSuppress = true;
                                rptDoc.ReportDefinition.ReportObjects["boxfotter"].ObjectFormat.EnableSuppress = true;
                                ///////////////////////////////////////////////////////////

                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Proforma Invoice", true, true, true, true, true, true, true, true, true, true, true);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Proforma Invoice - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                            }
                        }
                        else
                        {
                            MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
                }
            }


            ///////////////////sales invoice register///////////////////////////
            else if (cmbreports.SelectedIndex == 11)
            {
                try
                {

                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_FYID", CurrentUser.FYID.ToString());
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para.Add("@i_UserId", CurrentUser.UserID.ToString());
                    dtReport = objList.ListOfRecord("rpt_SalesInvoiceRegister", para, "SalesInvoice - Report");
                    DataView DVReport;
                    DVReport = dtReport.DefaultView;
                    DVReport.RowFilter = StrFilter;


                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoiceRegister.rpt"))
                        {
                            //dtblSalesInvoice .TableName = "PORegister";
                            //dtblSalesInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoiceRegister.rpt");
                            //rptDoc.BlankRecords.Height -= (ds.tblItems.Count * 136);
                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Sales Invoice Register", true, true, true, true, false, true, true, false, false, false, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice Register - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
                }
            }
            /////////////sales invoice detail//////////////////
            else if (cmbreports.SelectedIndex == 12)
            {
                rptSalesInvoice_Click(sender, e);
            }


            ///////////////////challan cum text invoice//////////////////////////
            else if (cmbreports.SelectedIndex == 13)
            {
                try
                {
                    if (dgvSalesInvoice.CurrentRow != null)
                    {
                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvSalesInvoice.CurrentRow.Cells["SIID"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_ChallanCumTaxInvoice", para, "SalesInvoice - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptChallanCumTaxInvoice.rpt"))
                            {
                                //dtReport.TableName = "ChallanCumTaxInvoice";
                                //dtReport.WriteXmlSchema(@"D:\ChallanCumTaxInvoice.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptChallanCumTaxInvoice.rpt");
                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Challan Cum Tax Invoice", true, true, true, true, true, true, true, true, true, true, true);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Challan Cum Tax Invoice - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                            }
                        }
                        else
                        {
                            MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            cmbreports.SelectedIndex = 0;
        }




        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

    }
}
