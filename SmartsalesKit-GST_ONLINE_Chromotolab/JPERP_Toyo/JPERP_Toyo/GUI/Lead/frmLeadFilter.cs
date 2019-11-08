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

namespace Account.GUI.Lead
{
    public partial class frmLeadFilter : Account.GUIBase
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


        public frmLeadFilter(DataTable dtdetail)
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
            objCommon.FillSourceOfLeadCombo(cmbSI);
            //txtInquiryNO.Text = "";
            txtFromDate.Text = "";
            txtTodate.Text = "";
            txtCustomerName.Text = "";
            cmbSI.SelectedIndex = 0;
            //chksend.Checked = false;
            //chksendno.Checked = false;

            objCommon.FillCategoryCombo(cmbCategory);
            objCommon.FillCityCombo(cmbCity);
            objCommon.FillStateCombo(cmbState);
            objCommon.FillEmployeeCombo(cmbAttendedBy);
            objCommon.FillEmployeeCombo(cmbEmpAllocatedTo);
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

                if (txtCustomerName.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtCustomerName.Text.Trim()) + "%' And ";
                }

                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " LeadDate >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " LeadDate <= '" + txtTodate.Text.Trim() + "' And ";
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

                if (Convert.ToInt64(cmbSI.SelectedIndex) > 0)
                {
                    //StrFilter = StrFilter + " SourceOfLead = '" + cmbSI.Text + "' And ";
                    StrFilter = StrFilter + " SourceOfLead Like '%" + PrepareFilterString(cmbSI.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt64(cmbInterestLevel.SelectedIndex) > 0)
                {
                    //StrFilter = StrFilter + " LeadStatus = '" + cmbInterestLevel.Text + "' And ";
                    StrFilter = StrFilter + " InqResponse Like '%" + PrepareFilterString(cmbInterestLevel.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt32(cmbAttendedBy.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " EmpID =" + cmbAttendedBy.SelectedValue + " And ";
                }

                if (Convert.ToInt32(cmbEmpAllocatedTo.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " AllocatedToEmpID =" + cmbEmpAllocatedTo.SelectedValue + " And ";
                }

                if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
                }

                //if (Convert.ToInt64(cmbState.SelectedIndex) > 0)
                //{
                //    StrFilter = StrFilter + " StateID = " + cmbState.SelectedValue + " And ";
                //}

                if (cmbState.Text != "--Select--")
                {
                    //StrFilter = StrFilter + " StateName = " + cmbState.Text + " And ";
                    StrFilter = StrFilter + " StateName Like '%" + PrepareFilterString(cmbState.Text.Trim()) + "%' And ";
                }

                //if (txtInquiryNO.Text.Trim() != "")
                //{
                //    StrFilter = StrFilter + " LeadNo Like '%" + PrepareFilterString(txtInquiryNO.Text.Trim()) + "%' And ";
                //}
              
                //if (chksend.Checked)
                //{
                //    StrFilter = StrFilter + " Quotation_Send = '" + true + "' And ";
                //}
                //if (chksendno.Checked)
                //{
                //    StrFilter = StrFilter + " Quotation_Send ='" + false + "' And ";
                //}            
                       
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
