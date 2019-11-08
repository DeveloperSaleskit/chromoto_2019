namespace Account.GUI.PromoMail
{
    partial class frmPromoMailEntry
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtPMID = new System.Windows.Forms.TextBox();
            this.dgvPromoSend = new System.Windows.Forms.DataGridView();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddRec = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtPMail = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dgvFile = new System.Windows.Forms.DataGridView();
            this.OpenFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteDoc = new System.Windows.Forms.Button();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.ErrName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.ErrUserName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtEditPMail = new System.Windows.Forms.TextBox();
            this.txtPMobile = new System.Windows.Forms.TextBox();
            this.txtPCategory = new System.Windows.Forms.TextBox();
            this.txtFileCount = new System.Windows.Forms.TextBox();
            this.txtPCustomer = new System.Windows.Forms.TextBox();
            this.txtEditPCustomer = new System.Windows.Forms.TextBox();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromoSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(587, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExit.Location = new System.Drawing.Point(455, 495);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(126, 23);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to send && exit;";
            this.btnSaveExit.Text = "Send && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(708, 39);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(484, 14);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(538, 15);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(112, 13);
            this.lblrequired.TabIndex = 12;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.txtPMID);
            this.grpData.Controls.Add(this.dgvPromoSend);
            this.grpData.Controls.Add(this.btnAddRec);
            this.grpData.Controls.Add(this.txtSubject);
            this.grpData.Controls.Add(this.txtPMail);
            this.grpData.Controls.Add(this.lblTo);
            this.grpData.Controls.Add(this.dgvFile);
            this.grpData.Controls.Add(this.btnDeleteDoc);
            this.grpData.Controls.Add(this.txtFooter);
            this.grpData.Controls.Add(this.btnAddDoc);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.btnBrowse);
            this.grpData.Controls.Add(this.ErrName);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.txtDocName);
            this.grpData.Controls.Add(this.txtHeader);
            this.grpData.Controls.Add(this.lblName);
            this.grpData.Controls.Add(this.ErrUserName);
            this.grpData.Controls.Add(this.lblUserName);
            this.grpData.Controls.Add(this.txtEditPMail);
            this.grpData.Controls.Add(this.txtPMobile);
            this.grpData.Controls.Add(this.txtPCategory);
            this.grpData.Controls.Add(this.txtFileCount);
            this.grpData.Controls.Add(this.txtPCustomer);
            this.grpData.Controls.Add(this.txtEditPCustomer);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 44);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(708, 445);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtPMID
            // 
            this.txtPMID.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMID.Location = new System.Drawing.Point(9, 56);
            this.txtPMID.Name = "txtPMID";
            this.txtPMID.Size = new System.Drawing.Size(68, 21);
            this.txtPMID.TabIndex = 237;
            this.txtPMID.Tag = "Enter contactperson;";
            this.txtPMID.Visible = false;
            // 
            // dgvPromoSend
            // 
            this.dgvPromoSend.AllowUserToAddRows = false;
            this.dgvPromoSend.AllowUserToDeleteRows = false;
            this.dgvPromoSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromoSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerName,
            this.Email,
            this.Mobile,
            this.Category});
            this.dgvPromoSend.Location = new System.Drawing.Point(86, 15);
            this.dgvPromoSend.Name = "dgvPromoSend";
            this.dgvPromoSend.RowTemplate.Height = 24;
            this.dgvPromoSend.Size = new System.Drawing.Size(509, 85);
            this.dgvPromoSend.TabIndex = 0;
            this.dgvPromoSend.Tag = "List of document;";
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 124;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // btnAddRec
            // 
            this.btnAddRec.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnAddRec.Location = new System.Drawing.Point(601, 16);
            this.btnAddRec.Name = "btnAddRec";
            this.btnAddRec.Size = new System.Drawing.Size(74, 84);
            this.btnAddRec.TabIndex = 1;
            this.btnAddRec.Tag = "Click to Add;";
            this.btnAddRec.Text = "Add";
            this.btnAddRec.UseVisualStyleBackColor = true;
            this.btnAddRec.Click += new System.EventHandler(this.btnAddRec_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(86, 106);
            this.txtSubject.MaxLength = 1500;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(589, 21);
            this.txtSubject.TabIndex = 2;
            this.txtSubject.Tag = "Enter Mail Subject;@";
            // 
            // txtPMail
            // 
            this.txtPMail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMail.Location = new System.Drawing.Point(411, 166);
            this.txtPMail.Name = "txtPMail";
            this.txtPMail.Size = new System.Drawing.Size(253, 21);
            this.txtPMail.TabIndex = 233;
            this.txtPMail.Tag = "Enter PMail;";
            this.txtPMail.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.Black;
            this.lblTo.Location = new System.Drawing.Point(51, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 13);
            this.lblTo.TabIndex = 228;
            this.lblTo.Text = "To:";
            // 
            // dgvFile
            // 
            this.dgvFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OpenFile,
            this.DocID,
            this.FileName,
            this.FullFileName});
            this.dgvFile.Location = new System.Drawing.Point(86, 344);
            this.dgvFile.Name = "dgvFile";
            this.dgvFile.RowTemplate.Height = 24;
            this.dgvFile.Size = new System.Drawing.Size(509, 74);
            this.dgvFile.TabIndex = 8;
            this.dgvFile.Tag = "List of document;";
            this.dgvFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFile_CellClick);
            // 
            // OpenFile
            // 
            this.OpenFile.HeaderText = "View File";
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.OpenFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.OpenFile.Text = "Open File";
            // 
            // DocID
            // 
            this.DocID.HeaderText = "DocID";
            this.DocID.Name = "DocID";
            this.DocID.Visible = false;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            // 
            // FullFileName
            // 
            this.FullFileName.HeaderText = "FullFileName";
            this.FullFileName.Name = "FullFileName";
            this.FullFileName.Visible = false;
            // 
            // btnDeleteDoc
            // 
            this.btnDeleteDoc.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDeleteDoc.Location = new System.Drawing.Point(601, 386);
            this.btnDeleteDoc.Name = "btnDeleteDoc";
            this.btnDeleteDoc.Size = new System.Drawing.Size(74, 24);
            this.btnDeleteDoc.TabIndex = 9;
            this.btnDeleteDoc.Tag = "Click to Delete;";
            this.btnDeleteDoc.Text = "Delete";
            this.btnDeleteDoc.UseVisualStyleBackColor = true;
            this.btnDeleteDoc.Click += new System.EventHandler(this.btnDeleteDoc_Click);
            // 
            // txtFooter
            // 
            this.txtFooter.Location = new System.Drawing.Point(86, 224);
            this.txtFooter.MaxLength = 4000;
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFooter.Size = new System.Drawing.Size(589, 85);
            this.txtFooter.TabIndex = 4;
            this.txtFooter.Tag = "Enter Footer Part of Mail Body;@";
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnAddDoc.Location = new System.Drawing.Point(601, 356);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(74, 24);
            this.btnAddDoc.TabIndex = 7;
            this.btnAddDoc.Tag = "Click to Add;";
            this.btnAddDoc.Text = "Add";
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Footer :";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowse.Location = new System.Drawing.Point(600, 318);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 24);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Tag = "Click to browse;";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ErrName
            // 
            this.ErrName.AutoSize = true;
            this.ErrName.ForeColor = System.Drawing.Color.Red;
            this.ErrName.Location = new System.Drawing.Point(681, 137);
            this.ErrName.Name = "ErrName";
            this.ErrName.Size = new System.Drawing.Size(15, 13);
            this.ErrName.TabIndex = 11;
            this.ErrName.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(51, 324);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "File:";
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocName.Location = new System.Drawing.Point(86, 318);
            this.txtDocName.MaxLength = 100;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(509, 21);
            this.txtDocName.TabIndex = 5;
            this.txtDocName.Tag = "Select Document;";
            // 
            // txtHeader
            // 
            this.txtHeader.AcceptsReturn = true;
            this.txtHeader.Location = new System.Drawing.Point(86, 133);
            this.txtHeader.MaxLength = 4000;
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHeader.Size = new System.Drawing.Size(589, 85);
            this.txtHeader.TabIndex = 3;
            this.txtHeader.Tag = "Enter Header Part of Mail Body;@";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(16, 169);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Header :";
            // 
            // ErrUserName
            // 
            this.ErrUserName.AutoSize = true;
            this.ErrUserName.ForeColor = System.Drawing.Color.Red;
            this.ErrUserName.Location = new System.Drawing.Point(681, 107);
            this.ErrUserName.Name = "ErrUserName";
            this.ErrUserName.Size = new System.Drawing.Size(15, 13);
            this.ErrUserName.TabIndex = 2;
            this.ErrUserName.Text = "*";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(16, 110);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Subject :";
            // 
            // txtEditPMail
            // 
            this.txtEditPMail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditPMail.Location = new System.Drawing.Point(570, 42);
            this.txtEditPMail.Name = "txtEditPMail";
            this.txtEditPMail.Size = new System.Drawing.Size(132, 21);
            this.txtEditPMail.TabIndex = 232;
            this.txtEditPMail.Tag = "Enter contactperson;";
            this.txtEditPMail.Visible = false;
            // 
            // txtPMobile
            // 
            this.txtPMobile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPMobile.Location = new System.Drawing.Point(600, 56);
            this.txtPMobile.Name = "txtPMobile";
            this.txtPMobile.Size = new System.Drawing.Size(96, 21);
            this.txtPMobile.TabIndex = 237;
            this.txtPMobile.Tag = "Enter PMail;";
            this.txtPMobile.Visible = false;
            // 
            // txtPCategory
            // 
            this.txtPCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCategory.Location = new System.Drawing.Point(601, 83);
            this.txtPCategory.Name = "txtPCategory";
            this.txtPCategory.Size = new System.Drawing.Size(95, 21);
            this.txtPCategory.TabIndex = 236;
            this.txtPCategory.Tag = "Enter contactperson;";
            this.txtPCategory.Visible = false;
            // 
            // txtFileCount
            // 
            this.txtFileCount.Location = new System.Drawing.Point(520, 322);
            this.txtFileCount.Name = "txtFileCount";
            this.txtFileCount.Size = new System.Drawing.Size(100, 21);
            this.txtFileCount.TabIndex = 231;
            this.txtFileCount.Tag = "Enter FileCount;";
            this.txtFileCount.Visible = false;
            // 
            // txtPCustomer
            // 
            this.txtPCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCustomer.Location = new System.Drawing.Point(520, 352);
            this.txtPCustomer.Name = "txtPCustomer";
            this.txtPCustomer.Size = new System.Drawing.Size(133, 21);
            this.txtPCustomer.TabIndex = 235;
            this.txtPCustomer.Tag = "Enter PMail;";
            this.txtPCustomer.Visible = false;
            // 
            // txtEditPCustomer
            // 
            this.txtEditPCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditPCustomer.Location = new System.Drawing.Point(520, 382);
            this.txtEditPCustomer.Name = "txtEditPCustomer";
            this.txtEditPCustomer.Size = new System.Drawing.Size(132, 21);
            this.txtEditPCustomer.TabIndex = 234;
            this.txtEditPCustomer.Tag = "Enter contactperson;";
            this.txtEditPCustomer.Visible = false;
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(14, 492);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(210, 26);
            this.lblDelMsg.TabIndex = 19;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveContinue.Location = new System.Drawing.Point(303, 495);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(142, 23);
            this.btnSaveContinue.TabIndex = 2;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Visible = false;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // frmPromoMailEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(732, 555);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPromoMailEntry";
            this.Load += new System.EventHandler(this.frmGodownEntry_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromoSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrUserName;
        private System.Windows.Forms.Label lblDelMsg;

        private System.Windows.Forms.Label ErrName;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFile;
        private System.Windows.Forms.Button btnDeleteDoc;
        private System.Windows.Forms.Button btnAddDoc;
        private System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.DataGridView dgvPromoSend;
        internal System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnAddRec;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.TextBox txtFileCount;
        internal System.Windows.Forms.TextBox txtEditPMail;
        internal System.Windows.Forms.TextBox txtPMail;
        internal System.Windows.Forms.TextBox txtPCustomer;
        internal System.Windows.Forms.TextBox txtEditPCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        internal System.Windows.Forms.TextBox txtPMobile;
        internal System.Windows.Forms.TextBox txtPCategory;
        private System.Windows.Forms.DataGridViewButtonColumn OpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullFileName;
        internal System.Windows.Forms.TextBox txtPMID;
    }
}
