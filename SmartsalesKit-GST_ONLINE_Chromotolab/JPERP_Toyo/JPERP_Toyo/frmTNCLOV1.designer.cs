namespace Account
{
    partial class frmTNCLOV
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
            this.grpGrid = new System.Windows.Forms.GroupBox();
            this.dgvLOV = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TNC_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnNewTNC = new System.Windows.Forms.Button();
            this.lblTNC = new System.Windows.Forms.Label();
            this.grpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOV)).BeginInit();
            this.SuspendLayout();
            // 
            // grpGrid
            // 
            this.grpGrid.Controls.Add(this.dgvLOV);
            this.grpGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGrid.Location = new System.Drawing.Point(11, 41);
            this.grpGrid.Name = "grpGrid";
            this.grpGrid.Size = new System.Drawing.Size(477, 344);
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
            this.TNC_Desc});
            this.dgvLOV.Location = new System.Drawing.Point(6, 20);
            this.dgvLOV.Name = "dgvLOV";
            this.dgvLOV.Size = new System.Drawing.Size(465, 318);
            this.dgvLOV.TabIndex = 0;
            this.dgvLOV.Tag = "Gdv;";
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
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
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
            // lblTNC
            // 
            this.lblTNC.AutoSize = true;
            this.lblTNC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTNC.Location = new System.Drawing.Point(184, 22);
            this.lblTNC.Name = "lblTNC";
            this.lblTNC.Size = new System.Drawing.Size(0, 16);
            this.lblTNC.TabIndex = 29;
            // 
            // frmTNCLOV
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(499, 448);
            this.Controls.Add(this.lblTNC);
            this.Controls.Add(this.btnNewTNC);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.grpGrid);
            this.Name = "frmTNCLOV";
            this.Load += new System.EventHandler(this.frmItemLOV_Load);
            this.Controls.SetChildIndex(this.grpGrid, 0);
            this.Controls.SetChildIndex(this.btnSelect, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnNewTNC, 0);
            this.Controls.SetChildIndex(this.lblTNC, 0);
            this.grpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLOV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView dgvLOV;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNC_Desc;
        private System.Windows.Forms.Button btnNewTNC;
        private System.Windows.Forms.Label lblTNC;      
    }
}
