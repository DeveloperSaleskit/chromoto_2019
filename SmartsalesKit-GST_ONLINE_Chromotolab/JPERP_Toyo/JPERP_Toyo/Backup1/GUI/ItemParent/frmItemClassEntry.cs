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
    public partial class frmItemClassEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        
        ItemClassBL objItemClassBL = new ItemClassBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtItemClass = new DataTable();

        int _Mode = 0;
        Int64 _ItemClassID = 0;

        #endregion

        #region "Form Event"

        public frmItemClassEntry(int Mode,long ItemClassID)
        {
            InitializeComponent();
            _Mode = Mode;
            _ItemClassID = ItemClassID;
        }

        private void frmItemClassEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                this.Text = "Item Class - New";

                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    this.Text = "Item Class - Edit";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Class-Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        
        #endregion

        #region "Private Methods"

        public void BindControl()
        {
            dtItemClass = CommSelect.SelectRecord(_ItemClassID, "usp_ItemClass_Select", "frmItemClassEntry-BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtItemClass.Rows.Count > 0)
                    {
                        txtItemClass.Text = dtItemClass.Rows[0]["Name"].ToString();
                        txtItemClassDescription.Text = dtItemClass.Rows[0]["Description"].ToString();
                        
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
                    objItemClassBL.Insert(txtItemClass.Text,txtItemClassDescription.Text);
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objItemClassBL.Update(_ItemClassID, txtItemClass.Text,txtItemClassDescription.Text);
                }

                if (objItemClassBL.Exception == null)
                {
                    if (objItemClassBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objItemClassBL.ErrorMessage;
                        txtItemClass.Focus();
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
                    MessageBox.Show(objItemClassBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }
        
        #endregion

        #region "Button Event"

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtItemClass.Text = "";
                txtItemClassDescription.Text = "";
                txtItemClass.Focus();
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
    }
}
