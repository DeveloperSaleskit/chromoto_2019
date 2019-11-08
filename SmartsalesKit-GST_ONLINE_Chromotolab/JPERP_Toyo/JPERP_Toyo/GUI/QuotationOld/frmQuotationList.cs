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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Diagnostics;
using System.IO;

namespace Account.GUI.Quotation
{
    public partial class frmQuotationList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable ObjDataTable = new DataTable();
        DataTable ObjDataTableRegister = new DataTable();
        CommonListBL objList = new CommonListBL();
        CommonSelectBL CommSelect = new CommonSelectBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        Exception mException = null;
        string mErrorMsg = "";

        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;

        public string PdfFile
        {
            get { return mpdfFile; }
            set { mpdfFile = value; }
        }

        string mpdfFile;

        #endregion

        #region "Form load events"

        public frmQuotationList()
        {
            InitializeComponent();
        }

        private void frmQuotationList_Load(object sender, EventArgs e)
        {
            cmbreports.Items.Add("--Select Report--");
            cmbreports.Items.Add("Quotation");
            cmbreports.SelectedIndex = 0;

            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
            LoadFollowUpList();



        }


        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {

                ObjDataTable = objList.ListOfRecord("usp_Quotation_List", null, "Quotation - List - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvSaleList.CurrentRow != null)
                    {
                        idgvPosition = dgvSaleList.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvSaleList.AutoGenerateColumns = false;
                    dgvSaleList.DataSource = ObjDataTable;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSaleList.RowCount.ToString();
                    if (dgvSaleList.CurrentRow != null && idgvPosition <= dgvSaleList.RowCount)
                    {
                        if (dgvSaleList.Rows.Count - 1 < idgvPosition)
                        {
                            dgvSaleList.CurrentCell = dgvSaleList.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvSaleList.CurrentCell = dgvSaleList.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                //dgvSaleList.Columns["CustomerName"].DataPropertyName = ObjDataTable.Columns["CustomerName"].ToString();
                //dgvSaleList.Columns["LeadNo"].DataPropertyName = ObjDataTable.Columns["LeadNo"].ToString();
                //dgvSaleList.Columns["QuotationId"].DataPropertyName = ObjDataTable.Columns["QuotationId"].ToString();
                //dgvSaleList.Columns["QDate"].DataPropertyName = ObjDataTable.Columns["QDate"].ToString();
                //dgvSaleList.Columns["Code"].DataPropertyName = ObjDataTable.Columns["Code"].ToString();
                //dgvSaleList.Columns["TotalAmount"].DataPropertyName = ObjDataTable.Columns["TotalAmount"].ToString();
                //dgvSaleList.Columns["PendingAmount"].DataPropertyName = ObjDataTable.Columns["PendingAmount"].ToString();
                //dgvSaleList.Columns["LeadID"].DataPropertyName = ObjDataTable.Columns["LeadID"].ToString();
                //dgvSaleList.Columns["TypeOfSale"].DataPropertyName = ObjDataTable.Columns["TypeOfSale"].ToString();
                //dgvSaleList.Columns["FollowupDate1"].DataPropertyName = ObjDataTable.Columns["FollowupDate1"].ToString();

                dgvSaleList.Columns["QuotationId"].DataPropertyName = ObjDataTable.Columns["QuotationId"].ToString();
                dgvSaleList.Columns["Code"].DataPropertyName = ObjDataTable.Columns["Code"].ToString();
                dgvSaleList.Columns["QDate"].DataPropertyName = ObjDataTable.Columns["QDate"].ToString();
                dgvSaleList.Columns["CustomerName"].DataPropertyName = ObjDataTable.Columns["CustomerName"].ToString();
                dgvSaleList.Columns["TotalAmount"].DataPropertyName = ObjDataTable.Columns["TotalAmount"].ToString();
                dgvSaleList.Columns["ContactPerson"].DataPropertyName = ObjDataTable.Columns["ContactPerson"].ToString();
                dgvSaleList.Columns["Mobile"].DataPropertyName = ObjDataTable.Columns["Mobile"].ToString();
                dgvSaleList.Columns["Email"].DataPropertyName = ObjDataTable.Columns["Email"].ToString();
                dgvSaleList.Columns["Category"].DataPropertyName = ObjDataTable.Columns["Category"].ToString();
                dgvSaleList.Columns["Status"].DataPropertyName = ObjDataTable.Columns["Status"].ToString();
                dgvSaleList.Columns["Remark"].DataPropertyName = ObjDataTable.Columns["Remark"].ToString();
                dgvSaleList.Columns["TakenBy"].DataPropertyName = ObjDataTable.Columns["EmpName"].ToString();
                dgvSaleList.Columns["AllocatedTo"].DataPropertyName = ObjDataTable.Columns["EmpAllTo"].ToString();
                dgvSaleList.Columns["FollowupDate1"].DataPropertyName = ObjDataTable.Columns["FollowupDate1"].ToString();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvSaleList.SortedColumn != null)
                {
                    sortedColumn = dgvSaleList.SortedColumn;
                    sortDirection = dgvSaleList.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
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

                dgvSaleList.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSaleList.RowCount.ToString();

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

                    dgvSaleList.Sort(dgvSaleList.Columns[sortedColumn.Name], LSD);
                }
                if (dgvSaleList.CurrentRow != null && idgvPosition <= dgvSaleList.RowCount)
                {
                    if (dgvSaleList.Rows.Count - 1 < idgvPosition)
                    {
                        dgvSaleList.CurrentCell = dgvSaleList.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvSaleList.CurrentCell = dgvSaleList.Rows[idgvPosition].Cells[0];
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button events"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = ObjDataTable.DefaultView;
            DV.RowFilter = StrFilter;
            dgvSaleList.DataSource = DV.ToTable();
            frmQuotationFilter filterSalesinvoice = new frmQuotationFilter(ObjDataTable);
            filterSalesinvoice.ShowDialog();
            DataTable dt = DV.ToTable();
            dgvSaleList.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvSaleList.RowCount.ToString();

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
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuotationNew fQuotationNew = new frmQuotationNew((int)Constant.Mode.Insert, 0);
                fQuotationNew.ShowInTaskbar = false;
                fQuotationNew.ShowDialog();
                btnClear_Click(sender, e);
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleList.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmQuotationNew fSalesNew = new frmQuotationNew((int)Constant.Mode.Modify, Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value));
                    fSalesNew.ShowInTaskbar = false;
                    fSalesNew.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleList.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmQuotationNew fSalesNew = new frmQuotationNew((int)Constant.Mode.Delete, Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value));
                    fSalesNew.ShowInTaskbar = false;
                    fSalesNew.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
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
                    GridDrawCustomHeaderColumns(dgvSaleList, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvSaleList, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox events"

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-,.");
        }

        #endregion

        #region "LOGOBIND"

        public void LogoBind(DataTable dt)
        {
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            dt.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Header", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Footer", System.Type.GetType("System.Byte[]"));
            //dt.TableName = "Logo";
            //dt.WriteXmlSchema(@"D:\ERP-CRM\CRM_ICON\Logo.xsd");
            drow = dt.Rows.Add();
            FileStream logo;
            FileStream header;
            FileStream footer;
            BinaryReader brLogo;
            BinaryReader brHeader;
            BinaryReader brFooter;
            string Logo = CurrentCompany.Logo;
            if (Logo == null || Logo == "")
            {
                Logo = CurrentUser.DocumentPath + "logoBlank.png";
            }
            string Header = CurrentCompany.Header;
            if (Header == null)
            {
                Header = CurrentUser.DocumentPath + "header.png";
            }
            string Footer = CurrentCompany.Footer;
            if (Footer == null)
            {
                Footer = CurrentUser.DocumentPath + "footer.png";
            }
            if (File.Exists(Logo))
            {

                logo = new FileStream(Logo, FileMode.Open);
            }
            else
            {
                logo = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Logo", FileMode.Open);
            }

            if (File.Exists(Header))
            {

                header = new FileStream(Header, FileMode.Open);
            }
            else
            {
                header = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Header", FileMode.Open);
            }

            if (File.Exists(Footer))
            {

                footer = new FileStream(Footer, FileMode.Open);
            }
            else
            {
                footer = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Footer", FileMode.Open);
            }

            brLogo = new BinaryReader(logo);
            byte[] imgbyteLogo = new byte[logo.Length + 1];
            imgbyteLogo = brLogo.ReadBytes(Convert.ToInt32((logo.Length)));
            drow[0] = imgbyteLogo;
            dt.NewRow();
            brLogo.Close();
            logo.Close();

            brHeader = new BinaryReader(header);
            byte[] imgbyteHeader = new byte[header.Length + 1];
            imgbyteHeader = brHeader.ReadBytes(Convert.ToInt32((header.Length)));
            drow[1] = imgbyteHeader;
            dt.NewRow();
            brHeader.Close();
            header.Close();

            brFooter = new BinaryReader(footer);
            byte[] imgbyteFooter = new byte[footer.Length + 1];
            imgbyteFooter = brFooter.ReadBytes(Convert.ToInt32((footer.Length)));
            drow[2] = imgbyteFooter;
            dt.NewRow();
            brFooter.Close();
            footer.Close();
        }

        #endregion

        public void RPT_Sub(Int64 QuotationID, string Code, Boolean _IsList)
        {
            DataTable dt = new DataTable();
            LogoBind(dt);
            mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            DataTable dtReport = new DataTable();
            dtReport = CommSelect.SelectRecord(QuotationID, "rpt_Quotation", "Quotation - Report");

            DataTable dtTNC = new DataTable();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Code", Code);
            para.Add("@i_TNC_Sub", "Quotation");

            dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");

            DataTable dtCompany = new DataTable();
            dtCompany = objDA.ExecuteDataTableSP("rpt_Company", null, false, ref mException, ref mErrorMsg, "Quotation TNC");
            //dtReport.TableName = "Quotation";
            //dtReport.WriteXmlSchema(@"D:\Quotation.xsd");

            if (CommSelect.Exception == null)
            {
                //if (TypeOFSale == "AMC")
                //{
                //    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation_AMC.rpt"))
                //    {

                //        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //        rptDoc.Load(CurrentUser.ReportPath + "rptQuotation_AMC.rpt");

                //        //rptDoc.SetDatabaseLogon("sa", "Un!ek3RP");
                //        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);

                //        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                //        rptDoc.Subreports[0].DataSourceConnections.Clear();
                //        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                //        rptDoc.Refresh();


                //        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                //        fRptView.Text = "Quotation - [Page Size: A4]";
                //        fRptView.crViewer.ReportSource = rptDoc;
                //        if (_IsList == true)
                //        {
                //            fRptView.ShowDialog();
                //        }
                //        else if (_IsList == false)
                //        {
                //            ExportOptions CrExportOptions;
                //            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                //            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                //            CrDiskFileDestinationOptions.DiskFileName = mpdfFile;
                //            CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
                //            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                //            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                //            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                //            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                //            rptDoc.Export();

                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("File is not exist...");
                //    }
                //}
                //else if (TypeOFSale != "AMC")
                //{
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation.rpt"))
                {

                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptQuotation.rpt");
                    //rptDoc.Subreports[0].DataSourceConnections.Clear();
                    rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                    rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                    rptDoc.Database.Tables[2].SetDataSource(dt);
                    rptDoc.Refresh();
                    CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                    CurrentUser.AddExtraParameter(rptDoc);
                    if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() !="")
                    {
                        rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
                    }
                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Quotation - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;

                    if (_IsList == true)
                    {
                        fRptView.ShowDialog();
                    }
                    else if (_IsList == false)
                    {
                        ExportOptions CrExportOptions;
                        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                        CrDiskFileDestinationOptions.DiskFileName = mpdfFile;
                        CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
                        CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                        CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                        CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                        CrExportOptions.FormatOptions = CrFormatTypeOptions;
                        rptDoc.Export();

                    }
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
                //}

            }
        }

        private void mmuMailingLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerMailingLabel1.rpt"))
                {
                    //dtblCustomer.TableName = "CustomerRegister";
                    //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                    //DataView DVReport;
                    //DVReport = dtblCustomer.DefaultView;
                    //DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptCustomerMailingLabel1.rpt");

                    //CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Mailing Label", false, false, false, false, false, false, false, false, false, false, false);

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



        private void btnrevisedquotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleList.CurrentRow != null)
                {
                    SetSortedColumns();

                    frmQuotationNew fSalesNew = new frmQuotationNew((int)Constant.Mode.View, Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value));
                    fSalesNew.ShowInTaskbar = false;
                    fSalesNew.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        public void LoadFollowUpList()
        {
            try
            {
                if (dgvSaleList.CurrentRow == null)
                    return;
                DataTable dtFollowUps = new DataTable();
                NameValueCollection Paralist = new NameValueCollection();
                Paralist.Add("@i_LeadID", dgvSaleList.CurrentRow.Cells["QuotationId"].Value.ToString());
                dtFollowUps = objList.ListOfRecord("usp_QuotationFollowUp_List", Paralist, "QuotationFollowUp -List");
                if (objList.Exception == null)
                {

                    dgvFollwUps.Columns["FollowupDate"].DataPropertyName = dtFollowUps.Columns["FollowupDate"].ToString();
                    dgvFollwUps.Columns["LeadFollowUpId"].DataPropertyName = dtFollowUps.Columns["QuotationFollowUpId"].ToString();
                    dgvFollwUps.Columns["FollowupByName"].DataPropertyName = dtFollowUps.Columns["FollowupByName"].ToString();
                    dgvFollwUps.Columns["Remarks"].DataPropertyName = dtFollowUps.Columns["Remarks"].ToString();
                    dgvFollwUps.AutoGenerateColumns = false;
                    dgvFollwUps.DataSource = dtFollowUps;
                    dgvFollwUps.Columns["FollowupDate"].DataPropertyName = dtFollowUps.Columns["FollowupDate"].ToString();
                    dgvFollwUps.Columns["LeadFollowUpId"].DataPropertyName = dtFollowUps.Columns["QuotationFollowUpId"].ToString();
                    dgvFollwUps.Columns["FollowupByName"].DataPropertyName = dtFollowUps.Columns["FollowupByName"].ToString();
                    dgvFollwUps.Columns["Remarks"].DataPropertyName = dtFollowUps.Columns["Remarks"].ToString();
                    //dgvFollwUps.Columns["FollowUpDate_Quotation"].DataPropertyName = dtFollowUps.Columns["FollowUpDate_Quotation"].ToString();

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


        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleList.CurrentRow != null)
                {
                    SetSortedColumns();
                    string CustName = dgvSaleList.CurrentRow.Cells["CustomerName"].Value.ToString();
                    string LeadDate = Convert.ToDateTime(dgvSaleList.CurrentRow.Cells["QDate"].Value.ToString()).ToShortDateString();
                    string folloupDate;
                    if (dgvSaleList.CurrentRow.Cells["FollowupDate1"].Value == null)
                    {
                        folloupDate = "";
                    }
                    else
                    {
                        folloupDate = Convert.ToDateTime(dgvSaleList.CurrentRow.Cells["FollowupDate1"].Value.ToString()).ToShortDateString();
                    }

                    frmQuotationFollowup fCustomer = new frmQuotationFollowup((Int64)dgvSaleList.CurrentRow.Cells["QuotationId"].Value, dgvSaleList.CurrentRow.Cells["Code"].Value.ToString(), LeadDate, CustName, folloupDate);
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

        private void dgvSaleList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvSaleList.CurrentRow != null)
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

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }



        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex > 0)
            {
                try
                {
                    if (dgvSaleList.CurrentRow != null)
                    {
                        RPT_Sub(Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value), dgvSaleList.CurrentRow.Cells["Code"].Value.ToString(), true);
                    }
                    else
                    {
                        MessageBox.Show(CommSelect.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Quotation - Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;
        }

        private void dgvFollwUps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
