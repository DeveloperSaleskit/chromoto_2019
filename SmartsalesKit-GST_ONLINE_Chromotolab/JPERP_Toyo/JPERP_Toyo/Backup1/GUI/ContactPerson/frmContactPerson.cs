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

namespace Account.GUI.ContactPerson
{
    public partial class frmContactPerson : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblContactPerson = new DataTable();
        CommonListBL objList = new CommonListBL();
        ContactPersonBL objCP = new ContactPersonBL();

        int _ContactType = 0;
        //Int64 _RefID = 0;
        string _RefID = "";

        #endregion

        #region "Form Event"

        public frmContactPerson(int ContactType, string RefID)
        {
            InitializeComponent();
            _ContactType = ContactType;
            _RefID = RefID;
        }

        private void frmContactPerson_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvContactPerson .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            LoadList();
            dgvContactPerson.Refresh();
            dgvContactPerson.AllowUserToAddRows = true;
            dgvContactPerson.AllowUserToDeleteRows = true;
            dgvContactPerson.ReadOnly = false;
         
            dgvContactPerson.StandardTab = false;

            if (_ContactType == 0)
            {
                this.Text = "Vendor - Contact Person";
            }
            else if (_ContactType == 1)
            {
                this.Text = "Customer - Contact Person";
            }
            else if (_ContactType == 2)
            {
                this.Text = "Transporter - Contact Person";
            }
            else if (_ContactType == 3)
            {
                this.Text = "Jobworker - Contact Person";
            }
            else if(_ContactType == 4)
            {
                this.Text = "Lead - Contact Person";
            }
        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_ContactType", _ContactType.ToString());
                para.Add("@i_RefID", _RefID.ToString());
                para.Add("@i_CompID", CurrentCompany.CompId.ToString());
                dtblContactPerson = objList.ListOfRecord("usp_ContactDetail_List", para, "ContactPerson - LoadList");

                if (objList.Exception == null)
                {
                    ArrangeDataGridView();
                    dgvContactPerson.AutoGenerateColumns = false;
                    dgvContactPerson.DataSource = dtblContactPerson;

                    ArrangeDataGridView();
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvContactPerson.Columns["ContactID"].DataPropertyName = dtblContactPerson.Columns["ContactID"].ToString();
                dgvContactPerson.Columns["ContactTitle"].DataPropertyName = dtblContactPerson.Columns["ContactTitle"].ToString();
                dgvContactPerson.Columns["ContactName"].DataPropertyName = dtblContactPerson.Columns["ContactName"].ToString();
                dgvContactPerson.Columns["Designation"].DataPropertyName = dtblContactPerson.Columns["Designation"].ToString();
                dgvContactPerson.Columns["Phone1"].DataPropertyName = dtblContactPerson.Columns["Phone1"].ToString();
                dgvContactPerson.Columns["Phone2"].DataPropertyName = dtblContactPerson.Columns["Phone2"].ToString();
                dgvContactPerson.Columns["Mobile"].DataPropertyName = dtblContactPerson.Columns["Mobile"].ToString();
                dgvContactPerson.Columns["Email"].DataPropertyName = dtblContactPerson.Columns["Email"].ToString();
                dgvContactPerson.Columns["DoB"].DataPropertyName = dtblContactPerson.Columns["DoB"].ToString();
                dgvContactPerson.Columns["DoA"].DataPropertyName = dtblContactPerson.Columns["DoA"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event"

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            dgvContactPerson.EndEdit();

            for (int i = 0; i < dgvContactPerson.RowCount; i++)
            {
                if (dgvContactPerson.Rows[i].IsNewRow == false)
                {
                    if (dgvContactPerson.Rows[i].Cells["ContactName"].Value.ToString() == "")
                    {
                        lblErrorMessage.Text = "Enter contact name";
                        dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["ContactName"];
                        dgvContactPerson.BeginEdit(true);
                        return;
                    }
                    //else if (dgvContactPerson.Rows[i].Cells["Designation"].Value.ToString() == "")
                    //{
                    //    lblErrorMessage.Text = "Enter designation";
                    //    dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["Designation"];
                    //    dgvContactPerson.BeginEdit(true);
                    //    return;
                    //}
                    //else if (dgvContactPerson.Rows[i].Cells["Phone1"].Value.ToString() == "")
                    //{
                    //    lblErrorMessage.Text = "Enter Phone 1";
                    //    dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["Phone1"];
                    //    dgvContactPerson.BeginEdit(true);
                    //    return;
                    //}
                    else if (dgvContactPerson.Rows[i].Cells["Email"].Value.ToString() == "")
                    {
                        lblErrorMessage.Text = "Enter Email";
                        dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["Email"];
                        dgvContactPerson.BeginEdit(true);
                        return;
                    }
                    else if (dgvContactPerson.Rows[i].Cells["Email"].Value.ToString() != "")
                    {
                        if (!Regex.IsMatch(dgvContactPerson.Rows[i].Cells["Email"].Value.ToString(), @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                        {
                            lblErrorMessage.Text = "Enter proper email address";
                            dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["Email"];
                            dgvContactPerson.BeginEdit(true);
                            return;
                        }
                    }
                    else if (dgvContactPerson.Rows[i].Cells["DOB"].Value.ToString() != "")
                    {
                        if (Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DOB"].Value).Year < 1800)
                        {
                            lblErrorMessage.Text = "Enter proper birth date";
                            dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["DOB"];
                            dgvContactPerson.BeginEdit(true);
                            return;
                        }
                        else
                        {
                            if (dgvContactPerson.Rows[i].Cells["DOB"].Value.ToString() != "" && dgvContactPerson.Rows[i].Cells["DOA"].Value.ToString() != "")
                            {
                                if (Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DOA"].Value) <= Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DOB"].Value))
                                {
                                    lblErrorMessage.Text = "Anniversary date should be greater than birthdate";
                                    dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["DOA"];
                                    dgvContactPerson.BeginEdit(true);
                                    return;
                                }
                            }
                        }
                    }
                    else if (dgvContactPerson.Rows[i].Cells["DOA"].Value.ToString() != "")
                    {
                        if (Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DOA"].Value).Year < 1800)
                        {
                            lblErrorMessage.Text = "Enter proper anniversary date";
                            dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["DOA"];
                            dgvContactPerson.BeginEdit(true);
                            return;
                        }
                        else
                        {
                            if (dgvContactPerson.Rows[i].Cells["DOB"].Value.ToString() != "" && dgvContactPerson.Rows[i].Cells["DOA"].Value.ToString() != "")
                            {
                                if (Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DOA"].Value) <= Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DOB"].Value))
                                {
                                    lblErrorMessage.Text = "Anniversary date should be greater than birthdate";
                                    dgvContactPerson.CurrentCell = dgvContactPerson.Rows[i].Cells["DOA"];
                                    dgvContactPerson.BeginEdit(true);
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            //for (int i = 0; i < dgvContactPerson.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtblContactPerson.Rows.Count; j++)
            //    {
            //        //if (dgvContactPerson.Rows[i].Cells["ContactID"].Value.ToString() == dtblContactPerson.Rows[i]["ContactID"].ToString() && )
            //        //{

            //        //}
            //    }
            //}

            //Prepare XMLString
            int Cnt = 0;
            string XMLString = string.Empty;
            XMLString = "<NewDataSet>";
            for (int i = 0; i < dgvContactPerson.Rows.Count; i++)
            {
                if (dgvContactPerson.Rows[i].IsNewRow == false)
                {
                    XMLString = XMLString + "<Table>";
                    XMLString = XMLString + "<ContactTitle>" + dgvContactPerson.Rows[i].Cells["ContactTitle"].Value + "</ContactTitle>";
                    XMLString = XMLString + "<ContactName>" + dgvContactPerson.Rows[i].Cells["ContactName"].Value + "</ContactName>";
                    XMLString = XMLString + "<Designation>" + dgvContactPerson.Rows[i].Cells["Designation"].Value + "</Designation>";
                    XMLString = XMLString + "<Phone1>" + dgvContactPerson.Rows[i].Cells["Phone1"].Value + "</Phone1>";
                    XMLString = XMLString + "<Phone2>" + dgvContactPerson.Rows[i].Cells["Phone2"].Value + "</Phone2>";
                    XMLString = XMLString + "<Mobile>" + dgvContactPerson.Rows[i].Cells["Mobile"].Value + "</Mobile>";
                    XMLString = XMLString + "<Email>" + dgvContactPerson.Rows[i].Cells["Email"].Value + "</Email>";
                    if (dgvContactPerson.Rows[i].Cells["DoB"].Value == System.DBNull.Value)
                    {
                        XMLString = XMLString + "<DOB>" + System.DBNull.Value + "</DOB>";
                    }
                    else
                    {
                        XMLString = XMLString + "<DOB>" + Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DoB"].Value).ToString("MM/dd/yyyy") + "</DOB>";
                    }
                    if (dgvContactPerson.Rows[i].Cells["DoA"].Value == System.DBNull.Value)
                    {
                        XMLString = XMLString + "<DOA>" + System.DBNull.Value + "</DOA>";
                    }
                    else
                    {
                        XMLString = XMLString + "<DOA>" + Convert.ToDateTime(dgvContactPerson.Rows[i].Cells["DoA"].Value).ToString("MM/dd/yyyy") + "</DOA>";
                    }
                    XMLString = XMLString + "</Table> ";
                    Cnt = Cnt + 1;
                }
            }
            XMLString = XMLString + "</NewDataSet>";
           
                objCP.Insert(_ContactType, _RefID, XMLString, Cnt);

            if (objCP.Exception == null)
            {
                if (objCP.ErrorMessage != "")
                {
                    lblErrorMessage.Text = objCP.ErrorMessage;
                    dgvContactPerson.Focus();
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

        private void dgvContactPerson_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvContactPerson, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvContactPerson, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvContactPerson_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void dgvContactPerson_CurrentCellChanged(object sender, EventArgs e)
        { 
            try
            {
            if (dgvContactPerson.CurrentRow != null)
            {
                this.dgvContactPerson.CurrentCell.Style.SelectionBackColor = Color.White;
            }
             }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvContactPerson_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvContactPerson.Rows.Count > 0)
                {
                    this.dgvContactPerson.CurrentCell.Style.SelectionBackColor = Color.FromArgb(230, 230, 225);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvContactPersonl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        public void KeyPressed(object o, KeyPressEventArgs e)
        {
            try
            {
                if (dgvContactPerson.CurrentCell.ColumnIndex == 8 || dgvContactPerson.CurrentCell.ColumnIndex == 9)
                {
                    DataValidator.AllowOnlyNumeric(e, "/,-");
                }
                else
                {
                    if ((int)e.KeyChar == 38 || (int)e.KeyChar == 60)
                    {
                        e.Handled = true;
                    }
                }

                if (dgvContactPerson.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt16(e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void dgvContactPerson_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress += KeyPressed;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ContactPerson", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void dgvContactPerson_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           // dtblContactPerson.

            //for (int i = 0; i < dgvContactPerson.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dtblContactPerson.Rows.Count; j++)
            //    {
            //        if (dgvContactPerson.Rows[i].Cells["ContactID"].Value.ToString() == dtblContactPerson.Rows[i]["ContactID"].ToString() && )
            //        {

            //        }
            //    }
            //}
        }
  
    }
}
