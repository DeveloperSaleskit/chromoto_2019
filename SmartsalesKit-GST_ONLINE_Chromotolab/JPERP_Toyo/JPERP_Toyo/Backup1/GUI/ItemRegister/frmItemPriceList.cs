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


namespace Account.GUI.ItemRegister
{
    public partial class frmItemPriceList : Account.GUIBase
    {

        #region "Variable Declaration...."

        DataTable dtblItem = new DataTable();
        CommonListBL objList = new CommonListBL();
        ItemBL objItemBL = new ItemBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        int idgvPosition = 0;
        string StrFilter = "";
        DataView DV;
        long _ItemID;
        bool ValGrid = false;
        string strHead = "";
        DataGridViewCheckBoxColumn chkSelect = new DataGridViewCheckBoxColumn(false);
        #endregion

        #region "Form Event...."

        public frmItemPriceList(long ItemID, string _StrFilter)
        {
            try
            {
                InitializeComponent();
                _ItemID = ItemID;
                StrFilter = _StrFilter;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void frmItemPriceList_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                dtpDate.Value = DateTime.Now;
                dgvUpdateRatesList.ReadOnly = false;
                cmbApply.SelectedIndex = 0;
                LoadList();
                this.Text = "Item - Pricelist";
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event...."

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbApply.SelectedIndex > 0)
                {
                    if (txtValue.Text.Trim() != "")
                    {
                        if (cmbApply.SelectedIndex == 1 || cmbApply.SelectedIndex == 2)
                        {
                            if (DataValidator.IsNumeric(txtValue.Text))
                            {
                                if (Convert.ToDecimal(txtValue.Text) <= 0)
                                {
                                    lblErrorMessage.Text = "Please enter value";
                                    txtValue.Focus();
                                    return;
                                }
                                txtValue.Text = Convert.ToDecimal(txtValue.Text).ToString("#0.00");
                                // Set Decimal Value after textbox's Leave Event
                                lblErrorMessage.Text = "No error";
                                int t = txtValue.TextLength;
                                if (t <= txtValue.MaxLength)
                                {
                                    lblErrorMessage.Text = "No error";
                                }
                                else
                                {
                                    lblErrorMessage.Text = DataValidator.lblFormatMessage + "999999999999999.99";
                                    txtValue.Focus();
                                    return;
                                }
                            }
                            else
                            {
                                txtValue.Text = "0.00";
                                return;
                            }
                        }

                        int i;
                        int CountItem = 0;
                        for (i = 0; i <= dgvUpdateRatesList.Rows.Count - 1; i++)
                        {
                            if (Convert.ToBoolean(dgvUpdateRatesList.Rows[i].Cells[0].Value) == true)
                            {
                                dgvUpdateRatesList.Rows[i].Cells[strHead].Value = txtValue.Text;
                                CountItem = CountItem + 1;
                            }
                        }
                        if (CountItem == 0)
                        {
                            lblErrorMessage.Text = "Select at least one item";
                            return;
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "Please enter value";
                        txtValue.Focus();
                    }
                }
                else
                {
                    lblErrorMessage.Text = "First select apply to which";
                    cmbApply.Focus();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetSave())
                {
                    this.Dispose();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                dtblItem = objList.ListOfRecord("usp_Item_Rate_List", null, "ItemPriceList - LoadList");
                if (objList.Exception == null)
                {
                    if (dgvUpdateRatesList.CurrentRow != null)
                    {
                        idgvPosition = dgvUpdateRatesList.CurrentRow.Index;
                    }
                    ArrangeDataGridView();
                    dgvUpdateRatesList.AutoGenerateColumns = false;
                    dtblItem.DefaultView.RowFilter = StrFilter;
                    DV = dtblItem.DefaultView;
                    DV.RowFilter = StrFilter;
                    dtblItem = DV.ToTable();

                    dgvUpdateRatesList.DataSource = dtblItem;
                    //dgvUpdateRatesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; 
                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvUpdateRatesList.RowCount.ToString();
                    if (dgvUpdateRatesList.CurrentRow != null && idgvPosition <= dgvUpdateRatesList.RowCount)
                    {
                        if (dgvUpdateRatesList.Rows.Count - 1 < idgvPosition)
                        {
                            dgvUpdateRatesList.CurrentCell = dgvUpdateRatesList.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvUpdateRatesList.CurrentCell = dgvUpdateRatesList.Rows[idgvPosition].Cells[0];
                        }
                    }
                    ArrangeDataGridView();
                    ValGrid = true;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvUpdateRatesList.Columns[0].DataPropertyName = dtblItem.Columns["IsSelect"].ToString();
                dgvUpdateRatesList.Columns[2].DataPropertyName = dtblItem.Columns["ItemID"].ToString();
                dgvUpdateRatesList.Columns[1].DataPropertyName = dtblItem.Columns["Name"].ToString();
                dgvUpdateRatesList.Columns[3].DataPropertyName = dtblItem.Columns["Rate"].ToString();
                dgvUpdateRatesList.Columns[4].DataPropertyName = dtblItem.Columns["VatRate"].ToString();
                dgvUpdateRatesList.Columns[5].DataPropertyName = dtblItem.Columns["UOMID"].ToString();
                dgvUpdateRatesList.Columns[6].DataPropertyName = dtblItem.Columns["ItemClassID"].ToString();
                dgvUpdateRatesList.Columns[7].DataPropertyName = dtblItem.Columns["CategoryID"].ToString();

                dgvUpdateRatesList.Columns[0].ReadOnly = false;
                dgvUpdateRatesList.Columns[1].ReadOnly = true;
                dgvUpdateRatesList.Columns[2].ReadOnly = true;
                dgvUpdateRatesList.Columns[3].ReadOnly = true;
                dgvUpdateRatesList.Columns[4].ReadOnly = true;
                dgvUpdateRatesList.Columns[5].ReadOnly = true;
                dgvUpdateRatesList.Columns[6].ReadOnly = true;
                dgvUpdateRatesList.Columns[7].ReadOnly = true;

                int i;
                for (i = 0; i <= dgvUpdateRatesList.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dgvUpdateRatesList.Rows[i].Cells[0].Value) == true)
                    {
                        dgvUpdateRatesList.Rows[i].Cells[3].ReadOnly = false;
                        dgvUpdateRatesList.Rows[i].Cells[4].ReadOnly = false;
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public bool SetSave()
        {
            bool ReturnValue = false;
            try
            {
                if (DataValidator.IsValid(this.grpData))
                {
                    dgvUpdateRatesList.EndEdit();
                    int i;

                    for (i = 0; i < dgvUpdateRatesList.Rows.Count; i++)
                    {
                        if (dgvUpdateRatesList.Rows[i].IsNewRow == false)
                        {
                            if (Convert.ToBoolean(dgvUpdateRatesList.Rows[i].Cells[0].Value) == true)
                            {
                                if (Convert.ToInt64(dgvUpdateRatesList.Rows[i].Cells["Rate"].Value) <= 0)
                                {
                                    lblErrorMessage.Text = "Enter rate";
                                    dgvUpdateRatesList.CurrentCell = dgvUpdateRatesList.Rows[i].Cells["Rate"];
                                    dgvUpdateRatesList.BeginEdit(true);
                                    return false;
                                }
                                if (Convert.ToInt64(dgvUpdateRatesList.Rows[i].Cells["VatRate"].Value) <= 0)
                                {
                                    lblErrorMessage.Text = "Enter vat rate";
                                    dgvUpdateRatesList.CurrentCell = dgvUpdateRatesList.Rows[i].Cells["VatRate"];
                                    dgvUpdateRatesList.BeginEdit(true);
                                    return false;
                                }
                            }
                        }
                    }

                    int Cnt = 0;
                    string XMLString = string.Empty;
                    XMLString = "<NewDataSet>";

                    for (i = 0; i < dgvUpdateRatesList.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvUpdateRatesList.Rows[i].Cells[0].Value) == true)
                        {
                            XMLString = XMLString + "<Table>";
                            XMLString = XMLString + "<ItemID>" + dgvUpdateRatesList.Rows[i].Cells["ItemID"].Value + "</ItemID>";
                            XMLString = XMLString + "<Rate>" + dgvUpdateRatesList.Rows[i].Cells["Rate"].Value + "</Rate>";
                            XMLString = XMLString + "<VatRate>" + dgvUpdateRatesList.Rows[i].Cells["VatRate"].Value + "</VatRate>";
                            XMLString = XMLString + "</Table> ";
                            Cnt = Cnt + 1;
                        }
                    }
                    XMLString = XMLString + "</NewDataSet>";

                    if (Cnt == 0)
                    {
                        lblErrorMessage.Text = "Select at least one item";
                        return false;
                    }

                    objItemBL.UpdateRates(dtpDate.Value, XMLString, Cnt);

                    if (objItemBL.Exception == null)
                    {
                        if (objItemBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objItemBL.ErrorMessage;
                            ReturnValue = false;
                        }
                        else
                        {
                            ReturnValue = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(objItemBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        #endregion

        #region "Grid Cell Event"

        public void KeyPressed(object o, KeyPressEventArgs e)
        {
            try
            {
                if (dgvUpdateRatesList.CurrentCell.ColumnIndex == 3 || dgvUpdateRatesList.CurrentCell.ColumnIndex == 4)
                {
                    DataValidator.AllowOnlyNumeric(e, ".");
                }
                if (dgvUpdateRatesList.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt16(e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvUpdateRatesList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (ValGrid == true)
            {
                dgvUpdateRatesList.EndEdit();
                //if (dgvUpdateRatesList.Rows.Count > 0)
                //{
                if (e.ColumnIndex == 0)
                {
                    if (Convert.ToBoolean(dgvUpdateRatesList.CurrentCell.Value) == true)
                    {
                        dgvUpdateRatesList.CurrentRow.Cells[3].ReadOnly = false;
                        dgvUpdateRatesList.CurrentRow.Cells[4].ReadOnly = false;
                        dgvUpdateRatesList.CurrentRow.Cells[5].ReadOnly = false;
                        dgvUpdateRatesList.CurrentRow.Cells[6].ReadOnly = false;
                    }
                    else
                    {
                        dgvUpdateRatesList.CurrentRow.Cells[3].ReadOnly = true;
                        dgvUpdateRatesList.CurrentRow.Cells[4].ReadOnly = true;
                        dgvUpdateRatesList.CurrentRow.Cells[5].ReadOnly = true;
                        dgvUpdateRatesList.CurrentRow.Cells[6].ReadOnly = true;
                        dgvUpdateRatesList.CurrentRow.Cells[3].Value = "0.00";
                        dgvUpdateRatesList.CurrentRow.Cells[4].Value = "0.00";
                       
                        //dgvUpdateRatesList.CurrentRow.Cells[6].Value = "";

                    }
                }
                //}
            }

        }


        private void dgvUpdateRatesList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvUpdateRatesList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvUpdateRatesList, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvUpdateRatesList, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register - Update Rate", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvUpdateRatesList_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUpdateRatesList.CurrentRow != null)
                {
                    this.dgvUpdateRatesList.CurrentCell.Style.SelectionBackColor = Color.White;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register - Update Rate", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvUpdateRatesList_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUpdateRatesList.Rows.Count > 0)
                {
                    this.dgvUpdateRatesList.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register - Update Rate", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        #region "Key Press Event"

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbApply.SelectedIndex > 0)
            {
                if (cmbApply.SelectedIndex == 1 || cmbApply.SelectedIndex == 2)
                {
                    DataValidator.AllowOnlyNumeric(e, ".");
                }
                else
                {
                    int ascii = e.KeyChar;
                    DataValidator.AllowOnlyCharacter(ascii, e);
                }
            }

        }

        #endregion

        #region "ComboBox Change Event"

        private void cmbApply_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = "";
            if (cmbApply.SelectedIndex == 1 || cmbApply.SelectedIndex == 2)
            {
                txtValue.TextAlign = HorizontalAlignment.Right;
                txtValue.MaxLength = 18;
                txtValue.Text = "0.00";
                if (cmbApply.SelectedIndex == 1)
                {
                    strHead = "Rate";
                }
                if (cmbApply.SelectedIndex == 2)
                {
                    strHead = "VatRate";
                }
            }
            else
            {
                txtValue.TextAlign = HorizontalAlignment.Left;
                txtValue.MaxLength = 50;
                if (cmbApply.SelectedIndex == 3)
                {
                    strHead = "TariffHeading";
                }
                if (cmbApply.SelectedIndex == 4)
                {
                    strHead = "HSNCode";
                }
            }
        }

        #endregion

      

    }
}
