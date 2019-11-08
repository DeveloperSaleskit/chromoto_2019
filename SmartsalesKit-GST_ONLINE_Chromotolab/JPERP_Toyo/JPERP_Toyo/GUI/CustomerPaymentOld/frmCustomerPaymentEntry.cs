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

    public partial class frmCustomerPaymentEntry : Account.GUIBase
    {

        #region "Variable Declaration..."

        CommonListBL objList = new CommonListBL();
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CustomerPaymentBL objCustomerPaymentBL = new CustomerPaymentBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtblCustomer = new DataTable();
        DataTable dtblCustomerPaymentDetail = new DataTable();

        DataGridViewComboBoxColumn clmItemName = new DataGridViewComboBoxColumn();
        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();

        int _Mode = 0;
        Int64 _CustomerPaymentID = 0;
        Int64 _CustomerID = 0;

        #endregion

        #region "Form load event"

        public frmCustomerPaymentEntry(int Mode, long CustomerPaymentID)
        {
            try
            {
                InitializeComponent();
                _CustomerPaymentID = CustomerPaymentID;
                _Mode = Mode;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void frmCustomerPaymentEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dtpchequeDate.Value = DateTime.Now;
            dgvCustomerPaymentDetail.StandardTab = false;
            LoadCustomerList();
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                DataValidator.SetDefaultDate(dtpDate, null, null);

                dgvCustomerPaymentDetail.ReadOnly = false;
                txtReceiptNo.Text = objCommon.AutoNumber("CPAY");

                this.Text = "Customer Payment - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                dgvCustomerPaymentDetail.ReadOnly = false;

                this.Text = "Customer Payment - Edit";
                BindControl();
                btnCustomerLOV.Enabled = false;
                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "Customer Payment - Delete";
                BindControl();

                SetReadOnlyControls(grpData);
                SetReadOnlyControls(grpDetail);
                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
                dgvCustomerPaymentDetail.TabStop = false;
                btnSaveExit.Text = "Yes";
                btnCancel.Text = "No";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                lblDelMsg.Visible = true;
            }
        }

        #endregion

        #region "Public Methods..."

        private void LoadCustomerList()
        {
            try
            {
                dtblCustomer = objList.ListOfRecord("usp_Customer_LOV", null, "Customer Paymenting - LoadCustomerList");
                if (objList.Exception == null)
                {
                    txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtblCustomer.Rows.Count; i++)
                    {
                        Data.Add(dtblCustomer.Rows[i]["CustomerName"].ToString());
                    }
                    txtCustomerName.AutoCompleteCustomSource = Data;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void BindControl()
        {
            try
            {
                DataSet dsCustomerPayment = new DataSet();
                NameValueCollection Paralist = new NameValueCollection();
                Paralist.Add("@i_RecID", _CustomerPaymentID.ToString());
                dsCustomerPayment = CommSelect.SelectDataSetRecord(Paralist, "usp_CustomerReceipt_Select", "Customer Payment - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dsCustomerPayment.Tables[0].Rows.Count > 0)
                        {
                            txtReceiptNo.Text = dsCustomerPayment.Tables[0].Rows[0]["ReceiptCode"].ToString();
                            dtpDate.Value = (DateTime)dsCustomerPayment.Tables[0].Rows[0]["ReceiptDate"];
                            _CustomerID = Convert.ToInt32(dsCustomerPayment.Tables[0].Rows[0]["CustomerID"].ToString());
                            txtCustomerName.Text = dsCustomerPayment.Tables[0].Rows[0]["CustomerName"].ToString();
                            txtTotalAmount.Text = dsCustomerPayment.Tables[0].Rows[0]["NetAmount"].ToString();
                            txtNarration.Text = dsCustomerPayment.Tables[0].Rows[0]["Narration"].ToString();
                            txtbankName.Text = dsCustomerPayment.Tables[0].Rows[0]["BankName"].ToString();
                            txtChequeNo.Text = dsCustomerPayment.Tables[0].Rows[0]["ChequeNo"].ToString();
                            if (dsCustomerPayment.Tables[0].Rows[0]["ChequeDate"].ToString() != null && dsCustomerPayment.Tables[0].Rows[0]["ChequeDate"].ToString() != "")
                            txtChequeDate.Text = Convert.ToDateTime(dsCustomerPayment.Tables[0].Rows[0]["ChequeDate"].ToString()).ToShortDateString();

                            dgvCustomerPaymentDetail.AutoGenerateColumns = false;
                            dgvCustomerPaymentDetail.DataSource = dsCustomerPayment.Tables[1];
                            dgvCustomerPaymentDetail.Columns["SIID"].Visible = false;

                            dgvCustomerPaymentDetail.Columns["Select"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["RecDetID"].ToString();
                            dgvCustomerPaymentDetail.Columns["PaidAmount"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["PaidAmount"].ToString();
                            dgvCustomerPaymentDetail.Columns["PendingAmount"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["PendingAmount"].ToString();
                            dgvCustomerPaymentDetail.Columns["SalesInvoice"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["SalesCode"].ToString();
                            dgvCustomerPaymentDetail.Columns["SIID"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["SIID"].ToString();
                            dgvCustomerPaymentDetail.Columns["SalesDate"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["SalesDate"].ToString();

                            for (int i = 0; i < dgvCustomerPaymentDetail.Columns.Count; i++)
                            {
                                dgvCustomerPaymentDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            //for (int i = 0; i < dgvCustomerPaymentDetail.Rows.Count; i++)
                            //{
                            for (int j = 0; j < dsCustomerPayment.Tables[1].Rows.Count; j++)
                            {
                                //  if (Convert.ToInt64(dgvCustomerPaymentDetail.Rows[i].Cells["Select"].Value) == Convert.ToInt64(dsCustomerPayment.Tables[1].Rows[j]["RecDetID"]))
                                if (Convert.ToInt64(dsCustomerPayment.Tables[1].Rows[j]["RecDetID"]) > 0)
                                {
                                    dgvCustomerPaymentDetail.Rows[j].Cells["Select"].Value = true;
                                    if (_Mode == (int)Common.Constant.Mode.Modify)
                                    {
                                        dgvCustomerPaymentDetail.Columns["PaidAmount"].ReadOnly = false;
                                    }
                                }
                                else
                                {
                                    dgvCustomerPaymentDetail.Columns["PaidAmount"].ReadOnly = true;
                                }
                            }
                            //}
                        }
                    }
                    else
                    {
                        MessageBox.Show(CommSelect.ErrorMessage);
                    }
                }
                else
                {
                    MessageBox.Show(CommSelect.Exception.Message.ToString());
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - BindControl", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public bool SetSave()
        {
            bool ReturnValue = false;
            try
            {
                if (_Mode == (int)Common.Constant.Mode.Delete)
                {

                    CommDelRec.DeleteRecord(_CustomerPaymentID, "usp_CustomerReceipt_Delete", "Customer Payment - Delete");
                    if (CommDelRec.Exception == null)
                    {
                        if (CommDelRec.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = CommDelRec.ErrorMessage;
                            dtpDate.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
                            ReturnValue = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
                else
                {
                    if (DataValidator.IsValid(this.grpData))
                    {

                        dgvCustomerPaymentDetail.EndEdit();

                        for (int i = 0; i < dgvCustomerPaymentDetail.RowCount; i++)
                        {
                            if (dgvCustomerPaymentDetail.Rows[i].Cells[0].Value != null && dgvCustomerPaymentDetail.Rows[i].Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvCustomerPaymentDetail.Rows[i].Cells[0].Value) == true)
                            //if (Convert.ToBoolean(dgvCustomerPaymentDetail.Rows[i].Cells["Select"].Value) == true)
                            {
                                if (dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"].Value == null || dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString() == "" || Convert.ToDecimal(dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"].Value) <= 0)
                                {
                                    lblErrorMessage.Text = "Enter paid amount";
                                    dgvCustomerPaymentDetail.CurrentCell = dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"];
                                    dgvCustomerPaymentDetail.BeginEdit(true);                                    ReturnValue = false;
                                    return false;
                                }
                            }
                        }


                        int Cnt = 0;
                        string XMLString = string.Empty;
                        XMLString = "<NewDataSet>";
                        for (int i = 0; i < dgvCustomerPaymentDetail.Rows.Count; i++)
                        {
                            if (dgvCustomerPaymentDetail.Rows[i].Cells[0].Value != null && dgvCustomerPaymentDetail.Rows[i].Cells[0].Value.ToString() != "" 
                                && Convert.ToBoolean(dgvCustomerPaymentDetail.Rows[i].Cells[0].Value) == true)
                            {
                                XMLString = XMLString + "<Table>";
                                XMLString = XMLString + "<SIID>" + dgvCustomerPaymentDetail.Rows[i].Cells["SIID"].Value + "</SIID>";
                                XMLString = XMLString + "<PaidAmount>" + dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"].Value + "</PaidAmount>";
                                XMLString = XMLString + "</Table> ";
                                Cnt++;
                            }
                        }
                        XMLString = XMLString + "</NewDataSet>";

                        //Cnt = dgvCustomerPaymentDetail.Rows.Count ;

                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            objCustomerPaymentBL.Insert(txtReceiptNo.Text, dtpDate.Value, _CustomerID, Convert.ToDecimal(txtTotalAmount.Text), 
                                txtNarration.Text, txtbankName.Text, txtChequeNo.Text, txtChequeDate.Text, XMLString, Cnt);
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objCustomerPaymentBL.Update(_CustomerPaymentID, txtReceiptNo.Text, dtpDate.Value, _CustomerID, 
                                Convert.ToDecimal(txtTotalAmount.Text), txtNarration.Text, txtbankName.Text, txtChequeNo.Text,
                                txtChequeDate.Text, XMLString, Cnt);
                        }

                        if (objCustomerPaymentBL.Exception == null)
                        {
                            if (objCustomerPaymentBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objCustomerPaymentBL.ErrorMessage;
                                dtpDate.Focus();
                                ReturnValue = false;
                            }
                            else
                            {
                                ReturnValue = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(objCustomerPaymentBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - SetSave", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        public void TotalAmount()
        {
            decimal TotalAmount = 0;

            for (int i = 0; i < dgvCustomerPaymentDetail.Rows.Count; i++)
            {
                if (dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString() != System.DBNull.Value.ToString())
                {
                    TotalAmount = TotalAmount + Convert.ToDecimal(dgvCustomerPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString());
                }
            }
            txtTotalAmount.Text = TotalAmount.ToString("0.00");

        }

        public void LoadSIList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                CommonListBL objList = new CommonListBL();

                para.Add("@i_CustomerID", _CustomerID.ToString());

                dtblCustomerPaymentDetail = objList.ListOfRecord("usp_CustomerPayment_PendingSI_List", para, "Customer Payemnt- LoadSIList");
                if (objList.Exception == null)
                {
                    dgvCustomerPaymentDetail.AutoGenerateColumns = false;
                    dgvCustomerPaymentDetail.DataSource = dtblCustomerPaymentDetail;

                    if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        dgvCustomerPaymentDetail.Columns["Select"].DataPropertyName = dtblCustomerPaymentDetail.Columns["RecDetID"].ToString();
                    }
                    dgvCustomerPaymentDetail.Columns["PaidAmount"].DataPropertyName = dtblCustomerPaymentDetail.Columns["PaidAmount"].ToString();
                    dgvCustomerPaymentDetail.Columns["PendingAmount"].DataPropertyName = dtblCustomerPaymentDetail.Columns["PendingAmount"].ToString();
                    dgvCustomerPaymentDetail.Columns["SalesInvoice"].DataPropertyName = dtblCustomerPaymentDetail.Columns["SalesCode"].ToString();
                    dgvCustomerPaymentDetail.Columns["SIID"].DataPropertyName = dtblCustomerPaymentDetail.Columns["SIID"].ToString();
                    dgvCustomerPaymentDetail.Columns["SalesDate"].DataPropertyName = dtblCustomerPaymentDetail.Columns["SalesDate"].ToString();

                    for (int i = 0; i < dgvCustomerPaymentDetail.Columns.Count; i++)
                    {
                        dgvCustomerPaymentDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgvCustomerPaymentDetail.Columns["PaidAmount"].ReadOnly = true;
                    }

                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerPayment - LoadSIList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button events"

        private void btnCustomerLOV_Click(object sender, EventArgs e)
        {
            frmCustomerLOV fLOV = new frmCustomerLOV("usp_Customer_LOV_Payment", null);
            fLOV.isFromCustomerPayment = true;
            fLOV.ShowDialog();
            txtCustomerName.Text = fLOV.CustomerName;
            _CustomerID = fLOV.CustomerID;
            if (_CustomerID > 0)
            {
                LoadSIList();
            }
            else
            {
                dgvCustomerPaymentDetail.DataSource = null;
            }
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtReceiptNo.Text = objCommon.AutoNumber("CPAY");
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtReceiptNo.Text = objCommon.AutoNumber("CPAY");
                dtpDate.Value = DateTime.Now;
                txtNarration.Text = "";
                txtCustomerName.Text = "";
                txtTotalAmount.Text = "0.00";
                txtbankName.Text = "";
                txtChequeDate.Text = "";
                txtChequeNo.Text = "";
                dtpchequeDate.Value = DateTime.Now;
                dgvCustomerPaymentDetail.DataSource = null;
               // dgvCustomerPaymentDetail.Columns.Clear();
                lblErrorMessage.Text = "No error";
                dtpDate.Focus();
            }

        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "DataGrid events"

        private void dgvCustomerPaymentDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomerPaymentDetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvCustomerPaymentDetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - New", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvCustomerPaymentDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCustomerPaymentDetail.CurrentRow != null)
                {
                    this.dgvCustomerPaymentDetail.CurrentCell.Style.SelectionBackColor = Color.White;
                    this.dgvCustomerPaymentDetail.CurrentCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvCustomerPaymentDetail_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                lblErrorMessage.Text = "No error";
                this.dgvCustomerPaymentDetail.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                this.dgvCustomerPaymentDetail.CurrentCell.Style.SelectionForeColor = Color.Black;

                if (e.ColumnIndex == 0)
                {
                    if (dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value != null && dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value) == true)
                    //if (Convert.ToBoolean(dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value) == true)
                    {
                        dgvCustomerPaymentDetail.CurrentRow.Cells[1].ReadOnly = false;
                        dgvCustomerPaymentDetail.CurrentRow.Cells[1].Value = dgvCustomerPaymentDetail.CurrentRow.Cells[2].Value;
                    }
                    else
                    {
                        dgvCustomerPaymentDetail.CurrentRow.Cells[1].ReadOnly = true;
                        dgvCustomerPaymentDetail.CurrentRow.Cells[1].Value = "0.00";
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    if (dgvCustomerPaymentDetail.CurrentCell.Value == null)
                    {
                        return;
                    }

                    string str;
                    str = dgvCustomerPaymentDetail.CurrentCell.Value.ToString();
                    if (DataValidator.IsNumeric(dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString()))
                    {

                        if (dgvCustomerPaymentDetail.CurrentCell.Value.ToString().IndexOf(".") != -1)
                        {
                            str = str.Substring(0, str.IndexOf("."));
                            if (str.Length <= 12)
                            {
                                dgvCustomerPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString()));
                            }
                        }
                        else if (dgvCustomerPaymentDetail.CurrentCell.Value.ToString().Length <= 12)
                        {
                            dgvCustomerPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString()));
                        }
                        else
                        {
                            dgvCustomerPaymentDetail.CurrentCell.Value = str.Substring(0, 12);
                            dgvCustomerPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.Value.ToString()));
                        }
                        if (Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.Value) <= Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentRow.Cells["PendingAmount"].Value))
                        {
                            lblErrorMessage.Text = "No error";
                        }
                        else
                        {
                            dgvCustomerPaymentDetail.CurrentCell.Value = "0.00";
                            lblErrorMessage.Text = "Paid amount should be less than or equal to pending amount";
                        }
                    }
                    else
                    {
                        dgvCustomerPaymentDetail.CurrentCell.Value = "0.00";
                    }
                }

                if (e.ColumnIndex == 1)
                {
                    TotalAmount();
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvCustomerPaymentDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.Cancel = false;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvCustomerPaymentDetail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dgvCustomerPaymentDetail.RowCount == 1)
                    {
                        e.Handled = true;
                        return;
                    }
                }
                if (e.KeyCode == Keys.Escape)
                {
                    this.Dispose();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox Event"

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            if (_Mode != (int)Common.Constant.Mode.Insert)
            {
                return;
            }
            if (txtCustomerName.Text != "")
            {
                DataView dvCustomer = new DataView();
                dvCustomer = dtblCustomer.DefaultView;
                dvCustomer.RowFilter = "CustomerName='" + txtCustomerName.Text + "'";

                DataTable dtTempCustomer = new DataTable();
                dtTempCustomer = dvCustomer.ToTable();
                if (dtTempCustomer.Rows.Count > 0)
                {
                    lblErrorMessage.Text = "No error";
                    _CustomerID = Convert.ToInt64(dtTempCustomer.Rows[0]["CustomerID"].ToString());
                    txtCustomerName.Text = dtTempCustomer.Rows[0]["CustomerName"].ToString();
                    if (_CustomerID > 0)
                    {
                        LoadSIList();
                    }
                    else
                    {
                        dgvCustomerPaymentDetail.DataSource = null;
                    }
                    btnSaveContinue.Enabled = true;
                    btnSaveExit.Enabled = true;
                }
                else
                {
                    lblErrorMessage.Text = "Invalid customer name";
                    _CustomerID = 0;
                    txtCustomerName.Focus();
                    btnSaveContinue.Enabled = false;
                    btnSaveExit.Enabled = false;
                    dgvCustomerPaymentDetail.DataSource = null;
                }
            }
            else
            {
                _CustomerID = 0;
                lblErrorMessage.Text = "No error";
                btnSaveContinue.Enabled = true;
                btnSaveExit.Enabled = true;
                dgvCustomerPaymentDetail.DataSource = null;
            }

        }

        #endregion

        #region "Key press event"

        public void KeyPressed(object o, KeyPressEventArgs e)
        {
            try
            {
                if (dgvCustomerPaymentDetail.CurrentCell.ColumnIndex == 0)
                {
                    int ascii = e.KeyChar;
                    Validator.DataValidator.AllowOnlyCharacter(ascii, e);
                }
                if (dgvCustomerPaymentDetail.CurrentCell.ColumnIndex == 1 || dgvCustomerPaymentDetail.CurrentCell.ColumnIndex == 2)
                {
                    DataValidator.AllowOnlyNumeric(e, ".");
                }
                if (dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    switch (dgvCustomerPaymentDetail.CurrentCell.ColumnIndex)
                    {
                        case 1:
                            if (dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString().Length >= 9)
                            {
                                e.Handled = true;
                            }
                            break;
                        case 2:
                            if (dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString().Length >= 7)
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
                if (dgvCustomerPaymentDetail.CurrentCell.ColumnIndex == 0)
                {
                    var combo = o as DataGridViewComboBoxEditingControl;
                    combo.DroppedDown = true;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion
              

        private void dtpchequeDate_CloseUp(object sender, EventArgs e)
        {
            txtChequeDate.Text = dtpchequeDate.Value.ToString("dd/MM/yyyy");
        }
        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-");
        }

        private void dgvCustomerPaymentDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //try
            //{
            //    lblErrorMessage.Text = "No error";
            //    this.dgvCustomerPaymentDetail.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
            //    this.dgvCustomerPaymentDetail.CurrentCell.Style.SelectionForeColor = Color.Black;

            //    if (e.ColumnIndex == 0)
            //    {
            //        if (dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value != null && dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value) == true)
            //        //if (Convert.ToBoolean(dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value) == true)
            //        {
            //            dgvCustomerPaymentDetail.CurrentRow.Cells[1].ReadOnly = false;
            //            dgvCustomerPaymentDetail.CurrentRow.Cells[1].Value = dgvCustomerPaymentDetail.CurrentRow.Cells[2].Value;
            //        }
            //        else
            //        {
            //            dgvCustomerPaymentDetail.CurrentRow.Cells[1].ReadOnly = true;
            //            dgvCustomerPaymentDetail.CurrentRow.Cells[1].Value = "0.00";
            //        }
            //    }
            //    if (e.ColumnIndex == 1)
            //    {
            //        if (dgvCustomerPaymentDetail.CurrentCell.Value == null)
            //        {
            //            return;
            //        }

            //        string str;
            //        str = dgvCustomerPaymentDetail.CurrentCell.Value.ToString();
            //        if (DataValidator.IsNumeric(dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString()))
            //        {

            //            if (dgvCustomerPaymentDetail.CurrentCell.Value.ToString().IndexOf(".") != -1)
            //            {
            //                str = str.Substring(0, str.IndexOf("."));
            //                if (str.Length <= 12)
            //                {
            //                    dgvCustomerPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString()));
            //                }
            //            }
            //            else if (dgvCustomerPaymentDetail.CurrentCell.Value.ToString().Length <= 12)
            //            {
            //                dgvCustomerPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.EditedFormattedValue.ToString()));
            //            }
            //            else
            //            {
            //                dgvCustomerPaymentDetail.CurrentCell.Value = str.Substring(0, 12);
            //                dgvCustomerPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.Value.ToString()));
            //            }
            //            if (Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentCell.Value) <= Convert.ToDecimal(dgvCustomerPaymentDetail.CurrentRow.Cells["PendingAmount"].Value))
            //            {
            //                lblErrorMessage.Text = "No error";
            //            }
            //            else
            //            {
            //                dgvCustomerPaymentDetail.CurrentCell.Value = "0.00";
            //                lblErrorMessage.Text = "Paid amount should be less than or equal to pending amount";
            //            }
            //        }
            //        else
            //        {
            //            dgvCustomerPaymentDetail.CurrentCell.Value = "0.00";
            //        }
            //    }

            //    if (e.ColumnIndex == 1)
            //    {
            //        TotalAmount();
            //    }

            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Customer Payment - Entry", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void dgvCustomerPaymentDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomerPaymentDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCustomerPaymentDetail_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void dgvCustomerPaymentDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 0)
            //{
            //    bool isChecked = (Boolean)dgvCustomerPaymentDetail[0, e.RowIndex].FormattedValue;

            //    if (isChecked)
            //        // dgvCustomerPaymentDetail[1, e.RowIndex].Value = true;
            //        MessageBox.Show("checked");
            //}
        }

       
    }
}
