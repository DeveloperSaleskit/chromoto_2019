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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;


namespace Account.GUI.Lead
{
    public partial class frmLeadEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        string dtdate;
        string custcode;
        Int16 AccCustID = 0;


        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        LeadBL objLeadBL = new LeadBL();

        ContactPersonBL objcontact = new ContactPersonBL();


        CustomerMainBL objLeadBL1 = new CustomerMainBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        Exception mException = null;
        string mErrorMsg = "";
        int CompId = 0;
     //   int _empId = 0;
        int editdetails = 0;
        CommonListBL objList = new CommonListBL();

        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtLead = new DataTable();
        int _Mode = 0;
        Int64 _LeadID = 0;
        CommonListBL CommList = new CommonListBL();
        int _CompId = 0;
        Int64 _AccountID = 0;
        DataTable dtblLOV = new DataTable();
        string StrFilter = "";
        string leaddocno = "";
        DataView DV;
        string ID = "";
        long _CustomerID = 0;

        DataTable dtDocList = new DataTable();
        string SelectedFileName = "";
        string CustomerCode = "";

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            DataSet dsLead = new DataSet();
            // dtLead = CommSelect.SelectRecord(_LeadID, "usp_Lead_Select", "Lead - BindControl");
            dsLead = CommSelect.SelectDataSetRecord(_LeadID, "usp_Lead_Select", "Lead - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dsLead.Tables[0].Rows.Count > 0)
                    {
                        txtLeadNo.Text = dsLead.Tables[0].Rows[0]["LeadNo"].ToString();
                        dtpLeadDate.Value = Convert.ToDateTime(dsLead.Tables[0].Rows[0]["LeadDate"].ToString());
                        txtCustomerName.Text = dsLead.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtAddress1.Text = dsLead.Tables[0].Rows[0]["Address"].ToString();
                        cmbCity.SelectedValue = Convert.ToInt32(dsLead.Tables[0].Rows[0]["CityID"].ToString());
                        txtPincode.Text = dsLead.Tables[0].Rows[0]["Pincode"].ToString();
                        txtPhone.Text = dsLead.Tables[0].Rows[0]["Phone1"].ToString();
                        txtMobile.Text = dsLead.Tables[0].Rows[0]["MobileNo"].ToString();
                        txtEmail.Text = dsLead.Tables[0].Rows[0]["Email"].ToString();
                        txtName1.Text = dsLead.Tables[0].Rows[0]["Name1"].ToString();
                        txtName2.Text = dsLead.Tables[0].Rows[0]["Name2"].ToString();
                        txtName3.Text = dsLead.Tables[0].Rows[0]["Name3"].ToString();
                        txtName4.Text = dsLead.Tables[0].Rows[0]["Name4"].ToString();
                        txtName5.Text = dsLead.Tables[0].Rows[0]["Name5"].ToString();
                        txtName6.Text = dsLead.Tables[0].Rows[0]["Name6"].ToString();
                        txtValue1.Text = dsLead.Tables[0].Rows[0]["Value1"].ToString();
                        txtValue2.Text = dsLead.Tables[0].Rows[0]["Value2"].ToString();
                        txtValue3.Text = dsLead.Tables[0].Rows[0]["Value3"].ToString();
                        txtValue4.Text = dsLead.Tables[0].Rows[0]["Value4"].ToString();
                        txtValue5.Text = dsLead.Tables[0].Rows[0]["Value5"].ToString();
                        txtValue6.Text = dsLead.Tables[0].Rows[0]["Value6"].ToString();
                        cmbSourceOfLead.Text = dsLead.Tables[0].Rows[0]["SourceOfLead"].ToString();
                        txtBudget.Text = dsLead.Tables[0].Rows[0]["CustomerBudget"].ToString();
                        cmbStatus.Text = dsLead.Tables[0].Rows[0]["InterestLevel"].ToString();
                        cmbInqResponse.Text = dsLead.Tables[0].Rows[0]["InqResponse"].ToString();
                        dtpNextDate.Value = Convert.ToDateTime(dsLead.Tables[0].Rows[0]["NextFollowUpDate"].ToString());
                        txtSpecification.Text = dsLead.Tables[0].Rows[0]["Specification"].ToString();
                        txtRemark.Text = dsLead.Tables[0].Rows[0]["Remarks"].ToString();
                        txtContactPerson.Text = dsLead.Tables[0].Rows[0]["ContactPerson"].ToString();
                        cmbarea.SelectedValue = dsLead.Tables[0].Rows[0]["AreaID"].ToString();
                        cmbemployee.SelectedValue = Convert.ToInt32(dsLead.Tables[0].Rows[0]["EmpID"].ToString());
                        txtwebsite.Text = dsLead.Tables[0].Rows[0]["Website"].ToString();

                        cmbEmpAllocatedTo.SelectedValue = Convert.ToInt32(dsLead.Tables[0].Rows[0]["AllocatedToEmpID"].ToString());
                        cmbCategory.Text = dsLead.Tables[0].Rows[0]["Category"].ToString();
                        CustomerCode = dsLead.Tables[0].Rows[0]["CustomerCode"].ToString();
                        if (Convert.ToBoolean(dsLead.Tables[0].Rows[0]["Inquiry_AutoResponse"].ToString()) == true)
                            chkInqAutoResponse_send.Checked = true;
                        else
                            chkInqAutoResponse_send.Checked = false;


                        /* code for Docs open*/

                        if (dsLead.Tables[1] != null && dsLead.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow DRow in dsLead.Tables[1].Rows)
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

        //public void SendToMail()
        //{
        //    try
        //    {

        //        string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

        //        DataTable dtEmail = new DataTable();
        //        NameValueCollection para = new NameValueCollection();
        //        para.Add("@i_Type", "Sales");
        //        dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");
        //        if (dtEmail.Rows.Count > 0)
        //        {

        //            vMailTo = ((txtEmail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtEmail.Text.ToLower());
        //            //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
        //            System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

        //            vSubject = dtEmail.Rows[0][0].ToString() + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

        //            vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
        //            vDetails += "<br /><br />";

        //            vDetails += " <BR> <BR> <b>Sale No : " + txtLeadNo.Text + "</b>"; // DETAIL PART OF BODY
        //            vDetails += "<BR> <BR>  <b> Date : " + dtpLeadDate.Value.Day + "/" + dtpLeadDate.Value.Month + "/" + dtpLeadDate.Value.Year + "</b><BR> <BR>";
        //            vDetails += "<html><head><title></title></head><body><table style=&quot;width: 100%;&quot; border=&quot;1&quot;>" +
        //                        "<tr align=&quot;center&quot; style=&quot;font-weight: bold&quot;><td>ITEM</td><td>QTY</td><td>UOM</td>" +
        //                        "<td>RATE</td><td>AMOUNT</td></tr>";

        //            for (int i = 0; i < dgvPIDetail.RowCount; i++)
        //            {
        //                vDetails += "<tr><td align=&quot;left&quot;> " + dgvPIDetail.Rows[i].Cells["ItemName"].Value.ToString() +
        //                            "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["Qty"].Value.ToString() +
        //                            "</td><td align=&quot;left&quot;>" + dgvPIDetail.Rows[i].Cells["UOM"].Value.ToString() +
        //                            "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["Rate"].Value.ToString() +
        //                            "</td><td align=&quot;right&quot;>" + dgvPIDetail.Rows[i].Cells["TotalAmount"].Value.ToString() +
        //                            "</td></tr>";
        //            }

        //            vDetails += "</table></body></html>";

        //            vDetails += " <BR> <BR> <b>Narration : </b>" + txtNarration.Text + "";
        //            vDetails += " <BR> <BR> <b>Net Amount : " + txtNetAmount.Text + "</b>";

        //            vDetails += "<br /><br />";
        //            vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY



        //            vDetails += "<br><br>";

        //            if (txtcc.Text.Trim() != "")
        //            {
        //                vMail.CC.Add(txtcc.Text);
        //            }
        //            if (txtbcc.Text.Trim() != "")
        //            {
        //                vMail.Bcc.Add(txtbcc.Text);
        //            }
        //            vMail.Subject = vSubject;
        //            vMail.Body = vDetails;
        //            vMail.IsBodyHtml = true;

        //            System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
        //            System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(CurrentCompany.Con_Email, CurrentCompany.Con_Password);

        //            //vSmpt.Host = "smtp.gmail.com";
        //            //vSmpt.Port = 25;
        //            //vSmpt.EnableSsl = false;
        //            //vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            vSmpt.Host = CurrentCompany.Host;
        //            vSmpt.Port = CurrentCompany.Port;
        //            vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            //vSmpt.UseDefaultCredentials = false;
        //            if (CurrentCompany.ssl == 0)
        //            {
        //                vSmpt.EnableSsl = true;
        //            }
        //            else if (CurrentCompany.ssl == 1)
        //            {
        //                vSmpt.EnableSsl = false;
        //            }
        //            vSmpt.Credentials = SmtpUser;
        //            vSmpt.Send(vMail);

        //        }
        //        else
        //        {
        //            MessageBox.Show("For Sending Email, First Set Email Details For Sales.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("There is some problem to send Email" + ex);
        //    }

        //}

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
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_LeadID, "usp_Lead_Delete", "Lead Delete - SetSave");
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
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {


                            objLeadBL.Insert(txtLeadNo.Text, dtpLeadDate.Value, txtCustomerName.Text, txtAddress1.Text,
                                Convert.ToInt32(cmbCity.SelectedValue), txtPincode.Text, txtPhone.Text, txtMobile.Text, txtEmail.Text,
                                txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text,
                                cmbSourceOfLead.Text, Convert.ToDecimal(txtBudget.Text), cmbStatus.Text, dtpNextDate.Value, txtSpecification.Text,
                                txtRemark.Text, 1, txtContactPerson.Text, Convert.ToInt32(cmbarea.SelectedValue), Convert.ToInt32(cmbemployee.SelectedValue), txtwebsite.Text,
                                cmbCategory.Text, Convert.ToInt32(cmbEmpAllocatedTo.SelectedValue), chkInqAutoResponse_send.Checked, CompId, _AccountID, cmbInqResponse.Text, _CustomerID);

                            if (editdetails == 1)
                            {


                                int IsAccount = 1;

                                dtdate = DateTime.Now.ToString();
                                custcode = objCommon.AutoNumber("CUST");

                                objLeadBL1.InsertINQUARIEEEDATA(custcode, txtCustomerName.Text, txtAddress1.Text,
                                Convert.ToInt32(cmbCity.SelectedValue), txtPincode.Text, txtPhone.Text, txtMobile.Text, txtEmail.Text,
                                txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text,
                                txtSpecification.Text,
                                txtRemark.Text, txtContactPerson.Text, Convert.ToInt32(cmbarea.SelectedValue), txtwebsite.Text,
                                cmbCategory.Text, CompId, AccCustID,
                                    //IsAccount, 0, dtpNextDate.Value, Convert.ToDecimal(txtBudget.Text), Convert.ToDecimal(txtBudget.Text));
                                IsAccount, 0, Convert.ToDateTime(dtdate), 0, 0);


                            }

                            if (chkInqAutoResponse_send.Checked == true)
                            {
                                //SendToMail();
                            }



                            //NameValueCollection padoc = new NameValueCollection();
                            //padoc.Add("@i_leaddocno", leaddocno.ToString());
                            //DataAccess.DataAccess objleaddoc = new DataAccess.DataAccess();
                            //objleaddoc.ExecuteSP("usp_Leaddocno", padoc, false, ref mException, ref mErrorMsg, "Sale - Insert");


                            if (objLeadBL.Exception == null)
                            {
                                if (objLeadBL.Exception == null)
                                {
                                    //--for doc save code
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        // DataTable dtdoc = new DataTable();
                                        // leaddocno = txtLeadNo.Text.ToString();
                                        // NameValueCollection padoc = new NameValueCollection();
                                        // padoc.Add("@i_leaddocno", leaddocno.ToString());
                                        // DataAccess.DataAccess objleaddoc = new DataAccess.DataAccess();
                                        //// objleaddoc.ExecuteSP("usp_Leaddocno", padoc, false, ref mException, ref mErrorMsg, "Sale - Insert");
                                        // dtdoc = objList.ListOfRecord("usp_Leaddocno", padoc, "Sale - Insert");

                                        // _LeadID = dtdoc.Tables[0].Rows[0]["LeadId"].ToString();



                                        NameValueCollection para = new NameValueCollection();
                                        para.Add("@i_leaddocno", txtLeadNo.Text.ToString());
                                        dtblLOV = objList.ListOfRecord("usp_LeadDocfinal", para, "iquariy");
                                        _LeadID = Convert.ToInt16(dtblLOV.Rows[0]["LeadId"].ToString());



                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            objLeadBL.InsertLeadDocument(_LeadID, dr["FileName"].ToString());
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objLeadBL.InsertLeadDocument(_LeadID, txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objLeadBL.Exception == null)
                                            {
                                                if (objLeadBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                    Upload(newFileName);
                                                }
                                            }
                                        }
                                    }
                                    //---------------


                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                                else
                                {
                                    lblErrorMessage.Text = objLeadBL.ErrorMessage;

                                    ReturnValue = false;
                                }
                                //if (objLeadBL.ErrorMessage != "" || _LeadID > 0)
                                //{
                                //    if (isRecordSave(objLeadBL.ErrorMessage))
                                //    {
                                //        if (_LeadID == 0)
                                //            _LeadID = Convert.ToInt64(objLeadBL.ErrorMessage);
                                //        //-----for doc save--------
                                //        foreach (DataRow dr in dtDocList.Rows)
                                //        {
                                //            if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                //            {
                                //                // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                //            }
                                //            else
                                //            {
                                //                string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                //                objLeadBL.InsertLeadDocument(_LeadID, txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                //                if (objLeadBL.Exception == null)
                                //                {
                                //                    if (objLeadBL.ErrorMessage == "")
                                //                    {
                                //                        File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                //                    }
                                //                }
                                //            }
                                //        }

                                //        //-------------------

                                //        //------get id for open rpt

                                //        //LQuotationID = objCommon.AutoNumberID("QU");

                                //        lblErrorMessage.Text = "No error";
                                //        ReturnValue = true;
                                //    }
                                //    else
                                //    {
                                //        lblErrorMessage.Text = objLeadBL.ErrorMessage;

                                //        ReturnValue = false;
                                //    }

                                //}
                                //else
                                //{
                                //    lblErrorMessage.Text = "No error";
                                //    ReturnValue = true;
                                //}
                            }
                            else
                            {
                                MessageBox.Show(objLeadBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }

                        }//chkQuotation_Send.Checked
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objLeadBL.Update(_LeadID, dtpLeadDate.Value, txtCustomerName.Text, txtAddress1.Text, Convert.ToInt32(cmbCity.SelectedValue),
                                txtPincode.Text, txtPhone.Text, txtMobile.Text, txtEmail.Text,
                                txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text,
                                cmbSourceOfLead.Text, Convert.ToDecimal(txtBudget.Text),
                                cmbStatus.Text, dtpNextDate.Value, txtSpecification.Text, txtRemark.Text, 1, txtContactPerson.Text,
                                 Convert.ToInt32(cmbarea.SelectedValue), Convert.ToInt32(cmbemployee.SelectedValue), txtwebsite.Text,
                                 cmbCategory.Text, Convert.ToInt32(cmbEmpAllocatedTo.SelectedValue), chkInqAutoResponse_send.Checked, CompId, _AccountID, cmbInqResponse.Text, _CustomerID);




                            if (objLeadBL.Exception == null)
                            {
                                if (objLeadBL.Exception == null)
                                {
                                    //--for doc save code
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            objLeadBL.InsertLeadDocument(_LeadID, dr["FileName"].ToString());
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objLeadBL.InsertLeadDocument(_LeadID, txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objLeadBL.Exception == null)
                                            {
                                                if (objLeadBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                    Upload(newFileName);
                                                }
                                            }
                                        }
                                    }
                                    //---------------


                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                                else
                                {
                                    lblErrorMessage.Text = objLeadBL.ErrorMessage;

                                    ReturnValue = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show(objLeadBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }

                        }

                        //if (objLeadBL.Exception == null)
                        //{
                        //    if (objLeadBL.ErrorMessage != "")
                        //    {
                        //        lblErrorMessage.Text = objLeadBL.ErrorMessage;
                        //        txtLeadNo.Focus();
                        //        ReturnValue = false;
                        //    }
                        //    else
                        //    {
                        //        lblErrorMessage.Text = "No error";
                        //        ReturnValue = true;
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(objLeadBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    ReturnValue = false;
                        //}
                    }
                }
            }

            return ReturnValue;
        }

        #endregion

        public frmLeadEntry(int Mode, long LeadID)
        {
            InitializeComponent();
            _Mode = Mode;
            _LeadID = LeadID;
        }

        private void frmInquiryEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                
             
                cmbSourceOfLead.DropDownStyle = ComboBoxStyle.DropDown;
                cmbSourceOfLead.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbSourceOfLead.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

                cmbInqResponse.DropDownStyle = ComboBoxStyle.DropDown;
                cmbInqResponse.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbInqResponse.AutoCompleteSource = AutoCompleteSource.ListItems;

                objCommon.FillSourceOfLeadCombo(cmbSourceOfLead);
                objCommon.FillInqResponse(cmbInqResponse);
                objCommon.FillCategoryCombo(cmbCategory);

                objCommon.FillCityCombo(cmbCity);


                dtDocList.Columns.Add("QDocID");
                dtDocList.Columns.Add("FileName");
                dtDocList.Columns.Add("FullFileName");

                if (cmbCity.SelectedIndex == 0)
                {
                    DataTable dtArea = new DataTable();
                    dtArea.Columns.Add("AreaID", typeof(Int32));
                    dtArea.Columns.Add("AreaName", typeof(string));

                    DataRow dr;
                    dr = dtArea.NewRow();
                    dr["AreaID"] = 0;
                    dr["AreaName"] = "--Select--";
                    dtArea.Rows.InsertAt(dr, 0);
                    cmbarea.DataSource = dtArea;
                    cmbarea.DisplayMember = "AreaName";
                    cmbarea.ValueMember = "AreaID";
                }


                objCommon.FillEmployeeCombo(cmbemployee);
                objCommon.FillEmployeeCombo(cmbEmpAllocatedTo);
               
               //cmbemployee.Text =sp;
                objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    cmbStatus.SelectedIndex = 0;
                    txtLeadNo.Text = objCommon.AutoNumber("INQ");
                    ID = objCommon.AutoNumberID("INQ");
                    this.Text = "Inquiry - New";
                    dtpLeadDate.Value = DateTime.Now;
                    dtpNextDate.Value = DateTime.Now;

                    cmbStatus.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //cmbInterestLevel.Text = "INPROGRESS";
                    cmbStatus.SelectedIndex = 4;
                    cmbStatus.Enabled = false;
                    LoadList();
                    cmbemployee.SelectedValue= CurrentUser.empId.ToString();
                    cmbEmpAllocatedTo.SelectedValue = CurrentUser.empId.ToString();
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnRegenrate.Visible = false;
                    btnSaveContinue.Visible = false;
                    this.Text = "Inquiry - Edit";
                    cmbStatus.Enabled = false;
                    button1.Visible = false;
                    btnLeadLOV.Visible = false;
                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    SetReadOnlyControls(grpData);
                    btnRegenrate.Visible = false;
                    btnSaveExit.Text = "Yes";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    btnCancel.Text = "No";
                    this.Text = "Inquiry - Delete";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-FormLoad", exc.StackTrace);
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

                dtblLOV = objList.ListOfRecord("usp_Customer_Lead_LOV", para, "Customer LOV - LoadList");

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


        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtLeadNo.Text = "";
                txtLeadNo.Text = objCommon.AutoNumber("INQ");
                ID = objCommon.AutoNumberID("INQ");
                dtpLeadDate.Value = DateTime.Now;
                txtCustomerName.Text = "";
                txtAddress1.Text = "";
                cmbCity.SelectedIndex = 0;
                txtPincode.Text = "";
                txtMobile.Text = "";
                txtCustomerName.Text = "";
                cmbSourceOfLead.Text = "";
                txtBudget.Text = "0";
                cmbStatus.Text = "";
                dtpNextDate.Value = DateTime.Now;
                txtSpecification.Text = "";
                txtRemark.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                cmbemployee.SelectedIndex = 0;
                cmbEmpAllocatedTo.SelectedIndex = 0;
                txtContactPerson.Text = "";
                txtwebsite.Text = "";
                cmbCategory.Text = "";
                dgvCountry.DataSource = null;
                txtName1.Text = "CST NO:";
                txtName2.Text = "VAT NO:";
                txtName3.Text = "PAN:";
                txtName4.Text = "SERVICE TAX:";
                txtName5.Text = "CO REG NO:";
                txtName6.Text = "OTHER NO:";
                txtValue1.Text = "";
                txtValue2.Text = "";
                txtValue3.Text = "";
                txtValue4.Text = "";
                txtValue5.Text = "";
                txtValue6.Text = "";

                txtLeadNo.Focus();
            }
        }

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
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtLeadNo.Text = objCommon.AutoNumber("INQ");
        }

        private void txtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtBudget_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            DataValidator.SetDecimalOnLeave(sender);
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

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCity.SelectedIndex > 0)
            {
                objCommon.FillAreaCombo(cmbarea, Convert.ToInt32(cmbCity.SelectedValue));
                DataSet dtArea = new DataSet();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_CityID", Convert.ToInt32(cmbCity.SelectedValue).ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtArea = CommList.ListOfDataSetRecordwithPara("usp_Area_List", para, "Common - FillAreaCombo");
                if (CommList.Exception != null)
                {
                }
                else
                {
                    if (dtArea.Tables[1] != null)
                    {
                        if (dtArea.Tables[1].Rows.Count > 0)
                        {
                            txtState.Text = dtArea.Tables[1].Rows[0]["StateName"].ToString();
                        }
                    }

                }
            }
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {

            //     if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //(e.KeyChar != '.'))
            //     {
            //         e.Handled = true;
            //     }

            //     // only allow one decimal point
            //     if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //     {
            //         e.Handled = true;
            //     }
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                if (txtMobile.Text.Length < 10)
                {
                    MessageBox.Show("Please enter the correct Mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobile.Focus();
                }
                if (txtMobile.Text.Length > 10)
                {
                    MessageBox.Show("Please enter the correct Mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMobile.Focus();
                }
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                string pattern = null;
                pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    //MessageBox.Show("Valid Email address ");
                }
                else
                {
                    MessageBox.Show("Not a valid Email address ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtContactPerson_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLeadLOV_Click(object sender, EventArgs e)
        {
            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

            frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId, "usp_Customer_Lead_LOV", para1);
            fLOV.Text = "List Of Customer";
            fLOV.ShowDialog();
            //txtLeadNo.Text = fLOV.CustomerCode;
            // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
            txtCustomerName.Text = fLOV.CustomerName;
            txtEmail.Text = fLOV.Email;
            txtPhone.Text = fLOV.Phone1;
            txtContactPerson.Text = fLOV.ContactPerson;
            txtAddress1.Text = fLOV.Address;
            _AccountID = fLOV.AccountID;
            _CustomerID = fLOV.CustomerID;
            cmbCity.SelectedValue = fLOV.CityID.ToString();
            txtMobile.Text = fLOV.MobileNo;
            txtPincode.Text = fLOV.PinCode;
            txtwebsite.Text = fLOV.WebSite;

            txtName1.Text = fLOV.Name1;
            txtName2.Text = fLOV.Name2;
            txtName3.Text = fLOV.Name3;
            txtName4.Text = fLOV.Name4;
            txtName5.Text = fLOV.Name5;
            txtName6.Text = fLOV.Name6;
            txtState.Text = fLOV.State;
            txtValue1.Text = fLOV.Value1;
            txtValue2.Text = fLOV.Value2;
            txtValue3.Text = fLOV.Value3;
            txtValue4.Text = fLOV.Value4;
            txtValue5.Text = fLOV.Value5;
            txtValue6.Text = fLOV.Value6;
            CustomerCode = fLOV.CustomerCode;
            cmbarea.SelectedValue = fLOV.AreaID.ToString();





            cmbCategory.Text = fLOV.categoryname.ToString();

            // cmbCity.SelectedIndex = fLOV.CityID.ToString();
            //fLOV.CityID.ToString();
            if (_CustomerID != 0)
            {
                // DataTable dtCustomerData = CommSelect.SelectRecord(_CustomerID, "usp_Customer_Lead_LOV_Details", "Godown - BindControl");

                NameValueCollection para2 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para2.Add("@i_CustomerId", _CustomerID.ToString());

                //DataTable dtCustomerData = CommSelect.SelectRecord(_CustomerID, "usp_Customer_Lead_LOV_Details", "Godown - BindControl");
                DataTable dtCustomerData = objDA.ExecuteDataTableSP("usp_Customer_Lead_LOV_Details", para2, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");


            }

            //_LeadID = fLOV.CustomerID;
        }

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //StrFilter = "";
                //if (dtblLOV != null)
                //{
                //    if (dtblLOV.Rows.Count > 0)
                //    {
                //        if (txtCustomerName.Text.Trim() != "")
                //        {
                //            StrFilter = StrFilter + " CustomerName = '" + PrepareFilterString(txtCustomerName.Text.Trim()) + "' OR ";
                //        }

                //        if (StrFilter != "")
                //        {
                //            StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                //        }

                //        DV = dtblLOV.DefaultView;
                //        DV.RowFilter = StrFilter;
                //        DataTable dtCustomer = new DataTable();
                //        dtCustomer = DV.ToTable();
                //        if (DV.ToTable() != null)
                //        {
                //            if (DV.ToTable().Rows.Count > 0)
                //            {
                //                //---------------
                //                //txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                //                //dtpLeadDate.Value = Convert.ToDateTime(dtLead.Rows[0]["LeadDate"].ToString());
                //                txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                //                txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                //                cmbCity.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["CityID"].ToString());
                //                txtPincode.Text = dtCustomer.Rows[0]["Pincode"].ToString();
                //                txtPhone.Text = dtCustomer.Rows[0]["Phone1"].ToString();
                //                txtMobile.Text = dtCustomer.Rows[0]["MobileNo"].ToString();
                //                txtEmail.Text = dtCustomer.Rows[0]["Email"].ToString();
                //                txtName1.Text = dtCustomer.Rows[0]["Name1"].ToString();
                //                txtName2.Text = dtCustomer.Rows[0]["Name2"].ToString();
                //                txtName3.Text = dtCustomer.Rows[0]["Name3"].ToString();
                //                txtName4.Text = dtCustomer.Rows[0]["Name4"].ToString();
                //                txtName5.Text = dtCustomer.Rows[0]["Name5"].ToString();
                //                txtName6.Text = dtCustomer.Rows[0]["Name6"].ToString();
                //                txtValue1.Text = dtCustomer.Rows[0]["Value1"].ToString();
                //                txtValue2.Text = dtCustomer.Rows[0]["Value2"].ToString();
                //                txtValue3.Text = dtCustomer.Rows[0]["Value3"].ToString();
                //                txtValue4.Text = dtCustomer.Rows[0]["Value4"].ToString();
                //                txtValue5.Text = dtCustomer.Rows[0]["Value5"].ToString();
                //                txtValue6.Text = dtCustomer.Rows[0]["Value6"].ToString();
                //                txtSpecification.Text = dtCustomer.Rows[0]["Specification"].ToString();
                //                txtRemark.Text = dtCustomer.Rows[0]["Remarks"].ToString();
                //                txtContactPerson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                //                cmbarea.SelectedValue = dtCustomer.Rows[0]["AreaID"].ToString();
                //                txtwebsite.Text = dtCustomer.Rows[0]["Website"].ToString();
                //                cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                //                _AccountID = Convert.ToInt64(dtCustomer.Rows[0]["AccountID"].ToString());
                //            }
                //            else
                //            {
                //                //MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //                //txtCustomerName.Focus();
                //            }
                //        }

                //        //dgvLOV.DataSource = DV.ToTable();
                //    }
                //}
            }
        }

        private void txtCustomerName_Leave(object sender, EventArgs e)
        {
            StrFilter = "";
            if (dtblLOV != null)
            {
               // if (dtblLOV.Rows.Count > 0)
                //{
                //    if (txtCustomerName.Text.Trim() != "")
                //    {
                //        StrFilter = StrFilter + " CustomerName = '" + PrepareFilterString(txtCustomerName.Text.Trim()) + "' OR ";
                //    }

                //    if (StrFilter != "")
                //    {
                //        StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                //    }

                //    DV = dtblLOV.DefaultView;
                //    DV.RowFilter = StrFilter;
                //    DataTable dtCustomer = new DataTable();
                //    dtCustomer = DV.ToTable();
                //    if (DV.ToTable() != null)
                //    {
                //        if (DV.ToTable().Rows.Count > 0)
                //        {
                //            //---------------
                //            //txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                //            //dtpLeadDate.Value = Convert.ToDateTime(dtLead.Rows[0]["LeadDate"].ToString());
                //            txtCustomerName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                //            txtAddress1.Text = dtCustomer.Rows[0]["Address"].ToString();
                //            cmbCity.SelectedValue = Convert.ToInt32(dtCustomer.Rows[0]["CityID"].ToString());
                //            txtPincode.Text = dtCustomer.Rows[0]["Pincode"].ToString();
                //            txtPhone.Text = dtCustomer.Rows[0]["Phone1"].ToString();
                //            txtMobile.Text = dtCustomer.Rows[0]["MobileNo"].ToString();
                //            txtEmail.Text = dtCustomer.Rows[0]["Email"].ToString();
                //            txtName1.Text = dtCustomer.Rows[0]["Name1"].ToString();
                //            txtName2.Text = dtCustomer.Rows[0]["Name2"].ToString();
                //            txtName3.Text = dtCustomer.Rows[0]["Name3"].ToString();
                //            txtName4.Text = dtCustomer.Rows[0]["Name4"].ToString();
                //            txtName5.Text = dtCustomer.Rows[0]["Name5"].ToString();
                //            txtName6.Text = dtCustomer.Rows[0]["Name6"].ToString();
                //            txtValue1.Text = dtCustomer.Rows[0]["Value1"].ToString();
                //            txtValue2.Text = dtCustomer.Rows[0]["Value2"].ToString();
                //            txtValue3.Text = dtCustomer.Rows[0]["Value3"].ToString();
                //            txtValue4.Text = dtCustomer.Rows[0]["Value4"].ToString();
                //            txtValue5.Text = dtCustomer.Rows[0]["Value5"].ToString();
                //            txtValue6.Text = dtCustomer.Rows[0]["Value6"].ToString();
                //            txtSpecification.Text = dtCustomer.Rows[0]["Specification"].ToString();
                //            txtRemark.Text = dtCustomer.Rows[0]["Remarks"].ToString();
                //            txtContactPerson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                //            cmbarea.SelectedValue = dtCustomer.Rows[0]["AreaID"].ToString();
                //            txtwebsite.Text = dtCustomer.Rows[0]["Website"].ToString();
                //            cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                //            _AccountID = Convert.ToInt64(dtCustomer.Rows[0]["AccountID"].ToString());
                //        }
                //        else
                //        {
                //            //MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            //txtCustomerName.Focus();

                //            txtAddress1.Text = "";
                //            cmbCity.SelectedValue = 0;
                //            txtPincode.Text = "";
                //            txtPhone.Text = "";
                //            txtMobile.Text = "";
                //            txtEmail.Text = "";
                //            txtName1.Text = "CST NO:";
                //            txtName2.Text = "VAT NO:";
                //            txtName3.Text = "PAN:";
                //            txtName4.Text = "SERVICE TAX:";
                //            txtName5.Text = "CO REG NO:";
                //            txtName6.Text = "OTHER NO:";
                //            txtValue1.Text = "";
                //            txtValue2.Text = "";
                //            txtValue3.Text = "";
                //            txtValue4.Text = "";
                //            txtValue5.Text = "";
                //            txtValue6.Text = "";
                //            txtSpecification.Text = "";
                //            txtRemark.Text = "";
                //            txtContactPerson.Text = "";
                //            cmbarea.SelectedValue = 0;
                //            txtwebsite.Text = "";
                //            cmbCategory.Text = "";
                //            _AccountID = 0;

                //        }
                //    }

                    //dgvLOV.DataSource = DV.ToTable();
                //}
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                   // GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, ID.ToString());
                    if (CustomerCode != "")
                    {
                        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, CustomerCode.Substring(5, 5));
                        fContact.ShowDialog();
                        txtContactPerson.Text = fContact.ContactName1;
                        txtMobile.Text = fContact.MobileNo;
                        txtEmail.Text = fContact.EmailID;
                    }
                    else
                    {
                        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(4,ID.ToString());
                        fContact.ShowDialog();
                        txtContactPerson.Text = fContact.ContactName1;
                        txtMobile.Text = fContact.MobileNo;
                        txtEmail.Text = fContact.EmailID;
                    }
                }

                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    if (CustomerCode != "")
                    {
                        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, CustomerCode.Substring(5, 5));
                        fContact.ShowDialog();
                        txtContactPerson.Text = fContact.ContactName1;
                        txtMobile.Text = fContact.MobileNo;
                        txtEmail.Text = fContact.EmailID;
                    }
                    else
                    {
                        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(4, txtLeadNo.Text.Substring(4, 5));
                        fContact.ShowDialog();
                        txtContactPerson.Text = fContact.ContactName1;
                        txtMobile.Text = fContact.MobileNo;
                        txtEmail.Text = fContact.EmailID;
                    }
                }
            }

            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
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

                    /*online*/

                    if (File.Exists(Path.GetTempPath() + dgvCountry.CurrentRow.Cells["FullFileName"].Value.ToString()))
                    {
                        Process.Start(Path.GetTempPath() + dgvCountry.CurrentRow.Cells["FullFileName"].Value.ToString());
                    }
                    else
                    {
                        Download(Path.GetTempPath(), dgvCountry.CurrentRow.Cells["FullFileName"].Value.ToString());
                        Process.Start(Path.GetTempPath() + dgvCountry.CurrentRow.Cells["FullFileName"].Value.ToString());
                    }

                    /*offline*/
                    //string strFile;
                    //strFile = CurrentUser.DocumentPath + dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();

                    //Process.Start(strFile);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                editdetails = 1;
                txtAddress1.ReadOnly = false;
                txtContactPerson.ReadOnly = false;
                txtEmail.ReadOnly = false;
                txtMobile.ReadOnly = false;
                txtAddress1.Text = "";
                txtMobile.Text = "";
                txtEmail.Text = "";
                txtContactPerson.Text = "";
                cmbarea.Enabled = true;
                cmbCity.Enabled = true;
                txtContactPerson.Focus();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cmbemployee_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      
      


        //  DataValidator.AllowO

    }
}
