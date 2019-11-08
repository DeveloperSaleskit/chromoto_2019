namespace Account.GUI.Lead
{
    partial class frmLeadFilter
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
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbEmpAllocatedTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbInterestLevel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbAttendedBy = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbSI = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
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
            this.grpErrorZone.Size = new System.Drawing.Size(360, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(348, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.cmbState);
            this.grpData.Controls.Add(this.label9);
            this.grpData.Controls.Add(this.cmbEmpAllocatedTo);
            this.grpData.Controls.Add(this.label7);
            this.grpData.Controls.Add(this.label12);
            this.grpData.Controls.Add(this.cmbInterestLevel);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.cmbCategory);
            this.grpData.Controls.Add(this.label13);
            this.grpData.Controls.Add(this.txtPhone1);
            this.grpData.Controls.Add(this.label5);
            this.grpData.Controls.Add(this.cmbAttendedBy);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.cmbCity);
            this.grpData.Controls.Add(this.cmbSI);
            this.grpData.Controls.Add(this.lblStatus);
            this.grpData.Controls.Add(this.lblCustomer);
            this.grpData.Controls.Add(this.txtCustomerName);
            this.grpData.Controls.Add(this.dtpTodate);
            this.grpData.Controls.Add(this.txtTodate);
            this.grpData.Controls.Add(this.lblToDate);
            this.grpData.Controls.Add(this.dtpFromDate);
            this.grpData.Controls.Add(this.txtFromDate);
            this.grpData.Controls.Add(this.lblFromDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(360, 312);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(261, 243);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(83, 21);
            this.cmbState.TabIndex = 11;
            this.cmbState.Tag = "Select city;@";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(221, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 297;
            this.label9.Text = "State";
            // 
            // cmbEmpAllocatedTo
            // 
            this.cmbEmpAllocatedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpAllocatedTo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpAllocatedTo.FormattingEnabled = true;
            this.cmbEmpAllocatedTo.Location = new System.Drawing.Point(126, 216);
            this.cmbEmpAllocatedTo.Name = "cmbEmpAllocatedTo";
            this.cmbEmpAllocatedTo.Size = new System.Drawing.Size(218, 21);
            this.cmbEmpAllocatedTo.TabIndex = 9;
            this.cmbEmpAllocatedTo.Tag = "Select Employee;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 219);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 282;
            this.label7.Text = "Allocated to";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(17, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 13);
            this.label12.TabIndex = 281;
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
            this.cmbInterestLevel.Location = new System.Drawing.Point(126, 270);
            this.cmbInterestLevel.Name = "cmbInterestLevel";
            this.cmbInterestLevel.Size = new System.Drawing.Size(218, 21);
            this.cmbInterestLevel.TabIndex = 12;
            this.cmbInterestLevel.Tag = "Select interest level;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(58, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 279;
            this.label4.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(44, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 277;
            this.label2.Text = "Of Inqiry";
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
            this.cmbCategory.Location = new System.Drawing.Point(126, 135);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(217, 21);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.Tag = "Select source of Inquiry;@";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(41, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 275;
            this.label13.Text = "Category";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone1.Location = new System.Drawing.Point(126, 108);
            this.txtPhone1.MaxLength = 20;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(218, 21);
            this.txtPhone1.TabIndex = 5;
            this.txtPhone1.Tag = "Enter Mobile No;";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(39, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 274;
            this.label5.Text = "Mobile No";
            // 
            // cmbAttendedBy
            // 
            this.cmbAttendedBy.FormattingEnabled = true;
            this.cmbAttendedBy.Location = new System.Drawing.Point(126, 189);
            this.cmbAttendedBy.Name = "cmbAttendedBy";
            this.cmbAttendedBy.Size = new System.Drawing.Size(218, 21);
            this.cmbAttendedBy.TabIndex = 8;
            this.cmbAttendedBy.Tag = "Select Attended By;";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(71, 247);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 270;
            this.lblCity.Text = "City";
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(126, 243);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(87, 21);
            this.cmbCity.TabIndex = 10;
            this.cmbCity.Tag = "Select city;@";
            // 
            // cmbSI
            // 
            this.cmbSI.FormattingEnabled = true;
            this.cmbSI.Location = new System.Drawing.Point(126, 162);
            this.cmbSI.Name = "cmbSI";
            this.cmbSI.Size = new System.Drawing.Size(218, 21);
            this.cmbSI.TabIndex = 7;
            this.cmbSI.Tag = "Select status;";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblStatus.Location = new System.Drawing.Point(54, 159);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "Source";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCustomer.Location = new System.Drawing.Point(38, 25);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(63, 13);
            this.lblCustomer.TabIndex = 13;
            this.lblCustomer.Text = "Customer";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(126, 22);
            this.txtCustomerName.MaxLength = 50;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(218, 21);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.Tag = "Enter customer;";
            // 
            // dtpTodate
            // 
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(321, 76);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(21, 21);
            this.dtpTodate.TabIndex = 4;
            this.dtpTodate.TabStop = false;
            this.dtpTodate.Tag = "Select to date;";
            this.dtpTodate.CloseUp += new System.EventHandler(this.dtpTodate_CloseUp);
            // 
            // txtTodate
            // 
            this.txtTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodate.Location = new System.Drawing.Point(126, 81);
            this.txtTodate.MaxLength = 50;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Size = new System.Drawing.Size(191, 21);
            this.txtTodate.TabIndex = 3;
            this.txtTodate.Tag = "Enter to date;";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblToDate.Location = new System.Drawing.Point(49, 84);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 7;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(321, 47);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(21, 21);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Tag = "Select from date;";
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(126, 49);
            this.txtFromDate.MaxLength = 50;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(191, 21);
            this.txtFromDate.TabIndex = 1;
            this.txtFromDate.Tag = "Enter from date;";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(34, 53);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 13);
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = "From Date";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(84, 381);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(207, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmLeadFilter
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(382, 436);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmLeadFilter";
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
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ComboBox cmbSI;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbAttendedBy;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbCity;
        internal System.Windows.Forms.TextBox txtPhone1;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbInterestLevel;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cmbEmpAllocatedTo;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox cmbState;
        internal System.Windows.Forms.Label label9;
    }
}
