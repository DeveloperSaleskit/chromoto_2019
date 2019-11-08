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

namespace Account.GUI.Expense
{
    public partial class frmExpenseEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        ExpenseBL objExpenseBL = new ExpenseBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtExpense = new DataTable();
        int _Mode = 0;
        Int64 _ExpenseID = 0;

        #endregion

        #region "Form Events...."

        public frmExpenseEntry(int Mode, Int64 ExpenseID)
        {
            InitializeComponent();
            _Mode = Mode;
            _ExpenseID = ExpenseID;
        }

        private void frmExpenseEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                txtExpenseCode.Text = objCommon.AutoNumber("EXP");
                this.Text = "Expense - New";

            }
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnRegenrate.Visible = false;
                btnSaveContinue.Visible = false;
                this.Text = "Expense - Edit";
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
                lblDelMsg.Visible = true;
                SetReadOnlyControls(grpExpense);
                btnSaveExit.Text = "Yes";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                btnCancel.Text = "No";
                this.Text = "Expense - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtExpense = CommSelect.SelectRecord(_ExpenseID, "usp_Expense_Select", "Expense - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtExpense.Rows.Count > 0)
                        {
                            txtExpenseCode.Text = dtExpense.Rows[0]["ExpNo"].ToString();
                            dtpDate.Value = Convert.ToDateTime(dtExpense.Rows[0]["Date"].ToString());
                            txtCrAmount.Text = dtExpense.Rows[0]["Amount"].ToString();
                            txtNarration.Text = dtExpense.Rows[0]["Narration"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
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
                    CommDelRec.DeleteRecord(_ExpenseID, "usp_Expense_Delete", "Expense - Delete");
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
                    if (DataValidator.IsValid(this.grpExpense))
                    {
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            objExpenseBL.Insert(txtExpenseCode.Text,Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text),txtNarration.Text);
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objExpenseBL.Update(_ExpenseID, Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), txtNarration.Text);
                        }

                        if (objExpenseBL.Exception == null)
                        {
                            if (objExpenseBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objExpenseBL.ErrorMessage;
                                dtpDate.Focus();
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
                            MessageBox.Show(objExpenseBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        #endregion

        #region "Button Event..."

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtExpenseCode.Text = objCommon.AutoNumber("EXP");
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
                txtExpenseCode.Text = objCommon.AutoNumber("EXP");
                txtNarration.Text = "";
                txtCrAmount.Text = "0.00";
                dtpDate.Value = DateTime.Now;
                dtpDate.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Textbox Event"

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        #endregion

    }
}
