namespace Account.GUI.Godown
{
    partial class frmGodownList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGodownList));
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Godown_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Godown_addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GodownID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolsReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuUserRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnfilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tools.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(991, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(1097, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(220, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Tag = "Click to delete selected user;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(114, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Tag = "Click to edit selected user;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnNew.Location = new System.Drawing.Point(8, 20);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Tag = "Click to add user;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotRec.Location = new System.Drawing.Point(8, 46);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(96, 18);
            this.lblTotRec.TabIndex = 10;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Godown_name,
            this.Godown_addr,
            this.GodownID,
            this.CityName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.Location = new System.Drawing.Point(6, 15);
            this.dgvUsers.Name = "dgvUsers";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.Size = new System.Drawing.Size(1192, 465);
            this.dgvUsers.TabIndex = 11;
            this.dgvUsers.Tag = "List of user;";
            this.dgvUsers.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUsers_CellPainting);
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            // 
            // Godown_name
            // 
            this.Godown_name.HeaderText = "Godown";
            this.Godown_name.Name = "Godown_name";
            this.Godown_name.ReadOnly = true;
            // 
            // Godown_addr
            // 
            this.Godown_addr.HeaderText = "Address";
            this.Godown_addr.Name = "Godown_addr";
            this.Godown_addr.ReadOnly = true;
            // 
            // GodownID
            // 
            this.GodownID.HeaderText = "UserID";
            this.GodownID.Name = "GodownID";
            this.GodownID.ReadOnly = true;
            this.GodownID.Visible = false;
            // 
            // CityName
            // 
            this.CityName.HeaderText = "CityName";
            this.CityName.Name = "CityName";
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(225)))));
            this.tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsReports});
            this.tools.Location = new System.Drawing.Point(1, 1);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(658, 23);
            this.tools.TabIndex = 12;
            this.tools.Text = "ToolStrip1";
            this.tools.Visible = false;
            // 
            // toolsReports
            // 
            this.toolsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUserRegister});
            this.toolsReports.Image = ((System.Drawing.Image)(resources.GetObject("toolsReports.Image")));
            this.toolsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsReports.Name = "toolsReports";
            this.toolsReports.Size = new System.Drawing.Size(58, 20);
            this.toolsReports.Tag = "View report;";
            this.toolsReports.Text = "Reports";
            // 
            // mnuUserRegister
            // 
            this.mnuUserRegister.Name = "mnuUserRegister";
            this.mnuUserRegister.Size = new System.Drawing.Size(139, 22);
            this.mnuUserRegister.Tag = "Click to view user register report;";
            this.mnuUserRegister.Text = "User Register";
            this.mnuUserRegister.Click += new System.EventHandler(this.mnuUserRegister_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvUsers);
            this.groupBox1.Location = new System.Drawing.Point(8, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1204, 486);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // btnfilter
            // 
            this.btnfilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfilter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnfilter.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnfilter.Location = new System.Drawing.Point(337, 19);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(132, 23);
            this.btnfilter.TabIndex = 28;
            this.btnfilter.Tag = "Click to close form;";
            this.btnfilter.Text = "Report Filter";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // frmGodownList
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1224, 585);
            this.Controls.Add(this.btnfilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotRec);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Name = "frmGodownList";
            this.Text = "Godown";
            this.Load += new System.EventHandler(this.frmGodownList_Load);
            this.Controls.SetChildIndex(this.btnNew, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.tools, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.lblTotRec, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.btnfilter, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.DataGridView dgvUsers;
        internal System.Windows.Forms.ToolStrip tools;
        internal System.Windows.Forms.ToolStripDropDownButton toolsReports;
        internal System.Windows.Forms.ToolStripMenuItem mnuUserRegister;
        private System.Windows.Forms.DataGridViewTextBoxColumn Godown_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Godown_addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn GodownID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnfilter;
    }
}
