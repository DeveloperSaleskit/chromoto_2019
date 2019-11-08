namespace Account.GUI.Customer
{
    partial class frmLeadFollowup
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
            this.ErrFollowupBy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFollowUpBy = new System.Windows.Forms.ComboBox();
            this.txtFollowupDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrNextDate = new System.Windows.Forms.Label();
            this.dtpNextDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblInquiryNo = new System.Windows.Forms.Label();
            this.txtLeadNo = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblrequired = new System.Windows.Forms.Label();
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
            this.grpErrorZone.Location = new System.Drawing.Point(12, 12);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(659, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(643, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrFollowupBy);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.cmbFollowUpBy);
            this.grpData.Controls.Add(this.txtFollowupDate);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.ErrNextDate);
            this.grpData.Controls.Add(this.dtpNextDate);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.lblRemark);
            this.grpData.Controls.Add(this.txtRemark);
            this.grpData.Controls.Add(this.lblInquiryNo);
            this.grpData.Controls.Add(this.txtLeadNo);
            this.grpData.Controls.Add(this.lblCustomerName);
            this.grpData.Controls.Add(this.txtCustomerName);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 73);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(659, 201);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // ErrFollowupBy
            // 
            this.ErrFollowupBy.AutoSize = true;
            this.ErrFollowupBy.ForeColor = System.Drawing.Color.Red;
            this.ErrFollowupBy.Location = new System.Drawing.Point(510, 126);
            this.ErrFollowupBy.Name = "ErrFollowupBy";
            this.ErrFollowupBy.Size = new System.Drawing.Size(14, 13);
            this.ErrFollowupBy.TabIndex = 14;
            this.ErrFollowupBy.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(268, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Followup By:";
            // 
            // cmbFollowUpBy
            // 
            this.cmbFollowUpBy.FormattingEnabled = true;
            this.cmbFollowUpBy.Location = new System.Drawing.Point(354, 122);
            this.cmbFollowUpBy.Name = "cmbFollowUpBy";
            this.cmbFollowUpBy.Size = new System.Drawing.Size(150, 21);
            this.cmbFollowUpBy.TabIndex = 13;
            this.cmbFollowUpBy.Tag = "Select followup by;@";
            // 
            // txtFollowupDate
            // 
            this.txtFollowupDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFollowupDate.Location = new System.Drawing.Point(136, 89);
            this.txtFollowupDate.MaxLength = 50;
            this.txtFollowupDate.Name = "txtFollowupDate";
            this.txtFollowupDate.ReadOnly = true;
            this.txtFollowupDate.Size = new System.Drawing.Size(116, 21);
            this.txtFollowupDate.TabIndex = 8;
            this.txtFollowupDate.Tag = "Enter to date;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(38, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Followup Date:";
            // 
            // ErrNextDate
            // 
            this.ErrNextDate.AutoSize = true;
            this.ErrNextDate.ForeColor = System.Drawing.Color.Red;
            this.ErrNextDate.Location = new System.Drawing.Point(226, 126);
            this.ErrNextDate.Name = "ErrNextDate";
            this.ErrNextDate.Size = new System.Drawing.Size(14, 13);
            this.ErrNextDate.TabIndex = 11;
            this.ErrNextDate.Text = "*";
            // 
            // dtpNextDate
            // 
            this.dtpNextDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.dtpNextDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNextDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNextDate.Location = new System.Drawing.Point(136, 122);
            this.dtpNextDate.Name = "dtpNextDate";
            this.dtpNextDate.Size = new System.Drawing.Size(90, 21);
            this.dtpNextDate.TabIndex = 10;
            this.dtpNextDate.Tag = "Select next followup date;@";
            this.dtpNextDate.Value = new System.DateTime(2013, 12, 30, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(8, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Next Followup Date:";
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.ForeColor = System.Drawing.Color.Black;
            this.lblRemark.Location = new System.Drawing.Point(67, 152);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(63, 13);
            this.lblRemark.TabIndex = 15;
            this.lblRemark.Text = "Remarks:";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(136, 149);
            this.txtRemark.MaxLength = 4000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(513, 40);
            this.txtRemark.TabIndex = 16;
            this.txtRemark.Tag = "Enter remarks;";
            // 
            // lblInquiryNo
            // 
            this.lblInquiryNo.AutoSize = true;
            this.lblInquiryNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryNo.Location = new System.Drawing.Point(33, 35);
            this.lblInquiryNo.Name = "lblInquiryNo";
            this.lblInquiryNo.Size = new System.Drawing.Size(97, 13);
            this.lblInquiryNo.TabIndex = 1;
            this.lblInquiryNo.Text = "Customer Code";
            // 
            // txtLeadNo
            // 
            this.txtLeadNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeadNo.Location = new System.Drawing.Point(136, 32);
            this.txtLeadNo.MaxLength = 20;
            this.txtLeadNo.Name = "txtLeadNo";
            this.txtLeadNo.ReadOnly = true;
            this.txtLeadNo.Size = new System.Drawing.Size(116, 21);
            this.txtLeadNo.TabIndex = 2;
            this.txtLeadNo.TabStop = false;
            this.txtLeadNo.Tag = "Lead No;";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Black;
            this.lblCustomerName.Location = new System.Drawing.Point(62, 65);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(67, 13);
            this.lblCustomerName.TabIndex = 5;
            this.lblCustomerName.Text = "Company:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(136, 62);
            this.txtCustomerName.MaxLength = 100;
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(313, 21);
            this.txtCustomerName.TabIndex = 6;
            this.txtCustomerName.Tag = "Enter customer;";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(410, 16);
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
            this.btnCancel.Location = new System.Drawing.Point(561, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(417, 280);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(138, 24);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // frmLeadFollowup
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(682, 335);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmLeadFollowup";
            this.Load += new System.EventHandler(this.frmLeadFollowup_Load);
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
        private System.Windows.Forms.Label ErrNextDate;
        internal System.Windows.Forms.DateTimePicker dtpNextDate;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblRemark;
        internal System.Windows.Forms.TextBox txtRemark;
        internal System.Windows.Forms.Label lblInquiryNo;
        internal System.Windows.Forms.TextBox txtLeadNo;
        internal System.Windows.Forms.Label lblCustomerName;
        internal System.Windows.Forms.TextBox txtCustomerName;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.TextBox txtFollowupDate;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrFollowupBy;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFollowUpBy;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
    }
}
