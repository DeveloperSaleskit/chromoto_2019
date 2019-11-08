namespace Account.GUI.ItemParent
{
    partial class frmUOMEntry
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
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.ErrAbbreviation = new System.Windows.Forms.Label();
            this.ErrUOM = new System.Windows.Forms.Label();
            this.txtUOMName = new System.Windows.Forms.TextBox();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.lblAbbreviation = new System.Windows.Forms.Label();
            this.lblUOMName = new System.Windows.Forms.Label();
            this.lblrequired = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.btnSaveContinue = new System.Windows.Forms.Button();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 6);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(380, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(367, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrAbbreviation);
            this.grpData.Controls.Add(this.ErrUOM);
            this.grpData.Controls.Add(this.txtUOMName);
            this.grpData.Controls.Add(this.txtAbbreviation);
            this.grpData.Controls.Add(this.lblAbbreviation);
            this.grpData.Controls.Add(this.lblUOMName);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 67);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(380, 95);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // ErrAbbreviation
            // 
            this.ErrAbbreviation.AutoSize = true;
            this.ErrAbbreviation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrAbbreviation.ForeColor = System.Drawing.Color.Red;
            this.ErrAbbreviation.Location = new System.Drawing.Point(246, 69);
            this.ErrAbbreviation.Name = "ErrAbbreviation";
            this.ErrAbbreviation.Size = new System.Drawing.Size(15, 13);
            this.ErrAbbreviation.TabIndex = 5;
            this.ErrAbbreviation.Text = "*";
            // 
            // ErrUOM
            // 
            this.ErrUOM.AutoSize = true;
            this.ErrUOM.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrUOM.ForeColor = System.Drawing.Color.Red;
            this.ErrUOM.Location = new System.Drawing.Point(339, 42);
            this.ErrUOM.Name = "ErrUOM";
            this.ErrUOM.Size = new System.Drawing.Size(15, 13);
            this.ErrUOM.TabIndex = 2;
            this.ErrUOM.Text = "*";
            // 
            // txtUOMName
            // 
            this.txtUOMName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUOMName.Location = new System.Drawing.Point(110, 38);
            this.txtUOMName.MaxLength = 50;
            this.txtUOMName.Name = "txtUOMName";
            this.txtUOMName.Size = new System.Drawing.Size(226, 21);
            this.txtUOMName.TabIndex = 0;
            this.txtUOMName.Tag = "Enter uom;@";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbbreviation.Location = new System.Drawing.Point(110, 65);
            this.txtAbbreviation.MaxLength = 5;
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(133, 21);
            this.txtAbbreviation.TabIndex = 3;
            this.txtAbbreviation.Tag = "Enter abbreviation;@";
            // 
            // lblAbbreviation
            // 
            this.lblAbbreviation.AutoSize = true;
            this.lblAbbreviation.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbbreviation.ForeColor = System.Drawing.Color.Black;
            this.lblAbbreviation.Location = new System.Drawing.Point(23, 69);
            this.lblAbbreviation.Name = "lblAbbreviation";
            this.lblAbbreviation.Size = new System.Drawing.Size(84, 13);
            this.lblAbbreviation.TabIndex = 3;
            this.lblAbbreviation.Text = "Abbreviation:";
            // 
            // lblUOMName
            // 
            this.lblUOMName.AutoSize = true;
            this.lblUOMName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUOMName.ForeColor = System.Drawing.Color.Black;
            this.lblUOMName.Location = new System.Drawing.Point(69, 42);
            this.lblUOMName.Name = "lblUOMName";
            this.lblUOMName.Size = new System.Drawing.Size(38, 13);
            this.lblUOMName.TabIndex = 0;
            this.lblUOMName.Text = "UOM:";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(209, 17);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(127, 13);
            this.lblrequired.TabIndex = 6;
            this.lblrequired.Text = "* - Required fields";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(292, 168);
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
            this.btnSaveExit.Location = new System.Drawing.Point(169, 168);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(117, 23);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(14, 168);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(149, 23);
            this.btnSaveContinue.TabIndex = 2;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // frmUOMEntry
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 222);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnSaveContinue);
            this.Name = "frmUOMEntry";
            this.Load += new System.EventHandler(this.frmUOMEntry_Load);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Label ErrAbbreviation;
        private System.Windows.Forms.Label ErrUOM;
       
        internal System.Windows.Forms.TextBox txtUOMName;
        internal System.Windows.Forms.TextBox txtAbbreviation;

        internal System.Windows.Forms.Label lblAbbreviation;
        internal System.Windows.Forms.Label lblUOMName;
        private System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
    }
}
