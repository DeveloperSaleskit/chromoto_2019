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


namespace Account.GUI.CustomerMain
{
    public partial class frmCustomerMainEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CustomerMainBL objLeadBL = new CustomerMainBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        Exception mException = null;
        string mErrorMsg = "";
        int CompId = 0;

        CommonListBL objList = new CommonListBL();

        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtLead = new DataTable();
        int _Mode = 0;
        Int64 _LeadID = 0;
        CommonListBL CommList = new CommonListBL();
        int _CompId = 0;
        Int64 _AccountID = 0;
        Int64 _CustomerID = 0;
        string ID = "";
        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            dtLead = CommSelect.SelectRecord(_LeadID, "usp_CustomerMain_Select", "Lead - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtLead.Rows.Count > 0)
                    {
                        txtLeadNo.Text = dtLead.Rows[0]["CustomerCode"].ToString();                       
                        txtCustomerName.Text = dtLead.Rows[0]["CustomerName"].ToString();
                        txtAddress1.Text = dtLead.Rows[0]["Address"].ToString();
                        cmbCity.SelectedValue = Convert.ToInt32(dtLead.Rows[0]["CityID"].ToString());
                        txtPincode.Text = dtLead.Rows[0]["Pincode"].ToString();
                        txtPhone.Text = dtLead.Rows[0]["Phone1"].ToString();
                        txtMobile.Text = dtLead.Rows[0]["MobileNo"].ToString();
                        txtEmail.Text = dtLead.Rows[0]["Email"].ToString();
                        txtName1.Text = dtLead.Rows[0]["Name1"].ToString();
                        txtName2.Text = dtLead.Rows[0]["Name2"].ToString();
                        txtName3.Text = dtLead.Rows[0]["Name3"].ToString();
                        txtName4.Text = dtLead.Rows[0]["Name4"].ToString();
                        txtName5.Text = dtLead.Rows[0]["Name5"].ToString();
                        txtName6.Text = dtLead.Rows[0]["Name6"].ToString();
                        txtValue1.Text = dtLead.Rows[0]["Value1"].ToString();
                        txtValue2.Text = dtLead.Rows[0]["Value2"].ToString();
                        txtValue3.Text = dtLead.Rows[0]["Value3"].ToString();
                        txtValue4.Text = dtLead.Rows[0]["Value4"].ToString();
                        txtValue5.Text = dtLead.Rows[0]["Value5"].ToString();
                        txtValue6.Text = dtLead.Rows[0]["Value6"].ToString();                      
                        
                        txtSpecification.Text = dtLead.Rows[0]["Specification"].ToString();
                        txtRemark.Text = dtLead.Rows[0]["Remarks"].ToString();
                        txtContactPerson.Text = dtLead.Rows[0]["ContactPerson"].ToString();
                        cmbarea.SelectedValue = dtLead.Rows[0]["AreaID"].ToString();
                        txtwebsite.Text = dtLead.Rows[0]["Website"].ToString();
                        cmbCategory.Text = dtLead.Rows[0]["Category"].ToString();
                        txtCreditDays.Text = dtLead.Rows[0]["CreditDays"].ToString();

                        int IsAccount = Convert.ToInt16(dtLead.Rows[0]["IsAccount"].ToString());
                        //dtpDate.Value = Convert.ToDateTime(dtLead.Rows[0]["TransactionDate"].ToString());
                        //txtCrAmount.Text = dtLead.Rows[0]["CRAmount"].ToString();
                        //txtDbAmount.Text = dtLead.Rows[0]["DBAmount"].ToString();
                        _CustomerID = Convert.ToInt64(dtLead.Rows[0]["CustomerID"].ToString());
                        if (IsAccount == 1)
                        {
                            dtLead = CommSelect.SelectRecord(_CustomerID, "usp_CustomerMain_Select_Account", "Customer - BindControl");
                            dtpDate.Value = Convert.ToDateTime(dtLead.Rows[0]["TransactionDate"].ToString());
                            txtCrAmount.Text = dtLead.Rows[0]["CRAmount"].ToString();
                            txtDbAmount.Text = dtLead.Rows[0]["DBAmount"].ToString();
                        }
                        else
                        {

                        }
                        if (IsAccount == 1)
                        {
                            chkCreateAccount.Checked = true;
                        }
                        else
                        {
                            chkCreateAccount.Checked = false;
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
        public bool SetSave()
        {
            bool ReturnValue = false;
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_LeadID, "usp_Customer_Delete", "Customer Delete - SetSave");
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
                        int IsAccount = 0;
                        if (chkCreateAccount.Checked == true)
                        {
                            IsAccount = 1;

                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                objLeadBL.Insert(txtLeadNo.Text, txtCustomerName.Text, txtAddress1.Text,
                                    Convert.ToInt32(cmbCity.SelectedValue), txtPincode.Text, txtPhone.Text, txtMobile.Text, txtEmail.Text,
                                    txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text,
                                    txtSpecification.Text,
                                    txtRemark.Text, txtContactPerson.Text, Convert.ToInt32(cmbarea.SelectedValue), txtwebsite.Text,
                                    cmbCategory.Text, CompId, _AccountID,
                                    IsAccount, Convert.ToInt32(txtCreditDays.Text), dtpDate.Value, Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text));

                                if (chkInqAutoResponse_send.Checked == true)
                                {
                                    //SendToMail();
                                }

                            }//chkQuotation_Send.Checked
                            else if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                objLeadBL.Update(_LeadID, txtCustomerName.Text, txtAddress1.Text, Convert.ToInt32(cmbCity.SelectedValue),
                                    txtPincode.Text, txtPhone.Text, txtMobile.Text, txtEmail.Text,
                                    txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text,
                                     txtSpecification.Text, txtRemark.Text, txtContactPerson.Text,
                                     Convert.ToInt32(cmbarea.SelectedValue), txtwebsite.Text,
                                     cmbCategory.Text, CompId, _AccountID,
                                    IsAccount, Convert.ToInt32(txtCreditDays.Text), dtpDate.Value, Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text));
                            }

                            if (objLeadBL.Exception == null)
                            {
                                if (objLeadBL.ErrorMessage != "")
                                {
                                    lblErrorMessage.Text = objLeadBL.ErrorMessage;
                                    txtLeadNo.Focus();
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
                                MessageBox.Show(objLeadBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Please select the Create Account.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            MessageBox.Show("Please select the Create Account.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  
                            chkCreateAccount.Focus();
                        }                        
                    }
                }
            }

            return ReturnValue;
        }

        #endregion

        public frmCustomerMainEntry(int Mode, long LeadID)
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

                objCommon.FillSourceOfLeadCombo(cmbSourceOfLead);

                objCommon.FillCategoryCombo(cmbCategory);

                objCommon.FillCityCombo(cmbCity);

                if (cmbCity.SelectedIndex == 0)
                {
                    DataTable dtArea = new DataTable();
                    dtArea.Columns.Add("AreaID",typeof(Int32));
                    dtArea.Columns.Add("AreaName",typeof(string));

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
                objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    cmbStatus.SelectedIndex = 0;
                    txtLeadNo.Text = objCommon.AutoNumber("CUST");
                    ID = objCommon.AutoNumberID("CUST");
                    this.Text = "Customer - New";
                    dtpLeadDate.Value = DateTime.Now;
                    dtpNextDate.Value = DateTime.Now;

                    cmbStatus.DropDownStyle = ComboBoxStyle.DropDown;
                    cmbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cmbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

                    //cmbInterestLevel.Text = "INPROGRESS";
                    cmbStatus.SelectedIndex = 4;
                    cmbStatus.Enabled = false;
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnRegenrate.Visible = false;
                    btnSaveContinue.Visible = false;
                    this.Text = "Customer - Edit";
                    cmbStatus.Enabled = false;
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
                    this.Text = "Customer - Delete";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtLeadNo.Text = "";
                txtLeadNo.Text = objCommon.AutoNumber("CUST");
                ID = objCommon.AutoNumberID("CUST");
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
            txtLeadNo.Text = objCommon.AutoNumber("CUST");
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

            frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId, "usp_Customer_Lead_LOV", null);
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
            
            //_LeadID = fLOV.CustomerID;
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1,ID.ToString());
                    fContact.ShowDialog();
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, txtLeadNo.Text.Substring(5, 5));
                    fContact.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

       
       
      
      //  DataValidator.AllowO

    }
}
