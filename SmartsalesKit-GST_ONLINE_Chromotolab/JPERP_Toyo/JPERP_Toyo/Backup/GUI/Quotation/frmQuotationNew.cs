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
using System.Diagnostics;
using System.IO;
using System.Collections.Specialized;
using System.Net.Mail;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;

namespace Account.GUI.Quotation
{
    public partial class frmQuotationNew : Account.GUIBase
    {
        #region "Variable Declaration..."

        CommonSelectBL CommSelect = new CommonSelectBL();
        CommonDeleteBL CommDelRec = new CommonDeleteBL();
        QuotationBL objQuotationBL = new QuotationBL();
        CommonListBL objList = new CommonListBL();
        DataAccess.DataAccess objDA = new DataAccess.DataAccess();
        DataTable dtDocList = new DataTable();

        Exception mException = null;
        string mErrorMsg = "";

        Int64 _QuotationID = 0;
        Int64 _LeadID = 0;
        Int64 _SIID = 0;

        Int64 _PIID = 0;
        Int64 _CustomerID = 0;
        string _XMLTNC = "";
        Int64 _CntTNC = 0;
        int QTNC = 0;
        int QPriview = 0;
        Int64 _BuildingID = 0;
        public bool Is_MailSend;
        public bool Mail_Send;
        int _CompId = 0;
        Int64 _UserID = 0;
        Int64 UserID = 0;
        int CompId = 0;
        public bool Mail_ByUser;
        bool MailStatus;

        string LQuotationID = "";
        DataTable dtblLOV = new DataTable();

        string StrFilter = "";
        DataView DV;
        public int RevisedMode = 0;
        Int64 _CurrencyID;
        bool IsFirstItem;

        int ISEditTNCClicked = 0;
        int ISAllchecked = 0;
        bool IsCustomer;

        public string PdfFile
        {
            get { return mpdfFile; }
            set { mpdfFile = value; }
        }

        string mpdfFile;


        DataTable dtPIDetail = new DataTable();
        DataTable dtContactDetail = new DataTable();
        DataTable dtblUser = new DataTable();
        DataSet dtQuotation = new DataSet();

        string SelectedFileName = "";
        int _Mode = 0;
        int _CMode = 0;
        BusinessLogic.Common objCommon = new Account.BusinessLogic.Common();

        string TYPE_OF_FORM;
        //string IsAllTNC;
        DataTable dtblContactPerson = new DataTable();
        // DataTable dtQTNC = new DataTable();
        DataTable dtQContDetail = new DataTable();
        DataTable dtTnCDetail = new DataTable();
        #endregion

        public
            frmQuotationNew(int Mode, long QuotationID)
        {
            InitializeComponent();
            _Mode = Mode;
            _QuotationID = QuotationID;
            _SIID = QuotationID;
        }

        private void frmQuotationNew_Load(object sender, EventArgs e)
        {
            try
            {
                AddHandlers(this);
                SetControlsDefaults(this);
                //DataValidator.SetDefaultDate(dtpSaleDate, null, null);

                btnLeadLOV.BackColor = Color.LightSkyBlue;
                btnTNC.BackColor = Color.LightSkyBlue;
                btnNew.BackColor = Color.LightSkyBlue;

                objCommon.FillEmployeeCombo(cmbEmp);
                objCommon.FillEmpAllocatedToCombo(cmbEmpAllocatedTo);
                objCommon.FillCurrencyCombo(cmbCurrency);
                objCommon.FillCategoryCombo(cmbCategory);

                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

                //DataValidator.SetDefaultDate(dtpSaleDate, null, null);
                dtpSaleDate.Value = DateTime.Now;
                dtpNextDate.Value = DateTime.Now;

                dtDocList.Columns.Add("QDocID");
                dtDocList.Columns.Add("FileName");
                dtDocList.Columns.Add("FullFileName");

                cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
                cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbCategory.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (ConfigurationManager.AppSettings["SMSENABLE"].ToString() == "True")
                {
                    chkSMS.Visible = true;
                }
                else
                {
                    chkSMS.Visible = false;
                }

                if (_Mode == (int)Common.Constant.Mode.Insert)
                {
                    this.Text = "Quotation - New";
                    txtPINo.Text = objCommon.AutoNumber("QU");


                    LoadPIDetailList();
                    LoadList();
                    btnedit.Visible = false;
                    cmbStatus.SelectedIndex = 5;
                    cmbStatus.Enabled = false;
                    //-----------
                    //btnTNC.Enabled = true;
                    //chkTNC.Checked = false;
                    //------------
                }
                if (_Mode == (int)Common.Constant.Mode.Modify)
                {
                    BindControl();
                    btnLeadLOV.Visible = false;
                    //  btnedit.Visible = false;
                    //dtpSaleDate.Enabled = false;
                    //txtAdvAmt.Enabled = false;
                    //txtSalePrice.Enabled = false;
                    //txtRemark.Enabled = false;
                    //btnLeadLOV.Enabled = false;
                    this.Text = "Quotation - Edit";
                    chkTNC.Enabled = false;
                }
                if (_Mode == (int)Common.Constant.Mode.View)
                {
                    this.Text = "Quotation - New";
                    BindControl();
                    //   btnedit.Visible = true;
                    //     string custno1 = txtCustName.Text.Substring(0, 3) + "/" + "2014-15";
                    //   txtquotationno.Text = objCommon.AutoNumber(custno1);
                    //        btnedit.Visible = true;
                    //  LoadPIDetailList();
                    //txtPINo.Text = "R"+ objCommon.AutoNumber("QU");

                }
                else if (_Mode == (int)Common.Constant.Mode.Delete)
                {
                    BindControl();

                    lblDelMsg.Visible = true;
                    SetReadOnlyControls(grpData);
                    btnSaveExit.Text = "Yes";
                    btnSaveExit.Tag = "Click to delete record;";
                    btnSaveExit.Width = btnCancel.Width;
                    btnSaveExit.Location = new Point(btnSaveExit.Location.X + 30, btnSaveExit.Location.Y);
                    btnCancel.Text = "No";
                    this.Text = "Quotation - Delete";
                }
                //txtBcc.CharacterCasing = CharacterCasing.Normal;
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation-FormLoad", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }
        private void LoadPIDetailList()
        {
            try
            {
                DataColumn clmItemID = new DataColumn("ItemID");
                clmItemID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmItemID);

                DataColumn clmItemName = new DataColumn("ItemName");
                clmItemName.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmItemName);

                DataColumn clmItemDesc = new DataColumn("ItemDesc");
                clmItemDesc.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmItemDesc);

                DataColumn clmItemODesc = new DataColumn("ItemODesc");
                clmItemODesc.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmItemODesc);

                DataColumn clmUOM = new DataColumn("UOM");
                clmUOM.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmUOM);

                DataColumn clmCurrencyID = new DataColumn("CurrencyID");
                clmCurrencyID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmCurrencyID);

                DataColumn clmCurrency = new DataColumn("Currency");
                clmCurrency.DataType = System.Type.GetType("System.String");
                dtPIDetail.Columns.Add(clmCurrency);

                DataColumn clmRate = new DataColumn("Rate");
                clmRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmRate);

                DataColumn clmQty = new DataColumn("Qty");
                clmQty.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmQty);

                DataColumn clmTaxClassID = new DataColumn("TaxClassID");
                clmTaxClassID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmTaxClassID);

                DataColumn clmTotalAmount = new DataColumn("TotalAmount");
                clmTotalAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmTotalAmount);

                DataColumn clmServiceRate = new DataColumn("ServiceRate");
                clmServiceRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmServiceRate);

                DataColumn clmServiceAmount = new DataColumn("ServiceAmount");
                clmServiceAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmServiceAmount);

                DataColumn clmExciseRate = new DataColumn("ExciseRate");
                clmExciseRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExciseRate);

                DataColumn clmExciseAmount = new DataColumn("ExciseAmount");
                clmExciseAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExciseAmount);

                DataColumn clmECessRate = new DataColumn("ECessRate");
                clmECessRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmECessRate);

                DataColumn clmECessAmount = new DataColumn("ECessAmount");
                clmECessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmECessAmount);

                DataColumn clmHECessRate = new DataColumn("HECessRate");
                clmHECessRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmHECessRate);

                DataColumn clmHECessAmount = new DataColumn("HECessAmount");
                clmHECessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmHECessAmount);

                DataColumn clmAmountAfterExcise = new DataColumn("AmountAfterExcise");
                clmAmountAfterExcise.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmAmountAfterExcise);

                DataColumn clmCSTRate = new DataColumn("CSTRate");
                clmCSTRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmCSTRate);

                DataColumn clmCSTAmount = new DataColumn("CSTAmount");
                clmCSTAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmCSTAmount);

                DataColumn clmVATRate = new DataColumn("VATRate");
                clmVATRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmVATRate);

                DataColumn clmVATAmount = new DataColumn("VATAmount");
                clmVATAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmVATAmount);

                DataColumn clmAVATRate = new DataColumn("AVATRate");
                clmAVATRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmAVATRate);

                DataColumn clmAVATAmount = new DataColumn("AVATAmount");
                clmAVATAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmAVATAmount);

                DataColumn clmSBCessRate = new DataColumn("SBCessRate");
                clmSBCessRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmSBCessRate);

                DataColumn clmSBCessAmount = new DataColumn("SBCessAmount");
                clmSBCessAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmSBCessAmount);

                DataColumn clmExtraTaxRate = new DataColumn("ExtraTaxRate");
                clmExtraTaxRate.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExtraTaxRate);

                DataColumn clmExtraTaxAmount = new DataColumn("ExtraTaxAmount");
                clmExtraTaxAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmExtraTaxAmount);

                DataColumn clmNetAmount = new DataColumn("NetAmount");
                clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmNetAmount);

                DataColumn clmDiscount = new DataColumn("Discount");
                clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                dtPIDetail.Columns.Add(clmDiscount);


                DataColumn clmGodownID = new DataColumn("GodownID");
                clmGodownID.DataType = System.Type.GetType("System.Int64");
                dtPIDetail.Columns.Add(clmGodownID);


                ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void LoadContactDetailList()
        {
            try
            {
                DataColumn clmContactTitle = new DataColumn("ContactTitle");
                clmContactTitle.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmContactTitle);

                DataColumn clmContactName = new DataColumn("ContactName");
                clmContactName.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmContactName);

                DataColumn clmDesignation = new DataColumn("Designation");
                clmDesignation.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmDesignation);

                DataColumn clmPhone1 = new DataColumn("Phone1");
                clmPhone1.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmPhone1);

                DataColumn clmPhone2 = new DataColumn("Phone2");
                clmPhone2.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmPhone2);

                DataColumn clmMobile = new DataColumn("Mobile");
                clmMobile.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmMobile);

                DataColumn clmEmail = new DataColumn("Email");
                clmEmail.DataType = System.Type.GetType("System.String");
                dtContactDetail.Columns.Add(clmEmail);

                DataColumn clmDoB = new DataColumn("DoB");
                clmDoB.DataType = System.Type.GetType("System.DateTime");
                dtContactDetail.Columns.Add(clmDoB);

                DataColumn clmDoA = new DataColumn("DoA");
                clmDoA.DataType = System.Type.GetType("System.DateTime");
                dtContactDetail.Columns.Add(clmDoA);

                //DataColumn clmServiceRate = new DataColumn("ServiceRate");
                //clmServiceRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmServiceRate);

                //DataColumn clmServiceAmount = new DataColumn("ServiceAmount");
                //clmServiceAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmServiceAmount);

                //DataColumn clmExciseRate = new DataColumn("ExciseRate");
                //clmExciseRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmExciseRate);

                //DataColumn clmExciseAmount = new DataColumn("ExciseAmount");
                //clmExciseAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmExciseAmount);

                //DataColumn clmECessRate = new DataColumn("ECessRate");
                //clmECessRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmECessRate);

                //DataColumn clmECessAmount = new DataColumn("ECessAmount");
                //clmECessAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmECessAmount);

                //DataColumn clmHECessRate = new DataColumn("HECessRate");
                //clmHECessRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmHECessRate);

                //DataColumn clmHECessAmount = new DataColumn("HECessAmount");
                //clmHECessAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmHECessAmount);

                //DataColumn clmAmountAfterExcise = new DataColumn("AmountAfterExcise");
                //clmAmountAfterExcise.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmAmountAfterExcise);

                //DataColumn clmCSTRate = new DataColumn("CSTRate");
                //clmCSTRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmCSTRate);

                //DataColumn clmCSTAmount = new DataColumn("CSTAmount");
                //clmCSTAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmCSTAmount);

                //DataColumn clmVATRate = new DataColumn("VATRate");
                //clmVATRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmVATRate);

                //DataColumn clmVATAmount = new DataColumn("VATAmount");
                //clmVATAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmVATAmount);

                //DataColumn clmAVATRate = new DataColumn("AVATRate");
                //clmAVATRate.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmAVATRate);

                //DataColumn clmAVATAmount = new DataColumn("AVATAmount");
                //clmAVATAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmAVATAmount);

                //DataColumn clmNetAmount = new DataColumn("NetAmount");
                //clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmNetAmount);

                //DataColumn clmDiscount = new DataColumn("Discount");
                //clmNetAmount.DataType = System.Type.GetType("System.Decimal");
                //dtPIDetail.Columns.Add(clmDiscount);


                //ArrangePIDetailGridView();
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        private void ArrangePIDetailGridView()
        {
            try
            {
                dgvPIDetail.Columns["GodownID"].DataPropertyName = dtPIDetail.Columns["GodownID"].ToString();
                dgvPIDetail.Columns["ItemID"].DataPropertyName = dtPIDetail.Columns["ItemID"].ToString();
                dgvPIDetail.Columns["ItemName"].DataPropertyName = dtPIDetail.Columns["ItemName"].ToString();
                dgvPIDetail.Columns["ItemDesc"].DataPropertyName = dtPIDetail.Columns["ItemDesc"].ToString();
                dgvPIDetail.Columns["Qty"].DataPropertyName = dtPIDetail.Columns["Qty"].ToString();
                dgvPIDetail.Columns["UOM"].DataPropertyName = dtPIDetail.Columns["UOM"].ToString();
                dgvPIDetail.Columns["Rate"].DataPropertyName = dtPIDetail.Columns["Rate"].ToString();
                dgvPIDetail.Columns["Currency"].DataPropertyName = dtPIDetail.Columns["Currency"].ToString();
                dgvPIDetail.Columns["CurrencyID"].DataPropertyName = dtPIDetail.Columns["CurrencyID"].ToString();
                dgvPIDetail.Columns["TaxClassID"].DataPropertyName = dtPIDetail.Columns["TaxClassID"].ToString();
                dgvPIDetail.Columns["TotalAmount"].DataPropertyName = dtPIDetail.Columns["TotalAmount"].ToString();
                dgvPIDetail.Columns["ServiceAmount"].DataPropertyName = dtPIDetail.Columns["ServiceAmount"].ToString();
                dgvPIDetail.Columns["ExciseAmount"].DataPropertyName = dtPIDetail.Columns["ExciseAmount"].ToString();
                dgvPIDetail.Columns["ECessAmount"].DataPropertyName = dtPIDetail.Columns["ECessAmount"].ToString();
                dgvPIDetail.Columns["HECessAmount"].DataPropertyName = dtPIDetail.Columns["HECessAmount"].ToString();
                dgvPIDetail.Columns["AmountAfterExcise"].DataPropertyName = dtPIDetail.Columns["AmountAfterExcise"].ToString();
                dgvPIDetail.Columns["CSTAmount"].DataPropertyName = dtPIDetail.Columns["CSTAmount"].ToString();
                dgvPIDetail.Columns["VATAmount"].DataPropertyName = dtPIDetail.Columns["VATAmount"].ToString();
                dgvPIDetail.Columns["AVATAmount"].DataPropertyName = dtPIDetail.Columns["AVATAmount"].ToString();
                dgvPIDetail.Columns["SBCessAmount"].DataPropertyName = dtPIDetail.Columns["SBCessAmount"].ToString();
                dgvPIDetail.Columns["ExtraTaxAmount"].DataPropertyName = dtPIDetail.Columns["ExtraTaxAmount"].ToString();

                dgvPIDetail.Columns["NetAmount"].DataPropertyName = dtPIDetail.Columns["NetAmount"].ToString();
                dgvPIDetail.Columns["Discount"].DataPropertyName = dtPIDetail.Columns["Discount"].ToString();

                for (int i = 0; i < dgvPIDetail.Columns.Count; i++)
                {
                    dgvPIDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dgvPIDetail.Rows.Count > 0)
                {

                    //if (_Mode == (int)Common.Constant.Mode.Insert)
                    //{
                    for (int i = 0; i < dgvPIDetail.Rows.Count; i++)
                    {
                        cmbCurrency.SelectedValue = dgvPIDetail.Rows[0].Cells["CurrencyID"].Value.ToString();
                    }
                    //}

                    //if (_Mode == (int)Common.Constant.Mode.Modify)
                    //{
                    //    for (int i = 1; i < dgvPIDetail.Rows.Count; i++)
                    //    {
                    //        cmbCurrency.SelectedValue = dgvPIDetail.Rows[dgvPIDetail.Rows.Count-1].Cells["CurrencyID"].Value.ToString();
                    //    }
                    //}
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        #region "Public Methods..."

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


        public void LogoBind(DataTable dt)
        {
            DataRow drow;
            // add the column in table to store the image of Byte array type 
            //dt.Columns.Add("Logo", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Header", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Footer", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Sign", System.Type.GetType("System.Byte[]"));
            //dt.TableName = "Logo";
            //dt.WriteXmlSchema(@"D:\ERP-CRM\CRM_ICON\Logo.xsd");
            drow = dt.Rows.Add();
            //FileStream logo;
            FileStream header;
            FileStream footer;
            FileStream sign;
            //BinaryReader brLogo;
            BinaryReader brHeader;
            BinaryReader brFooter;
            BinaryReader brSign;
            //string Logo = CurrentCompany.Logo;
            //if (Logo == null || Logo == "")
            //{
            //    Logo = CurrentUser.DocumentPath + "logoBlank.png";
            //}
            string Header = CurrentCompany.Header;
            if (Header == null)
            {
                Header = CurrentUser.DocumentPath + "header.png";
            }

            string Footer = CurrentCompany.Footer;
            if (Footer == null)
            {
                Footer = CurrentUser.DocumentPath + "footer.png";
            }

            string Sign = CurrentCompany.Sign;
            if (Sign == null || Sign == "")
            {
                Sign = CurrentUser.DocumentPath + "sign.png";
            }
            //if (File.Exists(Logo))
            //{

            //    logo = new FileStream(Logo, FileMode.Open);
            //}
            //else
            //{
            //    logo = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Logo", FileMode.Open);
            //}

            if (File.Exists(Header))
            {

                header = new FileStream(Header, FileMode.Open);
            }
            else
            {
                header = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Header", FileMode.Open);
            }


            if (File.Exists(Footer))
            {

                footer = new FileStream(Footer, FileMode.Open);
            }
            else
            {
                footer = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Footer", FileMode.Open);
            }

            if (File.Exists(Sign))
            {

                sign = new FileStream(Sign, FileMode.Open);
            }
            else
            {
                sign = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Sign", FileMode.Open);
            }

            //brLogo = new BinaryReader(logo);
            //byte[] imgbyteLogo = new byte[logo.Length + 1];
            //imgbyteLogo = brLogo.ReadBytes(Convert.ToInt32((logo.Length)));
            //drow[0] = imgbyteLogo;
            //dt.NewRow();
            //brLogo.Close();
            //logo.Close();

            brHeader = new BinaryReader(header);
            byte[] imgbyteHeader = new byte[header.Length + 1];
            imgbyteHeader = brHeader.ReadBytes(Convert.ToInt32((header.Length)));
            drow[0] = imgbyteHeader;
            dt.NewRow();
            brHeader.Close();
            header.Close();

            brFooter = new BinaryReader(footer);
            byte[] imgbyteFooter = new byte[footer.Length + 1];
            imgbyteFooter = brFooter.ReadBytes(Convert.ToInt32((footer.Length)));
            drow[1] = imgbyteFooter;
            dt.NewRow();
            brFooter.Close();
            footer.Close();

            brSign = new BinaryReader(sign);
            byte[] imgbyteSign = new byte[sign.Length + 1];
            imgbyteSign = brSign.ReadBytes(Convert.ToInt32((sign.Length)));
            drow[2] = imgbyteSign;
            dt.NewRow();
            brSign.Close();
            sign.Close();
        }

        //public void RPT_Sub(Int64 QuotationID, string Code, Boolean _IsList)
        //{
        //    DataTable dt = new DataTable();
        //    LogoBind(dt);
        //    mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
        //    DataTable dtReport = new DataTable();
        //    //dtReport = CommSelect.SelectRecord(QuotationID, "rpt_Quotation", "Quotation - Report");

        //    NameValueCollection para1 = new NameValueCollection();
        //    _CompId = CurrentCompany.CompId;
        //    para1.Add("@i_RecID", QuotationID.ToString());
        //    para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
        //    dtReport = objList.ListOfRecord("rpt_Quotation", para1, "Quotation - Report");

        //    DataTable dtTNC = new DataTable();
        //    NameValueCollection para = new NameValueCollection();
        //    para.Add("@i_Code", Code);
        //    para.Add("@i_TNC_Sub", "Quotation");

        //    dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");

        //    DataTable dtCompany = new DataTable();
        //    //dtCompany = objDA.ExecuteDataTableSP("rpt_Company", null, false, ref mException, ref mErrorMsg, "Quotation TNC");
        //    //dtReport.TableName = "Quotation";
        //    //dtReport.WriteXmlSchema(@"D:\Quotation.xsd");

        //    NameValueCollection para2 = new NameValueCollection();
        //    _CompId = CurrentCompany.CompId;
        //    para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
        //    dtCompany = objList.ListOfRecord("rpt_Company", para2, "Quotation - Report");

        //    if (CommSelect.Exception == null)
        //    {
        //        //if (TypeOFSale == "AMC")
        //        //{
        //        //    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation_AMC.rpt"))
        //        //    {

        //        //        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //        //        rptDoc.Load(CurrentUser.ReportPath + "rptQuotation_AMC.rpt");

        //        //        //rptDoc.SetDatabaseLogon("sa", "Un!ek3RP");
        //        //        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);

        //        //        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
        //        //        rptDoc.Subreports[0].DataSourceConnections.Clear();
        //        //        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);
        //        //        rptDoc.Refresh();


        //        //        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
        //        //        fRptView.Text = "Quotation - [Page Size: A4]";
        //        //        fRptView.crViewer.ReportSource = rptDoc;
        //        //        if (_IsList == true)
        //        //        {
        //        //            fRptView.ShowDialog();
        //        //        }
        //        //        else if (_IsList == false)
        //        //        {
        //        //            ExportOptions CrExportOptions;
        //        //            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
        //        //            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
        //        //            CrDiskFileDestinationOptions.DiskFileName = mpdfFile;
        //        //            CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
        //        //            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //        //            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //        //            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
        //        //            CrExportOptions.FormatOptions = CrFormatTypeOptions;
        //        //            rptDoc.Export();

        //        //        }
        //        //    }
        //        //    else
        //        //    {
        //        //        MessageBox.Show("File is not exist...");
        //        //    }
        //        //}
        //        //else if (TypeOFSale != "AMC")
        //        //{
        //        if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation.rpt"))
        //        {

        //            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //            rptDoc.Load(CurrentUser.ReportPath + "rptQuotation.rpt");
        //            //rptDoc.Subreports[0].DataSourceConnections.Clear();
        //            rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

        //            rptDoc.Database.Tables[1].SetDataSource(dtCompany);
        //            rptDoc.Database.Tables[2].SetDataSource(dt);
        //            rptDoc.Refresh();
        //            CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
        //            CurrentUser.AddExtraParameter(rptDoc);
        //            if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
        //            {
        //                rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
        //            }
        //            Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
        //            fRptView.Text = "Quotation - [Page Size: A4]";
        //            fRptView.crViewer.ReportSource = rptDoc;

        //            if (_IsList == true)
        //            {
        //                fRptView.ShowDialog();
        //            }
        //            else if (_IsList == false)
        //            {
        //                ExportOptions CrExportOptions;
        //                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
        //                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
        //                CrDiskFileDestinationOptions.DiskFileName = mpdfFile;
        //                CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
        //                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
        //                CrExportOptions.FormatOptions = CrFormatTypeOptions;
        //                rptDoc.Export();

        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
        //        }
        //        //}

        //    }
        //}


        public void RPT_Sub(Int64 QuotationID, string Code, Boolean _IsList)
        {
            DataTable dt = new DataTable();
            LogoBind(dt);

            //if (cbIsQuoWithTaxes.Checked)
            //{
            //    mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            //}
            //else
            //{
            mpdfFile = CurrentUser.DocumentPath + @"pdf\Quotation.pdf";
            //}

            DataTable dtReport = new DataTable();
            //dtReport = CommSelect.SelectRecord(QuotationID, "rpt_Quotation", "Quotation - Report");

            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_RecID", QuotationID.ToString());
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtReport = objList.ListOfRecord("rpt_Quotation", para1, "Quotation - Report");

            DataTable dtTNC = new DataTable();
            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_Code", Code);
            //para.Add("@i_TNC_Sub", "Quotation");

            if (Code.Length > 17)
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", Code);
                para.Add("@i_TNC_Sub", "Revised Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_Revised_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");
            }
            else
            {
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", Code);
                para.Add("@i_TNC_Sub", "Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");
            }

            //dtTNC = objDA.ExecuteDataTableSP("rpt_Quotation_TNC", para, false, ref mException, ref mErrorMsg, "Quotation TNC");

            DataTable dtCompany = new DataTable();
            //dtCompany = objDA.ExecuteDataTableSP("rpt_Company", null, false, ref mException, ref mErrorMsg, "Quotation TNC");
            //dtReport.TableName = "Quotation";
            //dtReport.WriteXmlSchema(@"D:\Quotation.xsd");

            NameValueCollection para2 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para2.Add("@i_CompId", CurrentCompany.CompId.ToString());
            dtCompany = objList.ListOfRecord("rpt_Company", para2, "Quotation - Report");

            if (CommSelect.Exception == null)
            {
                if (cbIsQuoWithTaxes.Checked)
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotationtax.rpt"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptQuotationtax.rpt");
                        //rptDoc.Subreports[0].DataSourceConnections.Clear();
                        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                        rptDoc.Database.Tables[2].SetDataSource(dt);
                        rptDoc.Refresh();
                        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                        CurrentUser.AddExtraParameter(rptDoc);

                        //rptDoc.SetParameterValue("pcmbcurrency", cmbCurrency.Text);                     
                        //rptDoc.SetParameterValue("pIsTaxation", true);
                        if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
                        {
                            rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
                        }
                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "QuotationTAX - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;

                        if (_IsList == true)
                        {
                            fRptView.ShowDialog();
                        }
                        else if (_IsList == false)
                        {
                            ExportOptions CrExportOptions;
                            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                            CrDiskFileDestinationOptions.DiskFileName = mpdfFile;
                            CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
                            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                            rptDoc.Export();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }
                else
                {
                    if (System.IO.File.Exists(CurrentUser.ReportPath + "rptQuotation.rpt"))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        rptDoc.Load(CurrentUser.ReportPath + "rptQuotation.rpt");
                        //rptDoc.Subreports[0].DataSourceConnections.Clear();
                        rptDoc.Subreports[0].Database.Tables[0].SetDataSource(dtTNC);

                        rptDoc.Database.Tables[1].SetDataSource(dtCompany);
                        rptDoc.Database.Tables[2].SetDataSource(dt);
                        rptDoc.Refresh();
                        CurrentUser.AddReportParameters(rptDoc, dtReport, "", false, false, false, false, false, false, false, false, false, false, false);
                        CurrentUser.AddExtraParameter(rptDoc);

                        // rptDoc.SetParameterValue("pcmbcurrency", cmbCurrency.Text); 
                        // rptDoc.SetParameterValue("pIsTaxation", false);
                        if (CurrentCompany.Com_Profile != null || CurrentCompany.Com_Profile.Trim() != "")
                        {
                            rptDoc.SetParameterValue("pCompanyProfile", CurrentCompany.Com_Profile);
                        }
                        Reports.frmReportViewer fRptView = new Reports.frmReportViewer();
                        fRptView.Text = "Quotation - [Page Size: A4]";
                        fRptView.crViewer.ReportSource = rptDoc;

                        if (_IsList == true)
                        {
                            fRptView.ShowDialog();
                        }
                        else if (_IsList == false)
                        {
                            ExportOptions CrExportOptions;
                            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                            CrDiskFileDestinationOptions.DiskFileName = mpdfFile;
                            CrExportOptions = rptDoc.ExportOptions;//Report document  object has to be given here
                            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                            rptDoc.Export();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please check Company Details,\n Go to the Master->Edit->Company Details->ReportPath/DocPath.");
                    }
                }
                //}

            }
        }


        public bool SetSave()
        {
            //SendToMail();
            bool ReturnValue = false;
            if (_Mode == (int)Common.Constant.Mode.Delete)
            {
                CommDelRec.DeleteRecord(_QuotationID, "usp_Quotation_Delete", "Quotation - Delete");
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
                    if (dgvPIDetail.Rows.Count == 0)
                    {
                        lblErrorMessage.Text = "Select at least one item";
                        dgvPIDetail.Focus();
                        return false;
                    }

                    int aa = Convert.ToInt32(_SIID);

                    if (Convert.ToDecimal(txtPaidAmount.Text) > Convert.ToDecimal(txtNetAmount.Text))
                    {
                        lblErrorMessage.Text = "Paid amount can not greater than net amount";
                        txtPaidAmount.Focus();
                        // return;
                    }

                    //bool Is_MailSend;
                    //if (chksend.Checked)
                    //{
                    //    Is_MailSend = true;


                    //}
                    //else
                    //{
                    //    Is_MailSend = false;
                    //}

                    long Cnt = 0;
                    string XMLString = string.Empty;

                    XMLString = "<NewDataSet>";
                    for (int i = 0; i < dtPIDetail.Rows.Count; i++)
                    {
                        XMLString = XMLString + "<Table>";
                        XMLString = XMLString + "<ItemID>" + dtPIDetail.Rows[i]["ItemID"] + "</ItemID>";
                        XMLString = XMLString + "<ItemDesc>" + dtPIDetail.Rows[i]["ItemDesc"] + "</ItemDesc>";
                        XMLString = XMLString + "<CurrencyID>" + dtPIDetail.Rows[i]["CurrencyID"] + "</CurrencyID>";
                        XMLString = XMLString + "<Qty>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Qty"]).ToString("#0.000") + "</Qty>";
                        XMLString = XMLString + "<Rate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Rate"]).ToString("#0.00") + "</Rate>";
                        XMLString = XMLString + "<Amount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["TotalAmount"]).ToString("#0.00") + "</Amount>";
                        XMLString = XMLString + "<TaxClassID>" + Convert.ToInt64(dtPIDetail.Rows[i]["TaxClassID"]).ToString() + "</TaxClassID>";

                        XMLString = XMLString + "<ServiceRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ServiceRate"]).ToString("#0.00") + "</ServiceRate>";
                        XMLString = XMLString + "<ServiceAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ServiceAmount"]).ToString("#0.00") + "</ServiceAmount>";

                        XMLString = XMLString + "<ExciseRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExciseRate"]).ToString("#0.00") + "</ExciseRate>";
                        XMLString = XMLString + "<ExciseAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExciseAmount"]).ToString("#0.00") + "</ExciseAmount>";
                        XMLString = XMLString + "<EduCessRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ECessRate"]).ToString("#0.00") + "</EduCessRate>";
                        XMLString = XMLString + "<EduCessAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ECessAmount"]).ToString("#0.00") + "</EduCessAmount>";
                        XMLString = XMLString + "<HEduCessRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["HECessRate"]).ToString("#0.00") + "</HEduCessRate>";
                        XMLString = XMLString + "<HEduCessAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["HECessAmount"]).ToString("#0.00") + "</HEduCessAmount>";
                        XMLString = XMLString + "<AmountAfterExcise>" + Convert.ToDecimal(dtPIDetail.Rows[i]["AmountAfterExcise"]).ToString("#0.00") + "</AmountAfterExcise>";
                        XMLString = XMLString + "<CSTRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["CSTRate"]).ToString("#0.00") + "</CSTRate>";
                        XMLString = XMLString + "<CSTAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["CSTAmount"]).ToString("#0.00") + "</CSTAmount>";
                        XMLString = XMLString + "<VATRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["VATRate"]).ToString("#0.00") + "</VATRate>";
                        XMLString = XMLString + "<VATAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["VATAmount"]).ToString("#0.00") + "</VATAmount>";
                        XMLString = XMLString + "<AVATRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["AVATRate"]).ToString("#0.00") + "</AVATRate>";
                        XMLString = XMLString + "<AVATAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["AVATAmount"]).ToString("#0.00") + "</AVATAmount>";

                        XMLString = XMLString + "<SBCessRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["SBCessRate"]).ToString("#0.00") + "</SBCessRate>";
                        XMLString = XMLString + "<SBCessAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["SBCessAmount"]).ToString("#0.00") + "</SBCessAmount>";

                        XMLString = XMLString + "<ExtraTaxRate>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExtraTaxRate"]).ToString("#0.00") + "</ExtraTaxRate>";
                        XMLString = XMLString + "<ExtraTaxAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["ExtraTaxAmount"]).ToString("#0.00") + "</ExtraTaxAmount>";

                        XMLString = XMLString + "<NetAmount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["NetAmount"]).ToString("#0.00") + "</NetAmount>";
                        XMLString = XMLString + "<Discount>" + Convert.ToDecimal(dtPIDetail.Rows[i]["Discount"]).ToString("#0.00") + "</Discount>";

                        XMLString = XMLString + "<GodownID>" + dtPIDetail.Rows[i]["GodownID"] + "</GodownID>";
                        XMLString = XMLString + "</Table> ";
                        Cnt = Cnt + 1;
                    }
                    XMLString = XMLString.ToString().Replace("&", "&amp;") + "</NewDataSet>";
                    //if (Cnt == 0)
                    //{
                    //    lblErrorMessage.Text = "Select at least one item";
                    //    dgvPIDetail.Focus();
                    //    // return;
                    //}



                    if (_Mode == (int)Common.Constant.Mode.Insert || _Mode == (int)Common.Constant.Mode.View)
                    {
                        objQuotationBL.Insert(_LeadID, dtpSaleDate.Value, _SIID, Convert.ToDecimal("0.00"), Convert.ToDecimal("0.00"),
                            txtSubject.Text, Convert.ToDecimal(txtServiceAmt.Text), Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                            Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text),
                            Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtSBCessAmount.Text), Convert.ToDecimal(txtExtraTax.Text),
                            Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text),
                            XMLString, Cnt, "RefNo", "TypeOfSale", txtPINo.Text, Convert.ToDateTime(dtpNextDate.Value), txtreference.Text,
                            Convert.ToInt16(cmbEmp.SelectedValue), Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), txtRemarks.Text, txtcc.Text, txtbcc.Text, Is_MailSend, CompId
                            , txtcontactperson.Text, txtemail.Text, txtmobile.Text, IsCustomer, cmbCategory.Text);

                        //objQuotationBL.Insert(_LeadID, dtpSaleDate.Value, _SIID, Convert.ToDecimal("0.00"), Convert.ToDecimal("0.00"),
                        //    txtSubject.Text, Convert.ToDecimal(txtServiceAmt.Text), Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                        //    Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text), Convert.ToDecimal(txtAmtwithExcise.Text),
                        //    Convert.ToDecimal(txtCSTAmt.Text), Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtSBCessAmount.Text), Convert.ToDecimal(txtExtraTax.Text),
                        //    Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text),
                        //    XMLString, Cnt, "RefNo", "TypeOfSale", txtPINo.Text, Convert.ToDateTime(dtpNextDate.Value), txtreference.Text,
                        //    Convert.ToInt16(cmbEmp.SelectedValue), Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), txtRemarks.Text, txtcc.Text, txtbcc.Text, Is_MailSend, CompId
                        //    ,txtcontactperson.Text,txtemail.Text,txtmobile.Text
                        //    );


                        if (objQuotationBL.Exception == null)
                        {
                            if (objQuotationBL.ErrorMessage != "" || _QuotationID > 0)
                            {
                                if (isRecordSave(objQuotationBL.ErrorMessage))
                                {
                                    if (_QuotationID == 0)
                                    {
                                        _QuotationID = Convert.ToInt64(objQuotationBL.ErrorMessage);
                                    }
                                    else
                                    {
                                        if (_Mode == (int)Common.Constant.Mode.View)
                                        {
                                            _QuotationID = Convert.ToInt64(objQuotationBL.ErrorMessage);
                                        }
                                    }

                                    //-----for doc save--------
                                    foreach (DataRow dr in dtDocList.Rows)
                                    {
                                        if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                        {
                                            // objSaleBL.InsertSaleDocument(_SaleID, dr["FileName"].ToString(), dr["DocRemark"].ToString());
                                            if (_Mode == (int)Common.Constant.Mode.View)
                                            {
                                                string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-').Substring(18, 2) + "-" + dr["FileName"].ToString().Replace('/', '-');
                                                objQuotationBL.InsertQuotationDocument(_QuotationID, txtPINo.Text.ToString().Replace('/', '-').Substring(18, 2) + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                                if (objQuotationBL.Exception == null)
                                                {
                                                    if (objQuotationBL.ErrorMessage == "")
                                                    {
                                                        //File.Copy(newFileName,dr["FileName"].ToString().Replace('/', '-'), false);
                                                        File.Copy(CurrentUser.DocumentPath + dr["FullFileName"].ToString(), newFileName, false);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (txtPINo.Text.Length > 17)
                                            {
                                                string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-').Substring(18, 2) + "-" + txtPINo.Text.ToString().Replace('/', '-').Substring(0, 17) + "-" + dr["FileName"].ToString().Replace('/', '-');
                                                objQuotationBL.InsertQuotationDocument(_QuotationID, txtPINo.Text.ToString().Replace('/', '-').Substring(18, 2) + "-" + txtPINo.Text.ToString().Replace('/', '-').Substring(0, 17) + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                                if (objQuotationBL.Exception == null)
                                                {
                                                    if (objQuotationBL.ErrorMessage == "")
                                                    {
                                                        File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                    }
                                                }
                                            }
                                            else
                                            {

                                                string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                                objQuotationBL.InsertQuotationDocument(_QuotationID, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                                if (objQuotationBL.Exception == null)
                                                {
                                                    if (objQuotationBL.ErrorMessage == "")
                                                    {
                                                        File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //-------------------

                                    if (chkTNC.Checked == true)
                                    {
                                        if (txtPINo.Text.Length > 17)
                                        {
                                            NameValueCollection para1 = new NameValueCollection();
                                            para1.Add("@i_TNC_SUB", "REVISED QUOTATION");
                                            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                                            DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                                            //for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                            //{
                                            //    objQuotationBL.InsertTNC("QUOTATION", dtAllTNC.Rows[i][0].ToString(), txtPINo.Text);
                                            //}

                                            long Cnt1 = 0;
                                            string XMLString1 = string.Empty;

                                            XMLString1 = "<NewDataSet>";
                                            for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                            {
                                                XMLString1 = XMLString1 + "<Table>";
                                                XMLString1 = XMLString1 + "<Code>" + txtPINo.Text + "</Code>";
                                                XMLString1 = XMLString1 + "<TNC_Sub>" + "REVISED QUOTATION" + "</TNC_Sub>";
                                                //XMLString = XMLString + "<ItemODesc>" + dtPIDetail.Rows[i]["ItemODesc"] + "</ItemODesc>";
                                                XMLString1 = XMLString1 + "<TNC_Desc>" + dtAllTNC.Rows[i]["TNC_Desc"].ToString() + "</TNC_Desc>";
                                                XMLString1 = XMLString1 + "<CompId>" + CurrentCompany.CompId.ToString() + "</CompId>";

                                                XMLString1 = XMLString1 + "</Table> ";
                                                Cnt1 = Cnt1 + 1;
                                            }
                                            XMLString1 = XMLString1.ToString().Replace("&", "&amp;") + "</NewDataSet>";
                                            objQuotationBL.InsertTNC_Revised_NEW(XMLString1, Cnt1);
                                        }
                                        else
                                        {
                                            NameValueCollection para1 = new NameValueCollection();
                                            para1.Add("@i_TNC_SUB", "QUOTATION");
                                            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                                            DataTable dtAllTNC = objDA.ExecuteDataTableSP("usp_Select_All_TNC", para1, false, ref mException, ref mErrorMsg, "Select All TNC");
                                            //for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                            //{
                                            //    objQuotationBL.InsertTNC("QUOTATION", dtAllTNC.Rows[i][0].ToString(), txtPINo.Text);
                                            //}

                                            long Cnt1 = 0;
                                            string XMLString1 = string.Empty;

                                            XMLString1 = "<NewDataSet>";
                                            for (int i = 0; i < dtAllTNC.Rows.Count; i++)
                                            {
                                                XMLString1 = XMLString1 + "<Table>";
                                                XMLString1 = XMLString1 + "<Code>" + txtPINo.Text + "</Code>";
                                                XMLString1 = XMLString1 + "<TNC_Sub>" + "QUOTATION" + "</TNC_Sub>";
                                                //XMLString = XMLString + "<ItemODesc>" + dtPIDetail.Rows[i]["ItemODesc"] + "</ItemODesc>";
                                                XMLString1 = XMLString1 + "<TNC_Desc>" + dtAllTNC.Rows[i]["TNC_Desc"].ToString() + "</TNC_Desc>";
                                                XMLString1 = XMLString1 + "<CompId>" + CurrentCompany.CompId.ToString() + "</CompId>";

                                                XMLString1 = XMLString1 + "</Table> ";
                                                Cnt1 = Cnt1 + 1;
                                            }
                                            XMLString1 = XMLString1.ToString().Replace("&", "&amp;") + "</NewDataSet>";

                                            objQuotationBL.InsertTNC_NEW(XMLString1, Cnt1);
                                        }



                                    }
                                    else
                                    {
                                        if (ISEditTNCClicked != 1)
                                        {
                                            if (txtPINo.Text.Length > 17)
                                            {
                                                long Cnt2 = 0;
                                                string XMLString2 = string.Empty;

                                                XMLString2 = "<NewDataSet>";
                                                for (int i = 0; i < dtTnCDetail.Rows.Count; i++)
                                                {
                                                    XMLString2 = XMLString2 + "<Table>";
                                                    XMLString2 = XMLString2 + "<Code>" + txtPINo.Text + "</Code>";
                                                    XMLString2 = XMLString2 + "<TNC_Sub>" + "REVISED QUOTATION" + "</TNC_Sub>";
                                                    //XMLString = XMLString + "<ItemODesc>" + dtPIDetail.Rows[i]["ItemODesc"] + "</ItemODesc>";
                                                    XMLString2 = XMLString2 + "<TNC_Desc>" + dtTnCDetail.Rows[i]["TNC_Desc"].ToString() + "</TNC_Desc>";
                                                    XMLString2 = XMLString2 + "<CompId>" + CurrentCompany.CompId.ToString() + "</CompId>";

                                                    XMLString2 = XMLString2 + "</Table> ";
                                                    Cnt2 = Cnt2 + 1;
                                                }
                                                XMLString2 = XMLString2.ToString().Replace("&", "&amp;") + "</NewDataSet>";
                                                objQuotationBL.InsertTNC_Revised_NEW(XMLString2, Cnt2);
                                            }
                                            else
                                            {
                                                long Cnt2 = 0;
                                                string XMLString2 = string.Empty;

                                                XMLString2 = "<NewDataSet>";
                                                for (int i = 0; i < dtTnCDetail.Rows.Count; i++)
                                                {
                                                    XMLString2 = XMLString2 + "<Table>";
                                                    XMLString2 = XMLString2 + "<Code>" + txtPINo.Text + "</Code>";
                                                    XMLString2 = XMLString2 + "<TNC_Sub>" + "QUOTATION" + "</TNC_Sub>";
                                                    //XMLString = XMLString + "<ItemODesc>" + dtPIDetail.Rows[i]["ItemODesc"] + "</ItemODesc>";
                                                    XMLString2 = XMLString2 + "<TNC_Desc>" + dtTnCDetail.Rows[i]["TNC_Desc"].ToString() + "</TNC_Desc>";
                                                    XMLString2 = XMLString2 + "<CompId>" + CurrentCompany.CompId.ToString() + "</CompId>";

                                                    XMLString2 = XMLString2 + "</Table> ";
                                                    Cnt2 = Cnt2 + 1;
                                                }
                                                XMLString2 = XMLString2.ToString().Replace("&", "&amp;") + "</NewDataSet>";

                                                objQuotationBL.InsertTNC_NEW(XMLString2, Cnt2);
                                            }



                                        }
                                    }

                                    //------get id for open rpt

                                    //LQuotationID = objCommon.AutoNumberID("QU");
                                    if (QPriview == 1)
                                    {
                                        RPT_Sub(_QuotationID, txtPINo.Text, true);
                                    }

                                    //------------------------

                                    if (chksend.Checked == true)
                                    {
                                        SendToMail();
                                    }

                                    if (chkSMS.Checked == true)
                                    {
                                        string mobileno = txtmobile.Text;
                                        //if (radioButton4.Checked == true)
                                        //{
                                        string CompanyNameR = "";
                                        //}
                                        //else
                                        //{
                                        CompanyNameR = ConfigurationManager.AppSettings["SMSCOMPNAME"].ToString();
                                        //}
                                        //System.Diagnostics.Process.Start(@"http://bulksms1.idiotcreator.com:/sendSMS?username=vraj&message= Dear Customer , Your Quotation No '" + txtPINo.Text + "' is generated&sendername=VRCORP&smstype=TRANS&numbers=" + mobileno + "&apikey=9a13efce-3a79-4b2b-b185-c7861c630f9b");

                                        //System.Diagnostics.Process.Start(@"http://bhashsms.com/api/sendmsg.php?user=Brahmani&pass=admin124&sender=BRAHMA&phone=9408327737&text=Test SMS&priority=Normal&smstype=TRANSACTIONAL");
                                        //System.Diagnostics.Process.Start(@"http://bulksms1.idiotcreator.com:/sendSMS?username=pareshsms&message= Dear Customer , Thanks for kind association with us,your quotation code is '" + txtPINo.Text + "'.Waiting for your positive and early reply. Thanks and Regards." + CompanyNameR + "&sendername=PARESH&smstype=TRANS&numbers=" + mobileno + "&apikey=00ce816f-1b7c-4b27-a70c-f763cb66dc01");

                                        //http://bulksms1.idiotcreator.com:/sendSMS?username=pareshsms&message=XXXXXXXXXX&sendername=XYZ&smstype=TRANS&numbers=<mobile_numbers>&apikey=d0002689-c347-4b82-af90-9d3188ad6c6e
                                        //                                 http://bulksms1.idiotcreator.com:/sendSMS?username=bidmee&message=Test message&sendername=JP Info&smstype=TRANS&numbers=9408327737&apikey=d0002689-c347-4b82-af90-9d3188ad6c6e

                                        // http://bulksms1.idiotcreator.com:/sendSMS?username=bidmee&message=XXXXXXXXXX&sendername=XYZ&smstype=TRANS&numbers=<mobile_numbers>&apikey=d0002689-c347-4b82-af90-9d3188ad6c6e
                                        //System.Diagnostics.Process.Start(@"http://ip.infisms.com/smsserver/SMS10N.aspx?Userid=jpinfo&UserPassword=admin123&PhoneNumber=91" + mobileno + "&Text=" + "Dear " + txtcontactname.Text + "This is for your kind information that your ordered material Quantity is loaded with " + txttransport.Text + "on" +txtdispatch.Text+ "&GSM=PCAPPL");

                                    }


                                    lblErrorMessage.Text = "No error";
                                    ReturnValue = true;
                                }
                                else
                                {
                                    lblErrorMessage.Text = objQuotationBL.ErrorMessage;

                                    ReturnValue = false;
                                }

                            }
                            else
                            {
                                lblErrorMessage.Text = "No error";
                                ReturnValue = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show(objQuotationBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                    else if (_Mode == (int)Common.Constant.Mode.Modify)
                    {
                        objQuotationBL.Update(_QuotationID, _LeadID, dtpSaleDate.Value, _SIID, Convert.ToDecimal("0.00"),
                                                Convert.ToDecimal("0.00"), txtSubject.Text, Convert.ToDecimal(txtServiceAmt.Text),
                                                Convert.ToDecimal(txtAmount.Text), Convert.ToDecimal(txtExciseAmt.Text),
                                                Convert.ToDecimal(txtEduCessAmt.Text), Convert.ToDecimal(txtHEduCessAmt.Text),
                                                Convert.ToDecimal(txtAmtwithExcise.Text), Convert.ToDecimal(txtCSTAmt.Text),
                                                Convert.ToDecimal(txtVATAmt.Text), Convert.ToDecimal(txtAVATAmt.Text), Convert.ToDecimal(txtSBCessAmount.Text), Convert.ToDecimal(txtExtraTax.Text), Convert.ToDecimal(txtDiscount.Text),
                                                Convert.ToDecimal(txtNetAmount.Text), Convert.ToDecimal(txtPaidAmount.Text), XMLString, Cnt, "RefNo",
                                                "TypeOfSale", Convert.ToDateTime(dtpNextDate.Value), txtreference.Text,
                                                Convert.ToInt16(cmbEmp.SelectedValue), Convert.ToInt16(cmbEmpAllocatedTo.SelectedValue), txtRemarks.Text, txtcc.Text, txtbcc.Text, MailStatus, CompId
                                                , txtcontactperson.Text, txtemail.Text, txtmobile.Text, IsCustomer, cmbCategory.Text
                                                );


                        if (objQuotationBL.Exception == null)
                        {
                            if (objQuotationBL.Exception == null)
                            {
                                //--for doc save code
                                foreach (DataRow dr in dtDocList.Rows)
                                {
                                    if (Convert.ToInt64(dr["QDocID"].ToString()) > 0)
                                    {
                                        objQuotationBL.InsertQuotationDocument(_QuotationID, dr["FileName"].ToString());
                                    }
                                    else
                                    {
                                        if (txtPINo.Text.Length > 17)
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-').Substring(18, 2) + "-" + txtPINo.Text.ToString().Replace('/', '-').Substring(0, 17) + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            //string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objQuotationBL.InsertQuotationDocument(_QuotationID, txtPINo.Text.ToString().Replace('/', '-').Substring(18, 2) + "-" + txtPINo.Text.ToString().Replace('/', '-').Substring(0, 17) + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objQuotationBL.Exception == null)
                                            {
                                                if (objQuotationBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            string newFileName = CurrentUser.DocumentPath + txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-');
                                            objQuotationBL.InsertQuotationDocument(_QuotationID, txtPINo.Text.ToString().Replace('/', '-') + "-" + dr["FileName"].ToString().Replace('/', '-'));
                                            if (objQuotationBL.Exception == null)
                                            {
                                                if (objQuotationBL.ErrorMessage == "")
                                                {
                                                    //Move File                                    
                                                    File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                                                }
                                            }
                                        }
                                    }
                                }
                                //---------------

                                //------get id for open rpt

                                // LQuotationID = objCommon.AutoNumberID("QU");
                                if (QPriview == 1)
                                {
                                    RPT_Sub(_QuotationID, txtPINo.Text, true);
                                }
                                //------------------------


                                if (chksend.Checked == true)
                                {
                                    SendToMail();
                                }

                                if (chkSMS.Checked == true)
                                {
                                    string mobileno = txtmobile.Text;
                                    //if (radioButton4.Checked == true)
                                    //{
                                    string CompanyNameR = "";
                                    //}
                                    //else
                                    //{
                                    CompanyNameR = ConfigurationManager.AppSettings["SMSCOMPNAME"].ToString();
                                    //}
                                    //System.Diagnostics.Process.Start(@"http://bulksms1.idiotcreator.com:/sendSMS?username=vraj&message= Dear Customer , Your Quotation No '" + txtPINo.Text + "' is generated&sendername=VRCORP&smstype=TRANS&numbers=" + mobileno + "&apikey=9a13efce-3a79-4b2b-b185-c7861c630f9b");

                                    //System.Diagnostics.Process.Start(@"http://bhashsms.com/api/sendmsg.php?user=Brahmani&pass=admin124&sender=BRAHMA&phone=9408327737&text=Test SMS&priority=Normal&smstype=TRANSACTIONAL");
                                    System.Diagnostics.Process.Start(@"http://bhashsms.com/api/sendmsg.php?user=Brahmani&pass=admin124&sender=BRAHMA&phone=" + mobileno + "&text=Thanks for kind association with us,your quotation code is '" + txtPINo.Text + "'.Waiting for your positive and early reply. Thanks and Regards." + CompanyNameR + "&priority=ndnd&stype=normal");

                                    //http://bulksms1.idiotcreator.com:/sendSMS?username=pareshsms&message=XXXXXXXXXX&sendername=XYZ&smstype=TRANS&numbers=<mobile_numbers>&apikey=d0002689-c347-4b82-af90-9d3188ad6c6e
                                    //                                 http://bulksms1.idiotcreator.com:/sendSMS?username=bidmee&message=Test message&sendername=JP Info&smstype=TRANS&numbers=9408327737&apikey=d0002689-c347-4b82-af90-9d3188ad6c6e

                                    // http://bulksms1.idiotcreator.com:/sendSMS?username=bidmee&message=XXXXXXXXXX&sendername=XYZ&smstype=TRANS&numbers=<mobile_numbers>&apikey=d0002689-c347-4b82-af90-9d3188ad6c6e
                                    //System.Diagnostics.Process.Start(@"http://ip.infisms.com/smsserver/SMS10N.aspx?Userid=jpinfo&UserPassword=admin123&PhoneNumber=91" + mobileno + "&Text=" + "Dear " + txtcontactname.Text + "This is for your kind information that your ordered material Quantity is loaded with " + txttransport.Text + "on" +txtdispatch.Text+ "&GSM=PCAPPL");

                                }

                                lblErrorMessage.Text = "No error";
                                ReturnValue = true;
                            }
                            else
                            {
                                lblErrorMessage.Text = objQuotationBL.ErrorMessage;

                                ReturnValue = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show(objQuotationBL.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ReturnValue = false;
                        }
                    }
                }
            }
            return ReturnValue;
        }

        public void BindControl()
        {
            DataSet ds = new DataSet();
            ds = CommSelect.SelectDataSetRecord(_SIID, "usp_Quotation_Select", "Quotation - BindControl");
            dtQuotation = CommSelect.SelectDataSetRecord(_SIID, "usp_Quotation_Select", "Quotation - BindControl");
            if (CommSelect.Exception == null)
            {
                if (CommSelect.ErrorMessage == "")
                {
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        dgvPIDetail.AutoGenerateColumns = false;
                        dgvPIDetail.DataSource = ds.Tables[3];
                        dtPIDetail = ds.Tables[3];
                        ArrangePIDetailGridView();
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        dtContactDetail = ds.Tables[4].DefaultView.ToTable();
                    }

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        dtTnCDetail = ds.Tables[5].DefaultView.ToTable();
                    }

                    if (dtQuotation.Tables[0].Rows.Count > 0)
                    {
                        _QuotationID = Convert.ToInt64(dtQuotation.Tables[0].Rows[0]["QuotationId"].ToString());
                        _LeadID = Convert.ToInt64(dtQuotation.Tables[0].Rows[0]["LeadID"].ToString());
                        txtLeadNo.Text = dtQuotation.Tables[0].Rows[0]["LeadNo"].ToString();
                        if (dtQuotation.Tables[0].Rows[0]["LeadDate"].ToString() == null || dtQuotation.Tables[0].Rows[0]["LeadDate"].ToString() == "")
                        {
                            txtLeaddate.Text = "";
                        }
                        else
                        {
                            txtLeaddate.Text = Convert.ToDateTime(dtQuotation.Tables[0].Rows[0]["LeadDate"].ToString()).ToShortDateString();
                        }
                        txtCustName.Text = dtQuotation.Tables[0].Rows[0]["CustomerName"].ToString();
                        dtpSaleDate.Value = Convert.ToDateTime(dtQuotation.Tables[0].Rows[0]["QDate"].ToString());
                        txtSubject.Text = dtQuotation.Tables[0].Rows[0]["Remarks"].ToString();
                        txtPaidAmount.Text = dtQuotation.Tables[0].Rows[0]["PaidAmount"].ToString();
                        txtDiscount.Text = dtQuotation.Tables[0].Rows[0]["Discount"].ToString();
                        txtAmount.Text = dtQuotation.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtServiceAmt.Text = dtQuotation.Tables[0].Rows[0]["ServiceAmount"].ToString();
                        txtExciseAmt.Text = dtQuotation.Tables[0].Rows[0]["ExciseAmount"].ToString();
                        txtHEduCessAmt.Text = dtQuotation.Tables[0].Rows[0]["HCessAmount"].ToString();
                        txtEduCessAmt.Text = dtQuotation.Tables[0].Rows[0]["CessAmount"].ToString();
                        txtAmtwithExcise.Text = dtQuotation.Tables[0].Rows[0]["AmountAfterExcise"].ToString();
                        txtCSTAmt.Text = dtQuotation.Tables[0].Rows[0]["CSTAmount"].ToString();
                        txtVATAmt.Text = dtQuotation.Tables[0].Rows[0]["VATAmount"].ToString();
                        txtAVATAmt.Text = dtQuotation.Tables[0].Rows[0]["AVATAmount"].ToString();
                        txtNetAmount.Text = dtQuotation.Tables[0].Rows[0]["NetAmount"].ToString();
                        txtPINo.Text = dtQuotation.Tables[0].Rows[0]["Code"].ToString();
                        dtpNextDate.Text = dtQuotation.Tables[0].Rows[0]["FollowUpDate"].ToString();
                        txtreference.Text = dtQuotation.Tables[0].Rows[0]["Reference"].ToString();
                        cmbEmp.SelectedValue = dtQuotation.Tables[0].Rows[0]["EmpID"].ToString();

                        txtAddress.Text = dtQuotation.Tables[0].Rows[0]["Address"].ToString();

                        txtRemarks.Text = dtQuotation.Tables[0].Rows[0]["Remarks_Orignal"].ToString();
                        txtcc.Text = dtQuotation.Tables[0].Rows[0]["CC"].ToString();
                        txtbcc.Text = dtQuotation.Tables[0].Rows[0]["BCC"].ToString();
                        cmbEmpAllocatedTo.SelectedValue = dtQuotation.Tables[0].Rows[0]["EmpAllToID"].ToString();
                        cmbCategory.Text = dtQuotation.Tables[0].Rows[0]["category"].ToString();
                        cmbStatus.Text = dtQuotation.Tables[0].Rows[0]["InterestLevel"].ToString();

                        txtcontactperson.Text = dtQuotation.Tables[0].Rows[0]["ContactPerson"].ToString();
                        txtemail.Text = dtQuotation.Tables[0].Rows[0]["Email"].ToString();
                        txtmobile.Text = dtQuotation.Tables[0].Rows[0]["Mobile"].ToString();

                        if (dtQuotation.Tables[0].Rows[0]["Is_SendMail"].ToString() == "True")
                        {
                            MailStatus = true;
                        }
                        else
                        {
                            MailStatus = false;
                        }
                        //MailStatus=
                        lblMailCheck.Text = dtQuotation.Tables[0].Rows[0]["Is_SendMail"].ToString();
                        //txtDocName.Text = dtQuotation.Tables[0].Rows[0]["FileName"].ToString();

                        /* Code For Revised Quotation number */
                        if (_Mode == (int)Common.Constant.Mode.View)
                        {
                            while (lblPICheck.Text != "0")
                            {
                                DataTable dtAddRe = new DataTable();
                                NameValueCollection paraAddRe = new NameValueCollection();
                                paraAddRe.Add("@i_PiNo", txtPINo.Text);
                                //paraAddRe.Add("@i_CompID", CurrentCompany.CompId.ToString());
                                dtAddRe = objDA.ExecuteDataTableSP("usp_Revised", paraAddRe, false, ref mException, ref mErrorMsg, "Revised PINO");
                                txtPINo.Text = dtAddRe.Rows[0][0].ToString();

                                DataTable dtcount = new DataTable();
                                NameValueCollection paraCount = new NameValueCollection();
                                paraCount.Add("@i_QuoCode", txtPINo.Text.Trim());
                                paraCount.Add("@i_CompID", CurrentCompany.CompId.ToString());
                                dtcount = objDA.ExecuteDataTableSP("usp_Check_Revised", paraCount, false, ref mException, ref mErrorMsg, "Quotation-New");
                                lblPICheck.Text = dtcount.Rows[0][0].ToString();
                            }
                        }//for revised quotation code end

                        /* code for Docs open*/

                        if (dtQuotation.Tables[1] != null && dtQuotation.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow DRow in dtQuotation.Tables[1].Rows)
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
                        //frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_QuotationTNC_Select", null, txtPINo.Text, "QUOTATION");
                        //fLOV.RevisedMode = 1;
                        CurrentCompany.RevisedMode = "1";

                        NameValueCollection para = new NameValueCollection();
                        para.Add("@i_Code", txtPINo.Text);
                        para.Add("@i_CompID", CurrentCompany.CompId.ToString());

                        if (dtContactDetail.Columns.Count > 0)
                        {

                        }
                        else
                        {
                            LoadContactDetailList();
                        }

                        dtQContDetail = objDA.ExecuteDataTableSP("usp_QuotationContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                        if (dtQContDetail != null)
                        { }

                        //----------------------
                        //NameValueCollection para = new NameValueCollection();
                        //para.Add("@i_ContactType", 0.ToString());
                        //para.Add("@i_RefID", _LeadID.ToString());

                        //dtblContactPerson = objList.ListOfRecord("usp_ContactDetail_List", para, "ContactPerson - LoadList");

                        //if (objList.Exception == null)
                        //{
                        //    if (dtblContactPerson.Rows.Count > 0)
                        //    {

                        //    }
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

        #endregion

        private void btnSaveExit_Click(object sender, EventArgs e)
        {


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_quaId", Convert.ToString(_QuotationID));

            dtblLOV = objList.ListOfRecord("usp_IsCUST_Select", para, "Customer LOV - LoadList");
            if (dtblLOV.Rows.Count > 0)
            {
                if (dtblLOV.Rows[0]["IsCustomer"].ToString() == "True")
                {
                    IsCustomer = true;
                }
                else
                {
                    IsCustomer = false;
                }
            }


            QTNC = 1;
            if (SetSave())
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            if (_Mode == (int)Constant.Mode.Insert)
            {
                objQuotationBL.DeleteTNC_On_Close("QUOTATION", txtPINo.Text);
                objQuotationBL.DeleteQContact_On_Close(txtPINo.Text);
            }
        }


        private void btnLeadLOV_Click(object sender, EventArgs e)
        {
            NameValueCollection para1 = new NameValueCollection();
            _CompId = CurrentCompany.CompId;
            para1.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para1.Add("@i_UserID", CurrentUser.UserID.ToString());

            frmCustomerLOV fLOV = new frmCustomerLOV(CurrentCompany.CompId, "usp_Customer_LOV", para1);
            fLOV.Text = "List Of Customer";
            fLOV.ShowDialog();
            txtLeadNo.Text = fLOV.CustomerCode;
            // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
            txtCustName.Text = fLOV.CustomerName;
            _LeadID = fLOV.CustomerID;
            txtemail.Text = fLOV.Email;
            txtmobile.Text = fLOV.MobileNo;
            txtcontactperson.Text = fLOV.ContactPerson;
            txtLeaddate.Text = fLOV.SaleDate.ToShortDateString();
            txtAddress.Text = fLOV.Address;
            cmbCategory.Text = Convert.ToString(fLOV.categorycust);
            cmbEmp.SelectedValue = fLOV.EmpID;
            cmbEmpAllocatedTo.SelectedValue = fLOV.AllocatedToEmpID;
            string custcode = fLOV.CustomerCode;
            if (custcode.ToString().Contains("CUST"))
            {
                IsCustomer = true;
            }
            else
            {
                IsCustomer = false;
            }


            NameValueCollection para = new NameValueCollection();
            para.Add("@i_Code", txtPINo.Text);
            para.Add("@i_CompID", CurrentCompany.CompId.ToString());
            if (dtContactDetail.Columns.Count > 0)
            {

            }
            else
            {
                LoadContactDetailList();
            }

            dtQContDetail = objDA.ExecuteDataTableSP("usp_QuotationContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
            if (dtQContDetail != null)
            { }
            btnContactPerson.Focus();
            //--------------
            //NameValueCollection para = new NameValueCollection();
            //para.Add("@i_ContactType", 0.ToString());
            //para.Add("@i_RefID", _LeadID.ToString());

            //dtblContactPerson = objList.ListOfRecord("usp_ContactDetail_List", para, "ContactPerson - LoadList");

            //if (objList.Exception == null)
            //{
            //    if (dtblContactPerson.Rows.Count > 0)
            //    { 

            //    }
            //}
        }



        private void txtAdvAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataValidator.AllowOnlyNumeric(e, ".");
        }

        private void txtAdvAmt_Leave(object sender, EventArgs e)
        {
            TextBox txtTextbox = sender as TextBox;
            if (txtTextbox.Text != "")
            {
                if (DataValidator.IsNumeric(txtTextbox.Text))
                {
                    txtTextbox.Text = Convert.ToDecimal(txtTextbox.Text).ToString("#0.00");
                    // Set Decimal Value after textbox's Leave Event
                    lblErrorMessage.Text = "No error";
                    int t = txtTextbox.TextLength;
                    if (t <= txtTextbox.MaxLength)
                    {
                        lblErrorMessage.Text = "No error";
                    }
                    else
                    {
                        lblErrorMessage.Text = DataValidator.lblFormatMessage + "99999999.99";
                        txtTextbox.Focus();
                    }
                }
                else
                {
                    txtTextbox.Text = "0.00";
                }
            }
            else
            {
                txtTextbox.Text = "0.00";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            string StrItem = "#";
            for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
            {
                StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
            }
            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                if (dtPIDetail.Columns.Count == 0)
                {
                    LoadPIDetailList();
                }
            }

            _CurrencyID = Convert.ToInt64(cmbCurrency.SelectedValue);
            Quotation.frmQuotationItemEntry fPIEntry = new Quotation.frmQuotationItemEntry((int)Constant.Mode.Insert, _PIID, _CustomerID, dtpSaleDate.Value, dtPIDetail, 0, "", _CurrencyID, false);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();
            CalculateNetAmount();
        }


        public void CalculateNetAmount()
        {
            try
            {
                if (dtPIDetail.Rows.Count > 0)
                {
                    txtAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(TotalAmount)", "")).ToString("#0.00");
                    txtServiceAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ServiceAmount)", "")).ToString("#0.00");
                    txtExciseAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ExciseAmount)", "")).ToString("#0.00");
                    txtEduCessAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ECessAmount)", "")).ToString("#0.00");
                    txtHEduCessAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(HECessAmount)", "")).ToString("#0.00");
                    txtAmtwithExcise.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(AmountAfterExcise)", "")).ToString("#0.00");
                    txtCSTAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(CSTAmount)", "")).ToString("#0.00");
                    txtVATAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(VATAmount)", "")).ToString("#0.00");
                    txtAVATAmt.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(AVATAmount)", "")).ToString("#0.00");


                    txtSBCessAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(SBCessAmount)", "")).ToString("#0.00");
                    txtExtraTax.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(ExtraTaxAmount)", "")).ToString("#0.00");

                    if (txtDiscount.Text != "" || txtDiscount.Text != "0.00")
                        txtNetAmount.Text = (Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")) - Convert.ToDecimal(txtDiscount.Text)).ToString("#0.00");
                    else
                        txtNetAmount.Text = Convert.ToDecimal(dtPIDetail.Compute("sum(NetAmount)", "")).ToString("#0.00");
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Sales Invoice", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvPIDetail.CurrentRow == null))
            {
                if ((dgvPIDetail.Rows.Count > 1))
                {
                    if ((MessageBox.Show(("You are going to Delete the Sales Invoice." + ("\r\n" + ("\r\n" + "Are you sure ?"))), "Confirm ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes))
                    {
                        int RowIndex = dgvPIDetail.CurrentRow.Index;
                        dtPIDetail.Rows[RowIndex].Delete();
                        dtPIDetail.AcceptChanges();

                        dgvPIDetail.AutoGenerateColumns = false;
                        dgvPIDetail.DataSource = dtPIDetail;
                        ArrangePIDetailGridView();
                        CalculateNetAmount();
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Atleast one Item entry is required";
                }
            }
        }

        private void btnTNC_Click(object sender, EventArgs e)
        {
            ISEditTNCClicked = 1;
            try
            {

                DataTable dtQTNC = new DataTable();
                NameValueCollection para = new NameValueCollection();
                //para.Add("@i_Code", txtPINo.Text);
                if (_Mode == (int)Common.Constant.Mode.View)
                {
                    string RevisedQuoID = txtPINo.Text.Substring(0, 17);
                    para.Add("@i_Code", RevisedQuoID);
                    para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                    dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
                }
                else
                {
                    if (txtPINo.Text.Length > 17)
                    {
                        para.Add("@i_Code", txtPINo.Text);
                        para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                        dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Revised_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
                    }
                    else
                    {
                        para.Add("@i_Code", txtPINo.Text);
                        para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                        dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
                    }
                }

                //dtQTNC = objDA.ExecuteDataTableSP("usp_QuotationTNC_Select", para, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");
                // frmTNCLOV obj = new frmTNCLOV();

                if (dtQTNC.Rows.Count > 0)
                {

                    // frmTNCLOV fLOV = new frmTNCLOV("usp_QuotationTNC_Select", para, txtPINo.Text, "QUOTATION");
                    // fLOV.Text = "List Of Terms & Conditions";                   
                    // fLOV.ShowDialog();                   

                    //// TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                    // TYPE_OF_FORM = fLOV.TYPE_OF_SALE;

                    if (_Mode == (int)Common.Constant.Mode.View)
                    {
                        //string RevisedQuoID = txtPINo.Text.Substring(0, 17);\
                        //frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_QuotationTNC_Select", para, txtPINo.Text, "QUOTATION");

                        frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_QuotationTNC_Revised_Select", para, txtPINo.Text, "REVISED QUOTATION");
                        //fLOV.RevisedMode = 0;
                        CurrentCompany.RevisedMode = "0";
                        fLOV.Text = "List Of Terms & Conditions";
                        fLOV.ShowDialog();
                        TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                    }
                    else
                    {
                        if (txtPINo.Text.Length > 17)
                        {
                            frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_QuotationTNC_Revised_Select", para, txtPINo.Text, "REVISED QUOTATION");
                            fLOV.RevisedMode = 1;
                            fLOV.Text = "List Of Terms & Conditions";
                            fLOV.ShowDialog();
                            TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                        }
                        else
                        {
                            frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_QuotationTNC_Select", para, txtPINo.Text, "QUOTATION");
                            fLOV.Text = "List Of Terms & Conditions";
                            fLOV.ShowDialog();
                            TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                        }

                    }
                }
                else
                {
                    if (txtPINo.Text.Length > 17)
                    {
                        frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_TNC_LOV", null, txtPINo.Text, "REVISED QUOTATION");
                        fLOV.Text = "List Of Terms & Conditions";
                        fLOV.ShowDialog();
                    }
                    else
                    {
                        frmTNCLOV_NEW fLOV = new frmTNCLOV_NEW("usp_TNC_LOV", null, txtPINo.Text, "QUOTATION");
                        fLOV.Text = "List Of Terms & Conditions";
                        fLOV.ShowDialog();
                    }

                    // TYPE_OF_FORM = fLOV.TYPE_OF_SALE;
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Quotation", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnRegenrate_Click(object sender, EventArgs e)
        {
            txtPINo.Text = objCommon.AutoNumber("QU");
        }

        public void SendToMailOld()
        {
            try
            {
                //NameValueCollection para2 = new NameValueCollection();
                //_CompId = CurrentCompany.CompId;
                //_UserID = CurrentUser.UserID;

                //para2.Add("@i_CompId", CurrentCompany.CompId.ToString());

                //para2.Add("@i_UserID", _UserID.ToString());

                //dtblUser = objList.ListOfRecord("usp_User_MailDetails", para2, "User - LoadList");
                //string vMailFm = "", vMailTo, vusername = "", vSubject = "", vDetails = ""; ;

                //if (dtblUser.Rows[0]["Mail_Send"].ToString() == "True")
                //{
                //    //vMailFm = "",
                //    vMailFm = dtblUser.Rows[0]["User_Email"].ToString();
                //}
                //else
                //{
                //    vMailFm = CurrentCompany.Con_Email;
                //}

                string vMailFm = "", vMailTo = "", vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                DataTable dtQuoId = new DataTable();
                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_Code", txtPINo.Text);
                dtQuoId = objDA.ExecuteDataTableSP("usp_Quotation_Id", para1, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");

                if (File.Exists(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"))
                {
                    File.Delete(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf");
                }

                //frmQuotationList QL = new frmQuotationList();
                //QL.RPT_Sub(Convert.ToInt64(dtQuoId.Rows[0][0].ToString()), txtPINo.Text, false,true);

                //string pdfname = QL.PdfFile;

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");

                string EmailIDs = "";
                if (dtEmail.Rows.Count > 0)
                {
                    //------------------------new code for multiple contact persons-----------------

                    //dtblContactPerson
                    if (dtQContDetail != null)
                    {
                        if (dtQContDetail.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtQContDetail.Rows.Count; i++)
                            {
                                if (dtQContDetail.Rows[i]["Email"].ToString() != "")
                                {
                                    EmailIDs = EmailIDs + dtQContDetail.Rows[i]["Email"].ToString() + ",";
                                }
                                else
                                {
                                    EmailIDs = txtemail.Text.ToLower();
                                }
                            }
                            vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : EmailIDs.TrimEnd(',').ToLower());
                            //vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                        }
                        else
                        {
                            if (txtemail.Text == "")
                            {
                                MessageBox.Show("No contact detail available for this client.\n Please fill up contact person details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                            }
                            MessageBox.Show("No contact detail available for this client.\n Please fill up contact person details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    }

                    //------------------------new code for multiple contact persons-----------------

                    //vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    if (_Mode == (int)Common.Constant.Mode.View)
                    {
                        vSubject = "Revised " + dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE
                    }
                    else
                    {
                        vSubject = dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE
                    }

                    // vSubject = dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY

                    vDetails += "<br /><br />";
                    vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY
                    vDetails += "<br><br>";

                    if (txtcc.Text.Trim() != "")
                    {
                        vMail.CC.Add(txtcc.Text);
                    }
                    if (txtbcc.Text.Trim() != "")
                    {
                        vMail.Bcc.Add(txtbcc.Text);
                    }
                    vMail.Subject = vSubject;
                    vMail.Body = vDetails;
                    vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"));
                    if (dtDocList.Rows.Count > 0)
                    {
                        foreach (DataRow dtr in dtDocList.Rows)
                        {
                            if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\" + dtr["FullFileName"].ToString()));
                            }
                            else
                            {
                                vMail.Attachments.Add(new Attachment(dtr["FullFileName"].ToString()));
                            }

                        }
                    }
                    vMail.IsBodyHtml = true;

                    System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();
                    System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(CurrentCompany.Con_Email, CurrentCompany.Con_Password);

                    vSmpt.Host = CurrentCompany.Host;
                    vSmpt.Port = CurrentCompany.Port;
                    vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //vSmpt.UseDefaultCredentials = false;
                    if (CurrentCompany.ssl == 0)
                    {
                        vSmpt.EnableSsl = true;
                    }
                    else if (CurrentCompany.ssl == 1)
                    {
                        vSmpt.EnableSsl = false;
                    }

                    vSmpt.Credentials = SmtpUser;
                    vSmpt.Send(vMail);
                    MessageBox.Show("Mail has been sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    vMail.Dispose();

                    //Is_MailSend = true;

                    //objQuotationBL.UpdateMail(Is_MailSend, txtPINo.Text);

                    if (File.Exists(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"))
                    {
                        File.Delete(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf");
                    }
                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Quotation.");
                }
                //if (dtblUser.Rows[0]["Mail_Send"].ToString() == "True")
                //{
                //    //vMailFm = "",
                //    vMailFm = dtblUser.Rows[0]["User_Email"].ToString();
                //    SmtpUser = new System.Net.NetworkCredential(dtblUser.Rows[0]["User_Email"].ToString(), dtblUser.Rows[0]["User_Password"].ToString());

                //    vSmpt.Host = dtblUser.Rows[0]["User_Host"].ToString();
                //    vSmpt.Port = Convert.ToInt16(dtblUser.Rows[0]["User_Port"].ToString());


                //    if (dtblUser.Rows[0]["User_ssl"].ToString() == 0.ToString())
                //    {
                //        vSmpt.EnableSsl = true;
                //    }
                //    else if (dtblUser.Rows[0]["User_ssl"].ToString() == 1.ToString())
                //    {
                //        vSmpt.EnableSsl = false;
                //    }


                //}
                //else
                //{
                //    vMailFm = CurrentCompany.Con_Email;
                //    vSmpt.Host = CurrentCompany.Host;
                //    vSmpt.Port = CurrentCompany.Port;

                //    if ((CurrentCompany.ssl).ToString() == 0.ToString())
                //    {
                //        vSmpt.EnableSsl = true;

                //    }
                //    else if ((CurrentCompany.ssl).ToString() == 1.ToString())
                //    {
                //        vSmpt.EnableSsl = false;

                //    }

                //    //if (dtblUser.Rows[0]["User_ssl"].ToString() == 0.ToString())
                //    //{
                //    //    vSmpt.EnableSsl = true;
                //    //}
                //    //else if (dtblUser.Rows[0]["User_ssl"].ToString() == 1.ToString())
                //    //{
                //    //    vSmpt.EnableSsl = false;
                //    //}        

                //    //if (dtblUser.Columns["User_SSL"].ToString() == "0")
                //    //{
                //    //    vSmpt.EnableSsl = true;
                //    //}
                //    //else if (dtblUser.Columns["User_SSL"].ToString() == "1")
                //    //{
                //    //    vSmpt.EnableSsl = false;
                //    //}        

                //}

                //System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(CurrentCompany.Con_Email, CurrentCompany.Con_Password);

                //vSmpt.Host = CurrentCompany.Con_Host;
                //vSmpt.Port = Convert.ToInt16(CurrentCompany.Con_Port);
                //  vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                //vSmpt.UseDefaultCredentials = false;
                //if (CurrentCompany.Con_SSL == 0.ToString())
                //{
                //    vSmpt.EnableSsl = true;

                //}
                //else if (CurrentCompany.Con_SSL == 1.ToString())
                //{
                //    vSmpt.EnableSsl = false;

                //}
            }

            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
                Is_MailSend = false;
            }
        }

        public void SendToMail()
        {
            try
            {
                //string vMailFm = "", vMailTo="", vusername = "", vSubject = "", vDetails = ""; vMailFm = CurrentCompany.Con_Email;

                //----------for mail from ID starts---------------

                NameValueCollection para2 = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                _UserID = CurrentUser.UserID;

                para2.Add("@i_CompId", CurrentCompany.CompId.ToString());

                para2.Add("@i_UserID", _UserID.ToString());

                dtblUser = objList.ListOfRecord("usp_User_MailDetails", para2, "User - LoadList");
                string vMailFm = "", vMailTo = "", vusername = "", vSubject = "", vDetails = ""; ;

                if (dtblUser.Rows[0]["Mail_Send"].ToString() == "True")
                {
                    //vMailFm = "",
                    if (dtblUser.Rows[0]["User_Email"].ToString() != "")
                    {
                        vMailFm = dtblUser.Rows[0]["User_Email"].ToString();
                    }
                    else
                    {
                        vMailFm = CurrentCompany.Con_Email;
                    }
                }
                else
                {
                    vMailFm = CurrentCompany.Con_Email;
                }
                //----------for mail from ID end---------------



                DataTable dtQuoId = new DataTable();
                NameValueCollection para1 = new NameValueCollection();
                para1.Add("@i_Code", txtPINo.Text);
                para1.Add("@i_CompId", CurrentCompany.CompId.ToString());

                dtQuoId = objDA.ExecuteDataTableSP("usp_Quotation_Id", para1, false, ref mException, ref mErrorMsg, "Quotation TNC - Select");

                if (File.Exists(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"))
                {
                    //MessageBox.Show("File exists");
                    File.Delete(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf");
                }

                //if (File.Exists(@"\\SERVER\d\JPCRM\Doc\pdf\Quotation.Doc"))
                //{
                //    MessageBox.Show("File exists");
                //    File.Delete(@"\\SERVER\d\JPCRM\Doc\pdf\Quotation.Doc");
                //}

                frmQuotationList QL = new frmQuotationList();
                if (cbIsQuoWithTaxes.Checked)
                {
                    QL.RPT_Sub(Convert.ToInt64(dtQuoId.Rows[0][0].ToString()), txtPINo.Text, false, true, true, true);
                }
                else
                {
                    QL.RPT_Sub(Convert.ToInt64(dtQuoId.Rows[0][0].ToString()), txtPINo.Text, false, false, true, true);
                }

                string pdfname = QL.PdfFile;

                DataTable dtEmail = new DataTable();
                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Type", "Quotation");
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                dtEmail = objList.ListOfRecord("usp_Email_LOV", para, "Email LOV - LoadList");

                string EmailIDs = "";
                if (dtEmail.Rows.Count > 0)
                {
                    //------------------------new code for multiple contact persons-----------------

                    //dtblContactPerson
                    if (dtQContDetail != null)
                    {
                        if (dtQContDetail.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtQContDetail.Rows.Count; i++)
                            {
                                if (dtQContDetail.Rows[i]["Email"].ToString() != "")
                                {
                                    EmailIDs = EmailIDs + dtQContDetail.Rows[i]["Email"].ToString() + ",";
                                }
                                else
                                {
                                    EmailIDs = txtemail.Text.ToLower();
                                }
                            }
                            vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : EmailIDs.TrimEnd(',').ToLower());
                            //vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                        }
                        else
                        {
                            if (txtemail.Text == "")
                            {
                                MessageBox.Show("No contact detail available for this client.\n Please fill up contact person details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                            }
                            //MessageBox.Show("No contact detail available for this client.\n Please fill up contact person details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    }

                    //------------------------new code for multiple contact persons-----------------

                    //vMailTo = ((txtemail.Text.ToLower() == "") ? CurrentCompany.Con_Email : txtemail.Text.ToLower());
                    //vMailTo = ((txtFatherMailId.Text == "") ? Convert.ToString(ViewState["Femail"]) : txtFatherMailId.Text);
                    System.Net.Mail.MailMessage vMail = new System.Net.Mail.MailMessage(vMailFm, vMailTo);

                    if (_Mode == (int)Common.Constant.Mode.View)
                    {
                        vSubject = "Revised " + dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE
                    }
                    else
                    {
                        vSubject = dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE
                    }

                    // vSubject = dtEmail.Rows[0][0].ToString() + " For " + txtSubject.Text.Replace("\n", "<br />") + " From " + CurrentCompany.CompanyName; // SUBJECT LINE

                    vDetails = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
                    //txtHeader.Text = dtEmail.Rows[0][1].ToString(); // HEADER PART OF BODY
                    //vDetails = "<p>" + txtHeader.Text.ToString() + "</p>";
                    vDetails += "<br /><br />";
                    vDetails += "<p>" + dtEmail.Rows[0][2].ToString() + "</p>"; // FOOTER PART OF BODY
                    vDetails += "<br><br>";

                    if (txtcc.Text.Trim() != "")
                    {
                        vMail.CC.Add(txtcc.Text);
                    }
                    if (txtbcc.Text.Trim() != "")
                    {
                        vMail.Bcc.Add(txtbcc.Text);
                    }
                    vMail.Subject = vSubject;
                    vMail.Body = vDetails;
                    vMail.Attachments.Add(new Attachment((CurrentUser.DocumentPath + @"\pdf\Quotation.pdf")));
                    if (dtDocList.Rows.Count > 0)
                    {
                        foreach (DataRow dtr in dtDocList.Rows)
                        {
                            if (_Mode == (int)Common.Constant.Mode.Modify)
                            {
                                if (File.Exists(CurrentUser.DocumentPath + @"\" + dtr["FullFileName"].ToString()))
                                {
                                    vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\" + dtr["FullFileName"].ToString()));
                                }
                                else
                                {
                                    vMail.Attachments.Add(new Attachment(dtr["FullFileName"].ToString()));
                                }
                            }
                            else
                            {
                                if (_Mode == (int)Common.Constant.Mode.View)
                                {
                                    if (File.Exists(CurrentUser.DocumentPath + @"\" + dtr["FullFileName"].ToString()))
                                    {
                                        vMail.Attachments.Add(new Attachment(CurrentUser.DocumentPath + @"\" + dtr["FullFileName"].ToString()));
                                    }
                                    else
                                    {
                                        vMail.Attachments.Add(new Attachment(dtr["FullFileName"].ToString()));
                                    }
                                }
                                else
                                {
                                    vMail.Attachments.Add(new Attachment(dtr["FullFileName"].ToString()));
                                }
                            }
                        }
                    }
                    vMail.IsBodyHtml = true;

                    System.Net.Mail.SmtpClient vSmpt = new System.Net.Mail.SmtpClient();

                    //---------check for By user Mailsend status and set credentials for from send mail,pwd----------------
                    //----old code--------
                    //vSmpt.Host = CurrentCompany.Host;
                    //vSmpt.Port = CurrentCompany.Port;
                    //vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                    ////vSmpt.UseDefaultCredentials = false;
                    //if (CurrentCompany.ssl == 0)
                    //{
                    //    vSmpt.EnableSsl = true;
                    //}
                    //else if (CurrentCompany.ssl == 1)
                    //{
                    //    vSmpt.EnableSsl = false;
                    //}
                    //-------------                    

                    string UserName = "";
                    string Password = "";

                    if (dtblUser.Rows[0]["Mail_Send"].ToString() == "True")
                    {
                        //vMailFm = "",
                        if (dtblUser.Rows[0]["User_Email"].ToString() != "" && dtblUser.Rows[0]["User_NPassword"].ToString() != "")
                        {
                            UserName = dtblUser.Rows[0]["User_Email"].ToString();
                            Password = dtblUser.Rows[0]["User_NPassword"].ToString();
                        }
                        else
                        {
                            UserName = CurrentCompany.Con_Email;
                            Password = CurrentCompany.Con_Password;
                        }
                    }
                    else
                    {
                        UserName = CurrentCompany.Con_Email;
                        Password = CurrentCompany.Con_Password;
                    }

                    vSmpt.UseDefaultCredentials = false;
                    vSmpt.Timeout = 800000;

                    System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential(UserName, Password);

                    if (dtblUser.Rows[0]["Mail_Send"].ToString() == "True")
                    {
                        if (dtblUser.Rows[0]["User_Email"].ToString() != "" && dtblUser.Rows[0]["User_NPassword"].ToString() != "")
                        {
                            if (dtblUser.Rows[0]["User_Host"].ToString() == "")
                            {
                                MessageBox.Show("Email credentials have missing Host detail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                vSmpt.Host = dtblUser.Rows[0]["User_Host"].ToString();
                            }

                            //vSmpt.Host = dtblUser.Rows[0]["User_Host"].ToString();
                            if (dtblUser.Rows[0]["User_Port"].ToString() == "0")
                            {
                                MessageBox.Show("Email credentials have missing Port detail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                vSmpt.Port = Convert.ToInt32(dtblUser.Rows[0]["User_Port"].ToString());
                            }

                            //vSmpt.Port = Convert.ToInt32(dtblUser.Rows[0]["User_Port"].ToString());
                            if (dtblUser.Rows[0]["User_ssl"].ToString() == "")
                            {
                                MessageBox.Show("Email credentials have missing SSL detail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (dtblUser.Rows[0]["User_ssl"].ToString() == "0")
                                {
                                    vSmpt.EnableSsl = true;
                                }
                                if (dtblUser.Rows[0]["User_ssl"].ToString() == "1")
                                {
                                    vSmpt.EnableSsl = false;
                                }
                            }
                            //if (dtblUser.Rows[0]["User_ssl"].ToString() == "0")
                            //{
                            //    vSmpt.EnableSsl = true;
                            //}
                            //if (dtblUser.Rows[0]["User_ssl"].ToString() == "1")
                            //{
                            //    vSmpt.EnableSsl = false;
                            //}
                        }
                        else
                        {
                            vSmpt.Host = CurrentCompany.Host;
                            vSmpt.Port = CurrentCompany.Port;
                            vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                            if (CurrentCompany.ssl == 0)
                            {
                                vSmpt.EnableSsl = true;
                            }
                            else if (CurrentCompany.ssl == 1)
                            {
                                vSmpt.EnableSsl = false;
                            }
                        }

                    }
                    else
                    {
                        vSmpt.Host = CurrentCompany.Host;
                        vSmpt.Port = CurrentCompany.Port;
                        vSmpt.DeliveryMethod = SmtpDeliveryMethod.Network;
                        if (CurrentCompany.ssl == 0)
                        {
                            vSmpt.EnableSsl = true;
                        }
                        else if (CurrentCompany.ssl == 1)
                        {
                            vSmpt.EnableSsl = false;
                        }
                    }

                    //---------check for By user Mailsend status and set credentials for from send mail,pwd,host,port,ssl----------------


                    vSmpt.Credentials = SmtpUser;
                    //  Application.DoEvents();
                    vSmpt.Send(vMail);
                    MessageBox.Show("Mail has been sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Is_MailSend = true;
                    objQuotationBL.UpdateMail(Is_MailSend, txtPINo.Text);

                    vMail.Dispose();

                    //Is_MailSend = true;

                    //objQuotationBL.UpdateMail(Is_MailSend, txtPINo.Text);
                    //MessageBox.Show(" It will get path");
                    if (File.Exists(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf"))
                    {
                        File.Delete(CurrentUser.DocumentPath + @"\pdf\Quotation.pdf");
                    }
                    //MessageBox.Show(" Path got");
                }
                else
                {
                    MessageBox.Show("For Sending Email, First Set Email Details For Quotation.");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("There is some problem to send Email");
                MessageBox.Show(ex.Message + " actual issue");
                Is_MailSend = false;
            }
        }


        private void btnedit_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            string StrItem = "#";
            for (int i = 0; (i <= (dgvPIDetail.Rows.Count - 1)); i++)
            {
                StrItem = (StrItem + (dgvPIDetail.Rows[i].Cells["ItemID"].Value + "#"));
            }
            // int godown = Convert.ToInt32(cmbgodown.SelectedValue);
            int ItemID_Edit = Convert.ToInt32(dgvPIDetail.CurrentRow.Cells["ItemID"].Value);
            string ItemDesc_Edit = dgvPIDetail.CurrentRow.Cells["ItemDesc"].Value.ToString();

            if (dgvPIDetail.CurrentRow.Index.ToString() == "0")
            {
                IsFirstItem = true;
            }
            else
            {
                IsFirstItem = false;
            }

            _CurrencyID = Convert.ToInt64(cmbCurrency.SelectedValue);
            Quotation.frmQuotationItemEntry fPIEntry = new Quotation.frmQuotationItemEntry((int)Constant.Mode.Modify, _SIID, _CustomerID, dtpSaleDate.Value, dtPIDetail, ItemID_Edit, ItemDesc_Edit, _CurrencyID, IsFirstItem);
            fPIEntry.ShowDialog();
            dgvPIDetail.AutoGenerateColumns = false;
            dgvPIDetail.DataSource = dtPIDetail;
            ArrangePIDetailGridView();

            if (_Mode == (int)Common.Constant.Mode.Insert)
            {
                for (int i = 0; i < dgvPIDetail.Rows.Count; i++)
                {
                    cmbCurrency.SelectedValue = dgvPIDetail.Rows[0].Cells["CurrencyID"].Value.ToString();
                }
            }

            if (_Mode == (int)Common.Constant.Mode.Modify)
            {
                for (int i = 1; i < dgvPIDetail.Rows.Count; i++)
                {
                    cmbCurrency.SelectedValue = dgvPIDetail.Rows[dgvPIDetail.Rows.Count - 1].Cells["CurrencyID"].Value.ToString();
                }
            }

            CalculateNetAmount();
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
            //if (txtDocName.Text == "")
            //{
            //    txtDocName.Focus();
            //    return;
            //}
            //DataRow dr = dtDocList.NewRow();
            //dr["FileName"] = txtDocName.Text;
            //dr["FullFileName"] = SelectedFileName;

            //dtDocList.Rows.Add(dr);


            //ArrangeDocumentGridView();
            //dgvCountry.AutoGenerateColumns = false;
            //dgvCountry.DataSource = dtDocList;
            //ArrangeDocumentGridView();
            //txtDocName.Text = "";
            //SelectedFileName = "";

            //btnAddDoc.Focus();

            //-----------------

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

                string DelFileName = dtDocList.Rows[RowIndex]["FullFileName"].ToString();
                string DelFileName1 = CurrentUser.DocumentPath.ToString();

                //File.Copy(dr["FullFileName"].ToString(), newFileName, true);
                if (File.Exists(CurrentUser.DocumentPath + DelFileName))
                {
                    File.Delete(CurrentUser.DocumentPath + DelFileName);
                }

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

        private void chkTNC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTNC.Checked == true)
            {
                btnTNC.Enabled = false;
                ISEditTNCClicked = 0;
            }
            else
            {
                btnTNC.Enabled = true;
            }
        }

        private void frmQuotationNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_Mode == (int)Constant.Mode.Insert)
            {
                if (QTNC == 0)
                {
                    objQuotationBL.DeleteTNC_On_Close("QUOTATION", txtPINo.Text);
                }
            }
        }

        private void btnContactPerson_Click(object sender, EventArgs e)
        {
            try
            {

                NameValueCollection para = new NameValueCollection();
                para.Add("@i_Code", txtPINo.Text);
                para.Add("@i_CompID", CurrentCompany.CompId.ToString());
                if (dtContactDetail.Columns.Count > 0)
                {

                }
                else
                {
                    LoadContactDetailList();
                }

                dtQContDetail = objDA.ExecuteDataTableSP("usp_QuotationContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");
                if (dtQContDetail != null)
                {
                    ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.QCUpdate, 0, txtLeadNo.Text.Substring(4, 5), txtPINo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "QUOTATION");
                    fLOV.Text = "List Of Conatct Details";
                    fLOV.ShowDialog();
                    dtQContDetail = objDA.ExecuteDataTableSP("usp_QuotationContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");

                    //-----------For MuliContact Display ----------
                    string MultiContact = "";
                    string MultiEmail = "";
                    string MultiMobile = "";
                    for (int i = 0; i < dtQContDetail.Rows.Count; i++)
                    {
                        // +=    
                        MultiContact += dtQContDetail.Rows[i]["ContactName"].ToString() + ",";
                        MultiEmail += dtQContDetail.Rows[i]["Email"].ToString() + ",";
                        MultiMobile += dtQContDetail.Rows[i]["Mobile"].ToString() + ",";
                    }
                    txtcontactperson.Text = MultiContact.TrimEnd(',');
                    txtemail.Text = MultiEmail.TrimEnd(',');
                    txtmobile.Text = MultiMobile.TrimEnd(',');
                    //--------------------------
                }
                else
                {
                    ContactPerson.frmContactPersonSelect fLOV = new ContactPerson.frmContactPersonSelect((int)Constant.Mode.QCInsert, 0, txtLeadNo.Text.Substring(4, 5), txtPINo.Text, dtContactDetail, "usp_ContactDetail_LOV", null, "QUOTATION");
                    fLOV.Text = "List Of Conatct Details";
                    fLOV.ShowDialog();
                    dtQContDetail = objDA.ExecuteDataTableSP("usp_QuotationContact_Select", para, false, ref mException, ref mErrorMsg, "Quotation Contact - Select");

                    //-----------For MuliContact Display ----------
                    string MultiContact = "";
                    string MultiEmail = "";
                    string MultiMobile = "";
                    for (int i = 0; i < dtQContDetail.Rows.Count; i++)
                    {
                        // +=    
                        MultiContact += dtQContDetail.Rows[i]["ContactName"].ToString() + ",";
                        MultiEmail += dtQContDetail.Rows[i]["Email"].ToString() + ",";
                        MultiMobile += dtQContDetail.Rows[i]["Mobile"].ToString() + ",";
                    }
                    txtcontactperson.Text = MultiContact.TrimEnd(',');
                    txtemail.Text = MultiEmail.TrimEnd(',');
                    txtmobile.Text = MultiMobile.TrimEnd(',');
                    //--------------------------
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Vendor", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void txtCustName_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadList()
        {
            try
            {
                NameValueCollection para = new NameValueCollection();
                _CompId = CurrentCompany.CompId;
                para.Add("@i_CompId", CurrentCompany.CompId.ToString());
                para.Add("@i_UserID", CurrentUser.UserID.ToString());

                dtblLOV = objList.ListOfRecord("usp_Customer_LOV", para, "Customer LOV - LoadList");

                //txtCustName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //txtCustName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteStringCollection Data = new AutoCompleteStringCollection();

                if (objList.Exception == null)
                {

                    //for (int i = 0; i < dtblLOV.Rows.Count; i++)
                    //{
                    //    Data.Add(dtblLOV.Rows[i]["CustomerName"].ToString());
                    //}
                    //txtCustName.AutoCompleteCustomSource = Data;

                    //-------------For Autosearch--
                    var source = new List<string>();
                    for (int i = 0; i < dtblLOV.Rows.Count; i++)
                    {
                        source.Add(dtblLOV.Rows[i]["CustomerName"].ToString());
                    }
                    txtCustName.AutoCompleteList = source;
                    //----------------
                }
                else
                {
                    MessageBox.Show(objList.Exception.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exc)
            {
                Utill.Common.ExceptionLogger.writeException("Customer LOV", exc.StackTrace);
                MessageBox.Show(Utill.Common.CommonMessage.ExceptionMesg, "Exception");
            }
        }

        private void btnSavePriview_Click(object sender, EventArgs e)
        {
            NameValueCollection para = new NameValueCollection();
            para.Add("@i_CompId", CurrentCompany.CompId.ToString());
            para.Add("@i_quaId", Convert.ToString(_QuotationID));

            dtblLOV = objList.ListOfRecord("usp_IsCUST_Select", para, "Customer LOV - LoadList");
            if (dtblLOV.Rows.Count > 0)
            {
                if (dtblLOV.Rows[0]["IsCustomer"].ToString() == "True")
                {
                    IsCustomer = true;
                }
                else
                {
                    IsCustomer = false;
                }
            }

            QTNC = 1;
            QPriview = 1;
            if (SetSave())
            {
                this.Close();
            }
        }

        private void txtCustName_Leave(object sender, EventArgs e)
        {
            StrFilter = "";
            if (dtblLOV != null)
            {
                if (dtblLOV.Rows.Count > 0)
                {
                    if (txtCustName.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerName = '" + PrepareFilterString(txtCustName.Text.Trim()) + "' OR ";
                    }

                    if (StrFilter != "")
                    {
                        StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                    }

                    DV = dtblLOV.DefaultView;
                    DV.RowFilter = StrFilter;
                    DataTable dtCustomer = new DataTable();
                    dtCustomer = DV.ToTable();
                    if (DV.ToTable() != null)
                    {
                        if (DV.ToTable().Rows.Count > 0)
                        {
                            txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                            // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
                            txtCustName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                            _LeadID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                            txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                            txtmobile.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                            txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                            txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                            txtAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                            cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                            cmbEmp.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();

                            if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCustName.Focus();
                        }
                    }

                    //dgvLOV.DataSource = DV.ToTable();
                }
            }
        }

        private void txtCustName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                StrFilter = "";
                if (dtblLOV != null)
                {
                    if (dtblLOV.Rows.Count > 0)
                    {
                        if (txtCustName.Text.Trim() != "")
                        {
                            StrFilter = StrFilter + " CustomerName = '" + PrepareFilterString(txtCustName.Text.Trim()) + "' OR ";
                        }

                        if (StrFilter != "")
                        {
                            StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                        }

                        DV = dtblLOV.DefaultView;
                        DV.RowFilter = StrFilter;
                        DataTable dtCustomer = new DataTable();
                        dtCustomer = DV.ToTable();
                        if (DV.ToTable() != null)
                        {
                            if (DV.ToTable().Rows.Count > 0)
                            {
                                txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                                // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
                                txtCustName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                                _LeadID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                                txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                                txtmobile.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                                txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                                txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                                txtAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                                cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                                cmbEmp.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                                cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();
                                btnContactPerson.Focus();
                                //if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                                //{
                                //    IsCustomer = true;
                                //}
                                //else
                                //{
                                //    IsCustomer = false;
                                //}
                            }
                            else
                            {
                                MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCustName.Focus();
                            }
                        }

                        //dgvLOV.DataSource = DV.ToTable();
                    }
                }
            }
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                StrFilter = "";
                if (dtblLOV != null)
                {
                    if (dtblLOV.Rows.Count > 0)
                    {
                        if (txtCustName.Text.Trim() != "")
                        {
                            StrFilter = StrFilter + " CustomerCode = '" + PrepareFilterString(txtLeadNo.Text.Trim()) + "' OR ";
                        }

                        if (StrFilter != "")
                        {
                            StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                        }

                        DV = dtblLOV.DefaultView;
                        DV.RowFilter = StrFilter;
                        DataTable dtCustomer = new DataTable();
                        dtCustomer = DV.ToTable();
                        if (DV.ToTable() != null)
                        {
                            if (DV.ToTable().Rows.Count > 0)
                            {
                                txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                                // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
                                txtCustName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                                _LeadID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                                txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                                txtmobile.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                                txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                                txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                                txtAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                                cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                                cmbEmp.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                                cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();
                                btnContactPerson.Focus();
                                //if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                                //{
                                //    IsCustomer = true;
                                //}
                                //else
                                //{
                                //    IsCustomer = false;
                                //}
                            }
                            else
                            {
                                MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCustName.Focus();
                            }
                        }

                        //dgvLOV.DataSource = DV.ToTable();
                    }
                }
            }
        }

        private void txtItemName_Leave(object sender, EventArgs e)
        {
            //if(txtCustName.LostFocus)
            //this.txtCustName.CausesValidation = false;
            //this.Close();
            StrFilter = "";
            if (dtblLOV != null)
            {
                if (dtblLOV.Rows.Count > 0)
                {
                    if (txtCustName.Text.Trim() != "")
                    {
                        StrFilter = StrFilter + " CustomerCode = '" + PrepareFilterString(txtLeadNo.Text.Trim()) + "' OR ";
                    }

                    if (StrFilter != "")
                    {
                        StrFilter = StrFilter.Substring(0, StrFilter.Length - 4);
                    }

                    DV = dtblLOV.DefaultView;
                    DV.RowFilter = StrFilter;
                    DataTable dtCustomer = new DataTable();
                    dtCustomer = DV.ToTable();
                    if (DV.ToTable() != null)
                    {
                        if (DV.ToTable().Rows.Count > 0)
                        {
                            txtLeadNo.Text = dtCustomer.Rows[0]["CustomerCode"].ToString();
                            // txtLeaddate.Text = fLOV.LeadDate.ToShortDateString();
                            txtCustName.Text = dtCustomer.Rows[0]["CustomerName"].ToString();
                            _LeadID = Convert.ToInt64(dtCustomer.Rows[0]["CustomerID"].ToString());
                            txtemail.Text = dtCustomer.Rows[0]["Email"].ToString();
                            txtmobile.Text = dtCustomer.Rows[0]["Mobile"].ToString();
                            txtcontactperson.Text = dtCustomer.Rows[0]["ContactPerson"].ToString();
                            txtLeaddate.Text = dtCustomer.Rows[0]["LeadDate"].ToString();
                            txtAddress.Text = dtCustomer.Rows[0]["Address"].ToString();
                            cmbCategory.Text = dtCustomer.Rows[0]["Category"].ToString();
                            cmbEmp.SelectedValue = dtCustomer.Rows[0]["EmpID"].ToString();
                            cmbEmpAllocatedTo.SelectedValue = dtCustomer.Rows[0]["AllocatedToEmpID"].ToString();
                            btnContactPerson.Focus();
                            if (dtCustomer.Rows[0]["CustomerCode"].ToString().Contains("CUST"))
                            {
                                IsCustomer = true;
                            }
                            else
                            {
                                IsCustomer = false;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Customer does not exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCustName.Focus();
                        }
                    }

                    //dgvLOV.DataSource = DV.ToTable();
                }
            }
        }
    }
}
