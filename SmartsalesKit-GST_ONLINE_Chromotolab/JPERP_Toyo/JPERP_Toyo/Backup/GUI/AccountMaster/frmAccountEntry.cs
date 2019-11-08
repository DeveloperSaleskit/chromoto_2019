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

namespace Account.GUI.AccountMaster
{
    public partial class frmAccountMasterEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        AccountBL objAccountMasterBL = new AccountBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtAccountMaster = new DataTable();
        int _Mode = 0;
        Int64 _AccountMasterID = 0;

        #endregion

        #region "Form Events...."

        public frmAccountMasterEntry(int Mode, Int64 AccountMasterID)
        {
            InitializeComponent();
            _Mode = Mode;
            _AccountMasterID = AccountMasterID;
        }

        private void frmAccountMasterEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                txtAccountCode.Text = objCommon.AutoNumber("ACC");
                this.Text = "Account - New";

            }
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnRegenrate.Visible = false;
                btnSaveContinue.Visible = false;
                this.Text = "Account - Edit";
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                btnRegenrate.Visible = false;
                lblDelMsg.Visible = true;
                SetReadOnlyControls(grpAccountMaster);
                SetReadOnlyControls(grpData);
                btnSaveExit.Text = "Yes";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                btnCancel.Text = "No";
                this.Text = "Account - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtAccountMaster = CommSelect.SelectRecord(_AccountMasterID, "usp_Account_Select", "AccountMaster - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtAccountMaster.Rows.Count > 0)
                        {
                            txtAccountCode.Text = dtAccountMaster.Rows[0]["AccountCode"].ToString();
                            txtAccountName.Text = dtAccountMaster.Rows[0]["AccountName"].ToString();
                            dtpDate.Value = Convert.ToDateTime(dtAccountMaster.Rows[0]["AccCreatedDate"].ToString());
                            txtCrAmount.Text = dtAccountMaster.Rows[0]["CRAmount"].ToString();
                            txtDbAmount.Text = dtAccountMaster.Rows[0]["DBAmount"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
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
                    objAccountMasterBL.Delete(_AccountMasterID, "usp_Account_Delete", "Account - Delete");
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
                    if (DataValidator.IsValid(this.grpAccountMaster))
                    {
                        if (DataValidator.IsValid(this.grpData))
                        {
                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                objAccountMasterBL.Insert(txtAccountCode.Text, txtAccountName.Text, Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text));
                            }
                            else if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                objAccountMasterBL.Update(_AccountMasterID, txtAccountCode.Text, txtAccountName.Text, Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text));
                            }

                            if (objAccountMasterBL.Exception == null)
                            {
                                if (objAccountMasterBL.ErrorMessage != "")
                                {
                                    lblErrorMessage.Text = objAccountMasterBL.ErrorMessage;
                                    txtAccountName.Focus();
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
                                MessageBox.Show(objAccountMasterBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }
                        }
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        #endregion

        #region "Button Event..."

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtAccountCode.Text = objCommon.AutoNumber("ACC");
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
                txtAccountCode.Text = objCommon.AutoNumber("ACC");
                txtAccountName.Text = "";
                txtCrAmount.Text = "0.00";
                txtDbAmount.Text = "0.00";
                dtpDate.Value = DateTime.Now;
                txtAccountName.Focus();
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
