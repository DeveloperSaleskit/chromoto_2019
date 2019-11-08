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

namespace Account.GUI.ItemParent
{
    public partial class frmUOMEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();

        UOMBL objUOMBL = new UOMBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtUOM = new DataTable();

        int _Mode = 0;
        Int64 _UOMID = 0;

        #endregion

        #region "Form Load Events"

        public frmUOMEntry(int Mode, long UOMID)
        {
            InitializeComponent();
            _Mode = Mode;
            _UOMID = UOMID;
        }

        private void frmUOMEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                this.Text = "UOM - New";

                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    this.Text = "UOM - Edit";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("UOM - Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Private Methods"

        public void BindControl()
        {
            dtUOM = CommSelect.SelectRecord(_UOMID, "usp_UOM_Select", "frmUOMEntry-BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUOM.Rows.Count > 0)
                    {
                        txtUOMName.Text = dtUOM.Rows[0]["Name"].ToString();
                        txtAbbreviation.Text = dtUOM.Rows[0]["Abbr"].ToString();

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

            if (DataValidator.IsValid(this.grpData))
            {
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    objUOMBL.Insert(txtUOMName.Text, txtAbbreviation.Text);
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objUOMBL.Update(_UOMID, txtUOMName.Text, txtAbbreviation.Text);
                }

                if (objUOMBL.Exception == null)
                {
                    if (objUOMBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objUOMBL.ErrorMessage;
                        txtUOMName.Focus();
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
                    MessageBox.Show(objUOMBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }

        #endregion

        #region "Button event"

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtUOMName.Text = "";
                txtAbbreviation.Text = "";
                txtUOMName.Focus();

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
    }
}
