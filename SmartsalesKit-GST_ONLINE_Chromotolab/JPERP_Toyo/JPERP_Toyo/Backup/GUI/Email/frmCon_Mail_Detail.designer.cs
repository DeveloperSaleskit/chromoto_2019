namespace Account.GUI.Email
{
    partial class frmCon_Mail_Detail
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
            this.ErrSSL = new System.Windows.Forms.Label();
            this.ErrPort = new System.Windows.Forms.Label();
            this.txtSSL = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblSSL = new System.Windows.Forms.Label();
            this.ErrHost = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtNPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrType = new System.Windows.Forms.Label();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.txtCPassword = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.ErrUserName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.ErrName = new System.Windows.Forms.Label();
            this.cmbHost = new System.Windows.Forms.ComboBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(281, 294);
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
            this.btnSaveExit.Location = new System.Drawing.Point(147, 294);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(126, 23);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(372, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(226, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(232, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(112, 13);
            this.lblrequired.TabIndex = 12;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrSSL);
            this.grpData.Controls.Add(this.ErrPort);
            this.grpData.Controls.Add(this.txtSSL);
            this.grpData.Controls.Add(this.txtPort);
            this.grpData.Controls.Add(this.lblSSL);
            this.grpData.Controls.Add(this.ErrHost);
            this.grpData.Controls.Add(this.lblPort);
            this.grpData.Controls.Add(this.txtNPassword);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.ErrType);
            this.grpData.Controls.Add(this.txtEmailId);
            this.grpData.Controls.Add(this.txtCPassword);
            this.grpData.Controls.Add(this.lblName);
            this.grpData.Controls.Add(this.ErrUserName);
            this.grpData.Controls.Add(this.lblUserName);
            this.grpData.Controls.Add(this.ErrName);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(372, 225);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // ErrSSL
            // 
            this.ErrSSL.AutoSize = true;
            this.ErrSSL.ForeColor = System.Drawing.Color.Red;
            this.ErrSSL.Location = new System.Drawing.Point(349, 167);
            this.ErrSSL.Name = "ErrSSL";
            this.ErrSSL.Size = new System.Drawing.Size(15, 13);
            this.ErrSSL.TabIndex = 91;
            this.ErrSSL.Text = "*";
            // 
            // ErrPort
            // 
            this.ErrPort.AutoSize = true;
            this.ErrPort.ForeColor = System.Drawing.Color.Red;
            this.ErrPort.Location = new System.Drawing.Point(349, 137);
            this.ErrPort.Name = "ErrPort";
            this.ErrPort.Size = new System.Drawing.Size(15, 13);
            this.ErrPort.TabIndex = 91;
            this.ErrPort.Text = "*";
            // 
            // txtSSL
            // 
            this.txtSSL.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSSL.Location = new System.Drawing.Point(133, 167);
            this.txtSSL.MaxLength = 12;
            this.txtSSL.Name = "txtSSL";
            this.txtSSL.Size = new System.Drawing.Size(215, 21);
            this.txtSSL.TabIndex = 4;
            this.txtSSL.Tag = "Enter SSL;";
            this.txtSSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSSL.TextChanged += new System.EventHandler(this.txtSSL_TextChanged);
            this.txtSSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSSL_KeyPress);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPort.Location = new System.Drawing.Point(133, 137);
            this.txtPort.MaxLength = 12;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(215, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Tag = "Enter Port;";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPort_KeyPress);
            // 
            // lblSSL
            // 
            this.lblSSL.AutoSize = true;
            this.lblSSL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSL.Location = new System.Drawing.Point(98, 167);
            this.lblSSL.Name = "lblSSL";
            this.lblSSL.Size = new System.Drawing.Size(38, 13);
            this.lblSSL.TabIndex = 92;
            this.lblSSL.Text = "SSL :";
            // 
            // ErrHost
            // 
            this.ErrHost.AutoSize = true;
            this.ErrHost.ForeColor = System.Drawing.Color.Red;
            this.ErrHost.Location = new System.Drawing.Point(349, 107);
            this.ErrHost.Name = "ErrHost";
            this.ErrHost.Size = new System.Drawing.Size(15, 13);
            this.ErrHost.TabIndex = 90;
            this.ErrHost.Text = "*";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(98, 137);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(39, 13);
            this.lblPort.TabIndex = 90;
            this.lblPort.Text = "Port :";
            // 
            // txtNPassword
            // 
            this.txtNPassword.Location = new System.Drawing.Point(130, 74);
            this.txtNPassword.MaxLength = 2550;
            this.txtNPassword.Name = "txtNPassword";
            this.txtNPassword.Size = new System.Drawing.Size(220, 21);
            this.txtNPassword.TabIndex = 2;
            this.txtNPassword.Tag = "Enter New Password;@";
            this.txtNPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "New Password :";
            // 
            // ErrType
            // 
            this.ErrType.AutoSize = true;
            this.ErrType.ForeColor = System.Drawing.Color.Red;
            this.ErrType.Location = new System.Drawing.Point(349, 78);
            this.ErrType.Name = "ErrType";
            this.ErrType.Size = new System.Drawing.Size(15, 13);
            this.ErrType.TabIndex = 15;
            this.ErrType.Text = "*";
            // 
            // txtEmailId
            // 
            this.txtEmailId.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailId.Location = new System.Drawing.Point(130, 20);
            this.txtEmailId.MaxLength = 1500;
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(220, 20);
            this.txtEmailId.TabIndex = 0;
            this.txtEmailId.Tag = "Enter EMail ID;@";
            // 
            // txtCPassword
            // 
            this.txtCPassword.Location = new System.Drawing.Point(130, 47);
            this.txtCPassword.MaxLength = 2550;
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.Size = new System.Drawing.Size(220, 21);
            this.txtCPassword.TabIndex = 1;
            this.txtCPassword.Tag = "Enter Current Password;@";
            this.txtCPassword.UseSystemPasswordChar = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(6, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(118, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Current Password :";
            // 
            // ErrUserName
            // 
            this.ErrUserName.AutoSize = true;
            this.ErrUserName.ForeColor = System.Drawing.Color.Red;
            this.ErrUserName.Location = new System.Drawing.Point(349, 24);
            this.ErrUserName.Name = "ErrUserName";
            this.ErrUserName.Size = new System.Drawing.Size(15, 13);
            this.ErrUserName.TabIndex = 2;
            this.ErrUserName.Text = "*";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(59, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(65, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Email ID :";
            // 
            // ErrName
            // 
            this.ErrName.AutoSize = true;
            this.ErrName.ForeColor = System.Drawing.Color.Red;
            this.ErrName.Location = new System.Drawing.Point(349, 51);
            this.ErrName.Name = "ErrName";
            this.ErrName.Size = new System.Drawing.Size(15, 13);
            this.ErrName.TabIndex = 11;
            this.ErrName.Text = "*";
            // 
            // cmbHost
            // 
            this.cmbHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHost.FormattingEnabled = true;
            this.cmbHost.Location = new System.Drawing.Point(142, 166);
            this.cmbHost.Name = "cmbHost";
            this.cmbHost.Size = new System.Drawing.Size(220, 21);
            this.cmbHost.TabIndex = 2;
            this.cmbHost.Tag = "Select Host;";
            this.cmbHost.SelectedIndexChanged += new System.EventHandler(this.cmbHost_SelectedIndexChanged);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.ForeColor = System.Drawing.Color.Black;
            this.lblHost.Location = new System.Drawing.Point(99, 169);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(37, 13);
            this.lblHost.TabIndex = 89;
            this.lblHost.Text = "Host:";
            // 
            // frmCon_Mail_Detail
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(396, 349);
            this.Controls.Add(this.cmbHost);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCon_Mail_Detail";
            this.Load += new System.EventHandler(this.frmGodownEntry_Load);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblHost, 0);
            this.Controls.SetChildIndex(this.cmbHost, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtCPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrUserName;

        private System.Windows.Forms.Label ErrName;
        private System.Windows.Forms.Label ErrType;
        private System.Windows.Forms.TextBox txtNPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbHost;
        internal System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label ErrHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblSSL;
        private System.Windows.Forms.TextBox txtSSL;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label ErrPort;
        private System.Windows.Forms.Label ErrSSL;
    }
}
