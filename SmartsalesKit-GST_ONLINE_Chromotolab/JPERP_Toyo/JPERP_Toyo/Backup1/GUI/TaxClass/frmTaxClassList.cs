using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Account.Common;
using Account.BusinessLogic;
using System.Collections.Specialized;
using System.Configuration;

namespace Account.GUI.TaxClass
{
    public partial class frmTaxClassList : Account.GUIBase
    {
        #region "Public Variable Declarations..."

        DataTable dtblTaxClass = new DataTable();
        CommonListBL CommList = new CommonListBL();
        int idgvPosition = 0;
        DataGridViewColumn sortedColumn;
        SortOrder sortDirection;
        string StrFilter = "";
        DataView DV;

        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        #endregion

        #region "Form Event..."

        public frmTaxClassList()
        {
            InitializeComponent();
        }

        private void frmTaxClassList_Load(object sender, EventArgs e)
        {
            AddHandlers(this);
            SetControlsDefaults(this);

            LoadList();
            DV = dtblTaxClass.DefaultView;
            DV.RowFilter = StrFilter;

            
                dgvTaxClass.DataSource = DV.ToTable();

                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#7002#") != -1)
                        { btnNew.Enabled = true; }
                        else { btnNew.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#7003#") != -1)
                        { btnEdit.Enabled = true; }
                        else { btnEdit.Enabled = false; }
                        if (CurrentUser.PrivilegeStr.IndexOf("#7004#") != -1)
                        { btnDelete.Enabled = true; }
                        else { btnDelete.Enabled = false; }
                    }
                }
        }

        #endregion

        #region "Private Methods..."

        public void LoadList()
        {
            try
            {

                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_UserID", CurrentUser.UserID.ToString());
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtblTaxClass = CommList.ListOfRecord("usp_TaxClass_List", para1, "Tax Class - LoadList");
                if (CommList.Exception != null)
                {
                    MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dgvTaxClass.CurrentRow != null)
                {
                    idgvPosition = dgvTaxClass.CurrentRow.Index;
                }
                ArrangeDataGridView();
                dgvTaxClass.AutoGenerateColumns = false;

                dgvTaxClass.DataSource = dtblTaxClass;
                lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvTaxClass.RowCount.ToString();

                if (dgvTaxClass.CurrentRow != null && idgvPosition <= dgvTaxClass.RowCount)
                {
                    if (dgvTaxClass.Rows.Count - 1 < idgvPosition)
                    {
                        dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition - 1].Cells[0];
                    }
                    else
                    {
                        dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition].Cells[0];
                    }
                }
                ArrangeDataGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void ArrangeDataGridView()
        {
            try
            {
                dgvTaxClass.Columns[1].DataPropertyName = dtblTaxClass.Columns["TaxClassID"].ToString();
                dgvTaxClass.Columns[0].DataPropertyName = dtblTaxClass.Columns["TaxClassName"].ToString();
                dgvTaxClass.Columns[2].DataPropertyName = dtblTaxClass.Columns["FromDate"].ToString();
                dgvTaxClass.Columns[3].DataPropertyName = dtblTaxClass.Columns["Excise"].ToString();
                dgvTaxClass.Columns[4].DataPropertyName = dtblTaxClass.Columns["EduCess"].ToString();
                dgvTaxClass.Columns[5].DataPropertyName = dtblTaxClass.Columns["HEduCess"].ToString();
                dgvTaxClass.Columns[6].DataPropertyName = dtblTaxClass.Columns["ServiceTax"].ToString();
                dgvTaxClass.Columns[7].DataPropertyName = dtblTaxClass.Columns["CST"].ToString();
                dgvTaxClass.Columns[8].DataPropertyName = dtblTaxClass.Columns["VAT"].ToString();
                dgvTaxClass.Columns[9].DataPropertyName = dtblTaxClass.Columns["AVAT"].ToString();
                dgvTaxClass.Columns[10].DataPropertyName = dtblTaxClass.Columns["SBCess"].ToString();
                dgvTaxClass.Columns[11].DataPropertyName = dtblTaxClass.Columns["ExtraTaxType"].ToString();
                dgvTaxClass.Columns[12].DataPropertyName = dtblTaxClass.Columns["ExtraTax"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void SetSortedColumns()
        {
            if (dgvTaxClass.SortedColumn != null)
            {
                sortedColumn = dgvTaxClass.SortedColumn;
                sortDirection = dgvTaxClass.SortOrder;
            }
        }

        private void setDefaultGridRecords(object sender, EventArgs e)
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

                dgvTaxClass.Sort(dgvTaxClass.Columns[sortedColumn.Name], LSD);
            }
            if (dgvTaxClass.CurrentRow != null && idgvPosition <= dgvTaxClass.RowCount)
            {
                if (dgvTaxClass.Rows.Count - 1 < idgvPosition)
                {
                    dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition - 1].Cells[0];
                }
                else
                {
                    dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition].Cells[0];
                }
            }
        }

        #endregion

        #region "Button Event..."

  

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
           
                StrFilter = "";
                LoadList();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmTaxClassEntry ftaxclassEntry = new frmTaxClassEntry((int)Common.Constant.Mode.Insert, 0);
                ftaxclassEntry.ShowDialog();
                LoadList();
          
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaxClass.CurrentRow != null)
                {
                    SetSortedColumns();
                    frmTaxClassEntry ftaxclassEntry = new frmTaxClassEntry((int)Common.Constant.Mode.Modify, (Int64)dgvTaxClass.CurrentRow.Cells["TaxClassID"].Value);
                    ftaxclassEntry.ShowDialog();
                    setDefaultGridRecords(sender, e);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaxClass.CurrentRow != null)
                {

                    if (dgvTaxClass.SortedColumn != null)
                    {
                        sortedColumn = dgvTaxClass.SortedColumn;
                        sortDirection = dgvTaxClass.SortOrder;
                    }
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CommDelRec.DeleteRecord((Int64)dgvTaxClass.CurrentRow.Cells["TaxClassID"].Value, "usp_TaxClass_Delete", "TaxClass - Delete");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
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

                                    dgvTaxClass.Sort(dgvTaxClass.Columns[sortedColumn.Name], LSD);
                                }
                                if (dgvTaxClass.CurrentRow != null && idgvPosition <= dgvTaxClass.RowCount)
                                {
                                    if (dgvTaxClass.Rows.Count - 1 < idgvPosition)
                                    {
                                        dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition - 1].Cells[0];
                                    }
                                    else
                                    {
                                        dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition].Cells[0];
                                    }
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTaxClass.CurrentRow != null)
                {
                    if (dgvTaxClass.SortedColumn != null)
                    {
                        sortedColumn = dgvTaxClass.SortedColumn;
                        sortDirection = dgvTaxClass.SortOrder;
                    }
                    if (MessageBox.Show("Do you want to terminate Record?", "Terminate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CommDelRec.DeleteRecord((Int64)dgvTaxClass.CurrentRow.Cells["TaxClassID"].Value, "usp_TaxClass_Terminate", "Tax Class - Terminate");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
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

                                    dgvTaxClass.Sort(dgvTaxClass.Columns[sortedColumn.Name], LSD);
                                }
                                if (dgvTaxClass.CurrentRow != null && idgvPosition <= dgvTaxClass.RowCount)
                                {
                                    if (dgvTaxClass.Rows.Count - 1 < idgvPosition)
                                    {
                                        dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition - 1].Cells[0];
                                    }
                                    else
                                    {
                                        dgvTaxClass.CurrentCell = dgvTaxClass.Rows[idgvPosition].Cells[0];
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(CommDelRec.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid Cell Event"

        private void dgvTaxClass_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvTaxClass, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
                if (e.ColumnIndex == -1)
                {
                    GridDrawCustomHeaderColumns(dgvTaxClass, e, Properties.Resources.Button_Gray_Stripe_01_050);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "TextBox Event"

        private void txtTaxClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ascii = e.KeyChar;
//            Validator.DataValidator.AllowOnlyCharacter(ascii, e);
        }

        #endregion

        #region "Report event"

        private void mnuTaxClass_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptTaxClassRegister.rpt"))
                {
                    //dtblTaxClass.TableName = "TaxClassList";
                    //dtblTaxClass.WriteXmlSchema(@"\TaxClassList.xsd");

                    DataView DVReport;
                    DVReport = dtblTaxClass.DefaultView;
                    DVReport.RowFilter = StrFilter;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptTaxClassRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Tax Class List", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Tax Class List - [Page Size: A4]";
                    fRptView.crViewer.ReportSource = rptDoc;
                    fRptView.ShowDialog();
                }
                else
                {
                    MessageBox.Show("File is not exist");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Tax Class", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            //frmTaxFilter filterSalesinvoice = new frmTaxFilter(dtblTaxClass);
            //filterSalesinvoice.ShowDialog();

            //dgvTaxClass.DataSource = DV.ToTable();
            //lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvTaxClass.RowCount.ToString();

            //ArrangeDataGridView();

            DV = dtblTaxClass.DefaultView;
            DV.RowFilter = StrFilter;
            dgvTaxClass.DataSource = DV.ToTable();
            frmTaxFilter filterSalesinvoice = new frmTaxFilter(dtblTaxClass);
            filterSalesinvoice.ShowDialog();
            DataTable dt = DV.ToTable();
            dgvTaxClass.DataSource = DV.ToTable();
            lblTotRec.Text = Utill.Common.CommonMessage.TotalRecord + dgvTaxClass.RowCount.ToString();

            ArrangeDataGridView();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

    }
}

