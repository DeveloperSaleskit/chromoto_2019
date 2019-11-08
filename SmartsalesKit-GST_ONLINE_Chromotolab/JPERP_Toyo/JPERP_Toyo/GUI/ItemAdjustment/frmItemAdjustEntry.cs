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

namespace Account.GUI.Item_Adjustment
{
    public partial class frmItemAdjustEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        ItemAdjustmentBL objItemAdjust = new ItemAdjustmentBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtItemAdjust = new DataTable();
        int _Mode = 0;
        Int64 _AdjustmentID = 0;
        DataTable dtItemList = new DataTable();
        Int64 _ItemID;
        int _godown;
        #endregion

        #region "Form Events...."

        public frmItemAdjustEntry(int Mode, Int64 AdjustmentID)
        {
            InitializeComponent();
            _Mode = Mode;
            _AdjustmentID = AdjustmentID;
        }

        private void frmItemAdjustEntry_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            objCommon.FillGodownCombo(cmbgodown);
            LoadItemList();

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                //DataValidator.SetDefaultDate(dtpAdjustDate, null, null);
                dtpAdjustDate.Value = DateTime.Now;
                this.Text = "Item Stock Adjustment - New";

            }
            else if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                BindControl();
                btnSaveContinue.Visible = false;
                this.Text = "Item Stock Adjustment - Edit";
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
                this.Text = "Item Stock Adjustment - Delete";
            }
        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtItemAdjust = CommSelect.SelectRecord(_AdjustmentID, "usp_ItemAdjustment_Select", "ItemAdjustment - BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtItemAdjust.Rows.Count > 0)
                        {
                         //   DataValidator.SetDefaultDate(dtpAdjustDate, Convert.ToDateTime(dtItemAdjust.Rows[0]["StartDate"]), Convert.ToDateTime(dtItemAdjust.Rows[0]["EndDate"]));
                           
                            txtItemName.Text = dtItemAdjust.Rows[0]["ItemName"].ToString();
                            _ItemID = Convert.ToInt64(dtItemAdjust.Rows[0]["ItemID"]);
                            txtDiffQty.Text = dtItemAdjust.Rows[0]["Qty"].ToString();
                            txtQty.Text = dtItemAdjust.Rows[0]["QOH"].ToString();
                            txtNarration.Text = dtItemAdjust.Rows[0]["Narration"].ToString();
                            cmbgodown.SelectedValue = dtItemAdjust.Rows[0]["GodownID"].ToString();
                            dtpAdjustDate.Value = Convert.ToDateTime(dtItemAdjust.Rows[0]["AdjustDate"].ToString());
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
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
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
                    CommDelRec.DeleteRecord(_AdjustmentID, "usp_ItemAdjustment_Delete", "ItemAdjustment - Delete");
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
                        if (Convert.ToDecimal(txtDiffQty.Text) == 0)
                        {
                            lblErrorMessage.Text = "Enter adjust qty";
                            txtDiffQty.Focus();
                            return false;
                        }
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {
                            objItemAdjust.Insert(dtpAdjustDate.Value, _ItemID, Convert.ToDecimal(txtDiffQty.Text), txtNarration.Text, Convert.ToInt32(cmbgodown.SelectedValue));
                        }
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {
                            objItemAdjust.Update(_AdjustmentID, dtpAdjustDate.Value, _ItemID, Convert.ToDecimal(txtDiffQty.Text), txtNarration.Text, Convert.ToInt32(cmbgodown.SelectedValue));
                        }

                        if (objItemAdjust.Exception == null)
                        {
                            if (objItemAdjust.ErrorMessage != "")
                            {
                                lblErrorMessage.Text = objItemAdjust.ErrorMessage;
                                dtpAdjustDate.Focus();
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
                            MessageBox.Show(objItemAdjust.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }

                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

            return ReturnValue;
        }


        private void LoadItemList()
        {
            try
            {
                //  _godown = Convert.ToInt32(cmbgodown.SelectedValue);
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_GodownID", Convert.ToInt32(cmbgodown.SelectedValue).ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtItemList = objList.ListOfRecord("usp_Item_AdjustItemLOV", para, "ItemAdjustment - LoadItemList");

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
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event..."

        private void btnItemLOV_Click(object sender, EventArgs e)
        {
            try
            {
                _godown = Convert.ToInt32(cmbgodown.SelectedValue);
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_GodownID", _godown.ToString());
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                frmItemLOV fLOV = new frmItemLOV("usp_Item_AdjustItemLOV", para);
                fLOV.ShowDialog();

                txtItemName.Text = fLOV.ItemName;

                if (fLOV.ItemName == null)
                {
                    _ItemID = 0;
                    txtQty.Text = "0.000";
                }
                else
                {
                    LoadItemList();
                    DataView dvItem = new DataView();
                    dvItem = dtItemList.DefaultView;
                    dvItem.RowFilter = "ItemName='" + PrepareFilterString(txtItemName.Text) + "'";

                    DataTable dtTempItem = new DataTable();
                    dtTempItem = dvItem.ToTable();
                    if (dtTempItem.Rows.Count > 0)
                    {
                        lblErrorMessage.Text = "No error";
                        _ItemID = Convert.ToInt64(dtTempItem.Rows[0]["ItemID"]);
                        txtQty.Text = dtTempItem.Rows[0]["QOH"].ToString();
                        txtDiffQty.Focus();
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Item name";
                        _ItemID = 0;
                        txtQty.Text = "0.000";
                        txtItemName.Focus();
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
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
//                DataValidator.SetDefaultDate(dtpAdjustDate, null, null);
                txtItemName.Text = "";
                _ItemID = 0;
                txtQty.Text = "0.000";
                txtDiffQty.Text = "0.000";
                txtNarration.Text = "";
                dtpAdjustDate.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Textbox Event"

        private void txtDiffQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".,-");
        }

        private void txtItemName_Validating(object sender, CancelEventArgs e)
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
                    txtQty.Text = dtTempItem.Rows[0]["QOH"].ToString();
                    txtDiffQty.Focus();
                    btnSaveContinue.Enabled = true;
                    btnSaveExit.Enabled = true;
                }
                else
                {
                    lblErrorMessage.Text = "Invalid Item name";
                    _ItemID = 0;
                    txtQty.Text = "0.000";
                    txtItemName.Focus();
                    btnSaveContinue.Enabled = false;
                    btnSaveExit.Enabled = false;
                }

            }
            else
            {
                _ItemID = 0;
                txtQty.Text = "0.000";
                btnSaveContinue.Enabled = true;
                btnSaveExit.Enabled = true;
            }
        }

        private void txtDiffQty_Leave(object sender, EventArgs e)
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
            //  LoadItemList();
        }

     
    }
}