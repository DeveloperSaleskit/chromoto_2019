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

namespace Account.GUI.VendorPaymentReturn
{

    public partial class frmVendorPaymentReturnEntry : Account.GUIBase
    {

        #region "Variable Declaration..."

        CommonListBL objList = new CommonListBL();
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        VendorPaymentReturnBL objCustomerPaymentBL = new VendorPaymentReturnBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtblCustomer = new DataTable();
        DataTable dtblCustomerPaymentDetail = new DataTable();

        DataGridViewComboBoxColumn clmItemName = new DataGridViewComboBoxColumn();
        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();

        int _Mode = 0;
        Int64 _CustomerPaymentID = 0;
        Int64 _VendorID = 0;
        Int64 _AccountID = 0;
        int CompId = 0;
        int _CompId = 0;
        Int64 _UserID = 0;

        DateTimePicker oDateTimePicker;
        bool IsCustomer;

        #endregion

        #region "Form load event"

        public frmVendorPaymentReturnEntry(int Mode, long CustomerPaymentID)
        {
            try
            {
                InitializeComponent();
                _CustomerPaymentID = CustomerPaymentID;
                _Mode = Mode;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void frmCustomerPaymentEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
          
            dgvVendorPaymentDetail.StandardTab = false;
            objCommon.FillBankCombo(cmbbankName);
            objCommon.FillCurrencyCombo(cmbCurrency);
            LoadCustomerList();

            //DateTimePicker dp = new DateTimePicker();
            //dgvCustomerPaymentDetail.Controls.Add(dp);

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                //DataValidator.SetDefaultDate(dtpDate, null, null);
                dtpchequeDate.Value = DateTime.Now;
                dtpDate.Value = DateTime.Now;

                dgvVendorPaymentDetail.ReadOnly = false;
                txtReceiptNo.Text = objCommon.AutoNumber("VRTN");

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
                btnCustomerLOV.Enabled = false;
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

        private void LoadCustomerList()
        {
            try
            {
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblCustomer = objList.ListOfRecord("usp_Vendor_LOV", para1, "Vendor Paymenting - LoadCustomerList");
                if (objList.Exception == null)
                {
                    txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtblCustomer.Rows.Count; i++)
                    {
                        Data.Add(dtblCustomer.Rows[i]["VendorName"].ToString());
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
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
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
                dsCustomerPayment = CommSelect.SelectDataSetRecord(Paralist, "usp_VendorPaymentReturn_Select", "Vendor Payment - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dsCustomerPayment.Tables[0].Rows.Count > 0)
                        {
                            txtReceiptNo.Text = dsCustomerPayment.Tables[0].Rows[0]["PaymentReturnCode"].ToString();
                            dtpDate.Value = (DateTime)dsCustomerPayment.Tables[0].Rows[0]["PaymentReturnDate"];
                            _VendorID = Convert.ToInt32(dsCustomerPayment.Tables[0].Rows[0]["VendorID"].ToString());
                            txtCustomerName.Text = dsCustomerPayment.Tables[0].Rows[0]["Name"].ToString();
                            txtTotalAmount.Text = dsCustomerPayment.Tables[0].Rows[0]["NetAmount"].ToString();
                            txtNarration.Text = dsCustomerPayment.Tables[0].Rows[0]["Narration"].ToString();
                            cmbbankName.Text = dsCustomerPayment.Tables[0].Rows[0]["BankName"].ToString();
                            txtChequeNo.Text = dsCustomerPayment.Tables[0].Rows[0]["ChequeNo"].ToString();
                            if (dsCustomerPayment.Tables[0].Rows[0]["ChequeDate"].ToString() != null && dsCustomerPayment.Tables[0].Rows[0]["ChequeDate"].ToString() != "")
                            txtChequeDate.Text = Convert.ToDateTime(dsCustomerPayment.Tables[0].Rows[0]["ChequeDate"].ToString()).ToShortDateString();

                            if (txtChequeNo.Text != "")
                            {
                                grpBankDetail.Enabled = true;
                                cmbMode.SelectedItem = "Cheque";
                            }
                            else
                            {
                                cmbMode.SelectedItem = "Cash";
                            }


                            if (dsCustomerPayment.Tables[0].Rows[0]["IsCustomer"].ToString() == "True")
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }
                            txtCustomerbankName.Text = dsCustomerPayment.Tables[0].Rows[0]["VendorBankName"].ToString();
                            cmbCurrency.SelectedValue = Convert.ToInt64(dsCustomerPayment.Tables[0].Rows[0]["CurrencyID"].ToString());

                            dgvVendorPaymentDetail.AutoGenerateColumns = false;
                            dgvVendorPaymentDetail.DataSource = dsCustomerPayment.Tables[1];
                            dgvVendorPaymentDetail.Columns["DNID"].Visible = false;

                            dgvVendorPaymentDetail.Columns["Select"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["RecDetID"].ToString();
                            dgvVendorPaymentDetail.Columns["PaidAmount"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["PaidAmount"].ToString();
                            dgvVendorPaymentDetail.Columns["PendingAmount"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["PaidAmount"].ToString();

                            //dgvCustomerPaymentDetail.Columns["SecurityDeposite"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["SecurityDeposite"].ToString();
                            //dgvCustomerPaymentDetail.Columns["ReminderDate"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["ReminderDate"].ToString();

                            //dgvVendorPaymentDetail.Columns["DebitNote"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["DNNumber"].ToString();
                            //dgvVendorPaymentDetail.Columns["DNID"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["DNID"].ToString();
                            //dgvVendorPaymentDetail.Columns["DNDate"].DataPropertyName = dsCustomerPayment.Tables[1].Columns["DNDate"].ToString();

                            for (int i = 0; i < dgvVendorPaymentDetail.Columns.Count; i++)
                            {
                                dgvVendorPaymentDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                            }

                            //for (int i = 0; i < dgvCustomerPaymentDetail.Rows.Count; i++)
                            //{
                            for (int j = 0; j < dsCustomerPayment.Tables[1].Rows.Count; j++)
                            {
                                //  if (Convert.ToInt64(dgvCustomerPaymentDetail.Rows[i].Cells["Select"].Value) == Convert.ToInt64(dsCustomerPayment.Tables[1].Rows[j]["RecDetID"]))
                                if (Convert.ToInt64(dsCustomerPayment.Tables[1].Rows[j]["RecDetID"]) > 0)
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

                    //CommDelRec.DeleteRecord(_CustomerPaymentID, "usp_CustomerReceipt_Delete", "Vendor Payment - Delete");
                    CommDelRec.DeleteRecordWithBank(_CustomerPaymentID, cmbbankName.Text, "usp_VendorPaymentReturn_Delete", "Vendor Payment - Delete");

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
                        bool IsValid = false;
                        if (cmbMode.SelectedItem.ToString() == "Cheque")
                        {
                            if (txtChequeNo.Text == "" || txtChequeDate.Text == "" || txtCustomerbankName.Text == "" || Convert.ToInt32(cmbbankName.SelectedValue) == 0)
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
                            dgvVendorPaymentDetail.EndEdit();

                            for (int i = 0; i < dgvVendorPaymentDetail.RowCount; i++)
                            {
                                if (dgvVendorPaymentDetail.Rows[i].Cells[0].Value != null && dgvVendorPaymentDetail.Rows[i].Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvVendorPaymentDetail.Rows[i].Cells[0].Value) == true)
                                //if (Convert.ToBoolean(dgvCustomerPaymentDetail.Rows[i].Cells["Select"].Value) == true)
                                {
                                    if (dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value == null || dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value.ToString() == "" || Convert.ToDecimal(dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value) <= 0)
                                    {
                                        lblErrorMessage.Text = "Enter paid amount";
                                        dgvVendorPaymentDetail.CurrentCell = dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"];
                                        dgvVendorPaymentDetail.BeginEdit(true); ReturnValue = false;
                                        return false;
                                    }
                                }
                            }


                            int Cnt = 0;
                            string XMLString = string.Empty;
                            XMLString = "<NewDataSet>";
                            for (int i = 0; i < dgvVendorPaymentDetail.Rows.Count; i++)
                            {
                                //if (dgvCustomerPaymentDetail.Rows[i].Cells["SecurityDeposite"].Value == null)
                                //{
                                //    dgvCustomerPaymentDetail.Rows[i].Cells["SecurityDeposite"].Value = 0;
                                //}
                                //if (dgvCustomerPaymentDetail.Rows[i].Cells["ReminderDate"].Value == null)
                                //{
                                //    dgvCustomerPaymentDetail.Rows[i].Cells["ReminderDate"].Value = DateTime.Now;
                                //}

                                if (dgvVendorPaymentDetail.Rows[i].Cells[0].Value != null && dgvVendorPaymentDetail.Rows[i].Cells[0].Value.ToString() != ""
                                    && Convert.ToBoolean(dgvVendorPaymentDetail.Rows[i].Cells[0].Value) == true)
                                {
                                    XMLString = XMLString + "<Table>";
                                    XMLString = XMLString + "<DNID>" + dgvVendorPaymentDetail.Rows[i].Cells["DNID"].Value + "</DNID>";
                                    XMLString = XMLString + "<PaidAmount>" + dgvVendorPaymentDetail.Rows[i].Cells["PaidAmount"].Value + "</PaidAmount>";
                                    //XMLString = XMLString + "<SecurityDeposite>" + dgvCustomerPaymentDetail.Rows[i].Cells["SecurityDeposite"].Value + "</SecurityDeposite>";
                                    //XMLString = XMLString + "<ReminderDate>" + Convert.ToDateTime(dgvCustomerPaymentDetail.Rows[i].Cells["ReminderDate"].Value).ToString("MM/dd/yyyy") + "</ReminderDate>";
                                    XMLString = XMLString + "</Table> ";
                                    Cnt++;
                                }
                            }
                            XMLString = XMLString + "</NewDataSet>";

                            //Cnt = dgvCustomerPaymentDetail.Rows.Count ;

                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                objCustomerPaymentBL.Insert(txtReceiptNo.Text, dtpDate.Value, _VendorID, Convert.ToDecimal(txtTotalAmount.Text),
                                    txtNarration.Text, txtCustomerbankName.Text, cmbbankName.Text, txtChequeNo.Text, txtChequeDate.Text, XMLString, Cnt, CompId, _AccountID, IsCustomer, Convert.ToInt64(cmbCurrency.SelectedValue));
                            }
                            else if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                objCustomerPaymentBL.Update(_CustomerPaymentID, txtReceiptNo.Text, dtpDate.Value, _VendorID,
                                    Convert.ToDecimal(txtTotalAmount.Text), txtNarration.Text, txtCustomerbankName.Text, cmbbankName.Text, txtChequeNo.Text,
                                    txtChequeDate.Text, XMLString, Cnt, CompId, _AccountID, IsCustomer, Convert.ToInt64(cmbCurrency.SelectedValue));
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
                        else
                        {
                            MessageBox.Show("Please fill up all Bank details","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
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

        public void LoadSIList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                CommonListBL objList = new CommonListBL();

                para.Add("@i_VendorID", _VendorID.ToString());

                dtblCustomerPaymentDetail = objList.ListOfRecord("usp_VendorPaymentReturn_PendingSI_List", para, "Vendor Payment Return- LoadSIList");
                if (objList.Exception == null)
                {
                    dgvVendorPaymentDetail.AutoGenerateColumns = false;
                    dgvVendorPaymentDetail.DataSource = dtblCustomerPaymentDetail;

                    if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        dgvVendorPaymentDetail.Columns["Select"].DataPropertyName = dtblCustomerPaymentDetail.Columns["PayDetID"].ToString();
                    }
                    dgvVendorPaymentDetail.Columns["PaidAmount"].DataPropertyName = dtblCustomerPaymentDetail.Columns["PaidAmount"].ToString();
                    dgvVendorPaymentDetail.Columns["PendingAmount"].DataPropertyName = dtblCustomerPaymentDetail.Columns["PendingAmount"].ToString();
                    //dgvVendorPaymentDetail.Columns["DebitNote"].DataPropertyName = dtblCustomerPaymentDetail.Columns["DNNumber"].ToString();
                    //dgvVendorPaymentDetail.Columns["DNID"].DataPropertyName = dtblCustomerPaymentDetail.Columns["DNID"].ToString();
                    //dgvVendorPaymentDetail.Columns["DNDate"].DataPropertyName = dtblCustomerPaymentDetail.Columns["DNDate"].ToString();
                    //dgvCustomerPaymentDetail.Columns["ReminderDate"].DataPropertyName = dtblCustomerPaymentDetail.Columns["ReminderDate"].ToString();
                    //dgvCustomerPaymentDetail.Columns["SecurityDeposite"].DataPropertyName = dtblCustomerPaymentDetail.Columns["SecurityDeposite"].ToString();

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
                Utill.Common.ExceptionLogger.writeException("VendorPayment - LoadSIList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button events"

        private void btnCustomerLOV_Click(object sender, EventArgs e)
        {

            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());


            frmVendorReturnLOV fLOV = new frmVendorReturnLOV(CurrentCompany.CompId, "usp_Vendor_LOV_PaymentReturn", para1);
            fLOV.isFromCustomerPayment = true;
            fLOV.ShowDialog();
            txtCustomerName.Text = fLOV.VendorName;

            //IsCustomer = fLOV.IsCustomer;

            _VendorID = fLOV.VendorID;
            //_AccountID = fLOV.AccountID;
            if (_VendorID > 0)
            {
                LoadSIList();
            }
            else
            {
                dgvVendorPaymentDetail.DataSource = null;
            }
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtReceiptNo.Text = objCommon.AutoNumber("VRTN");
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtReceiptNo.Text = objCommon.AutoNumber("VRTN");
                dtpDate.Value = DateTime.Now;
                txtNarration.Text = "";
                txtCustomerName.Text = "";
                txtTotalAmount.Text = "0.00";
                txtCustomerbankName.Text = "";
                txtChequeDate.Text = "";
                txtChequeNo.Text = "";
                dtpchequeDate.Value = DateTime.Now;
                dgvVendorPaymentDetail.DataSource = null;
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

        private void dgvCustomerPaymentDetail_CurrentCellChanged(object sender, EventArgs e)
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

        private void dgvCustomerPaymentDetail_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                lblErrorMessage.Text = "No error";
                this.dgvVendorPaymentDetail.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                this.dgvVendorPaymentDetail.CurrentCell.Style.SelectionForeColor = Color.Black;

                if (e.ColumnIndex == 0)
                {
                    if (dgvVendorPaymentDetail.CurrentRow.Cells[0].Value != null && dgvVendorPaymentDetail.CurrentRow.Cells[0].Value.ToString() != "" && Convert.ToBoolean(dgvVendorPaymentDetail.CurrentRow.Cells[0].Value) == true)
                    //if (Convert.ToBoolean(dgvCustomerPaymentDetail.CurrentRow.Cells[0].Value) == true)
                    {
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].ReadOnly = false;
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].Value = dgvVendorPaymentDetail.CurrentRow.Cells[2].Value;

                        //for (int i = 0; i < dgvCustomerPaymentDetail.Columns.Count; i++)
                        //{
                        //    if (i != 1)
                        //    {
                        //        dgvCustomerPaymentDetail.CurrentRow.Cells[i].ReadOnly = true;
                        //    }                           
                        //}
                    }
                    else
                    {
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].ReadOnly = true;
                        dgvVendorPaymentDetail.CurrentRow.Cells[1].Value = "0.00";
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

        private void dgvCustomerPaymentDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void dgvCustomerPaymentDetail_KeyDown(object sender, KeyEventArgs e)
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
                    _VendorID = Convert.ToInt64(dtTempCustomer.Rows[0]["VendorID"].ToString());
                    txtCustomerName.Text = dtTempCustomer.Rows[0]["CustomerName"].ToString();

                    if (dtTempCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                    {
                        IsCustomer = true;
                    }
                    else
                    {
                        IsCustomer = false;
                    }
                    
                    if (_VendorID > 0)
                    {
                        LoadSIList();
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
                    lblErrorMessage.Text = "Invalid Vendor name";
                    _VendorID = 0;
                    txtCustomerName.Focus();
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
            //    Utill.Common.ExceptionLogger.writeException("Vendor Payment - Entry", exc.StackTrace);
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

        private void dgvCustomerPaymentDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column
            if (e.ColumnIndex == 4)
            {
                oDateTimePicker = new DateTimePicker();  //DateTimePicker  

                //Adding DateTimePicker control into DataGridView 
                dgvVendorPaymentDetail.Controls.Add(oDateTimePicker);

                // Intially made it invisible
                oDateTimePicker.Visible = false;

                // Setting the format (i.e. 2014-10-10)
                oDateTimePicker.Format = DateTimePickerFormat.Short;  //
                //oDateTimePicker.CustomFormat = "MM/dd/yyyy";
                oDateTimePicker.TextChanged += new EventHandler(oDateTimePicker_TextChanged);

                // Now make it visible
                oDateTimePicker.Visible = true;

                // It returns the retangular area that represents the Display area for a cell
                Rectangle oRectangle = dgvVendorPaymentDetail.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
            }
            else
            { 
                
            }
        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
        }

        void oDateTimePicker_TextChanged(object sender, EventArgs e)
        {
            dgvVendorPaymentDetail.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
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
                        _VendorID = Convert.ToInt64(dtTempCustomer.Rows[0]["VendorID"].ToString());
                        txtCustomerName.Text = dtTempCustomer.Rows[0]["CustomerName"].ToString();
                        if (_VendorID > 0)
                        {
                            LoadSIList();
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
                        lblErrorMessage.Text = "Invalid Vendor name";
                        _VendorID = 0;
                        txtCustomerName.Focus();
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

        private void dtpchequeDate_ValueChanged(object sender, EventArgs e)
        {

        }

     

       
    }
}
