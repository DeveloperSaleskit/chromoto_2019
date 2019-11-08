using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;

namespace Account
{
    public partial class frmTNCLOV : Account.GUIBase
    {
        #region "Variable Declarations..."
        Exception mException = null;
        string mErrorMsg = "";
        DataTable dtblLOV = new DataTable();
        CommonListBL CommList = new CommonListBL();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        QuotationBL objQuotationBL = new QuotationBL();
        SalesInvoiceBL objSalesBL = new SalesInvoiceBL();
        ServiceModuleBL objServicesBL = new ServiceModuleBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        DataTable dtQTNC = new DataTable();
        string StrFilter = "";
        DataView DV;

        Int16 Asci;
        Int64 mItemID;
        string mItemCode;
        string mItemName;

        decimal _Height;
        decimal _Width;

        public NameValueCollection _para;
        public string _spName;
        public string _Code;
      //  public string _IsAllTNC;
        public string _FormName;
        public string MTYPE_OF_FORM;
        public string IsAllTNC_Check = "False";

        #endregion

        #region "Public Property..."

        public Int64 ItemID
        {
            get { return mItemID; }
            set { mItemID = value; }
        }

        public string ItemCode
        {
            get { return mItemCode; }
            set { mItemCode = value; }
        }

        public string TYPE_OF_SALE
        {
            get { return MTYPE_OF_FORM; }
            set { MTYPE_OF_FORM = value; }
        }

        public string ItemName
        {
            get { return mItemName; }
            set { mItemName = value; }
        }

        public decimal ItemHeight
        {
            get { return _Height; }
            set { _Height = value; }
        }

        public decimal ItemWidth
        {
            get { return _Width; }
            set { _Width = value; }
        }

        #endregion

        #region "Private Methods..."

        public void LoadList()
        {
            if (cmbTNCSub.SelectedIndex > 0)
            {
                if (dgvLOV.Rows.Count > 0)
                {
                    dgvLOV.DataSource = null;
                }
                DataTable dtTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_TNC_Sub", cmbTNCSub.Text);
                dtTNC = objList.ListOfRecord("usp_TNC_LOV", para, "Terms And Conditions - Select");
                if (dtTNC.Rows.Count > 0)
                {
                    dgvLOV.Columns["TNC_Desc"].DataPropertyName = dtTNC.Columns["TNC_Desc"].ToString();
                    dgvLOV.Columns["TNCID"].DataPropertyName = dtTNC.Columns["TNCID"].ToString();
                }
                dgvLOV.AutoGenerateColumns = false;
                dgvLOV.DataSource = dtTNC;
                dgvLOV.MultiSelect = true;                

                    if (dtQTNC.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtQTNC.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvLOV.RowCount; j++)
                            {
                                if (dtQTNC.Rows[i]["TNC_Desc"].ToString().Trim() == dgvLOV.Rows[j].Cells["TNC_Desc"].Value.ToString().Trim())
                                {
                                    dgvLOV.Rows[j].Cells[0].Value = true;
                                }
                            }
                        }
                    }
            }
           
        }

        private void ArrangeDataGridView()
        {
            dgvLOV.Columns["GridItemID"].DataPropertyName = dtblLOV.Columns["ItemID"].ToString();
            dgvLOV.Columns["GridItemCode"].DataPropertyName = dtblLOV.Columns["ItemCode"].ToString();
            dgvLOV.Columns["GridItemName"].DataPropertyName = dtblLOV.Columns["ItemName"].ToString();

            if (_spName == "usp_Quotation_BOM_DDL")
            {
                dgvLOV.Columns["GridHeight"].DataPropertyName = dtblLOV.Columns["Height"].ToString();
                dgvLOV.Columns["GridWidth"].DataPropertyName = dtblLOV.Columns["Width"].ToString();
            }

        }

        //public void Load_Serach()
        //{
        //    StrFilter = "";
        //    if (txtSearch.Text.Trim() != "")
        //    {
        //        StrFilter = StrFilter + " ItemCode Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
        //    }

        //    if (txtSearch.Text.Trim() != "")
        //    {
        //        StrFilter = StrFilter + " ItemName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' And ";
        //    }

        //    if (StrFilter != "")
        //    {
        //        StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
        //    }

        //    DV = dtblLOV.DefaultView;
        //    DV.RowFilter = StrFilter;

        //    dgvLOV.DataSource = DV.ToTable();
        //    ArrangeDataGridView();
        //}

        #endregion

        #region "Form Events.."

        public frmTNCLOV(string SpName, NameValueCollection para, string Code,string FormName)
        {
            InitializeComponent();
            _spName = SpName;
            _para = para;
            _Code = Code;         
            _FormName = FormName;
        }

        private void frmItemLOV_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillTNCSubCombo(cmbTNCSub);
            dgvLOV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLOV.MultiSelect = true;
            if (_spName == "usp_QuotationTNC_Select")
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", _Code);
                dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
                if (dtQTNC.Rows.Count > 0)
                {
                    cmbTNCSub.Text = dtQTNC.Rows[0]["TNC_Sub"].ToString();
                }               
                
            }
            else if (_spName == "usp_SalesTNC_Select")
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", _Code);
                dtQTNC = objDA.ExecuteDataTableSP("usp_SalesTNC_Select", para, false, ref mException, ref mErrorMsg, "Sales TNC - Select");
                if (dtQTNC.Rows.Count > 0)
                {
                    cmbTNCSub.Text = dtQTNC.Rows[0][0].ToString();
                }
            }
            else if (_spName == "usp_ServicesTNC_Select")
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", _Code);
                dtQTNC = objDA.ExecuteDataTableSP("usp_ServicesTNC_Select", para, false, ref mException, ref mErrorMsg, "Services TNC - Select");
                if (dtQTNC.Rows.Count > 0)
                {
                    cmbTNCSub.Text = dtQTNC.Rows[0][0].ToString();
                }
            }
            else if (_spName == "usp_TNC_LOV")
            {
                if (_FormName == "QUOTATION")
                {
                    cmbTNCSub.SelectedIndex = 1;
                }
                else if (_FormName == "SALES")
                {
                    cmbTNCSub.SelectedIndex = 2;
                }
                else  if (_FormName == "SERVICE")
                {
                    cmbTNCSub.SelectedIndex = 3;
                }
                cmbTNCSub.Enabled = false;

            }
            LoadList();
            dgvLOV.ReadOnly = false;
            cmbTNCSub.Enabled = false;
            chkTNC.Checked = false;
        }

        #endregion

        #region "Button Event..."

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MTYPE_OF_FORM = cmbTNCSub.Text;
            if (dgvLOV.CurrentRow != null)
            {
                Boolean delflag = false;
                Boolean insertflag = false;
                if (DialogResult == System.Windows.Forms.DialogResult.None)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    int checkcount = 0;
                    for (int i = 0; i <= dgvLOV.Rows.Count - 1; i++)
                    {                       

                        if (dtQTNC.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtQTNC.Rows.Count; j++)
                            {
                                if (dgvLOV.Rows[i].Cells[1].Value.ToString().Trim() == dtQTNC.Rows[j][1].ToString().Trim())
                                {
                                    insertflag = false;
                                    if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == false)
                                    {
                                        delflag = true;
                                        break;
                                    }
                                    break;
                                }
                                else
                                {
                                    if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                                    {
                                        insertflag = true;
                                    }
                                }
                            }
                            if (delflag == true)
                            {
                                if (_spName == "usp_QuotationTNC_Select")
                                {
                                    objQuotationBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    delflag = false;
                                }
                                else if (_spName == "usp_SalesTNC_Select")
                                {
                                    objSalesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    delflag = false;
                                }
                                else if (_spName == "usp_ServicesTNC_Select")
                                {
                                    objServicesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    delflag = false;
                                }
                            }
                            if (insertflag == true)
                            {
                                if (_spName == "usp_QuotationTNC_Select")
                                {
                                    objQuotationBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells["TNC_Desc"].Value.ToString(), _Code, Convert.ToInt16(dgvLOV.Rows[i].Cells["TNCID"].Value.ToString()));
                                    insertflag = false;
                                }
                                else if (_spName == "usp_SalesTNC_Select")
                                {
                                    objSalesBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    insertflag = false;
                                }
                                else if (_spName == "usp_ServicesTNC_Select")
                                {
                                    objServicesBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    insertflag = false;
                                }
                            }
                        }
                        else
                        {                           

                                if (_Code.Substring(3, 2) == "QU")
                                {
                                    if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                                    {
                                        objQuotationBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[2].Value.ToString(), _Code, Convert.ToInt16(dgvLOV.Rows[i].Cells[1].Value.ToString()));
                                    }
                                }
                                else if (_Code.Substring(0, 2) == "RI" || _Code.Substring(0, 2) == "CM" || _Code.Substring(0, 2) == "TI")
                                {
                                    if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                                    {
                                        objSalesBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    }
                                }
                                else if (_Code.Substring(0, 2) == "SR")
                                {
                                    if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                                    {
                                        objServicesBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    }
                                }
                        }                       
                    }                   
                    this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region "GridView Event..."

        private void dgvLOV_DoubleClick(object sender, EventArgs e)
        {

            btnSelect_Click(sender, e);
        }

        private void dgvLOV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Asci = (Int16)e.KeyChar;
            if (Asci != 13 && Asci != 27)
            {
                btnSelect_Click(sender, e);
            }
        }

        private void dgvLOV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvLOV, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvLOV, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemLOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Combo Event..."

        private void cmbTNCSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        #endregion

        private void btnNewTNC_Click(object sender, EventArgs e)
        {

            try
            {
                GUI.TermsNConditions.frmTermsNConditionsEntry fTNC = new GUI.TermsNConditions.frmTermsNConditionsEntry((int)Constant.Mode.Modify, cmbTNCSub.Text);
                fTNC.ShowInTaskbar = false;
                fTNC.ShowDialog();
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("TNC", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void chkTNC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTNC.Checked == true)
            {
                
            }
            else
            {
                
            }
        }

    }

}
