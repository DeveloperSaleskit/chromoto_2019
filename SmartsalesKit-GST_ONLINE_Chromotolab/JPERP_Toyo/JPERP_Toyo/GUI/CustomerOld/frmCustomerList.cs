using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using Account.Validator;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace Account.GUI.Customer
{
    public partial class frmCustomerList : Account.GUIBase
    {

        #region "Variable Declaration...."

        DataTable dtblCustomer = new DataTable();

        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDataAccess = new DataAccess.DataAccess();
        CustomerBL objCustomerBL = new CustomerBL();

        int idgvPosition = 0;

        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;

        string StrFilter = "";
        DataView DV;
        Exception mException = null;
        string mErrorMsg = "";
        string strFile;

        #endregion

        #region "Form load event"

        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);

                cmbreports.Items.Add("--Select Report--");
                cmbreports.Items.Add("Customer Register");
                cmbreports.Items.Add("Mailing Label");
                cmbreports.SelectedIndex = 0;
                LoadList();               
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtblCustomer = objList.ListOfRecord("usp_Customer_List", para, "Customer - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvCustomer.CurrentRow != null)
                    {
                        idgvPosition = dgvCustomer.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvCustomer.AutoGenerateColumns = false;
                    dgvCustomer.DataSource = dtblCustomer;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomer.RowCount.ToString();
                    if (dgvCustomer.CurrentRow != null && idgvPosition <= dgvCustomer.RowCount)
                    {
                        if (dgvCustomer.Rows.Count - 1 < idgvPosition)
                        {
                            dgvCustomer.CurrentCell = dgvCustomer.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvCustomer.CurrentCell = dgvCustomer.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Customer - LoadList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvCustomer.Columns[0].DataPropertyName = dtblCustomer.Columns["Code"].ToString();
                dgvCustomer.Columns[1].DataPropertyName = dtblCustomer.Columns["Company"].ToString();
                dgvCustomer.Columns[2].DataPropertyName = dtblCustomer.Columns["Address"].ToString();
                dgvCustomer.Columns[3].DataPropertyName = dtblCustomer.Columns["City"].ToString();
                dgvCustomer.Columns[4].DataPropertyName = dtblCustomer.Columns["Pincode"].ToString();
                dgvCustomer.Columns[5].DataPropertyName = dtblCustomer.Columns["Phone1"].ToString();
                dgvCustomer.Columns[6].DataPropertyName = dtblCustomer.Columns["Fax"].ToString();
                dgvCustomer.Columns[7].DataPropertyName = dtblCustomer.Columns["Mobile"].ToString();
                dgvCustomer.Columns[8].DataPropertyName = dtblCustomer.Columns["ContactName"].ToString();
                dgvCustomer.Columns[9].DataPropertyName = dtblCustomer.Columns["CustomerID"].ToString();
                dgvCustomer.Columns[10].DataPropertyName = dtblCustomer.Columns["CityID"].ToString();
                dgvCustomer.Columns[11].DataPropertyName = dtblCustomer.Columns["NextFollowUpDate"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            if (dgvCustomer.SortedColumn != null)
            {
                sortedColumn = dgvCustomer.SortedColumn;
                sortDirection = dgvCustomer.SortOrder;
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
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

                dgvCustomer.Sort(dgvCustomer.Columns[sortedColumn.Name], LSD);
            }
            if (dgvCustomer.CurrentRow != null && idgvPosition <= dgvCustomer.RowCount)
            {
                if (dgvCustomer.Rows.Count - 1 < idgvPosition)
                {
                    dgvCustomer.CurrentCell = dgvCustomer.Rows[idgvPosition - 1].Cells[0];
                }
                else
                {
                    dgvCustomer.CurrentCell = dgvCustomer.Rows[idgvPosition].Cells[0];
                }
            }

        }

        private void LoadFollowUpList()
        {
            try
            {
                if (dgvCustomer.CurrentRow == null)
                    return;
                DataTable dtFollowUps = new DataTable();
                NameValueCollection Paralist = new NameValueCollection();
                Paralist.Add("@i_CustomerID", dgvCustomer.CurrentRow.Cells["CustomerID"].Value.ToString());
                dtFollowUps = objList.ListOfRecord("usp_LeadFollowUp_List", Paralist, "FollowUp -List");
                if (objList.Exception == null)
                {
                   
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

        #endregion

        #region "Button Events"     

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerEntry fCustomer = new frmCustomerEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;
                fCustomer.ShowDialog();
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerEntry fCustomer = new frmCustomerEntry((int)Constant.Mode.Modify, (Int64)dgvCustomer.CurrentRow.Cells["CustomerID"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerEntry fCustomer = new frmCustomerEntry((int)Constant.Mode.Delete, (Int64)dgvCustomer.CurrentRow.Cells["CustomerID"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvCustomer.CurrentRow != null)
            //    {
            //        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, Convert.ToInt64(dgvCustomer.CurrentRow.Cells["CustomerID"].Value));
            //        fContact.ShowDialog();
            //        setDefaultGridRecords(sender, e);
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void btnBillingAddress_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.CurrentRow != null)
                {
                    GUI.BillingAddress.frmBillingAddress fBilling = new Account.GUI.BillingAddress.frmBillingAddress(1, Convert.ToInt64(dgvCustomer.CurrentRow.Cells["CustomerID"].Value));
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomer.CurrentRow != null)
                {
                    SetSortedColumns();
                    string Custcode = dgvCustomer.CurrentRow.Cells["Code"].Value.ToString();
                    string CustName = dgvCustomer.CurrentRow.Cells["CompanyName"].Value.ToString();
                    // string LeadDate = Convert.ToDateTime(dgvCustomer.CurrentRow.Cells["LeadDate"].Value.ToString()).ToShortDateString();
                    string folloupDate;
                    if (dgvCustomer.CurrentRow.Cells["NextFollowUpDate"].Value.ToString().Trim() != "")
                    {
                        folloupDate = Convert.ToDateTime(dgvCustomer.CurrentRow.Cells["NextFollowUpDate"].Value.ToString()).ToShortDateString();
                    }
                    else
                    {
                        folloupDate = "";
                    }

                    frmLeadFollowup fCustomer = new frmLeadFollowup(Convert.ToInt64(dgvCustomer.CurrentRow.Cells["CustomerID"].Value), dgvCustomer.CurrentRow.Cells["Code"].Value.ToString(), CustName, folloupDate);
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

        #endregion

        #region "Datagrid Events"

        private void dgvCustomer_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomer, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomer, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox events"

        private void txtFromCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int ascii = e.KeyChar;
                DataValidator.AllowOnlyCharacter(ascii, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int ascii = e.KeyChar;
                DataValidator.AllowOnlyCharacter(ascii, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Report Viewer"

        private void mnuCustomerRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerRegister.rpt"))
                {
                    //dtblCustomer.TableName = "CustomerRegister";
                    //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblCustomer.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptCustomerRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Register", true, true, true, true, false, true, false, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Customer Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Customer- Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void mmuMailingLabel_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerMailingLabel.rpt"))
                {
                    //dtblCustomer.TableName = "CustomerRegister";
                    //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblCustomer.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptCustomerMailingLabel.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Mailing Label", true, true, true, true, false, true, false, false, false, false, true);

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

        #endregion

        private void btnImportCustomer_Click(object sender, EventArgs e)
        {
            strFile = CurrentUser.DocumentPath + @"Upload\Customer.xls";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(strFile, @"d:\Customer.xls");
            }
            MessageBox.Show("Your File Save on following Path - " + "D:\\Customer.xls");
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

            objDataAccess.Upload("Temp_Customer", SelectedFileName);

            DataTable dtblCustomerImport = new DataTable();
            dtblCustomerImport = objList.ListOfRecord("usp_Import_Customer_List", null, "Import Customer - LoadList");

            for (int i = 0; i < dtblCustomerImport.Rows.Count; i++)
            {
                Int16 CityID;
                int IsAccount = 1;
                int CREADITDAYS;
                decimal CRAMOUNT, DBAMOUNT;
                DateTime TRANSDATE;

                DataTable dtMaxCode = new DataTable();
                dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code", null, "MAX Customer - LoadList");

                DataTable dtCityId = new DataTable();
                NameValueCollection ParaCity = new NameValueCollection();
                ParaCity.Add("@i_City", dtblCustomerImport.Rows[i]["CITY"].ToString());
                dtCityId = objList.ListOfRecord("usp_Select_CityID", ParaCity, "City Customer - LoadList");
                if (dtCityId.Rows.Count > 0)
                {
                    CityID = Convert.ToInt16(dtCityId.Rows[0][0].ToString());
                }
                else
                {
                    CityID = 0;
                }

                if (dtblCustomerImport.Rows[i]["CREADITDAYS"].ToString() == null || dtblCustomerImport.Rows[i]["CREADITDAYS"].ToString().Trim() == "")
                {
                    CREADITDAYS = 0;
                }
                else
                {
                    CREADITDAYS = Convert.ToInt16(dtblCustomerImport.Rows[i]["CREADITDAYS"].ToString());
                }

                if (dtblCustomerImport.Rows[i]["TRANSDATE"].ToString() == null || dtblCustomerImport.Rows[i]["TRANSDATE"].ToString().Trim() == "")
                {
                    TRANSDATE = Convert.ToDateTime(System.DateTime.Now.Date);
                }
                else
                {
                    TRANSDATE = Convert.ToDateTime(dtblCustomerImport.Rows[i]["TRANSDATE"].ToString());
                }

                if (dtblCustomerImport.Rows[i]["CRAMOUNT"].ToString() == null || dtblCustomerImport.Rows[i]["CRAMOUNT"].ToString().Trim() == "")
                {
                    CRAMOUNT = 0;
                }
                else
                {
                    CRAMOUNT = Convert.ToDecimal(dtblCustomerImport.Rows[i]["CRAMOUNT"].ToString());
                }
                if (dtblCustomerImport.Rows[i]["DBAMOUNT"].ToString() == null || dtblCustomerImport.Rows[i]["DBAMOUNT"].ToString().Trim() == "")
                {
                    DBAMOUNT = 0;
                }
                else
                {
                    DBAMOUNT = Convert.ToDecimal(dtblCustomerImport.Rows[i]["DBAMOUNT"].ToString());
                }

                objCustomerBL.Insert(("CUST-" + (Convert.ToInt16(dtMaxCode.Rows[0][0]) + 1).ToString().PadLeft(5, '0')),
                      dtblCustomerImport.Rows[i]["COMPANY"].ToString(),
                      dtblCustomerImport.Rows[i]["ADDRESS1"].ToString(),
                      dtblCustomerImport.Rows[i]["ADDRESS2"].ToString(),
                      (long)CityID,
                      dtblCustomerImport.Rows[i]["PINCODE"].ToString(),
                      dtblCustomerImport.Rows[i]["PHONE1"].ToString(),
                      dtblCustomerImport.Rows[i]["PHONE2"].ToString(),
                      dtblCustomerImport.Rows[i]["EMAIL"].ToString(),
                      dtblCustomerImport.Rows[i]["MOBILE"].ToString(),
                      dtblCustomerImport.Rows[i]["TINNO"].ToString(),
                      dtblCustomerImport.Rows[i]["CSTNO"].ToString(),
                      dtblCustomerImport.Rows[i]["PANO"].ToString(),
                      dtblCustomerImport.Rows[i]["ECCNO"].ToString(),
                      dtblCustomerImport.Rows[i]["RANGE"].ToString(),
                      dtblCustomerImport.Rows[i]["DIVISION"].ToString(),
                      CREADITDAYS,
                      TRANSDATE,
                      CRAMOUNT,
                      DBAMOUNT,
                      IsAccount,
                      0,
                      dtblCustomerImport.Rows[i]["CONTACTPERSON"].ToString());
            }

            MessageBox.Show("Data Uploded Successfully..!!");

        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerRegister.rpt"))
                    {
                        //dtblCustomer.TableName = "CustomerRegister";
                        //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblCustomer.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptCustomerRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Register", true, true, true, true, false, true, false, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Customer Register - [Page Size: A4]";
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
                    Utill.Common.ExceptionLogger.writeException("Customer- Register", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }

            if (cmbreports.SelectedIndex == 2)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerMailingLabel.rpt"))
                    {
                        //dtblCustomer.TableName = "CustomerRegister";
                        //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblCustomer.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptCustomerMailingLabel.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Mailing Label", true, true, true, true, false, true, false, false, false, false, true);

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DV = dtblCustomer.DefaultView;
            DV.RowFilter = StrFilter;
            dgvCustomer.DataSource = DV.ToTable();
            Account.GUI.Customer.frmCustomerFilter filterSalesinvoice = new Account.GUI.Customer.frmCustomerFilter(dtblCustomer);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvCustomer.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomer.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help obj = new Help();
            obj.ShowDialog();
        }        
    }
}
