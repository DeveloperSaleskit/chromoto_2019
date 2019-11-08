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

        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;
        bool valgrid = false;

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
            cmbreports.Items.Add("Sales Invoice Register");
            cmbreports.Items.Add("Sales Invoice Detail Register");
            cmbreports.Items.Add("Retail Invoice");
            cmbreports.Items.Add("Tax Invoice");
            cmbreports.SelectedIndex = 0;

            dgvSalesInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();
            btnClear_Click(sender, e);
            DV = dtblSalesInvoice.DefaultView;
            DV.RowFilter = StrFilter;

            dgvSalesInvoice.DataSource = DV.ToTable();

        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_FYID", CurrentUser.FYID.ToString());

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

        private void ArrangeDataGridView()
        {
            try
            {
                dgvSalesInvoice.Columns["SIID"].DataPropertyName = dtblSalesInvoice.Columns["SIID"].ToString();
                dgvSalesInvoice.Columns["SalesCode"].DataPropertyName = dtblSalesInvoice.Columns["SalesCode"].ToString();
                dgvSalesInvoice.Columns["SalesDate"].DataPropertyName = dtblSalesInvoice.Columns["SalesDate"].ToString();
                dgvSalesInvoice.Columns["CustomerID"].DataPropertyName = dtblSalesInvoice.Columns["CustomerID"].ToString();
                dgvSalesInvoice.Columns["Code"].DataPropertyName = dtblSalesInvoice.Columns["Code"].ToString();
                dgvSalesInvoice.Columns["CustomerName"].DataPropertyName = dtblSalesInvoice.Columns["CustomerName"].ToString();
                dgvSalesInvoice.Columns["DueDays"].DataPropertyName = dtblSalesInvoice.Columns["DueDays"].ToString();
                dgvSalesInvoice.Columns["DueDate"].DataPropertyName = dtblSalesInvoice.Columns["DueDate"].ToString();
                dgvSalesInvoice.Columns["TotalAmount"].DataPropertyName = dtblSalesInvoice.Columns["TotalAmount"].ToString();
                dgvSalesInvoice.Columns["NetAmount"].DataPropertyName = dtblSalesInvoice.Columns["NetAmount"].ToString();
                dgvSalesInvoice.Columns["Narration"].DataPropertyName = dtblSalesInvoice.Columns["Narration"].ToString();
                dgvSalesInvoice.Columns["SrNo"].DataPropertyName = dtblSalesInvoice.Columns["SrNo"].ToString();
                dgvSalesInvoice.Columns["DCDate"].DataPropertyName = dtblSalesInvoice.Columns["DCDate"].ToString();
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


                            CurrentUser.AddReportParameters(rptDoc, dvReport.ToTable(), "Sales Invoice Detail", true, false, false, false, false, false, true, false, false, false, false);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice Detail - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Sales Invoice - Detail Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
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
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                        {
                            //dtReport.TableName = "PurchaseOrder";
                            //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Retail Invoice", true, true, true, true, true, true, true, true, true, true, true);

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

        private void taxInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
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
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptSalesInvoice.rpt"))
                        {
                            //dtReport.TableName = "PurchaseOrder";
                            //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoice.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Tax Invoice", true, true, true, true, true, true, true, true, true, true, true);

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

        #endregion

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblSalesInvoice.DefaultView;
            DV.RowFilter = StrFilter;

            dgvSalesInvoice.DataSource = DV.ToTable();

            frmSalesInvoiceFilter filterSalesinvoice = new frmSalesInvoiceFilter(dtblSalesInvoice);
            filterSalesinvoice.ShowDialog();

            dgvSalesInvoice.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSalesInvoice.RowCount.ToString();

            ArrangeDataGridView();

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
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {

                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_FYID", CurrentUser.FYID.ToString());

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

                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Sales Invoice Register", true, false, false, false, false, false, true, false, false, false, false);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Sales Invoice Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            else if (cmbreports.SelectedIndex == 2)
            {
                rptSalesInvoice_Click(sender, e);
            }
            else if (cmbreports.SelectedIndex == 3)
            {
                salesInvoiceToolStripMenuItem_Click(sender, e);

            }
            else if (cmbreports.SelectedIndex == 4)
            {
                taxInvoiceToolStripMenuItem_Click(sender, e);
            }
            cmbreports.SelectedIndex = 0;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }








    }
}
