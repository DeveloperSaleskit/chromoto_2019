namespace Account.GUI.CustomerPaymentReturn
{
    partial class frmCustomerPaymentReturnEntry
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
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.ErrCustomer = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.ErrDate = new System.Windows.Forms.Label();
            this.ErrNo = new System.Windows.Forms.Label();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnCustomerLOV = new System.Windows.Forms.Button();
            this.lblEntryNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.grpBankDetail = new System.Windows.Forms.GroupBox();
            this.cmbbankName = new System.Windows.Forms.ComboBox();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.txtCustomerbankName = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.dtpchequeDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.dgvCustomerPaymentDetail = new System.Windows.Forms.DataGridView();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.LblTotalAmount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.grpBankDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerPaymentDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(677, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(305, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(409, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(127, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.ErrCustomer);
            this.grpData.Controls.Add(this.lblCustomer);
            this.grpData.Controls.Add(this.btnRegenrate);
            this.grpData.Controls.Add(this.ErrDate);
            this.grpData.Controls.Add(this.ErrNo);
            this.grpData.Controls.Add(this.txtReceiptNo);
            this.grpData.Controls.Add(this.txtCustomerName);
            this.grpData.Controls.Add(this.btnCustomerLOV);
            this.grpData.Controls.Add(this.lblEntryNo);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(677, 85);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(504, 19);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(146, 21);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Tag = "Select Receipt Date;@";
            // 
            // ErrCustomer
            // 
            this.ErrCustomer.AutoSize = true;
            this.ErrCustomer.ForeColor = System.Drawing.Color.Red;
            this.ErrCustomer.Location = new System.Drawing.Point(656, 52);
            this.ErrCustomer.Name = "ErrCustomer";
            this.ErrCustomer.Size = new System.Drawing.Size(15, 13);
            this.ErrCustomer.TabIndex = 10;
            this.ErrCustomer.Text = "*";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCustomer.Location = new System.Drawing.Point(25, 53);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(68, 13);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Customer:";
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(279, 18);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(89, 23);
            this.btnRegenrate.TabIndex = 1;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate receipt no;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // ErrDate
            // 
            this.ErrDate.AutoSize = true;
            this.ErrDate.ForeColor = System.Drawing.Color.Red;
            this.ErrDate.Location = new System.Drawing.Point(656, 23);
            this.ErrDate.Name = "ErrDate";
            this.ErrDate.Size = new System.Drawing.Size(15, 13);
            this.ErrDate.TabIndex = 7;
            this.ErrDate.Text = "*";
            // 
            // ErrNo
            // 
            this.ErrNo.AutoSize = true;
            this.ErrNo.ForeColor = System.Drawing.Color.Red;
            this.ErrNo.Location = new System.Drawing.Point(261, 17);
            this.ErrNo.Name = "ErrNo";
            this.ErrNo.Size = new System.Drawing.Size(15, 13);
            this.ErrNo.TabIndex = 3;
            this.ErrNo.Text = "*";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(104, 20);
            this.txtReceiptNo.MaxLength = 15;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(154, 21);
            this.txtReceiptNo.TabIndex = 0;
            this.txtReceiptNo.TabStop = false;
            this.txtReceiptNo.Tag = "Receipt no;@";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(104, 49);
            this.txtCustomerName.MaxLength = 20;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(510, 21);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.Tag = "Select customer;@";
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            this.txtCustomerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCustomerName_KeyUp);
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            // 
            // btnCustomerLOV
            // 
            this.btnCustomerLOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCustomerLOV.Location = new System.Drawing.Point(620, 47);
            this.btnCustomerLOV.Name = "btnCustomerLOV";
            this.btnCustomerLOV.Size = new System.Drawing.Size(30, 23);
            this.btnCustomerLOV.TabIndex = 4;
            this.btnCustomerLOV.Tag = "Click to select customer;";
            this.btnCustomerLOV.Text = "...";
            this.btnCustomerLOV.UseVisualStyleBackColor = true;
            this.btnCustomerLOV.Click += new System.EventHandler(this.btnCustomerLOV_Click);
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEntryNo.Location = new System.Drawing.Point(25, 23);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(73, 13);
            this.lblEntryNo.TabIndex = 1;
            this.lblEntryNo.Text = "Receipt No:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDate.Location = new System.Drawing.Point(413, 23);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Receipt Date:";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblNarration.Location = new System.Drawing.Point(25, 345);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 1;
            this.lblNarration.Text = "Narration:";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(108, 338);
            this.txtNarration.MaxLength = 4000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNarration.Size = new System.Drawing.Size(554, 53);
            this.txtNarration.TabIndex = 1;
            this.txtNarration.Tag = "Enter Narration;";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.grpBankDetail);
            this.grpDetail.Controls.Add(this.label2);
            this.grpDetail.Controls.Add(this.cmbMode);
            this.grpDetail.Controls.Add(this.label26);
            this.grpDetail.Controls.Add(this.cmbCurrency);
            this.grpDetail.Controls.Add(this.dgvCustomerPaymentDetail);
            this.grpDetail.Controls.Add(this.txtTotalAmount);
            this.grpDetail.Controls.Add(this.lblNarration);
            this.grpDetail.Controls.Add(this.LblTotalAmount);
            this.grpDetail.Controls.Add(this.txtNarration);
            this.grpDetail.Location = new System.Drawing.Point(12, 156);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(677, 474);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            // 
            // grpBankDetail
            // 
            this.grpBankDetail.Controls.Add(this.cmbbankName);
            this.grpBankDetail.Controls.Add(this.txtChequeNo);
            this.grpBankDetail.Controls.Add(this.label1);
            this.grpBankDetail.Controls.Add(this.label53);
            this.grpBankDetail.Controls.Add(this.txtCustomerbankName);
            this.grpBankDetail.Controls.Add(this.label52);
            this.grpBankDetail.Controls.Add(this.txtChequeDate);
            this.grpBankDetail.Controls.Add(this.dtpchequeDate);
            this.grpBankDetail.Controls.Add(this.lblFromDate);
            this.grpBankDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpBankDetail.Location = new System.Drawing.Point(8, 397);
            this.grpBankDetail.Name = "grpBankDetail";
            this.grpBankDetail.Size = new System.Drawing.Size(663, 71);
            this.grpBankDetail.TabIndex = 345;
            this.grpBankDetail.TabStop = false;
            this.grpBankDetail.Text = "Bank Details";
            // 
            // cmbbankName
            // 
            this.cmbbankName.FormattingEnabled = true;
            this.cmbbankName.Location = new System.Drawing.Point(434, 44);
            this.cmbbankName.Name = "cmbbankName";
            this.cmbbankName.Size = new System.Drawing.Size(220, 21);
            this.cmbbankName.TabIndex = 28;
            this.cmbbankName.Tag = "Select Bank Name;@";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(85, 16);
            this.txtChequeNo.MaxLength = 50;
            this.txtChequeNo.Multiline = true;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(210, 22);
            this.txtChequeNo.TabIndex = 2;
            this.txtChequeNo.Tag = "Enter Cheque No;@";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cheque No:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label53.Location = new System.Drawing.Point(351, 47);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(75, 13);
            this.label53.TabIndex = 342;
            this.label53.Text = "Bank(OUT):";
            // 
            // txtCustomerbankName
            // 
            this.txtCustomerbankName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerbankName.Location = new System.Drawing.Point(85, 46);
            this.txtCustomerbankName.MaxLength = 50;
            this.txtCustomerbankName.Multiline = true;
            this.txtCustomerbankName.Name = "txtCustomerbankName";
            this.txtCustomerbankName.Size = new System.Drawing.Size(210, 22);
            this.txtCustomerbankName.TabIndex = 5;
            this.txtCustomerbankName.Tag = "Enter bank name;@";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label52.Location = new System.Drawing.Point(17, 49);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(64, 13);
            this.label52.TabIndex = 339;
            this.label52.Text = "Bank(IN):";
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeDate.Location = new System.Drawing.Point(434, 17);
            this.txtChequeDate.MaxLength = 50;
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.Size = new System.Drawing.Size(195, 21);
            this.txtChequeDate.TabIndex = 3;
            this.txtChequeDate.Tag = "Enter cheque date;@";
            this.txtChequeDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromDate_KeyPress);
            // 
            // dtpchequeDate
            // 
            this.dtpchequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpchequeDate.Location = new System.Drawing.Point(635, 17);
            this.dtpchequeDate.Name = "dtpchequeDate";
            this.dtpchequeDate.Size = new System.Drawing.Size(19, 21);
            this.dtpchequeDate.TabIndex = 4;
            this.dtpchequeDate.TabStop = false;
            this.dtpchequeDate.Tag = "Select cheque date;";
            this.dtpchequeDate.Value = new System.DateTime(2014, 1, 5, 0, 0, 0, 0);
            this.dtpchequeDate.ValueChanged += new System.EventHandler(this.dtpchequeDate_ValueChanged);
            this.dtpchequeDate.CloseUp += new System.EventHandler(this.dtpchequeDate_CloseUp);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(339, 19);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(87, 13);
            this.lblFromDate.TabIndex = 16;
            this.lblFromDate.Text = "Cheque Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(8, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 344;
            this.label2.Text = "Payment Mode:";
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cmbMode.Location = new System.Drawing.Point(108, 311);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(554, 21);
            this.cmbMode.TabIndex = 343;
            this.cmbMode.Tag = "Select currency;@";
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label26.Location = new System.Drawing.Point(33, 288);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 13);
            this.label26.TabIndex = 76;
            this.label26.Text = "Currency:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(108, 284);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(116, 21);
            this.cmbCurrency.TabIndex = 75;
            this.cmbCurrency.Tag = "Select currency;@";
            // 
            // dgvCustomerPaymentDetail
            // 
            this.dgvCustomerPaymentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerPaymentDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.PaidAmount,
            this.PendingAmount,
            this.CreditNote,
            this.CNDate,
            this.CNID});
            this.dgvCustomerPaymentDetail.Location = new System.Drawing.Point(8, 16);
            this.dgvCustomerPaymentDetail.Name = "dgvCustomerPaymentDetail";
            this.dgvCustomerPaymentDetail.Size = new System.Drawing.Size(654, 257);
            this.dgvCustomerPaymentDetail.TabIndex = 0;
            this.dgvCustomerPaymentDetail.Tag = "Customer Payment detail items;";
            this.dgvCustomerPaymentDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerPaymentDetail_CellValueChanged);
            this.dgvCustomerPaymentDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCustomerPaymentDetail_CellBeginEdit);
            this.dgvCustomerPaymentDetail.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerPaymentDetail_CellValidated);
            this.dgvCustomerPaymentDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerPaymentDetail_CellEndEdit);
            this.dgvCustomerPaymentDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCustomerPaymentDetail_CellPainting);
            this.dgvCustomerPaymentDetail.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerPaymentDetail_CellClick);
            this.dgvCustomerPaymentDetail.CurrentCellChanged += new System.EventHandler(this.dgvCustomerPaymentDetail_CurrentCellChanged);
            this.dgvCustomerPaymentDetail.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCustomerPaymentDetail_CurrentCellDirtyStateChanged);
            this.dgvCustomerPaymentDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCustomerPaymentDetail_DataError);
            this.dgvCustomerPaymentDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerPaymentDetail_KeyDown);
            this.dgvCustomerPaymentDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerPaymentDetail_CellContentClick);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(344, 284);
            this.txtTotalAmount.MaxLength = 100;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(318, 21);
            this.txtTotalAmount.TabIndex = 6;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Tag = "Total amount;";
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblTotalAmount
            // 
            this.LblTotalAmount.AutoSize = true;
            this.LblTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.LblTotalAmount.Location = new System.Drawing.Point(250, 288);
            this.LblTotalAmount.Name = "LblTotalAmount";
            this.LblTotalAmount.Size = new System.Drawing.Size(88, 13);
            this.LblTotalAmount.TabIndex = 3;
            this.LblTotalAmount.Text = "Total Amount:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(583, 636);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(435, 636);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(142, 23);
            this.btnSaveExit.TabIndex = 4;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(280, 636);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(149, 23);
            this.btnSaveContinue.TabIndex = 3;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(12, 633);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 3;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // PaidAmount
            // 
            this.PaidAmount.HeaderText = "Returned Amount";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PaidAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PendingAmount
            // 
            this.PendingAmount.HeaderText = "Remaining Amount";
            this.PendingAmount.Name = "PendingAmount";
            // 
            // CreditNote
            // 
            this.CreditNote.HeaderText = "Credit Note";
            this.CreditNote.Name = "CreditNote";
            this.CreditNote.Visible = false;
            // 
            // CNDate
            // 
            this.CNDate.HeaderText = "CreditNote Date";
            this.CNDate.Name = "CNDate";
            this.CNDate.Visible = false;
            // 
            // CNID
            // 
            this.CNID.HeaderText = "CNID";
            this.CNID.Name = "CNID";
            this.CNID.Visible = false;
            // 
            // frmCustomerPaymentReturnEntry
            // 
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(701, 691);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmCustomerPaymentReturnEntry";
            this.Text = "Customer Payment Return - New";
            this.Load += new System.EventHandler(this.frmCustomerPaymentEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpDetail, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.grpBankDetail.ResumeLayout(false);
            this.grpBankDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerPaymentDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Button btnRegenrate;
        private System.Windows.Forms.Label ErrDate;
        private System.Windows.Forms.Label ErrNo;
        private System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.TextBox txtReceiptNo;
        internal System.Windows.Forms.Label lblEntryNo;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.TextBox txtNarration;
        internal System.Windows.Forms.Label lblNarration;
        internal System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.DataGridView dgvCustomerPaymentDetail;
        internal System.Windows.Forms.TextBox txtTotalAmount;
        internal System.Windows.Forms.Label LblTotalAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Label ErrCustomer;
        private System.Windows.Forms.Button btnCustomerLOV;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpchequeDate;
        private System.Windows.Forms.TextBox txtChequeDate;
        internal System.Windows.Forms.TextBox txtCustomerbankName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.ComboBox cmbbankName;
        private System.Windows.Forms.Label label26;
        internal System.Windows.Forms.ComboBox cmbCurrency;
        internal System.Windows.Forms.Label label52;
        internal System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.GroupBox grpBankDetail;
        public System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNID;
    }
}
