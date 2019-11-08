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
using EASendMail;



namespace Account.GUI.SalesReturn
{
    public partial class frmSalesReturnEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelete = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        DataTable dtDocList = new DataTable();
        SalesReturnBL objPOBL = new SalesReturnBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        DataTable dtCustomer = new DataTable();
        DataTable dtPIDetail = new DataTable();
        Int64 _CustomerID = 0;
        Int64 _QuotationID = 0;
        long _PIID = 0;
        Int64 _SaleId = 0;
        int _Mode = 0;
        decimal _ItemDiscAmt = 0;
        string SelectedFileName = "";
        decimal PreDisAmt = 0;
        decimal PreExtraAmt = 0;
        int STNC = 0;
        Exception mException = null;
        string mErrorMsg = "";
        int _CompId = 0;
        int CompId = 0;

        string _BONo = "";
        DateTime _BODate = DateTime.Today.Date;
        string _DNote = "";
        DateTime _DNoteDate = DateTime.Today.Date;
        string _SuRNo = "";
        string _DDNo = "";
        string _DT = "";
        string _D = "";
        DateTime _DtI = DateTime.Today.Date;
        DateTime _DtR = DateTime.Today.Date;
        string _TI = "";
        string _TR = "";
        string _ShipAdd = "";
        Boolean IsPaid;
        string IsAllTNC;
        decimal TotalDisAmt;
        DataTable dtContactDetail = new DataTable();
        DataTable dtQContactDetail = new DataTable();
        //------------------------

        Int32 PIID = 0;
        string mBONO = "";
        DateTime mBODate = DateTime.Today.Date;
        string mDNote = "";
        DateTime mDNoteDate = DateTime.Today.Date;
        string mSuRNo = "";
        string mDDNo = "";
        string mDT = "";
        string mD = "";
        string mTI = "";
        string mTR = "";
        string mShipAdd = "";
        DateTime mDtI = DateTime.Today.Date;
        DateTime mDtR = DateTime.Today.Date;//--------------

        #endregion

        #region "Form Events...."

        public frmSalesReturnEntry(int Mode, Int64 PIID)
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
            objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
         
            dgvPIDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtDocList.Columns.Add("DocID");
            dtDocList.Columns.Add("FileName");
            dtDocList.Columns.Add("FullFileName");
            dtDocList.Columns.Add("DocRemark");
            dtDocList.Columns.Add("SaleID");
            cmbType.SelectedIndex = 0;
            objCommon.FillGodownCombo(cmbgodown);

            txtextrachargestype.CharacterCasing = CharacterCasing.Normal;
            txtECType2.CharacterCasing = CharacterCasing.Normal;
            txtECType3.CharacterCasing = CharacterCasing.Normal;



            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                LoadCustomerList();
                LoadPIDetailList();
                //txtPINo.Text = objCommon.AutoNumber("SI");
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
                //btnGeneratePI.Width = btnCancel.Width;
                //btnGeneratePI.Location = new Point(btnGeneratePI.Location.X + 95, btnGeneratePI.Location.Y);
                chkTNC.Enabled = false;
                cmbType.Enabled = false;
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

                DataColumn clmDiscount = new DataColumn("Discount");
                clmDiscount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmDiscount);

                DataColumn clmDiscountAmt = new DataColumn("DiscountAmt");
                clmDiscountAmt.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmDiscountAmt);

                ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadContactDetailList()
        {
            try
            {
                DataColumn clmContactTitle = new DataColumn("ContactTitle");
                clmContactTitle.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmContactTitle);

                DataColumn clmContactName = new DataColumn("ContactName");
                clmContactName.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmContactName);

                DataColumn clmDesignation = new DataColumn("Designation");
                clmDesignation.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmDesignation);

                DataColumn clmPhone1 = new DataColumn("Phone1");
                clmPhone1.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmPhone1);

                DataColumn clmPhone2 = new DataColumn("Phone2");
                clmPhone2.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmPhone2);

                DataColumn clmMobile = new DataColumn("Mobile");
                clmMobile.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmMobile);

                DataColumn clmEmail = new DataColumn("Email");
                clmEmail.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmEmail);

                DataColumn clmDoB = new DataColumn("DoB");
                clmDoB.DataType = System.Type.GetType("System.DateTime");
                dtContactDetail.Columns.Add(clmDoB);

                DataColumn clmDoA = new DataColumn("DoA");
                clmDoA.DataType = System.Type.GetType("System.DateTime");
                dtContactDetail.Columns.Add(clmDoA);

                //DataColumn clmServiceRate = new DataColumn("ServiceRate");
                //clmServiceRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmServiceRate);

                //DataColumn clmServiceAmount = new DataColumn("ServiceAmount");
                //clmServiceAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmServiceAmount);

                //DataColumn clmExciseRate = new DataColumn("ExciseRate");
                //clmExciseRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmExciseRate);

                //DataColumn clmExciseAmount = new DataColumn("ExciseAmount");
                //clmExciseAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmExciseAmount);

                //DataColumn clmECessRate = new DataColumn("ECessRate");
                //clmECessRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmECessRate);

                //DataColumn clmECessAmount = new DataColumn("ECessAmount");
                //clmECessAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmECessAmount);

                //DataColumn clmHECessRate = new DataColumn("HECessRate");
                //clmHECessRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmHECessRate);

                //DataColumn clmHECessAmount = new DataColumn("HECessAmount");
                //clmHECessAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmHECessAmount);

                //DataColumn clmAmountAfterExcise = new DataColumn("AmountAfterExcise");
                //clmAmountAfterExcise.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmAmountAfterExcise);

                //DataColumn clmCSTRate = new DataColumn("CSTRate");
                //clmCSTRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmCSTRate);

                //DataColumn clmCSTAmount = new DataColumn("CSTAmount");
                //clmCSTAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmCSTAmount);

                //DataColumn clmVATRate = new DataColumn("VATRate");
                //clmVATRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmVATRate);

                //DataColumn clmVATAmount = new DataColumn("VATAmount");
                //clmVATAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmVATAmount);

                //DataColumn clmAVATRate = new DataColumn("AVATRate");
                //clmAVATRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmAVATRate);

                //DataColumn clmAVATAmount = new DataColumn("AVATAmount");
                //clmAVATAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmAVATAmount);

                //DataColumn clmNetAmount = new DataColumn("NetAmount");
                //clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmNetAmount);

                //DataColumn clmDiscount = new DataColumn("Discount");
                //clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmDiscount);


                //ArrangePIDetailGridView();
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
                dgvPIDetail.Columns["Discount"].DataPropertyName = dtPIDetail.Columns["Discount"].ToString();
                //dgvPIDetail.Columns["DiscountAmt"].DataPropertyName = dtPIDetail.Columns["DiscountAmt"].ToString();


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
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", _CompId.ToString());

                dtCustomer = objList.ListOfRecord("usp_Customer_LOV", para1, "Sales Invoice - LoadCustomerList");

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
                    txtAmount.Text = "";
                    txtAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(TotalAmount)", "")).ToString("#0.00");
                    txtServiceAmt.Text = "";
                    txtServiceAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ServiceAmount)", "")).ToString("#0.00");
                    txtExciseAmt.Text = "";
                    txtExciseAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ExciseAmount)", "")).ToString("#0.00");
                    txtEduCessAmt.Text = "";
                    txtEduCessAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ECessAmount)", "")).ToString("#0.00");
                    txtHEduCessAmt.Text = "";
                    txtHEduCessAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(HECessAmount)", "")).ToString("#0.00");
                    txtAmtwithExcise.Text = "";
                    txtAmtwithExcise.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(AmountAfterExcise)", "")).ToString("#0.00");
                    txtCSTAmt.Text = "";
                    txtCSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(CSTAmount)", "")).ToString("#0.00");
                    txtVATAmt.Text = "";
                    txtVATAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(VATAmount)", "")).ToString("#0.00");
                    txtAVATAmt.Text = "";
                    txtAVATAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(AVATAmount)", "")).ToString("#0.00");
                    string discount = "";
                    discount = Convert.ToDecimal(dtPIDetail.Compute("sum(Discount)", "")).ToString("#0.00");
                    //string discountAmt = "";
                    //discountAmt = Convert.ToDecimal(dtPIDetail.Compute("sum(DiscountAmt)", "")).ToString("#0.00");
                    txtNetAmount.Text = "";
                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        if (Convert.ToDecimal(txtDiscount.Text) > 0)
                        {
                            txtNetAmount.Text = (Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")) - Convert.ToDecimal(txtDiscount.Text)).ToString("#0.00");
                        }
                        else
                        {
                            txtNetAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")).ToString("#0.00");
                            if (txtextracharges.Text != null)
                            {
                                //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                                txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                            }
                            //if (txtextracharges2.Text != null)
                            //{
                            //    //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                            //    txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges2.Text)).ToString());
                            //}
                            //if (txtextracharges3.Text != null)
                            //{
                            //    //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                            //    txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                            //}
                        }   
                        //if()
                    }
                    else
                    {
                        txtNetAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")).ToString("#0.00");
                        if (txtextracharges.Text != null)
                        {
                            //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                            txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                        }
                    }

                    if (Convert.ToDecimal(discount) > 0)
                    {
                        //txtDiscount.Text = discount.ToString();
                        txtDiscount.Text = "";
                        txtDiscount.Text = (Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)).ToString();
                      //_ItemDiscAmt = discountAmt;
                    }

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

                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            dtContactDetail = ds.Tables[4].DefaultView.ToTable();
                        }

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtPINo.Text = ds.Tables[0].Rows[0]["SalesCode"].ToString();
                            _CustomerID = Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerID"]);
                            dtpPIDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["SalesDate"]);
                            //     txtDCno.Text = ds.Tables[0].Rows[0]["DCNo"].ToString();
                           
                            txtCustomer.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            txtDuedays.Text = ds.Tables[0].Rows[0]["DueDays"].ToString();
                            //   dtpDueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DueDate"]);
                            txtNarration.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
                            txtPaidAmount.Text = ds.Tables[0].Rows[0]["PaidAmount"].ToString();
                            txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                            txtDicAmt.Text = ds.Tables[0].Rows[0]["TotalDiscAmt"].ToString();
                            //    txtSrNo.Text = ds.Tables[0].Rows[0]["SrNo"].ToString();
                            //    cmbgodown.SelectedValue = ds.Tables[0].Rows[0]["GodownID"].ToString();
                          
                            //    cmbTypeofSale.SelectedItem = ds.Tables[0].Rows[0]["TypeOfSale"].ToString();
                            cmbAttendedBy.SelectedValue = ds.Tables[0].Rows[0]["EmpID"].ToString();
                            txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            txtmobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtcontactperson.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                            txtextracharges.Text = ds.Tables[0].Rows[0]["ExtraCharges"].ToString();
                            txtextrachargestype.Text = ds.Tables[0].Rows[0]["ExtraChargesType"].ToString();
                            txtTIN.Text = ds.Tables[0].Rows[0]["TIN"].ToString();
                            txtRec.Text = ds.Tables[0].Rows[0]["RecDay"].ToString();
                            cmbType.Text = ds.Tables[0].Rows[0]["Type"].ToString();
                            txtShippingAdd.Text = ds.Tables[0].Rows[0]["ShippingAdd"].ToString();
                            txtAddress1.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                            txtNetAmount.Text = ds.Tables[0].Rows[0]["NetAmount"].ToString();
                            _BONo = ds.Tables[0].Rows[0]["BONo"].ToString();
                            _BODate = Convert.ToDateTime(ds.Tables[0].Rows[0]["BODate"].ToString());
                            _DNote = ds.Tables[0].Rows[0]["DNote"].ToString();
                            _DNoteDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["DNoteDate"].ToString());
                            _SuRNo = ds.Tables[0].Rows[0]["SuRNo"].ToString();
                            _DDNo = ds.Tables[0].Rows[0]["DDNo"].ToString();
                            _DT = ds.Tables[0].Rows[0]["DT"].ToString();
                            _D = ds.Tables[0].Rows[0]["D"].ToString();
                            _DtI = Convert.ToDateTime(ds.Tables[0].Rows[0]["DtI"].ToString());
                            _DtR = Convert.ToDateTime(ds.Tables[0].Rows[0]["DtR"].ToString());
                            _TI = ds.Tables[0].Rows[0]["TI"].ToString();
                            _TR = ds.Tables[0].Rows[0]["TR"].ToString();
                            _ShipAdd = ds.Tables[0].Rows[0]["ShippingAdd"].ToString();
                            txtcc.Text = ds.Tables[0].Rows[0]["CC"].ToString();
                            txtbcc.Text = ds.Tables[0].Rows[0]["BCC"].ToString();
                            txtCustInvoiceNo.Text = ds.Tables[0].Rows[0]["CustInvoiceNo"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = ds.Tables[0].Rows[0]["EmpAllToID"].ToString();
                            cmbCategory.Text = ds.Tables[0].Rows[0]["Category"].ToString();
                            cmbStatus.Text = ds.Tables[0].Rows[0]["InterestLevel"].ToString();

                            txtNetAmount.Text = ds.Tables[0].Rows[0]["NetAmount"].ToString();
                           
                            txtextracharges2.Text = ds.Tables[0].Rows[0]["ExtraCharges2"].ToString();
                            txtECType2.Text = ds.Tables[0].Rows[0]["ExtraChargesType2"].ToString();
                            txtextracharges3.Text = ds.Tables[0].Rows[0]["ExtraCharges3"].ToString();
                            txtECType3.Text = ds.Tables[0].Rows[0]["ExtraChargesType3"].ToString();
                            txtCustInvoiceNo.Text = ds.Tables[0].Rows[0]["CustInvoiceNo"].ToString();
                            cmbgodown.SelectedValue = ds.Tables[0].Rows[0]["GoDownID"].ToString();
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
                        //------------------------- new contact-------------
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_Code", txtPINo.Text);

                        if (dtContactDetail.Columns.Count > 0)
                        {

                        }
                        else
                        {
                            LoadContactDetailList();
                        }

                        dtQContactDetail = objDA.ExecuteDataTableSP("usp_SaleContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                        if (dtQContactDetail != null)
                        { }
                        //------------------------- new contact-------------

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
                CommDelete.DeleteRecordWithGodown(_PIID, "usp_SalesInvoice_Delete", "SalesInvoice - Delete", Convert.ToInt16(cmbgodown.SelectedValue));
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
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", _CompId.ToString());

                DataTable dtquotation = new DataTable();
                frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId,"usp_Customer_Quotation_LOV", para1);
                fLOV.Text = "List Of Customer";
                fLOV.ShowDialog();
                txtCustomer.Text = fLOV.CustomerName;
                _CustomerID = fLOV.CustomerID;
                _QuotationID = fLOV.QuotationID;
                txtemail.Text = fLOV.Email;
                txtAddress1.Text = fLOV.Address;
                txtcontactperson.Text = fLOV.ContactPerson;
                txtmobile.Text = fLOV.Phone1;

                cmbCategory.Text = fLOV.Category;
                cmbAttendedBy.SelectedValue = fLOV.EmpID;
                cmbEmpAllocatedTo.SelectedValue = fLOV.AllocatedToEmpID;

                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbStatus.SelectedIndex = 6;
                cmbStatus.Enabled = false;
                cmbgodown.SelectedValue = fLOV.GodownID;
                if (fLOV.CustomerName == null)
                {
                    _CustomerID = 0;
                    //dgvPIDetail.DataSource = null;
                }
                if (_QuotationID != 0)
                {
                    dtquotation = CommSelect.SelectRecord(_QuotationID, "usp_Sale_Quotation", "Godown - BindControl");
                    dgvPIDetail.DataSource = dtquotation;
                    dgvPIDetail.Columns["QuotationId"].Visible = false;
                    dtPIDetail = dtquotation;
                    dgvPIDetail.AutoGenerateColumns = false;
                    ArrangePIDetailGridView();
                    dgvPIDetail.Columns["Discount"].Visible = true;

                }
                CalculateNetAmount();
                //--------------------NEW FOR CONTACT DETAILS -----------------
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);

                if (dtContactDetail.Columns.Count > 0)
                {

                }
                else
                {
                    LoadContactDetailList();
                }

                dtQContactDetail = objDA.ExecuteDataTableSP("usp_QuotationContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                if (dtQContactDetail != null)
                { }

                //--------------------NEW FOR CONTACT DETAILS -----------------
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Exception");
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
            STNC = 1;
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
                            XMLString = XMLString + "<Discount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Discount"]).ToString("#0.00") + "</Discount>";
                            //XMLString = XMLString + "<DiscountAmt>" + Convert.ToDecimal(dtPIDetail.Rows[i]["DiscountAmt"]).ToString("#0.00") + "</DiscountAmt>";
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


                        XMLString1 = "<NewDataSet>";
                        //for (int i = 0; i < dgvServicesReminder.Rows.Count; i++)
                        //{
                        //    XMLString1 = XMLString1 + "<Table>";
                        //    XMLString1 = XMLString1 + "<SR_Code>" + dgvServicesReminder.Rows[i].Cells[0].Value.ToString() + "</SR_Code>";
                        //    XMLString1 = XMLString1 + "<SR_Date>" + Convert.ToDateTime(dgvServicesReminder.Rows[i].Cells[1].Value).ToString("MM/dd/yyyy") + "</SR_Date>";
                        //    XMLString1 = XMLString1 + "<SR_Done>" + "0" + "</SR_Done>";
                        //    XMLString1 = XMLString1 + "</Table> ";
                        //    Cnt1 = Cnt1 + 1;
                        //}
                        XMLString1 = XMLString1 + "</NewDataSet>";


                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            //Int32 PIID = 0;
                            //string mBONO = "";
                            //DateTime mBODate = DateTime.Today.Date;
                            //string mDNote = "";
                            //DateTime mDNoteDate = DateTime.Today.Date;
                            //string mSuRNo = "";
                            //string mDDNo = "";
                            //string mDT = "";
                            //string mD = "";
                            //string mTI = "";
                            //string mTR = "";
                            //string mShipAdd = "";

                            //DateTime mDtI = DateTime.Today.Date;
                            //DateTime mDtR = DateTime.Today.Date;

                            //if (frmSalesInvoiceDispatchDetails.BONo != null)
                            //{
                            //    mBONO = frmSalesInvoiceDispatchDetails.BONo;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.BODate.ToString("dd/MM/yyyy") != "01/01/0001")
                            //{
                            //    mBODate = frmSalesInvoiceDispatchDetails.BODate;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DNote != null)
                            //{
                            //    mDNote = frmSalesInvoiceDispatchDetails.DNote;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DNoteDate.ToString("dd/MM/yyyy") != "01/01/0001")
                            //{
                            //    mDNoteDate = frmSalesInvoiceDispatchDetails.DNoteDate;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.SuRNo != null)
                            //{
                            //    mSuRNo = frmSalesInvoiceDispatchDetails.SuRNo;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DDNo != null)
                            //{
                            //    mDDNo = frmSalesInvoiceDispatchDetails.DDNo;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DT != null)
                            //{
                            //    mDT = frmSalesInvoiceDispatchDetails.DT;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.D != null)
                            //{
                            //    mD = frmSalesInvoiceDispatchDetails.D;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.TI != null)
                            //{
                            //    mTI = frmSalesInvoiceDispatchDetails.TI;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.TR != null)
                            //{
                            //    mTR = frmSalesInvoiceDispatchDetails.TR;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DtI.ToString("dd/MM/yyyy") != "01/01/0001")
                            //{
                            //    mDtI = frmSalesInvoiceDispatchDetails.DtI;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DtR.ToString("dd/MM/yyyy") != "01/01/0001")
                            //{
                            //    mDtR = frmSalesInvoiceDispatchDetails.DtR;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.ShipAdd != null)
                            //{
                            //    mShipAdd = frmSalesInvoiceDispatchDetails.ShipAdd;
                            //}

                             if (txtNetAmount.Text != null && txtPaidAmount.Text != null)
                             {
                                 if (Convert.ToDecimal(txtPaidAmount.Text) < Convert.ToDecimal(txtNetAmount.Text))
                                 {
                                     //MessageBox.Show("not total paid");

                                     IsPaid = false;
                                 }
                                 else
                                 {
                                    // MessageBox.Show("total paid");
                                     IsPaid = true;
                                 }
                             }

                            PIID = objPOBL.Insert(txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value),
                                _CustomerID,
                                Convert.ToInt64(txtDuedays.Text),
                                Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text),
                                Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), txtNarration.Text,
                                XMLString, Cnt,                                
                                XMLString1, Cnt1,
                                Convert.ToInt16(cmbAttendedBy.SelectedValue),
                                Convert.ToDecimal(txtextracharges.Text), txtextrachargestype.Text, txtTIN.Text, Convert.ToInt16(txtRec.Text),
                                cmbType.Text, mShipAdd, mBONO, mBODate,
                                mDNote, mDNoteDate,
                                mSuRNo, mDDNo,
                                mDT, mD,
                                mDtI, mTI,
                                mDtR, mTR,
                                txtcc.Text, txtbcc.Text, txtCustInvoiceNo.Text,
                                Convert.ToDecimal(txtextracharges2.Text), txtECType2.Text, 
                                Convert.ToDecimal(txtextracharges3.Text), txtECType3.Text,
                                Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue),IsPaid,Convert.ToDecimal(txtDicAmt.Text),CompId
                                ,Convert.ToInt16(cmbgodown.SelectedValue));


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
                                                string newFileName = CurrentUser.DocumentPath + @"\" + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                                objPOBL.InsertSaleDocument(_SaleId, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'), dr["DocRemark"].ToString());
                                                                                                
                                                //string PINO = txtPINo.Text;
                                                //string Module = PINO.Substring(0, 2);
                                                //string Year = PINO.Substring(3, 5);
                                                //string Code = PINO.Substring(9, 5);
                                                //string DocCode = Module + "-" + Year + "-" + Code;                                                
                                                
                                                if (objPOBL.Exception == null)
                                                {
                                                    if (objPOBL.ErrorMessage == "")
                                                    {
                                                        //Move File
                                                        //if (Convert.ToInt32(dr["DocID"].ToString()) > 0)
                                                        //{
                                                        //    File.Copy(CurrentUser.DocumentPath + @"\" + dr["FullFileName"].ToString(), newFileName, true);
                                                        //}
                                                        //else
                                                        //{
                                                            File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                       // }
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

                            if (chkTNC.Checked == true)
                            {
                                NameValueCollection para1 = new NameValueCollection();
                                para1.Add("@i_TNC_SUB", "SALES");
                                DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                                for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                {
                                    objPOBL.InsertTNC("SALES", dtAllTNC.Rows[i][0].ToString(), txtPINo.Text);
                                }

                            }
                        }
                        else
                        {
                            //if (frmSalesInvoiceDispatchDetails.BONo != null)
                            //{
                            //    _BONo = frmSalesInvoiceDispatchDetails.BONo;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DNote != null)
                            //{
                            //    _DNote = frmSalesInvoiceDispatchDetails.DNote;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.SuRNo != null)
                            //{
                            //    _SuRNo = frmSalesInvoiceDispatchDetails.SuRNo;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DDNo != null)
                            //{
                            //    _DDNo = frmSalesInvoiceDispatchDetails.DDNo;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.DT != null)
                            //{
                            //    _DT = frmSalesInvoiceDispatchDetails.DT;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.D != null)
                            //{
                            //    _D = frmSalesInvoiceDispatchDetails.D;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.TI != null)
                            //{
                            //    _TI = frmSalesInvoiceDispatchDetails.TI;
                            //}
                            //if (frmSalesInvoiceDispatchDetails.TR != null)
                            //{
                            //    _TR = frmSalesInvoiceDispatchDetails.TR;
                            //}
                            //if (Convert.ToString(frmSalesInvoiceDispatchDetails.BODate.ToString("dd/MM/yyyy")) != "01/01/0001")
                            //{
                            //    _BODate = frmSalesInvoiceDispatchDetails.BODate;
                            //}
                            //if (Convert.ToString(frmSalesInvoiceDispatchDetails.DNoteDate.ToString("dd/MM/yyyy")) != "01/01/0001")
                            //{
                            //    _DNoteDate = frmSalesInvoiceDispatchDetails.DNoteDate;
                            //}
                            //if (Convert.ToString(frmSalesInvoiceDispatchDetails.DtI.ToString("dd/MM/yyyy")) != "01/01/0001")
                            //{
                            //    _DtI = frmSalesInvoiceDispatchDetails.DtI;
                            //}
                            //if (Convert.ToString(frmSalesInvoiceDispatchDetails.DtR.ToString("dd/MM/yyyy")) != "01/01/0001")
                            //{
                            //    _DtR = frmSalesInvoiceDispatchDetails.DtR;
                            //}

                            //if (frmSalesInvoiceDispatchDetails.ShipAdd != null)
                            //{
                            //    _ShipAdd = frmSalesInvoiceDispatchDetails.ShipAdd;
                            //}

                            objPOBL.Update(_PIID, txtPINo.Text, Convert.ToDateTime(dtpPIDate.Value),                               
                               _CustomerID,
                                Convert.ToInt64(txtDuedays.Text),
                                Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text),
                                Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), txtNarration.Text,
                                XMLString, Cnt,
                                XMLString1, Cnt1,
                                Convert.ToInt16(cmbAttendedBy.SelectedValue),
                                 Convert.ToDecimal(txtextracharges.Text), txtextrachargestype.Text, txtTIN.Text, Convert.ToInt16(txtRec.Text),
                                 cmbType.Text, _ShipAdd, _BONo, _BODate,
                                _DNote, _DNoteDate,
                                _SuRNo, _DDNo,
                                _DT, _D,
                                _DtI, _TI,
                                _DtR, _TR,
                                txtcc.Text, txtbcc.Text, txtCustInvoiceNo.Text,
                                Convert.ToDecimal(txtextracharges2.Text), txtECType2.Text,
                                Convert.ToDecimal(txtextracharges3.Text), txtECType3.Text, Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue),IsPaid,Convert.ToDecimal(txtDicAmt.Text),CompId
                                , Convert.ToInt16(cmbgodown.SelectedValue));


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
                                        //string PINO = txtPINo.Text;
                                        //string Module = PINO.Substring(0, 2);
                                        //string Year = PINO.Substring(3, 5);
                                        //string Code = PINO.Substring(9, 5);
                                        //string DocCode = Module + "-" + Year + "-" + Code;

                                        //string newFileName = CurrentUser.DocumentPath + DocCode + "_" + dr["FileName"].ToString();

                                        //objPOBL.InsertSaleDocument(_SaleId, DocCode + "_" + dr["FileName"].ToString(), dr["DocRemark"].ToString());

                                        string newFileName = CurrentUser.DocumentPath + @"\" + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                        objPOBL.InsertSaleDocument(_SaleId, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'), dr["DocRemark"].ToString());

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
                        if (chksend.Checked == true)
                        {
                            SendToMail();
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
            if (_Mode == (int)Constant.Mode.Insert)
            {
                objPOBL.DeleteTNC_On_Close("SALES", txtPINo.Text);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cmbgodown.SelectedValue) > 0)
            {
                lblErrorMessage.Text = "";
                string StrItem = "#";
                for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
                {
                    StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    if (dtPIDetail.Columns.Count == 0)
                    {
                        LoadPIDetailList();
                    }
                }

                SalesInvoice.frmSalesInvoiceItemEntry fPIEntry = new SalesInvoice.frmSalesInvoiceItemEntry((int)Constant.Mode.Insert, _PIID, _CustomerID, dtpPIDate.Value, dtPIDetail, _ItemDiscAmt, 0, 0, Convert.ToInt16(cmbgodown.SelectedValue));
                fPIEntry.ShowDialog();
                dgvPIDetail.AutoGenerateColumns = false;
                dgvPIDetail.DataSource = dtPIDetail;
                //fPIEntry.ItemDiscountAmt += Convert.ToDecimal(fPIEntry.ItemDiscountAmt.ToString());
                TotalDisAmt = Convert.ToDecimal(txtDicAmt.Text);
                TotalDisAmt += Convert.ToDecimal(fPIEntry.ItemDiscountAmt.ToString());
                // fPIEntry.ItemDiscountAmt += fPIEntry.ItemDiscountAmt;
                txtDicAmt.Text = TotalDisAmt.ToString();
                ArrangePIDetailGridView();
                CalculateNetAmount();
            }
            else
            {
                MessageBox.Show("Select Godown.");
                return;
            }
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
            //if (txtCustomer.Text.Trim() == "")
            //{
            //    txtNoOfServices.Text = "";
            //    MessageBox.Show("First Select Customer.");
            //    return;
            //}

            //if (dtpInstallation.Value == dtpReminder.Value)
            //{
            //    txtNoOfServices.Text = "";
            //    MessageBox.Show("AMC/Warranty Date must be greater than Installation date.");
            //    return;
            //}

            //if (txtNoOfServices.Text.Trim() != "")
            //{
            //    TimeSpan t1 = (dtpReminder.Value) - (dtpInstallation.Value);
            //    double noofdays = t1.TotalDays;

            //    int days = 0;
            //    int p = 0;
            //    if (Convert.ToInt16(txtNoOfServices.Text) == 0)
            //    {
            //        dgvServicesReminder.DataSource = null;
            //    }
            //    else
            //    {
            //        dgvServicesReminder.Rows.Clear();
            //        days = Convert.ToInt16(noofdays) / Convert.ToInt16(txtNoOfServices.Text);
            //        DateTime NextReminderDate = dtpInstallation.Value.AddDays(days);

            //        for (p = 0; p < Convert.ToInt16(txtNoOfServices.Text); p++)
            //        {

            //            dgvServicesReminder.Rows.Add();
            //            string pad = Convert.ToString(p + 1);
            //            dgvServicesReminder.Rows[p].Cells[0].Value = txtCustomer.Text.Substring(0, 3) + "-" + pad.PadLeft(4, '0');
            //            dgvServicesReminder.Rows[p].Cells[1].Value = NextReminderDate;
            //            NextReminderDate = NextReminderDate.AddDays(days);

            //        }
            //    }
            //}
            //else
            //{
            //    dgvServicesReminder.Rows.Clear();
            //}
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

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Sales");
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");
                if (dtEmail.Rows.Count > 0)
                {

                    //------------------------new code for multiple contact persons-----------------
                    string EmailIDs = "";
                    //dtblContactPerson
                    if (dtQContactDetail != null)
                    {
                        if (dtQContactDetail.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtQContactDetail.Rows.Count; i++)
                            {
                                if (dtQContactDetail.Rows[i]["Email"].ToString() != "")
                                {
                                    EmailIDs = EmailIDs + dtQContactDetail.Rows[i]["Email"].ToString() + ",";
                                }
                                else
                                {

                                }
                            }
                            vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : EmailIDs.TrimEnd(',').ToLower());
                            //vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                        }
                        else
                        {
                            if (txtemail.Text == "")
                            {
                                MessageBox.Show("No contact detail available for this client.\n Please fill up contact person details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                            }
                            //MessageBox.Show("No contact detail available for this client.\n Please fill up contact person details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    }

                    //------------------------new code for multiple contact persons-----------------


                    vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    vSubject = dtEmail.Rows[0][0].ToString() + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
                    vDetails += "<br /><br />";

                    vDetails += " <BR> <BR> <b>Sale No : " + txtCustInvoiceNo.Text + "</b>"; // DETAIL PART OF BODY
                    vDetails += "<BR> <BR>  <b> Date : " + dtpPIDate.Value.Day + "/" + dtpPIDate.Value.Month + "/" + dtpPIDate.Value.Year + "</b><BR> <BR>";
                    vDetails += "<html><head><title></title></head><body><table style=&quot;width: 100%;&quot; border=&quot;1&quot;>" +
                                "<tr align=&quot;center&quot; style=&quot;font-weight: bold&quot;><td>ITEM</td><td>QTY</td><td>UOM</td>" +
                                "<td>RATE</td><td>AMOUNT</td></tr>";

                    for (int i = 0; i < dgvPIDetail.RowCount; i++)
                    {
                        vDetails += "<tr><td align=&quot;left&quot;> " + dgvPIDetail.Rows[i].Cells["ItemName"].Value.ToString() +
                                    "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["Qty"].Value.ToString() +
                                    "</td><td align=&quot;left&quot;>" + dgvPIDetail.Rows[i].Cells["UOM"].Value.ToString() +
                                    "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["Rate"].Value.ToString() +
                                    "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["TotalAmount"].Value.ToString() +
                                    "</td></tr>";
                    }

                    vDetails += "</table></body></html>";
                    vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text + "</b>";

                    //------------new content for dispatch detail------------

                    vDetails += " <BR> <BR> <b> ===== Dispatch Details =====</b>";

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Buyer's Order No.: " + mBONO + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Buyer's Order No.: " + _BONo + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Order Date: " + mBODate + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Order Date: " + _BODate + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Delivery Note: " + mDNote + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Delivery Note: " + _DNote + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Delivery Date: " + mDNoteDate + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Delivery Date: " + _DNoteDate + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Supplier's Ref./Order No.: " + mSuRNo + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Supplier's Ref./Order No.: " + _SuRNo + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Despatch Document No.: " + mDDNo + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Despatch Document No.: " + _DDNo + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Despatched through & Vehical No.: " + mDT + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Despatched through & Vehical No.: " + _DT + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Destination: " + mD + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Destination: " + _D + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Date & Time of issue of Invoice:" + mDtI + " - " + mTI + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Date & Time of issue of Invoice: " + _DtI + " - " + _TI + "</b>";
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        vDetails += " <BR> <BR> <b> Date & Time of Removal of Goods:" + mDtR + " - " + mTR + "</b>";
                    }
                    else
                    {
                        vDetails += " <BR> <BR> <b> Date & Time of Removal of Goods: " + _DtR + " - " + _TR + "</b>";
                    }

                    vDetails += " <BR> <BR> <b> Shipping Address: " + txtShippingAdd.Text + "</b>";


                    vDetails += "<br /><br />";
                    vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY



                    vDetails += "<br><br>";

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
                    //SmtpServer oServer = new SmtpServer(CurrentCompany.Host);
                    //oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
                    vSmpt.Credentials = SmtpUser;
                    vSmpt.Send(vMail);
                    MessageBox.Show("Mail has been sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Sales.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email" + ex);
            }

        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DataAccess.DataAccess objDA = new DataAccess.DataAccess();
            //    DataTable dtQTNC = new DataTable();
            //    NameValueCollection para = new NameValueCollection();
            //    para.Add("@i_Code", txtPINo.Text);
            //    dtQTNC = objDA.ExecuteDataTableSP("usp_SalesTNC_Select", para, false, ref mException, ref mErrorMsg, "Sales TNC - Select");
            //    string TNC_Sub = "SALES";
            //    if (dtQTNC.Rows.Count > 0)
            //    {
            //        frmTNCLOV fLOV = new frmTNCLOV("usp_SalesTNC_Select", para, txtPINo.Text, "SALES");
            //        fLOV.Text = "List Of Terms & Conditions";
            //        fLOV.ShowDialog();
            //    }
            //    else
            //    {

            //        frmTNCLOV fLOV = new frmTNCLOV("usp_TNC_LOV", null, txtPINo.Text, "SALES");
            //        fLOV.Text = "List Of Terms & Conditions";
            //        fLOV.ShowDialog();
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Quotation", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}

            try
            {

                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);
                dtQTNC = objDA.ExecuteDataTableSP("usp_SalesTNC_Select", para, false, ref mException, ref mErrorMsg, "Sales TNC - Select");

                if (dtQTNC.Rows.Count > 0)
                {
                    if (chkTNC.Checked == true)
                    {
                        IsAllTNC = "True";
                    }
                    else
                    {
                        IsAllTNC = "False";
                    }

                    frmTNCLOV fLOV = new frmTNCLOV("usp_SalesTNC_Select", para, txtPINo.Text, "SALES");
                    fLOV.Text = "List Of Terms & Conditions";
                   
                    //TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                    //if (chkTNC.Checked == true)
                    //{
                    //    fLOV.IsAllTNC_Check = "True";
                    //}
                    //else
                    //{
                    //    fLOV.IsAllTNC_Check = "False";
                    //}
                    fLOV.ShowDialog();
                    //if (fLOV.IsAllTNC_Check == "False")
                    //{
                    //    chkTNC.Checked = false;
                    //}
                    //else
                    //{
                    //    chkTNC.Checked = true;
                    //}
                   // TYPE_OF_FORM = fLOV.TYPE_OF_SALE;

                }
                else
                {
                    //if (chkTNC.Checked == true)
                    //{
                    //    IsAllTNC = "True";
                    //}
                    //else
                    //{
                    //    IsAllTNC = "False";
                    //}
                    frmTNCLOV fLOV = new frmTNCLOV("usp_TNC_LOV", null, txtPINo.Text, "SALES");
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
                    //if (fLOV.IsAllTNC_Check == "False")
                    //{
                    //    chkTNC.Checked = false;
                    //}
                    //else
                    //{
                    //    chkTNC.Checked = true;
                    //}
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void txtextracharges_Leave(object sender, EventArgs e)
        {           
            if (txtextracharges.Text != null)
            {               
                CalculateNetAmount();
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
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
                _PIID = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["QuotationId"].Value);
                _ID = 1;
            }

            SalesInvoice.frmSalesInvoiceItemEntry fPIEntry = new SalesInvoice.frmSalesInvoiceItemEntry((int)Constant.Mode.Modify, _PIID, _CustomerID, dtpPIDate.Value, dtPIDetail, _ItemDiscAmt, ItemID_Edit, _ID, Convert.ToInt16(cmbgodown.SelectedValue));
            fPIEntry.ShowDialog();



            dgvPIDetail.AutoGenerateColumns = false;
            //txtDicAmt.Text = _ItemDiscAmt.ToString();
            TotalDisAmt += Convert.ToDecimal(fPIEntry.ItemDiscountAmt.ToString());
            
            txtDicAmt.Text = TotalDisAmt.ToString();
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
        }


        private void txtDiscount_Leave(object sender, EventArgs e)
        {

        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                if (cmbType.SelectedIndex == 1)
                {
                    txtPINo.Text = objCommon.AutoNumber("RI");
                    txtCustInvoiceNo.Text = objCommon.AutoNumber("RI");
                }
                else if (cmbType.SelectedIndex == 2)
                {
                    txtPINo.Text = objCommon.AutoNumber("TI");
                    txtCustInvoiceNo.Text = objCommon.AutoNumber("TI");
                }
                else if (cmbType.SelectedIndex == 3)
                {
                    txtPINo.Text = objCommon.AutoNumber("ES");
                    txtCustInvoiceNo.Text = objCommon.AutoNumber("ES");
                }
            }
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                //frmSalesInvoiceDispatchDetails fSD = new frmSalesInvoiceDispatchDetails("", DateTime.Today.Date, "", DateTime.Today.Date, "", "", "",
                //                                                                        "", DateTime.Today.Date, DateTime.Today.Date, "", "", 1,"");
                //fSD.ShowDialog();
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                //frmSalesInvoiceDispatchDetails fSD = new frmSalesInvoiceDispatchDetails(_BONo, _BODate, _DNote, _DNoteDate, _SuRNo, _DDNo,
                //                                                                _DT, _D, _DtI, _DtR, _TI, _TR, 3,_ShipAdd);

                //fSD.ShowDialog();
            }

        }

        private void txtextracharges2_Leave(object sender, EventArgs e)
        {
            //if (txtextracharges2.Text != null)
            //{
            //    if (Convert.ToDecimal(txtextracharges2.Text) > 0)
            //    {

            //        if (PreDisAmt == 0 || Convert.ToDecimal(txtextracharges2.Text) != PreDisAmt)
            //        {
            //            //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges2.Text) - PreExtraAmt).ToString();
            //            //PreExtraAmt = Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text);

            //           // txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
            //        }
            //    }
            //    else if (Convert.ToDecimal(txtextracharges2.Text) == 0)
            //    {
            //        //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) - PreExtraAmt).ToString();
            //        //PreExtraAmt = Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text);
            //    }
            //}


            if (txtextracharges2.Text != null)
            {
                //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
               // txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges2.Text)).ToString());
                CalculateNetAmount();
            }
        }

        private void txtextracharges3_Leave(object sender, EventArgs e)
        {
            //if (txtextracharges3.Text != null)
            //{
            //    if (Convert.ToDecimal(txtextracharges3.Text) > 0)
            //    {

            //        if (PreDisAmt == 0 || Convert.ToDecimal(txtextracharges3.Text) != PreDisAmt)
            //        {
            //            //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges3.Text) - PreExtraAmt).ToString();
            //            //PreExtraAmt = Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text);

            //          //  txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
            //        }
            //    }
            //    else if (Convert.ToDecimal(txtextracharges3.Text) == 0)
            //    {
            //        //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) - PreExtraAmt).ToString();
            //        //PreExtraAmt = Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text);
            //    }
            //}

            if (txtextracharges3.Text != null)
            {
                //txtNetAmount.Text = (Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                //txtNetAmount.Text = ((Convert.ToDecimal(txtNetAmount.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                CalculateNetAmount();
            }

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSalesInvoiceEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Mode == (int)Constant.Mode.Insert)
            {
                if (STNC == 0)
                {
                    objPOBL.DeleteTNC_On_Close("SALES", txtPINo.Text);
                }
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);

                //if (_Mode == (int)Common.Constant.Mode.Insert)
                //{
                if (dtContactDetail.Columns.Count > 0)
                {
                    
                }
                else
                {
                    LoadContactDetailList();
                }
                //}
                dtQTNC = objDA.ExecuteDataTableSP("usp_SaleContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                if (dtQTNC != null)
                {
                    ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SCUpdate, 0, _CustomerID, txtPINo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SALE");
                    fLOV.Text = "List Of Conatct Details";
                    fLOV.ShowDialog();
                }
                else
                {
                    ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SCInsert, 0, _CustomerID, txtPINo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SALE");
                    fLOV.Text = "List Of Conatct Details";
                    fLOV.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
    }
        #endregion

      
}

