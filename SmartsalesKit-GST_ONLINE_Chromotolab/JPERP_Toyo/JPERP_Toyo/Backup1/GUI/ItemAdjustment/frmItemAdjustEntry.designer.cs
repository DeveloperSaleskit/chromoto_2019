namespace Account.GUI.Item_Adjustment
{
    partial class frmItemAdjustEntry
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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbgodown = new System.Windows.Forms.ComboBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtDiffQty = new System.Windows.Forms.TextBox();
            this.lblDiffQty = new System.Windows.Forms.Label();
            this.btnItemLOV = new System.Windows.Forms.Button();
            this.ErrItemName = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblAdjustDate = new System.Windows.Forms.Label();
            this.dtpAdjustDate = new System.Windows.Forms.DateTimePicker();
            this.Errlabel1 = new System.Windows.Forms.Label();
            this.ErrQty = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpData.SuspendLayout();
            this.grpErrorZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(267, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(155, 315);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(107, 23);
            this.btnSaveExit.TabIndex = 4;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.cmbgodown);
            this.grpData.Controls.Add(this.txtItemName);
            this.grpData.Controls.Add(this.txtQty);
            this.grpData.Controls.Add(this.lblQty);
            this.grpData.Controls.Add(this.txtDiffQty);
            this.grpData.Controls.Add(this.lblDiffQty);
            this.grpData.Controls.Add(this.btnItemLOV);
            this.grpData.Controls.Add(this.ErrItemName);
            this.grpData.Controls.Add(this.lblItemName);
            this.grpData.Controls.Add(this.txtNarration);
            this.grpData.Controls.Add(this.lblNarration);
            this.grpData.Controls.Add(this.lblAdjustDate);
            this.grpData.Controls.Add(this.dtpAdjustDate);
            this.grpData.Controls.Add(this.Errlabel1);
            this.grpData.Controls.Add(this.ErrQty);
            this.grpData.Location = new System.Drawing.Point(12, 66);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(340, 242);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(25, 53);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(62, 13);
            this.lblCity.TabIndex = 35;
            this.lblCity.Text = "Godown :";
            // 
            // cmbgodown
            // 
            this.cmbgodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgodown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgodown.FormattingEnabled = true;
            this.cmbgodown.Location = new System.Drawing.Point(93, 45);
            this.cmbgodown.Name = "cmbgodown";
            this.cmbgodown.Size = new System.Drawing.Size(230, 21);
            this.cmbgodown.TabIndex = 36;
            this.cmbgodown.Tag = "Select Godown Name;@";
            this.cmbgodown.SelectedIndexChanged += new System.EventHandler(this.cmbgodown_SelectedIndexChanged);
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(93, 72);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(199, 21);
            this.txtItemName.TabIndex = 4;
            this.txtItemName.Tag = "Enter item name;@";
            this.txtItemName.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemName_Validating);
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(93, 99);
            this.txtQty.MaxLength = 18;
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(230, 21);
            this.txtQty.TabIndex = 8;
            this.txtQty.TabStop = false;
            this.txtQty.Tag = "QOH;";
            this.txtQty.Text = "0.000";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(52, 111);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(38, 13);
            this.lblQty.TabIndex = 7;
            this.lblQty.Text = "QOH:";
            // 
            // txtDiffQty
            // 
            this.txtDiffQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiffQty.Location = new System.Drawing.Point(90, 126);
            this.txtDiffQty.MaxLength = 18;
            this.txtDiffQty.Name = "txtDiffQty";
            this.txtDiffQty.Size = new System.Drawing.Size(233, 21);
            this.txtDiffQty.TabIndex = 10;
            this.txtDiffQty.Tag = "Enter adjust qty;@";
            this.txtDiffQty.Text = "0.000";
            this.txtDiffQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiffQty.Leave += new System.EventHandler(this.txtDiffQty_Leave);
            this.txtDiffQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiffQty_KeyPress);
            // 
            // lblDiffQty
            // 
            this.lblDiffQty.AutoSize = true;
            this.lblDiffQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiffQty.ForeColor = System.Drawing.Color.Black;
            this.lblDiffQty.Location = new System.Drawing.Point(18, 138);
            this.lblDiffQty.Name = "lblDiffQty";
            this.lblDiffQty.Size = new System.Drawing.Size(72, 13);
            this.lblDiffQty.TabIndex = 9;
            this.lblDiffQty.Text = "Adjust Qty:";
            // 
            // btnItemLOV
            // 
            this.btnItemLOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnItemLOV.Location = new System.Drawing.Point(293, 72);
            this.btnItemLOV.Name = "btnItemLOV";
            this.btnItemLOV.Size = new System.Drawing.Size(30, 23);
            this.btnItemLOV.TabIndex = 5;
            this.btnItemLOV.Tag = "Click to select item;@";
            this.btnItemLOV.Text = "...";
            this.btnItemLOV.UseVisualStyleBackColor = true;
            this.btnItemLOV.Click += new System.EventHandler(this.btnItemLOV_Click);
            // 
            // ErrItemName
            // 
            this.ErrItemName.AutoSize = true;
            this.ErrItemName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrItemName.ForeColor = System.Drawing.Color.Red;
            this.ErrItemName.Location = new System.Drawing.Point(322, 78);
            this.ErrItemName.Name = "ErrItemName";
            this.ErrItemName.Size = new System.Drawing.Size(14, 13);
            this.ErrItemName.TabIndex = 6;
            this.ErrItemName.Text = "*";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(14, 84);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(76, 13);
            this.lblItemName.TabIndex = 3;
            this.lblItemName.Text = "Item Name:";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(90, 153);
            this.txtNarration.MaxLength = 4000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNarration.Size = new System.Drawing.Size(233, 75);
            this.txtNarration.TabIndex = 13;
            this.txtNarration.Tag = "Enter narration;";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.ForeColor = System.Drawing.Color.Black;
            this.lblNarration.Location = new System.Drawing.Point(25, 165);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 12;
            this.lblNarration.Text = "Narration:";
            // 
            // lblAdjustDate
            // 
            this.lblAdjustDate.AutoSize = true;
            this.lblAdjustDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjustDate.ForeColor = System.Drawing.Color.Black;
            this.lblAdjustDate.Location = new System.Drawing.Point(11, 22);
            this.lblAdjustDate.Name = "lblAdjustDate";
            this.lblAdjustDate.Size = new System.Drawing.Size(79, 13);
            this.lblAdjustDate.TabIndex = 1;
            this.lblAdjustDate.Text = "Adjust Date:";
            // 
            // dtpAdjustDate
            // 
            this.dtpAdjustDate.CustomFormat = "";
            this.dtpAdjustDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpAdjustDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdjustDate.Location = new System.Drawing.Point(93, 18);
            this.dtpAdjustDate.Name = "dtpAdjustDate";
            this.dtpAdjustDate.Size = new System.Drawing.Size(93, 21);
            this.dtpAdjustDate.TabIndex = 2;
            this.dtpAdjustDate.Tag = "Select adjust date;";
            this.dtpAdjustDate.Value = new System.DateTime(2010, 10, 23, 0, 0, 0, 0);
            // 
            // Errlabel1
            // 
            this.Errlabel1.AutoSize = true;
            this.Errlabel1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.Errlabel1.ForeColor = System.Drawing.Color.Red;
            this.Errlabel1.Location = new System.Drawing.Point(322, 49);
            this.Errlabel1.Name = "Errlabel1";
            this.Errlabel1.Size = new System.Drawing.Size(14, 13);
            this.Errlabel1.TabIndex = 37;
            this.Errlabel1.Text = "*";
            // 
            // ErrQty
            // 
            this.ErrQty.AutoSize = true;
            this.ErrQty.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrQty.ForeColor = System.Drawing.Color.Red;
            this.ErrQty.Location = new System.Drawing.Point(321, 132);
            this.ErrQty.Name = "ErrQty";
            this.ErrQty.Size = new System.Drawing.Size(14, 13);
            this.ErrQty.TabIndex = 11;
            this.ErrQty.Text = "*";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(221, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 5);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(340, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(186, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(12, 315);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(136, 23);
            this.btnSaveContinue.TabIndex = 3;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(8, 315);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 2;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // frmItemAdjustEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(361, 374);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.lblDelMsg);
            this.Name = "frmItemAdjustEntry";
            this.Load += new System.EventHandler(this.frmItemAdjustEntry_Load);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.TextBox txtNarration;
        internal System.Windows.Forms.Label lblNarration;
        internal System.Windows.Forms.Label lblAdjustDate;
        internal System.Windows.Forms.DateTimePicker dtpAdjustDate;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Button btnItemLOV;
        private System.Windows.Forms.Label ErrItemName;
        internal System.Windows.Forms.TextBox txtItemName;
        internal System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label ErrQty;
        internal System.Windows.Forms.TextBox txtDiffQty;
        internal System.Windows.Forms.Label lblDiffQty;
        internal System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.TextBox txtQty;
        internal System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Label Errlabel1;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbgodown;
    }
}
