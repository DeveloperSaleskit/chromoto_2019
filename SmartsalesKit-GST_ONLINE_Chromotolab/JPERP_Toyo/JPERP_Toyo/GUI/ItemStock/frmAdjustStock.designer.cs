namespace Account.GUI.ItemStock
{
    partial class frmAdjustStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.lblAdjustDate = new System.Windows.Forms.Label();
            this.dtpAdjustDate = new System.Windows.Forms.DateTimePicker();
            this.dgvAdjustStock = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.SelectRec = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QOH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiffQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GodownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Godown_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustStock)).BeginInit();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 5);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(597, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(585, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtNarration);
            this.grpData.Controls.Add(this.lblNarration);
            this.grpData.Controls.Add(this.lblAdjustDate);
            this.grpData.Controls.Add(this.dtpAdjustDate);
            this.grpData.Controls.Add(this.dgvAdjustStock);
            this.grpData.Location = new System.Drawing.Point(12, 66);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(597, 471);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(77, 386);
            this.txtNarration.MaxLength = 200;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNarration.Size = new System.Drawing.Size(336, 75);
            this.txtNarration.TabIndex = 4;
            this.txtNarration.Tag = "Enter narration;";
            this.txtNarration.Text = "Physical Stock Verification";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarration.ForeColor = System.Drawing.Color.Black;
            this.lblNarration.Location = new System.Drawing.Point(6, 389);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 3;
            this.lblNarration.Text = "Narration:";
            // 
            // lblAdjustDate
            // 
            this.lblAdjustDate.AutoSize = true;
            this.lblAdjustDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdjustDate.ForeColor = System.Drawing.Color.Black;
            this.lblAdjustDate.Location = new System.Drawing.Point(6, 16);
            this.lblAdjustDate.Name = "lblAdjustDate";
            this.lblAdjustDate.Size = new System.Drawing.Size(79, 13);
            this.lblAdjustDate.TabIndex = 0;
            this.lblAdjustDate.Text = "Adjust Date:";
            // 
            // dtpAdjustDate
            // 
            this.dtpAdjustDate.CustomFormat = "";
            this.dtpAdjustDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpAdjustDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAdjustDate.Location = new System.Drawing.Point(91, 12);
            this.dtpAdjustDate.Name = "dtpAdjustDate";
            this.dtpAdjustDate.Size = new System.Drawing.Size(93, 21);
            this.dtpAdjustDate.TabIndex = 1;
            this.dtpAdjustDate.Tag = "Select adjust date;";
            // 
            // dgvAdjustStock
            // 
            this.dgvAdjustStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdjustStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectRec,
            this.ItemID,
            this.ItemCode,
            this.ItemName,
            this.QOH,
            this.ActualQty,
            this.DiffQty,
            this.GodownID,
            this.Godown_name});
            this.dgvAdjustStock.Location = new System.Drawing.Point(3, 39);
            this.dgvAdjustStock.Name = "dgvAdjustStock";
            this.dgvAdjustStock.Size = new System.Drawing.Size(591, 339);
            this.dgvAdjustStock.TabIndex = 2;
            this.dgvAdjustStock.Tag = "List of items;";
            this.dgvAdjustStock.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdjustStock_CellLeave);
            this.dgvAdjustStock.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdjustStock_CellValidated);
            this.dgvAdjustStock.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAdjustStock_CellPainting);
            this.dgvAdjustStock.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAdjustStock_EditingControlShowing);
            this.dgvAdjustStock.CurrentCellChanged += new System.EventHandler(this.dgvAdjustStock_CurrentCellChanged);
            this.dgvAdjustStock.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAdjustStock_DataError);
            this.dgvAdjustStock.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAdjustStock_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(509, 543);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(386, 543);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(117, 23);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // SelectRec
            // 
            this.SelectRec.HeaderText = "Select";
            this.SelectRec.Name = "SelectRec";
            this.SelectRec.Width = 60;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            // 
            // QOH
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QOH.DefaultCellStyle = dataGridViewCellStyle1;
            this.QOH.HeaderText = "Qty(As Per S/W)";
            this.QOH.Name = "QOH";
            // 
            // ActualQty
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = "0.000";
            this.ActualQty.DefaultCellStyle = dataGridViewCellStyle2;
            this.ActualQty.HeaderText = "Physical Qty";
            this.ActualQty.Name = "ActualQty";
            // 
            // DiffQty
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = "0.000";
            this.DiffQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiffQty.HeaderText = "Diff. Qty";
            this.DiffQty.Name = "DiffQty";
            // 
            // GodownID
            // 
            this.GodownID.HeaderText = "GodownID";
            this.GodownID.Name = "GodownID";
            this.GodownID.Visible = false;
            // 
            // Godown_name
            // 
            this.Godown_name.HeaderText = "Godown";
            this.Godown_name.Name = "Godown_name";
            this.Godown_name.Visible = false;
            // 
            // frmAdjustStock
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(619, 601);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmAdjustStock";
            this.Load += new System.EventHandler(this.frmAdjustStock_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdjustStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvAdjustStock;
        internal System.Windows.Forms.DateTimePicker dtpAdjustDate;
        internal System.Windows.Forms.Label lblAdjustDate;
        internal System.Windows.Forms.TextBox txtNarration;
        internal System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn QOH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiffQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn GodownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Godown_name;
    }
}
