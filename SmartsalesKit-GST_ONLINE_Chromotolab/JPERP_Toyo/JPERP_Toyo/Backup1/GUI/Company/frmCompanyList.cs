using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.BusinessLogic;
using Account.Common;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Configuration;

namespace Account.GUI.Company
{
    public partial class frmCompanyList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblUser = new DataTable();
        DataSet dtblUser1 = new DataSet();
        CommonListBL objList = new CommonListBL();
        UserBL ObjUser = new UserBL();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        bool _isBind = false;
        bool IsShowAll = false;

        int _CompId=0;

        #endregion

        #region "Form Event...."

        public frmCompanyList()
        {
            InitializeComponent();
        }

        //private void frmGodownList_Load(object sender, EventArgs e)
        //{
        //    AddHandlers(this);
        //    SetControlsDefaults(this);
        //    LoadList();
        //    dgvUsers_SelectionChanged(sender, e);
        //}

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {


                _isBind = false;

                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtblUser1 = objList.ListOfDataSetRecordwithPara("usp_CompanyInfo_List", para1, "CompanyInfo - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvUsers.CurrentRow != null)
                    {
                        idgvPosition = dgvUsers.CurrentRow.Index;
                    }
                    //dgvUsers.AutoGenerateColumns = false;
                    dgvUsers.DataSource = dtblUser1.Tables[0];

                    for (int i = 0; i < dtblUser1.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < dtblUser1.Tables[1].Rows.Count; j++)
                        {
                            if (dtblUser1.Tables[0].Rows[i]["CompId"].ToString() == dtblUser1.Tables[1].Rows[j]["CompId"].ToString())
                            {
                                dtblUser1.Tables[0].Rows[i]["UserName"] = dtblUser1.Tables[1].Rows[j]["UserName"].ToString();
                                dtblUser1.Tables[0].Rows[i]["Password"] = dtblUser1.Tables[1].Rows[j]["Password"].ToString();
                                break;
                            }

                        }
                    }
                    dgvUsers.DataSource = dtblUser1.Tables[0];

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvUsers.RowCount.ToString();
                    if (dgvUsers.CurrentRow != null && idgvPosition <= dgvUsers.RowCount)
                    {
                        if (dgvUsers.Rows.Count - 1 < idgvPosition)
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                    _isBind = true;
                    dgvUsers.Columns["Password"].Visible = false;
                    dgvUsers.Columns["CompId"].Visible = false;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CompanyInfo", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        private void ArrangeDataGridView()
        {
            try
            {
                //dgvUsers.Columns["CompanyName"].DataPropertyName = dtblUser.Columns["CompanyName"].ToString();
                //dgvUsers.Columns["CompId"].DataPropertyName = dtblUser.Columns["CompId"].ToString();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CompanyInfo", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow != null)
                {
                    if (dgvUsers.SortedColumn != null)
                    {
                        sortedColumn = dgvUsers.SortedColumn;
                        sortDirection = dgvUsers.SortOrder;
                    }
                    frmCompanyEntry fUser = new frmCompanyEntry((int)Constant.Mode.Modify,(Int64)dgvUsers.CurrentRow.Cells["CompId"].Value);
                    fUser.ShowInTaskbar = false;
                    fUser.ShowDialog();
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

                        dgvUsers.Sort(dgvUsers.Columns[sortedColumn.Name], LSD);
                    }
                    if (dgvUsers.CurrentRow != null && idgvPosition <= dgvUsers.RowCount)
                    {
                        if (dgvUsers.Rows.Count - 1 < idgvPosition)
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition].Cells[0];
                        }
                    }
                    dgvUsers_SelectionChanged(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CompanyInfo", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";
                LoadList();
                dgvUsers_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CompanyInfo", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid Event..."

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isBind == true)
                {
                    if (dgvUsers.CurrentRow != null)
                    {

                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CompanyInfo", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CompanyInfo", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Report Event...."

        private void mnuUserRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptUserRegister.rpt"))
                {
                    //dtblUser.TableName = "UserRegister";
                    //dtblUser.WriteXmlSchema(@"D:\Project_Info\Report\UserRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblUser.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptUserRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "User Register", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "User Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("TNC - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void frmGodownList_Load(object sender, EventArgs e)
        {
            

            AddHandlers(this);
            SetControlsDefaults(this);
          

            LoadList();
           
               

            if (Convert.ToInt16(_CompId) == 1)
            {
                btnNew.Enabled = true;
            }
            else
            {
                btnNew.Enabled = false;
            }

            DataTable dtCompCount = new DataTable();
            dtCompCount = objList.ListOfRecord("usp_CompanyCount", null, "Company-Count");

            if (Convert.ToInt16(dtCompCount.Rows[0]["Company"].ToString()) >= 3)
            {
                btnNew.Enabled = false;
            }
            dgvUsers_SelectionChanged(sender, e);

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#2002#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                }
            }
           
        }



        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                frmCompanyEntry fCompany = new frmCompanyEntry((int)Constant.Mode.Insert, 0);
                fCompany.ShowInTaskbar = false;
                fCompany.ShowDialog();
                LoadList();

                DataTable dtCompCount = new DataTable();
                dtCompCount = objList.ListOfRecord("usp_CompanyCount", null, "Company-Count");

                if (Convert.ToInt16(dtCompCount.Rows[0]["Company"].ToString()) >= 3)
                {
                    btnNew.Enabled = false; 
                }
               
                
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow != null)
                {
                    MessageBox.Show(dgvUsers.CurrentRow.Cells["Password"].Value.ToString(), "Password");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

      


    }
}
