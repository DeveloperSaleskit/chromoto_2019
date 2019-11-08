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

namespace Account.GUI.Customer
{
    public partial class frmCustomerFilter : Account.GUIBase
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


        public frmCustomerFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            
            //txtInquiryNO.Text = "";          
            //chksend.Checked = false;
            //chksendno.Checked = false;         
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

                if (txtCustomerName.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Company Like '%" + PrepareFilterString(txtCustomerName.Text.Trim()) + "%' And ";
                }

                if (txtPhone1.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Mobile Like '%" + PrepareFilterString(txtPhone1.Text.Trim()) + "%' And ";
                }              

                if (Convert.ToInt64(cmbCity.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " CityID = " + cmbCity.SelectedValue + " And ";
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
              
    }
}
