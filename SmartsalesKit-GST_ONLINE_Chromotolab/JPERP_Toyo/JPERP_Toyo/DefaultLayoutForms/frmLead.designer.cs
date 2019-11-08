namespace Account.DefaultLayout
{
    partial class frmLead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLead));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnfollowup = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnrevisedquotation = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.InvoiceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Party = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACTPERSON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEADDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ALLOCATEDTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(937, 25);
            this.panel2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(937, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reminder";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(23, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(176, 30);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Tag = "Click to refresh;";
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnfollowup
            // 
            this.btnfollowup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfollowup.Location = new System.Drawing.Point(205, 7);
            this.btnfollowup.Name = "btnfollowup";
            this.btnfollowup.Size = new System.Drawing.Size(176, 30);
            this.btnfollowup.TabIndex = 13;
            this.btnfollowup.Text = "Followup";
            this.btnfollowup.UseVisualStyleBackColor = true;
            this.btnfollowup.Click += new System.EventHandler(this.btnfollowup_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnSendMail);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnrevisedquotation);
            this.panel3.Controls.Add(this.btnfollowup);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(937, 50);
            this.panel3.TabIndex = 14;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(387, 7);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(176, 30);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Tag = "Click to edit selected Quotation;";
            this.btnEdit.Text = "Edit Quotation";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnrevisedquotation
            // 
            this.btnrevisedquotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrevisedquotation.Location = new System.Drawing.Point(569, 7);
            this.btnrevisedquotation.Name = "btnrevisedquotation";
            this.btnrevisedquotation.Size = new System.Drawing.Size(176, 30);
            this.btnrevisedquotation.TabIndex = 16;
            this.btnrevisedquotation.Tag = "Click to  Selected Quotation;";
            this.btnrevisedquotation.Text = "Revised Quotation";
            this.btnrevisedquotation.UseVisualStyleBackColor = true;
            this.btnrevisedquotation.Click += new System.EventHandler(this.btnrevisedquotation_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvInvoice);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 429);
            this.panel1.TabIndex = 15;
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceID,
            this.Type,
            this.Code,
            this.Date,
            this.Party,
            this.CONTACTPERSON,
            this.PHONE1,
            this.LEADDATE,
            this.REMARKS,
            this.EMAIL,
            this.AMOUNT,
            this.ALLOCATEDTO});
            this.dgvInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoice.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.Size = new System.Drawing.Size(935, 427);
            this.dgvInvoice.TabIndex = 11;
            this.dgvInvoice.Tag = "List of quotation;";
            this.dgvInvoice.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvInvoice_CellPainting);
            this.dgvInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellContentClick);
            // 
            // InvoiceID
            // 
            this.InvoiceID.HeaderText = "InvoiceID";
            this.InvoiceID.Name = "InvoiceID";
            this.InvoiceID.Visible = false;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            // 
            // Date
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.Date.DefaultCellStyle = dataGridViewCellStyle2;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Party
            // 
            this.Party.HeaderText = "Customer Name";
            this.Party.Name = "Party";
            this.Party.ReadOnly = true;
            // 
            // CONTACTPERSON
            // 
            this.CONTACTPERSON.HeaderText = "Contact Person";
            this.CONTACTPERSON.Name = "CONTACTPERSON";
            // 
            // PHONE1
            // 
            this.PHONE1.HeaderText = "Contact No";
            this.PHONE1.Name = "PHONE1";
            // 
            // LEADDATE
            // 
            this.LEADDATE.HeaderText = "LEADDATE";
            this.LEADDATE.Name = "LEADDATE";
            this.LEADDATE.Visible = false;
            // 
            // REMARKS
            // 
            this.REMARKS.HeaderText = "Remarks";
            this.REMARKS.Name = "REMARKS";
            // 
            // EMAIL
            // 
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.Visible = false;
            // 
            // AMOUNT
            // 
            this.AMOUNT.HeaderText = "AMOUNT";
            this.AMOUNT.Name = "AMOUNT";
            // 
            // ALLOCATEDTO
            // 
            this.ALLOCATEDTO.HeaderText = "Employee";
            this.ALLOCATEDTO.Name = "ALLOCATEDTO";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendMail.Location = new System.Drawing.Point(751, 7);
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Size = new System.Drawing.Size(176, 30);
            this.btnSendMail.TabIndex = 18;
            this.btnSendMail.Tag = "Click to Send Mail;";
            this.btnSendMail.Text = "Send Mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // frmLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 504);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmLead";
            this.Text = "Quotation Reminder (AMC + Service)";
            this.Load += new System.EventHandler(this.frmLead_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnfollowup;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnrevisedquotation;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Party;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACTPERSON;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEADDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ALLOCATEDTO;
        private System.Windows.Forms.Button btnSendMail;
    }
}