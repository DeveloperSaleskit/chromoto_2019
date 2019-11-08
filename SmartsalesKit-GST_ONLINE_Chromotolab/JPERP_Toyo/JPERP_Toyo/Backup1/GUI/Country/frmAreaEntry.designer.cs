namespace Account.GUI.Country
{
    partial class frmAreaEntry
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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.lblrequired = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.ErrArea = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtAreaName = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(306, 223);
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
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(175, 223);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(125, 23);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(21, 223);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(148, 23);
            this.btnSaveContinue.TabIndex = 2;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 5);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(394, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(382, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Controls.Add(this.txtCity);
            this.grpData.Controls.Add(this.lblCity);
            this.grpData.Controls.Add(this.txtState);
            this.grpData.Controls.Add(this.lblState);
            this.grpData.Controls.Add(this.ErrArea);
            this.grpData.Controls.Add(this.txtCountry);
            this.grpData.Controls.Add(this.lblCountry);
            this.grpData.Controls.Add(this.txtAreaName);
            this.grpData.Controls.Add(this.lblArea);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpData.Location = new System.Drawing.Point(12, 62);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(394, 155);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(228, 14);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(97, 94);
            this.txtCity.MaxLength = 50;
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size(220, 21);
            this.txtCity.TabIndex = 6;
            this.txtCity.TabStop = false;
            this.txtCity.Tag = "City name;";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCity.Location = new System.Drawing.Point(56, 97);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(35, 13);
            this.lblCity.TabIndex = 5;
            this.lblCity.Text = "City:";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(97, 67);
            this.txtState.MaxLength = 50;
            this.txtState.Name = "txtState";
            this.txtState.ReadOnly = true;
            this.txtState.Size = new System.Drawing.Size(220, 21);
            this.txtState.TabIndex = 4;
            this.txtState.TabStop = false;
            this.txtState.Tag = "State name;";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblState.Location = new System.Drawing.Point(49, 70);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(42, 13);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "State:";
            // 
            // ErrArea
            // 
            this.ErrArea.AutoSize = true;
            this.ErrArea.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.ErrArea.ForeColor = System.Drawing.Color.Red;
            this.ErrArea.Location = new System.Drawing.Point(320, 126);
            this.ErrArea.Name = "ErrArea";
            this.ErrArea.Size = new System.Drawing.Size(14, 13);
            this.ErrArea.TabIndex = 9;
            this.ErrArea.Text = "*";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(97, 40);
            this.txtCountry.MaxLength = 50;
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.ReadOnly = true;
            this.txtCountry.Size = new System.Drawing.Size(220, 21);
            this.txtCountry.TabIndex = 2;
            this.txtCountry.TabStop = false;
            this.txtCountry.Tag = "Country name;";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblCountry.Location = new System.Drawing.Point(33, 43);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(58, 13);
            this.lblCountry.TabIndex = 1;
            this.lblCountry.Text = "Country:";
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(97, 121);
            this.txtAreaName.MaxLength = 50;
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Size = new System.Drawing.Size(220, 21);
            this.txtAreaName.TabIndex = 8;
            this.txtAreaName.Tag = "Enter area;@";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblArea.Location = new System.Drawing.Point(52, 124);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(39, 13);
            this.lblArea.TabIndex = 7;
            this.lblArea.Text = "Area:";
            // 
            // frmAreaEntry
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(419, 278);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.grpData);
            this.Name = "frmAreaEntry";
            this.Load += new System.EventHandler(this.frmAreaEntry_Load);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
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
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label ErrArea;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtAreaName;
        private System.Windows.Forms.Label lblArea;
    }
}
