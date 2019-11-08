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
using System.Collections.Specialized;
using System.Net.Mail;

namespace Account.GUI.Quotation
{
    public partial class frmQuotationNew : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        QuotationBL objQuotationBL = new QuotationBL();
        CommonListBL objList = new CommonListBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        DataTable dtDocList = new DataTable();

        Exception mException = null;
        string mErrorMsg = "";

        Int64 _QuotationID = 0;
        Int64 _LeadID = 0;
        Int64 _SIID = 0;
        Int64 _PIID = 0;
        Int64 _CustomerID = 0;
        string _XMLTNC = "";
        Int64 _CntTNC = 0;

        Int64 _BuildingID = 0;

        DataTable dtPIDetail = new DataTable();
        DataSet dtQuotation = new DataSet();

        string SelectedFileName = "";
        int _Mode = 0;
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        string TYPE_OF_FORM;
        string IsAllTNC;


        #endregion

        public
            frmQuotationNew(int Mode, long QuotationID)
        {
            InitializeComponent();
            _Mode = Mode;
            _QuotationID = QuotationID;
            _SIID = QuotationID;
        }

        private void frmQuotationNew_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                objCommon.FillEmployeeCombo(cmbEmp);
                objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);

                dtpSaleDate.Value = DateTime.Now;

                dtDocList.Columns.Add("QDocID");
                dtDocList.Columns.Add("FileName");
                dtDocList.Columns.Add("FullFileName");
                
                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    this.Text = "Quotation - New";
                    txtPINo.Text = objCommon.AutoNumber("QU");
                    LoadPIDetailList();
                    btnedit.Visible = false;
                    cmbStatus.SelectedIndex = 5;
                    cmbStatus.Enabled = false;
                    //-----------
                    //btnTNC.Enabled = true;
                    //chkTNC.Checked = false;
                    //------------
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    //  btnedit.Visible = false;
                    //dtpSaleDate.Enabled = false;
                    //txtAdvAmt.Enabled = false;
                    //txtSalePrice.Enabled = false;
                    //txtRemark.Enabled = false;
                    //btnLeadLOV.Enabled = false;
                    this.Text = "Quotation - Edit";
                    chkTNC.Enabled = false;
                }
                if (_Mode == (int)Common.Constant.Mode.View)
                {
                    this.Text = "Quotation - New";
                    BindControl();
                    //   btnedit.Visible = true;
                    //     string custno1 = txtCustName.Text.Substring(0, 3) + "/" + "2014-15";
                    //   txtquotationno.Text = objCommon.AutoNumber(custno1);
                    //        btnedit.Visible = true;
                    //  LoadPIDetailList();
                    //txtPINo.Text = "R"+ objCommon.AutoNumber("QU");

                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();

                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    btnSaveExit.Text = "Yes";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    btnCancel.Text = "No";
                    this.Text = "Quotation - Delete";
                }
                //txtBcc.CharacterCasing = CharacterCasing.Normal;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
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
                clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmDiscount);


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
                dgvPIDetail.Columns["Discount"].DataPropertyName = dtPIDetail.Columns["Discount"].ToString();
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

        public bool SetSave()
        {
            //SendToMail();
            bool ReturnValue = false;
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_QuotationID, "usp_Quotation_Delete", "Quotation - Delete");
                if (CommDelRec.Exception == null)
                {
                    if (CommDelRec.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = CommDelRec.ErrorMessage;
                        ReturnValue = false;
                    }
                    else
                    {
                        lblErrorMessage.Text = "No error";
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
                    if (dgvPIDetail.Rows.Count == 0)
                    {
                        lblErrorMessage.Text = "Select at least one item";
                        dgvPIDetail.Focus();
                        return false;
                    }

                    int aa = Convert.ToInt32(_SIID);

                    if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtNetAmount.Text))
                    {
                        lblErrorMessage.Text = "Paid amount can not greater than net amount";
                        txtPaidAmount.Focus();
                        // return;
                    }

                    bool Is_MailSend;
                    if (chksend.Checked)
                    {
                        Is_MailSend = true;
                    }
                    else
                    {
                        Is_MailSend = false;
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
                        XMLString = XMLString + "</Table> ";
                        Cnt = Cnt + 1;
                    }
                    XMLString = XMLString + "</NewDataSet>";
                    //if (Cnt == 0)
                    //{
                    //    lblErrorMessage.Text = "Select at least one item";
                    //    dgvPIDetail.Focus();
                    //    // return;
                    //}



                    if (_Mode == (int)Common.Constant.Mode.Insert || _Mode == (int)Common.Constant.Mode.View)
                    {
                        objQuotationBL.Insert(_LeadID, dtpSaleDate.Value, _SIID, Convert.ToDecimal("0.00"), Convert.ToDecimal("0.00"),
                            txtSubject.Text, Convert.ToDecimal(txtServiceAmt.Text), Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                            Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text),
                            Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text),
                            Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text),
                            XMLString, Cnt, "RefNo", "TypeOfSale", txtPINo.Text, Convert.ToDateTime(dtpNextDate.Value), txtreference.Text,
                            Convert.ToInt16(cmbEmp.SelectedValue),Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), txtRemarks.Text, txtcc.Text, txtbcc.Text);


                      
                        if (chkTNC.Checked == true)
                        {
                            NameValueCollection para1 = new NameValueCollection();
                            para1.Add("@i_TNC_SUB", "QUOTATION");
                            DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                            for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                            {
                                objQuotationBL.InsertTNC("QUOTATION", dtAllTNC.Rows[i][0].ToString(), txtPINo.Text, Convert.ToInt16(dtAllTNC.Rows[i][1].ToString()));
                            }

                        }

                        if (objQuotationBL.Exception == null)
                        {
                            if (objQuotationBL.ErrorMessage != "" || _QuotationID > 0)
                            {
                                if (isRecordSave(objQuotationBL.ErrorMessage))
                                {
                                    if (_QuotationID == 0)
                                        _QuotationID = Convert.ToInt64(objQuotationBL.ErrorMessage);
                                    //-----for doc save--------
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "_" + dr["FileName"].ToString().Replace('/', '-');
                                            objQuotationBL.InsertQuotationDocument(_QuotationID, txtLeadNo.Text.ToString().Replace('/', '-') + "_" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objQuotationBL.Exception == null)
                                            {
                                                if (objQuotationBL.ErrorMessage == "")
                                                {                                                   
                                                   File.Copy(dr["FullFileName"].ToString(), newFileName, true);                                                    
                                                }
                                            }
                                        }
                                    }

                                    //-------------------

                                    if (chksend.Checked == true)
                                    {
                                        SendToMail();
                                    }

                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                                else
                                {
                                    lblErrorMessage.Text = objQuotationBL.ErrorMessage;

                                    ReturnValue = false;
                                }

                            }
                            else
                            {
                                lblErrorMessage.Text = "No error";
                                ReturnValue = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(objQuotationBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objQuotationBL.Update(_QuotationID, _LeadID, dtpSaleDate.Value, _SIID, Convert.ToDecimal("0.00"),
                                                Convert.ToDecimal("0.00"), txtSubject.Text, Convert.ToDecimal(txtServiceAmt.Text),
                                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                                Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), XMLString, Cnt, "RefNo",
                                                "TypeOfSale", Convert.ToDateTime(dtpNextDate.Value), txtreference.Text,
                                                Convert.ToInt16(cmbEmp.SelectedValue), Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), txtRemarks.Text, txtcc.Text, txtbcc.Text);

                     
                        if (objQuotationBL.Exception == null)
                        {
                            if (objQuotationBL.Exception == null)
                            {
                                //--for doc save code
                                foreach (DataRow dr in dtDocList.Rows)
                                {
                                    if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                    {
                                        objQuotationBL.InsertQuotationDocument(_QuotationID, dr["FileName"].ToString());
                                    }
                                    else
                                    {
                                        string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "_" + dr["FileName"].ToString().Replace('/', '-');
                                        objQuotationBL.InsertQuotationDocument(_QuotationID, txtLeadNo.Text.ToString().Replace('/', '-') + "_" + dr["FileName"].ToString().Replace('/', '-'));
                                        if (objQuotationBL.Exception == null)
                                        {
                                            if (objQuotationBL.ErrorMessage == "")
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
                            }
                            else
                            {
                                lblErrorMessage.Text = objQuotationBL.ErrorMessage;

                                ReturnValue = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show(objQuotationBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }
            }
            return ReturnValue;
        }

        public void BindControl()
        {
            DataSet ds = new DataSet();
            ds = CommSelect.SelectDataSetRecord(_SIID, "usp_Quotation_Select", "Quotation - BindControl");
            dtQuotation = CommSelect.SelectDataSetRecord(_SIID, "usp_Quotation_Select", "Quotation - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        dgvPIDetail.AutoGenerateColumns = false;
                        dgvPIDetail.DataSource = ds.Tables[3];
                        dtPIDetail = ds.Tables[3];
                        ArrangePIDetailGridView();
                    }

                    if (dtQuotation.Tables[0].Rows.Count > 0)
                    {
                        _QuotationID = Convert.ToInt64(dtQuotation.Tables[0].Rows[0]["QuotationId"].ToString());
                        _LeadID = Convert.ToInt64(dtQuotation.Tables[0].Rows[0]["LeadID"].ToString());
                        txtLeadNo.Text = dtQuotation.Tables[0].Rows[0]["LeadNo"].ToString();
                        if (dtQuotation.Tables[0].Rows[0]["LeadDate"].ToString() == null || dtQuotation.Tables[0].Rows[0]["LeadDate"].ToString() == "")
                        {
                            txtLeaddate.Text = "";
                        }
                        else
                        {
                            txtLeaddate.Text = Convert.ToDateTime(dtQuotation.Tables[0].Rows[0]["LeadDate"].ToString()).ToShortDateString();
                        }
                        txtCustName.Text = dtQuotation.Tables[0].Rows[0]["CustomerName"].ToString();
                        dtpSaleDate.Value = Convert.ToDateTime(dtQuotation.Tables[0].Rows[0]["QDate"].ToString());
                        txtSubject.Text = dtQuotation.Tables[0].Rows[0]["Remarks"].ToString();
                        txtPaidAmount.Text = dtQuotation.Tables[0].Rows[0]["PaidAmount"].ToString();
                        txtDiscount.Text = dtQuotation.Tables[0].Rows[0]["Discount"].ToString();
                        txtAmount.Text = dtQuotation.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtServiceAmt.Text = dtQuotation.Tables[0].Rows[0]["ServiceAmount"].ToString();
                        txtExciseAmt.Text = dtQuotation.Tables[0].Rows[0]["ExciseAmount"].ToString();
                        txtHEduCessAmt.Text = dtQuotation.Tables[0].Rows[0]["HCessAmount"].ToString();
                        txtEduCessAmt.Text = dtQuotation.Tables[0].Rows[0]["CessAmount"].ToString();
                        txtAmtwithExcise.Text = dtQuotation.Tables[0].Rows[0]["AmountAfterExcise"].ToString();
                        txtCSTAmt.Text = dtQuotation.Tables[0].Rows[0]["CSTAmount"].ToString();
                        txtVATAmt.Text = dtQuotation.Tables[0].Rows[0]["VATAmount"].ToString();
                        txtAVATAmt.Text = dtQuotation.Tables[0].Rows[0]["AVATAmount"].ToString();
                        txtNetAmount.Text = dtQuotation.Tables[0].Rows[0]["NetAmount"].ToString();
                        txtPINo.Text = dtQuotation.Tables[0].Rows[0]["Code"].ToString();
                        dtpNextDate.Text = dtQuotation.Tables[0].Rows[0]["FollowUpDate"].ToString();
                        txtreference.Text = dtQuotation.Tables[0].Rows[0]["Reference"].ToString();
                        cmbEmp.SelectedValue = dtQuotation.Tables[0].Rows[0]["EmpID"].ToString();
                        txtcontactperson.Text = dtQuotation.Tables[0].Rows[0]["ContactPerson"].ToString();
                        txtmobile.Text = dtQuotation.Tables[0].Rows[0]["Phone1"].ToString();
                        txtAddress.Text = dtQuotation.Tables[0].Rows[0]["Address"].ToString();
                        txtemail.Text = dtQuotation.Tables[0].Rows[0]["Email"].ToString();
                        txtRemarks.Text = dtQuotation.Tables[0].Rows[0]["Remarks_Orignal"].ToString();
                        txtcc.Text = dtQuotation.Tables[0].Rows[0]["CC"].ToString();
                        txtbcc.Text = dtQuotation.Tables[0].Rows[0]["BCC"].ToString();
                        cmbEmpAllocatedTo.SelectedValue = dtQuotation.Tables[0].Rows[0]["AllocatedToEmpID"].ToString();
                        cmbCategory.Text = dtQuotation.Tables[0].Rows[0]["Category"].ToString();
                        cmbStatus.Text = dtQuotation.Tables[0].Rows[0]["InterestLevel"].ToString();
                        //txtDocName.Text = dtQuotation.Tables[0].Rows[0]["FileName"].ToString();
                        
                        /* Code For Revised Quotation number */
                        if (_Mode == (int)Common.Constant.Mode.View)
                        {
                            while (lblPICheck.Text != "0")
                            {
                                DataTable dtAddRe = new DataTable();
                                NameValueCollection paraAddRe = new NameValueCollection();
                                paraAddRe.Add("@i_PiNo", txtPINo.Text);
                                dtAddRe = objDA.ExecuteDataTableSP("usp_Revised", paraAddRe, false, ref mException, ref mErrorMsg, "Revised PINO");
                                txtPINo.Text = dtAddRe.Rows[0][0].ToString();

                                DataTable dtcount = new DataTable();
                                NameValueCollection paraCount = new NameValueCollection();
                                paraCount.Add("@i_QuoCode", txtPINo.Text.Trim());
                                dtcount = objDA.ExecuteDataTableSP("usp_Check_Revised", paraCount, false, ref mException, ref mErrorMsg, "Quotation-New");
                                lblPICheck.Text = dtcount.Rows[0][0].ToString();
                            }
                        }//for revised quotation code end

                        /* code for Docs open*/

                        if (dtQuotation.Tables[1] != null && dtQuotation.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow DRow in dtQuotation.Tables[1].Rows)
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

        #endregion

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
            objQuotationBL.DeleteTNC_On_Close("QUOTATION", txtPINo.Text);
        }


        private void btnLeadLOV_Click(object sender, EventArgs e)
        {

            frmCustomerLOV fLOV = new frmCustomerLOV("usp_Customer_LOV", null);
            fLOV.Text = "List Of Customer";
            fLOV.ShowDialog();
            txtLeadNo.Text = fLOV.CustomerCode;
            // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
            txtCustName.Text = fLOV.CustomerName;
            _LeadID = fLOV.CustomerID;
            txtemail.Text = fLOV.Email;
            txtmobile.Text = fLOV.Phone1;
            txtcontactperson.Text = fLOV.ContactPerson;
            txtLeaddate.Text = fLOV.SaleDate.ToShortDateString();
            txtAddress.Text = fLOV.Address;
            cmbCategory.Text = fLOV.Category;
            cmbEmp.SelectedValue = fLOV.EmpID;
            cmbEmpAllocatedTo.SelectedValue = fLOV.AllocatedToEmpID;
        }



        private void txtAdvAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtAdvAmt_Leave(object sender, EventArgs e)
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
        }

        private void btnNew_Click(object sender, EventArgs e)
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
            Quotation.frmQuotationItemEntry fPIEntry = new Quotation.frmQuotationItemEntry((int)Constant.Mode.Insert, _PIID, _CustomerID, dtpSaleDate.Value, dtPIDetail, 0);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
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

        private void btnTNC_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);
                dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
               // frmTNCLOV obj = new frmTNCLOV();
              
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
                    frmTNCLOV fLOV = new frmTNCLOV("usp_QuotationTNC_Select", para, txtPINo.Text,IsAllTNC, "QUOTATION");
                    fLOV.Text = "List Of Terms & Conditions";
                    if (chkTNC.Checked == true)
                    {
                        fLOV.IsAllTNC_Check = "True";
                    }
                    else
                    {
                        fLOV.IsAllTNC_Check = "False";
                    }

                    fLOV.ShowDialog();

                    if (fLOV.IsAllTNC_Check == "False")
                    {
                        chkTNC.Checked = false;
                    }
                    else
                    {
                        chkTNC.Checked = true;
                    }

                    TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                }
                else
                {
                    if (chkTNC.Checked == true)
                    {
                        IsAllTNC = "True";
                    }
                    else
                    {
                        IsAllTNC = "False";
                    }
                    frmTNCLOV fLOV = new frmTNCLOV("usp_TNC_LOV", null, txtPINo.Text, IsAllTNC, "QUOTATION");
                    fLOV.Text = "List Of Terms & Conditions";
                    //if (chkTNC.Checked == true)
                    //{
                    //    fLOV.IsAllTNC_Check = "True";
                    //}
                    //else
                    //{
                    //    fLOV.IsAllTNC_Check = "False";
                    //}

                    fLOV.ShowDialog();

                    if (fLOV.IsAllTNC_Check == "False")
                    {
                        chkTNC.Checked = false;
                    }
                    else
                    {
                        chkTNC.Checked = true;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtPINo.Text = objCommon.AutoNumber("QU");
        }

        public void SendToMail()
        {
            try
            {

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                DataTable dtQuoId = new DataTable();
                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_Code", txtPINo.Text);
                dtQuoId = objDA.ExecuteDataTableSP("usp_Quotation_Id", para1, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");


                frmQuotationList QL = new frmQuotationList();
                QL.RPT_Sub(Convert.ToInt64(dtQuoId.Rows[0][0].ToString()), txtPINo.Text, false);



                string pdfname = QL.PdfFile;

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Quotation");
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");

                if (dtEmail.Rows.Count > 0)
                {

                    vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    if (_Mode == (int)Common.Constant.Mode.View)
                    {
                        vSubject ="Revised "+ dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE
                    }
                    else
                    {
                        vSubject = dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE
                    }


                   // vSubject = dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY

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
                    vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"));
                    if (dtDocList.Rows.Count > 0)
                    {
                        foreach (DataRow dtr in dtDocList.Rows)
                        {
                            vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\"+dtr["FileName"].ToString()));
                        }
                    }
                    vMail.IsBodyHtml = true;


                    System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
                    System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(CurrentCompany.Con_Email, CurrentCompany.Con_Password);

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
                    vMail.Dispose();

                    if (File.Exists(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"))
                    {
                        File.Delete(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf");
                    }
                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Quotation.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
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

            Quotation.frmQuotationItemEntry fPIEntry = new Quotation.frmQuotationItemEntry((int)Constant.Mode.Modify, _SIID, _CustomerID, dtpSaleDate.Value, dtPIDetail, ItemID_Edit);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
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
            //if (txtDocName.Text == "")
            //{
            //    txtDocName.Focus();
            //    return;
            //}
            //DataRow dr = dtDocList.NewRow();
            //dr["FileName"] = txtDocName.Text;
            //dr["FullFileName"] = SelectedFileName;

            //dtDocList.Rows.Add(dr);


            //ArrangeDocumentGridView();
            //dgvCountry.AutoGenerateColumns = false;
            //dgvCountry.DataSource = dtDocList;
            //ArrangeDocumentGridView();
            //txtDocName.Text = "";
            //SelectedFileName = "";

            //btnAddDoc.Focus();

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
    }
}
