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

namespace Account.GUI.Vendor
{
    public partial class frmVendorFilter : Account.GUIBase
    {

       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);



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



        public frmVendorFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillVendorCategCombo(cmbcategory);
            objCommon.FillCityCombo(cmbCity);
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
                    StrFilter = StrFilter + " Code Like '%" + txtFromCode.Text.Trim() + "%' And ";
                }
                if (txtCompany.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Company Like '%" + PrepareFilterString(txtCompany.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
                }

                if (cmbcategory.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " category Like '%" + cmbcategory.Text.Trim() + "%' And ";
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
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }


        }





    }
}
