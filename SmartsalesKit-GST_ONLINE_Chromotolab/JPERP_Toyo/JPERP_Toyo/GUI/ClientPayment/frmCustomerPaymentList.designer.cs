namespace Account.GUI.CustomerPayment
{
    partial class frmCustomerPaymentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerPaymentList));
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolsReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuDeliveryChallanRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtPaymentCode = new System.Windows.Forms.TextBox();
            this.lblPaymentCode = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.txtTodate = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.grpGrid = new System.Windows.Forms.GroupBox();
            this.dgvCustomerPayment = new System.Windows.Forms.DataGridView();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.ReceiptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tools.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerPayment)).BeginInit();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsReports});
            this.tools.Location = new System.Drawing.Point(1, 1);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(805, 24);
            this.tools.TabIndex = 6;
            this.tools.TabStop = true;
            this.tools.Text = "ToolStrip1";
            // 
            // toolsReports
            // 
            this.toolsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDeliveryChallanRegister});
            this.toolsReports.Image = ((System.Drawing.Image)(resources.GetObject("toolsReports.Image")));
            this.toolsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsReports.Name = "toolsReports";
            this.toolsReports.Size = new System.Drawing.Size(65, 21);
            this.toolsReports.Tag = "View report;";
            this.toolsReports.Text = "Reports";
            // 
            // mnuDeliveryChallanRegister
            // 
            this.mnuDeliveryChallanRegister.Name = "mnuDeliveryChallanRegister";
            this.mnuDeliveryChallanRegister.Size = new System.Drawing.Size(194, 22);
            this.mnuDeliveryChallanRegister.Tag = "Click to view customer payment report;";
            this.mnuDeliveryChallanRegister.Text = "Customer Payment";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtCustomer);
            this.grpFilter.Controls.Add(this.lblCustomer);
            this.grpFilter.Controls.Add(this.txtPaymentCode);
            this.grpFilter.Controls.Add(this.lblPaymentCode);
            this.grpFilter.Controls.Add(this.lblToDate);
            this.grpFilter.Controls.Add(this.dtpTodate);
            this.grpFilter.Controls.Add(this.txtTodate);
            this.grpFilter.Controls.Add(this.lblFromDate);
            this.grpFilter.Controls.Add(this.dtpFromDate);
            this.grpFilter.Controls.Add(this.txtFromDate);
            this.grpFilter.Controls.Add(this.btnClear);
            this.grpFilter.Controls.Add(this.btnApply);
            this.grpFilter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(12, 31);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(783, 63);
            this.grpFilter.TabIndex = 4;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(107, 36);
            this.txtCustomer.MaxLength = 15;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(92, 21);
            this.txtCustomer.TabIndex = 3;
            this.txtCustomer.Tag = "Enter customer;";
            this.txtCustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromentryno_KeyPress);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCustomer.Location = new System.Drawing.Point(105, 20);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 13);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer";
            // 
            // txtPaymentCode
            // 
            this.txtPaymentCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentCode.Location = new System.Drawing.Point(9, 36);
            this.txtPaymentCode.MaxLength = 15;
            this.txtPaymentCode.Name = "txtPaymentCode";
            this.txtPaymentCode.Size = new System.Drawing.Size(92, 21);
            this.txtPaymentCode.TabIndex = 1;
            this.txtPaymentCode.Tag = "Enter payment code;";
            this.txtPaymentCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromentryno_KeyPress);
            // 
            // lblPaymentCode
            // 
            this.lblPaymentCode.AutoSize = true;
            this.lblPaymentCode.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblPaymentCode.Location = new System.Drawing.Point(7, 20);
            this.lblPaymentCode.Name = "lblPaymentCode";
            this.lblPaymentCode.Size = new System.Drawing.Size(88, 13);
            this.lblPaymentCode.TabIndex = 0;
            this.lblPaymentCode.Text = "Payment code";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblToDate.Location = new System.Drawing.Point(299, 20);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 6;
            this.lblToDate.Text = "To Date";
            // 
            // dtpTodate
            // 
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(373, 36);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(21, 21);
            this.dtpTodate.TabIndex = 9;
            this.dtpTodate.TabStop = false;
            this.dtpTodate.Tag = "Select to date;";
            this.dtpTodate.CloseUp += new System.EventHandler(this.dtpTodate_CloseUp);
            // 
            // txtTodate
            // 
            this.txtTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodate.Location = new System.Drawing.Point(303, 36);
            this.txtTodate.MaxLength = 50;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Size = new System.Drawing.Size(71, 21);
            this.txtTodate.TabIndex = 8;
            this.txtTodate.Tag = "Enter to date;";
            this.txtTodate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromDate_KeyPress);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(204, 20);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 13);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(276, 36);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(21, 21);
            this.dtpFromDate.TabIndex = 7;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Tag = "Select from date;";
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(205, 36);
            this.txtFromDate.MaxLength = 50;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(71, 21);
            this.txtFromDate.TabIndex = 5;
            this.txtFromDate.Tag = "Enter from date;";
            this.txtFromDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFromDate_KeyPress);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(702, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApply.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(621, 34);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 12;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(720, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(174, 454);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Click to delete selected Customer Payment;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(93, 454);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "Click to edit selected Customer Payment;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(12, 454);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "Click to add Customer Payment;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grpGrid
            // 
            this.grpGrid.Controls.Add(this.dgvCustomerPayment);
            this.grpGrid.Controls.Add(this.lblTotRec);
            this.grpGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGrid.Location = new System.Drawing.Point(12, 100);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(783, 348);
            this.grpGrid.TabIndex = 5;
            this.grpGrid.TabStop = false;
            // 
            // dgvCustomerPayment
            // 
            this.dgvCustomerPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReceiptCode,
            this.ReceiptID,
            this.ReceiptDate,
            this.CustomerCode,
            this.Customer,
            this.NetAmount,
            this.Narration});
            this.dgvCustomerPayment.Location = new System.Drawing.Point(7, 33);
            this.dgvCustomerPayment.Name = "dgvCustomerPayment";
            this.dgvCustomerPayment.Size = new System.Drawing.Size(770, 309);
            this.dgvCustomerPayment.TabIndex = 1;
            this.dgvCustomerPayment.Tag = "List of Customer Paymenting;";
            this.dgvCustomerPayment.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCustomerPayment_CellPainting);
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTotRec.Location = new System.Drawing.Point(4, 12);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(87, 18);
            this.lblTotRec.TabIndex = 0;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // ReceiptCode
            // 
            this.ReceiptCode.HeaderText = "Receipt Code";
            this.ReceiptCode.Name = "ReceiptCode";
            // 
            // ReceiptID
            // 
            this.ReceiptID.HeaderText = "ReceiptID";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.Visible = false;
            // 
            // ReceiptDate
            // 
            this.ReceiptDate.HeaderText = "Receipt Date";
            this.ReceiptDate.Name = "ReceiptDate";
            // 
            // CustomerCode
            // 
            this.CustomerCode.HeaderText = "Customer Code";
            this.CustomerCode.Name = "CustomerCode";
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // Narration
            // 
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            // 
            // frmCustomerPaymentList
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(807, 511);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grpGrid);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.tools);
            this.Name = "frmCustomerPaymentList";
            this.Text = "Customer Payment";
            this.Load += new System.EventHandler(this.frmCustomerPaymentList_Load);
            this.Controls.SetChildIndex(this.tools, 0);
            this.Controls.SetChildIndex(this.grpFilter, 0);
            this.Controls.SetChildIndex(this.grpGrid, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpGrid.ResumeLayout(false);
            this.grpGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerPayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip tools;
        internal System.Windows.Forms.ToolStripDropDownButton toolsReports;
        internal System.Windows.Forms.ToolStripMenuItem mnuDeliveryChallanRegister;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.TextBox txtTodate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtPaymentCode;
        private System.Windows.Forms.Label lblPaymentCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvCustomerPayment;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;

    }
}
