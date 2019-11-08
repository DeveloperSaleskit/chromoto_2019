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

namespace Account.GUI.SalesInvoice
{
    public partial class frmSalesInvoiceItemEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtItemList = new DataTable();
        Int64 _ItemID = 0;
        Int64 _CustomerID = 0;
        decimal _Rate;
        Int64 _PIID;
        int _godown;
        DateTime _PIDate;
        DataTable _dtDetail;

        #endregion

        #region "Form Events...."

        public frmSalesInvoiceItemEntry(Int64 PIID, Int64 CustomerID, DateTime PIDate, DataTable dtPIDetail)
        {
            InitializeComponent();
            _PIID = PIID;
            _CustomerID = CustomerID;
            _PIDate = PIDate;
            _dtDetail = dtPIDetail;
           
        }

        private void frmSalesInvoiceItemEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            LoadItemList();
            objCommon.FillTaxClassCombo(cmbTaxClass);
        }

        #endregion

        #region "Public Methods..."

        private void LoadItemList()
        {
            try
            {

                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
               
                dtItemList = objList.ListOfRecord("usp_Item_LOV", para, "Sales Invoice Detail - LoadItemList");

                if (objList.Exception == null)
                {
                    txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtItemList.Rows.Count; i++)
                    {
                        Data.Add(dtItemList.Rows[i]["ItemName"].ToString());
                    }
                    txtItemName.AutoCompleteCustomSource = Data;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void CalculateNetAmount()
        {
            try
            {
                double TotalAmount = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);
                double ServiceAmt = 0;
                double ExciseAmt = 0;
                double EducessAmt = 0;
                double HEducessAmt = 0;
                double AmtwithExcise = 0;
                double CSTAmt = 0;
                double VATAmt = 0;
                double AVATAmt = 0;
                double NetAmt = 0;

                txtAmount.Text = TotalAmount.ToString("#0.00");
                ServiceAmt = (TotalAmount * Convert.ToDouble(txtServiceTax.Text)) / 100;
                txtServiceAmt.Text = ServiceAmt.ToString("#0.00");
                ExciseAmt = (TotalAmount * Convert.ToDouble(txtExciseRate.Text)) / 100;
                txtExciseAmt.Text = ExciseAmt.ToString("#0.00");
                EducessAmt = (Convert.ToDouble(txtServiceAmt.Text) * Convert.ToDouble(txtEduCessRate.Text)) / 100;
                txtEduCessAmt.Text = EducessAmt.ToString("#0.00");
                HEducessAmt = (Convert.ToDouble(txtServiceAmt.Text) * Convert.ToDouble(txtHEduCessRate.Text)) / 100;
                txtHEduCessAmt.Text = HEducessAmt.ToString("#0.00");
                AmtwithExcise = TotalAmount + ExciseAmt;
                txtAmtwithExcise.Text = AmtwithExcise.ToString("#0.00");
                CSTAmt = (AmtwithExcise * Convert.ToDouble(txtCSTRate.Text)) / 100;
                txtCSTAmt.Text = CSTAmt.ToString("#0.00");
                VATAmt = (AmtwithExcise * Convert.ToDouble(txtVATRate.Text)) / 100;
                txtVATAmt.Text = VATAmt.ToString("#0.00");
                AVATAmt = (AmtwithExcise * Convert.ToDouble(txtAVATRate.Text)) / 100;
                txtAVATAmt.Text = AVATAmt.ToString("#0.00");

                NetAmt = ServiceAmt + AmtwithExcise + CSTAmt + VATAmt + AVATAmt + EducessAmt + HEducessAmt;
                txtNetAmount.Text = NetAmt.ToString("#0.00");
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event..."

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
               
                frmItemLOV fLOV = new frmItemLOV("usp_Item_LOV", para);
                fLOV.ShowDialog();

                //for (int i = 0; i < _dtDetail.Rows.Count; i++)
                //{
                //    if (fLOV.ItemID == Convert.ToInt64(_dtDetail.Rows[i]["ItemID"]))
                //    {
                //        lblErrorMessage.Text = "Item already exists in Sales Invoice";
                //        _ItemID = 0;
                //        txtQty.Text = "0.000";
                //        txtQOH.Text = "0.000";
                //        txtUOM.Text = "";
                //        txtItemName.Text = fLOV.ItemName;
                //        btnItemLOV.Focus();
                //        return;
                //    }
                //}
                txtItemName.Text = fLOV.ItemName;

                if (fLOV.ItemName == null)
                {
                    _ItemID = 0;
                    txtQty.Text = "0.000";
                    txtQOH.Text = "";
                    txtUOM.Text = "";
                }
                else
                {
                    DataView dvItem = new DataView();
                    dvItem = dtItemList.DefaultView;
                    dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();

                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                        txtQOH.Text = dtTempItem.Rows[0]["QOH"].ToString();
                        txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                        btnSaveExit.Enabled = true;
                        txtQty.Text = "0.000";
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid item";
                        _ItemID = 0;
                        txtQOH.Text = "0.000";
                        txtUOM.Text = "";
                        txtItemName.Focus();
                        btnSaveExit.Enabled = false;
                        txtQty.Text = "0.000";
                    }

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataValidator.IsValid(this.grpData))
                {

                    DataRow dr;
                    dr = _dtDetail.NewRow();
                    dr["ItemID"] = _ItemID;
                    dr["ItemName"] = txtItemName.Text;
                    dr["UOM"] = txtUOM.Text;
                    dr["Qty"] = Convert.ToDecimal(txtQty.Text);
                    dr["Rate"] = Convert.ToDecimal(txtRate.Text);
                    dr["TotalAmount"] = Convert.ToDecimal(txtAmount.Text); ;
                    dr["TaxClassID"] = Convert.ToInt64(cmbTaxClass.SelectedValue);
                    dr["ServiceRate"] = Convert.ToDecimal(txtServiceTax.Text);
                    dr["ServiceAmount"] = Convert.ToDecimal(txtServiceAmt.Text);

                    dr["ExciseRate"] = Convert.ToDecimal(txtExciseRate.Text);
                    dr["ExciseAmount"] = Convert.ToDecimal(txtExciseAmt.Text);
                    dr["ECessRate"] = Convert.ToDecimal(txtEduCessRate.Text);
                    dr["ECessAmount"] = Convert.ToDecimal(txtEduCessAmt.Text);
                    dr["HECessRate"] = Convert.ToDecimal(txtHEduCessRate.Text);
                    dr["HECessAmount"] = Convert.ToDecimal(txtHEduCessAmt.Text);
                    dr["AmountAfterExcise"] = Convert.ToDecimal(txtAmtwithExcise.Text);
                    dr["CSTRate"] = Convert.ToDecimal(txtCSTRate.Text);
                    dr["CSTAmount"] = Convert.ToDecimal(txtCSTAmt.Text);
                    dr["VATRate"] = Convert.ToDecimal(txtVATRate.Text);
                    dr["VATAmount"] = Convert.ToDecimal(txtVATAmt.Text);
                    dr["AVATRate"] = Convert.ToDecimal(txtAVATRate.Text);
                    dr["AVATAmount"] = Convert.ToDecimal(txtAVATAmt.Text);
                    dr["NetAmount"] = Convert.ToDecimal(txtNetAmount.Text);
                    dr["ItemDesc"] = txtItemDesc.Text;
                    _dtDetail.Rows.Add(dr);
                    this.Dispose();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Textbox Event"

        private void txtDiscRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtItemName.Text != "")
                {
                    DataView dvItem = new DataView();
                    dvItem = dtItemList.DefaultView;
                    dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();

                    if (dtTempItem.Rows.Count > 0)
                    {
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);

                        //for (int i = 0; i < _dtDetail.Rows.Count; i++)
                        //{
                        //    if (_ItemID == Convert.ToInt64(_dtDetail.Rows[i]["ItemID"]))
                        //    {
                        //        lblErrorMessage.Text = "Item already exists in Sales Invoice";
                        //        _ItemID = 0;
                        //        txtQty.Text = "0.000";
                        //        txtQOH.Text = "";
                        //        txtUOM.Text = "";
                        //        txtItemName.Focus();
                        //        return;
                        //    }
                        //}

                        lblErrorMessage.Text = "No error";
                        txtItemName.Text = dtTempItem.Rows[0]["ItemName"].ToString();
                        txtQOH.Text = dtTempItem.Rows[0]["QOH"].ToString();
                        txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                        btnSaveExit.Enabled = true;
                        txtQty.Text = "0.000";

                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid item";
                        _ItemID = 0;
                        txtQOH.Text = "0.000";
                        txtUOM.Text = "";
                        txtItemName.Focus();
                        btnSaveExit.Enabled = false;
                        txtQty.Text = "0.000";
                    }

                }
                else
                {
                    _ItemID = 0;
                    txtQOH.Text = "0.000";
                    txtUOM.Text = "";
                    txtQty.Text = "0.000";
                    btnSaveExit.Enabled = true;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {
                    txtTextbox.Text = Convert.ToDecimal(txtTextbox.Text).ToString("#0.000");
                    // Set Decimal Value after textbox's Leave Event
                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        btnSaveExit.Enabled = true;
                        lblErrorMessage.Text = "No error";
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99999999999999.999";
                        txtTextbox.Focus();
                        btnSaveExit.Enabled = false;
                    }
                }
                else
                {
                    txtTextbox.Text = "0.000";
                    btnSaveExit.Enabled = true;
                }
            }
            else
            {
                txtTextbox.Text = "0.000";
                btnSaveExit.Enabled = true;
            }
            CalculateNetAmount();
        }

        private void txtDiscRate_Leave(object sender, EventArgs e)
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
                        btnSaveExit.Enabled = true;
                        lblErrorMessage.Text = "No error";

                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99.99";
                        txtTextbox.Focus();
                        btnSaveExit.Enabled = false;
                    }
                }
                else
                {
                    txtTextbox.Text = "0.00";
                    btnSaveExit.Enabled = true;
                }
            }
            else
            {
                txtTextbox.Text = "0.00";
                btnSaveExit.Enabled = true;
            }
            CalculateNetAmount();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateNetAmount();
        }

        private void txtCSTRate_Leave(object sender, EventArgs e)
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
                        btnSaveExit.Enabled = true;
                        lblErrorMessage.Text = "No error";

                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99.99";
                        txtTextbox.Focus();
                        btnSaveExit.Enabled = false;
                    }
                }
                else
                {
                    txtTextbox.Text = "0.00";
                    btnSaveExit.Enabled = true;
                }
            }
            else
            {
                txtTextbox.Text = "0.00";
                btnSaveExit.Enabled = true;
            }

            if (Convert.ToDecimal(txtCSTRate.Text) > 0)
            {
                txtVATRate.Text = "0.00";
                txtAVATRate.Text = "0.00";
            }
            CalculateNetAmount();
        }

        private void txtVATRate_Leave(object sender, EventArgs e)
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
                        btnSaveExit.Enabled = true;
                        lblErrorMessage.Text = "No error";
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99.99";
                        txtTextbox.Focus();
                        btnSaveExit.Enabled = false;
                    }
                }
                else
                {
                    txtTextbox.Text = "0.00";
                    btnSaveExit.Enabled = true;
                }
            }
            else
            {
                txtTextbox.Text = "0.00";
                btnSaveExit.Enabled = true;
            }

            if (Convert.ToDecimal(txtVATRate.Text) > 0 || Convert.ToDecimal(txtAVATRate.Text) > 0)
            {
                txtCSTRate.Text = "0.00";
            }

            CalculateNetAmount();
        }

        #endregion

        #region "ComboBox Event..."

        private void cmbTaxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTaxClass.SelectedIndex > 0)
                {
                    DataTable dtTaxClass = new DataTable();
                    dtTaxClass = CommSelect.SelectRecord((long)cmbTaxClass.SelectedValue, "usp_TaxClass_GetRate", "Sales Invoice - TaxClass Select");
                    if (CommSelect.Exception == null)
                    {
                        if (CommSelect.ErrorMessage == "")
                        {
                            if (dtTaxClass.Rows.Count > 0)
                            {
                                txtServiceTax.Text = dtTaxClass.Rows[0]["ServiceTax"].ToString();
                                txtExciseRate.Text = dtTaxClass.Rows[0]["Excise"].ToString();
                                txtEduCessRate.Text = dtTaxClass.Rows[0]["EduCess"].ToString();
                                txtHEduCessRate.Text = dtTaxClass.Rows[0]["HEduCess"].ToString();
                                txtCSTRate.Text = dtTaxClass.Rows[0]["CST"].ToString();
                                txtVATRate.Text = dtTaxClass.Rows[0]["VAT"].ToString();
                                txtAVATRate.Text = dtTaxClass.Rows[0]["AVAT"].ToString();
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
                else
                {
                    txtServiceTax.Text = "0.00";
                    txtExciseRate.Text = "0.00";
                    txtEduCessRate.Text = "0.00";
                    txtHEduCessRate.Text = "0.00";
                    txtCSTRate.Text = "0.00";
                    txtVATRate.Text = "0.00";
                    txtAVATRate.Text = "0.00";
                    CalculateNetAmount();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion


    }
}
