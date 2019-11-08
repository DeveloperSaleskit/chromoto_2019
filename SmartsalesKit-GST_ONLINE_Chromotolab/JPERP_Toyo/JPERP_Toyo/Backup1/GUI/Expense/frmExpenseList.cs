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
using Account.GUI.Employee;
using System.Configuration;

namespace Account.GUI.Expense
{
    public partial class frmExpenseList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblExpense = new DataTable();
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

        public frmExpenseList()
        {
            InitializeComponent();
        }

        private void frmExpenseList_Load(object sender, EventArgs e)
        {

            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {

                    if (CurrentUser.PrivilegeStr.IndexOf("#9038#") != -1)
                    {
                        
                        cmbreports.Items.Add("Expense Register");
                    }

                }
                else
                {
                    cmbreports.Items.Add("Expense Register");
                }
            }

            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Expense Register");
            }
            //cmbreports.Items.Add("Service Vouchar");

            cmbreports.SelectedIndex = 0;




            AddHandlers(this);
            SetControlsDefaults(this);
            dgvExpense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();




            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9035#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9036#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9037#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                }
            }

           // cmbreports.Items.Add("--Select Report--");
           // cmbreports.Items.Add("Expense Register");
            //cmbreports.Items.Add("Expense");            
           // cmbreports.SelectedIndex = 0;

            btnApply_Click(sender, e);
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_FYID", CurrentUser.FYID.ToString());

                dtblExpense = objList.ListOfRecord("usp_Expense_List", para, "Expense - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvExpense.CurrentRow != null)
                    {
                        idgvPosition = dgvExpense.CurrentRow.Index;
                    }

                    valgrid = false;
                    ArrangeDataGridView();
                    dgvExpense.AutoGenerateColumns = false;
                    dgvExpense.DataSource = dtblExpense;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvExpense.RowCount.ToString();
                    if (dgvExpense.CurrentRow != null && idgvPosition <= dgvExpense.RowCount)
                    {
                        if (dgvExpense.Rows.Count - 1 < idgvPosition)
                        {
                            dgvExpense.CurrentCell = dgvExpense.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvExpense.CurrentCell = dgvExpense.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvExpense.Columns["ExpenseID"].DataPropertyName = dtblExpense.Columns["ExpenseID"].ToString();
                dgvExpense.Columns["ExpenseNo"].DataPropertyName = dtblExpense.Columns["ExpNo"].ToString();
                dgvExpense.Columns["ExpenseDate"].DataPropertyName = dtblExpense.Columns["Date"].ToString();
                dgvExpense.Columns["Amount"].DataPropertyName = dtblExpense.Columns["Amount"].ToString();
                dgvExpense.Columns["Narration"].DataPropertyName = dtblExpense.Columns["Narration"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvExpense.SortedColumn != null)
                {
                    sortedColumn = dgvExpense.SortedColumn;
                    sortDirection = dgvExpense.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();
                DV = dtblExpense.DefaultView;
                DV.RowFilter = StrFilter;

                dgvExpense.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvExpense.RowCount.ToString();

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

                    dgvExpense.Sort(dgvExpense.Columns[sortedColumn.Name], LSD);
                }
                if (dgvExpense.CurrentRow != null && idgvPosition <= dgvExpense.RowCount)
                {
                    if (dgvExpense.Rows.Count - 1 < idgvPosition)
                    {
                        dgvExpense.CurrentCell = dgvExpense.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvExpense.CurrentCell = dgvExpense.Rows[idgvPosition].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event"

        private void btnApply_Click(object sender, EventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                
                StrFilter = "";
                LoadList();
                btnApply_Click(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmExpenseEntry fExpense = new frmExpenseEntry((int)Constant.Mode.Insert, 0);
                fExpense.ShowDialog();
                LoadList();

                DV = dtblExpense.DefaultView;
                DV.RowFilter = StrFilter;

                dgvExpense .DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvExpense .RowCount.ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpense.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmExpenseEntry fExpense = new frmExpenseEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvExpense.CurrentRow.Cells["ExpenseID"].Value));
                    fExpense.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnEdit.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpense.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmExpenseEntry fExpense = new frmExpenseEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvExpense.CurrentRow.Cells["ExpenseID"].Value));
                    fExpense.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnDelete.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvExpense_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvExpense, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvExpense, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox KeyPress Event"

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            //Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtFromCode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-");
        }

        #endregion

        #region "Date time picker event"

      
        #endregion

        #region "Report Menu"

        private void rptExpenseRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptExpenseRegister.rpt"))
                {
                    //dtblExpense .TableName = "PORegister";
                    //dtblExpense.WriteXmlSchema(@"D:\Report\PORegister.xsd");

                    DataView DVReport;
                    DVReport = dtblExpense.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptExpenseRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Expense Register", true, true, true, true, false, true, true, false, false, false, true);
                    //rptDoc.SetParameterValue("pFromDate", txtFromDate.Text);
                    //rptDoc.SetParameterValue("pToDate", txtTodate.Text);
                    //if (DataValidator.IsDate(txtFromDate.Text.Trim()) && DataValidator.IsDate(txtTodate.Text.Trim()))
                    //{
                    //    rptDoc.SetParameterValue("pPassDate", true);
                    //}
                    //else
                    //{
                    //    rptDoc.SetParameterValue("pPassDate", false);
                    //}

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Expense Register - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void rptExpense_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpense.CurrentRow != null)
                {
                    DataTable dtReport = new DataTable();

                    dtReport = CommSelect.SelectRecord(Convert.ToInt64(dgvExpense.CurrentRow.Cells["POID"].Value), "rpt_Expense", "Expense - Report");

                    if (CommSelect.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptExpense.rpt"))
                        {
                            //dtReport.TableName = "Expense";
                            //dtReport.WriteXmlSchema(@"D:\Report\Expense.xsd");

                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptExpense.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Expense", true, true, true, true, true, true, true, false, false, false, false);
                            rptDoc.SetParameterValue("pBusinessLine", CurrentCompany.BusinessLine);
                            rptDoc.SetParameterValue("pCST", CurrentCompany.CST);
                            rptDoc.SetParameterValue("pEmail", CurrentCompany.Email);
                            rptDoc.SetParameterValue("pFax", CurrentCompany.Fax);
                            rptDoc.SetParameterValue("pPhone2", CurrentCompany.Phone2);
                            rptDoc.SetParameterValue("PState", CurrentCompany.State);
                            rptDoc.SetParameterValue("pTin", CurrentCompany.TIN);
                            rptDoc.SetParameterValue("pRegAddress1", CurrentCompany.RegAddress1);
                            rptDoc.SetParameterValue("pRegAddress2", CurrentCompany.RegAddress2);
                            rptDoc.SetParameterValue("pRegCity", CurrentCompany.RegCity);
                            rptDoc.SetParameterValue("pRegFax", CurrentCompany.RegFax);
                            rptDoc.SetParameterValue("pRegPhone", CurrentCompany.RegPhone);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Expense - [Page Size: A4]";
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
                        MessageBox.Show(CommSelect.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense - Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptExpenseRegister.rpt"))
                    {
                        //dtblExpense .TableName = "PORegister";
                        //dtblExpense.WriteXmlSchema(@"D:\Report\PORegister.xsd");

                        DataView DVReport;
                        DVReport = dtblExpense.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptExpenseRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Expense Register", true, true, true, true, false, true, true, false, false, false, true);
                        //rptDoc.SetParameterValue("pFromDate", txtFromDate.Text);
                        //rptDoc.SetParameterValue("pToDate", txtTodate.Text);
                        //if (DataValidator.IsDate(txtFromDate.Text.Trim()) && DataValidator.IsDate(txtTodate.Text.Trim()))
                        //{
                        //    rptDoc.SetParameterValue("pPassDate", true);
                        //}
                        //else
                        //{
                        //    rptDoc.SetParameterValue("pPassDate", false);
                        //}

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Expense Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("File is not exist...");
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Expense - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (dgvExpense.CurrentRow != null)
                    {
                        DataTable dtReport = new DataTable();

                        dtReport = CommSelect.SelectRecord(Convert.ToInt64(dgvExpense.CurrentRow.Cells["ExpenseID"].Value), "rpt_Expense", "Expense - Report");

                        if (CommSelect.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptExpense.rpt"))
                            {
                                //dtReport.TableName = "Expense";
                                //dtReport.WriteXmlSchema(@"D:\Report\Expense.xsd");

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptExpense.rpt");

                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Expense", true, true, true, true, true, true, true, false, false, false, false);
                                rptDoc.SetParameterValue("pBusinessLine", CurrentCompany.BusinessLine);
                                rptDoc.SetParameterValue("pCST", CurrentCompany.CST);
                                rptDoc.SetParameterValue("pEmail", CurrentCompany.Email);
                                rptDoc.SetParameterValue("pFax", CurrentCompany.Fax);
                                rptDoc.SetParameterValue("pPhone2", CurrentCompany.Phone2);
                                rptDoc.SetParameterValue("PState", CurrentCompany.State);
                                rptDoc.SetParameterValue("pTin", CurrentCompany.TIN);
                                rptDoc.SetParameterValue("pRegAddress1", CurrentCompany.RegAddress1);
                                rptDoc.SetParameterValue("pRegAddress2", CurrentCompany.RegAddress2);
                                rptDoc.SetParameterValue("pRegCity", CurrentCompany.RegCity);
                                rptDoc.SetParameterValue("pRegFax", CurrentCompany.RegFax);
                                rptDoc.SetParameterValue("pRegPhone", CurrentCompany.RegPhone);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Expense - [Page Size: A4]";
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
                            MessageBox.Show(CommSelect.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Expense - Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblExpense.DefaultView;
            DV.RowFilter = StrFilter;
            dgvExpense.DataSource = DV.ToTable();
            frmExpenseFilter filterSalesinvoice = new frmExpenseFilter(dtblExpense);
            filterSalesinvoice.ShowDialog();
            DataTable dt = DV.ToTable();
            dgvExpense.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvExpense.RowCount.ToString();

            ArrangeDataGridView();
        }

    }
}
