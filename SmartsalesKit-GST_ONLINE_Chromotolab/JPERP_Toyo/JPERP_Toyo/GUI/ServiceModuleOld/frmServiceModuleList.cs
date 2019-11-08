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

namespace Account.GUI.ServiceModule
{
    public partial class frmServiceModuleList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblItem = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;

        Exception mException = null;
        string mErrorMsg = "";
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();

        #endregion

        #region "Form Event...."

        public frmServiceModuleList()
        {
            InitializeComponent();
        }

        private void frmServiceModuleList_Load(object sender, EventArgs e)
        {
            try
            {

                cmbreports.Items.Add("--Select Report--");
                cmbreports.Items.Add(" Service Register");
                cmbreports.Items.Add("Service Order");
                cmbreports.Items.Add("Service Invoice");
                //cmbreports.Items.Add("Service Vouchar");

                cmbreports.SelectedIndex = 0;


                AddHandlers(this);
                SetControlsDefaults(this);
                dgvServiceModule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                LoadList();

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
            DV = dtblItem.DefaultView;
            DV.RowFilter = StrFilter;
            dgvServiceModule.DataSource = DV.ToTable();
            frmServiceModuleFilter filterSalesinvoice = new frmServiceModuleFilter(dtblItem);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvServiceModule.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvServiceModule.RowCount.ToString();

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
                frmServiceModuleEntry fSM = new frmServiceModuleEntry((int)Constant.Mode.Insert, 0);
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
                if (dgvServiceModule.CurrentRow != null)
                {
                    if (dgvServiceModule.SortedColumn != null)
                    {
                        sortedColumn = dgvServiceModule.SortedColumn;
                        sortDirection = dgvServiceModule.SortOrder;
                    }
                    frmServiceModuleEntry fSM = new frmServiceModuleEntry((int)Constant.Mode.Modify, (Int64)dgvServiceModule.CurrentRow.Cells["ServiceId"].Value);
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
                if (dgvServiceModule.CurrentRow != null)
                {
                    if (dgvServiceModule.SortedColumn != null)
                    {
                        sortedColumn = dgvServiceModule.SortedColumn;
                        sortDirection = dgvServiceModule.SortOrder;
                    }

                    frmServiceModuleEntry fSM = new frmServiceModuleEntry((int)Constant.Mode.Delete, (Int64)dgvServiceModule.CurrentRow.Cells["ServiceId"].Value);
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
                dtblItem = objList.ListOfRecord("usp_ServiceModule_List", null, "ServiceModule - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvServiceModule.CurrentRow != null)
                    {
                        idgvPosition = dgvServiceModule.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvServiceModule.AutoGenerateColumns = false;
                    dgvServiceModule.DataSource = dtblItem;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvServiceModule.RowCount.ToString();
                    if (dgvServiceModule.CurrentRow != null && idgvPosition <= dgvServiceModule.RowCount)
                    {
                        if (dgvServiceModule.Rows.Count - 1 < idgvPosition)
                        {
                            dgvServiceModule.CurrentCell = dgvServiceModule.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvServiceModule.CurrentCell = dgvServiceModule.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvServiceModule.Columns[1].DataPropertyName = dtblItem.Columns["ServiceId"].ToString();
                dgvServiceModule.Columns[0].DataPropertyName = dtblItem.Columns["RequestNo"].ToString();
                dgvServiceModule.Columns[2].DataPropertyName = dtblItem.Columns["ServiceDate"].ToString();
                dgvServiceModule.Columns[3].DataPropertyName = dtblItem.Columns["CustomerName"].ToString();
                dgvServiceModule.Columns[4].DataPropertyName = dtblItem.Columns["Address"].ToString();
                dgvServiceModule.Columns[5].DataPropertyName = dtblItem.Columns["MobileNo"].ToString();
                dgvServiceModule.Columns[6].DataPropertyName = dtblItem.Columns["ProductName"].ToString();
                dgvServiceModule.Columns[7].DataPropertyName = dtblItem.Columns["ModelNumber"].ToString();
                dgvServiceModule.Columns[8].DataPropertyName = dtblItem.Columns["Problem"].ToString();
                dgvServiceModule.Columns[9].DataPropertyName = dtblItem.Columns["EmpName"].ToString();
                dgvServiceModule.Columns["ServiceBy"].DataPropertyName = dtblItem.Columns["ServiceBy"].ToString();
                dgvServiceModule.Columns[11].DataPropertyName = dtblItem.Columns["JobComputed"].ToString();
                dgvServiceModule.Columns[12].DataPropertyName = dtblItem.Columns["Remarks"].ToString();
                dgvServiceModule.Columns[13].DataPropertyName = dtblItem.Columns["OtherRequirement"].ToString();
                dgvServiceModule.Columns[14].DataPropertyName = dtblItem.Columns["Charges"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
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

                    dgvServiceModule.Sort(dgvServiceModule.Columns[sortedColumn.Name], LSD);
                }
                if (dgvServiceModule.CurrentRow != null && idgvPosition <= dgvServiceModule.RowCount)
                {
                    if (dgvServiceModule.Rows.Count - 1 < idgvPosition)
                    {
                        dgvServiceModule.CurrentCell = dgvServiceModule.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvServiceModule.CurrentCell = dgvServiceModule.Rows[idgvPosition].Cells[0];
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
                    GridDrawCustomHeaderColumns(dgvServiceModule, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvServiceModule, e, Properties.Resources.Button_Gray_Stripe_01_050);
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
                //    //dtblItem.TableName = "ItemRegister";
                //    //dtblItem.WriteXmlSchema(@"C:\Report\ItemRegister.xsd");

                //    DataView DVReport;
                //    DVReport = dtblItem.DefaultView;
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
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (dgvServiceModule.CurrentRow == null)
                        return;

                    DataTable dtReport = new DataTable();
                    NameValueCollection Paralist = new NameValueCollection();
                    Paralist.Add("@i_ServiceId", dgvServiceModule.CurrentRow.Cells["ServiceId"].Value.ToString());
                    dtReport = objList.ListOfRecord("rpt_ServiceModule", Paralist, "ServiceModule - Report");
                    //if (objList.Exception == null)
                    //{
                    //dtReport.TableName = "ServiceModuleRegister";
                    //dtReport.WriteXmlSchema(@"D:\ServiceModuleRegister.xsd");
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptServiceModuleRegister.rpt"))
                    {


                        DataView DVReport;
                        DVReport = dtblItem.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptServiceModuleRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Service Module", true, true, true, true, false, true, true, false, false, false, true);
                        //CurrentUser.AddExtraParameter(rptDoc);
                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Service Module - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("File is not exist...");
                    }
                    //}
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {

                    if (dgvServiceModule.CurrentRow == null)
                        return;

                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    DataSet dtReport = new DataSet();
                    NameValueCollection Paralist = new NameValueCollection();
                    Paralist.Add("@i_RecID", dgvServiceModule.CurrentRow.Cells["ServiceId"].Value.ToString());
                    dtReport = objList.ListOfDataSetRecordwithPara("rpt_Service_Order", Paralist, "Service Invoice - Report");
                    if (objList.Exception == null)
                    {
                        dtReport.Tables[0].TableName = "ServiceInvoice";
                        dtReport.Tables[0].WriteXmlSchema(@"D:\ServiceInvoice.xsd");
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptServiceOrder.rpt"))
                        {

                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptServiceOrder.rpt");
                          //  rptDoc.Database.Tables[1].SetDataSource(dt);
                            rptDoc.Refresh();
                            CurrentUser.AddReportParameters(rptDoc, dtReport.Tables[0], "Service Order", true, true, true, true, false, true, true, false, false, false, true);
                            
                           
                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Service Order - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("File is not exist...");
                        }
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Service Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 3)
            {
                try
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (dgvServiceModule.CurrentRow != null)
                    {
                        DataTable dtTNC = new DataTable();
                        NameValueCollection para2 = new NameValueCollection();
                        para2.Add("@i_Code", dgvServiceModule.CurrentRow.Cells["RequestNo"].Value.ToString());
                        para2.Add("@i_TNC_Sub", "SERVICE");

                        dtTNC = objDA.ExecuteDataTableSP("rpt_Service_TNC", para2, false, ref mException, ref mErrorMsg, "Quotation TNC");



                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvServiceModule.CurrentRow.Cells["ServiceId"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_ServiceInvoice", para, "ServiceInvoice - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptServiceInvoice.rpt"))
                            {
                                //dtReport.TableName = "ServiceInvoice";
                                //dtReport.WriteXmlSchema(@"D:\ServiceInvoice.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptServiceInvoice.rpt");
                                rptDoc.Subreports[0].DataSourceConnections.Clear();
                                rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();
                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Service Invoice", true, true, true, true, true, true, true, true, true, true, true);
                                CurrentUser.AddExtraParameter(rptDoc);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Labour Invoice - [Page Size: A4]";
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
            else if (cmbreports.SelectedIndex == 4)
            {
                try
                {

                    if (dgvServiceModule.CurrentRow == null)
                        return;

                    DataTable dtReport = new DataTable();
                    NameValueCollection Paralist = new NameValueCollection();
                    Paralist.Add("@i_ServiceId", dgvServiceModule.CurrentRow.Cells["ServiceId"].Value.ToString());
                    dtReport = objList.ListOfRecord("rpt_ServiceModule", Paralist, "ServiceModule - Report");
                    //if (objList.Exception == null)
                    //{
                    //dtReport.TableName = "ServiceModuleRegister";
                    //dtReport.WriteXmlSchema(@"D:\ServiceModuleRegister.xsd");
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptServiceVouchar.rpt"))
                    {


                        DataView DVReport;
                        DVReport = dtblItem.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptServiceVouchar.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Service Module", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Service Module - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("File is not exist...");
                    }
                    //}
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Service Module", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            cmbreports.SelectedIndex = 0;


        }


    }
}
