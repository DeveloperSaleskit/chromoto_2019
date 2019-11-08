namespace Account.GUI.ContactPerson
{
    partial class frmContactPerson
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.dgvContactPerson = new System.Windows.Forms.DataGridView();
            this.ContactID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpErrorZone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(665, 491);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(534, 491);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(125, 23);
            this.btnSaveExit.TabIndex = 1;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 4);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(753, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(724, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvContactPerson
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContactPerson.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContactPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContactID,
            this.ContactTitle,
            this.ContactName,
            this.Designation,
            this.Phone1,
            this.Phone2,
            this.Mobile,
            this.Email,
            this.DoB,
            this.DoA});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContactPerson.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContactPerson.Location = new System.Drawing.Point(12, 67);
            this.dgvContactPerson.Name = "dgvContactPerson";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContactPerson.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvContactPerson.Size = new System.Drawing.Size(753, 418);
            this.dgvContactPerson.TabIndex = 0;
            this.dgvContactPerson.Tag = "List of contact person;";
            this.dgvContactPerson.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactPerson_CellValidated);
            this.dgvContactPerson.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactPerson_CellEndEdit);
            this.dgvContactPerson.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvContactPerson_CellPainting);
            this.dgvContactPerson.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvContactPerson_EditingControlShowing);
            this.dgvContactPerson.CurrentCellChanged += new System.EventHandler(this.dgvContactPerson_CurrentCellChanged);
            this.dgvContactPerson.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvContactPerson_DataError);
            this.dgvContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvContactPersonl_KeyDown);
            // 
            // ContactID
            // 
            this.ContactID.HeaderText = "ContactID";
            this.ContactID.Name = "ContactID";
            this.ContactID.Visible = false;
            // 
            // ContactTitle
            // 
            this.ContactTitle.HeaderText = "Contact Title";
            this.ContactTitle.MaxInputLength = 10;
            this.ContactTitle.Name = "ContactTitle";
            // 
            // ContactName
            // 
            this.ContactName.HeaderText = "Contact Name";
            this.ContactName.MaxInputLength = 50;
            this.ContactName.Name = "ContactName";
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Designation";
            this.Designation.MaxInputLength = 50;
            this.Designation.Name = "Designation";
            // 
            // Phone1
            // 
            this.Phone1.HeaderText = "Phone 1";
            this.Phone1.MaxInputLength = 20;
            this.Phone1.Name = "Phone1";
            // 
            // Phone2
            // 
            this.Phone2.HeaderText = "Phone 2";
            this.Phone2.MaxInputLength = 20;
            this.Phone2.Name = "Phone2";
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.MaxInputLength = 20;
            this.Mobile.Name = "Mobile";
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MaxInputLength = 50;
            this.Email.Name = "Email";
            // 
            // DoB
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.DoB.DefaultCellStyle = dataGridViewCellStyle2;
            this.DoB.HeaderText = "Birth Date";
            this.DoB.MaxInputLength = 10;
            this.DoB.Name = "DoB";
            // 
            // DoA
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.DoA.DefaultCellStyle = dataGridViewCellStyle3;
            this.DoA.HeaderText = "Anniversary Date";
            this.DoA.MaxInputLength = 10;
            this.DoA.Name = "DoA";
            // 
            // frmContactPerson
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(777, 545);
            this.Controls.Add(this.dgvContactPerson);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveExit);
            this.Name = "frmContactPerson";
            this.Load += new System.EventHandler(this.frmContactPerson_Load);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.dgvContactPerson, 0);
            this.grpErrorZone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactPerson)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.DataGridView dgvContactPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoA;
    }
}
