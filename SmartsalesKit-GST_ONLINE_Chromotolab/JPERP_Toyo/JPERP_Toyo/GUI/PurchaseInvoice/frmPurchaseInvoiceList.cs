/*----------------------------------------------------------------------------------
' Module Name : PurchaseInvoice List
' Created By  : Hetal Patel
' Created Date: 18/09/2010
' Description : This form is used to display PurchaseInvoice List
' Module Change History:
'    Date       Changed By   Description
---------------------------------------------------------------------------------- */

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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Diagnostics;
using System.Configuration;

namespace Account.GUI.PurchaseInvoice
{
    public partial class frmPurchaseInvoiceList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblPurchaseInvoice = new DataTable();
        DataView DV;
        CommonListBL objList = new CommonListBL();
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        string mpdfFile;
        int idgvPosition = 0;
        string StrFilter = "";
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;
        bool valgrid = false;
        Exception mException = null;
        string mErrorMsg = "";
        #endregion

        #region "Form Event"

        public frmPurchaseInvoiceList()
        {
            InitializeComponent();
        }

        private void frmPurchaseInvoiceList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvPurchaseInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();
            cmbreports.Items.Add("--Select Report--");

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9044#") != -1)
                    {
                        cmbreports.Items.Add("Purchase Order Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9045#") != -1)
                    {
                        cmbreports.Items.Add("Purchase Order Detail Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9046#") != -1)
                    {
                        cmbreports.Items.Add("Purchase Order");
                    }
                }
                else
                {
                    cmbreports.Items.Add("Purchase Order Reg_GST");
                    cmbreports.Items.Add("Purchase Order Register");
                    
                    cmbreports.Items.Add("Purchase Order Detail Register");
                    cmbreports.Items.Add("Purchase Order");

                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Purchase Order Reg_GST");
                cmbreports.Items.Add("Purchase Order Register");
                
                cmbreports.Items.Add("Purchase Order Detail Register");
                cmbreports.Items.Add("Purchase Order");

            }

            //cmbreports.Items.Add("PO VS GRN Register");
            cmbreports.SelectedIndex = 0;

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9041#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9042#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9043#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1505#") != -1)
                    //{ btnFollowUp.Enabled = true; }
                    //else { btnFollowUp.Enabled = false; }                 
                }
            }

        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_CompID", CurrentUser.CompId.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());


                dtblPurchaseInvoice = objList.ListOfRecord("usp_PO_List", para, "PurchaseInvoice - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvPurchaseInvoice.CurrentRow != null)
                    {
                        idgvPosition = dgvPurchaseInvoice.CurrentRow.Index;
                    }

                    valgrid = false;
                    ArrangeDataGridView();
                    dgvPurchaseInvoice.AutoGenerateColumns = false;
                    dgvPurchaseInvoice.DataSource = dtblPurchaseInvoice;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvPurchaseInvoice.RowCount.ToString();
                    if (dgvPurchaseInvoice.CurrentRow != null && idgvPosition <= dgvPurchaseInvoice.RowCount)
                    {
                        if (dgvPurchaseInvoice.Rows.Count - 1 < idgvPosition)
                        {
                            dgvPurchaseInvoice.CurrentCell = dgvPurchaseInvoice.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvPurchaseInvoice.CurrentCell = dgvPurchaseInvoice.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvPurchaseInvoice.Columns["PIID"].DataPropertyName = dtblPurchaseInvoice.Columns["PIID"].ToString();
                dgvPurchaseInvoice.Columns["PurchaseCode"].DataPropertyName = dtblPurchaseInvoice.Columns["PurchaseCode"].ToString();
                dgvPurchaseInvoice.Columns["PurchaseDate"].DataPropertyName = dtblPurchaseInvoice.Columns["PurchaseDate"].ToString();
                dgvPurchaseInvoice.Columns["SrNo"].DataPropertyName = dtblPurchaseInvoice.Columns["SrNo"].ToString();
                dgvPurchaseInvoice.Columns["VendorID"].DataPropertyName = dtblPurchaseInvoice.Columns["VendorID"].ToString();
                dgvPurchaseInvoice.Columns["Code"].DataPropertyName = dtblPurchaseInvoice.Columns["Code"].ToString();
                dgvPurchaseInvoice.Columns["VendorName"].DataPropertyName = dtblPurchaseInvoice.Columns["VendorName"].ToString();
                dgvPurchaseInvoice.Columns["DueDays"].DataPropertyName = dtblPurchaseInvoice.Columns["DueDays"].ToString();
                dgvPurchaseInvoice.Columns["DueDate"].DataPropertyName = dtblPurchaseInvoice.Columns["DueDate"].ToString();
                dgvPurchaseInvoice.Columns["TotalAmount"].DataPropertyName = dtblPurchaseInvoice.Columns["TotalAmount"].ToString();
                dgvPurchaseInvoice.Columns["NetAmount"].DataPropertyName = dtblPurchaseInvoice.Columns["NetAmount"].ToString();
                dgvPurchaseInvoice.Columns["Narration"].DataPropertyName = dtblPurchaseInvoice.Columns["Narration"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvPurchaseInvoice.SortedColumn != null)
                {
                    sortedColumn = dgvPurchaseInvoice.SortedColumn;
                    sortDirection = dgvPurchaseInvoice.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();
                DV = dtblPurchaseInvoice.DefaultView;
                DV.RowFilter = StrFilter;

                dgvPurchaseInvoice.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvPurchaseInvoice.RowCount.ToString();

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

                    dgvPurchaseInvoice.Sort(dgvPurchaseInvoice.Columns[sortedColumn.Name], LSD);
                }
                if (dgvPurchaseInvoice.CurrentRow != null && idgvPosition <= dgvPurchaseInvoice.RowCount)
                {
                    if (dgvPurchaseInvoice.Rows.Count - 1 < idgvPosition)
                    {
                        dgvPurchaseInvoice.CurrentCell = dgvPurchaseInvoice.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvPurchaseInvoice.CurrentCell = dgvPurchaseInvoice.Rows[idgvPosition].Cells[0];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblPurchaseInvoice.DefaultView;
            DV.RowFilter = StrFilter;
            dgvPurchaseInvoice.DataSource = DV.ToTable();
            frmPurchaseInvoiceFilter filterSalesinvoice = new frmPurchaseInvoiceFilter(dtblPurchaseInvoice);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvPurchaseInvoice.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvPurchaseInvoice.RowCount.ToString();

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
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmPurchaseInvoiceEntry fPurchaseInvoice = new frmPurchaseInvoiceEntry((int)Constant.Mode.Insert, 0);
                fPurchaseInvoice.ShowDialog();
                LoadList();

                DV = dtblPurchaseInvoice.DefaultView;
                DV.RowFilter = StrFilter;

                dgvPurchaseInvoice.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvPurchaseInvoice.RowCount.ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoice.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmPurchaseInvoiceEntry fPurchaseInvoice = new frmPurchaseInvoiceEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value));
                    fPurchaseInvoice.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnEdit.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseInvoice.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmPurchaseInvoiceEntry fPurchaseInvoice = new frmPurchaseInvoiceEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value));
                    fPurchaseInvoice.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnDelete.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvPurchaseInvoice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvPurchaseInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvPurchaseInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox KeyPress Event"

        private void txtCompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtFromCode_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-");
        }

        #endregion

        #region "LOGOBIND"
        public void LogoBind(DataTable dt)
        {


            //if (cmbreports.SelectedIndex > 0)
            //{
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

            //}
        }

        #endregion

        #region "Report Menu"

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_FYID", CurrentUser.FYID.ToString());

                    para.Add("@i_CompId", CurrentUser.CompId.ToString());

                    dtReport = objList.ListOfRecord("rpt_POGST_Register", para, "PurchaseInvoice - Report");
                    DataView DVReport;
                    DVReport = dtReport.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPurchaseInvoiceRegisterGST.rpt"))
                        {
                            //dtblPurchaseInvoice .TableName = "PORegister";
                            //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptPurchaseInvoiceRegisterGST.rpt");

                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Purchase Order Register", true, true, true, true, false, true, true, false, false, false, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Purchase Order Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Purchase Order - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }






            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_FYID", CurrentUser.FYID.ToString());

                    para.Add("@i_CompId", CurrentUser.CompId.ToString());
                    para.Add("@i_UserId", CurrentUser.UserID.ToString());

                    dtReport = objList.ListOfRecord("rpt_PORegister", para, "PurchaseInvoice - Report");
                    DataView DVReport;
                    DVReport = dtReport.DefaultView;
                    DVReport.RowFilter = StrFilter;

                    if (dtReport.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtReport.Rows.Count; i++)
                        {
                            string ItemCode = dtReport.Rows[i]["ItemCode"].ToString();
                            int OrderBookingID = Convert.ToInt16(dtReport.Rows[i]["PIID"].ToString());
                            int CompId = Convert.ToInt16(dtReport.Rows[i]["CompId"].ToString());

                            DataTable dtSQty = new DataTable();
                            if (ItemCode != "")
                            {
                                NameValueCollection para1 = new NameValueCollection();
                                para1.Add("@i_ItemCode", ItemCode.ToString());
                                para1.Add("@i_POID", OrderBookingID.ToString());
                                para1.Add("@i_CompId", CompId.ToString());

                                dtSQty = objList.ListOfRecord("rpt_Get_ReceivedQty", para1, "PurchaseInvoice - Reports");

                                decimal SQty = 0;
                                if (dtSQty.Rows[0][0].ToString().Trim() == "")
                                {
                                    SQty = 0;
                                }
                                else
                                {
                                    SQty = Convert.ToDecimal(dtSQty.Rows[0][0]);
                                }

                                dtReport.Rows[i]["DQty"] = SQty;
                                dtReport.Rows[i]["Diff"] = Convert.ToDecimal(dtReport.Rows[i]["OQty"]) - SQty;
                                dtReport.Rows[i]["OrdValue"] = Convert.ToDecimal(dtReport.Rows[i]["OQty"]) * Convert.ToDecimal(dtReport.Rows[i]["Rate"]);
                                dtReport.Rows[i]["SupplyValue"] = SQty * Convert.ToDecimal(dtReport.Rows[i]["Rate"]);
                                dtReport.Rows[i]["diff1"] = Convert.ToDecimal(dtReport.Rows[i]["OrdValue"]) - Convert.ToDecimal(dtReport.Rows[i]["SupplyValue"]);
                                string Difference = dtReport.Rows[i]["Diff"].ToString();
                            }
                            else
                            {
                            }

                        }
                        //StrFilter = " Diff <> 0";
                        DVReport = dtReport.DefaultView;
                        DVReport.RowFilter = StrFilter;

                    }


                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPurchaseInvoiceRegisterold.rpt"))
                        {
                            //dtblPurchaseInvoice .TableName = "PORegister";
                            //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptPurchaseInvoiceRegisterold.rpt");

                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Purchase Order Register", true, true, true, true, false, true, true, false, false, false, true);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Purchase Order Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Purchase Order - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }


            else if (cmbreports.SelectedIndex == 3)
            {
                try
                {
                    if (dgvPurchaseInvoice.CurrentRow != null)
                    {
                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_PIID", Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value).ToString());
                        dtReport = objList.ListOfRecord("rpt_PODetail", para, "PurchaseInvoice - Report");
                        DataView DVReport;
                        DVReport = dtReport.DefaultView;
                        DVReport.RowFilter = StrFilter;

                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPurchaseInvoiceRegisterWithDetail.rpt"))
                            {
                                //dtblPurchaseInvoice .TableName = "PORegister";
                                //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptPurchaseInvoiceRegisterWithDetail.rpt");
                                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Purchase Order Detail", true, true, true, true, false, true, true, false, false, false, false);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Purchase Order Detail - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Purchase Invoice - Detail Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 4)
            {
                try
                {
                    RPT_Sub(Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value), dgvPurchaseInvoice.CurrentRow.Cells["PurchaseCode"].Value.ToString(), true);

                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            //else if (cmbreports.SelectedIndex == 4)
            //{
            //    try
            //    {
            //        DataTable dtReport = new DataTable();
            //        NameValueCollection para = new NameValueCollection();
            //        para.Add("@i_FYID", CurrentUser.FYID.ToString());


            //        dtReport = objList.ListOfRecord("rpt_POVsGRN_Register", para, "PurchaseInvoice - Report");
            //        DataView DVReport;
            //        DVReport = dtReport.DefaultView;
            //        DVReport.RowFilter = StrFilter;

            //        if (objList.Exception == null)
            //        {
            //            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPOVsGRNRegister.rpt"))
            //            {
            //                //dtblPurchaseInvoice .TableName = "PORegister";
            //                //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
            //                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //                rptDoc.Load(CurrentUser.ReportPath + "rptPOVsGRNRegister.rpt");

            //                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "PO Vs GRN Register", true, true, true, true, false, true, true, false, false, false, false);

            //                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
            //                fRptView.Text = "PO Vs GRN Register - [Page Size: A4]";
            //                fRptView.crViewer.ReportSource = rptDoc;
            //                fRptView.ShowDialog();
            //            }
            //            else
            //            {
            //                MessageBox.Show("File is not exist...");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    catch (Exception exc)
            //    {
            //        Utill.Common.ExceptionLogger.writeException("Purchase Invoice - Register Report", exc.StackTrace);
            //        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //    }
            //}
            cmbreports.SelectedIndex = 0;
        }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }

        public void RPT_Sub(Int64 PIID, string PurchaseCode, Boolean _IsList)
        {

            mpdfFile = CurrentUser.DocumentPath + @"pdf\Purchase.pdf";
            DataTable dt = new DataTable();
            LogoBind(dt);
            //if (dgvPurchaseInvoice.CurrentRow != null)
            //{
            DataTable dtReport = new DataTable();
            DataTable dtTNC = new DataTable();
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Code", PurchaseCode);
            para.Add("@i_TNC_Sub", "Purchase");
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtTNC = objDA.ExecuteDataTableSP("rpt_Purchase_TNC", para, false, ref mException, ref mErrorMsg, "Purchase TNC");
            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_RecID", Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value).ToString());

            //dtReport = objList.ListOfRecord("rpt_PO", para, "PurchaseInvoice - Report");
            dtReport = CommSelect.SelectRecord(PIID, "rpt_PO", "PurchaseInvoice - Report");

            if (CommSelect.Exception == null)
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPurchaseInvoice.rpt"))
                {
                    //dtblPurchaseInvoice.TableName = "PORegister";
                    //dtblPurchaseInvoice.WriteXmlSchema(@"D:\ERP-CRM\Reports Project\POL_IGMS_Reports\DataSets\PORegister.xsd");
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptPurchaseInvoice.rpt");

                    rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                    rptDoc.Database.Tables[1].SetDataSource(dt);
                    rptDoc.Refresh();
                    CurrentUser.AddReportParameters(rptDoc, dtReport, "Purchase Order", true, true, true, true, true, true, true, true, true, true, false);
                    //CurrentUser.AddExtraParameter(rptDoc);
                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Purchase Order - [Page Size: A4]";
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

            }
        }
    }


}
