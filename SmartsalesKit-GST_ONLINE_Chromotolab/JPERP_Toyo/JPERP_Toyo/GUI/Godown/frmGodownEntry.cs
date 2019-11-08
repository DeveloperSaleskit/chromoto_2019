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

namespace Account.GUI.Godown
{
    public partial class frmGodownEntry : Account.GUIBase
    {

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
       


        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        GodownBL objUserBL = new GodownBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _GodownID = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmGodownEntry(int Mode, Int64 GodownID)
        {
            InitializeComponent();
            _Mode = Mode;
            _GodownID = GodownID;
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
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                this.Text = "Godown - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "Godown - Edit";
                BindControl();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "Godown - Delete";
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

            dtUser = CommSelect.SelectRecord(_GodownID, "usp_Godown_Select", "Godown - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtUserName.Text = dtUser.Rows[0]["Godown_name"].ToString();
                       
                        txtName.Text = dtUser.Rows[0]["Godown_addr"].ToString();

                        cmbCity.SelectedValue = dtUser.Rows[0]["CityID"].ToString();
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
                CommDelRec.DeleteRecord(_GodownID, "usp_Godown_Delete", "Godown - Delete");
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
                        objUserBL.Insert(txtUserName.Text,txtName.Text, Convert.ToInt32(cmbCity.SelectedValue));
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objUserBL.Update(_GodownID, txtUserName.Text, txtName.Text,Convert.ToInt32(cmbCity.SelectedValue) );
                    }

                    if (objUserBL.Exception == null)
                    {
                        if (objUserBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objUserBL.ErrorMessage;
                            txtUserName.Focus();
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
                txtUserName.Text = "";
           
                txtName.Text = "";
                txtUserName.Focus();
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


