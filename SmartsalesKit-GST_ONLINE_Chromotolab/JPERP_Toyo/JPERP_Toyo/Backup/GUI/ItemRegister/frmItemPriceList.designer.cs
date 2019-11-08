namespace Account.GUI.ItemRegister
{
    partial class frmItemPriceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdates = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvUpdateRatesList = new System.Windows.Forms.DataGridView();
            this.IsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblApplyTowhich = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.cmbApply = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateCaption = new System.Windows.Forms.Label();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateRatesList)).BeginInit();
            this.grpErrorZone.SuspendLayout();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(598, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdates
            // 
            this.btnUpdates.Location = new System.Drawing.Point(484, 372);
            this.btnUpdates.Name = "btnUpdates";
            this.btnUpdates.Size = new System.Drawing.Size(108, 23);
            this.btnUpdates.TabIndex = 2;
            this.btnUpdates.Tag = "Click to update rates;";
            this.btnUpdates.Text = "Update ";
            this.btnUpdates.UseVisualStyleBackColor = true;
            this.btnUpdates.Click += new System.EventHandler(this.btnUpdates_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvUpdateRatesList);
            this.grpData.Controls.Add(this.lblTotRec);
            this.grpData.Location = new System.Drawing.Point(8, 132);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(690, 233);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // dgvUpdateRatesList
            // 
            this.dgvUpdateRatesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpdateRatesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsSelect,
            this.ItemName,
            this.ItemID,
            this.Rate,
            this.VatRate,
            this.UOMID,
            this.ItemClassID,
            this.CategoryID});
            this.dgvUpdateRatesList.Location = new System.Drawing.Point(6, 34);
            this.dgvUpdateRatesList.Name = "dgvUpdateRatesList";
            this.dgvUpdateRatesList.Size = new System.Drawing.Size(678, 191);
            this.dgvUpdateRatesList.TabIndex = 1;
            this.dgvUpdateRatesList.Tag = "List of update rates;";
            this.dgvUpdateRatesList.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateRatesList_CellValidated);
            this.dgvUpdateRatesList.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvUpdateRatesList_CellValidating);
            this.dgvUpdateRatesList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUpdateRatesList_CellPainting);
            this.dgvUpdateRatesList.CurrentCellChanged += new System.EventHandler(this.dgvUpdateRatesList_CurrentCellChanged);
            this.dgvUpdateRatesList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvUpdateRatesList_DataError);
            // 
            // IsSelect
            // 
            this.IsSelect.HeaderText = "Select";
            this.IsSelect.Name = "IsSelect";
            this.IsSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // Rate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Rate.DefaultCellStyle = dataGridViewCellStyle1;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // VatRate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VatRate.DefaultCellStyle = dataGridViewCellStyle2;
            this.VatRate.HeaderText = "Vat Rate";
            this.VatRate.Name = "VatRate";
            // 
            // UOMID
            // 
            this.UOMID.HeaderText = "UOMID";
            this.UOMID.Name = "UOMID";
            this.UOMID.Visible = false;
            // 
            // ItemClassID
            // 
            this.ItemClassID.HeaderText = "ItemClassID";
            this.ItemClassID.Name = "ItemClassID";
            this.ItemClassID.Visible = false;
            // 
            // CategoryID
            // 
            this.CategoryID.HeaderText = "CategoryID";
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Visible = false;
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotRec.Location = new System.Drawing.Point(6, 13);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(96, 18);
            this.lblTotRec.TabIndex = 0;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.Black;
            this.lblValue.Location = new System.Drawing.Point(385, 33);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(44, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Value:";
            // 
            // lblApplyTowhich
            // 
            this.lblApplyTowhich.AutoSize = true;
            this.lblApplyTowhich.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplyTowhich.ForeColor = System.Drawing.Color.Black;
            this.lblApplyTowhich.Location = new System.Drawing.Point(150, 33);
            this.lblApplyTowhich.Name = "lblApplyTowhich";
            this.lblApplyTowhich.Size = new System.Drawing.Size(100, 13);
            this.lblApplyTowhich.TabIndex = 2;
            this.lblApplyTowhich.Text = "Apply To Which:";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(432, 29);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(129, 21);
            this.txtValue.TabIndex = 5;
            this.txtValue.Tag = "Enter value;";
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // cmbApply
            // 
            this.cmbApply.FormattingEnabled = true;
            this.cmbApply.Items.AddRange(new object[] {
            "--Select--",
            "Rate",
            "Vat Rate"});
            this.cmbApply.Location = new System.Drawing.Point(253, 29);
            this.cmbApply.Name = "cmbApply";
            this.cmbApply.Size = new System.Drawing.Size(121, 21);
            this.cmbApply.TabIndex = 3;
            this.cmbApply.Tag = "Select for apply;";
            this.cmbApply.SelectedIndexChanged += new System.EventHandler(this.cmbApply_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(50, 29);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(91, 21);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.Tag = "Select date;";
            // 
            // lblDateCaption
            // 
            this.lblDateCaption.AutoSize = true;
            this.lblDateCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateCaption.ForeColor = System.Drawing.Color.Black;
            this.lblDateCaption.Location = new System.Drawing.Point(8, 32);
            this.lblDateCaption.Name = "lblDateCaption";
            this.lblDateCaption.Size = new System.Drawing.Size(39, 13);
            this.lblDateCaption.TabIndex = 0;
            this.lblDateCaption.Text = "Date:";
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(8, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(690, 55);
            this.grpErrorZone.TabIndex = 26;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 14);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(677, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.lblValue);
            this.grpFilter.Controls.Add(this.btnApply);
            this.grpFilter.Controls.Add(this.lblApplyTowhich);
            this.grpFilter.Controls.Add(this.dtpDate);
            this.grpFilter.Controls.Add(this.lblDateCaption);
            this.grpFilter.Controls.Add(this.txtValue);
            this.grpFilter.Controls.Add(this.cmbApply);
            this.grpFilter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(8, 63);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(690, 65);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(581, 27);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(103, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Tag = "Click to apply all item;";
            this.btnApply.Text = "Apply To All";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmItemPriceList
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(706, 427);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdates);
            this.Controls.Add(this.grpData);
            this.Name = "frmItemPriceList";
            this.Load += new System.EventHandler(this.frmItemPriceList_Load);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnUpdates, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpFilter, 0);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateRatesList)).EndInit();
            this.grpErrorZone.ResumeLayout(false);
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnUpdates;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.Label lblValue;
        internal System.Windows.Forms.Label lblApplyTowhich;
        internal System.Windows.Forms.TextBox txtValue;
        internal System.Windows.Forms.ComboBox cmbApply;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.Label lblDateCaption;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Label lblTotRec;
        internal System.Windows.Forms.DataGridView dgvUpdateRatesList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
    }
}
