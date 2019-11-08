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

namespace Account.GUI.Bank_Master
{
    public partial class frmBankEntry : Account.GUIBase
    {

        
       

        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        BankBL objUserBL = new BankBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _GodownID = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmBankEntry(int Mode, Int64 GodownID)
        {
            InitializeComponent();
            _Mode = Mode;
            _GodownID = GodownID;
        }
      
        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
          
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                this.Text = "Bank - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "Bank - Edit";
                BindControl();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "Bank - Delete";
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
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            dtUser = CommSelect.SelectRecord(_GodownID, "usp_Bank_Select", "Godown - BindControl");

            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtBankName.Text = dtUser.Rows[0]["BankName"].ToString();

                        txtaddress.Text = dtUser.Rows[0]["BankAddr"].ToString();

                        txtifsccode.Text = dtUser.Rows[0]["IFSCcode"].ToString();
                        txtAccNo.Text=dtUser.Rows[0]["AccNo"].ToString();
                        txtPhNo.Text = dtUser.Rows[0]["PhNo"].ToString();
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
                CommDelRec.DeleteRecord(_GodownID, "usp_Bank_Delete", "Bank - Delete");
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
                        objUserBL.Insert(txtBankName.Text,txtaddress.Text, txtifsccode.Text,txtAccNo.Text,txtPhNo.Text);
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objUserBL.Update(_GodownID, txtBankName.Text, txtaddress.Text, txtifsccode.Text, txtAccNo.Text, txtPhNo.Text);
                    }

                    if (objUserBL.Exception == null)
                    {
                        if (objUserBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objUserBL.ErrorMessage;
                            txtBankName.Focus();
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
                txtBankName.Text = "";
                txtifsccode.Text = "";
                txtAccNo.Text = "";
                txtPhNo.Text = "";

                txtaddress.Text = "";
                txtBankName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    
    }
}


