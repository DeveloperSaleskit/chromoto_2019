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

namespace Account.GUI.ServiceModule
{
    public partial class frmServiceModuleEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        ServiceModuleBL objServiceModuleBL = new ServiceModuleBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        CommonListBL objList = new CommonListBL();
        DataTable dtServiceModule = new DataTable();
        DataTable dtDocList = new DataTable();
        DataTable dtReminderList = new DataTable();
        DataTable dtPIDetail = new DataTable();
        int _Mode = 0;
        Int64 _ServiceId = 0;
        Int64 _SIID = 0;
        Int64 _CustomerID = 0;
        long _PIID = 0;
        string IsAllTNC;

        string SelectedFileName = "";

        Exception mException = null;
        string mErrorMsg = "";
        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            ds = CommSelect.SelectDataSetRecord(_ServiceId, "usp_ServiceModule_Select", "SalesInvoice - BindControl");
            ds1 = CommSelect.SelectDataSetRecord(_ServiceId, "usp_ServiceDocList_List", "SalesInvoice - BindControl");
            dtServiceModule = CommSelect.SelectRecord(_ServiceId, "usp_ServiceModule_Select", "ServiceModule - BindControl");
            //dtDocList = CommSelect.SelectRecord(_ServiceId, "usp_ServiceDocList_List", "ServiceDocList - BindControl");
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

                    if (dtServiceModule.Rows.Count > 0)
                    {
                        txtRequestNo.Text = dtServiceModule.Rows[0]["RequestNo"].ToString();
                        dtpReqDate.Value = Convert.ToDateTime(dtServiceModule.Rows[0]["ServiceDate"].ToString());
                        txtCustomerName.Text = dtServiceModule.Rows[0]["CustomerName"].ToString();
                        txtProblem.Text = dtServiceModule.Rows[0]["Problem"].ToString();
                        txtRemarks.Text = dtServiceModule.Rows[0]["Remarks"].ToString();
                        txtOtherReq.Text = dtServiceModule.Rows[0]["OtherRequirement"].ToString();
                        txtCharges.Text = dtServiceModule.Rows[0]["Charges"].ToString();
                        txtcontactperson.Text = dtServiceModule.Rows[0]["Charges"].ToString();
                        txtcontactperson.Text = dtServiceModule.Rows[0]["ContactPerson"].ToString();
                        txtmobileNo.Text = dtServiceModule.Rows[0]["Phone1"].ToString();
                        txtemail.Text = dtServiceModule.Rows[0]["Email"].ToString();

                        txtSaledate.Text = Convert.ToDateTime(dtServiceModule.Rows[0]["SalesDate"].ToString()).ToShortDateString();
                        txtAddress1.Text = dtServiceModule.Rows[0]["Address"].ToString();
                        cmbAttendedBy.SelectedValue = Convert.ToInt32(dtServiceModule.Rows[0]["AttendedBy"].ToString());
                        cmbEmpAllocatedTo.SelectedValue = Convert.ToInt32(dtServiceModule.Rows[0]["AllocatedToEmpID"].ToString());
                        cmbTypeofCall.SelectedValue = Convert.ToInt32(dtServiceModule.Rows[0]["CallID"].ToString());

                        _SIID = Convert.ToInt64(dtServiceModule.Rows[0]["SIID"].ToString());

                        txtNetAmount.Text = dtServiceModule.Rows[0]["NetAmount"].ToString();
                        cmbStatus.Text = dtServiceModule.Rows[0]["Status"].ToString();
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
                            dr["ServiceID"] = DRow["ServiceID"].ToString();
                            dtDocList.Rows.Add(dr);
                        }
                        ArrangeDocumentGridView();
                        dgvCountry.AutoGenerateColumns = false;
                        dgvCountry.DataSource = dtDocList;
                        ArrangeDocumentGridView();

                    }


                    DataSet ds3 = new DataSet();
                    NameValueCollection para1 = new NameValueCollection();

                    para1.Add("@i_Name", txtCustomerName.Text);
                    para1.Add("@i_SIID", _SIID.ToString());
                    ds3 = CommSelect.SelectDataSetRecord(para1, "usp_Reminder_Service_Select", "SalesInvoice - BindControl");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int p = 0;
                        dgvReminder.Rows.Clear();
                        foreach (DataRow DRow in ds3.Tables[0].Rows)
                        {
                            dgvReminder.Rows.Add();
                            if (Convert.ToInt16(DRow["SR_Done"].ToString()) == 1)
                            {
                                dgvReminder.Rows[p].Cells[0].Value = true;
                                dgvReminder.Rows[p].ReadOnly = true;
                            }
                            dgvReminder.Rows[p].Cells["SR_Code"].Value = DRow["SR_Code"].ToString();
                            dgvReminder.Rows[p].Cells["SR_Date"].Value = DRow["SR_Date"].ToString();
                            dgvReminder.Rows[p].Cells["SIID"].Value = DRow["SIID"].ToString();
                            dgvReminder.Rows[p].Cells["SRID"].Value = DRow["SRID"].ToString();
                            dgvReminder.Rows[p].Cells["CustomerID"].Value = DRow["CustomerID"].ToString();
                            dgvReminder.Rows[p].Cells["AttendedBy"].Value = DRow["AttendedBy"].ToString();
                            dgvReminder.Rows[p].Cells["Problem"].Value = DRow["Problem"].ToString();
                            dgvReminder.Rows[p].Cells["OtherRequirement"].Value = DRow["OtherRequirement"].ToString();
                            dgvReminder.Rows[p].Cells["SR_Done"].Value = DRow["SR_Done"].ToString();

                            p++;
                        }
                    }
                    else
                    {
                        dgvReminder.DataSource = null;
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
            bool ReturnValue = false;
            int p = 0;
            int SIID = 0;
            int SRID = 0;
            string ServiceId = "";

            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_ServiceId, "usp_ServiceModule_Delete", "ServiceModule Delete - SetSave");
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
                    if (DataValidator.IsValid(this.grpData))
                    {

                        //if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtNetAmount.Text))
                        //{
                        //    lblErrorMessage.Text = "Paid amount can not greater than net amount";
                        //    txtPaidAmount.Focus();
                        //    // return;
                        //}

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
                        if (Cnt == 0)
                        {
                            lblErrorMessage.Text = "Select at least one item";
                            dgvPIDetail.Focus();
                            // return;
                        }

                        if (_Mode == Convert.ToInt64(Common.Constant.Mode.Insert))
                        {
                            objServiceModuleBL.Insert(txtRequestNo.Text, dtpReqDate.Value, txtCustomerName.Text, _SIID, txtAddress1.Text,
                               txtmobileNo.Text, "", txtProblem.Text, Convert.ToInt64(cmbAttendedBy.SelectedValue), "", txtRemarks.Text,
                                txtOtherReq.Text, Convert.ToDecimal(txtCharges.Text), Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtExciseAmt.Text), Convert.ToDecimal(txtEduCessAmt.Text),
                                Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), XMLString, Cnt,
                               0, Convert.ToInt32(cmbTypeofCall.SelectedValue), "1", Convert.ToInt32(cmbEmpAllocatedTo.SelectedValue), cmbStatus.Text);





                            if (objServiceModuleBL.Exception == null)
                            {
                                string error = objServiceModuleBL.ErrorMessage;
                                if (objServiceModuleBL.ErrorMessage != "" || _ServiceId > 0)
                                {
                                    if (isRecordSave(objServiceModuleBL.ErrorMessage))
                                    {
                                        if (_ServiceId == 0)
                                            _ServiceId = Convert.ToInt64(objServiceModuleBL.ErrorMessage);
                                        foreach (DataRow dr in dtDocList.Rows)
                                        {
                                            if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                                            {
                                                // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                            }
                                            else
                                            {

                                                string newFileName = CurrentUser.DocumentPath + @"\" + txtRequestNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                                objServiceModuleBL.InsertServiceDocument(_ServiceId, newFileName, dr["DocRemark"].ToString());
                                                if (objServiceModuleBL.Exception == null)
                                                {
                                                    if (objServiceModuleBL.ErrorMessage == "")
                                                    {
                                                        //Move File                                    
                                                        File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                    }
                                                }
                                            }
                                        }

                                        lblErrorMessage.Text = "No error";
                                        ReturnValue = true;
                                        this.Close();
                                    }
                                    else
                                    {
                                        lblErrorMessage.Text = objServiceModuleBL.ErrorMessage;
                                        //    cmbSite.Focus();
                                        ReturnValue = false;
                                    }
                                }
                                else
                                {
                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                            }


                            dgvReminder.EndEdit();

                            for (int i = 0; i < dgvReminder.Rows.Count; i++)
                            {
                                SIID = Convert.ToInt16(dgvReminder.Rows[i].Cells["SIID"].Value);
                                SRID = Convert.ToInt16(dgvReminder.Rows[i].Cells["SRID"].Value);
                                ServiceId = txtRequestNo.Text;

                                if (Convert.ToInt16(dgvReminder.Rows[i].Cells["SR_DONE"].Value) == 0)
                                {
                                    if (Convert.ToBoolean(dgvReminder.Rows[i].Cells[0].Value) == true)
                                    {
                                        objServiceModuleBL.UpdateReminder(SIID, SRID, ServiceId);
                                    }
                                }
                            }





                            if (chkTNC.Checked == true)
                            {
                                NameValueCollection para1 = new NameValueCollection();
                                para1.Add("@i_TNC_SUB", "SERVICE");
                                DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                                for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                {
                                    objServiceModuleBL.InsertTNC("SERVICE", dtAllTNC.Rows[i][0].ToString(), txtRequestNo.Text);
                                }

                            }


                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objServiceModuleBL.Update(_ServiceId, txtRequestNo.Text, dtpReqDate.Value, txtCustomerName.Text, _SIID, txtAddress1.Text,
                               txtmobileNo.Text, "", txtProblem.Text, Convert.ToInt64(cmbAttendedBy.SelectedValue), "", txtRemarks.Text,
                                txtOtherReq.Text, Convert.ToDecimal(txtCharges.Text), Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtExciseAmt.Text), Convert.ToDecimal(txtEduCessAmt.Text),
                                Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), XMLString, Cnt,
                                0, Convert.ToInt32(cmbTypeofCall.SelectedValue), "012", Convert.ToInt32(cmbEmpAllocatedTo.SelectedValue),cmbStatus.Text);


                            if (objServiceModuleBL.Exception == null)
                            {
                                foreach (DataRow dr in dtDocList.Rows)
                                {
                                    if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                                    {
                                        objServiceModuleBL.InsertServiceDocument(_ServiceId, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                    }
                                    else
                                    {
                                        string newFileName = CurrentUser.DocumentPath + @"\" + txtRequestNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');

                                        objServiceModuleBL.InsertServiceDocument(_ServiceId, txtRequestNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'), dr["DocRemark"].ToString());
                                        if (objServiceModuleBL.Exception == null)
                                        {
                                            if (objServiceModuleBL.ErrorMessage == "")
                                            {
                                                //Move File                                    
                                                File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                            }
                                        }
                                    }
                                }
                            }
                            if (chksend.Checked == true)
                            {
                                SendToMail();
                            }
                            for (int i = 0; i < dgvReminder.Rows.Count; i++)
                            {
                                SIID = Convert.ToInt16(dgvReminder.Rows[i].Cells["SIID"].Value);
                                SRID = Convert.ToInt16(dgvReminder.Rows[i].Cells["SRID"].Value);
                                ServiceId = txtRequestNo.Text;

                                if (Convert.ToInt16(dgvReminder.Rows[i].Cells["SR_Done"].Value) == 0)
                                {
                                    if (Convert.ToBoolean(dgvReminder.Rows[i].Cells[0].Value) == true)
                                    {
                                        objServiceModuleBL.UpdateReminder(SIID, SRID, ServiceId);
                                    }
                                }
                            }

                        }

                        if (chksend.Checked == true)
                        {
                            SendToMail();
                        }

                        if (objServiceModuleBL.Exception == null)
                        {
                            if (objServiceModuleBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objServiceModuleBL.ErrorMessage;
                                txtRequestNo.Focus();
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
                            MessageBox.Show(objServiceModuleBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }
            }

            return ReturnValue;
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Close();
            }
        }


        #endregion

        public frmServiceModuleEntry(int Mode, long LeadID)
        {
            InitializeComponent();
            _Mode = Mode;
            _ServiceId = LeadID;
            _SIID = LeadID;
        }

        private void frmServiceModuleEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                objCommon.FillEmployeeCombo(cmbAttendedBy);
                objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);
                objCommon.FillTypeofcallCombo(cmbTypeofCall);
                DataValidator.SetDefaultDate(dtpReqDate, null, null);

                dtDocList.Columns.Add("DocID");
                dtDocList.Columns.Add("FileName");
                dtDocList.Columns.Add("FullFileName");
                dtDocList.Columns.Add("DocRemark");
                dtDocList.Columns.Add("ServiceID");

                //  objCommon.FillGodownCombo(cmbgodown);

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    cmbAttendedBy.SelectedIndex = 0;
                    txtRequestNo.Text = objCommon.AutoNumber("SR");
                    this.Text = "Service - New";
                    LoadPIDetailList();
                    dtpReqDate.Value = DateTime.Now;
                    cmbStatus.SelectedIndex = 0;

                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnRegenrate.Visible = false;
                    this.Text = "Service - Edit";
                    chkTNC.Enabled = false;
                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();
                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    btnRegenrate.Visible = false;
                    btnSaveExit.Text = "Yes";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    btnCancel.Text = "No";
                    this.Text = "Service - Delete";
                }

                dgvReminder.ReadOnly = false;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ServiceModule-FormLoad", exc.StackTrace);
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

                ArrangePIDetailGridView();
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
            objServiceModuleBL.DeleteTNC_On_Close("SERVICE", txtRequestNo.Text);

        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtRequestNo.Text = objCommon.AutoNumber("SR");
        }

        private void txtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtBudget_Leave(object sender, EventArgs e)
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

        private void btnLeadLOV_Click(object sender, EventArgs e)
        {
            try
            {
                //NameValueCollection para = new NameValueCollection();
                //para.Add("@i_TypeOfSale", cmbTypeofSale.SelectedItem.ToString());
                frmCustomerLOV fLOV = new frmCustomerLOV("usp_Customer_LOV_Service", null);
                fLOV.isFromService = true;
                fLOV.ShowDialog();

                txtCustomerName.Text = fLOV.CustomerName;
                txtcontactperson.Text = fLOV.ContactPerson;
                txtemail.Text = fLOV.Email;
                txtmobileNo.Text = fLOV.Phone1;
                txtwarrantyDate.Text = fLOV.ReminderDate.ToShortDateString();
                txtAddress1.Text = fLOV.Address;
                _SIID = fLOV.CustomerID;
                txtSaledate.Text = fLOV.SaleDate.ToShortDateString();
                //  cmbTypeofSale.Text = fLOV.TypeOfSale;

                DataSet ds = new DataSet();
                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_Name", txtCustomerName.Text);
                para1.Add("@i_SIID", _SIID.ToString());
                ds = CommSelect.SelectDataSetRecord(para1, "usp_Reminder_For_Service", "SalesInvoice - BindControl");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int p = 0;
                    dgvReminder.Rows.Clear();
                    foreach (DataRow DRow in ds.Tables[0].Rows)
                    {
                        dgvReminder.Rows.Add();
                        if (Convert.ToInt16(DRow["SR_Done"].ToString()) == 1)
                        {
                            dgvReminder.Rows[p].Cells[0].Value = true;
                            dgvReminder.Rows[p].ReadOnly = true;
                        }
                        dgvReminder.Rows[p].Cells["SR_Code"].Value = DRow["SR_Code"].ToString();
                        dgvReminder.Rows[p].Cells["SR_Date"].Value = DRow["SR_Date"].ToString();
                        dgvReminder.Rows[p].Cells["SIID"].Value = DRow["SIID"].ToString();
                        dgvReminder.Rows[p].Cells["SRID"].Value = DRow["SRID"].ToString();
                        dgvReminder.Rows[p].Cells["CustomerID"].Value = DRow["CustomerID"].ToString();
                        dgvReminder.Rows[p].Cells["AttendedBy"].Value = DRow["attendedBy"].ToString();
                        dgvReminder.Rows[p].Cells["Problem"].Value = DRow["Problem"].ToString();
                        dgvReminder.Rows[p].Cells["OtherRequirement"].Value = DRow["OtherRequirement"].ToString();
                        dgvReminder.Rows[p].Cells["SR_Done"].Value = DRow["SR_Done"].ToString();

                        p++;
                    }


                }
                else
                {
                    dgvReminder.DataSource = null;
                }

                if (fLOV.CustomerName == null)
                {
                    _SIID = 0;

                    txtSaledate.Text = "";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
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
            if (txtDocName.Text == "")
            {
                txtDocName.Focus();
                return;
            }
            DataRow dr = dtDocList.NewRow();
            dr["DocID"] = "0";
            dr["ServiceID"] = _ServiceId;
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


        public void ArrangeDocumentGridView()
        {
            dgvCountry.Columns[1].DataPropertyName = dtDocList.Columns["DocID"].ToString();
            dgvCountry.Columns[2].DataPropertyName = dtDocList.Columns["FileName"].ToString();
            dgvCountry.Columns[3].DataPropertyName = dtDocList.Columns["DocRemark"].ToString();
            dgvCountry.Columns[4].DataPropertyName = dtDocList.Columns["FullFileName"].ToString();
            dgvCountry.Columns[5].DataPropertyName = dtDocList.Columns["ServiceID"].ToString();

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

        private void dgvCountry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    if (dgvCountry.Rows[e.RowIndex].Cells["ServiceID"].Value.ToString().Length > 0 && Convert.ToInt32(dgvCountry.Rows[e.RowIndex].Cells["ServiceID"].Value.ToString()) > 0)
                        strFile = dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();
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
                //  dtPIDetail.Columns.Clear();
                if (dtPIDetail.Columns.Count == 0)
                {

                    LoadPIDetailList();
                }
            }

            ServiceModule.frmServiceItemEntry fPIEntry = new ServiceModule.frmServiceItemEntry(_PIID, _CustomerID, dtpReqDate.Value, dtPIDetail);
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
                    txtCSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(TotalAmount)", "")).ToString("#0.00");
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
                DataAccess.DataAccess objDA = new DataAccess.DataAccess();
                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtRequestNo.Text);
                dtQTNC = objDA.ExecuteDataTableSP("usp_ServicesTNC_Select", para, false, ref mException, ref mErrorMsg, "Services TNC - Select");
                string TNC_Sub = "SERVICE";
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
                    frmTNCLOV fLOV = new frmTNCLOV("usp_ServicesTNC_Select", para, txtRequestNo.Text, "SERVICE");
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
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
                    frmTNCLOV fLOV = new frmTNCLOV("usp_TNC_LOV", null, txtRequestNo.Text, "SERVICE");
                    fLOV.Text = "List Of Terms & Conditions";
                    fLOV.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Services", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void SendToMail()
        {
            try
            {

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Services");
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");

                if (dtEmail.Rows.Count > 0)
                {
                    vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    vSubject = dtEmail.Rows[0][0].ToString() + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
                    vDetails += "<br /><br />";

                    vDetails += " <BR> <BR> <b>SR No : " + txtRequestNo.Text + "</b>"; // DETAIL PART OF BODY
                    vDetails += "<BR> <BR>  <b> Date : " + dtpReqDate.Value.Day + "/" + dtpReqDate.Value.Month + "/" + dtpReqDate.Value.Year + "</b>";

                    vDetails += "<BR> <BR>  <b> Product/Problem : </b>" + txtProblem.Text.Replace("\n", "<br />") + "";
                    vDetails += "<BR> <BR>  <b> Solution : </b>" + txtOtherReq.Text.Replace("\n", "<br />") + "";
                    vDetails += "<BR> <BR>   <b> Service Person </b>: " + cmbAttendedBy.Text + "<BR> <BR>";

                    //vDetails += "<html><head><title></title></head><body><table style=&quot;width: 100%;&quot; border=&quot;1&quot;>" +
                    //            "<tr align=&quot;center&quot; style=&quot;font-weight: bold&quot;><td>ITEM</td><td>QTY</td><td>UOM</td>" +
                    //            "<td>RATE</td><td>AMOUNT</td></tr>";

                    //for (int i = 0; i < dgvPIDetail.RowCount; i++)
                    //{
                    //    vDetails += "<tr><td align=&quot;left&quot;> " + dgvPIDetail.Rows[i].Cells[1].Value.ToString() +
                    //                "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells[3].Value.ToString() +
                    //                "</td><td align=&quot;left&quot;>" + dgvPIDetail.Rows[i].Cells[4].Value.ToString() +
                    //                "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells[5].Value.ToString() +
                    //                "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells[6].Value.ToString() +
                    //                "</td></tr>";
                    //}

                    //vDetails += "</table></body></html>";
                    //vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text + "</b>";

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
                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Service.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
            }
        }

       
    }
}
