using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Account
{
    abstract class mdiInstances
    {
        #region "Private Variable Declaration"

        private static Form _defMDIMain;
        private static Form _defUser;
        private static Form _defItemReg;
        private static Form _defLocation;
        private static Form _defItemPatent;
        private static Form _defVendor;
        private static Form _defCustomer;
        private static Form _defStock;
        private static Form _defItemAdjustment;
        private static Form _defPurchaseInvoice;
        private static Form _defSalesInvoice;
        private static Form _defAccount;
        private static Form _defTaxClass;

        #endregion

        #region "Public Properties Declaration..."

        public static Form DefMDIMain
        {
            get
            {
                if (_defMDIMain == null || _defMDIMain.IsDisposed == true)
                {
                    _defMDIMain = new frmMainMDI(); //frmMain();
                }
                return _defMDIMain;
            }
            set { _defMDIMain = value; }
        }

        public static Form DefUser
        {
            get
            {
                if (_defUser == null || _defUser.IsDisposed == true)
                {
                    _defUser = new Account.GUI.Users.frmUserList();
                    _defUser.MdiParent = DefMDIMain;
                }
                return _defUser;
            }
            set { _defUser = value; }
        }

        public static Form DefItemRegister
        {
            get
            {
                if (_defItemReg == null || _defItemReg.IsDisposed == true)
                {
                    _defItemReg = new Account.GUI.ItemRegister.frmItemList();
                    _defItemReg.MdiParent = DefMDIMain;
                }
                return _defItemReg;
            }
            set { _defItemReg = value; }
        }

        public static Form DefLocation
        {
            get
            {
                if (_defLocation == null || _defLocation.IsDisposed == true)
                {
                    _defLocation = new Account.GUI.Country.frmCSCAList();
                    _defLocation.MdiParent = DefMDIMain;
                }
                return _defLocation;
            }
            set { _defLocation = value; }
        }

        public static Form DefItemParent
        {
            get
            {
                if (_defItemPatent == null || _defItemPatent.IsDisposed == true)
                {
                    _defItemPatent = new Account.GUI.ItemParent.frmItemParentList();
                    _defItemPatent.MdiParent = DefMDIMain;
                }
                return _defItemPatent;
            }
            set { _defItemPatent = value; }
        }

        //public static Form DefItemAdjustment
        //{
        //    get
        //    {
        //        if (_defItemAdjustment == null || _defItemAdjustment.IsDisposed == true)
        //        {
        //            _defItemAdjustment = new Account.GUI.Item_Adjustment.frmItemAdjustList();
        //            _defItemAdjustment.MdiParent = DefMDIMain;
        //        }
        //        return _defItemAdjustment;
        //    }
        //    set { _defItemAdjustment = value; }
        //}

        public static Form DefVendor
        {
            get
            {
                if (_defVendor == null || _defVendor.IsDisposed == true)
                {
                    _defVendor = new Account.GUI.Vendor.frmVendorList();
                    _defVendor.MdiParent = DefMDIMain;
                }
                return _defVendor;
            }
            set { _defVendor = value; }
        }

        //public static Form DefCustomer
        //{
        //    get
        //    {
        //        if (_defCustomer == null || _defCustomer.IsDisposed == true)
        //        {
        //            _defCustomer = new Account.GUI.Customer.frmCustomerList();
        //            _defCustomer.MdiParent = DefMDIMain;
        //        }
        //        return _defCustomer;
        //    }
        //    set { _defCustomer = value; }
        //}

        public static Form DefPurchaseInvoice
        {
            get
            {
                if (_defPurchaseInvoice == null || _defPurchaseInvoice.IsDisposed == true)
                {
                    _defPurchaseInvoice = new Account.GUI.PurchaseInvoice.frmPurchaseInvoiceList();
                    _defPurchaseInvoice.MdiParent = DefMDIMain;
                }
                return _defPurchaseInvoice;
            }
            set { _defPurchaseInvoice = value; }
        }

        public static Form DefStock
        {
            get
            {
                if (_defStock == null || _defStock.IsDisposed == true)
                {
                    _defStock = new Account.GUI.ItemStock.frmItemStockList();
                    _defStock.MdiParent = DefMDIMain;
                }
                return _defStock;
            }
            set { _defStock = value; }
        }

        public static Form DefSalesInvoice
        {
            get
            {
                if (_defSalesInvoice == null || _defSalesInvoice.IsDisposed == true)
                {
                    _defSalesInvoice = new Account.GUI.SalesInvoice.frmSalesInvoiceList();
                    _defSalesInvoice.MdiParent = DefMDIMain;
                }
                return _defSalesInvoice;
            }
            set { _defSalesInvoice = value; }
        }

        public static Form DefAccount
        {
            get
            {
                if (_defAccount == null || _defAccount.IsDisposed == true)
                {
                    //_defAccount = new Account.GUI.Account.frmCustomerInquiryList();
                    _defAccount.MdiParent = DefMDIMain;
                }
                return _defAccount;
            }
            set { _defAccount= value; }
        }

        public static Form DefTaxClass
        {
            get
            {
                if (_defTaxClass == null || _defTaxClass.IsDisposed == true)
                {
                    _defTaxClass = new Account.GUI.TaxClass.frmTaxClassList();
                    _defTaxClass.MdiParent = DefMDIMain;
                }
                return _defTaxClass;
            }
            set { _defTaxClass = value; }
        }

        #endregion
    }
}
