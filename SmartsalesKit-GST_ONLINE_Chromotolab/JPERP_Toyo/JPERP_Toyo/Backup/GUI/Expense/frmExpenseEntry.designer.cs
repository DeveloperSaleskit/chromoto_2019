namespace Account.GUI.Expense
{
    partial class frmExpenseEntry
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
            this.grpExpense = new System.Windows.Forms.GroupBox();
            this.txtCrAmount = new System.Windows.Forms.TextBox();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.lblCrAmount = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAccountCode = new System.Windows.Forms.Label();
            this.txtExpenseCode = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpExpense.SuspendLayout();
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
            // grpExpense
            // 
            this.grpExpense.Controls.Add(this.txtCrAmount);
            this.grpExpense.Controls.Add(this.btnRegenrate);
            this.grpExpense.Controls.Add(this.lblCrAmount);
            this.grpExpense.Controls.Add(this.lblrequired);
            this.grpExpense.Controls.Add(this.dtpDate);
            this.grpExpense.Controls.Add(this.lblDate);
            this.grpExpense.Controls.Add(this.lblAccountCode);
            this.grpExpense.Controls.Add(this.txtExpenseCode);
            this.grpExpense.Controls.Add(this.lblAccountName);
            this.grpExpense.Controls.Add(this.txtNarration);
            this.grpExpense.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExpense.Location = new System.Drawing.Point(12, 66);
            this.grpExpense.Name = "grpExpense";
            this.grpExpense.Size = new System.Drawing.Size(601, 183);
            this.grpExpense.TabIndex = 1;
            this.grpExpense.TabStop = false;
            // 
            // txtCrAmount
            // 
            this.txtCrAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCrAmount.Location = new System.Drawing.Point(106, 87);
            this.txtCrAmount.MaxLength = 12;
            this.txtCrAmount.Name = "txtCrAmount";
            this.txtCrAmount.Size = new System.Drawing.Size(268, 21);
            this.txtCrAmount.TabIndex = 3;
            this.txtCrAmount.Tag = "Enter Cr amount;@";
            this.txtCrAmount.Text = "0.00";
            this.txtCrAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCrAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(285, 32);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(89, 23);
            this.btnRegenrate.TabIndex = 1;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate expense code;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // lblCrAmount
            // 
            this.lblCrAmount.AutoSize = true;
            this.lblCrAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrAmount.ForeColor = System.Drawing.Color.Black;
            this.lblCrAmount.Location = new System.Drawing.Point(48, 91);
            this.lblCrAmount.Name = "lblCrAmount";
            this.lblCrAmount.Size = new System.Drawing.Size(56, 13);
            this.lblCrAmount.TabIndex = 6;
            this.lblCrAmount.Text = "Amount:";
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
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(106, 60);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(268, 21);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.Tag = "Select transaction date;";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(29, 64);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Trans Date:";
            // 
            // lblAccountCode
            // 
            this.lblAccountCode.AutoSize = true;
            this.lblAccountCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountCode.Location = new System.Drawing.Point(10, 36);
            this.lblAccountCode.Name = "lblAccountCode";
            this.lblAccountCode.Size = new System.Drawing.Size(94, 13);
            this.lblAccountCode.TabIndex = 1;
            this.lblAccountCode.Text = "Expense Code:";
            // 
            // txtExpenseCode
            // 
            this.txtExpenseCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseCode.Location = new System.Drawing.Point(106, 33);
            this.txtExpenseCode.MaxLength = 20;
            this.txtExpenseCode.Name = "txtExpenseCode";
            this.txtExpenseCode.ReadOnly = true;
            this.txtExpenseCode.Size = new System.Drawing.Size(174, 21);
            this.txtExpenseCode.TabIndex = 0;
            this.txtExpenseCode.TabStop = false;
            this.txtExpenseCode.Tag = "Expense code;@";
            // 
            // lblAccountName
            // 
            this.lblAccountName.AutoSize = true;
            this.lblAccountName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.ForeColor = System.Drawing.Color.Black;
            this.lblAccountName.Location = new System.Drawing.Point(39, 118);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(65, 13);
            this.lblAccountName.TabIndex = 8;
            this.lblAccountName.Text = "Narration:";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(106, 114);
            this.txtNarration.MaxLength = 4000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNarration.Size = new System.Drawing.Size(477, 63);
            this.txtNarration.TabIndex = 4;
            this.txtNarration.Tag = "Enter narration;";
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(9, 252);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 2;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(513, 255);
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
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(371, 255);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(136, 23);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(222, 255);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(143, 23);
            this.btnSaveContinue.TabIndex = 2;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // frmExpenseEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(626, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpExpense);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmExpenseEntry";
            this.Load += new System.EventHandler(this.frmExpenseEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpExpense, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpExpense.ResumeLayout(false);
            this.grpExpense.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.GroupBox grpExpense;
        internal System.Windows.Forms.Label lblAccountCode;
        internal System.Windows.Forms.TextBox txtExpenseCode;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Button btnRegenrate;
        internal System.Windows.Forms.TextBox txtCrAmount;
        internal System.Windows.Forms.Label lblCrAmount;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.Label lblAccountName;
        internal System.Windows.Forms.TextBox txtNarration;
    }
}
