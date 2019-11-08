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
using System.Configuration;

namespace Account.GUI.Indent
{
    public partial class frmIndentList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblPurchaseInvoice = new DataTable();
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

        public frmIndentList()
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
                    if (CurrentUser.PrivilegeStr.IndexOf("#9051#") != -1)
                    {
                        cmbreports.Items.Add("GRN Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9052#") != -1)
                    {
                        cmbreports.Items.Add("GRN Detail Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9053#") != -1)
                    {
                        cmbreports.Items.Add("GRN");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9054#") != -1)
                    {
                        cmbreports.Items.Add("GRN Against C Form");
                    }
                }
                else
                {
                    cmbreports.Items.Add("GRN Register");
                    cmbreports.Items.Add("GRN Detail Register");
                    cmbreports.Items.Add("GRN");
                    cmbreports.Items.Add("GRN Against C Form");
                }
            }
            else if (CurrentUser.UserID == 1)
            {

                cmbreports.Items.Add("GRN Register");
                cmbreports.Items.Add("GRN Detail Register");
                cmbreports.Items.Add("GRN");
                cmbreports.Items.Add("GRN Against C Form");
            }
            cmbreports.SelectedIndex = 0;

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#3402#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#3403#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#3404#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }                        
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
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserId", CurrentUser.UserID.ToString());

                dtblPurchaseInvoice = objList.ListOfRecord("usp_Indent_List", para, "PurchaseInvoice - LoadList");

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
                dgvPurchaseInvoice.Columns["PGID"].DataPropertyName = dtblPurchaseInvoice.Columns["PGID"].ToString();
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
            frmIndentFilter filterSalesinvoice = new frmIndentFilter(dtblPurchaseInvoice);
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
                frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Insert, 0,false);
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

                    long PGID = Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PGID"].Value);
                    long PIID = Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value);
                    bool LatestGRN = false;
                    DataTable dtGetMaxPIID = CommSelect.SelectRecord(PGID, "GetMaxPIID", "Indent - check MaxID");

                    if (dtGetMaxPIID != null)
                    {
                        if (Convert.ToInt64(dtGetMaxPIID.Rows[0][0].ToString()) == PIID)
                        {
                            LatestGRN = true;
                            frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value),LatestGRN);
                            fPurchaseInvoice.ShowDialog();
                            setDefaultGridRecords(sender, e);
                            btnEdit.Focus();
                        }
                        else
                        {
                            LatestGRN = false;
                            frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value), LatestGRN);
                            fPurchaseInvoice.ShowDialog();
                            setDefaultGridRecords(sender, e);
                            btnEdit.Focus();

                            //MessageBox.Show("You can not edit previous GRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //btnEdit.Focus();
                        }
                    }    
                    //frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value));
                    //fPurchaseInvoice.ShowDialog();
                    //setDefaultGridRecords(sender, e);
                    //btnEdit.Focus();
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

                    long PGID = Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PGID"].Value);
                    long PIID = Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value);
                    bool LatestGRN = false;
                    DataTable dtGetMaxPIID = CommSelect.SelectRecord(PGID, "GetMaxPIID", "Indent - check MaxID");

                    if (dtGetMaxPIID != null)
                    {
                        if (Convert.ToInt64(dtGetMaxPIID.Rows[0][0].ToString()) == PIID)
                        {
                            LatestGRN = true;
                            //frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value), LatestGRN);
                            //fPurchaseInvoice.ShowDialog();
                            frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value), LatestGRN);
                            fPurchaseInvoice.ShowDialog();
                            setDefaultGridRecords(sender, e);
                            btnEdit.Focus();
                        }
                        else
                        {
                            //LatestGRN = false;
                            //frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value), LatestGRN);
                            //fPurchaseInvoice.ShowDialog();
                            //setDefaultGridRecords(sender, e);
                            //btnEdit.Focus();

                            MessageBox.Show("You can not delete previous GRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnEdit.Focus();
                        }
                    }
                    //frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value));
                    //fPurchaseInvoice.ShowDialog();
                    //setDefaultGridRecords(sender, e);
                    //btnEdit.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }


            //try
            //{
            //    if (dgvPurchaseInvoice.CurrentRow != null)
            //    {
            //        SetSortedColumns();
            //        frmIndentEntry fPurchaseInvoice = new frmIndentEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value),false);
            //        fPurchaseInvoice.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //        btnDelete.Focus();
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
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
//            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
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
        public void LogoBindold(DataTable dt)
        {


            if (cmbreports.SelectedIndex > 0)
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
                    para.Add("@i_UserId", CurrentUser.UserID.ToString());
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                    dtReport = objList.ListOfRecord("rpt_IndentRegister", para, "Indent - Report");
                    DataView DVReport;
                    DVReport = dtReport.DefaultView;
                    DVReport.RowFilter = StrFilter;

                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptGRNRegister.rpt"))
                        {
                            //dtblPurchaseInvoice .TableName = "PORegister";
                            //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptGRNRegister.rpt");

                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Indent Register", true, true, true, true, false, true, true, false, false, false, false);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Indent Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Indent - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (dgvPurchaseInvoice.CurrentRow != null)
                    {
                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_PIID", Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value).ToString());
                        dtReport = objList.ListOfRecord("rpt_IndentDetail", para, "Indent - Report");
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
                                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Indent Detail", true, true, true, true, false, true, true, false, false, false, false);
                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Indent Detail - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Indent - Detail Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 3)
            {
                try
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (dgvPurchaseInvoice.CurrentRow != null)
                    {
                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_RecID", Convert.ToInt64(dgvPurchaseInvoice.CurrentRow.Cells["PIID"].Value).ToString());

                        dtReport = objList.ListOfRecord("rpt_Indent", para, "Indent - Report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptIndent.rpt"))
                            {
                                //dtblPurchaseInvoice .TableName = "PORegister";
                                //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptIndent.rpt");
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();
                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Indent", true, true, true, true, true, true, true, true, true, true, false);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Indent - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 4)
            {
                try
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_FYID", CurrentUser.FYID.ToString());
                    para.Add("@i_UserId", CurrentUser.UserID.ToString());
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                    dtReport = objList.ListOfRecord("rpt_IndentRegister", para, "Indent - Report");
                    DataView DVReport;
                    DVReport = dtReport.DefaultView;
                    DVReport.RowFilter = StrFilter;

                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptGRNRegister.rpt"))
                        {
                            //dtblPurchaseInvoice .TableName = "PORegister";
                            //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptGRNRegister.rpt");

                            CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Indent Register", true, true, true, true, false, true, true, false, false, false, false);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer(); 
                            fRptView.Text = "Indent Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Indent - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;
        }

        #endregion

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }





    }


}
