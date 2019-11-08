using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using Account.Validator;
using System.Configuration;

namespace Account.GUI.Currency
{
    public partial class frmCurrencyList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable dtblEmployee = new DataTable();

        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        int idgvPosition = 0;

        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        int _CompId = 0;

        string StrFilter = "";
        DataView DV;

        #endregion

        #region "Form load event"

        public frmCurrencyList()
        {
            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
               
                LoadList();
                DV = dtblEmployee.DefaultView;
                DV.RowFilter = StrFilter;
                dgvEmployee.DataSource = DV.ToTable();

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#4002#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#4003#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#4004#") != -1)
                        { btnDelete.Enabled = true; }
                        else { btnDelete.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#9006#") != -1)
                        { btnfilter.Enabled = true; }
                        else { btnfilter.Enabled = false; }
                    }
                }

               
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        #endregion

        #region "Button Events"

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCurrencyEntry fCustomer = new frmCurrencyEntry((int)Constant.Mode.Insert, 0);
                fCustomer.ShowInTaskbar = false;
                fCustomer.ShowDialog();
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCurrencyEntry fCustomer = new frmCurrencyEntry((int)Constant.Mode.Modify, (Int64)dgvEmployee.CurrentRow.Cells["CurrencyID"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployee.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCurrencyEntry fCustomer = new frmCurrencyEntry((int)Constant.Mode.Delete, (Int64)dgvEmployee.CurrentRow.Cells["CurrencyID"].Value);
                    fCustomer.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
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

                dtblEmployee = objList.ListOfRecord("usp_Currency_List", para, "Employee-List");
                if (objList.Exception == null)
                {
                    if (dgvEmployee.CurrentRow != null)
                    {
                        idgvPosition = dgvEmployee.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvEmployee.AutoGenerateColumns = false;
                    dgvEmployee.DataSource = dtblEmployee;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvEmployee.RowCount.ToString();
                    if (dgvEmployee.CurrentRow != null && idgvPosition <= dgvEmployee.RowCount)
                    {
                        if (dgvEmployee.Rows.Count - 1 < idgvPosition)
                        {
                            dgvEmployee.CurrentCell = dgvEmployee.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvEmployee.CurrentCell = dgvEmployee.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvEmployee.Columns["CurrencyName"].DataPropertyName = dtblEmployee.Columns["CurrencyName"].ToString();
                dgvEmployee.Columns["Currency"].DataPropertyName = dtblEmployee.Columns["Currency"].ToString();
                dgvEmployee.Columns["CurrencyID"].DataPropertyName = dtblEmployee.Columns["CurrencyID"].ToString();
                
                
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            if (dgvEmployee.SortedColumn != null)
            {
                sortedColumn = dgvEmployee.SortedColumn;
                sortDirection = dgvEmployee.SortOrder;
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

                dgvEmployee.Sort(dgvEmployee.Columns[sortedColumn.Name], LSD);
            }
            if (dgvEmployee.CurrentRow != null && idgvPosition <= dgvEmployee.RowCount)
            {
                if (dgvEmployee.Rows.Count - 1 < idgvPosition)
                {
                    dgvEmployee.CurrentCell = dgvEmployee.Rows[idgvPosition - 1].Cells[0];
                }
                else
                {
                    dgvEmployee.CurrentCell = dgvEmployee.Rows[idgvPosition].Cells[0];
                }
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
                    GridDrawCustomHeaderColumns(dgvEmployee, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvEmployee, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblEmployee.DefaultView;
            DV.RowFilter = StrFilter;
            dgvEmployee.DataSource = DV.ToTable();
            frmCurrencyFilter filterSalesinvoice = new frmCurrencyFilter(dtblEmployee);
            filterSalesinvoice.ShowDialog();
            DataTable dt = DV.ToTable();
            dgvEmployee.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvEmployee.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }
    }
}
