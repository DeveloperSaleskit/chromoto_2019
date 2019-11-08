namespace Account.GUI.ItemParent
{
    partial class frmItemParentList
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTotRecUOM = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.dgvUOM = new System.Windows.Forms.DataGridView();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbreports = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUOM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(1054, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(948, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTotRecUOM
            // 
            this.lblTotRecUOM.AutoSize = true;
            this.lblTotRecUOM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRecUOM.Location = new System.Drawing.Point(6, 12);
            this.lblTotRecUOM.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRecUOM.Name = "lblTotRecUOM";
            this.lblTotRecUOM.Size = new System.Drawing.Size(96, 18);
            this.lblTotRecUOM.TabIndex = 0;
            this.lblTotRecUOM.Text = "Total Records:";
            this.lblTotRecUOM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRecUOM.UseCompatibleTextRendering = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnHelp.Location = new System.Drawing.Point(1160, 19);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(91, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Tag = "Click to Download Help File of  Customer;";
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dgvUOM
            // 
            this.dgvUOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUOM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UOM,
            this.Abbr,
            this.UOMID});
            this.dgvUOM.Location = new System.Drawing.Point(6, 33);
            this.dgvUOM.Name = "dgvUOM";
            this.dgvUOM.RowTemplate.Height = 24;
            this.dgvUOM.Size = new System.Drawing.Size(1227, 434);
            this.dgvUOM.TabIndex = 5;
            this.dgvUOM.Tag = "List of UOM;";
            this.dgvUOM.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUOM_CellPainting);
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            // 
            // Abbr
            // 
            this.Abbr.HeaderText = "Abbreviation";
            this.Abbr.Name = "Abbr";
            // 
            // UOMID
            // 
            this.UOMID.HeaderText = "UOMID";
            this.UOMID.Name = "UOMID";
            this.UOMID.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 42);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(218, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Click to delete selected employee;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteUOM_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(6, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "Click to add employee;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNewUOM_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(112, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "Click to edit selected employee;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEditUOM_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbreports);
            this.groupBox3.Controls.Add(this.btnApply);
            this.groupBox3.Location = new System.Drawing.Point(341, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 42);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // cmbreports
            // 
            this.cmbreports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbreports.FormattingEnabled = true;
            this.cmbreports.Location = new System.Drawing.Point(115, 12);
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
            this.btnApply.Location = new System.Drawing.Point(3, 11);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(106, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Tag = "Click to apply filter;";
            this.btnApply.Text = "Report Filter";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvUOM);
            this.groupBox2.Controls.Add(this.lblTotRecUOM);
            this.groupBox2.Location = new System.Drawing.Point(12, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1239, 473);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            // 
            // frmItemParentList
            // 
            this.AcceptButton = this.btnNew;
            this.AutoScroll = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1263, 565);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmItemParentList";
            this.Text = "UOM";
            this.Load += new System.EventHandler(this.frmItemParentList_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUOM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotRecUOM;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DataGridView dgvUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOMID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox cmbreports;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
