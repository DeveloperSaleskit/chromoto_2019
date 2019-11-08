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

namespace Account.GUI.Company
{
    public partial class frmCompanyEntry : Account.GUIBase
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);



        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        EmailBL objUserBL = new EmailBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _Email_ID = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmCompanyEntry()
        {
            InitializeComponent();
            //_Mode = Mode;
            //_Email_ID = Email_ID;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillCityCombo(cmbCity);
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

            //txtCompanyName.CharacterCasing = CharacterCasing.Normal;
            //txtBussinessLine.CharacterCasing = CharacterCasing.Normal;
            //txtAddress1.CharacterCasing = CharacterCasing.Normal;
            //txtPort.CharacterCasing = CharacterCasing.Normal;
            //txtSSL.CharacterCasing = CharacterCasing.Normal;
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            txtCompanyName.CharacterCasing = CharacterCasing.Normal;
            txtBussinessLine.CharacterCasing = CharacterCasing.Normal;
            txtAddress1.CharacterCasing = CharacterCasing.Normal;

            txtCompanyName.Text = CurrentCompany.Con_Email;
            txtBussinessLine.Focus();
        }


        public bool SetSave()
        {
            bool ReturnValue = false;
            if (CurrentCompany.Con_Password != txtBussinessLine.Text)
            {
                MessageBox.Show("You have Entered Wrong Current Password.");

            }
            else
            {
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    //objUserBL.Update_Email_Detail(txtCompanyName.Text, txtAddress1.Text, cmbState.Text, txtPort.Text, txtSSL.Text);

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
                            CurrentCompany.Con_Password = txtAddress1.Text;
                            CurrentCompany.Con_Email = txtCompanyName.Text;
                            CurrentCompany.Con_Host = cmbState.Text;
                            //CurrentCompany.Con_Port = txtPort.Text;
                            //CurrentCompany.Con_SSL = txtSSL.Text;

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
    }
}


