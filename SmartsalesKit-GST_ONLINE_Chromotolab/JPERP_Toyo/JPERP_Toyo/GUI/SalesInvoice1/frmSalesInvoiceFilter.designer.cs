namespace Account.GUI.SalesInvoice
{
    partial class frmSalesInvoiceFilter
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
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcontactperson = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.txtTodate = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.lblFromCode = new System.Windows.Forms.Label();
            this.txtFromCode = new System.Windows.Forms.TextBox();
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
            this.grpErrorZone.TabIndex = 1;
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
            this.grpData.Controls.Add(this.txtmobile);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.txtcontactperson);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtCompany);
            this.grpData.Controls.Add(this.lblCompany);
            this.grpData.Controls.Add(this.lblToDate);
            this.grpData.Controls.Add(this.dtpTodate);
            this.grpData.Controls.Add(this.txtTodate);
            this.grpData.Controls.Add(this.lblFromDate);
            this.grpData.Controls.Add(this.dtpFromDate);
            this.grpData.Controls.Add(this.txtFromDate);
            this.grpData.Controls.Add(this.lblFromCode);
            this.grpData.Controls.Add(this.txtFromCode);
            this.grpData.Controls.Add(this.txtSrNo);
            this.grpData.Controls.Add(this.label5);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(374, 208);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // txtmobile
            // 
            this.txtmobile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobile.Location = new System.Drawing.Point(148, 175);
            this.txtmobile.MaxLength = 200;
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(206, 21);
            this.txtmobile.TabIndex = 18;
            this.txtmobile.Tag = "Enter Customer;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mobile/Phone";
            // 
            // txtcontactperson
            // 
            this.txtcontactperson.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcontactperson.Location = new System.Drawing.Point(148, 143);
            this.txtcontactperson.MaxLength = 200;
            this.txtcontactperson.Name = "txtcontactperson";
            this.txtcontactperson.Size = new System.Drawing.Size(206, 21);
            this.txtcontactperson.TabIndex = 16;
            this.txtcontactperson.Tag = "Enter Customer;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Contact Person";
            // 
            // txtSrNo
            // 
            this.txtSrNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSrNo.Location = new System.Drawing.Point(148, 14);
            this.txtSrNo.Name = "txtSrNo";
            this.txtSrNo.Size = new System.Drawing.Size(206, 21);
            this.txtSrNo.TabIndex = 14;
            this.txtSrNo.Tag = "Enter sr no;";
            this.txtSrNo.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "SR No:";
            this.label5.Visible = false;
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(148, 108);
            this.txtCompany.MaxLength = 200;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(206, 21);
            this.txtCompany.TabIndex = 12;
            this.txtCompany.Tag = "Enter Customer;";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCompany.Location = new System.Drawing.Point(6, 111);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(63, 13);
            this.lblCompany.TabIndex = 11;
            this.lblCompany.Text = "Customer";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblToDate.Location = new System.Drawing.Point(6, 75);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "To Date";
            // 
            // dtpTodate
            // 
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(336, 75);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(18, 21);
            this.dtpTodate.TabIndex = 10;
            this.dtpTodate.TabStop = false;
            this.dtpTodate.Tag = "Select to date;";
            this.dtpTodate.CloseUp += new System.EventHandler(this.dtpTodate_CloseUp);
            // 
            // txtTodate
            // 
            this.txtTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodate.Location = new System.Drawing.Point(148, 75);
            this.txtTodate.MaxLength = 10;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Size = new System.Drawing.Size(187, 21);
            this.txtTodate.TabIndex = 9;
            this.txtTodate.Tag = "Enter to date;";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(6, 44);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 13);
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(336, 44);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(18, 21);
            this.dtpFromDate.TabIndex = 7;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Tag = "Select from date;";
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(148, 44);
            this.txtFromDate.MaxLength = 10;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(187, 21);
            this.txtFromDate.TabIndex = 6;
            this.txtFromDate.Tag = "Enter from date;";
            // 
            // lblFromCode
            // 
            this.lblFromCode.AutoSize = true;
            this.lblFromCode.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromCode.Location = new System.Drawing.Point(6, 15);
            this.lblFromCode.Name = "lblFromCode";
            this.lblFromCode.Size = new System.Drawing.Size(37, 13);
            this.lblFromCode.TabIndex = 2;
            this.lblFromCode.Text = "Code";
            // 
            // txtFromCode
            // 
            this.txtFromCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromCode.Location = new System.Drawing.Point(148, 15);
            this.txtFromCode.MaxLength = 10;
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Size = new System.Drawing.Size(206, 21);
            this.txtFromCode.TabIndex = 3;
            this.txtFromCode.Tag = "Enter from code;";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(266, 277);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 23);
            this.btnApply.TabIndex = 27;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmSalesInvoiceFilter
            // 
            this.ClientSize = new System.Drawing.Size(398, 333);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmSalesInvoiceFilter";
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
        internal System.Windows.Forms.TextBox txtFromCode;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.TextBox txtTodate;
        internal System.Windows.Forms.TextBox txtCompany;
        internal System.Windows.Forms.Label lblCompany;
        internal System.Windows.Forms.TextBox txtSrNo;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button btnApply;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtmobile;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtcontactperson;
    }
}
