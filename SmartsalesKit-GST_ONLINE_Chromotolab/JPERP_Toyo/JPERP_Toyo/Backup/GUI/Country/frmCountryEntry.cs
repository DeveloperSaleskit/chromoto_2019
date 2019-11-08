using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.BusinessLogic;
using Account.Common;
using Account .Validator;

namespace Account.GUI.Country
{
    public partial class frmCountryEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CountryBL objCountryBL = new CountryBL();
        DataTable dtCountry = new DataTable();
        int _Mode = 0;
        Int64 _CountryID = 0;

        #endregion

        #region "Form Events...."

        public frmCountryEntry(int Mode, Int64 CountryID)
        {
            InitializeComponent();
            _Mode = Mode;
            _CountryID = CountryID;
        }

        private void frmCountryEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            this.Text = "Country - New";

            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "Country - Edit";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtCountry = CommSelect.SelectRecord(_CountryID, "usp_Country_Select", "Country - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtCountry.Rows.Count > 0)
                        {
                            txtCountryName.Text = dtCountry.Rows[0]["CountryName"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
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
                        objCountryBL.Insert(txtCountryName.Text);
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objCountryBL.Update(_CountryID, txtCountryName.Text);
                    }

                    if (objCountryBL.Exception == null)
                    {
                        if (objCountryBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objCountryBL.ErrorMessage;
                            txtCountryName.Focus();
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
                        MessageBox.Show(objCountryBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Country", exc.StackTrace);
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
                txtCountryName.Text = "";
                txtCountryName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
