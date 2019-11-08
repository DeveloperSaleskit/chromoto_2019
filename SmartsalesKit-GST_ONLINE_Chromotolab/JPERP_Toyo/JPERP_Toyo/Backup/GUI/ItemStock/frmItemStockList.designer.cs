namespace Account.GUI.ItemStock
{
    partial class frmItemStockList
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
            this.lblTotRec = new System.Windows.Forms.Label();
            this.dgvItemStock = new System.Windows.Forms.DataGridView();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QOH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReorderLvl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RackNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Godown_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAdjustment = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbreports = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemStock)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRec.Location = new System.Drawing.Point(12, 73);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(81, 17);
            this.lblTotRec.TabIndex = 18;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // dgvItemStock
            // 
            this.dgvItemStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCode,
            this.ItemID,
            this.StockID,
            this.ItemName,
            this.UOM,
            this.QOH,
            this.MinLevel,
            this.MaxLevel,
            this.ReorderLvl,
            this.StockLocation,
            this.RackNo,
            this.Godown_name,
            this.ProductCode});
            this.dgvItemStock.Location = new System.Drawing.Point(12, 95);
            this.dgvItemStock.Name = "dgvItemStock";
            this.dgvItemStock.Size = new System.Drawing.Size(1320, 421);
            this.dgvItemStock.TabIndex = 3;
            this.dgvItemStock.Tag = "List of item stock;";
            this.dgvItemStock.VirtualMode = true;
            this.dgvItemStock.Sorted += new System.EventHandler(this.dgvItemStock_Sorted);
            this.dgvItemStock.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvItemStock_CellPainting);
            this.dgvItemStock.SelectionChanged += new System.EventHandler(this.dgvItemStock_SelectionChanged);
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Name = "ItemCode";
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // StockID
            // 
            this.StockID.HeaderText = "StockID";
            this.StockID.Name = "StockID";
            this.StockID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            // 
            // QOH
            // 
            this.QOH.HeaderText = "QOH";
            this.QOH.Name = "QOH";
            // 
            // MinLevel
            // 
            this.MinLevel.HeaderText = "Min Level";
            this.MinLevel.Name = "MinLevel";
            // 
            // MaxLevel
            // 
            this.MaxLevel.HeaderText = "Max Level";
            this.MaxLevel.Name = "MaxLevel";
            // 
            // ReorderLvl
            // 
            this.ReorderLvl.HeaderText = "Reorder Level";
            this.ReorderLvl.Name = "ReorderLvl";
            // 
            // StockLocation
            // 
            this.StockLocation.HeaderText = "Location";
            this.StockLocation.Name = "StockLocation";
            // 
            // RackNo
            // 
            this.RackNo.HeaderText = "Rack No";
            this.RackNo.Name = "RackNo";
            // 
            // Godown_name
            // 
            this.Godown_name.HeaderText = "Godown Name";
            this.Godown_name.Name = "Godown_name";
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            // 
            // BtnAdjustment
            // 
            this.BtnAdjustment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdjustment.Location = new System.Drawing.Point(112, 12);
            this.BtnAdjustment.Name = "BtnAdjustment";
            this.BtnAdjustment.Size = new System.Drawing.Size(100, 23);
            this.BtnAdjustment.TabIndex = 3;
            this.BtnAdjustment.Tag = "Click to adjust stock of item;";
            this.BtnAdjustment.Text = "Adjustment";
            this.BtnAdjustment.UseVisualStyleBackColor = true;
            this.BtnAdjustment.Click += new System.EventHandler(this.BtnAdjustment_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnClear);
            this.groupBox4.Controls.Add(this.btnHelp);
            this.groupBox4.Controls.Add(this.btnClose);
            this.groupBox4.Location = new System.Drawing.Point(1004, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(298, 49);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Other";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(6, 17);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 0;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnHelp.Location = new System.Drawing.Point(218, 17);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(76, 23);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Tag = "Click to Download Help File of  Customer;";
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(112, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.cmbreports);
            this.groupBox3.Controls.Add(this.btnApply);
            this.groupBox3.Location = new System.Drawing.Point(513, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(386, 45);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Format Selection";
            // 
            // cmbreports
            // 
            this.cmbreports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbreports.FormattingEnabled = true;
            this.cmbreports.Location = new System.Drawing.Point(225, 17);
            this.cmbreports.Name = "cmbreports";
            this.cmbreports.Size = new System.Drawing.Size(151, 21);
            this.cmbreports.TabIndex = 1;
            this.cmbreports.Tag = "Select city;@";
            this.cmbreports.SelectedIndexChanged += new System.EventHandler(this.cmbreports_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnApply.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(113, 15);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(106, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Report Filter";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnAdjustment);
            this.groupBox2.Location = new System.Drawing.Point(272, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 44);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(6, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "Click to edit selected Inquiry;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(157, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Click to delete selected Inquiry;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Enabled = false;
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(51, 26);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "Click to add Inquiry;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // frmItemStockList
            // 
            this.ClientSize = new System.Drawing.Size(1314, 548);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lblTotRec);
            this.Controls.Add(this.dgvItemStock);
            this.Name = "frmItemStockList";
            this.Text = "Item Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmItemStockList_Load);
            this.Controls.SetChildIndex(this.dgvItemStock, 0);
            this.Controls.SetChildIndex(this.lblTotRec, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNew, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemStock)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView dgvItemStock;
        private System.Windows.Forms.Label lblTotRec;
        internal System.Windows.Forms.Button BtnAdjustment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox cmbreports;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QOH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReorderLvl;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn RackNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Godown_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
    }
}
