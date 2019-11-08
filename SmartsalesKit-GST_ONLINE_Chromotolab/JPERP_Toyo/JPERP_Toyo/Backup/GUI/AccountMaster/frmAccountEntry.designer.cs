namespace Account.GUI.AccountMaster
{
    partial class frmAccountMasterEntry
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
            this.txtCrAmount = new System.Windows.Forms.TextBox();
            this.txtDbAmount = new System.Windows.Forms.TextBox();
            this.lblDbAmount = new System.Windows.Forms.Label();
            this.lblCrAmount = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.grpAccountMaster = new System.Windows.Forms.GroupBox();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.lblrequired = new System.Windows.Forms.Label();
            this.ErrCompany = new System.Windows.Forms.Label();
            this.lblAccountCode = new System.Windows.Forms.Label();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.grpAccountMaster.SuspendLayout();
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
            this.grpData.Controls.Add(this.txtCrAmount);
            this.grpData.Controls.Add(this.txtDbAmount);
            this.grpData.Controls.Add(this.lblDbAmount);
            this.grpData.Controls.Add(this.lblCrAmount);
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 162);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(601, 86);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            // 
            // txtCrAmount
            // 
            this.txtCrAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrAmount.Location = new System.Drawing.Point(99, 47);
            this.txtCrAmount.MaxLength = 12;
            this.txtCrAmount.Name = "txtCrAmount";
            this.txtCrAmount.Size = new System.Drawing.Size(118, 21);
            this.txtCrAmount.TabIndex = 3;
            this.txtCrAmount.Tag = "Enter Cr amount;@";
            this.txtCrAmount.Text = "0.00";
            this.txtCrAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtDbAmount
            // 
            this.txtDbAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbAmount.Location = new System.Drawing.Point(402, 46);
            this.txtDbAmount.MaxLength = 12;
            this.txtDbAmount.Name = "txtDbAmount";
            this.txtDbAmount.Size = new System.Drawing.Size(118, 21);
            this.txtDbAmount.TabIndex = 5;
            this.txtDbAmount.Tag = "Enter Db amount;@";
            this.txtDbAmount.Text = "0.00";
            this.txtDbAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // lblDbAmount
            // 
            this.lblDbAmount.AutoSize = true;
            this.lblDbAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbAmount.ForeColor = System.Drawing.Color.Black;
            this.lblDbAmount.Location = new System.Drawing.Point(327, 50);
            this.lblDbAmount.Name = "lblDbAmount";
            this.lblDbAmount.Size = new System.Drawing.Size(76, 13);
            this.lblDbAmount.TabIndex = 4;
            this.lblDbAmount.Text = "Db Amount:";
            // 
            // lblCrAmount
            // 
            this.lblCrAmount.AutoSize = true;
            this.lblCrAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrAmount.ForeColor = System.Drawing.Color.Black;
            this.lblCrAmount.Location = new System.Drawing.Point(24, 51);
            this.lblCrAmount.Name = "lblCrAmount";
            this.lblCrAmount.Size = new System.Drawing.Size(74, 13);
            this.lblCrAmount.TabIndex = 2;
            this.lblCrAmount.Text = "Cr Amount:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(99, 20);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(93, 21);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.Tag = "Select transaction date;";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(21, 24);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Trans Date:";
            // 
            // grpAccountMaster
            // 
            this.grpAccountMaster.Controls.Add(this.btnRegenrate);
            this.grpAccountMaster.Controls.Add(this.lblrequired);
            this.grpAccountMaster.Controls.Add(this.ErrCompany);
            this.grpAccountMaster.Controls.Add(this.lblAccountCode);
            this.grpAccountMaster.Controls.Add(this.txtAccountCode);
            this.grpAccountMaster.Controls.Add(this.lblAccountName);
            this.grpAccountMaster.Controls.Add(this.txtAccountName);
            this.grpAccountMaster.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAccountMaster.Location = new System.Drawing.Point(12, 66);
            this.grpAccountMaster.Name = "grpAccountMaster";
            this.grpAccountMaster.Size = new System.Drawing.Size(601, 90);
            this.grpAccountMaster.TabIndex = 1;
            this.grpAccountMaster.TabStop = false;
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(279, 31);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(89, 23);
            this.btnRegenrate.TabIndex = 3;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate Account code;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(478, 17);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrCompany
            // 
            this.ErrCompany.AutoSize = true;
            this.ErrCompany.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrCompany.ForeColor = System.Drawing.Color.Red;
            this.ErrCompany.Location = new System.Drawing.Point(578, 63);
            this.ErrCompany.Name = "ErrCompany";
            this.ErrCompany.Size = new System.Drawing.Size(14, 13);
            this.ErrCompany.TabIndex = 6;
            this.ErrCompany.Text = "*";
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountCode.Location = new System.Drawing.Point(9, 36);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(91, 13);
            this.lblAccountCode.TabIndex = 1;
            this.lblAccountCode.Text = "Account Code:";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountCode.Location = new System.Drawing.Point(106, 33);
            this.txtAccountCode.MaxLength = 20;
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.ReadOnly = true;
            this.txtAccountCode.Size = new System.Drawing.Size(167, 21);
            this.txtAccountCode.TabIndex = 2;
            this.txtAccountCode.TabStop = false;
            this.txtAccountCode.Tag = "Account code;@";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.Black;
            this.lblAccountName.Location = new System.Drawing.Point(6, 62);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(94, 13);
            this.lblAccountName.TabIndex = 4;
            this.lblAccountName.Text = "Account Name:";
            // 
            // txtAccountName
            // 
            this.txtAccountName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountName.Location = new System.Drawing.Point(106, 59);
            this.txtAccountName.MaxLength = 100;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(470, 21);
            this.txtAccountName.TabIndex = 5;
            this.txtAccountName.Tag = "Enter account name;@";
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(9, 252);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 3;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(513, 254);
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
            this.btnSaveExit.Location = new System.Drawing.Point(372, 254);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(135, 23);
            this.btnSaveExit.TabIndex = 5;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(216, 254);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(150, 23);
            this.btnSaveContinue.TabIndex = 4;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // frmAccountMasterEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(626, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpAccountMaster);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmAccountMasterEntry";
            this.Load += new System.EventHandler(this.frmAccountMasterEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpAccountMaster, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpAccountMaster.ResumeLayout(false);
            this.grpAccountMaster.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.GroupBox grpAccountMaster;
        internal System.Windows.Forms.Label lblAccountCode;
        internal System.Windows.Forms.TextBox txtAccountCode;
        internal System.Windows.Forms.Label lblAccountName;
        internal System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Label ErrCompany;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Button btnRegenrate;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.TextBox txtCrAmount;
        internal System.Windows.Forms.TextBox txtDbAmount;
        internal System.Windows.Forms.Label lblDbAmount;
        internal System.Windows.Forms.Label lblCrAmount;
    }
}
