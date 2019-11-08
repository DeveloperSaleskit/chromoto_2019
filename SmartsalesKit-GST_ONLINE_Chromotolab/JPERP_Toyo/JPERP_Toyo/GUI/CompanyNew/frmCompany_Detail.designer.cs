namespace Account.GUI.Company
{
    partial class frmCompanyEntry
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
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtValue6 = new System.Windows.Forms.TextBox();
            this.txtValue5 = new System.Windows.Forms.TextBox();
            this.txtValue4 = new System.Windows.Forms.TextBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.txtName6 = new System.Windows.Forms.TextBox();
            this.txtName5 = new System.Windows.Forms.TextBox();
            this.txtName4 = new System.Windows.Forms.TextBox();
            this.txtName3 = new System.Windows.Forms.TextBox();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.txtName1 = new System.Windows.Forms.TextBox();
            this.btnBrowseFooter = new System.Windows.Forms.Button();
            this.lblFooter = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnBrowseHeader = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBrowseLogo = new System.Windows.Forms.Button();
            this.lblFax = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtPhone2 = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblPhone2 = new System.Windows.Forms.Label();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.txtPhone1 = new System.Windows.Forms.TextBox();
            this.lblPincode = new System.Windows.Forms.Label();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtBussinessLine = new System.Windows.Forms.TextBox();
            this.lblBussinessLine = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(866, 441);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExit.Location = new System.Drawing.Point(732, 441);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(126, 23);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 54);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(965, 55);
            this.grpErrorZone.TabIndex = 1;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(226, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(252, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(137, 17);
            this.lblrequired.TabIndex = 12;
            this.lblrequired.Text = "* - Required fields";
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lblValue);
            this.grpData.Controls.Add(this.lblName);
            this.grpData.Controls.Add(this.txtValue6);
            this.grpData.Controls.Add(this.txtValue5);
            this.grpData.Controls.Add(this.txtValue4);
            this.grpData.Controls.Add(this.txtValue3);
            this.grpData.Controls.Add(this.txtValue2);
            this.grpData.Controls.Add(this.txtValue1);
            this.grpData.Controls.Add(this.txtName6);
            this.grpData.Controls.Add(this.txtName5);
            this.grpData.Controls.Add(this.txtName4);
            this.grpData.Controls.Add(this.txtName3);
            this.grpData.Controls.Add(this.txtName2);
            this.grpData.Controls.Add(this.txtName1);
            this.grpData.Controls.Add(this.btnBrowseFooter);
            this.grpData.Controls.Add(this.lblFooter);
            this.grpData.Controls.Add(this.textBox2);
            this.grpData.Controls.Add(this.btnBrowseHeader);
            this.grpData.Controls.Add(this.lblHeader);
            this.grpData.Controls.Add(this.textBox1);
            this.grpData.Controls.Add(this.btnBrowseLogo);
            this.grpData.Controls.Add(this.lblFax);
            this.grpData.Controls.Add(this.lblLogo);
            this.grpData.Controls.Add(this.txtFax);
            this.grpData.Controls.Add(this.txtDocName);
            this.grpData.Controls.Add(this.lblMobile);
            this.grpData.Controls.Add(this.txtPhone2);
            this.grpData.Controls.Add(this.txtMobile);
            this.grpData.Controls.Add(this.lblPhone2);
            this.grpData.Controls.Add(this.lblPhone1);
            this.grpData.Controls.Add(this.txtPhone1);
            this.grpData.Controls.Add(this.lblPincode);
            this.grpData.Controls.Add(this.txtPincode);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.lblState);
            this.grpData.Controls.Add(this.cmbCity);
            this.grpData.Controls.Add(this.cmbState);
            this.grpData.Controls.Add(this.txtAddress2);
            this.grpData.Controls.Add(this.txtAddress1);
            this.grpData.Controls.Add(this.lblAddress);
            this.grpData.Controls.Add(this.txtCompanyName);
            this.grpData.Controls.Add(this.txtBussinessLine);
            this.grpData.Controls.Add(this.lblBussinessLine);
            this.grpData.Controls.Add(this.lblCompanyName);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 115);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(965, 320);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.ForeColor = System.Drawing.Color.Black;
            this.lblValue.Location = new System.Drawing.Point(863, 114);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(46, 17);
            this.lblValue.TabIndex = 172;
            this.lblValue.Text = "Value";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(681, 114);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 17);
            this.lblName.TabIndex = 171;
            this.lblName.Text = "Name";
            // 
            // txtValue6
            // 
            this.txtValue6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue6.Location = new System.Drawing.Point(820, 285);
            this.txtValue6.MaxLength = 20;
            this.txtValue6.Name = "txtValue6";
            this.txtValue6.Size = new System.Drawing.Size(134, 24);
            this.txtValue6.TabIndex = 170;
            this.txtValue6.Tag = "Enter Value 6;@";
            // 
            // txtValue5
            // 
            this.txtValue5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue5.Location = new System.Drawing.Point(820, 255);
            this.txtValue5.MaxLength = 20;
            this.txtValue5.Name = "txtValue5";
            this.txtValue5.Size = new System.Drawing.Size(134, 24);
            this.txtValue5.TabIndex = 169;
            this.txtValue5.Tag = "Enter Value 5;@";
            // 
            // txtValue4
            // 
            this.txtValue4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue4.Location = new System.Drawing.Point(820, 225);
            this.txtValue4.MaxLength = 20;
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.Size = new System.Drawing.Size(134, 24);
            this.txtValue4.TabIndex = 168;
            this.txtValue4.Tag = "Enter Value 4;@";
            // 
            // txtValue3
            // 
            this.txtValue3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue3.Location = new System.Drawing.Point(820, 195);
            this.txtValue3.MaxLength = 20;
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Size = new System.Drawing.Size(134, 24);
            this.txtValue3.TabIndex = 167;
            this.txtValue3.Tag = "Enter Value 3;@";
            // 
            // txtValue2
            // 
            this.txtValue2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue2.Location = new System.Drawing.Point(820, 165);
            this.txtValue2.MaxLength = 20;
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Size = new System.Drawing.Size(134, 24);
            this.txtValue2.TabIndex = 166;
            this.txtValue2.Tag = "Enter Value 2;@";
            // 
            // txtValue1
            // 
            this.txtValue1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue1.Location = new System.Drawing.Point(820, 135);
            this.txtValue1.MaxLength = 20;
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Size = new System.Drawing.Size(134, 24);
            this.txtValue1.TabIndex = 165;
            this.txtValue1.Tag = "Enter Value 1;@";
            // 
            // txtName6
            // 
            this.txtName6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName6.Location = new System.Drawing.Point(647, 285);
            this.txtName6.MaxLength = 20;
            this.txtName6.Name = "txtName6";
            this.txtName6.Size = new System.Drawing.Size(134, 24);
            this.txtName6.TabIndex = 164;
            this.txtName6.Tag = "Enter Name 6;@";
            // 
            // txtName5
            // 
            this.txtName5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName5.Location = new System.Drawing.Point(647, 255);
            this.txtName5.MaxLength = 20;
            this.txtName5.Name = "txtName5";
            this.txtName5.Size = new System.Drawing.Size(134, 24);
            this.txtName5.TabIndex = 163;
            this.txtName5.Tag = "Enter Name 5;@";
            // 
            // txtName4
            // 
            this.txtName4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName4.Location = new System.Drawing.Point(647, 225);
            this.txtName4.MaxLength = 20;
            this.txtName4.Name = "txtName4";
            this.txtName4.Size = new System.Drawing.Size(134, 24);
            this.txtName4.TabIndex = 162;
            this.txtName4.Tag = "Enter Name 4;@";
            // 
            // txtName3
            // 
            this.txtName3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName3.Location = new System.Drawing.Point(647, 195);
            this.txtName3.MaxLength = 20;
            this.txtName3.Name = "txtName3";
            this.txtName3.Size = new System.Drawing.Size(134, 24);
            this.txtName3.TabIndex = 161;
            this.txtName3.Tag = "Enter Name 3;@";
            // 
            // txtName2
            // 
            this.txtName2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName2.Location = new System.Drawing.Point(646, 166);
            this.txtName2.MaxLength = 20;
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(134, 24);
            this.txtName2.TabIndex = 160;
            this.txtName2.Tag = "Enter Name 2;@";
            // 
            // txtName1
            // 
            this.txtName1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName1.Location = new System.Drawing.Point(646, 137);
            this.txtName1.MaxLength = 20;
            this.txtName1.Name = "txtName1";
            this.txtName1.Size = new System.Drawing.Size(134, 24);
            this.txtName1.TabIndex = 159;
            this.txtName1.Tag = "Enter Name 1;@";
            // 
            // btnBrowseFooter
            // 
            this.btnBrowseFooter.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowseFooter.Location = new System.Drawing.Point(880, 75);
            this.btnBrowseFooter.Name = "btnBrowseFooter";
            this.btnBrowseFooter.Size = new System.Drawing.Size(74, 24);
            this.btnBrowseFooter.TabIndex = 158;
            this.btnBrowseFooter.Tag = "Click to browse Footer;";
            this.btnBrowseFooter.Text = "Browse";
            this.btnBrowseFooter.UseVisualStyleBackColor = true;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.Black;
            this.lblFooter.Location = new System.Drawing.Point(618, 78);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(65, 17);
            this.lblFooter.TabIndex = 157;
            this.lblFooter.Text = "Footer :";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(684, 75);
            this.textBox2.MaxLength = 100;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(190, 24);
            this.textBox2.TabIndex = 156;
            this.textBox2.Tag = "Select Document;";
            // 
            // btnBrowseHeader
            // 
            this.btnBrowseHeader.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowseHeader.Location = new System.Drawing.Point(880, 48);
            this.btnBrowseHeader.Name = "btnBrowseHeader";
            this.btnBrowseHeader.Size = new System.Drawing.Size(74, 24);
            this.btnBrowseHeader.TabIndex = 155;
            this.btnBrowseHeader.Tag = "Click to browse Header;";
            this.btnBrowseHeader.Text = "Browse ";
            this.btnBrowseHeader.UseVisualStyleBackColor = true;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Black;
            this.lblHeader.Location = new System.Drawing.Point(615, 52);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(68, 17);
            this.lblHeader.TabIndex = 154;
            this.lblHeader.Text = "Header :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(684, 48);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(190, 24);
            this.textBox1.TabIndex = 153;
            this.textBox1.Tag = "Select Document;";
            // 
            // btnBrowseLogo
            // 
            this.btnBrowseLogo.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowseLogo.Location = new System.Drawing.Point(880, 20);
            this.btnBrowseLogo.Name = "btnBrowseLogo";
            this.btnBrowseLogo.Size = new System.Drawing.Size(74, 24);
            this.btnBrowseLogo.TabIndex = 93;
            this.btnBrowseLogo.Tag = "Click to browse Logo;";
            this.btnBrowseLogo.Text = "Browse";
            this.btnBrowseLogo.UseVisualStyleBackColor = true;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.ForeColor = System.Drawing.Color.Black;
            this.lblFax.Location = new System.Drawing.Point(59, 229);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(50, 17);
            this.lblFax.TabIndex = 151;
            this.lblFax.Text = "Email:";
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.ForeColor = System.Drawing.Color.Black;
            this.lblLogo.Location = new System.Drawing.Point(629, 24);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(54, 17);
            this.lblLogo.TabIndex = 92;
            this.lblLogo.Text = "Logo :";
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(130, 226);
            this.txtFax.MaxLength = 150;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(466, 24);
            this.txtFax.TabIndex = 152;
            this.txtFax.Tag = "Enter fax;";
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocName.Location = new System.Drawing.Point(684, 20);
            this.txtDocName.MaxLength = 100;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(190, 24);
            this.txtDocName.TabIndex = 91;
            this.txtDocName.Tag = "Select Document;";
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.ForeColor = System.Drawing.Color.Black;
            this.lblMobile.Location = new System.Drawing.Point(369, 197);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(57, 17);
            this.lblMobile.TabIndex = 91;
            this.lblMobile.Text = "Mobile:";
            // 
            // txtPhone2
            // 
            this.txtPhone2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone2.Location = new System.Drawing.Point(426, 164);
            this.txtPhone2.MaxLength = 20;
            this.txtPhone2.Name = "txtPhone2";
            this.txtPhone2.Size = new System.Drawing.Size(170, 24);
            this.txtPhone2.TabIndex = 97;
            this.txtPhone2.Tag = "Enter phone 2;";
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(426, 193);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(170, 24);
            this.txtMobile.TabIndex = 92;
            this.txtMobile.Tag = "Enter mobile;";
            // 
            // lblPhone2
            // 
            this.lblPhone2.AutoSize = true;
            this.lblPhone2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone2.ForeColor = System.Drawing.Color.Black;
            this.lblPhone2.Location = new System.Drawing.Point(355, 168);
            this.lblPhone2.Name = "lblPhone2";
            this.lblPhone2.Size = new System.Drawing.Size(71, 17);
            this.lblPhone2.TabIndex = 96;
            this.lblPhone2.Text = "Phone 2:";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.ForeColor = System.Drawing.Color.Black;
            this.lblPhone1.Location = new System.Drawing.Point(355, 138);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(71, 17);
            this.lblPhone1.TabIndex = 94;
            this.lblPhone1.Text = "Phone 1:";
            // 
            // txtPhone1
            // 
            this.txtPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone1.Location = new System.Drawing.Point(426, 134);
            this.txtPhone1.MaxLength = 20;
            this.txtPhone1.Name = "txtPhone1";
            this.txtPhone1.Size = new System.Drawing.Size(170, 24);
            this.txtPhone1.TabIndex = 95;
            this.txtPhone1.Tag = "Enter phone 1;@";
            // 
            // lblPincode
            // 
            this.lblPincode.AutoSize = true;
            this.lblPincode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPincode.ForeColor = System.Drawing.Color.Black;
            this.lblPincode.Location = new System.Drawing.Point(59, 200);
            this.lblPincode.Name = "lblPincode";
            this.lblPincode.Size = new System.Drawing.Size(72, 17);
            this.lblPincode.TabIndex = 91;
            this.lblPincode.Text = "Pin code:";
            // 
            // txtPincode
            // 
            this.txtPincode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPincode.Location = new System.Drawing.Point(130, 196);
            this.txtPincode.MaxLength = 20;
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(170, 24);
            this.txtPincode.TabIndex = 92;
            this.txtPincode.Tag = "Enter pin code;";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(82, 169);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(41, 17);
            this.lblCity.TabIndex = 91;
            this.lblCity.Text = "City:";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.Black;
            this.lblState.Location = new System.Drawing.Point(72, 137);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(57, 17);
            this.lblState.TabIndex = 89;
            this.lblState.Text = "State :";
            // 
            // cmbCity
            // 
            this.cmbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(130, 165);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(170, 25);
            this.cmbCity.TabIndex = 92;
            this.cmbCity.Tag = "Select city;@";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(130, 134);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(170, 25);
            this.cmbState.TabIndex = 88;
            this.cmbState.Tag = "Select State;";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(130, 104);
            this.txtAddress2.MaxLength = 2550;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(466, 24);
            this.txtAddress2.TabIndex = 93;
            this.txtAddress2.Tag = "Enter address2;@";
            this.txtAddress2.UseSystemPasswordChar = true;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(130, 74);
            this.txtAddress1.MaxLength = 2550;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(466, 24);
            this.txtAddress1.TabIndex = 3;
            this.txtAddress1.Tag = "Enter address1;@";
            this.txtAddress1.UseSystemPasswordChar = true;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(59, 78);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(77, 17);
            this.lblAddress.TabIndex = 16;
            this.lblAddress.Text = "Address :";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(130, 20);
            this.txtCompanyName.MaxLength = 1500;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(466, 24);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.Tag = "Enter Company Name;@";
            // 
            // txtBussinessLine
            // 
            this.txtBussinessLine.Location = new System.Drawing.Point(130, 47);
            this.txtBussinessLine.MaxLength = 2550;
            this.txtBussinessLine.Name = "txtBussinessLine";
            this.txtBussinessLine.Size = new System.Drawing.Size(466, 24);
            this.txtBussinessLine.TabIndex = 2;
            this.txtBussinessLine.Tag = "Enter Bussiness Line;@";
            this.txtBussinessLine.UseSystemPasswordChar = true;
            // 
            // lblBussinessLine
            // 
            this.lblBussinessLine.AutoSize = true;
            this.lblBussinessLine.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBussinessLine.Location = new System.Drawing.Point(13, 51);
            this.lblBussinessLine.Name = "lblBussinessLine";
            this.lblBussinessLine.Size = new System.Drawing.Size(123, 17);
            this.lblBussinessLine.TabIndex = 9;
            this.lblBussinessLine.Text = "Bussiness Line :";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.Location = new System.Drawing.Point(7, 24);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(129, 17);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(612, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 17);
            this.label2.TabIndex = 90;
            this.label2.Text = "*";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnEdit.Location = new System.Drawing.Point(12, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 23);
            this.btnEdit.TabIndex = 91;
            this.btnEdit.Tag = "Click to edit selected Quotation;";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // frmCompany_Detail
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(986, 495);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCompany_Detail";
            this.Load += new System.EventHandler(this.frmGodownEntry_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
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
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtBussinessLine;
        private System.Windows.Forms.Label lblBussinessLine;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.ComboBox cmbState;
        internal System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress2;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.ComboBox cmbCity;
        internal System.Windows.Forms.Label lblPincode;
        internal System.Windows.Forms.TextBox txtPincode;
        internal System.Windows.Forms.Label lblPhone1;
        internal System.Windows.Forms.TextBox txtPhone1;
        internal System.Windows.Forms.TextBox txtPhone2;
        internal System.Windows.Forms.Label lblPhone2;
        internal System.Windows.Forms.Label lblMobile;
        internal System.Windows.Forms.TextBox txtMobile;
        internal System.Windows.Forms.Label lblFax;
        internal System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Button btnBrowseLogo;
        internal System.Windows.Forms.Label lblLogo;
        internal System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Button btnBrowseHeader;
        internal System.Windows.Forms.Label lblHeader;
        internal System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnBrowseFooter;
        internal System.Windows.Forms.Label lblFooter;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.TextBox txtName1;
        internal System.Windows.Forms.TextBox txtName6;
        internal System.Windows.Forms.TextBox txtName5;
        internal System.Windows.Forms.TextBox txtName4;
        internal System.Windows.Forms.TextBox txtName3;
        internal System.Windows.Forms.TextBox txtName2;
        internal System.Windows.Forms.TextBox txtValue1;
        internal System.Windows.Forms.TextBox txtValue6;
        internal System.Windows.Forms.TextBox txtValue5;
        internal System.Windows.Forms.TextBox txtValue4;
        internal System.Windows.Forms.TextBox txtValue3;
        internal System.Windows.Forms.TextBox txtValue2;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnEdit;
    }
}
