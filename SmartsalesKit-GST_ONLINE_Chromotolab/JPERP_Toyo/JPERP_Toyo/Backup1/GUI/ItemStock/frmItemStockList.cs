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
using System.IO;
using System.Configuration;

namespace Account.GUI.ItemStock
{
    public partial class frmItemStockList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblItemStock = new DataTable();
        DataView DV;
        CommonListBL objList = new CommonListBL();
        ItemStockBL objStock = new ItemStockBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        int idgvPosition = 0;
        string StrFilter = "";
        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;

        string filter = "";

        #endregion

        #region "Form Event"

        public frmItemStockList()
        {
            InitializeComponent();
        }

        private void frmItemStockList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvItemStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();
            PaintCell();

            cmbreports.Items.Add("--Select Report--");

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9052#") != -1)
                    {
                        cmbreports.Items.Add("Item Stock Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9053#") != -1)
                    {
                        cmbreports.Items.Add("Bean Card");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9054#") != -1)
                    {
                        cmbreports.Items.Add("Stock Valuation");
                    }
                }
                else
                {
                    cmbreports.Items.Add("Item Stock Register");
                    cmbreports.Items.Add("Bean Card");
                    cmbreports.Items.Add("Stock Valuation");
                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Item Stock Register");
                cmbreports.Items.Add("Bean Card");
                cmbreports.Items.Add("Stock Valuation");
            }
            cmbreports.SelectedIndex = 0;

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9007#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9050#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9009#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9051#") != -1)
                    { BtnAdjustment.Enabled = true; }
                    else { BtnAdjustment.Enabled = false; }
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


                dtblItemStock = objList.ListOfRecord("usp_ItemStock_List", para, "ItemStock - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvItemStock.CurrentRow != null)
                    {
                        idgvPosition = dgvItemStock.CurrentRow.Index;
                    }

                    ArrangeDataGridView();
                    dgvItemStock.AutoGenerateColumns = false;
                    dgvItemStock.DataSource = dtblItemStock;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemStock.RowCount.ToString();
                    if (dgvItemStock.CurrentRow != null && idgvPosition <= dgvItemStock.RowCount)
                    {
                        if (dgvItemStock.Rows.Count - 1 < idgvPosition)
                        {
                            dgvItemStock.CurrentCell = dgvItemStock.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvItemStock.CurrentCell = dgvItemStock.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvItemStock.Columns["StockID"].DataPropertyName = dtblItemStock.Columns["StockID"].ToString();
                dgvItemStock.Columns["ItemID"].DataPropertyName = dtblItemStock.Columns["ItemID"].ToString();
                dgvItemStock.Columns["ItemCode"].DataPropertyName = dtblItemStock.Columns["ItemCode"].ToString();
                dgvItemStock.Columns["ItemName"].DataPropertyName = dtblItemStock.Columns["ItemName"].ToString();
                dgvItemStock.Columns["UOM"].DataPropertyName = dtblItemStock.Columns["UOM"].ToString();
                dgvItemStock.Columns["QOH"].DataPropertyName = dtblItemStock.Columns["QOH"].ToString();
                dgvItemStock.Columns["MinLevel"].DataPropertyName = dtblItemStock.Columns["MinLevel"].ToString();
                dgvItemStock.Columns["MaxLevel"].DataPropertyName = dtblItemStock.Columns["MaxLevel"].ToString();
                dgvItemStock.Columns["ReorderLvl"].DataPropertyName = dtblItemStock.Columns["ReorderLvl"].ToString();
                dgvItemStock.Columns["StockLocation"].DataPropertyName = dtblItemStock.Columns["Location"].ToString();
                dgvItemStock.Columns["RackNo"].DataPropertyName = dtblItemStock.Columns["RackNo"].ToString();
                dgvItemStock.Columns["Godown_name"].DataPropertyName = dtblItemStock.Columns["Godown_name"].ToString();
                dgvItemStock.Columns["ProductCode"].DataPropertyName = dtblItemStock.Columns["ProductCode"].ToString();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvItemStock.SortedColumn != null)
                {
                    sortedColumn = dgvItemStock.SortedColumn;
                    sortDirection = dgvItemStock.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
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

                    dgvItemStock.Sort(dgvItemStock.Columns[sortedColumn.Name], LSD);
                }
                if (dgvItemStock.CurrentRow != null && idgvPosition <= dgvItemStock.RowCount)
                {
                    if (dgvItemStock.Rows.Count - 1 < idgvPosition)
                    {
                        dgvItemStock.CurrentCell = dgvItemStock.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvItemStock.CurrentCell = dgvItemStock.Rows[idgvPosition].Cells[0];
                    }
                }
                dgvItemStock_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void PaintCell()
        {
            for (int i = 0; i < dgvItemStock.RowCount; i++)
            {
                if (Convert.ToDecimal(dgvItemStock.Rows[i].Cells["QOH"].Value) <= Convert.ToDecimal(dgvItemStock.Rows[i].Cells["ReorderLvl"].Value))
                {
                    dgvItemStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        #endregion

        #region "Button Event"



        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                StrFilter = "";

                LoadList();
                PaintCell();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemStockEntry fItemStock = new frmItemStockEntry((int)Constant.Mode.Insert, 0);
                fItemStock.ShowDialog();
                LoadList();

                DV = dtblItemStock.DefaultView;
                DV.RowFilter = StrFilter;

                dgvItemStock.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemStock.RowCount.ToString();
                dgvItemStock_SelectionChanged(sender, e);
                PaintCell();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemStock.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmItemStockEntry fItemStock = new frmItemStockEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvItemStock.CurrentRow.Cells["StockID"].Value));
                    fItemStock.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    //  btnEdit.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemStock.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmItemStockEntry fItemStock = new frmItemStockEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvItemStock.CurrentRow.Cells["StockID"].Value));
                    fItemStock.ShowDialog();
                    setDefaultGridRecords(sender, e);
                    btnDelete.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void BtnAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                frmAdjustStock fAdjust = new frmAdjustStock();

                DV = dtblItemStock.DefaultView;
                DV.RowFilter = StrFilter;

                fAdjust.MyDatatable = DV.ToTable();
                fAdjust.ShowDialog();
                LoadList();
                btnClear_Click(sender, e);
                PaintCell();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvItemStock_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvItemStock, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvItemStock, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvItemStock_Sorted(object sender, EventArgs e)
        {
            if (dgvItemStock.RowCount > 0)
            {
                PaintCell();
            }
        }

        private void dgvItemStock_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                if (dgvItemStock.CurrentRow != null)
                {
                    if (objStock.EnableEditDelete((long)dgvItemStock.CurrentRow.Cells["StockID"].Value))
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox KeyPress Event"

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            //            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtFromCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            //            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
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
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemStockRegister.rpt"))
                    {
                        //dtblItemStock .TableName = "ItemStockRegister";
                        //dtblItemStock.WriteXmlSchema(@"D:\ItemStockRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblItemStock.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptItemStockRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Stock Register", true, true, true, true, false, true, true, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Item Stock Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("ItemStock - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (dgvItemStock.CurrentRow != null)
                    {
                        DataTable dtReport = new DataTable();
                        NameValueCollection para = new NameValueCollection();

                        para.Add("@i_StockID", dgvItemStock.CurrentRow.Cells["StockID"].Value.ToString());
                        dtReport = objList.ListOfRecord("rpt_ItemBeanCard", para, "ItemStock - Bean Card report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemBeanCard.rpt"))
                            {
                                //dtReport .TableName = "ItemBeanCard";
                                //dtReport.WriteXmlSchema(@"D:\Report\ItemBeanCard.xsd");

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptItemBeanCard.rpt");

                                CurrentUser.AddReportParameters(rptDoc, dtReport, "Item Bean Card", true, true, true, true, false, true, true, false, false, false, false);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Item Bean Card - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("ItemStock - Bean Card Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 3)
            {
                try
                {
                    DataTable dt = new DataTable();
                    LogoBind(dt);
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemStockValuationRegister.rpt"))
                    {
                        //dtblItemStock .TableName = "ItemStockValuationRegister";
                        //dtblItemStock.WriteXmlSchema(@"D:\ItemStockValuationRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblItemStock.DefaultView;
                        DVReport.RowFilter = filter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptItemStockValuationRegister.rpt");
                        rptDoc.Database.Tables[1].SetDataSource(dt);
                        rptDoc.Refresh();
                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Stock Valuation Register", true, true, true, true, false, true, true, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Item Stock Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("ItemStock - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;
        }

        #endregion

        private void btnApply_Click_1(object sender, EventArgs e)
        {
            DV = dtblItemStock.DefaultView;
            DV.RowFilter = StrFilter;
            dgvItemStock.DataSource = DV.ToTable();
            frmItemStockFilter filterSalesinvoice = new frmItemStockFilter(dtblItemStock);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvItemStock.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemStock.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }





    }
}
