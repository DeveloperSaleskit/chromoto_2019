namespace Account.GUI.ItemRegister
{
    partial class frmItemFilter
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
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdUOM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblFromCode = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtproductcode = new System.Windows.Forms.TextBox();
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
            this.grpErrorZone.Size = new System.Drawing.Size(441, 55);
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
            this.grpData.Controls.Add(this.txtproductcode);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.dtpTodate);
            this.grpData.Controls.Add(this.txtTodate);
            this.grpData.Controls.Add(this.lblToDate);
            this.grpData.Controls.Add(this.dtpFromDate);
            this.grpData.Controls.Add(this.txtFromDate);
            this.grpData.Controls.Add(this.lblFromDate);
            this.grpData.Controls.Add(this.txtCustomer);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.cmdUOM);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.txtItemName);
            this.grpData.Controls.Add(this.lblItemName);
            this.grpData.Controls.Add(this.lblFromCode);
            this.grpData.Controls.Add(this.txtItemCode);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(441, 197);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // dtpTodate
            // 
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(403, 139);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(18, 21);
            this.dtpTodate.TabIndex = 7;
            this.dtpTodate.TabStop = false;
            this.dtpTodate.Tag = "Select to date;";
            this.dtpTodate.CloseUp += new System.EventHandler(this.dtpTodate_CloseUp);
            // 
            // txtTodate
            // 
            this.txtTodate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTodate.Location = new System.Drawing.Point(313, 139);
            this.txtTodate.MaxLength = 50;
            this.txtTodate.Name = "txtTodate";
            this.txtTodate.Size = new System.Drawing.Size(87, 21);
            this.txtTodate.TabIndex = 6;
            this.txtTodate.Tag = "Enter to date;";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblToDate.Location = new System.Drawing.Point(257, 142);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(52, 13);
            this.lblToDate.TabIndex = 22;
            this.lblToDate.Text = "To Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(210, 139);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(20, 21);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.TabStop = false;
            this.dtpFromDate.Tag = "Select from date;";
            this.dtpFromDate.CloseUp += new System.EventHandler(this.dtpFromDate_CloseUp);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromDate.Location = new System.Drawing.Point(116, 139);
            this.txtFromDate.MaxLength = 50;
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(88, 21);
            this.txtFromDate.TabIndex = 4;
            this.txtFromDate.Tag = "Enter from date;";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(10, 141);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(67, 13);
            this.lblFromDate.TabIndex = 20;
            this.lblFromDate.Text = "From Date";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(116, 112);
            this.txtCustomer.MaxLength = 50;
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(307, 21);
            this.txtCustomer.TabIndex = 3;
            this.txtCustomer.Tag = "Enter item;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Customer";
            // 
            // cmdUOM
            // 
            this.cmdUOM.FormattingEnabled = true;
            this.cmdUOM.Location = new System.Drawing.Point(116, 79);
            this.cmdUOM.Name = "cmdUOM";
            this.cmdUOM.Size = new System.Drawing.Size(103, 21);
            this.cmdUOM.TabIndex = 2;
            this.cmdUOM.Tag = "Select UOM;";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "UOM";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(116, 47);
            this.txtItemName.MaxLength = 50;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(307, 21);
            this.txtItemName.TabIndex = 1;
            this.txtItemName.Tag = "Enter item;";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblItemName.Location = new System.Drawing.Point(6, 47);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(34, 13);
            this.lblItemName.TabIndex = 9;
            this.lblItemName.Text = "Item";
            // 
            // lblFromCode
            // 
            this.lblFromCode.AutoSize = true;
            this.lblFromCode.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromCode.Location = new System.Drawing.Point(6, 15);
            this.lblFromCode.Name = "lblFromCode";
            this.lblFromCode.Size = new System.Drawing.Size(68, 13);
            this.lblFromCode.TabIndex = 2;
            this.lblFromCode.Text = "Item Code";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(116, 15);
            this.txtItemCode.MaxLength = 10;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(307, 21);
            this.txtItemCode.TabIndex = 0;
            this.txtItemCode.Tag = "Enter from code;";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(154, 266);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(225, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Product Code";
            // 
            // txtproductcode
            // 
            this.txtproductcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductcode.Location = new System.Drawing.Point(315, 79);
            this.txtproductcode.MaxLength = 10;
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(108, 21);
            this.txtproductcode.TabIndex = 24;
            this.txtproductcode.Tag = "Enter from code;";
            // 
            // frmItemFilter
            // 
            this.AcceptButton = this.btnApply;
            this.ClientSize = new System.Drawing.Size(465, 321);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmItemFilter";
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
        internal System.Windows.Forms.TextBox txtItemCode;
        internal System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ComboBox cmdUOM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.TextBox txtTodate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label lblFromDate;
        internal System.Windows.Forms.TextBox txtproductcode;
        internal System.Windows.Forms.Label label3;
    }
}
