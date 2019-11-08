namespace Account.GUI.VendorPayment
{
    partial class frmVendorPaymentEntry
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
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.ErrVendor = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.ErrDate = new System.Windows.Forms.Label();
            this.ErrNo = new System.Windows.Forms.Label();
            this.txtPaymentNo = new System.Windows.Forms.TextBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.btnVendorLOV = new System.Windows.Forms.Button();
            this.lblEntryNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.grpBankDetail = new System.Windows.Forms.GroupBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbankName = new System.Windows.Forms.TextBox();
            this.cmbbankName = new System.Windows.Forms.ComboBox();
            this.txtChequeDate = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpchequeDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.dgvVendorPaymentDetail = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.LblTotalAmount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpDetail.SuspendLayout();
            this.grpBankDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorPaymentDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(637, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(266, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(410, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(127, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.ErrVendor);
            this.grpData.Controls.Add(this.lblVendor);
            this.grpData.Controls.Add(this.btnRegenrate);
            this.grpData.Controls.Add(this.ErrDate);
            this.grpData.Controls.Add(this.ErrNo);
            this.grpData.Controls.Add(this.txtPaymentNo);
            this.grpData.Controls.Add(this.txtVendorName);
            this.grpData.Controls.Add(this.btnVendorLOV);
            this.grpData.Controls.Add(this.lblEntryNo);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(637, 81);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(499, 18);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(108, 21);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Tag = "Select Receipt Date;@";
            // 
            // ErrVendor
            // 
            this.ErrVendor.AutoSize = true;
            this.ErrVendor.ForeColor = System.Drawing.Color.Red;
            this.ErrVendor.Location = new System.Drawing.Point(613, 46);
            this.ErrVendor.Name = "ErrVendor";
            this.ErrVendor.Size = new System.Drawing.Size(15, 13);
            this.ErrVendor.TabIndex = 10;
            this.ErrVendor.Text = "*";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblVendor.Location = new System.Drawing.Point(37, 52);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(53, 13);
            this.lblVendor.TabIndex = 8;
            this.lblVendor.Text = "Vendor:";
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(264, 19);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(30, 23);
            this.btnRegenrate.TabIndex = 1;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate Payment no;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // ErrDate
            // 
            this.ErrDate.AutoSize = true;
            this.ErrDate.ForeColor = System.Drawing.Color.Red;
            this.ErrDate.Location = new System.Drawing.Point(613, 17);
            this.ErrDate.Name = "ErrDate";
            this.ErrDate.Size = new System.Drawing.Size(15, 13);
            this.ErrDate.TabIndex = 7;
            this.ErrDate.Text = "*";
            // 
            // ErrNo
            // 
            this.ErrNo.AutoSize = true;
            this.ErrNo.ForeColor = System.Drawing.Color.Red;
            this.ErrNo.Location = new System.Drawing.Point(296, 18);
            this.ErrNo.Name = "ErrNo";
            this.ErrNo.Size = new System.Drawing.Size(15, 13);
            this.ErrNo.TabIndex = 3;
            this.ErrNo.Text = "*";
            // 
            // txtPaymentNo
            // 
            this.txtPaymentNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentNo.Location = new System.Drawing.Point(93, 21);
            this.txtPaymentNo.MaxLength = 15;
            this.txtPaymentNo.Name = "txtPaymentNo";
            this.txtPaymentNo.ReadOnly = true;
            this.txtPaymentNo.Size = new System.Drawing.Size(164, 21);
            this.txtPaymentNo.TabIndex = 0;
            this.txtPaymentNo.TabStop = false;
            this.txtPaymentNo.Tag = "Payment no;@";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorName.Location = new System.Drawing.Point(93, 48);
            this.txtVendorName.MaxLength = 20;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(478, 21);
            this.txtVendorName.TabIndex = 3;
            this.txtVendorName.Tag = "Select customer;@";
            this.txtVendorName.Leave += new System.EventHandler(this.txtVendorName_Leave);
            this.txtVendorName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVendorName_KeyPress);
            // 
            // btnVendorLOV
            // 
            this.btnVendorLOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVendorLOV.Location = new System.Drawing.Point(577, 46);
            this.btnVendorLOV.Name = "btnVendorLOV";
            this.btnVendorLOV.Size = new System.Drawing.Size(30, 23);
            this.btnVendorLOV.TabIndex = 4;
            this.btnVendorLOV.Tag = "Click to select customer;";
            this.btnVendorLOV.Text = "...";
            this.btnVendorLOV.UseVisualStyleBackColor = true;
            this.btnVendorLOV.Click += new System.EventHandler(this.btnVendorLOV_Click);
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEntryNo.Location = new System.Drawing.Point(8, 25);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(81, 13);
            this.lblEntryNo.TabIndex = 1;
            this.lblEntryNo.Text = "Payment No:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDate.Location = new System.Drawing.Point(400, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(93, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Payment Date:";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblNarration.Location = new System.Drawing.Point(44, 307);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 1;
            this.lblNarration.Text = "Narration:";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(112, 304);
            this.txtNarration.MaxLength = 4000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNarration.Size = new System.Drawing.Size(495, 48);
            this.txtNarration.TabIndex = 1;
            this.txtNarration.Tag = "Enter Narration;";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.grpBankDetail);
            this.grpDetail.Controls.Add(this.label3);
            this.grpDetail.Controls.Add(this.cmbMode);
            this.grpDetail.Controls.Add(this.label26);
            this.grpDetail.Controls.Add(this.cmbCurrency);
            this.grpDetail.Controls.Add(this.dgvVendorPaymentDetail);
            this.grpDetail.Controls.Add(this.txtTotalAmount);
            this.grpDetail.Controls.Add(this.lblNarration);
            this.grpDetail.Controls.Add(this.LblTotalAmount);
            this.grpDetail.Controls.Add(this.txtNarration);
            this.grpDetail.Location = new System.Drawing.Point(12, 152);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(637, 432);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            // 
            // grpBankDetail
            // 
            this.grpBankDetail.Controls.Add(this.label53);
            this.grpBankDetail.Controls.Add(this.label52);
            this.grpBankDetail.Controls.Add(this.dateTimePicker1);
            this.grpBankDetail.Controls.Add(this.txtChequeNo);
            this.grpBankDetail.Controls.Add(this.label1);
            this.grpBankDetail.Controls.Add(this.txtbankName);
            this.grpBankDetail.Controls.Add(this.cmbbankName);
            this.grpBankDetail.Controls.Add(this.txtChequeDate);
            this.grpBankDetail.Controls.Add(this.lblFromDate);
            this.grpBankDetail.Controls.Add(this.dtpchequeDate);
            this.grpBankDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpBankDetail.Location = new System.Drawing.Point(6, 355);
            this.grpBankDetail.Name = "grpBankDetail";
            this.grpBankDetail.Size = new System.Drawing.Size(622, 71);
            this.grpBankDetail.TabIndex = 347;
            this.grpBankDetail.TabStop = false;
            this.grpBankDetail.Text = "Bank Details";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label53.Location = new System.Drawing.Point(316, 50);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(75, 13);
            this.label53.TabIndex = 343;
            this.label53.Text = "Bank(OUT):";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label52.Location = new System.Drawing.Point(26, 47);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(64, 13);
            this.label52.TabIndex = 340;
            this.label52.Text = "Bank(IN):";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(635, 17);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(19, 21);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.TabStop = false;
            this.dateTimePicker1.Tag = "Select cheque date;";
            this.dateTimePicker1.Value = new System.DateTime(2014, 1, 5, 0, 0, 0, 0);
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeNo.Location = new System.Drawing.Point(99, 16);
            this.txtChequeNo.MaxLength = 50;
            this.txtChequeNo.Multiline = true;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(165, 22);
            this.txtChequeNo.TabIndex = 24;
            this.txtChequeNo.Tag = "Enter Cheque No;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Cheque No:";
            // 
            // txtbankName
            // 
            this.txtbankName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbankName.Location = new System.Drawing.Point(99, 44);
            this.txtbankName.MaxLength = 50;
            this.txtbankName.Multiline = true;
            this.txtbankName.Name = "txtbankName";
            this.txtbankName.Size = new System.Drawing.Size(165, 22);
            this.txtbankName.TabIndex = 27;
            this.txtbankName.Tag = "Enter bank name;";
            // 
            // cmbbankName
            // 
            this.cmbbankName.FormattingEnabled = true;
            this.cmbbankName.Location = new System.Drawing.Point(397, 43);
            this.cmbbankName.Name = "cmbbankName";
            this.cmbbankName.Size = new System.Drawing.Size(206, 21);
            this.cmbbankName.TabIndex = 31;
            this.cmbbankName.Tag = "Select Bank Name;@";
            // 
            // txtChequeDate
            // 
            this.txtChequeDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChequeDate.Location = new System.Drawing.Point(397, 16);
            this.txtChequeDate.MaxLength = 50;
            this.txtChequeDate.Name = "txtChequeDate";
            this.txtChequeDate.Size = new System.Drawing.Size(179, 21);
            this.txtChequeDate.TabIndex = 25;
            this.txtChequeDate.Tag = "Enter cheque date;";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(304, 19);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(87, 13);
            this.lblFromDate.TabIndex = 30;
            this.lblFromDate.Text = "Cheque Date:";
            // 
            // dtpchequeDate
            // 
            this.dtpchequeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpchequeDate.Location = new System.Drawing.Point(582, 16);
            this.dtpchequeDate.Name = "dtpchequeDate";
            this.dtpchequeDate.Size = new System.Drawing.Size(21, 21);
            this.dtpchequeDate.TabIndex = 26;
            this.dtpchequeDate.TabStop = false;
            this.dtpchequeDate.Tag = "Select cheque date;";
            this.dtpchequeDate.Value = new System.DateTime(2014, 1, 5, 0, 0, 0, 0);
            this.dtpchequeDate.CloseUp += new System.EventHandler(this.dtpchequeDate_CloseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(10, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 346;
            this.label3.Text = "Payment Mode:";
            // 
            // cmbMode
            // 
            this.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.cmbMode.Location = new System.Drawing.Point(112, 277);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(495, 21);
            this.cmbMode.TabIndex = 345;
            this.cmbMode.Tag = "Select currency;@";
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label26.Location = new System.Drawing.Point(41, 254);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 13);
            this.label26.TabIndex = 78;
            this.label26.Text = "Currency:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(112, 250);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(97, 21);
            this.cmbCurrency.TabIndex = 77;
            this.cmbCurrency.Tag = "Select currency;@";
            // 
            // dgvVendorPaymentDetail
            // 
            this.dgvVendorPaymentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendorPaymentDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.PaidAmount,
            this.PendingAmount,
            this.PurchaseInvoice,
            this.PurchaseDate,
            this.PIID});
            this.dgvVendorPaymentDetail.Location = new System.Drawing.Point(8, 16);
            this.dgvVendorPaymentDetail.Name = "dgvVendorPaymentDetail";
            this.dgvVendorPaymentDetail.Size = new System.Drawing.Size(599, 224);
            this.dgvVendorPaymentDetail.TabIndex = 0;
            this.dgvVendorPaymentDetail.Tag = "Vendor Payment detail items;";
            this.dgvVendorPaymentDetail.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVendorPaymentDetail_CellValidated);
            this.dgvVendorPaymentDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvVendorPaymentDetail_CellPainting);
            this.dgvVendorPaymentDetail.CurrentCellChanged += new System.EventHandler(this.dgvVendorPaymentDetail_CurrentCellChanged);
            this.dgvVendorPaymentDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvVendorPaymentDetail_DataError);
            this.dgvVendorPaymentDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvVendorPaymentDetail_KeyDown);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // PaidAmount
            // 
            dataGridViewCellStyle1.Format = "#0.00";
            this.PaidAmount.DefaultCellStyle = dataGridViewCellStyle1;
            this.PaidAmount.HeaderText = "PaidAmount";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PaidAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PendingAmount
            // 
            this.PendingAmount.HeaderText = "Pending Amount";
            this.PendingAmount.Name = "PendingAmount";
            // 
            // PurchaseInvoice
            // 
            this.PurchaseInvoice.HeaderText = "Purchase Invoice";
            this.PurchaseInvoice.Name = "PurchaseInvoice";
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.HeaderText = "Purchase Date";
            this.PurchaseDate.Name = "PurchaseDate";
            // 
            // PIID
            // 
            this.PIID.HeaderText = "PIID";
            this.PIID.Name = "PIID";
            this.PIID.Visible = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(401, 250);
            this.txtTotalAmount.MaxLength = 100;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(206, 21);
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
            this.LblTotalAmount.Location = new System.Drawing.Point(308, 253);
            this.LblTotalAmount.Name = "LblTotalAmount";
            this.LblTotalAmount.Size = new System.Drawing.Size(88, 13);
            this.LblTotalAmount.TabIndex = 3;
            this.LblTotalAmount.Text = "Total Amount:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(521, 590);
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
            this.btnSaveExit.Location = new System.Drawing.Point(397, 590);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(111, 23);
            this.btnSaveExit.TabIndex = 4;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(266, 590);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(120, 23);
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
            this.lblDelMsg.Location = new System.Drawing.Point(15, 590);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 3;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // frmVendorPaymentEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(661, 645);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmVendorPaymentEntry";
            this.Text = "Vendor Payment - New";
            this.Load += new System.EventHandler(this.frmVendorPaymentEntry_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendorPaymentDetail)).EndInit();
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
        internal System.Windows.Forms.TextBox txtPaymentNo;
        internal System.Windows.Forms.Label lblEntryNo;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.TextBox txtNarration;
        internal System.Windows.Forms.Label lblNarration;
        internal System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.DataGridView dgvVendorPaymentDetail;
        internal System.Windows.Forms.TextBox txtTotalAmount;
        internal System.Windows.Forms.Label LblTotalAmount;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Label ErrVendor;
        private System.Windows.Forms.Button btnVendorLOV;
        internal System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIID;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpchequeDate;
        private System.Windows.Forms.TextBox txtChequeDate;
        internal System.Windows.Forms.TextBox txtbankName;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.ComboBox cmbbankName;
        private System.Windows.Forms.Label label26;
        internal System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.GroupBox grpBankDetail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Label label52;
        internal System.Windows.Forms.Label label53;
    }
}
