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

namespace Account.GUI.ItemStock
{
    public partial class frmItemStockFilter : Account.GUIBase
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

        public frmItemStockFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {

            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillLowStockDDL(cmbLowStock);
            objCommon.FillGodownCombo(cmbgodown);
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
                if (txtpcode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ProductCode LIKE '%" + PrepareFilterString(txtpcode.Text.Trim()) + "%' And ";
                }

                if (txtFromCode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ItemCode LIKE '%" + PrepareFilterString(txtFromCode.Text.Trim()) + "%' And ";
                }

                if (txtItemName.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " ItemName Like '%" + PrepareFilterString(txtItemName.Text.Trim()) + "%' And ";
                }

                if (Convert.ToInt64(cmbgodown.SelectedIndex) > 0)
                {
                    StrFilter = StrFilter + " GodownID = " + cmbgodown.SelectedValue + " And ";
                }

                if (cmbLowStock.SelectedIndex > 0)
                {
                    switch (cmbLowStock.SelectedIndex)
                    {
                        case 1:
                            // Current Stock is Below Minimum Level ...
                            StrFilter += "  QOH <= MinLevel AND ";
                            break;
                        case 2:
                            // Minimum Level is 0 ...
                            StrFilter += "  MinLevel = 0 AND";
                            break;
                        case 3:
                            // Maximum Level is 0 ...
                            StrFilter += "  MaxLevel = 0 AND";
                            break;
                        case 4:
                            // Reorder Level is 0 ...
                            StrFilter += "  ReOrderLvl = 0 AND";
                            break;
                        case 5:
                            // Location is not Defined ...
                            StrFilter += " ( Location = '' OR  Location IS NULL) AND";
                            break;
                    }
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
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }


    }
}
