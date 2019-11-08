namespace Account.GUI.CustomerPayment
{
    partial class frmCustomerPaymentEntry
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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.ErrCustomer = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.ErrDate = new System.Windows.Forms.Label();
            this.ErrNo = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.btnCustomerLOV = new System.Windows.Forms.Button();
            this.lblEntryNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblNarration = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.dgvCustomerPaymentDetail = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesInvoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SIID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.LblTotalAmount = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerPaymentDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(667, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(654, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrCustomer);
            this.grpData.Controls.Add(this.lblCustomer);
            this.grpData.Controls.Add(this.btnRegenrate);
            this.grpData.Controls.Add(this.ErrDate);
            this.grpData.Controls.Add(this.ErrNo);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Controls.Add(this.txtReceiptNo);
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.txtCustomerName);
            this.grpData.Controls.Add(this.btnCustomerLOV);
            this.grpData.Controls.Add(this.lblEntryNo);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(667, 96);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // ErrCustomer
            // 
            this.ErrCustomer.AutoSize = true;
            this.ErrCustomer.ForeColor = System.Drawing.Color.Red;
            this.ErrCustomer.Location = new System.Drawing.Point(304, 71);
            this.ErrCustomer.Name = "ErrCustomer";
            this.ErrCustomer.Size = new System.Drawing.Size(15, 13);
            this.ErrCustomer.TabIndex = 10;
            this.ErrCustomer.Text = "*";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCustomer.Location = new System.Drawing.Point(33, 70);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(68, 13);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Customer:";
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(223, 37);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(89, 23);
            this.btnRegenrate.TabIndex = 4;
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
            this.ErrDate.Location = new System.Drawing.Point(573, 44);
            this.ErrDate.Name = "ErrDate";
            this.ErrDate.Size = new System.Drawing.Size(15, 13);
            this.ErrDate.TabIndex = 7;
            this.ErrDate.Text = "*";
            // 
            // ErrNo
            // 
            this.ErrNo.AutoSize = true;
            this.ErrNo.ForeColor = System.Drawing.Color.Red;
            this.ErrNo.Location = new System.Drawing.Point(207, 43);
            this.ErrNo.Name = "ErrNo";
            this.ErrNo.Size = new System.Drawing.Size(15, 13);
            this.ErrNo.TabIndex = 3;
            this.ErrNo.Text = "*";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(522, 17);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(127, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required fields";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptNo.Location = new System.Drawing.Point(104, 39);
            this.txtReceiptNo.MaxLength = 15;
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.ReadOnly = true;
            this.txtReceiptNo.Size = new System.Drawing.Size(101, 21);
            this.txtReceiptNo.TabIndex = 2;
            this.txtReceiptNo.TabStop = false;
            this.txtReceiptNo.Tag = "Receipt no;@";
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(480, 39);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(90, 21);
            this.dtpDate.TabIndex = 6;
            this.dtpDate.Tag = "Select Receipt Date;@";
            this.dtpDate.Value = new System.DateTime(2010, 10, 16, 0, 0, 0, 0);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(104, 66);
            this.txtCustomerName.MaxLength = 20;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(197, 21);
            this.txtCustomerName.TabIndex = 9;
            this.txtCustomerName.Tag = "Select customer;@";
            this.txtCustomerName.Leave += new System.EventHandler(this.txtCustomerName_Leave);
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerName_KeyPress);
            // 
            // btnCustomerLOV
            // 
            this.btnCustomerLOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCustomerLOV.Location = new System.Drawing.Point(320, 65);
            this.btnCustomerLOV.Name = "btnCustomerLOV";
            this.btnCustomerLOV.Size = new System.Drawing.Size(30, 23);
            this.btnCustomerLOV.TabIndex = 11;
            this.btnCustomerLOV.Tag = "Click to select customer;";
            this.btnCustomerLOV.Text = "...";
            this.btnCustomerLOV.UseVisualStyleBackColor = true;
            this.btnCustomerLOV.Click += new System.EventHandler(this.btnCustomerLOV_Click);
            // 
            // lblEntryNo
            // 
            this.lblEntryNo.AutoSize = true;
            this.lblEntryNo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEntryNo.Location = new System.Drawing.Point(28, 43);
            this.lblEntryNo.Name = "lblEntryNo";
            this.lblEntryNo.Size = new System.Drawing.Size(73, 13);
            this.lblEntryNo.TabIndex = 1;
            this.lblEntryNo.Text = "Receipt No:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDate.Location = new System.Drawing.Point(394, 43);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Receipt Date:";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblNarration.Location = new System.Drawing.Point(15, 359);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 1;
            this.lblNarration.Text = "Narration:";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(83, 356);
            this.txtNarration.MaxLength = 50;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(349, 70);
            this.txtNarration.TabIndex = 2;
            this.txtNarration.Tag = "Enter Narration;";
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.dgvCustomerPaymentDetail);
            this.grpDetail.Controls.Add(this.txtTotalAmount);
            this.grpDetail.Controls.Add(this.lblNarration);
            this.grpDetail.Controls.Add(this.LblTotalAmount);
            this.grpDetail.Controls.Add(this.txtNarration);
            this.grpDetail.Location = new System.Drawing.Point(12, 167);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(667, 436);
            this.grpDetail.TabIndex = 2;
            this.grpDetail.TabStop = false;
            // 
            // dgvCustomerPaymentDetail
            // 
            this.dgvCustomerPaymentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerPaymentDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.PaidAmount,
            this.PendingAmount,
            this.SalesInvoice,
            this.SalesDate,
            this.SIID});
            this.dgvCustomerPaymentDetail.Location = new System.Drawing.Point(8, 16);
            this.dgvCustomerPaymentDetail.Name = "dgvCustomerPaymentDetail";
            this.dgvCustomerPaymentDetail.Size = new System.Drawing.Size(653, 334);
            this.dgvCustomerPaymentDetail.TabIndex = 0;
            this.dgvCustomerPaymentDetail.Tag = "Customer Payment detail items;";
            this.dgvCustomerPaymentDetail.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomerPaymentDetail_CellValidated);
            this.dgvCustomerPaymentDetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCustomerPaymentDetail_CellPainting);
            this.dgvCustomerPaymentDetail.CurrentCellChanged += new System.EventHandler(this.dgvCustomerPaymentDetail_CurrentCellChanged);
            this.dgvCustomerPaymentDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCustomerPaymentDetail_DataError);
            this.dgvCustomerPaymentDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomerPaymentDetail_KeyDown);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // PaidAmount
            // 
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
            // SalesInvoice
            // 
            this.SalesInvoice.HeaderText = "Sales Invoice";
            this.SalesInvoice.Name = "SalesInvoice";
            // 
            // SalesDate
            // 
            this.SalesDate.HeaderText = "Sales Date";
            this.SalesDate.Name = "SalesDate";
            // 
            // SIID
            // 
            this.SIID.HeaderText = "SIID";
            this.SIID.Name = "SIID";
            this.SIID.Visible = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(529, 356);
            this.txtTotalAmount.MaxLength = 100;
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(132, 21);
            this.txtTotalAmount.TabIndex = 4;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Tag = "Total amount;";
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblTotalAmount
            // 
            this.LblTotalAmount.AutoSize = true;
            this.LblTotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.LblTotalAmount.Location = new System.Drawing.Point(438, 359);
            this.LblTotalAmount.Name = "LblTotalAmount";
            this.LblTotalAmount.Size = new System.Drawing.Size(88, 13);
            this.LblTotalAmount.TabIndex = 3;
            this.LblTotalAmount.Text = "Total Amount:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(579, 609);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(431, 609);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(142, 23);
            this.btnSaveExit.TabIndex = 5;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(276, 609);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(149, 23);
            this.btnSaveContinue.TabIndex = 4;
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
            this.lblDelMsg.Location = new System.Drawing.Point(12, 608);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 3;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // frmCustomerPaymentEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(691, 666);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmCustomerPaymentEntry";
            this.Text = "Customer Payment - New";
            this.Load += new System.EventHandler(this.frmCustomerPaymentEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpDetail, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
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
        internal System.Windows.Forms.DateTimePicker dtpDate;
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
        internal System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SIID;
    }
}
