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

namespace Account.GUI.TypeOfCall
{
    public partial class frmTypeOfCallEntry : Account.GUIBase
    {

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
       


        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        TypeOfCallBL objUserBL = new TypeOfCallBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _GodownID = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmTypeOfCallEntry(int Mode, Int64 DeptID)
        {
            InitializeComponent();
            _Mode = Mode;
            _GodownID = DeptID;
        }

        

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {

            dtUser = CommSelect.SelectRecord(_GodownID, "usp_TypeOfCall_Select", "TypeOfCall - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtNameOfCall.Text = dtUser.Rows[0]["Call_Name"].ToString();

                        txtDesc.Text = dtUser.Rows[0]["Description"].ToString();
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
                CommDelRec.DeleteRecord(_GodownID, "usp_TypeOfCall_Delete", "TypeOfCall - Delete");
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
                        objUserBL.Insert(txtNameOfCall.Text,txtDesc.Text);
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objUserBL.Update(_GodownID, txtNameOfCall.Text,txtDesc.Text);
                    }

                    if (objUserBL.Exception == null)
                    {
                        if (objUserBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objUserBL.ErrorMessage;
                            txtNameOfCall.Focus();
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
                txtNameOfCall.Text = "";
           
                txtDesc.Text = "";
                txtNameOfCall.Focus();
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

        private void frmDepartmentEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            //objCommon.FillCityCombo(cmbCity);
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                this.Text = "TypeOfCall - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "TypeOfCall - Edit";
                BindControl();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "TypeOfCall - Delete";
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

   

    }
}


