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
namespace Account.GUI.Quotation
{
    public partial class frmQuotationFollowup : Account.GUIBase
    {
        #region "Variable Declaration..."

        QuotationBL objLeadBL = new QuotationBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        Int64 _LeadID = 0;
        
        #endregion

        #region "Public Methods..."

        public bool SetSave()
        {
            bool ReturnValue = false;

            if (DataValidator.IsValid(this.grpData))
            {
                objLeadBL.InsertFollowUp(_LeadID, dtpNextDate.Value, txtRemark.Text, (long)cmbFollowUpBy.SelectedValue);
                if (objLeadBL.Exception == null)
                {
                    if (objLeadBL.ErrorMessage != "")
                    {
                        lblErrorMessage.Text = objLeadBL.ErrorMessage;
                        dtpNextDate.Focus();
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
                    MessageBox.Show(objLeadBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }
            return ReturnValue;
        }

        #endregion

        public frmQuotationFollowup(long LeadID, string leadNo, string leadDate, string customerName, string followUpdate)
        {
            InitializeComponent();
            _LeadID = LeadID;
            txtLeadNo.Text = leadNo;
            txtLeaddate.Text = leadDate;
            txtCustomerName.Text = customerName;
            txtFollowupDate.Text = followUpdate;
        }

        private void frmLeadFollowup_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                dtpNextDate.Value = DateTime.Now;
                this.Text = "Follo up";
                //objCommon.FillUserInfoCombo(cmbFollowUpBy);
                objCommon.FillEmployeeCombo(cmbFollowUpBy);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Close();
                frmQuotationList FLov = new frmQuotationList();
                FLov.LoadFollowUpList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
