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
using System.Diagnostics;
using System.Configuration;

namespace Account.GUI.ItemParent
{
    public partial class frmItemParentList : Account.GUIBase
    {

        #region "Public Variable Declaration...."

        CommonListBL CommList = new CommonListBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();

        DataTable dtblItemClass = new DataTable();
        DataTable dtblItemGroup = new DataTable();
        DataTable dtblItemCategory = new DataTable();
        DataTable dtblUOM = new DataTable();
        int idgvPositionItemClass = 0;
        int idgvPositionItemGroup = 0;
        int idgvPositionItemCategory = 0;
        int idgvPositionUOM = 0;
        DataView DV;
        bool IsShowAllItemClass = false;
        bool IsShowAllItemGroup = false;
        bool IsShowAllItemCategory = false;
        string StrFilter = "";

        //bool valItemClass = false;
        bool valItemGroup = false;
        //bool valItemCategory = false;
        //bool valUOM = false;

        #endregion

        #region "Form Load Event"

        public frmItemParentList()
        {
            InitializeComponent();
        }

        private void frmItemParentList_Load(object sender, EventArgs e)
        {
            try
            {
                cmbreports.Items.Add("--Select Report--");
                if (CurrentUser.UserID != 1)
                {
                    if (ConfigurationManager.AppSettings["URENABLE"].ToString() == "TRUE")
                    {
                        if (CurrentUser.PrivilegeStr.IndexOf("#5005#") != -1)
                        {
                            //DataTable dtCombo = new DataTable();
                            //NameValueCollection para = new NameValueCollection();
                            //para.Add("@i_ComboEnabled", "5005");
                            //dtCombo = CommList.ListOfRecord("usp_Combo_List", para, "Combo List");
                            cmbreports.Items.Add("UOM Register");
                        }
                    }
                    else
                    {
                        cmbreports.Items.Add("UOM Register");
                    }
                }
                else if (CurrentUser.UserID == 1)
                {
                    cmbreports.Items.Add("UOM Register");
                }
                cmbreports.SelectedIndex = 0;
                AddHandlers(this);
                SetControlsDefaults(this);

                LoadUOMList();
                DV = dtblUOM.DefaultView;
                DV.RowFilter = StrFilter;

                dgvUOM.DataSource = DV.ToTable();

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Parent - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        #endregion

        #region "Private methods"

        public void LoadUOMList()
        {


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_UserID", CurrentUser.UserID.ToString());
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());

            dtblUOM = CommList.ListOfRecord("usp_UOM_List", para, "ItemParentList - LoadUOMList");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (dgvUOM.CurrentRow != null)
            {
                idgvPositionUOM = dgvUOM.CurrentRow.Index;
            }

            ArrangeUOMGridView();
            dgvUOM.AutoGenerateColumns = false;
            dgvUOM.DataSource = dtblUOM;

            lblTotRecUOM.Text = Utill.Common.CommonMessage.TotalRecord + dgvUOM.RowCount.ToString();
            if (dgvUOM.CurrentRow != null && idgvPositionUOM <= dgvUOM.RowCount)
            {
                if (dgvUOM.Rows.Count - 1 < idgvPositionUOM)
                {
                    dgvUOM.CurrentCell = dgvUOM.Rows[idgvPositionUOM - 1].Cells[0];
                }
                else
                {
                    dgvUOM.CurrentCell = dgvUOM.Rows[idgvPositionUOM].Cells[0];
                }
            }

            ArrangeUOMGridView();

        }

        private void ArrangeUOMGridView()
        {
            try
            {
                dgvUOM.Columns[0].DataPropertyName = dtblUOM.Columns["UOM"].ToString();
                dgvUOM.Columns[1].DataPropertyName = dtblUOM.Columns["Abbr"].ToString();
                dgvUOM.Columns[2].DataPropertyName = dtblUOM.Columns["UOMID"].ToString();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Item Parent - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        #region "Button Event"


        private void btnNewUOM_Click(object sender, EventArgs e)
        {
            try
            {
                frmUOMEntry fUOM = new frmUOMEntry((int)Common.Constant.Mode.Insert, 0);
                fUOM.ShowDialog();
                LoadUOMList();
                if (dgvUOM.Rows.Count > 0)
                {
                    dgvUOM.CurrentCell = dgvUOM.Rows[0].Cells[0];
                }

            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("UOM - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnEditUOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUOM.CurrentRow != null)
                {
                    frmUOMEntry fUOM = new frmUOMEntry((int)Common.Constant.Mode.Modify, (Int64)dgvUOM.CurrentRow.Cells["UOMID"].Value);
                    fUOM.ShowDialog();
                    LoadUOMList();

                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("UOM - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnDeleteUOM_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUOM.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete Record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CommDelRec.DeleteRecord((Int64)dgvUOM.CurrentRow.Cells["UOMID"].Value, "usp_UOM_Delete", "UOM - Delete");
                        if (CommDelRec.Exception == null)
                        {
                            if (CommDelRec.ErrorMessage != "")
                            {
                                MessageBox.Show(CommDelRec.ErrorMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                LoadUOMList();
                                //dgvCountry_SelectionChanged(sender, e);
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
                Utill.Common.ExceptionLogger.writeException("Item Parent - List", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Grid Cell Event"

        private void dgvUOM_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                GridDrawCustomHeaderColumns(dgvUOM, e, Properties.Resources.Button_Gray_Stripe_01_050);
            }
            if (e.ColumnIndex == -1)
            {
                GridDrawCustomHeaderColumns(dgvUOM, e, Properties.Resources.Button_Gray_Stripe_01_050);
            }
        }

        #endregion

        #region "Grid Selection change Event..."


        #endregion

        #region "Report menu"

        private void mnuItemClassRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemClassRegister.rpt"))
                {
                    //dtblItemClass.TableName = "ItemClassRegister";
                    //dtblItemClass.WriteXmlSchema(@"C:\Report\ItemClassRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblItemClass.DefaultView;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptItemClassRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Class Register", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Item Class Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Item Class - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void mmuItemGroupRegister_Click(object sender, EventArgs e)
        {

            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemGroupRegister.rpt"))
                {
                    //dtblItemGroup.TableName = "ItemGroupRegister";
                    //dtblItemGroup.WriteXmlSchema(@"D:\Report\ItemGroupRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblItemGroup.DefaultView;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptItemGroupRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Group Register", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Item Group Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Item Group - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void mmuItemCategoryRegister_Click(object sender, EventArgs e)
        {

            try
            {
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptItemCategoryRegister.rpt"))
                {
                    //dtblItemCategory.TableName = "ItemCategoryRegister";
                    //dtblItemCategory.WriteXmlSchema(@"D:\Report\ItemCategoryRegister.xsd");

                    DataView DVReport;
                    DVReport = dtblItemCategory.DefaultView;
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    rptDoc.Load(CurrentUser.ReportPath + "rptItemCategoryRegister.rpt");

                    CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "Item Category Register", true, true, true, true, false, true, true, false, false, false, false);

                    Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    fRptView.Text = "Item Category Register - [Page Size: A4]";
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
                Utill.Common.ExceptionLogger.writeException("Item Category - Register", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #endregion

        private void btnfilter_Click(object sender, EventArgs e)
        {
            DV = dtblUOM.DefaultView;
            DV.RowFilter = StrFilter;
            frmUOMFilter filterSalesinvoice = new frmUOMFilter(dtblUOM);
            filterSalesinvoice.ShowDialog();
            StrFilter = filterSalesinvoice.STRFILTER;
            dgvUOM.DataSource = DV.ToTable();
            lblTotRecUOM.Text = Utill.Common.CommonMessage.TotalRecord + dgvUOM.RowCount.ToString();

            ArrangeUOMGridView();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            StrFilter = "";
            LoadUOMList();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start(CurrentUser.ReportPath + @"Help\DWCCatalog.pdf");
            Help obj = new Help();
            obj.ShowDialog();
        }

        private void cmbreports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbreports.SelectedIndex > 0)
            {
                try
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptUOMRegister.rpt"))
                    {
                        //dtblUOM.TableName = "UOMRegister";
                        //dtblUOM.WriteXmlSchema(@"D:\Report\UOMRegister.xsd");

                        DataView DVReport;
                        DVReport = dtblUOM.DefaultView;
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptUOMRegister.rpt");

                        CurrentUser.AddReportParameters(rptDoc, DVReport.ToTable(), "UOM Register", true, true, true, true, false, true, true, false, false, false, true);

                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "UOM Register - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }

                catch (Exception exc)
                {
                    Utill.Common.ExceptionLogger.writeException("UOM - Register", exc.StackTrace);
                    MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
                }
            }
        }

    }
}
