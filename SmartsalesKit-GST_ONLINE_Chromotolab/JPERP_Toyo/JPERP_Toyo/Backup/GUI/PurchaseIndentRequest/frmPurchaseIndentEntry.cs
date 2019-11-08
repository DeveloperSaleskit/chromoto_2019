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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;


namespace Account.GUI.PurchaseIndentRequest
{
    public partial class frmPurchaseIndentEntry : Account.GUIBase
    {
        #region "Variable Declaration..."

        string dtdate;
        string custcode;
        Int16 AccCustID = 0;


        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        PurchaseIndentBL objPurchaseIndentBL = new PurchaseIndentBL();



        CustomerMainBL objLeadBL1 = new CustomerMainBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        Exception mException = null;
        string mErrorMsg = "";
        int CompId = 0;
        int editdetails = 0;
        CommonListBL objList = new CommonListBL();

        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtLead = new DataTable();
        int _Mode = 0;
        Int64 _LeadID = 0;
        CommonListBL CommList = new CommonListBL();
        int _CompId = 0;
        Int64 _AccountID = 0;
        DataTable dtblLOV = new DataTable();
        string StrFilter = "";
        string leaddocno = "";
        DataView DV;
        string ID = "";
        long _CustomerID = 0;

        DataTable dtDocList = new DataTable();
        string SelectedFileName = "";
        #endregion

        #region "Public Methods..."

        public void BindControl()
        {
            DataSet dsLead = new DataSet();
            // dtLead = CommSelect.SelectRecord(_LeadID, "usp_Lead_Select", "Lead - BindControl");
            dsLead = CommSelect.SelectDataSetRecord(_LeadID, "usp_PurchaseIndent_Select", "PurchaseIndent - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (dsLead.Tables[0].Rows.Count > 0)
                    {
                        txtLeadNo.Text = dsLead.Tables[0].Rows[0]["SrNo"].ToString();
                        dtpLeadDate.Value = Convert.ToDateTime(dsLead.Tables[0].Rows[0]["IndentDate"].ToString());
                        txtitemcode.Text = dsLead.Tables[0].Rows[0]["itemcode"].ToString();
                        txtproductcode.Text = dsLead.Tables[0].Rows[0]["productcode"].ToString();

                        txtitemdetails.Text = dsLead.Tables[0].Rows[0]["itemDetails"].ToString();
                        txtqtyreqd.Text = dsLead.Tables[0].Rows[0]["qtyreqd"].ToString();
                        txtqtyinstock.Text = dsLead.Tables[0].Rows[0]["qtyinstock"].ToString();
                        txtstockinhand.Text = dsLead.Tables[0].Rows[0]["stockinhand"].ToString();
                        txtapproxunitprie.Text = dsLead.Tables[0].Rows[0]["unitprice"].ToString();
                        txtapproxtotalcoast.Text = dsLead.Tables[0].Rows[0]["totalcost"].ToString();

                        txtitemused.Text = dsLead.Tables[0].Rows[0]["itemused"].ToString();
                        txtpurchaseindent.Text = dsLead.Tables[0].Rows[0]["purchaseindent"].ToString();
                        txtstatusPo.Text = dsLead.Tables[0].Rows[0]["statuspo"].ToString();
                        txtremarks.Text = dsLead.Tables[0].Rows[0]["Remarks"].ToString();
                      

                        /* code for Docs open*/

                        if (dsLead.Tables[1] != null && dsLead.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow DRow in dsLead.Tables[1].Rows)
                            {
                                DataRow dr = dtDocList.NewRow();
                                dr["QDocID"] = DRow["QDocID"].ToString();
                                dr["FileName"] = DRow["DocName"].ToString();
                                dr["FullFileName"] = DRow["DocName"].ToString();
                                // dr["DocRemark"] = DRow["Remarks"].ToString();
                                dtDocList.Rows.Add(dr);
                            }
                            ArrangeDocumentGridView();
                            dgvCountry.AutoGenerateColumns = false;
                            dgvCountry.DataSource = dtDocList;
                            ArrangeDocumentGridView();
                        }
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



        public bool isRecordSave(string retMsg)
        {
            if (retMsg == null)
            {
                return false;
            }
            if (retMsg.Length > 0)
            {
                Int32 dummyInt;
                try
                {
                    dummyInt = Int32.Parse(retMsg);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetSave()
        {
            bool ReturnValue = false;
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_LeadID, "usp_PurchaseIndent_Delete", "PurchaseIndent Delete - SetSave");
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
                    if (DataValidator.IsValid(this.grpData))
                    {
                        if (_Mode == (int)Common.Constant.Mode.Insert)
                        {


                            objPurchaseIndentBL.Insert(txtLeadNo.Text, dtpLeadDate.Value, txtitemcode.Text, txtproductcode.Text,
                                txtitemdetails.Text, Convert.ToDecimal(txtqtyreqd.Text), Convert.ToDecimal(txtqtyinstock.Text), Convert.ToDecimal(txtstockinhand.Text),
                                Convert.ToDecimal(txtapproxunitprie.Text), Convert.ToDecimal(txtapproxtotalcoast.Text), txtitemused.Text, txtpurchaseindent.Text, txtstatusPo.Text, txtremarks.Text);


                            if (objPurchaseIndentBL.Exception == null)
                            {
                                if (objPurchaseIndentBL.Exception == null)
                                {
                                    //--for doc save code
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        // DataTable dtdoc = new DataTable();
                                        // leaddocno = txtLeadNo.Text.ToString();
                                        // NameValueCollection padoc = new NameValueCollection();
                                        // padoc.Add("@i_leaddocno", leaddocno.ToString());
                                        // DataAccess.DataAccess objleaddoc = new DataAccess.DataAccess();
                                        //// objleaddoc.ExecuteSP("usp_Leaddocno", padoc, false, ref mException, ref mErrorMsg, "Sale - Insert");
                                        // dtdoc = objList.ListOfRecord("usp_Leaddocno", padoc, "Sale - Insert");

                                        // _LeadID = dtdoc.Tables[0].Rows[0]["LeadId"].ToString();



                                        NameValueCollection para = new NameValueCollection();
                                        para.Add("@i_leaddocno", txtLeadNo.Text.ToString());
                                        dtblLOV = objList.ListOfRecord("usp_PurchseIndentDocfinal", para, "PurchaseIndent");
                                        _LeadID = Convert.ToInt16(dtblLOV.Rows[0]["Id"].ToString());



                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            objPurchaseIndentBL.InsertLeadDocument(_LeadID, dr["FileName"].ToString());
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objPurchaseIndentBL.InsertLeadDocument(_LeadID, txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objPurchaseIndentBL.Exception == null)
                                            {
                                                if (objPurchaseIndentBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                }
                                            }
                                        }
                                    }
                                    //---------------


                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                                else
                                {
                                    lblErrorMessage.Text = objPurchaseIndentBL.ErrorMessage;

                                    ReturnValue = false;
                                }

                            }
                            else
                            {
                                MessageBox.Show(objPurchaseIndentBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }

                        }//chkQuotation_Send.Checked
                        else if (_Mode == (int)Common.Constant.Mode.Modify)
                        {

                           
                            objPurchaseIndentBL.Update(_LeadID,txtLeadNo.Text, dtpLeadDate.Value, txtitemcode.Text, txtproductcode.Text,
                                txtitemdetails.Text, Convert.ToDecimal(txtqtyreqd.Text), Convert.ToDecimal(txtqtyinstock.Text), Convert.ToDecimal(txtstockinhand.Text),
                                Convert.ToDecimal(txtapproxunitprie.Text), Convert.ToDecimal(txtapproxtotalcoast.Text), txtitemused.Text, txtpurchaseindent.Text, txtstatusPo.Text, txtremarks.Text);





                            if (objPurchaseIndentBL.Exception == null)
                            {
                                if (objPurchaseIndentBL.Exception == null)
                                {
                                    //--for doc save code
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            objPurchaseIndentBL.InsertLeadDocument(_LeadID, dr["FileName"].ToString());
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objPurchaseIndentBL.InsertLeadDocument(_LeadID, txtLeadNo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objPurchaseIndentBL.Exception == null)
                                            {
                                                if (objPurchaseIndentBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                }
                                            }
                                        }
                                    }
                                    //---------------


                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                                else
                                {
                                    lblErrorMessage.Text = objPurchaseIndentBL.ErrorMessage;

                                    ReturnValue = false;
                                }
                            }
                            else
                            {
                                MessageBox.Show(objPurchaseIndentBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ReturnValue = false;
                            }

                        }


                    }
                }
            }

            return ReturnValue;
        }

        #endregion

        public frmPurchaseIndentEntry(int Mode, long LeadID)
        {
            InitializeComponent();
            _Mode = Mode;
            _LeadID = LeadID;
        }

        private void frmPurchaseIndentEntry_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);




                dtDocList.Columns.Add("QDocID");
                dtDocList.Columns.Add("FileName");
                dtDocList.Columns.Add("FullFileName");



                if (_Mode == (int)Common.Constant.Mode.Insert)
                {

                    txtLeadNo.Text = objCommon.AutoNumber("PI");
                    ID = objCommon.AutoNumberID("PI");
                    this.Text = "Purchase-Indent - New";
                    dtpLeadDate.Value = DateTime.Now;


                    
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnRegenrate.Visible = false;
                    btnSaveContinue.Visible = false;
                    this.Text = "Purchase-Indent - Edit";

                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();
                    btnSaveContinue.Visible = false;
                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    SetReadOnlyControls(grpData);
                    btnRegenrate.Visible = false;
                    btnSaveExit.Text = "Yes";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    btnCancel.Text = "No";
                    this.Text = "Purchase-Indent - Delete";
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Lead-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

      

        private void btnSaveContinue_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                txtLeadNo.Text = "";
                txtLeadNo.Text = objCommon.AutoNumber("PI");
                ID = objCommon.AutoNumberID("PI");
                dtpLeadDate.Value = DateTime.Now;
                txtitemcode.Text = "";
                txtproductcode.Text = "";
              
                txtitemdetails.Text = "";
                txtqtyreqd.Text = "0.0";
                txtqtyinstock.Text = "0.0";
                txtstockinhand.Text = "0.0";
                txtapproxunitprie.Text = "0.0";
                txtapproxtotalcoast.Text = "0.0";
               
                txtitemused.Text = "";
                txtpurchaseindent.Text = "";
                txtstatusPo.Text = "";
                txtremarks.Text = "";
                
                
                txtLeadNo.Focus();
            }
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (SetSave())
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtLeadNo.Text = objCommon.AutoNumber("PI");
        }

        private void txtBudget_KeyPress(object sender, KeyPressEventArgs e)
        {
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
            }
        }

        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            if (txtDocName.Text == "")
            {
                txtDocName.Focus();
                return;
            }
            DataRow dr = dtDocList.NewRow();
            dr["QDocID"] = "0";
            //dr["BlockID"] = "0";
            dr["FileName"] = txtDocName.Text;
            dr["FullFileName"] = SelectedFileName;
            //dr["DocRemark"] = txtComment.Text;
            dtDocList.Rows.Add(dr);

            ArrangeDocumentGridView();
            dgvCountry.AutoGenerateColumns = false;
            dgvCountry.DataSource = dtDocList;
            ArrangeDocumentGridView();
            txtDocName.Text = "";
            SelectedFileName = "";
            //txtComment.Text = "";
            btnAddDoc.Focus();
        }

        public void ArrangeDocumentGridView()
        {
            dgvCountry.Columns["FileName"].DataPropertyName = dtDocList.Columns["FileName"].ToString();
            dgvCountry.Columns["FullFileName"].DataPropertyName = dtDocList.Columns["FullFileName"].ToString();
            //dgvCountry.Columns["BlockId"].DataPropertyName = dtDocList.Columns["BlockId"].ToString();
            dgvCountry.Columns["QDocID"].DataPropertyName = dtDocList.Columns["QDocID"].ToString();
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (dgvCountry.CurrentRow != null)
            {
                int RowIndex = dgvCountry.CurrentRow.Index;
                dtDocList.Rows[RowIndex].Delete();
                dtDocList.AcceptChanges();

                dgvCountry.AutoGenerateColumns = false;
                dgvCountry.DataSource = dtDocList;
                ArrangeDocumentGridView();
            }
        }

        private void dgvCountry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 0)
                {
                    if (_Mode == (int)Common.Constant.Mode.Insert)
                    {
                        MessageBox.Show("Please save record and then you can edit document in Edit Sale record.");
                        return;
                    }
                    string strFile;
                    strFile = CurrentUser.DocumentPath + dgvCountry.Rows[e.RowIndex].Cells["FullFileName"].Value.ToString();

                    Process.Start(strFile);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation-List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                editdetails = 1;
               

            }
            catch (Exception)
            {

                throw;
            }
        }

       


        //  DataValidator.AllowO

    }
}
