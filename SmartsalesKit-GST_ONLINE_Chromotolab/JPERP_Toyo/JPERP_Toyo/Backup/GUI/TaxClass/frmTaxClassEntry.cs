using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Account.Common;
using Account.BusinessLogic;
using Account.Validator;

namespace Account.GUI.TaxClass
{
    public partial class frmTaxClassEntry : Account.GUIBase
    {

        #region "Variable Declarations"

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        TaxClassBL objTaxClassBL = new TaxClassBL();
        DataTable dtTaxClass = new DataTable();

        int _Mode;
        Int64 _TaxClassID = 0;

        #endregion

        #region "Form Events..."

        public frmTaxClassEntry(int Mode, long TaxClassID)
        {
            InitializeComponent();
            _Mode = Mode;
            _TaxClassID = TaxClassID;
        }

        private void frmTaxClassEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                dtpFromDate.Value = DateTime.Now;
                this.Text = "Tax Class - New";

            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "Tax Class - Edit";
            }
        }

        #endregion

        #region "Private Methods..."

        public void BindControl()
        {
            try
            {
                dtTaxClass = CommSelect.SelectRecord(_TaxClassID, "usp_TaxClass_Select", "Tax Class - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (dtTaxClass.Rows.Count > 0)
                    {
                        txtTaxClass.Text = dtTaxClass.Rows[0]["TaxClassName"].ToString();
                        dtpFromDate.Value = Convert.ToDateTime(dtTaxClass.Rows[0]["FromDate"]);
                        txtexcise.Text = dtTaxClass.Rows[0]["Excise"].ToString();
                        txtVAT.Text = dtTaxClass.Rows[0]["VAT"].ToString();
                        txtAVAT.Text = dtTaxClass.Rows[0]["AVAT"].ToString();
                        if (Convert.ToDecimal(txtVAT.Text) > 0)
                        {
                            txtCST.Enabled = false;
                        }
                        txtCST.Text = dtTaxClass.Rows[0]["CST"].ToString();
                        if (Convert.ToDecimal(txtCST.Text) > 0)
                        {
                            txtVAT.Enabled = false;
                            txtAVAT.Enabled = false;
                        }
                        txtServiceTax.Text = dtTaxClass.Rows[0]["ServiceTax"].ToString();
                        txtEduCess.Text = dtTaxClass.Rows[0]["EduCess"].ToString();
                        txtHEduCess.Text = dtTaxClass.Rows[0]["HEduCess"].ToString();
                        txtSBCess.Text = dtTaxClass.Rows[0]["SBCess"].ToString();
                        txtExtraTax.Text = dtTaxClass.Rows[0]["ExtraTax"].ToString();
                        txtExtraTaxType.Text = dtTaxClass.Rows[0]["ExtraTaxType"].ToString();
                        if (txtExtraTaxType.Text == "")
                        {
                            txtExtraTaxType.Text = "Extra tax:";
                        }
                    }
                }
                else
                {
                    MessageBox.Show(CommSelect.Exception.Message.ToString());
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public bool SetSave()
        {
            bool ReturnValue = false;
            try
            {
                if (DataValidator.IsValid(this.grpData))
                {
                    if (txtexcise.Text == "")
                    {
                        txtexcise.Text = "0.00";
                    }
                    if (txtAVAT.Text == "")
                    {
                        txtAVAT.Text = "0.00";
                    }
                    if (txtCST.Text == "")
                    {
                        txtCST.Text = "0.00";
                    }
                    if (txtEduCess.Text == "")
                    {
                        txtEduCess.Text = "0.00";
                    }
                    if (txtHEduCess.Text == "")
                    {
                        txtHEduCess.Text = "0.00";
                    }
                    if (txtServiceTax.Text == "")
                    {
                        txtServiceTax.Text = "0.00";
                    }

                    //if (txts.Text == "")
                    //{
                    //    txtServiceTax.Text = "0.00";
                    //}

                    //if (txtServiceTax.Text == "")
                    //{
                    //    txtServiceTax.Text = "0.00";
                    //}  

                    if (txtexcise.Text == "0.00" && txtVAT.Text == "0.00" && txtServiceTax.Text == "0.00" && txtEduCess.Text == "0.00" && txtHEduCess.Text == "0.00" && txtCST.Text == "0.00" && txtAVAT.Text == "0.00" && txtSBCess.Text == "0.00" && txtExtraTax.Text == "0.00")
                    {
                        lblErrorMessage.Text = "Please select at least one rate";
                        txtexcise.Focus();
                        return false;
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        objTaxClassBL.Insert(txtTaxClass.Text, dtpFromDate.Value, Convert.ToDecimal(txtexcise.Text), Convert.ToDecimal(txtVAT.Text), Convert.ToDecimal(txtServiceTax.Text), Convert.ToDecimal(txtEduCess.Text), Convert.ToDecimal(txtHEduCess.Text), Convert.ToDecimal(txtCST.Text), Convert.ToDecimal(txtAVAT.Text), Convert.ToDecimal(txtSBCess.Text), txtExtraTaxType.Text,Convert.ToDecimal(txtExtraTax.Text));
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objTaxClassBL.Update(_TaxClassID, txtTaxClass.Text, dtpFromDate.Value, Convert.ToDecimal(txtexcise.Text), Convert.ToDecimal(txtVAT.Text), Convert.ToDecimal(txtServiceTax.Text), Convert.ToDecimal(txtEduCess.Text), Convert.ToDecimal(txtHEduCess.Text), Convert.ToDecimal(txtCST.Text), Convert.ToDecimal(txtAVAT.Text), Convert.ToDecimal(txtSBCess.Text), txtExtraTaxType.Text, Convert.ToDecimal(txtExtraTax.Text));
                    }

                    if (objTaxClassBL.Exception == null)
                    {
                        if (objTaxClassBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objTaxClassBL.ErrorMessage;
                            txtTaxClass.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
                            ReturnValue = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(objTaxClassBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        #endregion

        #region "Button Event..."

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "No error";
            if (SetSave())
            {
                txtTaxClass.Text = "";
                dtpFromDate.Value = DateTime.Now;
                txtEduCess.Text = "0.00";
                txtHEduCess.Text = "0.00";
                txtServiceTax.Text = "0.00";
                txtVAT.Text = "0.00";
                txtexcise.Text = "0.00";
                txtCST.Text = "0.00";
                txtAVAT.Text = "0.00";
                txtExtraTax.Text = "0.00";
                txtSBCess.Text = "0.00";
                txtExtraTaxType.Text = "Extra Tax";
                txtTaxClass.Focus();
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Dispose();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Textbox Event..."

        private void txtTaxClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
//            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        private void txtServiceTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtServiceTax_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {

                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        txtTextbox.Text = Convert.ToDecimal(txtTextbox.Text).ToString("#0.00");
                    }

                    if (txtTextbox.TextLength <= txtTextbox.MaxLength)
                    {
                        lblErrorMessage.Text = "No error";
                        if (txtTextbox.Name == "txtHEduCess")
                        {
                            if (btnSaveExit.Enabled == false)
                            {
                                btnSaveContinue.Enabled = true;
                                btnSaveExit.Enabled = true;
                                if (_Mode == (int)Common.Constant.Mode.Insert)
                                {
                                    btnSaveContinue.Focus();
                                }
                                else
                                {
                                    btnSaveExit.Focus();
                                }
                            }
                        }
                        if (Convert.ToDecimal(txtCST.Text) > 0)
                        {
                            txtVAT.Enabled = false;
                            txtAVAT.Enabled = false;
                        }
                        else
                        {
                            if (Convert.ToDecimal(txtVAT.Text) > 0 || Convert.ToDecimal(txtAVAT.Text) > 0)
                            {
                                txtCST.Enabled = false;
                            }
                            else
                            {
                                if (txtCST.Enabled == false)
                                {
                                    txtCST.Enabled = true;
                                }
                            }
                            if (txtVAT.Enabled == false)
                            {
                                txtVAT.Enabled = true;
                                txtAVAT.Enabled = true;
                                txtVAT.Focus();
                            }
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99.99";
                        txtTextbox.Focus();
                        btnSaveContinue.Enabled = false;
                        btnSaveExit.Enabled = false;
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

        #endregion

      
    }
}
