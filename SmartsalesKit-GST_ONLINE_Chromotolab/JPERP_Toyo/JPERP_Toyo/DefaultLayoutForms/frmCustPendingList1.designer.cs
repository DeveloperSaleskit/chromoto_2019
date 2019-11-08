namespace Account.DefaultLayout
{
    partial class frmCustPendingList
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
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PendingAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContacts
            // 
            this.dgvContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContacts.BackgroundColor = System.Drawing.Color.White;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerCode,
            this.CustomerName,
            this.PendingAmount,
            this.NetAmount,
            this.DueDate,
            this.SalesCode,
            this.Email});
            this.dgvContacts.Location = new System.Drawing.Point(0, 0);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.Size = new System.Drawing.Size(312, 585);
            this.dgvContacts.TabIndex = 0;
            this.dgvContacts.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvContacts_CellPainting);
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(97, 7);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(67, 37);
            this.btnRegenrate.TabIndex = 5;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to refresh vendor pending payment list;";
            this.btnRegenrate.Text = "Refresh";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dgvContacts);
            this.panel1.Location = new System.Drawing.Point(4, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 585);
            this.panel1.TabIndex = 6;
            // 
            // CustomerCode
            // 
            this.CustomerCode.HeaderText = "Cust Code";
            this.CustomerCode.Name = "CustomerCode";
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Cust Name";
            this.CustomerName.Name = "CustomerName";
            // 
            // PendingAmount
            // 
            this.PendingAmount.HeaderText = "Pending Amount";
            this.PendingAmount.Name = "PendingAmount";
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            // 
            // SalesCode
            // 
            this.SalesCode.HeaderText = "Sales Code";
            this.SalesCode.Name = "SalesCode";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // frmCustPendingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(328, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRegenrate);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCustPendingList";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide;
            this.Text = "Customer Pending Payment";
            this.Load += new System.EventHandler(this.frmContacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnRegenrate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PendingAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;

    }
}