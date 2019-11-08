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

namespace Account.GUI.CreditNote
{
    public partial class frmCreditNoteEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CreditNoteBL objPOBL = new CreditNoteBL();
        ServiceModuleBL objServiceModuleBL = new ServiceModuleBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        CommonListBL objList = new CommonListBL();
        DataTable dtServiceModule = new DataTable();
        DataTable dtDocList = new DataTable();
        DataTable dtReminderList = new DataTable();
        DataTable dtPIDetail = new DataTable();
        int _Mode = 0;
        Int64 _QuotationID = 0;
        string StrFilter = "";
        Int64 _ServiceId = 0;
        Int64 _SIID = 0;
        Int64 _CustomerID = 0;
        long PIID = 0;
        Int32 _PIID = 0;
        int STNC = 0;
        string IsAllTNC;
        int SerTNC = 0;
        string SelectedFileName = "";
        int CompId = 0;
        int _CompId = 0;
        bool IsCustomer;
        Int64 _SaleId = 0;
        Exception mException = null;
        string mErrorMsg = "";
        DataTable dtblLOV = new DataTable();
        DataView DV;

        DataTable dtContactDetail = new DataTable();

        DataTable dtQContactDetail = new DataTable();
        #endregion

        #region "Public Methods..."

        public void DeletePI()
        {
            try
            {
                
                CommDelRec.DeleteRecord(_PIID, "usp_CreditNote_Delete", "CreditNote - Delete");
                if (CommDelRec.Exception == null)
                {
                    if (CommDelRec.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = CommDelRec.ErrorMessage;
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
                    MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CreditNote", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public void BindControl()
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                ds = CommSelect.SelectDataSetRecord(_PIID, "usp_CreditNote_Select", "CreditNote - BindControl");
                //ds1 = CommSelect.SelectDataSetRecord(_SaleId, "usp_SaleDocList_List", "SalesInvoice - BindControl");
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

                        //////if (ds.Tables[4].Rows.Count > 0)
                        //////{
                        //////    dtContactDetail = ds.Tables[4].DefaultView.ToTable();
                        //////}

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            txtRequestNo.Text = ds.Tables[0].Rows[0]["CNnumber"].ToString();
                            _CustomerID = Convert.ToInt64(ds.Tables[0].Rows[0]["CustomerID"]);
                            dtpReqDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CNDate"]);
                            //     txtDCno.Text = ds.Tables[0].Rows[0]["DCNo"].ToString();
                            txtCustomerName.Text = ds.Tables[0].Rows[0]["CustomerName"].ToString();
                            //txtNarration.Text = ds.Tables[0].Rows[0]["Narration"].ToString();
                            txtAmount.Text = ds.Tables[0].Rows[0]["totalamount"].ToString();
                            txtServiceAmt.Text = ds.Tables[0].Rows[0]["ServiceAmount"].ToString();
                            txtExciseAmt.Text = ds.Tables[0].Rows[0]["ExciseAmount"].ToString();
                            txtEduCessAmt.Text = ds.Tables[0].Rows[0]["CessAmount"].ToString();
                            txtHEduCessAmt.Text = ds.Tables[0].Rows[0]["HCessAmount"].ToString();
                            txtAmtwithExcise.Text = ds.Tables[0].Rows[0]["AmountAfterExcise"].ToString();
                            txtCSTAmt.Text = ds.Tables[0].Rows[0]["CSTAmount"].ToString();
                            txtVATAmt.Text = ds.Tables[0].Rows[0]["VATAmount"].ToString();
                            txtAVATAmt.Text = ds.Tables[0].Rows[0]["AVATAmount"].ToString();
                            txtDiscount.Text = ds.Tables[0].Rows[0]["Discount"].ToString();
                            txtDicAmt.Text = ds.Tables[0].Rows[0]["TotalDiscAmt"].ToString();
                            txtAmount.Text = ds.Tables[0].Rows[0]["totalamount"].ToString();
                            txtNetAmount.Text = ds.Tables[0].Rows[0]["NetAmount"].ToString();
                            txtremark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                            txtcnamount.Text = ds.Tables[0].Rows[0]["Creditnoteamount"].ToString();
                            txtfinalamount.Text = ds.Tables[0].Rows[0]["finalamount"].ToString();
                            cmbAttendedBy.SelectedValue = ds.Tables[0].Rows[0]["EmpID"].ToString();
                            txtemail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                            txtmobileNo.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                            txtcontactperson.Text = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                            //txtcc.Text = ds.Tables[0].Rows[0]["CC"].ToString();
                            //txtbcc.Text = ds.Tables[0].Rows[0]["BCC"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = ds.Tables[0].Rows[0]["EmpAllToID"].ToString();
                            if (ds.Tables[0].Rows[0]["IsCustomer"].ToString() == "True")
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }

                            


                            
                            CalculateNetAmount();
                        }
                        //if (ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        //{

                        //    foreach (DataRow DRow in ds.Tables[2].Rows)
                        //    {
                        //        DataRow dr = dtDocList.NewRow();
                        //        dr["DocID"] = DRow["DocID"].ToString();
                        //        dr["FileName"] = DRow["DocName"].ToString();
                        //        dr["FullFileName"] = DRow["DocName"].ToString();
                        //        dr["DocRemark"] = DRow["Remarks"].ToString();
                        //        dr["SaleID"] = DRow["SaleID"].ToString();
                        //        dtDocList.Rows.Add(dr);
                        //    }
                        //    ArrangeDocumentGridView();
                        //    dgvCountry.AutoGenerateColumns = false;
                        //    dgvCountry.DataSource = dtDocList;
                        //    ArrangeDocumentGridView();
                        //}
                        //------------------------- new contact-------------
                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_Code", txtRequestNo.Text);

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
                Utill.Common.ExceptionLogger.writeException("CreditNote", exc.StackTrace);
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

        public bool SetSave()
        {
            
            return false;
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            STNC = 1;
            
            try
            {
                CalcFinalAmount();
                if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    DeletePI();
                }
                else
                {

                    if (DataValidator.IsValid(this.grpData))
                    {
                        

                        long Cnt = 0;
                        string XMLString = string.Empty;

                        XMLString = "<NewDataSet>";
                        for (int i = 0; i < dtPIDetail.Rows.Count; i++)
                        {
                            XMLString = XMLString + "<Table>";
                            XMLString = XMLString + "<GodownID>" + dtPIDetail.Rows[i]["GodownID"] + "</GodownID>";
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

                        //long Cnt1 = 0;
                        //string XMLString1 = string.Empty;
                        //dgvServicesReminder.EndEdit();


                        //XMLString1 = "<NewDataSet>";
                        //for (int i = 0; i < dgvServicesReminder.Rows.Count; i++)
                        //{
                        //    XMLString1 = XMLString1 + "<Table>";
                        //    XMLString1 = XMLString1 + "<SR_Code>" + dgvServicesReminder.Rows[i].Cells[0].Value.ToString() + "</SR_Code>";
                        //    XMLString1 = XMLString1 + "<SR_Date>" + Convert.ToDateTime(dgvServicesReminder.Rows[i].Cells[1].Value).ToString("MM/dd/yyyy") + "</SR_Date>";
                        //    XMLString1 = XMLString1 + "<SR_Done>" + "0" + "</SR_Done>";
                        //    XMLString1 = XMLString1 + "</Table> ";
                        //    Cnt1 = Cnt1 + 1;
                        //}
                        //XMLString1 = XMLString1 + "</NewDataSet>";


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

                            
                            PIID = objPOBL.Insert(txtRequestNo.Text, Convert.ToDateTime(dtpReqDate.Value),
                                _CustomerID,
                                
                                Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text),
                                Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text),
                                XMLString, Cnt,
                                //XMLString1, Cnt1,
                                Convert.ToInt16(cmbAttendedBy.SelectedValue),
                                Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), Convert.ToDecimal(txtDicAmt.Text), CompId,
                                txtremark.Text, Convert.ToDecimal(txtcnamount.Text), Convert.ToDecimal(txtfinalamount.Text), IsCustomer
                                //,Convert.ToInt16(cmbgodown.SelectedValue)
                                );


                            if (objPOBL.Exception == null)
                            {
                                string error = objPOBL.ErrorMessage;
                                if (objPOBL.ErrorMessage != "" || _SaleId > 0)
                                {
                                    if (isRecordSave(objPOBL.ErrorMessage))
                                    {
                            //////            if (_SaleId == 0)
                            //////                _SaleId = Convert.ToInt64(objPOBL.ErrorMessage);
                            //////            foreach (DataRow dr in dtDocList.Rows)
                            //////            {
                            //////                if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                            //////                {
                            //////                    // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                            //////                }
                            //////                else
                            //////                {
                            //////                    string newFileName = CurrentUser.DocumentPath + @"\" + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                            //////                    objPOBL.InsertSaleDocument(_SaleId, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'), dr["DocRemark"].ToString());

                            //////                    //string PINO = txtPINo.Text;
                            //////                    //string Module = PINO.Substring(0, 2);
                            //////                    //string Year = PINO.Substring(3, 5);
                            //////                    //string Code = PINO.Substring(9, 5);
                            //////                    //string DocCode = Module + "-" + Year + "-" + Code;                                                

                            //////                    if (objPOBL.Exception == null)
                            //////                    {
                            //////                        if (objPOBL.ErrorMessage == "")
                            //////                        {
                            //////                            //Move File
                            //////                            //if (Convert.ToInt32(dr["DocID"].ToString()) > 0)
                            //////                            //{
                            //////                            //    File.Copy(CurrentUser.DocumentPath + @"\" + dr["FullFileName"].ToString(), newFileName, true);
                            //////                            //}
                            //////                            //else
                            //////                            //{
                            //////                            File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                            //////                            // }
                            //////                        }
                            //////                    }
                            //////                }
                            //////            }

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

                            //if (chkTNC.Checked == true)
                            //{
                            //    NameValueCollection para1 = new NameValueCollection();
                            //    para1.Add("@i_TNC_SUB", "SALES");
                            //    DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                            //    for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                            //    {
                            //        objPOBL.InsertTNC("SALES", dtAllTNC.Rows[i][0].ToString(), txtPINo.Text);
                            //    }

                            //}
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

                            objPOBL.Update(_PIID, txtRequestNo.Text, Convert.ToDateTime(dtpReqDate.Value),
                                _CustomerID,

                                Convert.ToDecimal(txtServiceAmt.Text),
                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text),
                                Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtDiscount.Text),
                                Convert.ToDecimal(txtNetAmount.Text),
                                XMLString, Cnt,
                                //XMLString1, Cnt1,
                                Convert.ToInt16(cmbAttendedBy.SelectedValue),
                                Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), Convert.ToDecimal(txtDicAmt.Text), CompId,
                                txtremark.Text, Convert.ToDecimal(txtcnamount.Text), Convert.ToDecimal(txtfinalamount.Text), IsCustomer
                                //, Convert.ToInt16(cmbgodown.SelectedValue)
                                );


                            if (objPOBL.Exception == null)
                            {
                            ////    foreach (DataRow dr in dtDocList.Rows)
                            ////    {
                            ////        if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                            ////        {
                            ////            objPOBL.InsertSaleDocument(_SaleId, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                            ////        }
                            ////        else
                            ////        {
                            ////            //string PINO = txtPINo.Text;
                            ////            //string Module = PINO.Substring(0, 2);
                            ////            //string Year = PINO.Substring(3, 5);
                            ////            //string Code = PINO.Substring(9, 5);
                            ////            //string DocCode = Module + "-" + Year + "-" + Code;

                            ////            //string newFileName = CurrentUser.DocumentPath + DocCode + "_" + dr["FileName"].ToString();

                            ////            //objPOBL.InsertSaleDocument(_SaleId, DocCode + "_" + dr["FileName"].ToString(), dr["DocRemark"].ToString());

                            ////            string newFileName = CurrentUser.DocumentPath + @"\" + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                            ////            objPOBL.InsertSaleDocument(_SaleId, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'), dr["DocRemark"].ToString());

                            ////            if (objPOBL.Exception == null)
                            ////            {
                            ////                if (objPOBL.ErrorMessage == "")
                            ////                {
                            ////                    //Move File    


                            ////                    string fullfilename = dr["FullFileName"].ToString();
                            ////                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                            ////                }
                            ////            }
                            ////        }
                            ////    }
                            }


                        }
                        if (chksend.Checked == true)
                        {
                            //SendToMail();
                        }
                        if (objPOBL.Exception == null)
                        {
                            if (objPOBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objPOBL.ErrorMessage;
                                dtpReqDate.Focus();
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
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        public frmCreditNoteEntry(int Mode, long LeadID)
        {
            InitializeComponent();
            _Mode = Mode;
            _PIID = Convert.ToInt32(LeadID);
            _SIID = LeadID;
        }

        public void CalcFinalAmount()
        {
            try
            {
                double netamt = Convert.ToDouble(txtNetAmount.Text);
                double credtamt = Convert.ToDouble(txtcnamount.Text);

                if (netamt != 0)
                {
                    double finalamt = netamt;
                    txtfinalamount.Text = Convert.ToString(finalamt);
                }

                if (credtamt != 0)
                {
                    double finalamt = credtamt;
                    txtfinalamount.Text = Convert.ToString(finalamt);
                }

                if (netamt != 0 && credtamt != 0)
                {
                    double finalamt = netamt + credtamt;
                    txtfinalamount.Text = Convert.ToString(finalamt);
                }
            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            

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
                //DataValidator.SetDefaultDate(dtpReqDate, null, null);

                dtDocList.Columns.Add("DocID");
                dtDocList.Columns.Add("FileName");
                dtDocList.Columns.Add("FullFileName");
                dtDocList.Columns.Add("DocRemark");
                dtDocList.Columns.Add("ServiceID");

                //  objCommon.FillGodownCombo(cmbgodown);

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    cmbAttendedBy.SelectedIndex = 0;
                    txtRequestNo.Text = objCommon.AutoNumber("CN");
                    this.Text = "CreditNote - New";
                    LoadPIDetailList();
                    dtpReqDate.Value = DateTime.Now;
                    cmbStatus.SelectedIndex = 0;
                    btnNew.Enabled = true;
                    btnedit.Enabled = false;
                    LoadList();
                    cmbAttendedBy.SelectedValue = CurrentUser.empId.ToString();

                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnRegenrate.Visible = false;
                    this.Text = "CreditNote - Edit";
                    chkTNC.Enabled = false;
                    btnLeadLOV.Visible = false;
                    btnNew.Enabled = false;
                    btnedit.Enabled = true;
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
                    this.Text = "CreditNote - Delete";
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
                DataColumn clmGodownID = new DataColumn("GodownID");
                clmGodownID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmGodownID);

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
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
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

                dtblLOV = objList.ListOfRecord("usp_Customer_Quotation_LOV", para, "Customer LOV - LoadList");

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
            txtRequestNo.Text = objCommon.AutoNumber("CN");
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
                para.Add("@i_CompId", _CompId.ToString());
                //NameValueCollection para = new NameValueCollection();
                //para.Add("@i_TypeOfSale", cmbTypeofSale.SelectedItem.ToString());
                frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId,"usp_Customer_LOV_CreditNote", para);
                fLOV.isFromCreditNote = true;

                fLOV.ShowDialog();

                txtCustomerName.Text = fLOV.CustomerName;
                txtcontactperson.Text = fLOV.ContactPerson;
                txtemail.Text = fLOV.Email;
                txtmobileNo.Text = fLOV.Phone1;
                txtwarrantyDate.Text = fLOV.ReminderDate.ToShortDateString();
                txtAddress1.Text = fLOV.Address;
                _SIID = fLOV.CustomerID;
                _CustomerID = fLOV.CustomerID;
                txtSaledate.Text = fLOV.SaleDate.ToShortDateString();
                IsCustomer = fLOV.IsCustomer;
                //  cmbTypeofSale.Text = fLOV.TypeOfSale;

                DataSet ds = new DataSet();
                //NameValueCollection para1 = new NameValueCollection();
                //para1.Add("@i_Name", txtCustomerName.Text);
                //para1.Add("@i_SIID", _SIID.ToString());
                //ds = CommSelect.SelectDataSetRecord(para1, "usp_Reminder_For_Service", "SalesInvoice - BindControl");

                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    int p = 0;
                //    dgvReminder.Rows.Clear();
                //    foreach (DataRow DRow in ds.Tables[0].Rows)
                //    {
                //        dgvReminder.Rows.Add();
                //        if (Convert.ToInt16(DRow["SR_Done"].ToString()) == 1)
                //        {
                //            dgvReminder.Rows[p].Cells[0].Value = true;
                //            dgvReminder.Rows[p].ReadOnly = true;
                //        }
                //        dgvReminder.Rows[p].Cells["SR_Code"].Value = DRow["SR_Code"].ToString();
                //        dgvReminder.Rows[p].Cells["SR_Date"].Value = DRow["SR_Date"].ToString();
                //        dgvReminder.Rows[p].Cells["SIID"].Value = DRow["SIID"].ToString();
                //        dgvReminder.Rows[p].Cells["SRID"].Value = DRow["SRID"].ToString();
                //        dgvReminder.Rows[p].Cells["CustomerID"].Value = DRow["CustomerID"].ToString();
                //        dgvReminder.Rows[p].Cells["AttendedBy"].Value = DRow["attendedBy"].ToString();
                //        dgvReminder.Rows[p].Cells["Problem"].Value = DRow["Problem"].ToString();
                //        dgvReminder.Rows[p].Cells["OtherRequirement"].Value = DRow["OtherRequirement"].ToString();
                //        dgvReminder.Rows[p].Cells["SR_Done"].Value = DRow["SR_Done"].ToString();

                //        p++;
                //    }


                //}
                //else
                //{
                //    dgvReminder.DataSource = null;
                //}

                if (fLOV.CustomerName == null)
                {
                    _SIID = 0;

                    txtSaledate.Text = "";
                }

                //--------------------NEW FOR CONTACT DETAILS -----------------
                NameValueCollection para2 = new NameValueCollection();
                para2.Add("@i_Code", txtRequestNo.Text);

                if (dtContactDetail.Columns.Count > 0)
                {

                }
                else
                {
                    LoadContactDetailList();
                }

                //dtQContactDetail = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                //if (dtQContactDetail != null)
                //{ }

                //--------------------NEW FOR CONTACT DETAILS -----------------
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
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
            //lblErrorMessage.Text = "";
            //string StrItem = "#";
            //for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
            //{
            //    StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
            //}

            //if (_Mode == (int)Common.Constant.Mode.Modify)
            //{
            //    //  dtPIDetail.Columns.Clear();
            //    if (dtPIDetail.Columns.Count == 0)
            //    {

            //        LoadPIDetailList();
            //    }
            //}

            //ServiceModule.frmServiceItemEntry fPIEntry = new ServiceModule.frmServiceItemEntry(_PIID, _CustomerID, dtpReqDate.Value, dtPIDetail);
            //fPIEntry.ShowDialog();
            //dgvPIDetail.AutoGenerateColumns = false;
            //dgvPIDetail.DataSource = dtPIDetail;
            //ArrangePIDetailGridView();
            //CalculateNetAmount();
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

                    txtNetAmount.Text = "";
                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        if (Convert.ToDecimal(txtDiscount.Text) > 0)
                        {
                            //txtnamount.Text = (Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")) - Convert.ToDecimal(txtDiscount.Text)).ToString("#0.00");
                            txtNetAmount.Text = (Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")) - Convert.ToDecimal(txtDiscount.Text)).ToString("#0.00");
                        }
                        else
                        {
                            txtNetAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")).ToString("#0.00");
                            //if (txtextracharges.Text != null)
                            //{
                            //    //txtnamount.Text = (Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                            //    txtnamount.Text = ((Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                            //}
                            //if (txtextracharges2.Text != null)
                            //{
                            //    //txtnamount.Text = (Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                            //    txtnamount.Text = ((Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges2.Text)).ToString());
                            //}
                            //if (txtextracharges3.Text != null)
                            //{
                            //    //txtnamount.Text = (Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                            //    txtnamount.Text = ((Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                            //}
                        }
                        //if()
                    }
                    else
                    {
                        txtNetAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")).ToString("#0.00");
                        //if (txtextracharges.Text != null)
                        //{
                        //    //txtnamount.Text = (Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges.Text)).ToString();
                        //    txtnamount.Text = ((Convert.ToDecimal(txtnamount.Text) + Convert.ToDecimal(txtextracharges.Text) + Convert.ToDecimal(txtextracharges2.Text) + Convert.ToDecimal(txtextracharges3.Text)).ToString());
                        //}
                    }

                    if (Convert.ToDecimal(discount) > 0)
                    {
                        //txtDiscount.Text = discount.ToString();
                        txtDiscount.Text = "";
                        txtDiscount.Text = (Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtNetAmount.Text)).ToString();
                        //_ItemDiscAmt = discountAmt;
                    }

                    //---------------new added for Credit Amount
                    CalcFinalAmount();
                }
            }
            catch (Exception exc)
            { 
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangePIDetailGridView()
        {
            try
            {
                dgvPIDetail.Columns["GodownID"].DataPropertyName = dtPIDetail.Columns["GodownID"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (!(dgvPIDetail.CurrentRow == null))
            {
                if ((dgvPIDetail.Rows.Count > 1))
                {
                    if ((MessageBox.Show(("You are going to Delete the Credit Note." + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
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
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
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
                    vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text +" Rs." +"</b>";
                    vDetails += "<BR> <BR>   <b> Service Charges </b>: " + txtCharges.Text +" Rs."+ "<BR> <BR>";


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
                    //vDetails += " <BR> <BR> <b>Net Amount : " + txtnamount.Text + "</b>";

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
            //try
            //{
            //    DataTable dtQTNC = new DataTable();
            //    NameValueCollection para = new NameValueCollection();
            //    para.Add("@i_Code", txtRequestNo.Text);

            //    //if (_Mode == (int)Common.Constant.Mode.Insert)
            //    //{
            //    //    LoadContactDetailList();
            //    //}
            //    if (dtContactDetail.Columns.Count > 0)
            //    {

            //    }
            //    else
            //    {
            //        LoadContactDetailList();
            //    }

            //    dtQTNC = objDA.ExecuteDataTableSP("usp_ServiceContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
            //    if (dtQTNC != null)
            //    {
            //        if (dtQTNC.Rows.Count > 0)
            //        {
            //            ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SECUpdate, 0, _CustomerID, txtRequestNo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SERVICE");
            //            fLOV.Text = "List Of Contact Details";
            //            fLOV.ShowDialog();
            //        }
            //        else
            //        {
            //            ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.SECInsert, 0, _CustomerID, txtRequestNo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "SERVICE");
            //            fLOV.Text = "List Of Contact Details";
            //            fLOV.ShowDialog();
            //        }                    
            //    }
            //    //else
            //    //{
                    
            //    //}
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (Convert.ToInt16(cmbgodown.SelectedValue) > 0)
            //{
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

            CreditNote.frmCreditNoteItemEntry fPIEntry = new CreditNote.frmCreditNoteItemEntry((int)Constant.Mode.Insert, _PIID, _CustomerID, dtpReqDate.Value, dtPIDetail, 0, 0, 0, Convert.ToInt16(cmbgodown.SelectedValue), 0);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            //fPIEntry.ItemDiscountAmt += Convert.ToDecimal(fPIEntry.ItemDiscountAmt.ToString());
            //TotalDisAmt = Convert.ToDecimal(txtDicAmt.Text);
            //TotalDisAmt += Convert.ToDecimal(fPIEntry.ItemDiscountAmt.ToString());
            // fPIEntry.ItemDiscountAmt += fPIEntry.ItemDiscountAmt;
            //txtDicAmt.Text = TotalDisAmt.ToString();
            ArrangePIDetailGridView();
            CalculateNetAmount();
            //}
            //else
            //{
            //    MessageBox.Show("Select Godown.");
            //    return;
            //}
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
            int GodownID_Edit = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["GodownID"].Value);
            int _ID = 0;
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                //_PIID = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["QuotationId"].Value);

                _PIID = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["itemid"].Value);
                _ID = 1;
            }

            CreditNote.frmCreditNoteItemEntry fPIEntry = new CreditNote.frmCreditNoteItemEntry((int)Constant.Mode.Modify, _PIID, _CustomerID, dtpReqDate.Value, dtPIDetail, 0, ItemID_Edit, _ID, Convert.ToInt16(cmbgodown.SelectedValue), GodownID_Edit);
            fPIEntry.ShowDialog();



            dgvPIDetail.AutoGenerateColumns = false;
            //txtDicAmt.Text = _ItemDiscAmt.ToString();
            //TotalDisAmt += Convert.ToDecimal(fPIEntry.ItemDiscountAmt.ToString());

            //txtDicAmt.Text = TotalDisAmt.ToString();
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (!(dgvPIDetail.CurrentRow == null))
            {
                if ((dgvPIDetail.Rows.Count > 1))
                {
                    if ((MessageBox.Show(("You are going to Delete the Credit Note." + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
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

        private void txtcnamount_Leave(object sender, EventArgs e)
        {

        }

        private void txtnamount_Leave(object sender, EventArgs e)
        {
            try
            {
                CalcFinalAmount();
            }
            catch (Exception exc)
            {
                
                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtfinalamount_Leave(object sender, EventArgs e)
        {
            try
            {
                CalcFinalAmount();
            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtcnamount_Leave_1(object sender, EventArgs e)
        {
            try
            {
                CalcFinalAmount();
            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtfinalamount_Enter(object sender, EventArgs e)
        {
            try
            {
                CalcFinalAmount();
            }
            catch (Exception exc)
            {

                Utill.Common.ExceptionLogger.writeException("Credit Note", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
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
                            _CustomerID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                            txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                            txtmobileNo.Text = dtCustomer.Rows[0]["Phone1"].ToString();
                            txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                            // txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                            txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                            //cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                            cmbAttendedBy.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();

                            _QuotationID = Convert.ToInt64(dtCustomer.Rows[0]["QuotationID"].ToString());

                            if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }

                            DataTable dtquotation = new DataTable();
                            if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                            {
                                _CustomerID = 0;
                                //dgvPIDetail.DataSource = null;
                            }
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
                            CalculateNetAmount();
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
                                _CustomerID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                                txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                                txtmobileNo.Text = dtCustomer.Rows[0]["Phone1"].ToString();
                                txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                                // txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                                txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                                //cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                                cmbAttendedBy.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                                cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();

                                _QuotationID = Convert.ToInt64(dtCustomer.Rows[0]["QuotationID"].ToString());

                                if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                                {
                                    IsCustomer = true;
                                }
                                else
                                {
                                    IsCustomer = false;
                                }

                                DataTable dtquotation = new DataTable();
                                if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                                {
                                    _CustomerID = 0;
                                    //dgvPIDetail.DataSource = null;
                                }
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
                                CalculateNetAmount();
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

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
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
                            _CustomerID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                            txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                            txtmobileNo.Text = dtCustomer.Rows[0]["Phone1"].ToString();
                            txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                            // txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                            txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                            //cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                            cmbAttendedBy.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();

                            _QuotationID = Convert.ToInt64(dtCustomer.Rows[0]["QuotationID"].ToString());

                            if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }

                            DataTable dtquotation = new DataTable();
                            if (dtCustomer.Rows[0]["CustomerName"].ToString() == null)
                            {
                                _CustomerID = 0;
                                //dgvPIDetail.DataSource = null;
                            }
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
                            CalculateNetAmount();
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
}
