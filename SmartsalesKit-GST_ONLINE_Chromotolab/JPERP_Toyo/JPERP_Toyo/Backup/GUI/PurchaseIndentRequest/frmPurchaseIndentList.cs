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



namespace Account.GUI.PurchaseIndentRequest
{
    public partial class frmPurchaseIndentList : Account.GUIBase
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
        int CompId = 0;
        int _CompId = 0;
        string CODE = "";
        #endregion

        #region

        public frmPurchaseIndentList()
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
                        if (CurrentUser.PrivilegeStr.IndexOf("#9101#") != -1)
                        {
                            cmbreports.Items.Add("PurchaseIndent Register");
                        }

                    }
                    else
                    {
                        cmbreports.Items.Add("PurchaseIndent Register");

                    }
                }
                else if (CurrentUser.UserID == 1)
                {
                    cmbreports.Items.Add("PurchaseIndent Register");

                }
                cmbreports.SelectedIndex = 0;

                AddHandlers(this);
                SetControlsDefaults(this);
                LoadList();

                dgvInquiry.ReadOnly = true;

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#9098#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9099#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9100#") != -1)
                        { btnDelete.Enabled = true; }
                        else { btnDelete.Enabled = false; }

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
            frmPurchaseIndentFilter filterSalesinvoice = new frmPurchaseIndentFilter(dtblLead);
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
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseIndentEntry fCustomer = new frmPurchaseIndentEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;
                fCustomer.ShowDialog();
                LoadList();

            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("Lead", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Warning");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInquiry.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmPurchaseIndentEntry fCustomer = new frmPurchaseIndentEntry((int)Constant.Mode.Modify, (Int64)dgvInquiry.CurrentRow.Cells["Id"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
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
                    frmPurchaseIndentEntry fCustomer = new frmPurchaseIndentEntry((int)Constant.Mode.Delete, (Int64)dgvInquiry.CurrentRow.Cells["Id"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
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

                dtblLead = objList.ListOfRecord("usp_PurchaseIndent_List", para1, "Lead -List");
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
                dtFollowUps = objList.ListOfRecord("usp_LeadFollowUp_List", Paralist, "LeadFollowUp -List");
                if (objList.Exception == null)
                {

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
                dgvInquiry.Columns["purchaseindent"].DataPropertyName = dtblLead.Columns["purchaseindent"].ToString();

                dgvInquiry.Columns["Id"].DataPropertyName = dtblLead.Columns["Id"].ToString();
                dgvInquiry.Columns["SrNo"].DataPropertyName = dtblLead.Columns["SrNo"].ToString();
                dgvInquiry.Columns["IndentDate"].DataPropertyName = dtblLead.Columns["IndentDate"].ToString();
                dgvInquiry.Columns["itemcode"].DataPropertyName = dtblLead.Columns["itemcode"].ToString();
                dgvInquiry.Columns["productcode"].DataPropertyName = dtblLead.Columns["productcode"].ToString();
                dgvInquiry.Columns["itemDetails"].DataPropertyName = dtblLead.Columns["itemDetails"].ToString();
                dgvInquiry.Columns["qtyreqd"].DataPropertyName = dtblLead.Columns["qtyreqd"].ToString();
                dgvInquiry.Columns["qtyinstock"].DataPropertyName = dtblLead.Columns["qtyinstock"].ToString();
                dgvInquiry.Columns["stockinhand"].DataPropertyName = dtblLead.Columns["stockinhand"].ToString();
                dgvInquiry.Columns["unitprice"].DataPropertyName = dtblLead.Columns["unitprice"].ToString();
                dgvInquiry.Columns["totalcost"].DataPropertyName = dtblLead.Columns["totalcost"].ToString();
                dgvInquiry.Columns["itemused"].DataPropertyName = dtblLead.Columns["itemused"].ToString();

                dgvInquiry.Columns["statuspo"].DataPropertyName = dtblLead.Columns["statuspo"].ToString();
                dgvInquiry.Columns["Remarks"].DataPropertyName = dtblLead.Columns["Remarks"].ToString();


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

                if (cmbreports.SelectedIndex == 1)
                {

                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPurchaseIndentRegister.rpt"))
                    {
                        //dtblLead.TableName = "LeadRegister";
                        //dtblLead.WriteXmlSchema(@"E:\SharedFile\LeadRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblLead.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptPurchaseIndentRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "rptPurchaseIndent Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "rptPurchaseIndent Register - [Page Size: A4]";
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

                                //if (dtblImport.Rows[i]["LEAD_DATE"].ToString() == null || dtblImport.Rows[i]["LEAD_DATE"].ToString().Trim() == "")
                                //{
                                LEAD_DATE = System.DateTime.Now.Date;
                                //}
                                //else
                                //{
                                //    if (dtblImport.Rows[i]["LEAD_DATE"].ToString().Length == 10)
                                //    {
                                //        LEAD_DATE = Convert.ToDateTime(dtblImport.Rows[i]["LEAD_DATE"].ToString());
                                //    }
                                //    else
                                //    {
                                //        LEAD_DATE = System.DateTime.Now.Date;
                                //    }
                                //}

                                //if (dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString() == null || dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString().Trim() == "")
                                //{
                                NEXT_FOLLOWUP_DATE = System.DateTime.Now.Date;
                                //}
                                //else
                                //{
                                //    if (dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString().Length == 10)
                                //    {
                                //        NEXT_FOLLOWUP_DATE = Convert.ToDateTime(dtblImport.Rows[i]["NEXT_FOLLOWUP_DATE"].ToString());
                                //    }
                                //    else
                                //    {
                                //        NEXT_FOLLOWUP_DATE = System.DateTime.Now.Date;
                                //    }
                                //}

                                //if (dtblImport.Rows[i]["CUSTOMER_BUDGET"].ToString() == null || dtblImport.Rows[i]["CUSTOMER_BUDGET"].ToString().Trim() == "")
                                //{
                                CUSTOMER_BUDGET = 0;
                                //}
                                //else
                                //{
                                //    CUSTOMER_BUDGET = Convert.ToDecimal(dtblImport.Rows[i]["CUSTOMER_BUDGET"].ToString());
                                //}



                                objLeadBL.Insert(CODE,
                                                    LEAD_DATE,
                                                    dtblImport.Rows[i]["CUSTOMER_NAME"].ToString(),
                                                    dtblImport.Rows[i]["ADDRESS"].ToString(),
                                                    CityID,
                                                    "",
                                                    "",
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
                                                    "",
                                                    NEXT_FOLLOWUP_DATE,
                                                    "",
                                                    "",
                                                    1,
                                    //QUOTATION_SEND,
                                                    dtblImport.Rows[i]["CONTACT_PERSON"].ToString(),
                                                    0, 0, "",
                                                    "",
                                                    0
                                                    ,
                                                    false, CompId, 0, "", 0
                                                    );
                            }
                        }

                        MessageBox.Show("Data Uploded Successfully..!!");
                        LoadList();
                    }
                    else
                    {
                        MessageBox.Show("Select Proper Lead.xls File.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseIndentEntry fCustomer = new frmPurchaseIndentEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;


                fCustomer.ShowDialog();
                LoadList();
                LoadFollowUpList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

    }
}
