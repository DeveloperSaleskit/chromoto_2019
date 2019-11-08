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
using System.Configuration;
using Account.GUI.Employee;

namespace Account.GUI.Godown
{
    public partial class frmGodownList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblUser = new DataTable();
        CommonListBL objList = new CommonListBL();
        UserBL ObjUser = new UserBL();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;
        bool _isBind = false;
        bool IsShowAll = false;

        #endregion

        #region "Form Event...."

        public frmGodownList()
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

                NameValueCollection para = new NameValueCollection();
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());


                dtblUser = objList.ListOfRecord("usp_Godown_List", para, "Godown - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvUsers.CurrentRow != null)
                    {
                        idgvPosition = dgvUsers.CurrentRow.Index;
                    }                   
                    dgvUsers.AutoGenerateColumns = false;
                    dgvUsers.DataSource = dtblUser;
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
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        private void ArrangeDataGridView()
        {
            try
            {
                dgvUsers.Columns[0].DataPropertyName = dtblUser.Columns["Godown_name"].ToString();
                dgvUsers.Columns[1].DataPropertyName = dtblUser.Columns["Godown_addr"].ToString();
                dgvUsers.Columns[2].DataPropertyName = dtblUser.Columns["GodownID"].ToString();
                dgvUsers.Columns[3].DataPropertyName = dtblUser.Columns["CityName"].ToString(); 
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Godown", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmGodownEntry fUser = new frmGodownEntry((int)Constant.Mode.Insert, 0);
                fUser.ShowInTaskbar = false;
                fUser.ShowDialog();
                LoadList();
                btnApply_Click(sender, e);
                dgvUsers_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Godown", exc.StackTrace);
            }
        }

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
                    frmGodownEntry fUser = new frmGodownEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvUsers.CurrentRow.Cells["GodownID"].Value));
                    fUser.ShowInTaskbar = false;
                    fUser.ShowDialog();
                    LoadList();
                    btnApply_Click(sender, e);
                    
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
                Utill.Common.ExceptionLogger.writeException("Godown", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
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

                        frmGodownEntry fUser = new frmGodownEntry((int)Constant.Mode.Delete, Convert.ToInt64( dgvUsers.CurrentRow.Cells["GodownID"].Value));
                        fUser.ShowInTaskbar = false;
                        fUser.ShowDialog();
                        LoadList();
                        btnApply_Click(sender, e);
                       

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
                Utill.Common.ExceptionLogger.writeException("Godown", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

    
     

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

           
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
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
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

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "User Register", true, true, true, true, false, true, true, false, false, false, true);

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
                Utill.Common.ExceptionLogger.writeException("User - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void frmGodownList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9032#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9033#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9034#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                    //if (CurrentUser.PrivilegeStr.IndexOf("#1505#") != -1)
                    //{ btnFollowUp.Enabled = true; }
                    //else { btnFollowUp.Enabled = false; }                   
                }
            }


            dgvUsers_SelectionChanged(sender, e);
        }

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblUser.DefaultView;
            DV.RowFilter = StrFilter;
            dgvUsers.DataSource = DV.ToTable();
            frmGodownFilter filterSalesinvoice = new frmGodownFilter(dtblUser);
            filterSalesinvoice.ShowDialog();
            DataTable dt = DV.ToTable();
            dgvUsers.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvUsers.RowCount.ToString();

            ArrangeDataGridView();
        }

    }
}
