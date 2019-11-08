namespace Account
{
    partial class frmTNCLOV_NEW
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
            this.grpGrid = new System.Windows.Forms.GroupBox();
            this.dgvLOV = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.cmbTNCSub = new System.Windows.Forms.ComboBox();
            this.btnNewTNC = new System.Windows.Forms.Button();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TNC_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOV)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblSearch.Location = new System.Drawing.Point(107, 38);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(55, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Subject:";
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
            this.grpGrid.Text = "Terms && Conditions";
            // 
            // dgvLOV
            // 
            this.dgvLOV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLOV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.TNC_Desc,
            this.TNCID});
            this.dgvLOV.Location = new System.Drawing.Point(6, 20);
            this.dgvLOV.Name = "dgvLOV";
            this.dgvLOV.Size = new System.Drawing.Size(465, 298);
            this.dgvLOV.TabIndex = 0;
            this.dgvLOV.Tag = "Gdv;";
            this.dgvLOV.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLOV_CellBeginEdit);
            this.dgvLOV.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLOV_CellEndEdit);
            this.dgvLOV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLOV_CellClick);
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
            this.btnSelect.Tag = "Click to Save;";
            this.btnSelect.Text = "Save";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click_1);
            // 
            // cmbTNCSub
            // 
            this.cmbTNCSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTNCSub.FormattingEnabled = true;
            this.cmbTNCSub.Location = new System.Drawing.Point(168, 34);
            this.cmbTNCSub.Name = "cmbTNCSub";
            this.cmbTNCSub.Size = new System.Drawing.Size(209, 21);
            this.cmbTNCSub.TabIndex = 27;
            this.cmbTNCSub.Tag = "Select Terms & Conditions Subject;";
            this.cmbTNCSub.SelectedIndexChanged += new System.EventHandler(this.cmbTNCSub_SelectedIndexChanged);
            this.cmbTNCSub.Leave += new System.EventHandler(this.cmbTNCSub_Leave);
            // 
            // btnNewTNC
            // 
            this.btnNewTNC.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNewTNC.Location = new System.Drawing.Point(13, 391);
            this.btnNewTNC.Name = "btnNewTNC";
            this.btnNewTNC.Size = new System.Drawing.Size(235, 23);
            this.btnNewTNC.TabIndex = 28;
            this.btnNewTNC.Tag = "Click to Add New Terms & Conditions;";
            this.btnNewTNC.Text = "Add New Terms && Conditions";
            this.btnNewTNC.UseVisualStyleBackColor = true;
            this.btnNewTNC.Click += new System.EventHandler(this.btnNewTNC_Click);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            // 
            // TNC_Desc
            // 
            this.TNC_Desc.HeaderText = "TNC_Desc";
            this.TNC_Desc.Name = "TNC_Desc";
            // 
            // TNCID
            // 
            this.TNCID.HeaderText = "TNCID";
            this.TNCID.Name = "TNCID";
            this.TNCID.Visible = false;
            // 
            // frmTNCLOV_NEW
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(499, 448);
            this.Controls.Add(this.btnNewTNC);
            this.Controls.Add(this.cmbTNCSub);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.grpGrid);
            this.Controls.Add(this.lblSearch);
            this.Name = "frmTNCLOV_NEW";
            this.Load += new System.EventHandler(this.frmItemLOV_Load);
            this.Controls.SetChildIndex(this.lblSearch, 0);
            this.Controls.SetChildIndex(this.grpGrid, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.cmbTNCSub, 0);
            this.Controls.SetChildIndex(this.btnNewTNC, 0);
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.ComboBox cmbTNCSub;
        private System.Windows.Forms.DataGridView dgvLOV;
        private System.Windows.Forms.Button btnNewTNC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNC_Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNCID;      
    }
}
