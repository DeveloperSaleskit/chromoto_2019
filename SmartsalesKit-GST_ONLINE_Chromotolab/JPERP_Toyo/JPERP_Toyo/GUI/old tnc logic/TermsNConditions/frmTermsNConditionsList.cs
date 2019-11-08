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

namespace Account.GUI.TermsNConditions
{
    public partial class frmTermsNConditionsList : Account.GUIBase
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

        public frmTermsNConditionsList()
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
               
                dtblUser = objList.ListOfRecord("usp_TNC_List", null,"TNC - LoadList");
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
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        private void ArrangeDataGridView()
        {
            try
            {
                
                dgvUsers.Columns["TNC_Sub"].DataPropertyName = dtblUser.Columns["TNC_Sub"].ToString();
              
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmTermsNConditionsEntry fUser = new frmTermsNConditionsEntry((int)Constant.Mode.Insert, "");
                fUser.ShowInTaskbar = false;
                fUser.ShowDialog();
                LoadList();
           
                dgvUsers_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
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
                    frmTermsNConditionsEntry fUser = new frmTermsNConditionsEntry((int)Constant.Mode.Modify, (dgvUsers.CurrentRow.Cells["TNC_Sub"].Value).ToString());
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
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
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

                        frmTermsNConditionsEntry fUser = new frmTermsNConditionsEntry((int)Constant.Mode.Delete, (dgvUsers.CurrentRow.Cells["TNC_Sub"].Value).ToString());
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
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
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
            dgvUsers_SelectionChanged(sender, e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

    }
}
