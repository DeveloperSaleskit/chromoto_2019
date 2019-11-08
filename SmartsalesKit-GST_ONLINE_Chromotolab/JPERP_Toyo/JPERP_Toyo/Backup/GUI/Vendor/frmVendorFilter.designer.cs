namespace Account.GUI.Vendor
{
    partial class frmVendorFilter
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
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblFromCode = new System.Windows.Forms.Label();
            this.txtFromCode = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.lblSourceOfLead = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(11, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(355, 55);
            this.grpErrorZone.TabIndex = 1;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(338, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.cmbcategory);
            this.grpData.Controls.Add(this.lblSourceOfLead);
            this.grpData.Controls.Add(this.cmbCity);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.txtCompany);
            this.grpData.Controls.Add(this.lblCompany);
            this.grpData.Controls.Add(this.lblFromCode);
            this.grpData.Controls.Add(this.txtFromCode);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(11, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(355, 136);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(148, 74);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(196, 21);
            this.cmbCity.TabIndex = 63;
            this.cmbCity.Tag = "Select city;";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(6, 77);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 62;
            this.lblCity.Text = "City";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(148, 47);
            this.txtCompany.MaxLength = 100;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(196, 21);
            this.txtCompany.TabIndex = 61;
            this.txtCompany.Tag = "Enter company;";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(6, 51);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(62, 13);
            this.lblCompany.TabIndex = 60;
            this.lblCompany.Text = "Company";
            // 
            // lblFromCode
            // 
            this.lblFromCode.AutoSize = true;
            this.lblFromCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromCode.Location = new System.Drawing.Point(6, 23);
            this.lblFromCode.Name = "lblFromCode";
            this.lblFromCode.Size = new System.Drawing.Size(82, 13);
            this.lblFromCode.TabIndex = 58;
            this.lblFromCode.Text = "Vendor Code";
            // 
            // txtFromCode
            // 
            this.txtFromCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromCode.Location = new System.Drawing.Point(148, 20);
            this.txtFromCode.MaxLength = 10;
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Size = new System.Drawing.Size(135, 21);
            this.txtFromCode.TabIndex = 59;
            this.txtFromCode.Tag = "Enter vendor code;";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(255, 205);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cmbcategory
            // 
            this.cmbcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Items.AddRange(new object[] {
            "New Paper Advertise",
            "Hoarding",
            "Radio Adversie",
            "Website",
            "Exhibition",
            "Inter Net Advertise",
            "Reference",
            "Other"});
            this.cmbcategory.Location = new System.Drawing.Point(148, 101);
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.Size = new System.Drawing.Size(196, 21);
            this.cmbcategory.TabIndex = 75;
            this.cmbcategory.Tag = "Select source of Inquiry;@";
            // 
            // lblSourceOfLead
            // 
            this.lblSourceOfLead.AutoSize = true;
            this.lblSourceOfLead.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceOfLead.ForeColor = System.Drawing.Color.Black;
            this.lblSourceOfLead.Location = new System.Drawing.Point(6, 104);
            this.lblSourceOfLead.Name = "lblSourceOfLead";
            this.lblSourceOfLead.Size = new System.Drawing.Size(60, 13);
            this.lblSourceOfLead.TabIndex = 76;
            this.lblSourceOfLead.Text = "Category";
            // 
            // frmVendorFilter
            // 
            this.ClientSize = new System.Drawing.Size(377, 267);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmVendorFilter";
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
        internal System.Windows.Forms.Label lblFromCode;
        internal System.Windows.Forms.TextBox txtFromCode;
        internal System.Windows.Forms.TextBox txtCompany;
        internal System.Windows.Forms.Label lblCompany;
        internal System.Windows.Forms.ComboBox cmbCity;
        internal System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.ComboBox cmbcategory;
        internal System.Windows.Forms.Label lblSourceOfLead;
    }
}
