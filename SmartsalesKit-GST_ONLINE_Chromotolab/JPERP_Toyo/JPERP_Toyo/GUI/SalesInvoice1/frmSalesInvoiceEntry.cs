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
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;

namespace Account.GUI.SalesInvoice
{
    public partial class frmSalesInvoiceEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelete = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        DataTable dtDocList = new DataTable();
        SalesInvoiceBL objPOBL = new SalesInvoiceBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtCustomer = new DataTable();
        DataTable dtPIDetail = new DataTable();
        Int64 _CustomerID = 0;
        Int64 _QuotationID = 0;
        long _PIID = 0;
        Int64 _SaleId = 0;
        int _Mode = 0;
        string SelectedFileName = "";

        Exception mException = null;
        string mErrorMsg = "";
        #endregion

        #region "Form Events...."

        public frmSalesInvoiceEntry(int Mode, Int64 PIID)
        {
            InitializeComponent();
            _Mode = Mode;
            _PIID = PIID;
            _SaleId = PIID;
        }

        private void frmSalesInvoiceEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            DataValidator.SetDefaultDate(dtpPIDate, null, null);
            objCommon.FillEmployeeCombo(cmbAttendedBy);
            dtpReminder.Value = DateTime.Now;
            dtpInstallation.Value = DateTime.Now;
            dgvPIDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtDocList.Columns.Add("DocID");
            dtDocList.Columns.Add("FileName");
            dtDocList.Columns.Add("FullFileName");
            dtDocList.Columns.Add("DocRemark");
            dtDocList.Columns.Add("SaleID");
       
      
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                LoadCustomerList();
                LoadPIDetailList();
                txtPINo.Text = objCommon.AutoNumber("SI");
                this.Text = "Sales Invoice - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                Errcustname.Visible = false;
                BindControl();
                btnGeneratePI.Text = "Save";
                btnCustomerLOV.Visible = false;
                txtCustomer.ReadOnly = true;
                this.Text = "Sales Invoice - Edit";
                btnRegenrate.Visible = false;
                btnGeneratePI.Width = btnCancel.Width;
                btnGeneratePI.Location = new Point(btnGeneratePI.Location.X + 95, btnGeneratePI.Location.Y);
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                btnRegenrate.Visible = false;
                BindControl();
                btnCustomerLOV.Visible = false;
                txtCustomer.ReadOnly = true;
                lblDelMsg.Visible = true;
                btnNew.Visible = false;
                btnDelete.Visible = false;
                SetReadOnlyControls(grpData);
                btnGeneratePI.Text = "Yes";
                btnGeneratePI.Tag = "Click to delete record;";
                btnGeneratePI.Width = btnCancel.Width;
                btnGeneratePI.Location = new Point(btnGeneratePI.Location.X + 95, btnGeneratePI.Location.Y);
                btnCancel.Text = "No";
                this.Text = "Sales Invoice - Delete";
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

                DataColumn clmItemDesc = new DataColumn("ItemDesc");
                clmItemDesc.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmItemDesc);

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

                DataColumn clmServiceRate = new DataColumn("ServiceRate");
                clmServiceRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmServiceRate);

                DataColumn clmServiceAmount = new DataColumn("ServiceAmount");
                clmServiceAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmServiceAmount);

                DataColumn clmExciseRate = new DataColumn("ExciseRate");
                clmExciseRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExciseRate);

                DataColumn clmExciseAmount = new DataColumn("ExciseAmount");
                clmExciseAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExciseAmount);

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

                ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangePIDetailGridView()
        {
            try
            {
                dgvPIDetail.Columns["ItemID"].DataPropertyName = dtPIDetail.Columns["ItemID"].ToString();
                dgvPIDetail.Columns["ItemName"].DataPropertyName = dtPIDetail.Columns["ItemName"].ToString();
                dgvPIDetail.Columns["ItemDesc"].DataPropertyName = dtPIDetail.Columns["ItemDesc"].ToString();
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

                for (int i = 0; i < dgvPIDetail.Columns.Count; i++)
                {
                    dgvPIDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadCustomerList()
        {
            try
            {
                dtCustomer = objList.ListOfRecord("usp_Customer_LOV", null, "Sales Invoice - LoadCustomerList");

                if (objList.Exception == null)
                {
                    txtCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtCustomer.Rows.Count; i++)
                    {
                        Data.Add(dtCustomer.Rows[i]["CustomerName"].ToString());
                    }
                    txtCustomer.AutoCompleteCustomSource = Data;
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
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void BindControl()
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = CommSelect.SelectDataSetRecord(_PIID, "usp_SalesInvoice_Select", "SalesInvoice - BindControl");
                ds1 = CommSelect.SelectDataSetRecord(_SaleId, "usp_SaleDocList_List", "SalesInvoice - BindControl");
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
                            txtPINo.Text = ds.Tables[0].Rows[0]["SalesCode"].ToString();
                            _CustomerID = Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerID"]);
                            dtpPIDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["SalesDate"]);
                       //     txtDCno.Text = ds.Tables[0].Rows[0]["DCNo"].ToString();
                            dtpDCDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DCDate"]);
                            txtCustomer.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            txtDuedays.Text = ds.Tables[0].Rows[0]["DueDays"].ToString();
                         //   dtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"]);
                            txtNarration.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
                            txtPaidAmount.Text = ds.Tables[0].Rows[0]["PaidAmount"].ToString();
                            txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                        //    txtSrNo.Text = ds.Tables[0].Rows[0]["SrNo"].ToString();
                        //    cmbgodown.SelectedValue = ds.Tables[0].Rows[0]["GodownID"].ToString();
                            dtpInstallation.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InstallationDate"]);
                            dtpReminder.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReminderDate"]);
                            txtNoOfServices.Text = ds.Tables[0].Rows[0]["NoofServices"].ToString();
                        //    cmbTypeofSale.SelectedItem = ds.Tables[0].Rows[0]["TypeOfSale"].ToString();
                            cmbAttendedBy.SelectedValue = ds.Tables[0].Rows[0]["EmpID"].ToString();
                            txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            txtmobile.Text = ds.Tables[0].Rows[0]["Phone1"].ToString();
                            txtcontactperson.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                            CalculateNetAmount();
                        }
                        if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {

                            foreach (DataRow DRow in ds.Tables[2].Rows)
                            {
                                DataRow dr = dtDocList.NewRow();
                                dr["DocID"] = DRow["DocID"].ToString();
                                dr["FileName"] = DRow["DocName"].ToString();
                                dr["FullFileName"] = DRow["DocName"].ToString();
                                dr["DocRemark"] = DRow["Remarks"].ToString();
                                dr["SaleID"] = DRow["SaleID"].ToString();
                                dtDocList.Rows.Add(dr);
                            }
                            ArrangeDocumentGridView();
                            dgvCountry.AutoGenerateColumns = false;
                            dgvCountry.DataSource = dtDocList;
                            ArrangeDocumentGridView();
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
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void DeletePI()
        {
            try
            {
                CommDelete.DeleteRecord(_PIID, "usp_SalesInvoice_Delete", "SalesInvoice - Delete");
                if (CommDelete.Exception == null)
                {
                    if (CommDelete.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = CommDelete.ErrorMessage;
                        // ReturnValue = false;
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
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Button Event..."

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtPINo.Text = objCommon.AutoNumber("SI");
        }

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtquotation = new DataTable();
                frmCustomerLOV fLOV = new frmCustomerLOV("usp_Customer_Quotation_LOV", null);
                fLOV.Text = "List Of Customer";
                fLOV.ShowDialog();
                txtCustomer.Text = fLOV.CustomerName;
                _CustomerID = fLOV.CustomerID;
                _QuotationID = fLOV.QuotationID;
                txtemail.Text = fLOV.Email;
                txtAddress1.Text = fLOV.Address;
                txtcontactperson.Text = fLOV.ContactPerson;
                txtmobile.Text = fLOV.Phone1;
                if (fLOV.CustomerName == null)
                {
                    _CustomerID = 0;
                    //dgvPIDetail.DataSource = null;
                }
                if (_QuotationID != 0)
                {
                    dtquotation = CommSelect.SelectRecord(_QuotationID, "usp_Sale_Quotation", "Godown - BindControl");
                    dgvPIDetail.DataSource = dtquotation;
                    dtPIDetail = dtquotation;
                    dgvPIDetail.AutoGenerateColumns = false;
                    ArrangePIDetailGridView();

                }
                CalculateNetAmount();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

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

        private void btnGeneratePI_Click(object sender, EventArgs e)
        {
            try
            {
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
                            XMLString = XMLString + "<ItemDesc>" + dtPIDetail.Rows[i]["ItemDesc"] + "</ItemDesc>";
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
                            XMLString = XMLString + "</Table> ";
                            Cnt = Cnt + 1;
                        }
                        XMLString = XMLString + "</NewDataSet>";
                        //if (Cnt == 0)
                        //{
                        //    lblErrorMessage.Text = "Select at least one item";
                        //    dgvPIDetail.Focus();
                        //    return;
                        //}

                        long Cnt1 = 0;
                        string XMLString1 = string.Empty;
                        dgvServicesReminder.EndEdit();


                        XMLString1 = "<NewDataSet>";
                        for (int i = 0; i < dgvServicesReminder.Rows.Count; i++)
                        {
                            XMLString1 = XMLString1 + "<Table>";
                            XMLString1 = XMLString1 + "<SR_Code>" + dgvServicesReminder.Rows[i].Cells[0].Value.ToString() + "</SR_Code>";
                            XMLString1 = XMLString1 + "<SR_Date>" + Convert.ToDateTime(dgvServicesReminder.Rows[i].Cells[1].Value).ToString("MM/dd/yyyy") + "</SR_Date>";
                            XMLString1 = XMLString1 + "<SR_Done>" + "0" + "</SR_Done>";
                            XMLString1 = XMLString1 + "</Table> ";
                            Cnt1 = Cnt1 + 1;
                        }
                        XMLString1 = XMLString1 + "</NewDataSet>";


                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            Int32 PIID = 0;

                            PIID = objPOBL.Insert(txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value), Convert.ToDateTime(dtpDCDate.Value),
                                _CustomerID,
                                Convert.ToInt64(txtDuedays.Text),
                                Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text),
                                Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), txtNarration.Text,
                                XMLString, Cnt,
                                Convert.ToDateTime(dtpInstallation.Value), Convert.ToDateTime(dtpReminder.Value),
                                Convert.ToInt16(txtNoOfServices.Text), 
                                XMLString1, Cnt1,
                                Convert.ToInt16(cmbAttendedBy.SelectedValue));


                            if (objPOBL.Exception == null)
                            {
                                string error = objPOBL.ErrorMessage;
                                if (objPOBL.ErrorMessage != "" || _SaleId > 0)
                                {
                                    if (isRecordSave(objPOBL.ErrorMessage))
                                    {
                                        if (_SaleId == 0)
                                            _SaleId = Convert.ToInt64(objPOBL.ErrorMessage);
                                        foreach (DataRow dr in dtDocList.Rows)
                                        {
                                            if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                                            {
                                                // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                            }
                                            else
                                            {
                                                string newFileName = CurrentUser.DocumentPath + @"\" + txtPINo.Text + "_" + dr["FileName"].ToString();
                                                objPOBL.InsertSaleDocument(_SaleId, txtPINo.Text + "_" + dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                                if (objPOBL.Exception == null)
                                                {
                                                    if (objPOBL.ErrorMessage == "")
                                                    {
                                                        //Move File
                                                        if (Convert.ToInt32(dr["DocID"].ToString()) > 0)
                                                        {
                                                            File.Copy(CurrentUser.DocumentPath + @"\" + dr["FullFileName"].ToString(), newFileName, true);
                                                        }
                                                        else
                                                        {
                                                            File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        lblErrorMessage.Text = "No error";
                                        //  ReturnValue = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        lblErrorMessage.Text = objPOBL.ErrorMessage;
                                        //    cmbSite.Focus();
                                        //  ReturnValue = false;
                                    }
                                }
                                else
                                {
                                    lblErrorMessage.Text = "No error";
                                    //   ReturnValue = true;
                                }
                            }


                            if (chksend.Checked == true)
                            {
                                SendToMail();
                            }



                        }
                        else
                        {
                            objPOBL.Update(_PIID, txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value),
                                Convert.ToDateTime(dtpDCDate.Value),
                               _CustomerID,
                                Convert.ToInt64(txtDuedays.Text),
                                Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text),
                                Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), txtNarration.Text,
                                XMLString, Cnt,
                                Convert.ToDateTime(dtpInstallation.Value), Convert.ToDateTime(dtpReminder.Value),
                                Convert.ToInt16(txtNoOfServices.Text),
                                XMLString1, Cnt1,
                                Convert.ToInt16(cmbAttendedBy.SelectedValue));


                            if (objPOBL.Exception == null)
                            {
                                foreach (DataRow dr in dtDocList.Rows)
                                {
                                    if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                                    {
                                        objPOBL.InsertSaleDocument(_SaleId, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                    }
                                    else
                                    {
                                        string newFileName = CurrentUser.DocumentPath + @"\" + txtPINo.Text + "_" + dr["FileName"].ToString();

                                        objPOBL.InsertSaleDocument(_SaleId, txtPINo.Text + "_" + dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                        if (objPOBL.Exception == null)
                                        {
                                            if (objPOBL.ErrorMessage == "")
                                            {
                                                //Move File     
                                                string fullfilename = dr["FullFileName"].ToString();
                                                File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                            }
                                        }
                                    }
                                }
                            }


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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            string StrItem = "#";
            for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
            {
                StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
            }
          
            SalesInvoice.frmSalesInvoiceItemEntry fPIEntry = new SalesInvoice.frmSalesInvoiceItemEntry(_PIID, _CustomerID, dtpPIDate.Value, dtPIDetail);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvPIDetail.CurrentRow == null))
            {
                if ((dgvPIDetail.Rows.Count > 1))
                {
                    if ((MessageBox.Show(("You are going to Delete the Sales Invoice." + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
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
            if (txtDocName.Text == "")
            {
                txtDocName.Focus();
                return;
            }
            DataRow dr = dtDocList.NewRow();
            dr["DocID"] = "0";
            dr["SaleID"] = _SaleId;
            dr["FileName"] = txtDocName.Text;
            dr["FullFileName"] = SelectedFileName;
            dr["DocRemark"] = txtComment.Text;
            dtDocList.Rows.Add(dr);


            ArrangeDocumentGridView();
            dgvCountry.AutoGenerateColumns = false;
            dgvCountry.DataSource = dtDocList;
            ArrangeDocumentGridView();
            txtDocName.Text = "";
            SelectedFileName = "";
            txtComment.Text = "";
            btnAddDoc.Focus();
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (dgvCountry.CurrentRow != null)
            {
                int RowIndex = dgvCountry.CurrentRow.Index;
                dtDocList.Rows[RowIndex].Delete();
                dtDocList.AcceptChanges();

                dgvCountry.AutoGenerateColumns = false;
                dgvCountry.DataSource = dtDocList;
                ArrangeDocumentGridView();
            }
        }

        #endregion

        #region "Textbox Event"

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                if (txtCustomer.Text != "")
                {
                    DataView dvItem = new DataView();
                    dvItem = dtCustomer.DefaultView;
                    dvItem.RowFilter = "CustomerName='" + PrepareFilterString(txtCustomer.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();

                    //DataView dvCustomer = new DataView();
                    //dvCustomer = dtCustomer.DefaultView;
                    //dvCustomer.RowFilter = "CustomerName='" + PrepareFilterString(txtCustomer.Text) + "%'";

                    //DataTable dtTempItem = new DataTable();
                    //dtTempItem = dvCustomer.ToTable();

                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        txtCustomer.Text = dtTempItem.Rows[0]["CustomerName"].ToString();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Customer";
                        _CustomerID = 0;
                        //dgvPIDetail.DataSource = null;
                        txtCustomer.Focus();
                    }

                }
                else
                {
                    _CustomerID = 0;
                    dgvPIDetail.DataSource = null;
                }
            }
        }

        private void txtDuedays_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
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
                           // dtpDueDate.Value = dtpPIDate.Value.Date.AddDays(Convert.ToInt16(txtTextbox.Text));
                        }
                        else
                        {
                          //  dtpDueDate.Value = dtpPIDate.Value;
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

        private void txtNarration_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNoOfServices_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomer.Text.Trim() == "")
            {
                txtNoOfServices.Text = "";
                MessageBox.Show("First Select Customer.");
                return;
            }

            if (dtpInstallation.Value == dtpReminder.Value)
            {
                txtNoOfServices.Text = "";
                MessageBox.Show("AMC/Warranty Date must be greater than Installation date.");
                return;
            }

            if (txtNoOfServices.Text.Trim() != "")
            {
                TimeSpan t1 = (dtpReminder.Value) - (dtpInstallation.Value);
                double noofdays = t1.TotalDays;

                int days = 0;
                int p = 0;
                if (Convert.ToInt16(txtNoOfServices.Text) == 0)
                {
                    dgvServicesReminder.DataSource = null;
                }
                else
                {
                    dgvServicesReminder.Rows.Clear();
                    days = Convert.ToInt16(noofdays) / Convert.ToInt16(txtNoOfServices.Text);
                    DateTime NextReminderDate = dtpInstallation.Value.AddDays(days);

                    for (p = 0; p < Convert.ToInt16(txtNoOfServices.Text); p++)
                    {

                        dgvServicesReminder.Rows.Add();
                        string pad = Convert.ToString(p + 1);
                        dgvServicesReminder.Rows[p].Cells[0].Value = txtCustomer.Text.Substring(0, 3) + "-" + pad.PadLeft(4, '0');
                        dgvServicesReminder.Rows[p].Cells[1].Value = NextReminderDate;
                        NextReminderDate = NextReminderDate.AddDays(days);

                    }
                }
            }
            else
            {
                dgvServicesReminder.Rows.Clear();
            }
        }

        private void txtNoOfServices_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataValidator.AllowOnlyNumeric(e, ".");
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice-Keypress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid View Cellpainting Event & Other"

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
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void ArrangeDocumentGridView()
        {
            dgvCountry.Columns[1].DataPropertyName = dtDocList.Columns["DocID"].ToString();
            dgvCountry.Columns[2].DataPropertyName = dtDocList.Columns["FileName"].ToString();
            dgvCountry.Columns[3].DataPropertyName = dtDocList.Columns["DocRemark"].ToString();
            dgvCountry.Columns[4].DataPropertyName = dtDocList.Columns["FullFileName"].ToString();
            dgvCountry.Columns[5].DataPropertyName = dtDocList.Columns["SaleID"].ToString();

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
                    if (dgvCountry.Rows[e.RowIndex].Cells["SaleID"].Value.ToString().Length > 0 && Convert.ToInt32(dgvCountry.Rows[e.RowIndex].Cells["SaleID"].Value.ToString()) > 0)
                        // strFile = dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();
                        strFile = CurrentUser.DocumentPath + @"\" + dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();
                    else
                        strFile = CurrentUser.DocumentPath + dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();

                    Process.Start(strFile);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sale-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        #region "User Define Function"

        public void SendToMail()
        {
            try
            {

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = "niharnathwani1981@gmail.com";

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Sales");
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");
                if (dtEmail.Rows.Count > 0)
                {

                    vMailTo = ((txtemail.Text.ToLower() == "") ? "niharnathwani1981@gmail.com" : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    vSubject = dtEmail.Rows[0][0].ToString() + " For "+ " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
                    vDetails += "<br /><br />";

                    vDetails += " <BR> <BR> <b>Sale No : " + txtPINo.Text + "</b>"; // DETAIL PART OF BODY
                    vDetails += "<BR> <BR>  <b> Date : " + dtpPIDate.Value.Day + "/" + dtpPIDate.Value.Month + "/" + dtpPIDate.Value.Year + "</b><BR> <BR>";
                    vDetails += "<html><head><title></title></head><body><table style=&quot;width: 100%;&quot; border=&quot;1&quot;>" +
                                "<tr align=&quot;center&quot; style=&quot;font-weight: bold&quot;><td>ITEM</td><td>QTY</td><td>UOM</td>" +
                                "<td>RATE</td><td>AMOUNT</td></tr>";

                    for (int i = 0; i < dgvPIDetail.RowCount; i++)
                    {
                        vDetails += "<tr><td align=&quot;left&quot;> " + dgvPIDetail.Rows[i].Cells[1].Value.ToString() +
                                    "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells[3].Value.ToString() +
                                    "</td><td align=&quot;left&quot;>" + dgvPIDetail.Rows[i].Cells[4].Value.ToString() +
                                    "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells[5].Value.ToString() +
                                    "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells[6].Value.ToString() +
                                    "</td></tr>";
                    }

                    vDetails += "</table></body></html>";
                    vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text + "</b>";

                    vDetails += "<br /><br />";
                    vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY



                    vDetails += "<br><br>";
                    vMail.Subject = vSubject;
                    vMail.Body = vDetails;
                    vMail.IsBodyHtml = true;

                    System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
                    System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential("niharnathwani1981@gmail.com", "parshwanathwani123");

                    vSmpt.Host = "smtp.gmail.com";
                    vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //vSmpt.UseDefaultCredentials = false;
                    vSmpt.EnableSsl = true;
                    vSmpt.Credentials = SmtpUser;
                    vSmpt.Send(vMail);

                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Sales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
            }

        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess.DataAccess objDA = new DataAccess.DataAccess();
                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);
                dtQTNC = objDA.ExecuteDataTableSP("usp_SalesTNC_Select", para, false, ref mException, ref mErrorMsg, "Sales TNC - Select");
                string TNC_Sub = "SALES";
                if (dtQTNC.Rows.Count > 0)
                {
                    frmTNCLOV fLOV = new frmTNCLOV("usp_SalesTNC_Select", para, txtPINo.Text , TNC_Sub);
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
                }
                else
                {

                    frmTNCLOV fLOV = new frmTNCLOV("usp_TNC_LOV", null, txtPINo.Text , TNC_Sub);
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

       

    }


        #endregion


}

