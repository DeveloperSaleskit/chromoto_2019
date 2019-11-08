namespace Account
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Panel2 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ErrPassword = new System.Windows.Forms.Label();
            this.ErrUserName = new System.Windows.Forms.Label();
            this.SignIN = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.PoweredBY = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.BorderS = new System.Windows.Forms.PictureBox();
            this.BorderN = new System.Windows.Forms.PictureBox();
            this.BorderW = new System.Windows.Forms.PictureBox();
            this.BorderE = new System.Windows.Forms.PictureBox();
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorderS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.White;
            this.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel2.Controls.Add(this.txtUserName);
            this.Panel2.Controls.Add(this.txtPassword);
            this.Panel2.Controls.Add(this.lblVersion);
            this.Panel2.Controls.Add(this.btnExit);
            this.Panel2.Controls.Add(this.btnLogin);
            this.Panel2.Controls.Add(this.ErrPassword);
            this.Panel2.Controls.Add(this.ErrUserName);
            this.Panel2.Controls.Add(this.SignIN);
            this.Panel2.Controls.Add(this.lblUserName);
            this.Panel2.Controls.Add(this.lblPassword);
            this.Panel2.Location = new System.Drawing.Point(173, 31);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(287, 140);
            this.Panel2.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(95, 42);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(169, 21);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Tag = "Enter User Name ;@";
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Wingdings 2", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtPassword.ForeColor = System.Drawing.Color.Red;
            this.txtPassword.Location = new System.Drawing.Point(95, 69);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '®';
            this.txtPassword.Size = new System.Drawing.Size(169, 19);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Tag = "Enter Password;@";
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // lblVersion
            // 
            this.lblVersion.BackColor = System.Drawing.Color.LightBlue;
            this.lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Black;
            this.lblVersion.Location = new System.Drawing.Point(163, -1);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(123, 20);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version:";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(189, 107);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Tag = "Exit;";
            this.btnExit.Text = "Quit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(108, 107);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Tag = "Login;";
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ErrPassword
            // 
            this.ErrPassword.AutoSize = true;
            this.ErrPassword.BackColor = System.Drawing.Color.Transparent;
            this.ErrPassword.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrPassword.ForeColor = System.Drawing.Color.Red;
            this.ErrPassword.Location = new System.Drawing.Point(266, 73);
            this.ErrPassword.Name = "ErrPassword";
            this.ErrPassword.Size = new System.Drawing.Size(15, 13);
            this.ErrPassword.TabIndex = 7;
            this.ErrPassword.Text = "*";
            // 
            // ErrUserName
            // 
            this.ErrUserName.AutoSize = true;
            this.ErrUserName.BackColor = System.Drawing.Color.Transparent;
            this.ErrUserName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrUserName.ForeColor = System.Drawing.Color.Red;
            this.ErrUserName.Location = new System.Drawing.Point(266, 46);
            this.ErrUserName.Name = "ErrUserName";
            this.ErrUserName.Size = new System.Drawing.Size(15, 13);
            this.ErrUserName.TabIndex = 4;
            this.ErrUserName.Text = "*";
            // 
            // SignIN
            // 
            this.SignIN.BackColor = System.Drawing.Color.LightBlue;
            this.SignIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SignIN.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIN.ForeColor = System.Drawing.Color.Black;
            this.SignIN.Location = new System.Drawing.Point(-1, -1);
            this.SignIN.Name = "SignIN";
            this.SignIN.Size = new System.Drawing.Size(167, 20);
            this.SignIN.TabIndex = 0;
            this.SignIN.Text = "Sign In";
            this.SignIN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(132)))), ((int)(((byte)(155)))));
            this.lblUserName.Location = new System.Drawing.Point(10, 45);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(82, 13);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(132)))), ((int)(((byte)(155)))));
            this.lblPassword.Location = new System.Drawing.Point(19, 72);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.PoweredBY);
            this.Panel1.ForeColor = System.Drawing.Color.White;
            this.Panel1.Location = new System.Drawing.Point(3, 173);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(457, 25);
            this.Panel1.TabIndex = 1;
            // 
            // PoweredBY
            // 
            this.PoweredBY.AutoSize = true;
            this.PoweredBY.BackColor = System.Drawing.Color.DodgerBlue;
            this.PoweredBY.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PoweredBY.ForeColor = System.Drawing.Color.White;
            this.PoweredBY.Location = new System.Drawing.Point(76, 3);
            this.PoweredBY.Name = "PoweredBY";
            this.PoweredBY.Size = new System.Drawing.Size(317, 16);
            this.PoweredBY.TabIndex = 0;
            this.PoweredBY.Text = "Powered by: JP Infoweb Solutions Pvt. Ltd.";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblFormTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFormTitle.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(3, 3);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(457, 25);
            this.lblFormTitle.TabIndex = 20;
            this.lblFormTitle.Text = "Smart SalesKit";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BorderS
            // 
            this.BorderS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BorderS.Location = new System.Drawing.Point(1, 199);
            this.BorderS.Name = "BorderS";
            this.BorderS.Size = new System.Drawing.Size(462, 1);
            this.BorderS.TabIndex = 25;
            this.BorderS.TabStop = false;
            // 
            // BorderN
            // 
            this.BorderN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderN.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderN.Location = new System.Drawing.Point(1, 0);
            this.BorderN.Name = "BorderN";
            this.BorderN.Size = new System.Drawing.Size(462, 1);
            this.BorderN.TabIndex = 24;
            this.BorderN.TabStop = false;
            // 
            // BorderW
            // 
            this.BorderW.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderW.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderW.Location = new System.Drawing.Point(0, 0);
            this.BorderW.Name = "BorderW";
            this.BorderW.Size = new System.Drawing.Size(1, 200);
            this.BorderW.TabIndex = 22;
            this.BorderW.TabStop = false;
            // 
            // BorderE
            // 
            this.BorderE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderE.Dock = System.Windows.Forms.DockStyle.Right;
            this.BorderE.Location = new System.Drawing.Point(463, 0);
            this.BorderE.Name = "BorderE";
            this.BorderE.Size = new System.Drawing.Size(1, 200);
            this.BorderE.TabIndex = 21;
            this.BorderE.TabStop = false;
            // 
            // pctLogo
            // 
            this.pctLogo.BackColor = System.Drawing.Color.White;
            this.pctLogo.BackgroundImage = global::Account.Properties.Resources._27_INQ_00006_jpLogo;
            this.pctLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctLogo.InitialImage = null;
            this.pctLogo.Location = new System.Drawing.Point(3, 31);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(164, 140);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 19;
            this.pctLogo.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(464, 200);
            this.Controls.Add(this.BorderS);
            this.Controls.Add(this.BorderN);
            this.Controls.Add(this.BorderW);
            this.Controls.Add(this.BorderE);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.pctLogo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BorderS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox pctLogo;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label SignIN;
        internal System.Windows.Forms.Label lblUserName;
        internal System.Windows.Forms.Label lblPassword;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label PoweredBY;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label ErrPassword;
        internal System.Windows.Forms.Label ErrUserName;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.PictureBox BorderE;
        private System.Windows.Forms.PictureBox BorderW;
        private System.Windows.Forms.PictureBox BorderN;
        private System.Windows.Forms.PictureBox BorderS;
    }
}