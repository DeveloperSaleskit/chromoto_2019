using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.GUI;
using System.Collections.Specialized;
using WeifenLuo.WinFormsUI.Docking;
using System.Configuration;
using Account.BusinessLogic;

namespace Account
{
    public partial class frmMainMDI : Form
    {

        CommonListBL objList = new CommonListBL();
        //DefaultLayout.frmLead frmld = new DefaultLayout.frmLead();
        //DefaultLayout.frmVendorPendingList frmVendorPending = new DefaultLayout.frmVendorPendingList();
        //DefaultLayout.frmVendPendingList frmVendPending = new DefaultLayout.frmVendPendingList();
        //DefaultLayout.frmCustPendingList frmcustPending = new DefaultLayout.frmCustPendingList();
        private int xpos = 0, ypos = 0;
        //DataTable dtblCustomer = new DataTable();
        string StrFilter = "";
        DataTable dtblLead = new DataTable();


        #region "Form Events ..."

        public frmMainMDI()
        {
            InitializeComponent();

            //frmVendorPending.Show(dockPanel1);
            //frmVendPending.Show(dockPanel1);
            //frmcustPending.Show(dockPanel1);
            //frmld.Show(dockPanel1);

            if (CurrentUser.UserID != 1)
            {
                userToolStripMenuItem.Visible = false;
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    Setprivileges();
                }
            }
        }

        public void Setprivileges()
        {
            bool MasterMenu = false;


            if (CurrentUser.PrivilegeStr.IndexOf("#2001#") != -1)
            { companyDetailToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { companyDetailToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#3001#") != -1)
            { locationToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { locationToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#4001#") != -1)
            { employeeToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { employeeToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#5001#") != -1)
            { itemParentToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { itemParentToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#6001#") != -1)
            { itemRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { itemRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9092#") != -1)
            { vendorPaymentToolStripMenuItem1.Visible = true; MasterMenu = true; }
            else { vendorPaymentToolStripMenuItem1.Visible = false; }


            //////////////////////////////customer/vendor/godown////////////////////////
            if (CurrentUser.PrivilegeStr.IndexOf("#9017#") != -1)
            { CustomerToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { CustomerToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9024#") != -1)
            { vendorToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { vendorToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9031#") != -1)
            { godownToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { godownToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9035#") != -1)
            { BanktoolStripMenuItem.Visible = true; MasterMenu = true; }
            else { BanktoolStripMenuItem.Visible = false; }
            ///////////////////////////////////////////////////////////////////


            if (CurrentUser.PrivilegeStr.IndexOf("#7001#") != -1)
            { texClassToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { texClassToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#8001#") != -1)
            { userToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { userToolStripMenuItem.Visible = false; }

           
            if (CurrentUser.PrivilegeStr.IndexOf("#9001#") != -1)
            { typeOfCallToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { typeOfCallToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1101#") != -1)
            { termsConditionToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { termsConditionToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1201#") != -1)
            { emailToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { emailToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1301#") != -1)
            { utilityToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { utilityToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1501#") != -1)
            { leadToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { leadToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1601#") != -1)
            { quotationToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { quotationToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1801#") != -1)
            { salesToolStripMenuItem1.Visible = true; MasterMenu = true; }
            else { salesToolStripMenuItem1.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#1901#") != -1)
            { customerPaymentToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { customerPaymentToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#2101#") != -1)
            { serviceFormToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { serviceFormToolStripMenuItem.Visible = false; }

            //if (CurrentUser.PrivilegeStr.IndexOf("##") != -1)
            //{ inquiryToolStripMenuItem.Visible = true; MasterMenu = true; }
            //else { inquiryToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#2301#") != -1)
            { promotionalMailToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { promotionalMailToolStripMenuItem.Visible = false; }

           
           
            if (CurrentUser.PrivilegeStr.IndexOf("#2801#") != -1)
            { customerFollowupToolStripMenuItem1.Visible = true; MasterMenu = true; }
            else { customerFollowupToolStripMenuItem1.Visible = false; }

            //if (CurrentUser.PrivilegeStr.IndexOf("#2401#") != -1)
            //{ traToolStripMenuItem.Visible = true; MasterMenu = true; }
            //else { traToolStripMenuItem.Visible = false; }

            //if (CurrentUser.PrivilegeStr.IndexOf("#2501#") != -1)
            //{ bOMBillOfMaterialToolStripMenuItem.Visible = true; MasterMenu = true; }
            //else { bOMBillOfMaterialToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9005#") != -1)
            { currencyToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { currencyToolStripMenuItem.Visible = false; }

            //////////////////////////////////////PURCHASE/////////////////////////////////
            if (CurrentUser.PrivilegeStr.IndexOf("#9040#") != -1)
            { purchaseInvoiceToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { purchaseInvoiceToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9047#") != -1)
            { GRNToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { GRNToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9101#") != -1)
            { purchaseIndentRequestToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { purchaseIndentRequestToolStripMenuItem.Visible = false; }

            //////////////////////////////////////////////////////////////////////////////////////


            ////////////////////////////////////Inventory////////////////////////////////////

            if (CurrentUser.PrivilegeStr.IndexOf("#9049#") != -1)
            { sToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { sToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9061#") != -1)
            { itemStockAdjustmentToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { itemStockAdjustmentToolStripMenuItem.Visible = false; }


            /////////////////////////////////////////////////////////

            ///////////////////////////ledger/////////////////////

            if (CurrentUser.PrivilegeStr.IndexOf("#9021#") != -1)
            { accountToolStripMenuItem2.Visible = true; MasterMenu = true; }
            else { accountToolStripMenuItem2.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9024#") != -1)
            { creditNoteToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { creditNoteToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9029#") != -1)
            { debitNoteToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { debitNoteToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9034#") != -1)
            { expenseToolStripMenuItem1.Visible = true; MasterMenu = true; }
            else { expenseToolStripMenuItem1.Visible = false; }

            ////////////////////////////////////////////////////



            ///////////////////////////materialIssue/////////////////////

            if (CurrentUser.PrivilegeStr.IndexOf("#9005#") != -1)
            { materialIssueToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { materialIssueToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9011#") != -1)
            { materialReturnToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { materialReturnToolStripMenuItem.Visible = false; }



            ////////////////////////////////////////////////////




            //////////////////////Reports/////////////////////////////

            if (CurrentUser.PrivilegeStr.IndexOf("#9151#") != -1)
            { itemStockRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { itemStockRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9152#") != -1)
            { cutomerRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { cutomerRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9153#") != -1)
            { venderRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { venderRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9154#") != -1)
            { inquiryRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { inquiryRegisterToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#9155#") != -1)
            { quotationRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { quotationRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9156#") != -1)
            { salesInvoiceRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { salesInvoiceRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9157#") != -1)
            { customerPendingPaymentRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { customerPendingPaymentRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9158#") != -1)
            { purchaseOrderRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { purchaseOrderRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9159#") != -1)
            { gRNRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { gRNRegisterToolStripMenuItem.Visible = false; }



            if (CurrentUser.PrivilegeStr.IndexOf("#9160#") != -1)
            { serviceOrderRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { serviceOrderRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9161#") != -1)
            { expenceRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { expenceRegisterToolStripMenuItem.Visible = false; }


            if (CurrentUser.PrivilegeStr.IndexOf("#9162#") != -1)
            { vendorPaymentRegisterToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { vendorPaymentRegisterToolStripMenuItem.Visible = false; }



            ///////////////////Reminders//////////////////////////////

            if (CurrentUser.PrivilegeStr.IndexOf("#5051#") != -1)
            { leaToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { leaToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#5058#") != -1)
            { customerPendingPaymentReminderToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { customerPendingPaymentReminderToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#5053#") != -1)
            { quotationServiceAMCFollowupsToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { quotationServiceAMCFollowupsToolStripMenuItem.Visible = false; }

            if (CurrentUser.PrivilegeStr.IndexOf("#5061#") != -1)
            { vendorPendingPaymentReminderToolStripMenuItem.Visible = true; MasterMenu = true; }
            else { vendorPendingPaymentReminderToolStripMenuItem.Visible = false; }




        }



        private void frmMainMDI_Load(object sender, EventArgs e)
        {
            try
            {

                this.Text = CurrentCompany.CompanyName;
                currentTime.Start();
                //lblDate.Text = "Date: " + DateTime.Now.Date.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();

                lblDate.Text = "Date: " + DateTime.Now.ToString("dd/MM/yyyy") + ", " + DateTime.Now.ToString("dd/MM/yyyy");


                lblWellcome.Text = "Welcome, " + CurrentUser.DispUserName;
                // lblDate.Text = "Date: " + DateTime.Now.Date.ToShortDateString();
                //panel3.BringToFront();
                //timer1.Start();

                DefaultLayout.frmVendorPendingList frmVendorPending = new DefaultLayout.frmVendorPendingList();

                if (FindDocument(frmVendorPending.Text) == null)
                {
                    frmVendorPending.Show(dockPanel1);
                }

                DefaultLayout.frmCustPendingList frmcustPending = new DefaultLayout.frmCustPendingList();

                if (FindDocument(frmcustPending.Text) == null)
                {
                    frmcustPending.Show(dockPanel1);
                }

                DefaultLayout.frmVendPendingList frmVendPending1 = new DefaultLayout.frmVendPendingList();

                if (FindDocument(frmVendPending1.Text) == null)
                {
                    frmVendPending1.Show(dockPanel1);
                }

                DefaultLayout.frmLead frmld = new DefaultLayout.frmLead();


                if (FindDocument(frmld.Text) == null)
                {
                    frmld.Show(dockPanel1);
                }


            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User SignIn", exc.StackTrace);
            }
        }

        private void frmMainMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure want to close Smart SalesKit?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
            else
            {
                e.Cancel = true;
            }
            //Application.Exit();
        }

        private IDockContent FindDocument(string text)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel1.Documents)
                {
                    if (content.DockHandler.TabText == text)
                    {
                        content.DockHandler.Show();
                        return content;
                    }
                }
                return null;
            }
        }

        #endregion

        #region "Link Events ..."

        private void lnkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();

        }

        private void lnkLogout_Click(object sender, EventArgs e)
        {
            this.Dispose(false);
            CompanyFYNSplash _defMDIMain = new CompanyFYNSplash();
            //Login lg = new Login();
            //lg.Show();
            _defMDIMain.Show();
            //Application.Exit();
            //_defMDIMain.Focus();
            this.Close();



        }

        private void lnkMyProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        #endregion

        #region "Open Windows Link Event...."

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dockPanel1.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                for (int index = dockPanel1.Contents.Count - 1; index >= 0; index--)
                {
                    if (dockPanel1.Contents[index] is IDockContent)
                    {
                        IDockContent content = (IDockContent)dockPanel1.Contents[index];
                        content.DockHandler.Close();
                    }
                }
            }
        }

        #endregion

        #region "Master Menu Event..."

        private void mnuLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Country.frmCSCAList frmcsc = new Account.GUI.Country.frmCSCAList();
                if (FindDocument(frmcsc.Text) == null)
                {
                    frmcsc.Show(dockPanel1);
                }

                //mdiInstances.DefLocation.Show();
                //mdiInstances.DefLocation.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Location", exc.StackTrace);
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Users.frmUserList frmUser = new Account.GUI.Users.frmUserList();
                if (FindDocument(frmUser.Text) == null)
                {
                    frmUser.Show(dockPanel1);
                }


                //mdiInstances.DefUser.Show();
                //mdiInstances.DefUser.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User SignIn", exc.StackTrace);
            }
        }

        private void mmuCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.CustomerMain.frmCustomerMainList _defCustomer = new Account.GUI.CustomerMain.frmCustomerMainList();
                if (FindDocument(_defCustomer.Text) == null)
                {
                    _defCustomer.Show(dockPanel1);
                }


                //mdiInstances.DefCustomer.Show();
                //mdiInstances.DefCustomer.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
            }
        }

        private void mmuVendor_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Vendor.frmVendorList _defVendor = new Account.GUI.Vendor.frmVendorList();
                if (FindDocument(_defVendor.Text) == null)
                {
                    _defVendor.Show(dockPanel1);
                }
                //mdiInstances.DefVendor.Show();
                //mdiInstances.DefVendor.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
            }
        }

        private void mnuItemParentMech_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.ItemParent.frmItemParentList _defItemPatent = new Account.GUI.ItemParent.frmItemParentList();
                if (FindDocument(_defItemPatent.Text) == null)
                {
                    _defItemPatent.Show(dockPanel1);
                }

                //mdiInstances.DefItemParent.Show();
                //mdiInstances.DefItemParent.Activate();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Parent", exc.StackTrace);
            }
        }

        private void mnuItemRegisterMech_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.ItemRegister.frmItemList _defItemReg = new Account.GUI.ItemRegister.frmItemList();
                if (FindDocument(_defItemReg.Text) == null)
                {
                    _defItemReg.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("User SignIn", exc.StackTrace);
            }
        }

        private void mnutaxClass_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.TaxClass.frmTaxClassList _defTaxClass = new Account.GUI.TaxClass.frmTaxClassList();
                if (FindDocument(_defTaxClass.Text) == null)
                {
                    _defTaxClass.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Employee.frmEmployeeList _defEmp = new Account.GUI.Employee.frmEmployeeList();
                if (FindDocument(_defEmp.Text) == null)
                {
                    _defEmp.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee", exc.StackTrace);
            }

        }

        #endregion

        #region "Store Menu Event..."

        private void mnuStockMech_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.ItemStock.frmItemStockList _defStock = new Account.GUI.ItemStock.frmItemStockList();
                if (FindDocument(_defStock.Text) == null)
                {
                    _defStock.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Stock", exc.StackTrace);
            }
        }

        private void mnuAdjustment_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Item_Adjustment.frmItemAdjustList _defItemAdjustment = new Account.GUI.Item_Adjustment.frmItemAdjustList();
                if (FindDocument(_defItemAdjustment.Text) == null)
                {
                    _defItemAdjustment.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Adjustment", exc.StackTrace);
            }
        }

        private void mnuPurchaseInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.PurchaseInvoice.frmPurchaseInvoiceList _defPI = new Account.GUI.PurchaseInvoice.frmPurchaseInvoiceList();
                if (FindDocument(_defPI.Text) == null)
                {
                    _defPI.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
            }


            //try
            //{
            //    Account.GUI.PurchaseInvoice.frmPurchaseInvoiceList _defPI = new Account.GUI.PurchaseInvoice.frmPurchaseInvoiceList();
            //    if (FindDocument(_defPI.Text) == null)
            //    {
            //        _defPI.Show(dockPanel1);
            //    }
            //    //mdiInstances.DefStock.Activate();
            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("PurchaseInvoice", exc.StackTrace);
            //}
        }

        private void mnuSalesInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.SalesInvoice.frmSalesInvoiceList _defSI = new Account.GUI.SalesInvoice.frmSalesInvoiceList();
                if (FindDocument(_defSI.Text) == null)
                {
                    _defSI.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("SalesInvoice", exc.StackTrace);
            }
        }

        #endregion

        #region "Account Menu..."

        private void mnuCustomerPayment_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.CustomerPayment.frmCustomerPaymentList _defCP = new Account.GUI.CustomerPayment.frmCustomerPaymentList();
                if (FindDocument(_defCP.Text) == null)
                {
                    _defCP.Show(dockPanel1);
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment", exc.StackTrace);
            }
        }

        private void mnuVendorPayment_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.VendorPayment.frmVendorPaymentList _defVP = new Account.GUI.VendorPayment.frmVendorPaymentList();
                if (FindDocument(_defVP.Text) == null)
                {
                    _defVP.Show(dockPanel1);
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment", exc.StackTrace);
            }

            //try
            //{
            //    Account.GUI.VendorPayment.frmVendorPaymentList _defVP = new Account.GUI.VendorPayment.frmVendorPaymentList();
            //    if (FindDocument(_defVP.Text) == null)
            //    {
            //        _defVP.Show(dockPanel1);
            //    }

            //}
            //catch (Exception exc)
            //{
            //    Utill.Common.ExceptionLogger.writeException("Vendor Payment", exc.StackTrace);
            //}
        }

        private void commissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Commission.frmCommissionEntry _defComm = new Account.GUI.Commission.frmCommissionEntry();
                if (FindDocument(_defComm.Text) == null)
                {
                    _defComm.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Commission", exc.StackTrace);
            }
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.AccountMaster.frmAccountMasterList _defAccount = new Account.GUI.AccountMaster.frmAccountMasterList();
                if (FindDocument(_defAccount.Text) == null)
                {
                    _defAccount.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
            }
        }

        private void expenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Expense.frmExpenseList _defExp = new Account.GUI.Expense.frmExpenseList();
                if (FindDocument(_defExp.Text) == null)
                {
                    _defExp.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense", exc.StackTrace);
            }
        }

        #endregion

        #region "Timer Event...."

        private void currentTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = "Date: " + DateTime.Now.Date.ToShortDateString() + ", " + DateTime.Now.ToLongTimeString();
        }

        #endregion

        #region "Utility Menu..."

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Currency.frmBackupEntry _defCompany = new Account.GUI.Currency.frmBackupEntry();
                if (FindDocument(_defCompany.Text) == null)
                {
                    _defCompany.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Local Backup", exc.StackTrace);
            }
        }

        #endregion


        private void leadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Lead.frmLeadList _defEmp = new Account.GUI.Lead.frmLeadList();
                if (FindDocument(_defEmp.Text) == null)
                {
                    _defEmp.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead", exc.StackTrace);
            }

        }

        private void quotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Quotation.frmQuotationList _defQuotation = new Account.GUI.Quotation.frmQuotationList();
                if (FindDocument(_defQuotation.Text) == null)
                {
                    _defQuotation.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
            }
        }

        private void serviceFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.ServiceModule.frmServiceModuleList _defTaxClass = new Account.GUI.ServiceModule.frmServiceModuleList();
                if (FindDocument(_defTaxClass.Text) == null)
                {
                    _defTaxClass.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
            }
        }

        private void dailyAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void godownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Godown.frmGodownList _defgodown = new Account.GUI.Godown.frmGodownList();
                if (FindDocument(_defgodown.Text) == null)
                {
                    _defgodown.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Godown", exc.StackTrace);
            }
        }

        private void typeOfCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.TypeOfCall.frmTypeOfCallList _deftypeofcall = new Account.GUI.TypeOfCall.frmTypeOfCallList();
                if (FindDocument(_deftypeofcall.Text) == null)
                {
                    _deftypeofcall.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Type Of Call", exc.StackTrace);
            }
        }

        private void termsConditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.TermsNConditions.frmTermsNConditionsList _defTermsNConditions = new Account.GUI.TermsNConditions.frmTermsNConditionsList();
                if (FindDocument(_defTermsNConditions.Text) == null)
                {
                    _defTermsNConditions.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
            }
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Email.frmEmailList _defEmail = new Account.GUI.Email.frmEmailList();
                if (FindDocument(_defEmail.Text) == null)
                {
                    _defEmail.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Email", exc.StackTrace);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (xpos == 0)
            //{
            //    this.label1.Location = new System.Drawing.Point(this.Width, ypos);
            //    xpos = this.Width;

            //}
            //else
            //{
            //    this.label1.Location = new System.Drawing.Point(xpos, ypos);
            //    xpos -= 2;

            //}
        }

        private void companyDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Company.frmCompanyList _defCompany = new Account.GUI.Company.frmCompanyList();
                if (FindDocument(_defCompany.Text) == null)
                {
                    _defCompany.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Company", exc.StackTrace);
            }

        }

        private void promotionalMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.PromoMail.frmPromoMailList _defPromoMail = new Account.GUI.PromoMail.frmPromoMailList();
                if (FindDocument(_defPromoMail.Text) == null)
                {
                    _defPromoMail.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Promotional Mail", exc.StackTrace);
            }
        }

        private void customerFollowupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.CustomerFollowup.frmCustomerFollowupList _defTaxClass = new Account.GUI.CustomerFollowup.frmCustomerFollowupList();
                if (FindDocument(_defTaxClass.Text) == null)
                {
                    _defTaxClass.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Followup", exc.StackTrace);
            }
        }

        private void GRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Indent.frmIndentList _defPI = new Account.GUI.Indent.frmIndentList();
                if (FindDocument(_defPI.Text) == null)
                {
                    _defPI.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Indent", exc.StackTrace);
            }
        }

        private void customerFollowupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.CustomerFollowup.frmCustomerFollowupList _defTaxClass = new Account.GUI.CustomerFollowup.frmCustomerFollowupList();
                if (FindDocument(_defTaxClass.Text) == null)
                {
                    _defTaxClass.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Followup", exc.StackTrace);
            }
        }

        private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Currency.frmCurrencyList _defEmp = new Account.GUI.Currency.frmCurrencyList();
                if (FindDocument(_defEmp.Text) == null)
                {
                    _defEmp.Show(dockPanel1);
                }
                //mdiInstances.DefItemRegister.Show();
                //mdiInstances.DefItemRegister.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee", exc.StackTrace);
            }
        }

        private void BanktoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.Bank_Master.frmBankList frmcsc = new Account.GUI.Bank_Master.frmBankList();
                if (FindDocument(frmcsc.Text) == null)
                {
                    frmcsc.Show(dockPanel1);
                }

                //mdiInstances.DefLocation.Show();
                //mdiInstances.DefLocation.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Bank", exc.StackTrace);
            }
        }

        private void creditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.CreditNote.frmCreditNoteList _defCN = new Account.GUI.CreditNote.frmCreditNoteList();
                if (FindDocument(_defCN.Text) == null)
                {
                    _defCN.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("CreditNote", exc.StackTrace);
            }
        }

        private void debitNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.DebitNote.frmDebitNoteList _defCN = new Account.GUI.DebitNote.frmDebitNoteList();
                if (FindDocument(_defCN.Text) == null)
                {
                    _defCN.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("DebitNote", exc.StackTrace);
            }
        }

        private void remoteDatabaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("You are going to Backup the Current Database. Are you sure?", "Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BusinessLogic.UtilityBL ObjUtility = new BusinessLogic.UtilityBL();
                    NameValueCollection Paralist = new NameValueCollection();

                    Paralist.Add("@i_DBName", ConfigurationManager.AppSettings["DBName"].ToString());
                    Paralist.Add("@i_BackupType", "Remote");
                    Paralist.Add("@i_BackupPath", "");

                    ObjUtility.GetBackUp("usp_BackUp", Paralist, true, "MDI Main - Backup");
                    if (ObjUtility.Exception == null)
                    {
                        if (ObjUtility.ErrorMessage != "")
                        {
                            MessageBox.Show(ObjUtility.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(ObjUtility.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("MDI Main - Backup", exc.StackTrace);
            }
        }



        private void leaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefaultLayout.frmVendorPendingList frmVendorPending = new DefaultLayout.frmVendorPendingList();

            if (FindDocument(frmVendorPending.Text) == null)
            {
                frmVendorPending.Show(dockPanel1);
            }
        }

        private void quotationServiceAMCFollowupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefaultLayout.frmLead frmld = new DefaultLayout.frmLead();


            if (FindDocument(frmld.Text) == null)
            {
                frmld.Show(dockPanel1);
            }

        }

        private void customerPendingPaymentReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefaultLayout.frmCustPendingList frmcustPending = new DefaultLayout.frmCustPendingList();

            if (FindDocument(frmcustPending.Text) == null)
            {
                frmcustPending.Show(dockPanel1);
            }
        }

        private void vendorPendingPaymentReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DefaultLayout.frmVendPendingList frmVendPending1 = new DefaultLayout.frmVendPendingList();

            if (FindDocument(frmVendPending1.Text) == null)
            {
                frmVendPending1.Show(dockPanel1);
            }
        }

        private void customerPaymentReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.CustomerPaymentReturn.frmVendorPaymentReturnList _defCPR = new Account.GUI.CustomerPaymentReturn.frmVendorPaymentReturnList();
                if (FindDocument(_defCPR.Text) == null)
                {
                    _defCPR.Show(dockPanel1);
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer Payment Return", exc.StackTrace);
            }
        }

        private void vendorPaymentReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.VendorPaymentReturn.frmVendorPaymentReturnList _defVPR = new Account.GUI.VendorPaymentReturn.frmVendorPaymentReturnList();
                if (FindDocument(_defVPR.Text) == null)
                {
                    _defVPR.Show(dockPanel1);
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment Return", exc.StackTrace);
            }
        }

        private void itemStockRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemStockRegister.rpt"))
                {

                    NameValueCollection para = new NameValueCollection();

                    para.Add("@i_FYID", CurrentUser.FYID.ToString());
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para.Add("@i_UserId", CurrentUser.UserID.ToString());


                    DataTable dtblItemStock = objList.ListOfRecord("usp_ItemStock_List", para, "ItemStock - LoadList");

                    //dtblItemStock .TableName = "ItemStockRegister";
                    //dtblItemStock.WriteXmlSchema(@"D:\ItemStockRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblItemStock.DefaultView;
                    // DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptItemStockRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Stock Register", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Item Stock Register - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void venderRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptVendorRegister.rpt"))
                {

                    NameValueCollection para1 = new NameValueCollection();
                    para1.Add("@i_UserID", CurrentUser.UserID.ToString());
                    para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                    DataTable dtblVendor = objList.ListOfRecord("usp_Vendor_List", para1, "Vendor - LoadList");
                    //dtblVendor.TableName = "VendorRegister";
                    //dtblVendor.WriteXmlSchema(@"D:\Report\VendorRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblVendor.DefaultView;
                    // DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptVendorRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Vendor Register", true, true, true, true, false, true, true, false, false, false, true);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Vendor Register - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                    // DataTable dt = new DataTable();
                    //// dt = dgvVendor.DataSource();
                    // for (int i = 0; i < dgvVendor.Rows.Count; i++)
                    // {
                    //     DataRow dr = dt.NewRow();
                    //     dr["Col1"] = dgvVendor.rows[i]["Col1"].text;
                    //     dt.Rows.Add(dr);
                    // }
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void cutomerRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerRegister.rpt"))
                //{
                //    //dtblCustomer.TableName = "CustomerRegister";
                //    //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");
                //    NameValueCollection para = new NameValueCollection();

                //    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                //    DataTable dtblCustomer = objList.ListOfRecord("usp_Customer_List", para, "Customer - LoadList");

                //    DataView DVReport;
                //    DVReport = dtblCustomer.DefaultView;
                //   // DVReport.RowFilter = StrFilter;
                //    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                //    rptDoc.Load(CurrentUser.ReportPath + "rptCustomerRegister.rpt");

                //    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Register", true, true, true, true, false, true, false, false, false, false, false);

                //    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                //    fRptView.Text = "Customer Register - [Page Size: A4]";
                //    fRptView.crViewer.ReportSource = rptDoc;
                //    fRptView.ShowDialog();
                //}
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerRegister.rpt"))
                {
                    //dtblCustomer.TableName = "CustomerRegister";
                    //dtblCustomer.WriteXmlSchema(@"D:\report\CustomerRegister.xsd");

                    NameValueCollection para1 = new NameValueCollection();
                    para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para1.Add("@i_UserID", CurrentUser.UserID.ToString());

                    DataTable dtblLead = objList.ListOfRecord("usp_CustomerMain_List", para1, "Lead -List");
                    //DataTable dtblLead = objList.ListOfRecord("usp_Lead_Select", para1, "Lead -List");


                    DataView DVReport;
                    DVReport = dtblLead.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptCustomerRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Register", true, true, true, true, false, true, false, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Customer Register - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }

            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer- Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void inquiryRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptLeadRegister.rpt"))
                {
                    //dtblLead.TableName = "LeadRegister";
                    //dtblLead.WriteXmlSchema(@"E:\SharedFile\LeadRegister.xsd");
                    NameValueCollection para1 = new NameValueCollection();
                    para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para1.Add("@i_UserID", CurrentUser.UserID.ToString());

                    DataTable dtblLead = objList.ListOfRecord("usp_Lead_List", para1, "Lead -List");

                    DataView DVReport;
                    DVReport = dtblLead.DefaultView;
                    //  DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptLeadRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Inquiry Register", true, true, true, true, false, true, true, false, false, false, true);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Inquiry Register - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void quotationRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotationRegister.rpt"))
            {

                NameValueCollection para1 = new NameValueCollection();

                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para1.Add("@i_UserID", CurrentUser.UserID.ToString());

                DataTable dtblQuotation = objList.ListOfRecord("usp_Quotation_List", para1, "Quotation - List - LoadList");

                DataView DVReport;
                DVReport = dtblQuotation.DefaultView;
                //ObjDataTable.TableName = "QuoRegister";
                //ObjDataTable.WriteXmlSchema(@"D:\QuoRegister.xsd");
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rptDoc.Load(CurrentUser.ReportPath + "rptQuotationRegister.rpt");
                //rptDoc.BlankRecords.Height -= (ds.tblItems.Count * 136);
                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Quotation Register", true, true, true, true, false, true, true, false, false, false, true);

                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                fRptView.Text = "Quotation Register - [Page Size: A4]";
                fRptView.crViewer.ReportSource = rptDoc;
                fRptView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
            }
        }

        private void salesInvoiceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotationRegister.rpt"))
            {

                DataTable dtReport = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserId", CurrentUser.UserID.ToString());

                dtReport = objList.ListOfRecord("rpt_SalesInvoiceRegister", para, "SalesInvoice - Report");
                DataView DVReport;
                DVReport = dtReport.DefaultView;
                //DVReport.RowFilter = StrFilter;

                //dtblSalesInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rptDoc.Load(CurrentUser.ReportPath + "rptSalesInvoiceRegister.rpt");
                //rptDoc.BlankRecords.Height -= (ds.tblItems.Count * 136);
                CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Sales Invoice Register", true, true, true, true, false, true, true, false, false, false, true);

                Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                fRptView.Text = "Sales Invoice Register - [Page Size: A4]";
                fRptView.crViewer.ReportSource = rptDoc;
                fRptView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
            }
        }

        private void customerPendingPaymentRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtReport = new DataTable();
                NameValueCollection PARA = new NameValueCollection();
                PARA.Add("@i_CompID", CurrentCompany.CompId.ToString());
                PARA.Add("@i_UserId", CurrentUser.UserID.ToString());
                dtReport = objList.ListOfRecord("rpt_CustomerReceipt", PARA, "CustomerPayment - Report");

                if (objList.Exception == null)
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptCustomerPaymentRegister.rpt"))
                    {
                        //ObjDataTable.TableName = "PaymentRegister";
                        //ObjDataTable.WriteXmlSchema(@"D:\PaymentRegister.xsd");

                        DataView DVReport;
                        DVReport = dtReport.DefaultView;
                        //DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptCustomerPaymentRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Customer Payment Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Customer Payment Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please enter the Valid ReportPath or Docpath...");
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
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMessage, "Exception");
            }

        }

        private void purchaseOrderRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtReport = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserId", CurrentUser.UserID.ToString());
                dtReport = objList.ListOfRecord("rpt_PORegister", para, "PurchaseInvoice - Report");
                DataView DVReport;
                DVReport = dtReport.DefaultView;
                // DVReport.RowFilter = StrFilter;

                if (dtReport.Rows.Count > 0)
                {
                    for (int i = 0; i < dtReport.Rows.Count; i++)
                    {
                        string ItemCode = dtReport.Rows[i]["ItemCode"].ToString();
                        int OrderBookingID = Convert.ToInt16(dtReport.Rows[i]["PIID"].ToString());
                        DataTable dtSQty = new DataTable();
                        NameValueCollection para1 = new NameValueCollection();
                        para1.Add("@i_ItemCode", ItemCode.ToString());
                        para1.Add("@i_POID", OrderBookingID.ToString());
                        para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                        dtSQty = objList.ListOfRecord("rpt_Get_ReceivedQty", para1, "PurchaseInvoice - Reports");

                        decimal SQty = 0;
                        if (dtSQty.Rows[0][0].ToString().Trim() == "")
                        {
                            SQty = 0;
                        }
                        else
                        {
                            SQty = Convert.ToDecimal(dtSQty.Rows[0][0]);
                        }

                        dtReport.Rows[i]["DQty"] = SQty;
                        dtReport.Rows[i]["Diff"] = Convert.ToDecimal(dtReport.Rows[i]["OQty"]) - SQty;
                        dtReport.Rows[i]["OrdValue"] = Convert.ToDecimal(dtReport.Rows[i]["OQty"]) * Convert.ToDecimal(dtReport.Rows[i]["Rate"]);
                        dtReport.Rows[i]["SupplyValue"] = SQty * Convert.ToDecimal(dtReport.Rows[i]["Rate"]);
                        dtReport.Rows[i]["diff1"] = Convert.ToDecimal(dtReport.Rows[i]["OrdValue"]) - Convert.ToDecimal(dtReport.Rows[i]["SupplyValue"]);
                        string Difference = dtReport.Rows[i]["Diff"].ToString();
                    }
                    //StrFilter = " Diff <> 0";
                    DVReport = dtReport.DefaultView;
                    //  DVReport.RowFilter = StrFilter;

                }


                if (objList.Exception == null)
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptPurchaseInvoiceRegister.rpt"))
                    {
                        //dtblPurchaseInvoice .TableName = "PORegister";
                        //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptPurchaseInvoiceRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Purchase Order Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Purchase Order Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Purchase Order - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void gRNRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtReport = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_UserId", CurrentUser.UserID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtReport = objList.ListOfRecord("rpt_IndentRegister", para, "Indent - Report");
                DataView DVReport;
                DVReport = dtReport.DefaultView;
                //DVReport.RowFilter = StrFilter;

                if (objList.Exception == null)
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptGRNRegister.rpt"))
                    {
                        //dtblPurchaseInvoice .TableName = "PORegister";
                        //dtblPurchaseInvoice.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptGRNRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Indent Register", true, true, true, true, false, true, true, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Indent Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Indent - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void serviceOrderRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptServiceModuleRegister.rpt"))
                {
                    NameValueCollection para = new NameValueCollection();
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    para.Add("@i_UserID", CurrentUser.UserID.ToString());

                    DataTable dtblItem = objList.ListOfRecord("usp_ServiceModule_List", para, "ServiceModule - LoadList");

                    DataView DVReport;
                    DVReport = dtblItem.DefaultView;
                    // DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptServiceModuleRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Service Module", true, true, true, true, false, true, true, false, false, false, true);
                    //CurrentUser.AddExtraParameter(rptDoc);
                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Service Module - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Indent - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        private void expenceRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptExpenseRegister.rpt"))
                {
                    //dtblExpense .TableName = "PORegister";
                    //dtblExpense.WriteXmlSchema(@"D:\Report\PORegister.xsd");
                    NameValueCollection para = new NameValueCollection();

                    para.Add("@i_FYID", CurrentUser.FYID.ToString());
                    //para.Add("@i_UserId", CurrentUser.UserID.ToString());
                    //para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                    DataTable dtblExpense = objList.ListOfRecord("usp_Expense_List", para, "Expense - LoadList");

                    DataView DVReport;
                    DVReport = dtblExpense.DefaultView;
                    //l DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptExpenseRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Expense Register", true, true, true, true, false, true, true, false, false, false, true);
                    //rptDoc.SetParameterValue("pFromDate", txtFromDate.Text);
                    //rptDoc.SetParameterValue("pToDate", txtTodate.Text);
                    //if (DataValidator.IsDate(txtFromDate.Text.Trim()) && DataValidator.IsDate(txtTodate.Text.Trim()))
                    //{
                    //    rptDoc.SetParameterValue("pPassDate", true);
                    //}
                    //else
                    //{
                    //    rptDoc.SetParameterValue("pPassDate", false);
                    //}

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Expense Register - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Expense - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void menuStripControlPanel_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void materialIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                Account.GUI.MaterialIssue.frmMaterialIssueList _MaterialIssueList = new Account.GUI.MaterialIssue.frmMaterialIssueList();
                if (FindDocument(_MaterialIssueList.Text) == null)
                {
                    _MaterialIssueList.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();


            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("MaterialIssue", exc.StackTrace);
            }
        }

        private void materialReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {


                Account.GUI.MaterialReturn.frmMaterialReturnList _MaterialreturnList1 = new Account.GUI.MaterialReturn.frmMaterialReturnList();
                if (FindDocument(_MaterialreturnList1.Text) == null)
                {
                    _MaterialreturnList1.Show(dockPanel1);
                }
                //mdiInstances.DefStock.Activate();



            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("MaterialIssueReturn", exc.StackTrace);
            }

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuControlPanel_Click(object sender, EventArgs e)
        {

        }

        private void purchaseIndentRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Account.GUI.PurchaseIndentRequest.frmPurchaseIndentList _defVP = new Account.GUI.PurchaseIndentRequest.frmPurchaseIndentList();
                if (FindDocument(_defVP.Text) == null)
                {
                    _defVP.Show(dockPanel1);
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor Payment", exc.StackTrace);
            }
        }

        private void vendorPaymentRegisterToolStripMenuItem_Click(object sender, EventArgs e)
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
                Utill.Common.ExceptionLogger.writeException("Vendor Payment - Register Report", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void utilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



    }

}
