namespace Account.GUI.ItemParent
{
    partial class frmItemClassEntry
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
            this.ErrItemClassDescription = new System.Windows.Forms.Label();
            this.ErrItemClass = new System.Windows.Forms.Label();
            this.txtItemClass = new System.Windows.Forms.TextBox();
            this.txtItemClassDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblItemClass = new System.Windows.Forms.Label();
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
            this.grpErrorZone.Location = new System.Drawing.Point(12, 3);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(410, 55);
            this.grpErrorZone.TabIndex = 4;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(397, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrItemClassDescription);
            this.grpData.Controls.Add(this.ErrItemClass);
            this.grpData.Controls.Add(this.txtItemClass);
            this.grpData.Controls.Add(this.txtItemClassDescription);
            this.grpData.Controls.Add(this.lblDescription);
            this.grpData.Controls.Add(this.lblItemClass);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 64);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(410, 95);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // ErrItemClassDescription
            // 
            this.ErrItemClassDescription.AutoSize = true;
            this.ErrItemClassDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrItemClassDescription.ForeColor = System.Drawing.Color.Red;
            this.ErrItemClassDescription.Location = new System.Drawing.Point(386, 70);
            this.ErrItemClassDescription.Name = "ErrItemClassDescription";
            this.ErrItemClassDescription.Size = new System.Drawing.Size(15, 13);
            this.ErrItemClassDescription.TabIndex = 5;
            this.ErrItemClassDescription.Text = "*";
            // 
            // ErrItemClass
            // 
            this.ErrItemClass.AutoSize = true;
            this.ErrItemClass.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrItemClass.ForeColor = System.Drawing.Color.Red;
            this.ErrItemClass.Location = new System.Drawing.Point(386, 42);
            this.ErrItemClass.Name = "ErrItemClass";
            this.ErrItemClass.Size = new System.Drawing.Size(15, 13);
            this.ErrItemClass.TabIndex = 2;
            this.ErrItemClass.Text = "*";
            // 
            // txtItemClass
            // 
            this.txtItemClass.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemClass.Location = new System.Drawing.Point(98, 38);
            this.txtItemClass.MaxLength = 50;
            this.txtItemClass.Name = "txtItemClass";
            this.txtItemClass.Size = new System.Drawing.Size(285, 21);
            this.txtItemClass.TabIndex = 1;
            this.txtItemClass.Tag = "Enter item class;@";
            // 
            // txtItemClassDescription
            // 
            this.txtItemClassDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemClassDescription.Location = new System.Drawing.Point(98, 65);
            this.txtItemClassDescription.MaxLength = 50;
            this.txtItemClassDescription.Name = "txtItemClassDescription";
            this.txtItemClassDescription.Size = new System.Drawing.Size(285, 21);
            this.txtItemClassDescription.TabIndex = 4;
            this.txtItemClassDescription.Tag = "Enter item class description;@";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(19, 69);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(76, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // lblItemClass
            // 
            this.lblItemClass.AutoSize = true;
            this.lblItemClass.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemClass.ForeColor = System.Drawing.Color.Black;
            this.lblItemClass.Location = new System.Drawing.Point(52, 42);
            this.lblItemClass.Name = "lblItemClass";
            this.lblItemClass.Size = new System.Drawing.Size(43, 13);
            this.lblItemClass.TabIndex = 0;
            this.lblItemClass.Text = "Class:";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(277, 17);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(127, 13);
            this.lblrequired.TabIndex = 6;
            this.lblrequired.Text = "* - Required fields";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(321, 165);
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
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(193, 165);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(122, 23);
            this.btnSaveExit.TabIndex = 2;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(41, 165);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(146, 23);
            this.btnSaveContinue.TabIndex = 1;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // frmItemClassEntry
            // 
            this.AcceptButton = this.btnSaveExit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(433, 222);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmItemClassEntry";
            this.Load += new System.EventHandler(this.frmItemClassEntry_Load);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
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

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.Label lblItemClass;
        internal System.Windows.Forms.Label lblDescription;

        internal System.Windows.Forms.TextBox txtItemClass;
        internal System.Windows.Forms.TextBox txtItemClassDescription;
        
        private System.Windows.Forms.Label ErrItemClassDescription;
        private System.Windows.Forms.Label ErrItemClass;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
    }
}
