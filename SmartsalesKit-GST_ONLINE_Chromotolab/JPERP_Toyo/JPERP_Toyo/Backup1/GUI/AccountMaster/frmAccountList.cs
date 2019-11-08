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

namespace Account.GUI.AccountMaster
{
    public partial class frmAccountMasterList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblAccountMaster = new DataTable();
        DataTable dtblItem = new DataTable();
        DataTable dtblPriceList = new DataTable();

        DataView DV;

        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        int idgvPosition = 0;
        string StrFilter = "";
        bool valAccountMaster = false;
        bool valItem = false;

        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;

        #endregion

        #region "Form Event"

        public frmAccountMasterList()
        {
            InitializeComponent();
        }

        private void frmAccountMasterList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            dgvAccount.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            cmbReports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (CurrentUser.PrivilegeStr.IndexOf("#9022#") != -1)
                {
                    //cmbReports.Items.Add("Account Register");
                    cmbReports.Items.Add("Account Ledger");
                }
                if (CurrentUser.PrivilegeStr.IndexOf("#9023#") != -1)
                {
                    cmbReports.Items.Add("Profit Loss Statement");
                }
                //if (CurrentUser.PrivilegeStr.IndexOf("#1509#") != -1)
                //{
                //    cmbReports.Items.Add("Account Ledger");
                //}
            }
            else if (CurrentUser.UserID == 1)
            {
                //cmbReports.Items.Add("Account Register");
                cmbReports.Items.Add("Account Ledger");
                cmbReports.Items.Add("Profit Loss Statement");
            }
            cmbReports.SelectedIndex = 0;
            //cmbReports.

            LoadList();

        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());



                dtblAccountMaster = objList.ListOfRecord("usp_Account_List", para, "AccountMaster - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvAccount.CurrentRow != null)
                    {
                        idgvPosition = dgvAccount.CurrentRow.Index;
                    }
                    valAccountMaster = false;
                    ArrangeDataGridView();
                    dgvAccount.AutoGenerateColumns = false;
                    dgvAccount.DataSource = dtblAccountMaster;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvAccount.RowCount.ToString();
                    if (dgvAccount.CurrentRow != null && idgvPosition <= dgvAccount.RowCount)
                    {
                        if (dgvAccount.Rows.Count - 1 < idgvPosition)
                        {
                            dgvAccount.CurrentCell = dgvAccount.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvAccount.CurrentCell = dgvAccount.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                    valAccountMaster = true;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvAccount.Columns["AccountID"].DataPropertyName = dtblAccountMaster.Columns["AccountID"].ToString();
                dgvAccount.Columns["AccountCode"].DataPropertyName = dtblAccountMaster.Columns["AccountCode"].ToString();
                dgvAccount.Columns["AccountName"].DataPropertyName = dtblAccountMaster.Columns["AccountName"].ToString();
                dgvAccount.Columns["CRAMount"].DataPropertyName = dtblAccountMaster.Columns["CrAmount"].ToString();
                dgvAccount.Columns["AccTYpeID"].DataPropertyName = dtblAccountMaster.Columns["AccTYpeID"].ToString();
                dgvAccount.Columns["AcountType"].DataPropertyName = dtblAccountMaster.Columns["AcountType"].ToString();
                dgvAccount.Columns["DBAmount"].DataPropertyName = dtblAccountMaster.Columns["DBAmount"].ToString();
                dgvAccount.Columns["ContactPerson"].DataPropertyName = dtblAccountMaster.Columns["ContactPerson"].ToString();
                dgvAccount.Columns["Email"].DataPropertyName = dtblAccountMaster.Columns["Email"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvAccount.SortedColumn != null)
                {
                    sortedColumn = dgvAccount.SortedColumn;
                    sortDirection = dgvAccount.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();
                btnApply_Click(sender, e);

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

                    dgvAccount.Sort(dgvAccount.Columns[sortedColumn.Name], LSD);
                }
                if (dgvAccount.CurrentRow != null && idgvPosition <= dgvAccount.RowCount)
                {
                    if (dgvAccount.Rows.Count - 1 < idgvPosition)
                    {
                        dgvAccount.CurrentCell = dgvAccount.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvAccount.CurrentCell = dgvAccount.Rows[idgvPosition].Cells[0];
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
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
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        //private void btnNew_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        frmAccountMasterEntry fAccountMaster = new frmAccountMasterEntry((int)Constant.Mode.Insert, 0);
        //        fAccountMaster.ShowDialog();
        //        LoadList();
        //        btnApply_Click(sender, e);
        //    }
        //    catch (Exception exc)
        //    {
        //        Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
        //        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
        //    }
        //}

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dgvAccount.CurrentRow != null)
        //        {
        //            SetSortedColumns();
        //            frmAccountMasterEntry fAccountMaster = new frmAccountMasterEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvAccount.CurrentRow.Cells["AccountID"].Value));
        //            fAccountMaster.ShowDialog();
        //            setDefaultGridRecords(sender, e);
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
        //        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
        //    }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dgvAccount.CurrentRow != null)
        //        {
        //            SetSortedColumns();
        //            frmAccountMasterEntry fAccountMaster = new frmAccountMasterEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvAccount.CurrentRow.Cells["AccountID"].Value));
        //            fAccountMaster.ShowDialog();
        //            setDefaultGridRecords(sender, e);
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
        //        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
        //    }
        //}

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvAccount.CurrentRow != null)
            //    {
            //        SetSortedColumns();
            //        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(0, Convert.ToInt64(dgvAccount.CurrentRow.Cells["AccountID"].Value));
            //        fContact.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBillingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.CurrentRow != null)
                {
                    GUI.BillingAddress.frmBillingAddress fBilling = new Account.GUI.BillingAddress.frmBillingAddress(0, Convert.ToInt64(dgvAccount.CurrentRow.Cells["AccountID"].Value));
                    fBilling.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Billing Address", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid View Event"

        private void dgvAccountMaster_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvAccount, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvAccount, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
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
            int ascii = e.KeyChar;
            //Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        #endregion

        #region "Report Menu"

        private void rptAccountMasterRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptAccountMasterRegister.rpt"))
                {
                    //dtblAccountMaster.TableName = "AccountMasterRegister";
                    //dtblAccountMaster.WriteXmlSchema(@"D:\Report\AccountMasterRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblAccountMaster.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptAccountMasterRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "AccountMaster Register", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Account Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("AccountMaster - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void rptMailingLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptAccountMasterMailingLabel.rpt"))
                {
                    //dtblAccountMaster.TableName = "AccountMasterRegister";
                    //dtblAccountMaster.WriteXmlSchema(@"D:\Report\AccountMasterRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblAccountMaster.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptAccountMasterMailingLabel.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "AccountMaster Mailing Label", true, true, true, true, false, true, false, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "AccountMaster Mailing Label - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("AccountMaster - Mailing Label Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void mnuPriceListRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.CurrentRow != null)
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();

                    para.Add("@i_AccountID", dgvAccount.CurrentRow.Cells["AccountID"].Value.ToString());
                    dtReport = objList.ListOfRecord("rpt_AccountMasterPriceListRegister", para, "AccountMaster - PriceList report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPriceList.rpt"))
                        {
                            //dtReport.TableName = "PriceListRegister";
                            //dtReport.WriteXmlSchema(@"D:\Report\PriceListRegister.xsd");

                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptPriceList.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Price List Register", true, true, true, false, false, true, true, false, false, false, false);
                            rptDoc.SetParameterValue("pAccountCode", dgvAccount.CurrentRow.Cells["Code"].Value.ToString());
                            rptDoc.SetParameterValue("pAccountName", dgvAccount.CurrentRow.Cells["Company"].Value.ToString());
                            rptDoc.SetParameterValue("pAccountCity", dgvAccount.CurrentRow.Cells["City"].Value.ToString());
                            rptDoc.SetParameterValue("pAccountPhone", dgvAccount.CurrentRow.Cells["Phone1"].Value.ToString());
                            rptDoc.SetParameterValue("pCST", CurrentCompany.CST);
                            rptDoc.SetParameterValue("pECC", CurrentCompany.ECC);
                            rptDoc.SetParameterValue("pTin", CurrentCompany.TIN);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Price List Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("AccountMaster - PriceList report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void accountLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccount.CurrentRow != null)
                {
                    frmLedgerReport fLedger = new frmLedgerReport((long) dgvAccount.CurrentRow.Cells["AccountID"].Value,1);
                    fLedger.Show();
                }
                else
                {
                    frmLedgerReport fLedger = new frmLedgerReport(0,1);
                    fLedger.Show();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AccountLedger - Ledger", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbReports.SelectedIndex > 0)
                {
                    //if (cmbReports.SelectedIndex == 1)
                    //{
                    //    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptAccountMasterRegister.rpt"))
                    //    {
                    //        //dtblAccountMaster.TableName = "AccountMasterRegister";
                    //        //dtblAccountMaster.WriteXmlSchema(@"D:\Report\AccountMasterRegister.xsd");

                    //        DataView DVReport;
                    //        DVReport = dtblAccountMaster.DefaultView;
                    //        DVReport.RowFilter = StrFilter;
                    //        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //        rptDoc.Load(CurrentUser.ReportPath + "rptAccountMasterRegister.rpt");

                    //        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "AccountMaster Register", true, true, true, true, false, true, true, false, false, false, false);

                    //        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    //        fRptView.Text = "Account Register - [Page Size: A4]";
                    //        fRptView.crViewer.ReportSource = rptDoc;
                    //        fRptView.ShowDialog();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("File is not exist...");
                    //    }
                    //}


                    if (cmbReports.SelectedIndex == 1)
                    {
                        if (dgvAccount.CurrentRow != null)
                        {
                            frmLedgerReport fLedger = new frmLedgerReport((long)dgvAccount.CurrentRow.Cells["AccountID"].Value,1);
                            fLedger.ShowDialog();
                        }
                        else
                        {
                            frmLedgerReport fLedger = new frmLedgerReport(0,1);
                            fLedger.ShowDialog();
                        }
                    }
                    if (cmbReports.SelectedIndex == 2)
                    {
                        if (dgvAccount.CurrentRow != null)
                        {
                            frmLedgerReport fLedger = new frmLedgerReport(0, 2);
                            fLedger.ShowDialog();
                        }
                        else
                        {
                            frmLedgerReport fLedger = new frmLedgerReport(0, 2);
                            fLedger.ShowDialog();
                        }
                    }
                }
                
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AccountMaster - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnReportFilter_Click(object sender, EventArgs e)
        {
            DV = dtblAccountMaster.DefaultView;
            DV.RowFilter = StrFilter;
            dgvAccount.DataSource = DV.ToTable();
            frmAccountFilter filterSalesinvoice = new frmAccountFilter(dtblAccountMaster);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvAccount.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvAccount.RowCount.ToString();

            ArrangeDataGridView();
        }

       
    }
}
