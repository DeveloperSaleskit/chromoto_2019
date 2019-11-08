namespace Account.GUI.Quotation
{
    partial class frmQuotationList
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.grpGrid = new System.Windows.Forms.GroupBox();
            this.dgvFollwUps = new System.Windows.Forms.DataGridView();
            this.FollowupByName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FollowupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadFollowUpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSaleList = new System.Windows.Forms.DataGridView();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cmbreports = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFollowUp = new System.Windows.Forms.Button();
            this.btnrevisedquotation = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbIsQuoWithTaxes = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakenBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocatedTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FollowupDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeadNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuotationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Is_SendMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollwUps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(1194, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(214, 21);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Click to delete selected Quotation;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(113, 21);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "Click to edit selected Quotation;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(2, 21);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "Click to add Quotation;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grpGrid
            // 
            this.grpGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGrid.Controls.Add(this.dgvFollwUps);
            this.grpGrid.Controls.Add(this.dgvSaleList);
            this.grpGrid.Controls.Add(this.lblTotRec);
            this.grpGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGrid.Location = new System.Drawing.Point(6, 71);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(1354, 647);
            this.grpGrid.TabIndex = 28;
            this.grpGrid.TabStop = false;
            // 
            // dgvFollwUps
            // 
            this.dgvFollwUps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFollwUps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFollwUps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FollowupByName,
            this.FollowupDate,
            this.LeadFollowUpId,
            this.Remarks});
            this.dgvFollwUps.Location = new System.Drawing.Point(959, 33);
            this.dgvFollwUps.Name = "dgvFollwUps";
            this.dgvFollwUps.Size = new System.Drawing.Size(389, 608);
            this.dgvFollwUps.TabIndex = 1;
            this.dgvFollwUps.Tag = "List of follow ups;";
            this.dgvFollwUps.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvFollwUps_CellPainting);
            this.dgvFollwUps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFollwUps_CellContentClick);
            // 
            // FollowupByName
            // 
            this.FollowupByName.HeaderText = "Followup By";
            this.FollowupByName.Name = "FollowupByName";
            this.FollowupByName.ReadOnly = true;
            // 
            // FollowupDate
            // 
            this.FollowupDate.HeaderText = "Followup Date";
            this.FollowupDate.Name = "FollowupDate";
            // 
            // LeadFollowUpId
            // 
            this.LeadFollowUpId.HeaderText = "LeadFollowUpId";
            this.LeadFollowUpId.Name = "LeadFollowUpId";
            this.LeadFollowUpId.ReadOnly = true;
            this.LeadFollowUpId.Visible = false;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // dgvSaleList
            // 
            this.dgvSaleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSaleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSaleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.QDate,
            this.CustomerName,
            this.TotalAmount,
            this.ContactPerson,
            this.Mobile,
            this.Phone1,
            this.Email,
            this.Category,
            this.Status,
            this.Remark,
            this.TakenBy,
            this.AllocatedTo,
            this.FollowupDate1,
            this.Date,
            this.PendingAmount,
            this.LeadID,
            this.TypeOfSale,
            this.LeadNo,
            this.QuotationId,
            this.Is_SendMail,
            this.CompId});
            this.dgvSaleList.Location = new System.Drawing.Point(7, 33);
            this.dgvSaleList.Name = "dgvSaleList";
            this.dgvSaleList.ReadOnly = true;
            this.dgvSaleList.Size = new System.Drawing.Size(946, 608);
            this.dgvSaleList.TabIndex = 0;
            this.dgvSaleList.Tag = "List of Quotation;";
            this.dgvSaleList.MouseHover += new System.EventHandler(this.dgvSaleList_MouseHover);
            this.dgvSaleList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvVendorPayment_CellPainting);
            this.dgvSaleList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSaleList_DataBindingComplete);
            this.dgvSaleList.SelectionChanged += new System.EventHandler(this.dgvSaleList_SelectionChanged);
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRec.Location = new System.Drawing.Point(4, 12);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(96, 18);
            this.lblTotRec.TabIndex = 0;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(1109, 27);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApply.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(139, 21);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(108, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = " Report Filter";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Visible = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnHelp.Location = new System.Drawing.Point(1266, 27);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(77, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Tag = "Click to Download Help File of  Customer;";
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cmbreports
            // 
            this.cmbreports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbreports.FormattingEnabled = true;
            this.cmbreports.Location = new System.Drawing.Point(139, 22);
            this.cmbreports.Name = "cmbreports";
            this.cmbreports.Size = new System.Drawing.Size(265, 21);
            this.cmbreports.TabIndex = 1;
            this.cmbreports.Tag = "Select city;@";
            this.cmbreports.SelectedIndexChanged += new System.EventHandler(this.cmbreports_SelectedIndexChanged);
            this.cmbreports.Click += new System.EventHandler(this.cmbreports_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFollowUp);
            this.groupBox1.Controls.Add(this.btnrevisedquotation);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(543, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnFollowUp
            // 
            this.btnFollowUp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnFollowUp.Location = new System.Drawing.Point(429, 21);
            this.btnFollowUp.Name = "btnFollowUp";
            this.btnFollowUp.Size = new System.Drawing.Size(108, 23);
            this.btnFollowUp.TabIndex = 4;
            this.btnFollowUp.Tag = "Click to followup;";
            this.btnFollowUp.Text = "Next Follow up";
            this.btnFollowUp.UseVisualStyleBackColor = true;
            this.btnFollowUp.Click += new System.EventHandler(this.btnFollowUp_Click);
            // 
            // btnrevisedquotation
            // 
            this.btnrevisedquotation.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnrevisedquotation.Location = new System.Drawing.Point(304, 22);
            this.btnrevisedquotation.Name = "btnrevisedquotation";
            this.btnrevisedquotation.Size = new System.Drawing.Size(119, 23);
            this.btnrevisedquotation.TabIndex = 3;
            this.btnrevisedquotation.Tag = "Click to  Selected Quotation;";
            this.btnrevisedquotation.Text = "Revised Quotation";
            this.btnrevisedquotation.UseVisualStyleBackColor = true;
            this.btnrevisedquotation.Click += new System.EventHandler(this.btnrevisedquotation_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbIsQuoWithTaxes);
            this.groupBox2.Controls.Add(this.cmbreports);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Location = new System.Drawing.Point(681, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(415, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbIsQuoWithTaxes
            // 
            this.cbIsQuoWithTaxes.AutoSize = true;
            this.cbIsQuoWithTaxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsQuoWithTaxes.Location = new System.Drawing.Point(26, 25);
            this.cbIsQuoWithTaxes.Name = "cbIsQuoWithTaxes";
            this.cbIsQuoWithTaxes.Size = new System.Drawing.Size(92, 17);
            this.cbIsQuoWithTaxes.TabIndex = 3;
            this.cbIsQuoWithTaxes.Tag = "Select Taxation Option;";
            this.cbIsQuoWithTaxes.Text = "With Taxation";
            this.cbIsQuoWithTaxes.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(556, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 59);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search By";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "Click to apply filter;";
            this.button1.Text = " Report Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // Code
            // 
            this.Code.HeaderText = "Quot. No";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // QDate
            // 
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            dataGridViewCellStyle1.NullValue = null;
            this.QDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.QDate.HeaderText = "Quotation Date";
            this.QDate.Name = "QDate";
            this.QDate.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Company Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "Quotation Amount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // ContactPerson
            // 
            this.ContactPerson.HeaderText = "Contact Person";
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // Phone1
            // 
            this.Phone1.HeaderText = "Phone";
            this.Phone1.Name = "Phone1";
            this.Phone1.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // TakenBy
            // 
            this.TakenBy.HeaderText = "TakenBy";
            this.TakenBy.Name = "TakenBy";
            this.TakenBy.ReadOnly = true;
            // 
            // AllocatedTo
            // 
            this.AllocatedTo.HeaderText = "AllocatedTo";
            this.AllocatedTo.Name = "AllocatedTo";
            this.AllocatedTo.ReadOnly = true;
            // 
            // FollowupDate1
            // 
            this.FollowupDate1.HeaderText = "Followup Date";
            this.FollowupDate1.Name = "FollowupDate1";
            this.FollowupDate1.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Visible = false;
            // 
            // PendingAmount
            // 
            this.PendingAmount.HeaderText = "Pending Amount";
            this.PendingAmount.Name = "PendingAmount";
            this.PendingAmount.ReadOnly = true;
            this.PendingAmount.Visible = false;
            // 
            // LeadID
            // 
            this.LeadID.HeaderText = "LeadID";
            this.LeadID.Name = "LeadID";
            this.LeadID.ReadOnly = true;
            this.LeadID.Visible = false;
            // 
            // TypeOfSale
            // 
            this.TypeOfSale.HeaderText = "TypeOfSale";
            this.TypeOfSale.Name = "TypeOfSale";
            this.TypeOfSale.ReadOnly = true;
            this.TypeOfSale.Visible = false;
            // 
            // LeadNo
            // 
            this.LeadNo.HeaderText = "Inquiry No";
            this.LeadNo.Name = "LeadNo";
            this.LeadNo.ReadOnly = true;
            this.LeadNo.Visible = false;
            // 
            // QuotationId
            // 
            this.QuotationId.HeaderText = "QuotationId";
            this.QuotationId.Name = "QuotationId";
            this.QuotationId.ReadOnly = true;
            this.QuotationId.Visible = false;
            // 
            // Is_SendMail
            // 
            this.Is_SendMail.HeaderText = "MailStatus";
            this.Is_SendMail.Name = "Is_SendMail";
            this.Is_SendMail.ReadOnly = true;
            this.Is_SendMail.Visible = false;
            // 
            // CompId
            // 
            this.CompId.HeaderText = "CompId";
            this.CompId.Name = "CompId";
            this.CompId.ReadOnly = true;
            this.CompId.Visible = false;
            // 
            // frmQuotationList
            // 
            this.AcceptButton = this.btnNew;
            this.AutoScroll = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1372, 752);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpGrid);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmQuotationList";
            this.Text = "Quotation List";
            this.Load += new System.EventHandler(this.frmQuotationList_Load);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.grpGrid, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.grpGrid.ResumeLayout(false);
            this.grpGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFollwUps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSaleList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvSaleList;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView dgvFollwUps;
        private System.Windows.Forms.DataGridViewTextBoxColumn FollowupByName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FollowupDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadFollowUpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.Button btnHelp;
        internal System.Windows.Forms.ComboBox cmbreports;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFollowUp;
        private System.Windows.Forms.Button btnrevisedquotation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbIsQuoWithTaxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn QDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakenBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocatedTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FollowupDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeadNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuotationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Is_SendMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompId;
    }
}
