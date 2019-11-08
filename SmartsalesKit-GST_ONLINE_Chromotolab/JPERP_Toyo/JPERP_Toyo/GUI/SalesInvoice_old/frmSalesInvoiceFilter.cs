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

namespace Account.GUI.SalesInvoice
{
    public partial class frmSalesInvoiceFilter : Account.GUIBase
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


        public frmSalesInvoiceFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillCityCombo(cmbCity);
            objCommon.FillEmployeeCombo(cmbAttendedBy);
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
                if (txtFromCode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " SalesCode Like '%" + PrepareFilterString(txtFromCode.Text.Trim()) + "%' And ";
                }

                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " SalesDate >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " SalesDate <= '" + txtTodate.Text.Trim() + "' And ";
                }

                if (txtCompany.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtCompany.Text.Trim()) + "%' And ";
                }

                if (txtSrNo.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " SrNo Like '%" + PrepareFilterString(txtSrNo.Text.Trim()) + "%' And ";
                }
                if (Convert.ToInt32(cmbAttendedBy.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " EmpID =" + cmbAttendedBy.SelectedValue + " And ";
                }
                if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
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
            catch (Exception ex)
            {
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
