namespace Account.GUI.ItemParent
{
    partial class frmItemCategoryEntry
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
            this.ErrItemCategory = new System.Windows.Forms.Label();
            this.ErrItemGroup = new System.Windows.Forms.Label();
            this.txtItemCategory = new System.Windows.Forms.TextBox();
            this.cmbItemGroup = new System.Windows.Forms.ComboBox();
            this.lblItemGroup = new System.Windows.Forms.Label();
            this.lblItemCategoryName = new System.Windows.Forms.Label();
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
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(366, 55);
            this.grpErrorZone.TabIndex = 4;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(7, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(347, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.ErrItemCategory);
            this.grpData.Controls.Add(this.ErrItemGroup);
            this.grpData.Controls.Add(this.txtItemCategory);
            this.grpData.Controls.Add(this.cmbItemGroup);
            this.grpData.Controls.Add(this.lblItemGroup);
            this.grpData.Controls.Add(this.lblItemCategoryName);
            this.grpData.Controls.Add(this.lblrequired);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 65);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(366, 95);
            this.grpData.TabIndex = 0;
            this.grpData.TabStop = false;
            // 
            // ErrItemCategory
            // 
            this.ErrItemCategory.AutoSize = true;
            this.ErrItemCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrItemCategory.ForeColor = System.Drawing.Color.Red;
            this.ErrItemCategory.Location = new System.Drawing.Point(339, 42);
            this.ErrItemCategory.Name = "ErrItemCategory";
            this.ErrItemCategory.Size = new System.Drawing.Size(15, 13);
            this.ErrItemCategory.TabIndex = 4;
            this.ErrItemCategory.Text = "*";
            // 
            // ErrItemGroup
            // 
            this.ErrItemGroup.AutoSize = true;
            this.ErrItemGroup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ErrItemGroup.ForeColor = System.Drawing.Color.Red;
            this.ErrItemGroup.Location = new System.Drawing.Point(339, 69);
            this.ErrItemGroup.Name = "ErrItemGroup";
            this.ErrItemGroup.Size = new System.Drawing.Size(15, 13);
            this.ErrItemGroup.TabIndex = 5;
            this.ErrItemGroup.Text = "*";
            // 
            // txtItemCategory
            // 
            this.txtItemCategory.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCategory.Location = new System.Drawing.Point(117, 38);
            this.txtItemCategory.MaxLength = 50;
            this.txtItemCategory.Name = "txtItemCategory";
            this.txtItemCategory.Size = new System.Drawing.Size(219, 21);
            this.txtItemCategory.TabIndex = 1;
            this.txtItemCategory.Tag = "Enter item category;@";
            // 
            // cmbItemGroup
            // 
            this.cmbItemGroup.FormattingEnabled = true;
            this.cmbItemGroup.Location = new System.Drawing.Point(117, 65);
            this.cmbItemGroup.Name = "cmbItemGroup";
            this.cmbItemGroup.Size = new System.Drawing.Size(219, 21);
            this.cmbItemGroup.TabIndex = 3;
            this.cmbItemGroup.Tag = "Select item group;@";
            // 
            // lblItemGroup
            // 
            this.lblItemGroup.AutoSize = true;
            this.lblItemGroup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemGroup.ForeColor = System.Drawing.Color.Black;
            this.lblItemGroup.Location = new System.Drawing.Point(37, 69);
            this.lblItemGroup.Name = "lblItemGroup";
            this.lblItemGroup.Size = new System.Drawing.Size(78, 13);
            this.lblItemGroup.TabIndex = 2;
            this.lblItemGroup.Text = "Item Group:";
            // 
            // lblItemCategoryName
            // 
            this.lblItemCategoryName.AutoSize = true;
            this.lblItemCategoryName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCategoryName.ForeColor = System.Drawing.Color.Black;
            this.lblItemCategoryName.Location = new System.Drawing.Point(19, 42);
            this.lblItemCategoryName.Name = "lblItemCategoryName";
            this.lblItemCategoryName.Size = new System.Drawing.Size(96, 13);
            this.lblItemCategoryName.TabIndex = 0;
            this.lblItemCategoryName.Text = "Item Category:";
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
            this.btnCancel.Location = new System.Drawing.Point(278, 166);
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
            this.btnSaveExit.Location = new System.Drawing.Point(150, 166);
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
            this.btnSaveContinue.Location = new System.Drawing.Point(9, 166);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(135, 23);
            this.btnSaveContinue.TabIndex = 1;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // frmItemCategoryEntry
            // 
            this.AcceptButton = this.btnSaveExit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(389, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Name = "frmItemCategoryEntry";
            this.Load += new System.EventHandler(this.frmItemCategoryEntry_Load);
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
        internal System.Windows.Forms.Label lblItemGroup;
        internal System.Windows.Forms.Label lblItemCategoryName;
        private System.Windows.Forms.Label lblrequired;

        
        private System.Windows.Forms.Label ErrItemCategory;
        private System.Windows.Forms.Label ErrItemGroup; 

        internal System.Windows.Forms.TextBox txtItemCategory;
        private System.Windows.Forms.ComboBox cmbItemGroup;
        
        
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
       
    }
}
