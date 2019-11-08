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
using System.Configuration;

namespace Account.GUI.PromoMail
{
    public partial class frmPromoMailSend : Account.GUIBase
    {
        #region "Variable Declarations..."
        Exception mException = null;
        string mErrorMsg = "";
        DataTable dtblLOV = new DataTable();
        CommonListBL CommList = new CommonListBL();
        CommonListBL objList = new CommonListBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        PromoMailSendBL objPromoMailSendBL = new PromoMailSendBL();
        SalesInvoiceBL objSalesBL = new SalesInvoiceBL();
        ServiceModuleBL objServicesBL = new ServiceModuleBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        DataTable dtPromoMail = new DataTable();
        DataTable _dtPromoSend = new DataTable();
        int _Count;
        string StrFilter = "";
        string _PM = "";
        string _PCustomer = "";
        string _PMobile = "";
        string _PCategory= "";
        int _CompId = 0;
        DataView DV;
        NameValueCollection para1 = new NameValueCollection();
        Int16 Asci;
        Int64 mItemID;
        string mItemCode;
        string mItemName;
        string mPMail;
        string mPCustomerName;
        string mPMobile;
        string mPCategory;
        decimal _Height;
        decimal _Width;

        public NameValueCollection _para;
        //public string PMail;
        //public string _Code;
        //public string _FormName;
        public string MTYPE_OF_FORM;

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
        public string PMail
        {
            get { return mPMail; }
            set { mPMail = value; }
        }
        public string PCustomerName
        {
            get { return mPCustomerName; }
            set { mPCustomerName = value; }
        }

        public string PMobile
        {
            get { return mPMobile; }
            set { mPMobile = value; }
        }

        public string PCategory
        {
            get { return mPCategory; }
            set { mPCategory = value; }
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

        public void  LoadList()
        {

           
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            DataTable dtPromoLoad = new DataTable();
            dtPromoLoad = objList.ListOfRecord("usp_PromoMailLead_List", para1, "Promo Mail - Select");
            if (dtPromoLoad.Rows.Count > 0)
            {
                dgvLOV.Columns["CustomerName"].DataPropertyName = dtPromoLoad.Columns["CustomerName"].ToString();
                dgvLOV.Columns["Email"].DataPropertyName = dtPromoLoad.Columns["Email"].ToString();
                dgvLOV.Columns["Mobile"].DataPropertyName = dtPromoLoad.Columns["Mobile"].ToString();
                dgvLOV.Columns["Category"].DataPropertyName = dtPromoLoad.Columns["Category"].ToString();
                dgvLOV.Columns["CompId"].DataPropertyName = dtPromoLoad.Columns["CompId"].ToString();
            }
            dgvLOV.AutoGenerateColumns = false;
            dgvLOV.DataSource = dtPromoLoad;
            dgvLOV.MultiSelect = true;

            if (_Count == 1 || _dtPromoSend.Rows.Count>0)
            {
                if (_dtPromoSend.Rows.Count > 0)
                {
                    for (int i = 0; i < _dtPromoSend.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvLOV.RowCount; j++)
                        {
                            if (_dtPromoSend.Rows[i]["Email"].ToString().Trim() == dtPromoLoad.Rows[j]["Email"].ToString().Trim() && _dtPromoSend.Rows[i]["CustomerName"].ToString().Trim() == dtPromoLoad.Rows[j]["CustomerName"].ToString().Trim() && _dtPromoSend.Rows[i]["Mobile"].ToString().Trim() == dtPromoLoad.Rows[j]["Mobile"].ToString().Trim() && _dtPromoSend.Rows[i]["Category"].ToString().Trim() == dtPromoLoad.Rows[j]["Category"].ToString().Trim())
                            {
                                dgvLOV.Rows[j].Cells[0].Value = true;

                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region "Form Events.."

        public frmPromoMailSend(DataTable dtPromoSend, int Count)
        {
            InitializeComponent();
            _dtPromoSend = dtPromoSend;
            _Count = Count;
        }

        private void frmItemLOV_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvLOV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLOV.MultiSelect = true;
            LoadList();
            dgvLOV.ReadOnly = false;
        }

        #endregion

        #region "Button Event..."

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvLOV.CurrentRow != null)
            {
                _dtPromoSend.Clear();
                if (_dtPromoSend.Columns.Count == 0)
                {
                    _dtPromoSend.Columns.Add("CustomerName");
                    _dtPromoSend.Columns.Add("Email");
                    _dtPromoSend.Columns.Add("Mobile");
                    _dtPromoSend.Columns.Add("Category");
                }
                for (int i = 0; i <= dgvLOV.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                    {
                        if (_PM.Trim() != "" && _PCustomer.Trim() != "")
                        // && _PMobile.Trim() != "" && _PCategory.Trim() != ""
                        {
                            _PM = _PM + ",";
                            _PCustomer = _PCustomer + ",";
                            _PMobile = _PMobile + ",";
                            _PCategory = _PCategory + ",";
                        }
                        _PCustomer = _PCustomer + dgvLOV.Rows[i].Cells[1].Value.ToString();
                        _PM = _PM + dgvLOV.Rows[i].Cells[2].Value.ToString();                        
                        _PMobile = _PMobile + dgvLOV.Rows[i].Cells[3].Value.ToString();
                        _PCategory = _PCategory + dgvLOV.Rows[i].Cells[4].Value.ToString();

                        _dtPromoSend.Rows.Add(dgvLOV.Rows[i].Cells["CustomerName"].Value.ToString(), dgvLOV.Rows[i].Cells["Email"].Value.ToString(), dgvLOV.Rows[i].Cells["Mobile"].Value.ToString(), dgvLOV.Rows[i].Cells["Category"].Value.ToString());
                    }
                    else if (chkSelectAll.Checked == true)
                    {
                        //DataTable dtSendToAll = objDA.ExecuteDataTableSP("usp_PromoMailLead_List", null, false, ref mException, ref mErrorMsg, "Send To All");
                        if (_PM.Trim() != "" && _PCustomer.Trim() != "")
                        {
                            _PM = _PM + ",";
                            _PCustomer = _PCustomer + ",";
                            _PMobile = _PMobile + ",";
                            _PCategory = _PCategory + ",";
                        }
                        _PCustomer = _PCustomer + dgvLOV.Rows[i].Cells[1].Value.ToString();
                        _PM = _PM + dgvLOV.Rows[i].Cells[2].Value.ToString();
                        _PMobile = _PMobile + dgvLOV.Rows[i].Cells[2].Value.ToString();
                        _PCategory = _PCategory + dgvLOV.Rows[i].Cells[1].Value.ToString();
                        
                        _dtPromoSend.Rows.Add(dgvLOV.Rows[i].Cells["CustomerName"].Value.ToString(), dgvLOV.Rows[i].Cells["Email"].Value.ToString(), dgvLOV.Rows[i].Cells["Mobile"].Value.ToString(), dgvLOV.Rows[i].Cells["Category"].Value.ToString());
                    }
                }
                PMail = _PM.Substring(0, _PM.Length);
                PCustomerName = _PCustomer.Substring(0, _PCustomer.Length);
                PMobile = _PMobile.Substring(0, _PMobile.Length);
                PCategory = _PCategory.Substring(0, _PCategory.Length);
            }
            this.Close();
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
                Utill.Common.ExceptionLogger.writeException("Promo Mail", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "SearchBox"
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                Load_Serach();
            }
            else
            {
                StrFilter = "";
                DV = dtblLOV.DefaultView;
                DV.RowFilter = StrFilter;
                dgvLOV.DataSource = DV.ToTable();
            }
        }

        public void Load_Serach()
        {
            try
            {
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtblLOV = objList.ListOfRecord("usp_PromoMailLead_List", para1, "Promo Mail - Select");

                StrFilter = "";

                if (txtSearch.Text.Trim() != "")
                {
                    //StrFilter = StrFilter + " Customer Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                    StrFilter = StrFilter + " CustomerName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' OR ";
                }
                if (txtSearch.Text.Trim() != "")
                {
                    StrFilter = StrFilter + " Email Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
                }
                if (StrFilter != "")
                {
                    StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                }

                DV = dtblLOV.DefaultView;
                DV.RowFilter = StrFilter;

                dgvLOV.DataSource = DV.ToTable();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Promo Mail", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        #endregion
        
    }

}
