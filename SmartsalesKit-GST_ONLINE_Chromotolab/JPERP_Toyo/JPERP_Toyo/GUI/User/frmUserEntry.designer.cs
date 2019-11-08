namespace Account.GUI.Users
{
    partial class frmUserEntry
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
            this.lblrequired = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.panelIsByUser = new System.Windows.Forms.Panel();
            this.chksend = new System.Windows.Forms.CheckBox();
            this.gbPortSSL = new System.Windows.Forms.GroupBox();
            this.cmbHost = new System.Windows.Forms.ComboBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblSSL = new System.Windows.Forms.Label();
            this.txtSSL = new System.Windows.Forms.TextBox();
            this.gbUserEmailDetail = new System.Windows.Forms.GroupBox();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbCompMailDetail = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbUserLoginDetail = new System.Windows.Forms.GroupBox();
            this.lblEmpName = new System.Windows.Forms.Label();
            this.cmbEmpName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbComp = new System.Windows.Forms.ComboBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.ErrUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.ErrPassword = new System.Windows.Forms.Label();
            this.ErrConfirmPassword = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.ErrName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPrivi = new System.Windows.Forms.GroupBox();
            this.trvUserPrivilieges = new System.Windows.Forms.TreeView();
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.panelIsByUser.SuspendLayout();
            this.gbPortSSL.SuspendLayout();
            this.gbUserEmailDetail.SuspendLayout();
            this.gbCompMailDetail.SuspendLayout();
            this.gbUserLoginDetail.SuspendLayout();
            this.grpPrivi.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(259, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveExit.Location = new System.Drawing.Point(139, 406);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(111, 23);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveContinue.Location = new System.Drawing.Point(16, 406);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(119, 23);
            this.btnSaveContinue.TabIndex = 2;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(890, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(739, 17);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(112, 13);
            this.lblrequired.TabIndex = 12;
            this.lblrequired.Text = "* - Required fields";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(857, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.panelIsByUser);
            this.grpData.Controls.Add(this.gbPortSSL);
            this.grpData.Controls.Add(this.gbUserEmailDetail);
            this.grpData.Controls.Add(this.gbCompMailDetail);
            this.grpData.Controls.Add(this.gbUserLoginDetail);
            this.grpData.Controls.Add(this.grpPrivi);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(15, 63);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(887, 335);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // panelIsByUser
            // 
            this.panelIsByUser.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelIsByUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIsByUser.Controls.Add(this.chksend);
            this.panelIsByUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelIsByUser.Location = new System.Drawing.Point(362, 148);
            this.panelIsByUser.Name = "panelIsByUser";
            this.panelIsByUser.Size = new System.Drawing.Size(171, 68);
            this.panelIsByUser.TabIndex = 226;
            this.panelIsByUser.Tag = "Select next followup date;";
            // 
            // chksend
            // 
            this.chksend.AutoSize = true;
            this.chksend.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksend.Location = new System.Drawing.Point(5, 20);
            this.chksend.Name = "chksend";
            this.chksend.Size = new System.Drawing.Size(158, 17);
            this.chksend.TabIndex = 27;
            this.chksend.Tag = "Send Email;";
            this.chksend.Text = "Send E-mail By User";
            this.chksend.UseVisualStyleBackColor = true;
            this.chksend.CheckedChanged += new System.EventHandler(this.chksend_CheckedChanged);
            this.chksend.Click += new System.EventHandler(this.chksend_Click);
            this.chksend.Leave += new System.EventHandler(this.chksend_Leave);
            // 
            // gbPortSSL
            // 
            this.gbPortSSL.Controls.Add(this.cmbHost);
            this.gbPortSSL.Controls.Add(this.lblHost);
            this.gbPortSSL.Controls.Add(this.lblPort);
            this.gbPortSSL.Controls.Add(this.txtPort);
            this.gbPortSSL.Controls.Add(this.lblSSL);
            this.gbPortSSL.Controls.Add(this.txtSSL);
            this.gbPortSSL.Location = new System.Drawing.Point(368, 237);
            this.gbPortSSL.Name = "gbPortSSL";
            this.gbPortSSL.Size = new System.Drawing.Size(168, 90);
            this.gbPortSSL.TabIndex = 27;
            this.gbPortSSL.TabStop = false;
            this.gbPortSSL.Text = "Other Detail";
            // 
            // cmbHost
            // 
            this.cmbHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHost.FormattingEnabled = true;
            this.cmbHost.Location = new System.Drawing.Point(45, 29);
            this.cmbHost.Name = "cmbHost";
            this.cmbHost.Size = new System.Drawing.Size(106, 21);
            this.cmbHost.TabIndex = 91;
            this.cmbHost.Tag = "Select Host;";
            this.cmbHost.SelectedIndexChanged += new System.EventHandler(this.cmbHost_SelectedIndexChanged);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.ForeColor = System.Drawing.Color.Black;
            this.lblHost.Location = new System.Drawing.Point(5, 33);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(37, 13);
            this.lblHost.TabIndex = 90;
            this.lblHost.Text = "Host:";
            this.lblHost.Click += new System.EventHandler(this.lblHost_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(3, 58);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(39, 13);
            this.lblPort.TabIndex = 92;
            this.lblPort.Text = "Port :";
            this.lblPort.Click += new System.EventHandler(this.lblPort_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtPort.Location = new System.Drawing.Point(45, 55);
            this.txtPort.MaxLength = 12;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(43, 21);
            this.txtPort.TabIndex = 93;
            this.txtPort.Tag = "Enter Port;";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // lblSSL
            // 
            this.lblSSL.AutoSize = true;
            this.lblSSL.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSL.Location = new System.Drawing.Point(89, 58);
            this.lblSSL.Name = "lblSSL";
            this.lblSSL.Size = new System.Drawing.Size(38, 13);
            this.lblSSL.TabIndex = 94;
            this.lblSSL.Text = "SSL :";
            this.lblSSL.Click += new System.EventHandler(this.lblSSL_Click);
            // 
            // txtSSL
            // 
            this.txtSSL.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSSL.Location = new System.Drawing.Point(128, 55);
            this.txtSSL.MaxLength = 12;
            this.txtSSL.Name = "txtSSL";
            this.txtSSL.Size = new System.Drawing.Size(21, 21);
            this.txtSSL.TabIndex = 95;
            this.txtSSL.Tag = "Enter SSL;";
            this.txtSSL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSSL.TextChanged += new System.EventHandler(this.txtSSL_TextChanged);
            // 
            // gbUserEmailDetail
            // 
            this.gbUserEmailDetail.Controls.Add(this.txtUserEmail);
            this.gbUserEmailDetail.Controls.Add(this.label11);
            this.gbUserEmailDetail.Controls.Add(this.txtNPassword);
            this.gbUserEmailDetail.Controls.Add(this.label4);
            this.gbUserEmailDetail.Location = new System.Drawing.Point(6, 237);
            this.gbUserEmailDetail.Name = "gbUserEmailDetail";
            this.gbUserEmailDetail.Size = new System.Drawing.Size(353, 90);
            this.gbUserEmailDetail.TabIndex = 106;
            this.gbUserEmailDetail.TabStop = false;
            this.gbUserEmailDetail.Text = "User Email Details";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserEmail.Location = new System.Drawing.Point(124, 29);
            this.txtUserEmail.MaxLength = 1500;
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(219, 20);
            this.txtUserEmail.TabIndex = 103;
            this.txtUserEmail.Tag = "Enter EMail ID;";
            this.txtUserEmail.TextChanged += new System.EventHandler(this.txtUserEmail_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(55, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 102;
            this.label11.Text = "Email ID :";
            // 
            // txtNPassword
            // 
            this.txtNPassword.Location = new System.Drawing.Point(124, 55);
            this.txtNPassword.MaxLength = 2550;
            this.txtNPassword.Name = "txtNPassword";
            this.txtNPassword.Size = new System.Drawing.Size(219, 21);
            this.txtNPassword.TabIndex = 23;
            this.txtNPassword.Tag = "Enter New Password;";
            this.txtNPassword.UseSystemPasswordChar = true;
            this.txtNPassword.TextChanged += new System.EventHandler(this.txtNPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Password :";
            // 
            // gbCompMailDetail
            // 
            this.gbCompMailDetail.Controls.Add(this.label5);
            this.gbCompMailDetail.Controls.Add(this.txtEmailId);
            this.gbCompMailDetail.Controls.Add(this.label2);
            this.gbCompMailDetail.Controls.Add(this.txtCPassword);
            this.gbCompMailDetail.Controls.Add(this.label3);
            this.gbCompMailDetail.Location = new System.Drawing.Point(6, 142);
            this.gbCompMailDetail.Name = "gbCompMailDetail";
            this.gbCompMailDetail.Size = new System.Drawing.Size(353, 74);
            this.gbCompMailDetail.TabIndex = 105;
            this.gbCompMailDetail.TabStop = false;
            this.gbCompMailDetail.Text = "Company Email Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(25, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Mail Password :";
            // 
            // txtEmailId
            // 
            this.txtEmailId.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailId.Location = new System.Drawing.Point(124, 17);
            this.txtEmailId.MaxLength = 1500;
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(219, 20);
            this.txtEmailId.TabIndex = 19;
            this.txtEmailId.Tag = "Enter EMail ID;@";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Email ID :";
            // 
            // txtCPassword
            // 
            this.txtCPassword.Location = new System.Drawing.Point(124, 40);
            this.txtCPassword.MaxLength = 2550;
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.Size = new System.Drawing.Size(219, 21);
            this.txtCPassword.TabIndex = 21;
            this.txtCPassword.Tag = "Enter Current Password;";
            this.txtCPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(70, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Current";
            // 
            // gbUserLoginDetail
            // 
            this.gbUserLoginDetail.Controls.Add(this.lblEmpName);
            this.gbUserLoginDetail.Controls.Add(this.cmbEmpName);
            this.gbUserLoginDetail.Controls.Add(this.label6);
            this.gbUserLoginDetail.Controls.Add(this.cmbComp);
            this.gbUserLoginDetail.Controls.Add(this.lblUserName);
            this.gbUserLoginDetail.Controls.Add(this.ErrUserName);
            this.gbUserLoginDetail.Controls.Add(this.lblPassword);
            this.gbUserLoginDetail.Controls.Add(this.ErrPassword);
            this.gbUserLoginDetail.Controls.Add(this.ErrConfirmPassword);
            this.gbUserLoginDetail.Controls.Add(this.lblConfirmPassword);
            this.gbUserLoginDetail.Controls.Add(this.txtConfirmPassword);
            this.gbUserLoginDetail.Controls.Add(this.txtPassword);
            this.gbUserLoginDetail.Controls.Add(this.txtUserName);
            this.gbUserLoginDetail.Controls.Add(this.ErrName);
            this.gbUserLoginDetail.Controls.Add(this.label1);
            this.gbUserLoginDetail.Location = new System.Drawing.Point(6, 11);
            this.gbUserLoginDetail.Name = "gbUserLoginDetail";
            this.gbUserLoginDetail.Size = new System.Drawing.Size(527, 125);
            this.gbUserLoginDetail.TabIndex = 27;
            this.gbUserLoginDetail.TabStop = false;
            this.gbUserLoginDetail.Text = "User Login Details";
            // 
            // lblEmpName
            // 
            this.lblEmpName.AutoSize = true;
            this.lblEmpName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpName.Location = new System.Drawing.Point(308, 53);
            this.lblEmpName.Name = "lblEmpName";
            this.lblEmpName.Size = new System.Drawing.Size(45, 13);
            this.lblEmpName.TabIndex = 20;
            this.lblEmpName.Text = "Name:";
            // 
            // cmbEmpName
            // 
            this.cmbEmpName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpName.FormattingEnabled = true;
            this.cmbEmpName.Items.AddRange(new object[] {
            "New Paper Advertise",
            "Hoarding",
            "Radio Adversie",
            "Website",
            "Exhibition",
            "Inter Net Advertise",
            "Reference",
            "Other"});
            this.cmbEmpName.Location = new System.Drawing.Point(362, 50);
            this.cmbEmpName.Name = "cmbEmpName";
            this.cmbEmpName.Size = new System.Drawing.Size(155, 21);
            this.cmbEmpName.TabIndex = 19;
            this.cmbEmpName.Tag = "Select source of Company;@";
            this.cmbEmpName.SelectedIndexChanged += new System.EventHandler(this.cmbEmpName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label6.Location = new System.Drawing.Point(287, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Password:";
            // 
            // cmbComp
            // 
            this.cmbComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComp.FormattingEnabled = true;
            this.cmbComp.Items.AddRange(new object[] {
            "New Paper Advertise",
            "Hoarding",
            "Radio Adversie",
            "Website",
            "Exhibition",
            "Inter Net Advertise",
            "Reference",
            "Other"});
            this.cmbComp.Location = new System.Drawing.Point(124, 20);
            this.cmbComp.Name = "cmbComp";
            this.cmbComp.Size = new System.Drawing.Size(393, 21);
            this.cmbComp.TabIndex = 17;
            this.cmbComp.Tag = "Select source of Company;@";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(46, 50);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(75, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name:";
            // 
            // ErrUserName
            // 
            this.ErrUserName.AutoSize = true;
            this.ErrUserName.ForeColor = System.Drawing.Color.Red;
            this.ErrUserName.Location = new System.Drawing.Point(106, 43);
            this.ErrUserName.Name = "ErrUserName";
            this.ErrUserName.Size = new System.Drawing.Size(15, 13);
            this.ErrUserName.TabIndex = 2;
            this.ErrUserName.Text = "*";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(55, 84);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // ErrPassword
            // 
            this.ErrPassword.AutoSize = true;
            this.ErrPassword.ForeColor = System.Drawing.Color.Red;
            this.ErrPassword.Location = new System.Drawing.Point(106, 76);
            this.ErrPassword.Name = "ErrPassword";
            this.ErrPassword.Size = new System.Drawing.Size(15, 13);
            this.ErrPassword.TabIndex = 5;
            this.ErrPassword.Text = "*";
            // 
            // ErrConfirmPassword
            // 
            this.ErrConfirmPassword.AutoSize = true;
            this.ErrConfirmPassword.ForeColor = System.Drawing.Color.Red;
            this.ErrConfirmPassword.Location = new System.Drawing.Point(338, 67);
            this.ErrConfirmPassword.Name = "ErrConfirmPassword";
            this.ErrConfirmPassword.Size = new System.Drawing.Size(15, 13);
            this.ErrConfirmPassword.TabIndex = 8;
            this.ErrConfirmPassword.Text = "*";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(300, 75);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(53, 13);
            this.lblConfirmPassword.TabIndex = 6;
            this.lblConfirmPassword.Text = "Confirm";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(362, 80);
            this.txtConfirmPassword.MaxLength = 20;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(155, 21);
            this.txtConfirmPassword.TabIndex = 2;
            this.txtConfirmPassword.Tag = "Enter confirm password;@";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(124, 80);
            this.txtPassword.MaxLength = 20;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(157, 21);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Tag = "Enter password;@";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(124, 47);
            this.txtUserName.MaxLength = 20;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(157, 21);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.Tag = "Enter user name;@";
            // 
            // ErrName
            // 
            this.ErrName.AutoSize = true;
            this.ErrName.ForeColor = System.Drawing.Color.Red;
            this.ErrName.Location = new System.Drawing.Point(338, 44);
            this.ErrName.Name = "ErrName";
            this.ErrName.Size = new System.Drawing.Size(15, 13);
            this.ErrName.TabIndex = 11;
            this.ErrName.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Company:";
            // 
            // grpPrivi
            // 
            this.grpPrivi.Controls.Add(this.trvUserPrivilieges);
            this.grpPrivi.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpPrivi.Location = new System.Drawing.Point(551, 11);
            this.grpPrivi.Name = "grpPrivi";
            this.grpPrivi.Size = new System.Drawing.Size(330, 319);
            this.grpPrivi.TabIndex = 104;
            this.grpPrivi.TabStop = false;
            this.grpPrivi.Tag = "j;";
            this.grpPrivi.Text = "User Privilieges";
            // 
            // trvUserPrivilieges
            // 
            this.trvUserPrivilieges.CheckBoxes = true;
            this.trvUserPrivilieges.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvUserPrivilieges.Location = new System.Drawing.Point(6, 20);
            this.trvUserPrivilieges.Name = "trvUserPrivilieges";
            this.trvUserPrivilieges.Size = new System.Drawing.Size(318, 293);
            this.trvUserPrivilieges.TabIndex = 0;
            this.trvUserPrivilieges.Tag = "List of user privilieges;";
            this.trvUserPrivilieges.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvUserPrivilieges_NodeMouseClick);
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(506, 404);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(210, 26);
            this.lblDelMsg.TabIndex = 19;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // frmUserEntry
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(914, 475);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.lblDelMsg);
            this.Name = "frmUserEntry";
            this.Load += new System.EventHandler(this.frmUserEntry_Load);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.panelIsByUser.ResumeLayout(false);
            this.panelIsByUser.PerformLayout();
            this.gbPortSSL.ResumeLayout(false);
            this.gbPortSSL.PerformLayout();
            this.gbUserEmailDetail.ResumeLayout(false);
            this.gbUserEmailDetail.PerformLayout();
            this.gbCompMailDetail.ResumeLayout(false);
            this.gbCompMailDetail.PerformLayout();
            this.gbUserLoginDetail.ResumeLayout(false);
            this.gbUserLoginDetail.PerformLayout();
            this.grpPrivi.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Label ErrConfirmPassword;        
        private System.Windows.Forms.Label ErrPassword;       
        private System.Windows.Forms.Label ErrUserName;
        private System.Windows.Forms.Label lblDelMsg;

        private System.Windows.Forms.Label ErrName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNPassword;
        internal System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.ComboBox cmbHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblSSL;
        private System.Windows.Forms.TextBox txtSSL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.CheckBox chksend;
        internal System.Windows.Forms.GroupBox grpPrivi;
        internal System.Windows.Forms.TreeView trvUserPrivilieges;
        private System.Windows.Forms.GroupBox gbCompMailDetail;
        private System.Windows.Forms.GroupBox gbUserLoginDetail;
        private System.Windows.Forms.GroupBox gbUserEmailDetail;
        private System.Windows.Forms.GroupBox gbPortSSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelIsByUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEmpName;
        private System.Windows.Forms.ComboBox cmbEmpName;
    }
}
