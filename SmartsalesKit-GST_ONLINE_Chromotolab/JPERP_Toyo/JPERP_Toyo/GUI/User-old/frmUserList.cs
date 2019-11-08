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

namespace Account.GUI.Users
{
    public partial class frmUserList : Account.GUIBase
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
        //Int64 _CompId = 0;
        bool _isBind = false;
        bool IsShowAll = false;
        int _CompId = 0;

        #endregion

        #region "Form Event...."

        public frmUserList()
        {
            InitializeComponent();
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#8007#") != -1)
                    {
                        cmbreports.Items.Add("User Register");
                    }
                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("User Register");
            }
            cmbreports.SelectedIndex = 0;
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
            //dgvUsers_SelectionChanged(sender, e);
            DV = dtblUser.DefaultView;
            DV.RowFilter = StrFilter;
            dgvUsers.DataSource = DV.ToTable();

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#8002#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#8003#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#8004#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#8005#") != -1)
                    { btnShowPassword.Enabled = true; }
                    else { btnShowPassword.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#8006#") != -1)
                    { btnActDeAct.Enabled = true; }
                    else { btnActDeAct.Enabled = false; }
                }
            }
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                _isBind = false;
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", _CompId.ToString());
                para1.Add("@i_UserID", CurrentUser.UserID.ToString());

                dtblUser = objList.ListOfRecord("usp_User_List", para1, "User - LoadList");
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
                dgvUsers.Columns[0].DataPropertyName = dtblUser.Columns["UserName"].ToString();
                dgvUsers.Columns[1].DataPropertyName = dtblUser.Columns["Password"].ToString();
                dgvUsers.Columns[2].DataPropertyName = dtblUser.Columns["DisplayName"].ToString();
                dgvUsers.Columns[3].DataPropertyName = dtblUser.Columns["IsActive"].ToString();
                dgvUsers.Columns[4].DataPropertyName = dtblUser.Columns["UserID"].ToString();
                dgvUsers.Columns[5].DataPropertyName = dtblUser.Columns["CompId"].ToString();
                dgvUsers.Columns["Company"].DataPropertyName = dtblUser.Columns["Company"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmUserEntry fUser = new frmUserEntry((int)Constant.Mode.Insert, 0,CurrentCompany.CompId);
                fUser.ShowInTaskbar = false;
                fUser.ShowDialog();
                LoadList();
                btnClear_Click(sender, e);
                dgvUsers_SelectionChanged(sender, e);

             
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
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
                    frmUserEntry fUser = new frmUserEntry((int)Constant.Mode.Modify, (Int64)dgvUsers.CurrentRow.Cells["UserID"].Value,CurrentCompany.CompId);
                    fUser.ShowInTaskbar = false;
                    fUser.ShowDialog();
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
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow != null)
                {
                    if ((Int64)dgvUsers.CurrentRow.Cells["UserID"].Value == CurrentUser.UserID)
                    {
                        MessageBox.Show("You can not delete this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (dgvUsers.SortedColumn != null)
                        {
                            sortedColumn = dgvUsers.SortedColumn;
                            sortDirection = dgvUsers.SortOrder;
                        }

                        frmUserEntry fUser = new frmUserEntry((int)Constant.Mode.Delete, (Int64)dgvUsers.CurrentRow.Cells["UserID"].Value,CurrentCompany.CompId);
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
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
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

        private void btnActDeAct_Click(object sender, EventArgs e)
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

                    if (dgvUsers.CurrentRow.Cells["IsActive"].Value.ToString() == "Active")
                    {
                        if ((Int64)dgvUsers.CurrentRow.Cells["UserID"].Value != CurrentUser.UserID)
                        {
                            if (MessageBox.Show("You are going to deactivate the user.\n\n Are you sure?", "Deactivate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                            {
                                ObjUser.Activate_DeactivateUser(Convert.ToInt64(dgvUsers.CurrentRow.Cells["UserID"].Value),_CompId, 0, "usp_User_ActiveDeactive");
                                if (ObjUser.Exception == null)
                                {
                                    LoadList();
                                    //btnApply_Click(sender, e);
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
                                else
                                {
                                    MessageBox.Show(ObjUser.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("You can not deactivate this user.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("You are going to Activate the user.\n\n Are you sure?", "Activate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            ObjUser.Activate_DeactivateUser(Convert.ToInt64(dgvUsers.CurrentRow.Cells["UserID"].Value),_CompId, 1, "usp_User_ActiveDeactive");
                            if (ObjUser.Exception == null)
                            {
                                LoadList();
                               // btnApply_Click(sender, e);

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
                            else
                            {
                                MessageBox.Show(ObjUser.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblUser.DefaultView;
            DV.RowFilter = StrFilter;
            dgvUsers.DataSource = DV.ToTable();
            User.frmUserFilter frt = new User.frmUserFilter(dtblUser);
            frt.ShowDialog();
            StrFilter = frt.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvUsers.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvUsers.RowCount.ToString();

            ArrangeDataGridView();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";
                LoadList();
                // dgvUsers_SelectionChanged(sender, e);
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
                        if (dgvUsers.CurrentRow.Cells["IsActive"].Value.ToString() == "Active")
                        {
                            btnActDeAct.Text = "Deactivate";
                        }
                        else
                        {
                            btnActDeAct.Text = "Activate";
                        }
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
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvUsers, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvUsers, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Report Event...."

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex > 0)
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
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("User - Register", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
        }

        #endregion

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
                Email.frmCon_Mail_Detail fUser = new Email.frmCon_Mail_Detail((int)Constant.Mode.Modify, 0);
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
