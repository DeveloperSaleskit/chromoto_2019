namespace Account.GUI.Commission
{
    partial class frmCommissionEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.lblrequired = new System.Windows.Forms.Label();
            this.txtCrAmount = new System.Windows.Forms.TextBox();
            this.ErrCompany = new System.Windows.Forms.Label();
            this.txtDbAmount = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.lblDbAmount = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblCrAmount = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 5);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(601, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(589, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.cmbAccount);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Controls.Add(this.txtCrAmount);
            this.grpData.Controls.Add(this.ErrCompany);
            this.grpData.Controls.Add(this.txtDbAmount);
            this.grpData.Controls.Add(this.lblAccountName);
            this.grpData.Controls.Add(this.lblDbAmount);
            this.grpData.Controls.Add(this.txtNarration);
            this.grpData.Controls.Add(this.lblCrAmount);
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 66);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(601, 182);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Narration:";
            // 
            // cmbAccount
            // 
            this.cmbAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Location = new System.Drawing.Point(99, 26);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(286, 21);
            this.cmbAccount.TabIndex = 2;
            this.cmbAccount.Tag = "Select account;@";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(478, 12);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCrAmount
            // 
            this.txtCrAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrAmount.Location = new System.Drawing.Point(99, 80);
            this.txtCrAmount.MaxLength = 12;
            this.txtCrAmount.Name = "txtCrAmount";
            this.txtCrAmount.Size = new System.Drawing.Size(118, 21);
            this.txtCrAmount.TabIndex = 7;
            this.txtCrAmount.Tag = "Enter Cr amount;@";
            this.txtCrAmount.Text = "0.00";
            this.txtCrAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // ErrCompany
            // 
            this.ErrCompany.AutoSize = true;
            this.ErrCompany.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrCompany.ForeColor = System.Drawing.Color.Red;
            this.ErrCompany.Location = new System.Drawing.Point(388, 30);
            this.ErrCompany.Name = "ErrCompany";
            this.ErrCompany.Size = new System.Drawing.Size(14, 13);
            this.ErrCompany.TabIndex = 3;
            this.ErrCompany.Text = "*";
            // 
            // txtDbAmount
            // 
            this.txtDbAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbAmount.Location = new System.Drawing.Point(458, 81);
            this.txtDbAmount.MaxLength = 12;
            this.txtDbAmount.Name = "txtDbAmount";
            this.txtDbAmount.Size = new System.Drawing.Size(118, 21);
            this.txtDbAmount.TabIndex = 9;
            this.txtDbAmount.Tag = "Enter Db amount;@";
            this.txtDbAmount.Text = "0.00";
            this.txtDbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.Black;
            this.lblAccountName.Location = new System.Drawing.Point(41, 29);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(57, 13);
            this.lblAccountName.TabIndex = 1;
            this.lblAccountName.Text = "Account:";
            // 
            // lblDbAmount
            // 
            this.lblDbAmount.AutoSize = true;
            this.lblDbAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDbAmount.Location = new System.Drawing.Point(383, 85);
            this.lblDbAmount.Name = "lblDbAmount";
            this.lblDbAmount.Size = new System.Drawing.Size(76, 13);
            this.lblDbAmount.TabIndex = 8;
            this.lblDbAmount.Text = "Db Amount:";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(99, 108);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(477, 65);
            this.txtNarration.TabIndex = 10;
            this.txtNarration.Tag = "Enter narration;";
            // 
            // lblCrAmount
            // 
            this.lblCrAmount.AutoSize = true;
            this.lblCrAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrAmount.ForeColor = System.Drawing.Color.Black;
            this.lblCrAmount.Location = new System.Drawing.Point(24, 84);
            this.lblCrAmount.Name = "lblCrAmount";
            this.lblCrAmount.Size = new System.Drawing.Size(74, 13);
            this.lblCrAmount.TabIndex = 6;
            this.lblCrAmount.Text = "Cr Amount:";
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
            this.dtpDate.Tag = "Select transaction date;";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(21, 57);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Trans Date:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(513, 257);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(407, 257);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(100, 23);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // frmCommissionEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(626, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmCommissionEntry";
            this.Load += new System.EventHandler(this.frmCommissionEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.Label lblAccountName;
        internal System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label ErrCompany;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        internal System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.TextBox txtCrAmount;
        internal System.Windows.Forms.TextBox txtDbAmount;
        internal System.Windows.Forms.Label lblDbAmount;
        internal System.Windows.Forms.Label lblCrAmount;
        internal System.Windows.Forms.ComboBox cmbAccount;
        internal System.Windows.Forms.Label label1;
    }
}
