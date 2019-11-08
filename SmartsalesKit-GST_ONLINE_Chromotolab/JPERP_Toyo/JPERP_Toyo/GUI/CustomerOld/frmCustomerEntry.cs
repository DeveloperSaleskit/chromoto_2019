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

namespace Account.GUI.Customer
{
    public partial class frmCustomerEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CustomerBL objCustomerBL = new CustomerBL();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtCustomer = new DataTable();

        int _Mode = 0;
        Int64 _CustomerID = 0;
        Int64 _TransportID = 0;
        string ID = "";

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            dtCustomer = CommSelect.SelectRecord(_CustomerID, "usp_Customer_Select", "Customer - BindControl");

            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_RecID", _CustomerID.ToString());           

           // dtCustomer = objList.ListOfRecord("usp_Customer_Select", para, "Customer - BindControl");
            
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtCustomer.Rows.Count > 0)
                    {
                        txtCustomerCode.Text = dtCustomer.Rows[0]["Code"].ToString();
                        txtCompanyName.Text = dtCustomer.Rows[0]["Company"].ToString();
                        txtAddress1.Text = dtCustomer.Rows[0]["Address1"].ToString();
                        txtAddress2.Text = dtCustomer.Rows[0]["Address2"].ToString();
                        cmbCity.SelectedValue = dtCustomer.Rows[0]["CityID"];
                        txtPincode.Text = dtCustomer.Rows[0]["Pincode"].ToString();
                        txtState.Text = dtCustomer.Rows[0]["State"].ToString();
                        txtCountry.Text = dtCustomer.Rows[0]["Country"].ToString();
                        txtTINNo.Text = dtCustomer.Rows[0]["TinNo"].ToString();
                        txtPhone1.Text = dtCustomer.Rows[0]["Phone1"].ToString();
                        txtPhone2.Text = dtCustomer.Rows[0]["Phone2"].ToString();
                        txtFax.Text = dtCustomer.Rows[0]["Fax"].ToString();
                        txtMobile.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                        txtCSTNo.Text = dtCustomer.Rows[0]["CSTNo"].ToString();
                        txtPANo.Text = dtCustomer.Rows[0]["PANo"].ToString();
                        txtEccNo.Text = dtCustomer.Rows[0]["EccNo"].ToString();
                        txtRange.Text = dtCustomer.Rows[0]["Range"].ToString();
                        txtDivision.Text = dtCustomer.Rows[0]["Division"].ToString();
                        txtCreditDays.Text = dtCustomer.Rows[0]["CreditDays"].ToString();

                        cmblead.SelectedValue = dtCustomer.Rows[0]["LeadId"].ToString();
                        //txtDbAmount.Text = dtCustomer.Rows[0]["DBAmount"].ToString();
                        txtContactPerson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                        int IsAccount = Convert.ToInt16(dtCustomer.Rows[0]["IsAccount"].ToString());

                        if (IsAccount == 1)
                        {
                            dtCustomer = CommSelect.SelectRecord(_CustomerID, "usp_Customer_Select_Account", "Customer - BindControl");
                            dtpDate.Value = Convert.ToDateTime(dtCustomer.Rows[0]["TransactionDate"].ToString());
                            txtCrAmount.Text = dtCustomer.Rows[0]["CRAmount"].ToString();
                            txtDbAmount.Text = dtCustomer.Rows[0]["DBAmount"].ToString();
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

        public bool SetSave()
        {
            bool ReturnValue = false;
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_CustomerID, "usp_Customer_Delete", "Customer - SetSave");
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
                    if (DataValidator.IsValid(this.grpContactInformation))
                    {
                        int IsAccount = 0;
                        if (chkCreateAccount.Checked == true)
                        {
                            IsAccount = 1;
                        }
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            objCustomerBL.Insert(txtCustomerCode.Text, txtCompanyName.Text, txtAddress1.Text, txtAddress2.Text, 
                                (long)cmbCity.SelectedValue, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text, txtMobile.Text, 
                                txtTINNo.Text, txtCSTNo.Text, txtPANo.Text, txtEccNo.Text, txtRange.Text, txtDivision.Text, 
                                Convert.ToInt32(txtCreditDays.Text), Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), 
                                Convert.ToDecimal(txtDbAmount.Text), IsAccount, Convert.ToInt32(cmblead.SelectedValue),txtContactPerson.Text );
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objCustomerBL.Update(_CustomerID, txtCustomerCode.Text, txtCompanyName.Text, txtAddress1.Text, txtAddress2.Text, 
                                (long)cmbCity.SelectedValue, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text, txtMobile.Text, txtTINNo.Text, 
                                txtCSTNo.Text, txtPANo.Text, txtEccNo.Text, txtRange.Text, txtDivision.Text, Convert.ToInt32(txtCreditDays.Text), 
                                Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text), IsAccount,
                                Convert.ToInt32(cmblead.SelectedValue), txtContactPerson.Text);
                        }

                        if (objCustomerBL.Exception == null)
                        {
                            if (objCustomerBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objCustomerBL.ErrorMessage;
                                txtCompanyName.Focus();
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
                            MessageBox.Show(objCustomerBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }
            }

            return ReturnValue;
        }

        #endregion

        #region "Form Load events"

        public frmCustomerEntry(int Mode, long CustomerID)
        {
            InitializeComponent();
            _Mode = Mode;
            _CustomerID = CustomerID;
        }

        private void frmCustomerEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                objCommon.FillLead(cmblead);
                objCommon.FillCityCombo(cmbCity);
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    txtCustomerCode.Text = objCommon.AutoNumber("CUST");
                    ID =objCommon.AutoNumberID("CUST");
                    this.Text = "Customer - New";

                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnRegenrate.Visible = false;
                    btnSaveContinue.Visible = false;
                    this.Text = "Customer - Edit";
                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    SetReadOnlyControls(grpContactInformation);
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
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button events"

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtCustomerCode.Text = objCommon.AutoNumber("CUST");
        }

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtCustomerCode.Text = objCommon.AutoNumber("CUST");
                txtCompanyName.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                cmbCity.SelectedIndex = 0;
                txtState.Text = "";
                txtCountry.Text = "";
                txtPhone1.Text = "";
                txtPhone2.Text = "";
                txtPincode.Text = "";
                txtFax.Text = "";
                txtMobile.Text = "";
                txtTINNo.Text = "";
                txtCSTNo.Text = "";
                txtPANo.Text = "";
                txtEccNo.Text = "";
                txtRange.Text = "";
                txtDivision.Text = "";
                txtCreditDays.Text = "0";
                chkCreateAccount.Checked = false;
                txtCompanyName.Focus();

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

        #endregion

        #region "Combobox event"

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedIndex > 0)
                {
                    DataTable dtStateCountry = new DataTable();
                    dtStateCountry = CommSelect.SelectRecord((long)cmbCity.SelectedValue, "usp_City_GetStateCountry", "Transport - cmbCity_SelectedIndexChanged");
                    if (CommSelect.Exception == null)
                    {
                        if (CommSelect.ErrorMessage == "")
                        {
                            if (dtStateCountry.Rows.Count > 0)
                            {
                                txtState.Text = dtStateCountry.Rows[0]["State"].ToString();
                                txtCountry.Text = dtStateCountry.Rows[0]["Country"].ToString();
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
                else
                {
                    txtState.Text = "";
                    txtCountry.Text = "";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-ComboboxEvent", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox event"

        private void txtCreditDays_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditDays.Text == "")
                {
                    txtCreditDays.Text = "0";
                }
                DataValidator.SetIntegerOnLeave(sender);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-Leave", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                int ascii = e.KeyChar;
                DataValidator.AllowOnlyCharacter(ascii, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-Keypress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataValidator.AllowOnlyNumeric(e, "");
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-Keypress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataValidator.AllowOnlyNumeric(e, ".");
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-Keypress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditDays.Text == "")
                {
                    txtCreditDays.Text = "0.00";
                }
                DataValidator.SetIntegerOnLeave(sender);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CustomerEntry-Leave", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void cmblead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                try
                {
                    if (cmblead.SelectedIndex > 0)
                    {
                        DataTable dtlead = new DataTable();
                        dtlead = CommSelect.SelectRecord((long)cmblead.SelectedValue, "usp_Lead_Select", "Lead - cmblead_SelectedIndexChanged");
                        if (CommSelect.Exception == null)
                        {
                            if (CommSelect.ErrorMessage == "")
                            {
                                if (dtlead.Rows.Count > 0)
                                {
                                    txtCompanyName.Text = dtlead.Rows[0]["CustomerName"].ToString();
                                    txtAddress1.Text = dtlead.Rows[0]["Address"].ToString();
                                    txtPincode.Text = dtlead.Rows[0]["Pincode"].ToString();
                                    txtPhone1.Text = dtlead.Rows[0]["Phone1"].ToString();
                                    txtMobile.Text = dtlead.Rows[0]["MobileNo"].ToString();
                                    txtFax.Text = dtlead.Rows[0]["Email"].ToString();
                                    cmbCity.SelectedValue = dtlead.Rows[0]["CityID"].ToString();
                                    txtContactPerson.Text = dtlead.Rows[0]["ContactPerson"].ToString();

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
                    else
                    {
                        txtCompanyName.Text = "";
                        txtAddress1.Text = "";
                        txtPincode.Text = "";
                        txtPhone1.Text = "";
                        txtMobile.Text = "";
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("CustomerEntry-ComboboxEvent", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (_Mode == (int)Common.Constant.Mode.Insert)
            //    {
            //        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, Convert.ToInt64(ID.ToString()));
            //        fContact.ShowDialog();
            //    }
            //    if (_Mode == (int)Common.Constant.Mode.Modify)
            //    {
            //        GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(1, _CustomerID);
            //        fContact.ShowDialog();
            //    }
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
            //    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //}
        }

    }
}
