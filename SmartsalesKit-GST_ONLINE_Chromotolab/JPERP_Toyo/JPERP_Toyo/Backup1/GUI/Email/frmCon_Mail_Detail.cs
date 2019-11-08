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
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;

namespace Account.GUI.Email
{
    public partial class frmCon_Mail_Detail : Account.GUIBase
    {
            
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        EmailBL objUserBL = new EmailBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _Email_ID = 0;
        int CompId = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmCon_Mail_Detail(int Mode, Int64 Email_ID)
        {
            InitializeComponent();
            _Mode = Mode;
            _Email_ID = Email_ID;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            cmbHost.DropDownStyle = ComboBoxStyle.DropDown;
            cmbHost.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbHost.AutoCompleteSource = AutoCompleteSource.ListItems;
            objCommon.FillHostCombo(cmbHost);
            //objCommon.FillCityCombo(cmbType);
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "Mail Detail - Update";
                BindControl();

            }

            txtEmailId.CharacterCasing = CharacterCasing.Normal;
            txtCPassword.CharacterCasing = CharacterCasing.Normal;
            txtNPassword.CharacterCasing = CharacterCasing.Normal;
            txtPort.CharacterCasing = CharacterCasing.Normal;
            txtSSL.CharacterCasing = CharacterCasing.Normal;
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            txtEmailId.CharacterCasing = CharacterCasing.Normal;
            txtCPassword.CharacterCasing = CharacterCasing.Normal;
            txtNPassword.CharacterCasing = CharacterCasing.Normal;
            cmbHost.Text = CurrentCompany.Host;
            txtPort.Text = Convert.ToInt16(CurrentCompany.Port).ToString();
            txtSSL.Text = Convert.ToInt16(CurrentCompany.ssl).ToString();
            txtEmailId.Text = CurrentCompany.Con_Email;
            txtCPassword.Focus();
        }


        public bool SetSave()
        {
            bool ReturnValue = false;
            if (CurrentCompany.Con_Password != txtCPassword.Text)
            {
                MessageBox.Show("You have Entered Wrong Current Password.");

            }
            else
            {
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    objUserBL.Update_Email_Detail(txtEmailId.Text, txtNPassword.Text, cmbHost.Text, txtPort.Text, txtSSL.Text,CompId);

                    if (CommDelRec.Exception == null)
                    {
                        if (CommDelRec.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = CommDelRec.ErrorMessage;
                            ReturnValue = false;
                        }
                        else
                        {
                            ReturnValue = true;
                            CurrentCompany.Con_Password = txtNPassword.Text;
                            CurrentCompany.Con_Email = txtEmailId.Text;
                            CurrentCompany.Host = cmbHost.Text;
                            CurrentCompany.Port = Convert.ToInt16(txtPort.Text);
                            CurrentCompany.ssl = Convert.ToInt16(txtSSL.Text);
                            //txtEmailId.Text = CurrentCompany.Con_Email;

                        }
                    }
                    else
                    {
                        MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
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

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region "TEXTBOX EVENTS"
        private void txtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtSSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtSSL_TextChanged(object sender, EventArgs e)
        {
            if (txtSSL.Text == "1" || txtSSL.Text == "0")
            { }
            else
            {
                MessageBox.Show("Enter proper SSL value");
            }
        }

        #endregion

        private void cmbHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHost.Text == "smtp.gmail.com" || cmbHost.Text == "smtp.mail.yahoo.com")
            {
                txtPort.Text = "25";
                txtSSL.Text = "0";
            }
        }



    }
}


