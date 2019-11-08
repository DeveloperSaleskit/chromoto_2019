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

namespace Account.GUI.VendorPayment
{

    public partial class frmVendorPaymentEntry : Account.GUIBase
    {

        #region "Variable Declaration..."

        CommonListBL objList = new CommonListBL();
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        VendorPaymentBL objVendorPaymentBL = new VendorPaymentBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtblVendor = new DataTable();
        DataTable dtblVendorPaymentDetail = new DataTable();

        DataGridViewComboBoxColumn clmItemName = new DataGridViewComboBoxColumn();
        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();

        int _Mode = 0;
        Int64 _VendorPaymentID = 0;
        Int64 _VendorID = 0;

        #endregion

        #region "Form load event"

        public frmVendorPaymentEntry(int Mode, long VendorPaymentID)
        {
            try
            {
                InitializeComponent();
                _VendorPaymentID = VendorPaymentID;
                _Mode = Mode;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void frmVendorPaymentEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvVendorPaymentDetail.StandardTab = false;
            LoadVendorList();
            objCommon.FillBankCombo(cmbbankName);
            objCommon.FillCurrencyCombo(cmbCurrency);
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                //DataValidator.SetDefaultDate(dtpDate, null, null);
                dtpDate.Value = DateTime.Now;
                dtpchequeDate.Value = DateTime.Now;
                dgvVendorPaymentDetail.ReadOnly = false;
                txtPaymentNo.Text = objCommon.AutoNumber("VPAY");

                this.Text = "Vendor Payment - New";

                //-----------------------------------------------
                int Currency_ID;
                DataTable dtCurrencyId = new DataTable();
                NameValueCollection ParaCurrency = new NameValueCollection();
                ParaCurrency.Add("@i_Currency", "Rs");
                dtCurrencyId = objList.ListOfRecord("usp_Select_CurrencyID", ParaCurrency, "Item Class - LoadList");
                if (dtCurrencyId.Rows.Count > 0)
                {
                    Currency_ID = Convert.ToInt32(dtCurrencyId.Rows[0][0].ToString());
                }
                else
                {
                    Currency_ID = 0;
                }
                cmbCurrency.SelectedValue = Currency_ID;
                cmbMode.SelectedItem = "Cash";
                if (cmbMode.SelectedItem.ToString() == "Cash")
                {
                    grpBankDetail.Enabled = false;
                }
                else
                {
                    grpBankDetail.Enabled = false;
                }
                //----------------------------------------------------
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                dgvVendorPaymentDetail.ReadOnly = false;

                this.Text = "Vendor Payment - Edit";
                BindControl();

                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "Vendor Payment - Delete";
                BindControl();

                SetReadOnlyControls(grpData);
                SetReadOnlyControls(grpDetail);
                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
                dgvVendorPaymentDetail.TabStop = false;
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

        private void LoadVendorList()
        {
            try
            {
                NameValueCollection para1 = new NameValueCollection();
                 para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblVendor = objList.ListOfRecord("usp_Vendor_LOV", para1, "Vendor Paymenting - LoadVendorList");
                if (objList.Exception == null)
                {
                    txtVendorName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtVendorName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtblVendor.Rows.Count; i++)
                    {
                        Data.Add(dtblVendor.Rows[i]["VendorName"].ToString());
                    }
                    txtVendorName.AutoCompleteCustomSource = Data;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void BindControl()
        {
            try
            {
                DataSet dsVendorPayment = new DataSet();
                NameValueCollection Paralist = new NameValueCollection();
                Paralist.Add("@i_RecID", _VendorPaymentID.ToString());
                dsVendorPayment = CommSelect.SelectDataSetRecord(Paralist, "usp_VendorPayment_Select", "Vendor Payment - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dsVendorPayment.Tables[0].Rows.Count > 0)
                        {
                            txtPaymentNo.Text = dsVendorPayment.Tables[0].Rows[0]["PaymentCode"].ToString();
                            dtpDate.Value = (DateTime)dsVendorPayment.Tables[0].Rows[0]["PaymentDate"];
                            _VendorID = Convert.ToInt32(dsVendorPayment.Tables[0].Rows[0]["VendorID"].ToString());
                            txtVendorName.Text = dsVendorPayment.Tables[0].Rows[0]["VendorName"].ToString();
                            txtTotalAmount.Text = dsVendorPayment.Tables[0].Rows[0]["NetAmount"].ToString();
                            txtNarration.Text = dsVendorPayment.Tables[0].Rows[0]["Narration"].ToString();
                            cmbbankName.Text = dsVendorPayment.Tables[0].Rows[0]["BankName"].ToString();
                            txtChequeNo.Text = dsVendorPayment.Tables[0].Rows[0]["ChequeNo"].ToString();
                            if (dsVendorPayment.Tables[0].Rows[0]["ChequeDate"].ToString() != null && dsVendorPayment.Tables[0].Rows[0]["ChequeDate"].ToString() != "")
                                txtChequeDate.Text = Convert.ToDateTime(dsVendorPayment.Tables[0].Rows[0]["ChequeDate"].ToString()).ToShortDateString();

                            //------------------
                            if (txtChequeNo.Text != "")
                            {
                                grpBankDetail.Enabled = true;
                                cmbMode.SelectedItem = "Cheque";
                            }
                            else
                            {
                                cmbMode.SelectedItem = "Cash";
                            }

                            txtbankName.Text = dsVendorPayment.Tables[0].Rows[0]["CustomerBankName"].ToString();
                            cmbCurrency.SelectedValue = Convert.ToInt64(dsVendorPayment.Tables[0].Rows[0]["CurrencyID"].ToString());

                            //---------------------


                            dgvVendorPaymentDetail.AutoGenerateColumns = false;
                            dgvVendorPaymentDetail.DataSource = dsVendorPayment.Tables[1];
                            dgvVendorPaymentDetail.Columns["PIID"].Visible = false;

                            dgvVendorPaymentDetail.Columns["Select"].DataPropertyName = dsVendorPayment.Tables[1].Columns["PayDetID"].ToString();
                            dgvVendorPaymentDetail.Columns["PaidAmount"].DataPropertyName = dsVendorPayment.Tables[1].Columns["PaidAmount"].ToString();
                            dgvVendorPaymentDetail.Columns["PendingAmount"].DataPropertyName = dsVendorPayment.Tables[1].Columns["PendingAmount"].ToString();
                            dgvVendorPaymentDetail.Columns["PurchaseInvoice"].DataPropertyName = dsVendorPayment.Tables[1].Columns["PurchaseCode"].ToString();
                            dgvVendorPaymentDetail.Columns["PIID"].DataPropertyName = dsVendorPayment.Tables[1].Columns["PIID"].ToString();
                            dgvVendorPaymentDetail.Columns["PurchaseDate"].DataPropertyName = dsVendorPayment.Tables[1].Columns["PurchaseDate"].ToString();

                            for (int i = 0; i < dgvVendorPaymentDetail.Columns.Count; i++)
                            {
                                dgvVendorPaymentDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            //for (int i = 0; i < dgvVendorPaymentDetail.Rows.Count; i++)
                            //{
                            for (int j = 0; j < dsVendorPayment.Tables[1].Rows.Count; j++)
                            {
                                //if (Convert.ToInt64(dgvVendorPaymentDetail.Rows[i].Cells["Select"].Value) == Convert.ToInt64(dsVendorPayment.Tables[1].Rows[j]["PayDetID"]))
                                if (Convert.ToInt64(dsVendorPayment.Tables[1].Rows[j]["PayDetID"]) > 0)
                                {
                                    dgvVendorPaymentDetail.Rows[j].Cells["Select"].Value = true;
                                    if (_Mode == (int)Common.Constant.Mode.Modify)
                                    {
                                        dgvVendorPaymentDetail.Columns["PaidAmount"].ReadOnly = false;
                                    }
                                }
                                else
                                {
                                    dgvVendorPaymentDetail.Columns["PaidAmount"].ReadOnly = true;
                                }
                            }
                            // }

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
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - BindControl", exc.StackTrace);
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
                    CommDelRec.DeleteRecordWithBank(_VendorPaymentID, cmbbankName.Text, "usp_VendorPayment_Delete", "Vendor Payment - Delete");
                    //CommDelRec.DeleteRecordWithBank(_VendorPaymentID, cmbbankName.Text, "usp_VendorPayment_Delete", "Vendor Payment - Delete");
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

                        dgvVendorPaymentDetail.EndEdit();

                        for (int i = 0; i < dgvVendorPaymentDetail.RowCount; i++)
                        {
                            if (dgvVendorPaymentDetail.Rows[i].Cells[0].Value != null && dgvVendorPaymentDetail.Rows[i].Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvVendorPaymentDetail.Rows[i].Cells[0].Value) == true)
                            {
                                if (dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value == null || dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString() == "" || Convert.ToDecimal(dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value) <= 0)
                                {
                                    lblErrorMessage.Text = "Enter paid amount";
                                    dgvVendorPaymentDetail.CurrentCell = dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"];
                                    dgvVendorPaymentDetail.BeginEdit(true);
                                    ReturnValue = false;
                                    return false;
                                }
                            }
                        }

                        bool IsValid = false;
                        if (cmbMode.SelectedItem.ToString() == "Cheque")
                        {
                            if (txtChequeNo.Text == "" || txtChequeDate.Text == "" || txtbankName.Text == "" || Convert.ToInt32(cmbbankName.SelectedValue) == 0)
                            {
                                IsValid = false;
                            }
                            else
                            {
                                IsValid = true;
                            }
                        }
                        else
                        {
                            IsValid = true;
                        }

                        if (IsValid == true)
                        {

                            int Cnt = 0;
                            string XMLString = string.Empty;
                            XMLString = "<NewDataSet>";
                            for (int i = 0; i < dgvVendorPaymentDetail.Rows.Count; i++)
                            {
                                if (dgvVendorPaymentDetail.Rows[i].Cells[0].Value != null && dgvVendorPaymentDetail.Rows[i].Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvVendorPaymentDetail.Rows[i].Cells[0].Value) == true)
                                //if (Convert.ToBoolean(dgvVendorPaymentDetail.Rows[i].Cells["Select"].Value) == true)
                                {
                                    XMLString = XMLString + "<Table>";
                                    XMLString = XMLString + "<PIID>" + dgvVendorPaymentDetail.Rows[i].Cells["PIID"].Value + "</PIID>";
                                    XMLString = XMLString + "<PaidAmount>" + dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value + "</PaidAmount>";
                                    XMLString = XMLString + "</Table> ";
                                    Cnt++;
                                }
                            }
                            XMLString = XMLString + "</NewDataSet>";

                            //  Cnt = dgvVendorPaymentDetail.Rows.Count;

                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                objVendorPaymentBL.Insert(cmbMode.Text, txtPaymentNo.Text, dtpDate.Value, _VendorID, Convert.ToDecimal(txtTotalAmount.Text), txtNarration.Text, XMLString, Cnt, txtbankName.Text, cmbbankName.Text, txtChequeNo.Text, txtChequeDate.Text, Convert.ToInt64(cmbCurrency.SelectedValue));
                            }
                            else if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                objVendorPaymentBL.Update(cmbMode.Text, _VendorPaymentID, txtPaymentNo.Text, dtpDate.Value, _VendorID, Convert.ToDecimal(txtTotalAmount.Text), txtNarration.Text, XMLString, Cnt, txtbankName.Text, cmbbankName.Text, txtChequeNo.Text, txtChequeDate.Text, Convert.ToInt64(cmbCurrency.SelectedValue));
                            }

                            if (objVendorPaymentBL.Exception == null)
                            {
                                if (objVendorPaymentBL.ErrorMessage != "")
                                {
                                    lblErrorMessage.Text = objVendorPaymentBL.ErrorMessage;
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
                                MessageBox.Show(objVendorPaymentBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up all Bank details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grpBankDetail.Focus();

                            lblErrorMessage.Text = "Please fill up all Bank details";
                            grpBankDetail.Focus();
                            ReturnValue = false;
                        }
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - SetSave", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        public void TotalAmount()
        {
            decimal TotalAmount = 0;

            for (int i = 0; i < dgvVendorPaymentDetail.Rows.Count; i++)
            {
                if (dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString() != System.DBNull.Value.ToString())
                {
                    TotalAmount = TotalAmount + Convert.ToDecimal(dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString());
                }
            }
            txtTotalAmount.Text = TotalAmount.ToString("0.00");

        }

        public void LoadPIList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                CommonListBL objList = new CommonListBL();

                para.Add("@i_VendorID", _VendorID.ToString());

                dtblVendorPaymentDetail = objList.ListOfRecord("usp_VendorPayment_PendingPI_List", para, "Vendor Payemnt- LoadPIList");
                if (objList.Exception == null)
                {
                    dgvVendorPaymentDetail.AutoGenerateColumns = false;
                    dgvVendorPaymentDetail.DataSource = dtblVendorPaymentDetail;

                    if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        dgvVendorPaymentDetail.Columns["Select"].DataPropertyName = dtblVendorPaymentDetail.Columns["RecDetID"].ToString();
                    }
                    dgvVendorPaymentDetail.Columns["PaidAmount"].DataPropertyName = dtblVendorPaymentDetail.Columns["PaidAmount"].ToString();
                    dgvVendorPaymentDetail.Columns["PendingAmount"].DataPropertyName = dtblVendorPaymentDetail.Columns["PendingAmount"].ToString();
                    dgvVendorPaymentDetail.Columns["PurchaseInvoice"].DataPropertyName = dtblVendorPaymentDetail.Columns["PurchaseCode"].ToString();
                    dgvVendorPaymentDetail.Columns["PIID"].DataPropertyName = dtblVendorPaymentDetail.Columns["PIID"].ToString();
                    dgvVendorPaymentDetail.Columns["PurchaseDate"].DataPropertyName = dtblVendorPaymentDetail.Columns["PurchaseDate"].ToString();

                    for (int i = 0; i < dgvVendorPaymentDetail.Columns.Count; i++)
                    {
                        dgvVendorPaymentDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dgvVendorPaymentDetail.Columns["PaidAmount"].ReadOnly = true;
                    }

                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("VendorPayment - LoadPIList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button events"

        private void btnVendorLOV_Click(object sender, EventArgs e)
        {
            frmVendorLOV fLOV = new frmVendorLOV();
            fLOV.ShowDialog();
            txtVendorName.Text = fLOV.VendorName;
            _VendorID = fLOV.VendorID;
            if (_VendorID > 0)
            {
                LoadPIList();
            }
            else
            {
                dgvVendorPaymentDetail.DataSource = null;
            }
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtPaymentNo.Text = objCommon.AutoNumber("VPAY");
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtPaymentNo.Text = objCommon.AutoNumber("VPAY");
                dtpDate.Value = DateTime.Now;
                txtNarration.Text = "";
                txtVendorName.Text = "";
                txtTotalAmount.Text = "0.00";
                dgvVendorPaymentDetail.DataSource = null;
                //dgvVendorPaymentDetail.Columns.Clear();
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

        private void dgvVendorPaymentDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvVendorPaymentDetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvVendorPaymentDetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - New", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvVendorPaymentDetail_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvVendorPaymentDetail.CurrentRow != null)
                {
                    this.dgvVendorPaymentDetail.CurrentCell.Style.SelectionBackColor = Color.White;
                    this.dgvVendorPaymentDetail.CurrentCell.Style.SelectionForeColor = Color.Black;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvVendorPaymentDetail_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                dgvVendorPaymentDetail.EndEdit();
                lblErrorMessage.Text = "No error";
                this.dgvVendorPaymentDetail.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                this.dgvVendorPaymentDetail.CurrentCell.Style.SelectionForeColor = Color.Black;

                if (e.ColumnIndex == 0)
                {
                    if (dgvVendorPaymentDetail.CurrentRow.Cells[0].Value != null && dgvVendorPaymentDetail.CurrentRow.Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvVendorPaymentDetail.CurrentRow.Cells[0].Value) == true)
                    {
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].ReadOnly = false;
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].Value = dgvVendorPaymentDetail.CurrentRow.Cells[2].Value;
                    }
                    else
                    {
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].ReadOnly = true;
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].Value = "0.000";
                    }
                }
                if (e.ColumnIndex == 1)
                {
                    if (dgvVendorPaymentDetail.CurrentCell.Value == null)
                    {
                        return;
                    }

                    string str;
                    str = dgvVendorPaymentDetail.CurrentCell.Value.ToString();
                    if (DataValidator.IsNumeric(dgvVendorPaymentDetail.CurrentCell.EditedFormattedValue.ToString()))
                    {

                        if (dgvVendorPaymentDetail.CurrentCell.Value.ToString().IndexOf(".") != -1)
                        {
                            str = str.Substring(0, str.IndexOf("."));
                            if (str.Length <= 12)
                            {
                                dgvVendorPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvVendorPaymentDetail.CurrentCell.EditedFormattedValue.ToString()));
                            }
                        }
                        else if (dgvVendorPaymentDetail.CurrentCell.Value.ToString().Length <= 12)
                        {
                            dgvVendorPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvVendorPaymentDetail.CurrentCell.EditedFormattedValue.ToString()));
                        }
                        else
                        {
                            dgvVendorPaymentDetail.CurrentCell.Value = str.Substring(0, 12);
                            dgvVendorPaymentDetail.CurrentCell.Value = String.Format("{0:0.00}", Convert.ToDecimal(dgvVendorPaymentDetail.CurrentCell.Value.ToString()));
                        }
                        if (Convert.ToDecimal(dgvVendorPaymentDetail.CurrentCell.Value) <= Convert.ToDecimal(dgvVendorPaymentDetail.CurrentRow.Cells["PendingAmount"].Value))
                        {
                            lblErrorMessage.Text = "No error";
                        }
                        else
                        {
                            dgvVendorPaymentDetail.CurrentCell.Value = "0.00";
                            lblErrorMessage.Text = "Paid amount should be less than or equal to pending amount";
                        }
                    }
                    else
                    {
                        dgvVendorPaymentDetail.CurrentCell.Value = "0.00";
                    }
                }

                if (e.ColumnIndex == 1)
                {
                    TotalAmount();
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvVendorPaymentDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.Cancel = false;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvVendorPaymentDetail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (dgvVendorPaymentDetail.RowCount == 1)
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
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox Event"

        private void txtVendorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtVendorName_Leave(object sender, EventArgs e)
        {

            if (txtVendorName.Text != "")
            {
                DataView dvVendor = new DataView();
                dvVendor = dtblVendor.DefaultView;
                dvVendor.RowFilter = "VendorName='" + txtVendorName.Text + "'";

                DataTable dtTempVendor = new DataTable();
                dtTempVendor = dvVendor.ToTable();
                if (dtTempVendor.Rows.Count > 0)
                {
                    lblErrorMessage.Text = "No error";
                    _VendorID = Convert.ToInt64(dtTempVendor.Rows[0]["VendorID"].ToString());
                    txtVendorName.Text = dtTempVendor.Rows[0]["VendorName"].ToString();
                    if (_VendorID > 0)
                    {
                        LoadPIList();
                    }
                    else
                    {
                        dgvVendorPaymentDetail.DataSource = null;
                    }
                    btnSaveContinue.Enabled = true;
                    btnSaveExit.Enabled = true;
                }
                else
                {
                    lblErrorMessage.Text = "Invalid customer name";
                    _VendorID = 0;
                    txtVendorName.Focus();
                    btnSaveContinue.Enabled = false;
                    btnSaveExit.Enabled = false;
                    dgvVendorPaymentDetail.DataSource = null;
                }
            }
            else
            {
                _VendorID = 0;
                lblErrorMessage.Text = "No error";
                btnSaveContinue.Enabled = true;
                btnSaveExit.Enabled = true;
                dgvVendorPaymentDetail.DataSource = null;
            }

        }

        #endregion

        #region "Key press event"

        public void KeyPressed(object o, KeyPressEventArgs e)
        {
            try
            {
                if (dgvVendorPaymentDetail.CurrentCell.ColumnIndex == 0)
                {
                    int ascii = e.KeyChar;
                    //                    Validator.DataValidator.AllowOnlyCharacter(ascii, e);
                }
                if (dgvVendorPaymentDetail.CurrentCell.ColumnIndex == 1 || dgvVendorPaymentDetail.CurrentCell.ColumnIndex == 2)
                {
                    DataValidator.AllowOnlyNumeric(e, ".");
                }
                if (dgvVendorPaymentDetail.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    switch (dgvVendorPaymentDetail.CurrentCell.ColumnIndex)
                    {
                        case 1:
                            if (dgvVendorPaymentDetail.CurrentCell.EditedFormattedValue.ToString().Length >= 9)
                            {
                                e.Handled = true;
                            }
                            break;
                        case 2:
                            if (dgvVendorPaymentDetail.CurrentCell.EditedFormattedValue.ToString().Length >= 7)
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
                if (dgvVendorPaymentDetail.CurrentCell.ColumnIndex == 0)
                {
                    var combo = o as DataGridViewComboBoxEditingControl;
                    combo.DroppedDown = true;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void dtpchequeDate_CloseUp(object sender, EventArgs e)
        {
            txtChequeDate.Text = dtpchequeDate.Value.ToString("dd/MM/yyyy");
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMode.SelectedItem.ToString() == "Cash")
            {
                grpBankDetail.Enabled = false;
            }
            else
            {
                grpBankDetail.Enabled = true;
            }
        }

    }
}
