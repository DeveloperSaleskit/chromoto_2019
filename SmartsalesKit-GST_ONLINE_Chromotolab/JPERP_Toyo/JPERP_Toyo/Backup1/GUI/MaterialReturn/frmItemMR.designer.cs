namespace Account.GUI.MaterialReturn
{
    partial class frmItemMR
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
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.grpGrid = new System.Windows.Forms.GroupBox();
            this.dgvLOV = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.MICODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOV)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblSearch.Location = new System.Drawing.Point(13, 38);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(81, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search Text:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(100, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(388, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Tag = "Enter search text;";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grpGrid
            // 
            this.grpGrid.Controls.Add(this.dgvLOV);
            this.grpGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGrid.Location = new System.Drawing.Point(11, 61);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(477, 324);
            this.grpGrid.TabIndex = 3;
            this.grpGrid.TabStop = false;
            this.grpGrid.Tag = "";
            this.grpGrid.Text = "List of items";
            // 
            // dgvLOV
            // 
            this.dgvLOV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLOV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MICODE,
            this.Itemcode,
            this.ItemID,
            this.ItemName,
            this.id});
            this.dgvLOV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLOV.Location = new System.Drawing.Point(3, 17);
            this.dgvLOV.Name = "dgvLOV";
            this.dgvLOV.Size = new System.Drawing.Size(471, 304);
            this.dgvLOV.TabIndex = 0;
            this.dgvLOV.Tag = "List of item;";
            this.dgvLOV.VirtualMode = true;
            this.dgvLOV.DoubleClick += new System.EventHandler(this.dgvLOV_DoubleClick);
            this.dgvLOV.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLOV_CellPainting);
            this.dgvLOV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvLOV_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(413, 391);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Tag = "Click to close;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSelect.Location = new System.Drawing.Point(332, 391);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Tag = "Click to select record;";
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewItem
            // 
            this.btnNewItem.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewItem.Location = new System.Drawing.Point(178, 391);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(148, 23);
            this.btnNewItem.TabIndex = 27;
            this.btnNewItem.Tag = "Click to add new Item;";
            this.btnNewItem.Text = "Add New Item";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Visible = false;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // MICODE
            // 
            this.MICODE.HeaderText = "MICODE";
            this.MICODE.Name = "MICODE";
            // 
            // Itemcode
            // 
            this.Itemcode.HeaderText = "Itemcode";
            this.Itemcode.Name = "Itemcode";
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // frmItemMR
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(499, 448);
            this.Controls.Add(this.btnNewItem);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.grpGrid);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Name = "frmItemMR";
            this.Load += new System.EventHandler(this.frmItemMR_Load);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.grpGrid, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnNewItem, 0);
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.DataGridView dgvLOV;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MICODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn Itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;      
    }
}
