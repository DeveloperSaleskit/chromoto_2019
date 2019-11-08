using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using Account.Validator;
using Account.Properties;
using System.Net.Mail;
using System.Configuration;

namespace Account.DefaultLayout
{
    public partial class frmLead : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        #region "Variable Declaration...."

        DataTable dtblPI = new DataTable();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataView DV;
        int _CompId = 0;
        private Font NormalFont = new Font("Verdana", 8, FontStyle.Regular);
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        #endregion

        #region "Form Event..."

        public frmLead()
        {
            InitializeComponent();
        }

        private void frmLead_Load(object sender, EventArgs e)
        {
            DataGridView t = ((DataGridView)dgvInvoice);
            t.ForeColor = Color.Black;
            t.BackgroundColor = Color.White;
            t.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            t.StandardTab = true;
            t.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            t.AllowUserToAddRows = false;
            t.AllowUserToDeleteRows = false;
            t.MultiSelect = false;
            t.ReadOnly = true;
            t.RowHeadersWidth = 25;
            t.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            t.ColumnHeadersDefaultCellStyle.Font = NormalFont;
            t.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 244, 244);
            t.RowsDefaultCellStyle.Font = NormalFont;
            t.RowsDefaultCellStyle.BackColor = Color.FromArgb(253, 253, 253);
            t.ColumnHeadersDefaultCellStyle.Font = NormalFont;
            t.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            t.RowsDefaultCellStyle.Font = NormalFont;
            t.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            t.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 225);

            //btnRefresh.BackgroundImage = Resources.stufftheme4;
            //btnRefresh.Text = "";
            //btnRefresh.Width = 26;
            //btnRefresh.Height = 30;

            // btnRefresh.FlatStyle = FlatStyle.Popup;

            btnRefresh.ForeColor = Color.Black;
            btnEdit.ForeColor = Color.Black;
            btnfollowup.ForeColor = Color.Black;
            btnrevisedquotation.ForeColor = Color.Black;
            btnSendMail.ForeColor = Color.Black;


            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#5054#") != -1)
                    { btnfollowup.Enabled = true; }
                    else { btnfollowup.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#5055#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#5056#") != -1)
                    { btnrevisedquotation.Enabled = true; }
                    else { btnrevisedquotation.Enabled = false; }

                    if (CurrentUser.PrivilegeStr.IndexOf("#5057#") != -1)
                    { btnSendMail.Enabled = true; }
                    else { btnSendMail.Enabled = false; }

                }
            }



            LoadList();
            //if (CurrentCompany.AutoMailPayQuo == "Mail")
            //{
            //    mail();
            //}
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para1.Add("@i_UserId", CurrentUser.UserID.ToString());

                dtblPI = objList.ListOfRecord("usp_Reminder_List", para1, "Invoice - LoadList");
                if (dtblPI != null)
                {
                    if (objList.Exception == null)
                    {
                        ArrangeDataGridView();
                        dgvInvoice.AutoGenerateColumns = false;
                        dgvInvoice.DataSource = dtblPI;
                        ArrangeDataGridView();
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Invoice-LoadList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvInvoice.Columns["InvoiceID"].DataPropertyName = dtblPI.Columns["InvoiceID"].ToString();
                dgvInvoice.Columns["Type"].DataPropertyName = dtblPI.Columns["Type"].ToString();
                dgvInvoice.Columns["Code"].DataPropertyName = dtblPI.Columns["Code"].ToString();
                dgvInvoice.Columns["Date"].DataPropertyName = dtblPI.Columns["Date"].ToString();
                dgvInvoice.Columns["Party"].DataPropertyName = dtblPI.Columns["Party"].ToString();
                dgvInvoice.Columns["CONTACTPERSON"].DataPropertyName = dtblPI.Columns["CONTACTPERSON"].ToString();
                dgvInvoice.Columns["PHONE1"].DataPropertyName = dtblPI.Columns["PHONE1"].ToString();
                dgvInvoice.Columns["LEADDATE"].DataPropertyName = dtblPI.Columns["LEADDATE"].ToString();
                dgvInvoice.Columns["REMARKS"].DataPropertyName = dtblPI.Columns["REMARKS"].ToString();
                dgvInvoice.Columns["EMAIL"].DataPropertyName = dtblPI.Columns["EMAIL"].ToString();
                dgvInvoice.Columns["AMOUNT"].DataPropertyName = dtblPI.Columns["AMOUNT"].ToString();
                dgvInvoice.Columns["ALLOCATEDTO"].DataPropertyName = dtblPI.Columns["ALLOCATEDTO"].ToString();
                //dgvInvoice.Columns["DueDays"].DataPropertyName = dtblPI.Columns["DueDays"].ToString();
                //dgvInvoice.Columns["DueDate"].DataPropertyName = dtblPI.Columns["DueDate"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Invoice-ArrangeGrid", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        protected void mail()
        {
            if (dgvInvoice.Rows.Count > 0)
            {
                for (int i = 0; i < dgvInvoice.Rows.Count; i++)
                {
                    if (dgvInvoice.Rows[i].Cells["TYPE"].Value.ToString().Trim() != "Quotation" && dgvInvoice.Rows[i].Cells["TYPE"].Value.ToString().Trim() != "SERVICE" && dgvInvoice.Rows[i].Cells["TYPE"].Value.ToString().Trim() != "WARRANTY" && dgvInvoice.Rows[i].Cells["TYPE"].Value.ToString().Trim() != "Customer Followup")
                    {
                        if (dgvInvoice.Rows[i].Cells["DATE"].Value != DBNull.Value)
                        {
                            if (Convert.ToDateTime(dgvInvoice.Rows[i].Cells["DATE"].Value) == System.DateTime.Today)
                            {
                                SendToMail(dgvInvoice.Rows[i].Cells["EMAIL"].Value.ToString(), "0.00", dgvInvoice.Rows[i].Cells["INVOICEID"].Value.ToString());
                            }
                        }
                    }
                }
            }
        }

        public void SendToMail(string EmailID, string PendingAmt, string SalesID)
        {
            try
            {

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                vMailTo = ((EmailID.ToLower() == "") ? CurrentCompany.Con_Email : EmailID.ToLower());
                System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Reminder");
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");



                vSubject = dtEmail.Rows[0]["Subject"].ToString(); // SUBJECT LINE

                vDetails = dtEmail.Rows[0]["Header"].ToString();
                vDetails += "<br /><br />";
                vDetails += dtEmail.Rows[0]["Footer"].ToString();
                vDetails += "<br><br>";


                vMail.Subject = vSubject;
                vMail.Body = vDetails;

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

        #endregion

        #region "GridView Event"

        private void dgvInvoice_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvInvoice, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Invoice Lead", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadList();
        }


        private void SetSortedColumns()
        {
            try
            {
                if (dgvInvoice.SortedColumn != null)
                {
                    sortedColumn = dgvInvoice.SortedColumn;
                    sortDirection = dgvInvoice.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }



        private void btnfollowup_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.CurrentRow != null)
                {
                    SetSortedColumns();
                    string CustName = dgvInvoice.CurrentRow.Cells["Party"].Value.ToString();
                    string LeadDate = Convert.ToDateTime(dgvInvoice.CurrentRow.Cells["LEADDATE"].Value.ToString()).ToShortDateString();
                    string folloupDate;
                    if (dgvInvoice.CurrentRow.Cells["Date"].Value == null)
                    {
                        folloupDate = "";
                    }
                    else
                    {
                        folloupDate = Convert.ToDateTime(dgvInvoice.CurrentRow.Cells["Date"].Value.ToString()).ToShortDateString();
                    }


                    Account.GUI.Quotation.frmQuotationFollowup fCustomer = new Account.GUI.Quotation.frmQuotationFollowup((Int64)dgvInvoice.CurrentRow.Cells["INVOICEID"].Value, dgvInvoice.CurrentRow.Cells["CODE"].Value.ToString(), LeadDate, CustName, folloupDate);
                    fCustomer.ShowInTaskbar = false;
                    fCustomer.ShowDialog();
                    //setDefaultGridRecords(sender, e);
                    //LoadFollowUpList();

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.CurrentRow != null)
                {
                    if (dgvInvoice.CurrentRow.Cells["TYPE"].Value.ToString() == "Quotation")
                    {
                        SetSortedColumns();
                        Account.GUI.Quotation.frmQuotationNew fSalesNew = new Account.GUI.Quotation.frmQuotationNew((int)Constant.Mode.Modify, Convert.ToInt64(dgvInvoice.CurrentRow.Cells["INVOICEID"].Value));
                        // frmQuotationNew fSalesNew = new frmQuotationNew((int)Constant.Mode.Modify, Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value));
                        fSalesNew.ShowInTaskbar = false;
                        fSalesNew.ShowDialog();
                        //setDefaultGridRecords(sender, e);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnrevisedquotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.CurrentRow != null)
                {
                    if (dgvInvoice.CurrentRow.Cells["TYPE"].Value.ToString() == "Quotation")
                    {
                        SetSortedColumns();
                        Account.GUI.Quotation.frmQuotationNew fSalesNew = new Account.GUI.Quotation.frmQuotationNew((int)Constant.Mode.View, Convert.ToInt64(dgvInvoice.CurrentRow.Cells["INVOICEID"].Value));
                        // frmQuotationNew fSalesNew = new frmQuotationNew((int)Constant.Mode.Modify, Convert.ToInt64(dgvSaleList.CurrentRow.Cells["QuotationID"].Value));
                        fSalesNew.ShowInTaskbar = false;
                        fSalesNew.ShowDialog();
                        //setDefaultGridRecords(sender, e);
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.DataSource != null)
            {
                if (dgvInvoice.Rows.Count > 0)
                {
                    if ((MessageBox.Show(("Do you want to send Autogenerated Mail for AMC reminders ?" + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
                    {
                        //if (CurrentCompany.AutoMailPayQuo == "Mail")
                        //{
                        mail();
                        //}
                    }
                }
            }
        }
    }
}
