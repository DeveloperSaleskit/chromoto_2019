namespace Account.GUI.SalesInvoice
{
    partial class frmSalesInvoiceDispatchDetails
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
            this.lblrequired = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveExit = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtShippingAdd = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpRemovalTime = new System.Windows.Forms.DateTimePicker();
            this.dtpIssueTime = new System.Windows.Forms.DateTimePicker();
            this.dtpRemoval = new System.Windows.Forms.DateTimePicker();
            this.dtpIssue = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtDesTh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.lblSourceOfLead = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDespDocNo = new System.Windows.Forms.TextBox();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.txtSupplierOrderNo = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtDelNote = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtBuyerOrderNo = new System.Windows.Forms.TextBox();
            this.grpErrorZone.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(12, 12);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(426, 55);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(26, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(155, 35);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(261, 26);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(331, 410);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(185, 410);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(140, 24);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtShippingAdd);
            this.grpData.Controls.Add(this.label25);
            this.grpData.Controls.Add(this.label26);
            this.grpData.Controls.Add(this.label9);
            this.grpData.Controls.Add(this.dtpRemovalTime);
            this.grpData.Controls.Add(this.dtpIssueTime);
            this.grpData.Controls.Add(this.dtpRemoval);
            this.grpData.Controls.Add(this.dtpIssue);
            this.grpData.Controls.Add(this.label7);
            this.grpData.Controls.Add(this.label6);
            this.grpData.Controls.Add(this.label5);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.txtDestination);
            this.grpData.Controls.Add(this.txtDesTh);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.dtpDeliveryDate);
            this.grpData.Controls.Add(this.dtpOrderDate);
            this.grpData.Controls.Add(this.lblSourceOfLead);
            this.grpData.Controls.Add(this.label8);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtDespDocNo);
            this.grpData.Controls.Add(this.lblPhone1);
            this.grpData.Controls.Add(this.txtSupplierOrderNo);
            this.grpData.Controls.Add(this.lblAddress1);
            this.grpData.Controls.Add(this.txtDelNote);
            this.grpData.Controls.Add(this.lblCompanyName);
            this.grpData.Controls.Add(this.txtBuyerOrderNo);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(12, 73);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(426, 331);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtShippingAdd
            // 
            this.txtShippingAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShippingAdd.Location = new System.Drawing.Point(166, 294);
            this.txtShippingAdd.Name = "txtShippingAdd";
            this.txtShippingAdd.Size = new System.Drawing.Size(238, 21);
            this.txtShippingAdd.TabIndex = 302;
            this.txtShippingAdd.Tag = "Enter Shipping Address;";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(99, 292);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 13);
            this.label25.TabIndex = 300;
            this.label25.Text = "Shipping";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(98, 306);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 13);
            this.label26.TabIndex = 301;
            this.label26.Text = "Address:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(72, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 128;
            this.label9.Text = "&& Vehical No.:";
            // 
            // dtpRemovalTime
            // 
            this.dtpRemovalTime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.dtpRemovalTime.CustomFormat = "hh:mm:ss tt";
            this.dtpRemovalTime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpRemovalTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRemovalTime.Location = new System.Drawing.Point(261, 267);
            this.dtpRemovalTime.Name = "dtpRemovalTime";
            this.dtpRemovalTime.ShowUpDown = true;
            this.dtpRemovalTime.Size = new System.Drawing.Size(95, 21);
            this.dtpRemovalTime.TabIndex = 127;
            this.dtpRemovalTime.Tag = "Select Removal time;@";
            this.dtpRemovalTime.Value = new System.DateTime(2014, 6, 5, 17, 55, 0, 0);
            // 
            // dtpIssueTime
            // 
            this.dtpIssueTime.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.dtpIssueTime.CustomFormat = "hh:mm:ss tt";
            this.dtpIssueTime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpIssueTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueTime.Location = new System.Drawing.Point(261, 235);
            this.dtpIssueTime.Name = "dtpIssueTime";
            this.dtpIssueTime.ShowUpDown = true;
            this.dtpIssueTime.Size = new System.Drawing.Size(123, 21);
            this.dtpIssueTime.TabIndex = 126;
            this.dtpIssueTime.Tag = "Select Issue time;@";
            this.dtpIssueTime.Value = new System.DateTime(2015, 1, 12, 17, 55, 0, 0);
            // 
            // dtpRemoval
            // 
            this.dtpRemoval.CustomFormat = "";
            this.dtpRemoval.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpRemoval.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRemoval.Location = new System.Drawing.Point(166, 267);
            this.dtpRemoval.Name = "dtpRemoval";
            this.dtpRemoval.Size = new System.Drawing.Size(89, 21);
            this.dtpRemoval.TabIndex = 99;
            this.dtpRemoval.Tag = "Select Date for Removal of Goods;";
            // 
            // dtpIssue
            // 
            this.dtpIssue.CustomFormat = "";
            this.dtpIssue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIssue.Location = new System.Drawing.Point(166, 235);
            this.dtpIssue.Name = "dtpIssue";
            this.dtpIssue.Size = new System.Drawing.Size(89, 21);
            this.dtpIssue.TabIndex = 98;
            this.dtpIssue.Tag = "Select Issue date;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label7.Location = new System.Drawing.Point(10, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 97;
            this.label7.Text = "Date && Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label6.Location = new System.Drawing.Point(10, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 96;
            this.label6.Text = "Date && Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(43, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 95;
            this.label5.Text = "of issue of Invoice:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label4.Location = new System.Drawing.Point(26, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 94;
            this.label4.Text = "of Removal of Goods:";
            // 
            // txtDestination
            // 
            this.txtDestination.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestination.Location = new System.Drawing.Point(166, 207);
            this.txtDestination.MaxLength = 50;
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(238, 21);
            this.txtDestination.TabIndex = 93;
            this.txtDestination.Tag = "Enter Destination;";
            // 
            // txtDesTh
            // 
            this.txtDesTh.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesTh.Location = new System.Drawing.Point(166, 180);
            this.txtDesTh.MaxLength = 50;
            this.txtDesTh.Name = "txtDesTh";
            this.txtDesTh.Size = new System.Drawing.Size(238, 21);
            this.txtDesTh.TabIndex = 92;
            this.txtDesTh.Tag = "Enter Despatched Through;";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Despatch Document No.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(69, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "Delivery Date:";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.CustomFormat = "";
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(166, 98);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(89, 21);
            this.dtpDeliveryDate.TabIndex = 89;
            this.dtpDeliveryDate.Tag = "Select Delivery date;";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.CustomFormat = "";
            this.dtpOrderDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderDate.Location = new System.Drawing.Point(166, 44);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(89, 21);
            this.dtpOrderDate.TabIndex = 88;
            this.dtpOrderDate.Tag = "Select Order date;";
            // 
            // lblSourceOfLead
            // 
            this.lblSourceOfLead.AutoSize = true;
            this.lblSourceOfLead.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceOfLead.ForeColor = System.Drawing.Color.Black;
            this.lblSourceOfLead.Location = new System.Drawing.Point(70, 74);
            this.lblSourceOfLead.Name = "lblSourceOfLead";
            this.lblSourceOfLead.Size = new System.Drawing.Size(90, 13);
            this.lblSourceOfLead.TabIndex = 87;
            this.lblSourceOfLead.Text = "Delivery Note:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label8.Location = new System.Drawing.Point(84, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 85;
            this.label8.Text = "Destination:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Despatched through";
            // 
            // txtDespDocNo
            // 
            this.txtDespDocNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDespDocNo.Location = new System.Drawing.Point(166, 153);
            this.txtDespDocNo.MaxLength = 50;
            this.txtDespDocNo.Name = "txtDespDocNo";
            this.txtDespDocNo.Size = new System.Drawing.Size(238, 21);
            this.txtDespDocNo.TabIndex = 82;
            this.txtDespDocNo.Tag = "Enter Despatch Document No.;";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.ForeColor = System.Drawing.Color.Black;
            this.lblPhone1.Location = new System.Drawing.Point(4, 129);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(156, 13);
            this.lblPhone1.TabIndex = 16;
            this.lblPhone1.Text = "Supplier\'s Ref./Order No.:";
            // 
            // txtSupplierOrderNo
            // 
            this.txtSupplierOrderNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierOrderNo.Location = new System.Drawing.Point(166, 126);
            this.txtSupplierOrderNo.MaxLength = 20;
            this.txtSupplierOrderNo.Name = "txtSupplierOrderNo";
            this.txtSupplierOrderNo.Size = new System.Drawing.Size(238, 21);
            this.txtSupplierOrderNo.TabIndex = 2;
            this.txtSupplierOrderNo.Tag = "Enter Supplier\'s Ref./Order No.;";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1.ForeColor = System.Drawing.Color.Black;
            this.lblAddress1.Location = new System.Drawing.Point(84, 48);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(76, 13);
            this.lblAddress1.TabIndex = 7;
            this.lblAddress1.Text = "Order Date:";
            // 
            // txtDelNote
            // 
            this.txtDelNote.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelNote.Location = new System.Drawing.Point(166, 71);
            this.txtDelNote.MaxLength = 100;
            this.txtDelNote.Name = "txtDelNote";
            this.txtDelNote.Size = new System.Drawing.Size(238, 21);
            this.txtDelNote.TabIndex = 1;
            this.txtDelNote.Tag = "Enter Delivery Note;";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyName.Location = new System.Drawing.Point(45, 20);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(115, 13);
            this.lblCompanyName.TabIndex = 4;
            this.lblCompanyName.Text = "Buyer\'s Order No.:";
            // 
            // txtBuyerOrderNo
            // 
            this.txtBuyerOrderNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuyerOrderNo.Location = new System.Drawing.Point(166, 17);
            this.txtBuyerOrderNo.MaxLength = 100;
            this.txtBuyerOrderNo.Name = "txtBuyerOrderNo";
            this.txtBuyerOrderNo.Size = new System.Drawing.Size(238, 21);
            this.txtBuyerOrderNo.TabIndex = 0;
            this.txtBuyerOrderNo.Tag = "Enter Order No.;";
            // 
            // frmSalesInvoiceDispatchDetails
            // 
            this.AcceptButton = this.btnSaveExit;
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 466);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSalesInvoiceDispatchDetails";
            this.Load += new System.EventHandler(this.frmEmployeeEntry_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.Label lblAddress1;
        internal System.Windows.Forms.TextBox txtDelNote;
        internal System.Windows.Forms.Label lblrequired;
        internal System.Windows.Forms.Label lblCompanyName;
        internal System.Windows.Forms.TextBox txtBuyerOrderNo;
        internal System.Windows.Forms.Label lblPhone1;
        internal System.Windows.Forms.TextBox txtSupplierOrderNo;
        internal System.Windows.Forms.Label lblSourceOfLead;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtDespDocNo;
        internal System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        internal System.Windows.Forms.DateTimePicker dtpOrderDate;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtDestination;
        internal System.Windows.Forms.TextBox txtDesTh;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.DateTimePicker dtpRemoval;
        internal System.Windows.Forms.DateTimePicker dtpIssue;
        internal System.Windows.Forms.DateTimePicker dtpRemovalTime;
        internal System.Windows.Forms.DateTimePicker dtpIssueTime;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtShippingAdd;
        internal System.Windows.Forms.Label label25;
        internal System.Windows.Forms.Label label26;
    }
}
