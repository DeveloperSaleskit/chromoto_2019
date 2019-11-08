using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using Account.Validator;
using System.Net;
using System.IO;
using System.Configuration;



namespace Account.GUI.CustomerMain
{
    public partial class frmCustomerMainList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblLead = new DataTable();
        CommonListBL objList = new CommonListBL();
        Account.BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDataAccess = new DataAccess.DataAccess();
        CustomerMainBL objLeadBL = new CustomerMainBL();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        string strFile = "";
        int CompId = 0;
        int _CompId = 0;
        string CODE = "";
        #endregion

        #region

        public frmCustomerMainList()
        {
            InitializeComponent();
        }

        private void frmLeadList_Load(object sender, EventArgs e)
        {
            try
            {

                cmbreports.Items.Add("--Select Report--");
                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#9021#") != -1)
                        {
                            cmbreports.Items.Add("Customer Register");
                        }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9022#") != -1)
                        {
                            cmbreports.Items.Add("Mailing Label");
                        }
                    }
                    else
                    {
                        cmbreports.Items.Add("Customer Register");
                        cmbreports.Items.Add("Mailing Label");
                    }
                }
                else if (CurrentUser.UserID == 1)
                {
                    cmbreports.Items.Add("Customer Register");
                    cmbreports.Items.Add("Mailing Label");
                }
                cmbreports.SelectedIndex = 0;

                AddHandlers(this);
                SetControlsDefaults(this);
                LoadList();
                LoadFollowUpList();

                dgvInquiry.ReadOnly = true;

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#9018#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9019#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9020#") != -1)
                        { btnDelete.Enabled = true; }
                        else { btnDelete.Enabled = false; }
                        //if (CurrentUser.PrivilegeStr.IndexOf("#1505#") != -1)
                        //{ btnFollowUp.Enabled = true; }
                        //else { btnFollowUp.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9023#") != -1)
                        { btnUploadCustomer.Enabled = true; }
                        else { groupBox1.Visible = false; }
                      
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Events"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblLead.DefaultView;
            DV.RowFilter = StrFilter;
            dgvInquiry.DataSource = DV.ToTable();
            frmCustomerMainFilter filterSalesinvoice = new frmCustomerMainFilter(dtblLead);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvInquiry.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvInquiry.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                StrFilter = "";

                cmbreports.SelectedIndex = 0;
                LoadList();
                //btnClear_Click(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerMainEntry fCustomer = new frmCustomerMainEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;
                fCustomer.ShowDialog();
                LoadList();
                LoadFollowUpList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerMainEntry fCustomer = new frmCustomerMainEntry((int)Constant.Mode.Modify, (Int64)dgvInquiry.CurrentRow.Cells["LeadID"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    LoadFollowUpList();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerMainEntry fCustomer = new frmCustomerMainEntry((int)Constant.Mode.Delete, (Int64)dgvInquiry.CurrentRow.Cells["LeadId"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    LoadFollowUpList();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                {
                    SetSortedColumns();
                    string CustName = dgvInquiry.CurrentRow.Cells["CustomerName"].Value.ToString();
                    string LeadDate = Convert.ToDateTime(dgvInquiry.CurrentRow.Cells["LeadDate"].Value.ToString()).ToShortDateString();
                    string folloupDate = Convert.ToDateTime(dgvInquiry.CurrentRow.Cells["NextFollowUpDate"].Value.ToString()).ToShortDateString();
                    frmCustomerMainFollowup fCustomer = new frmCustomerMainFollowup((Int64)dgvInquiry.CurrentRow.Cells["LeadId"].Value, dgvInquiry.CurrentRow.Cells["LeadNo"].Value.ToString(), LeadDate, CustName, folloupDate);
                    fCustomer.ShowInTaskbar = false;
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    LoadFollowUpList();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para1.Add("@i_UserID", CurrentUser.UserID.ToString());

                dtblLead = objList.ListOfRecord("usp_CustomerMain_List", para1, "CustomerMain -List");
                if (objList.Exception == null)
                {
                    if (dgvInquiry.CurrentRow != null)
                    {
                        idgvPosition = dgvInquiry.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvInquiry.AutoGenerateColumns = false;
                    dgvInquiry.DataSource = dtblLead;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvInquiry.RowCount.ToString();
                    if (dgvInquiry.CurrentRow != null && idgvPosition <= dgvInquiry.RowCount)
                    {
                        if (dgvInquiry.Rows.Count - 1 < idgvPosition)
                        {
                            dgvInquiry.CurrentCell = dgvInquiry.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvInquiry.CurrentCell = dgvInquiry.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadFollowUpList()
        {

        }

        private void ArrangeDataGridView()
        {
            try
            {
                //dgvInquiry.Columns[0].DataPropertyName = dtblLead.Columns["LeadDate"].ToString();
                //dgvInquiry.Columns[1].DataPropertyName = dtblLead.Columns["LeadId"].ToString();
                //dgvInquiry.Columns[2].DataPropertyName = dtblLead.Columns["LeadNo"].ToString();
                //dgvInquiry.Columns[3].DataPropertyName = dtblLead.Columns["CustomerName"].ToString();
                //dgvInquiry.Columns[4].DataPropertyName = dtblLead.Columns["Phone1"].ToString();                

                //dgvInquiry.Columns[12].DataPropertyName = dtblLead.Columns["Value2"].ToString();
                //dgvInquiry.Columns[13].DataPropertyName = dtblLead.Columns["Value3"].ToString();
                //dgvInquiry.Columns[14].DataPropertyName = dtblLead.Columns["Value4"].ToString();
                //dgvInquiry.Columns[15].DataPropertyName = dtblLead.Columns["Value5"].ToString();
                //dgvInquiry.Columns[16].DataPropertyName = dtblLead.Columns["Value6"].ToString();

                //dgvInquiry.Columns[5].DataPropertyName = dtblLead.Columns["SourceOfLead"].ToString();
                //dgvInquiry.Columns[6].DataPropertyName = dtblLead.Columns["CustomerBudget"].ToString();
                //dgvInquiry.Columns[7].DataPropertyName = dtblLead.Columns["InterestLevel"].ToString();
                //dgvInquiry.Columns[8].DataPropertyName = dtblLead.Columns["NextFollowUpDate"].ToString();
                //dgvInquiry.Columns[9].DataPropertyName = dtblLead.Columns["Specification"].ToString();
                //dgvInquiry.Columns[10].DataPropertyName = dtblLead.Columns["LeadStatus"].ToString();
                //dgvInquiry.Columns[11].DataPropertyName = dtblLead.Columns["LeadBy"].ToString();
                dgvInquiry.Columns["LeadId"].DataPropertyName = dtblLead.Columns["CustomerID"].ToString();
                dgvInquiry.Columns["CustomerCode"].DataPropertyName = dtblLead.Columns["CustomerCode"].ToString();
                dgvInquiry.Columns["CustomerName"].DataPropertyName = dtblLead.Columns["CustomerName"].ToString();
                dgvInquiry.Columns["ContactPerson"].DataPropertyName = dtblLead.Columns["ContactPerson"].ToString();
                dgvInquiry.Columns["Phone1"].DataPropertyName = dtblLead.Columns["Phone1"].ToString();
                dgvInquiry.Columns["Mobile"].DataPropertyName = dtblLead.Columns["MobileNo"].ToString();
                dgvInquiry.Columns["Email"].DataPropertyName = dtblLead.Columns["Email"].ToString();
                //dgvInquiry.Columns["Specification"].DataPropertyName = dtblLead.Columns["Specification"].ToString();
                //dgvInquiry.Columns["Category"].DataPropertyName = dtblLead.Columns["Category"].ToString();
                //dgvInquiry.Columns["Remarks"].DataPropertyName = dtblLead.Columns["Remarks"].ToString();               
                dgvInquiry.Columns["CompId1"].DataPropertyName = dtblLead.Columns["CompId"].ToString();
                dgvInquiry.Columns["CustomerCode"].Width = 400;
                dgvInquiry.Columns["CustomerName"].Width = 400;
                dgvInquiry.Columns["ContactPerson"].Width = 400;
                dgvInquiry.Columns["Mobile"].Width = 300;
                dgvInquiry.Columns["Email"].Width = 400;

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            if (dgvInquiry.SortedColumn != null)
            {
                sortedColumn = dgvInquiry.SortedColumn;
                sortDirection = dgvInquiry.SortOrder;
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            LoadList();
            btnClear_Click(sender, e);
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

                dgvInquiry.Sort(dgvInquiry.Columns[sortedColumn.Name], LSD);
            }
            if (dgvInquiry.CurrentRow != null && idgvPosition <= dgvInquiry.RowCount)
            {
                if (dgvInquiry.Rows.Count - 1 < idgvPosition)
                {
                    dgvInquiry.CurrentCell = dgvInquiry.Rows[idgvPosition - 1].Cells[0];
                }
                else
                {
                    dgvInquiry.CurrentCell = dgvInquiry.Rows[idgvPosition].Cells[0];
                }
            }

        }

        #endregion

        #region "Datagrid Events"

        private void dgvBuilding_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvInquiry, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvInquiry, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvInquiry_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                    LoadFollowUpList();
                //else
                //dgvFollwUps.DataSource = null;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("LeadFollowUp - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvInquiry_Sorted(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                    LoadFollowUpList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("LeadFollowUp - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvFollwUps_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //if (e.RowIndex == -1)
                //{
                //    GridDrawCustomHeaderColumns(dgvFollwUps, e, Properties.Resources.Button_Gray_Stripe_01_050);
                //}
                //if (e.ColumnIndex == -1)
                //{
                //    GridDrawCustomHeaderColumns(dgvFollwUps, e, Properties.Resources.Button_Gray_Stripe_01_050);
                //}
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("FollwUps-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region Date Event

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-,.");
        }

        #endregion



        #region "Report"
        private void mnuCustomerRegister_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnUploadCustomer_Click(object sender, EventArgs e)
        {
            strFile = CurrentUser.DocumentPath + @"Upload\Customer.xls";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(strFile, CurrentUser.DocumentPath + "Customer.xls");
                //webClient.DownloadFile(strFile, CurrentUser.DocumentPath + "Lead.xls");
            }
            //MessageBox.Show("Your File Save on following Path - " + "D:\\Lead.xls");
            MessageBox.Show("Your File Save on following Path - " + CurrentUser.DocumentPath + "Customer.xls");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerRegister.rpt"))
                    {
                        //dtblCustomer.TableName = "CustomerRegister";
                        //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblLead.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptCustomerRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Register", true, true, true, true, false, true, false, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Customer Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Customer- Register", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerMailingLabel.rpt"))
                    {
                        //dtblCustomer.TableName = "CustomerRegister";
                        //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblLead.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptCustomerMailingLabel.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Mailing Label", true, true, true, true, false, true, false, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Customer Mailing Label - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Customer- Mailing Label", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            //------------------------
            //try
            //{

            //    if (cmbreports.SelectedIndex > 0)
            //    {

            //        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptLeadRegister.rpt"))
            //        {
            //            //dtblLead.TableName = "LeadRegister";
            //            //dtblLead.WriteXmlSchema(@"E:\SharedFile\LeadRegister.xsd");

            //            DataView DVReport;
            //            DVReport = dtblLead.DefaultView;
            //            DVReport.RowFilter = StrFilter;
            //            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //            rptDoc.Load(CurrentUser.ReportPath + "rptLeadRegister.rpt");

            //            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Inquiry Register", true, true, true, true, false, true, true, false, false, false, true);

            //            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
            //            fRptView.Text = "Inquiry Register - [Page Size: A4]";
            //            fRptView.crViewer.ReportSource = rptDoc;
            //            fRptView.ShowDialog();          


            //        }
            //        else
            //        {
            //            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
            //        }
            //    }

            //    cmbreports.SelectedIndex = 0;

            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("User - Register", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }





        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string ExcelFile = "";
                string SelectedFileName = "";

                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    ExcelFile = ofd.SafeFileName;
                    SelectedFileName = ofd.FileName;


                    objDataAccess.Upload("Temp_Customer", SelectedFileName);

                    DataTable dtblCustomerImport = new DataTable();
                    dtblCustomerImport = objList.ListOfRecord("usp_Import_Customer_List", null, "Import Customer - LoadList");

                    for (int i = 0; i < dtblCustomerImport.Rows.Count; i++)
                    {
                        Int16 CityID;
                        int IsAccount = 1;
                        int CREADITDAYS;
                        decimal CRAMOUNT, DBAMOUNT;
                        DateTime TRANSDATE;

                        DataTable dtMaxCode = new DataTable();
                        dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code", null, "MAX Customer - LoadList");

                        if (dtMaxCode.Rows[0][0].ToString() == null || dtMaxCode.Rows[0][0].ToString().Trim() == "")
                        {
                            CODE = "CUST-00001";
                        }
                        else
                        {
                            CODE = "CUST-" + (Convert.ToInt16(dtMaxCode.Rows[0][0].ToString().Substring(5, 5).TrimStart('0')) + 1).ToString().PadLeft(5, '0');
                        }

                        DataTable dtCityId = new DataTable();
                        NameValueCollection ParaCity = new NameValueCollection();
                        ParaCity.Add("@i_City", dtblCustomerImport.Rows[i]["CITY"].ToString());
                        dtCityId = objList.ListOfRecord("usp_Select_CityID", ParaCity, "City Customer - LoadList");
                        if (dtCityId.Rows.Count > 0)
                        {
                            CityID = Convert.ToInt16(dtCityId.Rows[0][0].ToString());
                        }
                        else
                        {
                            CityID = 0;
                        }

                        if (dtblCustomerImport.Rows[i]["CREADITDAYS"].ToString() == null || dtblCustomerImport.Rows[i]["CREADITDAYS"].ToString().Trim() == "")
                        {
                            CREADITDAYS = 0;
                        }
                        else
                        {
                            CREADITDAYS = Convert.ToInt16(dtblCustomerImport.Rows[i]["CREADITDAYS"].ToString());
                        }

                        if (dtblCustomerImport.Rows[i]["TRANSDATE"].ToString() == null || dtblCustomerImport.Rows[i]["TRANSDATE"].ToString().Trim() == "")
                        {
                            TRANSDATE = Convert.ToDateTime(System.DateTime.Now.Date);
                        }
                        else
                        {
                            TRANSDATE = Convert.ToDateTime(dtblCustomerImport.Rows[i]["TRANSDATE"].ToString());
                        }

                        if (dtblCustomerImport.Rows[i]["CRAMOUNT"].ToString() == null || dtblCustomerImport.Rows[i]["CRAMOUNT"].ToString().Trim() == "")
                        {
                            CRAMOUNT = 0;
                        }
                        else
                        {
                            CRAMOUNT = Convert.ToDecimal(dtblCustomerImport.Rows[i]["CRAMOUNT"].ToString());
                        }
                        if (dtblCustomerImport.Rows[i]["DBAMOUNT"].ToString() == null || dtblCustomerImport.Rows[i]["DBAMOUNT"].ToString().Trim() == "")
                        {
                            DBAMOUNT = 0;
                        }
                        else
                        {
                            DBAMOUNT = Convert.ToDecimal(dtblCustomerImport.Rows[i]["DBAMOUNT"].ToString());
                        }

                        //objLeadBL.Insert(("CUST-" + (Convert.ToInt16(dtMaxCode.Rows[0][0]) + 1).ToString().PadLeft(5, '0')),
                        //      dtblCustomerImport.Rows[i]["COMPANY"].ToString(),
                        //      dtblCustomerImport.Rows[i]["ADDRESS1"].ToString(),
                        //      dtblCustomerImport.Rows[i]["ADDRESS2"].ToString(),
                        //      (long)CityID,
                        //      dtblCustomerImport.Rows[i]["PINCODE"].ToString(),
                        //      dtblCustomerImport.Rows[i]["PHONE1"].ToString(),
                        //      dtblCustomerImport.Rows[i]["PHONE2"].ToString(),
                        //      dtblCustomerImport.Rows[i]["EMAIL"].ToString(),
                        //      dtblCustomerImport.Rows[i]["MOBILE"].ToString(),
                        //      dtblCustomerImport.Rows[i]["TINNO"].ToString(),
                        //      dtblCustomerImport.Rows[i]["CSTNO"].ToString(),
                        //      dtblCustomerImport.Rows[i]["PANO"].ToString(),
                        //      dtblCustomerImport.Rows[i]["ECCNO"].ToString(),
                        //      dtblCustomerImport.Rows[i]["RANGE"].ToString(),
                        //      dtblCustomerImport.Rows[i]["DIVISION"].ToString(),
                        //      CREADITDAYS,
                        //      TRANSDATE,
                        //      CRAMOUNT,
                        //      DBAMOUNT,
                        //      IsAccount,
                        //      0,
                        //      dtblCustomerImport.Rows[i]["CONTACTPERSON"].ToString());

                        //--------------------------------

                        objLeadBL.Insert(CODE,
                                                        dtblCustomerImport.Rows[i]["COMPANY"].ToString(),
                                                        dtblCustomerImport.Rows[i]["ADDRESS1"].ToString(),
                                                        CityID,
                                                        dtblCustomerImport.Rows[i]["PINCODE"].ToString(),
                                                        dtblCustomerImport.Rows[i]["PHONE1"].ToString(),
                                                        dtblCustomerImport.Rows[i]["MOBILE"].ToString(),
                                                        dtblCustomerImport.Rows[i]["EMAIL"].ToString(),
                                                        "", "", "", "", "", "", "", "", "", "", "", "",
                                                        "",
                                                        "",
                            //dtblCustomerImport.Rows[i]["SPECIFICATION"].ToString(),
                            //dtblCustomerImport.Rows[i]["REMARKS"].ToString(),
                                                        dtblCustomerImport.Rows[i]["CONTACTPERSON"].ToString(),
                                                        0,
                                                        "",
                            //dtblCustomerImport.Rows[i]["WEBSITE"].ToString(),
                                                        "",
                                                        1,
                                                        0,
                                                       1,
                                                        CREADITDAYS,
                                                        TRANSDATE,
                                                        CRAMOUNT,
                                                        DBAMOUNT
                                                        );

                    }

                    MessageBox.Show("Data Uploded Successfully..!!");
                    LoadList();


                }
                

                           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvInquiry.CurrentRow != null)
            //    {
            //        SetSortedColumns();
            //        Account.GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(0, (Int64)dgvInquiry.CurrentRow.Cells["LeadId"].Value);
            //        fContact.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

    }
}
