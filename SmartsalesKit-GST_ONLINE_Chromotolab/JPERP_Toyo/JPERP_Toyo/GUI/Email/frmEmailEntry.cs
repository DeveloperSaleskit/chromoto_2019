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
    public partial class frmEmailEntry : Account.GUIBase
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

        public frmEmailEntry(int Mode, Int64 Email_ID)
        {
            InitializeComponent();
            _Mode = Mode;
            _Email_ID = Email_ID;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            cmbType.SelectedIndex = 0;
            //objCommon.FillCityCombo(cmbType);
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                this.Text = "Email - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "Email - Edit";
                BindControl();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "Email - Delete";
                BindControl();

                SetReadOnlyControls(grpData);
                btnSaveContinue.Visible = false;
                btnSaveExit.Text = "Yes";
                btnCancel.Text = "No";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                lblDelMsg.Visible = true;
            }
            txtSubject.CharacterCasing = CharacterCasing.Normal;
            txtHeader.CharacterCasing = CharacterCasing.Normal;
            txtFooter.CharacterCasing = CharacterCasing.Normal;
            cmbType.Enabled = false;
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {

            dtUser = CommSelect.SelectRecord(_Email_ID, "usp_Email_Select", "Email - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtSubject.CharacterCasing = CharacterCasing.Normal;
                        txtHeader.CharacterCasing = CharacterCasing.Normal;
                        txtFooter.CharacterCasing = CharacterCasing.Normal;
                        cmbType.SelectedItem = dtUser.Rows[0]["Type"].ToString();
                        txtSubject.Text = dtUser.Rows[0]["Subject"].ToString();
                        txtHeader.Text = dtUser.Rows[0]["Header"].ToString();
                        if (CurrentUser.UnitID == 1 || CurrentUser.UnitID == 2 || CurrentUser.UnitID == 3)
                       {
                            txtFooter.Text = dtUser.Rows[0]["Footer"].ToString();
                       }
                        else
                      {
                            txtFooter.Text = "Rgds,"+"\r\n"+CurrentUser.EmaiId + "\r\n" + CurrentUser.PhonNo + "\r\n" +CurrentUser.Address+"\r\n"+ CurrentCompany.CompanyName;
                      }
                            //    txtFooter.Text = CurrentUser.EmaiId + "\r\n" + CurrentUser.PhonNo + "\r\n" + CurrentUser.Address + dtUser.Rows[0]["Footer"].ToString();
                        
                        //lblAddress.Text = CurrentUser.Address;
                        //lblEmailId.Text = CurrentUser.EmaiId;
                        //lblPhonNo.Text = CurrentUser.PhonNo;//
                       // +CurrentUser.EmaiId+CurrentUser.PhonNo+CurrentUser.Address
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
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_Email_ID, "usp_Email_Delete", "Email - Delete");
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
                    }
                }
                else
                {
                    MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            }
            else
            {
                if (DataValidator.IsValid(this.grpData))
                {

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                       
                        objUserBL.Insert(cmbType.Text, txtSubject.Text, txtHeader.Text, txtFooter.Text,CompId);
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objUserBL.Update(_Email_ID, cmbType.Text, txtSubject.Text, txtHeader.Text, txtFooter.Text,CompId);
                    }

                    if (objUserBL.Exception == null)
                    {
                        if (objUserBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objUserBL.ErrorMessage;
                            txtSubject.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
                            ReturnValue = true;
                            lblErrorMessage.Text = "No error";
                        }
                    }
                    else
                    {
                        MessageBox.Show(objUserBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtSubject.Text = "";
                cmbType.SelectedIndex = 0;
                txtFooter.Text = "";
                txtHeader.Text = "";
                txtSubject.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

      

    }
}


