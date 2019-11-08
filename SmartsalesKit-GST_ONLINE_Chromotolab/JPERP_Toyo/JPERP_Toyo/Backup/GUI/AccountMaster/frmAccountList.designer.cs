namespace Account.GUI.AccountMaster
{
    partial class frmAccountMasterList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountMasterList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClear = new System.Windows.Forms.Button();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolsReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.rptAccountRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.accountLedgerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.AccountCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcountType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.btnReportFilter = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(9, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(225)))));
            this.tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsReports});
            this.tools.Location = new System.Drawing.Point(1, 1);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(911, 25);
            this.tools.TabIndex = 20;
            this.tools.Text = "ToolStrip1";
            this.tools.Visible = false;
            // 
            // toolsReports
            // 
            this.toolsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rptAccountRegister,
            this.accountLedgerToolStripMenuItem});
            this.toolsReports.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolsReports.Image = ((System.Drawing.Image)(resources.GetObject("toolsReports.Image")));
            this.toolsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsReports.Name = "toolsReports";
            this.toolsReports.Size = new System.Drawing.Size(58, 22);
            this.toolsReports.Tag = "View report;";
            this.toolsReports.Text = "Reports";
            // 
            // rptAccountRegister
            // 
            this.rptAccountRegister.Name = "rptAccountRegister";
            this.rptAccountRegister.Size = new System.Drawing.Size(156, 22);
            this.rptAccountRegister.Text = "Account Register";
            this.rptAccountRegister.Visible = false;
            this.rptAccountRegister.Click += new System.EventHandler(this.rptAccountMasterRegister_Click);
            // 
            // accountLedgerToolStripMenuItem
            // 
            this.accountLedgerToolStripMenuItem.Name = "accountLedgerToolStripMenuItem";
            this.accountLedgerToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.accountLedgerToolStripMenuItem.Text = "Account Ledger";
            this.accountLedgerToolStripMenuItem.Click += new System.EventHandler(this.accountLedgerToolStripMenuItem_Click);
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRec.Location = new System.Drawing.Point(12, 46);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(78, 17);
            this.lblTotRec.TabIndex = 14;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // dgvAccount
            // 
            this.dgvAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountCode,
            this.AccountID,
            this.AccountName,
            this.CrAmount,
            this.DBAmount,
            this.AccTypeID,
            this.AcountType,
            this.ContactPerson,
            this.Email});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAccount.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAccount.Location = new System.Drawing.Point(12, 66);
            this.dgvAccount.Name = "dgvAccount";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvAccount.Size = new System.Drawing.Size(1320, 393);
            this.dgvAccount.TabIndex = 15;
            this.dgvAccount.Tag = "List of account;";
            this.dgvAccount.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAccountMaster_CellPainting);
            // 
            // AccountCode
            // 
            this.AccountCode.HeaderText = "Account Code";
            this.AccountCode.Name = "AccountCode";
            // 
            // AccountID
            // 
            this.AccountID.HeaderText = "AccountID";
            this.AccountID.Name = "AccountID";
            this.AccountID.Visible = false;
            // 
            // AccountName
            // 
            this.AccountName.HeaderText = "Account Name";
            this.AccountName.Name = "AccountName";
            // 
            // CrAmount
            // 
            this.CrAmount.HeaderText = "Cr Amount";
            this.CrAmount.Name = "CrAmount";
            this.CrAmount.Visible = false;
            // 
            // DBAmount
            // 
            this.DBAmount.HeaderText = "DB Amount";
            this.DBAmount.Name = "DBAmount";
            this.DBAmount.Visible = false;
            // 
            // AccTypeID
            // 
            this.AccTypeID.HeaderText = "AccTypeID";
            this.AccTypeID.Name = "AccTypeID";
            this.AccTypeID.Visible = false;
            // 
            // AcountType
            // 
            this.AcountType.HeaderText = "Acount Type";
            this.AcountType.Name = "AcountType";
            // 
            // ContactPerson
            // 
            this.ContactPerson.HeaderText = "ContactPerson";
            this.ContactPerson.Name = "ContactPerson";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(28, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Click to delete selected account;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(122, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(96, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(67, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "Click to edit selected account;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(169, 14);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "Click to add account;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cmbReports);
            this.groupBox3.Controls.Add(this.btnReportFilter);
            this.groupBox3.Location = new System.Drawing.Point(312, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(309, 52);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Format Selection";
            // 
            // cmbReports
            // 
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(115, 20);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(182, 21);
            this.cmbReports.TabIndex = 1;
            this.cmbReports.Tag = "Select city;@";
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // btnReportFilter
            // 
            this.btnReportFilter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReportFilter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportFilter.Location = new System.Drawing.Point(3, 19);
            this.btnReportFilter.Name = "btnReportFilter";
            this.btnReportFilter.Size = new System.Drawing.Size(106, 23);
            this.btnReportFilter.TabIndex = 0;
            this.btnReportFilter.Tag = "Click to apply filter;";
            this.btnReportFilter.Text = "Report Filter";
            this.btnReportFilter.UseVisualStyleBackColor = true;
            this.btnReportFilter.Click += new System.EventHandler(this.btnReportFilter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Location = new System.Drawing.Point(1065, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 47);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Other";
            // 
            // frmAccountMasterList
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1351, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvAccount);
            this.Controls.Add(this.lblTotRec);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Name = "frmAccountMasterList";
            this.Text = "Account";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAccountMasterList_Load);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.tools, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.lblTotRec, 0);
            this.Controls.SetChildIndex(this.dgvAccount, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.ToolStrip tools;
        internal System.Windows.Forms.ToolStripDropDownButton toolsReports;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolStripMenuItem rptAccountRegister;
        private System.Windows.Forms.ToolStripMenuItem accountLedgerToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Button btnReportFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
