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


namespace Account.GUI.AccountMaster
{
    public partial class frmLedgerReport : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonListBL CommList = new CommonListBL();
        CommissionBL objCommisionBL = new CommissionBL();
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();
        DataTable dtAccountMaster = new DataTable();
        long _AccountID = 0;
        int _RptType = 0;
        #endregion

        #region "form Event..."
        public frmLedgerReport(long AccID, int RptType)
        {
            InitializeComponent();
            _AccountID = AccID;
            _RptType = RptType;
        }

        private void frmLedgerReport_Load(object sender, EventArgs e)
        {
            SetControlsDefaults(this);
            AddHandlers(this);

            dtpDate.Value = Common.CurrentUser.FYStartDate.Date;
            //dtpToDate.Value = Common.CurrentUser.FYEndDate.Date;
            FillAccountCombo(cmbAccount);

            if (_AccountID > 0)
            {
                cmbAccount.SelectedValue = _AccountID;
            }
        }
        #endregion


        #region "Button's Event..."

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (_RptType == 2)
            {
                lblErrorMessage.Text = "";
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptProfitnLossStatement.rpt"))
                {

                    DataTable dt = new DataTable();

                    NameValueCollection Para = new NameValueCollection();
                    // Para.Add("@i_AccountID", cmbAccount.SelectedValue.ToString());
                    Para.Add("@i_FromDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                    Para.Add("@i_ToDate", dtpToDate.Value.ToString("MM/dd/yyyy"));

                    dt = CommList.ListOfRecord("rpt_ProfitLossStatement", Para, "Profit Loss Statement");

                    //dt.TableName = "ProfitnLossStatement";
                    //dt.WriteXmlSchema(@"D:\ProfitnLossStatement.xsd");

                    if (CommList.Exception == null)
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptProfitnLossStatement.rpt");

                        CurrentUser.AddReportParameters(rptDoc, dt, "Profit Loss Statement", true, true, true, true, false, true, true, false, false, false, false);
                        rptDoc.SetParameterValue("pFromDate", dtpDate.Value.Date);
                        rptDoc.SetParameterValue("pToDate", dtpToDate.Value.Date);
                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Profit n Loss Statement - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;
                        fRptView.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    //if (cmbAccount.SelectedIndex > 0)
                    //{
                    //    DataTable dt = new DataTable();

                    //    NameValueCollection Para = new NameValueCollection();
                    //   // Para.Add("@i_AccountID", cmbAccount.SelectedValue.ToString());
                    //    Para.Add("@i_FromDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                    //    Para.Add("@i_ToDate", dtpToDate.Value.ToString("MM/dd/yyyy"));

                    //    dt = CommList.ListOfRecord("rpt_ProfitLossStatement", Para, "Profit Loss Statement");

                    //    //dt.TableName = "ProfitnLossStatement";
                    //    //dt.WriteXmlSchema(@"D:\ProfitnLossStatement.xsd");

                    //    if (CommList.Exception == null)
                    //    {
                    //        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    //        rptDoc.Load(CurrentUser.ReportPath + "rptProfitnLossStatement.rpt");

                    //        CurrentUser.AddReportParameters(rptDoc, dt, "Profit Loss Statement", true, true, true, true, false, true, true, false, false, false, false);
                    //        rptDoc.SetParameterValue("pFromDate", dtpDate.Value.Date);
                    //        rptDoc.SetParameterValue("pToDate", dtpToDate.Value.Date);
                    //        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                    //        fRptView.Text = "Profit n Loss Statement - [Page Size: A4]";
                    //        fRptView.crViewer.ReportSource = rptDoc;
                    //        fRptView.ShowDialog();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    }
                    //}
                    //else
                    //{
                    //    lblErrorMessage.Text = "Please select Account";
                    //    return;
                    //}
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }
            else
            {
                //---------------------------------------
                lblErrorMessage.Text = "";
                if (System.IO.File.Exists(CurrentUser.ReportPath + "rptLedger.rpt"))
                {
                    if (cmbAccount.SelectedIndex > 0)
                    {
                        DataTable dt = new DataTable();

                        NameValueCollection Para = new NameValueCollection();
                        Para.Add("@i_AccountID", cmbAccount.SelectedValue.ToString());
                        Para.Add("@i_FromDate", dtpDate.Value.ToString("MM/dd/yyyy"));
                        Para.Add("@i_ToDate", dtpToDate.Value.ToString("MM/dd/yyyy"));

                        dt = CommList.ListOfRecord("rpt_AccountLedger", Para, "Ledger Report");



                        if (CommList.Exception == null)
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                            rptDoc.Load(CurrentUser.ReportPath + "rptLedger.rpt");

                            CurrentUser.AddReportParameters(rptDoc, dt, "Ledger Register", true, true, true, true, false, true, true, false, false, false, false);
                            rptDoc.SetParameterValue("pFromDate", dtpDate.Value.Date);
                            rptDoc.SetParameterValue("pToDate", dtpToDate.Value.Date);
                            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                            fRptView.Text = "Ledger Register - [Page Size: A4]";
                            fRptView.crViewer.ReportSource = rptDoc;
                            fRptView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        lblErrorMessage.Text = "Please select Account";
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("File is not exist...");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Public Methods..."

        public void FillAccountCombo(ComboBox cmb)
        {
            DataTable dtCity = new DataTable();
            dtCity = CommList.ListOfRecord("usp_Account_LOV", null, "Commission - FillAccountCombo");
            if (CommList.Exception != null)
            {
                MessageBox.Show(CommList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DataRow dr;
                dr = dtCity.NewRow();
                dr["AccountID"] = 0;
                dr["AccountName"] = "--Select--";
                dtCity.Rows.InsertAt(dr, 0);
                cmb.DataSource = dtCity;
                cmb.DisplayMember = "AccountName";
                cmb.ValueMember = "AccountID";
            }
        }

        #endregion

    }
}
