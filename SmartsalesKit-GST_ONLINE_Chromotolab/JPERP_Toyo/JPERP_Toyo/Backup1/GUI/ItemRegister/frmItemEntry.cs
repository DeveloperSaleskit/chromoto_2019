
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections.Specialized;
using Account.BusinessLogic;
using Account.Common;
using Account.Validator;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace Account.GUI.ItemRegister
{
    public partial class frmItemEntry : Account.GUIBase
    {

        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        CommonListBL objList = new CommonListBL();
        ItemBL objItemBL = new ItemBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        DataTable dtItem = new DataTable();
        DataTable dtParentItem = new DataTable();

        int _Mode = 0;
        Int64 _ItemID = 0;
        Int64 _ParentItemID = 0;

        CommonListBL CommList = new CommonListBL();
        Int64 _StockID = 0;
        string SelectedFileName = "";
        string strFile;
        #endregion

        #region "Form Event..."

        public frmItemEntry(int Mode, Int64 ItemID)
        {
            try
            {
                InitializeComponent();
                _Mode = Mode;
                _ItemID = ItemID;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void frmItemEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);

                objCommon.FillUOMDDL(cmbUOM);
                objCommon.FillGodownCombo(cmbgodown);
                objCommon.FillCurrencyCombo(cmbCurrency);
                //cmbCurrency.Text = "Rs";

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    this.Text = "Item Register - New";
                    txtItemCode.Text = objCommon.AutoNumber("ITEM");
                    //----------------------------------------------------
                    cmbgodown.SelectedIndex = 0;
                    //----------------------------------------------------
                    int UOM_ID, Currency_ID;
                    DataTable dtUOMId = new DataTable();
                    NameValueCollection ParaUOM = new NameValueCollection();
                    ParaUOM.Add("@i_UOM", "No");
                    dtUOMId = objList.ListOfRecord("usp_Select_UOMID", ParaUOM, "Item Class - LoadList");
                    if (dtUOMId.Rows.Count > 0)
                    {
                        UOM_ID = Convert.ToInt32(dtUOMId.Rows[0][0].ToString());
                    }
                    else
                    {
                        UOM_ID = 1;
                    }

                    //cmbCurrency.Text = 1;
                    cmbUOM.SelectedValue = UOM_ID;
                    //-----------------------------------------------

                    DataTable dtCurrencyId = new DataTable();
                    NameValueCollection ParaCurrency = new NameValueCollection();
                    ParaCurrency.Add("@i_Currency", "Rs");
                    dtCurrencyId = objList.ListOfRecord("usp_Select_CurrencyID", ParaCurrency, "Item Class - LoadList");
                    if (dtCurrencyId.Rows.Count > 0)
                    {
                        Currency_ID = Convert.ToInt32(dtCurrencyId.Rows[0][0].ToString());
                    }
                    else
                    {
                        Currency_ID = 0;
                    }
                    cmbCurrency.SelectedValue = Currency_ID;
                    //----------------------------------------------------

                    //CurrentUser.DocumentPath
                    //Image image = Image.FromFile(ConfigurationManager.AppSettings["ITEMNOIMAGE"].ToString());
                    //Image image = Image.FromFile(CurrentUser.DocumentPath + "NoImage.png");
                    //pictureBox1.Image = image;
                    ////pictureBox1.Height = image.Height;
                    ////pictureBox1.Width = image.Width;
                    //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //pictureBox1.Image = CurrentCompany.ItemImage;
                }
                else if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    this.Text = "Item Register - Edit";
                    BindControl();
                    btnSaveContinue.Visible = false;
                    btnRegenrate.Visible = false;
                    // gbStockDetail.Enabled = false;
                    txtOpeningStock.Enabled = false;
                    txtCurrentStock.Enabled = false;
                    cmbgodown.Enabled = false;
                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    this.Text = "Item Register - Delete";
                    BindControl();
                    SetReadOnlyControls(grpData);
                    btnSaveContinue.Visible = false;
                    btnRegenrate.Visible = false;
                    btnSaveExit.Text = "Yes";
                    btnCancel.Text = "No";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    lblDelMsg.Visible = true;
                    btnRegenrate.Visible = false;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }

        }

        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            try
            {
                dtItem = CommSelect.SelectRecord(_ItemID, "usp_Item_Select", "frmItemEntry-BindControl");
                if (CommSelect.Exception == null)
                {
                    if (CommSelect.ErrorMessage == "")
                    {
                        if (dtItem.Rows.Count > 0)
                        {
                            txtItemCode.Text = dtItem.Rows[0]["Code"].ToString();
                            txtItemName.Text = dtItem.Rows[0]["Name"].ToString();
                            txtOtherName.Text = dtItem.Rows[0]["OtherName"].ToString();
                            txtSpecification.Text = dtItem.Rows[0]["Specification"].ToString();
                            txtprice.Text = dtItem.Rows[0]["Price"].ToString();
                            cmbUOM.SelectedValue = dtItem.Rows[0]["CUOMID"];
                            txtHSN.Text = dtItem.Rows[0]["HSNCode"].ToString();
                            txtProductCode.Text = dtItem.Rows[0]["ProductCode"].ToString();

                            txtOpeningStock.Text = dtItem.Rows[0]["QOH"].ToString();
                            txtCurrentStock.Text = dtItem.Rows[0]["QOH"].ToString();

                            txtReorderLevel.Text = dtItem.Rows[0]["ReorderLvl"].ToString();
                            txtLocation.Text = dtItem.Rows[0]["Location"].ToString();
                            txtRackNo.Text = dtItem.Rows[0]["RackNo"].ToString();
                            cmbgodown.SelectedValue = dtItem.Rows[0]["GodownID"].ToString();
                            _StockID = Convert.ToInt64(dtItem.Rows[0]["StockID"].ToString());
                            cmbCurrency.SelectedValue = dtItem.Rows[0]["CurrencyID"];
                            //--------------------
                            if (dtItem.Rows[0]["DocName"].ToString() != "")
                            {
                                if (dtItem.Rows[0]["DocName"].ToString() != null)
                                {
                                    txtDocName.Text = dtItem.Rows[0]["DocName"].ToString();

                                    strFile = dtItem.Rows[0]["DocName"].ToString();
                                    //pictureBox1.Image=
                                    Image image = Image.FromFile(strFile);
                                    pictureBox1.Image = image;
                                    pictureBox1.Height = image.Height;
                                    pictureBox1.Width = image.Width;
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                            //---------------------
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
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
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
                    CommDelRec.DeleteRecord(_ItemID, "usp_Item_Delete", "frmItemEntry-SetSave");
                    if (CommDelRec.Exception == null)
                    {
                        if (CommDelRec.ErrorMessage != "")
                        {
                            lblErrorMessage.Text = CommDelRec.ErrorMessage;
                            txtItemName.Focus();
                            ReturnValue = false;
                        }
                        else
                        {
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


                    if (txtprice.Text == "")
                    {
                        txtprice.Text = "0.00";
                    }

                    if (DataValidator.IsValid(this.grpData))
                    {
                        if (Convert.ToInt16(cmbgodown.SelectedValue) != 0)
                        {

                            if (_Mode == (int)Common.Constant.Mode.Insert)
                            {
                                string XMLString = string.Empty;
                                long Cnt = 0;
                                DataTable dtgodown = new DataTable();
                                NameValueCollection para = new NameValueCollection();
                                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                                para.Add("@i_CompId", CurrentCompany.CompId.ToString());

                                dtgodown = CommList.ListOfRecord("usp_Godown_DDL", para, "Common - FillGodownCombo");
                                if (CommList.Exception != null)
                                {
                                    MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {

                                    XMLString = "<NewDataSet>";
                                    for (int i = 0; i < dtgodown.Rows.Count; i++)
                                    {
                                        XMLString = XMLString + "<Table>";
                                        XMLString = XMLString + "<GodownID>" + Convert.ToInt32(dtgodown.Rows[i]["GodownID"]) + "</GodownID>";
                                        XMLString = XMLString + "</Table> ";
                                        Cnt = Cnt + 1;
                                    }
                                    XMLString = XMLString + "</NewDataSet>";
                                }
                                //string newFileName = CurrentUser.DocumentPath + txtItemCode.Text.ToString().Replace('/', '-') + "-" + txtDocName.Text.ToString().Replace('/', '-');
                                string newFileName = txtDocName.Text.ToString().Replace('/', '-');
                                objItemBL.Insert(txtItemCode.Text, txtItemName.Text, txtOtherName.Text, txtSpecification.Text,
                                    Convert.ToInt64(cmbUOM.SelectedValue), Convert.ToDecimal(txtprice.Text), txtProductCode.Text, txtHSN.Text, XMLString, Cnt,
                                    Convert.ToDecimal(txtOpeningStock.Text), Convert.ToDecimal(txtReorderLevel.Text), txtLocation.Text, txtRackNo.Text, (int)cmbgodown.SelectedValue,
                                    newFileName, Convert.ToInt64(cmbCurrency.SelectedValue)
                                    );
                            }
                            else if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                string newFileName = txtDocName.Text.ToString().Replace('/', '-');

                                objItemBL.Update(_ItemID, _StockID, txtItemCode.Text, txtItemName.Text, txtOtherName.Text, txtSpecification.Text,
                                    Convert.ToInt64(cmbUOM.SelectedValue), Convert.ToDecimal(txtprice.Text), txtProductCode.Text, txtHSN.Text,
                                    Convert.ToDecimal(txtOpeningStock.Text), Convert.ToDecimal(txtReorderLevel.Text), txtLocation.Text, txtRackNo.Text, (int)cmbgodown.SelectedValue,
                                    newFileName, Convert.ToInt64(cmbCurrency.SelectedValue)
                                    );
                            }

                            if (objItemBL.Exception == null)
                            {
                                if (objItemBL.ErrorMessage != "")
                                {
                                    lblErrorMessage.Text = objItemBL.ErrorMessage;
                                    txtItemName.Focus();
                                    ReturnValue = false;
                                }
                                else
                                {
                                    //if (_Mode == (int)Common.Constant.Mode.Insert)
                                    //{
                                    //string newFileName = CurrentUser.DocumentPath + txtItemCode.Text.ToString().Replace('/', '-') + "-" + txtDocName.Text.ToString().Replace('/', '-');
                                    //objItemBL.InsertQuotationDocument(_ItemID, txtItemCode.Text.ToString().Replace('/', '-') + "-" + txtItemCode.Text.ToString().Replace('/', '-'));

                                    string newFileName = txtDocName.Text.ToString().Replace('/', '-');
                                    if (objItemBL.Exception == null)
                                    {
                                        if (objItemBL.ErrorMessage == "")
                                        {
                                            //File.Copy(SelectedFileName, newFileName, true);
                                        }
                                    }
                                    //}

                                    ReturnValue = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show(objItemBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please select  Godown First.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cmbgodown.Focus();

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
            return ReturnValue;
        }

        #endregion

        #region "Button Event..."

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetSave())
                {
                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                    txtOtherName.Text = "";
                    txtSpecification.Text = "";
                    //cmbUOM.SelectedIndex = 0;
                    //cmbCurrency.SelectedIndex = 1;
                    //----------------------------------------------------
                    int UOM_ID, Currency_ID;
                    DataTable dtUOMId = new DataTable();
                    NameValueCollection ParaUOM = new NameValueCollection();
                    ParaUOM.Add("@i_UOM", "No");
                    dtUOMId = objList.ListOfRecord("usp_Select_UOMID", ParaUOM, "Item Class - LoadList");
                    if (dtUOMId.Rows.Count > 0)
                    {
                        UOM_ID = Convert.ToInt32(dtUOMId.Rows[0][0].ToString());
                    }
                    else
                    {
                        UOM_ID = 1;
                    }

                    //cmbCurrency.Text = 1;
                    cmbUOM.SelectedValue = UOM_ID;
                    //-----------------------------------------------

                    DataTable dtCurrencyId = new DataTable();
                    NameValueCollection ParaCurrency = new NameValueCollection();
                    ParaCurrency.Add("@i_Currency", "Rs");
                    dtCurrencyId = objList.ListOfRecord("usp_Select_CurrencyID", ParaCurrency, "Item Class - LoadList");
                    if (dtCurrencyId.Rows.Count > 0)
                    {
                        Currency_ID = Convert.ToInt32(dtCurrencyId.Rows[0][0].ToString());
                    }
                    else
                    {
                        Currency_ID = 0;
                    }
                    cmbCurrency.SelectedValue = Currency_ID;
                    //----------------------------------------------------
                    txtprice.Text = "0.00";
                    txtProductCode.Text = "";
                    txtHSN.Text = "";
                    cmbgodown.SelectedIndex = 1;
                    txtOpeningStock.Text = "0";
                    txtReorderLevel.Text = "0";
                    txtLocation.Text = "";
                    txtRackNo.Text = "";

                    txtItemCode.Text = objCommon.AutoNumber("ITEM");
                    txtItemName.Focus();
                    lblErrorMessage.Text = "No error";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetSave())
                {
                    this.Dispose();
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            try
            {
                txtItemCode.Text = objCommon.AutoNumber("ITEM");
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox KeyPress Event"

        private void txtSpecification_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
            //            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        #endregion

        #region "TextBox Leave Event"

        private void txtNetWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                DataValidator.AllowOnlyNumeric(e, ".");
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemEntry-Keypress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtNetWeight_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46 || e.KeyChar==8)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}

            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                txtDocName.Text = ofd.SafeFileName;
                SelectedFileName = ofd.FileName;
                Image image = Image.FromFile(SelectedFileName);
                pictureBox1.Image = image;
                //pictureBox1.Height = image.Height;
                //pictureBox1.Width = image.Width;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                string newFileName = CurrentUser.DocumentPath + txtItemCode.Text.ToString().Replace('/', '-') + "-" + txtDocName.Text.ToString().Replace('/', '-');
                txtDocName.Text = newFileName;
                File.Copy(SelectedFileName, newFileName, true);
                strFile = newFileName;
                // pictureBox1.Image ;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDocName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //if (_Mode == (int)Common.Constant.Mode.Insert)
            //{
            //    MessageBox.Show("Please save record and then you can edit document in Edit Sale record.");
            //    return;
            //}
            //string strFile;
            //strFile = CurrentUser.DocumentPath + dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                Process.Start(strFile);
            }
        }

        //public void NumberValidation(object sender, KeyPressEventArgs e)
        // {
        //     if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 46)
        //     {
        //         e.Handled = false;
        //     }
        //     else
        //     {
        //         e.Handled = true;
        //     }
        // }

    }
}
