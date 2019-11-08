namespace Account.GUI.PurchaseIndentRequest
{
    partial class frmPurchaseIndentEntry
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
            this.lblDelMsg = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtstatusPo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtpurchaseindent = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtitemused = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtapproxtotalcoast = new System.Windows.Forms.TextBox();
            this.txtapproxunitprie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtstockinhand = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtqtyinstock = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtproductcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCountry = new System.Windows.Forms.DataGridView();
            this.OpenFile = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BlockId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteDoc = new System.Windows.Forms.Button();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.lblPICheck = new System.Windows.Forms.Label();
            this.txtqtyreqd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtitemcode = new System.Windows.Forms.TextBox();
            this.txtitemdetails = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPhone1 = new System.Windows.Forms.Label();
            this.dtpLeadDate = new System.Windows.Forms.DateTimePicker();
            this.lblInquiryDate = new System.Windows.Forms.Label();
            this.btnRegenrate = new System.Windows.Forms.Button();
            this.lblInquiryNo = new System.Windows.Forms.Label();
            this.txtLeadNo = new System.Windows.Forms.TextBox();
            this.lblrequired = new System.Windows.Forms.Label();
            this.grpErrorZone = new System.Windows.Forms.GroupBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.grpData.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            this.grpErrorZone.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(517, 524);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Tag = "Click to cancel operation;";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveExit
            // 
            this.btnSaveExit.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveExit.Location = new System.Drawing.Point(373, 524);
            this.btnSaveExit.Name = "btnSaveExit";
            this.btnSaveExit.Size = new System.Drawing.Size(138, 24);
            this.btnSaveExit.TabIndex = 3;
            this.btnSaveExit.Tag = "Click to save && exit;";
            this.btnSaveExit.Text = "Save && Exit";
            this.btnSaveExit.UseVisualStyleBackColor = true;
            this.btnSaveExit.Click += new System.EventHandler(this.btnSaveExit_Click);
            // 
            // btnSaveContinue
            // 
            this.btnSaveContinue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnSaveContinue.Location = new System.Drawing.Point(214, 524);
            this.btnSaveContinue.Name = "btnSaveContinue";
            this.btnSaveContinue.Size = new System.Drawing.Size(153, 24);
            this.btnSaveContinue.TabIndex = 2;
            this.btnSaveContinue.Tag = "Click to save && continue;";
            this.btnSaveContinue.Text = "Save && Continue";
            this.btnSaveContinue.UseVisualStyleBackColor = true;
            this.btnSaveContinue.Click += new System.EventHandler(this.btnSaveContinue_Click);
            // 
            // lblDelMsg
            // 
            this.lblDelMsg.AutoSize = true;
            this.lblDelMsg.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblDelMsg.ForeColor = System.Drawing.Color.Red;
            this.lblDelMsg.Location = new System.Drawing.Point(13, 524);
            this.lblDelMsg.Name = "lblDelMsg";
            this.lblDelMsg.Size = new System.Drawing.Size(185, 26);
            this.lblDelMsg.TabIndex = 2;
            this.lblDelMsg.Text = "You are going to delete record.\r\nAre you sure?\r\n";
            this.lblDelMsg.Visible = false;
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.txtremarks);
            this.grpData.Controls.Add(this.label12);
            this.grpData.Controls.Add(this.txtstatusPo);
            this.grpData.Controls.Add(this.label11);
            this.grpData.Controls.Add(this.txtpurchaseindent);
            this.grpData.Controls.Add(this.label10);
            this.grpData.Controls.Add(this.txtitemused);
            this.grpData.Controls.Add(this.label6);
            this.grpData.Controls.Add(this.label5);
            this.grpData.Controls.Add(this.txtapproxtotalcoast);
            this.grpData.Controls.Add(this.txtapproxunitprie);
            this.grpData.Controls.Add(this.label3);
            this.grpData.Controls.Add(this.label2);
            this.grpData.Controls.Add(this.txtstockinhand);
            this.grpData.Controls.Add(this.label9);
            this.grpData.Controls.Add(this.txtqtyinstock);
            this.grpData.Controls.Add(this.label8);
            this.grpData.Controls.Add(this.txtproductcode);
            this.grpData.Controls.Add(this.label7);
            this.grpData.Controls.Add(this.groupBox3);
            this.grpData.Controls.Add(this.txtqtyreqd);
            this.grpData.Controls.Add(this.label1);
            this.grpData.Controls.Add(this.txtitemcode);
            this.grpData.Controls.Add(this.txtitemdetails);
            this.grpData.Controls.Add(this.label4);
            this.grpData.Controls.Add(this.lblPhone1);
            this.grpData.Controls.Add(this.dtpLeadDate);
            this.grpData.Controls.Add(this.lblInquiryDate);
            this.grpData.Controls.Add(this.btnRegenrate);
            this.grpData.Controls.Add(this.lblInquiryNo);
            this.grpData.Controls.Add(this.txtLeadNo);
            this.grpData.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpData.Location = new System.Drawing.Point(7, 43);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(651, 475);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            // 
            // txtremarks
            // 
            this.txtremarks.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremarks.Location = new System.Drawing.Point(181, 278);
            this.txtremarks.MaxLength = 4000;
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtremarks.Size = new System.Drawing.Size(455, 28);
            this.txtremarks.TabIndex = 244;
            this.txtremarks.Tag = "Enter specification;";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(17, 291);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 243;
            this.label12.Text = "Remarks/Narration";
            // 
            // txtstatusPo
            // 
            this.txtstatusPo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstatusPo.Location = new System.Drawing.Point(181, 251);
            this.txtstatusPo.MaxLength = 50;
            this.txtstatusPo.Name = "txtstatusPo";
            this.txtstatusPo.Size = new System.Drawing.Size(455, 21);
            this.txtstatusPo.TabIndex = 242;
            this.txtstatusPo.Tag = "Enter Mobile No;";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(17, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 13);
            this.label11.TabIndex = 241;
            this.label11.Text = "Status PO released/Not";
            // 
            // txtpurchaseindent
            // 
            this.txtpurchaseindent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpurchaseindent.Location = new System.Drawing.Point(181, 221);
            this.txtpurchaseindent.MaxLength = 50;
            this.txtpurchaseindent.Name = "txtpurchaseindent";
            this.txtpurchaseindent.Size = new System.Drawing.Size(455, 21);
            this.txtpurchaseindent.TabIndex = 239;
            this.txtpurchaseindent.Tag = "Enter Mobile No;";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(17, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 26);
            this.label10.TabIndex = 240;
            this.label10.Text = "Purchase Indent\r\nRequest By";
            // 
            // txtitemused
            // 
            this.txtitemused.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemused.Location = new System.Drawing.Point(181, 187);
            this.txtitemused.MaxLength = 50;
            this.txtitemused.Name = "txtitemused";
            this.txtitemused.Size = new System.Drawing.Size(455, 21);
            this.txtitemused.TabIndex = 237;
            this.txtitemused.Tag = "Enter Mobile No;";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 26);
            this.label6.TabIndex = 238;
            this.label6.Text = "Item Used \r\nFor Job No/ Client Po";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label5.Location = new System.Drawing.Point(370, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 26);
            this.label5.TabIndex = 236;
            this.label5.Text = "Approx Total\r\nCost";
            // 
            // txtapproxtotalcoast
            // 
            this.txtapproxtotalcoast.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapproxtotalcoast.Location = new System.Drawing.Point(475, 158);
            this.txtapproxtotalcoast.MaxLength = 20;
            this.txtapproxtotalcoast.Name = "txtapproxtotalcoast";
            this.txtapproxtotalcoast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtapproxtotalcoast.Size = new System.Drawing.Size(161, 21);
            this.txtapproxtotalcoast.TabIndex = 234;
            this.txtapproxtotalcoast.Tag = "Enter Budget;";
            this.txtapproxtotalcoast.Text = "0";
            // 
            // txtapproxunitprie
            // 
            this.txtapproxunitprie.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtapproxunitprie.Location = new System.Drawing.Point(183, 154);
            this.txtapproxunitprie.MaxLength = 20;
            this.txtapproxunitprie.Name = "txtapproxunitprie";
            this.txtapproxunitprie.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtapproxunitprie.Size = new System.Drawing.Size(154, 21);
            this.txtapproxunitprie.TabIndex = 233;
            this.txtapproxunitprie.Tag = "Enter Budget;";
            this.txtapproxunitprie.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label3.Location = new System.Drawing.Point(20, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 232;
            this.label3.Text = "Approx Unit Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label2.Location = new System.Drawing.Point(35, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 231;
            // 
            // txtstockinhand
            // 
            this.txtstockinhand.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtstockinhand.Location = new System.Drawing.Point(475, 97);
            this.txtstockinhand.MaxLength = 20;
            this.txtstockinhand.Name = "txtstockinhand";
            this.txtstockinhand.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtstockinhand.Size = new System.Drawing.Size(160, 21);
            this.txtstockinhand.TabIndex = 230;
            this.txtstockinhand.Tag = "Enter Budget;";
            this.txtstockinhand.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label9.Location = new System.Drawing.Point(370, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 229;
            this.label9.Text = "Stock In Hand";
            // 
            // txtqtyinstock
            // 
            this.txtqtyinstock.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqtyinstock.Location = new System.Drawing.Point(183, 96);
            this.txtqtyinstock.MaxLength = 20;
            this.txtqtyinstock.Name = "txtqtyinstock";
            this.txtqtyinstock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtqtyinstock.Size = new System.Drawing.Size(154, 21);
            this.txtqtyinstock.TabIndex = 228;
            this.txtqtyinstock.Tag = "Enter Budget;";
            this.txtqtyinstock.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label8.Location = new System.Drawing.Point(20, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 227;
            this.label8.Text = "Qty in Stock";
            // 
            // txtproductcode
            // 
            this.txtproductcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductcode.Location = new System.Drawing.Point(475, 42);
            this.txtproductcode.MaxLength = 50;
            this.txtproductcode.Name = "txtproductcode";
            this.txtproductcode.Size = new System.Drawing.Size(161, 21);
            this.txtproductcode.TabIndex = 225;
            this.txtproductcode.Tag = "Enter Mobile No;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(370, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 226;
            this.label7.Text = "ProductCode:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvCountry);
            this.groupBox3.Controls.Add(this.btnDeleteDoc);
            this.groupBox3.Controls.Add(this.btnAddDoc);
            this.groupBox3.Controls.Add(this.btnBrowse);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtDocName);
            this.groupBox3.Controls.Add(this.lblPICheck);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(17, 326);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(619, 130);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Document Details";
            // 
            // dgvCountry
            // 
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OpenFile,
            this.BlockId,
            this.QDocID,
            this.FileName,
            this.FullFileName});
            this.dgvCountry.Location = new System.Drawing.Point(6, 38);
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.RowTemplate.Height = 24;
            this.dgvCountry.Size = new System.Drawing.Size(533, 86);
            this.dgvCountry.TabIndex = 2;
            this.dgvCountry.Tag = "List of document;";
            this.dgvCountry.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCountry_CellClick);
            // 
            // OpenFile
            // 
            this.OpenFile.HeaderText = "View File";
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Text = "Open File";
            // 
            // BlockId
            // 
            this.BlockId.HeaderText = "BlockId";
            this.BlockId.Name = "BlockId";
            this.BlockId.Visible = false;
            // 
            // QDocID
            // 
            this.QDocID.HeaderText = "DocID";
            this.QDocID.Name = "QDocID";
            this.QDocID.Visible = false;
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            // 
            // FullFileName
            // 
            this.FullFileName.HeaderText = "FullFileName";
            this.FullFileName.Name = "FullFileName";
            this.FullFileName.Visible = false;
            // 
            // btnDeleteDoc
            // 
            this.btnDeleteDoc.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnDeleteDoc.Location = new System.Drawing.Point(555, 93);
            this.btnDeleteDoc.Name = "btnDeleteDoc";
            this.btnDeleteDoc.Size = new System.Drawing.Size(60, 24);
            this.btnDeleteDoc.TabIndex = 4;
            this.btnDeleteDoc.Tag = "Click to Delete;";
            this.btnDeleteDoc.Text = "Delete";
            this.btnDeleteDoc.UseVisualStyleBackColor = true;
            this.btnDeleteDoc.Click += new System.EventHandler(this.btnDeleteDoc_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnAddDoc.Location = new System.Drawing.Point(555, 63);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(60, 24);
            this.btnAddDoc.TabIndex = 3;
            this.btnAddDoc.Tag = "Click to Add;";
            this.btnAddDoc.Text = "Add";
            this.btnAddDoc.UseVisualStyleBackColor = true;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnBrowse.Location = new System.Drawing.Point(555, 37);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(60, 24);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Tag = "Click to browse;";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(1, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 13);
            this.label20.TabIndex = 215;
            this.label20.Text = "File:";
            // 
            // txtDocName
            // 
            this.txtDocName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocName.Location = new System.Drawing.Point(35, 14);
            this.txtDocName.MaxLength = 100;
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.ReadOnly = true;
            this.txtDocName.Size = new System.Drawing.Size(504, 21);
            this.txtDocName.TabIndex = 0;
            this.txtDocName.Tag = "Select Document;";
            // 
            // lblPICheck
            // 
            this.lblPICheck.AutoSize = true;
            this.lblPICheck.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblPICheck.Location = new System.Drawing.Point(3, 43);
            this.lblPICheck.Name = "lblPICheck";
            this.lblPICheck.Size = new System.Drawing.Size(55, 13);
            this.lblPICheck.TabIndex = 210;
            this.lblPICheck.Text = "PICheck";
            this.lblPICheck.Visible = false;
            // 
            // txtqtyreqd
            // 
            this.txtqtyreqd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtqtyreqd.Location = new System.Drawing.Point(183, 123);
            this.txtqtyreqd.MaxLength = 20;
            this.txtqtyreqd.Name = "txtqtyreqd";
            this.txtqtyreqd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtqtyreqd.Size = new System.Drawing.Size(154, 21);
            this.txtqtyreqd.TabIndex = 2;
            this.txtqtyreqd.Tag = "Enter Budget;";
            this.txtqtyreqd.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.label1.Location = new System.Drawing.Point(20, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Qty reqd.";
            // 
            // txtitemcode
            // 
            this.txtitemcode.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemcode.Location = new System.Drawing.Point(183, 41);
            this.txtitemcode.MaxLength = 50;
            this.txtitemcode.Name = "txtitemcode";
            this.txtitemcode.Size = new System.Drawing.Size(154, 21);
            this.txtitemcode.TabIndex = 17;
            this.txtitemcode.Tag = "Enter Mobile No;";
            // 
            // txtitemdetails
            // 
            this.txtitemdetails.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtitemdetails.Location = new System.Drawing.Point(184, 69);
            this.txtitemdetails.MaxLength = 4000;
            this.txtitemdetails.Multiline = true;
            this.txtitemdetails.Name = "txtitemdetails";
            this.txtitemdetails.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtitemdetails.Size = new System.Drawing.Size(451, 22);
            this.txtitemdetails.TabIndex = 5;
            this.txtitemdetails.Tag = "Enter specification;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Item Details";
            // 
            // lblPhone1
            // 
            this.lblPhone1.AutoSize = true;
            this.lblPhone1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone1.ForeColor = System.Drawing.Color.Black;
            this.lblPhone1.Location = new System.Drawing.Point(20, 45);
            this.lblPhone1.Name = "lblPhone1";
            this.lblPhone1.Size = new System.Drawing.Size(69, 13);
            this.lblPhone1.TabIndex = 35;
            this.lblPhone1.Text = "ItemCode:";
            // 
            // dtpLeadDate
            // 
            this.dtpLeadDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.dtpLeadDate.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeadDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLeadDate.Location = new System.Drawing.Point(476, 16);
            this.dtpLeadDate.Name = "dtpLeadDate";
            this.dtpLeadDate.Size = new System.Drawing.Size(156, 21);
            this.dtpLeadDate.TabIndex = 2;
            this.dtpLeadDate.Tag = "Select Inquiry date;@";
            this.dtpLeadDate.Value = new System.DateTime(2014, 1, 2, 0, 0, 0, 0);
            // 
            // lblInquiryDate
            // 
            this.lblInquiryDate.AutoSize = true;
            this.lblInquiryDate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblInquiryDate.Location = new System.Drawing.Point(363, 18);
            this.lblInquiryDate.Name = "lblInquiryDate";
            this.lblInquiryDate.Size = new System.Drawing.Size(95, 13);
            this.lblInquiryDate.TabIndex = 2;
            this.lblInquiryDate.Text = "Date of Indent:";
            // 
            // btnRegenrate
            // 
            this.btnRegenrate.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnRegenrate.Location = new System.Drawing.Point(316, 12);
            this.btnRegenrate.Name = "btnRegenrate";
            this.btnRegenrate.Size = new System.Drawing.Size(34, 23);
            this.btnRegenrate.TabIndex = 1;
            this.btnRegenrate.TabStop = false;
            this.btnRegenrate.Tag = "Click to re-generate Inquiry no;";
            this.btnRegenrate.Text = "Re-Generate";
            this.btnRegenrate.UseVisualStyleBackColor = true;
            this.btnRegenrate.Click += new System.EventHandler(this.btnRegenrate_Click);
            // 
            // lblInquiryNo
            // 
            this.lblInquiryNo.AutoSize = true;
            this.lblInquiryNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInquiryNo.Location = new System.Drawing.Point(20, 18);
            this.lblInquiryNo.Name = "lblInquiryNo";
            this.lblInquiryNo.Size = new System.Drawing.Size(44, 13);
            this.lblInquiryNo.TabIndex = 0;
            this.lblInquiryNo.Text = "Sr No:";
            // 
            // txtLeadNo
            // 
            this.txtLeadNo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeadNo.Location = new System.Drawing.Point(184, 14);
            this.txtLeadNo.MaxLength = 20;
            this.txtLeadNo.Name = "txtLeadNo";
            this.txtLeadNo.ReadOnly = true;
            this.txtLeadNo.Size = new System.Drawing.Size(120, 21);
            this.txtLeadNo.TabIndex = 0;
            this.txtLeadNo.TabStop = false;
            this.txtLeadNo.Tag = "Inquiry No;@";
            // 
            // lblrequired
            // 
            this.lblrequired.AutoSize = true;
            this.lblrequired.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblrequired.ForeColor = System.Drawing.Color.Red;
            this.lblrequired.Location = new System.Drawing.Point(519, 15);
            this.lblrequired.Name = "lblrequired";
            this.lblrequired.Size = new System.Drawing.Size(114, 13);
            this.lblrequired.TabIndex = 0;
            this.lblrequired.Text = "* - Required Fields";
            this.lblrequired.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpErrorZone
            // 
            this.grpErrorZone.Controls.Add(this.lblErrorMessage);
            this.grpErrorZone.Controls.Add(this.lblrequired);
            this.grpErrorZone.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpErrorZone.Location = new System.Drawing.Point(7, 3);
            this.grpErrorZone.Name = "grpErrorZone";
            this.grpErrorZone.Size = new System.Drawing.Size(651, 38);
            this.grpErrorZone.TabIndex = 0;
            this.grpErrorZone.TabStop = false;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(6, 15);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(498, 19);
            this.lblErrorMessage.TabIndex = 0;
            this.lblErrorMessage.Text = "No error";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPurchaseIndentEntry
            // 
            this.AutoScroll = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(674, 584);
            this.Controls.Add(this.lblDelMsg);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpErrorZone);
            this.Controls.Add(this.btnSaveExit);
            this.Controls.Add(this.btnSaveContinue);
            this.Controls.Add(this.btnCancel);
            this.Name = "frmPurchaseIndentEntry";
            this.Text = "Inquiry";
            this.Load += new System.EventHandler(this.frmPurchaseIndentEntry_Load);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnSaveContinue, 0);
            this.Controls.SetChildIndex(this.btnSaveExit, 0);
            this.Controls.SetChildIndex(this.grpErrorZone, 0);
            this.Controls.SetChildIndex(this.grpData, 0);
            this.Controls.SetChildIndex(this.lblDelMsg, 0);
            this.grpData.ResumeLayout(false);
            this.grpData.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            this.grpErrorZone.ResumeLayout(false);
            this.grpErrorZone.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveExit;
        private System.Windows.Forms.Button btnSaveContinue;
        private System.Windows.Forms.Label lblDelMsg;
        internal System.Windows.Forms.GroupBox grpData;
        internal System.Windows.Forms.Label lblrequired;
        private System.Windows.Forms.GroupBox grpErrorZone;
        private System.Windows.Forms.Label lblErrorMessage;
        internal System.Windows.Forms.DateTimePicker dtpLeadDate;
        internal System.Windows.Forms.Label lblInquiryDate;
        private System.Windows.Forms.Button btnRegenrate;
        internal System.Windows.Forms.Label lblInquiryNo;
        internal System.Windows.Forms.TextBox txtLeadNo;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtitemdetails;
        internal System.Windows.Forms.Label lblPhone1;
        internal System.Windows.Forms.TextBox txtqtyreqd;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCountry;
        private System.Windows.Forms.DataGridViewButtonColumn OpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn BlockId;
        private System.Windows.Forms.DataGridViewTextBoxColumn QDocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullFileName;
        private System.Windows.Forms.Button btnDeleteDoc;
        private System.Windows.Forms.Button btnAddDoc;
        private System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtDocName;
        internal System.Windows.Forms.Label lblPICheck;
        public System.Windows.Forms.TextBox txtitemcode;
        public System.Windows.Forms.TextBox txtproductcode;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtqtyinstock;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtstockinhand;
        internal System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtitemused;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtapproxtotalcoast;
        internal System.Windows.Forms.TextBox txtapproxunitprie;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtremarks;
        internal System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtstatusPo;
        internal System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtpurchaseindent;
        internal System.Windows.Forms.Label label10;
    }
}
