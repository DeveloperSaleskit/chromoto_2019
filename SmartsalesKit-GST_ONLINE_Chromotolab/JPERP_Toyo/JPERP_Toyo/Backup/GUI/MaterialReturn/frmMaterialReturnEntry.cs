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

namespace Account.GUI.MaterialReturn
{
    public partial class frmMaterialReturnEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        MaterialReturnBL objmaterialBL = new MaterialReturnBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtStock = new DataTable();
        int _Mode = 0;
        Int64 _StockID = 0;

        string _itemcode;
        bool _LatestMatriealReturn;
        DataTable dtItemList = new DataTable();
        Int64 _ItemID = 0;
        Int64 _MaterialID = 0;
        Int64 _MRID = 0;
        int Isreturnable = 0;
        string IsreturnYESNO;
        #endregion

        #region "Form Events...."

        public frmMaterialReturnEntry(int Mode, Int64 id, bool LatestMatriealReturn)
        {
            InitializeComponent();
            _Mode = Mode;
            _MaterialID = id;
            _LatestMatriealReturn = LatestMatriealReturn;
        }

        private void frmMaterialReturnEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);






            //LoadItemList();
            objCommon.FillGodownCombo(cmbgodown);
            objCommon.FillEmpAllocatedToCombo(cmbemployee1);
            objCommon.FillEmpAllocatedToCombo(cmbemployee2);

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                //this.Text = "MaterialIssue - New";
                //txtmaterialissuecode.Text = objCommon.AutoNumber("MI");


                btnItemLOV.Visible = true;
                if (cmbgodown.Text == "--Select--")
                {
                    cmbgodown.SelectedIndex = 0;

                }
                this.Text = "Material Return-New";
            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {

                if (_LatestMatriealReturn == true)
                {
                    grpData.Enabled = true;
                }
                else
                {
                    grpData.Enabled = false;
                }

                ErrItemName.Visible = false;
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "Material Return - Edit";
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
                this.Text = "Material Return- Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtStock = CommSelect.SelectRecord(_MaterialID, "usp_MaterialReturn_Select", "MaterialIssue - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtStock.Rows.Count > 0)
                        {
                            cmbgodown.SelectedValue = dtStock.Rows[0]["GodownID"].ToString();
                            txtmaterialissuecode.Text = dtStock.Rows[0]["MaterialIssueCode"].ToString();
                            txtItemName.Text = dtStock.Rows[0]["ItemName"].ToString();
                            _ItemID = Convert.ToInt64(dtStock.Rows[0]["ItemID"]);
                            _itemcode = dtStock.Rows[0]["ItemCode"].ToString();
                            cmbemployee1.Text = dtStock.Rows[0]["ReturnBy"].ToString();
                            cmbemployee2.Text = dtStock.Rows[0]["ReturnTo"].ToString();
                            _MaterialID = Convert.ToInt16(dtStock.Rows[0]["id"].ToString());

                            txtretunqty.Text = dtStock.Rows[0]["ReturnQty"].ToString();
                            txtissueqty.Text = dtStock.Rows[0]["IssueQTY"].ToString();

                            txtreamaingqty.Text = dtStock.Rows[0]["RemaingQTY"].ToString();

                            txtNarration.Text = dtStock.Rows[0]["narration"].ToString();

                            //if (Convert.ToInt16(dtStock.Rows[0]["returnable"].ToString()) == 1)
                            //{
                            //    chkReasonble.Checked = true;

                            //}
                            //if (Convert.ToInt16(dtStock.Rows[0]["returnable"].ToString()) == 0)
                            //{
                            //    chkReasonble.Checked = false;

                            //}


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
                Utill.Common.ExceptionLogger.writeException("MaterialIssue", exc.StackTrace);
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
                    CommDelRec.DeleteRecord(_MaterialID, "usp_MaterialReturn_Delete", "MaterialReturn - Delete");
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
                            objmaterialBL.Insert(_MRID, txtmaterialissuecode.Text, _ItemID, Convert.ToInt16(cmbgodown.SelectedValue), Convert.ToInt16(cmbemployee1.SelectedValue), Convert.ToInt16(cmbemployee2.SelectedValue), txtNarration.Text, Convert.ToString(_itemcode), Convert.ToDecimal(txtretunqty.Text), Convert.ToDecimal(txtissueqty.Text), Convert.ToDecimal(txtreamaingqty.Text));
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objmaterialBL.Update(_MRID, _MaterialID, txtmaterialissuecode.Text, _ItemID, Convert.ToInt16(cmbgodown.SelectedValue), Convert.ToInt16(cmbemployee1.SelectedValue), Convert.ToInt16(cmbemployee2.SelectedValue), txtNarration.Text, Convert.ToString(_itemcode), Convert.ToDecimal(txtretunqty.Text), Convert.ToDecimal(txtissueqty.Text), Convert.ToDecimal(txtreamaingqty.Text));

                        }

                        if (objmaterialBL.Exception == null)
                        {
                            if (objmaterialBL.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objmaterialBL.ErrorMessage;
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
                            MessageBox.Show(objmaterialBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }

                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("MaterialIssue", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        private void LoadItemList1()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                dtItemList = objList.ListOfRecord("usp_Item_StockItemLOV", para, "MaterialIssue - LoadItemList");

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
                Utill.Common.ExceptionLogger.writeException("MaterialIssue", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadItemList()
        {
            try
            {

                NameValueCollection para = new NameValueCollection();
                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_RecID", _MRID.ToString());

                dtItemList = objList.ListOfRecord("usp_MaterialReturn_ItemNEW_lov", para, "Sales Invoice Detail - LoadItemList");



                ////----------------------
                if (_Mode == (int)Common.Constant.Mode.Insert)
                {

                    DataView dvItem = new DataView();//added by rooja for item autosearch data fill
                    dvItem = dtItemList.DefaultView;
                    if (txtItemName.Text != "")
                    {
                        string id = _MRID.ToString();

                        dvItem.RowFilter = "ItemName like '%" + PrepareFilterString(txtItemName.Text) + "%' and id='" + PrepareFilterString(id) + "'";
                        DataTable dtTempItem = new DataTable();
                        dtTempItem = dvItem.ToTable();

                        if (dtTempItem.Rows.Count > 0)
                        {
                            lblErrorMessage.Text = "No error";
                            _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);

                            txtmaterialissuecode.Text = dtTempItem.Rows[0]["MaterialIssueCode"].ToString();
                            cmbgodown.SelectedValue = Convert.ToInt64(dtTempItem.Rows[0]["GodownID"].ToString());

                            txtissueqty.Text = dtTempItem.Rows[0]["IssueQTY"].ToString();
                            txtreamaingqty.Text = dtTempItem.Rows[0]["RemainingQty"].ToString();

                            btnSaveExit.Enabled = true;
                            txtretunqty.Text = dtTempItem.Rows[0]["ReturnQty"].ToString();
                        }

                    }
                    else
                    {
                        // lblErrorMessage.Text = "Invalid item";
                        lblErrorMessage.Text = "Please Select Item";
                        _ItemID = 0;
                        txtretunqty.Text = "0.000";
                        //txtUOM.Text = "";
                        //txtRate.Text = "0.00";
                        //txtAmount.Text = "0.00";
                        txtItemName.Focus();
                        btnSaveExit.Enabled = false;
                        txtretunqty.Text = "0.000";
                    }
                }
                ////------------------------------

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
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event..."

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemMR fLOV = new frmItemMR("usp_MaterialReturn_Item", null);
                fLOV.ShowDialog();

                txtItemName.Text = fLOV.ItemName1;
                _itemcode = fLOV.ItemCode;
                _MRID = fLOV.MIID1;

                LoadItemList();
                if (fLOV.ItemName1 == null)
                {
                    _ItemID = 0;

                }
                else
                {
                    DataView dvItem = new DataView();
                    dvItem = dtItemList.DefaultView;
                    dvItem.RowFilter = "ItemName like '%" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();
                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Item name";
                        _ItemID = 0;

                        txtItemName.Focus();
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("MaterialIssue", exc.StackTrace);
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
                txtNarration.Text = "";
                cmbemployee1.Text = "";
                cmbemployee2.Text = "";
                cmbgodown.Text = "";



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
                    dvItem.RowFilter = "ItemName like '%" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();
                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                        txtItemName.Text = dtTempItem.Rows[0]["ItemName"].ToString();

                        btnSaveContinue.Enabled = true;
                        btnSaveExit.Enabled = true;
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Item name";
                        _ItemID = 0;

                        txtItemName.Focus();
                        btnSaveContinue.Enabled = false;
                        btnSaveExit.Enabled = false;
                    }

                }
                else
                {
                    _ItemID = 0;


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

        private void cmbgodown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbemployee1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtretunqty_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtreamaingqty.Text) < Convert.ToDecimal(txtretunqty.Text))
            {
                MessageBox.Show("Return Quantity should not be greater than Remaing Quantity");
                txtretunqty.Focus();
                return;

            }

        }



    }
}
