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
        int SerTNC = 0;
        string SelectedFileName = "";
        int CompId = 0;
        int _CompId = 0;

        Exception mException = null;
        string mErrorMsg = "";

        DataTable dtContactDetail = new DataTable();

        DataTable dtQContactDetail = new DataTable();
        DataTable dtblLOV = new DataTable();

        string StrFilter = "";
        DataView DV;

        bool IsCustomer;
        string LeadNo = "";
        Int64 _CurrencyID;
        bool IsFirstItem;
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

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        dtContactDetail = ds.Tables[4].DefaultView.ToTable();
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
                        txtmobileNo.Text = dtServiceModule.Rows[0]["Mobile"].ToString();
                        txtemail.Text = dtServiceModule.Rows[0]["Email"].ToString();

                        txtSaledate.Text = dtServiceModule.Rows[0]["SalesDate"].ToString();
                        txtAddress1.Text = dtServiceModule.Rows[0]["Address"].ToString();
                        cmbAttendedBy.SelectedValue = Convert.ToInt32(dtServiceModule.Rows[0]["AttendedBy"].ToString());
                        cmbEmpAllocatedTo.SelectedValue = Convert.ToInt32(dtServiceModule.Rows[0]["EmpAllToID"].ToString());
                        cmbTypeofCall.SelectedValue = Convert.ToInt32(dtServiceModule.Rows[0]["CallID"].ToString());

                        _SIID = Convert.ToInt64(dtServiceModule.Rows[0]["SIID"].ToString());
                        _CustomerID = Convert.ToInt64(dtServiceModule.Rows[0]["CustomerID"].ToString());
                        txtNetAmount.Text = dtServiceModule.Rows[0]["NetAmount"].ToString();
                        cmbStatus.Text = dtServiceModule.Rows[0]["Status"].ToString();
                        cmbgodown.SelectedValue = dtServiceModule.Rows[0]["GodownID"].ToString();
                        LeadNo = ds.Tables[0].Rows[0]["LeadNo"].ToString();

                        txtcc.Text = ds.Tables[0].Rows[0]["CC"].ToString();
                        txtbcc.Text = ds.Tables[0].Rows[0]["BCC"].ToString();

                        if (dtServiceModule.Rows[0]["ReminderDate"].ToString() != "")
                        {
                            txtSaledate.Text = Convert.ToDateTime(dtServiceModule.Rows[0]["ReminderDate"].ToString()).ToShortDateString();
                        }
                        else
                        {
                            txtwarrantyDate.Text = dtServiceModule.Rows[0]["ReminderDate"].ToString();
                        }

                        if (dtServiceModule.Rows[0]["IsCustomer"].ToString() == "True")
                        {
                            IsCustomer = true;
                        }
                        else
                        {
                            IsCustomer = false;
                        }
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
                    para1.Add("@i_CustomerID", _CustomerID.ToString());
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
                            dgvReminder.Rows[p].Cells["EmpID"].Value = DRow["EmpAllToID"].ToString();
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

                    //------------------------- new contact-------------
                    NameValueCollection para2 = new NameValueCollection();
                    para2.Add("@i_Code", txtRequestNo.Text);
                    para2.Add("@i_CompID", CurrentCompany.CompId.ToString());
                    if (dtContactDetail.Columns.Count > 0)
                    {

                    }
                    else
                    {
                        LoadContactDetailList();
                    }

                    dtQContactDetail = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para2, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
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
            int EmpID = 0;
            string Problem = "";
            string Solution = "";
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

                            XMLString = XMLString + "<GodownID>" + dtPIDetail.Rows[i]["GodownID"] + "</GodownID>"; XMLString = XMLString + "<GodownID>" + dtPIDetail.Rows[i]["GodownID"] + "</GodownID>";

                            XMLString = XMLString + "<ItemDesc>" + dtPIDetail.Rows[i]["ItemDesc"] + "</ItemDesc>";
                            XMLString = XMLString + "<Qty>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Qty"]).ToString("#0.00") + "</Qty>";
                            XMLString = XMLString + "<Rate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Rate"]).ToString("#0.00") + "</Rate>";

                            XMLString = XMLString + "<CurrencyID>" + dtPIDetail.Rows[i]["CurrencyID"] + "</CurrencyID>";

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


                            XMLString = XMLString + "<SBCessRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["SBCessRate"]).ToString("#0.00") + "</SBCessRate>";
                            XMLString = XMLString + "<SBCessAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["SBCessAmount"]).ToString("#0.00") + "</SBCessAmount>";

                            XMLString = XMLString + "<ExtraTaxRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExtraTaxRate"]).ToString("#0.00") + "</ExtraTaxRate>";
                            XMLString = XMLString + "<ExtraTaxAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExtraTaxAmount"]).ToString("#0.00") + "</ExtraTaxAmount>";


                            XMLString = XMLString + "<NetAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["NetAmount"]).ToString("#0.00") + "</NetAmount>";
                            XMLString = XMLString + "</Table> ";
                            Cnt = Cnt + 1;
                        }
                        //XMLString = XMLString + "</NewDataSet>";
                        XMLString = XMLString.ToString().Replace("&", "&amp;") + "</NewDataSet>";

                        //long Cnt1 = 0;
                        //string XMLString1 = string.Empty;

                        //XMLString1 = "<NewDataSet>";
                        //for (int j = 0; j < dgvReminder.Rows.Count; j++)
                        //{
                        //    XMLString1 = XMLString1 + "<Table>";
                        //    XMLString1 = XMLString1 + "<SR_Code>" + dgvReminder.Rows[j].Cells["SR_CODE"].Value.ToString() + "</SR_Code>";
                        //    XMLString1 = XMLString1 + "<SR_Date>" + Convert.ToDateTime(dgvReminder.Rows[j].Cells["SR_Date"].Value) + "</SR_Date>";
                        //    XMLString1 = XMLString1 + "<SIID>" + Convert.ToInt16(dgvReminder.Rows[j].Cells["SIID"].Value) + "</SIID>";
                        //    XMLString1 = XMLString1 + "<SR_Done>" + Convert.ToInt16(dgvReminder.Rows[j].Cells["SR_DONE"].Value) + "</SR_Done>";
                        //    XMLString1 = XMLString1 + "<ServiceId>" + Convert.ToInt16(dgvReminder.Rows[j].Cells["SRID"].Value) + "</ServiceId>";

                        //    XMLString1 = XMLString1 + "</Table> ";
                        //    Cnt1 = Cnt1 + 1;
                        //}
                        ////XMLString = XMLString + "</NewDataSet>";
                        //XMLString1 = XMLString1.ToString().Replace("&", "&amp;") + "</NewDataSet>";

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
                                Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtSBCessAmount.Text), Convert.ToDecimal(txtExtraTax.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), XMLString, Cnt,
                               Convert.ToInt32(cmbgodown.SelectedValue.ToString()), Convert.ToInt32(cmbTypeofCall.SelectedValue), "1", Convert.ToInt32(cmbEmpAllocatedTo.SelectedValue), cmbStatus.Text, CompId, _CustomerID, IsCustomer, txtcc.Text, txtbcc.Text
                                , txtcontactperson.Text, txtemail.Text, txtmobileNo.Text
                               );


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
                                EmpID = Convert.ToInt16(dgvReminder.Rows[i].Cells["EmpID"].Value);
                                Problem = dgvReminder.Rows[i].Cells["Problem"].Value.ToString();
                                Solution = dgvReminder.Rows[i].Cells["OtherRequirement"].Value.ToString();
                                ServiceId = txtRequestNo.Text;

                                if (Convert.ToInt16(dgvReminder.Rows[i].Cells["SR_DONE"].Value) == 0)
                                {
                                    if (Convert.ToBoolean(dgvReminder.Rows[i].Cells[0].Value) == true)
                                    {
                                        objServiceModuleBL.UpdateReminder(SIID, SRID, ServiceId, EmpID, Problem, Solution, 0);
                                    }
                                }

                            }

                            if (chksend.Checked == true)
                            {
                                SendToMail();
                            }

                            //if (chkTNC.Checked == true)
                            //{
                            //    NameValueCollection para1 = new NameValueCollection();
                            //    para1.Add("@i_TNC_SUB", "SERVICE");
                            //    para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                            //    DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                            //    for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                            //    {
                            //        objServiceModuleBL.InsertTNC("SERVICE", dtAllTNC.Rows[i][0].ToString(), txtRequestNo.Text);
                            //    }
                            //}
                            if (chkTNC.Checked == true)
                            {
                                NameValueCollection para1 = new NameValueCollection();
                                para1.Add("@i_TNC_SUB", "SERVICE");
                                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                                DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                                //for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                //{
                                //objServiceModuleBL.InsertTNC("SERVICE", dtAllTNC.Rows[i][0].ToString(), txtRequestNo.Text);
                                //}

                                long Cnt2 = 0;
                                string XMLString2 = string.Empty;

                                XMLString2 = "<NewDataSet>";
                                for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                {
                                    XMLString2 = XMLString2 + "<Table>";
                                    XMLString2 = XMLString2 + "<Code>" + txtRequestNo.Text + "</Code>";
                                    XMLString2 = XMLString2 + "<TNC_Sub>" + "SERVICE" + "</TNC_Sub>";
                                    //XMLString = XMLString + "<ItemODesc>" + dtPIDetail.Rows[i]["ItemODesc"] + "</ItemODesc>";
                                    XMLString2 = XMLString2 + "<TNC_Desc>" + dtAllTNC.Rows[i]["TNC_Desc"].ToString() + "</TNC_Desc>";
                                    XMLString2 = XMLString2 + "<CompId>" + CurrentCompany.CompId.ToString() + "</CompId>";

                                    XMLString2 = XMLString2 + "</Table> ";
                                    Cnt2 = Cnt2 + 1;
                                }
                                XMLString2 = XMLString2 + "</NewDataSet>";

                                objServiceModuleBL.InsertTNC_NEW(XMLString2, Cnt2);
                            }
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objServiceModuleBL.Update(_ServiceId, txtRequestNo.Text, dtpReqDate.Value, txtCustomerName.Text, _SIID, txtAddress1.Text,
                               txtmobileNo.Text, "", txtProblem.Text, Convert.ToInt64(cmbAttendedBy.SelectedValue), "", txtRemarks.Text,
                                txtOtherReq.Text, Convert.ToDecimal(txtCharges.Text), Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtExciseAmt.Text), Convert.ToDecimal(txtEduCessAmt.Text),
                                Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtSBCessAmount.Text), Convert.ToDecimal(txtExtraTax.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), XMLString, Cnt,
                                Convert.ToInt32(cmbgodown.SelectedValue.ToString()), Convert.ToInt32(cmbTypeofCall.SelectedValue), "012", Convert.ToInt32(cmbEmpAllocatedTo.SelectedValue), cmbStatus.Text, CompId, _CustomerID, IsCustomer, txtcc.Text, txtbcc.Text
                                   , txtcontactperson.Text, txtemail.Text, txtmobileNo.Text
                                );


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
                                EmpID = Convert.ToInt16(dgvReminder.Rows[i].Cells["EmpID"].Value);
                                Problem = dgvReminder.Rows[i].Cells["Problem"].Value.ToString();
                                Solution = dgvReminder.Rows[i].Cells["OtherRequirement"].Value.ToString();
                                ServiceId = txtRequestNo.Text;

                                if (Convert.ToInt16(dgvReminder.Rows[i].Cells["SR_DONE"].Value) == 0)
                                {
                                    if (Convert.ToBoolean(dgvReminder.Rows[i].Cells[0].Value) == true)
                                    {
                                        objServiceModuleBL.UpdateReminder(SIID, SRID, ServiceId, EmpID, Problem, Solution, 0);
                                    }
                                }
                            }
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
            SerTNC = 1;
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

                btnLeadLOV.BackColor = Color.LightSkyBlue;
                btnTNC.BackColor = Color.LightSkyBlue;
                btnNew.BackColor = Color.LightSkyBlue;

                objCommon.FillEmployeeCombo(cmbAttendedBy);
                objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);
                objCommon.FillTypeofcallCombo(cmbTypeofCall);
                objCommon.FillGodownCombo(cmbgodown);
                objCommon.FillCurrencyCombo(cmbCurrency);
                // DataValidator.SetDefaultDate(dtpReqDate, null, null);

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
                    LoadList();
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

                DataColumn clmCurrencyID = new DataColumn("CurrencyID");
                clmCurrencyID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmCurrencyID);

                DataColumn clmCurrency = new DataColumn("Currency");
                clmCurrency.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmCurrency);

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

                DataColumn clmSBCessRate = new DataColumn("SBCessRate");
                clmSBCessRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmSBCessRate);

                DataColumn clmSBCessAmount = new DataColumn("SBCessAmount");
                clmSBCessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmSBCessAmount);

                DataColumn clmExtraTaxRate = new DataColumn("ExtraTaxRate");
                clmExtraTaxRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExtraTaxRate);

                DataColumn clmExtraTaxAmount = new DataColumn("ExtraTaxAmount");
                clmExtraTaxAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExtraTaxAmount);

                DataColumn clmNetAmount = new DataColumn("NetAmount");
                clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmNetAmount);

                DataColumn clmGodownID = new DataColumn("GodownID");
                clmGodownID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmGodownID);

                ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());

                dtblLOV = objList.ListOfRecord("usp_Customer_LOV_Service", para, "Customer LOV - LoadList");

                txtCustomerName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtCustomerName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection Data = new AutoCompleteStringCollection();

                if (objList.Exception == null)
                {

                    for (int i = 0; i < dtblLOV.Rows.Count; i++)
                    {
                        Data.Add(dtblLOV.Rows[i]["CustomerName"].ToString());
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
                Utill.Common.ExceptionLogger.writeException("Customer LOV", exc.StackTrace);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (_Mode == (int)Constant.Mode.Insert)
            {
                objServiceModuleBL.DeleteTNC_On_Close("SERVICE", txtRequestNo.Text);
            }

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
                NameValueCollection para = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());

                //NameValueCollection para = new NameValueCollection();
                //para.Add("@i_TypeOfSale", cmbTypeofSale.SelectedItem.ToString());
                frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId, "usp_Customer_LOV_Service", para);
                fLOV.isFromService = true;
                fLOV.ShowDialog();

                txtCustomerName.Text = fLOV.CustomerName;
                txtcontactperson.Text = fLOV.ContactPerson;
                txtemail.Text = fLOV.Email;
                txtmobileNo.Text = fLOV.MobileNo;
                txtwarrantyDate.Text = fLOV.ReminderDate.ToShortDateString();
                txtAddress1.Text = fLOV.Address;
                _SIID = fLOV.CustomerID;
                _CustomerID = fLOV.LeadID;
                txtSaledate.Text = fLOV.SaleDate.ToShortDateString();

                cmbAttendedBy.SelectedValue = fLOV.EmpID;
                cmbEmpAllocatedTo.SelectedValue = fLOV.AllocatedToEmpID;
                IsCustomer = fLOV.IsCustomer;
                //  cmbTypeofSale.Text = fLOV.TypeOfSale;
                LeadNo = fLOV.CustomerCode;


                //if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                //{
                //    IsCustomer = true;
                //}
                //else
                //{
                //    IsCustomer = false;
                //}

                DataSet ds = new DataSet();
                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_Name", txtCustomerName.Text);
                para1.Add("@i_CustomerID", _CustomerID.ToString());
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
                        //dgvReminder.Rows[p].Cells["EmpID"].Value = DRow["EmpAllToID"].ToString();
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

                //--------------------NEW FOR CONTACT DETAILS -----------------
                NameValueCollection para2 = new NameValueCollection();
                para2.Add("@i_Code", txtRequestNo.Text);
                para2.Add("@i_CompID", CurrentCompany.CompId.ToString());
                if (dtContactDetail.Columns.Count > 0)
                {

                }
                else
                {
                    LoadContactDetailList();
                }

                dtQContactDetail = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                if (dtQContactDetail != null)
                { }
                btnContactPerson.Focus();
                //--------------------NEW FOR CONTACT DETAILS -----------------
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage1, "Warning");
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
            //if (Convert.ToInt16(cmbgodown.SelectedValue) == 0)
            //{
            //    MessageBox.Show("First Select Godown.");
            //    return;
            //}
           // else
           // {
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
                int godown = Convert.ToInt32(cmbgodown.SelectedValue);
                _CurrencyID = Convert.ToInt64(cmbCurrency.SelectedValue);
                ServiceModule.frmServiceItemEntry fPIEntry = new ServiceModule.frmServiceItemEntry((int)Constant.Mode.Insert, _PIID, _CustomerID, dtpReqDate.Value, dtPIDetail, godown, 0, _CurrencyID, false);
                fPIEntry.ShowDialog();
                dgvPIDetail.AutoGenerateColumns = false;
                dgvPIDetail.DataSource = dtPIDetail;
                ArrangePIDetailGridView();
                CalculateNetAmount();
            //}
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

                    txtSBCessAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(SBCessAmount)", "")).ToString("#0.00");
                    txtExtraTax.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ExtraTaxAmount)", "")).ToString("#0.00");

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
                dgvPIDetail.Columns["Currency"].DataPropertyName = dtPIDetail.Columns["Currency"].ToString();
                dgvPIDetail.Columns["CurrencyID"].DataPropertyName = dtPIDetail.Columns["CurrencyID"].ToString();
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
                dgvPIDetail.Columns["SBCessAmount"].DataPropertyName = dtPIDetail.Columns["SBCessAmount"].ToString();
                dgvPIDetail.Columns["ExtraTaxAmount"].DataPropertyName = dtPIDetail.Columns["ExtraTaxAmount"].ToString();
                dgvPIDetail.Columns["NetAmount"].DataPropertyName = dtPIDetail.Columns["NetAmount"].ToString();
                dgvPIDetail.Columns["GodownID"].DataPropertyName = dtPIDetail.Columns["GodownID"].ToString();

                for (int i = 0; i < dgvPIDetail.Columns.Count; i++)
                {
                    dgvPIDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dgvPIDetail.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvPIDetail.Rows.Count; i++)
                    {
                        cmbCurrency.SelectedValue = dgvPIDetail.Rows[0].Cells["CurrencyID"].Value.ToString();
                    }
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
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
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
                    frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_ServicesTNC_Select", para, txtRequestNo.Text, "SERVICE");
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
                    frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_TNC_LOV", null, txtRequestNo.Text, "SERVICE");
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
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
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

                    vDetails += " <BR> <BR> <b>SR No : " + txtRequestNo.Text + "</b>"; // DETAIL PART OF BODY
                    vDetails += "<BR> <BR>  <b> Date : " + dtpReqDate.Value.Day + "/" + dtpReqDate.Value.Month + "/" + dtpReqDate.Value.Year + "</b>";

                    vDetails += "<BR> <BR>  <b> Product/Problem : </b>" + txtProblem.Text.Replace("\n", "<br />") + "";
                    vDetails += "<BR> <BR>  <b> Solution : </b>" + txtOtherReq.Text.Replace("\n", "<br />") + "";
                    vDetails += "<BR> <BR>   <b> Service Person </b>: " + cmbAttendedBy.Text + "<BR> <BR>";

                    vDetails += "<BR> <BR>   <b> Service Status </b>: " + cmbStatus.Text + "<BR> <BR>";


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
                    vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text + " Rs." + "</b>";
                    vDetails += "<BR> <BR>   <b> Service Charges </b>: " + txtCharges.Text + " Rs." + "<BR> <BR>";


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

        private void frmServiceModuleEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Mode == (int)Constant.Mode.Insert)
            {
                if (SerTNC == 0)
                {
                    objServiceModuleBL.DeleteTNC_On_Close("SERVICE", txtRequestNo.Text);
                }
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtRequestNo.Text);
                para.Add("@i_CompID", CurrentCompany.CompId.ToString());
                //if (_Mode == (int)Common.Constant.Mode.Insert)
                //{
                //    LoadContactDetailList();
                //}
                if (dtContactDetail.Columns.Count > 0)
                {

                }
                else
                {
                    LoadContactDetailList();
                }

                dtQTNC = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                if (IsCustomer == true)
                {
                    if (dtQTNC != null)
                    {
                        if (dtQTNC.Rows.Count > 0)
                        {
                            ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SECUpdate, 1, LeadNo.Substring(5, 5), txtRequestNo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SERVICE");
                            fLOV.Text = "List Of Conatct Details";
                            fLOV.ShowDialog();
                            dtQTNC = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                            //-----------For MuliContact Display ----------
                            string MultiContact = "";
                            string MultiEmail = "";
                            string MultiMobile = "";
                            for (int i = 0; i < dtQTNC.Rows.Count; i++)
                            {
                                // +=    
                                MultiContact += dtQTNC.Rows[i]["ContactName"].ToString() + ",";
                                MultiEmail += dtQTNC.Rows[i]["Email"].ToString() + ",";
                                MultiMobile += dtQTNC.Rows[i]["Mobile"].ToString() + ",";
                            }
                            txtcontactperson.Text = MultiContact.TrimEnd(',');
                            txtemail.Text = MultiEmail.TrimEnd(',');
                            txtmobileNo.Text = MultiMobile.TrimEnd(',');
                            //--------------------------
                        }
                        else
                        {
                            ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SECInsert, 1, LeadNo.Substring(5, 5), txtRequestNo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SERVICE");
                            fLOV.Text = "List Of Conatct Details";
                            fLOV.ShowDialog();
                            dtQTNC = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                            //-----------For MuliContact Display ----------
                            string MultiContact = "";
                            string MultiEmail = "";
                            string MultiMobile = "";
                            for (int i = 0; i < dtQTNC.Rows.Count; i++)
                            {
                                // +=    
                                MultiContact += dtQTNC.Rows[i]["ContactName"].ToString() + ",";
                                MultiEmail += dtQTNC.Rows[i]["Email"].ToString() + ",";
                                MultiMobile += dtQTNC.Rows[i]["Mobile"].ToString() + ",";
                            }
                            txtcontactperson.Text = MultiContact.TrimEnd(',');
                            txtemail.Text = MultiEmail.TrimEnd(',');
                            txtmobileNo.Text = MultiMobile.TrimEnd(',');
                            //--------------------------
                        }
                    }
                }
                else
                {
                    if (dtQTNC != null)
                    {
                        if (dtQTNC.Rows.Count > 0)
                        {
                            ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SECUpdate, 4, LeadNo.Substring(4, 5), txtRequestNo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SERVICE");
                            fLOV.Text = "List Of Conatct Details";
                            fLOV.ShowDialog();
                            dtQTNC = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                            //-----------For MuliContact Display ----------
                            string MultiContact = "";
                            string MultiEmail = "";
                            string MultiMobile = "";
                            for (int i = 0; i < dtQTNC.Rows.Count; i++)
                            {
                                // +=    
                                MultiContact += dtQTNC.Rows[i]["ContactName"].ToString() + ",";
                                MultiEmail += dtQTNC.Rows[i]["Email"].ToString() + ",";
                                MultiMobile += dtQTNC.Rows[i]["Mobile"].ToString() + ",";
                            }
                            txtcontactperson.Text = MultiContact.TrimEnd(',');
                            txtemail.Text = MultiEmail.TrimEnd(',');
                            txtmobileNo.Text = MultiMobile.TrimEnd(',');
                            //--------------------------
                        }
                        else
                        {
                            ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SECInsert, 4, LeadNo.Substring(4, 5), txtRequestNo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SERVICE");
                            fLOV.Text = "List Of Conatct Details";
                            fLOV.ShowDialog();
                            dtQTNC = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                            //-----------For MuliContact Display ----------
                            string MultiContact = "";
                            string MultiEmail = "";
                            string MultiMobile = "";
                            for (int i = 0; i < dtQTNC.Rows.Count; i++)
                            {
                                // +=    
                                MultiContact += dtQTNC.Rows[i]["ContactName"].ToString() + ",";
                                MultiEmail += dtQTNC.Rows[i]["Email"].ToString() + ",";
                                MultiMobile += dtQTNC.Rows[i]["Mobile"].ToString() + ",";
                            }
                            txtcontactperson.Text = MultiContact.TrimEnd(',');
                            txtemail.Text = MultiEmail.TrimEnd(',');
                            txtmobileNo.Text = MultiMobile.TrimEnd(',');
                            //--------------------------
                        }
                    }
                }
                //else
                //{

                //}
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvReminder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvReminder.Rows[e.RowIndex].Cells["EmpID"].Value = cmbEmpAllocatedTo.SelectedValue.ToString();
                dgvReminder.Rows[e.RowIndex].Cells["AttendedBy"].Value = cmbEmpAllocatedTo.Text;
                dgvReminder.Rows[e.RowIndex].Cells["Problem"].Value = txtProblem.Text;
                dgvReminder.Rows[e.RowIndex].Cells["OtherRequirement"].Value = txtOtherReq.Text;
            }
        }

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                StrFilter = "";
                if (dtblLOV != null)
                {
                    if (dtblLOV.Rows.Count > 0)
                    {
                        if (txtCustomerName.Text.Trim() != "")
                        {
                            StrFilter = StrFilter + " CustomerName = '" + PrepareFilterString(txtCustomerName.Text.Trim()) + "' OR ";
                        }

                        if (StrFilter != "")
                        {
                            StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                        }

                        DV = dtblLOV.DefaultView;
                        DV.RowFilter = StrFilter;
                        DataTable dtCustomer = new DataTable();
                        dtCustomer = DV.ToTable();
                        if (DV.ToTable() != null)
                        {
                            if (DV.ToTable().Rows.Count > 0)
                            {
                                //txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                                // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
                                txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                                _SIID = Convert.ToInt64(dtCustomer.Rows[0]["SIID"].ToString());
                                _CustomerID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                                txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                                txtmobileNo.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                                txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                                txtSaledate.Text = dtCustomer.Rows[0]["SalesDate"].ToString();
                                txtwarrantyDate.Text = dtCustomer.Rows[0]["ReminderDate"].ToString();
                                txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                                //cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                                cmbAttendedBy.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                                cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();
                                LeadNo = dtCustomer.Rows[0]["Code"].ToString();

                                if (dtCustomer.Rows[0]["Code"].ToString().Contains("CUST"))
                                {
                                    IsCustomer = true;
                                }
                                else
                                {
                                    IsCustomer = false;
                                }

                                //_QuotationID = Convert.ToInt64(dtCustomer.Rows[0]["QuotationID"].ToString());

                                //DataTable dtquotation = new DataTable();
                                //if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                                //{
                                //    _CustomerID = 0;
                                //    dgvPIDetail.DataSource = null;
                                //}
                                //if (_QuotationID != 0)
                                //{
                                //    dtquotation = CommSelect.SelectRecord(_QuotationID, "usp_Sale_Quotation", "Godown - BindControl");
                                //    dgvPIDetail.DataSource = dtquotation;
                                //    dgvPIDetail.Columns["QuotationId"].Visible = false;
                                //    dtPIDetail = dtquotation;
                                //    dgvPIDetail.AutoGenerateColumns = false;
                                //    ArrangePIDetailGridView();
                                //    dgvPIDetail.Columns["Discount"].Visible = true;

                                //}
                                //CalculateNetAmount();


                                DataSet ds = new DataSet();
                                NameValueCollection para1 = new NameValueCollection();
                                para1.Add("@i_Name", txtCustomerName.Text);
                                para1.Add("@i_CustomerID", _CustomerID.ToString());
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
                                        dgvReminder.Rows[p].Cells["EmpID"].Value = DRow["EmpAllToID"].ToString();
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

                                if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                                {
                                    _SIID = 0;

                                    txtSaledate.Text = "";
                                }
                                btnContactPerson.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCustomerName.Focus();
                            }
                        }

                        //dgvLOV.DataSource = DV.ToTable();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt16(cmbgodown.SelectedValue) == 0)
            //{
            //    MessageBox.Show("First Select Godown.");
            //    return;
            //}
            //else
            //{
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

            _CurrencyID = Convert.ToInt64(cmbCurrency.SelectedValue);
            int godown = Convert.ToInt32(cmbgodown.SelectedValue);
            int GodownID_Edit = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["GodownID"].Value);
            ServiceModule.frmServiceItemEntry fPIEntry = new ServiceModule.frmServiceItemEntry((int)Constant.Mode.Modify, _ServiceId, _CustomerID, dtpReqDate.Value, dtPIDetail, GodownID_Edit, ItemID_Edit, _CurrencyID, IsFirstItem);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                for (int i = 0; i < dgvPIDetail.Rows.Count; i++)
                {
                    cmbCurrency.SelectedValue = dgvPIDetail.Rows[0].Cells["CurrencyID"].Value.ToString();
                }
            }

            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                for (int i = 1; i < dgvPIDetail.Rows.Count; i++)
                {
                    cmbCurrency.SelectedValue = dgvPIDetail.Rows[dgvPIDetail.Rows.Count - 1].Cells["CurrencyID"].Value.ToString();
                }
            }

            CalculateNetAmount();
            // }
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            StrFilter = "";
            if (dtblLOV != null)
            {
                if (dtblLOV.Rows.Count > 0)
                {
                    if (txtCustomerName.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerName = '" + PrepareFilterString(txtCustomerName.Text.Trim()) + "' OR ";
                    }

                    if (StrFilter != "")
                    {
                        StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                    }

                    DV = dtblLOV.DefaultView;
                    DV.RowFilter = StrFilter;
                    DataTable dtCustomer = new DataTable();
                    dtCustomer = DV.ToTable();
                    if (DV.ToTable() != null)
                    {
                        if (DV.ToTable().Rows.Count > 0)
                        {
                            //txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                            // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
                            txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                            _SIID = Convert.ToInt64(dtCustomer.Rows[0]["SIID"].ToString());
                            _CustomerID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                            txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                            txtmobileNo.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                            txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                            txtSaledate.Text = dtCustomer.Rows[0]["SalesDate"].ToString();
                            txtwarrantyDate.Text = dtCustomer.Rows[0]["ReminderDate"].ToString();
                            txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                            //cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                            cmbAttendedBy.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();
                            LeadNo = dtCustomer.Rows[0]["Code"].ToString();


                            if (dtCustomer.Rows[0]["Code"].ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }

                            //_QuotationID = Convert.ToInt64(dtCustomer.Rows[0]["QuotationID"].ToString());

                            //DataTable dtquotation = new DataTable();
                            //if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                            //{
                            //    _CustomerID = 0;
                            //    dgvPIDetail.DataSource = null;
                            //}
                            //if (_QuotationID != 0)
                            //{
                            //    dtquotation = CommSelect.SelectRecord(_QuotationID, "usp_Sale_Quotation", "Godown - BindControl");
                            //    dgvPIDetail.DataSource = dtquotation;
                            //    dgvPIDetail.Columns["QuotationId"].Visible = false;
                            //    dtPIDetail = dtquotation;
                            //    dgvPIDetail.AutoGenerateColumns = false;
                            //    ArrangePIDetailGridView();
                            //    dgvPIDetail.Columns["Discount"].Visible = true;

                            //}
                            //CalculateNetAmount();


                            DataSet ds = new DataSet();
                            NameValueCollection para1 = new NameValueCollection();
                            para1.Add("@i_Name", txtCustomerName.Text);
                            para1.Add("@i_CustomerID", _CustomerID.ToString());
                            para1.Add("@i_SIID", _SIID.ToString());
                            ds = CommSelect.SelectDataSetRecord(para1, "usp_Reminder_For_Service", "SalesInvoice - BindControl");
                            if (ds != null)
                            {
                                if (ds.Tables[0] != null)
                                {
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
                                            dgvReminder.Rows[p].Cells["EmpID"].Value = DRow["EmpAllToID"].ToString();
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
                                }
                            }
                            if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                            {
                                _SIID = 0;

                                txtSaledate.Text = "";
                            }
                            btnContactPerson.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCustomerName.Focus();
                        }
                    }

                    //dgvLOV.DataSource = DV.ToTable();
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
