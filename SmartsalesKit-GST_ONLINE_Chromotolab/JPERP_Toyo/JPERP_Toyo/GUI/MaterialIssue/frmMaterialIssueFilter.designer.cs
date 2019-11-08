namespace Account.GUI.MaterialIssue
{
    partial class frmMaterialIssueFilter
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
            this.label3 = new System.Windows.Forms.Label();
            this.chkRtrnable = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbgodown = new System.Windows.Forms.ComboBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblFromCode = new System.Windows.Forms.Label();
            this.txtFromCode = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmicode = new System.Windows.Forms.TextBox();
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
            this.grpErrorZone.Size = new System.Drawing.Size(340, 55);
            this.grpErrorZone.TabIndex = 1;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(328, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.txtmicode);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.chkRtrnable);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.cmbgodown);
            this.grpData.Controls.Add(this.txtItemName);
            this.grpData.Controls.Add(this.lblItemName);
            this.grpData.Controls.Add(this.lblFromCode);
            this.grpData.Controls.Add(this.txtFromCode);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(340, 188);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(6, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 201;
            this.label3.Text = "Returnable\r\nItem";
            // 
            // chkRtrnable
            // 
            this.chkRtrnable.AutoSize = true;
            this.chkRtrnable.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRtrnable.Location = new System.Drawing.Point(128, 139);
            this.chkRtrnable.Name = "chkRtrnable";
            this.chkRtrnable.Size = new System.Drawing.Size(88, 17);
            this.chkRtrnable.TabIndex = 200;
            this.chkRtrnable.Tag = "Click to create account;@";
            this.chkRtrnable.Text = "Returnable";
            this.chkRtrnable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(6, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 151;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 150;
            this.label1.Text = "Godown";
            // 
            // cmbgodown
            // 
            this.cmbgodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgodown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgodown.FormattingEnabled = true;
            this.cmbgodown.Location = new System.Drawing.Point(128, 74);
            this.cmbgodown.Name = "cmbgodown";
            this.cmbgodown.Size = new System.Drawing.Size(200, 21);
            this.cmbgodown.TabIndex = 149;
            this.cmbgodown.Tag = "Select Godown Name;";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(128, 47);
            this.txtItemName.MaxLength = 200;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(200, 21);
            this.txtItemName.TabIndex = 18;
            this.txtItemName.Tag = "Enter item name;";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblItemName.Location = new System.Drawing.Point(6, 50);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(71, 13);
            this.lblItemName.TabIndex = 17;
            this.lblItemName.Text = "Item Name";
            // 
            // lblFromCode
            // 
            this.lblFromCode.AutoSize = true;
            this.lblFromCode.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromCode.Location = new System.Drawing.Point(6, 23);
            this.lblFromCode.Name = "lblFromCode";
            this.lblFromCode.Size = new System.Drawing.Size(68, 13);
            this.lblFromCode.TabIndex = 16;
            this.lblFromCode.Text = "Item Code";
            // 
            // txtFromCode
            // 
            this.txtFromCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromCode.Location = new System.Drawing.Point(128, 20);
            this.txtFromCode.MaxLength = 10;
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Size = new System.Drawing.Size(200, 21);
            this.txtFromCode.TabIndex = 15;
            this.txtFromCode.Tag = "Enter item code;";
            // 
            // btnApply
            // 
            this.btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApply.Location = new System.Drawing.Point(240, 266);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(100, 23);
            this.btnApply.TabIndex = 27;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 26);
            this.label4.TabIndex = 203;
            this.label4.Text = "Material\r\nIssue Code";
            // 
            // txtmicode
            // 
            this.txtmicode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmicode.Location = new System.Drawing.Point(128, 106);
            this.txtmicode.MaxLength = 10;
            this.txtmicode.Name = "txtmicode";
            this.txtmicode.Size = new System.Drawing.Size(200, 21);
            this.txtmicode.TabIndex = 202;
            this.txtmicode.Tag = "Enter item code;";
            // 
            // frmMaterialIssueFilter
            // 
            this.ClientSize = new System.Drawing.Size(362, 345);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmMaterialIssueFilter";
            this.Load += new System.EventHandler(this.frmMaterialIssueFilter_Load);
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
        internal System.Windows.Forms.TextBox txtFromCode;
        internal System.Windows.Forms.Label lblFromCode;
        internal System.Windows.Forms.Label lblItemName;
        internal System.Windows.Forms.TextBox txtItemName;
        internal System.Windows.Forms.ComboBox cmbgodown;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRtrnable;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtmicode;
    }
}
