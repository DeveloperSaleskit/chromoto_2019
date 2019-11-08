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

namespace Account.GUI.Quotation
{
    public partial class frmQuotationFilter : Account.GUIBase
    {
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        //GodownBL objUserBL = new GodownBL();
        DataTable dtUser = new DataTable();
        DataTable dtFilter = new DataTable();
        int _Mode = 0;
        DataView DV;
        string StrFilter = "";
        BusinessLogic.Common objCommon = new BusinessLogic.Common();



        public frmQuotationFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            txtCustomer.Text = "";
            txtFromDate.Text = "";
            txtTodate.Text = "";
            objCommon.FillCityCombo(cmbCity);
            objCommon.FillStateCombo(cmbState);
            objCommon.FillEmployeeCombo(cmbEmp);
            objCommon.FillEmployeeCombo(cmbEmpAllocatedTo);
            objCommon.FillCategoryCombo(cmbCategory);
            objCommon.FillSourceOfLeadCombo(cmbSI);
            objCommon.FillInqResponse(cmbInterestLevel);

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

                if (txtCode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Code LIKE '%" + PrepareFilterString(txtCode.Text.Trim()) + "%' And ";
                }

                if (txtCustomer.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " CustomerName LIKE '%" + PrepareFilterString(txtCustomer.Text.Trim()) + "%' And ";
                }
                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " QDate >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " QDate <= '" + txtTodate.Text.Trim() + "' And ";
                }
                if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
                }

                if (cmbState.Text!="--Select--")
                {
                    //StrFilter = StrFilter + " StateName = " + cmbState.Text + " And ";
                    StrFilter = StrFilter + " StateName Like '%" + PrepareFilterString(cmbState.Text.Trim()) + "%' And ";
                }

                if (txtPhone1.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Mobile Like '%" + PrepareFilterString(txtPhone1.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt64(cmbCategory.SelectedIndex) > 0)
                {
                    //StrFilter = StrFilter + " Category = '" + cmbCategory.Text + "' And ";
                    StrFilter = StrFilter + " Category Like '%" + PrepareFilterString(cmbCategory.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt64(cmbInterestLevel.SelectedIndex) > 0)
                {
                    //StrFilter = StrFilter + " Status = '" + cmbInterestLevel.Text + "' And ";
                    StrFilter = StrFilter + " InqResponse Like '%" + PrepareFilterString(cmbInterestLevel.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt32(cmbEmpAllocatedTo.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " AllocatedToEmpID =" + cmbEmpAllocatedTo.SelectedValue + " And ";
                }

                if (Convert.ToInt64(cmbEmp.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " EmpID = " + cmbEmp.SelectedValue + " And ";
                }

                if (DataValidator.IsDate(txtNFFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " FollowUpDate1 >= '" + txtNFFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtNFTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " FollowUpDate1 <= '" + txtNFTodate.Text.Trim() + "' And ";
                }

                if (Convert.ToInt64(cmbSI.SelectedIndex) > 0)
                {
                    //StrFilter = StrFilter + " SourceOfLead = '" + cmbSI.Text + "' And ";
                    StrFilter = StrFilter + " SourceOfLead Like '%" + PrepareFilterString(cmbSI.Text.Trim()) + "%' And ";
                }

                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }
                DV = dtFilter.DefaultView;
                 DV.RowFilter = StrFilter;
                this.Dispose();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation -List", exc.StackTrace);
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

        private void dtpNFFromDate_CloseUp(object sender, EventArgs e)
        {
            txtNFFromDate.Text = dtpNFFromDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpNFTodate_CloseUp(object sender, EventArgs e)
        {
            txtNFTodate.Text = dtpNFTodate.Value.ToString("dd/MM/yyyy");
        }

      
    }
}
