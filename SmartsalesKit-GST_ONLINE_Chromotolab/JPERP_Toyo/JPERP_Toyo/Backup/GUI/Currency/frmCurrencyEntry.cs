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
using System.Text.RegularExpressions;

namespace Account.GUI.Currency
{
    public partial class frmCurrencyEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CurrencyBL objEmployeeBL = new CurrencyBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtEmployee = new DataTable();

        int _Mode = 0;
        Int64 _EmpID = 0;
        
        
        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            dtEmployee = CommSelect.SelectRecord(_EmpID, "usp_Currency_Select", "Employee - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtEmployee.Rows.Count > 0)
                    {
                        txtCurrencyName.Text = dtEmployee.Rows[0]["CurrencyName"].ToString();

                        txtCurrency.Text = dtEmployee.Rows[0]["Currency"].ToString();
                        
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
                CommDelRec.DeleteRecord(_EmpID, "usp_Currency_Delete", "Employee - SetSave");
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

                            objEmployeeBL.Insert(txtCurrencyName.Text, txtCurrency.Text);
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objEmployeeBL.Update(_EmpID, txtCurrencyName.Text, txtCurrency.Text);
                        }

                        if (objEmployeeBL.Exception == null)
                        {
                            if (objEmployeeBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objEmployeeBL.ErrorMessage;
                                txtCurrencyName.Focus();
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
                            MessageBox.Show(objEmployeeBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }
            }

            return ReturnValue;
        }

        #endregion

        #region "Form Load events"

        public frmCurrencyEntry(int Mode, long EmpID)
        {
            InitializeComponent();
            _Mode = Mode;
            _EmpID = EmpID;
           
        }

        private void frmEmployeeEntry_Load(object sender, EventArgs e)
        {
            

           
            try
            {


               


                AddHandlers(this);
                SetControlsDefaults(this);
                //cmbDepartment.DropDownStyle = ComboBoxStyle.DropDown;
                //cmbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //cmbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
                //objCommon.FillDepartmentCombo(cmbDepartment);



                


                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    this.Text = "Currency - New";
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    this.Text = "Currency - Edit";
                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    SetReadOnlyControls(grpData);

                    btnSaveExit.Text = "Yes";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    btnCancel.Text = "No";
                    this.Text = "Employee - Delete";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button events"

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtCurrencyName.Text = "";
                txtCurrency.Text = "";
                //txtAddress1.Text = "";
                //txtPhone.Text = "";
                //txtEmail.Text = "";
                //txtSalary.Text = "0";
                //cmbDepartment.Text = "";
                txtCurrencyName.Focus();
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
        #endregion

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

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhone_KeyPress(sender, e);
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            //if (txtEmail.Text != "")
            //{
            //    string pattern = null;
            //    pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            //    if (Regex.IsMatch(txtEmail.Text, pattern))
            //    {
            //        //MessageBox.Show("Valid Email address ");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Not a valid Email address ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtEmail.Focus();
            //    }
            //}
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            //if (txtPhone.Text.Length < 10)
            //{
            //    MessageBox.Show("Please enter the correct Mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPhone.Focus();
            //}
            //if (txtPhone.Text.Length > 10)
            //{
            //    MessageBox.Show("Please enter the correct Mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPhone.Focus();
            //}
        }

    }
}
