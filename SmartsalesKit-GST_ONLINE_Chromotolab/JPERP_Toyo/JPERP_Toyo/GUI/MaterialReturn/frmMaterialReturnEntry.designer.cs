namespace Account.GUI.MaterialReturn
{
    partial class frmMaterialReturnEntry
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
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtreamaingqty = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmaterialissuecode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtissueqty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtretunqty = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbemployee2 = new System.Windows.Forms.ComboBox();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbemployee1 = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbgodown = new System.Windows.Forms.ComboBox();
            this.btnItemLOV = new System.Windows.Forms.Button();
            this.ErrItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(413, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(235, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(268, 26);
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
            this.btnCancel.Location = new System.Drawing.Point(306, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(171, 450);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(129, 23);
            this.btnSaveExit.TabIndex = 4;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(26, 450);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(139, 23);
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
            this.lblDelMsg.Location = new System.Drawing.Point(12, 418);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 2;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtreamaingqty);
            this.grpData.Controls.Add(this.label5);
            this.grpData.Controls.Add(this.txtmaterialissuecode);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.txtissueqty);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtretunqty);
            this.grpData.Controls.Add(this.lblQty);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.cmbemployee2);
            this.grpData.Controls.Add(this.txtNarration);
            this.grpData.Controls.Add(this.lblNarration);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.cmbemployee1);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.cmbgodown);
            this.grpData.Controls.Add(this.btnItemLOV);
            this.grpData.Controls.Add(this.ErrItemName);
            this.grpData.Controls.Add(this.txtItemName);
            this.grpData.Controls.Add(this.lblItemName);
            this.grpData.Location = new System.Drawing.Point(12, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(413, 338);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtreamaingqty
            // 
            this.txtreamaingqty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreamaingqty.Location = new System.Drawing.Point(316, 120);
            this.txtreamaingqty.MaxLength = 18;
            this.txtreamaingqty.Name = "txtreamaingqty";
            this.txtreamaingqty.ReadOnly = true;
            this.txtreamaingqty.Size = new System.Drawing.Size(91, 21);
            this.txtreamaingqty.TabIndex = 212;
            this.txtreamaingqty.TabStop = false;
            this.txtreamaingqty.Tag = "QOH;";
            this.txtreamaingqty.Text = "0.000";
            this.txtreamaingqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(219, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 211;
            this.label5.Text = "Reamaing QTY";
            // 
            // txtmaterialissuecode
            // 
            this.txtmaterialissuecode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaterialissuecode.Location = new System.Drawing.Point(108, 58);
            this.txtmaterialissuecode.MaxLength = 18;
            this.txtmaterialissuecode.Name = "txtmaterialissuecode";
            this.txtmaterialissuecode.ReadOnly = true;
            this.txtmaterialissuecode.Size = new System.Drawing.Size(299, 21);
            this.txtmaterialissuecode.TabIndex = 210;
            this.txtmaterialissuecode.TabStop = false;
            this.txtmaterialissuecode.Tag = "QOH;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 26);
            this.label4.TabIndex = 209;
            this.label4.Text = "Materialissue\r\nCode";
            // 
            // txtissueqty
            // 
            this.txtissueqty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtissueqty.Location = new System.Drawing.Point(108, 120);
            this.txtissueqty.MaxLength = 18;
            this.txtissueqty.Name = "txtissueqty";
            this.txtissueqty.ReadOnly = true;
            this.txtissueqty.Size = new System.Drawing.Size(102, 21);
            this.txtissueqty.TabIndex = 208;
            this.txtissueqty.TabStop = false;
            this.txtissueqty.Tag = "QOH;";
            this.txtissueqty.Text = "0.000";
            this.txtissueqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 207;
            this.label1.Text = "Issue Qty";
            // 
            // txtretunqty
            // 
            this.txtretunqty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtretunqty.Location = new System.Drawing.Point(108, 151);
            this.txtretunqty.MaxLength = 18;
            this.txtretunqty.Name = "txtretunqty";
            this.txtretunqty.Size = new System.Drawing.Size(102, 21);
            this.txtretunqty.TabIndex = 206;
            this.txtretunqty.TabStop = false;
            this.txtretunqty.Tag = "QOH;";
            this.txtretunqty.Text = "0.000";
            this.txtretunqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtretunqty.Leave += new System.EventHandler(this.txtretunqty_Leave);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(11, 154);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(72, 13);
            this.lblQty.TabIndex = 205;
            this.lblQty.Text = "Return QTY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 201;
            this.label3.Text = "Returnto";
            // 
            // cmbemployee2
            // 
            this.cmbemployee2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbemployee2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbemployee2.FormattingEnabled = true;
            this.cmbemployee2.Location = new System.Drawing.Point(108, 207);
            this.cmbemployee2.Name = "cmbemployee2";
            this.cmbemployee2.Size = new System.Drawing.Size(299, 21);
            this.cmbemployee2.TabIndex = 202;
            this.cmbemployee2.Tag = "Select Godown Name;@";
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(108, 238);
            this.txtNarration.MaxLength = 4000;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNarration.Size = new System.Drawing.Size(299, 75);
            this.txtNarration.TabIndex = 39;
            this.txtNarration.Tag = "Enter narration;";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.ForeColor = System.Drawing.Color.Black;
            this.lblNarration.Location = new System.Drawing.Point(10, 269);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 38;
            this.lblNarration.Text = "Narration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Return By";
            // 
            // cmbemployee1
            // 
            this.cmbemployee1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbemployee1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbemployee1.FormattingEnabled = true;
            this.cmbemployee1.Location = new System.Drawing.Point(108, 179);
            this.cmbemployee1.Name = "cmbemployee1";
            this.cmbemployee1.Size = new System.Drawing.Size(299, 21);
            this.cmbemployee1.TabIndex = 37;
            this.cmbemployee1.Tag = "Select Godown Name;@";
            this.cmbemployee1.SelectedIndexChanged += new System.EventHandler(this.cmbemployee1_SelectedIndexChanged);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(10, 92);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(62, 13);
            this.lblCity.TabIndex = 32;
            this.lblCity.Text = "Godown :";
            // 
            // cmbgodown
            // 
            this.cmbgodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgodown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgodown.FormattingEnabled = true;
            this.cmbgodown.Location = new System.Drawing.Point(108, 89);
            this.cmbgodown.Name = "cmbgodown";
            this.cmbgodown.Size = new System.Drawing.Size(299, 21);
            this.cmbgodown.TabIndex = 33;
            this.cmbgodown.Tag = "Select Godown Name;@";
            this.cmbgodown.SelectedIndexChanged += new System.EventHandler(this.cmbgodown_SelectedIndexChanged);
            // 
            // btnItemLOV
            // 
            this.btnItemLOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnItemLOV.Location = new System.Drawing.Point(363, 22);
            this.btnItemLOV.Name = "btnItemLOV";
            this.btnItemLOV.Size = new System.Drawing.Size(30, 23);
            this.btnItemLOV.TabIndex = 3;
            this.btnItemLOV.Tag = "Click to select item;@";
            this.btnItemLOV.Text = "...";
            this.btnItemLOV.UseVisualStyleBackColor = true;
            this.btnItemLOV.Visible = false;
            this.btnItemLOV.Click += new System.EventHandler(this.btnItemLOV_Click);
            // 
            // ErrItemName
            // 
            this.ErrItemName.AutoSize = true;
            this.ErrItemName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrItemName.ForeColor = System.Drawing.Color.Red;
            this.ErrItemName.Location = new System.Drawing.Point(392, 27);
            this.ErrItemName.Name = "ErrItemName";
            this.ErrItemName.Size = new System.Drawing.Size(14, 13);
            this.ErrItemName.TabIndex = 5;
            this.ErrItemName.Text = "*";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(108, 24);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(249, 21);
            this.txtItemName.TabIndex = 2;
            this.txtItemName.Tag = "Enter item name;@";
            this.txtItemName.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemName_Validating);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(11, 27);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(76, 13);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Item Name:";
            // 
            // frmMaterialReturnEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(435, 525);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpErrorZone);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMaterialReturnEntry";
            this.Load += new System.EventHandler(this.frmMaterialReturnEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
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
        private System.Windows.Forms.Label lblDelMsg;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.TextBox txtItemName;
        internal System.Windows.Forms.Label lblItemName;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrItemName;
        private System.Windows.Forms.Button btnItemLOV;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbgodown;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbemployee1;
        internal System.Windows.Forms.TextBox txtNarration;
        internal System.Windows.Forms.Label lblNarration;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox cmbemployee2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtretunqty;
        internal System.Windows.Forms.Label lblQty;
        internal System.Windows.Forms.TextBox txtissueqty;
        internal System.Windows.Forms.TextBox txtmaterialissuecode;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtreamaingqty;
        internal System.Windows.Forms.Label label5;
    }
}
