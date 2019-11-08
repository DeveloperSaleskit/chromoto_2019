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
    public partial class frmCityEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CityBL objCityBL = new CityBL();
        DataTable dtCity = new DataTable();
        int _Mode = 0;
        Int64 _CityID = 0;
        string _CountryName = "";
        long _StateID = 0;
        string _StateName = "";

        #endregion

        #region "Form Events...."

        public frmCityEntry(int Mode, Int64 CityID, string CountryName, long StateID, string StateName)
        {
            InitializeComponent();
            _Mode = Mode;
            _CityID = CityID;
            _CountryName = CountryName;
            _StateID = StateID;
            _StateName = StateName;
        }

        private void frmCityEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            txtCountry.Text = _CountryName;
            txtState.Text = _StateName;
            this.Text = "City - New";

            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "City - Edit";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try{
            dtCity = CommSelect.SelectRecord(_CityID, "usp_City_Select","City - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtCity.Rows.Count > 0)
                    {
                        txtCityName.Text = dtCity.Rows[0]["CityName"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
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
                    objCityBL.Insert(_StateID, txtCityName.Text);
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objCityBL.Update(_CityID, _StateID, txtCityName.Text);
                }

                if (objCityBL.Exception == null)
                {
                    if (objCityBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objCityBL.ErrorMessage;
                        txtCityName.Focus();
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
                    MessageBox.Show(objCityBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }

            
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
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
                txtCityName.Text = "";
                txtCityName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
