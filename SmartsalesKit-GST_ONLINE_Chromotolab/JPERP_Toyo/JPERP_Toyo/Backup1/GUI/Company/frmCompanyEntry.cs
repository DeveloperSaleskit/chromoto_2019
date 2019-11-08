using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.IO;
using System.Text.RegularExpressions;

namespace Account.GUI.Company
{
    public partial class frmCompanyEntry : Account.GUIBase
    {

        //
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        string SelectedFileName = "";
        string strFile = "";
        string _Company_Entry = "";
        CompanyInfoBL objCompanyInfoBL = new CompanyInfoBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        Int64 _CompId = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmCompanyEntry(int Mode, long CompId)
        {
            InitializeComponent();
            _Mode = Mode;
            _CompId = CompId;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            txtEmail.CharacterCasing = CharacterCasing.Normal;
            txtCom_Profile.CharacterCasing = CharacterCasing.Normal;
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "Company Entry - Update";
                BindControl();

            }

        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CompId", _CompId.ToString());
            dtUser = objList.ListOfRecord("usp_CompanyInfoDetail_Select", para, "CompanyInfo - Select");

            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtCompanyName.Text = dtUser.Rows[0]["CompanyName"].ToString();
                        txtBussinessLine.Text = dtUser.Rows[0]["BusinessLine"].ToString(); 
                        txtAddress1.Text = dtUser.Rows[0]["Address1"].ToString();
                        txtAddress2.Text = dtUser.Rows[0]["Address2"].ToString();
                        txtState.Text = dtUser.Rows[0]["State"].ToString();
                        txtCity.Text =dtUser.Rows[0]["CityName"].ToString();
                        txtPincode.Text = dtUser.Rows[0]["Pincode"].ToString();
                        txtEmail.Text = dtUser.Rows[0]["Email"].ToString();
                        txtPhone1.Text = dtUser.Rows[0]["Phone1"].ToString();
                        txtPhone2.Text = dtUser.Rows[0]["Phone2"].ToString();
                        txtMobile.Text = dtUser.Rows[0]["Mobile"].ToString();
                        txtLogo.Text = dtUser.Rows[0]["Logo"].ToString();
                        txtHeader.Text =dtUser.Rows[0]["Header"].ToString();                        
                        txtFooter.Text =dtUser.Rows[0]["Footer"].ToString();
                        txtSign.Text = dtUser.Rows[0]["Sign"].ToString();
                        txtName1.Text = dtUser.Rows[0]["Name1"].ToString();
                        txtName2.Text = dtUser.Rows[0]["Name2"].ToString();
                        txtName3.Text = dtUser.Rows[0]["Name3"].ToString();
                        txtName4.Text = dtUser.Rows[0]["Name4"].ToString();
                        txtName5.Text = dtUser.Rows[0]["Name5"].ToString();
                        txtName6.Text = dtUser.Rows[0]["Name6"].ToString();
                        txtValue1.Text = dtUser.Rows[0]["Value1"].ToString();
                        txtValue2.Text = dtUser.Rows[0]["Value2"].ToString();
                        txtValue3.Text = dtUser.Rows[0]["Value3"].ToString();
                        txtValue4.Text = dtUser.Rows[0]["Value4"].ToString();
                        txtValue5.Text = dtUser.Rows[0]["Value5"].ToString();
                        txtValue6.Text = dtUser.Rows[0]["Value6"].ToString();
                        txtRPath.Text = dtUser.Rows[0]["ReportPath"].ToString();
                        txtDPath.Text = dtUser.Rows[0]["DocPath"].ToString();
                        

                        txtCom_Profile.Text = dtUser.Rows[0]["Com_Profile"].ToString();
                        //txtRPath.Text = CurrentUser.ReportPath;
                        //txtDPath.Text = CurrentUser.DocumentPath;
                        txtEmail.CharacterCasing = CharacterCasing.Normal;
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
            //if (CurrentCompany.Con_Password != txtBussinessLine.Text)
            //{
            //    MessageBox.Show("You have Entered Wrong Current Password.");

            //}
            //else
            //{
           
           
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                objCompanyInfoBL.Insert_CompanyInfo_Detail(txtCompanyName.Text, txtBussinessLine.Text, txtAddress1.Text, txtAddress2.Text, txtState.Text, txtCity.Text, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtMobile.Text, txtEmail.Text,txtLogo.Text, txtHeader.Text, txtFooter.Text, txtSign.Text, txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text, txtCom_Profile.Text, txtRPath.Text, txtDPath.Text);
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
                        //CurrentCompany.CompanyName = txtCompanyName.Text;
                        //CurrentCompany.BusinessLine = txtBussinessLine.Text;
                        //CurrentCompany.Address1 = txtAddress1.Text;
                        //CurrentCompany.Address2 = txtAddress2.Text;
                        //CurrentCompany.State = txtState.Text;
                        //CurrentCompany.City = txtCity.Text;
                        //CurrentCompany.Pincode = txtPincode.Text;
                        //CurrentCompany.Email = txtEmail.Text;
                        //CurrentCompany.Phone1 = txtPhone1.Text;
                        //CurrentCompany.Phone2 = txtPhone2.Text;
                        //CurrentCompany.Mobile = txtMobile.Text;
                        //CurrentCompany.Logo = txtLogo.Text;
                        //CurrentCompany.Header = txtHeader.Text;
                        //CurrentCompany.Footer = txtFooter.Text;
                        //CurrentCompany.Name1 = txtName1.Text;
                        //CurrentCompany.Name2 = txtName2.Text;
                        //CurrentCompany.Name3 = txtName3.Text;
                        //CurrentCompany.Name4 = txtName4.Text;
                        //CurrentCompany.Name5 = txtName5.Text;
                        //CurrentCompany.Name6 = txtName6.Text;
                        //CurrentCompany.Value1 = txtValue1.Text;
                        //CurrentCompany.Value2 = txtValue2.Text;
                        //CurrentCompany.Value3 = txtValue3.Text;
                        //CurrentCompany.Value4 = txtValue4.Text;
                        //CurrentCompany.Value5 = txtValue5.Text;
                        //CurrentCompany.Value6 = txtValue6.Text;
                        //CurrentCompany.Com_Profile = txtCom_Profile.Text;
                        //CurrentUser.ReportPath = txtRPath.Text;
                        //CurrentUser.DocumentPath = txtDPath.Text;
                    }
                }
                else
                {
                    MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
                }
            
            }

            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                objCompanyInfoBL.Update_CompanyInfo_Detail(_CompId, txtCompanyName.Text, txtBussinessLine.Text, txtAddress1.Text, txtAddress2.Text, txtState.Text, txtCity.Text, txtPincode.Text, txtPhone1.Text, txtPhone2.Text, txtMobile.Text, txtEmail.Text, txtLogo.Text, txtHeader.Text, txtFooter.Text, txtSign.Text, txtName1.Text, txtName2.Text, txtName3.Text, txtName4.Text, txtName5.Text, txtName6.Text, txtValue1.Text, txtValue2.Text, txtValue3.Text, txtValue4.Text, txtValue5.Text, txtValue6.Text, txtCom_Profile.Text, txtRPath.Text, txtDPath.Text);

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
                    //    CurrentCompany.CompanyName = txtCompanyName.Text;
                    //    CurrentCompany.BusinessLine = txtBussinessLine.Text;
                    //    CurrentCompany.Address1 = txtAddress1.Text;
                    //    CurrentCompany.Address2 = txtAddress2.Text;
                    //    CurrentCompany.State = txtState.Text;
                    //    CurrentCompany.City = txtCity.Text;
                    //    CurrentCompany.Pincode = txtPincode.Text;
                    //    CurrentCompany.Email = txtEmail.Text;
                    //    CurrentCompany.Phone1 = txtPhone1.Text;
                    //    CurrentCompany.Phone2 = txtPhone2.Text;
                    //    CurrentCompany.Mobile = txtMobile.Text;
                    //    CurrentCompany.Logo = txtLogo.Text;
                    //    CurrentCompany.Header = txtHeader.Text;
                    //    CurrentCompany.Footer = txtFooter.Text;
                    //    CurrentCompany.Name1 = txtName1.Text;
                    //    CurrentCompany.Name2 = txtName2.Text;
                    //    CurrentCompany.Name3 = txtName3.Text;
                    //    CurrentCompany.Name4 = txtName4.Text;
                    //    CurrentCompany.Name5 = txtName5.Text;
                    //    CurrentCompany.Name6 = txtName6.Text;
                    //    CurrentCompany.Value1 = txtValue1.Text;
                    //    CurrentCompany.Value2 = txtValue2.Text;
                    //    CurrentCompany.Value3 = txtValue3.Text;
                    //    CurrentCompany.Value4 = txtValue4.Text;
                    //    CurrentCompany.Value5 = txtValue5.Text;
                    //    CurrentCompany.Value6 = txtValue6.Text;
                    //    CurrentCompany.Com_Profile = txtCom_Profile.Text;
                    //    CurrentUser.ReportPath = txtRPath.Text;
                    //    CurrentUser.DocumentPath = txtDPath.Text;
                    }
                }
                else
                {
                    MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReturnValue = false;
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

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                strFile = ofd.FileName;
                string ex = strFile.Substring(strFile.Length - 4, 4).ToLower();
                if (ex == ".jpg" || ex == ".png")
                {
                    txtLogo.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Only .jpg or .png type of files are allowded");
                }
            }
        }

        private void btnBrowseHeader_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                strFile = ofd.FileName;
                string ex = strFile.Substring(strFile.Length - 4, 4).ToLower();
                if (ex == ".jpg" || ex == ".png")
                {
                    txtHeader.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Only .jpg or .png type of files are allowded");
                }
            }

        }

        private void btnBrowseFooter_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                strFile = ofd.FileName;
                string ex = strFile.Substring(strFile.Length - 4, 4).ToLower();
                if (ex == ".jpg" || ex == ".png")
                {
                    txtFooter.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Only .jpg or .png type of files are allowded");
                }
            }
        }

        #endregion

        private void btnBrowseRPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            string[] files = Directory.GetFiles(fbd.SelectedPath);
            txtRPath.Text = fbd.SelectedPath.ToString() + "\\";
        }

        private void btnBrowseDPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            string[] files = Directory.GetFiles(fbd.SelectedPath);
            txtDPath.Text = fbd.SelectedPath.ToString() + "\\";


        }

        private void grpData_Enter(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblValue_Click(object sender, EventArgs e)
        {

        }

        private void txtName1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValue1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValue2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtValue3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void txtPhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhone1_KeyPress(sender, e);
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhone1_KeyPress(sender, e);
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPhone1_KeyPress(sender, e);
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            if (txtMobile.Text.Length < 10)
            {
                MessageBox.Show("Please enter the correct Mobile number","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtMobile.Focus();
            }
            if (txtMobile.Text.Length > 10)
            {
                MessageBox.Show("Please enter the correct Mobile number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobile.Focus();
            }
        }

        private void lblrequired_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

            if (txtEmail.Text != "")
            {
                string pattern = null;
                pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    //MessageBox.Show("Valid Email address ");
                }
                else
                {
                    MessageBox.Show("Not a valid Email address ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
            }

        }

        private void btnBrowseSign_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                strFile = ofd.FileName;
                string ex = strFile.Substring(strFile.Length - 4, 4).ToLower();
                if (ex == ".jpg" || ex == ".png")
                {
                    txtSign.Text = ofd.FileName;
                }
                else
                {
                    MessageBox.Show("Only .jpg or .png type of files are allowded");
                }
            }
        }

        
    }
}



