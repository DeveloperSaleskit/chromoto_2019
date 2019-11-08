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

namespace Account.GUI.ItemStock
{
    public partial class frmAdjustStock : Account.GUIBase
    {
        #region "Variable Declaration"

        ItemStockBL objStockBL = new ItemStockBL();
        DataTable _MyDatatable = new DataTable();

        #endregion

        #region "Public Properties ..."

        public DataTable MyDatatable
        {
            get
            { return _MyDatatable; }
            set
            { _MyDatatable = value; }
        }

        #endregion

        #region "Form Event"

        public frmAdjustStock()
        {
            InitializeComponent();
        }

        private void frmAdjustStock_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            //dtpAdjustDate.MinDate = CurrentUser.FYStartDate;
            //dtpAdjustDate.MaxDate = CurrentUser.FYEndDate;
            dtpAdjustDate.Value = DateTime.Now;
            dgvAdjustStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgvAdjustStock.ReadOnly = false;
            dgvAdjustStock.StandardTab = false;
            ArrangeDataGridView();
            dgvAdjustStock.AutoGenerateColumns = false;
            dgvAdjustStock.DataSource = MyDatatable;

            ArrangeDataGridView();
            this.Text = "Adjust Stock";

        }

        #endregion

        #region "Private Helper Methods"

        private void ArrangeDataGridView()
        {
            try
            {
                dgvAdjustStock.Columns["ItemID"].DataPropertyName = MyDatatable.Columns["ItemID"].ToString();
                dgvAdjustStock.Columns["ItemCode"].DataPropertyName = MyDatatable.Columns["ItemCode"].ToString();
                dgvAdjustStock.Columns["ItemName"].DataPropertyName = MyDatatable.Columns["ItemName"].ToString();
                dgvAdjustStock.Columns["QOH"].DataPropertyName = MyDatatable.Columns["QOH"].ToString();
                dgvAdjustStock.Columns["ActualQty"].DataPropertyName = "0.000";
                dgvAdjustStock.Columns["DiffQty"].DataPropertyName = "0.000";
                dgvAdjustStock.Columns["GodownID"].DataPropertyName = MyDatatable.Columns["GodownID"].ToString();
                dgvAdjustStock.Columns["Godown_name"].DataPropertyName = MyDatatable.Columns["Godown_name"].ToString();

                dgvAdjustStock.Columns["ItemCode"].ReadOnly = true;
                dgvAdjustStock.Columns["ItemName"].ReadOnly = true;
                dgvAdjustStock.Columns["QOH"].ReadOnly = true;
                dgvAdjustStock.Columns["DiffQty"].ReadOnly = true;
                dgvAdjustStock.Columns["GodownID"].ReadOnly = true;
                dgvAdjustStock.Columns["Godown_name"].ReadOnly = true;
                dgvAdjustStock.Columns["GodownID"].Visible = false;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        #region "Button Event"

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAdjustStock.EndEdit();

                for (int i = 0; i < dgvAdjustStock.RowCount; i++)
                {
                    if (Convert.ToBoolean(dgvAdjustStock.Rows[i].Cells["SelectRec"].Value) == true)
                    {
                        if (dgvAdjustStock.Rows[i].Cells["ActualQty"].Value == null || dgvAdjustStock.Rows[i].Cells["ActualQty"].Value.ToString() == "" || Convert.ToDecimal(dgvAdjustStock.Rows[i].Cells["ActualQty"].Value) <= 0)
                        {
                            lblErrorMessage.Text = "Enter actual qty";
                            dgvAdjustStock.CurrentCell = dgvAdjustStock.Rows[i].Cells["ActualQty"];
                            dgvAdjustStock.BeginEdit(true);
                            return;
                        }
                    }
                }

                //Prepare XMLString
                int Cnt = 0;
                string XMLString = string.Empty;
                XMLString = "<NewDataSet>";
                for (int i = 0; i < dgvAdjustStock.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dgvAdjustStock.Rows[i].Cells["SelectRec"].Value) == true)
                    {
                        XMLString = XMLString + "<Table>";

                        XMLString = XMLString + "<ItemID>" + dgvAdjustStock.Rows[i].Cells["ItemID"].Value + "</ItemID>";
                        XMLString = XMLString + "<Qty>" + dgvAdjustStock.Rows[i].Cells["DiffQty"].Value + "</Qty>";
                        XMLString = XMLString + "<GodownID>" + dgvAdjustStock.Rows[i].Cells["GodownID"].Value + "</GodownID>";
                        XMLString = XMLString + "</Table> ";
                        Cnt = Cnt + 1;

                    }
                }
                XMLString = XMLString + "</NewDataSet>";

                if (Cnt == 0)
                {
                    dgvAdjustStock.Focus();
                    lblErrorMessage.Text = "Select at least one record";
                    return;
                }

                objStockBL.AdjustStock(dtpAdjustDate.Value, txtNarration.Text, XMLString, Cnt);

                if (objStockBL.Exception == null)
                {
                    if (objStockBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objStockBL.ErrorMessage;
                        dgvAdjustStock.Focus();
                        return;
                    }
                    else
                    {
                        lblErrorMessage.Text = "No error";
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show(objStockBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvAdjustStock_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvAdjustStock, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvAdjustStock, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvAdjustStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvAdjustStock_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAdjustStock.CurrentRow != null)
                {
                    this.dgvAdjustStock.CurrentCell.Style.SelectionBackColor = Color.White;
                    this.dgvAdjustStock.CurrentCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvAdjustStock_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAdjustStock.Rows.Count > 0)
                {
                    this.dgvAdjustStock.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                    this.dgvAdjustStock.CurrentCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        private void dgvAdjustStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();

        }

        #endregion

        #region "Function for KeyPress and KeyLeave Event in Grid..."

        public void KeyPressed(object o, KeyPressEventArgs e)
        {
            try
            {
                DataValidator.AllowOnlyNumeric(e, ".");

                if (dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    switch (dgvAdjustStock.CurrentCell.ColumnIndex)
                    {
                        case 5:
                            if (dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString().Length >= 14)
                            {
                                e.Handled = true;
                            }
                            break;
                    }

                    if (Convert.ToInt16(e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvAdjustStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += KeyPressed;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvAdjustStock_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvAdjustStock.EndEdit();
                switch (dgvAdjustStock.CurrentCell.ColumnIndex)
                {
                    case 5:
                        if (dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString() == "" || dgvAdjustStock.CurrentCell.Value == null)
                        {
                            dgvAdjustStock.CurrentCell.Value = "0.000";
                        }
                        else
                        {
                            if (DataValidator.IsNumeric(dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString()))
                            {
                                string str;
                                str = dgvAdjustStock.CurrentCell.Value.ToString();
                                if (dgvAdjustStock.CurrentCell.Value.ToString().IndexOf(".") != -1)
                                {
                                    str = str.Substring(0, str.IndexOf("."));
                                    if (str.Length <= 14)
                                    {
                                        dgvAdjustStock.CurrentCell.Value = String.Format("{0:0.000}", Convert.ToDecimal(dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString()));
                                    }
                                }
                                else if (dgvAdjustStock.CurrentCell.Value.ToString().Length <= 14)
                                {
                                    dgvAdjustStock.CurrentCell.Value = String.Format("{0:0.000}", Convert.ToDecimal(dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString()));
                                }
                                else
                                {
                                    dgvAdjustStock.CurrentCell.Value = str.Substring(0, 14);
                                    dgvAdjustStock.CurrentCell.Value = String.Format("{0:0.000}", Convert.ToDecimal(dgvAdjustStock.CurrentCell.EditedFormattedValue.ToString()));
                                }

                                if (Convert.ToDecimal(dgvAdjustStock.CurrentCell.Value) > 0)
                                {
                                    dgvAdjustStock.CurrentRow.Cells["DiffQty"].Value = Convert.ToDecimal(dgvAdjustStock.CurrentRow.Cells["ActualQty"].Value) - Convert.ToDecimal(dgvAdjustStock.CurrentRow.Cells["QOH"].Value);
                                }
                            }
                            else
                            {
                                dgvAdjustStock.CurrentCell.Value = "0.000";
                            }
                        }
                        break;

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("AdjustStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

    }
}
