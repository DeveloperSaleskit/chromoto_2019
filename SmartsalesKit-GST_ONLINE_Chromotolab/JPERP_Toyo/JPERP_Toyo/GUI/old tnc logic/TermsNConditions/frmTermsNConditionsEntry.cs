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
using System.Collections.Specialized;

namespace Account.GUI.TermsNConditions
{
    public partial class frmTermsNConditionsEntry : Account.GUIBase
    {              
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        TNCBL objUserBL = new TNCBL();
        DataTable dtUser = new DataTable();
        int _Mode = 0;
        string _TNC_Sub = "";
        BusinessLogic.Common objCommon = new BusinessLogic.Common();

        #endregion

        #region "Form Event..."

        public frmTermsNConditionsEntry(int Mode, string TNC_Sub)
        {
            InitializeComponent();
            _Mode = Mode;
            _TNC_Sub = TNC_Sub;
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
                this.Text = "Terms and Conditions - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "Terms and Conditions - Edit";
                BindControl();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "Terms and Conditions - Delete";
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
            dgvDescriptions.AllowUserToAddRows = true;
            dgvDescriptions.AllowUserToDeleteRows = true;
            dgvDescriptions.Columns["TNC_Desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDescriptions.ReadOnly = false;

        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_TNC_Sub", _TNC_Sub);
            dtUser = objList.ListOfRecord("usp_TNC_Select", para, "Terms And Conditions - Select");

            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUser.Rows.Count > 0)
                    {
                        txtSubject.Text = dtUser.Rows[0]["TNC_Sub"].ToString();
                        if (dgvDescriptions.Rows.Count > 0)
                        {
                            dgvDescriptions.Rows.Clear();
                        }
                        int p = 0;
                        int q = 0;
                        for (p = 0; p < dtUser.Rows.Count; p++)
                        {
                            dgvDescriptions.Rows.Add();
                            dgvDescriptions.Rows[q].Cells[0].Value = dtUser.Rows[p][2].ToString();
                            q += 1;
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


        //public bool SetSave()
        //{
        //    bool ReturnValue = false;
        //    if (_Mode == (int)Common.Constant.Mode.Delete)
        //    {
        //        CommDelRec.DeleteRecord(_TNCID, "usp_TNC_Delete", "TNC - Delete");
        //        if (CommDelRec.Exception == null)
        //        {
        //            if (CommDelRec.ErrorMessage != "")
        //            {
        //                lblErrorMessage.Text = CommDelRec.ErrorMessage;
        //                ReturnValue = false;
        //            }
        //            else
        //            {
        //                ReturnValue = true;
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            ReturnValue = false;
        //        }
        //    }
        //    else
        //    {
        //        if (DataValidator.IsValid(this.grpData))
        //        {

        //            if (_Mode == (int)Common.Constant.Mode.Insert)
        //            {

        //            }
        //            else if (_Mode == (int)Common.Constant.Mode.Modify)
        //            {
        //               // objUserBL.Update(_TNCID, txtSubject.Text, txtDesc.Text);
        //            }

        //            if (objUserBL.Exception == null)
        //            {
        //                if (objUserBL.ErrorMessage != "")
        //                {
        //                    lblErrorMessage.Text = objUserBL.ErrorMessage;
        //                    txtSubject.Focus();
        //                    ReturnValue = false;
        //                }
        //                else
        //                {
        //                    ReturnValue = true;
        //                    lblErrorMessage.Text = "No error";
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show(objUserBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                ReturnValue = false;
        //            }

        //        }
        //    }
        //    return ReturnValue;
        //}




        #endregion

        #region "Button Event..."

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            dgvDescriptions.EndEdit();

            for (int i = 0; i < dgvDescriptions.RowCount; i++)
            {
                if (dgvDescriptions.Rows[i].IsNewRow == false)
                {
                    if (dgvDescriptions.Rows[i].Cells["TNC_Desc"].Value.ToString() == "")
                    {
                        lblErrorMessage.Text = "Enter Descriptions";
                        dgvDescriptions.CurrentCell = dgvDescriptions.Rows[i].Cells["TNC_Desc"];
                        dgvDescriptions.BeginEdit(true);
                        return;
                    }
                }
            }

            //Prepare XMLString
            int Cnt = 0;
            string XMLString = string.Empty;
            XMLString = "<NewDataSet>";
            for (int i = 0; i < dgvDescriptions.Rows.Count; i++)
            {
                if (dgvDescriptions.Rows[i].IsNewRow == false)
                {
                    XMLString = XMLString + "<Table>";
                    XMLString = XMLString + "<TNC_Desc>" + dgvDescriptions.Rows[i].Cells["TNC_Desc"].Value + "</TNC_Desc>";
                    XMLString = XMLString + "</Table> ";
                    Cnt = Cnt + 1;
                }
            }

            XMLString = XMLString.ToString().Replace("&", "&amp;") + "</NewDataSet>";
            //XMLString = XMLString.ToString().Replace("<", "&lt;") + "</NewDataSet>";
            //XMLString = XMLString.ToString().Replace(">", "&gt;") + "</NewDataSet>";
           // XMLString1 = XMLString1.ToString().Replace("&", "&amp;") + "</NewDataSet>";

           // MinifyB(XMLString);


            objUserBL.Insert(txtSubject.Text, XMLString, Cnt);

            if (objUserBL.Exception == null)
            {
                if (objUserBL.ErrorMessage != "")
                {
                    lblErrorMessage.Text = objUserBL.ErrorMessage;
                    dgvDescriptions.Focus();
                    return;
                }
                else
                {
                    lblErrorMessage.Text = "No error";
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show(objUserBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        //static string MinifyB(string p)
        //{
        //    StringBuilder b = new StringBuilder(p);
        //    //b.Replace("  ", string.Empty);
        //    //b.Replace(Environment.NewLine, string.Empty);
        //    //b.Replace("\\t", string.Empty);
        //    //b.Replace(" {", "{");
        //    //b.Replace(" :", ":");
        //    //b.Replace(": ", ":");
        //    b.Replace("&", "&amp;");
        //    b.Replace("<", "&lt;");
        //    b.Replace(">", "&gt;");
        //    return b.ToString();
        //}


        //private void btnSaveContinue_Click(object sender, EventArgs e)
        //{
        //    if (SetSave())
        //    {
        //        txtSubject.Text = "";

        //        txtSubject.Focus();
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion




    }
}


