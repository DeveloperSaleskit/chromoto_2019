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

namespace Account.GUI.PurchaseInvoice
{
    public partial class frmPurchaseInvoiceEdit : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonListBL objList = new CommonListBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        PurchaseInvoiceBL objPOBL = new PurchaseInvoiceBL();
        int _Mode = 0;
        Int64 _POID;
        DataSet dsPO = new DataSet();
        DataTable dtPODetail = new DataTable();
        Int64 _VendorID;
        DataTable dtPO = new DataTable();
        string StrDelete = "";

        #endregion

        #region "Form Events...."

        public frmPurchaseInvoiceEdit(int Mode, Int64 POID)
        {
            InitializeComponent();
            _Mode = Mode;
            _POID = POID;
        }

        private void frmPurchaseInvoiceEdit_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvPODetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            InitializaPODetaildt();
            BindControl();

            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                SetReadOnlyControls(grpData);
                lblDelMsg.Visible = true;
                btnSaveExit.Text = "Yes";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                btnCancel.Text = "No";
                this.Text = "Purchase Invoice - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void InitializaPODetaildt()
        {
            try
            {
                DataColumn dcItemID = new DataColumn("ItemID");
                dcItemID.DataType = System.Type.GetType("System.Int32");
                dtPO.Columns.Add(dcItemID);

                DataColumn dcItemName = new DataColumn("ItemName");
                dcItemName.DataType = System.Type.GetType("System.String");
                dtPO.Columns.Add(dcItemName);

                DataColumn dcUOM = new DataColumn("UOM");
                dcUOM.DataType = System.Type.GetType("System.String");
                dtPO.Columns.Add(dcUOM);

                DataColumn dcQty = new DataColumn("Qty");
                dcQty.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcQty);

                DataColumn dcRate = new DataColumn("Rate");
                dcRate.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcRate);

                DataColumn dcAmount = new DataColumn("Amount");
                dcAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcAmount);

                DataColumn dcDiscAmount = new DataColumn("DiscAmount");
                dcDiscAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcDiscAmount);

                DataColumn dcAssessableValue = new DataColumn("AssessableValue");
                dcAssessableValue.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcAssessableValue);

                DataColumn dcExciseAmount = new DataColumn("ExciseAmount");
                dcExciseAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcExciseAmount);

                DataColumn dcEduCessAmount = new DataColumn("EduCessAmount");
                dcEduCessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcEduCessAmount);

                DataColumn dcHEduCessAmount = new DataColumn("HEduCessAmount");
                dcHEduCessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcHEduCessAmount);

                DataColumn dcTotalAmount = new DataColumn("TotalAmount");
                dcTotalAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcTotalAmount);

                DataColumn dcCSTAmount = new DataColumn("CSTAmount");
                dcCSTAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcCSTAmount);

                DataColumn dcVATAmount = new DataColumn("VATAmount");
                dcVATAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcVATAmount);

                DataColumn dcAVATAmount = new DataColumn("AVATAmount");
                dcAVATAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcAVATAmount);

                DataColumn dcNetAmount = new DataColumn("NetAmount");
                dcNetAmount.DataType = System.Type.GetType("System.Decimal");
                dtPO.Columns.Add(dcNetAmount);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        public void PrepareDetail()
        {
            try
            {
                decimal Qty = 0;
                decimal Amount = 0;
                decimal DiscAmount = 0;
                decimal AssessableValue = 0;
                decimal ExciseAmount = 0;
                decimal EduCessAmount = 0;
                decimal HEduCessAmount = 0;
                decimal TotalAmount = 0;
                decimal CSTAmount = 0;
                decimal VATAmount = 0;
                decimal AVATAmount = 0;
                decimal NetAmount = 0;
                dtPO.Clear();

                for (int i = 0; i < dtPODetail.Rows.Count; i++)
                {
                    if (i < dtPODetail.Rows.Count - 1)
                    {
                        Qty = Qty + Convert.ToDecimal(dtPODetail.Rows[i]["Qty"]);
                        Amount = Amount + Convert.ToDecimal(dtPODetail.Rows[i]["Amount"]);
                        DiscAmount = DiscAmount + Convert.ToDecimal(dtPODetail.Rows[i]["DiscAmount"]);
                        AssessableValue = AssessableValue + Convert.ToDecimal(dtPODetail.Rows[i]["AssessableValue"]);
                        ExciseAmount = ExciseAmount + Convert.ToDecimal(dtPODetail.Rows[i]["ExciseAmount"]);
                        EduCessAmount = EduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["EduCessAmount"]);
                        HEduCessAmount = HEduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["HEduCessAmount"]);
                        TotalAmount = TotalAmount + Convert.ToDecimal(dtPODetail.Rows[i]["TotalAmount"]);
                        CSTAmount = CSTAmount + Convert.ToDecimal(dtPODetail.Rows[i]["CSTAmount"]);
                        VATAmount = VATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["VATAmount"]);
                        AVATAmount = AVATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["AVATAmount"]);
                        NetAmount = NetAmount + Convert.ToDecimal(dtPODetail.Rows[i]["NetAmount"]);

                        if (Convert.ToInt64(dtPODetail.Rows[i]["ItemID"]) != Convert.ToInt64(dtPODetail.Rows[i + 1]["ItemID"]))
                        {
                            DataRow dr;
                            dr = dtPO.NewRow();

                            dr["ItemID"] = dtPODetail.Rows[i]["ItemID"];
                            dr["ItemName"] = dtPODetail.Rows[i]["ItemName"];
                            dr["UOM"] = dtPODetail.Rows[i]["UOM"];
                            dr["Qty"] = Qty;
                            dr["Rate"] = dtPODetail.Rows[i]["Rate"];
                            dr["Amount"] = Amount;
                            dr["DiscAmount"] = DiscAmount;
                            dr["AssessableValue"] = AssessableValue;
                            dr["ExciseAmount"] = ExciseAmount;
                            dr["EduCessAmount"] = EduCessAmount;
                            dr["HEduCessAmount"] = HEduCessAmount;
                            dr["TotalAmount"] = TotalAmount;
                            dr["CSTAmount"] = CSTAmount;
                            dr["VATAmount"] = VATAmount;
                            dr["AVATAmount"] = AVATAmount;
                            dr["NetAmount"] = NetAmount;

                            dtPO.Rows.Add(dr);

                            Qty = 0;
                            Amount = 0;
                            DiscAmount = 0;
                            AssessableValue = 0;
                            ExciseAmount = 0;
                            EduCessAmount = 0;
                            HEduCessAmount = 0;
                            TotalAmount = 0;
                            CSTAmount = 0;
                            VATAmount = 0;
                            AVATAmount = 0;
                            NetAmount = 0;
                        }

                    }
                    else
                    {
                        if (dtPODetail.Rows.Count == 1)
                        {
                            Qty = Qty + Convert.ToDecimal(dtPODetail.Rows[i]["Qty"]);
                            Amount = Amount + Convert.ToDecimal(dtPODetail.Rows[i]["Amount"]);
                            DiscAmount = DiscAmount + Convert.ToDecimal(dtPODetail.Rows[i]["DiscAmount"]);
                            AssessableValue = AssessableValue + Convert.ToDecimal(dtPODetail.Rows[i]["AssessableValue"]);
                            ExciseAmount = ExciseAmount + Convert.ToDecimal(dtPODetail.Rows[i]["ExciseAmount"]);
                            EduCessAmount = EduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["EduCessAmount"]);
                            HEduCessAmount = HEduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["HEduCessAmount"]);
                            TotalAmount = TotalAmount + Convert.ToDecimal(dtPODetail.Rows[i]["TotalAmount"]);
                            CSTAmount = CSTAmount + Convert.ToDecimal(dtPODetail.Rows[i]["CSTAmount"]);
                            VATAmount = VATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["VATAmount"]);
                            AVATAmount = AVATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["AVATAmount"]);
                            NetAmount = NetAmount + Convert.ToDecimal(dtPODetail.Rows[i]["NetAmount"]);
                        }
                        else
                        {
                            if (Convert.ToInt64(dtPODetail.Rows[i]["ItemID"]) == Convert.ToInt64(dtPODetail.Rows[i - 1]["ItemID"]))
                            {
                                Qty = Qty + Convert.ToDecimal(dtPODetail.Rows[i]["Qty"]);
                                Amount = Amount + Convert.ToDecimal(dtPODetail.Rows[i]["Amount"]);
                                DiscAmount = DiscAmount + Convert.ToDecimal(dtPODetail.Rows[i]["DiscAmount"]);
                                AssessableValue = AssessableValue + Convert.ToDecimal(dtPODetail.Rows[i]["AssessableValue"]);
                                ExciseAmount = ExciseAmount + Convert.ToDecimal(dtPODetail.Rows[i]["ExciseAmount"]);
                                EduCessAmount = EduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["EduCessAmount"]);
                                HEduCessAmount = HEduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["HEduCessAmount"]);
                                TotalAmount = TotalAmount + Convert.ToDecimal(dtPODetail.Rows[i]["TotalAmount"]);
                                CSTAmount = CSTAmount + Convert.ToDecimal(dtPODetail.Rows[i]["CSTAmount"]);
                                VATAmount = VATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["VATAmount"]);
                                AVATAmount = AVATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["AVATAmount"]);
                                NetAmount = NetAmount + Convert.ToDecimal(dtPODetail.Rows[i]["NetAmount"]);
                            }
                            else
                            {
                                Qty = 0;
                                Amount = 0;
                                DiscAmount = 0;
                                AssessableValue = 0;
                                ExciseAmount = 0;
                                EduCessAmount = 0;
                                HEduCessAmount = 0;
                                TotalAmount = 0;
                                CSTAmount = 0;
                                VATAmount = 0;
                                AVATAmount = 0;
                                NetAmount = 0;

                                Qty = Qty + Convert.ToDecimal(dtPODetail.Rows[i]["Qty"]);
                                Amount = Amount + Convert.ToDecimal(dtPODetail.Rows[i]["Amount"]);
                                DiscAmount = DiscAmount + Convert.ToDecimal(dtPODetail.Rows[i]["DiscAmount"]);
                                AssessableValue = AssessableValue + Convert.ToDecimal(dtPODetail.Rows[i]["AssessableValue"]);
                                ExciseAmount = ExciseAmount + Convert.ToDecimal(dtPODetail.Rows[i]["ExciseAmount"]);
                                EduCessAmount = EduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["EduCessAmount"]);
                                HEduCessAmount = HEduCessAmount + Convert.ToDecimal(dtPODetail.Rows[i]["HEduCessAmount"]);
                                TotalAmount = TotalAmount + Convert.ToDecimal(dtPODetail.Rows[i]["TotalAmount"]);
                                CSTAmount = CSTAmount + Convert.ToDecimal(dtPODetail.Rows[i]["CSTAmount"]);
                                VATAmount = VATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["VATAmount"]);
                                AVATAmount = AVATAmount + Convert.ToDecimal(dtPODetail.Rows[i]["AVATAmount"]);
                                NetAmount = NetAmount + Convert.ToDecimal(dtPODetail.Rows[i]["NetAmount"]);

                            }
                        }
                        DataRow dr;
                        dr = dtPO.NewRow();

                        dr["ItemID"] = dtPODetail.Rows[i]["ItemID"];
                        dr["ItemName"] = dtPODetail.Rows[i]["ItemName"];
                        dr["UOM"] = dtPODetail.Rows[i]["UOM"];
                        dr["Qty"] = Qty;
                        dr["Rate"] = dtPODetail.Rows[i]["Rate"];
                        dr["Amount"] = Amount;
                        dr["DiscAmount"] = DiscAmount;
                        dr["AssessableValue"] = AssessableValue;
                        dr["ExciseAmount"] = ExciseAmount;
                        dr["EduCessAmount"] = EduCessAmount;
                        dr["HEduCessAmount"] = HEduCessAmount;
                        dr["TotalAmount"] = TotalAmount;
                        dr["CSTAmount"] = CSTAmount;
                        dr["VATAmount"] = VATAmount;
                        dr["AVATAmount"] = AVATAmount;
                        dr["NetAmount"] = NetAmount;

                        dtPO.Rows.Add(dr);
                    }
                }

                ArrangeDataGridView();
                dgvPODetail.AutoGenerateColumns = false;
                dgvPODetail.DataSource = null;
                dgvPODetail.DataSource = dtPO;
                CalculateAmt();
                ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void CalculateAmt()
        {
            try
            {
                if (dtPO.Rows.Count > 0)
                {
                    txtAmount.Text = dtPO.Compute("Sum(Amount)", "").ToString();
                    txtDiscAmt.Text = dtPO.Compute("Sum(DiscAmount)", "").ToString();
                    txtAssessableAmt.Text = dtPO.Compute("Sum(AssessableValue)", "").ToString();
                    txtExciseAmt.Text = dtPO.Compute("Sum(ExciseAmount)", "").ToString();
                    txtEduCessAmt.Text = dtPO.Compute("Sum(EduCessAmount)", "").ToString(); ;
                    txtHEduCessAmt.Text = dtPO.Compute("Sum(HEduCessAmount)", "").ToString();
                    txtAmtwithExcise.Text = dtPO.Compute("Sum(TotalAmount)", "").ToString();
                    txtCSTAmt.Text = dtPO.Compute("Sum(CSTAmount)", "").ToString();
                    txtVATAmt.Text = dtPO.Compute("Sum(VATAmount)", "").ToString();
                    txtAVATAmt.Text = dtPO.Compute("Sum(AVATAmount)", "").ToString();
                    txtTotalNet.Text = dtPO.Compute("Sum(NetAmount)", "").ToString();
                    txtNetAmount.Text = (Convert.ToDecimal(txtTotalNet.Text) + Convert.ToDecimal(txtPackingCharge.Text)).ToString();
                }
                else
                {
                    txtAmount.Text = "0.00";
                    txtDiscAmt.Text = "0.00";
                    txtAssessableAmt.Text = "0.00";
                    txtExciseAmt.Text = "0.00";
                    txtEduCessAmt.Text = "0.00";
                    txtHEduCessAmt.Text = "0.00";
                    txtAmtwithExcise.Text = "0.00";
                    txtCSTAmt.Text = "0.00";
                    txtVATAmt.Text = "0.00";
                    txtAVATAmt.Text = "0.00";
                    txtTotalNet.Text = "0.00";
                    txtNetAmount.Text = "0.00";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        public void BindControl()
        {
            try
            {
                dsPO = CommSelect.SelectDataSetRecord(_POID, "usp_PurchaseInvoice_Select", "PurchaseInvoice - BindControl");

                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dsPO.Tables[0].Rows.Count > 0)
                        {
                            txtOrderNo.Text = dsPO.Tables[0].Rows[0]["PONo"].ToString();
                            txtOrderDate.Text = String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dsPO.Tables[0].Rows[0]["PODate"]));
                            _VendorID = Convert.ToInt64(dsPO.Tables[0].Rows[0]["VendorID"]);
                            txtVendor.Text = dsPO.Tables[0].Rows[0]["Vendor"].ToString();
                            txtPhone.Text = dsPO.Tables[0].Rows[0]["Phone1"].ToString();
                            txtAmount.Text = dsPO.Tables[0].Rows[0]["SubTotal"].ToString();
                            txtDiscAmt.Text = dsPO.Tables[0].Rows[0]["DiscAmount"].ToString();
                            txtAssessableAmt.Text = dsPO.Tables[0].Rows[0]["AssessableValue"].ToString();
                            txtExciseAmt.Text = dsPO.Tables[0].Rows[0]["ExciseAmount"].ToString();
                            txtEduCessAmt.Text = dsPO.Tables[0].Rows[0]["EduCessAmount"].ToString();
                            txtHEduCessAmt.Text = dsPO.Tables[0].Rows[0]["HEduCessAmount"].ToString();
                            txtAmtwithExcise.Text = dsPO.Tables[0].Rows[0]["TotalAmount"].ToString();
                            txtCSTAmt.Text = dsPO.Tables[0].Rows[0]["CSTAmount"].ToString();
                            txtVATAmt.Text = dsPO.Tables[0].Rows[0]["VATAmount"].ToString();
                            txtAVATAmt.Text = dsPO.Tables[0].Rows[0]["AVATAmount"].ToString();
                            txtPackingCharge.Text = dsPO.Tables[0].Rows[0]["PackageCharge"].ToString();
                            txtNetAmount.Text = dsPO.Tables[0].Rows[0]["NetAmount"].ToString();
                            txtNarration.Text = dsPO.Tables[0].Rows[0]["Narration"].ToString();

                            // Bind Detail record
                            dtPODetail = dsPO.Tables[1];

                            PrepareDetail();

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

        private void ArrangeDataGridView()
        {
            try
            {
                dgvPODetail.Columns["ItemID"].DataPropertyName = dtPO.Columns["ItemID"].ToString();
                dgvPODetail.Columns["ItemName"].DataPropertyName = dtPO.Columns["ItemName"].ToString();
                dgvPODetail.Columns["UOM"].DataPropertyName = dtPO.Columns["UOM"].ToString();
                dgvPODetail.Columns["Qty"].DataPropertyName = dtPO.Columns["Qty"].ToString();
                dgvPODetail.Columns["Rate"].DataPropertyName = dtPO.Columns["Rate"].ToString();
                dgvPODetail.Columns["Amount"].DataPropertyName = dtPO.Columns["Amount"].ToString();
                dgvPODetail.Columns["DiscAmount"].DataPropertyName = dtPO.Columns["DiscAmount"].ToString();
                dgvPODetail.Columns["AssessableValue"].DataPropertyName = dtPO.Columns["AssessableValue"].ToString();
                dgvPODetail.Columns["ExciseAmount"].DataPropertyName = dtPO.Columns["ExciseAmount"].ToString();
                dgvPODetail.Columns["EduCessAmount"].DataPropertyName = dtPO.Columns["EduCessAmount"].ToString();
                dgvPODetail.Columns["HEduCessAmount"].DataPropertyName = dtPO.Columns["HEduCessAmount"].ToString();
                dgvPODetail.Columns["TotalAmount"].DataPropertyName = dtPO.Columns["TotalAmount"].ToString();
                dgvPODetail.Columns["CSTAmount"].DataPropertyName = dtPO.Columns["CSTAmount"].ToString();
                dgvPODetail.Columns["VATAmount"].DataPropertyName = dtPO.Columns["VATAmount"].ToString();
                dgvPODetail.Columns["AVATAmount"].DataPropertyName = dtPO.Columns["AVATAmount"].ToString();
                dgvPODetail.Columns["NetAmount"].DataPropertyName = dtPO.Columns["NetAmount"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event..."

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               // frmPurchaseInvoiceItemEntry fPurchaseInvoice = new frmPurchaseInvoiceItemEntry(_POID, _VendorID, Convert.ToDateTime(txtOrderDate.Text), dtPODetail, dtPO);
                //fPurchaseInvoice.ShowDialog();
                PrepareDetail();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPODetail.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Int64 _ItemID;
                        _ItemID = Convert.ToInt64(dgvPODetail.CurrentRow.Cells["ItemID"].Value);

                        for (int i = 0; i < dtPODetail.Rows.Count; i++)
                        {
                            if (Convert.ToInt64(dtPODetail.Rows[i]["ItemID"]) == _ItemID)
                            {
                                StrDelete = StrDelete + dtPODetail.Rows[i]["PODetailID"].ToString() + ",";
                                dtPODetail.Rows[i].Delete();
                            }
                        }
                        dtPODetail.AcceptChanges();
                        PrepareDetail();
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    CommDelRec.DeleteRecord(_POID, "usp_PurchaseInvoice_Delete", "PurchaseInvoice - Delete");
                    if (CommDelRec.Exception == null)
                    {
                        if (CommDelRec.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = CommDelRec.ErrorMessage;
                            return;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (dgvPODetail.Rows.Count == 0)
                    {
                        btnAdd.Focus();
                        lblErrorMessage.Text = "Add at least one item";
                        return;
                    }
                    //Prepare XMLString
                    int Cnt = 0;
                    string XMLString = string.Empty;
                    XMLString = "<NewDataSet>";
                    for (int i = 0; i < dtPODetail.Rows.Count; i++)
                    {
                        if (Convert.ToInt64(dtPODetail.Rows[i]["PODetailID"]) == 0)
                        {
                            XMLString = XMLString + "<Table>";

                            XMLString = XMLString + "<ItemID>" + dtPODetail.Rows[i]["ItemID"] + "</ItemID>";
                            XMLString = XMLString + "<PRNDetailID>" + dtPODetail.Rows[i]["PRNDetailID"] + "</PRNDetailID>";
                            XMLString = XMLString + "<Qty>" + dtPODetail.Rows[i]["Qty"] + "</Qty>";
                            XMLString = XMLString + "<Rate>" + dtPODetail.Rows[i]["Rate"] + "</Rate>";
                            XMLString = XMLString + "<Amount>" + dtPODetail.Rows[i]["Amount"] + "</Amount>";
                            XMLString = XMLString + "<DiscRate>" + dtPODetail.Rows[i]["DiscRate"] + "</DiscRate>";
                            XMLString = XMLString + "<DiscAmount>" + dtPODetail.Rows[i]["DiscAmount"] + "</DiscAmount>";
                            XMLString = XMLString + "<AssessableValue>" + dtPODetail.Rows[i]["AssessableValue"] + "</AssessableValue>";
                            XMLString = XMLString + "<TaxClassID>" + dtPODetail.Rows[i]["TaxClassID"] + "</TaxClassID>";
                            XMLString = XMLString + "<ExciseRate>" + dtPODetail.Rows[i]["ExciseRate"] + "</ExciseRate>";
                            XMLString = XMLString + "<ExciseAmount>" + dtPODetail.Rows[i]["ExciseAmount"] + "</ExciseAmount>";
                            XMLString = XMLString + "<EduCessRate>" + dtPODetail.Rows[i]["EduCessRate"] + "</EduCessRate>";
                            XMLString = XMLString + "<EduCessAmount>" + dtPODetail.Rows[i]["EduCessAmount"] + "</EduCessAmount>";
                            XMLString = XMLString + "<HEduCessRate>" + dtPODetail.Rows[i]["HEduCessRate"] + "</HEduCessRate>";
                            XMLString = XMLString + "<HEduCessAmount>" + dtPODetail.Rows[i]["HEduCessAmount"] + "</HEduCessAmount>";
                            XMLString = XMLString + "<TotalAmount>" + dtPODetail.Rows[i]["TotalAmount"] + "</TotalAmount>";
                            XMLString = XMLString + "<CSTRate>" + dtPODetail.Rows[i]["CSTRate"] + "</CSTRate>";
                            XMLString = XMLString + "<CSTAmount>" + dtPODetail.Rows[i]["CSTAmount"] + "</CSTAmount>";
                            XMLString = XMLString + "<VATRate>" + dtPODetail.Rows[i]["VATRate"] + "</VATRate>";
                            XMLString = XMLString + "<VATAmount>" + dtPODetail.Rows[i]["VATAmount"] + "</VATAmount>";
                            XMLString = XMLString + "<AVATRate>" + dtPODetail.Rows[i]["AVATRate"] + "</AVATRate>";
                            XMLString = XMLString + "<AVATAmount>" + dtPODetail.Rows[i]["AVATAmount"] + "</AVATAmount>";
                            XMLString = XMLString + "<NetAmount>" + dtPODetail.Rows[i]["NetAmount"] + "</NetAmount>";
                            XMLString = XMLString + "<Naration>" + dtPODetail.Rows[i]["Narration"] + "</Naration>";

                            XMLString = XMLString + "</Table> ";
                            Cnt = Cnt + 1;
                        }
                    }
                    XMLString = XMLString + "</NewDataSet>";

                    if (StrDelete != "")
                    {
                        StrDelete = StrDelete.Remove(StrDelete.Length - 1, 1);
                    }

                    //objPOBL.Update(_POID, Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtDiscAmt.Text), Convert.ToDecimal(txtAssessableAmt.Text), Convert.ToDecimal(txtExciseAmt.Text), Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtPackingCharge.Text), Convert.ToDecimal(txtNetAmount.Text), txtNarration.Text, XMLString, Cnt, StrDelete);
                    if (objPOBL.Exception == null)
                    {
                        if (objPOBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objPOBL.ErrorMessage;
                            txtNarration.Focus();
                            StrDelete = StrDelete + ",";
                            return;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(objPOBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StrDelete = StrDelete + ",";
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Grid View Cellpainting Event"

        private void dgvPODetail_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvPODetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvPODetail, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Purchase Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox Event..."

        private void txtPackingCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtPackingCharge_Leave(object sender, EventArgs e)
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
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "999999999999999.99";
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
            CalculateAmt();
        }

        #endregion

    }
}
