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

namespace Account.GUI.Customer
{
    public partial class frmImportCustomerList : Account.GUIBase
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
        public string _File_Path;

        #endregion

        #region "Form load event"

        public frmImportCustomerList(string File_Path)
        {
            InitializeComponent();
            _File_Path = File_Path;
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                LoadList();
                dgvCustomer.ReadOnly = false;

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
                objDataAccess.Upload("Temp_Customer", _File_Path);
                dtblCustomer = objList.ListOfRecord("usp_Import_Customer_List", null, "Import Customer - LoadList");
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
                    dgvCustomer.ReadOnly = false;
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
                dgvCustomer.Columns["COMPANY"].DataPropertyName = dtblCustomer.Columns["COMPANY"].ToString();
                dgvCustomer.Columns["CONTACTPERSON"].DataPropertyName = dtblCustomer.Columns["CONTACTPERSON"].ToString();
                dgvCustomer.Columns["ADDRESS1"].DataPropertyName = dtblCustomer.Columns["ADDRESS1"].ToString();
                dgvCustomer.Columns["ADDRESS2"].DataPropertyName = dtblCustomer.Columns["ADDRESS2"].ToString();
                dgvCustomer.Columns["CITY"].DataPropertyName = dtblCustomer.Columns["CITY"].ToString();
                dgvCustomer.Columns["PINCODE"].DataPropertyName = dtblCustomer.Columns["PINCODE"].ToString();
                dgvCustomer.Columns["PHONE1"].DataPropertyName = dtblCustomer.Columns["PHONE1"].ToString();
                dgvCustomer.Columns["PHONE2"].DataPropertyName = dtblCustomer.Columns["PHONE2"].ToString();
                dgvCustomer.Columns["EMAIL"].DataPropertyName = dtblCustomer.Columns["EMAIL"].ToString();
                dgvCustomer.Columns["MOBILE"].DataPropertyName = dtblCustomer.Columns["MOBILE"].ToString();
                dgvCustomer.Columns["TINNO"].DataPropertyName = dtblCustomer.Columns["TINNO"].ToString();
                dgvCustomer.Columns["CSTNO"].DataPropertyName = dtblCustomer.Columns["CSTNO"].ToString();

                dgvCustomer.Columns["PANO"].DataPropertyName = dtblCustomer.Columns["PANO"].ToString();
                dgvCustomer.Columns["ECCNO"].DataPropertyName = dtblCustomer.Columns["ECCNO"].ToString();
                dgvCustomer.Columns["RANGE"].DataPropertyName = dtblCustomer.Columns["RANGE"].ToString();
                dgvCustomer.Columns["DIVISION"].DataPropertyName = dtblCustomer.Columns["DIVISION"].ToString();
                dgvCustomer.Columns["CREADITDAYS"].DataPropertyName = dtblCustomer.Columns["CREADITDAYS"].ToString();
                dgvCustomer.Columns["TRANSDATE"].DataPropertyName = dtblCustomer.Columns["TRANSDATE"].ToString();
                dgvCustomer.Columns["CRAMOUNT"].DataPropertyName = dtblCustomer.Columns["CRAMOUNT"].ToString();
                dgvCustomer.Columns["DBAMOUNT"].DataPropertyName = dtblCustomer.Columns["DBAMOUNT"].ToString();

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

        #endregion

        #region "Button Events"





        private void btnClose_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvCustomer.Rows.Count; i++)
            {
                Int16 CityID;
                int IsAccount = 0;

                DataTable dtMaxCode = new DataTable();
                dtMaxCode = objList.ListOfRecord("usp_Select_Max_Code", null, "MAX Customer - LoadList");

                DataTable dtCityId = new DataTable();
                NameValueCollection ParaCity = new NameValueCollection();
                ParaCity.Add("@i_City", dgvCustomer.Rows[i].Cells["CITY"].Value.ToString());
                dtCityId = objList.ListOfRecord("usp_Select_CityID", ParaCity, "City Customer - LoadList");
                if (dtCityId.Rows.Count > 0)
                {
                    CityID = Convert.ToInt16(dtCityId.Rows[0][0].ToString());
                }
                else
                {
                    CityID = 0;
                }

                if (Convert.ToBoolean(dgvCustomer.Rows[i].Cells["Check"].Value) == true)
                {
                    IsAccount = 1;
                }
                else
                {
                    IsAccount = 0;
                }

                objCustomerBL.Insert(("CUST-" + (Convert.ToInt16(dtMaxCode.Rows[0][0]) + 1).ToString().PadLeft(5, '0')),
                                      dgvCustomer.Rows[i].Cells["COMPANY"].Value.ToString(), dgvCustomer.Rows[i].Cells["ADDRESS1"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["ADDRESS2"].Value.ToString(), (long)CityID,
                                      dgvCustomer.Rows[i].Cells["PINCODE"].Value.ToString(), dgvCustomer.Rows[i].Cells["PHONE1"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["PHONE2"].Value.ToString(), dgvCustomer.Rows[i].Cells["EMAIL"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["MOBILE"].Value.ToString(), dgvCustomer.Rows[i].Cells["TINNO"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["CSTNO"].Value.ToString(), dgvCustomer.Rows[i].Cells["PANO"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["ECCNO"].Value.ToString(), dgvCustomer.Rows[i].Cells["RANGE"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["DIVISION"].Value.ToString(),
                                      dgvCustomer.Rows[i].Cells["CREADITDAYS"].Value!= null ?  Convert.ToInt32(dgvCustomer.Rows[i].Cells["CREADITDAYS"].Value.ToString()) : 0,
                                      dgvCustomer.Rows[i].Cells["TRANSDATE"].Value != null ?  Convert.ToDateTime(dgvCustomer.Rows[i].Cells["TRANSDATE"].Value) :System.DateTime.Today.Date,
                                      dgvCustomer.Rows[i].Cells["CRAMOUNT"].Value != null ? Convert.ToDecimal(dgvCustomer.Rows[i].Cells["CRAMOUNT"].Value.ToString()) : 0,
                                      dgvCustomer.Rows[i].Cells["DBAMOUNT"].Value != null ?  Convert.ToDecimal(dgvCustomer.Rows[i].Cells["DBAMOUNT"].Value.ToString()) : 0,

                                      IsAccount, 0, dgvCustomer.Rows[i].Cells["CONTACTPERSON"].Value.ToString());
            }

            this.Close();
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

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Register", true, false, false, false, false, false, true, false, false, false, false);

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

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Mailing Label", false, false, false, false, false, false, false, false, false, false, false);

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

         
    }
}
