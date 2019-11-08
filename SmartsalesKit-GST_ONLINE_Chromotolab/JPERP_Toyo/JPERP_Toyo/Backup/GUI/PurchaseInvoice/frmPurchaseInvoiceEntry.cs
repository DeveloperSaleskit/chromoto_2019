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
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;
namespace Account.GUI.PurchaseInvoice
{
    public partial class frmPurchaseInvoiceEntry : Account.GUIBase
    {
        #region "Variable Declaration..."
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        Exception mException = null;
        string mErrorMsg = "";

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelete = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        POBL objPOBL = new POBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtVendor = new DataTable();
        DataTable dtPIDetail = new DataTable();
        Int64 _VendorID = 0;
        long _PIID = 0;
        int _Mode = 0;

        string SelectedFileName = "";
        DataTable dtDocList = new DataTable();

        public bool Is_MailSend;
        int CompId = 0;
        int _CompId = 0;

        #endregion

        #region "Form Events...."

        public frmPurchaseInvoiceEntry(int Mode, Int64 PIID)
        {
            InitializeComponent();
            _Mode = Mode;
            _PIID = PIID;
        }

        private void frmPurchaseInvoiceEntry_Load(object sender, EventArgs e)
        {


            AddHandlers(this);
            SetControlsDefaults(this);
            //DataValidator.SetDefaultDate(dtpPIDate, null, null);
            dgvPIDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            objCommon.FillGodownCombo(cmbgodown);

            dtDocList.Columns.Add("QDocID");
            dtDocList.Columns.Add("FileName");
            dtDocList.Columns.Add("FullFileName");
            _CompId = CurrentCompany.CompId;
            cmbgodown.SelectedValue = 1;
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                LoadVendorList();
                LoadPIDetailList();
                dtpPIDate.Value = DateTime.Now;
                txtPINo.Text = objCommon.AutoNumber("PO");
                this.Text = "Purchase Order - New";

            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                ErrItemName.Visible = false;
                BindControl();
                chkTNC.Enabled = false;
                btnGeneratePI.Text = "Save";
                btnVendorLOV.Visible = false;
                txtVendor.ReadOnly = true;
                this.Text = "Purchase Order - Edit";
                btnRegenrate.Visible = false;
                btnGeneratePI.Width = btnCancel.Width;
                btnGeneratePI.Location = new Point(btnGeneratePI.Location.X + 95, btnGeneratePI.Location.Y);
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
                this.Text = "Purchase Order - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public bool isRecordSave(string retMsg)
        {
            if (retMsg == null)
            {
                return false;
            }
            if (retMsg.Length > 0)
            {
                Int32 dummyInt;
                try
                {
                    dummyInt = Int32.Parse(retMsg);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

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

                DataColumn clmDDate = new DataColumn("DDate");
                clmDDate.DataType = System.Type.GetType("System.DateTime");
                dtPIDetail.Columns.Add(clmDDate);


                ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
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
                dgvPIDetail.Columns["DDate"].DataPropertyName = dtPIDetail.Columns["DDate"].ToString();


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
                ds = CommSelect.SelectDataSetRecord(_PIID, "usp_PO_Select", "PurchaseInvoice - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            dgvPIDetail.AutoGenerateColumns = false;
                            dgvPIDetail.DataSource = ds.Tables[2];
                            dtPIDetail = ds.Tables[2];
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
                            txtDuedays.Text = ds.Tables[0].Rows[0]["DueDays"].ToString();
                            dtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"]);
                            txtNarration.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
                            txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                            txtPaidAmount.Text = ds.Tables[0].Rows[0]["PaidAmount"].ToString();
                            txtSrNo.Text = ds.Tables[0].Rows[0]["SrNo"].ToString();
                            cmbgodown.SelectedValue = ds.Tables[0].Rows[0]["GodownID"].ToString();
                            txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            txtcc.Text = ds.Tables[0].Rows[0]["CC"].ToString();
                            txtbcc.Text = ds.Tables[0].Rows[0]["BCC"].ToString();
                            txtCustInvoiceNo.Text = ds.Tables[0].Rows[0]["CustInvoiceNo"].ToString();
                            txtmobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                          
                            //if (dtQuotation.Tables[0].Rows[0]["Is_SendMail"].ToString() == "True")
                            //{
                            //    MailStatus = true;
                            //}
                            //else
                            //{
                            //    MailStatus = false;
                            //}
                            // lblMailCheck.Text = dtQuotation.Tables[0].Rows[0]["Is_SendMail"].ToString();
                            /* code for Docs open*/

                            if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                            {
                                foreach (DataRow DRow in ds.Tables[1].Rows)
                                {
                                    DataRow dr = dtDocList.NewRow();
                                    dr["QDocID"] = DRow["QDocID"].ToString();
                                    dr["FileName"] = DRow["DocName"].ToString();
                                    dr["FullFileName"] = DRow["DocName"].ToString();
                                    // dr["DocRemark"] = DRow["Remarks"].ToString();
                                    dtDocList.Rows.Add(dr);
                                }
                                ArrangeDocumentGridView();
                                dgvCountry.AutoGenerateColumns = false;
                                dgvCountry.DataSource = dtDocList;
                                ArrangeDocumentGridView();
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
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void DeletePI()
        {
            try
            {
                CommDelete.DeleteRecordWithGodown(_PIID, "usp_PO_Delete", "PurchaseInvoice - Delete", Convert.ToInt16(cmbgodown.SelectedValue));
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
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button Event..."

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtPINo.Text = objCommon.AutoNumber("PO");
        }

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                //NameValueCollection para1 = new NameValueCollection();
                //_CompId = CurrentCompany.CompId;
                //para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                //frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId, "usp_Customer_LOV", para1);

                frmVendorLOV fLOV = new frmVendorLOV();
                fLOV.ShowDialog();

                txtVendor.Text = fLOV.VendorName;
                txtemail.Text = fLOV.Fax;
                txtmobile.Text = fLOV.MobileNo;
                _VendorID = fLOV.VendorID;
                if (fLOV.VendorName == null)
                {
                    _VendorID = 0;
                    //  dgvPIDetail.DataSource = null;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnGeneratePI_Click(object sender, EventArgs e)
        {
            try
            {
                bool ReturnValue = false;
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
                            XMLString = XMLString + "<DDate>" + Convert.ToDateTime(dtPIDetail.Rows[i]["DDate"]).ToString("MM/dd/yyyy") + "</DDate>";
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
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            //Int32 PIID = 0;
                            objPOBL.Insert(txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value), txtSrNo.Text, txtVoucherno.Text,
                                                    Convert.ToDateTime(dtpVoucherDate.Value), _VendorID, Convert.ToInt64(txtDuedays.Text),
                                                    Convert.ToDateTime(dtpDueDate.Value), Convert.ToDecimal(txtServiceAmt.Text),
                                                    Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                                    Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                                    Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                                    Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text),
                                                    Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text),
                                                    Convert.ToDecimal(txtPaidAmount.Text), txtNarration.Text, XMLString, Cnt,
                                                    Convert.ToInt32(cmbgodown.SelectedValue), txtcc.Text, txtbcc.Text, Is_MailSend, CompId, txtCustInvoiceNo.Text);

                            if (objPOBL.Exception == null)
                            {
                                if (objPOBL.ErrorMessage != "" || _PIID > 0)
                                {
                                    if (isRecordSave(objPOBL.ErrorMessage))
                                    {
                                        if (_PIID == 0)
                                            _PIID = Convert.ToInt64(objPOBL.ErrorMessage);
                                        //-----for doc save--------
                                        foreach (DataRow dr in dtDocList.Rows)
                                        {
                                            if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                            {
                                                // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                            }
                                            else
                                            {
                                                string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                                objPOBL.InsertPODocument(_PIID, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                                if (objPOBL.Exception == null)
                                                {
                                                    if (objPOBL.ErrorMessage == "")
                                                    {
                                                        File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                    }
                                                }
                                            }
                                        }

                                        //-------------------

                                        if (chkTNC.Checked == true)
                                        {
                                            NameValueCollection para1 = new NameValueCollection();
                                            para1.Add("@i_TNC_SUB", "PURCHASE");
                                            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                                            DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                                            //for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                            //{
                                            //    objPOBL.InsertTNC("SALES", dtAllTNC.Rows[i][0].ToString(), txtPINo.Text);
                                            //}

                                            long Cnt2 = 0;
                                            string XMLString2 = string.Empty;

                                            XMLString2 = "<NewDataSet>";
                                            for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                            {
                                                XMLString2 = XMLString2 + "<Table>";
                                                XMLString2 = XMLString2 + "<Code>" + txtPINo.Text + "</Code>";
                                                XMLString2 = XMLString2 + "<TNC_Sub>" + "PURCHASE" + "</TNC_Sub>";
                                                //XMLString = XMLString + "<ItemODesc>" + dtPIDetail.Rows[i]["ItemODesc"] + "</ItemODesc>";
                                                XMLString2 = XMLString2 + "<TNC_Desc>" + dtAllTNC.Rows[i]["TNC_Desc"].ToString() + "</TNC_Desc>";
                                                XMLString2 = XMLString2 + "<CompId>" + CurrentCompany.CompId.ToString() + "</CompId>";

                                                XMLString2 = XMLString2 + "</Table> ";
                                                Cnt2 = Cnt2 + 1;
                                            }

                                            XMLString2 = XMLString2.ToString().Replace("&", "&amp;") + "</NewDataSet>";

                                            objPOBL.InsertTNC_NEW(XMLString2, Cnt2);

                                        }
                                        //--------------------------------------

                                        if (chksend.Checked == true)
                                        {
                                            SendToMail();
                                        }

                                        //lblErrorMessage.Text = objPOBL.ErrorMessage;
                                        //dtpPIDate.Focus();
                                        //return;

                                        lblErrorMessage.Text = "No error";
                                        ReturnValue = true;
                                        this.Dispose();
                                        //return;
                                    }
                                    else
                                    {
                                        lblErrorMessage.Text = objPOBL.ErrorMessage;
                                        ReturnValue = false;
                                        //return;
                                    }
                                }
                                else
                                {
                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                    this.Dispose();
                                }
                            }
                            else
                            {
                                MessageBox.Show(objPOBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }

                        }
                        else
                        {
                            objPOBL.Update(_PIID, txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value), txtSrNo.Text, txtVoucherno.Text,
                                            Convert.ToDateTime(dtpVoucherDate.Value), _VendorID, Convert.ToInt64(txtDuedays.Text),
                                            Convert.ToDateTime(dtpDueDate.Value), Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtServiceAmt.Text),
                                            Convert.ToDecimal(txtExciseAmt.Text), Convert.ToDecimal(txtEduCessAmt.Text),
                                            Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text),
                                            Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text),
                                            Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text),
                                            txtNarration.Text, XMLString, Cnt, Convert.ToInt32(cmbgodown.SelectedValue), txtcc.Text, txtbcc.Text, Is_MailSend, CompId, txtCustInvoiceNo.Text);

                            if (objPOBL.Exception == null)
                            {
                                if (objPOBL.Exception == null)
                                {
                                    //--for doc save code
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            objPOBL.InsertPODocument(_PIID, dr["FileName"].ToString());
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objPOBL.InsertPODocument(_PIID, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objPOBL.Exception == null)
                                            {
                                                if (objPOBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                }
                                            }
                                        }
                                    }
                                    //---------------

                                    if (chksend.Checked == true)
                                    {
                                        SendToMail();
                                    }

                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                    this.Close();
                                }
                                else
                                {
                                    lblErrorMessage.Text = objPOBL.ErrorMessage;

                                    ReturnValue = false;
                                }
                            }
                            //if (objPOBL.ErrorMessage != "")
                            //{
                            //    lblErrorMessage.Text = objPOBL.ErrorMessage;
                            //    dtpPIDate.Focus();
                            //    return;
                            //}
                            //else
                            //{
                            //    this.Dispose();
                            //}

                            else
                            {
                                MessageBox.Show(objPOBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }
                        }
                        //if (chksend.Checked == true)
                        //{
                        //    SendToMail();
                        //}

                        //if (objPOBL.Exception == null)
                        //{
                        //    if (objPOBL.ErrorMessage != "")
                        //    {
                        //        lblErrorMessage.Text = objPOBL.ErrorMessage;
                        //        dtpPIDate.Focus();
                        //        return;
                        //    }
                        //    else
                        //    {
                        //        this.Dispose();
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(objPOBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}


                    }
                }
                ReturnValue = false;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                this.Close();
                objPOBL.DeleteTNC_On_Close("PURCHASE", txtPINo.Text);
            }
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
                PurchaseInvoice.frmPurchaseInvoiceItemEntry fPIEntry = new PurchaseInvoice.frmPurchaseInvoiceItemEntry((int)Constant.Mode.Insert, _PIID, _VendorID, dtpPIDate.Value, dtPIDetail, godown, 0, 0);
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

        #region "User Defined Functions"
        public void SendToMail()
        {
            try
            {
                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                DataTable dtPurchaseId = new DataTable();
                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_Code", txtPINo.Text);
                dtPurchaseId = objDA.ExecuteDataTableSP("usp_PO_Id", para1, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");

                frmPurchaseInvoiceList PL = new frmPurchaseInvoiceList();
                PL.RPT_Sub(Convert.ToInt64(dtPurchaseId.Rows[0][0].ToString()), txtPINo.Text, false);

                //string pdfname = QL.PdfFile;

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Purchase");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");
                if (dtEmail.Rows.Count > 0)
                {

                    vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    vSubject = dtEmail.Rows[0][0].ToString() + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
                    vDetails += "<br /><br />";
                    vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY
                    vDetails += "<br><br>";

                    //vDetails += " <BR> <BR> <b>Sale No : " + txtPINo.Text + "</b>"; // DETAIL PART OF BODY
                    //vDetails += "<BR> <BR>  <b> Date : " + dtpPIDate.Value.Day + "/" + dtpPIDate.Value.Month + "/" + dtpPIDate.Value.Year + "</b><BR> <BR>";
                    //if (dgvPIDetail.Rows.Count > 0)
                    //{
                    //    vDetails += "<html><head><title></title></head><body><table style=&quot;width: 100%;&quot; border=&quot;1&quot;>" +
                    //           "<tr align=&quot;center&quot; style=&quot;font-weight: bold&quot;><td>ITEM</td><td>QTY</td><td>UOM</td>" +
                    //           "<td>RATE</td><td>AMOUNT</td></tr>";
                    //}

                    //for (int i = 0; i < dgvPIDetail.RowCount; i++)
                    //{
                    //    vDetails += "<tr><td align=&quot;left&quot;> " + dgvPIDetail.Rows[i].Cells["ItemName"].Value.ToString() +
                    //                "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["Qty"].Value.ToString() +
                    //                "</td><td align=&quot;left&quot;>" + dgvPIDetail.Rows[i].Cells["UOM"].Value.ToString() +
                    //                "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["Rate"].Value.ToString() +
                    //                "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["TotalAmount"].Value.ToString() +
                    //                "</td></tr>";
                    //}

                    //vDetails += "</table></body></html>";
                    //vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text + "</b>";

                    //vDetails += "<br /><br />";
                    //vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY



                    //vDetails += "<br><br>";

                    if (txtcc.Text.Trim() != "")
                    {
                        vMail.CC.Add(txtcc.Text);
                    }
                    if (txtbcc.Text.Trim() != "")
                    {
                        vMail.Bcc.Add(txtbcc.Text);
                    }
                    vMail.Subject = vSubject;
                    vMail.Body = vDetails;
                    vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\pdf\Purchase.pdf"));

                    vMail.IsBodyHtml = true;

                    System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
                    System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(CurrentCompany.Con_Email, CurrentCompany.Con_Password);

                    //vSmpt.Host = "smtp.gmail.com";
                    //vSmpt.Port = 25;
                    //vSmpt.EnableSsl = false;
                    //vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    vSmpt.Host = CurrentCompany.Host;
                    vSmpt.Port = CurrentCompany.Port;
                    vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //vSmpt.UseDefaultCredentials = false; 
                    if (CurrentCompany.ssl == 0)
                    {
                        vSmpt.EnableSsl = true;
                    }
                    else if (CurrentCompany.ssl == 1)
                    {
                        vSmpt.EnableSsl = false;
                    }
                    vSmpt.Credentials = SmtpUser;
                    vSmpt.Send(vMail);
                    MessageBox.Show("Mail has been sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vMail.Dispose();
                    //if (File.Exists(CurrentUser.DocumentPath + @"\pdf\Purchase.pdf"))
                    //{
                    //    File.Delete(CurrentUser.DocumentPath + @"\pdf\Purchase.pdf");
                    //}

                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Purchase.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email" + ex);
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
            if (dgvPIDetail.Rows.Count >= 1)
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
                    //_PIID = PGID;
                    _ID = 1;
                }
                int godown = Convert.ToInt32(cmbgodown.SelectedValue);
                PurchaseInvoice.frmPurchaseInvoiceItemEntry fPIEntry = new PurchaseInvoice.frmPurchaseInvoiceItemEntry((int)Constant.Mode.Modify, _PIID, _VendorID, dtpPIDate.Value, dtPIDetail, godown, ItemID_Edit, _ID);
                fPIEntry.ShowDialog();
                dgvPIDetail.AutoGenerateColumns = false;
                dgvPIDetail.DataSource = dtPIDetail;
                ArrangePIDetailGridView();
                CalculateNetAmount();

            }

            //lblErrorMessage.Text = "";
            //string StrItem = "#";
            //for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
            //{
            //    StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
            //}
            //// int godown = Convert.ToInt32(cmbgodown.SelectedValue);
            //int ItemID_Edit = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["ItemID"].Value);
            //int _ID = 0;
            //if (_Mode == (int)Common.Constant.Mode.Insert)
            //{
            //    //_PIID = PGID;
            //    _ID = 1;
            //}
            //int godown = Convert.ToInt32(cmbgodown.SelectedValue);
            //PurchaseInvoice.frmPurchaseInvoiceItemEntry fPIEntry = new PurchaseInvoice.frmPurchaseInvoiceItemEntry((int)Constant.Mode.Modify, _PIID, _VendorID, dtpPIDate.Value, dtPIDetail, godown, ItemID_Edit, _ID);
            //fPIEntry.ShowDialog();
            //dgvPIDetail.AutoGenerateColumns = false;
            //dgvPIDetail.DataSource = dtPIDetail;
            //ArrangePIDetailGridView();
            //CalculateNetAmount();
        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtPTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtPTNC = objDA.ExecuteDataTableSP("usp_PurchaseTNC_Select", para, false, ref mException, ref mErrorMsg, "Purchase TNC - Select");

                if (dtPTNC.Rows.Count > 0)
                {
                    frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_PurchaseTNC_Select", para, txtPINo.Text, "PURCHASE");
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
                    //TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                }
                else
                {

                    frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_TNC_LOV", null, txtPINo.Text, "PURCHASE");
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtDocName.Text = ofd.SafeFileName;
                SelectedFileName = ofd.FileName;
            }
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            //-----------------

            if (txtDocName.Text == "")
            {
                txtDocName.Focus();
                return;
            }
            DataRow dr = dtDocList.NewRow();
            dr["QDocID"] = "0";
            //dr["BlockID"] = "0";
            dr["FileName"] = txtDocName.Text;
            dr["FullFileName"] = SelectedFileName;
            //dr["DocRemark"] = txtComment.Text;
            dtDocList.Rows.Add(dr);

            ArrangeDocumentGridView();
            dgvCountry.AutoGenerateColumns = false;
            dgvCountry.DataSource = dtDocList;
            ArrangeDocumentGridView();
            txtDocName.Text = "";
            SelectedFileName = "";
            //txtComment.Text = "";
            btnAddDoc.Focus();
        }

        public void ArrangeDocumentGridView()
        {
            dgvCountry.Columns["FileName"].DataPropertyName = dtDocList.Columns["FileName"].ToString();
            dgvCountry.Columns["FullFileName"].DataPropertyName = dtDocList.Columns["FullFileName"].ToString();
            //dgvCountry.Columns["BlockId"].DataPropertyName = dtDocList.Columns["BlockId"].ToString();
            dgvCountry.Columns["QDocID"].DataPropertyName = dtDocList.Columns["QDocID"].ToString();
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (dgvCountry.CurrentRow != null)
            {
                int RowIndex = dgvCountry.CurrentRow.Index;
                string DelFileName = dtDocList.Rows[RowIndex]["FullFileName"].ToString();
                string DelFileName1 = CurrentUser.DocumentPath.ToString();

                //File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                if (File.Exists(CurrentUser.DocumentPath + DelFileName))
                {
                    File.Delete(CurrentUser.DocumentPath + DelFileName);
                }
                dtDocList.Rows[RowIndex].Delete();
                dtDocList.AcceptChanges();

                dgvCountry.AutoGenerateColumns = false;
                dgvCountry.DataSource = dtDocList;
                ArrangeDocumentGridView();


            }
        }

        private void dgvCountry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 0)
                {
                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        MessageBox.Show("Please save record and then you can edit document in Edit Sale record.");
                        return;
                    }
                    string strFile;
                    strFile = CurrentUser.DocumentPath + dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();

                    Process.Start(strFile);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void chkTNC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTNC.Checked == true)
            {
                btnTNC.Enabled = false;
            }
            else
            {
                btnTNC.Enabled = true;
            }
        }
        private IDockContent FindDocument(string text)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel1.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        content.DockHandler.Show();
                        return content;
                    }
                }
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendorEntry fLOV = new frmVendorEntry();
                fLOV.ShowDialog();
            }
            catch (Exception)
            {
                
                throw;
            }
        }



    }
}
