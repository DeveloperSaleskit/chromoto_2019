namespace Account.GUI.Quotation
{
    partial class frmQuotationFilter
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
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNFTodate = new System.Windows.Forms.DateTimePicker();
            this.txtNFTodate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNFFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtNFFromDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEmpAllocatedTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbInterestLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEmp = new System.Windows.Forms.ComboBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.txtTodate = new System.Windows.Forms.TextBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(380, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(312, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.label5);
            this.grpData.Controls.Add(this.dtpNFTodate);
            this.grpData.Controls.Add(this.txtNFTodate);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.dtpNFFromDate);
            this.grpData.Controls.Add(this.txtNFFromDate);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.cmbEmpAllocatedTo);
            this.grpData.Controls.Add(this.label7);
            this.grpData.Controls.Add(this.label12);
            this.grpData.Controls.Add(this.cmbInterestLevel);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.cmbCategory);
            this.grpData.Controls.Add(this.label13);
            this.grpData.Controls.Add(this.txtPhone1);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.cmbEmp);
            this.grpData.Controls.Add(this.txtCustomer);
            this.grpData.Controls.Add(this.lblCustomer);
            this.grpData.Controls.Add(this.dtpTodate);
            this.grpData.Controls.Add(this.txtTodate);
            this.grpData.Controls.Add(this.lblToDate);
            this.grpData.Controls.Add(this.dtpFromDate);
            this.grpData.Controls.Add(this.txtFromDate);
            this.grpData.Controls.Add(this.lblFromDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(380, 315);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(71, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 292;
            this.label5.Text = "From Date";
            // 
            // dtpNFTodate
            // 
            this.dtpNFTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNFTodate.Location = new System.Drawing.Point(333, 240);
            this.dtpNFTodate.Name = "dtpNFTodate";
            this.dtpNFTodate.Size = new System.Drawing.Size(18, 21);
            this.dtpNFTodate.TabIndex = 291;
            this.dtpNFTodate.TabStop = false;
            this.dtpNFTodate.Tag = "Select to date;";
            // 
            // txtNFTodate
            // 
            this.txtNFTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNFTodate.Location = new System.Drawing.Point(161, 243);
            this.txtNFTodate.MaxLength = 50;
            this.txtNFTodate.Name = "txtNFTodate";
            this.txtNFTodate.Size = new System.Drawing.Size(165, 21);
            this.txtNFTodate.TabIndex = 8;
            this.txtNFTodate.Tag = "Enter to date;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(84, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 289;
            this.label1.Text = "To Date";
            // 
            // dtpNFFromDate
            // 
            this.dtpNFFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNFFromDate.Location = new System.Drawing.Point(331, 213);
            this.dtpNFFromDate.Name = "dtpNFFromDate";
            this.dtpNFFromDate.Size = new System.Drawing.Size(20, 21);
            this.dtpNFFromDate.TabIndex = 288;
            this.dtpNFFromDate.TabStop = false;
            this.dtpNFFromDate.Tag = "Select from date;";
            // 
            // txtNFFromDate
            // 
            this.txtNFFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNFFromDate.Location = new System.Drawing.Point(161, 216);
            this.txtNFFromDate.MaxLength = 50;
            this.txtNFFromDate.Name = "txtNFFromDate";
            this.txtNFFromDate.Size = new System.Drawing.Size(165, 21);
            this.txtNFFromDate.TabIndex = 7;
            this.txtNFFromDate.Tag = "Enter from date;";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(53, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 287;
            this.label3.Text = "Next Followup";
            // 
            // cmbEmpAllocatedTo
            // 
            this.cmbEmpAllocatedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpAllocatedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpAllocatedTo.FormattingEnabled = true;
            this.cmbEmpAllocatedTo.Location = new System.Drawing.Point(161, 189);
            this.cmbEmpAllocatedTo.Name = "cmbEmpAllocatedTo";
            this.cmbEmpAllocatedTo.Size = new System.Drawing.Size(189, 21);
            this.cmbEmpAllocatedTo.TabIndex = 6;
            this.cmbEmpAllocatedTo.Tag = "Select Employee;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(66, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 284;
            this.label7.Text = "Allocated to";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(55, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 283;
            this.label12.Text = "App taken By";
            // 
            // cmbInterestLevel
            // 
            this.cmbInterestLevel.FormattingEnabled = true;
            this.cmbInterestLevel.Items.AddRange(new object[] {
            "--Select--",
            "Hot",
            "Warm",
            "Cold",
            "INPROGRESS",
            "QUOTATION",
            "SALE"});
            this.cmbInterestLevel.Location = new System.Drawing.Point(161, 270);
            this.cmbInterestLevel.Name = "cmbInterestLevel";
            this.cmbInterestLevel.Size = new System.Drawing.Size(190, 21);
            this.cmbInterestLevel.TabIndex = 9;
            this.cmbInterestLevel.Tag = "Select interest level;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(96, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 282;
            this.label4.Text = "Status";
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
            this.cmbCategory.Location = new System.Drawing.Point(161, 135);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(189, 21);
            this.cmbCategory.TabIndex = 4;
            this.cmbCategory.Tag = "Select source of Inquiry;@";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(79, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 279;
            this.label13.Text = "Category";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone1.Location = new System.Drawing.Point(161, 108);
            this.txtPhone1.MaxLength = 20;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(190, 21);
            this.txtPhone1.TabIndex = 3;
            this.txtPhone1.Tag = "Enter Mobile No;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(77, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 278;
            this.label2.Text = "Mobile No";
            // 
            // cmbEmp
            // 
            this.cmbEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmp.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmp.FormattingEnabled = true;
            this.cmbEmp.Location = new System.Drawing.Point(161, 162);
            this.cmbEmp.Name = "cmbEmp";
            this.cmbEmp.Size = new System.Drawing.Size(190, 21);
            this.cmbEmp.TabIndex = 5;
            this.cmbEmp.Tag = "Select Employee Name;@";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(160, 25);
            this.txtCustomer.MaxLength = 15;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(191, 21);
            this.txtCustomer.TabIndex = 0;
            this.txtCustomer.Tag = "Enter customer;";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCustomer.Location = new System.Drawing.Point(72, 33);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 13);
            this.lblCustomer.TabIndex = 13;
            this.lblCustomer.Text = "Customer";
            // 
            // dtpTodate
            // 
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(333, 81);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(18, 21);
            this.dtpTodate.TabIndex = 9;
            this.dtpTodate.TabStop = false;
            this.dtpTodate.Tag = "Select to date;";
            this.dtpTodate.CloseUp += new System.EventHandler(this.dtpTodate_CloseUp);
            // 
            // txtTodate
            // 
            this.txtTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodate.Location = new System.Drawing.Point(161, 81);
            this.txtTodate.MaxLength = 50;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Size = new System.Drawing.Size(166, 21);
            this.txtTodate.TabIndex = 2;
            this.txtTodate.Tag = "Enter to date;";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblToDate.Location = new System.Drawing.Point(84, 84);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 7;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(331, 52);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(20, 21);
            this.dtpFromDate.TabIndex = 6;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Tag = "Select from date;";
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(160, 52);
            this.txtFromDate.MaxLength = 50;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(166, 21);
            this.txtFromDate.TabIndex = 1;
            this.txtFromDate.Tag = "Enter from date;";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(38, 55);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(102, 13);
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = "Quot. From Date";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(111, 384);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(192, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmQuotationFilter
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(405, 439);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmQuotationFilter";
            this.Load += new System.EventHandler(this.frmGodownEntry_Load);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnApply, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.TextBox txtTodate;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txtCustomer;
        internal System.Windows.Forms.ComboBox cmbEmp;
        private System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtPhone1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInterestLevel;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbEmpAllocatedTo;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpNFTodate;
        private System.Windows.Forms.TextBox txtNFTodate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNFFromDate;
        private System.Windows.Forms.TextBox txtNFFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
    }
}
