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
using System.Net;
using System.Configuration;
using Excel;
using System.IO;
using System.Data.SqlClient;
namespace Account.GUI.Vendor
{
    public partial class frmVendorList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblVendor = new DataTable();
        DataTable dtblItem = new DataTable();
        DataTable dtblPriceList = new DataTable();

        DataView DV;

        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDataAccess = new DataAccess.DataAccess();
        VendorBL objVendorBL = new VendorBL();

        int idgvPosition = 0;
        string StrFilter = "";
        bool valVendor = false;
        bool valItem = false;
        string strFile = "";

        System.Windows.Forms.SortOrder sortDirection;
        DataGridViewColumn sortedColumn;

        #endregion

        #region "Form Event"

        public frmVendorList()
        {
            InitializeComponent();
        }

        private void frmVendorList_Load(object sender, EventArgs e)
        {
            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9028#") != -1)
                    {
                        cmbreports.Items.Add("Vendor Register");
                    }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9029#") != -1)
                    {
                        cmbreports.Items.Add("Mailing Label");
                    }
                }
                else
                {
                    cmbreports.Items.Add("Vendor Register");
                    cmbreports.Items.Add("Mailing Label");
                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Vendor Register");
                cmbreports.Items.Add("Mailing Label");
            }
            cmbreports.SelectedIndex = 0;

            


            AddHandlers(this);
            SetControlsDefaults(this);

            dgvVendor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

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
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1505#") != -1)
                    //{ btnFollowUp.Enabled = true; }
                    //else { btnFollowUp.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9030#") != -1)
                    { groupBox1.Visible = false; }
                    else { btnUploadCustomer.Enabled = true; }
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
                para1.Add("@i_UserID", CurrentUser.UserID.ToString());
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblVendor = objList.ListOfRecord("usp_Vendor_List", para1, "Vendor - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvVendor.CurrentRow != null)
                    {
                        idgvPosition = dgvVendor.CurrentRow.Index;
                    }
                    valVendor = false;
                    ArrangeDataGridView();
                    dgvVendor.AutoGenerateColumns = false;
                    dgvVendor.DataSource = dtblVendor;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvVendor.RowCount.ToString();
                    if (dgvVendor.CurrentRow != null && idgvPosition <= dgvVendor.RowCount)
                    {
                        if (dgvVendor.Rows.Count - 1 < idgvPosition)
                        {
                            dgvVendor.CurrentCell = dgvVendor.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvVendor.CurrentCell = dgvVendor.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                    valVendor = true;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvVendor.Columns["VendorID"].DataPropertyName = dtblVendor.Columns["VendorID"].ToString();
                dgvVendor.Columns["Code"].DataPropertyName = dtblVendor.Columns["Code"].ToString();
                dgvVendor.Columns["Company"].DataPropertyName = dtblVendor.Columns["Company"].ToString();
                dgvVendor.Columns["Address"].DataPropertyName = dtblVendor.Columns["Address"].ToString();
                dgvVendor.Columns["CityID"].DataPropertyName = dtblVendor.Columns["CityID"].ToString();
                dgvVendor.Columns["City"].DataPropertyName = dtblVendor.Columns["City"].ToString();
                dgvVendor.Columns["Pincode"].DataPropertyName = dtblVendor.Columns["Pincode"].ToString();
                dgvVendor.Columns["Phone1"].DataPropertyName = dtblVendor.Columns["Phone1"].ToString();
                dgvVendor.Columns["Fax"].DataPropertyName = dtblVendor.Columns["Fax"].ToString();
                dgvVendor.Columns["Mobile"].DataPropertyName = dtblVendor.Columns["Mobile"].ToString();
                dgvVendor.Columns["ContactName"].DataPropertyName = dtblVendor.Columns["ContactName"].ToString();
                dgvVendor.Columns["remarks"].DataPropertyName = dtblVendor.Columns["remarks"].ToString();
                dgvVendor.Columns["category"].DataPropertyName = dtblVendor.Columns["category"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvVendor.SortedColumn != null)
                {
                    sortedColumn = dgvVendor.SortedColumn;
                    sortDirection = dgvVendor.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
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
                    if (sortDirection == System.Windows.Forms.SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvVendor.Sort(dgvVendor.Columns[sortedColumn.Name], LSD);
                }
                if (dgvVendor.CurrentRow != null && idgvPosition <= dgvVendor.RowCount)
                {
                    if (dgvVendor.Rows.Count - 1 < idgvPosition)
                    {
                        dgvVendor.CurrentCell = dgvVendor.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvVendor.CurrentCell = dgvVendor.Rows[idgvPosition].Cells[0];
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button Event"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblItem.DefaultView;
            DV.RowFilter = StrFilter;
            dgvVendor.DataSource = DV.ToTable();
            frmVendorFilter filterSalesinvoice = new frmVendorFilter(dtblItem);
            filterSalesinvoice.ShowDialog();
            DataTable dt = DV.ToTable();
            dgvVendor.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvVendor.RowCount.ToString();

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
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendorEntry fVendor = new frmVendorEntry((int)Constant.Mode.Insert, 0);
                fVendor.ShowDialog();
                LoadList();
                btnClear_Click(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendor.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmVendorEntry fVendor = new frmVendorEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvVendor.CurrentRow.Cells["VendorID"].Value));
                    fVendor.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendor.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmVendorEntry fVendor = new frmVendorEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvVendor.CurrentRow.Cells["VendorID"].Value));
                    fVendor.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvVendor.CurrentRow != null)
            //    {
            //        SetSortedColumns();
            //        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(0, Convert.ToInt64(dgvVendor.CurrentRow.Cells["VendorID"].Value));
            //        fContact.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBillingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendor.CurrentRow != null)
                {
                    GUI.BillingAddress.frmBillingAddress fBilling = new Account.GUI.BillingAddress.frmBillingAddress(0, Convert.ToInt64(dgvVendor.CurrentRow.Cells["VendorID"].Value));
                    fBilling.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Billing Address", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid View Event"

        private void dgvVendor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvVendor, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvVendor, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
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
            int ascii = e.KeyChar;
//            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        #endregion

        #region "Report Menu"

        private void rptvendorRegister_Click(object sender, EventArgs e)
        {

        }

        private void rptMailingLabel_Click(object sender, EventArgs e)
        {

        }

        private void mnuPriceListRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendor.CurrentRow != null)
                {
                    DataTable dtReport = new DataTable();
                    NameValueCollection para = new NameValueCollection();

                    para.Add("@i_VendorID", dgvVendor.CurrentRow.Cells["VendorID"].Value.ToString());
                    dtReport = objList.ListOfRecord("rpt_VendorPriceListRegister", para, "Vendor - PriceList report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPriceList.rpt"))
                        {
                            //dtReport.TableName = "PriceListRegister";
                            //dtReport.WriteXmlSchema(@"D:\Report\PriceListRegister.xsd");

                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptPriceList.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Price List Register", true, true, true, false, false, true, true, false, false, false, false);
                            rptDoc.SetParameterValue("pVendorCode", dgvVendor.CurrentRow.Cells["Code"].Value.ToString());
                            rptDoc.SetParameterValue("pVendorName", dgvVendor.CurrentRow.Cells["Company"].Value.ToString());
                            rptDoc.SetParameterValue("pVendorCity", dgvVendor.CurrentRow.Cells["City"].Value.ToString());
                            rptDoc.SetParameterValue("pVendorPhone", dgvVendor.CurrentRow.Cells["Phone1"].Value.ToString());
                            rptDoc.SetParameterValue("pCST", CurrentCompany.CST);
                            rptDoc.SetParameterValue("pECC", CurrentCompany.ECC);
                            rptDoc.SetParameterValue("pTin", CurrentCompany.TIN);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Price List Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Vendor - PriceList report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void btnUploadCustomer_Click(object sender, EventArgs e)
        {
            strFile = CurrentUser.DocumentPath + @"Upload\Vendor.xls";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(strFile, CurrentUser.DocumentPath + "Vendor.xls");
                //webClient.DownloadFile(strFile, @"D:\Vendor.xls");
            }
           // MessageBox.Show("Your File Save on following Path - " + "D:\\Vendor.xls");
            MessageBox.Show("Your File Save on following Path - " + CurrentUser.DocumentPath + "Vendor.xls");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string ExcelFile = "";
            string SelectedFileName = "";

            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                ExcelFile = ofd.SafeFileName;
                SelectedFileName = ofd.FileName;
            }

           // objDataAccess.Upload("Temp_Vendor", SelectedFileName);
            FileInfo f = new FileInfo(SelectedFileName);
            FileStream fstr = f.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Stream stream = fstr;
            IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(stream);
            reader.IsFirstRowAsColumnNames = true;

            DataSet dsExcel = reader.AsDataSet();
            reader.Close();
            DataTable dtExcel = dsExcel.Tables[0];
            string drop = "";
            drop = "Delete FROM Temp_Vendor";
            SqlCommand cmddrop = new SqlCommand(drop, DataAccess.DataAccess.cnnConnection);
            DataAccess.DataAccess.cnnConnection.Open();
            cmddrop.ExecuteNonQuery();
            DataAccess.DataAccess.cnnConnection.Close();
            UploadExcel(dtExcel);
            DataTable dtblImport = new DataTable();
            dtblImport = objList.ListOfRecord("usp_Import_Vendor_List", null, "Import Vendor - LoadList");

            for (int i = 0; i < dtblImport.Rows.Count; i++)
            {
                if (dtblImport.Rows[i]["COMPANY"].ToString().Trim() != "" && dtblImport.Rows[i]["COMPANY"].ToString() != null)
                {
                    Int16 CityID;
                    int CREADITDAYS;
                    decimal CRAMOUNT, DBAMOUNT;
                    DateTime TRANSDATE;
                    string CODE = "";
                    DataTable dtMaxCode = new DataTable();
                    dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code_Vendor", null, "MAX Vendor - LoadList");

                    //if (dtMaxCode.Rows[0][0].ToString() == null || dtMaxCode.Rows[0][0].ToString().Trim() == "")
                    //{
                    //    CODE = "VEN-00001";
                    //}
                    //else
                    //{
                    //    CODE = "VEN-" + (Convert.ToInt16(dtMaxCode.Rows[0][0].ToString().Substring(4, 5).TrimStart('0')) + 1).ToString().PadLeft(5, '0');
                    //}

                    DataTable dtCityId = new DataTable();
                    NameValueCollection ParaCity = new NameValueCollection();
                    ParaCity.Add("@i_City", dtblImport.Rows[i]["CITY"].ToString());
                    dtCityId = objList.ListOfRecord("usp_Select_CityID", ParaCity, "City Customer - LoadList");
                    if (dtCityId.Rows.Count > 0)
                    {
                        CityID = Convert.ToInt16(dtCityId.Rows[0][0].ToString());
                    }
                    else
                    {
                        CityID = 0;
                    }

                    if (dtblImport.Rows[i]["CREADITDAYS"].ToString() == null || dtblImport.Rows[i]["CREADITDAYS"].ToString().Trim() == "")
                    {
                        CREADITDAYS = 0;
                    }
                    else
                    {
                        CREADITDAYS = Convert.ToInt16(dtblImport.Rows[i]["CREADITDAYS"].ToString());
                    }

                    if (dtblImport.Rows[i]["TRANSDATE"].ToString() == null || dtblImport.Rows[i]["TRANSDATE"].ToString().Trim() == "")
                    {
                        TRANSDATE = Convert.ToDateTime(System.DateTime.Now.Date);
                    }
                    else
                    {
                        TRANSDATE = Convert.ToDateTime(dtblImport.Rows[i]["TRANSDATE"].ToString());
                    }

                    if (dtblImport.Rows[i]["CRAMOUNT"].ToString() == null || dtblImport.Rows[i]["CRAMOUNT"].ToString().Trim() == "")
                    {
                        CRAMOUNT = 0;
                    }
                    else
                    {
                        CRAMOUNT = Convert.ToDecimal(dtblImport.Rows[i]["CRAMOUNT"].ToString());
                    }
                    if (dtblImport.Rows[i]["DBAMOUNT"].ToString() == null || dtblImport.Rows[i]["DBAMOUNT"].ToString().Trim() == "")
                    {
                        DBAMOUNT = 0;
                    }
                    else
                    {
                        DBAMOUNT = Convert.ToDecimal(dtblImport.Rows[i]["DBAMOUNT"].ToString());
                    }

                    objVendorBL.InsertFILE(("VEN-" + (Convert.ToInt16(dtMaxCode.Rows[0][0]) + 1).ToString().PadLeft(5, '0')),
                        //CODE,
                                            dtblImport.Rows[i]["COMPANY"].ToString(),
                                            dtblImport.Rows[i]["ADDRESS1"].ToString(),
                                            dtblImport.Rows[i]["ADDRESS2"].ToString(),
                                            (long)CityID,
                                            dtblImport.Rows[i]["PINCODE"].ToString(),
                                            dtblImport.Rows[i]["PHONE1"].ToString(),
                                            dtblImport.Rows[i]["PHONE2"].ToString(),
                                            dtblImport.Rows[i]["EMAIL"].ToString(),
                                            dtblImport.Rows[i]["MOBILE"].ToString(),
                                            dtblImport.Rows[i]["TINNO"].ToString(),
                                            dtblImport.Rows[i]["GSTNO"].ToString(),
                                            dtblImport.Rows[i]["PANNO"].ToString(),
                                            dtblImport.Rows[i]["ECCNO"].ToString(),
                                            CREADITDAYS,
                                            dtblImport.Rows[i]["RANGE"].ToString(),
                                            dtblImport.Rows[i]["DIVISION"].ToString(),
                                            TRANSDATE,
                                            CRAMOUNT,
                                            DBAMOUNT);

                }
            }

            MessageBox.Show("Data Uploded Successfully..!!");



            //----------------------

            //string ExcelFile = "";
            //string SelectedFileName = "";

            //OpenFileDialog ofd = new OpenFileDialog();
            //DialogResult result = ofd.ShowDialog(); // Show the dialog.
            //if (result == DialogResult.OK)
            //{
            //    if (result == DialogResult.OK) // Test result.
            //    {
            //        ExcelFile = ofd.SafeFileName;
            //        SelectedFileName = ofd.FileName;
            //    }
            //    if (ExcelFile.ToString() == "Vendor.xls")
            //    {
            //        objDataAccess.Upload("Temp_Vendor", SelectedFileName);

            //        DataTable dtblImport = new DataTable();
            //        dtblImport = objList.ListOfRecord("usp_Import_Vendor_List", null, "Import Vendor - LoadList");

            //        for (int i = 0; i < dtblImport.Rows.Count; i++)
            //        {
            //            if (dtblImport.Rows[i]["COMPANY"].ToString().Trim() != "" && dtblImport.Rows[i]["COMPANY"].ToString() != null)
            //            {
            //                Int16 CityID;
            //                int CREADITDAYS;
            //                decimal CRAMOUNT, DBAMOUNT;
            //                DateTime TRANSDATE;
            //                string CODE = "";
            //                DataTable dtMaxCode = new DataTable();
            //                dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code_Vendor", null, "MAX Vendor - LoadList");

            //                if (dtMaxCode.Rows[0][0].ToString() == null || dtMaxCode.Rows[0][0].ToString().Trim() == "")
            //                {
            //                    CODE = "VEN-00001";
            //                }
            //                else
            //                {
            //                    CODE = "VEN-" + (Convert.ToInt16(dtMaxCode.Rows[0][0].ToString().Substring(4, 5).TrimStart('0')) + 1).ToString().PadLeft(5, '0');
            //                }

            //                DataTable dtCityId = new DataTable();
            //                NameValueCollection ParaCity = new NameValueCollection();
            //                ParaCity.Add("@i_City", dtblImport.Rows[i]["CITY"].ToString());
            //                dtCityId = objList.ListOfRecord("usp_Select_CityID", ParaCity, "City Customer - LoadList");
            //                if (dtCityId.Rows.Count > 0)
            //                {
            //                    CityID = Convert.ToInt16(dtCityId.Rows[0][0].ToString());
            //                }
            //                else
            //                {
            //                    CityID = 0;
            //                }

            //                if (dtblImport.Rows[i]["CREADITDAYS"].ToString() == null || dtblImport.Rows[i]["CREADITDAYS"].ToString().Trim() == "")
            //                {
            //                    CREADITDAYS = 0;
            //                }
            //                else
            //                {
            //                    CREADITDAYS = Convert.ToInt16(dtblImport.Rows[i]["CREADITDAYS"].ToString());
            //                }

            //                if (dtblImport.Rows[i]["TRANSDATE"].ToString() == null || dtblImport.Rows[i]["TRANSDATE"].ToString().Trim() == "")
            //                {
            //                    TRANSDATE = Convert.ToDateTime(System.DateTime.Now.Date);
            //                }
            //                else
            //                {
            //                    TRANSDATE = Convert.ToDateTime(dtblImport.Rows[i]["TRANSDATE"].ToString());
            //                }

            //                if (dtblImport.Rows[i]["CRAMOUNT"].ToString() == null || dtblImport.Rows[i]["CRAMOUNT"].ToString().Trim() == "")
            //                {
            //                    CRAMOUNT = 0;
            //                }
            //                else
            //                {
            //                    CRAMOUNT = Convert.ToDecimal(dtblImport.Rows[i]["CRAMOUNT"].ToString());
            //                }
            //                if (dtblImport.Rows[i]["DBAMOUNT"].ToString() == null || dtblImport.Rows[i]["DBAMOUNT"].ToString().Trim() == "")
            //                {
            //                    DBAMOUNT = 0;
            //                }
            //                else
            //                {
            //                    DBAMOUNT = Convert.ToDecimal(dtblImport.Rows[i]["DBAMOUNT"].ToString());
            //                }

            //                string COMPANY = "";
            //                string ADDRESS1 = "";
            //                string ADDRESS2 = "";
            //                if (dtblImport.Rows[i]["COMPANY"].ToString() == null || dtblImport.Rows[i]["COMPANY"].ToString().Trim() == "")
            //                {
            //                    COMPANY = "";
            //                }
            //                else
            //                {
            //                    COMPANY = dtblImport.Rows[i]["COMPANY"].ToString();
            //                }
            //                if (dtblImport.Rows[i]["ADDRESS1"].ToString() == null || dtblImport.Rows[i]["ADDRESS1"].ToString().Trim() == "")
            //                {
            //                    ADDRESS1 = "";
            //                }
            //                else
            //                {
            //                    ADDRESS1 = dtblImport.Rows[i]["ADDRESS1"].ToString();
            //                }
            //                if (dtblImport.Rows[i]["ADDRESS2"].ToString() == null || dtblImport.Rows[i]["ADDRESS2"].ToString().Trim() == "")
            //                {
            //                    ADDRESS2 = "";
            //                }
            //                else
            //                {
            //                    ADDRESS2 = dtblImport.Rows[i]["ADDRESS2"].ToString();
            //                }
            //                string PINCODE = "";

            //                if (dtblImport.Rows[i]["PINCODE"].ToString() == null || dtblImport.Rows[i]["PINCODE"].ToString().Trim() == "")
            //                {
            //                    PINCODE = "";
            //                }
            //                else
            //                {
            //                    PINCODE = dtblImport.Rows[i]["PINCODE"].ToString();
            //                }
            //                string PHONE1 = "";
            //                if (dtblImport.Rows[i]["PHONE1"].ToString() == null || dtblImport.Rows[i]["PHONE1"].ToString().Trim() == "")
            //                {
            //                    PHONE1 = "";
            //                }
            //                else
            //                {
            //                    PHONE1 = dtblImport.Rows[i]["PHONE1"].ToString();
            //                }
            //                string PHONE2 = "";
            //                if (dtblImport.Rows[i]["PHONE2"].ToString() == null || dtblImport.Rows[i]["PHONE2"].ToString().Trim() == "")
            //                {
            //                    PHONE2 = "";
            //                }
            //                else
            //                {
            //                    PHONE2 = (dtblImport.Rows[i]["PHONE2"].ToString());
            //                }
            //                string EMAIL = "";
            //                if (dtblImport.Rows[i]["EMAIL"].ToString() == null || dtblImport.Rows[i]["EMAIL"].ToString().Trim() == "")
            //                {
            //                    EMAIL = "";
            //                }
            //                else
            //                {
            //                    EMAIL = (dtblImport.Rows[i]["EMAIL"].ToString());
            //                }
            //                string MOBILE = "";
            //                if (dtblImport.Rows[i]["MOBILE"].ToString() == null || dtblImport.Rows[i]["MOBILE"].ToString().Trim() == "")
            //                {
            //                    MOBILE = "";
            //                }
            //                else
            //                {
            //                    MOBILE = (dtblImport.Rows[i]["MOBILE"].ToString());
            //                }
            //                string TINNO = "";
            //                if (dtblImport.Rows[i]["TINNO"].ToString() == null || dtblImport.Rows[i]["TINNO"].ToString().Trim() == "")
            //                {
            //                    MOBILE = "";
            //                }
            //                else
            //                {
            //                    MOBILE = (dtblImport.Rows[i]["TINNO"].ToString());
            //                }
            //                string CSTNO = "";
            //                if (dtblImport.Rows[i]["CSTNO"].ToString() == null || dtblImport.Rows[i]["CSTNO"].ToString().Trim() == "")
            //                {
            //                    CSTNO = "";
            //                }
            //                else
            //                {
            //                    CSTNO = (dtblImport.Rows[i]["CSTNO"].ToString());
            //                }
            //                string PANO = "";
            //                if (dtblImport.Rows[i]["PANO"].ToString() == null || dtblImport.Rows[i]["PANO"].ToString().Trim() == "")
            //                {
            //                    PANO = "";
            //                }
            //                else
            //                {
            //                    PANO = (dtblImport.Rows[i]["PANO"].ToString());
            //                }
            //                string ECCNO = "";
            //                if (dtblImport.Rows[i]["ECCNO"].ToString() == null || dtblImport.Rows[i]["ECCNO"].ToString().Trim() == "")
            //                {
            //                    ECCNO = "";
            //                }
            //                else
            //                {
            //                    ECCNO = (dtblImport.Rows[i]["ECCNO"].ToString());
            //                }
            //                string RANGE = "";
            //                if (dtblImport.Rows[i]["RANGE"].ToString() == null || dtblImport.Rows[i]["RANGE"].ToString().Trim() == "")
            //                {
            //                    RANGE = "";
            //                }
            //                else
            //                {
            //                    RANGE = (dtblImport.Rows[i]["RANGE"].ToString());
            //                }
            //                string DIVISION = "";
            //                if (dtblImport.Rows[i]["DIVISION"].ToString() == null || dtblImport.Rows[i]["DIVISION"].ToString().Trim() == "")
            //                {
            //                    DIVISION = "";
            //                }
            //                else
            //                {
            //                    DIVISION = (dtblImport.Rows[i]["DIVISION"].ToString());
            //                }
            //                objVendorBL.Insert(CODE,
            //                                        COMPANY,
            //                                        ADDRESS1,
            //                                        ADDRESS2,
            //                                        (long)CityID,
            //                                        PINCODE,
            //                                        PHONE1,
            //                                        PHONE2,
            //                                        EMAIL,
            //                                        MOBILE,
            //                                        TINNO,
            //                                        CSTNO,
            //                                        PANO,
            //                                        ECCNO,
            //                                        CREADITDAYS,
            //                                        RANGE,
            //                                        DIVISION,
            //                                        TRANSDATE,
            //                                        CRAMOUNT,
            //                                        DBAMOUNT);

            //            }
            //        }

            //        MessageBox.Show("Data Uploded Successfully..!!");
            //    }
            //}

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblVendor.DefaultView;
            DV.RowFilter = StrFilter;

            dgvVendor.DataSource = DV.ToTable();

            frmVendorFilter filterSalesinvoice = new frmVendorFilter(dtblVendor);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            dgvVendor.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvVendor.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptVendorRegister.rpt"))
                    {
                        //dtblVendor.TableName = "VendorRegister";
                        //dtblVendor.WriteXmlSchema(@"D:\Report\VendorRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblVendor.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptVendorRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Vendor Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Vendor Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                        // DataTable dt = new DataTable();
                        //// dt = dgvVendor.DataSource();
                        // for (int i = 0; i < dgvVendor.Rows.Count; i++)
                        // {
                        //     DataRow dr = dt.NewRow();
                        //     dr["Col1"] = dgvVendor.rows[i]["Col1"].text;
                        //     dt.Rows.Add(dr);
                        // }
                    }
                    else
                    {
                        MessageBox.Show("File is not exist...");
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Vendor - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            else if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptVendorMailingLabel.rpt"))
                    {
                        //dtblVendor.TableName = "VendorRegister";
                        //dtblVendor.WriteXmlSchema(@"D:\Report\VendorRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblVendor.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptVendorMailingLabel.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Vendor Mailing Label", true, true, true, true, false, true, false, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Vendor Mailing Label - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Vendor - Mailing Label Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;
        }

        public void UploadExcel(DataTable dtCust)
        {
            string XMLString = "<NewDataSet>";
            long Cnt = 0;
            if (dtCust.Rows[1]["COMPANY"].ToString() == "")
            {
                dtCust.Rows.RemoveAt(1);
            }
            for (int row = 0; row < dtCust.Rows.Count; row++)
            {
                XMLString += "<Table>";
                XMLString += "<CustomerName>" + dtCust.Rows[row]["COMPANY"].ToString() + "</CustomerName>";
                XMLString += "<Address1>" + dtCust.Rows[row]["ADDRESS1"].ToString() + "</Address1>";
                XMLString += "<Address2>" + dtCust.Rows[row]["ADDRESS2"].ToString() + "</Address2>";
                XMLString += "<City>" + dtCust.Rows[row]["CITY"].ToString() + "</City>";
                XMLString += "<PinCode>" + dtCust.Rows[row]["PINCODE"].ToString() + "</PinCode>";
                XMLString += "<Phone1>" + dtCust.Rows[row]["PHONE1"].ToString() + "</Phone1>";
                XMLString += "<Phone2>" + dtCust.Rows[row]["PHONE2"].ToString() + "</Phone2>";
                XMLString += "<Email>" + dtCust.Rows[row]["EMAIL"].ToString() + "</Email>";
                XMLString += "<MobileNo>" + dtCust.Rows[row]["MOBILE"].ToString() + "</MobileNo>";
                XMLString += "<TinNo>" + dtCust.Rows[row][10].ToString() + "</TinNo>";
                XMLString += "<GstNo>" + dtCust.Rows[row][11].ToString() + "</GstNo>";
                XMLString += "<PanNo>" + dtCust.Rows[row][12].ToString() + "</PanNo>";
                XMLString += "<EccNo>" + dtCust.Rows[row][13].ToString() + "</EccNo>";
                XMLString += "<Range>" + dtCust.Rows[row][14].ToString() + "</Range>";
                XMLString += "<Division>" + dtCust.Rows[row][15].ToString() + "</Division>";
                XMLString += "<CreditDays>" + dtCust.Rows[row]["CREADITDAYS"].ToString() + "</CreditDays>";
                XMLString += "<TransDate>" + dtCust.Rows[row]["TRANSDATE"].ToString() + "</TransDate>";
                XMLString += "<CRAmount>" + dtCust.Rows[row]["CRAMOUNT"].ToString() + "</CRAmount>";
                XMLString += "<DBAmount>" + dtCust.Rows[row]["DBAMOUNT"].ToString() + "</DBAmount>";
                XMLString += "</Table>";
                Cnt++;
            }
            XMLString = XMLString.ToString().Replace("&", "&amp;") + "</NewDataSet>";
            objVendorBL.UploadVendor(XMLString, Cnt);
        }
    }
}
