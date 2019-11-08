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
using System.Net.Mail;
using System.IO;
using System.Diagnostics;


namespace Account.GUI.PromoMail
{
    public partial class frmPromoMailEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        DataTable dtDocList = new DataTable();
        PromoMailSendBL objPromoMailSendBL = new PromoMailSendBL();
        DataTable dtUser = new DataTable();
        DataSet dtUserN = new DataSet();
        int _Mode = 0;
        Int64 PromoMail_ID = 0;
        BusinessLogic.Common objCommon = new BusinessLogic.Common();
        string SelectedFileName = "";
        string PM = "";
        DataTable dtPromoSend = new DataTable();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        Exception mException = null;
        string mErrorMsg = "";
        int CompId = 0;

        #endregion

        #region "Form Event..."

        public frmPromoMailEntry(int Mode, Int64 Email_ID)
        {
            InitializeComponent();
            _Mode = Mode;
            PromoMail_ID = Email_ID;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dtDocList.Columns.Add("DocID");
            dtDocList.Columns.Add("FileName");
            dtDocList.Columns.Add("FullFileName");
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                txtPMID.Text = objCommon.AutoNumber("Promo");
                this.Text = "PromoMail - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                this.Text = "PromoMail - Edit";
                BindControl();
                dtPromoSend.Columns.Add("CustomerName");
                dtPromoSend.Columns.Add("Email");
                dtPromoSend.Columns.Add("Mobile");
                dtPromoSend.Columns.Add("Category");
                string[] EditPCustomerName = txtPCustomer.Text.Split(',');
                string[] EditPMail = txtPMail.Text.Split(',');
                string[] EditPMobile = txtPMobile.Text.Split(',');
                string[] EditPCategory = txtPCategory.Text.Split(',');
                for (int j = 0; j < EditPMail.Length; j++)
                {
                    dtPromoSend.Rows.Add(EditPCustomerName[j], EditPMail[j],EditPMobile[j],EditPCategory[j]);
                }
                dgvPromoSend.AutoGenerateColumns = false;
                dgvPromoSend.DataSource = dtPromoSend.DefaultView;
                ArrangePromo();
                btnSaveContinue.Visible = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                this.Text = "PromoMail - Delete";
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
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {

            dtUserN = CommSelect.SelectDataSetRecord(PromoMail_ID, "usp_PromoMail_Select", "PromoMail - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dtUserN.Tables[0].Rows.Count > 0)
                    {
                        DataTable _dtPromoSend = new DataTable();
                        txtSubject.CharacterCasing = CharacterCasing.Normal;
                        txtHeader.CharacterCasing = CharacterCasing.Normal;
                        txtFooter.CharacterCasing = CharacterCasing.Normal;
                        txtSubject.Text = dtUserN.Tables[0].Rows[0]["Subject"].ToString();
                        txtHeader.Text = dtUserN.Tables[0].Rows[0]["Header"].ToString();
                        txtFooter.Text = dtUserN.Tables[0].Rows[0]["Footer"].ToString();
                        txtPMail.Text = dtUserN.Tables[0].Rows[0]["Email"].ToString();
                        txtPCustomer.Text = dtUserN.Tables[0].Rows[0]["CustomerName"].ToString();
                        txtPMobile.Text = dtUserN.Tables[0].Rows[0]["Mobile"].ToString();
                        txtPCategory.Text = dtUserN.Tables[0].Rows[0]["Category"].ToString();

                        /* code for Docs open*/

                        if (dtUserN.Tables[1] != null && dtUserN.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow DRow in dtUserN.Tables[1].Rows)
                            {
                                DataRow dr = dtDocList.NewRow();
                                dr["DocID"] = DRow["DocID"].ToString();
                                dr["FileName"] = DRow["DocName"].ToString();
                                dr["FullFileName"] = DRow["DocName"].ToString();
                                // dr["DocRemark"] = DRow["Remarks"].ToString();
                                dtDocList.Rows.Add(dr);
                            }
                            ArrangeDocumentGridView();
                            dgvFile.AutoGenerateColumns = false;
                            dgvFile.DataSource = dtDocList;
                            ArrangeDocumentGridView();
                        }

                        //txtEditPMail.Text = txtPMail.Text;
                        //txtEditPCustomer.Text = txtPCustomer.Text;
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
        }

        public bool SetSave()
        {
            bool ReturnValue = false;
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(PromoMail_ID, "usp_PromoMail_Delete", "PromoMail - Delete");
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
                //if (DataValidator.IsValid(this.grpData))
                //{

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                   
                    objPromoMailSendBL.Insert(txtPCustomer.Text, txtPMail.Text, txtPCategory.Text, txtPMobile.Text, txtSubject.Text, txtHeader.Text, txtFooter.Text, txtFileCount.Text,CompId);

                    if (objPromoMailSendBL.Exception == null)
                    {
                        //if (objPromoMailSendBL.ErrorMessage != "")
                        if (objPromoMailSendBL.ErrorMessage != "")
                        {                    
                                                     
                            lblErrorMessage.Text = objPromoMailSendBL.ErrorMessage;
                            txtSubject.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
                            //-----for doc save--------

                            foreach (DataRow dr in dtDocList.Rows)
                            {
                                if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                                {
                                    objPromoMailSendBL.InsertPMDocument(Convert.ToInt32(txtPMID.Text), dr["FileName"].ToString());
                                }
                                else
                                {
                                    string newFileName = CurrentUser.DocumentPath + txtPMID.Text + "_" + dr["FileName"].ToString().Replace('/', '-');
                                    objPromoMailSendBL.InsertPMDocument(Convert.ToInt32(txtPMID.Text), txtPMID.Text + "_" + dr["FileName"].ToString().Replace('/', '-'));
                                    if (objPromoMailSendBL.Exception == null)
                                    {
                                        if (objPromoMailSendBL.ErrorMessage == "")
                                        {
                                            File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                        }
                                    }
                                }
                            }

                            //-------------------
                            SendToMail();
                            ReturnValue = true;
                            lblErrorMessage.Text = "No error";
                        }
                    }
                    else
                    {
                        MessageBox.Show(objPromoMailSendBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    
                    //txtPCustomer.Text = txtEditPCustomer.Text + "," + txtPCustomer.Text;
                    //txtPMail.Text = txtEditPMail.Text + "," + txtPMail.Text;

                    objPromoMailSendBL.Update(PromoMail_ID, txtPCustomer.Text, txtPMail.Text, txtPCategory.Text, txtPMobile.Text, txtSubject.Text, txtHeader.Text, txtFooter.Text, txtFileCount.Text,CompId);

                    if (objPromoMailSendBL.Exception == null)
                    {
                        if (objPromoMailSendBL.ErrorMessage != "")
                        {                           

                            lblErrorMessage.Text = objPromoMailSendBL.ErrorMessage;
                            txtSubject.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
                            //--for doc save code
                            foreach (DataRow dr in dtDocList.Rows)
                            {
                                if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                                {
                                    objPromoMailSendBL.InsertPMDocument(PromoMail_ID, dr["FileName"].ToString());
                                }
                                else
                                {
                                    string newFileName = CurrentUser.DocumentPath + PromoMail_ID + "_" + dr["FileName"].ToString().Replace('/', '-');
                                    objPromoMailSendBL.InsertPMDocument(PromoMail_ID, PromoMail_ID + "_" + dr["FileName"].ToString().Replace('/', '-'));
                                    if (objPromoMailSendBL.Exception == null)
                                    {
                                        if (objPromoMailSendBL.ErrorMessage == "")
                                        {
                                            //Move File                                    
                                            File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                        }
                                    }
                                }
                            }
                            //---------------
                            SendToMail();

                            ReturnValue = true;
                            lblErrorMessage.Text = "No error";
                        }
                    }
                    else
                    {
                        MessageBox.Show(objPromoMailSendBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }

                //if (objPromoMailSendBL.Exception == null)
                //{
                //    if (objPromoMailSendBL.ErrorMessage != "")
                //    {
                //        //-----for doc save--------

                //        foreach (DataRow dr in dtDocList.Rows)
                //        {
                //            if (Convert.ToInt64(dr["DocID"].ToString()) > 0)
                //            {
                //                objPromoMailSendBL.InsertPMDocument(PromoMail_ID, dr["FileName"].ToString());
                //            }
                //            else
                //            {
                //                string newFileName = CurrentUser.DocumentPath + PromoMail_ID + "_" + dr["FileName"].ToString().Replace('/', '-');
                //                objPromoMailSendBL.InsertPMDocument(PromoMail_ID, PromoMail_ID + "_" + dr["FileName"].ToString().Replace('/', '-'));
                //                if (objPromoMailSendBL.Exception == null)
                //                {
                //                    if (objPromoMailSendBL.ErrorMessage == "")
                //                    {
                //                        File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                //                    }
                //                }
                //            }
                //        }

                //        //-------------------


                //        lblErrorMessage.Text = objPromoMailSendBL.ErrorMessage;
                //        txtSubject.Focus();
                //        ReturnValue = false;
                //    }
                //    else
                //    {
                //        ReturnValue = true;
                //        lblErrorMessage.Text = "No error";
                //    }
                //}
                //else
                //{
                //    MessageBox.Show(objPromoMailSendBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    ReturnValue = false;
                //}

                //}
            }
            return ReturnValue;
        }

        #endregion

        #region "Button Event..."

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            int i;
            string FileCount = "";
            for (i = 0; i < dgvFile.Rows.Count; i++)
            {
                if (FileCount.Trim() != "")
                {
                    FileCount = FileCount + ",";
                }
                FileCount = FileCount + dtDocList.Rows[i]["FileName"].ToString();
            }
            txtFileCount.Text = FileCount;

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
                //cmbType.SelectedIndex = 0;
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

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddRec_Click(object sender, EventArgs e)
        {
            int Count = 0;
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                if (txtPMail.Text.Trim() != "")
                {
                    Count = 1;
                }
            }
            //    dtPromoSend.Columns.Add(DataGridViewCheckBoxColumn);
            //    dtPromoSend.Columns.Add("CustomerName");
            //    dtPromoSend.Columns.Add("Email");
            //    string[] EditPCustomerName = txtPCustomer.Text.Split(',');
            //    string[] EditPMail = txtPMail.Text.Split(',');
            //    for (int j = 0; j < EditPMail.Length; j++)
            //    {
            //        dtPromoSend.Rows.Add(EditPCustomerName[j], EditPMail[j]);
            //    }
            //}
            frmPromoMailSend fPM = new frmPromoMailSend(dtPromoSend, Count);
            fPM.Text = "List Of Customer for Promotional Mail";
            fPM.ShowDialog();
            txtPMail.Text = "";
            txtPCustomer.Text = "";
            txtPMail.Text = fPM.PMail;
            txtPCustomer.Text = fPM.PCustomerName;
            txtPMobile.Text = fPM.PMobile;
            txtPCategory.Text = fPM.PCategory;

            dgvPromoSend.AutoGenerateColumns = false;
            dgvPromoSend.DataSource = dtPromoSend.DefaultView;
            ArrangePromo();




        }


        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            //if (txtDocName.Text == "")
            //{
            //    txtDocName.Focus();
            //    return;
            //}
            //DataRow dr = dtDocList.NewRow();
            //dr["FileName"] = txtDocName.Text;
            //dr["FullFileName"] = SelectedFileName;

            //dtDocList.Rows.Add(dr);

            //ArrangeDocumentGridView();
            //dgvFile.AutoGenerateColumns = false;
            //dgvFile.DataSource = dtDocList;
            //ArrangeDocumentGridView();

            //txtDocName.Text = "";
            //SelectedFileName = "";

            //btnAddDoc.Focus();
            //----------------------

            if (txtDocName.Text == "")
            {
                txtDocName.Focus();
                return;
            }
            DataRow dr = dtDocList.NewRow();
            dr["DocID"] = "0";
            //dr["BlockID"] = "0";
            dr["FileName"] = txtDocName.Text;
            dr["FullFileName"] = SelectedFileName;
            //dr["DocRemark"] = txtComment.Text;
            dtDocList.Rows.Add(dr);

            ArrangeDocumentGridView();
            dgvFile.AutoGenerateColumns = false;
            dgvFile.DataSource = dtDocList;
            ArrangeDocumentGridView();
            txtDocName.Text = "";
            SelectedFileName = "";
            //txtComment.Text = "";
            btnAddDoc.Focus();
        }

        public void ArrangeDocumentGridView()
        {
            dgvFile.Columns["DocID"].DataPropertyName = dtDocList.Columns["DocID"].ToString();
            dgvFile.Columns["FileName"].DataPropertyName = dtDocList.Columns["FileName"].ToString();
            dgvFile.Columns["FullFileName"].DataPropertyName = dtDocList.Columns["FullFileName"].ToString();
        }

        public void ArrangePromo()
        {
            dgvPromoSend.Columns["CustomerName"].DataPropertyName = dtPromoSend.Columns["CustomerName"].ToString();
            dgvPromoSend.Columns["Email"].DataPropertyName = dtPromoSend.Columns["Email"].ToString();

            dgvPromoSend.Columns["Mobile"].DataPropertyName = dtPromoSend.Columns["Mobile"].ToString();
            dgvPromoSend.Columns["Category"].DataPropertyName = dtPromoSend.Columns["Category"].ToString();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtDocName.Text = ofd.SafeFileName;
                SelectedFileName = ofd.FileName;
            }
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (dgvFile.CurrentRow != null)
            {
                int RowIndex = dgvFile.CurrentRow.Index;
                dtDocList.Rows[RowIndex].Delete();
                dtDocList.AcceptChanges();

                dgvFile.AutoGenerateColumns = false;
                dgvFile.DataSource = dtDocList;
                ArrangeDocumentGridView();
            }
        }

        public void SendToMail()
        {
            try
            {
                //-----------------for substring after , for multiple mail-------------
                string source = txtPMail.Text.ToLower();
                string[] stringSeparators = new string[] { "," };
                string[] result;

                // ...
                result = source.Split(stringSeparators, StringSplitOptions.None);
                string EmailID = result[0].ToString();
                string BCC = "";
                string s = "";

                //for (int i = 0; i < result.Length; i++)
                //{
                //    s += result[i] + ",";
                //}
                //BCC = s.ToString().TrimEnd(',');

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                vMailTo = ((txtPMail.Text.ToLower() == "") ? CurrentCompany.Con_Email : EmailID.ToLower());
                //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                vSubject = txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                vDetails = txtHeader.Text.Replace("\n", "<br />"); // HEADER PART OF BODY

                vDetails += "<br /><br />";
                vDetails += "<p>" + txtFooter.Text.Replace("\n", "<br />") + "</p>"; // FOOTER PART OF BODY
                vDetails += "<br><br>";

                for (int i = 1; i < result.Length; i++)
                {
                    s += result[i] + ",";
                }
                BCC = s.ToString().TrimEnd(',');
                //---------------------------------------------------------------------------


                if (BCC != "")
                {
                    vMail.Bcc.Add(BCC);
                }

                vMail.Subject = vSubject;
                vMail.Body = vDetails;
                //vMail.Attachments.Add(new Attachment(dtDocList.Columns["FileName"].ToString()));
                if (dtDocList.Rows.Count > 0)
                {
                    foreach (DataRow dtr in dtDocList.Rows)
                    {
                        vMail.Attachments.Add(new Attachment(dtr["FullFileName"].ToString()));
                    }
                }
                vMail.IsBodyHtml = true;


                System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
                System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(CurrentCompany.Con_Email, CurrentCompany.Con_Password);

                vSmpt.Host = CurrentCompany.Host;
                vSmpt.Port = CurrentCompany.Port;
                vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                //vSmpt.UseDefaultCredentials = false;
                if (CurrentCompany.ssl == 0)
                {
                    vSmpt.EnableSsl = true;
                }
                else if (CurrentCompany.ssl == 1)
                {
                    vSmpt.EnableSsl = false;
                }

                vSmpt.Credentials = SmtpUser;
                vSmpt.Send(vMail);
                vMail.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
            }

        }

        private void dgvFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 0)
                {
                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        MessageBox.Show("Please save record and then you can edit document in Edit Sale record.");
                        return;
                    }
                    string strFile;
                    strFile = CurrentUser.DocumentPath + dgvFile.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();

                    Process.Start(strFile);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }      
    }
}


