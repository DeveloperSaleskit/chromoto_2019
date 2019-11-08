namespace Account.DefaultLayout
{
    partial class frmCustPendingList
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
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalPendingAmt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.cmbreports = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.SalesCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnRegenrate.Location = new System.Drawing.Point(6, 16);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(176, 30);
            this.btnRegenrate.TabIndex = 5;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to refresh vendor pending payment list;";
            this.btnRegenrate.Text = "Refresh";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Total Pending Amount:";
            // 
            // txtTotalPendingAmt
            // 
            this.txtTotalPendingAmt.Enabled = false;
            this.txtTotalPendingAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPendingAmt.Location = new System.Drawing.Point(399, 14);
            this.txtTotalPendingAmt.Name = "txtTotalPendingAmt";
            this.txtTotalPendingAmt.ReadOnly = true;
            this.txtTotalPendingAmt.Size = new System.Drawing.Size(520, 20);
            this.txtTotalPendingAmt.TabIndex = 8;
            this.txtTotalPendingAmt.Tag = "Total Pending Amount;";
            this.txtTotalPendingAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSendMail);
            this.groupBox2.Controls.Add(this.cmbreports);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.btnRegenrate);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(925, 55);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Send AutoMail && Filter && Report Selection ";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMail.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendMail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.Location = new System.Drawing.Point(743, 16);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(176, 30);
            this.btnSendMail.TabIndex = 43;
            this.btnSendMail.Tag = "Click to Send Mail;";
            this.btnSendMail.Text = "Send Mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // cmbreports
            // 
            this.cmbreports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbreports.FormattingEnabled = true;
            this.cmbreports.Location = new System.Drawing.Point(370, 20);
            this.cmbreports.Name = "cmbreports";
            this.cmbreports.Size = new System.Drawing.Size(352, 21);
            this.cmbreports.TabIndex = 42;
            this.cmbreports.Tag = "Select city;@";
            this.cmbreports.SelectedIndexChanged += new System.EventHandler(this.cmbreports_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApply.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(188, 16);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(176, 30);
            this.btnApply.TabIndex = 5;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = " Report Filter";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRec.Location = new System.Drawing.Point(6, 14);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(96, 18);
            this.lblTotRec.TabIndex = 46;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvContacts);
            this.groupBox1.Controls.Add(this.lblTotRec);
            this.groupBox1.Controls.Add(this.txtTotalPendingAmt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(925, 536);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // dgvContacts
            // 
            this.dgvContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContacts.BackgroundColor = System.Drawing.Color.White;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SalesCode,
            this.ReceiptCode,
            this.CustomerName,
            this.PendingAmount,
            this.NetAmount,
            this.DueDate,
            this.ContactPerson,
            this.Mobile,
            this.Email,
            this.RecDay,
            this.DueDays,
            this.CustomerCode,
            this.CompId});
            this.dgvContacts.Location = new System.Drawing.Point(6, 41);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.Size = new System.Drawing.Size(913, 489);
            this.dgvContacts.TabIndex = 0;
            this.dgvContacts.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvContacts_CellPainting);
            // 
            // SalesCode
            // 
            this.SalesCode.HeaderText = "Sales Code";
            this.SalesCode.Name = "SalesCode";
            // 
            // ReceiptCode
            // 
            this.ReceiptCode.HeaderText = "ReceiptCode";
            this.ReceiptCode.Name = "ReceiptCode";
            this.ReceiptCode.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // PendingAmount
            // 
            this.PendingAmount.HeaderText = "Pending Amount";
            this.PendingAmount.Name = "PendingAmount";
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            // 
            // ContactPerson
            // 
            this.ContactPerson.HeaderText = "ContactPerson";
            this.ContactPerson.Name = "ContactPerson";
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // RecDay
            // 
            this.RecDay.HeaderText = "RecDay";
            this.RecDay.Name = "RecDay";
            this.RecDay.Visible = false;
            // 
            // DueDays
            // 
            this.DueDays.HeaderText = "DueDays";
            this.DueDays.Name = "DueDays";
            this.DueDays.Visible = false;
            // 
            // CustomerCode
            // 
            this.CustomerCode.HeaderText = "Cust Code";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerCode.Visible = false;
            // 
            // CompId
            // 
            this.CompId.HeaderText = "CompId";
            this.CompId.Name = "CompId";
            this.CompId.Visible = false;
            // 
            // frmCustPendingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(949, 611);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCustPendingList";
            this.Text = "Customer Pending Payment List";
            this.Load += new System.EventHandler(this.frmContacts_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRegenrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPendingAmt;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.ComboBox cmbreports;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompId;

    }
}