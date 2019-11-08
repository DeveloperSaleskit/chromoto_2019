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
    public partial class frmItemCategoryEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();

        ItemCategoryBL objItemCategoryBL = new ItemCategoryBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtItemCategory = new DataTable();

        int _Mode = 0;
        Int64 _CategoryID = 0;

        #endregion

        #region "Form load event"
            
        public frmItemCategoryEntry(int Mode,long CategoryID)
            {
                InitializeComponent();
                _Mode = Mode;
                _CategoryID = CategoryID;
            }

        private void frmItemCategoryEntry_Load(object sender, EventArgs e)
            {
                try
                {
                    AddHandlers(this);
                    SetControlsDefaults(this);
                    this.Text = "Item Category - New";

                    objCommon.FillItemGroupDDL(cmbItemGroup);
                    if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        BindControl();
                        btnSaveContinue.Visible = false;
                        this.Text = "Item Category - Edit";
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Item Category - Entry", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            
        #endregion

        #region "Private Methods"

        public void BindControl()
        {
            dtItemCategory = CommSelect.SelectRecord(_CategoryID, "usp_ItemCategory_Select", "frmItemCategoryEntry-BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtItemCategory.Rows.Count > 0)
                    {
                        txtItemCategory.Text = dtItemCategory.Rows[0]["Name"].ToString();
                        cmbItemGroup.SelectedValue = dtItemCategory.Rows[0]["ItemGroupID"];

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
                    objItemCategoryBL.Insert(txtItemCategory.Text, Convert.ToInt64(cmbItemGroup.SelectedValue));
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objItemCategoryBL.Update(_CategoryID, txtItemCategory.Text, Convert.ToInt64(cmbItemGroup.SelectedValue));
                }

                if (objItemCategoryBL.Exception == null)
                {
                    if (objItemCategoryBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objItemCategoryBL.ErrorMessage;
                        txtItemCategory.Focus();
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
                    MessageBox.Show(objItemCategoryBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtItemCategory.Text = "";
                cmbItemGroup.SelectedIndex = 0;
                txtItemCategory.Focus();
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
