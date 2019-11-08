namespace Account.GUI.ItemStock
{
    partial class frmItemStockEntry
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
            this.txtfinalprod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbgodown = new System.Windows.Forms.ComboBox();
            this.btnItemLOV = new System.Windows.Forms.Button();
            this.ErrItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.txtOpeningStock = new System.Windows.Forms.TextBox();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.txtMinLevel = new System.Windows.Forms.TextBox();
            this.txtMaxLevel = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtRackNo = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblRackNo = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblReorder = new System.Windows.Forms.Label();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.lblOpeningStock = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
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
            this.grpErrorZone.Size = new System.Drawing.Size(386, 55);
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
            this.btnCancel.Location = new System.Drawing.Point(298, 417);
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
            this.btnSaveExit.Location = new System.Drawing.Point(163, 417);
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
            this.btnSaveContinue.Location = new System.Drawing.Point(18, 417);
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
            this.lblDelMsg.Location = new System.Drawing.Point(12, 386);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 2;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtfinalprod);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.cmbgodown);
            this.grpData.Controls.Add(this.btnItemLOV);
            this.grpData.Controls.Add(this.ErrItemName);
            this.grpData.Controls.Add(this.txtItemName);
            this.grpData.Controls.Add(this.txtUOM);
            this.grpData.Controls.Add(this.txtOpeningStock);
            this.grpData.Controls.Add(this.txtCurrentStock);
            this.grpData.Controls.Add(this.txtMinLevel);
            this.grpData.Controls.Add(this.txtMaxLevel);
            this.grpData.Controls.Add(this.txtReorderLevel);
            this.grpData.Controls.Add(this.txtLocation);
            this.grpData.Controls.Add(this.txtRackNo);
            this.grpData.Controls.Add(this.lblLocation);
            this.grpData.Controls.Add(this.lblRackNo);
            this.grpData.Controls.Add(this.dtpDate);
            this.grpData.Controls.Add(this.lblDate);
            this.grpData.Controls.Add(this.lblReorder);
            this.grpData.Controls.Add(this.lblCurrentStock);
            this.grpData.Controls.Add(this.lblOpeningStock);
            this.grpData.Controls.Add(this.lblUOM);
            this.grpData.Controls.Add(this.lblItemName);
            this.grpData.Location = new System.Drawing.Point(12, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(386, 308);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtfinalprod
            // 
            this.txtfinalprod.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinalprod.Location = new System.Drawing.Point(108, 71);
            this.txtfinalprod.MaxLength = 100;
            this.txtfinalprod.Name = "txtfinalprod";
            this.txtfinalprod.ReadOnly = true;
            this.txtfinalprod.Size = new System.Drawing.Size(232, 21);
            this.txtfinalprod.TabIndex = 35;
            this.txtfinalprod.Tag = "Enter location;";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(14, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Final Product:";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(37, 102);
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
            this.cmbgodown.Location = new System.Drawing.Point(108, 98);
            this.cmbgodown.Name = "cmbgodown";
            this.cmbgodown.Size = new System.Drawing.Size(232, 21);
            this.cmbgodown.TabIndex = 33;
            this.cmbgodown.Tag = "Select Godown Name;@";
            // 
            // btnItemLOV
            // 
            this.btnItemLOV.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnItemLOV.Location = new System.Drawing.Point(339, 15);
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
            this.ErrItemName.Location = new System.Drawing.Point(368, 20);
            this.ErrItemName.Name = "ErrItemName";
            this.ErrItemName.Size = new System.Drawing.Size(14, 13);
            this.ErrItemName.TabIndex = 5;
            this.ErrItemName.Text = "*";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(108, 17);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(232, 21);
            this.txtItemName.TabIndex = 2;
            this.txtItemName.Tag = "Enter item name;@";
            this.txtItemName.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemName_Validating);
            // 
            // txtUOM
            // 
            this.txtUOM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUOM.Location = new System.Drawing.Point(108, 44);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.ReadOnly = true;
            this.txtUOM.Size = new System.Drawing.Size(232, 21);
            this.txtUOM.TabIndex = 11;
            this.txtUOM.TabStop = false;
            this.txtUOM.Tag = "UOM;";
            // 
            // txtOpeningStock
            // 
            this.txtOpeningStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpeningStock.Location = new System.Drawing.Point(108, 125);
            this.txtOpeningStock.MaxLength = 18;
            this.txtOpeningStock.Name = "txtOpeningStock";
            this.txtOpeningStock.Size = new System.Drawing.Size(232, 21);
            this.txtOpeningStock.TabIndex = 15;
            this.txtOpeningStock.Tag = "Enter opening stock;";
            this.txtOpeningStock.Text = "0.000";
            this.txtOpeningStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOpeningStock.Leave += new System.EventHandler(this.txtOpeningStock_Leave);
            this.txtOpeningStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningStock_KeyPress);
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentStock.Location = new System.Drawing.Point(108, 153);
            this.txtCurrentStock.MaxLength = 50;
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Size = new System.Drawing.Size(232, 21);
            this.txtCurrentStock.TabIndex = 18;
            this.txtCurrentStock.TabStop = false;
            this.txtCurrentStock.Tag = "Current stock;";
            this.txtCurrentStock.Text = "0.000";
            this.txtCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMinLevel
            // 
            this.txtMinLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinLevel.Location = new System.Drawing.Point(245, 277);
            this.txtMinLevel.MaxLength = 18;
            this.txtMinLevel.Name = "txtMinLevel";
            this.txtMinLevel.Size = new System.Drawing.Size(69, 21);
            this.txtMinLevel.TabIndex = 20;
            this.txtMinLevel.Tag = "Enter minimum level;@";
            this.txtMinLevel.Text = "0.000";
            this.txtMinLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinLevel.Visible = false;
            this.txtMinLevel.Leave += new System.EventHandler(this.txtOpeningStock_Leave);
            this.txtMinLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningStock_KeyPress);
            // 
            // txtMaxLevel
            // 
            this.txtMaxLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxLevel.Location = new System.Drawing.Point(245, 277);
            this.txtMaxLevel.MaxLength = 18;
            this.txtMaxLevel.Name = "txtMaxLevel";
            this.txtMaxLevel.Size = new System.Drawing.Size(69, 21);
            this.txtMaxLevel.TabIndex = 23;
            this.txtMaxLevel.Tag = "Enter maxium level;@";
            this.txtMaxLevel.Text = "0.000";
            this.txtMaxLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxLevel.Visible = false;
            this.txtMaxLevel.Leave += new System.EventHandler(this.txtOpeningStock_Leave);
            this.txtMaxLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningStock_KeyPress);
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReorderLevel.Location = new System.Drawing.Point(108, 182);
            this.txtReorderLevel.MaxLength = 18;
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(232, 21);
            this.txtReorderLevel.TabIndex = 26;
            this.txtReorderLevel.Tag = "Enter reorder level;@";
            this.txtReorderLevel.Text = "0.000";
            this.txtReorderLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReorderLevel.Leave += new System.EventHandler(this.txtOpeningStock_Leave);
            this.txtReorderLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOpeningStock_KeyPress);
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(108, 214);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(232, 21);
            this.txtLocation.TabIndex = 29;
            this.txtLocation.Tag = "Enter location;";
            // 
            // txtRackNo
            // 
            this.txtRackNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRackNo.Location = new System.Drawing.Point(108, 241);
            this.txtRackNo.MaxLength = 100;
            this.txtRackNo.Name = "txtRackNo";
            this.txtRackNo.Size = new System.Drawing.Size(232, 21);
            this.txtRackNo.TabIndex = 31;
            this.txtRackNo.Tag = "Enter rack no;";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.Black;
            this.lblLocation.Location = new System.Drawing.Point(37, 218);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(59, 13);
            this.lblLocation.TabIndex = 28;
            this.lblLocation.Text = "Location:";
            // 
            // lblRackNo
            // 
            this.lblRackNo.AutoSize = true;
            this.lblRackNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRackNo.ForeColor = System.Drawing.Color.Black;
            this.lblRackNo.Location = new System.Drawing.Point(37, 240);
            this.lblRackNo.Name = "lblRackNo";
            this.lblRackNo.Size = new System.Drawing.Size(59, 13);
            this.lblRackNo.TabIndex = 30;
            this.lblRackNo.Text = "Rack No:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(108, 274);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(93, 21);
            this.dtpDate.TabIndex = 13;
            this.dtpDate.Tag = "Select opening stock date;";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(56, 278);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(39, 13);
            this.lblDate.TabIndex = 12;
            this.lblDate.Text = "Date:";
            // 
            // lblReorder
            // 
            this.lblReorder.AutoSize = true;
            this.lblReorder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReorder.ForeColor = System.Drawing.Color.Black;
            this.lblReorder.Location = new System.Drawing.Point(7, 182);
            this.lblReorder.Name = "lblReorder";
            this.lblReorder.Size = new System.Drawing.Size(92, 13);
            this.lblReorder.TabIndex = 25;
            this.lblReorder.Text = "Reorder Level:";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStock.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentStock.Location = new System.Drawing.Point(4, 156);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(92, 13);
            this.lblCurrentStock.TabIndex = 17;
            this.lblCurrentStock.Text = "Current Stock:";
            // 
            // lblOpeningStock
            // 
            this.lblOpeningStock.AutoSize = true;
            this.lblOpeningStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpeningStock.ForeColor = System.Drawing.Color.Black;
            this.lblOpeningStock.Location = new System.Drawing.Point(0, 128);
            this.lblOpeningStock.Name = "lblOpeningStock";
            this.lblOpeningStock.Size = new System.Drawing.Size(95, 13);
            this.lblOpeningStock.TabIndex = 14;
            this.lblOpeningStock.Text = "Opening Stock:";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.ForeColor = System.Drawing.Color.Black;
            this.lblUOM.Location = new System.Drawing.Point(61, 48);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(38, 13);
            this.lblUOM.TabIndex = 10;
            this.lblUOM.Text = "UOM:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(27, 21);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(76, 13);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Text = "Item Name:";
            // 
            // frmItemStockEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(410, 472);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpErrorZone);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmItemStockEntry";
            this.Load += new System.EventHandler(this.frmItemStockEntry_Load);
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
        internal System.Windows.Forms.TextBox txtUOM;
        internal System.Windows.Forms.TextBox txtOpeningStock;
        internal System.Windows.Forms.TextBox txtCurrentStock;
        internal System.Windows.Forms.TextBox txtMinLevel;
        internal System.Windows.Forms.TextBox txtMaxLevel;
        internal System.Windows.Forms.TextBox txtReorderLevel;
        internal System.Windows.Forms.TextBox txtLocation;
        internal System.Windows.Forms.TextBox txtRackNo;
        internal System.Windows.Forms.Label lblLocation;
        internal System.Windows.Forms.Label lblRackNo;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.Label lblReorder;
        internal System.Windows.Forms.Label lblCurrentStock;
        internal System.Windows.Forms.Label lblOpeningStock;
        internal System.Windows.Forms.Label lblUOM;
        internal System.Windows.Forms.Label lblItemName;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrItemName;
        private System.Windows.Forms.Button btnItemLOV;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbgodown;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtfinalprod;
    }
}
