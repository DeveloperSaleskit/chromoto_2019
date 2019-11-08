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
using System.Collections.Specialized;

namespace Account.GUI.ItemStock
{
    public partial class frmItemStockEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        ItemStockBL objStockBL = new ItemStockBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtStock = new DataTable();
        int _Mode = 0;
        Int64 _StockID = 0;
        DataTable dtItemList = new DataTable();
        Int64 _ItemID;

        #endregion

        #region "Form Events...."

        public frmItemStockEntry(int Mode, Int64 StockID)
        {
            InitializeComponent();
            _Mode = Mode;
            _StockID = StockID;
        }

        private void frmItemStockEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
//            DataValidator.SetDefaultDate(dtpDate, null, null);
            LoadItemList();
            objCommon.FillGodownCombo(cmbgodown);
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                btnItemLOV.Visible = true;
                this.Text = "Item Stock - New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                ErrItemName.Visible = false;
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "Item Stock - Edit";
                btnItemLOV.Enabled = false;
                txtItemName.ReadOnly = true;
                btnItemLOV.TabStop = false;
                txtItemName.TabStop = false;
            }
            else if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                lblDelMsg.Visible = true;
                SetReadOnlyControls(grpData);
                btnSaveExit.Text = "Yes";
                btnSaveExit.Tag = "Click to delete record;";
                btnSaveExit.Width = btnCancel.Width;
                btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                btnCancel.Text = "No";
                this.Text = "Item Stock - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtStock = CommSelect.SelectRecord(_StockID, "usp_ItemStock_Select", "ItemStock - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtStock.Rows.Count > 0)
                        {
                            txtItemName.Text = dtStock.Rows[0]["ItemName"].ToString();
                            _ItemID = Convert.ToInt64(dtStock.Rows[0]["ItemID"]);
                            txtUOM.Text = dtStock.Rows[0]["UOM"].ToString();
                           // dtpDate.Value = Convert.ToDateTime(dtStock.Rows[0]["Date"]);
                            txtOpeningStock.Text = dtStock.Rows[0]["QOH"].ToString();
                            txtCurrentStock.Text = dtStock.Rows[0]["QOH"].ToString();
                            txtMinLevel.Text = dtStock.Rows[0]["MinLevel"].ToString();
                            txtMaxLevel.Text = dtStock.Rows[0]["MaxLevel"].ToString();
                            txtReorderLevel.Text = dtStock.Rows[0]["ReorderLvl"].ToString();
                            txtLocation.Text = dtStock.Rows[0]["Location"].ToString();
                            txtRackNo.Text = dtStock.Rows[0]["RackNo"].ToString();
                            cmbgodown.SelectedValue = dtStock.Rows[0]["GodownID"].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show(CommSelect.ErrorMessage);
                    }
                }
                else
                {
                    MessageBox.Show(CommSelect.Exception.Message.ToString());
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        public bool SetSave()
        {
            bool ReturnValue = false;

            try
            {
                if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    CommDelRec.DeleteRecord(_StockID, "usp_ItemStock_Delete", "ItemStock - Delete");
                    if (CommDelRec.Exception == null)
                    {
                        if (CommDelRec.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = CommDelRec.ErrorMessage;
                            ReturnValue = false;
                        }
                        else
                        {
                            lblErrorMessage.Text = "No error";
                            ReturnValue = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ReturnValue = false;
                    }
                }
                else
                {
                    if (DataValidator.IsValid(this.grpData))
                    {
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            objStockBL.Insert(_ItemID, Convert.ToDecimal(txtOpeningStock.Text), Convert.ToDecimal(txtMinLevel.Text), Convert.ToDecimal(txtMaxLevel.Text), Convert.ToDecimal(txtReorderLevel.Text), txtLocation.Text, txtRackNo.Text, dtpDate.Value, (int)cmbgodown.SelectedValue);
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objStockBL.Update(_StockID, _ItemID, Convert.ToDecimal(txtOpeningStock.Text), Convert.ToDecimal(txtMinLevel.Text), Convert.ToDecimal(txtMaxLevel.Text), Convert.ToDecimal(txtReorderLevel.Text), txtLocation.Text, txtRackNo.Text, dtpDate.Value, (int)cmbgodown.SelectedValue);
                        }

                        if (objStockBL.Exception == null)
                        {
                            if (objStockBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objStockBL.ErrorMessage;
                                txtItemName.Focus();
                                ReturnValue = false;
                            }
                            else
                            {
                                lblErrorMessage.Text = "No error";
                                ReturnValue = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(objStockBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }

                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        private void LoadItemList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                dtItemList = objList.ListOfRecord("usp_Item_StockItemLOV", para, "ItemStock - LoadItemList");

                if (objList.Exception == null)
                {
                    txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    AutoCompleteStringCollection Data = new AutoCompleteStringCollection();
                    for (int i = 0; i < dtItemList.Rows.Count; i++)
                    {
                        Data.Add(dtItemList.Rows[i]["ItemName"].ToString());
                        
                    }
                    txtItemName.AutoCompleteCustomSource = Data;
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event..."

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemLOV fLOV = new frmItemLOV("usp_Item_StockItemLOV", null);
                fLOV.ShowDialog();

                txtItemName.Text = fLOV.ItemName;
                if (fLOV.ItemName == null)
                {
                    _ItemID = 0;
                    txtUOM.Text = "";
                    txtfinalprod.Text = "";
                }
                else
                {
                    DataView dvItem = new DataView();
                    dvItem = dtItemList.DefaultView;
                    dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();
                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                        txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                        txtfinalprod.Text = dtTempItem.Rows[0]["ProductCode"].ToString();
                        dtpDate.Focus();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Item name";
                        _ItemID = 0;
                        txtUOM.Text = "";
                        txtItemName.Focus();
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemStock", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Dispose();
            }
        }
        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtItemName.Text = "";
                _ItemID = 0;
                txtUOM.Text = "";
//                DataValidator.SetDefaultDate(dtpDate, null, null);
                txtOpeningStock.Text = "0.000";
                txtCurrentStock.Text = "0.000";
                txtMinLevel.Text = "0.000";
                txtMaxLevel.Text = "0.000";
                txtReorderLevel.Text = "0.000";
                txtLocation.Text = "";
                txtRackNo.Text = "";
                LoadItemList();
                txtItemName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Textbox Event"

        private void txtOpeningStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtItemName_Validating(object sender, CancelEventArgs e)
        {
            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                if (txtItemName.Text != "")
                {
                    DataView dvItem = new DataView();
                    dvItem = dtItemList.DefaultView;
                    dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();
                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                        txtItemName.Text = dtTempItem.Rows[0]["ItemName"].ToString();
                        txtUOM.Text = dtTempItem.Rows[0]["UOM"].ToString();
                        dtpDate.Focus();
                        btnSaveContinue.Enabled = true;
                        btnSaveExit.Enabled = true;
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Item name";
                        _ItemID = 0;
                        txtUOM.Text = "";
                        txtItemName.Focus();
                        btnSaveContinue.Enabled = false;
                        btnSaveExit.Enabled = false;
                    }

                }
                else
                {
                    _ItemID = 0;

                    txtUOM.Text = "";
                    btnSaveContinue.Enabled = true;
                    btnSaveExit.Enabled = true;
                }
            }
        }

        private void txtOpeningStock_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {
                    txtTextbox.Text = Convert.ToDecimal(txtTextbox.Text).ToString("#0.000");
                    // Set Decimal Value after textbox's Leave Event
                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        btnSaveContinue.Enabled = true;
                        btnSaveExit.Enabled = true;
                        lblErrorMessage.Text = "No error";
                        txtCurrentStock.Text = txtOpeningStock.Text;
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99999999999999.999";
                        txtTextbox.Focus();
                        btnSaveContinue.Enabled = false;
                        btnSaveExit.Enabled = false;
                    }
                }
                else
                {
                    txtTextbox.Text = "0.000";
                    btnSaveContinue.Enabled = true;
                    btnSaveExit.Enabled = true;
                }
            }
            else
            {
                txtTextbox.Text = "0.000";
                btnSaveContinue.Enabled = true;
                btnSaveExit.Enabled = true;
            }
        }

        #endregion



    }
}
