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

namespace Account.GUI.CustomerPayment
{
    public partial class frmCustomerPaymentList : Account.GUIBase
    {
        #region "Variable Declaration...."

        DataTable ObjDataTable = new DataTable();
        DataTable ObjDataTableRegister = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;

        #endregion

        #region "Form load events"

        public frmCustomerPaymentList()
        {
            InitializeComponent();
        }

        private void frmCustomerPaymentList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {

                ObjDataTable = objList.ListOfRecord("usp_CustomerReceipt_List", null, "Customer Payment - List - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvCustomerPayment.CurrentRow != null)
                    {
                        idgvPosition = dgvCustomerPayment.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvCustomerPayment.AutoGenerateColumns = false;
                    dgvCustomerPayment.DataSource = ObjDataTable;
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomerPayment.RowCount.ToString();
                    if (dgvCustomerPayment.CurrentRow != null && idgvPosition <= dgvCustomerPayment.RowCount)
                    {
                        if (dgvCustomerPayment.Rows.Count - 1 < idgvPosition)
                        {
                            dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition].Cells[0];
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
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvCustomerPayment.Columns["ReceiptCode"].DataPropertyName = ObjDataTable.Columns["ReceiptCode"].ToString();
                dgvCustomerPayment.Columns["ReceiptID"].DataPropertyName = ObjDataTable.Columns["ReceiptID"].ToString();
                dgvCustomerPayment.Columns["ReceiptDate"].DataPropertyName = ObjDataTable.Columns["ReceiptDate"].ToString();
                dgvCustomerPayment.Columns["CustomerCode"].DataPropertyName = ObjDataTable.Columns["CustomerCode"].ToString();
                dgvCustomerPayment.Columns["Customer"].DataPropertyName = ObjDataTable.Columns["CustomerName"].ToString();
                dgvCustomerPayment.Columns["NetAmount"].DataPropertyName = ObjDataTable.Columns["NetAmount"].ToString();
                dgvCustomerPayment.Columns["Narration"].DataPropertyName = ObjDataTable.Columns["Narration"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvCustomerPayment.SortedColumn != null)
                {
                    sortedColumn = dgvCustomerPayment.SortedColumn;
                    sortDirection = dgvCustomerPayment.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
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

                dgvCustomerPayment.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomerPayment.RowCount.ToString();

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

                    dgvCustomerPayment.Sort(dgvCustomerPayment.Columns[sortedColumn.Name], LSD);
                }
                if (dgvCustomerPayment.CurrentRow != null && idgvPosition <= dgvCustomerPayment.RowCount)
                {
                    if (dgvCustomerPayment.Rows.Count - 1 < idgvPosition)
                    {
                        dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvCustomerPayment.CurrentCell = dgvCustomerPayment.Rows[idgvPosition].Cells[0];
                    }
                }
               
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button events"

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";
                if (txtPaymentCode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ReceiptCode LIKE '%" + PrepareFilterString(txtPaymentCode.Text.Trim()) + "%' And ";
                }
                if (txtCustomer.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " CustomerName LIKE '%" + PrepareFilterString(txtCustomer.Text.Trim()) + "%' And ";
                }
                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " ReceiptDate >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " Date <= '" + txtTodate.Text.Trim() + "' And ";
                }               

                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }

                DV = ObjDataTable.DefaultView;
                DV.RowFilter = StrFilter;
                dgvCustomerPayment.DataSource = DV.ToTable();
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvCustomerPayment.RowCount.ToString();
                ArrangeDataGridView();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtPaymentCode.Text = "";
                txtCustomer.Text = "";
                txtFromDate.Text = "";
                txtTodate.Text = "";
                StrFilter = "";
                LoadList();
               
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
             try
            {
                frmCustomerPaymentEntry fCustomerPayment = new frmCustomerPaymentEntry((int)Constant.Mode.Insert, 0);
                fCustomerPayment.ShowInTaskbar = false;
                fCustomerPayment.ShowDialog();
                btnApply_Click(sender, e);
                LoadList();
                
            }
             catch (Exception exc)
             {
                 Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                 MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
             }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomerPayment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerPaymentEntry fCustomerPayment = new frmCustomerPaymentEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvCustomerPayment.CurrentRow.Cells["ReceiptID"].Value));
                    fCustomerPayment.ShowInTaskbar = false;
                    fCustomerPayment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomerPayment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmCustomerPaymentEntry fCustomerPayment = new frmCustomerPaymentEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvCustomerPayment.CurrentRow.Cells["ReceiptID"].Value));
                    fCustomerPayment.ShowInTaskbar = false;
                    fCustomerPayment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Datagrid Event"

        private void dgvCustomerPayment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomerPayment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomerPayment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        
        #endregion

        #region "TextBox events"

        private void txtFromentryno_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            DataValidator.AllowOnlyCharacter(ascii,e);
        }

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-,.");
        }

        #endregion

        #region "DatePicker events"

        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
            txtFromDate.Text = dtpFromDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpTodate_CloseUp(object sender, EventArgs e)
        {
            txtTodate.Text = dtpTodate.Value.ToString("dd/MM/yyyy");
        }

        #endregion
    }
}
