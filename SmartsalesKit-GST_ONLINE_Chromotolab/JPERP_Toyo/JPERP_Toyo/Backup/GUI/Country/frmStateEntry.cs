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

namespace Account.GUI.Country
{
    public partial class frmStateEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        StateBL objStateBL = new StateBL();
        DataTable dtState = new DataTable();
        int _Mode = 0;
        Int64 _StateID = 0;
        long _CountryID = 0;
        string _CountryName = "";

        #endregion

        #region "Form Events...."

        public frmStateEntry(int Mode, Int64 StateID, long CountryID, string CountryName)
        {
            InitializeComponent();
            _Mode = Mode;
            _StateID = StateID;
            _CountryID = CountryID;
            _CountryName = CountryName;
        }

        private void frmStateEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            txtCountry.Text = _CountryName;
            this.Text = "State - New";

            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "State - Edit";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
            dtState = CommSelect.SelectRecord(_StateID, "usp_State_Select","State - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtState.Rows.Count > 0)
                    {
                        txtStateName.Text = dtState.Rows[0]["StateName"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
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
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    objStateBL.Insert(_CountryID, txtStateName.Text);
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objStateBL.Update(_StateID, _CountryID, txtStateName.Text);
                }

                if (objStateBL.Exception == null)
                {
                    if (objStateBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objStateBL.ErrorMessage;
                        txtStateName.Focus();
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
                    MessageBox.Show(objStateBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("State", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }
        #endregion

        #region "Button Event..."

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
                txtStateName.Text = "";
                txtStateName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
