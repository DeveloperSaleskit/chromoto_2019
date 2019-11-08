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
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Configuration;

namespace Account.GUI.ItemRegister
{
    public partial class frmItemList : Account.GUIBase
    {

        #region "Variable Declaration...."

        DataTable dtblItem = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDataAccess = new DataAccess.DataAccess();
        ItemBL objItemBL = new ItemBL();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        string strFile = "";
        string CODE = "";
        DataTable dtblCustomer = new DataTable();
        #endregion

        #region "Form Event...."

        public frmItemList()
        {
            InitializeComponent();
        }

        private void frmItemList_Load(object sender, EventArgs e)
        {
            try
            {

                cmbreports.Items.Add("--Select Report--");
                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#6007#") != -1)
                        {
                            cmbreports.Items.Add("Item Register");
                        }
                        if (CurrentUser.PrivilegeStr.IndexOf("#6008#") != -1)
                        {
                            cmbreports.Items.Add("Item Quotation Report");
                        }
                        if (CurrentUser.PrivilegeStr.IndexOf("#6009#") != -1)
                        {
                            cmbreports.Items.Add("Item Sale Report");
                        }
                        if (CurrentUser.PrivilegeStr.IndexOf("#6010#") != -1)
                        {
                            cmbreports.Items.Add("Item Service Report");
                        }
                    }
                    else
                    {
                        cmbreports.Items.Add("Item Register");
                        cmbreports.Items.Add("Item Quotation Report");
                        cmbreports.Items.Add("Item Sales Report");
                        cmbreports.Items.Add("Item Service Report");
                    }
                }
                else if (CurrentUser.UserID == 1)
                {
                    cmbreports.Items.Add("Item Register");
                    cmbreports.Items.Add("Item Quotation Report");
                    cmbreports.Items.Add("Item Sales Report");
                    cmbreports.Items.Add("Item Service Report");
                }
                cmbreports.SelectedIndex = 0;
                AddHandlers(this);
                SetControlsDefaults(this);
                dgvItemRegister.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                LoadList();

                DV = dtblItem.DefaultView;
                DV.RowFilter = StrFilter;

                dgvItemRegister.DataSource = DV.ToTable();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."



        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemEntry fItem = new frmItemEntry((int)Constant.Mode.Insert, 0);
                fItem.ShowInTaskbar = false;
                fItem.ShowDialog();
                LoadList();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemRegister.CurrentRow != null)
                {
                    if (dgvItemRegister.SortedColumn != null)
                    {
                        sortedColumn = dgvItemRegister.SortedColumn;
                        sortDirection = dgvItemRegister.SortOrder;
                    }
                    frmItemEntry fItem = new frmItemEntry((int)Constant.Mode.Modify, (Int64)dgvItemRegister.CurrentRow.Cells["ItemID"].Value);
                    fItem.ShowInTaskbar = false;
                    fItem.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemRegister.CurrentRow != null)
                {
                    if (dgvItemRegister.SortedColumn != null)
                    {
                        sortedColumn = dgvItemRegister.SortedColumn;
                        sortDirection = dgvItemRegister.SortOrder;
                    }

                    frmItemEntry fItem = new frmItemEntry((int)Constant.Mode.Delete, (Int64)dgvItemRegister.CurrentRow.Cells["ItemID"].Value);
                    fItem.ShowInTaskbar = false;
                    fItem.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnUpdateRates_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemRegister.CurrentRow != null)
                {
                    if (dgvItemRegister.SortedColumn != null)
                    {
                        sortedColumn = dgvItemRegister.SortedColumn;
                        sortDirection = dgvItemRegister.SortOrder;
                    }
                    frmItemPriceList fItem = new frmItemPriceList((Int64)dgvItemRegister.CurrentRow.Cells["ItemID"].Value, StrFilter);
                    fItem.ShowInTaskbar = false;
                    fItem.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
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
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblItem = objList.ListOfRecord("usp_Item_List", para, "Item - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvItemRegister.CurrentRow != null)
                    {
                        idgvPosition = dgvItemRegister.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvItemRegister.AutoGenerateColumns = false;
                    dgvItemRegister.DataSource = dtblItem;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemRegister.RowCount.ToString();
                    if (dgvItemRegister.CurrentRow != null && idgvPosition <= dgvItemRegister.RowCount)
                    {
                        if (dgvItemRegister.Rows.Count - 1 < idgvPosition)
                        {
                            dgvItemRegister.CurrentCell = dgvItemRegister.Rows[idgvPosition - 1].Cells[1];
                        }
                        else
                        {
                            dgvItemRegister.CurrentCell = dgvItemRegister.Rows[idgvPosition].Cells[1];
                        }
                    }
                    ArrangeDataGridView();
                    dtblCustomer = objList.ListOfRecord("rpt_Sales_Service_Quotation", null, "Item - Report");
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvItemRegister.Columns["ItemID"].DataPropertyName = dtblItem.Columns["ItemID"].ToString();
                dgvItemRegister.Columns["iCode"].DataPropertyName = dtblItem.Columns["iCode"].ToString();
                dgvItemRegister.Columns["Name"].DataPropertyName = dtblItem.Columns["ITEMNAME"].ToString();
                dgvItemRegister.Columns["UOMID"].DataPropertyName = dtblItem.Columns["UOMID"].ToString();
                dgvItemRegister.Columns["UOM"].DataPropertyName = dtblItem.Columns["UOM"].ToString();
                dgvItemRegister.Columns["Currency"].DataPropertyName = dtblItem.Columns["Currency"].ToString();
                dgvItemRegister.Columns["CurrencyID"].DataPropertyName = dtblItem.Columns["CurrencyID"].ToString();
                dgvItemRegister.Columns["CurrencyName"].DataPropertyName = dtblItem.Columns["CurrencyName"].ToString();
                dgvItemRegister.Columns["Specification"].DataPropertyName = dtblItem.Columns["Specification"].ToString();
                dgvItemRegister.Columns["Price"].DataPropertyName = dtblItem.Columns["Price"].ToString();
                dgvItemRegister.Columns["HSNCode"].DataPropertyName = dtblItem.Columns["HSNCode"].ToString();
                dgvItemRegister.Columns["ProductCode"].DataPropertyName = dtblItem.Columns["ProductCode"].ToString();

                dgvItemRegister.Columns["Godown"].DataPropertyName = dtblItem.Columns["Godown"].ToString();
                dgvItemRegister.Columns["QOH"].DataPropertyName = dtblItem.Columns["QOH"].ToString();
                dgvItemRegister.Columns["ReorderLevel"].DataPropertyName = dtblItem.Columns["ReorderLevel"].ToString();
                dgvItemRegister.Columns["Location"].DataPropertyName = dtblItem.Columns["Location"].ToString();
                dgvItemRegister.Columns["RackNo"].DataPropertyName = dtblItem.Columns["RackNo"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();

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

                    dgvItemRegister.Sort(dgvItemRegister.Columns[sortedColumn.Name], LSD);
                }
                if (dgvItemRegister.CurrentRow != null && idgvPosition <= dgvItemRegister.RowCount)
                {
                    if (dgvItemRegister.Rows.Count - 1 < idgvPosition)
                    {
                        dgvItemRegister.CurrentCell = dgvItemRegister.Rows[idgvPosition - 1].Cells[1];
                    }
                    else
                    {
                        dgvItemRegister.CurrentCell = dgvItemRegister.Rows[idgvPosition].Cells[1];
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
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
                    GridDrawCustomHeaderColumns(dgvItemRegister, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvItemRegister, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox KeyPress Event"

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            DataValidator.AllowOnlyCharacter(ascii, e);
        }

        #endregion

        #region "Report viewer...."

        private void mnuItemRegister_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnUploadCustomer_Click(object sender, EventArgs e)
        {
            strFile = CurrentUser.DocumentPath + @"Upload\Item.xls";
            //using (WebClient webClient = new WebClient())
            //{
            //    webClient.DownloadFile(strFile, CurrentUser.DocumentPath + "Item.xls");                
            //}
            File.Copy(strFile, CurrentUser.DocumentPath + "Item.xls", true);
            MessageBox.Show("Your File Save on following Path - " + CurrentUser.DocumentPath + "Item.xls");

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

                    objDataAccess.Upload("Temp_Item", SelectedFileName);

                    DataTable dtblImport = new DataTable();
                    dtblImport = objList.ListOfRecord("usp_Import_Item_List", null, "Import Item - LoadList");
                    if (ExcelFile.ToString() == "Item.xls")
                    {
                        for (int i = 0; i < dtblImport.Rows.Count; i++)
                        {
                            if (dtblImport.Rows[i]["ITEM"].ToString().Trim() != "" && dtblImport.Rows[i]["ITEM"].ToString() != null)
                            {
                                Int64 CAT_ID, UOM_ID, CLASS_ID, Godown_ID, Currency_ID;


                                DataTable dtMaxCode = new DataTable();
                                dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code_Item", null, "MAX ITEM - LoadList");


                                if (dtMaxCode.Rows[0][0].ToString() == null || dtMaxCode.Rows[0][0].ToString().Trim() == "")
                                {
                                    CODE = "ITEM-00001";
                                }
                                else
                                {
                                    CODE = "ITEM-" + (Convert.ToInt16(dtMaxCode.Rows[0][0].ToString().Substring(5, 5).TrimStart('0')) + 1).ToString().PadLeft(5, '0');
                                }


                                DataTable dtUOMId = new DataTable();
                                NameValueCollection ParaUOM = new NameValueCollection();
                                ParaUOM.Add("@i_UOM", dtblImport.Rows[i]["UOM"].ToString());
                                dtUOMId = objList.ListOfRecord("usp_Select_UOMID", ParaUOM, "Item Class - LoadList");
                                if (dtUOMId.Rows.Count > 0)
                                {
                                    UOM_ID = Convert.ToInt64(dtUOMId.Rows[0][0].ToString());
                                }
                                else
                                {
                                    UOM_ID = 0;
                                }

                                DataTable dtCurrencyId = new DataTable();
                                NameValueCollection ParaCurrency = new NameValueCollection();
                                ParaCurrency.Add("@i_Currency", dtblImport.Rows[i]["CURRENCY"].ToString());
                                dtCurrencyId = objList.ListOfRecord("usp_Select_CurrencyID", ParaCurrency, "Item Class - LoadList");
                                if (dtCurrencyId.Rows.Count > 0)
                                {
                                    Currency_ID = Convert.ToInt64(dtCurrencyId.Rows[0][0].ToString());
                                }
                                else
                                {
                                    Currency_ID = 0;
                                }

                                string Othername = "";
                                //if (dtblImport.Rows[i]["OTHER_NAME"].ToString().Trim() != "" || dtblImport.Rows[i]["OTHER_NAME"].ToString() != null)
                                //{
                                //    Othername = dtblImport.Rows[i]["OTHER_NAME"].ToString();
                                //}
                                //else
                                //{
                                //    Othername = "";
                                //}
                                string Description = "";
                                string PRODUCT_CODE = "";
                                string HSN_CODE = "";


                                decimal OPENINGSTOCK = 0;
                                decimal REORDERLEVEL = 0;
                                string LOCATION = "";
                                string RACKNO = "";

                                if (dtblImport.Rows[i]["DESCRIPTION"].ToString().Trim() != "" || dtblImport.Rows[i]["DESCRIPTION"].ToString() != null)
                                {
                                    Description = dtblImport.Rows[i]["DESCRIPTION"].ToString();
                                }
                                else
                                {
                                    Description = "";
                                }
                                decimal Price = 0;
                                if (dtblImport.Rows[i]["Price"].ToString().Trim() != "")
                                {
                                    Price = Convert.ToDecimal(dtblImport.Rows[i]["Price"].ToString());
                                }
                                else
                                {
                                    Price = 0;
                                }
                                if (dtblImport.Rows[i]["PRODUCT_CODE"].ToString().Trim() != "" || dtblImport.Rows[i]["PRODUCT_CODE"].ToString() != null)
                                {
                                    PRODUCT_CODE = dtblImport.Rows[i]["PRODUCT_CODE"].ToString();
                                }
                                else
                                {
                                    PRODUCT_CODE = "";
                                }
                                if (dtblImport.Rows[i]["HSN_CODE"].ToString().Trim() != "" || dtblImport.Rows[i]["HSN_CODE"].ToString() != null)
                                {
                                    HSN_CODE = dtblImport.Rows[i]["HSN_CODE"].ToString();
                                }
                                else
                                {
                                    HSN_CODE = "";
                                }

                                DataTable dtGodownId = new DataTable();
                                NameValueCollection ParaGD = new NameValueCollection();
                                ParaGD.Add("@i_GODOWN", dtblImport.Rows[i]["GODOWN"].ToString());
                                dtGodownId = objList.ListOfRecord("usp_Select_GODOWNID", ParaGD, "Item Class - LoadList");
                                //if (dtGodownId.Rows.Count > 0)
                                //{
                                //    Godown_ID = Convert.ToInt64(dtGodownId.Rows[0][0].ToString());
                                //}
                                //else
                                //{
                                Godown_ID = 1;
                                //}

                                if (dtblImport.Rows[i]["OPENING STOCK"].ToString().Trim() != "" || dtblImport.Rows[i]["OPENING STOCK"].ToString() != null)
                                {
                                    if (dtblImport.Rows[i]["OPENING STOCK"].ToString() == "")
                                    {

                                    }
                                    else
                                    {
                                        OPENINGSTOCK = Convert.ToDecimal(dtblImport.Rows[i]["OPENING STOCK"].ToString());
                                    }
                                }
                                else
                                {
                                    OPENINGSTOCK = 0;
                                }

                                if (dtblImport.Rows[i]["REORDER LEVEL"].ToString().Trim() != "" || dtblImport.Rows[i]["REORDER LEVEL"].ToString() != null)
                                {
                                    if (dtblImport.Rows[i]["REORDER LEVEL"].ToString() == "")
                                    {

                                    }
                                    else
                                    {
                                        REORDERLEVEL = Convert.ToDecimal(dtblImport.Rows[i]["REORDER LEVEL"].ToString());
                                    }
                                }
                                else
                                {
                                    REORDERLEVEL = 0;
                                }

                                if (dtblImport.Rows[i]["LOCATION"].ToString().Trim() != "" || dtblImport.Rows[i]["LOCATION"].ToString() != null)
                                {
                                    LOCATION = dtblImport.Rows[i]["LOCATION"].ToString();
                                }
                                else
                                {
                                    LOCATION = "";
                                }

                                if (dtblImport.Rows[i]["RACK NO"].ToString().Trim() != "" || dtblImport.Rows[i]["RACK NO"].ToString() != null)
                                {
                                    RACKNO = dtblImport.Rows[i]["RACK NO"].ToString();
                                }
                                else
                                {
                                    RACKNO = "";
                                }

                                objItemBL.Insert(CODE,
                                                    dtblImport.Rows[i]["ITEM"].ToString(),
                                                    Othername,
                                                    Description,
                                                    UOM_ID,
                                                    Price, PRODUCT_CODE, HSN_CODE, "", 0,
                                                    OPENINGSTOCK,
                                                    Convert.ToDecimal(REORDERLEVEL), LOCATION, RACKNO, Convert.ToInt32(Godown_ID), "", Currency_ID
                                                    );
                            }
                        }

                        MessageBox.Show("Data Uploded Successfully..!!");
                        LoadList();
                    }
                    else
                    {
                        MessageBox.Show("Select Proper Item.xls File.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {

            // frmItemFilter filterSalesinvoice = new frmItemFilter(dtblItem);
            // filterSalesinvoice.ShowDialog();
            // StrFilter = filterSalesinvoice.STRFILTER;
            //// DataTable dt = DV.ToTable();
            // dgvItemRegister.DataSource = DV.ToTable();
            // lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemRegister.RowCount.ToString();

            // ArrangeDataGridView();

            try
            {
                DV = dtblItem.DefaultView;
                DV.RowFilter = StrFilter;
                dgvItemRegister.DataSource = DV.ToTable();
                frmItemFilter filterSalesinvoice = new frmItemFilter(dtblItem, dtblCustomer);
                filterSalesinvoice.ShowDialog();
                DataTable dt = DV.ToTable();
                dgvItemRegister.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemRegister.RowCount.ToString();
                StrFilter = filterSalesinvoice.STRFILTER;//rooja
                ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
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
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemRegister.rpt"))
                    {
                        dtblItem.TableName = "ItemRegister";
                        dtblItem.WriteXmlSchema(@"D:\ItemRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblItem.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptItemRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Item Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }

            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {

                    DataTable dtReport = new DataTable();
                    dtReport = objList.ListOfRecord("rpt_Sales_Service_Quotation", null, "Item - Report");

                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemSales.rpt"))
                        {
                            //dtReport.TableName = "ItemSales";
                            //dtReport.WriteXmlSchema(@"D:\ItemSales.xsd");                          

                            DataView DVReport; //rooja
                            DVReport = dtReport.DefaultView;//rooja

                            if (StrFilter != "")
                            {
                                StrFilter = StrFilter + " And ";
                                StrFilter = StrFilter + " TYPE = 'QUOTATION' And ";


                                if (StrFilter != "")
                                {
                                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                                }

                                DVReport.RowFilter = StrFilter;//rooja

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptItemSales.rpt");

                                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Quotation Report", true, true, true, true, false, true, true, false, false, false, true);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Item Sales Report - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please filter data with Customer name and/or Item name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnfilter.Focus();
                            }
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
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            else if (cmbreports.SelectedIndex == 3)
            {
                try
                {

                    DataTable dtReport = new DataTable();
                    dtReport = objList.ListOfRecord("rpt_Sales_Service_Quotation", null, "Item - Report");

                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemSales.rpt"))
                        {
                            //dtReport.TableName = "ItemSales";
                            //dtReport.WriteXmlSchema(@"D:\ItemSales.xsd");                          

                            DataView DVReport; //rooja
                            DVReport = dtReport.DefaultView;//rooja
                            if (StrFilter != "")
                            {
                                StrFilter = StrFilter + " And ";
                                StrFilter = StrFilter + " TYPE = 'Sales' And ";


                                if (StrFilter != "")
                                {
                                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                                }

                                DVReport.RowFilter = StrFilter;//rooja

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptItemSales.rpt");

                                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Quotation Report", true, true, true, true, false, true, true, false, false, false, true);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Item Sales Report - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please filter data with Customer name and/or Item name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnfilter.Focus();
                            }
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
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 4)
            {
                try
                {

                    DataTable dtReport = new DataTable();
                    dtReport = objList.ListOfRecord("rpt_Sales_Service_Quotation", null, "Item - Report");

                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemSales.rpt"))
                        {
                            //dtReport.TableName = "ItemSales";
                            //dtReport.WriteXmlSchema(@"D:\ItemSales.xsd");                          

                            DataView DVReport; //rooja
                            DVReport = dtReport.DefaultView;//rooja
                            if (StrFilter != "")
                            {
                                StrFilter = StrFilter + " And ";
                                StrFilter = StrFilter + " TYPE = 'Service' And ";


                                if (StrFilter != "")
                                {
                                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                                }

                                DVReport.RowFilter = StrFilter;//rooja

                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptItemSales.rpt");

                                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Quotation Report", true, true, true, true, false, true, true, false, false, false, true);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Item Sales Report - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please filter data with Customer name and/or Item name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                btnfilter.Focus();
                            }
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
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Sales Invoice - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            cmbreports.SelectedIndex = 0;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// creating Excel Application
            //Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();


            //// creating new WorkBook within Excel application
            //Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);


            //// creating new Excelsheet in workbook
            //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            //// see the excel sheet behind the program
            //app.Visible = true;

            //// get the reference of first sheet. By default its name is Sheet1.
            //// store its reference to worksheet
            //worksheet = workbook.Sheets["Sheet1"];
            //worksheet = workbook.ActiveSheet;

            //// changing the name of active sheet
            //worksheet.Name = "Exported from gridview";


            //// storing header part in Excel
            //for (int i = 1; i < dgvItemRegister.Columns.Count + 1; i++)
            //{
            //    worksheet.Cells[1, i] = dgvItemRegister.Columns[i - 1].HeaderText;
            //}



            //// storing Each row and column value to excel sheet
            //for (int i = 0; i < dgvItemRegister.Rows.Count - 1; i++)
            //{
            //    for (int j = 0; j < dgvItemRegister.Columns.Count; j++)
            //    {
            //        worksheet.Cells[i + 2, j + 1] = dgvItemRegister.Rows[i].Cells[j].Value.ToString();
            //    }
            //}


            //// save the application
            //workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //// Exit from the application
            //app.Quit();

            //------------------------------------------------------

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvItemRegister, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }


    }
}


