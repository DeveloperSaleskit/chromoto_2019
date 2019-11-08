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

namespace Account.GUI.SalesInvoice
{
    public partial class frmSalesInvoiceDispatchDetails : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        SalesInvoiceBL objPOBL = new SalesInvoiceBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtEmployee = new DataTable();
        int _Mode = 0;

        private static string mBONo;
        private static DateTime mBODate;
        private static string mDNoate;
        private static DateTime mDNoteDate;
        private static string mSRNo;
        private static string mDDNo;
        private static string mDT;
        private static string mD;
        private static DateTime mDtI;
        private static DateTime mDtR;
        private static string mTI;
        private static string mTR;
        private static string mShipAdd, mShipotherAdd;

        string _BONo = "";
        DateTime _BODate = DateTime.Today.Date;
        string _DNote = "";
        DateTime _DNoteDate = DateTime.Today.Date;
        string _SuRNo = "";
        string _DDNo = "";
        string _DT = "";
        string _D = "";
        DateTime _DtI = DateTime.Today.Date;
        DateTime _DtR = DateTime.Today.Date;
        string _TI = "";
        string _TR = "";
        string _ShipAdd = "";
        string _ShipOtherAdd = "";

        #endregion

        #region "Public Methods..."

        public static string BONo
        {
            get
            { return mBONo; }
            set
            { mBONo = value; }
        }
        public static DateTime BODate
        {
            get
            { return mBODate; }
            set
            { mBODate = value; }
        }
        public static string DNote
        {
            get
            { return mDNoate; }
            set
            { mDNoate = value; }
        }
        public static DateTime DNoteDate
        {
            get
            { return mDNoteDate; }
            set
            { mDNoteDate = value; }
        }
        public static string SuRNo
        {
            get
            { return mSRNo; }
            set
            { mSRNo = value; }
        }
        public static string DDNo
        {
            get
            { return mDDNo; }
            set
            { mDDNo = value; }
        }
        public static string DT
        {
            get
            { return mDT; }
            set
            { mDT = value; }
        }
        public static string D
        {
            get
            { return mD; }
            set
            { mD = value; }
        }
        public static DateTime DtI
        {
            get
            { return mDtI; }
            set
            { mDtI = value; }
        }
        public static DateTime DtR
        {
            get
            { return mDtR; }
            set
            { mDtR = value; }
        }
        public static string TI
        {
            get
            { return mTI; }
            set
            { mTI = value; }
        }
        public static string TR
        {
            get
            { return mTR; }
            set
            { mTR = value; }
        }

        public static string ShipAdd
        {
            get
            { return mShipAdd; }
            set
            { mShipAdd = value; }
        }

        public static string ShipotherAdd
        {
            get
            { return mShipotherAdd; }
            set
            { mShipotherAdd = value; }
        }


        public bool SetSave()
        {
            bool ReturnValue = false;
            if (DataValidator.IsValid(this.grpData))
            {
                if (DataValidator.IsValid(this.grpData))
                {
                    BONo = txtBuyerOrderNo.Text;
                    BODate = dtpOrderDate.Value;
                    DNote = txtDelNote.Text;
                    DNoteDate = dtpDeliveryDate.Value;
                    SuRNo = txtSupplierOrderNo.Text;
                    DDNo = txtDespDocNo.Text;
                    DT = txtDesTh.Text;
                    D = txtDestination.Text;
                    DtI = dtpIssue.Value;
                    TI = dtpIssueTime.Text;
                    DtR = dtpRemoval.Value;
                    TR = dtpRemovalTime.Text;
                    ShipAdd = txtShippingAdd.Text;
                    ShipotherAdd = txtShippingOtherAdd.Text;


                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {

                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {

                    }

                    if (objPOBL.Exception == null)
                    {
                        if (objPOBL.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = objPOBL.ErrorMessage;
                            txtBuyerOrderNo.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
                            lblErrorMessage.Text = "No error";
                            ReturnValue = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(objPOBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
            }
            return ReturnValue;
        }

        #endregion

        #region "Form Load events"

        public frmSalesInvoiceDispatchDetails(string BONo, DateTime BODate, string DNote, DateTime DNoteDate, string SuRNo,
            string DDNo, string DT, string D, DateTime DtI, DateTime DtR, string TI, string TR, int Mode, string ShipAdd, string ShipotherAdd)
        {
            InitializeComponent();
            _BONo = BONo;
            _BODate = BODate;
            _DNote = DNote;
            _DNoteDate = DNoteDate;
            _SuRNo = SuRNo;
            _DDNo = DDNo;
            _DT = DT;
            _D = D;
            _DtI = DtI;
            _DtR = DtR;
            _TI = TI;
            _TR = TR;
            _Mode = Mode;
            _ShipAdd = ShipAdd;
            _ShipOtherAdd = ShipotherAdd;
        }

        private void frmEmployeeEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                dtpDeliveryDate.Value = DateTime.Now;
                dtpIssue.Value = DateTime.Now;
                dtpIssueTime.Value = DateTime.Now;
                dtpOrderDate.Value = DateTime.Now;
                dtpRemoval.Value = DateTime.Now;
                dtpRemovalTime.Value = DateTime.Now;

                //dtpIssueTime.Format = DateTimePickerFormat.Custom;
                //dtpIssueTime.CustomFormat = "HH:mm:ss tt";
                //dtpIssueTime.Value = DateTime.Now.Date;
                dtpIssueTime.Format = DateTimePickerFormat.Time;
                dtpIssueTime.ShowUpDown = true;

                 dtpRemovalTime.Format = DateTimePickerFormat.Time;
                dtpRemovalTime.ShowUpDown = true;

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    this.Text = "Despatch Details- New";
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    this.Text = "Despatch Details - Edit";
                    BindControl();
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Employee-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        private void BindControl()
        {
            txtBuyerOrderNo.Text = _BONo;
            dtpOrderDate.Value = _BODate;
            txtDelNote.Text = _DNote;
            dtpDeliveryDate.Value = _DNoteDate;
            txtSupplierOrderNo.Text = _SuRNo;
            txtDespDocNo.Text = _DDNo;
            txtDesTh.Text = _DT;
            txtDestination.Text = _D;
            dtpIssue.Value = _DtI;
            dtpIssueTime.Text = _TI;
            dtpRemoval.Value = _DtR;
            dtpRemovalTime.Text = _TR;
            txtShippingAdd.Text = _ShipAdd;
            txtShippingOtherAdd.Text = _ShipOtherAdd;
        }

        #endregion

        #region "Button events"
        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtBuyerOrderNo.Text = "";
                txtDelNote.Text = "";
                txtSupplierOrderNo.Text = "";
                txtDespDocNo.Text = "";
                txtBuyerOrderNo.Focus();
            }
        }
        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Close();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }
        private void txtBudget_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {
                    txtTextbox.Text = Convert.ToDecimal(txtTextbox.Text).ToString("#0.00");
                    // Set Decimal Value after textbox's Leave Event
                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        lblErrorMessage.Text = "No error";
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99999999.99";
                        txtTextbox.Focus();
                    }
                }
                else
                {
                    txtTextbox.Text = "0.00";
                }
            }
            else
            {
                txtTextbox.Text = "0.00";
            }
        }
        #endregion

        private void lblCompanyName_Click(object sender, EventArgs e)
        {

        }

        private void txtShippingAdd_TextChanged(object sender, EventArgs e)
        {

        }




    }
}
