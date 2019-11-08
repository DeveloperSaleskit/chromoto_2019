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

namespace Account.GUI.DebitNote
{
    public partial class frmDebitNoteList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblDebitNote = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        int _CompId = 0;

        Exception mException = null;
        string mErrorMsg = "";
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();

        #endregion

        #region "Form Event...."

        public frmDebitNoteList()
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

                        if (CurrentUser.PrivilegeStr.IndexOf("#9033#") != -1)
                        {
                            cmbreports.Items.Add("Debit Note");
                        }

                    }
                    else
                    {
                        cmbreports.Items.Add("Debit Note");
                    }
                }

                else if (CurrentUser.UserID == 1)
                {                   
                    cmbreports.Items.Add("Debit Note");
                }
                //cmbreports.Items.Add("Service Vouchar");

                cmbreports.SelectedIndex = 0;


                AddHandlers(this);
                SetControlsDefaults(this);
                dgvDebitNote.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                LoadList();

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#9030#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9031#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9032#") != -1)
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
            DV = dtblDebitNote.DefaultView;
            DV.RowFilter = StrFilter;
            dgvDebitNote.DataSource = DV.ToTable();
            frmDebitNoteFilter filterDebitNote = new frmDebitNoteFilter(dtblDebitNote);
            filterDebitNote.ShowDialog();
            StrFilter = filterDebitNote.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvDebitNote.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvDebitNote.RowCount.ToString();

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
                frmDebitNoteEntry fSM = new frmDebitNoteEntry((int)Constant.Mode.Insert, 0);
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
                if (dgvDebitNote.CurrentRow != null)
                {
                    if (dgvDebitNote.SortedColumn != null)
                    {
                        sortedColumn = dgvDebitNote.SortedColumn;
                        sortDirection = dgvDebitNote.SortOrder;
                    }
                    frmDebitNoteEntry fSM = new frmDebitNoteEntry((int)Constant.Mode.Modify, (Int64)dgvDebitNote.CurrentRow.Cells["DNID"].Value);
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
                if (dgvDebitNote.CurrentRow != null)
                {
                    if (dgvDebitNote.SortedColumn != null)
                    {
                        sortedColumn = dgvDebitNote.SortedColumn;
                        sortDirection = dgvDebitNote.SortOrder;
                    }

                    frmDebitNoteEntry fSM = new frmDebitNoteEntry((int)Constant.Mode.Delete, (Int64)dgvDebitNote.CurrentRow.Cells["DNID"].Value);
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

                dtblDebitNote = objList.ListOfRecord("usp_DebitNote_List", para, "DebitNote - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvDebitNote.CurrentRow != null)
                    {
                        idgvPosition = dgvDebitNote.CurrentRow.Index;
                    }

                    //valgrid = false;
                    ArrangeDataGridView();
                    dgvDebitNote.AutoGenerateColumns = false;
                    dgvDebitNote.DataSource = dtblDebitNote;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvDebitNote.RowCount.ToString();
                    if (dgvDebitNote.CurrentRow != null && idgvPosition <= dgvDebitNote.RowCount)
                    {
                        if (dgvDebitNote.Rows.Count - 1 < idgvPosition)
                        {
                            dgvDebitNote.CurrentCell = dgvDebitNote.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvDebitNote.CurrentCell = dgvDebitNote.Rows[idgvPosition].Cells[0];
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
                dgvDebitNote.Columns["DNID"].DataPropertyName = dtblDebitNote.Columns["DNID"].ToString();
                dgvDebitNote.Columns["DNnumber"].DataPropertyName = dtblDebitNote.Columns["DNnumber"].ToString();
                dgvDebitNote.Columns["DNDate"].DataPropertyName = dtblDebitNote.Columns["DNDate"].ToString();
                dgvDebitNote.Columns["VendorName"].DataPropertyName = dtblDebitNote.Columns["Name"].ToString();
                dgvDebitNote.Columns["TotalAmount"].DataPropertyName = dtblDebitNote.Columns["TotalAmount"].ToString();
                dgvDebitNote.Columns["NetAmount"].DataPropertyName = dtblDebitNote.Columns["NetAmount"].ToString();
                dgvDebitNote.Columns["DebitAmount"].DataPropertyName = dtblDebitNote.Columns["DebitNoteamount"].ToString();
                dgvDebitNote.Columns["finalamount"].DataPropertyName = dtblDebitNote.Columns["finalamount"].ToString();
                dgvDebitNote.Columns["Mobile"].DataPropertyName = dtblDebitNote.Columns["Mobile"].ToString();
                dgvDebitNote.Columns["Email"].DataPropertyName = dtblDebitNote.Columns["fax"].ToString();
                
                
                dgvDebitNote.Columns["CompId"].DataPropertyName = dtblDebitNote.Columns["CompId"].ToString();
                //dgvDebitNote.Columns["CustomerID"].DataPropertyName = dtblDebitNote.Columns["CustomerID"].ToString();
                //dgvDebitNote.Columns["Code"].DataPropertyName = dtblDebitNote.Columns["Code"].ToString();

                //dgvDebitNote.Columns["DueDays"].DataPropertyName = dtblDebitNote.Columns["DueDays"].ToString();
                //dgvDebitNote.Columns["DueDate"].DataPropertyName = dtblDebitNote.Columns["DueDate"].ToString();
                //
                //
                //dgvDebitNote.Columns["Narration"].DataPropertyName = dtblDebitNote.Columns["Narration"].ToString();
                //dgvDebitNote.Columns["SrNo"].DataPropertyName = dtblDebitNote.Columns["SrNo"].ToString();
                //
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("DebitNote", exc.StackTrace);
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

                    dgvDebitNote.Sort(dgvDebitNote.Columns[sortedColumn.Name], LSD);
                }
                if (dgvDebitNote.CurrentRow != null && idgvPosition <= dgvDebitNote.RowCount)
                {
                    if (dgvDebitNote.Rows.Count - 1 < idgvPosition)
                    {
                        dgvDebitNote.CurrentCell = dgvDebitNote.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvDebitNote.CurrentCell = dgvDebitNote.Rows[idgvPosition].Cells[0];
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
                    GridDrawCustomHeaderColumns(dgvDebitNote, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvDebitNote, e, Properties.Resources.Button_Gray_Stripe_01_050);
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
                //    //dtblDebitNote.TableName = "ItemRegister";
                //    //dtblDebitNote.WriteXmlSchema(@"C:\Report\ItemRegister.xsd");

                //    DataView DVReport;
                //    DVReport = dtblDebitNote.DefaultView;
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
            string Header = CurrentCompany.Header;
            string Footer = CurrentCompany.Footer;
            if (File.Exists(Logo))
            {

                logo = new FileStream(Logo, FileMode.Open);
            }
            else
            {
                logo = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Srinath.png", FileMode.Open);
            }

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

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbreports.SelectedIndex == 1)
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (dgvDebitNote.CurrentRow != null)
                    {

                        DataTable dtTNC = new DataTable();
                        //NameValueCollection para2 = new NameValueCollection();
                        //para2.Add("@i_Code", dgvSalesInvoice.CurrentRow.Cells["SalesCode"].Value.ToString());
                        //para2.Add("@i_TNC_Sub", "SALES");

                        //dtTNC = objDA.ExecuteDataTableSP("rpt_Sales_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");

                        DataTable dtReport = new DataTable();

                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvDebitNote.CurrentRow.Cells["DNID"].Value).ToString());
                        dtReport = objList.ListOfRecord("rpt_DebitNote", para, "DebitNote - Report");

                        //NameValueCollection para2 = new NameValueCollection();
                        //_CompId = CurrentCompany.CompId;
                        //para2.Add("@i_CompId", _CompId.ToString());
                        //dtCompany = objList.ListOfRecord("rpt_Company", para2, "Quotation - Report");
                        dtReport.TableName = "DebitNote";
                        dtReport.WriteXmlSchema(@"D:\DebitNote.xsd");

                        dtReport = objList.ListOfRecord("rpt_DebitNote", para, "DebitNote - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptDebitNote.rpt"))
                            {
                                //dtReport.TableName = "PurchaseOrder";
                                //dtReport.WriteXmlSchema(@"D:\PurchaseOrder.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptDebitNote.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                //rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                //rptDoc.Database.Tables[2].SetDataSource(dtCompany);

                                rptDoc.Refresh();
                                CurrentUser.AddReportParameters(rptDoc, dtReport, "", true, false, false, false, false, false, false, false, false, false, false);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Debit Note - [Page Size: A4]";
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
