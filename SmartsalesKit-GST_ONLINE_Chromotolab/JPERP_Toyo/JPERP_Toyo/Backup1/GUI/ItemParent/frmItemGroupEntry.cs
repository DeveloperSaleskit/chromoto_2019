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
    public partial class frmItemGroupEntry : Account.GUIBase
    {
        #region "Variable declaration"

        CommonSelectBL CommSelect = new CommonSelectBL();

        ItemGroupBL objItemGroupBL = new ItemGroupBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtItemGroup = new DataTable();

        int _Mode = 0;
        Int64 _ItemGroupID = 0;
        #endregion

        #region "Form Load Events"

        public frmItemGroupEntry(int Mode,long ItemGroupID)
        {
            InitializeComponent();
            _Mode = Mode;
            _ItemGroupID = ItemGroupID;

        }

        private void frmItemGroupEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                this.Text = "Item Group - New";

                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    this.Text = "Item Group - Edit";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Group-Entry", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Private helper methods"
        
        public void BindControl()
        {
            dtItemGroup = CommSelect.SelectRecord(_ItemGroupID, "usp_ItemGroup_Select", "frmItemGroupEntry - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtItemGroup.Rows.Count > 0)
                    {
                        txtItemGroup.Text = dtItemGroup.Rows[0]["Name"].ToString();
                        

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
                    objItemGroupBL.Insert(txtItemGroup.Text);
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objItemGroupBL.Update(_ItemGroupID, txtItemGroup.Text);
                }

                if (objItemGroupBL.Exception == null)
                {
                    if (objItemGroupBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objItemGroupBL.ErrorMessage;
                        txtItemGroup.Focus();
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
                    MessageBox.Show(objItemGroupBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }

            return ReturnValue;
        }
        
        #endregion
        
        #region "Button Events"

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtItemGroup.Text = "";
                txtItemGroup.Focus();
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
