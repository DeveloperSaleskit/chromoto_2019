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

namespace Account.GUI.Users
{
    public partial class frmUserEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        UserBL objUserBL = new UserBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _UserID = 0;
        int _CompId = 0;
        int CompanyID;
        int CompId = 0;
        bool flag;
        bool detFlag;
        bool tmpflag;
        public bool Mail_ByUser;
        TreeNode pNode;
        DataTable dtPrivilage = new DataTable();
        DataTable dtblUserPrivilieges = new DataTable();
        DataSet dsUserPrivilieges = new DataSet();
        DataSet dsUserDetPrivilieges = new DataSet();
        bool _IsChangesInTree = false;
        
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmUserEntry(int Mode, Int64 UserID, int CompId)
        {
            InitializeComponent();
            _Mode = Mode;
            _UserID = UserID;
            _CompId = CompId;
        }

        private void frmUserEntry_Load(object sender, EventArgs e)
        {



            AddHandlers(this);
            SetControlsDefaults(this);
            txtEmailId.Text = CurrentCompany.Con_Email;

            if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "FALSE")
            {
                grpPrivi.Visible = false;
                this.Width = 570;
                this.Height = 520;
            }

            if (chksend.Checked)
            {
                CurrentCompany.Con_Email = txtUserEmail.Text;
                CurrentCompany.Con_Port = txtPort.Text;
                CurrentCompany.Con_SSL = txtSSL.Text;
                CurrentCompany.Con_Host = cmbHost.Text;
            }
            else
            {
                CurrentCompany.Con_Email = txtEmailId.Text;
            }

            txtEmailId.Text = CurrentCompany.Con_Email;
            cmbHost.DropDownStyle = ComboBoxStyle.DropDown;
            cmbHost.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbHost.AutoCompleteSource = AutoCompleteSource.ListItems;
            objCommon.FillHostCombo(cmbHost);
            

            if (_CompId == 1)
            {
                cmbComp.Visible = true;
                label1.Visible = true;
            }
            else
            {
                cmbComp.Visible = false;
                label1.Visible = false;
            }

            objCommon.FillCompanyCombo(cmbComp);
            cmbComp.SelectedIndex = 1;

           
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            FillPrivilegesList();
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                this.Text = "User - New";
                txtEmailId.Enabled = false;

                txtUserEmail.Text = CurrentCompany.Con_Email;
                txtCPassword.Text = CurrentCompany.Con_Password;
                txtNPassword.Text = CurrentCompany.Con_Password;
                cmbHost.Text = CurrentCompany.Host;
                txtPort.Text = CurrentCompany.Port.ToString();
                txtSSL.Text = CurrentCompany.ssl.ToString();
              
               
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "User - Edit";
                BindControl();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "User - Delete";
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
            txtEmailId.CharacterCasing = CharacterCasing.Normal;
            txtCPassword.CharacterCasing = CharacterCasing.Normal;
            txtNPassword.CharacterCasing = CharacterCasing.Normal;
            txtPort.CharacterCasing = CharacterCasing.Normal;
            txtSSL.CharacterCasing = CharacterCasing.Normal;
        }

        private void FillPrivilegesList()
        {
            dtblUserPrivilieges = objUserBL.GetUserPriviliegiesList();
            if (objUserBL.Exception == null)
            {
                if (objUserBL.ErrorMessage == "")
                {
                    try
                    {
                        trvUserPrivilieges.Nodes.Clear();
                        flag = false;
                        detFlag = false;
                        dsUserPrivilieges.Tables.Add(dtblUserPrivilieges);


                        foreach (DataRow drUserPrivilieges in dtblUserPrivilieges.Rows)
                        {
                            pNode = new TreeNode();
                            if (drUserPrivilieges["ParentID"].ToString() == drUserPrivilieges["MainID"].ToString())
                            {
                                pNode.Text = drUserPrivilieges["Caption"].ToString();
                                pNode.Name = drUserPrivilieges["Caption"].ToString();
                                pNode.Tag = drUserPrivilieges["PrivilegeID"].ToString();
                                trvUserPrivilieges.Nodes[trvUserPrivilieges.Nodes.Count - 1].Nodes.Add(pNode);
                            }
                            else
                            {
                                pNode.Text = drUserPrivilieges["Caption"].ToString();
                                pNode.Name = drUserPrivilieges["Caption"].ToString();
                                pNode.Tag = drUserPrivilieges["PrivilegeID"].ToString();
                                trvUserPrivilieges.Nodes.Add(pNode);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(CommSelect.ErrorMessage);
                }
            }
            else
            {
                MessageBox.Show(objUserBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            dtUser = CommSelect.SelectRecord(_UserID, "usp_User_Select", "User - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtUserName.Text = dtUser.Rows[0]["UserName"].ToString();
                        txtPassword.Text = dtUser.Rows[0]["Password"].ToString();
                        txtConfirmPassword.Text = dtUser.Rows[0]["Password"].ToString();
                        txtName.Text = dtUser.Rows[0]["Name"].ToString();
                        txtEmailId.Text = dtUser.Rows[0]["Company_Email"].ToString();
                        txtUserEmail.Text = dtUser.Rows[0]["User_Email"].ToString();
                        txtSSL.Text = dtUser.Rows[0]["User_ssl"].ToString();
                        txtPort.Text = dtUser.Rows[0]["User_Port"].ToString();
                        cmbHost.Text = dtUser.Rows[0]["User_Host"].ToString();


                        dtPrivilage = CommSelect.SelectRecord(_UserID, "usp_Get_Privilage_List", "User - BindControl");
                        if (CommSelect.Exception == null)
                        {
                            if (CommSelect.ErrorMessage == "")
                            {
                                if (dtPrivilage.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtPrivilage.Rows.Count; i++)
                                    {
                                        for (int j = 0; j < trvUserPrivilieges.Nodes.Count; j++)
                                        {
                                            if (dtPrivilage.Rows[i]["PrivilegeID"].ToString().Trim() == trvUserPrivilieges.Nodes[j].Tag.ToString().Trim())
                                            {
                                                trvUserPrivilieges.Nodes[j].Checked = true;
                                                trvUserPrivilieges.Nodes[j].Expand();
                                            }

                                        }
                                    }


                                    for (int p = 0; p < trvUserPrivilieges.Nodes.Count; p++)
                                    {
                                        if (trvUserPrivilieges.Nodes[p].Checked == true)
                                        {
                                            for (int q = 0; q < dtPrivilage.Rows.Count; q++)
                                            {
                                                for (int r = 0; r < trvUserPrivilieges.Nodes[p].Nodes.Count; r++)
                                                {
                                                    if (trvUserPrivilieges.Nodes[p].Nodes[r].Tag.ToString().Trim() == dtPrivilage.Rows[q]["PrivilegeID"].ToString().Trim())
                                                    {
                                                        trvUserPrivilieges.Nodes[p].Nodes[r].Checked = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
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
                CommDelRec.DeleteRecord(_UserID, "usp_User_Delete", "User - Delete");
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
                    //if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                    //{
                    string strPrivilegeList = "";
                    int i = 0;
                    DataTable dtblIGMSPrivilieges = new DataTable();

                    for (i = 0; i < trvUserPrivilieges.Nodes.Count; i++)
                    {
                        if (trvUserPrivilieges.Nodes[i].Checked == true)
                        {
                            strPrivilegeList = strPrivilegeList + trvUserPrivilieges.Nodes[i].Tag.ToString() + ",";
                            dtblIGMSPrivilieges = objUserBL.GetUserParentPriviliegiesList(Convert.ToInt64(trvUserPrivilieges.Nodes[i].Tag));
                            for (int j = 0; j < trvUserPrivilieges.Nodes[i].Nodes.Count; j++)
                            {
                                if (trvUserPrivilieges.Nodes[i].Nodes[j].Checked == true)
                                {
                                    strPrivilegeList = strPrivilegeList + trvUserPrivilieges.Nodes[i].Nodes[j].Tag.ToString() + ",";
                                }

                            }

                            
                        }
                    }
                    if (strPrivilegeList != "")
                    {
                        strPrivilegeList = strPrivilegeList.Substring(0, strPrivilegeList.Length - 1);
                    }
                    else
                    {
                        if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "FALSE")
                        {

                        }
                        else
                        {
                            lblErrorMessage.Text = "Select at least one privilege";
                            return false;
                        }                      
                    }
                    if (chksend.Checked)
                    {
                        Mail_ByUser = true;

                    }
                    else
                    {
                        Mail_ByUser = false;
                    }

                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        if (_CompId == 1)
                        {
                            CompanyID = Convert.ToInt16(cmbComp.SelectedValue.ToString());

                                                      
                        }
                        else
                        {
                            CompanyID = _CompId;
                            label1.Visible = false;

                        }
                        objUserBL.Insert(CompanyID, cmbComp.Text, txtUserName.Text, txtPassword.Text, txtName.Text, txtEmailId.Text, txtUserEmail.Text, txtCPassword.Text, txtNPassword.Text, cmbHost.Text, txtPort.Text, txtSSL.Text, Mail_ByUser, strPrivilegeList);

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

                                //CurrentCompany.Con_Password = txtNPassword.Text;
                                //CurrentCompany.Con_Email = txtEmailId.Text;
                                //CurrentCompany.Host = cmbHost.Text;
                                //CurrentCompany.Port = Convert.ToInt16(txtPort.Text);
                                //CurrentCompany.ssl = Convert.ToInt16(txtSSL.Text);
                                //txtEmailId.Text = CurrentCompany.Con_Email;

                            }
                        }

                        //}

                    }
                    //else
                    //{
                    //    lblErrorMessage.Text = "Password and confirm password must be same";
                    //    ReturnValue = false;
                    //}
                    //}
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        if (_CompId == 1)
                        {
                            CompanyID = Convert.ToInt16(cmbComp.SelectedValue.ToString());


                        }
                        else
                        {
                            CompanyID = _CompId;
                            label1.Visible = false;

                        }

                        objUserBL.Update(_UserID, CompanyID, cmbComp.Text, txtUserName.Text, txtPassword.Text, txtName.Text, txtEmailId.Text, txtUserEmail.Text, txtCPassword.Text, txtNPassword.Text, cmbHost.Text, txtPort.Text, txtSSL.Text, Mail_ByUser, strPrivilegeList);
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
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtName.Text = "";
                trvUserPrivilieges.Nodes.Clear();
                txtUserName.Focus();
                trvUserPrivilieges.Nodes.Clear();
                FillPrivilegesList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void chksend_Leave(object sender, EventArgs e)
        {
            //if (chksend.Checked)
            //{
            //    CurrentCompany.Con_Email = txtUserEmail.Text;
            //    CurrentCompany.Con_Port = txtPort.Text;
            //    CurrentCompany.Con_SSL = txtSSL.Text;
            //    CurrentCompany.Con_Host = cmbHost.Text;
            //}
            //else
            //{
            //    CurrentCompany.Con_Email = txtEmailId.Text;
            //}
        }

        private void chksend_Click(object sender, EventArgs e)
        {
            //if (chksend.Checked)
            //{
            //    CurrentCompany.Con_Email = txtUserEmail.Text;
            //    CurrentCompany.Con_Password = txtNPassword.Text;
            //    CurrentCompany.Con_Port = txtPort.Text;
            //    CurrentCompany.Con_SSL = txtSSL.Text;
            //    CurrentCompany.Con_Host = cmbHost.Text;
              
            //}
            //else
            //{
            //    CurrentCompany.Con_Email = txtEmailId.Text;
            //    //CurrentCompany.Con_Port = CurrentCompany.Port.ToString();
            //    //CurrentCompany.Con_SSL = CurrentCompany.ssl.ToString();
            //    //CurrentCompany.Con_Host = CurrentCompany.Host;
            //}
        }

        private void trvUserPrivilieges_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (trvUserPrivilieges != null)
            {
                string PrePart = "";
                PrePart = e.Node.Tag.ToString().Substring(0, 2);
                if (e.Node.Tag.ToString().Substring(2, 2) == "01")
                {
                    for (int i = 0; i < trvUserPrivilieges.Nodes.Count; i++)
                    {
                        if (trvUserPrivilieges.Nodes[i].Checked == true)
                        {
                            for (int j = 0; j < trvUserPrivilieges.Nodes[i].Nodes.Count; j++)
                            {
                                if (trvUserPrivilieges.Nodes[i].Nodes[j].Tag.ToString().Substring(0, 2) == PrePart)
                                {
                                    trvUserPrivilieges.Nodes[i].Expand();
                                    trvUserPrivilieges.Nodes[i].Nodes[j].Checked = true;
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}


