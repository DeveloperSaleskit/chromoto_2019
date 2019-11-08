namespace Account.GUI.PurchaseInvoice
{
    partial class frmPurchaseInvoiceEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalNet = new System.Windows.Forms.TextBox();
            this.lblServiceTax = new System.Windows.Forms.Label();
            this.txtAssessableAmt = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblNarration = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtOrderDate = new System.Windows.Forms.TextBox();
            this.txtPackingCharge = new System.Windows.Forms.TextBox();
            this.lblPackingCharge = new System.Windows.Forms.Label();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtVATAmt = new System.Windows.Forms.TextBox();
            this.lblAVAT = new System.Windows.Forms.Label();
            this.txtAVATAmt = new System.Windows.Forms.TextBox();
            this.lblCST = new System.Windows.Forms.Label();
            this.txtCSTAmt = new System.Windows.Forms.TextBox();
            this.lblExcise = new System.Windows.Forms.Label();
            this.txtExciseAmt = new System.Windows.Forms.TextBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscAmt = new System.Windows.Forms.TextBox();
            this.lblEduCess = new System.Windows.Forms.Label();
            this.lblHEduCess = new System.Windows.Forms.Label();
            this.lblAmtwithexcise = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.txtAmtwithExcise = new System.Windows.Forms.TextBox();
            this.txtHEduCessAmt = new System.Windows.Forms.TextBox();
            this.txtEduCessAmt = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblNetAmt = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.dgvPODetail = new System.Windows.Forms.DataGridView();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.ItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssessableValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExciseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EduCessAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HEduCessAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VATAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AVATAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPODetail)).BeginInit();
            this.grpErrorZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtTotalNet);
            this.grpData.Controls.Add(this.lblServiceTax);
            this.grpData.Controls.Add(this.txtAssessableAmt);
            this.grpData.Controls.Add(this.txtPhone);
            this.grpData.Controls.Add(this.lblPhone);
            this.grpData.Controls.Add(this.txtVendor);
            this.grpData.Controls.Add(this.lblVendor);
            this.grpData.Controls.Add(this.txtNarration);
            this.grpData.Controls.Add(this.lblNarration);
            this.grpData.Controls.Add(this.btnAdd);
            this.grpData.Controls.Add(this.btnDelete);
            this.grpData.Controls.Add(this.txtOrderDate);
            this.grpData.Controls.Add(this.txtPackingCharge);
            this.grpData.Controls.Add(this.lblPackingCharge);
            this.grpData.Controls.Add(this.lblVAT);
            this.grpData.Controls.Add(this.txtVATAmt);
            this.grpData.Controls.Add(this.lblAVAT);
            this.grpData.Controls.Add(this.txtAVATAmt);
            this.grpData.Controls.Add(this.lblCST);
            this.grpData.Controls.Add(this.txtCSTAmt);
            this.grpData.Controls.Add(this.lblExcise);
            this.grpData.Controls.Add(this.txtExciseAmt);
            this.grpData.Controls.Add(this.lblDiscount);
            this.grpData.Controls.Add(this.txtDiscAmt);
            this.grpData.Controls.Add(this.lblEduCess);
            this.grpData.Controls.Add(this.lblHEduCess);
            this.grpData.Controls.Add(this.lblAmtwithexcise);
            this.grpData.Controls.Add(this.txtNetAmount);
            this.grpData.Controls.Add(this.txtAmtwithExcise);
            this.grpData.Controls.Add(this.txtHEduCessAmt);
            this.grpData.Controls.Add(this.txtEduCessAmt);
            this.grpData.Controls.Add(this.txtAmount);
            this.grpData.Controls.Add(this.lblNetAmt);
            this.grpData.Controls.Add(this.lblAmount);
            this.grpData.Controls.Add(this.dgvPODetail);
            this.grpData.Controls.Add(this.txtOrderNo);
            this.grpData.Controls.Add(this.lblOrderNo);
            this.grpData.Controls.Add(this.lblOrderDate);
            this.grpData.Location = new System.Drawing.Point(12, 89);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(868, 557);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(602, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Total Net Amount:";
            // 
            // txtTotalNet
            // 
            this.txtTotalNet.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtTotalNet.Location = new System.Drawing.Point(719, 484);
            this.txtTotalNet.MaxLength = 12;
            this.txtTotalNet.Name = "txtTotalNet";
            this.txtTotalNet.ReadOnly = true;
            this.txtTotalNet.Size = new System.Drawing.Size(142, 21);
            this.txtTotalNet.TabIndex = 38;
            this.txtTotalNet.TabStop = false;
            this.txtTotalNet.Tag = "Total net amount;";
            this.txtTotalNet.Text = "0.00";
            this.txtTotalNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblServiceTax
            // 
            this.lblServiceTax.AutoSize = true;
            this.lblServiceTax.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblServiceTax.Location = new System.Drawing.Point(558, 295);
            this.lblServiceTax.Name = "lblServiceTax";
            this.lblServiceTax.Size = new System.Drawing.Size(155, 13);
            this.lblServiceTax.TabIndex = 15;
            this.lblServiceTax.Text = "Total Assessable Amount:";
            // 
            // txtAssessableAmt
            // 
            this.txtAssessableAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAssessableAmt.Location = new System.Drawing.Point(719, 292);
            this.txtAssessableAmt.MaxLength = 12;
            this.txtAssessableAmt.Name = "txtAssessableAmt";
            this.txtAssessableAmt.ReadOnly = true;
            this.txtAssessableAmt.Size = new System.Drawing.Size(142, 21);
            this.txtAssessableAmt.TabIndex = 16;
            this.txtAssessableAmt.TabStop = false;
            this.txtAssessableAmt.Tag = "Assessable amount;";
            this.txtAssessableAmt.Text = "0.00";
            this.txtAssessableAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(760, 19);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(101, 21);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.TabStop = false;
            this.txtPhone.Tag = "Phone;";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblPhone.Location = new System.Drawing.Point(707, 22);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(47, 13);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "Phone:";
            // 
            // txtVendor
            // 
            this.txtVendor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendor.Location = new System.Drawing.Point(438, 19);
            this.txtVendor.MaxLength = 20;
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            this.txtVendor.Size = new System.Drawing.Size(250, 21);
            this.txtVendor.TabIndex = 5;
            this.txtVendor.TabStop = false;
            this.txtVendor.Tag = "Vendor;";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblVendor.Location = new System.Drawing.Point(379, 22);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(53, 13);
            this.lblVendor.TabIndex = 4;
            this.lblVendor.Text = "Vendor:";
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(87, 292);
            this.txtNarration.MaxLength = 500;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNarration.Size = new System.Drawing.Size(371, 136);
            this.txtNarration.TabIndex = 36;
            this.txtNarration.Tag = "Enter narration;";
            // 
            // lblNarration
            // 
            this.lblNarration.AutoSize = true;
            this.lblNarration.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblNarration.Location = new System.Drawing.Point(16, 292);
            this.lblNarration.Name = "lblNarration";
            this.lblNarration.Size = new System.Drawing.Size(65, 13);
            this.lblNarration.TabIndex = 35;
            this.lblNarration.Text = "Narration:";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnAdd.Location = new System.Drawing.Point(6, 244);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Tag = "Click to add item;";
            this.btnAdd.Text = "New";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDelete.Location = new System.Drawing.Point(87, 244);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Tag = "Click to delete selected item;";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtOrderDate
            // 
            this.txtOrderDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderDate.Location = new System.Drawing.Point(273, 19);
            this.txtOrderDate.MaxLength = 20;
            this.txtOrderDate.Name = "txtOrderDate";
            this.txtOrderDate.ReadOnly = true;
            this.txtOrderDate.Size = new System.Drawing.Size(86, 21);
            this.txtOrderDate.TabIndex = 3;
            this.txtOrderDate.TabStop = false;
            this.txtOrderDate.Tag = "Order date;";
            // 
            // txtPackingCharge
            // 
            this.txtPackingCharge.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPackingCharge.Location = new System.Drawing.Point(719, 508);
            this.txtPackingCharge.MaxLength = 18;
            this.txtPackingCharge.Name = "txtPackingCharge";
            this.txtPackingCharge.Size = new System.Drawing.Size(142, 21);
            this.txtPackingCharge.TabIndex = 32;
            this.txtPackingCharge.Tag = "Enter packing charge;";
            this.txtPackingCharge.Text = "0.00";
            this.txtPackingCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPackingCharge.Leave += new System.EventHandler(this.txtPackingCharge_Leave);
            this.txtPackingCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPackingCharge_KeyPress);
            // 
            // lblPackingCharge
            // 
            this.lblPackingCharge.AutoSize = true;
            this.lblPackingCharge.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblPackingCharge.Location = new System.Drawing.Point(611, 511);
            this.lblPackingCharge.Name = "lblPackingCharge";
            this.lblPackingCharge.Size = new System.Drawing.Size(102, 13);
            this.lblPackingCharge.TabIndex = 31;
            this.lblPackingCharge.Text = "Packing Charge:";
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblVAT.Location = new System.Drawing.Point(646, 439);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(67, 13);
            this.lblVAT.TabIndex = 27;
            this.lblVAT.Text = "Total VAT:";
            // 
            // txtVATAmt
            // 
            this.txtVATAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtVATAmt.Location = new System.Drawing.Point(719, 436);
            this.txtVATAmt.MaxLength = 12;
            this.txtVATAmt.Name = "txtVATAmt";
            this.txtVATAmt.ReadOnly = true;
            this.txtVATAmt.Size = new System.Drawing.Size(142, 21);
            this.txtVATAmt.TabIndex = 28;
            this.txtVATAmt.TabStop = false;
            this.txtVATAmt.Tag = "VAT amount;";
            this.txtVATAmt.Text = "0.00";
            this.txtVATAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblAVAT
            // 
            this.lblAVAT.AutoSize = true;
            this.lblAVAT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAVAT.Location = new System.Drawing.Point(586, 463);
            this.lblAVAT.Name = "lblAVAT";
            this.lblAVAT.Size = new System.Drawing.Size(127, 13);
            this.lblAVAT.TabIndex = 29;
            this.lblAVAT.Text = "Total Additional VAT:";
            // 
            // txtAVATAmt
            // 
            this.txtAVATAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAVATAmt.Location = new System.Drawing.Point(719, 460);
            this.txtAVATAmt.MaxLength = 12;
            this.txtAVATAmt.Name = "txtAVATAmt";
            this.txtAVATAmt.ReadOnly = true;
            this.txtAVATAmt.Size = new System.Drawing.Size(142, 21);
            this.txtAVATAmt.TabIndex = 30;
            this.txtAVATAmt.TabStop = false;
            this.txtAVATAmt.Tag = "Avat amount;";
            this.txtAVATAmt.Text = "0.00";
            this.txtAVATAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCST
            // 
            this.lblCST.AutoSize = true;
            this.lblCST.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCST.Location = new System.Drawing.Point(645, 415);
            this.lblCST.Name = "lblCST";
            this.lblCST.Size = new System.Drawing.Size(68, 13);
            this.lblCST.TabIndex = 25;
            this.lblCST.Text = "Total CST:";
            // 
            // txtCSTAmt
            // 
            this.txtCSTAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtCSTAmt.Location = new System.Drawing.Point(719, 412);
            this.txtCSTAmt.MaxLength = 12;
            this.txtCSTAmt.Name = "txtCSTAmt";
            this.txtCSTAmt.ReadOnly = true;
            this.txtCSTAmt.Size = new System.Drawing.Size(142, 21);
            this.txtCSTAmt.TabIndex = 26;
            this.txtCSTAmt.TabStop = false;
            this.txtCSTAmt.Tag = "CST amount;";
            this.txtCSTAmt.Text = "0.00";
            this.txtCSTAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblExcise
            // 
            this.lblExcise.AutoSize = true;
            this.lblExcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblExcise.Location = new System.Drawing.Point(633, 319);
            this.lblExcise.Name = "lblExcise";
            this.lblExcise.Size = new System.Drawing.Size(80, 13);
            this.lblExcise.TabIndex = 17;
            this.lblExcise.Text = "Total Excise:";
            // 
            // txtExciseAmt
            // 
            this.txtExciseAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtExciseAmt.Location = new System.Drawing.Point(719, 316);
            this.txtExciseAmt.MaxLength = 12;
            this.txtExciseAmt.Name = "txtExciseAmt";
            this.txtExciseAmt.ReadOnly = true;
            this.txtExciseAmt.Size = new System.Drawing.Size(142, 21);
            this.txtExciseAmt.TabIndex = 18;
            this.txtExciseAmt.TabStop = false;
            this.txtExciseAmt.Tag = "Excise amount;";
            this.txtExciseAmt.Text = "0.00";
            this.txtExciseAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDiscount.Location = new System.Drawing.Point(620, 271);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(93, 13);
            this.lblDiscount.TabIndex = 13;
            this.lblDiscount.Text = "Total Discount:";
            // 
            // txtDiscAmt
            // 
            this.txtDiscAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtDiscAmt.Location = new System.Drawing.Point(719, 268);
            this.txtDiscAmt.MaxLength = 12;
            this.txtDiscAmt.Name = "txtDiscAmt";
            this.txtDiscAmt.ReadOnly = true;
            this.txtDiscAmt.Size = new System.Drawing.Size(142, 21);
            this.txtDiscAmt.TabIndex = 14;
            this.txtDiscAmt.TabStop = false;
            this.txtDiscAmt.Tag = "Discount amount;";
            this.txtDiscAmt.Text = "0.00";
            this.txtDiscAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblEduCess
            // 
            this.lblEduCess.AutoSize = true;
            this.lblEduCess.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEduCess.Location = new System.Drawing.Point(612, 343);
            this.lblEduCess.Name = "lblEduCess";
            this.lblEduCess.Size = new System.Drawing.Size(101, 13);
            this.lblEduCess.TabIndex = 19;
            this.lblEduCess.Text = "Total Edu. Cess:";
            // 
            // lblHEduCess
            // 
            this.lblHEduCess.AutoSize = true;
            this.lblHEduCess.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblHEduCess.Location = new System.Drawing.Point(604, 367);
            this.lblHEduCess.Name = "lblHEduCess";
            this.lblHEduCess.Size = new System.Drawing.Size(109, 13);
            this.lblHEduCess.TabIndex = 21;
            this.lblHEduCess.Text = "Total HEdu. Cess:";
            // 
            // lblAmtwithexcise
            // 
            this.lblAmtwithexcise.AutoSize = true;
            this.lblAmtwithexcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAmtwithexcise.Location = new System.Drawing.Point(575, 391);
            this.lblAmtwithexcise.Name = "lblAmtwithexcise";
            this.lblAmtwithexcise.Size = new System.Drawing.Size(138, 13);
            this.lblAmtwithexcise.TabIndex = 23;
            this.lblAmtwithexcise.Text = "Total Amt. with Excise:";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtNetAmount.Location = new System.Drawing.Point(719, 532);
            this.txtNetAmount.MaxLength = 15;
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.ReadOnly = true;
            this.txtNetAmount.Size = new System.Drawing.Size(142, 21);
            this.txtNetAmount.TabIndex = 34;
            this.txtNetAmount.TabStop = false;
            this.txtNetAmount.Tag = "Net amount;";
            this.txtNetAmount.Text = "0.00";
            this.txtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmtwithExcise
            // 
            this.txtAmtwithExcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmtwithExcise.Location = new System.Drawing.Point(719, 388);
            this.txtAmtwithExcise.MaxLength = 12;
            this.txtAmtwithExcise.Name = "txtAmtwithExcise";
            this.txtAmtwithExcise.ReadOnly = true;
            this.txtAmtwithExcise.Size = new System.Drawing.Size(142, 21);
            this.txtAmtwithExcise.TabIndex = 24;
            this.txtAmtwithExcise.TabStop = false;
            this.txtAmtwithExcise.Tag = "Amount with excise;";
            this.txtAmtwithExcise.Text = "0.00";
            this.txtAmtwithExcise.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHEduCessAmt
            // 
            this.txtHEduCessAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtHEduCessAmt.Location = new System.Drawing.Point(719, 364);
            this.txtHEduCessAmt.MaxLength = 12;
            this.txtHEduCessAmt.Name = "txtHEduCessAmt";
            this.txtHEduCessAmt.ReadOnly = true;
            this.txtHEduCessAmt.Size = new System.Drawing.Size(142, 21);
            this.txtHEduCessAmt.TabIndex = 22;
            this.txtHEduCessAmt.TabStop = false;
            this.txtHEduCessAmt.Tag = "Hedu. cess amount;";
            this.txtHEduCessAmt.Text = "0.00";
            this.txtHEduCessAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtEduCessAmt
            // 
            this.txtEduCessAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtEduCessAmt.Location = new System.Drawing.Point(719, 340);
            this.txtEduCessAmt.MaxLength = 12;
            this.txtEduCessAmt.Name = "txtEduCessAmt";
            this.txtEduCessAmt.ReadOnly = true;
            this.txtEduCessAmt.Size = new System.Drawing.Size(142, 21);
            this.txtEduCessAmt.TabIndex = 20;
            this.txtEduCessAmt.TabStop = false;
            this.txtEduCessAmt.Tag = "Edu. cess amount;";
            this.txtEduCessAmt.Text = "0.00";
            this.txtEduCessAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtAmount.Location = new System.Drawing.Point(719, 244);
            this.txtAmount.MaxLength = 12;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(142, 21);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TabStop = false;
            this.txtAmount.Tag = "Amount;";
            this.txtAmount.Text = "0.00";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNetAmt
            // 
            this.lblNetAmt.AutoSize = true;
            this.lblNetAmt.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblNetAmt.Location = new System.Drawing.Point(634, 535);
            this.lblNetAmt.Name = "lblNetAmt";
            this.lblNetAmt.Size = new System.Drawing.Size(79, 13);
            this.lblNetAmt.TabIndex = 33;
            this.lblNetAmt.Text = "Net Amount:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAmount.Location = new System.Drawing.Point(625, 247);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(88, 13);
            this.lblAmount.TabIndex = 11;
            this.lblAmount.Text = "Total Amount:";
            // 
            // dgvPODetail
            // 
            this.dgvPODetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPODetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemID,
            this.ItemName,
            this.Qty,
            this.UOM,
            this.Rate,
            this.Amount,
            this.DiscAmount,
            this.AssessableValue,
            this.ExciseAmount,
            this.EduCessAmount,
            this.HEduCessAmount,
            this.TotalAmount,
            this.CSTAmount,
            this.VATAmount,
            this.AVATAmount,
            this.NetAmount});
            this.dgvPODetail.Location = new System.Drawing.Point(6, 52);
            this.dgvPODetail.Name = "dgvPODetail";
            this.dgvPODetail.Size = new System.Drawing.Size(855, 186);
            this.dgvPODetail.TabIndex = 8;
            this.dgvPODetail.Tag = "List of po detail;";
            this.dgvPODetail.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPODetail_CellPainting);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(72, 19);
            this.txtOrderNo.MaxLength = 20;
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.ReadOnly = true;
            this.txtOrderNo.Size = new System.Drawing.Size(101, 21);
            this.txtOrderNo.TabIndex = 1;
            this.txtOrderNo.TabStop = false;
            this.txtOrderNo.Tag = "Order no;@";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblOrderNo.Location = new System.Drawing.Point(4, 22);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(64, 13);
            this.lblOrderNo.TabIndex = 0;
            this.lblOrderNo.Text = "Order No:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblOrderDate.Location = new System.Drawing.Point(191, 22);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(76, 13);
            this.lblOrderDate.TabIndex = 2;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 28);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(868, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(856, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(695, 652);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(104, 23);
            this.btnSaveExit.TabIndex = 27;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(805, 652);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(9, 649);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 29;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // ItemID
            // 
            this.ItemID.HeaderText = "ItemID";
            this.ItemID.Name = "ItemID";
            this.ItemID.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item";
            this.ItemName.Name = "ItemName";
            // 
            // Qty
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Qty.DefaultCellStyle = dataGridViewCellStyle1;
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // UOM
            // 
            this.UOM.HeaderText = "UOM";
            this.UOM.Name = "UOM";
            // 
            // Rate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.00";
            this.Rate.DefaultCellStyle = dataGridViewCellStyle2;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Amount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // DiscAmount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiscAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.DiscAmount.HeaderText = "Disc. Amt";
            this.DiscAmount.Name = "DiscAmount";
            // 
            // AssessableValue
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AssessableValue.DefaultCellStyle = dataGridViewCellStyle5;
            this.AssessableValue.HeaderText = "Total AV";
            this.AssessableValue.Name = "AssessableValue";
            // 
            // ExciseAmount
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ExciseAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.ExciseAmount.HeaderText = "Excise Amt";
            this.ExciseAmount.Name = "ExciseAmount";
            // 
            // EduCessAmount
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EduCessAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.EduCessAmount.HeaderText = "EduCess Amount";
            this.EduCessAmount.Name = "EduCessAmount";
            // 
            // HEduCessAmount
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.HEduCessAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.HEduCessAmount.HeaderText = "HEduCess Amt";
            this.HEduCessAmount.Name = "HEduCessAmount";
            // 
            // TotalAmount
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.TotalAmount.HeaderText = "Amt with Excise";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // CSTAmount
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CSTAmount.DefaultCellStyle = dataGridViewCellStyle10;
            this.CSTAmount.HeaderText = "CST Amt";
            this.CSTAmount.Name = "CSTAmount";
            // 
            // VATAmount
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VATAmount.DefaultCellStyle = dataGridViewCellStyle11;
            this.VATAmount.HeaderText = "VAT Amt";
            this.VATAmount.Name = "VATAmount";
            // 
            // AVATAmount
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AVATAmount.DefaultCellStyle = dataGridViewCellStyle12;
            this.AVATAmount.HeaderText = "AVAT Amt";
            this.AVATAmount.Name = "AVATAmount";
            // 
            // NetAmount
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "#0.00";
            this.NetAmount.DefaultCellStyle = dataGridViewCellStyle13;
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            // 
            // frmPurchaseInvoiceEdit
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(892, 715);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmPurchaseInvoiceEdit";
            this.Load += new System.EventHandler(this.frmPurchaseInvoiceEdit_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPODetail)).EndInit();
            this.grpErrorZone.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.TextBox txtPackingCharge;
        private System.Windows.Forms.Label lblPackingCharge;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.TextBox txtVATAmt;
        private System.Windows.Forms.Label lblAVAT;
        private System.Windows.Forms.TextBox txtAVATAmt;
        private System.Windows.Forms.Label lblCST;
        private System.Windows.Forms.TextBox txtCSTAmt;
        private System.Windows.Forms.Label lblExcise;
        private System.Windows.Forms.TextBox txtExciseAmt;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscAmt;
        private System.Windows.Forms.Label lblEduCess;
        private System.Windows.Forms.Label lblHEduCess;
        private System.Windows.Forms.Label lblAmtwithexcise;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.TextBox txtAmtwithExcise;
        private System.Windows.Forms.TextBox txtHEduCessAmt;
        private System.Windows.Forms.TextBox txtEduCessAmt;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblNetAmt;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DataGridView dgvPODetail;
        internal System.Windows.Forms.TextBox txtOrderNo;
        internal System.Windows.Forms.Label lblOrderNo;
        internal System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.TextBox txtOrderDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.Label lblPhone;
        internal System.Windows.Forms.TextBox txtVendor;
        internal System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblNarration;
        private System.Windows.Forms.Label lblServiceTax;
        private System.Windows.Forms.TextBox txtAssessableAmt;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssessableValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExciseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn EduCessAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HEduCessAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn VATAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AVATAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
    }
}
