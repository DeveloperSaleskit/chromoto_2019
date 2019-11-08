namespace Account.GUI.TaxClass
{
    partial class frmTaxClassEntry
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExtraTaxType = new System.Windows.Forms.TextBox();
            this.txtExtraTax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSBCess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAVAT = new System.Windows.Forms.TextBox();
            this.lblAVAT = new System.Windows.Forms.Label();
            this.txtCST = new System.Windows.Forms.TextBox();
            this.lblCST = new System.Windows.Forms.Label();
            this.txtVAT = new System.Windows.Forms.TextBox();
            this.lblVAT = new System.Windows.Forms.Label();
            this.txtexcise = new System.Windows.Forms.TextBox();
            this.lblExcise = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtHEduCess = new System.Windows.Forms.TextBox();
            this.lblHEduCess = new System.Windows.Forms.Label();
            this.txtEduCess = new System.Windows.Forms.TextBox();
            this.lblEduCess = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.ErrTaxClass = new System.Windows.Forms.Label();
            this.txtTaxClass = new System.Windows.Forms.TextBox();
            this.lblTaxClass = new System.Windows.Forms.Label();
            this.txtServiceTax = new System.Windows.Forms.TextBox();
            this.lblServiceTax = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(256, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(146, 238);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(109, 23);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(7, 238);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(137, 23);
            this.btnSaveContinue.TabIndex = 1;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(9, 6);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(327, 55);
            this.grpErrorZone.TabIndex = 5;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(128, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(194, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(127, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtCGST);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.txtIGST);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.txtSGST);
            this.grpData.Controls.Add(this.label5);
            this.grpData.Controls.Add(this.txtExtraTaxType);
            this.grpData.Controls.Add(this.txtExtraTax);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.txtSBCess);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtAVAT);
            this.grpData.Controls.Add(this.lblAVAT);
            this.grpData.Controls.Add(this.txtCST);
            this.grpData.Controls.Add(this.lblCST);
            this.grpData.Controls.Add(this.txtVAT);
            this.grpData.Controls.Add(this.lblVAT);
            this.grpData.Controls.Add(this.txtexcise);
            this.grpData.Controls.Add(this.lblExcise);
            this.grpData.Controls.Add(this.dtpFromDate);
            this.grpData.Controls.Add(this.txtHEduCess);
            this.grpData.Controls.Add(this.lblHEduCess);
            this.grpData.Controls.Add(this.txtEduCess);
            this.grpData.Controls.Add(this.lblEduCess);
            this.grpData.Controls.Add(this.lblFromDate);
            this.grpData.Controls.Add(this.ErrTaxClass);
            this.grpData.Controls.Add(this.txtTaxClass);
            this.grpData.Controls.Add(this.lblTaxClass);
            this.grpData.Controls.Add(this.txtServiceTax);
            this.grpData.Controls.Add(this.lblServiceTax);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(9, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(327, 168);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // txtCGST
            // 
            this.txtCGST.Location = new System.Drawing.Point(144, 101);
            this.txtCGST.MaxLength = 5;
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(120, 21);
            this.txtCGST.TabIndex = 29;
            this.txtCGST.Tag = "Enter CGST;";
            this.txtCGST.Text = "0.00";
            this.txtCGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(93, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "CGST:";
            // 
            // txtIGST
            // 
            this.txtIGST.Location = new System.Drawing.Point(144, 128);
            this.txtIGST.MaxLength = 5;
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(120, 21);
            this.txtIGST.TabIndex = 31;
            this.txtIGST.Tag = "Enter IGST;";
            this.txtIGST.Text = "0.00";
            this.txtIGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(96, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "IGST:";
            // 
            // txtSGST
            // 
            this.txtSGST.Location = new System.Drawing.Point(144, 74);
            this.txtSGST.MaxLength = 5;
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(120, 21);
            this.txtSGST.TabIndex = 27;
            this.txtSGST.Tag = "Enter SGST;";
            this.txtSGST.Text = "0.00";
            this.txtSGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(94, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "SGST:";
            // 
            // txtExtraTaxType
            // 
            this.txtExtraTaxType.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtExtraTaxType.Location = new System.Drawing.Point(265, 300);
            this.txtExtraTaxType.MaxLength = 25;
            this.txtExtraTaxType.Name = "txtExtraTaxType";
            this.txtExtraTaxType.Size = new System.Drawing.Size(120, 21);
            this.txtExtraTaxType.TabIndex = 25;
            this.txtExtraTaxType.Tag = "Enter extra tax class name;";
            this.txtExtraTaxType.Text = "Extra tax:";
            this.txtExtraTaxType.Visible = false;
            // 
            // txtExtraTax
            // 
            this.txtExtraTax.Location = new System.Drawing.Point(391, 300);
            this.txtExtraTax.MaxLength = 5;
            this.txtExtraTax.Name = "txtExtraTax";
            this.txtExtraTax.Size = new System.Drawing.Size(120, 21);
            this.txtExtraTax.TabIndex = 24;
            this.txtExtraTax.Tag = "Enter Extra Tax;";
            this.txtExtraTax.Text = "0.00";
            this.txtExtraTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtExtraTax.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(337, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = " (SBC):";
            this.label2.Visible = false;
            // 
            // txtSBCess
            // 
            this.txtSBCess.Location = new System.Drawing.Point(391, 273);
            this.txtSBCess.MaxLength = 5;
            this.txtSBCess.Name = "txtSBCess";
            this.txtSBCess.Size = new System.Drawing.Size(120, 21);
            this.txtSBCess.TabIndex = 21;
            this.txtSBCess.Tag = "Enter swachch Bharat cess;";
            this.txtSBCess.Text = "0.00";
            this.txtSBCess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSBCess.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(263, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Swachh Bharat Cess";
            this.label1.Visible = false;
            // 
            // txtAVAT
            // 
            this.txtAVAT.Location = new System.Drawing.Point(391, 153);
            this.txtAVAT.MaxLength = 5;
            this.txtAVAT.Name = "txtAVAT";
            this.txtAVAT.Size = new System.Drawing.Size(120, 21);
            this.txtAVAT.TabIndex = 13;
            this.txtAVAT.Tag = "Enter AVAT;";
            this.txtAVAT.Text = "0.00";
            this.txtAVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAVAT.Visible = false;
            this.txtAVAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtAVAT.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblAVAT
            // 
            this.lblAVAT.AutoSize = true;
            this.lblAVAT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblAVAT.Location = new System.Drawing.Point(345, 157);
            this.lblAVAT.Name = "lblAVAT";
            this.lblAVAT.Size = new System.Drawing.Size(43, 13);
            this.lblAVAT.TabIndex = 12;
            this.lblAVAT.Text = "AVAT:";
            this.lblAVAT.Visible = false;
            // 
            // txtCST
            // 
            this.txtCST.Location = new System.Drawing.Point(391, 99);
            this.txtCST.MaxLength = 5;
            this.txtCST.Name = "txtCST";
            this.txtCST.Size = new System.Drawing.Size(120, 21);
            this.txtCST.TabIndex = 9;
            this.txtCST.Tag = "Enter CST;";
            this.txtCST.Text = "0.00";
            this.txtCST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCST.Visible = false;
            this.txtCST.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtCST.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblCST
            // 
            this.lblCST.AutoSize = true;
            this.lblCST.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCST.Location = new System.Drawing.Point(352, 103);
            this.lblCST.Name = "lblCST";
            this.lblCST.Size = new System.Drawing.Size(36, 13);
            this.lblCST.TabIndex = 8;
            this.lblCST.Text = "CST:";
            this.lblCST.Visible = false;
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(391, 126);
            this.txtVAT.MaxLength = 5;
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Size = new System.Drawing.Size(120, 21);
            this.txtVAT.TabIndex = 11;
            this.txtVAT.Tag = "Enter VAT;";
            this.txtVAT.Text = "0.00";
            this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVAT.Visible = false;
            this.txtVAT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtVAT.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblVAT.Location = new System.Drawing.Point(353, 130);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(35, 13);
            this.lblVAT.TabIndex = 10;
            this.lblVAT.Text = "VAT:";
            this.lblVAT.Visible = false;
            // 
            // txtexcise
            // 
            this.txtexcise.Location = new System.Drawing.Point(391, 180);
            this.txtexcise.MaxLength = 5;
            this.txtexcise.Name = "txtexcise";
            this.txtexcise.Size = new System.Drawing.Size(120, 21);
            this.txtexcise.TabIndex = 15;
            this.txtexcise.Tag = "Enter excise;";
            this.txtexcise.Text = "0.00";
            this.txtexcise.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtexcise.Visible = false;
            this.txtexcise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtexcise.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblExcise
            // 
            this.lblExcise.AutoSize = true;
            this.lblExcise.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblExcise.Location = new System.Drawing.Point(340, 183);
            this.lblExcise.Name = "lblExcise";
            this.lblExcise.Size = new System.Drawing.Size(48, 13);
            this.lblExcise.TabIndex = 14;
            this.lblExcise.Text = "Excise:";
            this.lblExcise.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(145, 45);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(120, 21);
            this.dtpFromDate.TabIndex = 5;
            this.dtpFromDate.Tag = "Select from date;";
            // 
            // txtHEduCess
            // 
            this.txtHEduCess.Location = new System.Drawing.Point(391, 238);
            this.txtHEduCess.MaxLength = 5;
            this.txtHEduCess.Name = "txtHEduCess";
            this.txtHEduCess.Size = new System.Drawing.Size(120, 21);
            this.txtHEduCess.TabIndex = 19;
            this.txtHEduCess.Tag = "Enter hedu cess;";
            this.txtHEduCess.Text = "0.00";
            this.txtHEduCess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHEduCess.Visible = false;
            this.txtHEduCess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtHEduCess.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblHEduCess
            // 
            this.lblHEduCess.AutoSize = true;
            this.lblHEduCess.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblHEduCess.Location = new System.Drawing.Point(311, 241);
            this.lblHEduCess.Name = "lblHEduCess";
            this.lblHEduCess.Size = new System.Drawing.Size(77, 13);
            this.lblHEduCess.TabIndex = 18;
            this.lblHEduCess.Text = "H.Edu Cess:";
            this.lblHEduCess.Visible = false;
            // 
            // txtEduCess
            // 
            this.txtEduCess.Location = new System.Drawing.Point(391, 207);
            this.txtEduCess.MaxLength = 5;
            this.txtEduCess.Name = "txtEduCess";
            this.txtEduCess.Size = new System.Drawing.Size(120, 21);
            this.txtEduCess.TabIndex = 17;
            this.txtEduCess.Tag = "Enter edu cess;";
            this.txtEduCess.Text = "0.00";
            this.txtEduCess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEduCess.Visible = false;
            this.txtEduCess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtEduCess.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblEduCess
            // 
            this.lblEduCess.AutoSize = true;
            this.lblEduCess.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEduCess.Location = new System.Drawing.Point(323, 210);
            this.lblEduCess.Name = "lblEduCess";
            this.lblEduCess.Size = new System.Drawing.Size(65, 13);
            this.lblEduCess.TabIndex = 16;
            this.lblEduCess.Text = "Edu Cess:";
            this.lblEduCess.Visible = false;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblFromDate.Location = new System.Drawing.Point(70, 48);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(72, 13);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From Date:";
            // 
            // ErrTaxClass
            // 
            this.ErrTaxClass.AutoSize = true;
            this.ErrTaxClass.ForeColor = System.Drawing.Color.Red;
            this.ErrTaxClass.Location = new System.Drawing.Point(269, 16);
            this.ErrTaxClass.Name = "ErrTaxClass";
            this.ErrTaxClass.Size = new System.Drawing.Size(15, 13);
            this.ErrTaxClass.TabIndex = 3;
            this.ErrTaxClass.Text = "*";
            // 
            // txtTaxClass
            // 
            this.txtTaxClass.Location = new System.Drawing.Point(145, 18);
            this.txtTaxClass.MaxLength = 25;
            this.txtTaxClass.Name = "txtTaxClass";
            this.txtTaxClass.Size = new System.Drawing.Size(120, 21);
            this.txtTaxClass.TabIndex = 2;
            this.txtTaxClass.Tag = "Enter tax class name;@";
            this.txtTaxClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTaxClass_KeyPress);
            // 
            // lblTaxClass
            // 
            this.lblTaxClass.AutoSize = true;
            this.lblTaxClass.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTaxClass.Location = new System.Drawing.Point(37, 21);
            this.lblTaxClass.Name = "lblTaxClass";
            this.lblTaxClass.Size = new System.Drawing.Size(105, 13);
            this.lblTaxClass.TabIndex = 1;
            this.lblTaxClass.Text = "Tax Class Name:";
            // 
            // txtServiceTax
            // 
            this.txtServiceTax.Location = new System.Drawing.Point(391, 72);
            this.txtServiceTax.MaxLength = 5;
            this.txtServiceTax.Name = "txtServiceTax";
            this.txtServiceTax.Size = new System.Drawing.Size(120, 21);
            this.txtServiceTax.TabIndex = 7;
            this.txtServiceTax.Tag = "Enter service tax;";
            this.txtServiceTax.Text = "0.00";
            this.txtServiceTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtServiceTax.Visible = false;
            this.txtServiceTax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceTax_KeyPress);
            this.txtServiceTax.Leave += new System.EventHandler(this.txtServiceTax_Leave);
            // 
            // lblServiceTax
            // 
            this.lblServiceTax.AutoSize = true;
            this.lblServiceTax.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblServiceTax.Location = new System.Drawing.Point(308, 75);
            this.lblServiceTax.Name = "lblServiceTax";
            this.lblServiceTax.Size = new System.Drawing.Size(80, 13);
            this.lblServiceTax.TabIndex = 6;
            this.lblServiceTax.Text = "Service Tax:";
            this.lblServiceTax.Visible = false;
            // 
            // frmTaxClassEntry
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(346, 294);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmTaxClassEntry";
            this.Load += new System.EventHandler(this.frmTaxClassEntry_Load);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtHEduCess;
        private System.Windows.Forms.Label lblHEduCess;
        private System.Windows.Forms.TextBox txtEduCess;
        private System.Windows.Forms.Label lblEduCess;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label ErrTaxClass;
        private System.Windows.Forms.TextBox txtTaxClass;
        private System.Windows.Forms.Label lblTaxClass;
        private System.Windows.Forms.TextBox txtServiceTax;
        private System.Windows.Forms.Label lblServiceTax;
        private System.Windows.Forms.TextBox txtVAT;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.TextBox txtexcise;
        private System.Windows.Forms.Label lblExcise;
        private System.Windows.Forms.TextBox txtAVAT;
        private System.Windows.Forms.Label lblAVAT;
        private System.Windows.Forms.TextBox txtCST;
        private System.Windows.Forms.Label lblCST;
        private System.Windows.Forms.TextBox txtSBCess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtExtraTaxType;
        private System.Windows.Forms.TextBox txtExtraTax;
        private System.Windows.Forms.TextBox txtCGST;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.Label label5;
    }
}
