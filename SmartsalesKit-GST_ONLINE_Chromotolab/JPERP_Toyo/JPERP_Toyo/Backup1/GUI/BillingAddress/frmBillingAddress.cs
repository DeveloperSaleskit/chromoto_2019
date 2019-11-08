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

namespace Account.GUI.BillingAddress
{
    public partial class frmBillingAddress : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblBillingAddress = new DataTable();
        DataTable dtCity = new DataTable();
        DataTable dtTempCity = new DataTable();
        CommonListBL objList = new CommonListBL();
        BillingAddressBL objCP = new BillingAddressBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();

        int _AddressType = 0;
        Int64 _RefID = 0;

        #endregion

        #region "Form Event"

        public frmBillingAddress(int AddressType, Int64 RefID)
        {
            InitializeComponent();
            _AddressType = AddressType;
            _RefID = RefID;
        }

        private void frmBillingAddress_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvBillingAddress.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LoadCIty();
            LoadList();

            //dgvBillingAddress.Refresh();
            dgvBillingAddress.AllowUserToAddRows = true;
            dgvBillingAddress.AllowUserToDeleteRows = true;
            dgvBillingAddress.ReadOnly = false;
            dgvBillingAddress.StandardTab = false;



            if (_AddressType == 0)
            {
                this.Text = "Vendor - Billing Address";
            }
            else if (_AddressType == 1)
            {
                this.Text = "Customer - Billing Address";
            }
            else if (_AddressType == 2)
            {
                this.Text = "Transporter - Billing Address";
            }
            else if (_AddressType == 3)
            {
                this.Text = "Jobworker - Billing Address";
            }

            dgvBillingAddress.Columns["CityID"].Width = 250;

        }

        #endregion

        #region "Private Helper Methods"

        private void LoadCIty()
        {
            dtCity = objCommon.GetCityList();
            for (int i = 0; i < dtCity.Rows.Count; i++)
            {
                scAutoComplete.Add(dtCity.Rows[i][1].ToString());
            }

            DataGridViewComboBoxColumn clmCity = this.dgvBillingAddress.Columns["CityID"] as DataGridViewComboBoxColumn;
            DataRow dr;
            dr = dtCity.NewRow();
            dr["CityName"] = "";
            dr["CityID"] = 0;
            dtCity.Rows.InsertAt(dr, 0);

            clmCity.DataSource = dtCity;
            dtTempCity = dtCity.Copy();
            clmCity.DisplayMember = "CityName";
            clmCity.ValueMember = "CityID";
            //  dgvBillingAddress.Columns["CityID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvBillingAddress.Columns["CityID"].Width = 100;

        }

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_AddressType", _AddressType.ToString());
                para.Add("@i_RefID", _RefID.ToString());

                dtblBillingAddress = objList.ListOfRecord("usp_AddressDetail_List", para, "BillingAddress - LoadList");

                if (objList.Exception == null)
                {
                    ArrangeDataGridView();
                    dgvBillingAddress.AutoGenerateColumns = false;
                    // dgvBillingAddress.DataSource = dtblBillingAddress;
                    for (int i = 0; i < dtblBillingAddress.Rows.Count; i++)
                    {
                        dgvBillingAddress.Rows.Add();
                    }

                    for (int i = 0; i < dtblBillingAddress.Rows.Count; i++)
                    {
                        dgvBillingAddress.Rows[i].Cells[0].Value = dtblBillingAddress.Rows[i]["Address1"].ToString();
                        dgvBillingAddress.Rows[i].Cells[1].Value = dtblBillingAddress.Rows[i]["Address2"].ToString();
                        dgvBillingAddress.Rows[i].Cells[2].Value = Convert.ToInt64(dtblBillingAddress.Rows[i]["CityID"].ToString());
                        dgvBillingAddress.Rows[i].Cells[3].Value = dtblBillingAddress.Rows[i]["Phone1"].ToString();
                        dgvBillingAddress.Rows[i].Cells[4].Value = dtblBillingAddress.Rows[i]["Phone2"].ToString();
                        dgvBillingAddress.Rows[i].Cells[5].Value = dtblBillingAddress.Rows[i]["Mobile"].ToString();
                        dgvBillingAddress.Rows[i].Cells[6].Value = dtblBillingAddress.Rows[i]["Fax"].ToString();
                        dgvBillingAddress.Rows[i].Cells[7].Value = dtblBillingAddress.Rows[i]["Pincode"].ToString();
                        dgvBillingAddress.EndEdit();
                    }


                    ArrangeDataGridView();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvBillingAddress.Columns["Address1"].DataPropertyName = dtblBillingAddress.Columns["Address1"].ToString();
                dgvBillingAddress.Columns["Address2"].DataPropertyName = dtblBillingAddress.Columns["Address2"].ToString();
                dgvBillingAddress.Columns["CityID"].DataPropertyName = dtblBillingAddress.Columns["CityID"].ToString();
                dgvBillingAddress.Columns["Phone1"].DataPropertyName = dtblBillingAddress.Columns["Phone1"].ToString();
                dgvBillingAddress.Columns["Phone2"].DataPropertyName = dtblBillingAddress.Columns["Phone2"].ToString();
                dgvBillingAddress.Columns["Mobile"].DataPropertyName = dtblBillingAddress.Columns["Mobile"].ToString();
                dgvBillingAddress.Columns["Fax"].DataPropertyName = dtblBillingAddress.Columns["Fax"].ToString();
                dgvBillingAddress.Columns["Pincode"].DataPropertyName = dtblBillingAddress.Columns["Pincode"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event"

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            dgvBillingAddress.EndEdit();

            for (int i = 0; i < dgvBillingAddress.RowCount; i++)
            {
                if (dgvBillingAddress.Rows[i].IsNewRow == false)
                {
                    if (dgvBillingAddress.Rows[i].Cells["Address1"].Value.ToString() == "")
                    {
                        lblErrorMessage.Text = "Enter address1";
                        dgvBillingAddress.CurrentCell = dgvBillingAddress.Rows[i].Cells["Address1"];
                        dgvBillingAddress.BeginEdit(true);
                        return;
                    }
                    else if (Convert.ToInt64(dgvBillingAddress.Rows[i].Cells["CityID"].Value) <= 0)
                    {
                        lblErrorMessage.Text = "Select city";
                        dgvBillingAddress.CurrentCell = dgvBillingAddress.Rows[i].Cells["CityID"];
                        dgvBillingAddress.BeginEdit(true);
                        return;
                    }
                    else if (dgvBillingAddress.Rows[i].Cells["Phone1"].Value == null || dgvBillingAddress.Rows[i].Cells["Phone1"].Value.ToString() == "")
                    {
                        lblErrorMessage.Text = "Enter phone 1";
                        dgvBillingAddress.CurrentCell = dgvBillingAddress.Rows[i].Cells["Phone1"];
                        dgvBillingAddress.BeginEdit(true);
                        return;
                    }
                }
            }

            //Prepare XMLString
            int Cnt = 0;
            string XMLString = string.Empty;
            XMLString = "<NewDataSet>";
            for (int i = 0; i < dgvBillingAddress.Rows.Count; i++)
            {
                if (dgvBillingAddress.Rows[i].IsNewRow == false)
                {
                    XMLString = XMLString + "<Table>";
                    XMLString = XMLString + "<Address1>" + dgvBillingAddress.Rows[i].Cells["Address1"].Value + "</Address1>";
                    XMLString = XMLString + "<Address2>" + dgvBillingAddress.Rows[i].Cells["Address2"].Value + "</Address2>";
                    XMLString = XMLString + "<CityID>" + dgvBillingAddress.Rows[i].Cells["CityID"].Value + "</CityID>";
                    XMLString = XMLString + "<Pincode>" + dgvBillingAddress.Rows[i].Cells["Pincode"].Value + "</Pincode>";
                    XMLString = XMLString + "<Phone1>" + dgvBillingAddress.Rows[i].Cells["Phone1"].Value + "</Phone1>";
                    XMLString = XMLString + "<Phone2>" + dgvBillingAddress.Rows[i].Cells["Phone2"].Value + "</Phone2>";
                    XMLString = XMLString + "<Mobile>" + dgvBillingAddress.Rows[i].Cells["Mobile"].Value + "</Mobile>";
                    XMLString = XMLString + "<Fax>" + dgvBillingAddress.Rows[i].Cells["Fax"].Value + "</Fax>";
                    XMLString = XMLString + "</Table> ";
                    Cnt = Cnt + 1;
                }
            }
            XMLString = XMLString + "</NewDataSet>";

            objCP.Insert(_AddressType, _RefID, XMLString, Cnt);

            if (objCP.Exception == null)
            {
                if (objCP.ErrorMessage != "")
                {
                    lblErrorMessage.Text = objCP.ErrorMessage;
                    dgvBillingAddress.Focus();
                    return;
                }
                else
                {
                    lblErrorMessage.Text = "No error";
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show(objCP.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvBillingAddress_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvBillingAddress, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvBillingAddress, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvBillingAddress_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvBillingAddress_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBillingAddress.CurrentRow != null)
                {
                    this.dgvBillingAddress.CurrentCell.Style.SelectionBackColor = Color.White;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvBillingAddress_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvBillingAddress.Rows.Count > 0)
                {
                    this.dgvBillingAddress.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvBillingAddressl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void dgvBillingAddress_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DataGridView dgv = (DataGridView)sender;
                ComboBox cbo = dgv.EditingControl as ComboBox;
                if (cbo != null)
                {
                    if (cbo.Text.Length > 0)
                    {
                        cbo.SelectedIndex = cbo.FindString(cbo.Text.Trim());
                        if (cbo.SelectedValue == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                        DataGridViewComboBoxCell cbocell = (DataGridViewComboBoxCell)dgvBillingAddress.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        cbocell.Value = cbo.SelectedValue;

                        DataView dv = new DataView();
                        dv = dtTempCity.DefaultView;
                        dv.RowFilter = "CityName='" + cbo.Text + "'"; 
                        if (dv.ToTable().Rows.Count > 0)
                        {
                            dgvBillingAddress.CurrentRow.Cells[2].Value = dv.ToTable().Rows[0][0];
                            dv.RowFilter = null;
                            return;
                        }

                    }
                }
            }
        }

        public void KeyPressed(object o, KeyPressEventArgs e)
        {
            try
            {
                if ((int)e.KeyChar == 38 || (int)e.KeyChar == 60)
                {
                    e.Handled = true;
                }

                if (dgvBillingAddress.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt16(e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }

                    if (dgvBillingAddress.CurrentCell.ColumnIndex == 2)
                    {
                        var combo = o as DataGridViewComboBoxEditingControl;
                        combo.DroppedDown = true;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvBillingAddress_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += KeyPressed;
                if (dgvBillingAddress.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
                {
                    ComboBox t = (ComboBox)e.Control;
                    t.DropDownStyle = ComboBoxStyle.DropDown;
                    t.AutoCompleteCustomSource = scAutoComplete;
                    t.AutoCompleteMode = AutoCompleteMode.None;
                    t.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("BillingAddress", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

    }
}
