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

namespace Account.GUI.AccountMaster
{
    public partial class frmAccountFilter : Account.GUIBase
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

        public frmAccountFilter(DataTable dtdetail)
        {
            InitializeComponent();
            dtFilter = dtdetail;
        }

        private void frmGodownEntry_Load(object sender, EventArgs e)
        {
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
                if (txtAccountCode.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " AccountCode Like '%" + txtAccountCode.Text.Trim() + "%' And ";
                }
                if (txtAccountName.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " AccountName Like '%" + PrepareFilterString(txtAccountName.Text.Trim()) + "%' And ";
                }
                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }

                DV = dtFilter.DefaultView;
                DV.RowFilter = StrFilter;
                this.Dispose();
                //dgvAccount.DataSource = DV.ToTable();
                //lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvAccount.RowCount.ToString();

                //ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Account", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

       
    }
}
