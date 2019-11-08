namespace Account.GUI.ItemRegister
{
    partial class frmItemEntry
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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.ErrCurrency = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.txtHSN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpecification = new System.Windows.Forms.TextBox();
            this.ErrUOM = new System.Windows.Forms.Label();
            this.cmbUOM = new System.Windows.Forms.ComboBox();
            this.ErrItemCode = new System.Windows.Forms.Label();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.ErrItemName = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.txtOtherName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.lblUOM = new System.Windows.Forms.Label();
            this.lblItemNameCaption = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.lblCity = new System.Windows.Forms.Label();
            this.cmbgodown = new System.Windows.Forms.ComboBox();
            this.txtOpeningStock = new System.Windows.Forms.TextBox();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.txtReorderLevel = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtRackNo = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblRackNo = new System.Windows.Forms.Label();
            this.lblReorder = new System.Windows.Forms.Label();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.lblOpeningStock = new System.Windows.Forms.Label();
            this.gbStockDetail = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpErrorZone.SuspendLayout();
            this.gbStockDetail.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrCurrency);
            this.grpData.Controls.Add(this.label6);
            this.grpData.Controls.Add(this.cmbCurrency);
            this.grpData.Controls.Add(this.txtHSN);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.txtProductCode);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.txtprice);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.txtSpecification);
            this.grpData.Controls.Add(this.ErrUOM);
            this.grpData.Controls.Add(this.cmbUOM);
            this.grpData.Controls.Add(this.ErrItemCode);
            this.grpData.Controls.Add(this.btnRegenrate);
            this.grpData.Controls.Add(this.ErrItemName);
            this.grpData.Controls.Add(this.txtItemCode);
            this.grpData.Controls.Add(this.txtItemName);
            this.grpData.Controls.Add(this.txtOtherName);
            this.grpData.Controls.Add(this.Label1);
            this.grpData.Controls.Add(this.lblItemCode);
            this.grpData.Controls.Add(this.lblUOM);
            this.grpData.Controls.Add(this.lblItemNameCaption);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(9, 60);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(403, 206);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "Item Details";
            // 
            // ErrCurrency
            // 
            this.ErrCurrency.AutoSize = true;
            this.ErrCurrency.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrCurrency.ForeColor = System.Drawing.Color.Red;
            this.ErrCurrency.Location = new System.Drawing.Point(386, 80);
            this.ErrCurrency.Name = "ErrCurrency";
            this.ErrCurrency.Size = new System.Drawing.Size(14, 13);
            this.ErrCurrency.TabIndex = 36;
            this.ErrCurrency.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(207, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Currency:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(276, 76);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(101, 21);
            this.cmbCurrency.TabIndex = 4;
            this.cmbCurrency.Tag = "Select city;@";
            // 
            // txtHSN
            // 
            this.txtHSN.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHSN.Location = new System.Drawing.Point(276, 131);
            this.txtHSN.MaxLength = 200;
            this.txtHSN.Name = "txtHSN";
            this.txtHSN.Size = new System.Drawing.Size(101, 21);
            this.txtHSN.TabIndex = 7;
            this.txtHSN.Tag = "Enter HSN Code;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(203, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "HSN Code:";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(99, 131);
            this.txtProductCode.MaxLength = 200;
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(101, 21);
            this.txtProductCode.TabIndex = 6;
            this.txtProductCode.Tag = "Enter Product Code;";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(4, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Product Code:";
            // 
            // txtprice
            // 
            this.txtprice.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtprice.Location = new System.Drawing.Point(99, 76);
            this.txtprice.MaxLength = 200;
            this.txtprice.Multiline = true;
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(101, 21);
            this.txtprice.TabIndex = 3;
            this.txtprice.Tag = "Enter Price;";
            this.txtprice.Text = "0.00";
            this.txtprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprice_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Price:";
            // 
            // txtSpecification
            // 
            this.txtSpecification.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecification.Location = new System.Drawing.Point(99, 158);
            this.txtSpecification.MaxLength = 4000;
            this.txtSpecification.Multiline = true;
            this.txtSpecification.Name = "txtSpecification";
            this.txtSpecification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpecification.Size = new System.Drawing.Size(278, 40);
            this.txtSpecification.TabIndex = 8;
            this.txtSpecification.Tag = "Enter specification;";
            // 
            // ErrUOM
            // 
            this.ErrUOM.AutoSize = true;
            this.ErrUOM.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrUOM.ForeColor = System.Drawing.Color.Red;
            this.ErrUOM.Location = new System.Drawing.Point(386, 106);
            this.ErrUOM.Name = "ErrUOM";
            this.ErrUOM.Size = new System.Drawing.Size(14, 13);
            this.ErrUOM.TabIndex = 20;
            this.ErrUOM.Text = "*";
            // 
            // cmbUOM
            // 
            this.cmbUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUOM.FormattingEnabled = true;
            this.cmbUOM.Location = new System.Drawing.Point(99, 103);
            this.cmbUOM.Name = "cmbUOM";
            this.cmbUOM.Size = new System.Drawing.Size(278, 21);
            this.cmbUOM.TabIndex = 5;
            this.cmbUOM.Tag = "Select UOM;@";
            // 
            // ErrItemCode
            // 
            this.ErrItemCode.AutoSize = true;
            this.ErrItemCode.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrItemCode.ForeColor = System.Drawing.Color.Red;
            this.ErrItemCode.Location = new System.Drawing.Point(333, 8);
            this.ErrItemCode.Name = "ErrItemCode";
            this.ErrItemCode.Size = new System.Drawing.Size(14, 13);
            this.ErrItemCode.TabIndex = 3;
            this.ErrItemCode.Text = "*";
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(333, 20);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(44, 23);
            this.btnRegenrate.TabIndex = 1;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate item code;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // ErrItemName
            // 
            this.ErrItemName.AutoSize = true;
            this.ErrItemName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrItemName.ForeColor = System.Drawing.Color.Red;
            this.ErrItemName.Location = new System.Drawing.Point(386, 47);
            this.ErrItemName.Name = "ErrItemName";
            this.ErrItemName.Size = new System.Drawing.Size(14, 13);
            this.ErrItemName.TabIndex = 7;
            this.ErrItemName.Text = "*";
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(99, 22);
            this.txtItemCode.MaxLength = 100;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(228, 21);
            this.txtItemCode.TabIndex = 0;
            this.txtItemCode.TabStop = false;
            this.txtItemCode.Tag = "Item code;@";
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemName.Location = new System.Drawing.Point(99, 47);
            this.txtItemName.MaxLength = 200;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(278, 21);
            this.txtItemName.TabIndex = 2;
            this.txtItemName.Tag = "Enter item;@";
            this.txtItemName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecification_KeyPress);
            // 
            // txtOtherName
            // 
            this.txtOtherName.Location = new System.Drawing.Point(6, 177);
            this.txtOtherName.MaxLength = 200;
            this.txtOtherName.Multiline = true;
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(31, 21);
            this.txtOtherName.TabIndex = 9;
            this.txtOtherName.Tag = "Enter other name;";
            this.txtOtherName.Visible = false;
            this.txtOtherName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecification_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(10, 161);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(76, 13);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Description:";
            // 
            // lblItemCode
            // 
            this.lblItemCode.AutoSize = true;
            this.lblItemCode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.ForeColor = System.Drawing.Color.Black;
            this.lblItemCode.Location = new System.Drawing.Point(23, 25);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(73, 13);
            this.lblItemCode.TabIndex = 1;
            this.lblItemCode.Text = "Item Code:";
            // 
            // lblUOM
            // 
            this.lblUOM.AutoSize = true;
            this.lblUOM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOM.ForeColor = System.Drawing.Color.Black;
            this.lblUOM.Location = new System.Drawing.Point(57, 106);
            this.lblUOM.Name = "lblUOM";
            this.lblUOM.Size = new System.Drawing.Size(38, 13);
            this.lblUOM.TabIndex = 18;
            this.lblUOM.Text = "UOM:";
            // 
            // lblItemNameCaption
            // 
            this.lblItemNameCaption.AutoSize = true;
            this.lblItemNameCaption.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemNameCaption.ForeColor = System.Drawing.Color.Black;
            this.lblItemNameCaption.Location = new System.Drawing.Point(57, 50);
            this.lblItemNameCaption.Name = "lblItemNameCaption";
            this.lblItemNameCaption.Size = new System.Drawing.Size(39, 13);
            this.lblItemNameCaption.TabIndex = 5;
            this.lblItemNameCaption.Text = "Item:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(506, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowse.Location = new System.Drawing.Point(386, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(114, 24);
            this.btnBrowse.TabIndex = 217;
            this.btnBrowse.Tag = "Click to browse;";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocName.Location = new System.Drawing.Point(96, 20);
            this.txtDocName.MaxLength = 100;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(278, 21);
            this.txtDocName.TabIndex = 216;
            this.txtDocName.Tag = "Select Document;";
            this.txtDocName.TextChanged += new System.EventHandler(this.txtDocName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 220;
            this.label5.Text = "Item Image:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(564, 14);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(112, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(10, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(697, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 14);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(587, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(10, 272);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 26;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(633, 272);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(487, 272);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(141, 23);
            this.btnSaveExit.TabIndex = 4;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(312, 272);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(169, 23);
            this.btnSaveContinue.TabIndex = 3;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(19, 26);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(62, 13);
            this.lblCity.TabIndex = 44;
            this.lblCity.Text = "Godown :";
            // 
            // cmbgodown
            // 
            this.cmbgodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbgodown.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbgodown.FormattingEnabled = true;
            this.cmbgodown.Location = new System.Drawing.Point(102, 22);
            this.cmbgodown.Name = "cmbgodown";
            this.cmbgodown.Size = new System.Drawing.Size(180, 21);
            this.cmbgodown.TabIndex = 0;
            this.cmbgodown.Tag = "Select Godown Name;@";
            // 
            // txtOpeningStock
            // 
            this.txtOpeningStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOpeningStock.Location = new System.Drawing.Point(102, 49);
            this.txtOpeningStock.MaxLength = 18;
            this.txtOpeningStock.Name = "txtOpeningStock";
            this.txtOpeningStock.Size = new System.Drawing.Size(180, 21);
            this.txtOpeningStock.TabIndex = 1;
            this.txtOpeningStock.Tag = "Enter opening stock;";
            this.txtOpeningStock.Text = "0.000";
            this.txtOpeningStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentStock.Location = new System.Drawing.Point(102, 77);
            this.txtCurrentStock.MaxLength = 50;
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Size = new System.Drawing.Size(180, 21);
            this.txtCurrentStock.TabIndex = 2;
            this.txtCurrentStock.TabStop = false;
            this.txtCurrentStock.Tag = "Current stock;";
            this.txtCurrentStock.Text = "0.000";
            this.txtCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReorderLevel
            // 
            this.txtReorderLevel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReorderLevel.Location = new System.Drawing.Point(102, 106);
            this.txtReorderLevel.MaxLength = 18;
            this.txtReorderLevel.Name = "txtReorderLevel";
            this.txtReorderLevel.Size = new System.Drawing.Size(180, 21);
            this.txtReorderLevel.TabIndex = 3;
            this.txtReorderLevel.Tag = "Enter reorder level;@";
            this.txtReorderLevel.Text = "0.000";
            this.txtReorderLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(102, 130);
            this.txtLocation.MaxLength = 100;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(180, 21);
            this.txtLocation.TabIndex = 4;
            this.txtLocation.Tag = "Enter location;";
            // 
            // txtRackNo
            // 
            this.txtRackNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRackNo.Location = new System.Drawing.Point(102, 158);
            this.txtRackNo.MaxLength = 100;
            this.txtRackNo.Name = "txtRackNo";
            this.txtRackNo.Size = new System.Drawing.Size(180, 21);
            this.txtRackNo.TabIndex = 5;
            this.txtRackNo.Tag = "Enter rack no;";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.ForeColor = System.Drawing.Color.Black;
            this.lblLocation.Location = new System.Drawing.Point(40, 134);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(59, 13);
            this.lblLocation.TabIndex = 40;
            this.lblLocation.Text = "Location:";
            // 
            // lblRackNo
            // 
            this.lblRackNo.AutoSize = true;
            this.lblRackNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRackNo.ForeColor = System.Drawing.Color.Black;
            this.lblRackNo.Location = new System.Drawing.Point(40, 161);
            this.lblRackNo.Name = "lblRackNo";
            this.lblRackNo.Size = new System.Drawing.Size(59, 13);
            this.lblRackNo.TabIndex = 42;
            this.lblRackNo.Text = "Rack No:";
            // 
            // lblReorder
            // 
            this.lblReorder.AutoSize = true;
            this.lblReorder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReorder.ForeColor = System.Drawing.Color.Black;
            this.lblReorder.Location = new System.Drawing.Point(7, 109);
            this.lblReorder.Name = "lblReorder";
            this.lblReorder.Size = new System.Drawing.Size(92, 13);
            this.lblReorder.TabIndex = 38;
            this.lblReorder.Text = "Reorder Level:";
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStock.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentStock.Location = new System.Drawing.Point(7, 81);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(92, 13);
            this.lblCurrentStock.TabIndex = 36;
            this.lblCurrentStock.Text = "Current Stock:";
            // 
            // lblOpeningStock
            // 
            this.lblOpeningStock.AutoSize = true;
            this.lblOpeningStock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpeningStock.ForeColor = System.Drawing.Color.Black;
            this.lblOpeningStock.Location = new System.Drawing.Point(4, 53);
            this.lblOpeningStock.Name = "lblOpeningStock";
            this.lblOpeningStock.Size = new System.Drawing.Size(95, 13);
            this.lblOpeningStock.TabIndex = 34;
            this.lblOpeningStock.Text = "Opening Stock:";
            // 
            // gbStockDetail
            // 
            this.gbStockDetail.Controls.Add(this.label7);
            this.gbStockDetail.Controls.Add(this.lblCity);
            this.gbStockDetail.Controls.Add(this.cmbgodown);
            this.gbStockDetail.Controls.Add(this.lblOpeningStock);
            this.gbStockDetail.Controls.Add(this.txtOpeningStock);
            this.gbStockDetail.Controls.Add(this.lblCurrentStock);
            this.gbStockDetail.Controls.Add(this.txtCurrentStock);
            this.gbStockDetail.Controls.Add(this.lblReorder);
            this.gbStockDetail.Controls.Add(this.txtReorderLevel);
            this.gbStockDetail.Controls.Add(this.lblRackNo);
            this.gbStockDetail.Controls.Add(this.txtLocation);
            this.gbStockDetail.Controls.Add(this.lblLocation);
            this.gbStockDetail.Controls.Add(this.txtRackNo);
            this.gbStockDetail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.gbStockDetail.Location = new System.Drawing.Point(416, 60);
            this.gbStockDetail.Name = "gbStockDetail";
            this.gbStockDetail.Size = new System.Drawing.Size(291, 206);
            this.gbStockDetail.TabIndex = 2;
            this.gbStockDetail.TabStop = false;
            this.gbStockDetail.Text = "Stock Details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDocName);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(695, 113);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Image Details";
            this.groupBox1.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(82, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "*";
            // 
            // frmItemEntry
            // 
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(717, 331);
            this.Controls.Add(this.gbStockDetail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmItemEntry";
            this.Load += new System.EventHandler(this.frmItemEntry_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.gbStockDetail, 0);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.gbStockDetail.ResumeLayout(false);
            this.gbStockDetail.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.TextBox txtItemCode;
        internal System.Windows.Forms.TextBox txtItemName;
        internal System.Windows.Forms.ComboBox cmbUOM;
        internal System.Windows.Forms.TextBox txtOtherName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblItemCode;
        internal System.Windows.Forms.Label lblUOM;
        internal System.Windows.Forms.Label lblItemNameCaption;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblDelMsg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrItemName;
        private System.Windows.Forms.Label ErrUOM;
        private System.Windows.Forms.Button btnRegenrate;
        private System.Windows.Forms.Label ErrItemCode;
        internal System.Windows.Forms.TextBox txtprice;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtSpecification;
        internal System.Windows.Forms.TextBox txtHSN;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtProductCode;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbgodown;
        internal System.Windows.Forms.TextBox txtOpeningStock;
        internal System.Windows.Forms.TextBox txtCurrentStock;
        internal System.Windows.Forms.TextBox txtReorderLevel;
        internal System.Windows.Forms.TextBox txtLocation;
        internal System.Windows.Forms.TextBox txtRackNo;
        internal System.Windows.Forms.Label lblLocation;
        internal System.Windows.Forms.Label lblRackNo;
        internal System.Windows.Forms.Label lblReorder;
        internal System.Windows.Forms.Label lblCurrentStock;
        internal System.Windows.Forms.Label lblOpeningStock;
        private System.Windows.Forms.GroupBox gbStockDetail;
        private System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ErrCurrency;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label7;
    }
}
