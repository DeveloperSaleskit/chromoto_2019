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

namespace Account.GUI.MaterialReturn
{
    public partial class frmMaterialReturnList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblItemStock = new DataTable();
        DataView DV;
        CommonListBL objList = new CommonListBL();
        ItemStockBL objStock = new ItemStockBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        CommonSelectBL CommSelect = new CommonSelectBL();
        int idgvPosition = 0;
        string StrFilter = "";
        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;

        string filter = "";

        #endregion

        #region "Form Event"

        public frmMaterialReturnList()
        {
            InitializeComponent();
        }

        private void frmMaterialReturnList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            //dgvItemStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();
            PaintCell();

            cmbreports.Items.Add("--Select Report--");

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9015#") != -1)
                    {
                        cmbreports.Items.Add("Material Return Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9016#") != -1)
                    {
                        cmbreports.Items.Add("Material Return");
                    }

                }
                else
                {
                    cmbreports.Items.Add("Material Return Register");
                    cmbreports.Items.Add("Material Return");

                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Material Return Register");
                cmbreports.Items.Add("Material Return");

            }
            cmbreports.SelectedIndex = 0;

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9012#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9013#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9014#") != -1)
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

                dtblItemStock = objList.ListOfRecord("usp_MaterialReturn_List", para, "ItemStock - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvMaterial.CurrentRow != null)
                    {
                        idgvPosition = dgvMaterial.CurrentRow.Index;
                    }

                    ArrangeDataGridView();
                    dgvMaterial.AutoGenerateColumns = false;
                    dgvMaterial.DataSource = dtblItemStock;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvMaterial.RowCount.ToString();
                    if (dgvMaterial.CurrentRow != null && idgvPosition <= dgvMaterial.RowCount)
                    {
                        if (dgvMaterial.Rows.Count - 1 < idgvPosition)
                        {
                            dgvMaterial.CurrentCell = dgvMaterial.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvMaterial.CurrentCell = dgvMaterial.Rows[idgvPosition].Cells[0];
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

                dgvMaterial.Columns["MaterialIssueCode"].DataPropertyName = dtblItemStock.Columns["MaterialIssueCode"].ToString();
                dgvMaterial.Columns["id"].DataPropertyName = dtblItemStock.Columns["id"].ToString();
                dgvMaterial.Columns["ReturnQty"].DataPropertyName = dtblItemStock.Columns["ReturnQty"].ToString();
                dgvMaterial.Columns["IssueQTY"].DataPropertyName = dtblItemStock.Columns["IssueQTY"].ToString();

                dgvMaterial.Columns["MIID"].DataPropertyName = dtblItemStock.Columns["MIID"].ToString();

                dgvMaterial.Columns["ItemID"].DataPropertyName = dtblItemStock.Columns["ItemID"].ToString();
                dgvMaterial.Columns["ItemName"].DataPropertyName = dtblItemStock.Columns["ItemName"].ToString();
                dgvMaterial.Columns["ItemCode"].DataPropertyName = dtblItemStock.Columns["ItemCode"].ToString();
                dgvMaterial.Columns["emp1"].DataPropertyName = dtblItemStock.Columns["emp1"].ToString();
                dgvMaterial.Columns["ReturnBy"].DataPropertyName = dtblItemStock.Columns["ReturnBy"].ToString();

                dgvMaterial.Columns["emp2"].DataPropertyName = dtblItemStock.Columns["emp2"].ToString();
                dgvMaterial.Columns["ReturnTo"].DataPropertyName = dtblItemStock.Columns["ReturnTo"].ToString();
                //dgvMaterial.Columns["reason"].DataPropertyName = dtblItemStock.Columns["reason"].ToString();

                dgvMaterial.Columns["narration"].DataPropertyName = dtblItemStock.Columns["narration"].ToString();
                dgvMaterial.Columns["GodownID"].DataPropertyName = dtblItemStock.Columns["GodownID"].ToString();
                dgvMaterial.Columns["CompId"].DataPropertyName = dtblItemStock.Columns["CompId"].ToString();
                dgvMaterial.Columns["GodownName"].DataPropertyName = dtblItemStock.Columns["GodownName"].ToString();
                dgvMaterial.Columns["ItemName"].Width = 500;
                dgvMaterial.Columns["narration"].Width = 500;

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Material Issue", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvMaterial.SortedColumn != null)
                {
                    sortedColumn = dgvMaterial.SortedColumn;
                    sortDirection = dgvMaterial.SortOrder;
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

                    dgvMaterial.Sort(dgvMaterial.Columns[sortedColumn.Name], LSD);
                }
                if (dgvMaterial.CurrentRow != null && idgvPosition <= dgvMaterial.RowCount)
                {
                    if (dgvMaterial.Rows.Count - 1 < idgvPosition)
                    {
                        dgvMaterial.CurrentCell = dgvMaterial.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvMaterial.CurrentCell = dgvMaterial.Rows[idgvPosition].Cells[0];
                    }
                }
                // dgvItemStock_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void PaintCell()
        {
            //for (int i = 0; i < dgvItemStock.RowCount; i++)
            //{
            //    if (Convert.ToDecimal(dgvItemStock.Rows[i].Cells["QOH"].Value) <= Convert.ToDecimal(dgvItemStock.Rows[i].Cells["ReorderLvl"].Value))
            //    {
            //        dgvItemStock.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //    }
            //}
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
                frmMaterialReturnEntry frmMaterialReturnEntry = new frmMaterialReturnEntry((int)Constant.Mode.Insert, 0, false);
                frmMaterialReturnEntry.ShowDialog();
                LoadList();

                DV = dtblItemStock.DefaultView;
                DV.RowFilter = StrFilter;

                dgvMaterial.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvMaterial.RowCount.ToString();
                // dgvItemStock_SelectionChanged(sender, e);

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("materialIssueReturn", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Warning");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                long MIID = Convert.ToInt64(dgvMaterial.CurrentRow.Cells["MIID"].Value);
                long MRID = Convert.ToInt64(dgvMaterial.CurrentRow.Cells["id"].Value);
                bool LatestMatriealReturn = false;
                DataTable dtGetMaxMRID = CommSelect.SelectRecord(MIID, "GetMaxMRID", "Indent - check MaxID");



                if (dtGetMaxMRID != null)
                {
                    if (Convert.ToInt64(dtGetMaxMRID.Rows[0][0].ToString()) == MRID)
                    {
                        LatestMatriealReturn = true;
                        SetSortedColumns();
                        frmMaterialReturnEntry frmMaterialReturnEntry = new frmMaterialReturnEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvMaterial.CurrentRow.Cells["id"].Value), LatestMatriealReturn);
                        frmMaterialReturnEntry.ShowDialog();
                        setDefaultGridRecords(sender, e);
                        btnEdit.Focus();


                    }
                    else
                    {
                        LatestMatriealReturn = false;
                        SetSortedColumns();
                        frmMaterialReturnEntry frmMaterialReturnEntry = new frmMaterialReturnEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvMaterial.CurrentRow.Cells["id"].Value), LatestMatriealReturn);
                        frmMaterialReturnEntry.ShowDialog();
                        setDefaultGridRecords(sender, e);
                        btnEdit.Focus();

                        //MessageBox.Show("You can not edit previous GRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //btnEdit.Focus();
                    }
                }



            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("materialIssueReturn", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Warning");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMaterial.CurrentRow != null)
                {
                    SetSortedColumns();


                    long MIID = Convert.ToInt64(dgvMaterial.CurrentRow.Cells["MIID"].Value);
                    long MRID = Convert.ToInt64(dgvMaterial.CurrentRow.Cells["id"].Value);
                    bool LatestMatriealReturn = false;
                    DataTable dtGetMaxMRID = CommSelect.SelectRecord(MIID, "GetMaxMRID", "Indent - check MaxID");



                    if (dtGetMaxMRID != null)
                    {
                        if (Convert.ToInt64(dtGetMaxMRID.Rows[0][0].ToString()) == MRID)
                        {
                            LatestMatriealReturn = true;
                            frmMaterialReturnEntry frmMaterialReturnEntry = new frmMaterialReturnEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvMaterial.CurrentRow.Cells["id"].Value), LatestMatriealReturn);
                            frmMaterialReturnEntry.ShowDialog();
                            setDefaultGridRecords(sender, e);
                            btnDelete.Focus();
                        }
                        else
                        {
                           
                            MessageBox.Show("You can not delete previous GRN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnEdit.Focus();
                        }
                    }


                   
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("materialIssueReturn", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void BtnAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                //    frmAdjustStock fAdjust = new frmAdjustStock();

                //    DV = dtblItemStock.DefaultView;
                //    DV.RowFilter = StrFilter;

                //    fAdjust.MyDatatable = DV.ToTable();
                //    fAdjust.ShowDialog();
                //    LoadList();
                //    btnClear_Click(sender, e);
                //    PaintCell();
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
                    GridDrawCustomHeaderColumns(dgvMaterial, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvMaterial, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvMaterial_Sorted(object sender, EventArgs e)
        {
            //if (dgvMaterial.RowCount > 0)
            //{
            //    //PaintCell();
            //}
        }

        private void dgvMaterial_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //btnEdit.Enabled = true;
                //btnDelete.Enabled = true;
                //if (dgvMaterial.CurrentRow != null)
                //{
                //    if (objStock.EnableEditDelete((long)dgvMaterial.CurrentRow.Cells["StockID"].Value))
                //    {
                //        btnEdit.Enabled = true;
                //        btnDelete.Enabled = true;
                //    }
                //    else
                //    {
                //        btnEdit.Enabled = false;
                //        btnDelete.Enabled = false;
                //    }
                //}

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
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "MaterialReturnRegister.rpt"))
                    {
                        //dtblItemStock .TableName = "ItemStockRegister";
                        //dtblItemStock.WriteXmlSchema(@"D:\ItemStockRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblItemStock.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "MaterialReturnRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Material  Return Register", true, true, true, true, false, true, true, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Material  Return Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("MaterialIssue - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (dgvMaterial.CurrentRow != null)
                    {

                        DataTable dt = new DataTable();
                        LogoBind(dt);
                        DataTable dtReport1 = new DataTable();
                        NameValueCollection para1 = new NameValueCollection();

                        para1.Add("@i_RecID", dgvMaterial.CurrentRow.Cells["id"].Value.ToString());
                        dtReport1 = objList.ListOfRecord("rpt_MaterialReturn", para1, "Material Issue report");
                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "MaterialReturn.rpt"))
                            {
                                //dtReport .TableName = "ItemBeanCard";
                                //dtReport.WriteXmlSchema(@"D:\Report\ItemBeanCard.xsd");

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "MaterialReturn.rpt");
                                rptDoc.Database.Tables[1].SetDataSource(dt);
                                rptDoc.Refresh();
                                CurrentUser.AddReportParameters(rptDoc, dtReport1, "Material return", true, true, true, true, false, true, true, false, false, false, false);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Material return- [Page Size: A4]";
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
            dgvMaterial.DataSource = DV.ToTable();
            frmMaterialReturnFilter filterSalesinvoice = new frmMaterialReturnFilter(dtblItemStock);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvMaterial.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvMaterial.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }





    }
}
