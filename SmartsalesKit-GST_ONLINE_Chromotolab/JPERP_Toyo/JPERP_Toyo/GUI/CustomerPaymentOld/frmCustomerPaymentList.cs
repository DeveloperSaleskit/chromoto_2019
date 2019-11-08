using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Specialized;
using Account.BusinessLogic;
using Account.Common;
using Account.Validator;

namespace Account.GUI.CustomerPayment
{
    public partial class frmCustomerPaymentList : Account.GUIBase
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

        public frmCustomerPaymentList()
        {
            InitializeComponent();
        }

        private void frmCustomerPaymentList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
            cmbreports.Items.Add("--Select Report--");
            cmbreports.Items.Add("Customer Payment Register");
           // cmbreports.Items.Add("Customer Pending Payment Receipt");
            cmbreports.Items.Add("Payment Receipt");
            cmbreports.SelectedIndex = 0;
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {

                ObjDataTable = objList.ListOfRecord("usp_CustomerReceipt_List", null, "Customer Payment - List - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvCustomerPayment.CurrentRow != null)
                    {
                        idgvPosition = dgvCustomerPayment.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvCustomerPayment.AutoGenerateColumns = false;
                    dgvCustomerPayment.DataSource = ObjDataTable;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomerPayment.RowCount.ToString();
                    if (dgvCustomerPayment.CurrentRow != null && idgvPosition <= dgvCustomerPayment.RowCount)
                    {
                        if (dgvCustomerPayment.Rows.Count - 1 < idgvPosition)
                        {
                            dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvCustomerPayment.Columns["ReceiptCode"].DataPropertyName = ObjDataTable.Columns["ReceiptCode"].ToString();
                dgvCustomerPayment.Columns["ReceiptID"].DataPropertyName = ObjDataTable.Columns["ReceiptID"].ToString();
                dgvCustomerPayment.Columns["ReceiptDate"].DataPropertyName = ObjDataTable.Columns["ReceiptDate"].ToString();
                dgvCustomerPayment.Columns["CustomerCode"].DataPropertyName = ObjDataTable.Columns["CustomerCode"].ToString();
                dgvCustomerPayment.Columns["Customer"].DataPropertyName = ObjDataTable.Columns["CustomerName"].ToString();
                dgvCustomerPayment.Columns["NetAmount"].DataPropertyName = ObjDataTable.Columns["NetAmount"].ToString();
                dgvCustomerPayment.Columns["Narration"].DataPropertyName = ObjDataTable.Columns["Narration"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvCustomerPayment.SortedColumn != null)
                {
                    sortedColumn = dgvCustomerPayment.SortedColumn;
                    sortDirection = dgvCustomerPayment.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
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

                dgvCustomerPayment.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomerPayment.RowCount.ToString();

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

                    dgvCustomerPayment.Sort(dgvCustomerPayment.Columns[sortedColumn.Name], LSD);
                }
                if (dgvCustomerPayment.CurrentRow != null && idgvPosition <= dgvCustomerPayment.RowCount)
                {
                    if (dgvCustomerPayment.Rows.Count - 1 < idgvPosition)
                    {
                        dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition].Cells[0];
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button events"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = ObjDataTable.DefaultView;
            DV.RowFilter = StrFilter;
            dgvCustomerPayment.DataSource = DV.ToTable();
            frmCustomerPaymentFilter filterSalesinvoice = new frmCustomerPaymentFilter(ObjDataTable);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            
            DataTable dt = DV.ToTable();
            dgvCustomerPayment.DataSource = DV.ToTable();
            //DataTable dt = DV.ToTable();
            dgvCustomerPayment.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomerPayment.RowCount.ToString();

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
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerPaymentEntry fCustomerPayment = new frmCustomerPaymentEntry((int)Constant.Mode.Insert, 0);
                fCustomerPayment.ShowInTaskbar = false;
                fCustomerPayment.ShowDialog();
                btnClear_Click(sender, e);
                LoadList();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomerPayment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerPaymentEntry fCustomerPayment = new frmCustomerPaymentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvCustomerPayment.CurrentRow.Cells["ReceiptID"].Value));
                    fCustomerPayment.ShowInTaskbar = false;
                    fCustomerPayment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomerPayment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerPaymentEntry fCustomerPayment = new frmCustomerPaymentEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvCustomerPayment.CurrentRow.Cells["ReceiptID"].Value));
                    fCustomerPayment.ShowInTaskbar = false;
                    fCustomerPayment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Datagrid Event"

        private void dgvCustomerPayment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomerPayment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomerPayment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
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



        #region "Report menu..."

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    DataTable dtReport = new DataTable();
                    dtReport = objList.ListOfRecord("rpt_CustomerReceipt", null, "CustomerPayment - Report");
                    
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerPaymentRegister.rpt"))
                        {
                            //ObjDataTable.TableName = "PaymentRegister";
                            //ObjDataTable.WriteXmlSchema(@"D:\PaymentRegister.xsd");
                            DataView DVReport;
                            DVReport = ObjDataTable.DefaultView;
                            DVReport.RowFilter = StrFilter;
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptCustomerPaymentRegister.rpt");

                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Payment Register", true, true, true, true, false, true, true, false, false, false, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Customer Payment Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Customer Payment - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection PARA1 = new NameValueCollection();
                    PARA1.Add("@i_ReceiptID", dgvCustomerPayment.CurrentRow.Cells["ReceiptID"].Value.ToString());
                    dtReport = objList.ListOfRecord("rpt_Customer_Payment_Receipt", PARA1, "CustomerPayment - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerPendingPaymentReceipt.rpt"))
                        {
                            //dtReport.TableName = "PaymentReceipt";
                            //dtReport.WriteXmlSchema(@"D:\PaymentReceipt.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptCustomerPendingPaymentReceipt.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Payment Receipt", true, true, true, true, false, true, true, false, false, false, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Payment Receipt - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Customer Payment - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;
        }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }




    }
}
