/*----------------------------------------------------------------------------------
' Module Name:  Puchase Order 
' Created By:   Hetal Patel 
' Created Date: 20-09-2010
' Description:  This form is used to Add Purchase Invoice
'               Generate Purchase Invoice button is used to save data and then close the form.
'               Close button is used to close the form.
' Module Change History:
'    Date        Changed By    Description
'----------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.BusinessLogic;
using Account.Common;
using Account.Validator;
using System.Collections.Specialized;
namespace Account.GUI.Indent
{
    public partial class frmIndentEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelete = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        PurchaseInvoiceBL objPOBL = new PurchaseInvoiceBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtVendor = new DataTable();
        DataTable dtPIDetail = new DataTable();
        Int64 _VendorID = 0;
        long _PIID = 0;
        long _PIDetailID = 0;
        int _Mode = 0;
        long PGID = 0;
        bool _LatestGRN;
        Boolean AginstCForm = false;
        #endregion
        int editlov = 0;
        #region "Form Events...."

        public frmIndentEntry(int Mode, Int64 PIID, bool LatestGRN)
        {
            InitializeComponent();
            _Mode = Mode;
            _PIID = PIID;
            _LatestGRN = LatestGRN;
        }

        private void frmPurchaseInvoiceEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            //DataValidator.SetDefaultDate(dtpPIDate, null, null);
            dgvPIDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            objCommon.FillGodownCombo(cmbgodown);
            objCommon.FillBankCombo(cmbbankName);
            cmbAgainstDN.Text = "Direct GRN";
            //---default direct GRN--------
            groupBox1.Height = 250;
            dgvPIDetail.Height = 205;

            grpBankDetail.Enabled = false;
            cmbMode.Enabled = false;
            cmbgodown.SelectedValue = 1;


            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                LoadVendorList();
                LoadPIDetailList();
                dtpchequeDate.Value = DateTime.Now;
                dtpDueDate.Value = DateTime.Now;
                dtpPIDate.Value = DateTime.Now;
                dtpVoucherDate.Value = DateTime.Now;


                txtPINo.Text = objCommon.AutoNumber("GRN");
                this.Text = "GRN - New";

                cmbMode.SelectedItem = "Cash";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                if (_LatestGRN == true)
                {
                    grpData.Enabled = true;
                }
                else
                {
                    grpData.Enabled = false;
                }
                ErrItemName.Visible = false;
                BindControl();
                btnGeneratePI.Text = "Save";
                btnVendorLOV.Visible = false;
                txtVendor.ReadOnly = true;
                this.Text = "GRN - Edit";
                btnRegenrate.Visible = false;
                btnGeneratePI.Width = btnCancel.Width;
                btnGeneratePI.Location = new Point(btnGeneratePI.Location.X + 95, btnGeneratePI.Location.Y);
                cmbAgainstDN.Enabled = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                btnRegenrate.Visible = false;
                BindControl();
                btnVendorLOV.Visible = false;
                txtVendor.ReadOnly = true;
                lblDelMsg.Visible = true;
                btnNew.Visible = false;
                btnDelete.Visible = false;
                SetReadOnlyControls(grpData);
                btnGeneratePI.Text = "Yes";
                btnGeneratePI.Tag = "Click to delete record;";
                btnGeneratePI.Width = btnCancel.Width;
                btnGeneratePI.Location = new Point(btnGeneratePI.Location.X + 95, btnGeneratePI.Location.Y);
                btnCancel.Text = "No";
                this.Text = "GRN - Delete";
                cmbAgainstDN.Enabled = false;
            }
        }

        #endregion

        #region "Public Methods..."

        private void LoadPIDetailList()
        {
            try
            {
                DataColumn clmItemID = new DataColumn("ItemID");
                clmItemID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmItemID);

                DataColumn clmItemName = new DataColumn("ItemName");
                clmItemName.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmItemName);

                DataColumn clmUOM = new DataColumn("UOM");
                clmUOM.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmUOM);

                DataColumn clmRate = new DataColumn("Rate");
                clmRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmRate);

                DataColumn clmQty = new DataColumn("Qty");
                clmQty.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmQty);

                DataColumn clmTaxClassID = new DataColumn("TaxClassID");
                clmTaxClassID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmTaxClassID);

                DataColumn clmTotalAmount = new DataColumn("TotalAmount");
                clmTotalAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmTotalAmount);

                DataColumn clmExciseRate = new DataColumn("ExciseRate");
                clmExciseRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExciseRate);

                DataColumn clmExciseAmount = new DataColumn("ExciseAmount");
                clmExciseAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExciseAmount);

                DataColumn clmServiceRate = new DataColumn("ServiceRate");
                clmServiceRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmServiceRate);

                DataColumn clmServiceAmount = new DataColumn("ServiceAmount");
                clmServiceAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmServiceAmount);

                DataColumn clmECessRate = new DataColumn("ECessRate");
                clmECessRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmECessRate);

                DataColumn clmECessAmount = new DataColumn("ECessAmount");
                clmECessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmECessAmount);

                DataColumn clmHECessRate = new DataColumn("HECessRate");
                clmHECessRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmHECessRate);

                DataColumn clmHECessAmount = new DataColumn("HECessAmount");
                clmHECessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmHECessAmount);

                DataColumn clmAmountAfterExcise = new DataColumn("AmountAfterExcise");
                clmAmountAfterExcise.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmAmountAfterExcise);

                DataColumn clmCSTRate = new DataColumn("CSTRate");
                clmCSTRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmCSTRate);

                DataColumn clmCSTAmount = new DataColumn("CSTAmount");
                clmCSTAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmCSTAmount);

                DataColumn clmVATRate = new DataColumn("VATRate");
                clmVATRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmVATRate);

                DataColumn clmVATAmount = new DataColumn("VATAmount");
                clmVATAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmVATAmount);

                DataColumn clmAVATRate = new DataColumn("AVATRate");
                clmAVATRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmAVATRate);

                DataColumn clmAVATAmount = new DataColumn("AVATAmount");
                clmAVATAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmAVATAmount);

                DataColumn clmNetAmount = new DataColumn("NetAmount");
                clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmNetAmount);

                DataColumn clmRemainingQty = new DataColumn("RemainingQty");
                clmRemainingQty.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmRemainingQty);

                DataColumn clmReceivedQty = new DataColumn("ReceivedQty");
                clmReceivedQty.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmReceivedQty);

                DataColumn clmDDate = new DataColumn("DDate");
                clmDDate.DataType = System.Type.GetType("System.DateTime");
                dtPIDetail.Columns.Add(clmDDate);

                DataColumn clmTaxClass = new DataColumn("TaxClass");
                clmTaxClass.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmTaxClass);




                DataColumn clmSGSTRate = new DataColumn("SGSTRate");
                clmSGSTRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmSGSTRate);

                DataColumn clmSGSTAmount = new DataColumn("SGSTAmount");
                clmSGSTAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmSGSTAmount);


                DataColumn clmCGSTRate = new DataColumn("CGSTRate");
                clmCGSTRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmCGSTRate);

                DataColumn clmCGSTAmount = new DataColumn("CGSTAmount");
                clmCGSTAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmCGSTAmount);



                DataColumn clmIGSTRate = new DataColumn("IGSTRate");
                clmIGSTRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmIGSTRate);

                DataColumn clmIGSTAmount = new DataColumn("IGSTAmount");
                clmIGSTAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmIGSTAmount);


                ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangePIDetailGridView()
        {
            try
            {
                dgvPIDetail.Columns["ItemID"].DataPropertyName = dtPIDetail.Columns["ItemID"].ToString();
                dgvPIDetail.Columns["ItemName"].DataPropertyName = dtPIDetail.Columns["ItemName"].ToString();
                dgvPIDetail.Columns["Qty"].DataPropertyName = dtPIDetail.Columns["Qty"].ToString();
                dgvPIDetail.Columns["UOM"].DataPropertyName = dtPIDetail.Columns["UOM"].ToString();
                dgvPIDetail.Columns["Rate"].DataPropertyName = dtPIDetail.Columns["Rate"].ToString();
                dgvPIDetail.Columns["TaxClassID"].DataPropertyName = dtPIDetail.Columns["TaxClassID"].ToString();
                dgvPIDetail.Columns["TotalAmount"].DataPropertyName = dtPIDetail.Columns["TotalAmount"].ToString();
                dgvPIDetail.Columns["ServiceAmount"].DataPropertyName = dtPIDetail.Columns["ServiceAmount"].ToString();
                dgvPIDetail.Columns["ExciseAmount"].DataPropertyName = dtPIDetail.Columns["ExciseAmount"].ToString();
                dgvPIDetail.Columns["ECessAmount"].DataPropertyName = dtPIDetail.Columns["ECessAmount"].ToString();
                dgvPIDetail.Columns["HECessAmount"].DataPropertyName = dtPIDetail.Columns["HECessAmount"].ToString();
                dgvPIDetail.Columns["AmountAfterExcise"].DataPropertyName = dtPIDetail.Columns["AmountAfterExcise"].ToString();
                dgvPIDetail.Columns["CSTAmount"].DataPropertyName = dtPIDetail.Columns["CSTAmount"].ToString();
                dgvPIDetail.Columns["VATAmount"].DataPropertyName = dtPIDetail.Columns["VATAmount"].ToString();
                dgvPIDetail.Columns["AVATAmount"].DataPropertyName = dtPIDetail.Columns["AVATAmount"].ToString();
                dgvPIDetail.Columns["NetAmount"].DataPropertyName = dtPIDetail.Columns["NetAmount"].ToString();
                dgvPIDetail.Columns["RemainingQty"].DataPropertyName = dtPIDetail.Columns["RemainingQty"].ToString();
                dgvPIDetail.Columns["ReceivedQty"].DataPropertyName = dtPIDetail.Columns["ReceivedQty"].ToString();
                dgvPIDetail.Columns["DDate"].DataPropertyName = dtPIDetail.Columns["DDate"].ToString();


                dgvPIDetail.Columns["SGSTAmount"].DataPropertyName = dtPIDetail.Columns["SGSTAmount"].ToString();
                dgvPIDetail.Columns["CGSTAmount"].DataPropertyName = dtPIDetail.Columns["CGSTAmount"].ToString();
                dgvPIDetail.Columns["IGSTAmount"].DataPropertyName = dtPIDetail.Columns["IGSTAmount"].ToString();



                for (int i = 0; i < dgvPIDetail.Columns.Count; i++)
                {
                    dgvPIDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadVendorList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtVendor = objList.ListOfRecord("usp_Vendor_LOV", para, "Purchase Invoice - LoadVendorList");

                if (objList.Exception == null)
                {
                    txtVendor.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtVendor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtVendor.Rows.Count; i++)
                    {
                        Data.Add(dtVendor.Rows[i]["VendorName"].ToString());
                    }
                    txtVendor.AutoCompleteCustomSource = Data;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void CalculateNetAmount()
        {
            try
            {
                if (dtPIDetail.Rows.Count > 0)
                {


                    txtSGSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(SGSTAmount)", "")).ToString("#0.00");
                    txtCGSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(CGSTAmount)", "")).ToString("#0.00");
                    txtIGSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(IGSTAmount)", "")).ToString("#0.00");

                    txtAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(TotalAmount)", "")).ToString("#0.00");
                    txtServiceAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ServiceAmount)", "")).ToString("#0.00");
                    txtExciseAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ExciseAmount)", "")).ToString("#0.00");
                    txtEduCessAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ECessAmount)", "")).ToString("#0.00");
                    txtHEduCessAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(HECessAmount)", "")).ToString("#0.00");
                    txtAmtwithExcise.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(AmountAfterExcise)", "")).ToString("#0.00");
                    txtCSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(CSTAmount)", "")).ToString("#0.00");
                    txtVATAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(VATAmount)", "")).ToString("#0.00");
                    txtAVATAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(AVATAmount)", "")).ToString("#0.00");
                    if (txtDiscount.Text != "" || txtDiscount.Text != "0.00")
                        txtNetAmount.Text = (Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")) - Convert.ToDecimal(txtDiscount.Text)).ToString("#0.00");
                    else
                        txtNetAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")).ToString("#0.00");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void BindControl()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CommSelect.SelectDataSetRecord(_PIID, "usp_Indent_Select", "Indent - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            dgvPIDetail.AutoGenerateColumns = false;
                            dgvPIDetail.DataSource = ds.Tables[1];
                            dtPIDetail = ds.Tables[1];
                            ArrangePIDetailGridView();
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtPINo.Text = ds.Tables[0].Rows[0]["PurchaseCode"].ToString();
                            _VendorID = Convert.ToInt64(ds.Tables[0].Rows[0]["VendorID"]);
                            dtpPIDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["PurchaseDate"]);
                            txtVoucherno.Text = ds.Tables[0].Rows[0]["VoucherNo"].ToString();
                            dtpVoucherDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["VoucherDate"]);
                            txtVendor.Text = ds.Tables[0].Rows[0]["VendorName"].ToString();
                            txtCreditDays.Text = ds.Tables[0].Rows[0]["CreditDays"].ToString();
                            txtDuedays.Text = ds.Tables[0].Rows[0]["DueDays"].ToString();
                            dtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"]);
                            txtNarration.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
                            txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                            txtPaidAmount.Text = ds.Tables[0].Rows[0]["PaidAmount"].ToString();
                            txtSrNo.Text = ds.Tables[0].Rows[0]["SrNo"].ToString();
                            cmbgodown.SelectedValue = ds.Tables[0].Rows[0]["GodownID"].ToString();
                            PGID = Convert.ToInt64(ds.Tables[0].Rows[0]["PGID"].ToString());
                            if (ds.Tables[0].Rows[0]["AgainstCForm"].ToString() == "True")
                            {
                                chkAgainstCForm.Checked = true;
                            }
                            else
                            {
                                chkAgainstCForm.Checked = false;
                            }


                            txtDNoutstand.Text = ds.Tables[0].Rows[0]["DebitOutstanding"].ToString();
                            txtRemainingDN.Text = ds.Tables[0].Rows[0]["RemainingDebit"].ToString();
                            txtAdjDN.Text = ds.Tables[0].Rows[0]["AdjustedDebit"].ToString();
                            cmbAgainstDN.Text = ds.Tables[0].Rows[0]["IsAgainstDebit"].ToString();

                            cmbAgainstDN.Enabled = false;
                            cmbbankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                            txtChequeNo.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
                            dtpchequeDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChequeDate"].ToString());
                            txtCustomerBankName.Text = ds.Tables[0].Rows[0]["CustomerBankName"].ToString();

                            if (Convert.ToDecimal(txtPaidAmount.Text) > 0)
                            {
                                grpBankDetail.Enabled = true;
                                cmbMode.Enabled = true;
                            }
                            else
                            {
                                grpBankDetail.Enabled = false;
                                cmbMode.Enabled = false;
                            }

                            if (txtChequeNo.Text != "")
                            {
                                grpBankDetail.Enabled = true;
                                cmbMode.SelectedItem = "Cheque";
                            }
                            else
                            {
                                grpBankDetail.Enabled = false;
                                cmbMode.SelectedItem = "Cash";
                            }

                            CalculateNetAmount();
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
                Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void DeletePI()
        {
            try
            {
                CommDelete.DeleteRecordWithGodowNBank(_PIID, "usp_Indent_Delete", "Indent - Delete", Convert.ToInt16(cmbgodown.SelectedValue), cmbbankName.Text);
                if (CommDelete.Exception == null)
                {
                    if (CommDelete.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = CommDelete.ErrorMessage;
                    }
                    else
                    {
                        lblErrorMessage.Text = "No error";
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show(CommDelete.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button Event..."

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtPINo.Text = objCommon.AutoNumber("GRN");
        }

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtIndent = new DataTable();
                frmIndentLOV fLOV = new frmIndentLOV();
                fLOV.ShowDialog();

                txtVendor.Text = fLOV.VendorName;
                txtVoucherno.Text = fLOV.VoucherNo;
                dtpPIDate.Value = fLOV.PurchaseDate;
                dtpVoucherDate.Value = fLOV.VoucherDate;
                cmbgodown.Text = fLOV.GodownName;
                txtemail.Text = fLOV.Fax;
                txtmobile.Text = fLOV.Mobile;
                txtCreditDays.Text = fLOV.CreditDays;
                _VendorID = fLOV.VendorID;
                PGID = fLOV.PIID;

                //_PIDetailID = fLOV.PIDetailID;

                if (fLOV.VendorName == null)
                {
                    PGID = 0;
                    //  dgvPIDetail.DataSource = null;
                }
                if (PGID != 0)
                {
                    dtIndent = CommSelect.SelectRecord(PGID, "usp_Purchase_Indent_LOV", "Indent - BindControl");
                    dgvPIDetail.DataSource = dtIndent;
                    dtPIDetail = dtIndent;
                    dgvPIDetail.AutoGenerateColumns = false;
                    ArrangePIDetailGridView();
                    //dgvPIDetail.Columns["Discount"].Visible = true;

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Warning");
            }
        }

        private void btnGeneratePI_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgainstDN.Text == "Against Debit Note")
                {
                    if (Convert.ToDecimal(txtAdjDN.Text) > Convert.ToDecimal(txtDNoutstand.Text))
                    {
                        lblErrorMessage.Text = "Adjustment amount can not greater than Outstanding Amount";
                        txtAdjDN.Focus();
                        return;
                    }

                    if (Convert.ToDecimal(txtAdjDN.Text) > Convert.ToDecimal(txtNetAmount.Text))
                    {
                        lblErrorMessage.Text = "Adjustment amount can not greater than Net Amount";
                        txtAdjDN.Focus();
                        return;
                    }



                    if (Convert.ToDouble(txtNetAmount.Text) < Convert.ToDouble(txtDNoutstand.Text))
                    {

                        //CalcPaidForLessNetAmount();
                        CalcRemainingDN();
                    }
                    else
                    {
                        //CalcPaidDN();
                        CalcRemainingDN();
                    }

                }

                if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    DeletePI();
                }
                else
                {
                    if (DataValidator.IsValid(this.grpData))
                    {
                        if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtNetAmount.Text))
                        {
                            lblErrorMessage.Text = "Paid amount can not greater than net amount";
                            txtPaidAmount.Focus();
                            return;
                        }

                        bool IsValid = false;
                        if (cmbMode.SelectedItem.ToString() == "Cheque")
                        {
                            if (txtChequeNo.Text == "" || txtCustomerBankName.Text == "" || Convert.ToInt32(cmbbankName.SelectedValue) == 0)
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
                            long Cnt = 0;
                            string XMLString = string.Empty;

                            XMLString = "<NewDataSet>";
                            for (int i = 0; i < dtPIDetail.Rows.Count; i++)
                            {
                                XMLString = XMLString + "<Table>";
                                XMLString = XMLString + "<ItemID>" + dtPIDetail.Rows[i]["ItemID"] + "</ItemID>";
                                XMLString = XMLString + "<Qty>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Qty"]).ToString("#0.00") + "</Qty>";
                                XMLString = XMLString + "<Rate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Rate"]).ToString("#0.00") + "</Rate>";
                                XMLString = XMLString + "<Amount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["TotalAmount"]).ToString("#0.00") + "</Amount>";
                                XMLString = XMLString + "<TaxClassID>" + Convert.ToInt64(dtPIDetail.Rows[i]["TaxClassID"]).ToString() + "</TaxClassID>";
                                XMLString = XMLString + "<ServiceRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ServiceRate"]).ToString("#0.00") + "</ServiceRate>";
                                XMLString = XMLString + "<ServiceAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ServiceAmount"]).ToString("#0.00") + "</ServiceAmount>";
                                XMLString = XMLString + "<ExciseRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExciseRate"]).ToString("#0.00") + "</ExciseRate>";
                                XMLString = XMLString + "<ExciseAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExciseAmount"]).ToString("#0.00") + "</ExciseAmount>";
                                XMLString = XMLString + "<EduCessRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ECessRate"]).ToString("#0.00") + "</EduCessRate>";
                                XMLString = XMLString + "<EduCessAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ECessAmount"]).ToString("#0.00") + "</EduCessAmount>";
                                XMLString = XMLString + "<HEduCessRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["HECessRate"]).ToString("#0.00") + "</HEduCessRate>";
                                XMLString = XMLString + "<HEduCessAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["HECessAmount"]).ToString("#0.00") + "</HEduCessAmount>";
                                XMLString = XMLString + "<AmountAfterExcise>" + Convert.ToDecimal(dtPIDetail.Rows[i]["AmountAfterExcise"]).ToString("#0.00") + "</AmountAfterExcise>";
                                XMLString = XMLString + "<CSTRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["CSTRate"]).ToString("#0.00") + "</CSTRate>";
                                XMLString = XMLString + "<CSTAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["CSTAmount"]).ToString("#0.00") + "</CSTAmount>";
                                XMLString = XMLString + "<VATRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["VATRate"]).ToString("#0.00") + "</VATRate>";
                                XMLString = XMLString + "<VATAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["VATAmount"]).ToString("#0.00") + "</VATAmount>";
                                XMLString = XMLString + "<AVATRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["AVATRate"]).ToString("#0.00") + "</AVATRate>";
                                XMLString = XMLString + "<AVATAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["AVATAmount"]).ToString("#0.00") + "</AVATAmount>";
                                XMLString = XMLString + "<NetAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["NetAmount"]).ToString("#0.00") + "</NetAmount>";
                                XMLString = XMLString + "<RemainingQty>" + Convert.ToDecimal(dtPIDetail.Rows[i]["RemainingQty"]).ToString("#0.00") + "</RemainingQty>";
                                XMLString = XMLString + "<ReceivedQty>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ReceivedQty"]).ToString("#0.00") + "</ReceivedQty>";
                                XMLString = XMLString + "<DDate>" + Convert.ToDateTime(dtPIDetail.Rows[i]["DDate"]).ToString("MM/dd/yyyy") + "</DDate>";


                                XMLString = XMLString + "<SGSTRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["SGSTRate"]).ToString("#0.00") + "</SGSTRate>";
                                XMLString = XMLString + "<SGSTAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["SGSTAmount"]).ToString("#0.00") + "</SGSTAmount>";

                                XMLString = XMLString + "<CGSTRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["CGSTRate"]).ToString("#0.00") + "</CGSTRate>";
                                XMLString = XMLString + "<CGSTAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["CGSTAmount"]).ToString("#0.00") + "</CGSTAmount>";

                                XMLString = XMLString + "<IGSTRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["IGSTRate"]).ToString("#0.00") + "</IGSTRate>";
                                XMLString = XMLString + "<IGSTAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["IGSTAmount"]).ToString("#0.00") + "</IGSTAmount>";



                                XMLString = XMLString + "</Table> ";
                                Cnt = Cnt + 1;
                            }
                            XMLString = XMLString + "</NewDataSet>";
                            if (Cnt == 0)
                            {
                                lblErrorMessage.Text = "Select at least one item";
                                dgvPIDetail.Focus();
                                return;
                            }

                            if (chkAgainstCForm.Checked)
                            {
                                AginstCForm = true;
                            }
                            else
                            {
                                AginstCForm = false;
                            }



                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                Int32 PIID = 0;
                                objPOBL.Insert(txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value), txtSrNo.Text, txtVoucherno.Text,
                                                        Convert.ToDateTime(dtpVoucherDate.Value), _VendorID, Convert.ToInt64(txtDuedays.Text),
                                                        Convert.ToDateTime(dtpDueDate.Value), Convert.ToDecimal(txtServiceAmt.Text),
                                                        Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                                        Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                                        Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                                        Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text),
                                                        Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text),
                                                        Convert.ToDecimal(txtPaidAmount.Text), txtNarration.Text, XMLString, Cnt,
                                                        Convert.ToInt32(cmbgodown.SelectedValue), PGID, AginstCForm
                                                        ,
                                                        Convert.ToDecimal(txtDNoutstand.Text), Convert.ToDecimal(txtRemainingDN.Text), Convert.ToDecimal(txtAdjDN.Text), cmbAgainstDN.Text
                                                        , cmbbankName.Text, txtChequeNo.Text, Convert.ToDateTime(dtpchequeDate.Value)
                                                        , txtCustomerBankName.Text, txtSGSTAmt.Text, txtSGSTAmt.Text, txtSGSTAmt.Text
                                                        );
                            }
                            else
                            {
                                decimal tempRecvQty = frmIndentItemEntry.tempRecvQty;
                                objPOBL.Update(_PIID, txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value), txtSrNo.Text, txtVoucherno.Text,
                                                Convert.ToDateTime(dtpVoucherDate.Value), _VendorID, Convert.ToInt64(txtDuedays.Text),
                                                Convert.ToDateTime(dtpDueDate.Value), Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtServiceAmt.Text),
                                                Convert.ToDecimal(txtExciseAmt.Text), Convert.ToDecimal(txtEduCessAmt.Text),
                                                Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text),
                                                Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text),
                                                Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text),
                                                txtNarration.Text, XMLString, Cnt, Convert.ToInt32(cmbgodown.SelectedValue), tempRecvQty, PGID, AginstCForm
                                                , Convert.ToDecimal(txtDNoutstand.Text), Convert.ToDecimal(txtRemainingDN.Text), Convert.ToDecimal(txtAdjDN.Text), cmbAgainstDN.Text
                                                , cmbbankName.Text, txtChequeNo.Text, Convert.ToDateTime(dtpchequeDate.Value)
                                               , txtCustomerBankName.Text, txtSGSTAmt.Text, txtSGSTAmt.Text, txtSGSTAmt.Text
                                                );
                            }
                            if (objPOBL.Exception == null)
                            {
                                if (objPOBL.ErrorMessage != "")
                                {
                                    lblErrorMessage.Text = objPOBL.ErrorMessage;
                                    dtpPIDate.Focus();
                                    return;
                                }
                                else
                                {
                                    this.Dispose();
                                }
                            }
                            else
                            {
                                MessageBox.Show(objPOBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill up all Bank details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //grpBankDetail.Focus();

                            lblErrorMessage.Text = "Please fill up all Bank details";
                            grpBankDetail.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cmbgodown.SelectedValue) == 0)
            {
                MessageBox.Show("First Select Godown.");
                return;
            }
            else
            {

                lblErrorMessage.Text = "";
                string StrItem = "#";
                for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
                {
                    StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
                }
                int godown = Convert.ToInt32(cmbgodown.SelectedValue);
                Indent.frmIndentItemEntry fPIEntry = new Indent.frmIndentItemEntry((int)Constant.Mode.Insert, _PIID, _VendorID, dtpPIDate.Value, dtPIDetail, godown, 0, 0, 0, editlov);
                fPIEntry.ShowDialog();
                dgvPIDetail.AutoGenerateColumns = false;
                dgvPIDetail.DataSource = dtPIDetail;
                ArrangePIDetailGridView();
                CalculateNetAmount();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvPIDetail.CurrentRow == null))
            {
                if ((dgvPIDetail.Rows.Count > 1))
                {
                    if ((MessageBox.Show(("You are going to Delete the Purchase Invoice." + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
                    {
                        int RowIndex = dgvPIDetail.CurrentRow.Index;
                        dtPIDetail.Rows[RowIndex].Delete();
                        dtPIDetail.AcceptChanges();

                        dgvPIDetail.AutoGenerateColumns = false;
                        dgvPIDetail.DataSource = dtPIDetail;
                        ArrangePIDetailGridView();
                        CalculateNetAmount();
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Atleast one Item entry is required";
                }
            }
        }

        #endregion

        #region "Textbox Event"

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                if (txtVendor.Text != "")
                {

                    DataView dvItem = new DataView();
                    dvItem = dtVendor.DefaultView;
                    dvItem.RowFilter = "VendorName='" + PrepareFilterString(txtVendor.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();

                    //DataView dvVendor = new DataView();
                    //dvVendor = dtVendor.DefaultView;
                    //dvVendor.RowFilter = "VendorName='" + PrepareFilterString(txtVendor.Text) + "%'";

                    //DataTable dtTempItem = new DataTable();
                    //dtTempItem = dvVendor.ToTable();

                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        txtVendor.Text = dtTempItem.Rows[0]["VendorName"].ToString();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid vendor";
                        _VendorID = 0;
                        //   dgvPIDetail.DataSource = null;
                        txtVendor.Focus();
                    }

                }
                else
                {
                    _VendorID = 0;
                    dgvPIDetail.DataSource = null;
                }
            }
        }

        #endregion

        #region "Grid View Cellpainting Event"

        private void dgvPIDetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvPIDetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvPIDetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {
                    txtTextbox.Text = Convert.ToDecimal(txtTextbox.Text).ToString("#0.00");
                    // Set Decimal Value after textbox's Leave Event
                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        lblErrorMessage.Text = "No error";
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99999999.99";
                        txtTextbox.Focus();
                    }
                }
                else
                {
                    txtTextbox.Text = "0.00";
                }
            }
            else
            {
                txtTextbox.Text = "0.00";
            }
            if (txtTextbox.Name == "txtDiscount")
                CalculateNetAmount();

            if (Convert.ToDecimal(txtPaidAmount.Text) > 0)
            {
                grpBankDetail.Enabled = true;
                cmbMode.Enabled = true;
            }
        }

        private void txtDuedays_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {
                    // Set Decimal Value after textbox's Leave Event
                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        lblErrorMessage.Text = "No error";
                        if (Convert.ToInt16(txtTextbox.Text) > 0)
                        {
                            dtpDueDate.Value = dtpPIDate.Value.Date.AddDays(Convert.ToInt16(txtTextbox.Text));
                        }
                        else
                        {
                            dtpDueDate.Value = dtpPIDate.Value;
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99";
                        txtTextbox.Focus();
                    }
                }
                else
                {
                    txtTextbox.Text = "0";
                }
            }
            else
            {
                txtTextbox.Text = "0";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            lblErrorMessage.Text = "";
            string StrItem = "#";
            for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
            {
                StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
            }
            // int godown = Convert.ToInt32(cmbgodown.SelectedValue);
            int ItemID_Edit = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["ItemID"].Value);
            int _ID = 0;
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                _PIID = PGID;
                _ID = 1;
            }
            int godown = Convert.ToInt32(cmbgodown.SelectedValue);
            Indent.frmIndentItemEntry fPIEntry = new Indent.frmIndentItemEntry((int)Constant.Mode.Modify, _PIID, _VendorID, dtpPIDate.Value, dtPIDetail, godown, ItemID_Edit, _ID, _PIDetailID, editlov);
            fPIEntry.ShowDialog();



            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
        }

        private void chkAgainstCForm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgainstCForm.Checked)
            {
                AginstCForm = true;
            }
            else
            {
                AginstCForm = false;
            }
        }

        public void CalcPaidForLessNetAmount()
        {
            txtAdjDN.Text = txtNetAmount.Text;
            //txtPaidAmount.Text = Convert.ToDecimal(Convert.ToDouble(txtNetAmount.Text) - Convert.ToDouble(txtAdjDN.Text)).ToString("#0.00");

        }

        public void CalcRemainingDN()
        {
            if (txtDNoutstand.Text != "0.00" && txtDNoutstand.Text != "" && txtAdjDN.Text != "0.00" && txtAdjDN.Text != "")
            {
                txtRemainingDN.Text = Convert.ToDecimal(Convert.ToDouble(txtDNoutstand.Text) - Convert.ToDouble(txtAdjDN.Text)).ToString("#0.00");
            }
        }

        public void CalcPaidDN()
        {
            if (txtNetAmount.Text != "0.00" && txtNetAmount.Text != "" && txtAdjDN.Text != "0.00" && txtAdjDN.Text != "")
            {
                txtPaidAmount.Text = Convert.ToDecimal(Convert.ToDouble(txtNetAmount.Text) - Convert.ToDouble(txtAdjDN.Text)).ToString("#0.00");
                txtTotalPaidAmount.Text = Convert.ToDecimal(Convert.ToDouble(txtNetAmount.Text) - Convert.ToDouble(txtAdjDN.Text)).ToString("#0.00");
            }
        }

        private void cmbAgainstDN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgainstDN.Text == "Against Debit Note")
                {
                    GrpDN.Visible = true;
                    //groupBox1.Height = 180;
                    //dgvPIDetail.Height = 131;
                    groupBox1.Height = 164;
                    dgvPIDetail.Height = 119;
                    txtPaidAmount.ReadOnly = true;

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        DataSet ds3 = new DataSet();
                        DataTable dtDNout = new DataTable();

                        ds3 = CommSelect.SelectDataSetRecord(_VendorID, "usp_Indent_DNOutstanding", "Indent - DNOutstanding");
                        //ds1 = CommSelect.SelectDataSetRecord(_SaleId, "usp_SaleDocList_List", "SalesInvoice - BindControl");
                        if (CommSelect.Exception == null)
                        {
                            if (CommSelect.ErrorMessage == "")
                            {
                                if (ds3.Tables[0].Rows.Count > 0)
                                {
                                    dtDNout = ds3.Tables[0];
                                    if (dtDNout.Rows[0]["DNout"].ToString() != "")
                                    {
                                        txtDNoutstand.Text = dtDNout.Rows[0]["DNout"].ToString();
                                        txtAdjDN.Text = dtDNout.Rows[0]["DNout"].ToString();

                                        if (Convert.ToDouble(txtNetAmount.Text) < Convert.ToDouble(txtDNoutstand.Text))
                                        {

                                            CalcPaidForLessNetAmount();
                                            CalcRemainingDN();
                                        }

                                    }
                                    else
                                    {
                                        txtDNoutstand.Text = "0.00";
                                        txtAdjDN.Text = "0.00";

                                        lblErrorMessage.Text = "No Debit Note for this Vendor";
                                        cmbAgainstDN.Text = "Direct Indent";
                                    }
                                }

                            }
                            //////////
                        }

                    }
                    //////////

                }
                else if (cmbAgainstDN.Text == "Direct Indent")
                {
                    GrpDN.Visible = false;
                    groupBox1.Height = 250;
                    dgvPIDetail.Height = 205;
                    txtPaidAmount.ReadOnly = false;
                    txtDNoutstand.Text = "0.00";
                    txtRemainingDN.Text = "0.00";
                    txtAdjDN.Text = "0.00";

                }
            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("SaleInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtAdjDN_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbAgainstDN.Text == "Against Debit Note")
                {
                    if (txtAdjDN.Text != "" && txtDNoutstand.Text != "")
                    {
                        if (Convert.ToDecimal(txtAdjDN.Text) > Convert.ToDecimal(txtDNoutstand.Text))
                        {
                            lblErrorMessage.Text = "Adjustment amount can not greater than Outstanding Amount";
                            txtAdjDN.Focus();
                            return;
                        }

                        if (Convert.ToDecimal(txtAdjDN.Text) > Convert.ToDecimal(txtNetAmount.Text))
                        {
                            lblErrorMessage.Text = "Adjustment amount can not greater than Net Amount";
                            txtAdjDN.Focus();
                            return;
                        }

                        if (Convert.ToDouble(txtNetAmount.Text) < Convert.ToDouble(txtDNoutstand.Text))
                        {

                            // CalcPaidForLessNetAmount();
                            CalcRemainingDN();
                        }
                        else
                        {
                            //CalcPaidDN();
                            CalcRemainingDN();
                        }



                    }
                    else
                    {
                        lblErrorMessage.Text = "No credit Note for this customer";
                        cmbAgainstDN.Text = "Direct Indent";
                    }
                }

            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtpchequeDate_CloseUp(object sender, EventArgs e)
        {
            //txtChequeDate.Text = dtpchequeDate.Value.ToString("dd/MM/yyyy");
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
