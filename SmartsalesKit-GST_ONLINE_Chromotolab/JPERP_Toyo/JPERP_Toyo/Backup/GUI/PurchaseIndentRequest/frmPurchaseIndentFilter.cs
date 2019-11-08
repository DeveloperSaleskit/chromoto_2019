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

namespace Account.GUI.PurchaseIndentRequest
{
    public partial class frmPurchaseIndentFilter : Account.GUIBase
    {
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        GodownBL objUserBL = new GodownBL();
        DataTable dtUser = new DataTable();
        DataTable dtFilter = new DataTable();
        int _Mode = 0;
        DataView DV;
        string StrFilter = "";
        BusinessLogic.Common objCommon = new BusinessLogic.Common();
        private string mSTRFILTER = "";

        public string STRFILTER
        {
            get
            { return mSTRFILTER; }
            set
            { mSTRFILTER = value; }
        }


        public frmPurchaseIndentFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dtpFromDate.Value = DateTime.Now;
            dtpTodate.Value = DateTime.Now;
           
            txtFromDate.Text = "";
            txtTodate.Text = "";
            //chksendno.Checked = false;

           
            if (objCommon.Exception != null)
            {
                MessageBox.Show(objCommon.Exception.Message.ToString());
                return;
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                StrFilter = "";

                if (txtitemcode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " itemcode Like '%" + PrepareFilterString(txtitemcode.Text.Trim()) + "%' And ";
                }

                if (txtproductcode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " productcode Like '%" + PrepareFilterString(txtproductcode.Text.Trim()) + "%' And ";
                }

                if (txtsrno.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " SrNo Like '%" + PrepareFilterString(txtsrno.Text.Trim()) + "%' And ";
                }

                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " IndentDate >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " IndentDate <= '" + txtTodate.Text.Trim() + "' And ";
                }

                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }
                DV = dtFilter.DefaultView;
                DV.RowFilter = StrFilter;
                STRFILTER = StrFilter;
                this.Dispose();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #region "DatePicker events"

        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
            txtFromDate.Text = dtpFromDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpTodate_CloseUp(object sender, EventArgs e)
        {
            txtTodate.Text = dtpTodate.Value.ToString("dd/MM/yyyy");
        }

        #endregion

      
    }
}
