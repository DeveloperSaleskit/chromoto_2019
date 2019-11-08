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
using Account.GUI.CustomerPayment;
using Account.GUI.DefaultLayoutForms;
using System.Configuration;

namespace Account.DefaultLayout
{
    public partial class frmVendPendingList : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        #region "Variable Declaration...."

        DataTable dtblCustomer = new DataTable();
        private Font NormalFont = new Font("Verdana", 8, FontStyle.Regular);
        CommonListBL objList = new CommonListBL();
        DataView DV;
        string StrFilter = "";
        int _CompId = 0;
        DataTable ObjDataTable = new DataTable();

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para1 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblCustomer = objList.ListOfRecord("usp_Vendor_PendingPaymentList", para1, "Vendor - PaymentPendingList");
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
                dgvContacts.Columns["SalesCode"].DataPropertyName = dtblCustomer.Columns["PurchaseCode"].ToString();
                dgvContacts.Columns["CustomerName"].DataPropertyName = dtblCustomer.Columns["VendorName"].ToString();
                dgvContacts.Columns["PendingAmount"].DataPropertyName = dtblCustomer.Columns["PendingAmount"].ToString();
                dgvContacts.Columns["NetAmount"].DataPropertyName = dtblCustomer.Columns["NetAmount"].ToString();
                dgvContacts.Columns["DueDate"].DataPropertyName = dtblCustomer.Columns["DueDate"].ToString();
                //dgvContacts.Columns["ContactPerson"].DataPropertyName = dtblCustomer.Columns["ContactPerson"].ToString();
                //dgvContacts.Columns["Mobile"].DataPropertyName = dtblCustomer.Columns["Mobile"].ToString();               
                //dgvContacts.Columns["Email"].DataPropertyName = dtblCustomer.Columns["Email"].ToString();
                //dgvContacts.Columns["RecDay"].DataPropertyName = dtblCustomer.Columns["RecDay"].ToString();
                dgvContacts.Columns["DueDays"].DataPropertyName = dtblCustomer.Columns["DueDays"].ToString();
                dgvContacts.Columns["CustomerCode"].DataPropertyName = dtblCustomer.Columns["VendorCode"].ToString();
                //dgvContacts.Columns["CompId"].DataPropertyName = dtblCustomer.Columns["CompId"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Contacts", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Form Event..."

        public frmVendPendingList()
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
            t.RowsDefaultCellStyle.SelectionForeColor = Color.Blue;
            t.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 225);

            //btnRegenrate.BackgroundImage = Resources.stufftheme4;
            //btnRegenrate.Text = "";
            //btnRegenrate.Width = 26;//26
            //btnRegenrate.Height = 30;//30
            //btnRegenrate.FlatStyle = FlatStyle.Popup;

            btnApply.ForeColor = Color.Black;
            btnRegenrate.ForeColor = Color.Black;

            ////Button btnFilter = ((Button)btnApply);
            ////btnFilter.Width = 89;
            ////btnFilter.Height = 23;



            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#5062#") != -1)
                    {
                        cmbreports.Items.Add("Vendor Payment Register");
                    }

                }
                else
                {
                    cmbreports.Items.Add("Vendor Payment Register");

                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Vendor Payment Register");

            }
            cmbreports.SelectedIndex = 0;


            LoadList();
            // cmbreports.Items.Add("--Select Report--");
            // cmbreports.Items.Add("Vendor Payment Register");
            //  cmbreports.Items.Add("Customer Pending Payment Receipt");
            //  cmbreports.SelectedIndex = 0;
            if (CurrentCompany.AutoMailPayQuo == "Mail")
            {
                mail();
            }
            TotalPendingAmount();

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

        #region " User Defined Functions"

        protected void mail()
        {
            if (dgvContacts.Rows.Count > 0)
            {
                for (int i = 0; i < dgvContacts.Rows.Count; i++)
                {
                    if (Convert.ToInt16(dgvContacts.Rows[i].Cells["DueDays"].Value) != 0)
                    {
                        if (dgvContacts.Rows[i].Cells["DueDate"].Value != DBNull.Value)
                        {
                            if (Convert.ToDateTime(dgvContacts.Rows[i].Cells[4].Value) == System.DateTime.Today)
                            {
                                SendToMail(dgvContacts.Rows[i].Cells[6].Value.ToString(), dgvContacts.Rows[i].Cells[2].Value.ToString(), dgvContacts.Rows[i].Cells[5].Value.ToString());
                            }
                            else if (System.DateTime.Today > Convert.ToDateTime(dgvContacts.Rows[i].Cells[4].Value))
                            {
                                int RecDay = Convert.ToInt16(dgvContacts.Rows[i].Cells["RecDay"].Value);
                                DateTime DueDate = Convert.ToDateTime(dgvContacts.Rows[i].Cells[4].Value);
                                double s = 0;
                                if (RecDay > 0)
                                {
                                    if (System.DateTime.Today > DueDate)
                                    {
                                        s = (System.DateTime.Today - DueDate).TotalDays;
                                    }
                                    if (s % RecDay == 0)
                                    {
                                        if (System.DateTime.Today == DueDate.AddDays(s))
                                        {
                                            SendToMail(dgvContacts.Rows[i].Cells[6].Value.ToString(), dgvContacts.Rows[i].Cells[2].Value.ToString(), dgvContacts.Rows[i].Cells[5].Value.ToString());
                                        }
                                    }
                                }
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
                para.Add("@i_Type", "Payment Reminder");
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");


                vSubject = dtEmail.Rows[0]["Subject"].ToString();// SUBJECT LINE

                vDetails = dtEmail.Rows[0]["Header"].ToString(); // HEADER PART OF BODY
                vDetails += "<br /><br />";
                vDetails += "<html><head><title></title></head><body><table style=&quot;width: 100%;&quot; border=&quot;1&quot;>" +
                                "<tr align=&quot;center&quot; style=&quot;font-weight: bold&quot;><td>Sales Code</td><td>Pending Amount</td></tr>";
                vDetails += "<tr><td align=&quot;left&quot;> " + SalesID +
                                    "</td><td align=&quot;right&quot;>" + PendingAmt +
                                    "</td></tr>";

                vDetails += "</table></body></html>";
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

        public void TotalPendingAmount()
        {
            txtTotalPendingAmt.Text = "0.00";
            if (dgvContacts.RowCount > 0)
            {
                for (int i = 0; i < dgvContacts.RowCount; i++)
                {
                    txtTotalPendingAmt.Text = (Convert.ToDecimal(txtTotalPendingAmt.Text) + Convert.ToDecimal(dgvContacts.Rows[i].Cells["PendingAmount"].Value.ToString())).ToString("#.00");
                }
            }
        }

        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblCustomer.DefaultView;
            DV.RowFilter = StrFilter;
            dgvContacts.DataSource = DV.ToTable();
            //frmCustomerPaymentFilter filterSalesinvoice = new frmCustomerPaymentFilter(dtblCustomer);
            frmVendorPPFilter filterSalesinvoice = new frmVendorPPFilter(dtblCustomer);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;

            DataTable dt = DV.ToTable();
            dgvContacts.DataSource = DV.ToTable();
            //DataTable dt = DV.ToTable();
            dgvContacts.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvContacts.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para.Add("@i_UserID", CurrentUser.UserID.ToString());
                    DataTable dtReport = new DataTable();

                    dtReport = objList.ListOfRecord("rpt_VendorPayment", para, "VendorPayment - Report");
                    if (objList.Exception == null)
                    {
                        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptVendorPaymentRegister.rpt"))
                        {
                            //dtblPurchaseInvoice .TableName = "PORegister";
                            //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptVendorPaymentRegister.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dtReport, "Vendor Payment Register", true, true, true, true, false, true, true, false, false, false, false);

                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Vendor Payment Register - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("File is not exist...");
                        }
                    }
                    else
                    {
                        MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("Customer Payment - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            //else if (cmbreports.SelectedIndex == 2)
            //{
            //    try
            //    {
            //        DataTable dtReport = new DataTable();
            //        NameValueCollection PARA1 = new NameValueCollection();
            //        PARA1.Add("@i_ReceiptID", dgvContacts.CurrentRow.Cells["ReceiptID"].Value.ToString());
            //        dtReport = objList.ListOfRecord("rpt_Customer_Payment_Receipt", PARA1, "CustomerPayment - Report");
            //        if (objList.Exception == null)
            //        {
            //            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerPendingPaymentReceipt.rpt"))
            //            {
            //                //dtReport.TableName = "PaymentReceipt";
            //                //dtReport.WriteXmlSchema(@"D:\PaymentReceipt.xsd");
            //                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //                rptDoc.Load(CurrentUser.ReportPath + "rptCustomerPendingPaymentReceipt.rpt");

            //                CurrentUser.AddReportParameters(rptDoc, dtReport, "Payment Receipt", true, true, true, true, false, true, true, false, false, false, true);

            //                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
            //                fRptView.Text = "Payment Receipt - [Page Size: A4]";
            //                fRptView.crViewer.ReportSource = rptDoc;
            //                fRptView.ShowDialog();
            //            }
            //            else
            //            {
            //                MessageBox.Show("File is not exist...");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    catch (Exception exc)
            //    {
            //        Utill.Common.ExceptionLogger.writeException("Customer Payment - Register Report", exc.StackTrace);
            //        MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            //    }
            //}
            cmbreports.SelectedIndex = 0;
        }
    }
}
