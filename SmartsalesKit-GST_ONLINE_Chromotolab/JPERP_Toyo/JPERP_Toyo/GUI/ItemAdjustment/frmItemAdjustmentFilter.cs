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

namespace Account.GUI.ItemAdjustment
{
    public partial class frmItemAdjustmentFilter : Account.GUIBase
    {

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        GodownBL objUserBL = new GodownBL();
        DataTable dtUser = new DataTable();
        DataTable dtFilter = new DataTable();
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
        public frmItemAdjustmentFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {

            AddHandlers(this);
            SetControlsDefaults(this);
            cmbStatus.SelectedIndex = 0;
            txtFromDate.Text = Common.CurrentUser.FYStartDate.ToString("dd/MM/yyyy");
            txtTodate.Text = Common.CurrentUser.FYEndDate.ToString("dd/MM/yyyy");
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

                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " AdjustDate >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " AdjustDate <= '" + txtTodate.Text.Trim() + "' And ";
                }

                if (cmbStatus.SelectedIndex > 0)
                {
                    StrFilter = StrFilter + " Status = '" + cmbStatus.Text + "' And ";
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
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }
        #region "Date time picker event"

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
