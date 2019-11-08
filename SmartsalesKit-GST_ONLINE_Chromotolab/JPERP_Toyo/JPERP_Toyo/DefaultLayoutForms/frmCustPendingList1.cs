using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using Account.Validator;
using Account.Properties;
using System.Net.Mail;

namespace Account.DefaultLayout
{
    public partial class frmCustPendingList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region "Variable Declaration...."

        DataTable dtblCustomer = new DataTable();
        private Font NormalFont = new Font("Verdana", 8, FontStyle.Regular);
        CommonListBL objList = new CommonListBL();

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                dtblCustomer = objList.ListOfRecord("usp_Customer_ReceiptPendingList", null, "Customer - ReceiptPendingList");
                if (objList.Exception == null)
                {
                    ArrangeDataGridView();
                    dgvContacts.AutoGenerateColumns = false;
                    dgvContacts.DataSource = dtblCustomer;
                    ArrangeDataGridView();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts - LoadList", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvContacts.Columns[0].DataPropertyName = dtblCustomer.Columns["CustomerCode"].ToString();
                dgvContacts.Columns[1].DataPropertyName = dtblCustomer.Columns["CustomerName"].ToString();
                dgvContacts.Columns[2].DataPropertyName = dtblCustomer.Columns["PendingAmount"].ToString();
                dgvContacts.Columns[3].DataPropertyName = dtblCustomer.Columns["NetAmount"].ToString();
                dgvContacts.Columns[5].DataPropertyName = dtblCustomer.Columns["SalesCode"].ToString();
                dgvContacts.Columns[4].DataPropertyName = dtblCustomer.Columns["DueDate"].ToString();
                dgvContacts.Columns[6].DataPropertyName = dtblCustomer.Columns["Email"].ToString();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Form Event..."

        public frmCustPendingList()
        {
            InitializeComponent();
        }

        private void frmContacts_Load(object sender, EventArgs e)
        {

            DataGridView t = ((DataGridView)dgvContacts);
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
            t.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            t.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 225);

            btnRegenrate.BackgroundImage = Resources.stufftheme4;
            btnRegenrate.Text = "";
            btnRegenrate.Width = 26;
            btnRegenrate.Height = 30;
            btnRegenrate.FlatStyle = FlatStyle.Popup;
            LoadList();
            if (dgvContacts.Rows.Count > 0)
            {
                for (int i = 0; i < dgvContacts.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(dgvContacts.Rows[i].Cells[4].Value) == System.DateTime.Today)
                    {
                        SendToMail(dgvContacts.Rows[i].Cells[6].Value.ToString(), dgvContacts.Rows[i].Cells[2].Value.ToString(), dgvContacts.Rows[i].Cells[5].Value.ToString());
                    }
                }
            }

        }

        #endregion

        #region "GridView Event"

        private void dgvContacts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvContacts, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GUIBase.GridDrawCustomHeaderColumns(dgvContacts, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button's Event"
        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            LoadList();
        }
        #endregion


        public void SendToMail(string EmailID, string PendingAmt, string SalesID)
        {
            try
            {

                string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; vMailFm = "niharnathwani1981@gmail.com";

                vMailTo = ((EmailID.ToLower() == "") ? "niharnathwani1981@gmail.com" : EmailID.ToLower());
                System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                vSubject = "Pending Payment Reminder"; // SUBJECT LINE

                vDetails = "Deaar Customer,"; // HEADER PART OF BODY
                vDetails += "<br /><br />";
                vDetails += "Thank You So much for your kind association with " + CurrentCompany.CompanyName + " .";
                vDetails += "<br />";
                vDetails += "You are very valueable to us as our Customer & we forward for mutualy benificial relationship. This is just a kind Reminder of your pending payment of Rs." + PendingAmt + " Againts Sales Invoice " + SalesID + " . Which is over due. Looking forward for early action. Thanking you in advance.";
                vDetails += "<br /><br />";
                vDetails += "<br /><br />";
                vDetails += "Regards,";
                vDetails += "<br /><br />";
                vDetails += CurrentCompany.CompanyName;
                vDetails += "<br />";
                vDetails += CurrentCompany.Address1 + " " + CurrentCompany.Address2;
                vDetails += "<br />";
                vDetails += CurrentCompany.Phone1;
                vDetails += "<br />";
                vDetails += CurrentCompany.Email;
                vDetails += "<br><br>";


                vMail.Subject = vSubject;
                vMail.Body = vDetails;

                vMail.IsBodyHtml = true;


                System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
                System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential("niharnathwani1981@gmail.com", "parshwanathwani123");


                vSmpt.Host = "smtp.gmail.com";
                vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                //vSmpt.UseDefaultCredentials = false;
                vSmpt.EnableSsl = true;
                vSmpt.Credentials = SmtpUser;
                vSmpt.Send(vMail);
                vMail.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
            }

        }
    }
}
