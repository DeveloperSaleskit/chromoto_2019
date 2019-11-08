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



namespace Account.GUI.CustomerFollowup
{
    public partial class frmCustomerFollowupList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblLead = new DataTable();
        CommonListBL objList = new CommonListBL();
        Account.BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDataAccess = new DataAccess.DataAccess();
        LeadBL objLeadBL = new LeadBL();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        string strFile = "";
        int CompId=0;
        int _CompId = 0;
        string CODE = "";
        #endregion

        #region

        public frmCustomerFollowupList()
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
                        if (CurrentUser.PrivilegeStr.IndexOf("#2803#") != -1)
                        {
                            cmbreports.Items.Add("Customer Followup Register");
                        }
                    }
                    else
                    {
                        cmbreports.Items.Add("Customer Followup Register");
                    }
                }
                else if (CurrentUser.UserID == 1)
                {
                    cmbreports.Items.Add("Customer Followup Register");
                }
                cmbreports.SelectedIndex = 0;

                AddHandlers(this);
                SetControlsDefaults(this);
                LoadList();
                LoadFollowUpList();
                dgvFollwUps.ReadOnly = true;
                dgvInquiry.ReadOnly = true;

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#1502#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#1503#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#1504#") != -1)
                        { btnDelete.Enabled = true; }
                        else { btnDelete.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#2802#") != -1)
                        { btnFollowUp.Enabled = true; }
                        else { btnFollowUp.Enabled = false; }

                        if (CurrentUser.PrivilegeStr.IndexOf("#1506#") != -1)
                        { btnUploadCustomer.Enabled = true; }
                        else { btnUploadCustomer.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#1507#") != -1)
                        { btnImport.Enabled = true; }
                        else { btnImport.Enabled = false; }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead - List", exc.StackTrace);
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
            CustomerFollowup.frmCustomerFollowupFilter filterSalesinvoice = new frmCustomerFollowupFilter(dtblLead);
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
                dgvFollwUps.DataSource = null;
                cmbreports.SelectedIndex = 0;
                LoadList();
                //btnClear_Click(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    frmLeadEntry fCustomer = new frmLeadEntry((int)Constant.Mode.Insert, 0);
            //    fCustomer.ShowInTaskbar = false;
            //    fCustomer.ShowDialog();
            //    LoadList();
            //    LoadFollowUpList();
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Lead", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvInquiry.CurrentRow != null)
            //    {
            //        SetSortedColumns();
            //        frmLeadEntry fCustomer = new frmLeadEntry((int)Constant.Mode.Modify, (Int64)dgvInquiry.CurrentRow.Cells["LeadId"].Value);
            //        fCustomer.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //        LoadFollowUpList();
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvInquiry.CurrentRow != null)
            //    {
            //        SetSortedColumns();
            //        frmLeadEntry fCustomer = new frmLeadEntry((int)Constant.Mode.Delete, (Int64)dgvInquiry.CurrentRow.Cells["LeadId"].Value);
            //        fCustomer.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //        LoadFollowUpList();
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
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
                    string LeadDate1 = Convert.ToDateTime(dgvInquiry.CurrentRow.Cells["LeadDate"].Value.ToString()).ToShortDateString();
                    string folloupDate1 = Convert.ToDateTime(dgvInquiry.CurrentRow.Cells["NextFollowUpDate"].Value.ToString()).ToShortDateString();
                    CustomerFollowup.frmCustomerFollowup fCustomer = new CustomerFollowup.frmCustomerFollowup(Convert.ToInt64(dgvInquiry.CurrentRow.Cells["LeadId"].Value.ToString()), dgvInquiry.CurrentRow.Cells["LeadNo"].Value.ToString(), LeadDate1.ToString(), CustName, folloupDate1.ToString());
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

                dtblLead = objList.ListOfRecord("usp_CustomerFollowup_List", para1, "Customer Followup -List");
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
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadFollowUpList()
        {
            try
            {
                if (dgvInquiry.CurrentRow == null)
                    return;
                DataTable dtFollowUps = new DataTable();
                NameValueCollection Paralist = new NameValueCollection();
                Paralist.Add("@i_LeadID", dgvInquiry.CurrentRow.Cells["LeadId"].Value.ToString());
                dtFollowUps = objList.ListOfRecord("usp_CustomerFFollowUp_List", Paralist, "CustomerFollowUp -List");
                if (objList.Exception == null)
                {

                    dgvFollwUps.Columns["FollowupDate"].DataPropertyName = dtFollowUps.Columns["FollowupDate"].ToString();
                    dgvFollwUps.Columns["LeadFollowUpId"].DataPropertyName = dtFollowUps.Columns["CustomerFollowUpId"].ToString();
                    dgvFollwUps.Columns["FollowupByName"].DataPropertyName = dtFollowUps.Columns["FollowupByName"].ToString();
                    dgvFollwUps.Columns["Remarks"].DataPropertyName = dtFollowUps.Columns["Remarks"].ToString();
                    dgvFollwUps.AutoGenerateColumns = false;
                    dgvFollwUps.DataSource = dtFollowUps;
                    dgvFollwUps.Columns["FollowupDate"].DataPropertyName = dtFollowUps.Columns["FollowupDate"].ToString();
                    dgvFollwUps.Columns["LeadFollowUpId"].DataPropertyName = dtFollowUps.Columns["CustomerFollowUpId"].ToString();
                    dgvFollwUps.Columns["FollowupByName"].DataPropertyName = dtFollowUps.Columns["FollowupByName"].ToString();
                    dgvFollwUps.Columns["Remarks"].DataPropertyName = dtFollowUps.Columns["Remarks"].ToString();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Followup-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
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
                dgvInquiry.Columns["LeadId"].DataPropertyName = dtblLead.Columns["LeadId"].ToString();
                dgvInquiry.Columns[0].DataPropertyName = dtblLead.Columns["LeadNo"].ToString();
                dgvInquiry.Columns[1].DataPropertyName = dtblLead.Columns["LeadDate"].ToString();
                dgvInquiry.Columns[2].DataPropertyName = dtblLead.Columns["CustomerName"].ToString();
                dgvInquiry.Columns[3].DataPropertyName = dtblLead.Columns["ContactPerson"].ToString();
                dgvInquiry.Columns[4].DataPropertyName = dtblLead.Columns["Phone"].ToString();
                dgvInquiry.Columns[5].DataPropertyName = dtblLead.Columns["Mobile"].ToString();
                dgvInquiry.Columns[6].DataPropertyName = dtblLead.Columns["Email"].ToString();
                //dgvInquiry.Columns[7].DataPropertyName = dtblLead.Columns["Specification"].ToString();
                //dgvInquiry.Columns[8].DataPropertyName = dtblLead.Columns["Category"].ToString();
                //dgvInquiry.Columns[9].DataPropertyName = dtblLead.Columns["SourceOfLead"].ToString();
                //dgvInquiry.Columns[10].DataPropertyName = dtblLead.Columns["LeadStatus"].ToString();                
                //dgvInquiry.Columns[11].DataPropertyName = dtblLead.Columns["Remarks"].ToString();
                //dgvInquiry.Columns[12].DataPropertyName = dtblLead.Columns["EmpName"].ToString();
                //dgvInquiry.Columns[13].DataPropertyName = dtblLead.Columns["EmpAllTo"].ToString();
                dgvInquiry.Columns["NextFollowUpDate"].DataPropertyName = dtblLead.Columns["NextFollowUpDate"].ToString();
                //dgvInquiry.Columns["CompId1"].DataPropertyName = dtblLead.Columns["CompId"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvInquiry_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                    LoadFollowUpList();
                else
                    dgvFollwUps.DataSource = null;
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
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvFollwUps, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvFollwUps, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
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
            strFile = CurrentUser.DocumentPath + @"Upload\Lead.xls";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(strFile, CurrentUser.DocumentPath + "Lead.xls");
                //webClient.DownloadFile(strFile, CurrentUser.DocumentPath + "Lead.xls");
            }
            //MessageBox.Show("Your File Save on following Path - " + "D:\\Lead.xls");
            MessageBox.Show("Your File Save on following Path - " + CurrentUser.DocumentPath + "Lead.xls");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbreports.SelectedIndex > 0)
                {

                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptLeadRegister.rpt"))
                    {
                        //dtblLead.TableName = "LeadRegister";
                        //dtblLead.WriteXmlSchema(@"E:\SharedFile\LeadRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblLead.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptLeadRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Followup Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Inquiry Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();          
                                

                    }
                    else
                    {
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }

                cmbreports.SelectedIndex = 0;

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
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
                    if (result == DialogResult.OK) // Test result.
                    {
                        ExcelFile = ofd.SafeFileName;
                        SelectedFileName = ofd.FileName;
                    }

                    objDataAccess.Upload("Temp_Lead", SelectedFileName);

                    DataTable dtblImport = new DataTable();
                    dtblImport = objList.ListOfRecord("usp_Import_Lead_List", null, "Import Vendor - LoadList");
                    if (ExcelFile.ToString() == "Lead.xls")
                    {
                        for (int i = 0; i < dtblImport.Rows.Count; i++)
                        {
                            if (dtblImport.Rows[i]["CUSTOMER_NAME"].ToString().Trim() != "" && dtblImport.Rows[i]["CUSTOMER_NAME"].ToString() != null)
                            {
                                Int16 CityID;
                                //bool QUOTATION_SEND = false;
                                bool INQUIRY_AUTORESPONSE = false;
                                DateTime LEAD_DATE, NEXT_FOLLOWUP_DATE;
                                decimal CUSTOMER_BUDGET;
                                string CODE = "";
                                DataTable dtMaxCode = new DataTable();
                                dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code_Lead", null, "MAX Lead - LoadList");
                                if (dtMaxCode.Rows[0][0].ToString() == null || dtMaxCode.Rows[0][0].ToString().Trim() == "")
                                {
                                    CODE = "INQ-00001";
                                }
                                else
                                {
                                    CODE = "INQ-" + (Convert.ToInt16(dtMaxCode.Rows[0][0].ToString().Substring(4, 5).TrimStart('0')) + 1).ToString().PadLeft(5, '0');
                                }

                                DataTable dtCityId = new DataTable();
                                NameValueCollection ParaCity = new NameValueCollection();
                                ParaCity.Add("@i_City", dtblImport.Rows[i]["CITY"].ToString());
                                dtCityId = objList.ListOfRecord("usp_Select_CityID", ParaCity, "City Customer - LoadList");
                                if (dtCityId.Rows.Count > 0)
                                {
                                    CityID = Convert.ToInt16(dtCityId.Rows[0][0].ToString());
                                }
                                else
                                {
                                    CityID = 0;
                                }

                                //if (dtblImport.Rows[i]["QUOTATION_SEND"].ToString() == null || dtblImport.Rows[i]["QUOTATION_SEND"].ToString().Trim() == "")
                                //{
                                //    QUOTATION_SEND = false;
                                //}
                                //else
                                //{
                                //    if (dtblImport.Rows[i]["QUOTATION_SEND"].ToString() == "Yes")
                                //    {
                                //        QUOTATION_SEND = true;
                                //    }
                                //}

                                //if (dtblImport.Rows[i]["INQUIRY_AUTORESPONSE"].ToString() == null || dtblImport.Rows[i]["INQUIRY_AUTORESPONSE"].ToString().Trim() == "")
                                //{
                                //    INQUIRY_AUTORESPONSE = false;
                                //}
                                //else
                                //{
                                //    if (dtblImport.Rows[i]["INQUIRY_AUTORESPONSE"].ToString() == "Yes")
                                //    {
                                //        INQUIRY_AUTORESPONSE = true;
                                //    }
                                //}

                                if (dtblImport.Rows[i]["LEAD_DATE"].ToString() == null || dtblImport.Rows[i]["LEAD_DATE"].ToString().Trim() == "")
                                {
                                    LEAD_DATE = System.DateTime.Now.Date;
                                }
                                else
                                {
                                    if (dtblImport.Rows[i]["LEAD_DATE"].ToString().Length == 10)
                                    {
                                        LEAD_DATE = Convert.ToDateTime(dtblImport.Rows[i]["LEAD_DATE"].ToString());
                                    }
                                    else
                                    {
                                        LEAD_DATE = System.DateTime.Now.Date;
                                    }
                                }

                                if (dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString() == null || dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString().Trim() == "")
                                {
                                    NEXT_FOLLOWUP_DATE = System.DateTime.Now.Date;
                                }
                                else
                                {
                                    if (dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString().Length == 10)
                                    {
                                        NEXT_FOLLOWUP_DATE = Convert.ToDateTime(dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString());
                                    }
                                    else
                                    {
                                        NEXT_FOLLOWUP_DATE = System.DateTime.Now.Date;
                                    }
                                }

                                if (dtblImport.Rows[i]["CUSTOMER_BUDGET"].ToString() == null || dtblImport.Rows[i]["CUSTOMER_BUDGET"].ToString().Trim() == "")
                                {
                                    CUSTOMER_BUDGET = 0;
                                }
                                else
                                {
                                    CUSTOMER_BUDGET = Convert.ToDecimal(dtblImport.Rows[i]["CUSTOMER_BUDGET"].ToString());
                                }



                                objLeadBL.Insert(CODE,
                                                    LEAD_DATE,
                                                    dtblImport.Rows[i]["CUSTOMER_NAME"].ToString(),
                                                    dtblImport.Rows[i]["ADDRESS"].ToString(),
                                                    CityID,
                                                    dtblImport.Rows[i]["PINCODE"].ToString(),
                                                    dtblImport.Rows[i]["PHONE1"].ToString(),
                                                    dtblImport.Rows[i]["MOBILE"].ToString(),
                                                    dtblImport.Rows[i]["EMAIL"].ToString(),
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                    "",
                                                     "",
                                                   "",
                                                   "",
                                                    dtblImport.Rows[i]["SOURCE_OF_INQUIRY"].ToString(),
                                                    CUSTOMER_BUDGET,
                                                    dtblImport.Rows[i]["INTERAST_LEVEL"].ToString(),
                                                    NEXT_FOLLOWUP_DATE,
                                                    dtblImport.Rows[i]["SPECIFICATION"].ToString(),
                                                    dtblImport.Rows[i]["REMARKS"].ToString(),
                                                    1,
                                    //QUOTATION_SEND,
                                                    dtblImport.Rows[i]["CONTACT_PERSON"].ToString(),
                                                    0, 0, dtblImport.Rows[i]["WEBSITE"].ToString(),
                                                    "",
                                                    0
                                                    ,
                                                    false, CompId,0,"",0
                                                    );
                            }
                        }

                        MessageBox.Show("Data Uploded Successfully..!!");
                    }
                    else
                    {
                        MessageBox.Show("Select Proper Lead.xls File.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
