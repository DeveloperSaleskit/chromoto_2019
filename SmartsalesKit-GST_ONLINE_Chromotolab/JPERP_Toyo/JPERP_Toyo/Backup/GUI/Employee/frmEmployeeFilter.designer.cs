namespace Account.GUI.Employee
{
    partial class frmEmployeeFilter
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtDept = new System.Windows.Forms.TextBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFromCode = new System.Windows.Forms.Label();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
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
            this.grpErrorZone.Size = new System.Drawing.Size(374, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(362, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtEmail);
            this.grpData.Controls.Add(this.txtPhoneNo);
            this.grpData.Controls.Add(this.txtDept);
            this.grpData.Controls.Add(this.txtAdd);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.lblFromCode);
            this.grpData.Controls.Add(this.txtEmployeeName);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(374, 181);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(148, 110);
            this.txtEmail.MaxLength = 10;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(206, 21);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Tag = "Enter from code;";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(148, 73);
            this.txtPhoneNo.MaxLength = 10;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(206, 21);
            this.txtPhoneNo.TabIndex = 2;
            this.txtPhoneNo.Tag = "Enter from code;";
            // 
            // txtDept
            // 
            this.txtDept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Location = new System.Drawing.Point(148, 137);
            this.txtDept.MaxLength = 10;
            this.txtDept.Name = "txtDept";
            this.txtDept.Size = new System.Drawing.Size(206, 21);
            this.txtDept.TabIndex = 4;
            this.txtDept.Tag = "Enter from code;";
            // 
            // txtAdd
            // 
            this.txtAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdd.Location = new System.Drawing.Point(148, 42);
            this.txtAdd.MaxLength = 10;
            this.txtAdd.Name = "txtAdd";
            this.txtAdd.Size = new System.Drawing.Size(206, 21);
            this.txtAdd.TabIndex = 1;
            this.txtAdd.Tag = "Enter from code;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(6, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Department";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mobile No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Address";
            // 
            // lblFromCode
            // 
            this.lblFromCode.AutoSize = true;
            this.lblFromCode.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromCode.Location = new System.Drawing.Point(6, 15);
            this.lblFromCode.Name = "lblFromCode";
            this.lblFromCode.Size = new System.Drawing.Size(100, 13);
            this.lblFromCode.TabIndex = 2;
            this.lblFromCode.Text = "Employee Name";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(148, 15);
            this.txtEmployeeName.MaxLength = 10;
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(206, 21);
            this.txtEmployeeName.TabIndex = 0;
            this.txtEmployeeName.Tag = "Enter from code;";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(266, 250);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmEmployeeFilter
            // 
            this.AcceptButton = this.btnApply;
            this.ClientSize = new System.Drawing.Size(398, 305);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmEmployeeFilter";
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
        internal System.Windows.Forms.Label lblFromCode;
        internal System.Windows.Forms.TextBox txtEmployeeName;
        internal System.Windows.Forms.Button btnApply;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.TextBox txtDept;
        internal System.Windows.Forms.TextBox txtAdd;
    }
}
