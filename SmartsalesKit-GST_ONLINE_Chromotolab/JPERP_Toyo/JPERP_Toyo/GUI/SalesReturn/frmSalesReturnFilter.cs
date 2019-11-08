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

namespace Account.GUI.SalesReturn
{
    public partial class frmSalesReturnFilter : Account.GUIBase
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


        public frmSalesReturnFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
         //   objCommon.FillCityCombo(cmbCity);
            objCommon.FillEmployeeCombo(cmbAttendedBy);
            objCommon.FillEmployeeCombo(cmbEmpAllocatedTo);
            objCommon.FillCategoryCombo(cmbCategory);
            objCommon.FillCityCombo(cmbCity);
            objCommon.FillStateCombo(cmbState);
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
                if (txtcontactperson.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ContactPerson Like '%" + PrepareFilterString(txtcontactperson.Text.Trim()) + "%' And ";
                }

                if (txtSrNo.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " SrNo Like '%" + PrepareFilterString(txtSrNo.Text.Trim()) + "%' And ";
                }

                if (txtmobile.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Mobile Like '%" + PrepareFilterString(txtmobile.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt64(cmbCategory.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " Category = '" + cmbCategory.Text + "' And ";
                }

                if (Convert.ToInt32(cmbEmpAllocatedTo.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " AllocatedToEmpID =" + cmbEmpAllocatedTo.SelectedValue + " And ";
                }

                if (Convert.ToInt32(cmbAttendedBy.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " EmpID =" + cmbAttendedBy.SelectedValue + " And ";
                }

                if (DataValidator.IsDate(txtInstFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " InstallationDate >= '" + txtInstFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtInstTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " InstallationDate <= '" + txtInstTodate.Text.Trim() + "' And ";
                }

                if (DataValidator.IsDate(txtAMCWrFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " ReminderDate >= '" + txtAMCWrFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtAMCWrTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " ReminderDate <= '" + txtAMCWrTodate.Text.Trim() + "' And ";
                }

                if (DataValidator.IsDate(txtAMCWrReminderFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " DCDate >= '" + txtAMCWrReminderFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtAMCWrReminderTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " DCDate <= '" + txtAMCWrReminderTodate.Text.Trim() + "' And ";
                }

                if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
                }

                if (cmbState.Text != "--Select--")
                {
                    StrFilter = StrFilter + " StateName = " + cmbState.Text + " And ";
                }
                //if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                //{
                //    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
                //}
                string Type = "";
                //Type = txtFromCode.Text.Substring(0, 2);

                if (cmbType.Text == "Retail")
                {
                    Type = "RI";
                    StrFilter = StrFilter + " SalesCode Like '%" + PrepareFilterString(Type.ToString().Trim()) + "%' And ";
                }

                if (cmbType.Text == "Tax")
                {
                    Type = "TI";
                    StrFilter = StrFilter + " SalesCode Like '%" + PrepareFilterString(Type.ToString().Trim()) + "%' And ";
                }

                if (cmbType.Text == "Estimate")
                {
                    Type = "ES";
                    StrFilter = StrFilter + " SalesCode Like '%" + PrepareFilterString(Type.ToString().Trim()) + "%' And ";
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

        private void dtpInstFromDate_CloseUp(object sender, EventArgs e)
        {
            txtInstFromDate.Text = dtpInstFromDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpInstTodate_CloseUp(object sender, EventArgs e)
        {
            txtInstTodate.Text = dtpInstTodate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpWFromDate_CloseUp(object sender, EventArgs e)
        {
            txtAMCWrFromDate.Text = dtpWFromDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpWTodate_CloseUp(object sender, EventArgs e)
        {
            txtAMCWrTodate.Text = dtpWTodate.Value.ToString("dd/MM/yyyy");
        }
        private void dtpWRTodate_CloseUp(object sender, EventArgs e)
        {
            txtAMCWrReminderTodate.Text = dtpWRTodate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpWRFromDate_CloseUp(object sender, EventArgs e)
        {
            txtAMCWrReminderFromDate.Text = dtpWRFromDate.Value.ToString("dd/MM/yyyy");
        }

       
    }
}
