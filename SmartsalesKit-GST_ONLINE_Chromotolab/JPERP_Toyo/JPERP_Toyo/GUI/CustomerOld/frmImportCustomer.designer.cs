namespace Account.GUI.Customer
{
    partial class frmImportCustomerList
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
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.lblTotRec = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.COMPANY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTACTPERSON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESS2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PINCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOBILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TINNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSTNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PANO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECCNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RANGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIVISION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREADITDAYS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRAMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBAMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.COMPANY,
            this.CONTACTPERSON,
            this.ADDRESS1,
            this.ADDRESS2,
            this.CITY,
            this.PINCODE,
            this.PHONE1,
            this.PHONE2,
            this.EMAIL,
            this.MOBILE,
            this.TINNO,
            this.CSTNO,
            this.PANO,
            this.ECCNO,
            this.RANGE,
            this.DIVISION,
            this.CREADITDAYS,
            this.TRANSDATE,
            this.CRAMOUNT,
            this.DBAMOUNT});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomer.Location = new System.Drawing.Point(12, 30);
            this.dgvCustomer.Name = "dgvCustomer";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomer.Size = new System.Drawing.Size(1212, 421);
            this.dgvCustomer.TabIndex = 16;
            this.dgvCustomer.Tag = "List of customer;";
            this.dgvCustomer.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCustomer_CellPainting);
            // 
            // lblTotRec
            // 
            this.lblTotRec.AutoSize = true;
            this.lblTotRec.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTotRec.Location = new System.Drawing.Point(9, 9);
            this.lblTotRec.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotRec.Name = "lblTotRec";
            this.lblTotRec.Size = new System.Drawing.Size(88, 18);
            this.lblTotRec.TabIndex = 15;
            this.lblTotRec.Text = "Excel Records:";
            this.lblTotRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotRec.UseCompatibleTextRendering = true;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(1123, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Tag = "Click to Submit form;";
            this.btnClose.Text = "Submit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Check
            // 
            this.Check.HeaderText = "Account";
            this.Check.Name = "Check";
            // 
            // COMPANY
            // 
            this.COMPANY.HeaderText = "COMPANY";
            this.COMPANY.Name = "COMPANY";
            // 
            // CONTACTPERSON
            // 
            this.CONTACTPERSON.HeaderText = "CONTACTPERSON";
            this.CONTACTPERSON.Name = "CONTACTPERSON";
            // 
            // ADDRESS1
            // 
            this.ADDRESS1.HeaderText = "ADDRESS1";
            this.ADDRESS1.Name = "ADDRESS1";
            // 
            // ADDRESS2
            // 
            this.ADDRESS2.HeaderText = "ADDRESS2";
            this.ADDRESS2.Name = "ADDRESS2";
            // 
            // CITY
            // 
            this.CITY.HeaderText = "CITY";
            this.CITY.Name = "CITY";
            // 
            // PINCODE
            // 
            this.PINCODE.HeaderText = "PINCODE";
            this.PINCODE.Name = "PINCODE";
            // 
            // PHONE1
            // 
            this.PHONE1.HeaderText = "PHONE1";
            this.PHONE1.Name = "PHONE1";
            // 
            // PHONE2
            // 
            this.PHONE2.HeaderText = "PHONE2";
            this.PHONE2.Name = "PHONE2";
            // 
            // EMAIL
            // 
            this.EMAIL.HeaderText = "EMAIL";
            this.EMAIL.Name = "EMAIL";
            // 
            // MOBILE
            // 
            this.MOBILE.HeaderText = "MOBILE";
            this.MOBILE.Name = "MOBILE";
            // 
            // TINNO
            // 
            this.TINNO.HeaderText = "TINNO";
            this.TINNO.Name = "TINNO";
            // 
            // CSTNO
            // 
            this.CSTNO.HeaderText = "CSTNO";
            this.CSTNO.Name = "CSTNO";
            // 
            // PANO
            // 
            this.PANO.HeaderText = "PANO";
            this.PANO.Name = "PANO";
            // 
            // ECCNO
            // 
            this.ECCNO.HeaderText = "ECCNO";
            this.ECCNO.Name = "ECCNO";
            // 
            // RANGE
            // 
            this.RANGE.HeaderText = "RANGE";
            this.RANGE.Name = "RANGE";
            // 
            // DIVISION
            // 
            this.DIVISION.HeaderText = "DIVISION";
            this.DIVISION.Name = "DIVISION";
            // 
            // CREADITDAYS
            // 
            this.CREADITDAYS.HeaderText = "CREADITDAYS";
            this.CREADITDAYS.Name = "CREADITDAYS";
            // 
            // TRANSDATE
            // 
            this.TRANSDATE.HeaderText = "TRANSDATE";
            this.TRANSDATE.Name = "TRANSDATE";
            this.TRANSDATE.ReadOnly = true;
            // 
            // CRAMOUNT
            // 
            this.CRAMOUNT.HeaderText = "CRAMOUNT";
            this.CRAMOUNT.Name = "CRAMOUNT";
            this.CRAMOUNT.ReadOnly = true;
            // 
            // DBAMOUNT
            // 
            this.DBAMOUNT.HeaderText = "DBAMOUNT";
            this.DBAMOUNT.Name = "DBAMOUNT";
            this.DBAMOUNT.ReadOnly = true;
            // 
            // frmImportCustomerList
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1235, 508);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.lblTotRec);
            this.Controls.Add(this.btnClose);
            this.Name = "frmImportCustomerList";
            this.Text = "Import Customer";
            this.Load += new System.EventHandler(this.frmCustomerList_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblTotRec, 0);
            this.Controls.SetChildIndex(this.dgvCustomer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Label lblTotRec;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMPANY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTACTPERSON;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESS2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PINCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOBILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TINNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSTNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PANO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECCNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn RANGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIVISION;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREADITDAYS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CRAMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBAMOUNT;

    }
}
