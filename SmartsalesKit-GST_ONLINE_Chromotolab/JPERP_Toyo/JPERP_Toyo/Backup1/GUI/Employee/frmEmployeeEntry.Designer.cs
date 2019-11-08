namespace Account.GUI.Employee
{
    partial class frmEmployeeEntry
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
            this.lblrequired = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblSourceOfLead = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.ErrtransportName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 12);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(390, 55);
            this.grpErrorZone.TabIndex = 1;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(26, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(155, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(261, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(317, 306);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(171, 306);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(140, 24);
            this.btnSaveExit.TabIndex = 4;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(12, 306);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(153, 24);
            this.btnSaveContinue.TabIndex = 3;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.cmbDepartment);
            this.grpData.Controls.Add(this.lblSourceOfLead);
            this.grpData.Controls.Add(this.txtSalary);
            this.grpData.Controls.Add(this.label8);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtEmail);
            this.grpData.Controls.Add(this.lblPhone1);
            this.grpData.Controls.Add(this.txtPhone);
            this.grpData.Controls.Add(this.lblAddress1);
            this.grpData.Controls.Add(this.txtAddress1);
            this.grpData.Controls.Add(this.ErrtransportName);
            this.grpData.Controls.Add(this.lblCompanyName);
            this.grpData.Controls.Add(this.txtEmployeeName);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 73);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(390, 227);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(98, 187);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(265, 21);
            this.cmbDepartment.TabIndex = 6;
            this.cmbDepartment.Tag = "Select department;";
            // 
            // lblSourceOfLead
            // 
            this.lblSourceOfLead.AutoSize = true;
            this.lblSourceOfLead.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceOfLead.ForeColor = System.Drawing.Color.Black;
            this.lblSourceOfLead.Location = new System.Drawing.Point(12, 190);
            this.lblSourceOfLead.Name = "lblSourceOfLead";
            this.lblSourceOfLead.Size = new System.Drawing.Size(80, 13);
            this.lblSourceOfLead.TabIndex = 87;
            this.lblSourceOfLead.Text = "Department:";
            // 
            // txtSalary
            // 
            this.txtSalary.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalary.Location = new System.Drawing.Point(98, 160);
            this.txtSalary.MaxLength = 20;
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(265, 21);
            this.txtSalary.TabIndex = 5;
            this.txtSalary.Tag = "Enter salary;";
            this.txtSalary.Text = "00";
            this.txtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalary_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label8.Location = new System.Drawing.Point(43, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 85;
            this.label8.Text = "Salary:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(98, 133);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(265, 21);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Tag = "Enter email;";
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.ForeColor = System.Drawing.Color.Black;
            this.lblPhone1.Location = new System.Drawing.Point(25, 109);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(67, 13);
            this.lblPhone1.TabIndex = 16;
            this.lblPhone1.Text = "Mobile No:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(98, 104);
            this.txtPhone.MaxLength = 10;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(265, 21);
            this.txtPhone.TabIndex = 3;
            this.txtPhone.Tag = "Enter phone;";
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1.ForeColor = System.Drawing.Color.Black;
            this.lblAddress1.Location = new System.Drawing.Point(34, 44);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(58, 13);
            this.lblAddress1.TabIndex = 7;
            this.lblAddress1.Text = "Address:";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(98, 41);
            this.txtAddress1.MaxLength = 4000;
            this.txtAddress1.Multiline = true;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress1.Size = new System.Drawing.Size(265, 57);
            this.txtAddress1.TabIndex = 2;
            this.txtAddress1.Tag = "Enter address;";
            // 
            // ErrtransportName
            // 
            this.ErrtransportName.AutoSize = true;
            this.ErrtransportName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrtransportName.ForeColor = System.Drawing.Color.Red;
            this.ErrtransportName.Location = new System.Drawing.Point(369, 14);
            this.ErrtransportName.Name = "ErrtransportName";
            this.ErrtransportName.Size = new System.Drawing.Size(14, 13);
            this.ErrtransportName.TabIndex = 6;
            this.ErrtransportName.Text = "*";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyName.Location = new System.Drawing.Point(47, 17);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(45, 13);
            this.lblCompanyName.TabIndex = 4;
            this.lblCompanyName.Text = "Name:";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(98, 14);
            this.txtEmployeeName.MaxLength = 100;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(265, 21);
            this.txtEmployeeName.TabIndex = 1;
            this.txtEmployeeName.Tag = "Enter name;@";
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(9, 307);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 34;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // frmEmployeeEntry
            // 
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 367);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmEmployeeEntry";
            this.Load += new System.EventHandler(this.frmEmployeeEntry_Load);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.Label lblAddress1;
        internal System.Windows.Forms.TextBox txtAddress1;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrtransportName;
        internal System.Windows.Forms.Label lblCompanyName;
        internal System.Windows.Forms.TextBox txtEmployeeName;
        internal System.Windows.Forms.Label lblPhone1;
        internal System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.ComboBox cmbDepartment;
        internal System.Windows.Forms.Label lblSourceOfLead;
        internal System.Windows.Forms.TextBox txtSalary;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDelMsg;
    }
}
