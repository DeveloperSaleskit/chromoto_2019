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

namespace Account.GUI.Commission
{
    public partial class frmCommissionEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonListBL CommList = new CommonListBL();
        CommissionBL objCommisionBL = new CommissionBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtAccountMaster = new DataTable();

        #endregion

        #region "Form Events...."

        public frmCommissionEntry()
        {
            InitializeComponent();
        }

        private void frmCommissionEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

                FillAccountCombo(cmbAccount);
                this.Text = "Commission ";

        }

        #endregion

        #region "Public Methods..."

        public void FillAccountCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();
            dtCity = CommList.ListOfRecord("usp_Account_LOV", null, "Commission - FillAccountCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["AccountID"] = 0;
                dr["AccountName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "AccountName";
                cmb.ValueMember = "AccountID";
            }
        }

        public bool SetSave()
        {
            bool ReturnValue = false;
            try
            {
                if (DataValidator.IsValid(this.grpData))
                {
                    
                        objCommisionBL.Insert(Convert.ToInt64(cmbAccount.SelectedValue), Convert.ToDateTime(dtpDate.Value), Convert.ToDecimal(txtCrAmount.Text), Convert.ToDecimal(txtDbAmount.Text), txtNarration.Text);
                    if (objCommisionBL.Exception == null)
                    {
                        if (objCommisionBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objCommisionBL.ErrorMessage;
                            txtNarration.Focus();
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
                        MessageBox.Show(objCommisionBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Commission", exc.StackTrace);
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
