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

namespace Account.GUI.ItemRegister
{
    public partial class frmItemFilter : Account.GUIBase
    {
        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        GodownBL objUserBL = new GodownBL();
        DataTable dtUser = new DataTable();
        DataTable dtFilter = new DataTable();
        DataTable dtCustomerFilter = new DataTable();
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

        public frmItemFilter(DataTable dtdetail, DataTable dtCustomerQdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
            dtCustomerFilter = dtCustomerQdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
            objCommon.FillUOMDDL(cmdUOM);
            AddHandlers(this);
            SetControlsDefaults(this);

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
                if (txtproductcode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ProductCode Like '%" + PrepareFilterString(txtproductcode.Text.Trim()) + "%' And ";
                }
                if (txtItemCode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " iCode Like '%" + PrepareFilterString(txtItemCode.Text.Trim()) + "%' And ";
                }
                if (txtItemName.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ITEMNAME Like '%" + PrepareFilterString(txtItemName.Text.Trim()) + "%' And ";
                }
                if (cmdUOM.SelectedIndex > 0)
                {
                    StrFilter = StrFilter + " UOMID =" + cmdUOM.SelectedValue + " And ";
                }

                if (txtCustomer.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtCustomer.Text.Trim()) + "%' And ";
                }

                if (DataValidator.IsDate(txtFromDate.Text.Trim()))
                {
                    StrFilter = StrFilter + " DATE >= '" + txtFromDate.Text.Trim() + "' And ";
                }
                if (DataValidator.IsDate(txtTodate.Text.Trim()))
                {
                    StrFilter = StrFilter + " DATE <= '" + txtTodate.Text.Trim() + "' And ";
                }

                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }

                //if (txtCustomer.Text.Trim() != "" && txtItemCode.Text.Trim() == "" && txtItemName.Text.Trim() == "" && cmdUOM.SelectedIndex == 0)
                if (txtCustomer.Text.Trim() != "" || txtItemName.Text.Trim() != "" && cmdUOM.SelectedIndex == 0 && txtproductcode.Text.Trim() != "")
                {
                    if (txtCustomer.Text.Trim() == "" && txtItemName.Text.Trim() != "" && cmdUOM.SelectedIndex == 0 && txtproductcode.Text.Trim() != "")
                    {
                        DV = dtFilter.DefaultView;
                        DV.RowFilter = StrFilter;
                    }
                    else
                    {
                        if (txtItemCode.Text.Trim() != "" || cmdUOM.SelectedIndex != 0 ||  txtproductcode.Text.Trim() != ""  )
                        {
                            DV = dtFilter.DefaultView;
                            DV.RowFilter = StrFilter;
                        }
                        else
                        {
                            DV = dtCustomerFilter.DefaultView;
                            DV.RowFilter = StrFilter;
                        }
                    }
                }
                else if (txtCustomer.Text.Trim() == "" && txtItemName.Text.Trim() != "" && cmdUOM.SelectedIndex == 0 && txtproductcode.Text.Trim() != "")
                {
                    DV = dtFilter.DefaultView;
                    DV.RowFilter = StrFilter;
                }
                else
                {
                    if (txtItemCode.Text.Trim() != "" || cmdUOM.SelectedIndex != 0 || txtproductcode.Text.Trim() != "")
                    {
                        DV = dtFilter.DefaultView;
                        DV.RowFilter = StrFilter;
                    }
                    else
                    {
                        DV = dtCustomerFilter.DefaultView;
                        DV.RowFilter = StrFilter;
                    }
                }

                STRFILTER = StrFilter;
                this.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        private void dtpFromDate_CloseUp(object sender, EventArgs e)
        {
            txtFromDate.Text = dtpFromDate.Value.ToString("dd/MM/yyyy");
        }

        private void dtpTodate_CloseUp(object sender, EventArgs e)
        {
            txtTodate.Text = dtpTodate.Value.ToString("dd/MM/yyyy");
        }


    }
}
