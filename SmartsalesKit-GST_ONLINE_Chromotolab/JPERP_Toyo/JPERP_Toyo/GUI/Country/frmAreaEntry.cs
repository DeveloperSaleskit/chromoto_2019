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
    public partial class frmAreaEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        AreaBL objAreaBL = new AreaBL();
        DataTable dtArea = new DataTable();
        int _Mode = 0;
        Int64 _AreaID = 0;
        string _CountryName = "";
        string _StateName = "";
        long _CityID = 0;
        string _CityName = "";

        #endregion

        #region "Form Events...."

        public frmAreaEntry(int Mode, Int64 AreaID, string CountryName, string StateName, long CityID, string CityName)
        {
            InitializeComponent();
            _Mode = Mode;
            _AreaID = AreaID;
            _CountryName = CountryName;
            _StateName = StateName;
            _CityID = CityID;
            _CityName = CityName;
        }

        private void frmAreaEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            txtCountry.Text = _CountryName;
            txtState.Text = _StateName;
            txtCity.Text = _CityName;
            this.Text = "Area - New";

            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "Area - Edit";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtArea = CommSelect.SelectRecord(_AreaID, "usp_Area_Select", "Area - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtArea.Rows.Count > 0)
                        {
                            txtAreaName.Text = dtArea.Rows[0]["AreaName"].ToString();
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
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
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
                        objAreaBL.Insert(_CityID, txtAreaName.Text);
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objAreaBL.Update(_AreaID, _CityID, txtAreaName.Text);
                    }

                    if (objAreaBL.Exception == null)
                    {
                        if (objAreaBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objAreaBL.ErrorMessage;
                            txtAreaName.Focus();
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
                        MessageBox.Show(objAreaBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Area", exc.StackTrace);
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
                txtAreaName.Text = "";
                txtAreaName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
