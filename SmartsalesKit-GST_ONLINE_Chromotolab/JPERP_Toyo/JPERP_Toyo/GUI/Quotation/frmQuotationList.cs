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
using System.Configuration;

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
        int _CompId = 0;
        DataView DV;
        int n;
        int i;

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
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#1607#") != -1)
                    {
                        cmbreports.Items.Add("Quotation Preview");
                    }
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1608#") != -1)
                    //{
                    //    cmbreports.Items.Add("Quotation Preview WithoutHeader");
                    //}
                    if (CurrentUser.PrivilegeStr.IndexOf("#1608#") != -1)
                    {
                        cmbreports.Items.Add("Quotation Register");
                    }
                }
                else
                {
                    cmbreports.Items.Add("Quotation Preview");
                    //cmbreports.Items.Add("Quotation Preview WithoutHeader");
                    cmbreports.Items.Add("Quotation Register");
                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Quotation Preview");
               // cmbreports.Items.Add("Quotation Preview WithoutHeader");
                cmbreports.Items.Add("Quotation Register");
            }
            cmbreports.SelectedIndex = 0;

            //objCommon.FillCurrencyCombo(cmbCurrency);

            //cmbCurrency.SelectedIndex = 0;

            AddHandlers(this);
            SetControlsDefaults(this);

            //btnNew.BackColor = Color.LightSkyBlue;

            LoadList();
            LoadFollowUpList();

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#1602#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1603#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1604#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1605#") != -1)
                    { btnrevisedquotation.Enabled = true; }
                    else { btnrevisedquotation.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1606#") != -1)
                    { btnFollowUp.Enabled = true; }
                    else { btnFollowUp.Enabled = false; }
                }
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

                ObjDataTable = objList.ListOfRecord("usp_Quotation_List", para1, "Quotation - List - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvSaleList.CurrentRow != null)
                    {
                        idgvPosition = dgvSaleList.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    for (int i = 0; i < dgvSaleList.Rows.Count; i++)
                    {

                        if (dgvSaleList.Rows[i].Cells["Is_SendMail"].Value.ToString() == "Not Sent")
                        {
                            //this.dgvSaleList.Columns["Is_SendMail"].DefaultCellStyle.ForeColor = Color.Red;
                            dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.BackColor = Color.Green;
                        }
                    }
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
                    DV = ObjDataTable.DefaultView;
                    DV.RowFilter = StrFilter;


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
                dgvSaleList.Columns["Phone1"].DataPropertyName = ObjDataTable.Columns["Phone1"].ToString();
                dgvSaleList.Columns["Email"].DataPropertyName = ObjDataTable.Columns["Email"].ToString();
                dgvSaleList.Columns["Category"].DataPropertyName = ObjDataTable.Columns["Category"].ToString();
                dgvSaleList.Columns["Status"].DataPropertyName = ObjDataTable.Columns["Status"].ToString();
                dgvSaleList.Columns["Remark"].DataPropertyName = ObjDataTable.Columns["Remark"].ToString();
                dgvSaleList.Columns["TakenBy"].DataPropertyName = ObjDataTable.Columns["EmpName"].ToString();
                dgvSaleList.Columns["AllocatedTo"].DataPropertyName = ObjDataTable.Columns["EmpAllTo"].ToString();
                dgvSaleList.Columns["FollowupDate1"].DataPropertyName = ObjDataTable.Columns["FollowupDate1"].ToString();
                dgvSaleList.Columns["Is_SendMail"].DataPropertyName = ObjDataTable.Columns["Is_SendMail"].ToString();
                dgvSaleList.Columns["CompId"].DataPropertyName = ObjDataTable.Columns["CompId"].ToString();

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
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Warning");
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
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Warning");
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
            // dt.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
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
            BinaryReader brLogo;
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

        public void RPT_Sub(Int64 QuotationID, string Code, Boolean _IsList, Boolean _IsTaxation, Boolean _IsCode, Boolean _IsDiscount)
        {
            DataTable dt = new DataTable();
            LogoBind(dt);

            //if (cbIsQuoWithTaxes.Checked)
            //{
            //    mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            //}
            //else
            //{
            mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            //}

            DataTable dtReport = new DataTable();
            //dtReport = CommSelect.SelectRecord(QuotationID, "rpt_Quotation", "Quotation - Report");

            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_RecID", QuotationID.ToString());
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtReport = objList.ListOfRecord("rpt_Quotation", para1, "Quotation - Report");

            DataTable dtTNC = new DataTable();
            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_Code", Code);
            //para.Add("@i_TNC_Sub", "Quotation");

            if (Code.Length > 18)
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", Code);
                para.Add("@i_TNC_Sub", "Revised Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_Revised_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");
            }
            else
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", Code);
                para.Add("@i_TNC_Sub", "Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");
            }

            //dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");

            DataTable dtCompany = new DataTable();
            //dtCompany = objDA.ExecuteDataTableSP("rpt_Company", null, false, ref mException, ref mErrorMsg, "Quotation TNC");
            //dtReport.TableName = "Quotation";
            //dtReport.WriteXmlSchema(@"D:\Quotation.xsd");

            NameValueCollection para2 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtCompany = objList.ListOfRecord("rpt_Company", para2, "Quotation - Report");

            if (CommSelect.Exception == null)
            {
                // if (cbIsQuoWithTaxes.Checked)
                if (_IsTaxation == true)
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotationtax.rpt"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptQuotationtax.rpt");
                        //rptDoc.Subreports[0].DataSourceConnections.Clear();
                        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                        rptDoc.Database.Tables[2].SetDataSource(dt);
                        rptDoc.Refresh();

                        #region Testing Code
                        ///////////////////////     All modes    /////////////////

                        ////if (_IsTaxation == true)// if taxation
                        ////{
                        ////    if (_IsCode == true)
                        ////    {
                        ////        if (_IsDiscount == true)//with tax,with code,with discount
                        ////        {

                        ////        }
                        ////        else                    //with tax,with code,no discount
                        ////        {

                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        if (_IsDiscount == true)//with tax,no code,with discount
                        ////        {

                        ////        }
                        ////        else                    //with tax,no code,no discount
                        ////        {

                        ////        }
                        ////    }
                        ////}
                        ////else //if no taxation
                        ////{
                        ////    if (_IsCode == true)
                        ////    {
                        ////        if (_IsDiscount == true)//no tax,with code,with discount
                        ////        {

                        ////        }
                        ////        else                    //no tax,with code,no discount
                        ////        {

                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        if (_IsDiscount == true)//no tax,no code,with discount
                        ////        {

                        ////        }
                        ////        else                    //no tax,no code,with discount
                        ////        {

                        ////        }
                        ////    }
                        ////}

                        //////////////////////////////////////////


                        ////if (cbIsQuoWithDisc.Checked)//with disc & with code
                        ////{
                        ////    
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtDisc"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["Discount1"].ObjectFormat.EnableSuppress = false;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRD"].ObjectFormat.EnableSuppress = false;
                        ////    //Enlarge right side header & values 

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRD"].ObjectFormat.EnableSuppress = false;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRUN"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRDN"].ObjectFormat.EnableSuppress = true;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRD"].ObjectFormat.EnableSuppress = false;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRUN"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRDN"].ObjectFormat.EnableSuppress = true;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRD"].ObjectFormat.EnableSuppress = false;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRUN"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRDN"].ObjectFormat.EnableSuppress = true;
                        ////    ///////////////////////////////

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnitRate"]).Left = 7560;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Currency1"]).Left = 7560;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Rate1"]).Left = 7680;

                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Right = 7560;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRD"]).Right = 7560;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnit"]).Left = 6600;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["UOM1"]).Left = 6720;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRU"]).Right = 6600;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRD"]).Right = 6600;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtQty"]).Left = 5640;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Qty1"]).Left = 5760;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRU"]).Right = 5640;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRD"]).Right = 5640;

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 3600;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 3360;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 3240;

                        ////}
                        ////else//without disc & with code
                        ////{
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtDisc"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["Discount1"].ObjectFormat.EnableSuppress = true;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRD"].ObjectFormat.EnableSuppress = true;
                        ////    //Enlarge right side header & values   
                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRD"].ObjectFormat.EnableSuppress = true;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRUN"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRDN"].ObjectFormat.EnableSuppress = false;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRD"].ObjectFormat.EnableSuppress = true;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRUN"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRDN"].ObjectFormat.EnableSuppress = false;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRD"].ObjectFormat.EnableSuppress = true;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRUN"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRDN"].ObjectFormat.EnableSuppress = false;
                        ////    ///////////////////////////////

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnitRate"]).Left = 8400;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Currency1"]).Left = 8400;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Rate1"]).Left = 8520;

                        ////    //Line Objects
                        ////    //ReportObject reportObject = rptDoc.ReportDefinition.ReportObjects["lnUnitRU"];

                        ////    //LineObject lineObject = (LineObject)reportObject;

                        ////    //int top = lineObject.Top;

                        ////    //int bottom = lineObject.Bottom;

                        ////    //lineObject.Top = lineObject.Bottom;
                        ////    //lineObject.Bottom = 480;
                        ////    //lineObject.Right = 7560;
                        ////    ////lineObject.Left = 8400;
                        ////    //lineObject.Top = top;
                        ////    //////////////////////

                        ////    ////int top = ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top = ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Bottom;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Right = 11160 - ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Left;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Left = 11160 - ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Left;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top = top;

                        ////    ////// After fliping LineStyle must be set:
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).LineStyle = LineStyle.SingleLine;
                        ////    //////////////////////

                        ////    //bottom = 480
                        ////    //    Right=7560

                        ////    ////////////////////////////////////////////////////////////////////////////////////////
                        ////    //ReportObject reportObject = rptDoc.ReportDefinition.ReportObjects["lnUnitRUNew"];
                        ////    //LineObject lineObject = (LineObject)reportObject;
                        ////    //lineObject.Right = 6000;
                        ////    //lineObject.Bottom = 10;
                        ////    //lineObject.Left = 10;
                        ////    //lineObject.Top = 10;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRUNew"]).LineStyle = LineStyle.SingleLine;
                        ////    //lineObject.EndSectionName = ((SectionFormat)rptDoc.ReportDefinition.ReportObjects["PageHeaderSection1"]).Name.ToString();
                        ////    //PageHeaderSection1



                        ////    ///////////////////////////////////////////////////

                        ////    ////Create a new line Object	
                        ////    //LineObject = new CrystalDecisions.ReportAppServer.ReportDefModel.LineObject();

                        ////    ////Set it's properties
                        ////    //boLineObject.Right = 6000;
                        ////    //boLineObject.Bottom = 10;
                        ////    //boLineObject.Left = 10;
                        ////    //boLineObject.Top = 10;
                        ////    //boLineObject.LineThickness = 15;
                        ////    //boLineObject.LineStyle = CrystalDecisions.ReportAppServer.ReportDefModel.CrLineStyleEnum.crLineStyleSingle;
                        ////    //boLineObject.SectionName = boSectionStart.Name;
                        ////    //boLineObject.EndSectionName = boSectionEnd.Name;

                        ////    ////Does this go into other sections
                        ////    //boLineObject.EnableExtendToBottomOfSection = false;

                        ////    ////Set the section code for the section it is being added to
                        ////    //boLineObject.SectionCode = boSectionStart.SectionCode;

                        ////    ////Add to the report
                        ////    //boReportClientDocument.ReportDefController.ReportObjectController.Add(boLineObject, boSectionStart, -1);


                        ////    ////////////////////////////////////////////////////////////////////////////////////////

                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top = 0;

                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Right = 8400;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRD"]).Right = 8400;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRD"].ObjectFormat.EnableSuppress = true;



                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnit"]).Left = 7440;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["UOM1"]).Left = 7560;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRU"]).Right = 7440;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRD"]).Right = 7440;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtQty"]).Left = 6480;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Qty1"]).Left = 6600;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRU"]).Right = 6480;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRD"]).Right = 6480;

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 4440;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 4200;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 4080;

                        ////}

                        ////if (cbIsQuoWithCode.Checked)//with code & disc
                        ////{
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = false;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = false;
                        ////    //Enlarge right side header & values                            

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 1920;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 4080;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 2040;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 3840;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Left = 2190;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 3690;
                        ////}
                        ////else//without code & disc
                        ////{
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = true;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = true;
                        ////    //Enlarge right side header & values                            

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 720;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 5280;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 840;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 5025;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Left = 975;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 4905;
                        ////}
                        //
                        #endregion
                     
                        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                        CurrentUser.AddExtraParameter(rptDoc);

                        //rptDoc.SetParameterValue("pcmbcurrency", cmbCurrency.Text);                     
                        rptDoc.SetParameterValue("pIsTaxation", _IsTaxation);
                        if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
                        {
                            rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
                        }
                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "QuotationTax - [Page Size: A4]";
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
                }
                else
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation.rpt"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptQuotation.rpt");
                        //rptDoc.Subreports[0].DataSourceConnections.Clear();
                        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                        //rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtReport);

                        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                        rptDoc.Database.Tables[2].SetDataSource(dt);
                        rptDoc.Refresh();
                        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                        CurrentUser.AddExtraParameter(rptDoc);

                        // rptDoc.SetParameterValue("pcmbcurrency", cmbCurrency.Text); 
                      //  rptDoc.SetParameterValue("pIsTaxation", _IsTaxation);
                        if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
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
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }
                //}
                //}
            }
        }

        public void RPT_Sub1(Int64 QuotationID, string Code, Boolean _IsList, Boolean _IsTaxation, Boolean _IsCode, Boolean _IsDiscount)
        {
            DataTable dt = new DataTable();
            //LogoBind(dt);

            //if (cbIsQuoWithTaxes.Checked)
            //{
            //    mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            //}
            //else
            //{
            mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            //}

            DataTable dtReport = new DataTable();
            //dtReport = CommSelect.SelectRecord(QuotationID, "rpt_Quotation", "Quotation - Report");

            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_RecID", QuotationID.ToString());
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtReport = objList.ListOfRecord("rpt_Quotation", para1, "Quotation - Report");

            DataTable dtTNC = new DataTable();
            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_Code", Code);
            //para.Add("@i_TNC_Sub", "Quotation");

            if (Code.Length > 17)
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", Code);
                para.Add("@i_TNC_Sub", "Revised Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_Revised_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");
            }
            else
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", Code);
                para.Add("@i_TNC_Sub", "Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");
            }

            //dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");

            DataTable dtCompany = new DataTable();
            //dtCompany = objDA.ExecuteDataTableSP("rpt_Company", null, false, ref mException, ref mErrorMsg, "Quotation TNC");
            //dtReport.TableName = "Quotation";
            //dtReport.WriteXmlSchema(@"D:\Quotation.xsd");

            NameValueCollection para2 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtCompany = objList.ListOfRecord("rpt_Company", para2, "Quotation - Report");

            if (CommSelect.Exception == null)
            {
                // if (cbIsQuoWithTaxes.Checked)
                if (_IsTaxation == true)
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotationtax.rpt"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptQuotationtax.rpt");
                        //rptDoc.Subreports[0].DataSourceConnections.Clear();
                        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                        rptDoc.Database.Tables[2].SetDataSource(dt);
                        rptDoc.Refresh();

                        #region Testing Code
                        ///////////////////////     All modes    /////////////////

                        ////if (_IsTaxation == true)// if taxation
                        ////{
                        ////    if (_IsCode == true)
                        ////    {
                        ////        if (_IsDiscount == true)//with tax,with code,with discount
                        ////        {

                        ////        }
                        ////        else                    //with tax,with code,no discount
                        ////        {

                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        if (_IsDiscount == true)//with tax,no code,with discount
                        ////        {

                        ////        }
                        ////        else                    //with tax,no code,no discount
                        ////        {

                        ////        }
                        ////    }
                        ////}
                        ////else //if no taxation
                        ////{
                        ////    if (_IsCode == true)
                        ////    {
                        ////        if (_IsDiscount == true)//no tax,with code,with discount
                        ////        {

                        ////        }
                        ////        else                    //no tax,with code,no discount
                        ////        {

                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        if (_IsDiscount == true)//no tax,no code,with discount
                        ////        {

                        ////        }
                        ////        else                    //no tax,no code,with discount
                        ////        {

                        ////        }
                        ////    }
                        ////}

                        //////////////////////////////////////////


                        ////if (cbIsQuoWithDisc.Checked)//with disc & with code
                        ////{
                        ////    
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtDisc"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["Discount1"].ObjectFormat.EnableSuppress = false;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRD"].ObjectFormat.EnableSuppress = false;
                        ////    //Enlarge right side header & values 

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRD"].ObjectFormat.EnableSuppress = false;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRUN"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRDN"].ObjectFormat.EnableSuppress = true;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRD"].ObjectFormat.EnableSuppress = false;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRUN"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRDN"].ObjectFormat.EnableSuppress = true;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRD"].ObjectFormat.EnableSuppress = false;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRUN"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRDN"].ObjectFormat.EnableSuppress = true;
                        ////    ///////////////////////////////

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnitRate"]).Left = 7560;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Currency1"]).Left = 7560;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Rate1"]).Left = 7680;

                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Right = 7560;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRD"]).Right = 7560;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnit"]).Left = 6600;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["UOM1"]).Left = 6720;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRU"]).Right = 6600;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRD"]).Right = 6600;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtQty"]).Left = 5640;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Qty1"]).Left = 5760;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRU"]).Right = 5640;
                        ////    ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRD"]).Right = 5640;

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 3600;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 3360;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 3240;

                        ////}
                        ////else//without disc & with code
                        ////{
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtDisc"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["Discount1"].ObjectFormat.EnableSuppress = true;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnURateRD"].ObjectFormat.EnableSuppress = true;
                        ////    //Enlarge right side header & values   
                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRD"].ObjectFormat.EnableSuppress = true;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRUN"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnItemRDN"].ObjectFormat.EnableSuppress = false;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRD"].ObjectFormat.EnableSuppress = true;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRUN"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnQtyRDN"].ObjectFormat.EnableSuppress = false;
                        ////    ///////////////////////////////

                        ////    ////////////////////////////////
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRD"].ObjectFormat.EnableSuppress = true;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRUN"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRDN"].ObjectFormat.EnableSuppress = false;
                        ////    ///////////////////////////////

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnitRate"]).Left = 8400;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Currency1"]).Left = 8400;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Rate1"]).Left = 8520;

                        ////    //Line Objects
                        ////    //ReportObject reportObject = rptDoc.ReportDefinition.ReportObjects["lnUnitRU"];

                        ////    //LineObject lineObject = (LineObject)reportObject;

                        ////    //int top = lineObject.Top;

                        ////    //int bottom = lineObject.Bottom;

                        ////    //lineObject.Top = lineObject.Bottom;
                        ////    //lineObject.Bottom = 480;
                        ////    //lineObject.Right = 7560;
                        ////    ////lineObject.Left = 8400;
                        ////    //lineObject.Top = top;
                        ////    //////////////////////

                        ////    ////int top = ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top = ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Bottom;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Right = 11160 - ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Left;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Left = 11160 - ((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Left;
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top = top;

                        ////    ////// After fliping LineStyle must be set:
                        ////    ////((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).LineStyle = LineStyle.SingleLine;
                        ////    //////////////////////

                        ////    //bottom = 480
                        ////    //    Right=7560

                        ////    ////////////////////////////////////////////////////////////////////////////////////////
                        ////    //ReportObject reportObject = rptDoc.ReportDefinition.ReportObjects["lnUnitRUNew"];
                        ////    //LineObject lineObject = (LineObject)reportObject;
                        ////    //lineObject.Right = 6000;
                        ////    //lineObject.Bottom = 10;
                        ////    //lineObject.Left = 10;
                        ////    //lineObject.Top = 10;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRUNew"]).LineStyle = LineStyle.SingleLine;
                        ////    //lineObject.EndSectionName = ((SectionFormat)rptDoc.ReportDefinition.ReportObjects["PageHeaderSection1"]).Name.ToString();
                        ////    //PageHeaderSection1



                        ////    ///////////////////////////////////////////////////

                        ////    ////Create a new line Object	
                        ////    //LineObject = new CrystalDecisions.ReportAppServer.ReportDefModel.LineObject();

                        ////    ////Set it's properties
                        ////    //boLineObject.Right = 6000;
                        ////    //boLineObject.Bottom = 10;
                        ////    //boLineObject.Left = 10;
                        ////    //boLineObject.Top = 10;
                        ////    //boLineObject.LineThickness = 15;
                        ////    //boLineObject.LineStyle = CrystalDecisions.ReportAppServer.ReportDefModel.CrLineStyleEnum.crLineStyleSingle;
                        ////    //boLineObject.SectionName = boSectionStart.Name;
                        ////    //boLineObject.EndSectionName = boSectionEnd.Name;

                        ////    ////Does this go into other sections
                        ////    //boLineObject.EnableExtendToBottomOfSection = false;

                        ////    ////Set the section code for the section it is being added to
                        ////    //boLineObject.SectionCode = boSectionStart.SectionCode;

                        ////    ////Add to the report
                        ////    //boReportClientDocument.ReportDefController.ReportObjectController.Add(boLineObject, boSectionStart, -1);


                        ////    ////////////////////////////////////////////////////////////////////////////////////////

                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Top = 0;

                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRU"]).Right = 8400;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnUnitRD"]).Right = 8400;

                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnUnitRD"].ObjectFormat.EnableSuppress = true;



                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtUnit"]).Left = 7440;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["UOM1"]).Left = 7560;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRU"]).Right = 7440;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnQtyRD"]).Right = 7440;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtQty"]).Left = 6480;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["Qty1"]).Left = 6600;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRU"]).Right = 6480;
                        ////    //((LineObject)rptDoc.ReportDefinition.ReportObjects["lnItemRD"]).Right = 6480;

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 4440;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 4200;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 4080;

                        ////}

                        ////if (cbIsQuoWithCode.Checked)//with code & disc
                        ////{
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = false;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = false;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = false;
                        ////    //Enlarge right side header & values                            

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 1920;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 4080;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 2040;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 3840;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Left = 2190;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 3690;
                        ////}
                        ////else//without code & disc
                        ////{
                        ////    //FOR SUPPERSS PRODUCT CODE

                        ////    //suppress header and values
                        ////    rptDoc.ReportDefinition.ReportObjects["txtCode"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["ProductCode1"].ObjectFormat.EnableSuppress = true;

                        ////    //suppress lines
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRU"].ObjectFormat.EnableSuppress = true;
                        ////    rptDoc.ReportDefinition.ReportObjects["lnProCodeRD"].ObjectFormat.EnableSuppress = true;
                        ////    //Enlarge right side header & values                            

                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Left = 720;
                        ////    ((TextObject)rptDoc.ReportDefinition.ReportObjects["txtItemH"]).Width = 5280;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Left = 840;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["ItemName1"]).Width = 5025;

                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Left = 975;
                        ////    ((FieldObject)rptDoc.ReportDefinition.ReportObjects["QItemDesc1"]).Width = 4905;
                        ////}
                        //
                        #endregion
                       // rptDoc.ReportDefinition.ReportObjects["boxfooter"].ObjectFormat.EnableSuppress = true;
                       // rptDoc.ReportDefinition.ReportObjects["boxheader"].ObjectFormat.EnableSuppress = true;

                        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                        CurrentUser.AddExtraParameter(rptDoc);

                        //rptDoc.SetParameterValue("pcmbcurrency", cmbCurrency.Text);                     
                        //rptDoc.SetParameterValue("pIsTaxation", _IsTaxation);
                        if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
                        {
                            rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
                        }
                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "QuotationTax - [Page Size: A4]";
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
                }
                else
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation.rpt"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptQuotation.rpt");
                        //rptDoc.Subreports[0].DataSourceConnections.Clear();
                        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
                        //rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtReport);

                        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                        rptDoc.Database.Tables[2].SetDataSource(dt);
                        rptDoc.Refresh();


                       // rptDoc.ReportDefinition.ReportObjects["boxfooter"].ObjectFormat.EnableSuppress = true;
                        //rptDoc.ReportDefinition.ReportObjects["boxheader"].ObjectFormat.EnableSuppress = true;


                        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                        CurrentUser.AddExtraParameter(rptDoc);

                        // rptDoc.SetParameterValue("pcmbcurrency", cmbCurrency.Text); 
                      //  rptDoc.SetParameterValue("pIsTaxation", _IsTaxation);
                        if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
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
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }
                //}
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
            for (int i = 0; i < dgvSaleList.Rows.Count; i++)
            {

                if (dgvSaleList.Rows[i].Cells["Is_SendMail"].Value.ToString() == "Not Sent")
                {
                    //this.dgvSaleList.Columns["Is_SendMail"].DefaultCellStyle.ForeColor = Color.Red;
                    dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Red;
                }
                else
                {
                    dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Green;
                }
            }
            //for (int i = 0; i < dgvSaleList.Rows.Count; i++)
            //{

            //    if (dgvSaleList.Rows[i].Cells["Is_SendMail"].Value.ToString() == "Not Sent")
            //    {
            //        //this.dgvSaleList.Columns["Is_SendMail"].DefaultCellStyle.ForeColor = Color.Red;
            //        dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Red;
            //    }
            //    else if (dgvSaleList.Rows[i].Cells["Is_SendMail"].Value.ToString() == "Sent")
            //    {
            //        dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Green;
            //    }
            //}

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
                    if (cmbreports.SelectedIndex == 1)
                    {
                        if (dgvSaleList.CurrentRow != null)
                        {
                            if (cbIsQuoWithTaxes.Checked)
                            {
                                RPT_Sub(Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value), dgvSaleList.CurrentRow.Cells["Code"].Value.ToString(), true, true, true, true);
                            }
                            else
                            {
                                RPT_Sub(Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value), dgvSaleList.CurrentRow.Cells["Code"].Value.ToString(), true, false, true, true);
                            }
                        }
                        else
                        {
                            MessageBox.Show(CommSelect.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    //else if (cmbreports.SelectedIndex == 2)
                    //{
                    //    if (dgvSaleList.CurrentRow != null)
                    //    {
                    //        if (cbIsQuoWithTaxes.Checked)
                    //        {
                    //            RPT_Sub1(Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value), dgvSaleList.CurrentRow.Cells["Code"].Value.ToString(), true, true, true, true);
                    //        }
                    //        else
                    //        {
                    //            RPT_Sub1(Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value), dgvSaleList.CurrentRow.Cells["Code"].Value.ToString(), true, false, true, true);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(CommSelect.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}

                    else if (cmbreports.SelectedIndex == 2)
                    {
                        //DataTable dtReport = new DataTable();
                        //dtReport = objList.ListOfRecord("usp_Quotation_List", null, "Quo Regi - Report");
                        //DataView DVReport;
                        //DVReport = ObjDataTable.DefaultView;
                        //DVReport.RowFilter = StrFilter;

                        if (objList.Exception == null)
                        {
                            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotationRegister.rpt"))
                            {
                                //ObjDataTable.TableName = "QuoRegister";
                                //ObjDataTable.WriteXmlSchema(@"D:\QuoRegister.xsd");
                                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                                rptDoc.Load(CurrentUser.ReportPath + "rptQuotationRegister.rpt");
                                //rptDoc.BlankRecords.Height -= (ds.tblItems.Count * 136);
                                CurrentUser.AddReportParameters(rptDoc, DV.ToTable(), "Quotation Register", true, true, true, true, false, true, true, false, false, false, true);

                                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                                fRptView.Text = "Quotation Register - [Page Size: A4]";
                                fRptView.crViewer.ReportSource = rptDoc;
                                fRptView.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                            }
                        }
                    }

                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Quotation - Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
                }
            }

            cmbreports.SelectedIndex = 0;
        }

        private void dgvFollwUps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvSaleList_MouseHover(object sender, EventArgs e)
        {
            //for (int i = 0; i < dgvSaleList.Rows.Count; i++)
            //{

            //    if (dgvSaleList.Rows[i].Cells["Is_SendMail"].Value.ToString() == "Not Sent")
            //    {
            //        //this.dgvSaleList.Columns["Is_SendMail"].DefaultCellStyle.ForeColor = Color.Red;
            //        dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Red;
            //    }
            //    else
            //    {
            //        dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Green;
            //    }
            //}
        }

        private void dgvSaleList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgvSaleList.Rows.Count; i++)
            {

                if (dgvSaleList.Rows[i].Cells["Is_SendMail"].Value.ToString() == "Not Sent")
                {
                    //this.dgvSaleList.Columns["Is_SendMail"].DefaultCellStyle.ForeColor = Color.Red;
                    //dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.BackColor = Color.Red;
                    dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Black;
                }
                else
                {
                    //dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.BackColor = Color.Green;
                    dgvSaleList.Rows[i].Cells["Is_SendMail"].Style.ForeColor = Color.Black;
                }
            }
        }


    }
}
