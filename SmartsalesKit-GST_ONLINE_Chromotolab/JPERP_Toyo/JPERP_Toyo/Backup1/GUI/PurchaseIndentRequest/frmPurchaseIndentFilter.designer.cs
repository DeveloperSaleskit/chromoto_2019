namespace Account.GUI.PurchaseIndentRequest
{
    partial class frmPurchaseIndentFilter
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
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.txtTodate = new System.Windows.Forms.TextBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtitemcode = new System.Windows.Forms.TextBox();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtproductcode = new System.Windows.Forms.TextBox();
            this.lblInquiryNo = new System.Windows.Forms.Label();
            this.txtsrno = new System.Windows.Forms.TextBox();
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
            this.grpErrorZone.Size = new System.Drawing.Size(360, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(348, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtsrno);
            this.grpData.Controls.Add(this.lblInquiryNo);
            this.grpData.Controls.Add(this.txtproductcode);
            this.grpData.Controls.Add(this.label7);
            this.grpData.Controls.Add(this.txtitemcode);
            this.grpData.Controls.Add(this.lblPhone1);
            this.grpData.Controls.Add(this.dtpTodate);
            this.grpData.Controls.Add(this.txtTodate);
            this.grpData.Controls.Add(this.lblToDate);
            this.grpData.Controls.Add(this.dtpFromDate);
            this.grpData.Controls.Add(this.txtFromDate);
            this.grpData.Controls.Add(this.lblFromDate);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(360, 208);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // dtpTodate
            // 
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(321, 76);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(21, 21);
            this.dtpTodate.TabIndex = 4;
            this.dtpTodate.TabStop = false;
            this.dtpTodate.Tag = "Select to date;";
            this.dtpTodate.CloseUp += new System.EventHandler(this.dtpTodate_CloseUp);
            // 
            // txtTodate
            // 
            this.txtTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodate.Location = new System.Drawing.Point(126, 81);
            this.txtTodate.MaxLength = 50;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Size = new System.Drawing.Size(191, 21);
            this.txtTodate.TabIndex = 3;
            this.txtTodate.Tag = "Enter to date;";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblToDate.Location = new System.Drawing.Point(34, 82);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 7;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(321, 47);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(21, 21);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Tag = "Select from date;";
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(126, 49);
            this.txtFromDate.MaxLength = 50;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(191, 21);
            this.txtFromDate.TabIndex = 1;
            this.txtFromDate.Tag = "Enter from date;";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(34, 53);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 13);
            this.lblFromDate.TabIndex = 5;
            this.lblFromDate.Text = "From Date";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(89, 277);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(207, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtitemcode
            // 
            this.txtitemcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemcode.Location = new System.Drawing.Point(126, 108);
            this.txtitemcode.MaxLength = 50;
            this.txtitemcode.Name = "txtitemcode";
            this.txtitemcode.Size = new System.Drawing.Size(216, 21);
            this.txtitemcode.TabIndex = 36;
            this.txtitemcode.Tag = "Enter Mobile No;";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.ForeColor = System.Drawing.Color.Black;
            this.lblPhone1.Location = new System.Drawing.Point(34, 111);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(69, 13);
            this.lblPhone1.TabIndex = 37;
            this.lblPhone1.Text = "ItemCode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(34, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 227;
            this.label7.Text = "ProductCode:";
            // 
            // txtproductcode
            // 
            this.txtproductcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductcode.Location = new System.Drawing.Point(126, 142);
            this.txtproductcode.MaxLength = 50;
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(216, 21);
            this.txtproductcode.TabIndex = 228;
            this.txtproductcode.Tag = "Enter Mobile No;";
            // 
            // lblInquiryNo
            // 
            this.lblInquiryNo.AutoSize = true;
            this.lblInquiryNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryNo.Location = new System.Drawing.Point(34, 175);
            this.lblInquiryNo.Name = "lblInquiryNo";
            this.lblInquiryNo.Size = new System.Drawing.Size(44, 13);
            this.lblInquiryNo.TabIndex = 229;
            this.lblInquiryNo.Text = "Sr No:";
            // 
            // txtsrno
            // 
            this.txtsrno.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsrno.Location = new System.Drawing.Point(126, 172);
            this.txtsrno.MaxLength = 50;
            this.txtsrno.Name = "txtsrno";
            this.txtsrno.Size = new System.Drawing.Size(216, 21);
            this.txtsrno.TabIndex = 230;
            this.txtsrno.Tag = "Enter Mobile No;";
            // 
            // frmPurchaseIndentFilter
            // 
            this.AcceptButton = this.btnApply;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(382, 335);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmPurchaseIndentFilter";
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
        internal System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.TextBox txtTodate;
        public System.Windows.Forms.TextBox txtitemcode;
        internal System.Windows.Forms.Label lblPhone1;
        internal System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtproductcode;
        public System.Windows.Forms.TextBox txtsrno;
        internal System.Windows.Forms.Label lblInquiryNo;
    }
}
