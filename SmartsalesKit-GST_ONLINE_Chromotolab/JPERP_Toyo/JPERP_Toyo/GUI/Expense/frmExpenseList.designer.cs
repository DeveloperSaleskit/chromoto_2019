namespace Account.GUI.Expense
{
    partial class frmExpenseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpenseList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolsReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.rptExpenseRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.rptExpense = new System.Windows.Forms.ToolStripMenuItem();
            this.grpdata = new System.Windows.Forms.GroupBox();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.dgvExpense = new System.Windows.Forms.DataGridView();
            this.ExpenseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnfilter = new System.Windows.Forms.Button();
            this.cmbreports = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tools.SuspendLayout();
            this.grpdata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tools
            // 
            this.tools.AutoSize = false;
            this.tools.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(225)))));
            this.tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsReports});
            this.tools.Location = new System.Drawing.Point(1, 1);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(941, 25);
            this.tools.TabIndex = 6;
            this.tools.Text = "ToolStrip1";
            this.tools.Visible = false;
            // 
            // toolsReports
            // 
            this.toolsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rptExpenseRegister,
            this.rptExpense});
            this.toolsReports.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolsReports.Image = ((System.Drawing.Image)(resources.GetObject("toolsReports.Image")));
            this.toolsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsReports.Name = "toolsReports";
            this.toolsReports.Size = new System.Drawing.Size(58, 22);
            this.toolsReports.Tag = "View report;";
            this.toolsReports.Text = "Reports";
            // 
            // rptExpenseRegister
            // 
            this.rptExpenseRegister.Name = "rptExpenseRegister";
            this.rptExpenseRegister.Size = new System.Drawing.Size(158, 22);
            this.rptExpenseRegister.Text = "Expense Register";
            this.rptExpenseRegister.Click += new System.EventHandler(this.rptExpenseRegister_Click);
            // 
            // rptExpense
            // 
            this.rptExpense.Name = "rptExpense";
            this.rptExpense.Size = new System.Drawing.Size(158, 22);
            this.rptExpense.Text = "Expense";
            this.rptExpense.Click += new System.EventHandler(this.rptExpense_Click);
            // 
            // grpdata
            // 
            this.grpdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpdata.Controls.Add(this.lblTotRec);
            this.grpdata.Controls.Add(this.dgvExpense);
            this.grpdata.Location = new System.Drawing.Point(12, 87);
            this.grpdata.Name = "grpdata";
            this.grpdata.Size = new System.Drawing.Size(1158, 464);
            this.grpdata.TabIndex = 1;
            this.grpdata.TabStop = false;
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRec.Location = new System.Drawing.Point(6, 14);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(78, 17);
            this.lblTotRec.TabIndex = 0;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // dgvExpense
            // 
            this.dgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExpenseNo,
            this.ExpenseID,
            this.ExpenseDate,
            this.Amount,
            this.Narration});
            this.dgvExpense.Location = new System.Drawing.Point(6, 34);
            this.dgvExpense.Name = "dgvExpense";
            this.dgvExpense.Size = new System.Drawing.Size(1146, 424);
            this.dgvExpense.TabIndex = 0;
            this.dgvExpense.Tag = "List of Expense;";
            this.dgvExpense.VirtualMode = true;
            this.dgvExpense.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvExpense_CellPainting);
            // 
            // ExpenseNo
            // 
            this.ExpenseNo.HeaderText = "Expense No";
            this.ExpenseNo.Name = "ExpenseNo";
            // 
            // ExpenseID
            // 
            this.ExpenseID.HeaderText = "ExpenseID";
            this.ExpenseID.Name = "ExpenseID";
            this.ExpenseID.Visible = false;
            // 
            // ExpenseDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.ExpenseDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExpenseDate.HeaderText = "Expense Date";
            this.ExpenseDate.Name = "ExpenseDate";
            // 
            // Amount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // Narration
            // 
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.btnfilter);
            this.grpFilter.Controls.Add(this.cmbreports);
            this.grpFilter.Controls.Add(this.btnDelete);
            this.grpFilter.Controls.Add(this.btnClose);
            this.grpFilter.Controls.Add(this.btnNew);
            this.grpFilter.Controls.Add(this.btnEdit);
            this.grpFilter.Controls.Add(this.btnClear);
            this.grpFilter.Location = new System.Drawing.Point(12, 6);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(1159, 75);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // btnfilter
            // 
            this.btnfilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnfilter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnfilter.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnfilter.Location = new System.Drawing.Point(546, 32);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(132, 23);
            this.btnfilter.TabIndex = 8;
            this.btnfilter.Tag = "Click to close form;";
            this.btnfilter.Text = "Report Filter";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // cmbreports
            // 
            this.cmbreports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbreports.FormattingEnabled = true;
            this.cmbreports.Location = new System.Drawing.Point(684, 33);
            this.cmbreports.Name = "cmbreports";
            this.cmbreports.Size = new System.Drawing.Size(151, 21);
            this.cmbreports.TabIndex = 7;
            this.cmbreports.Tag = "Select city;@";
            this.cmbreports.SelectedIndexChanged += new System.EventHandler(this.cmbreports_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(217, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Tag = "Click to delete selected Expense;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1053, 31);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Location = new System.Drawing.Point(5, 32);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Tag = "Click to add Expense;";
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Location = new System.Drawing.Point(111, 32);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Tag = "Click to edit selected Expense;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Location = new System.Drawing.Point(947, 33);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmExpenseList
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1183, 613);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.grpdata);
            this.Controls.Add(this.grpFilter);
            this.Name = "frmExpenseList";
            this.Text = "Expense - List";
            this.Load += new System.EventHandler(this.frmExpenseList_Load);
            this.Controls.SetChildIndex(this.grpFilter, 0);
            this.Controls.SetChildIndex(this.grpdata, 0);
            this.Controls.SetChildIndex(this.tools, 0);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.grpdata.ResumeLayout(false);
            this.grpdata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpense)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip tools;
        internal System.Windows.Forms.ToolStripDropDownButton toolsReports;
        internal System.Windows.Forms.GroupBox grpdata;
        private System.Windows.Forms.Label lblTotRec;
        internal System.Windows.Forms.DataGridView dgvExpense;
        internal System.Windows.Forms.GroupBox grpFilter;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnEdit;
        internal System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ToolStripMenuItem rptExpenseRegister;
        private System.Windows.Forms.ToolStripMenuItem rptExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
        internal System.Windows.Forms.ComboBox cmbreports;
        private System.Windows.Forms.Button btnfilter;
    }
}
