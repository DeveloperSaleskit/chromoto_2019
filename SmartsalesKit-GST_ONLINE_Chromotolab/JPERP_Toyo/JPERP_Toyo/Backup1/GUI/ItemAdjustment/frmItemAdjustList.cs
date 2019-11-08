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
using System.Configuration;

namespace Account.GUI.Item_Adjustment
{
    public partial class frmItemAdjustList : Account.GUIBase
    {
        #region "Variable Declaration"

        DataTable dtblItemAdjustment = new DataTable();
        DataView DV;
        CommonListBL objList = new CommonListBL();
        ItemAdjustmentBL objItemAdjust = new ItemAdjustmentBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        int idgvPosition = 0;
        string StrFilter = "";

        SortOrder sortDirection;
        DataGridViewColumn sortedColumn;

        #endregion

        #region "Form Event"

        public frmItemAdjustList()
        {
            InitializeComponent();
        }

        private void frmItemAdjustmentList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);
            dgvItemAdjustment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            LoadList();

            cmbreports.Items.Add("--Select Report--");
            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9066#") != -1)
                    {
                        cmbreports.Items.Add("Item Adjustment Register");
                    }
                }
                else
                {
                    cmbreports.Items.Add("Item Adjustment Register");
                }
            }
            else if (CurrentUser.UserID == 1)
            {
                cmbreports.Items.Add("Item Adjustment Register");
            }


            cmbreports.SelectedIndex = 0;

            if (CurrentUser.UserID != 1)
            {
                if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                {
                    if (CurrentUser.PrivilegeStr.IndexOf("#9062#") != -1)
                    { btnNew.Enabled = true; }
                    else { btnNew.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9063#") != -1)
                    { btnEdit.Enabled = true; }
                    else { btnEdit.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9064#") != -1)
                    { btnDelete.Enabled = true; }
                    else { btnDelete.Enabled = false; }
                    if (CurrentUser.PrivilegeStr.IndexOf("#9065#") != -1)
                    { btnConfirm.Enabled = true; }
                    else { btnConfirm.Enabled = false; }

                }
            }

        }

        #endregion

        #region "Private Helper Methods"

        private void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();

                para.Add("@i_FYID", CurrentUser.FYID.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());
                para.Add("@i_CompanyID", CurrentCompany.CompId.ToString());

                dtblItemAdjustment = objList.ListOfRecord("usp_ItemAdjustment_List", para, "ItemAdjustment - LoadList");

                if (objList.Exception == null)
                {
                    if (dgvItemAdjustment.CurrentRow != null)
                    {
                        idgvPosition = dgvItemAdjustment.CurrentRow.Index;
                    }

                    ArrangeDataGridView();
                    dgvItemAdjustment.AutoGenerateColumns = false;
                    dgvItemAdjustment.DataSource = dtblItemAdjustment;

                    lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemAdjustment.RowCount.ToString();
                    if (dgvItemAdjustment.CurrentRow != null && idgvPosition <= dgvItemAdjustment.RowCount)
                    {
                        if (dgvItemAdjustment.Rows.Count - 1 < idgvPosition)
                        {
                            dgvItemAdjustment.CurrentCell = dgvItemAdjustment.Rows[idgvPosition - 1].Cells[0];
                        }
                        else
                        {
                            dgvItemAdjustment.CurrentCell = dgvItemAdjustment.Rows[idgvPosition].Cells[0];
                        }
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
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvItemAdjustment.Columns["AdjustmentID"].DataPropertyName = dtblItemAdjustment.Columns["AdjustmentID"].ToString();
                dgvItemAdjustment.Columns["AdjustDate"].DataPropertyName = dtblItemAdjustment.Columns["AdjustDate"].ToString();
                dgvItemAdjustment.Columns["ItemID"].DataPropertyName = dtblItemAdjustment.Columns["ItemID"].ToString();
                dgvItemAdjustment.Columns["ItemCode"].DataPropertyName = dtblItemAdjustment.Columns["ItemCode"].ToString();
                dgvItemAdjustment.Columns["ItemName"].DataPropertyName = dtblItemAdjustment.Columns["ItemName"].ToString();
                dgvItemAdjustment.Columns["Qty"].DataPropertyName = dtblItemAdjustment.Columns["Qty"].ToString();
                dgvItemAdjustment.Columns["Status"].DataPropertyName = dtblItemAdjustment.Columns["Status"].ToString();
                dgvItemAdjustment.Columns["Godown_name"].DataPropertyName = dtblItemAdjustment.Columns["Godown_name"].ToString();
                dgvItemAdjustment.Columns["Narration"].DataPropertyName = dtblItemAdjustment.Columns["Narration"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            try
            {
                if (dgvItemAdjustment.SortedColumn != null)
                {
                    sortedColumn = dgvItemAdjustment.SortedColumn;
                    sortDirection = dgvItemAdjustment.SortOrder;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
        {
            try
            {
                LoadList();


                if (sortedColumn != null)
                {
                    ListSortDirection LSD;
                    if (sortDirection == SortOrder.Ascending)
                    {
                        LSD = System.ComponentModel.ListSortDirection.Ascending;
                    }
                    else
                    {
                        LSD = System.ComponentModel.ListSortDirection.Descending;
                    }

                    dgvItemAdjustment.Sort(dgvItemAdjustment.Columns[sortedColumn.Name], LSD);
                }
                if (dgvItemAdjustment.CurrentRow != null && idgvPosition <= dgvItemAdjustment.RowCount)
                {
                    if (dgvItemAdjustment.Rows.Count - 1 < idgvPosition)
                    {
                        dgvItemAdjustment.CurrentCell = dgvItemAdjustment.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvItemAdjustment.CurrentCell = dgvItemAdjustment.Rows[idgvPosition].Cells[0];
                    }
                }
                dgvItemAdjustment_SelectionChanged(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Button Event"

        private void btnApply_Click(object sender, EventArgs e)
        {
            DV = dtblItemAdjustment.DefaultView;
            DV.RowFilter = StrFilter;
            dgvItemAdjustment.DataSource = DV.ToTable();
            ItemAdjustment.frmItemAdjustmentFilter filterSalesinvoice = new ItemAdjustment.frmItemAdjustmentFilter(dtblItemAdjustment);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            DataTable dt = DV.ToTable();
            dgvItemAdjustment.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvItemAdjustment.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {

                StrFilter = "";
                LoadList();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmItemAdjustEntry fItemAdjustment = new frmItemAdjustEntry((int)Constant.Mode.Insert, 0);
                fItemAdjustment.ShowDialog();
                LoadList();
                btnClear_Click(sender, e);
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemAdjustment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmItemAdjustEntry fItemAdjustment = new frmItemAdjustEntry((int)Constant.Mode.Modify, Convert.ToInt64(dgvItemAdjustment.CurrentRow.Cells["AdjustmentID"].Value));
                    fItemAdjustment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemAdjustment.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmItemAdjustEntry fItemAdjustment = new frmItemAdjustEntry((int)Constant.Mode.Delete, Convert.ToInt64(dgvItemAdjustment.CurrentRow.Cells["AdjustmentID"].Value));
                    fItemAdjustment.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvItemAdjustment.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to confirm record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SetSortedColumns();
                        objItemAdjust.Confirm((Int64)dgvItemAdjustment.CurrentRow.Cells["AdjustmentID"].Value);
                        if (objItemAdjust.Exception == null)
                        {
                            if (objItemAdjust.ErrorMessage != "")
                            {
                                MessageBox.Show(objItemAdjust.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                setDefaultGridRecords(sender, e);
                            }
                        }
                        else
                        {
                            MessageBox.Show(objItemAdjust.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("City", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid View Event"

        private void dgvItemAdjustment_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvItemAdjustment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvItemAdjustment, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        private void dgvItemAdjustment_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnConfirm.Enabled = true;
                if (dgvItemAdjustment.CurrentRow != null)
                {
                    if (dgvItemAdjustment.CurrentRow.Cells["Status"].Value.ToString() == "Confirmed")
                    {
                        btnEdit.Enabled = false;
                        btnDelete.Enabled = false;
                        btnConfirm.Enabled = false;
                    }
                    else
                    {
                        btnEdit.Enabled = true;
                        btnDelete.Enabled = true;
                        btnConfirm.Enabled = true;
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("ItemAdjustment", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Textbox KeyPress Event"

        private void txtFromDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, "/,-");
        }

        #endregion



        #region "Report Menu"

        private void rptIitemAdjustmentRegister_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex == 1)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemAdjustmentRegister.rpt"))
                    {
                        //dtblItemAdjustment .TableName = "ItemAdjustmentRegister";
                        //dtblItemAdjustment.WriteXmlSchema(@"D:\Report\ItemAdjustmentRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblItemAdjustment.DefaultView;
                        DVReport.RowFilter = StrFilter;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptItemAdjustmentRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Adjustment Register", true, true, true, true, false, true, true, false, false, false, false);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Item Adjustment Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("File is not exist...");
                    }
                }
                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("ItemAdjustment - Register Report", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
            cmbreports.SelectedIndex = 0;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
        }




    }
}
