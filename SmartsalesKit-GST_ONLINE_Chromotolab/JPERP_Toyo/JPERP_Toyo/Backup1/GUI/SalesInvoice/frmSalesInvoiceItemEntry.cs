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
        int _ItemID_Edit;
        int UID;
        int _GodownID_Edit = 0;
        int _GodownID = 0;

        int _Mode = 0;
        DataTable dtsaleEdit = new DataTable();
        int _ID = 0;
        public decimal ItemDiscountAmt;
        decimal _ItemDiscAmt;

        Int64 _CurrencyID;
        bool _IsFirstItem;
        #endregion

        #region "Form Events...."

        public frmSalesInvoiceItemEntry(int Mode, Int64 PIID, Int64 CustomerID, DateTime PIDate, DataTable dtPIDetail, decimal ItemDiscAmt, int ItemID_Edit, int ID, int GodownID, int GodownID_Edit, Int64 CurrencyID, bool IsFirstItem)
        {
            InitializeComponent();
            _Mode = Mode;
            _PIID = PIID;
            _CustomerID = CustomerID;
            _PIDate = PIDate;
            _dtDetail = dtPIDetail;
            _ItemID_Edit = ItemID_Edit;
            _ID = ID;
            _ItemDiscAmt = ItemDiscAmt;
            _godown = GodownID;
            _GodownID_Edit = GodownID_Edit;
            _CurrencyID = CurrencyID;
            _IsFirstItem = IsFirstItem;
        }

        private void frmSalesInvoiceItemEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillTaxClassCombo(cmbTaxClass);
            objCommon.FillGodownCombo(cmbgodown);
            objCommon.FillCurrencyCombo(cmbCurrency);
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                if (_ID == 0)
                {
                    txtItemName.ReadOnly = true;
                    btnItemLOV.Visible = false;
                    cmbgodown.Enabled = false;

                    _ItemID = _ItemID_Edit;
                    _GodownID = _GodownID_Edit;
                    NameValueCollection para1 = new NameValueCollection();
                    para1.Add("@i_ItemID", _ItemID.ToString());
                    para1.Add("@i_GodownID", _GodownID.ToString());
                    para1.Add("@i_SIID", _PIID.ToString());
                    dtsaleEdit = objList.ListOfRecord("usp_Item_Sale_edit", para1, "Quotation - LoadList");
                    if (dtsaleEdit.Rows.Count > 0)
                    {
                        txtItemName.Text = dtsaleEdit.Rows[0]["ItemName"].ToString();
                        txtUOM.Text = dtsaleEdit.Rows[0]["UOM"].ToString();
                        txtRate.Text = dtsaleEdit.Rows[0]["Rate"].ToString();
                        txtQty.Text = dtsaleEdit.Rows[0]["Qty"].ToString();
                        txtAmount.Text = dtsaleEdit.Rows[0]["Amount"].ToString();

                        txtdiscopunt.Text = dtsaleEdit.Rows[0]["Discount"].ToString();
                        //txtamtdiscount.Text = dtsaleEdit.Rows[0]["NetAmount"].ToString();
                        txtamtdiscount.Text = dtsaleEdit.Rows[0]["AmtAfterDisc"].ToString();
                        txtAmtwithExcise.Text = dtsaleEdit.Rows[0]["AmountAfterExcise"].ToString();

                        cmbTaxClass.SelectedValue = Convert.ToInt32(dtsaleEdit.Rows[0]["TaxClassID"]);
                        txtItemDesc.Text = dtsaleEdit.Rows[0]["ItemDesc"].ToString();
                        cmbgodown.SelectedValue = Convert.ToInt32(dtsaleEdit.Rows[0]["GodownID"]);
                        cmbCurrency.SelectedValue = Convert.ToInt64(dtsaleEdit.Rows[0]["CurrencyID"].ToString());
                        lblExtraTax.Text = dtsaleEdit.Rows[0]["ExtraTaxType"].ToString();
                        CalculateNetAmount();
                        cmbTaxClass_SelectedIndexChanged(sender, e);
                    }
                }
                else if (_ID == 1)
                {
                    _ItemID = _ItemID_Edit;
                    _GodownID = _GodownID_Edit;
                    DataTable dtQuotationItem = new DataTable();
                    NameValueCollection para2 = new NameValueCollection();
                    para2.Add("@i_ItemID", _ItemID.ToString());
                    para2.Add("@i_GodownID", _GodownID.ToString());
                    para2.Add("@i_QuotationID", _PIID.ToString());
                    dtQuotationItem = objList.ListOfRecord("usp_Item_Quotation_edit", para2, "Quotation - LoadList");

                    if (dtQuotationItem.Rows.Count > 0)
                    {
                        txtItemName.Text = dtQuotationItem.Rows[0]["ItemName"].ToString();
                        txtUOM.Text = dtQuotationItem.Rows[0]["UOM"].ToString();
                        txtRate.Text = dtQuotationItem.Rows[0]["Rate"].ToString();
                        txtQty.Text = dtQuotationItem.Rows[0]["Qty"].ToString();
                        txtAmount.Text = dtQuotationItem.Rows[0]["Amount"].ToString();
                        //txtamtdiscount.Text = dtQuotationItem.Rows[0]["AmtAfterDisc"].ToString();
                        txtamtdiscount.Text = dtQuotationItem.Rows[0]["AmountAfterExcise"].ToString();
                        txtdiscopunt.Text = dtQuotationItem.Rows[0]["Discount"].ToString();
                        cmbgodown.SelectedValue = Convert.ToInt32(dtQuotationItem.Rows[0]["GodownID"]);

                        cmbTaxClass.SelectedValue = dtQuotationItem.Rows[0]["TaxClassId"].ToString();
                        cmbCurrency.SelectedValue = Convert.ToInt64(dtQuotationItem.Rows[0]["CurrencyID"].ToString());
                        lblExtraTax.Text = dtQuotationItem.Rows[0]["ExtraTaxType"].ToString();

                        CalculateNetAmount();
                        cmbTaxClass_SelectedIndexChanged(sender, e);
                        btnItemLOV.Enabled = false;
                    }
                }
                LoadItemList();
            }
            else
            {
                cmbgodown.SelectedValue = 0;
                //cmbTaxClass.SelectedValue = 2;
                // LoadItemList();
            }
        }

        #endregion

        #region "Public Methods..."

        private void LoadItemList()
        {
            try
            {

                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_GodownID", cmbgodown.SelectedValue.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtItemList = objList.ListOfRecord("usp_Item_LOV", para, "Sales Invoice Detail - LoadItemList");

                ////----------------------
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {

                    DataView dvItem = new DataView();//added by rooja for item autosearch data fill
                    dvItem = dtItemList.DefaultView;
                    if (txtItemName.Text != "")
                    {
                        dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "' and ItemID = '" + UID + "' ";
                        DataTable dtTempItem = new DataTable();
                        dtTempItem = dvItem.ToTable();

                        if (dtTempItem.Rows.Count > 0)
                        {
                            lblErrorMessage.Text = "No error";
                            _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                            txtQOH.Text = dtTempItem.Rows[0]["QOH"].ToString();
                            txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                            txtRate.Text = dtTempItem.Rows[0]["Price"].ToString();
                            txtItemDesc.Text = dtTempItem.Rows[0]["Specification"].ToString();
                            cmbCurrency.SelectedValue = Convert.ToInt64(dtTempItem.Rows[0]["CurrencyID"].ToString());
                            //btnSaveExit.Enabled = true;
                            // txtQty.Text = "0.000";
                        }

                    }
                    else
                    {
                        // lblErrorMessage.Text = "Invalid item";
                        lblErrorMessage.Text = "Please Select Item";
                        _ItemID = 0;
                        txtQOH.Text = "0.000";
                        txtUOM.Text = "";
                        txtRate.Text = "0.00";
                        txtAmount.Text = "0.00";
                        txtItemName.Focus();
                        btnSaveExit.Enabled = false;
                        txtQty.Text = "0.000";
                    }
                }
                ////------------------------------

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
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Warning");
            }
        }

        //public void CalculateNetAmount()
        //{
        //    try
        //    {
        //        double TotalAmount = Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text);
        //        double ServiceAmt = 0;
        //        double ExciseAmt = 0;
        //        double EducessAmt = 0;
        //        double HEducessAmt = 0;
        //        double AmtwithExcise = 0;
        //        double CSTAmt = 0;
        //        double VATAmt = 0;
        //        double AVATAmt = 0;
        //        double NetAmt = 0;

        //        if (txtdiscopunt.Text != "0.00")
        //        {
        //            TotalAmount = Convert.ToDouble(txtamtdiscount.Text);
        //        }

        //        txtAmount.Text = TotalAmount.ToString("#0.00");
        //        ServiceAmt = (TotalAmount * Convert.ToDouble(txtServiceTax.Text)) / 100;
        //        txtServiceAmt.Text = ServiceAmt.ToString("#0.00");
        //        ExciseAmt = (TotalAmount * Convert.ToDouble(txtExciseRate.Text)) / 100;
        //        txtExciseAmt.Text = ExciseAmt.ToString("#0.00");
        //        EducessAmt = (TotalAmount * Convert.ToDouble(txtEduCessRate.Text)) / 100;
        //        txtEduCessAmt.Text = EducessAmt.ToString("#0.00");
        //        HEducessAmt = (TotalAmount * Convert.ToDouble(txtHEduCessRate.Text)) / 100;
        //        txtHEduCessAmt.Text = HEducessAmt.ToString("#0.00");
        //        AmtwithExcise = TotalAmount + ExciseAmt;
        //        txtAmtwithExcise.Text = AmtwithExcise.ToString("#0.00");
        //        CSTAmt = (AmtwithExcise * Convert.ToDouble(txtCSTRate.Text)) / 100;
        //        txtCSTAmt.Text = CSTAmt.ToString("#0.00");
        //        VATAmt = (AmtwithExcise * Convert.ToDouble(txtVATRate.Text)) / 100;
        //        txtVATAmt.Text = VATAmt.ToString("#0.00");
        //        AVATAmt = (AmtwithExcise * Convert.ToDouble(txtAVATRate.Text)) / 100;
        //        txtAVATAmt.Text = AVATAmt.ToString("#0.00");

        //        NetAmt = ServiceAmt + AmtwithExcise + CSTAmt + VATAmt + AVATAmt + EducessAmt + HEducessAmt;
        //        txtNetAmount.Text = NetAmt.ToString("#0.00");
        //    }
        //    catch (Exception exc)
        //    {
        //        Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
        //        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
        //    }
        //}
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

                double SBCessAmt = 0;
                double ExtraTaxAmt = 0;
                double NetAmt = 0;

                if (txtdiscopunt.Text != "0.00")
                {
                    TotalAmount = Convert.ToDouble(txtamtdiscount.Text);
                }

                //double WeightInch = 0;
                //double HeightInch = 0;


                txtAmount.Text = (Convert.ToDouble(txtQty.Text) * Convert.ToDouble(txtRate.Text)).ToString("#0.00");
                ServiceAmt = (TotalAmount * Convert.ToDouble(txtServiceTax.Text)) / 100;
                txtServiceAmt.Text = ServiceAmt.ToString("#0.00");
                ExciseAmt = (TotalAmount * Convert.ToDouble(txtExciseRate.Text)) / 100;
                txtExciseAmt.Text = ExciseAmt.ToString("#0.00");
                EducessAmt = (TotalAmount * Convert.ToDouble(txtEduCessRate.Text)) / 100;
                txtEduCessAmt.Text = EducessAmt.ToString("#0.00");
                HEducessAmt = (TotalAmount * Convert.ToDouble(txtHEduCessRate.Text)) / 100;
                txtHEduCessAmt.Text = HEducessAmt.ToString("#0.00");
                AmtwithExcise = TotalAmount + ExciseAmt;
                txtAmtwithExcise.Text = AmtwithExcise.ToString("#0.00");
                CSTAmt = (AmtwithExcise * Convert.ToDouble(txtCSTRate.Text)) / 100;
                txtCSTAmt.Text = CSTAmt.ToString("#0.00");
                VATAmt = (AmtwithExcise * Convert.ToDouble(txtVATRate.Text)) / 100;
                txtVATAmt.Text = VATAmt.ToString("#0.00");
                AVATAmt = (AmtwithExcise * Convert.ToDouble(txtAVATRate.Text)) / 100;
                txtAVATAmt.Text = AVATAmt.ToString("#0.00");

                SBCessAmt = (AmtwithExcise * Convert.ToDouble(txtSBCessRate.Text)) / 100;
                txtSBCessAmt.Text = SBCessAmt.ToString("#0.00");

                ExtraTaxAmt = (AmtwithExcise * Convert.ToDouble(txtExtraTaxRate.Text)) / 100;
                txtExtraTaxAmt.Text = ExtraTaxAmt.ToString("#0.00");

                // NetAmt = ServiceAmt + AmtwithExcise + CSTAmt + VATAmt + AVATAmt + EducessAmt + HEducessAmt;
                NetAmt = ServiceAmt + TotalAmount + CSTAmt + VATAmt + AVATAmt + EducessAmt + HEducessAmt + SBCessAmt + ExtraTaxAmt + ExciseAmt;
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
                if (Convert.ToInt16(cmbgodown.SelectedValue) == 0)
                {
                    MessageBox.Show("First Select Godown.");
                    cmbgodown.Focus();
                    return;
                }
                else
                {
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_FYID", CurrentUser.FYID.ToString());
                    para.Add("@i_GodownID", cmbgodown.SelectedValue.ToString());
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                    frmItemLOV fLOV = new frmItemLOV("usp_Item_LOV", para);
                    fLOV.ShowDialog();

                    UID = Convert.ToInt16(fLOV.ItemID);
                    txtItemName.Text = fLOV.ItemName;
                    txtItemDesc.Text = fLOV.Specification;
                    LoadItemList();
                    if (fLOV.ItemName == null)
                    {
                        //  _ItemID = 0;
                        //       txtQty.Text = "0.000";
                        //   txtQOH.Text = "";
                        //   txtUOM.Text = "";
                    }
                    else
                    {
                        DataView dvItem = new DataView();
                        dvItem = dtItemList.DefaultView;
                        dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "' and ItemID = '" + UID + "' ";

                        DataTable dtTempItem = new DataTable();
                        dtTempItem = dvItem.ToTable();

                        if (dtTempItem.Rows.Count > 0)
                        {
                            lblErrorMessage.Text = "No error";
                            _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                            txtQOH.Text = dtTempItem.Rows[0]["QOH"].ToString();
                            txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                            txtRate.Text = dtTempItem.Rows[0]["Price"].ToString();
                            txtItemDesc.Text = dtTempItem.Rows[0]["Specification"].ToString();
                            cmbCurrency.SelectedValue = Convert.ToInt64(dtTempItem.Rows[0]["CurrencyID"].ToString());
                            btnSaveExit.Enabled = true;
                            txtQty.Focus();
                            //txtQty.Text = "0.000";
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


            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void UpdateOutputDatatable()
        {

            DataRow dr;
            dr = _dtDetail.NewRow();
            dr["GodownID"] = Convert.ToInt64(cmbgodown.SelectedValue);
            dr["ItemID"] = _ItemID;
            dr["ItemName"] = txtItemName.Text;
            dr["UOM"] = txtUOM.Text;
            dr["Qty"] = Convert.ToDecimal(txtQty.Text);
            dr["Rate"] = Convert.ToDecimal(txtRate.Text);

            dr["CurrencyID"] = cmbCurrency.SelectedValue;
            dr["Currency"] = cmbCurrency.Text;

            dr["TotalAmount"] = Convert.ToDecimal(txtAmount.Text);
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

            dr["SBCessRate"] = Convert.ToDecimal(txtSBCessRate.Text);
            dr["SBCessAmount"] = Convert.ToDecimal(txtSBCessAmt.Text);

            dr["ExtraTaxRate"] = Convert.ToDecimal(txtExtraTaxRate.Text);
            dr["ExtraTaxAmount"] = Convert.ToDecimal(txtExtraTaxAmt.Text);

            dr["NetAmount"] = Convert.ToDecimal(txtNetAmount.Text);
            dr["ItemDesc"] = txtItemDesc.Text;
            dr["Discount"] = txtdiscopunt.Text;
            ItemDiscountAmt = ((Convert.ToDecimal(txtAmount.Text) * Convert.ToDecimal(txtdiscopunt.Text)) / 100);
            //dr["DiscountAmt"] = ItemDiscAmt.ToString();
            // _ItemDiscAmt = _ItemDiscAmt;
            _dtDetail.Rows.Add(dr);
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataValidator.IsValid(this.grpData))
                {
                    //-------------------for check currency difference ------------------
                    if (_dtDetail.Rows.Count > 0)
                    {
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            if (Convert.ToInt16(cmbgodown.SelectedValue) > 0)
                            {
                                if (cmbCurrency.SelectedValue.ToString() != _CurrencyID.ToString())
                                {
                                    MessageBox.Show("You can not select this currency", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    cmbCurrency.Focus();
                                }
                                else
                                {
                                    UpdateOutputDatatable();
                                    this.Dispose();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Select Godown.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        if (_Mode == (int)Common.Constant.Mode.Modify)
                        {

                            if (cmbCurrency.SelectedValue.ToString() != _CurrencyID.ToString())
                            {
                                // MessageBox.Show("Currency you will change now will be affected to all items", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                if ((MessageBox.Show(("Currency you will change now will be affected to all items" + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                                {
                                    if (_dtDetail.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < _dtDetail.Rows.Count; i++)
                                        {
                                            DataRow drr = _dtDetail.Rows[i];
                                            if (Convert.ToInt32(drr["ItemID"]) == _ItemID_Edit && Convert.ToInt32(drr["GodownID"]) == _GodownID_Edit)
                                            {
                                                _dtDetail.Rows.Remove(drr);
                                            }
                                        }
                                    }

                                    UpdateOutputDatatable();

                                    for (int i = 0; i < _dtDetail.Rows.Count; i++)
                                    {
                                        _dtDetail.Rows[i]["Currency"] = cmbCurrency.Text;
                                        _dtDetail.Rows[i]["CurrencyID"] = cmbCurrency.SelectedValue;
                                    }
                                    this.Dispose();
                                }
                                else
                                {
                                    cmbCurrency.Focus();
                                }
                            }
                            else
                            {
                                if (_dtDetail.Rows.Count > 0)
                                {
                                    for (int i = 0; i < _dtDetail.Rows.Count; i++)
                                    {
                                        DataRow drr = _dtDetail.Rows[i];
                                        if (Convert.ToInt32(drr["ItemID"]) == _ItemID_Edit && Convert.ToInt32(drr["GodownID"]) == _GodownID_Edit)
                                        {
                                            _dtDetail.Rows.Remove(drr);
                                        }
                                    }
                                }

                                UpdateOutputDatatable();

                                for (int i = 0; i < _dtDetail.Rows.Count; i++)
                                {
                                    _dtDetail.Rows[i]["Currency"] = cmbCurrency.Text;
                                    _dtDetail.Rows[i]["CurrencyID"] = cmbCurrency.SelectedValue;
                                }

                                this.Dispose();
                            }

                        }
                    }
                    else
                    {
                        if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            if (_dtDetail.Rows.Count > 0)
                            {
                                for (int i = 0; i < _dtDetail.Rows.Count; i++)
                                {
                                    DataRow drr = _dtDetail.Rows[i];
                                    if (Convert.ToInt32(drr["ItemID"]) == _ItemID_Edit && Convert.ToInt32(drr["GodownID"]) == _GodownID_Edit)
                                    {
                                        _dtDetail.Rows.Remove(drr);
                                    }
                                }
                            }
                            UpdateOutputDatatable();
                            for (int i = 0; i < _dtDetail.Rows.Count; i++)
                            {
                                _dtDetail.Rows[i]["Currency"] = cmbCurrency.Text;
                                _dtDetail.Rows[i]["CurrencyID"] = cmbCurrency.SelectedValue;
                            }
                            this.Dispose();
                        }
                        else
                        {
                            if (Convert.ToInt16(cmbgodown.SelectedValue) > 0)
                            {
                                UpdateOutputDatatable();
                                this.Dispose();
                            }
                            else
                            {
                                MessageBox.Show("Select Godown.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    //----------------------  

                    //if (_Mode == (int)Common.Constant.Mode.Modify)
                    //{
                    //    if (_dtDetail.Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < _dtDetail.Rows.Count; i++)
                    //        {
                    //            DataRow drr = _dtDetail.Rows[i];
                    //            if (Convert.ToInt32(drr["ItemID"]) == _ItemID_Edit)
                    //            {
                    //                _dtDetail.Rows.Remove(drr);
                    //            }
                    //        }
                    //    }
                    //    UpdateOutputDatatable();
                    //    this.Dispose();
                    //}
                    //else
                    //{
                    //    if (Convert.ToInt16(cmbgodown.SelectedValue) > 0)
                    //    {
                    //        UpdateOutputDatatable();
                    //        this.Dispose();
                    //    }
                    //}
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
            txtamtdiscount.Text = (Convert.ToDecimal(txtAmount.Text) - ((Convert.ToDecimal(txtAmount.Text) * Convert.ToDecimal(txtdiscopunt.Text)) / 100)).ToString();
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
                                txtSBCessRate.Text = dtTaxClass.Rows[0]["SBCess"].ToString();
                                txtExtraTaxRate.Text = dtTaxClass.Rows[0]["ExtraTax"].ToString();
                                lblExtraTax.Text = dtTaxClass.Rows[0]["ExtraTaxType"].ToString();
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

        private void txtdiscopunt_Leave(object sender, EventArgs e)
        {
            if (txtdiscopunt.Text != "0.00")
            {
                // _ItemDiscAmt = ((Convert.ToDecimal(txtAmount.Text) * Convert.ToDecimal(txtdiscopunt.Text)) / 100);
                txtamtdiscount.Text = (Convert.ToDecimal(txtAmount.Text) - ((Convert.ToDecimal(txtAmount.Text) * Convert.ToDecimal(txtdiscopunt.Text)) / 100)).ToString();
                txtAmtwithExcise.Text = (Convert.ToDecimal(txtamtdiscount.Text) + Convert.ToDecimal(txtExciseAmt.Text)).ToString("#0.00");
                txtNetAmount.Text = (Convert.ToDouble(txtServiceAmt.Text) + Convert.ToDouble(txtAmtwithExcise.Text) + Convert.ToDouble(txtCSTAmt.Text) + Convert.ToDouble(txtVATAmt.Text) + Convert.ToDouble(txtAVATAmt.Text) + Convert.ToDouble(txtEduCessAmt.Text) + Convert.ToDouble(txtHEduCessAmt.Text)).ToString("#0.00");
            }
            CalculateNetAmount();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {

                DataView dvItem = new DataView();//added by rooja for item autosearch data fill
                dvItem = dtItemList.DefaultView;
                if (txtItemName.Text != "")
                {
                    dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";
                }
                DataTable dtTempItem = new DataTable();
                dtTempItem = dvItem.ToTable();

                if (dtTempItem.Rows.Count > 0)
                {
                    lblErrorMessage.Text = "No error";
                    _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                    txtQOH.Text = dtTempItem.Rows[0]["QOH"].ToString();
                    txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                    txtRate.Text = dtTempItem.Rows[0]["Price"].ToString();
                    txtItemDesc.Text = dtTempItem.Rows[0]["Specification"].ToString();
                    txtQty.Focus();
                    //btnSaveExit.Enabled = true;
                    // txtQty.Text = "0.000";
                }
                else
                {
                    if (txtItemName.Text != "")
                    {
                        lblErrorMessage.Text = "Invalid item";
                        _ItemID = 0;
                        txtQOH.Text = "0.000";
                        txtUOM.Text = "";
                        txtItemName.Focus();
                        btnSaveExit.Enabled = false;
                        txtQty.Text = "0.000";
                    }
                    //if (txtItemName.Text != "")
                    //{
                    //    MessageBox.Show("Item does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txtItemName.Focus();
                    //}
                }
            }
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {

                    DataView dvItem = new DataView();//added by rooja for item autosearch data fill
                    dvItem = dtItemList.DefaultView;
                    if (txtItemName.Text != "")
                    {
                        dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";
                    }
                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();

                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                        txtQOH.Text = dtTempItem.Rows[0]["QOH"].ToString();
                        txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                        txtRate.Text = dtTempItem.Rows[0]["Price"].ToString();
                        txtItemDesc.Text = dtTempItem.Rows[0]["Specification"].ToString();
                        txtQty.Focus();
                        //btnSaveExit.Enabled = true;
                        // txtQty.Text = "0.000";
                    }
                    else
                    {
                        if (txtItemName.Text != "")
                        {
                            lblErrorMessage.Text = "Invalid item";
                            _ItemID = 0;
                            txtQOH.Text = "0.000";
                            txtUOM.Text = "";
                            txtItemName.Focus();
                            btnSaveExit.Enabled = false;
                            txtQty.Text = "0.000";
                        }
                        //if (txtItemName.Text != "")
                        //{
                        //    MessageBox.Show("Item does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    txtItemName.Focus();
                        //}
                    }
                }
            }
        }

        private void cmbCurrency_Leave(object sender, EventArgs e)
        {
            if (_dtDetail.Rows.Count > 0)
            {
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    if (cmbCurrency.SelectedValue.ToString() != _CurrencyID.ToString())
                    {
                        MessageBox.Show("You can not select this currency", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cmbCurrency.Focus();
                    }
                }

                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    if (_IsFirstItem == false)
                    {

                        if (cmbCurrency.SelectedValue.ToString() != _CurrencyID.ToString())
                        {
                            MessageBox.Show("You can not select this currency", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cmbCurrency.Focus();
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        // MessageBox.Show("Currency you will change now will be affected to all items", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if ((MessageBox.Show(("Currency you will change now will be affected to all items" + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {

                        }
                        else
                        {
                            cmbCurrency.Focus();
                        }
                    }
                }
            }
        }

    }
}
