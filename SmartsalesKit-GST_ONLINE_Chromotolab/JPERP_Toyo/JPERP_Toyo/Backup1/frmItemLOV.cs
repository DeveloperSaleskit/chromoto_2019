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

    public partial class frmItemLOV : Account.GUIBase
    {
        #region "Variable Declarations..."

        DataTable dtblLOV = new DataTable();
        CommonListBL CommList = new CommonListBL();

        string StrFilter = "";
        DataView DV;

        Int16 Asci;
        Int64 mItemID;
        string mItemCode;
        string mItemName,mSpecification;

        decimal _Height;
        decimal _Width;

        public NameValueCollection _para;
        public string _spName;

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

        public string ItemName
        {
            get { return mItemName; }
            set { mItemName = value; }
        }

        public string Specification
        {
            get { return mSpecification; }
            set { mSpecification = value; }
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

           
            dtblLOV = CommList.ListOfRecord(_spName, _para, "ItemLOV - LoadList");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ArrangeDataGridView();
                dgvLOV.AutoGenerateColumns = false;
                dgvLOV.DataSource = dtblLOV;
                ArrangeDataGridView();
            }
        }

        private void ArrangeDataGridView()
        {
            dgvLOV.Columns["GridItemID"].DataPropertyName = dtblLOV.Columns["ItemID"].ToString();
            dgvLOV.Columns["GridItemCode"].DataPropertyName = dtblLOV.Columns["ItemCode"].ToString();
            dgvLOV.Columns["GridItemName"].DataPropertyName = dtblLOV.Columns["ItemName"].ToString();
            //dgvLOV.Columns["GridSpecification"].DataPropertyName = dtblLOV.Columns["Specification"].ToString();
            if (_spName == "usp_Quotation_BOM_DDL")
            {
                dgvLOV.Columns["GridHeight"].DataPropertyName = dtblLOV.Columns["Height"].ToString();
                dgvLOV.Columns["GridWidth"].DataPropertyName = dtblLOV.Columns["Width"].ToString();
            }
            
        }

        public void Load_Serach()
        {
            StrFilter = "";
            if (txtSearch.Text.Trim() != "")
            {
                StrFilter = StrFilter + " ItemCode Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' Or ";
            }

            if (txtSearch.Text.Trim() != "")
            {
                StrFilter = StrFilter + " ItemName Like '%" + PrepareFilterString(txtSearch.Text.Trim()) + "%' And ";
            }

            if (StrFilter != "")
            {
                StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
            }

            DV = dtblLOV.DefaultView;
            DV.RowFilter = StrFilter;

            dgvLOV.DataSource = DV.ToTable();
            ArrangeDataGridView();
        }

        #endregion

        #region "Form Events.."

        public frmItemLOV(string SpName, NameValueCollection para)
        {
            InitializeComponent();
            _spName = SpName;
            _para = para;
        }

        private void frmItemLOV_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            LoadList();
        }

        #endregion

        #region "Button Event..."

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvLOV.CurrentRow != null)
            {
                if (DialogResult == System.Windows.Forms.DialogResult.None)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    ItemID = Convert.ToInt64(dgvLOV.CurrentRow.Cells["GridItemID"].Value.ToString());
                    ItemCode = dgvLOV.CurrentRow.Cells["GridItemCode"].Value.ToString();
                    ItemName = dgvLOV.CurrentRow.Cells["GridItemName"].Value.ToString();
                    //Specification = dgvLOV.CurrentRow.Cells["GridSpecification"].Value.ToString();
                    if (_spName == "usp_Quotation_BOM_DDL")
                    {
                        ItemHeight = Convert.ToDecimal(dgvLOV.CurrentRow.Cells["GridHeight"].Value);
                        ItemWidth = Convert.ToDecimal(dgvLOV.CurrentRow.Cells["GridWidth"].Value);
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

        #region "Textbox Event..."

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() != "")
            {
                Load_Serach();
            }
        }

        #endregion

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                GUI.ItemRegister.frmItemEntry fLead = new GUI.ItemRegister.frmItemEntry((int)Constant.Mode.Insert, 0);
                fLead.ShowInTaskbar = false;
                fLead.ShowDialog();
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

    }

}
