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

namespace Account.GUI.Vendor
{
    public partial class frmVendorEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        VendorBL objVendorBL = new VendorBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtVendor = new DataTable();
        int _Mode = 0;
        Int64 _VendorID = 0;
        string ID = "";

        #endregion

        #region "Form Events...."

        public frmVendorEntry(int Mode, Int64 VendorID)
        {
            InitializeComponent();
            _Mode = Mode;
            _VendorID = VendorID;
        }

        private void frmVendorEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            cmbcategory.DropDownStyle = ComboBoxStyle.DropDown;
            cmbcategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbcategory.AutoCompleteSource = AutoCompleteSource.ListItems;


            objCommon.FillVendorCategCombo(cmbcategory);

            objCommon.FillCityCombo(cmbCity);
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                txtVendorCode.Text = objCommon.AutoNumber("VEN");
                ID = objCommon.AutoNumberID("VEN");
                this.Text = "Vendor - New";

            }
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnRegenrate.Visible = false;
                btnSaveContinue.Visible = false;
                this.Text = "Vendor - Edit";
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
                lblDelMsg.Visible = true;
                SetReadOnlyControls(grpVendor);
                SetReadOnlyControls(grpData);
                btnSaveExit.Text = "Yes";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                btnCancel.Text = "No";
                this.Text = "Vendor - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtVendor = CommSelect.SelectRecord(_VendorID, "usp_Vendor_Select", "Vendor - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtVendor.Rows.Count > 0)
                        {

                            cmbcategory.Text = dtVendor.Rows[0]["category"].ToString();
                            txtreamrks.Text = dtVendor.Rows[0]["remarks"].ToString();
                            txtVendorCode.Text = dtVendor.Rows[0]["Code"].ToString();
                            txtCompany.Text = dtVendor.Rows[0]["Company"].ToString();
                            txtAddress1.Text = dtVendor.Rows[0]["Address1"].ToString();
                            txtAddress2.Text = dtVendor.Rows[0]["Address2"].ToString();
                            cmbCity.SelectedValue = dtVendor.Rows[0]["CityID"];
                            txtPincode.Text = dtVendor.Rows[0]["Pincode"].ToString();
                            txtState.Text = dtVendor.Rows[0]["State"].ToString();
                            txtCountry.Text = dtVendor.Rows[0]["Country"].ToString();
                            txtPhone1.Text = dtVendor.Rows[0]["Phone1"].ToString();
                            txtPhone2.Text = dtVendor.Rows[0]["Phone2"].ToString();
                            txtFax.Text = dtVendor.Rows[0]["Fax"].ToString();
                            txtMobile.Text = dtVendor.Rows[0]["Mobile"].ToString();
                            txtTinNo.Text = dtVendor.Rows[0]["TinNo"].ToString();
                            txtCSTNo.Text = dtVendor.Rows[0]["CSTNo"].ToString();
                            txtPANo.Text = dtVendor.Rows[0]["PANo"].ToString();
                            txtEccNo.Text = dtVendor.Rows[0]["EccNo"].ToString();
                            txtRange.Text = dtVendor.Rows[0]["Range"].ToString();
                            txtDivision.Text = dtVendor.Rows[0]["Division"].ToString();
                            txtCreditDays.Text = dtVendor.Rows[0]["CreditDays"].ToString();
                            dtpDate.Value = Convert.ToDateTime(dtVendor.Rows[0]["TransactionDate"].ToString());
                            txtCrAmount.Text = dtVendor.Rows[0]["CRAmount"].ToString();
                            txtDbAmount.Text = dtVendor.Rows[0]["DBAmount"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public bool SetSave()
        {

            bool ReturnValue = false;
            try
            {
                if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    CommDelRec.DeleteRecord(_VendorID, "usp_Vendor_Delete", "Vendor - Delete");
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
                    if (DataValidator.IsValid(this.grpVendor))
                    {
                        if (DataValidator.IsValid(this.grpData))
                        {
                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                objVendorBL.Insert(txtreamrks.Text,cmbcategory.Text,txtVendorCode.Text, txtCompany.Text, txtAddress1.Text, txtAddress2.Text, (long)cmbCity.SelectedValue, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text, txtMobile.Text, txtTinNo.Text, txtCSTNo.Text, txtPANo.Text, txtEccNo.Text, Convert.ToInt64(txtCreditDays.Text), txtRange.Text, txtDivision.Text, Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text));
                            }
                            else if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                objVendorBL.Update(txtreamrks.Text, cmbcategory.Text, _VendorID, txtVendorCode.Text, txtCompany.Text, txtAddress1.Text, txtAddress2.Text, (long)cmbCity.SelectedValue, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtFax.Text, txtMobile.Text, txtTinNo.Text, txtCSTNo.Text, txtPANo.Text, txtEccNo.Text, Convert.ToInt64(txtCreditDays.Text), txtRange.Text, txtDivision.Text, Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text));
                            }

                            if (objVendorBL.Exception == null)
                            {
                                if (objVendorBL.ErrorMessage != "")
                                {
                                    lblErrorMessage.Text = objVendorBL.ErrorMessage;
                                    txtCompany.Focus();
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
                                MessageBox.Show(objVendorBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }
                        }
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }
        #endregion

        #region "Button Event..."

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtVendorCode.Text = objCommon.AutoNumber("VEN");
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Dispose();
            }
        }
        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtVendorCode.Text = objCommon.AutoNumber("VEN");
                txtCompany.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                cmbCity.SelectedIndex = 0;
                txtPincode.Text = "";
                txtState.Text = "";
                txtCountry.Text = "";
                txtPhone1.Text = "";
                txtPhone2.Text = "";
                txtFax.Text = "";
                txtMobile.Text = "";
                txtTinNo.Text = "";
                txtCSTNo.Text = "";
                txtPANo.Text = "";
                txtEccNo.Text = "";
                txtRange.Text = "";
                txtDivision.Text = "";
                txtCreditDays.Text = "0";
                txtCompany.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Textbox Event"

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "");
        }

        private void txtCreditDays_Leave(object sender, EventArgs e)
        {
            if (txtCreditDays.Text == "")
            {
                txtCreditDays.Text = "0";
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
                Utill.Common.ExceptionLogger.writeException("VendorEntry-Keypress", exc.StackTrace);
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
                Utill.Common.ExceptionLogger.writeException("VendorEntry-Leave", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Combobox Event...."

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedIndex > 0)
                {
                    DataTable dtStateCountry = new DataTable();
                    dtStateCountry = CommSelect.SelectRecord((long)cmbCity.SelectedValue, "usp_City_GetStateCountry", "Vendor - cmbCity_SelectedIndexChanged");
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
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(0, ID.ToString());
                    fContact.ShowDialog();
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    GUI.ContactPerson.frmContactPerson fContact = new Account.GUI.ContactPerson.frmContactPerson(0, txtVendorCode.Text.Substring(4, 5));
                    fContact.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
