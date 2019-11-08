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

namespace Account.GUI.Email
{
    public partial class frmEmailList : Account.GUIBase
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
        int _CompId = 0;

        #endregion

        #region "Form Event...."

        public frmEmailList()
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
               
                para1.Add("@i_UserID", CurrentUser.UserID.ToString());


                dtblUser = objList.ListOfRecord("usp_Email_List", para1, "Email - LoadList");
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
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition - 1].Cells[1];
                        }
                        else
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition].Cells[1];
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
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        private void ArrangeDataGridView()
        {
            try
            {
                dgvUsers.Columns[0].DataPropertyName = dtblUser.Columns["Email_ID"].ToString();
                dgvUsers.Columns[1].DataPropertyName = dtblUser.Columns["Type"].ToString();
                dgvUsers.Columns[2].DataPropertyName = dtblUser.Columns["Subject"].ToString();
                dgvUsers.Columns["CompId"].DataPropertyName = dtblUser.Columns["CompId"].ToString();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmailEntry fUser = new frmEmailEntry((int)Constant.Mode.Insert, 0);
                fUser.ShowInTaskbar = false;
                fUser.ShowDialog();
                LoadList();
                
                dgvUsers_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
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
                    frmEmailEntry fUser = new frmEmailEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvUsers.CurrentRow.Cells["Email_ID"].Value));
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
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition - 1].Cells[1];
                        }
                        else
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition].Cells[1];
                        }
                    }
                    dgvUsers_SelectionChanged(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
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

                    frmEmailEntry fUser = new frmEmailEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvUsers.CurrentRow.Cells["Email_ID"].Value));
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
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition - 1].Cells[1];
                        }
                        else
                        {
                            dgvUsers.CurrentCell = dgvUsers.Rows[idgvPosition].Cells[1];
                        }
                    }
                    dgvUsers_SelectionChanged(sender, e);

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
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

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "User Register", true, false, false, false, false, false, true, false, false, false, false);

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
                Utill.Common.ExceptionLogger.writeException("Email - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void frmGodownList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
            dgvUsers_SelectionChanged(sender, e);
            btnNew.Enabled = false;
            btnDelete.Enabled = false;

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#1202#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#1203#") != -1)
                    { btnEmailDetail.Enabled = true; }
                    else { btnEmailDetail.Enabled = false; }
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void btnEmailDetail_Click(object sender, EventArgs e)
        {
            try
            {
                frmCon_Mail_Detail fUser = new frmCon_Mail_Detail((int)Constant.Mode.Modify, 0);
                fUser.ShowInTaskbar = false;
                fUser.ShowDialog();
                LoadList();

                dgvUsers_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
            }
        }

        

    }
}
