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
        POBL objPurchaseBL = new POBL();
        PurchaseInvoiceBL objGRNBL = new PurchaseInvoiceBL();
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
        public string _FormName;
        public string MTYPE_OF_FORM;
        Boolean delEditedFlag = false;
        int EditedRowIndex = 0;
        string[] editedRows;
        List<string> Col1 = new List<string>();
        DataTable dtTNC = new DataTable();
        DataTable dtOTNC = new DataTable();

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
                //dtTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_TNC_Sub", cmbTNCSub.Text);


                dtOTNC = objList.ListOfRecord("usp_TNC_LOV", para, "Terms And Conditions - Select");    
                dtTNC = objList.ListOfRecord("usp_TNC_LOV", para, "Terms And Conditions - Select");
                if (dtTNC.Rows.Count > 0)
                {
                    dgvLOV.Columns["TNC_Desc"].DataPropertyName = dtTNC.Columns["TNC_Desc"].ToString();
                }

                if (dtOTNC.Rows.Count > 0)
                {
                    dgvLOV.Columns["TNC_Desc"].DataPropertyName = dtOTNC.Columns["TNC_Desc"].ToString();
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
                            if (dtQTNC.Rows[i][1].ToString().Trim() == dgvLOV.Rows[j].Cells[1].Value.ToString().Trim())
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

        public frmTNCLOV(string SpName, NameValueCollection para, string Code, string FormName)
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
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
                if (dtQTNC.Rows.Count > 0)
                {
                    cmbTNCSub.Text = dtQTNC.Rows[0][0].ToString();
                }

            }
            else if (_spName == "usp_SalesTNC_Select")
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", _Code);
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
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
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtQTNC = objDA.ExecuteDataTableSP("usp_ServicesTNC_Select", para, false, ref mException, ref mErrorMsg, "Services TNC - Select");
                if (dtQTNC.Rows.Count > 0)
                {
                    cmbTNCSub.Text = dtQTNC.Rows[0][0].ToString();
                }
            }
            else if (_spName == "usp_PurchaseTNC_Select")
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", _Code);
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtQTNC = objDA.ExecuteDataTableSP("usp_PurchaseTNC_Select", para, false, ref mException, ref mErrorMsg, "Services TNC - Select");
                if (dtQTNC.Rows.Count > 0)
                {
                    cmbTNCSub.Text = dtQTNC.Rows[0][0].ToString();
                }
            }
            else if (_spName == "usp_TNC_LOV")
            {
                if (_FormName == "QUOTATION")
                {
                    cmbTNCSub.Text = "QUOTATION";
                }
                else if (_FormName == "SALES")
                {
                    cmbTNCSub.Text = "SALES";
                }
                else if (_FormName == "SERVICE")
                {
                    cmbTNCSub.Text = "SERVICE";
                }
                else if (_FormName == "PURCHASE")
                {
                    cmbTNCSub.Text = "PURCHASE";
                }
                cmbTNCSub.Enabled = false;

            }
            LoadList();
            dgvLOV.ReadOnly = false;
            cmbTNCSub.Enabled = false;
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

                    for (int i = 0; i <= dgvLOV.Rows.Count - 1; i++)
                    {
                        if (dtQTNC.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtQTNC.Rows.Count; j++)
                            {
                                // if(dgvLOV.Rows.Count)


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
                                        string status = "";
                                        for (int x = 0; x < Col1.Count; x++)
                                        {
                                            if (delEditedFlag == true && i == Convert.ToInt16(Col1[x].ToString()))
                                            {
                                                status = "";
                                                delflag = true;
                                                //insertflag = true;
                                                break;
                                            }
                                            else
                                            {
                                                status = "Insert";
                                                //insertflag = true;
                                            }
                                        }
                                        if (Col1.Count == 0)
                                        {
                                            insertflag = true;
                                        }
                                        else
                                        {
                                            //if (status == "Insert")
                                            if (delEditedFlag == false)
                                            {
                                                insertflag = true;
                                            }
                                        }
                                        //if (delEditedFlag == false)
                                        //{
                                        //    insertflag = true;
                                        //}

                                        //if (delEditedFlag == true && i == EditedRowIndex)
                                        //{
                                        //    delflag = true;
                                        //    //insertflag = true;
                                        //    break;
                                        //}
                                        //else
                                        //{
                                        //    insertflag = true;
                                        //}
                                        //insertflag = true;
                                    }
                                }
                            }
                            if (delflag == true)
                            {
                                if (_spName == "usp_QuotationTNC_Select")
                                {
                                    string delstatus = "";
                                    for (int x = 0; x < Col1.Count; x++)
                                    {
                                        if (delEditedFlag == true && i == Convert.ToInt16(Col1[x].ToString()))
                                        {
                                            objQuotationBL.DeleteTNC(cmbTNCSub.Text, dtOTNC.Rows[Convert.ToInt16(Col1[x].ToString())]["TNC_Desc"].ToString(), _Code);
                                            delflag = false;
                                            insertflag = true;
                                        }
                                        else
                                        {
                                            delstatus = "delete";
                                        }
                                    }
                                    if (delEditedFlag == false)
                                    {
                                        objQuotationBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                        delflag = false;
                                    }

                                    //if (delEditedFlag == true && i == EditedRowIndex)//desc modified in edit mode
                                    //{
                                    //    objQuotationBL.DeleteTNC(cmbTNCSub.Text, dtOTNC.Rows[EditedRowIndex]["TNC_Desc"].ToString(), _Code);
                                    //    delflag = false;
                                    //    insertflag = true;
                                    //}
                                    //else//desc as it is
                                    //{
                                    //    objQuotationBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    //    delflag = false;
                                    //}   

                                    //objQuotationBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    //delflag = false;
                                }
                                else if (_spName == "usp_SalesTNC_Select")
                                {
                                    string delstatus = "";
                                    for (int x = 0; x < Col1.Count; x++)
                                    {
                                        if (delEditedFlag == true && i == Convert.ToInt16(Col1[x].ToString()))
                                        {
                                            objSalesBL.DeleteTNC(cmbTNCSub.Text, dtOTNC.Rows[Convert.ToInt16(Col1[x].ToString())]["TNC_Desc"].ToString(), _Code);
                                            delflag = false;
                                            insertflag = true;
                                        }
                                        else
                                        {
                                            delstatus = "delete";
                                        }
                                    }
                                    if (delEditedFlag == false)
                                    {
                                        objSalesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                        delflag = false;
                                    }


                                    //objSalesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    //delflag = false;
                                }
                                else if (_spName == "usp_ServicesTNC_Select")
                                {
                                    string delstatus = "";
                                    for (int x = 0; x < Col1.Count; x++)
                                    {
                                        if (delEditedFlag == true && i == Convert.ToInt16(Col1[x].ToString()))
                                        {
                                            objServicesBL.DeleteTNC(cmbTNCSub.Text, dtOTNC.Rows[Convert.ToInt16(Col1[x].ToString())]["TNC_Desc"].ToString(), _Code);
                                            delflag = false;
                                            insertflag = true;
                                        }
                                        else
                                        {
                                            delstatus = "delete";
                                        }
                                    }
                                    if (delEditedFlag == false)
                                    {
                                        objServicesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                        delflag = false;
                                    }

                                    //objServicesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    //delflag = false;
                                }
                                else if (_spName == "usp_PurchaseTNC_Select")
                                {
                                    string delstatus = "";
                                    for (int x = 0; x < Col1.Count; x++)
                                    {
                                        if (delEditedFlag == true && i == Convert.ToInt16(Col1[x].ToString()))
                                        {
                                            objPurchaseBL.DeleteTNC(cmbTNCSub.Text, dtOTNC.Rows[Convert.ToInt16(Col1[x].ToString())]["TNC_Desc"].ToString(), _Code);
                                            delflag = false;
                                            insertflag = true;
                                        }
                                        else
                                        {
                                            delstatus = "delete";
                                        }
                                    }
                                    if (delEditedFlag == false)
                                    {
                                        objServicesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                        delflag = false;
                                    }

                                    //objServicesBL.DeleteTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    //delflag = false;
                                }
                            }
                            if (insertflag == true)
                            {
                                if (_spName == "usp_QuotationTNC_Select")
                                {
                                    objQuotationBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
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
                                else if (_spName == "usp_PurchaseTNC_Select")
                                {
                                    objPurchaseBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                    insertflag = false;
                                }
                            }
                        }
                        else
                        {
                            // MessageBox.Show(_Code.Substring(2,2).ToString());

                            if (_Code.Substring(3, 2) == "QU" || _Code.EndsWith("R%"))
                            // _Code.Substring(18,1)=="R" ||
                            {
                                if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                                {
                                    objQuotationBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
                                }
                            }
                            else if (_Code.Substring(0, 2) == "RI" || _Code.Substring(0, 2) == "TI" || _Code.Substring(0, 2) == "ES")
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
                            else if (_Code.Substring(0, 2) == "PO")
                            {
                                if (Convert.ToBoolean(dgvLOV.Rows[i].Cells[0].Value) == true)
                                {
                                    objPurchaseBL.InsertTNC(cmbTNCSub.Text, dgvLOV.Rows[i].Cells[1].Value.ToString(), _Code);
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

        private void dgvLOV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show("new row");
        }

        private void dgvLOV_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //MessageBox.Show("new row");
        }

        private void dgvLOV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                //MessageBox.Show("new row"+e.ColumnIndex.ToString());
                //  MessageBox.Show("new row" + e.RowIndex.ToString());

                for (int i = 0; i <= dgvLOV.Rows.Count - 1; i++)
                {
                    if (dtQTNC.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtQTNC.Rows.Count; j++)
                        {
                            if (dgvLOV.Rows[i].Cells[1].Value.ToString().Trim() != dtQTNC.Rows[j][1].ToString().Trim())
                            {
                                if (i == e.RowIndex)
                                {
                                    string desc = dtQTNC.Rows[j][1].ToString();
                                    //editedRows = e.RowIndex.ToString(); 
                                    EditedRowIndex = e.RowIndex;
                                    Col1.Add(e.RowIndex.ToString());
                                    delEditedFlag = true;
                                    break;
                                }
                                // delEditedFlag = false;    
                                break;
                            }
                            else
                            {
                                string desc = dtQTNC.Rows[j][1].ToString();
                                delEditedFlag = false;
                            }
                        }
                    }
                }
                DataGridView dtedited = new DataGridView();
                DataTable dteditedtable = new DataTable();
                dteditedtable.Columns.Add(new DataColumn("index", typeof(string)));
                dtedited.DataSource = dteditedtable;

                dtedited.DataSource = Col1;
            }
            else
            {

            }
            //MessageBox.Show("new row");
        }

    }

}
