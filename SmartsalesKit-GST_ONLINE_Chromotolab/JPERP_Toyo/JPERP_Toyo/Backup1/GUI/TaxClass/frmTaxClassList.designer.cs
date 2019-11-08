namespace Account.GUI.TaxClass
{
    partial class frmTaxClassList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaxClassList));
            this.dgvTaxClass = new System.Windows.Forms.DataGridView();
            this.TaxClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Excise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EduCess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEduCess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AVAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SBCess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraTaxType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExtraTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolsReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuTaxClass = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotRec = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxClass)).BeginInit();
            this.tools.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTaxClass
            // 
            this.dgvTaxClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaxClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaxClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaxClassName,
            this.TaxClassID,
            this.FromDate,
            this.Excise,
            this.EduCess,
            this.HEduCess,
            this.ServiceTax,
            this.CST,
            this.VAT,
            this.AVAT,
            this.SBCess,
            this.ExtraTaxType,
            this.ExtraTax});
            this.dgvTaxClass.Location = new System.Drawing.Point(6, 43);
            this.dgvTaxClass.Name = "dgvTaxClass";
            this.dgvTaxClass.RowTemplate.Height = 24;
            this.dgvTaxClass.Size = new System.Drawing.Size(1158, 422);
            this.dgvTaxClass.TabIndex = 5;
            this.dgvTaxClass.Tag = "List of tax class;";
            this.dgvTaxClass.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTaxClass_CellPainting);
            // 
            // TaxClassName
            // 
            this.TaxClassName.HeaderText = "Tax Class";
            this.TaxClassName.Name = "TaxClassName";
            this.TaxClassName.ReadOnly = true;
            // 
            // TaxClassID
            // 
            this.TaxClassID.HeaderText = "Tax Class ID";
            this.TaxClassID.Name = "TaxClassID";
            this.TaxClassID.ReadOnly = true;
            this.TaxClassID.Visible = false;
            // 
            // FromDate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.FromDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.FromDate.HeaderText = "From Date";
            this.FromDate.Name = "FromDate";
            this.FromDate.ReadOnly = true;
            // 
            // Excise
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Excise.DefaultCellStyle = dataGridViewCellStyle2;
            this.Excise.HeaderText = "Excise";
            this.Excise.Name = "Excise";
            // 
            // EduCess
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EduCess.DefaultCellStyle = dataGridViewCellStyle3;
            this.EduCess.HeaderText = "Edu Cess";
            this.EduCess.Name = "EduCess";
            this.EduCess.ReadOnly = true;
            // 
            // HEduCess
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HEduCess.DefaultCellStyle = dataGridViewCellStyle4;
            this.HEduCess.HeaderText = "H.Edu Cess";
            this.HEduCess.Name = "HEduCess";
            this.HEduCess.ReadOnly = true;
            // 
            // ServiceTax
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ServiceTax.DefaultCellStyle = dataGridViewCellStyle5;
            this.ServiceTax.HeaderText = "Service Tax";
            this.ServiceTax.Name = "ServiceTax";
            this.ServiceTax.ReadOnly = true;
            // 
            // CST
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CST.DefaultCellStyle = dataGridViewCellStyle6;
            this.CST.HeaderText = "CST";
            this.CST.Name = "CST";
            // 
            // VAT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VAT.DefaultCellStyle = dataGridViewCellStyle7;
            this.VAT.HeaderText = "VAT";
            this.VAT.Name = "VAT";
            // 
            // AVAT
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AVAT.DefaultCellStyle = dataGridViewCellStyle8;
            this.AVAT.HeaderText = "AVAT";
            this.AVAT.Name = "AVAT";
            // 
            // SBCess
            // 
            this.SBCess.HeaderText = "SBCess";
            this.SBCess.Name = "SBCess";
            // 
            // ExtraTaxType
            // 
            this.ExtraTaxType.HeaderText = "ExtraTaxType";
            this.ExtraTaxType.Name = "ExtraTaxType";
            // 
            // ExtraTax
            // 
            this.ExtraTax.HeaderText = "ExtraTax";
            this.ExtraTax.Name = "ExtraTax";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(115, 9);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Tag = "Click to clear filter;";
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.tools.Size = new System.Drawing.Size(1189, 25);
            this.tools.TabIndex = 11;
            this.tools.Text = "ToolStrip1";
            this.tools.Visible = false;
            // 
            // toolsReports
            // 
            this.toolsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaxClass});
            this.toolsReports.Image = ((System.Drawing.Image)(resources.GetObject("toolsReports.Image")));
            this.toolsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsReports.Name = "toolsReports";
            this.toolsReports.Size = new System.Drawing.Size(65, 22);
            this.toolsReports.Tag = "View report;";
            this.toolsReports.Text = "Reports";
            // 
            // mnuTaxClass
            // 
            this.mnuTaxClass.Name = "mnuTaxClass";
            this.mnuTaxClass.Size = new System.Drawing.Size(178, 22);
            this.mnuTaxClass.Tag = "Click to view tax class register report;";
            this.mnuTaxClass.Text = "Tax Class Register";
            this.mnuTaxClass.Click += new System.EventHandler(this.mnuTaxClass_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(956, 35);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.button1.Location = new System.Drawing.Point(4, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "Click to Filter;";
            this.button1.Text = "Report Filter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnHelp.Location = new System.Drawing.Point(1078, 35);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(101, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Tag = "Click to Download Help File of  Customer;";
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Location = new System.Drawing.Point(9, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 38);
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
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
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
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnTerminate
            // 
            this.btnTerminate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnTerminate.Location = new System.Drawing.Point(738, 33);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(100, 23);
            this.btnTerminate.TabIndex = 2;
            this.btnTerminate.Tag = "Click to terminate selected tax class;";
            this.btnTerminate.Text = "Terminate";
            this.btnTerminate.UseVisualStyleBackColor = true;
            this.btnTerminate.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Location = new System.Drawing.Point(461, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(221, 39);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblTotRec);
            this.groupBox3.Controls.Add(this.dgvTaxClass);
            this.groupBox3.Location = new System.Drawing.Point(9, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1170, 471);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotRec.Location = new System.Drawing.Point(10, 15);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(96, 18);
            this.lblTotRec.TabIndex = 18;
            this.lblTotRec.Text = "Total Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // frmTaxClassList
            // 
            this.AcceptButton = this.btnNew;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1191, 567);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnTerminate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tools);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmTaxClassList";
            this.Text = "Tax Class";
            this.Load += new System.EventHandler(this.frmTaxClassList_Load);
            this.Controls.SetChildIndex(this.tools, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.btnTerminate, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaxClass)).EndInit();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvTaxClass;
        internal System.Windows.Forms.ToolStrip tools;
        internal System.Windows.Forms.ToolStripDropDownButton toolsReports;
        internal System.Windows.Forms.ToolStripMenuItem mnuTaxClass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Excise;
        private System.Windows.Forms.DataGridViewTextBoxColumn EduCess;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEduCess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn CST;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SBCess;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraTaxType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExtraTax;
    }
}
