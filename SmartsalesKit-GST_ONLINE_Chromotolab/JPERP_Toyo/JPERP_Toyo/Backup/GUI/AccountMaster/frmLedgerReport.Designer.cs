namespace Account.GUI.AccountMaster
{
    partial class frmLedgerReport
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
            this.btnViewReport = new System.Windows.Forms.Button();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.ErrCompany = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(406, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnViewReport.Location = new System.Drawing.Point(304, 175);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(96, 23);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Tag = "Click to view report;";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 12);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(494, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(482, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(21, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(72, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "From Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(99, 53);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(93, 21);
            this.dtpDate.TabIndex = 5;
            this.dtpDate.Tag = "Select from date;";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.Black;
            this.lblAccountName.Location = new System.Drawing.Point(36, 29);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(57, 13);
            this.lblAccountName.TabIndex = 1;
            this.lblAccountName.Text = "Account:";
            // 
            // ErrCompany
            // 
            this.ErrCompany.AutoSize = true;
            this.ErrCompany.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrCompany.ForeColor = System.Drawing.Color.Red;
            this.ErrCompany.Location = new System.Drawing.Point(474, 29);
            this.ErrCompany.Name = "ErrCompany";
            this.ErrCompany.Size = new System.Drawing.Size(14, 13);
            this.ErrCompany.TabIndex = 3;
            this.ErrCompany.Text = "*";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(374, 10);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(99, 26);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(369, 21);
            this.cmbAccount.TabIndex = 2;
            this.cmbAccount.Tag = "Select account;@";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dtpToDate);
            this.grpData.Controls.Add(this.lblToDate);
            this.grpData.Controls.Add(this.cmbAccount);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Controls.Add(this.ErrCompany);
            this.grpData.Controls.Add(this.lblAccountName);
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 73);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(494, 96);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "";
            this.dtpToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(277, 53);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(93, 21);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.Tag = "Select to date;";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.ForeColor = System.Drawing.Color.Black;
            this.lblToDate.Location = new System.Drawing.Point(214, 57);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(57, 13);
            this.lblToDate.TabIndex = 6;
            this.lblToDate.Text = "To Date:";
            // 
            // frmLedgerReport
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(518, 231);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnViewReport);
            this.Name = "frmLedgerReport";
            this.Text = "Ledger Reports";
            this.Load += new System.EventHandler(this.frmLedgerReport_Load);
            this.Controls.SetChildIndex(this.btnViewReport, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.Label ErrCompany;
        internal System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.ComboBox cmbAccount;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.DateTimePicker dtpToDate;
        internal System.Windows.Forms.Label lblToDate;

    }
}
