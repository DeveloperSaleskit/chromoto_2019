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
using System.Diagnostics;
using System.IO;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;




namespace Account.GUI.CreditNote
{
    public partial class frmCreditNoteList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblCreditNote = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        int _CompId = 0;

        DataTable dtCompany = new DataTable();

        Exception mException = null;
        string mErrorMsg = "";
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        string mpdfFile;
        CommonSelectBL CommSelect = new CommonSelectBL();

        #endregion

        #region "Form Event...."

        public frmCreditNoteList()
        {
            InitializeComponent();
        }

        private void frmServiceModuleList_Load(object sender, EventArgs e)
        {
            try
            {
                cmbreports.Items.Add("--Select Report--");
                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {

                        if (CurrentUser.PrivilegeStr.IndexOf("#9028#") != -1)
                        {
                            cmbreports.Items.Add("Credit Note");
                        }
                        //if (CurrentUser.PrivilegeStr.IndexOf("#2106#") != -1)
                        //{
                        //    cmbreports.Items.Add("Service Order");
                        //}
                        //if (CurrentUser.PrivilegeStr.IndexOf("#2107#") != -1)
                        //{
                        //    cmbreports.Items.Add("Service Invoice");
                        //}
                    }
                    else
                    {
                        cmbreports.Items.Add("Credit Note");
                    }
                    
                }

                else if (CurrentUser.UserID == 1)
                {
                    //cmbreports.Items.Add("--Select Report--");
                    cmbreports.Items.Add("Credit Note");
                    //cmbreports.Items.Add("Service Order");
                    //cmbreports.Items.Add("Service Invoice");

                }
                //cmbreports.Items.Add("Service Vouchar");

                cmbreports.SelectedIndex = 0;


                AddHandlers(this);
                SetControlsDefaults(this);
                dgvCreditNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                LoadList();

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#9025#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9026#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9027#") != -1)
                        { btnDelete.Enabled = true; }
                        else { btnDelete.Enabled = false; }
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblCreditNote.DefaultView;
            DV.RowFilter = StrFilter;
            dgvCreditNote.DataSource = DV.ToTable();
            frmCreditNoteFilter filterCreditNote = new frmCreditNoteFilter(dtblCreditNote);
            filterCreditNote.ShowDialog();
            StrFilter = filterCreditNote.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvCreditNote.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCreditNote.RowCount.ToString();

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
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCreditNoteEntry fSM = new frmCreditNoteEntry((int)Constant.Mode.Insert, 0);
                fSM.ShowInTaskbar = false;
                fSM.ShowDialog();
                LoadList();
                btnClear_Click(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCreditNote.CurrentRow != null)
                {
                    if (dgvCreditNote.SortedColumn != null)
                    {
                        sortedColumn = dgvCreditNote.SortedColumn;
                        sortDirection = dgvCreditNote.SortOrder;
                    }
                    frmCreditNoteEntry fSM = new frmCreditNoteEntry((int)Constant.Mode.Modify, (Int64)dgvCreditNote.CurrentRow.Cells["CNID"].Value);
                    fSM.ShowInTaskbar = false;
                    fSM.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCreditNote.CurrentRow != null)
                {
                    if (dgvCreditNote.SortedColumn != null)
                    {
                        sortedColumn = dgvCreditNote.SortedColumn;
                        sortDirection = dgvCreditNote.SortOrder;
                    }

                    frmCreditNoteEntry fSM = new frmCreditNoteEntry((int)Constant.Mode.Delete, (Int64)dgvCreditNote.CurrentRow.Cells["CNID"].Value);
                    fSM.ShowInTaskbar = false;
                    fSM.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                para.Add("@i_CompId", _CompId.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());

                dtblCreditNote = objList.ListOfRecord("usp_CreditNote_List", para, "CreditNote - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvCreditNote.CurrentRow != null)
                    {
                        idgvPosition = dgvCreditNote.CurrentRow.Index;
                    }

                    //valgrid = false;
                    ArrangeDataGridView();
                    dgvCreditNote.AutoGenerateColumns = false;
                    dgvCreditNote.DataSource = dtblCreditNote;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCreditNote.RowCount.ToString();
                    if (dgvCreditNote.CurrentRow != null && idgvPosition <= dgvCreditNote.RowCount)
                    {
                        if (dgvCreditNote.Rows.Count - 1 < idgvPosition)
                        {
                            dgvCreditNote.CurrentCell = dgvCreditNote.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvCreditNote.CurrentCell = dgvCreditNote.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                    //valgrid = true;
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
                dgvCreditNote.Columns["CNID"].DataPropertyName = dtblCreditNote.Columns["CNID"].ToString();
                dgvCreditNote.Columns["CNnumber"].DataPropertyName = dtblCreditNote.Columns["CNnumber"].ToString();
                dgvCreditNote.Columns["CNDate"].DataPropertyName = dtblCreditNote.Columns["CNDate"].ToString();
                dgvCreditNote.Columns["CustomerName"].DataPropertyName = dtblCreditNote.Columns["CustomerName"].ToString();
                dgvCreditNote.Columns["TotalAmount"].DataPropertyName = dtblCreditNote.Columns["TotalAmount"].ToString();
                dgvCreditNote.Columns["NetAmount"].DataPropertyName = dtblCreditNote.Columns["NetAmount"].ToString();
                dgvCreditNote.Columns["CreditAmount"].DataPropertyName = dtblCreditNote.Columns["Creditnoteamount"].ToString();
                dgvCreditNote.Columns["finalamount"].DataPropertyName = dtblCreditNote.Columns["finalamount"].ToString();
                dgvCreditNote.Columns["ContactPerson"].DataPropertyName = dtblCreditNote.Columns["ContactPerson"].ToString();
                dgvCreditNote.Columns["Mobile"].DataPropertyName = dtblCreditNote.Columns["Mobile"].ToString();
                dgvCreditNote.Columns["Email"].DataPropertyName = dtblCreditNote.Columns["Email"].ToString();
                dgvCreditNote.Columns["EmpName"].DataPropertyName = dtblCreditNote.Columns["EmpName"].ToString();
                dgvCreditNote.Columns["EmpAllTo"].DataPropertyName = dtblCreditNote.Columns["EmpAllTo"].ToString();
                dgvCreditNote.Columns["CompId"].DataPropertyName = dtblCreditNote.Columns["CompId"].ToString();
                //dgvCreditNote.Columns["CustomerID"].DataPropertyName = dtblCreditNote.Columns["CustomerID"].ToString();
                //dgvCreditNote.Columns["Code"].DataPropertyName = dtblCreditNote.Columns["Code"].ToString();

                //dgvCreditNote.Columns["DueDays"].DataPropertyName = dtblCreditNote.Columns["DueDays"].ToString();
                //dgvCreditNote.Columns["DueDate"].DataPropertyName = dtblCreditNote.Columns["DueDate"].ToString();
                //
                //
                //dgvCreditNote.Columns["Narration"].DataPropertyName = dtblCreditNote.Columns["Narration"].ToString();
                //dgvCreditNote.Columns["SrNo"].DataPropertyName = dtblCreditNote.Columns["SrNo"].ToString();
                //
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CreditNote", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
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

                    dgvCreditNote.Sort(dgvCreditNote.Columns[sortedColumn.Name], LSD);
                }
                if (dgvCreditNote.CurrentRow != null && idgvPosition <= dgvCreditNote.RowCount)
                {
                    if (dgvCreditNote.Rows.Count - 1 < idgvPosition)
                    {
                        dgvCreditNote.CurrentCell = dgvCreditNote.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvCreditNote.CurrentCell = dgvCreditNote.Rows[idgvPosition].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid Cell Event"

        private void dgvItemRegister_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCreditNote, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCreditNote, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
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

        #region "Report viewer...."

        private void mnuItemRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemRegister.rpt"))
                //{
                //    //dtblCreditNote.TableName = "ItemRegister";
                //    //dtblCreditNote.WriteXmlSchema(@"C:\Report\ItemRegister.xsd");

                //    DataView DVReport;
                //    DVReport = dtblCreditNote.DefaultView;
                //    DVReport.RowFilter = StrFilter;
                //    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    rptDoc.Load(CurrentUser.ReportPath + "rptItemRegister.rpt");

                //    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Service Module", true, false, false, false, false, false, true, false, false, false, false);

                //    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                //    fRptView.Text = "Service Module - [Page Size: A4]";
                //    fRptView.crViewer.ReportSource = rptDoc;
                //    fRptView.ShowDialog();
                //}
                //else
                //{
                //    MessageBox.Show("File is not exist...");
                //}
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "LOGOBIND"
        public void LogoBindold(DataTable dt)
        {
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            //dt.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Header", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Footer", System.Type.GetType("System.Byte[]"));
            //dt.TableName = "Logo";
            //dt.WriteXmlSchema(@"D:\ERP-CRM\CRM_ICON\Logo.xsd");
            drow = dt.Rows.Add();
            //FileStream logo;
            FileStream header;
            FileStream footer;
            //BinaryReader brLogo;
            BinaryReader brHeader;
            BinaryReader brFooter;
            //string Logo = CurrentCompany.Logo;
            string Header = CurrentCompany.Header;
            string Footer = CurrentCompany.Footer;
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
        }

        public void LogoBind(DataTable dt)
        {
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            //dt.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
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
            //if (Logo == null || Logo == "")
            //{
            //    Logo = CurrentUser.DocumentPath + "logoBlank.png";
            //}
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

            string Sign = CurrentCompany.Sign;
            if (Sign == null || Sign == "")
            {
                Sign = CurrentUser.DocumentPath + "sign.png";
            }
            //if (File.Exists(Logo))
            //{

            //    logo = new FileStream(Logo, FileMode.Open);
            //}
            //else
            //{
            //    logo = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Logo", FileMode.Open);
            //}

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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void serviceInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }


        public void RPT_Sub(Int64 QuotationID, string Code, Boolean _IsList)
        {
            DataTable dt = new DataTable();
            LogoBind(dt);
            mpdfFile = CurrentUser.DocumentPath + @"pdf\CreditNote.pdf";
            DataTable dtReport = new DataTable();
            //dtReport = CommSelect.SelectRecord(QuotationID, "rpt_Quotation", "Quotation - Report");

            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_RecID", QuotationID.ToString());
            para1.Add("@i_CompId", _CompId.ToString());
            dtReport = objList.ListOfRecord("rpt_CreditNote", para1, "CreditNote - Report");

            //DataTable dtTNC = new DataTable();
            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_Code", Code);
            //para.Add("@i_TNC_Sub", "CreditNote");

            //dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");

            DataTable dtCompany = new DataTable();
            //dtCompany = objDA.ExecuteDataTableSP("rpt_Company", null, false, ref mException, ref mErrorMsg, "Quotation TNC");
            dtReport.TableName = "CreditNote";
            dtReport.WriteXmlSchema(@"D:\CreditNote.xsd");

            NameValueCollection para2 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para2.Add("@i_CompId", _CompId.ToString());
            dtCompany = objList.ListOfRecord("rpt_Company", para2, "CreditNote - Report");

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
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCreditNote.rpt"))
                {

                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptCreditNote.rpt");
                    //rptDoc.Subreports[0].DataSourceConnections.Clear();
                    //rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                    rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                    rptDoc.Database.Tables[2].SetDataSource(dt);
                    rptDoc.Refresh();
                    CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                    CurrentUser.AddExtraParameter(rptDoc);
                    if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
                    {
                        rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
                    }
                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "CreditNote - [Page Size: A4]";
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
                    MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                }
                //}

            }
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvCreditNote.CurrentRow != null)
            //    {
            //        RPT_Sub(Convert.ToInt64(dgvCreditNote.CurrentRow.Cells["CNID"].Value), dgvCreditNote.CurrentRow.Cells["CNnumber"].Value.ToString(), true);
            //    }
            //    else
            //    {
            //        MessageBox.Show(CommSelect.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Quotation - Report", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            //}

            try
            {
                if (cmbreports.SelectedIndex == 1)
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (dgvCreditNote.CurrentRow != null)
                    {

                        DataTable dtTNC = new DataTable();
                        //NameValueCollection para2 = new NameValueCollection();
                        //para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                        //para2.Add("@i_TNC_Sub", "SALES");

                        //dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");

                        DataTable dtReport = new DataTable();

                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvCreditNote.CurrentRow.Cells["CNID"].Value).ToString());
                        dtReport = objList.ListOfRecord("rpt_CreditNote", para, "CreditNote - Report");

                        //NameValueCollection para2 = new NameValueCollection();
                        //_CompId = CurrentCompany.CompId;
                        //para2.Add("@i_CompId", _CompId.ToString());
                        //dtCompany = objList.ListOfRecord("rpt_Company", para2, "Quotation - Report");
                        //dtReport.TableName = "CreditNote";
                        //dtReport.WriteXmlSchema(@"D:\CreditNote.xsd");

                        dtReport = objList.ListOfRecord("rpt_CreditNote", para, "CreditNote - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCreditNote.rpt"))
                            {
                                //dtReport.TableName = "PurchaseOrder";
                                //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptCreditNote.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                //rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                //rptDoc.Database.Tables[2].SetDataSource(dtCompany);

                                rptDoc.Refresh();
                                CurrentUser.AddReportParameters(rptDoc, dtReport, "", true, false, false, false, false, false, false, false, false, false, false);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Credit Note - [Page Size: A4]";
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
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            }


        }


    }
}
