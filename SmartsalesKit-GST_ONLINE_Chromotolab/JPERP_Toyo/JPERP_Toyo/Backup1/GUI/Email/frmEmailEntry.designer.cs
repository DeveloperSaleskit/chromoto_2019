namespace Account.GUI.Email
{
    partial class frmEmailEntry
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
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrType = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.ErrName = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.ErrUserName = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(625, 349);
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
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExit.Location = new System.Drawing.Point(493, 349);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(126, 23);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveContinue.Location = new System.Drawing.Point(341, 349);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(142, 23);
            this.btnSaveContinue.TabIndex = 1;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(713, 55);
            this.grpErrorZone.TabIndex = 1;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(701, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Controls.Add(this.txtFooter);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.ErrType);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.cmbType);
            this.grpData.Controls.Add(this.ErrName);
            this.grpData.Controls.Add(this.txtSubject);
            this.grpData.Controls.Add(this.txtHeader);
            this.grpData.Controls.Add(this.lblName);
            this.grpData.Controls.Add(this.ErrUserName);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Controls.Add(this.lblUserName);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(713, 280);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // txtFooter
            // 
            this.txtFooter.Location = new System.Drawing.Point(112, 165);
            this.txtFooter.MaxLength = 4000;
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFooter.Size = new System.Drawing.Size(560, 85);
            this.txtFooter.TabIndex = 3;
            this.txtFooter.Tag = "Enter Footer Part of Mail Body;@";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Footer :";
            // 
            // ErrType
            // 
            this.ErrType.AutoSize = true;
            this.ErrType.ForeColor = System.Drawing.Color.Red;
            this.ErrType.Location = new System.Drawing.Point(292, 23);
            this.ErrType.Name = "ErrType";
            this.ErrType.Size = new System.Drawing.Size(15, 13);
            this.ErrType.TabIndex = 15;
            this.ErrType.Text = "*";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(26, 24);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(75, 13);
            this.lblCity.TabIndex = 13;
            this.lblCity.Text = "Email Type:";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "--Select--",
            "Quotation",
            "Sales",
            "Services",
            "Payment Reminder",
            "Reminder",
            "Purchase"});
            this.cmbType.Location = new System.Drawing.Point(112, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(174, 21);
            this.cmbType.TabIndex = 0;
            this.cmbType.Tag = "Select Email Type;@";
            // 
            // ErrName
            // 
            this.ErrName.AutoSize = true;
            this.ErrName.ForeColor = System.Drawing.Color.Red;
            this.ErrName.Location = new System.Drawing.Point(678, 106);
            this.ErrName.Name = "ErrName";
            this.ErrName.Size = new System.Drawing.Size(15, 13);
            this.ErrName.TabIndex = 11;
            this.ErrName.Text = "*";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(112, 47);
            this.txtSubject.MaxLength = 1500;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(560, 21);
            this.txtSubject.TabIndex = 1;
            this.txtSubject.Tag = "Enter Mail Subject;@";
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(112, 74);
            this.txtHeader.MaxLength = 4000;
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHeader.Size = new System.Drawing.Size(560, 85);
            this.txtHeader.TabIndex = 2;
            this.txtHeader.Tag = "Enter Header Part of Mail Body;@";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(44, 110);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Header :";
            // 
            // ErrUserName
            // 
            this.ErrUserName.AutoSize = true;
            this.ErrUserName.ForeColor = System.Drawing.Color.Red;
            this.ErrUserName.Location = new System.Drawing.Point(678, 51);
            this.ErrUserName.Name = "ErrUserName";
            this.ErrUserName.Size = new System.Drawing.Size(15, 13);
            this.ErrUserName.TabIndex = 2;
            this.ErrUserName.Text = "*";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(594, 14);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(112, 13);
            this.lblrequired.TabIndex = 12;
            this.lblrequired.Text = "* - Required fields";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(42, 51);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(59, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Subject :";
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(14, 346);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(210, 26);
            this.lblDelMsg.TabIndex = 19;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // frmEmailEntry
            // 
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(737, 408);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.lblDelMsg);
            this.Name = "frmEmailEntry";
            this.Load += new System.EventHandler(this.frmGodownEntry_Load);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
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
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label ErrType;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label label1;
    }
}
