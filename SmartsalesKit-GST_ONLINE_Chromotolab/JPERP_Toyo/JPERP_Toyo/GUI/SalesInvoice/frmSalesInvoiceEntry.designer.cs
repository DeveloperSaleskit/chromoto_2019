namespace Account.GUI.SalesInvoice
{
    partial class frmSalesInvoiceEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbBusinessType = new System.Windows.Forms.ComboBox();
            this.label60 = new System.Windows.Forms.Label();
            this.txtIGSTAmt = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.txtCGSTAmt = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtSGSTAmt = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.grpBankDetail = new System.Windows.Forms.GroupBox();
            this.txtCustomerBankName = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.cmbbankName = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.dtpchequeDate = new System.Windows.Forms.DateTimePicker();
            this.label50 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.GrpCN = new System.Windows.Forms.GroupBox();
            this.txtAdjCN = new System.Windows.Forms.TextBox();
            this.txtTotalPaidAmount = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtRemainingCN = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtCNoutstand = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.cmbAgainstCN = new System.Windows.Forms.ComboBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.txtSBCessAmount = new System.Windows.Forms.TextBox();
            this.lblExtraTax = new System.Windows.Forms.Label();
            this.txtExtraTax = new System.Windows.Forms.TextBox();
            this.txtChallanNo = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnContactPerson = new System.Windows.Forms.Button();
            this.txtDicAmt = new System.Windows.Forms.TextBox();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.lblNetAmt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRec = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtDuedays = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnDis = new System.Windows.Forms.Button();
            this.txtCustInvoiceNo = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.grpItemDetail = new System.Windows.Forms.GroupBox();
            this.dgvPIDetail = new System.Windows.Forms.DataGridView();
            this.GodownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExciseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECessAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HECessAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountAfterExcise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VATAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AVATAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SBCessAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraTaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscountAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtECType3 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtextracharges3 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtECType2 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtextracharges2 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbEmpAllocatedTo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnTNC = new System.Windows.Forms.Button();
            this.txtextrachargestype = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtextracharges = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.chkTNC = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.txtcontactperson = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.cmbAttendedBy = new System.Windows.Forms.ComboBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtServiceAmt = new System.Windows.Forms.TextBox();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.dtpPIDate = new System.Windows.Forms.DateTimePicker();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtVATAmt = new System.Windows.Forms.TextBox();
            this.lblAVAT = new System.Windows.Forms.Label();
            this.txtAVATAmt = new System.Windows.Forms.TextBox();
            this.lblCST = new System.Windows.Forms.Label();
            this.txtCSTAmt = new System.Windows.Forms.TextBox();
            this.lblExcise = new System.Windows.Forms.Label();
            this.txtExciseAmt = new System.Windows.Forms.TextBox();
            this.lblEduCess = new System.Windows.Forms.Label();
            this.lblHEduCess = new System.Windows.Forms.Label();
            this.lblAmtwithexcise = new System.Windows.Forms.Label();
            this.txtAmtwithExcise = new System.Windows.Forms.TextBox();
            this.txtHEduCessAmt = new System.Windows.Forms.TextBox();
            this.txtEduCessAmt = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.btnCustomerLOV = new System.Windows.Forms.Button();
            this.Errcustname = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.ErrOrderNo = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbgodown = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.Errlabel7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpExtraReminder = new System.Windows.Forms.DateTimePicker();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.txtExtraReminder = new System.Windows.Forms.TextBox();
            this.dtpReminder = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpInstallation = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDCDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvServicesReminder = new System.Windows.Forms.DataGridView();
            this.ServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReminderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoOfServices = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chksend = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbcc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtcc = new System.Windows.Forms.TextBox();
            this.gpDocDet = new System.Windows.Forms.GroupBox();
            this.dgvCountry = new System.Windows.Forms.DataGridView();
            this.OpenFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteDoc = new System.Windows.Forms.Button();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtShippingAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblrequired = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnGeneratePI = new System.Windows.Forms.Button();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.grpData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpBankDetail.SuspendLayout();
            this.GrpCN.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpItemDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPIDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesReminder)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpDocDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            this.grpErrorZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.groupBox2);
            this.grpData.Controls.Add(this.groupBox1);
            this.grpData.Controls.Add(this.gpDocDet);
            this.grpData.Location = new System.Drawing.Point(12, 46);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(1143, 627);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbBusinessType);
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Controls.Add(this.txtIGSTAmt);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.txtCGSTAmt);
            this.groupBox2.Controls.Add(this.label56);
            this.groupBox2.Controls.Add(this.txtSGSTAmt);
            this.groupBox2.Controls.Add(this.label55);
            this.groupBox2.Controls.Add(this.label54);
            this.groupBox2.Controls.Add(this.grpBankDetail);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.cmbMode);
            this.groupBox2.Controls.Add(this.GrpCN);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Controls.Add(this.cmbAgainstCN);
            this.groupBox2.Controls.Add(this.label44);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.txtSBCessAmount);
            this.groupBox2.Controls.Add(this.lblExtraTax);
            this.groupBox2.Controls.Add(this.txtExtraTax);
            this.groupBox2.Controls.Add(this.txtChallanNo);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.btnContactPerson);
            this.groupBox2.Controls.Add(this.txtDicAmt);
            this.groupBox2.Controls.Add(this.txtNetAmount);
            this.groupBox2.Controls.Add(this.lblNetAmt);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.btnDis);
            this.groupBox2.Controls.Add(this.txtCustInvoiceNo);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.label33);
            this.groupBox2.Controls.Add(this.grpItemDetail);
            this.groupBox2.Controls.Add(this.txtECType3);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.txtextracharges3);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.txtECType2);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.txtextracharges2);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.cmbEmpAllocatedTo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.cmbType);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.btnTNC);
            this.groupBox2.Controls.Add(this.txtextrachargestype);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.txtextracharges);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.chkTNC);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtNarration);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtmobile);
            this.groupBox2.Controls.Add(this.txtcontactperson);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtAddress1);
            this.groupBox2.Controls.Add(this.cmbAttendedBy);
            this.groupBox2.Controls.Add(this.txtemail);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtServiceAmt);
            this.groupBox2.Controls.Add(this.txtPaidAmount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCustomer);
            this.groupBox2.Controls.Add(this.dtpPIDate);
            this.groupBox2.Controls.Add(this.lblVAT);
            this.groupBox2.Controls.Add(this.txtVATAmt);
            this.groupBox2.Controls.Add(this.lblAVAT);
            this.groupBox2.Controls.Add(this.txtAVATAmt);
            this.groupBox2.Controls.Add(this.lblCST);
            this.groupBox2.Controls.Add(this.txtCSTAmt);
            this.groupBox2.Controls.Add(this.lblExcise);
            this.groupBox2.Controls.Add(this.txtExciseAmt);
            this.groupBox2.Controls.Add(this.lblEduCess);
            this.groupBox2.Controls.Add(this.lblHEduCess);
            this.groupBox2.Controls.Add(this.lblAmtwithexcise);
            this.groupBox2.Controls.Add(this.txtAmtwithExcise);
            this.groupBox2.Controls.Add(this.txtHEduCessAmt);
            this.groupBox2.Controls.Add(this.txtEduCessAmt);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.lblAmount);
            this.groupBox2.Controls.Add(this.btnRegenrate);
            this.groupBox2.Controls.Add(this.txtPINo);
            this.groupBox2.Controls.Add(this.lblOrderNo);
            this.groupBox2.Controls.Add(this.lblOrderDate);
            this.groupBox2.Controls.Add(this.btnCustomerLOV);
            this.groupBox2.Controls.Add(this.Errcustname);
            this.groupBox2.Controls.Add(this.lblCustomer);
            this.groupBox2.Controls.Add(this.ErrOrderNo);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbgodown);
            this.groupBox2.Controls.Add(this.lblCity);
            this.groupBox2.Controls.Add(this.Errlabel7);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 614);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sales Details:";
            // 
            // cmbBusinessType
            // 
            this.cmbBusinessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusinessType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusinessType.FormattingEnabled = true;
            this.cmbBusinessType.Items.AddRange(new object[] {
            "--Select--",
            "Business",
            "Individual"});
            this.cmbBusinessType.Location = new System.Drawing.Point(454, 12);
            this.cmbBusinessType.Name = "cmbBusinessType";
            this.cmbBusinessType.Size = new System.Drawing.Size(110, 21);
            this.cmbBusinessType.TabIndex = 370;
            this.cmbBusinessType.Tag = "Select Business Type;";
            this.cmbBusinessType.SelectedIndexChanged += new System.EventHandler(this.cmbBusinessType_SelectedIndexChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label60.Location = new System.Drawing.Point(387, 10);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(61, 26);
            this.label60.TabIndex = 369;
            this.label60.Text = "Business \r\nType :";
            // 
            // txtIGSTAmt
            // 
            this.txtIGSTAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtIGSTAmt.Location = new System.Drawing.Point(554, 253);
            this.txtIGSTAmt.MaxLength = 12;
            this.txtIGSTAmt.Name = "txtIGSTAmt";
            this.txtIGSTAmt.ReadOnly = true;
            this.txtIGSTAmt.Size = new System.Drawing.Size(267, 21);
            this.txtIGSTAmt.TabIndex = 367;
            this.txtIGSTAmt.TabStop = false;
            this.txtIGSTAmt.Tag = "IGST amount;";
            this.txtIGSTAmt.Text = "0.00";
            this.txtIGSTAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label58.Location = new System.Drawing.Point(504, 256);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(41, 13);
            this.label58.TabIndex = 366;
            this.label58.Text = "IGST:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label57.Location = new System.Drawing.Point(503, 237);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(45, 13);
            this.label57.TabIndex = 365;
            this.label57.Text = "CGST:";
            // 
            // txtCGSTAmt
            // 
            this.txtCGSTAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCGSTAmt.Location = new System.Drawing.Point(554, 229);
            this.txtCGSTAmt.MaxLength = 12;
            this.txtCGSTAmt.Name = "txtCGSTAmt";
            this.txtCGSTAmt.ReadOnly = true;
            this.txtCGSTAmt.Size = new System.Drawing.Size(267, 21);
            this.txtCGSTAmt.TabIndex = 364;
            this.txtCGSTAmt.TabStop = false;
            this.txtCGSTAmt.Tag = "CGST amount;";
            this.txtCGSTAmt.Text = "0.00";
            this.txtCGSTAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label56.Location = new System.Drawing.Point(504, 215);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(44, 13);
            this.label56.TabIndex = 363;
            this.label56.Text = "SGST:";
            // 
            // txtSGSTAmt
            // 
            this.txtSGSTAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSGSTAmt.Location = new System.Drawing.Point(554, 207);
            this.txtSGSTAmt.MaxLength = 12;
            this.txtSGSTAmt.Name = "txtSGSTAmt";
            this.txtSGSTAmt.ReadOnly = true;
            this.txtSGSTAmt.Size = new System.Drawing.Size(267, 21);
            this.txtSGSTAmt.TabIndex = 362;
            this.txtSGSTAmt.TabStop = false;
            this.txtSGSTAmt.Tag = "SGST amount;";
            this.txtSGSTAmt.Text = "0.00";
            this.txtSGSTAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(187, 45);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(77, 13);
            this.label55.TabIndex = 361;
            this.label55.Text = " Invoice No:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label54.Location = new System.Drawing.Point(1, 515);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(96, 13);
            this.label54.TabIndex = 360;
            this.label54.Text = "Payment Mode:";
            // 
            // grpBankDetail
            // 
            this.grpBankDetail.Controls.Add(this.txtCustomerBankName);
            this.grpBankDetail.Controls.Add(this.label53);
            this.grpBankDetail.Controls.Add(this.txtChequeNo);
            this.grpBankDetail.Controls.Add(this.cmbbankName);
            this.grpBankDetail.Controls.Add(this.label51);
            this.grpBankDetail.Controls.Add(this.lblFromDate);
            this.grpBankDetail.Controls.Add(this.label52);
            this.grpBankDetail.Controls.Add(this.dtpchequeDate);
            this.grpBankDetail.Location = new System.Drawing.Point(6, 541);
            this.grpBankDetail.Name = "grpBankDetail";
            this.grpBankDetail.Size = new System.Drawing.Size(216, 41);
            this.grpBankDetail.TabIndex = 343;
            this.grpBankDetail.TabStop = false;
            this.grpBankDetail.Text = "Bank Details";
            // 
            // txtCustomerBankName
            // 
            this.txtCustomerBankName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerBankName.Location = new System.Drawing.Point(295, 14);
            this.txtCustomerBankName.MaxLength = 50;
            this.txtCustomerBankName.Multiline = true;
            this.txtCustomerBankName.Name = "txtCustomerBankName";
            this.txtCustomerBankName.Size = new System.Drawing.Size(126, 22);
            this.txtCustomerBankName.TabIndex = 342;
            this.txtCustomerBankName.Tag = "Enter Bank Name;";
            this.txtCustomerBankName.TextChanged += new System.EventHandler(this.txtCustomerBankName_TextChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label53.Location = new System.Drawing.Point(217, 18);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(75, 13);
            this.label53.TabIndex = 341;
            this.label53.Text = "Bank(OUT):";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(506, 13);
            this.txtChequeNo.MaxLength = 50;
            this.txtChequeNo.Multiline = true;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(104, 22);
            this.txtChequeNo.TabIndex = 333;
            this.txtChequeNo.Tag = "Enter Cheque No;";
            // 
            // cmbbankName
            // 
            this.cmbbankName.FormattingEnabled = true;
            this.cmbbankName.Location = new System.Drawing.Point(90, 14);
            this.cmbbankName.Name = "cmbbankName";
            this.cmbbankName.Size = new System.Drawing.Size(117, 21);
            this.cmbbankName.TabIndex = 340;
            this.cmbbankName.Tag = "Select Bank Name;";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label51.Location = new System.Drawing.Point(427, 17);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(75, 13);
            this.label51.TabIndex = 337;
            this.label51.Text = "Cheque No:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(616, 16);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(87, 13);
            this.lblFromDate.TabIndex = 339;
            this.lblFromDate.Text = "Cheque Date:";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label52.Location = new System.Drawing.Point(23, 18);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(64, 13);
            this.label52.TabIndex = 338;
            this.label52.Text = "Bank(IN):";
            // 
            // dtpchequeDate
            // 
            this.dtpchequeDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpchequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpchequeDate.Location = new System.Drawing.Point(706, 13);
            this.dtpchequeDate.Name = "dtpchequeDate";
            this.dtpchequeDate.Size = new System.Drawing.Size(105, 21);
            this.dtpchequeDate.TabIndex = 335;
            this.dtpchequeDate.TabStop = false;
            this.dtpchequeDate.Tag = "Select cheque date;";
            this.dtpchequeDate.Value = new System.DateTime(2014, 1, 5, 0, 0, 0, 0);
            this.dtpchequeDate.CloseUp += new System.EventHandler(this.dtpchequeDate_CloseUp);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(3, 185);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(65, 13);
            this.label50.TabIndex = 342;
            this.label50.Text = "Narration:";
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cmbMode.Location = new System.Drawing.Point(97, 512);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(347, 21);
            this.cmbMode.TabIndex = 359;
            this.cmbMode.Tag = "Select currency;@";
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // GrpCN
            // 
            this.GrpCN.Controls.Add(this.txtAdjCN);
            this.GrpCN.Controls.Add(this.txtTotalPaidAmount);
            this.GrpCN.Controls.Add(this.label46);
            this.GrpCN.Controls.Add(this.label45);
            this.GrpCN.Controls.Add(this.txtRemainingCN);
            this.GrpCN.Controls.Add(this.label47);
            this.GrpCN.Controls.Add(this.txtCNoutstand);
            this.GrpCN.Controls.Add(this.label49);
            this.GrpCN.Location = new System.Drawing.Point(6, 431);
            this.GrpCN.Name = "GrpCN";
            this.GrpCN.Size = new System.Drawing.Size(441, 74);
            this.GrpCN.TabIndex = 341;
            this.GrpCN.TabStop = false;
            this.GrpCN.Text = "Credit Note Details";
            this.GrpCN.Visible = false;
            // 
            // txtAdjCN
            // 
            this.txtAdjCN.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAdjCN.Location = new System.Drawing.Point(89, 46);
            this.txtAdjCN.MaxLength = 12;
            this.txtAdjCN.Name = "txtAdjCN";
            this.txtAdjCN.Size = new System.Drawing.Size(132, 21);
            this.txtAdjCN.TabIndex = 331;
            this.txtAdjCN.TabStop = false;
            this.txtAdjCN.Tag = "Amount;";
            this.txtAdjCN.Text = "0.00";
            this.txtAdjCN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAdjCN.Leave += new System.EventHandler(this.txtAdjCN_Leave);
            // 
            // txtTotalPaidAmount
            // 
            this.txtTotalPaidAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtTotalPaidAmount.Location = new System.Drawing.Point(306, 46);
            this.txtTotalPaidAmount.MaxLength = 12;
            this.txtTotalPaidAmount.Name = "txtTotalPaidAmount";
            this.txtTotalPaidAmount.ReadOnly = true;
            this.txtTotalPaidAmount.Size = new System.Drawing.Size(130, 21);
            this.txtTotalPaidAmount.TabIndex = 255;
            this.txtTotalPaidAmount.TabStop = false;
            this.txtTotalPaidAmount.Tag = "Amount;";
            this.txtTotalPaidAmount.Text = "0.00";
            this.txtTotalPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPaidAmount.Visible = false;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label46.Location = new System.Drawing.Point(228, 46);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(67, 26);
            this.label46.TabIndex = 256;
            this.label46.Text = "Total Paid \r\nAmount:";
            this.label46.Visible = false;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label45.Location = new System.Drawing.Point(7, 49);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(83, 13);
            this.label45.TabIndex = 254;
            this.label45.Text = "Adj. Amount:";
            // 
            // txtRemainingCN
            // 
            this.txtRemainingCN.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtRemainingCN.Location = new System.Drawing.Point(306, 16);
            this.txtRemainingCN.MaxLength = 12;
            this.txtRemainingCN.Name = "txtRemainingCN";
            this.txtRemainingCN.ReadOnly = true;
            this.txtRemainingCN.Size = new System.Drawing.Size(130, 21);
            this.txtRemainingCN.TabIndex = 251;
            this.txtRemainingCN.TabStop = false;
            this.txtRemainingCN.Tag = "Amount;";
            this.txtRemainingCN.Text = "0.00";
            this.txtRemainingCN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label47.Location = new System.Drawing.Point(228, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(77, 26);
            this.label47.TabIndex = 252;
            this.label47.Text = "Remaining \r\nCredit Note:";
            // 
            // txtCNoutstand
            // 
            this.txtCNoutstand.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCNoutstand.Location = new System.Drawing.Point(89, 17);
            this.txtCNoutstand.MaxLength = 12;
            this.txtCNoutstand.Name = "txtCNoutstand";
            this.txtCNoutstand.ReadOnly = true;
            this.txtCNoutstand.Size = new System.Drawing.Size(132, 21);
            this.txtCNoutstand.TabIndex = 247;
            this.txtCNoutstand.TabStop = false;
            this.txtCNoutstand.Tag = "Amount;";
            this.txtCNoutstand.Text = "0.00";
            this.txtCNoutstand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label49.Location = new System.Drawing.Point(7, 16);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(80, 26);
            this.label49.TabIndex = 248;
            this.label49.Text = "Credit Note \r\nOutstanding:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label48.Location = new System.Drawing.Point(504, 558);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(38, 13);
            this.label48.TabIndex = 340;
            this.label48.Text = "Note:";
            // 
            // cmbAgainstCN
            // 
            this.cmbAgainstCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgainstCN.FormattingEnabled = true;
            this.cmbAgainstCN.Items.AddRange(new object[] {
            "Against Credit Note",
            "Direct Sale"});
            this.cmbAgainstCN.Location = new System.Drawing.Point(547, 549);
            this.cmbAgainstCN.Name = "cmbAgainstCN";
            this.cmbAgainstCN.Size = new System.Drawing.Size(274, 21);
            this.cmbAgainstCN.TabIndex = 338;
            this.cmbAgainstCN.Tag = "Select source of Inquiry;";
            this.cmbAgainstCN.SelectedIndexChanged += new System.EventHandler(this.cmbAgainstCN_SelectedIndexChanged);
            this.cmbAgainstCN.Leave += new System.EventHandler(this.cmbAgainstCN_Leave);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(453, 545);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(92, 13);
            this.label44.TabIndex = 339;
            this.label44.Text = "Against Credit ";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label43.Location = new System.Drawing.Point(529, 521);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 13);
            this.label43.TabIndex = 336;
            this.label43.Text = "SBCess:";
            this.label43.Visible = false;
            // 
            // txtSBCessAmount
            // 
            this.txtSBCessAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSBCessAmount.Location = new System.Drawing.Point(588, 528);
            this.txtSBCessAmount.MaxLength = 12;
            this.txtSBCessAmount.Name = "txtSBCessAmount";
            this.txtSBCessAmount.ReadOnly = true;
            this.txtSBCessAmount.Size = new System.Drawing.Size(94, 21);
            this.txtSBCessAmount.TabIndex = 28;
            this.txtSBCessAmount.TabStop = false;
            this.txtSBCessAmount.Tag = "VAT amount;";
            this.txtSBCessAmount.Text = "0.00";
            this.txtSBCessAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSBCessAmount.Visible = false;
            // 
            // lblExtraTax
            // 
            this.lblExtraTax.AutoSize = true;
            this.lblExtraTax.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblExtraTax.Location = new System.Drawing.Point(694, 521);
            this.lblExtraTax.Name = "lblExtraTax";
            this.lblExtraTax.Size = new System.Drawing.Size(37, 13);
            this.lblExtraTax.TabIndex = 337;
            this.lblExtraTax.Text = "Extra";
            this.lblExtraTax.Visible = false;
            // 
            // txtExtraTax
            // 
            this.txtExtraTax.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtExtraTax.Location = new System.Drawing.Point(734, 528);
            this.txtExtraTax.MaxLength = 12;
            this.txtExtraTax.Name = "txtExtraTax";
            this.txtExtraTax.ReadOnly = true;
            this.txtExtraTax.Size = new System.Drawing.Size(82, 21);
            this.txtExtraTax.TabIndex = 29;
            this.txtExtraTax.TabStop = false;
            this.txtExtraTax.Tag = "Avat amount;";
            this.txtExtraTax.Text = "0.00";
            this.txtExtraTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtraTax.Visible = false;
            // 
            // txtChallanNo
            // 
            this.txtChallanNo.Location = new System.Drawing.Point(652, 17);
            this.txtChallanNo.MaxLength = 500;
            this.txtChallanNo.Name = "txtChallanNo";
            this.txtChallanNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChallanNo.Size = new System.Drawing.Size(170, 21);
            this.txtChallanNo.TabIndex = 5;
            this.txtChallanNo.Tag = "Enter Extra Chrages Type;";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label40.Location = new System.Drawing.Point(576, 19);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(70, 13);
            this.label40.TabIndex = 326;
            this.label40.Text = "ChallanNo:";
            // 
            // btnContactPerson
            // 
            this.btnContactPerson.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnContactPerson.Location = new System.Drawing.Point(331, 94);
            this.btnContactPerson.Name = "btnContactPerson";
            this.btnContactPerson.Size = new System.Drawing.Size(119, 23);
            this.btnContactPerson.TabIndex = 12;
            this.btnContactPerson.Tag = "Click to show and add contact person;";
            this.btnContactPerson.Text = "Contact Person";
            this.btnContactPerson.UseVisualStyleBackColor = true;
            this.btnContactPerson.Visible = false;
            this.btnContactPerson.Click += new System.EventHandler(this.btnContactPerson_Click);
            // 
            // txtDicAmt
            // 
            this.txtDicAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtDicAmt.Location = new System.Drawing.Point(554, 277);
            this.txtDicAmt.MaxLength = 15;
            this.txtDicAmt.Name = "txtDicAmt";
            this.txtDicAmt.ReadOnly = true;
            this.txtDicAmt.Size = new System.Drawing.Size(267, 21);
            this.txtDicAmt.TabIndex = 30;
            this.txtDicAmt.Tag = "Enter discount;";
            this.txtDicAmt.Text = "0.00";
            this.txtDicAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.txtNetAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtNetAmount.Location = new System.Drawing.Point(555, 375);
            this.txtNetAmount.MaxLength = 15;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(268, 21);
            this.txtNetAmount.TabIndex = 37;
            this.txtNetAmount.Tag = "Net amount;";
            this.txtNetAmount.Text = "0.00";
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNetAmt
            // 
            this.lblNetAmt.AutoSize = true;
            this.lblNetAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblNetAmt.Location = new System.Drawing.Point(468, 378);
            this.lblNetAmt.Name = "lblNetAmt";
            this.lblNetAmt.Size = new System.Drawing.Size(79, 13);
            this.lblNetAmt.TabIndex = 262;
            this.lblNetAmt.Text = "Net Amount:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtRec);
            this.panel2.Controls.Add(this.lblQty);
            this.panel2.Controls.Add(this.txtDuedays);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(265, 584);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 23);
            this.panel2.TabIndex = 225;
            this.panel2.Tag = "Select next followup date;";
            // 
            // txtRec
            // 
            this.txtRec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRec.Location = new System.Drawing.Point(205, 0);
            this.txtRec.MaxLength = 18;
            this.txtRec.Name = "txtRec";
            this.txtRec.Size = new System.Drawing.Size(61, 21);
            this.txtRec.TabIndex = 1;
            this.txtRec.Tag = "Enter Rec. days;";
            this.txtRec.Text = "0";
            this.txtRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(6, 3);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(68, 13);
            this.lblQty.TabIndex = 240;
            this.lblQty.Text = "Due Days:";
            // 
            // txtDuedays
            // 
            this.txtDuedays.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuedays.Location = new System.Drawing.Point(73, 0);
            this.txtDuedays.MaxLength = 18;
            this.txtDuedays.Name = "txtDuedays";
            this.txtDuedays.Size = new System.Drawing.Size(61, 21);
            this.txtDuedays.TabIndex = 0;
            this.txtDuedays.Tag = "Enter due days;";
            this.txtDuedays.Text = "0";
            this.txtDuedays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDuedays.Click += new System.EventHandler(this.txtDuedays_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(135, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 13);
            this.label23.TabIndex = 289;
            this.label23.Text = "Rec. Day:";
            // 
            // btnDis
            // 
            this.btnDis.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDis.Location = new System.Drawing.Point(546, 584);
            this.btnDis.Name = "btnDis";
            this.btnDis.Size = new System.Drawing.Size(276, 23);
            this.btnDis.TabIndex = 41;
            this.btnDis.Tag = "Click to Enter Dispatch Details.;";
            this.btnDis.Text = "Dispatch Details";
            this.btnDis.UseVisualStyleBackColor = true;
            this.btnDis.Click += new System.EventHandler(this.btnDis_Click);
            // 
            // txtCustInvoiceNo
            // 
            this.txtCustInvoiceNo.Location = new System.Drawing.Point(265, 40);
            this.txtCustInvoiceNo.MaxLength = 500;
            this.txtCustInvoiceNo.Name = "txtCustInvoiceNo";
            this.txtCustInvoiceNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustInvoiceNo.Size = new System.Drawing.Size(184, 21);
            this.txtCustInvoiceNo.TabIndex = 4;
            this.txtCustInvoiceNo.Tag = "Enter Extra Chrages Type;";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label39.Location = new System.Drawing.Point(226, 34);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(33, 13);
            this.label39.TabIndex = 322;
            this.label39.Text = "Your";
            this.label39.Click += new System.EventHandler(this.label39_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label33.Location = new System.Drawing.Point(512, 482);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(75, 13);
            this.label33.TabIndex = 320;
            this.label33.Text = "with Excise:";
            this.label33.Visible = false;
            // 
            // grpItemDetail
            // 
            this.grpItemDetail.Controls.Add(this.dgvPIDetail);
            this.grpItemDetail.Controls.Add(this.btnDelete);
            this.grpItemDetail.Controls.Add(this.btnNew);
            this.grpItemDetail.Controls.Add(this.btnedit);
            this.grpItemDetail.Controls.Add(this.label41);
            this.grpItemDetail.Controls.Add(this.cmbCurrency);
            this.grpItemDetail.Controls.Add(this.label42);
            this.grpItemDetail.Location = new System.Drawing.Point(6, 210);
            this.grpItemDetail.Name = "grpItemDetail";
            this.grpItemDetail.Size = new System.Drawing.Size(444, 220);
            this.grpItemDetail.TabIndex = 19;
            this.grpItemDetail.TabStop = false;
            this.grpItemDetail.Text = "Item";
            // 
            // dgvPIDetail
            // 
            this.dgvPIDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPIDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GodownID,
            this.ItemID,
            this.ItemName,
            this.ItemDesc,
            this.Qty,
            this.UOM,
            this.Rate,
            this.CurrencyID,
            this.SGSTAmount,
            this.CGSTAmount,
            this.IGSTAmount,
            this.Currency,
            this.TotalAmount,
            this.TaxClassID,
            this.ServiceAmount,
            this.ExciseAmount,
            this.ECessAmount,
            this.HECessAmount,
            this.AmountAfterExcise,
            this.CSTAmount,
            this.VATAmount,
            this.AVATAmount,
            this.SBCessAmount,
            this.ExtraTaxAmount,
            this.NetAmount,
            this.Discount,
            this.DiscountAmt});
            this.dgvPIDetail.Location = new System.Drawing.Point(6, 42);
            this.dgvPIDetail.Name = "dgvPIDetail";
            this.dgvPIDetail.RowTemplate.Height = 24;
            this.dgvPIDetail.Size = new System.Drawing.Size(432, 147);
            this.dgvPIDetail.TabIndex = 4;
            this.dgvPIDetail.Tag = "List of pi detail;";
            // 
            // GodownID
            // 
            this.GodownID.HeaderText = "GodownID";
            this.GodownID.Name = "GodownID";
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item";
            this.ItemName.Name = "ItemName";
            // 
            // ItemDesc
            // 
            this.ItemDesc.HeaderText = "Item Desc";
            this.ItemDesc.Name = "ItemDesc";
            // 
            // Qty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle1;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            // 
            // Rate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.00";
            this.Rate.DefaultCellStyle = dataGridViewCellStyle2;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // CurrencyID
            // 
            this.CurrencyID.HeaderText = "CurrencyID";
            this.CurrencyID.Name = "CurrencyID";
            this.CurrencyID.Visible = false;
            // 
            // SGSTAmount
            // 
            this.SGSTAmount.HeaderText = "SGSTAmount";
            this.SGSTAmount.Name = "SGSTAmount";
            // 
            // CGSTAmount
            // 
            this.CGSTAmount.HeaderText = "CGSTAmount";
            this.CGSTAmount.Name = "CGSTAmount";
            // 
            // IGSTAmount
            // 
            this.IGSTAmount.HeaderText = "IGSTAmount";
            this.IGSTAmount.Name = "IGSTAmount";
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            // 
            // TotalAmount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.TotalAmount.HeaderText = "Amount";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // TaxClassID
            // 
            this.TaxClassID.HeaderText = "TaxClassID";
            this.TaxClassID.Name = "TaxClassID";
            this.TaxClassID.Visible = false;
            // 
            // ServiceAmount
            // 
            this.ServiceAmount.HeaderText = "Service Amount";
            this.ServiceAmount.Name = "ServiceAmount";
            this.ServiceAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ServiceAmount.Visible = false;
            // 
            // ExciseAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ExciseAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ExciseAmount.HeaderText = "Excise Amount";
            this.ExciseAmount.Name = "ExciseAmount";
            this.ExciseAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExciseAmount.Visible = false;
            // 
            // ECessAmount
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ECessAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ECessAmount.HeaderText = "ECess Amount";
            this.ECessAmount.Name = "ECessAmount";
            this.ECessAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ECessAmount.Visible = false;
            // 
            // HECessAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HECessAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.HECessAmount.HeaderText = "HECess Amount";
            this.HECessAmount.Name = "HECessAmount";
            this.HECessAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HECessAmount.Visible = false;
            // 
            // AmountAfterExcise
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AmountAfterExcise.DefaultCellStyle = dataGridViewCellStyle7;
            this.AmountAfterExcise.HeaderText = "Amount after Excise";
            this.AmountAfterExcise.Name = "AmountAfterExcise";
            this.AmountAfterExcise.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AmountAfterExcise.Visible = false;
            // 
            // CSTAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CSTAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.CSTAmount.HeaderText = "CST Amount";
            this.CSTAmount.Name = "CSTAmount";
            this.CSTAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CSTAmount.Visible = false;
            // 
            // VATAmount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VATAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.VATAmount.HeaderText = "VAT Amount";
            this.VATAmount.Name = "VATAmount";
            this.VATAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.VATAmount.Visible = false;
            // 
            // AVATAmount
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AVATAmount.DefaultCellStyle = dataGridViewCellStyle10;
            this.AVATAmount.HeaderText = "AVAT Amount";
            this.AVATAmount.Name = "AVATAmount";
            this.AVATAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AVATAmount.Visible = false;
            // 
            // SBCessAmount
            // 
            this.SBCessAmount.HeaderText = "SBCessAmount";
            this.SBCessAmount.Name = "SBCessAmount";
            this.SBCessAmount.Visible = false;
            // 
            // ExtraTaxAmount
            // 
            this.ExtraTaxAmount.HeaderText = "ExtraTaxAmount";
            this.ExtraTaxAmount.Name = "ExtraTaxAmount";
            this.ExtraTaxAmount.Visible = false;
            // 
            // NetAmount
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "#0.00";
            this.NetAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            // 
            // DiscountAmt
            // 
            this.DiscountAmt.HeaderText = "DiscountAmt";
            this.DiscountAmt.Name = "DiscountAmt";
            this.DiscountAmt.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(306, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Tag = "Click to delete selected item;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(42, 14);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(126, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Tag = "Click to add item;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnedit
            // 
            this.btnedit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnedit.Location = new System.Drawing.Point(174, 13);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(126, 23);
            this.btnedit.TabIndex = 2;
            this.btnedit.Tag = "Click to add item;";
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label41.Location = new System.Drawing.Point(-3, 41);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(65, 13);
            this.label41.TabIndex = 304;
            this.label41.Text = "Currency:";
            this.label41.Visible = false;
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(66, 50);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(102, 21);
            this.cmbCurrency.TabIndex = 303;
            this.cmbCurrency.Tag = "Select currency;@";
            this.cmbCurrency.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.ForeColor = System.Drawing.Color.Red;
            this.label42.Location = new System.Drawing.Point(174, 41);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(15, 13);
            this.label42.TabIndex = 305;
            this.label42.Text = "*";
            this.label42.Visible = false;
            // 
            // txtECType3
            // 
            this.txtECType3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtECType3.Location = new System.Drawing.Point(555, 350);
            this.txtECType3.MaxLength = 500;
            this.txtECType3.Name = "txtECType3";
            this.txtECType3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtECType3.Size = new System.Drawing.Size(108, 20);
            this.txtECType3.TabIndex = 35;
            this.txtECType3.Tag = "Enter Extra Chrages Type3;";
            this.txtECType3.Text = "Courier Charges";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label35.Location = new System.Drawing.Point(498, 353);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(47, 13);
            this.label35.TabIndex = 318;
            this.label35.Text = "Type3:";
            // 
            // txtextracharges3
            // 
            this.txtextracharges3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtextracharges3.Location = new System.Drawing.Point(718, 350);
            this.txtextracharges3.MaxLength = 15;
            this.txtextracharges3.Name = "txtextracharges3";
            this.txtextracharges3.Size = new System.Drawing.Size(103, 21);
            this.txtextracharges3.TabIndex = 36;
            this.txtextracharges3.Tag = "Extra Charges;";
            this.txtextracharges3.Text = "0.00";
            this.txtextracharges3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtextracharges3.Leave += new System.EventHandler(this.txtextracharges3_Leave);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label37.Location = new System.Drawing.Point(674, 353);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(35, 13);
            this.label37.TabIndex = 316;
            this.label37.Text = "Amt:";
            // 
            // txtECType2
            // 
            this.txtECType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtECType2.Location = new System.Drawing.Point(555, 324);
            this.txtECType2.MaxLength = 500;
            this.txtECType2.Name = "txtECType2";
            this.txtECType2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtECType2.Size = new System.Drawing.Size(108, 20);
            this.txtECType2.TabIndex = 33;
            this.txtECType2.Tag = "Enter Extra Chrages Type2;";
            this.txtECType2.Text = "Transport Charges";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label32.Location = new System.Drawing.Point(498, 327);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(47, 13);
            this.label32.TabIndex = 313;
            this.label32.Text = "Type2:";
            // 
            // txtextracharges2
            // 
            this.txtextracharges2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtextracharges2.Location = new System.Drawing.Point(718, 324);
            this.txtextracharges2.MaxLength = 15;
            this.txtextracharges2.Name = "txtextracharges2";
            this.txtextracharges2.Size = new System.Drawing.Size(103, 21);
            this.txtextracharges2.TabIndex = 34;
            this.txtextracharges2.Tag = "Extra Charges;";
            this.txtextracharges2.Text = "0.00";
            this.txtextracharges2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtextracharges2.Leave += new System.EventHandler(this.txtextracharges2_Leave);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label34.Location = new System.Drawing.Point(674, 327);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(35, 13);
            this.label34.TabIndex = 311;
            this.label34.Text = "Amt:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label31.Location = new System.Drawing.Point(693, 511);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 13);
            this.label31.TabIndex = 308;
            this.label31.Text = "VAT:";
            this.label31.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label30.Location = new System.Drawing.Point(690, 455);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 13);
            this.label30.TabIndex = 307;
            this.label30.Text = "Cess:";
            this.label30.Visible = false;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "--Select--",
            "Hot",
            "Warm",
            "Cold",
            "INPROGRESS",
            "QUOTATION",
            "SALE"});
            this.cmbStatus.Location = new System.Drawing.Point(555, 154);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(267, 21);
            this.cmbStatus.TabIndex = 16;
            this.cmbStatus.Tag = "Select interest level;";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(499, 157);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 306;
            this.label28.Text = "Status:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "New Paper Advertise",
            "Hoarding",
            "Radio Adversie",
            "Website",
            "Exhibition",
            "Inter Net Advertise",
            "Reference",
            "Other"});
            this.cmbCategory.Location = new System.Drawing.Point(554, 100);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(267, 21);
            this.cmbCategory.TabIndex = 10;
            this.cmbCategory.Tag = "Select source of Inquiry;";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(482, 103);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 13);
            this.label29.TabIndex = 303;
            this.label29.Text = "Category:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(464, 72);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(83, 13);
            this.label27.TabIndex = 302;
            this.label27.Text = "Allocated to :";
            // 
            // cmbEmpAllocatedTo
            // 
            this.cmbEmpAllocatedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpAllocatedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpAllocatedTo.FormattingEnabled = true;
            this.cmbEmpAllocatedTo.Location = new System.Drawing.Point(554, 70);
            this.cmbEmpAllocatedTo.Name = "cmbEmpAllocatedTo";
            this.cmbEmpAllocatedTo.Size = new System.Drawing.Size(267, 21);
            this.cmbEmpAllocatedTo.TabIndex = 9;
            this.cmbEmpAllocatedTo.Tag = "Select Employee Name;";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(459, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 13);
            this.label13.TabIndex = 300;
            this.label13.Text = "App taken By:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(6, 180);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 13);
            this.label25.TabIndex = 297;
            this.label25.Text = "Shipping";
            this.label25.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(5, 194);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 13);
            this.label26.TabIndex = 298;
            this.label26.Text = "Address:";
            this.label26.Visible = false;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "--Select--",
            "Retail",
            "Tax",
            "Estimate"});
            this.cmbType.Location = new System.Drawing.Point(71, 15);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(110, 21);
            this.cmbType.TabIndex = 0;
            this.cmbType.Tag = "Select Invoice Type;";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label24.Location = new System.Drawing.Point(25, 20);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 13);
            this.label24.TabIndex = 295;
            this.label24.Text = "Type:";
            // 
            // btnTNC
            // 
            this.btnTNC.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnTNC.Location = new System.Drawing.Point(7, 584);
            this.btnTNC.Name = "btnTNC";
            this.btnTNC.Size = new System.Drawing.Size(172, 23);
            this.btnTNC.TabIndex = 39;
            this.btnTNC.Tag = "Click to edit Terms & Conditions;";
            this.btnTNC.Text = "Edit Terms && Conditions";
            this.btnTNC.UseVisualStyleBackColor = true;
            this.btnTNC.Click += new System.EventHandler(this.btnTNC_Click);
            // 
            // txtextrachargestype
            // 
            this.txtextrachargestype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtextrachargestype.Location = new System.Drawing.Point(555, 302);
            this.txtextrachargestype.MaxLength = 500;
            this.txtextrachargestype.Name = "txtextrachargestype";
            this.txtextrachargestype.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtextrachargestype.Size = new System.Drawing.Size(108, 20);
            this.txtextrachargestype.TabIndex = 31;
            this.txtextrachargestype.Tag = "Enter Extra Chrages Type1;";
            this.txtextrachargestype.Text = "P & F Charges";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label21.Location = new System.Drawing.Point(498, 313);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 13);
            this.label21.TabIndex = 285;
            this.label21.Text = "Type1:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label20.Location = new System.Drawing.Point(456, 300);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 13);
            this.label20.TabIndex = 284;
            this.label20.Text = "Extra Charges";
            // 
            // txtextracharges
            // 
            this.txtextracharges.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtextracharges.Location = new System.Drawing.Point(718, 300);
            this.txtextracharges.MaxLength = 15;
            this.txtextracharges.Name = "txtextracharges";
            this.txtextracharges.Size = new System.Drawing.Size(103, 21);
            this.txtextracharges.TabIndex = 32;
            this.txtextracharges.Tag = "Extra Charges;";
            this.txtextracharges.Text = "0.00";
            this.txtextracharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtextracharges.Leave += new System.EventHandler(this.txtextracharges_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label12.Location = new System.Drawing.Point(674, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 283;
            this.label12.Text = "Amt:";
            // 
            // chkTNC
            // 
            this.chkTNC.AutoSize = true;
            this.chkTNC.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTNC.Location = new System.Drawing.Point(185, 588);
            this.chkTNC.Name = "chkTNC";
            this.chkTNC.Size = new System.Drawing.Size(73, 17);
            this.chkTNC.TabIndex = 40;
            this.chkTNC.Tag = "Send Email;";
            this.chkTNC.Text = "All T&&C";
            this.chkTNC.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(14, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 278;
            this.label11.Text = "Person:";
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(71, 182);
            this.txtNarration.MaxLength = 4000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNarration.Size = new System.Drawing.Size(378, 27);
            this.txtNarration.TabIndex = 17;
            this.txtNarration.Tag = "Enter narration;";
            this.txtNarration.Click += new System.EventHandler(this.txtNarration_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(25, 157);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 274;
            this.label17.Text = "Email:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(480, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 273;
            this.label16.Text = "Mobile No:";
            // 
            // txtmobile
            // 
            this.txtmobile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobile.Location = new System.Drawing.Point(554, 127);
            this.txtmobile.MaxLength = 100;
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.ReadOnly = true;
            this.txtmobile.Size = new System.Drawing.Size(267, 21);
            this.txtmobile.TabIndex = 14;
            this.txtmobile.Tag = "Enter customer;";
            // 
            // txtcontactperson
            // 
            this.txtcontactperson.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontactperson.Location = new System.Drawing.Point(72, 96);
            this.txtcontactperson.MaxLength = 100;
            this.txtcontactperson.Name = "txtcontactperson";
            this.txtcontactperson.ReadOnly = true;
            this.txtcontactperson.Size = new System.Drawing.Size(253, 21);
            this.txtcontactperson.TabIndex = 11;
            this.txtcontactperson.Tag = "Enter contactperson;";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(14, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 13);
            this.label15.TabIndex = 270;
            this.label15.Text = "Contact";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 269;
            this.label5.Text = "Address:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(72, 127);
            this.txtAddress1.MaxLength = 100;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ReadOnly = true;
            this.txtAddress1.Size = new System.Drawing.Size(378, 21);
            this.txtAddress1.TabIndex = 13;
            this.txtAddress1.Tag = "Enter customer;";
            // 
            // cmbAttendedBy
            // 
            this.cmbAttendedBy.FormattingEnabled = true;
            this.cmbAttendedBy.Location = new System.Drawing.Point(554, 43);
            this.cmbAttendedBy.Name = "cmbAttendedBy";
            this.cmbAttendedBy.Size = new System.Drawing.Size(267, 21);
            this.cmbAttendedBy.TabIndex = 6;
            this.cmbAttendedBy.Tag = "Select Attended By;";
            this.cmbAttendedBy.SelectedIndexChanged += new System.EventHandler(this.cmbAttendedBy_SelectedIndexChanged);
            // 
            // txtemail
            // 
            this.txtemail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtemail.Location = new System.Drawing.Point(71, 154);
            this.txtemail.Name = "txtemail";
            this.txtemail.ReadOnly = true;
            this.txtemail.Size = new System.Drawing.Size(378, 21);
            this.txtemail.TabIndex = 15;
            this.txtemail.Tag = "Enter Email;";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label6.Location = new System.Drawing.Point(507, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 264;
            this.label6.Text = "Service Tax:";
            this.label6.Visible = false;
            // 
            // txtServiceAmt
            // 
            this.txtServiceAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtServiceAmt.Location = new System.Drawing.Point(589, 420);
            this.txtServiceAmt.MaxLength = 12;
            this.txtServiceAmt.Name = "txtServiceAmt";
            this.txtServiceAmt.ReadOnly = true;
            this.txtServiceAmt.Size = new System.Drawing.Size(94, 21);
            this.txtServiceAmt.TabIndex = 20;
            this.txtServiceAmt.TabStop = false;
            this.txtServiceAmt.Tag = "Service Tax amount;";
            this.txtServiceAmt.Text = "0.00";
            this.txtServiceAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceAmt.Visible = false;
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPaidAmount.Location = new System.Drawing.Point(554, 397);
            this.txtPaidAmount.MaxLength = 15;
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(268, 21);
            this.txtPaidAmount.TabIndex = 38;
            this.txtPaidAmount.Tag = "Paid amount;";
            this.txtPaidAmount.Text = "0.00";
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaidAmount.Leave += new System.EventHandler(this.txtPaidAmount_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(461, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 263;
            this.label3.Text = "Paid Amount:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(72, 68);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(253, 21);
            this.txtCustomer.TabIndex = 7;
            this.txtCustomer.Tag = "Enter Customer;@";
            this.txtCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomer_KeyUp);
            this.txtCustomer.Leave += new System.EventHandler(this.txtCustomer_Leave);
            // 
            // dtpPIDate
            // 
            this.dtpPIDate.CustomFormat = "";
            this.dtpPIDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpPIDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPIDate.Location = new System.Drawing.Point(71, 41);
            this.dtpPIDate.Name = "dtpPIDate";
            this.dtpPIDate.Size = new System.Drawing.Size(110, 21);
            this.dtpPIDate.TabIndex = 3;
            this.dtpPIDate.Tag = "Select sales invoice date;";
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblVAT.Location = new System.Drawing.Point(550, 504);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(35, 13);
            this.lblVAT.TabIndex = 259;
            this.lblVAT.Text = "VAT:";
            this.lblVAT.Visible = false;
            // 
            // txtVATAmt
            // 
            this.txtVATAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtVATAmt.Location = new System.Drawing.Point(589, 501);
            this.txtVATAmt.MaxLength = 12;
            this.txtVATAmt.Name = "txtVATAmt";
            this.txtVATAmt.ReadOnly = true;
            this.txtVATAmt.Size = new System.Drawing.Size(94, 21);
            this.txtVATAmt.TabIndex = 26;
            this.txtVATAmt.TabStop = false;
            this.txtVATAmt.Tag = "VAT amount;";
            this.txtVATAmt.Text = "0.00";
            this.txtVATAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVATAmt.Visible = false;
            // 
            // lblAVAT
            // 
            this.lblAVAT.AutoSize = true;
            this.lblAVAT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAVAT.Location = new System.Drawing.Point(698, 500);
            this.lblAVAT.Name = "lblAVAT";
            this.lblAVAT.Size = new System.Drawing.Size(33, 13);
            this.lblAVAT.TabIndex = 260;
            this.lblAVAT.Text = "Add.";
            this.lblAVAT.Visible = false;
            // 
            // txtAVATAmt
            // 
            this.txtAVATAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAVATAmt.Location = new System.Drawing.Point(734, 501);
            this.txtAVATAmt.MaxLength = 12;
            this.txtAVATAmt.Name = "txtAVATAmt";
            this.txtAVATAmt.ReadOnly = true;
            this.txtAVATAmt.Size = new System.Drawing.Size(82, 21);
            this.txtAVATAmt.TabIndex = 27;
            this.txtAVATAmt.TabStop = false;
            this.txtAVATAmt.Tag = "Avat amount;";
            this.txtAVATAmt.Text = "0.00";
            this.txtAVATAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAVATAmt.Visible = false;
            // 
            // lblCST
            // 
            this.lblCST.AutoSize = true;
            this.lblCST.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCST.Location = new System.Drawing.Point(694, 477);
            this.lblCST.Name = "lblCST";
            this.lblCST.Size = new System.Drawing.Size(36, 13);
            this.lblCST.TabIndex = 258;
            this.lblCST.Text = "CST:";
            this.lblCST.Visible = false;
            // 
            // txtCSTAmt
            // 
            this.txtCSTAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCSTAmt.Location = new System.Drawing.Point(734, 474);
            this.txtCSTAmt.MaxLength = 12;
            this.txtCSTAmt.Name = "txtCSTAmt";
            this.txtCSTAmt.ReadOnly = true;
            this.txtCSTAmt.Size = new System.Drawing.Size(82, 21);
            this.txtCSTAmt.TabIndex = 25;
            this.txtCSTAmt.TabStop = false;
            this.txtCSTAmt.Tag = "CST amount;";
            this.txtCSTAmt.Text = "0.00";
            this.txtCSTAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCSTAmt.Visible = false;
            // 
            // lblExcise
            // 
            this.lblExcise.AutoSize = true;
            this.lblExcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblExcise.Location = new System.Drawing.Point(683, 423);
            this.lblExcise.Name = "lblExcise";
            this.lblExcise.Size = new System.Drawing.Size(48, 13);
            this.lblExcise.TabIndex = 248;
            this.lblExcise.Text = "Excise:";
            this.lblExcise.Visible = false;
            // 
            // txtExciseAmt
            // 
            this.txtExciseAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtExciseAmt.Location = new System.Drawing.Point(734, 420);
            this.txtExciseAmt.MaxLength = 12;
            this.txtExciseAmt.Name = "txtExciseAmt";
            this.txtExciseAmt.ReadOnly = true;
            this.txtExciseAmt.Size = new System.Drawing.Size(82, 21);
            this.txtExciseAmt.TabIndex = 21;
            this.txtExciseAmt.TabStop = false;
            this.txtExciseAmt.Tag = "Excise amount;";
            this.txtExciseAmt.Text = "0.00";
            this.txtExciseAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExciseAmt.Visible = false;
            // 
            // lblEduCess
            // 
            this.lblEduCess.AutoSize = true;
            this.lblEduCess.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEduCess.Location = new System.Drawing.Point(516, 450);
            this.lblEduCess.Name = "lblEduCess";
            this.lblEduCess.Size = new System.Drawing.Size(69, 13);
            this.lblEduCess.TabIndex = 250;
            this.lblEduCess.Text = "Edu. Cess:";
            this.lblEduCess.Visible = false;
            // 
            // lblHEduCess
            // 
            this.lblHEduCess.AutoSize = true;
            this.lblHEduCess.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblHEduCess.Location = new System.Drawing.Point(689, 442);
            this.lblHEduCess.Name = "lblHEduCess";
            this.lblHEduCess.Size = new System.Drawing.Size(40, 13);
            this.lblHEduCess.TabIndex = 254;
            this.lblHEduCess.Text = "HEdu.";
            this.lblHEduCess.Visible = false;
            // 
            // lblAmtwithexcise
            // 
            this.lblAmtwithexcise.AutoSize = true;
            this.lblAmtwithexcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAmtwithexcise.Location = new System.Drawing.Point(548, 469);
            this.lblAmtwithexcise.Name = "lblAmtwithexcise";
            this.lblAmtwithexcise.Size = new System.Drawing.Size(34, 13);
            this.lblAmtwithexcise.TabIndex = 256;
            this.lblAmtwithexcise.Text = "Amt.";
            this.lblAmtwithexcise.Visible = false;
            // 
            // txtAmtwithExcise
            // 
            this.txtAmtwithExcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmtwithExcise.Location = new System.Drawing.Point(589, 474);
            this.txtAmtwithExcise.MaxLength = 12;
            this.txtAmtwithExcise.Name = "txtAmtwithExcise";
            this.txtAmtwithExcise.ReadOnly = true;
            this.txtAmtwithExcise.Size = new System.Drawing.Size(94, 21);
            this.txtAmtwithExcise.TabIndex = 24;
            this.txtAmtwithExcise.TabStop = false;
            this.txtAmtwithExcise.Tag = "Amount with excise;";
            this.txtAmtwithExcise.Text = "0.00";
            this.txtAmtwithExcise.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmtwithExcise.Visible = false;
            // 
            // txtHEduCessAmt
            // 
            this.txtHEduCessAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtHEduCessAmt.Location = new System.Drawing.Point(734, 447);
            this.txtHEduCessAmt.MaxLength = 12;
            this.txtHEduCessAmt.Name = "txtHEduCessAmt";
            this.txtHEduCessAmt.ReadOnly = true;
            this.txtHEduCessAmt.Size = new System.Drawing.Size(82, 21);
            this.txtHEduCessAmt.TabIndex = 23;
            this.txtHEduCessAmt.TabStop = false;
            this.txtHEduCessAmt.Tag = "Hedu. cess amount;";
            this.txtHEduCessAmt.Text = "0.00";
            this.txtHEduCessAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHEduCessAmt.Visible = false;
            // 
            // txtEduCessAmt
            // 
            this.txtEduCessAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtEduCessAmt.Location = new System.Drawing.Point(588, 447);
            this.txtEduCessAmt.MaxLength = 12;
            this.txtEduCessAmt.Name = "txtEduCessAmt";
            this.txtEduCessAmt.ReadOnly = true;
            this.txtEduCessAmt.Size = new System.Drawing.Size(94, 21);
            this.txtEduCessAmt.TabIndex = 22;
            this.txtEduCessAmt.TabStop = false;
            this.txtEduCessAmt.Tag = "Edu. cess amount;";
            this.txtEduCessAmt.Text = "0.00";
            this.txtEduCessAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEduCessAmt.Visible = false;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(554, 180);
            this.txtAmount.MaxLength = 12;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(267, 21);
            this.txtAmount.TabIndex = 18;
            this.txtAmount.TabStop = false;
            this.txtAmount.Tag = "Amount;";
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAmount.Location = new System.Drawing.Point(492, 185);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(56, 13);
            this.lblAmount.TabIndex = 244;
            this.lblAmount.Text = "Amount:";
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(348, 10);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(33, 23);
            this.btnRegenrate.TabIndex = 2;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate pi no;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // txtPINo
            // 
            this.txtPINo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPINo.Location = new System.Drawing.Point(223, 11);
            this.txtPINo.MaxLength = 20;
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.ReadOnly = true;
            this.txtPINo.Size = new System.Drawing.Size(117, 21);
            this.txtPINo.TabIndex = 1;
            this.txtPINo.TabStop = false;
            this.txtPINo.Tag = "SI no;@";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblOrderNo.Location = new System.Drawing.Point(190, 16);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(27, 13);
            this.lblOrderNo.TabIndex = 225;
            this.lblOrderNo.Text = "No:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblOrderDate.Location = new System.Drawing.Point(29, 44);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(39, 13);
            this.lblOrderDate.TabIndex = 231;
            this.lblOrderDate.Text = "Date:";
            // 
            // btnCustomerLOV
            // 
            this.btnCustomerLOV.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCustomerLOV.Location = new System.Drawing.Point(331, 67);
            this.btnCustomerLOV.Name = "btnCustomerLOV";
            this.btnCustomerLOV.Size = new System.Drawing.Size(119, 23);
            this.btnCustomerLOV.TabIndex = 8;
            this.btnCustomerLOV.Tag = "Click to select Customer;";
            this.btnCustomerLOV.Text = "SELECT";
            this.btnCustomerLOV.UseVisualStyleBackColor = true;
            this.btnCustomerLOV.Click += new System.EventHandler(this.btnItemLOV_Click);
            // 
            // Errcustname
            // 
            this.Errcustname.AutoSize = true;
            this.Errcustname.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Errcustname.ForeColor = System.Drawing.Color.Red;
            this.Errcustname.Location = new System.Drawing.Point(57, 62);
            this.Errcustname.Name = "Errcustname";
            this.Errcustname.Size = new System.Drawing.Size(14, 13);
            this.Errcustname.TabIndex = 234;
            this.Errcustname.Text = "*";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.Black;
            this.lblCustomer.Location = new System.Drawing.Point(3, 70);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(68, 13);
            this.lblCustomer.TabIndex = 233;
            this.lblCustomer.Text = "Customer:";
            // 
            // ErrOrderNo
            // 
            this.ErrOrderNo.AutoSize = true;
            this.ErrOrderNo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrOrderNo.ForeColor = System.Drawing.Color.Red;
            this.ErrOrderNo.Location = new System.Drawing.Point(54, 35);
            this.ErrOrderNo.Name = "ErrOrderNo";
            this.ErrOrderNo.Size = new System.Drawing.Size(14, 13);
            this.ErrOrderNo.TabIndex = 1;
            this.ErrOrderNo.Text = "*";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtDiscount.Location = new System.Drawing.Point(554, 277);
            this.txtDiscount.MaxLength = 15;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(268, 21);
            this.txtDiscount.TabIndex = 26;
            this.txtDiscount.Tag = "Enter discount;";
            this.txtDiscount.Text = "0.00";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(484, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 261;
            this.label4.Text = "Discount:";
            // 
            // cmbgodown
            // 
            this.cmbgodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgodown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgodown.FormattingEnabled = true;
            this.cmbgodown.Location = new System.Drawing.Point(89, 220);
            this.cmbgodown.Name = "cmbgodown";
            this.cmbgodown.Size = new System.Drawing.Size(110, 21);
            this.cmbgodown.TabIndex = 0;
            this.cmbgodown.Tag = "Select Godown Name;@";
            this.cmbgodown.Visible = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(25, 224);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(62, 13);
            this.lblCity.TabIndex = 300;
            this.lblCity.Text = "Godown :";
            this.lblCity.Visible = false;
            // 
            // Errlabel7
            // 
            this.Errlabel7.AutoSize = true;
            this.Errlabel7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Errlabel7.ForeColor = System.Drawing.Color.Red;
            this.Errlabel7.Location = new System.Drawing.Point(199, 216);
            this.Errlabel7.Name = "Errlabel7";
            this.Errlabel7.Size = new System.Drawing.Size(14, 13);
            this.Errlabel7.TabIndex = 302;
            this.Errlabel7.Text = "*";
            this.Errlabel7.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.dtpReminder);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpInstallation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpDCDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvServicesReminder);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtNoOfServices);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(841, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 411);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Service Reminder Dates";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpExtraReminder);
            this.groupBox5.Controls.Add(this.label36);
            this.groupBox5.Controls.Add(this.label38);
            this.groupBox5.Controls.Add(this.txtExtraReminder);
            this.groupBox5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(15, 253);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(280, 76);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Extra Reminder( C Form or other)";
            // 
            // dtpExtraReminder
            // 
            this.dtpExtraReminder.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.dtpExtraReminder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExtraReminder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExtraReminder.Location = new System.Drawing.Point(75, 46);
            this.dtpExtraReminder.Name = "dtpExtraReminder";
            this.dtpExtraReminder.Size = new System.Drawing.Size(122, 21);
            this.dtpExtraReminder.TabIndex = 1;
            this.dtpExtraReminder.Tag = "Select Request date;@";
            this.dtpExtraReminder.Value = new System.DateTime(2014, 1, 2, 0, 0, 0, 0);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label36.Location = new System.Drawing.Point(30, 49);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(39, 13);
            this.label36.TabIndex = 300;
            this.label36.Text = "Date:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label38.Location = new System.Drawing.Point(2, 22);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(67, 13);
            this.label38.TabIndex = 205;
            this.label38.Text = "Reminder:";
            // 
            // txtExtraReminder
            // 
            this.txtExtraReminder.Location = new System.Drawing.Point(75, 19);
            this.txtExtraReminder.MaxLength = 500;
            this.txtExtraReminder.Name = "txtExtraReminder";
            this.txtExtraReminder.Size = new System.Drawing.Size(197, 21);
            this.txtExtraReminder.TabIndex = 0;
            this.txtExtraReminder.Tag = "Enter Bcc / Cc;";
            // 
            // dtpReminder
            // 
            this.dtpReminder.CustomFormat = "";
            this.dtpReminder.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpReminder.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReminder.Location = new System.Drawing.Point(168, 49);
            this.dtpReminder.Name = "dtpReminder";
            this.dtpReminder.Size = new System.Drawing.Size(123, 21);
            this.dtpReminder.TabIndex = 1;
            this.dtpReminder.Tag = "Select Warranty Reminder Date;";
            this.dtpReminder.Value = new System.DateTime(2016, 1, 30, 0, 0, 0, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label9.Location = new System.Drawing.Point(12, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 13);
            this.label9.TabIndex = 126;
            this.label9.Text = "AMC/Warranty End Date:";
            // 
            // dtpInstallation
            // 
            this.dtpInstallation.CustomFormat = "";
            this.dtpInstallation.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpInstallation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInstallation.Location = new System.Drawing.Point(168, 18);
            this.dtpInstallation.Name = "dtpInstallation";
            this.dtpInstallation.Size = new System.Drawing.Size(123, 21);
            this.dtpInstallation.TabIndex = 0;
            this.dtpInstallation.Tag = "Select Installation date;";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label8.Location = new System.Drawing.Point(65, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 125;
            this.label8.Text = "Installtion Date:";
            // 
            // dtpDCDate
            // 
            this.dtpDCDate.CustomFormat = "";
            this.dtpDCDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDCDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDCDate.Location = new System.Drawing.Point(168, 76);
            this.dtpDCDate.Name = "dtpDCDate";
            this.dtpDCDate.Size = new System.Drawing.Size(123, 21);
            this.dtpDCDate.TabIndex = 2;
            this.dtpDCDate.Tag = "Select AMC/Warranty Date;";
            this.dtpDCDate.Value = new System.DateTime(2014, 5, 1, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(11, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 124;
            this.label1.Text = "AMC/Wr. Reminder Date:";
            // 
            // dgvServicesReminder
            // 
            this.dgvServicesReminder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvServicesReminder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServicesReminder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServiceCode,
            this.ReminderDate});
            this.dgvServicesReminder.Location = new System.Drawing.Point(15, 129);
            this.dgvServicesReminder.Name = "dgvServicesReminder";
            this.dgvServicesReminder.RowTemplate.Height = 24;
            this.dgvServicesReminder.Size = new System.Drawing.Size(276, 123);
            this.dgvServicesReminder.TabIndex = 4;
            this.dgvServicesReminder.Tag = "List of Warranty Reminder Date;";
            // 
            // ServiceCode
            // 
            this.ServiceCode.HeaderText = "Service Code";
            this.ServiceCode.Name = "ServiceCode";
            // 
            // ReminderDate
            // 
            this.ReminderDate.HeaderText = "Reminder Date";
            this.ReminderDate.Name = "ReminderDate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(71, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 120;
            this.label10.Text = "No. of Service:";
            // 
            // txtNoOfServices
            // 
            this.txtNoOfServices.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfServices.Location = new System.Drawing.Point(168, 102);
            this.txtNoOfServices.Name = "txtNoOfServices";
            this.txtNoOfServices.Size = new System.Drawing.Size(123, 21);
            this.txtNoOfServices.TabIndex = 3;
            this.txtNoOfServices.Tag = "Enter no of Services;";
            this.txtNoOfServices.Text = "0";
            this.txtNoOfServices.TextChanged += new System.EventHandler(this.txtNoOfServices_TextChanged);
            this.txtNoOfServices.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfServices_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtbcc);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtcc);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(282, 79);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mail Details";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chksend);
            this.panel1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(6, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 23);
            this.panel1.TabIndex = 224;
            this.panel1.Tag = "Select next followup date;";
            // 
            // chksend
            // 
            this.chksend.AutoSize = true;
            this.chksend.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksend.Location = new System.Drawing.Point(86, 2);
            this.chksend.Name = "chksend";
            this.chksend.Size = new System.Drawing.Size(98, 17);
            this.chksend.TabIndex = 0;
            this.chksend.Tag = "Send Email;";
            this.chksend.Text = "Send Email";
            this.chksend.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label7.Location = new System.Drawing.Point(148, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "BCC:";
            // 
            // txtbcc
            // 
            this.txtbcc.Location = new System.Drawing.Point(189, 15);
            this.txtbcc.MaxLength = 4000;
            this.txtbcc.Name = "txtbcc";
            this.txtbcc.Size = new System.Drawing.Size(88, 21);
            this.txtbcc.TabIndex = 1;
            this.txtbcc.Tag = "Enter Bcc / Cc;";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label14.Location = new System.Drawing.Point(2, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 13);
            this.label14.TabIndex = 205;
            this.label14.Text = "CC:";
            // 
            // txtcc
            // 
            this.txtcc.Location = new System.Drawing.Point(35, 15);
            this.txtcc.MaxLength = 4000;
            this.txtcc.Name = "txtcc";
            this.txtcc.Size = new System.Drawing.Size(106, 21);
            this.txtcc.TabIndex = 0;
            this.txtcc.Tag = "Enter Bcc / Cc;";
            // 
            // gpDocDet
            // 
            this.gpDocDet.Controls.Add(this.dgvCountry);
            this.gpDocDet.Controls.Add(this.btnDeleteDoc);
            this.gpDocDet.Controls.Add(this.btnAddDoc);
            this.gpDocDet.Controls.Add(this.label18);
            this.gpDocDet.Controls.Add(this.btnBrowse);
            this.gpDocDet.Controls.Add(this.txtComment);
            this.gpDocDet.Controls.Add(this.label19);
            this.gpDocDet.Controls.Add(this.txtDocName);
            this.gpDocDet.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpDocDet.Location = new System.Drawing.Point(841, 9);
            this.gpDocDet.Name = "gpDocDet";
            this.gpDocDet.Size = new System.Drawing.Size(296, 201);
            this.gpDocDet.TabIndex = 1;
            this.gpDocDet.TabStop = false;
            this.gpDocDet.Tag = "Select Document;";
            this.gpDocDet.Text = "Document Details";
            // 
            // dgvCountry
            // 
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OpenFile,
            this.DocID,
            this.FileName,
            this.DocRemark,
            this.FullFileName,
            this.SaleID});
            this.dgvCountry.Location = new System.Drawing.Point(15, 76);
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.RowTemplate.Height = 24;
            this.dgvCountry.Size = new System.Drawing.Size(276, 117);
            this.dgvCountry.TabIndex = 5;
            this.dgvCountry.Tag = "List of document;";
            this.dgvCountry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountry_CellClick);
            // 
            // OpenFile
            // 
            this.OpenFile.HeaderText = "View";
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseColumnTextForButtonValue = true;
            // 
            // DocID
            // 
            this.DocID.HeaderText = "DocID";
            this.DocID.Name = "DocID";
            this.DocID.Visible = false;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File";
            this.FileName.Name = "FileName";
            // 
            // DocRemark
            // 
            this.DocRemark.HeaderText = "File Name";
            this.DocRemark.Name = "DocRemark";
            // 
            // FullFileName
            // 
            this.FullFileName.HeaderText = "FullFileName";
            this.FullFileName.Name = "FullFileName";
            this.FullFileName.Visible = false;
            // 
            // SaleID
            // 
            this.SaleID.HeaderText = "SaleID";
            this.SaleID.Name = "SaleID";
            this.SaleID.Visible = false;
            // 
            // btnDeleteDoc
            // 
            this.btnDeleteDoc.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDeleteDoc.Location = new System.Drawing.Point(218, 46);
            this.btnDeleteDoc.Name = "btnDeleteDoc";
            this.btnDeleteDoc.Size = new System.Drawing.Size(72, 24);
            this.btnDeleteDoc.TabIndex = 4;
            this.btnDeleteDoc.Tag = "Click to Delete;";
            this.btnDeleteDoc.Text = "Delete";
            this.btnDeleteDoc.UseVisualStyleBackColor = true;
            this.btnDeleteDoc.Click += new System.EventHandler(this.btnDeleteDoc_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnAddDoc.Location = new System.Drawing.Point(219, 16);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(73, 24);
            this.btnAddDoc.TabIndex = 2;
            this.btnAddDoc.Tag = "Click to Add;";
            this.btnAddDoc.Text = "Add";
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(6, 50);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "File Name:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowse.Location = new System.Drawing.Point(140, 16);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(73, 24);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Tag = "Click to browse;";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtComment
            // 
            this.txtComment.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComment.Location = new System.Drawing.Point(74, 46);
            this.txtComment.MaxLength = 4000;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(139, 23);
            this.txtComment.TabIndex = 3;
            this.txtComment.Tag = "Enter remarks;";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(37, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "File:";
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocName.Location = new System.Drawing.Point(74, 16);
            this.txtDocName.MaxLength = 100;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(60, 21);
            this.txtDocName.TabIndex = 0;
            this.txtDocName.Tag = "Select Document;";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label59.Location = new System.Drawing.Point(213, 693);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(27, 13);
            this.label59.TabIndex = 368;
            this.label59.Text = "No:";
            this.label59.Visible = false;
            // 
            // txtShippingAdd
            // 
            this.txtShippingAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShippingAdd.Location = new System.Drawing.Point(764, 15);
            this.txtShippingAdd.Name = "txtShippingAdd";
            this.txtShippingAdd.Size = new System.Drawing.Size(17, 21);
            this.txtShippingAdd.TabIndex = 299;
            this.txtShippingAdd.Tag = "Enter Shipping Address;";
            this.txtShippingAdd.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(758, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 276;
            this.label2.Text = "Narration:";
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.label2);
            this.grpErrorZone.Controls.Add(this.txtShippingAdd);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 2);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(1141, 43);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(871, 19);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 1;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(1, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(824, 21);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(1044, 679);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnGeneratePI
            // 
            this.btnGeneratePI.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnGeneratePI.Location = new System.Drawing.Point(868, 679);
            this.btnGeneratePI.Name = "btnGeneratePI";
            this.btnGeneratePI.Size = new System.Drawing.Size(170, 23);
            this.btnGeneratePI.TabIndex = 2;
            this.btnGeneratePI.Tag = "Click to generate Sales Invoice;";
            this.btnGeneratePI.Text = "Generate Sales Invoice";
            this.btnGeneratePI.UseVisualStyleBackColor = true;
            this.btnGeneratePI.Click += new System.EventHandler(this.btnGeneratePI_Click);
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(7, 677);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 3;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // txtTIN
            // 
            this.txtTIN.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTIN.Location = new System.Drawing.Point(246, 677);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(153, 21);
            this.txtTIN.TabIndex = 10;
            this.txtTIN.Tag = "Enter TIN;";
            this.txtTIN.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(208, 680);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 13);
            this.label22.TabIndex = 288;
            this.label22.Text = "TIN:";
            this.label22.Visible = false;
            // 
            // frmSalesInvoiceEntry
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1159, 750);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.btnGeneratePI);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.txtTIN);
            this.Controls.Add(this.label22);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "frmSalesInvoiceEntry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesInvoiceEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmSalesInvoiceEntry_Load);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.txtTIN, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnGeneratePI, 0);
            this.Controls.SetChildIndex(this.label59, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.grpData.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpBankDetail.ResumeLayout(false);
            this.grpBankDetail.PerformLayout();
            this.GrpCN.ResumeLayout(false);
            this.GrpCN.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.grpItemDetail.ResumeLayout(false);
            this.grpItemDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPIDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicesReminder)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpDocDet.ResumeLayout(false);
            this.gpDocDet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnGeneratePI;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.GroupBox gpDocDet;
        private System.Windows.Forms.DataGridView dgvCountry;
        private System.Windows.Forms.Button btnDeleteDoc;
        private System.Windows.Forms.Button btnAddDoc;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.TextBox txtComment;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.TextBox txtDocName;
        internal System.Windows.Forms.TextBox txtNoOfServices;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvServicesReminder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReminderDate;
        internal System.Windows.Forms.DateTimePicker dtpReminder;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.DateTimePicker dtpInstallation;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.DateTimePicker dtpDCDate;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbcc;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtcc;
        private System.Windows.Forms.CheckBox chksend;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNarration;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.TextBox txtmobile;
        internal System.Windows.Forms.TextBox txtcontactperson;
        internal System.Windows.Forms.Label label15;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.ComboBox cmbAttendedBy;
        private System.Windows.Forms.Button btnTNC;
        internal System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtServiceAmt;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPIDetail;
        internal System.Windows.Forms.TextBox txtCustomer;
        internal System.Windows.Forms.TextBox txtDuedays;
        internal System.Windows.Forms.DateTimePicker dtpPIDate;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.TextBox txtVATAmt;
        private System.Windows.Forms.Label lblAVAT;
        private System.Windows.Forms.TextBox txtAVATAmt;
        private System.Windows.Forms.Label lblCST;
        private System.Windows.Forms.TextBox txtCSTAmt;
        private System.Windows.Forms.Label lblExcise;
        private System.Windows.Forms.TextBox txtExciseAmt;
        private System.Windows.Forms.Label lblEduCess;
        private System.Windows.Forms.Label lblHEduCess;
        private System.Windows.Forms.Label lblAmtwithexcise;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.TextBox txtAmtwithExcise;
        private System.Windows.Forms.TextBox txtHEduCessAmt;
        private System.Windows.Forms.TextBox txtEduCessAmt;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblNetAmt;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label ErrOrderNo;
        private System.Windows.Forms.Button btnRegenrate;
        internal System.Windows.Forms.TextBox txtPINo;
        internal System.Windows.Forms.Label lblOrderNo;
        internal System.Windows.Forms.Label lblOrderDate;
        internal System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Button btnCustomerLOV;
        private System.Windows.Forms.Label Errcustname;
        internal System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.DataGridViewButtonColumn OpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleID;
        internal System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkTNC;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtextracharges;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtextrachargestype;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnedit;
        internal System.Windows.Forms.TextBox txtRec;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.ComboBox cmbType;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.Label label26;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.TextBox txtShippingAdd;
        private System.Windows.Forms.Button btnDis;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.ComboBox cmbEmpAllocatedTo;
        private System.Windows.Forms.ComboBox cmbStatus;
        internal System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtECType3;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtextracharges3;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtECType2;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txtextracharges2;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.GroupBox grpItemDetail;
        private System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.DateTimePicker dtpExtraReminder;
        internal System.Windows.Forms.Label label36;
        internal System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox txtExtraReminder;
        private System.Windows.Forms.TextBox txtCustInvoiceNo;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDicAmt;
        internal System.Windows.Forms.TextBox txtTIN;
        internal System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnContactPerson;
        internal System.Windows.Forms.ComboBox cmbgodown;
        internal System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label Errlabel7;
        private System.Windows.Forms.TextBox txtChallanNo;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        internal System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txtSBCessAmount;
        private System.Windows.Forms.Label lblExtraTax;
        private System.Windows.Forms.TextBox txtExtraTax;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.ComboBox cmbAgainstCN;
        internal System.Windows.Forms.Label label44;
        private System.Windows.Forms.GroupBox GrpCN;
        private System.Windows.Forms.TextBox txtAdjCN;
        private System.Windows.Forms.TextBox txtTotalPaidAmount;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox txtRemainingCN;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox txtCNoutstand;
        private System.Windows.Forms.Label label49;
        internal System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox grpBankDetail;
        internal System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.ComboBox cmbbankName;
        internal System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lblFromDate;
        internal System.Windows.Forms.Label label52;
        private System.Windows.Forms.DateTimePicker dtpchequeDate;
        internal System.Windows.Forms.TextBox txtCustomerBankName;
        internal System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        internal System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox txtIGSTAmt;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtCGSTAmt;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox txtSGSTAmt;
        internal System.Windows.Forms.ComboBox cmbBusinessType;
        internal System.Windows.Forms.Label label60;
        internal System.Windows.Forms.Label label59;
        private System.Windows.Forms.DataGridViewTextBoxColumn GodownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExciseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECessAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HECessAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountAfterExcise;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn VATAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVATAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SBCessAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraTaxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountAmt;
    }
}
