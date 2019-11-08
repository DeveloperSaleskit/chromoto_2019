namespace Account.GUI.Country
{
    partial class frmCSCAList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCSCAList));
            this.toolsReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.rptLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpArea = new System.Windows.Forms.GroupBox();
            this.btnDeleteArea = new System.Windows.Forms.Button();
            this.btnEditArea = new System.Windows.Forms.Button();
            this.btnNewArea = new System.Windows.Forms.Button();
            this.lblTotRecArea = new System.Windows.Forms.Label();
            this.dgvArea = new System.Windows.Forms.DataGridView();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCity = new System.Windows.Forms.GroupBox();
            this.btnDeleteCity = new System.Windows.Forms.Button();
            this.btnEditCity = new System.Windows.Forms.Button();
            this.btnNewCity = new System.Windows.Forms.Button();
            this.lblTotRecCity = new System.Windows.Forms.Label();
            this.dgvCity = new System.Windows.Forms.DataGridView();
            this.CityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpState = new System.Windows.Forms.GroupBox();
            this.btnDeleteState = new System.Windows.Forms.Button();
            this.btnEditState = new System.Windows.Forms.Button();
            this.btnNewState = new System.Windows.Forms.Button();
            this.lblTotRecState = new System.Windows.Forms.Label();
            this.dgvState = new System.Windows.Forms.DataGridView();
            this.StateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCountry = new System.Windows.Forms.GroupBox();
            this.btnDeleteCountry = new System.Windows.Forms.Button();
            this.btnEditCountry = new System.Windows.Forms.Button();
            this.btnNewCountry = new System.Windows.Forms.Button();
            this.lblTotRecCountry = new System.Windows.Forms.Label();
            this.dgvCountry = new System.Windows.Forms.DataGridView();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu = new System.Windows.Forms.ToolStripSplitButton();
            this.locationRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.Button();
            this.cmbreports = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).BeginInit();
            this.grpCity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).BeginInit();
            this.grpState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvState)).BeginInit();
            this.grpCountry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolsReports
            // 
            this.toolsReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolsReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rptLocation});
            this.toolsReports.Image = ((System.Drawing.Image)(resources.GetObject("toolsReports.Image")));
            this.toolsReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolsReports.Name = "toolsReports";
            this.toolsReports.Size = new System.Drawing.Size(58, 22);
            this.toolsReports.Tag = "View report;";
            this.toolsReports.Text = "Reports";
            // 
            // rptLocation
            // 
            this.rptLocation.Name = "rptLocation";
            this.rptLocation.Size = new System.Drawing.Size(158, 22);
            this.rptLocation.Text = "Location Report";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(890, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Tag = "Click to close form;";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpArea
            // 
            this.grpArea.Controls.Add(this.btnDeleteArea);
            this.grpArea.Controls.Add(this.btnEditArea);
            this.grpArea.Controls.Add(this.btnNewArea);
            this.grpArea.Controls.Add(this.lblTotRecArea);
            this.grpArea.Controls.Add(this.dgvArea);
            this.grpArea.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpArea.Location = new System.Drawing.Point(442, 283);
            this.grpArea.Name = "grpArea";
            this.grpArea.Size = new System.Drawing.Size(436, 260);
            this.grpArea.TabIndex = 3;
            this.grpArea.TabStop = false;
            this.grpArea.Text = "Area";
            // 
            // btnDeleteArea
            // 
            this.btnDeleteArea.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteArea.Location = new System.Drawing.Point(330, 92);
            this.btnDeleteArea.Name = "btnDeleteArea";
            this.btnDeleteArea.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteArea.TabIndex = 2;
            this.btnDeleteArea.Tag = "Click to delete selected area;";
            this.btnDeleteArea.Text = "Delete";
            this.btnDeleteArea.UseVisualStyleBackColor = true;
            this.btnDeleteArea.Click += new System.EventHandler(this.btnDeleteArea_Click);
            // 
            // btnEditArea
            // 
            this.btnEditArea.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditArea.Location = new System.Drawing.Point(330, 63);
            this.btnEditArea.Name = "btnEditArea";
            this.btnEditArea.Size = new System.Drawing.Size(100, 23);
            this.btnEditArea.TabIndex = 1;
            this.btnEditArea.Tag = "Click to edit selected area;";
            this.btnEditArea.Text = "Edit";
            this.btnEditArea.UseVisualStyleBackColor = true;
            this.btnEditArea.Click += new System.EventHandler(this.btnEditArea_Click);
            // 
            // btnNewArea
            // 
            this.btnNewArea.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewArea.Location = new System.Drawing.Point(330, 34);
            this.btnNewArea.Name = "btnNewArea";
            this.btnNewArea.Size = new System.Drawing.Size(100, 23);
            this.btnNewArea.TabIndex = 0;
            this.btnNewArea.Tag = "Click to add area;";
            this.btnNewArea.Text = "New";
            this.btnNewArea.UseVisualStyleBackColor = true;
            this.btnNewArea.Click += new System.EventHandler(this.btnNewArea_Click);
            // 
            // lblTotRecArea
            // 
            this.lblTotRecArea.AutoSize = true;
            this.lblTotRecArea.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTotRecArea.Location = new System.Drawing.Point(2, 17);
            this.lblTotRecArea.Name = "lblTotRecArea";
            this.lblTotRecArea.Size = new System.Drawing.Size(90, 13);
            this.lblTotRecArea.TabIndex = 3;
            this.lblTotRecArea.Text = "Total Records:";
            this.lblTotRecArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvArea
            // 
            this.dgvArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AreaName,
            this.AreaID});
            this.dgvArea.Location = new System.Drawing.Point(5, 34);
            this.dgvArea.Name = "dgvArea";
            this.dgvArea.RowTemplate.Height = 24;
            this.dgvArea.Size = new System.Drawing.Size(319, 220);
            this.dgvArea.TabIndex = 4;
            this.dgvArea.Tag = "List of area;";
            this.dgvArea.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvArea_CellPainting);
            // 
            // AreaName
            // 
            this.AreaName.HeaderText = "Area";
            this.AreaName.Name = "AreaName";
            // 
            // AreaID
            // 
            this.AreaID.HeaderText = "AreaID";
            this.AreaID.Name = "AreaID";
            this.AreaID.Visible = false;
            // 
            // grpCity
            // 
            this.grpCity.Controls.Add(this.btnDeleteCity);
            this.grpCity.Controls.Add(this.btnEditCity);
            this.grpCity.Controls.Add(this.btnNewCity);
            this.grpCity.Controls.Add(this.lblTotRecCity);
            this.grpCity.Controls.Add(this.dgvCity);
            this.grpCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCity.Location = new System.Drawing.Point(6, 283);
            this.grpCity.Name = "grpCity";
            this.grpCity.Size = new System.Drawing.Size(430, 260);
            this.grpCity.TabIndex = 2;
            this.grpCity.TabStop = false;
            this.grpCity.Text = "City";
            // 
            // btnDeleteCity
            // 
            this.btnDeleteCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCity.Location = new System.Drawing.Point(324, 92);
            this.btnDeleteCity.Name = "btnDeleteCity";
            this.btnDeleteCity.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteCity.TabIndex = 2;
            this.btnDeleteCity.Tag = "Click to delete selected city;";
            this.btnDeleteCity.Text = "Delete";
            this.btnDeleteCity.UseVisualStyleBackColor = true;
            this.btnDeleteCity.Click += new System.EventHandler(this.btnDeleteCity_Click);
            // 
            // btnEditCity
            // 
            this.btnEditCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCity.Location = new System.Drawing.Point(324, 63);
            this.btnEditCity.Name = "btnEditCity";
            this.btnEditCity.Size = new System.Drawing.Size(100, 23);
            this.btnEditCity.TabIndex = 1;
            this.btnEditCity.Tag = "Click to edit selected city;";
            this.btnEditCity.Text = "Edit";
            this.btnEditCity.UseVisualStyleBackColor = true;
            this.btnEditCity.Click += new System.EventHandler(this.btnEditCity_Click);
            // 
            // btnNewCity
            // 
            this.btnNewCity.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCity.Location = new System.Drawing.Point(324, 34);
            this.btnNewCity.Name = "btnNewCity";
            this.btnNewCity.Size = new System.Drawing.Size(100, 23);
            this.btnNewCity.TabIndex = 0;
            this.btnNewCity.Tag = "Click to add city;";
            this.btnNewCity.Text = "New";
            this.btnNewCity.UseVisualStyleBackColor = true;
            this.btnNewCity.Click += new System.EventHandler(this.btnNewCity_Click);
            // 
            // lblTotRecCity
            // 
            this.lblTotRecCity.AutoSize = true;
            this.lblTotRecCity.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTotRecCity.Location = new System.Drawing.Point(2, 17);
            this.lblTotRecCity.Name = "lblTotRecCity";
            this.lblTotRecCity.Size = new System.Drawing.Size(90, 13);
            this.lblTotRecCity.TabIndex = 3;
            this.lblTotRecCity.Text = "Total Records:";
            this.lblTotRecCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCity
            // 
            this.dgvCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CityName,
            this.CityID});
            this.dgvCity.Location = new System.Drawing.Point(5, 34);
            this.dgvCity.Name = "dgvCity";
            this.dgvCity.RowTemplate.Height = 24;
            this.dgvCity.Size = new System.Drawing.Size(313, 220);
            this.dgvCity.TabIndex = 4;
            this.dgvCity.Tag = "List of city;";
            this.dgvCity.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCity_CellPainting);
            this.dgvCity.SelectionChanged += new System.EventHandler(this.dgvCity_SelectionChanged);
            // 
            // CityName
            // 
            this.CityName.HeaderText = "City";
            this.CityName.Name = "CityName";
            // 
            // CityID
            // 
            this.CityID.HeaderText = "CityID";
            this.CityID.Name = "CityID";
            this.CityID.Visible = false;
            // 
            // grpState
            // 
            this.grpState.Controls.Add(this.btnDeleteState);
            this.grpState.Controls.Add(this.btnEditState);
            this.grpState.Controls.Add(this.btnNewState);
            this.grpState.Controls.Add(this.lblTotRecState);
            this.grpState.Controls.Add(this.dgvState);
            this.grpState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpState.Location = new System.Drawing.Point(442, 18);
            this.grpState.Name = "grpState";
            this.grpState.Size = new System.Drawing.Size(436, 264);
            this.grpState.TabIndex = 1;
            this.grpState.TabStop = false;
            this.grpState.Text = "State";
            // 
            // btnDeleteState
            // 
            this.btnDeleteState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteState.Location = new System.Drawing.Point(330, 92);
            this.btnDeleteState.Name = "btnDeleteState";
            this.btnDeleteState.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteState.TabIndex = 2;
            this.btnDeleteState.Tag = "Click to delete selected state;";
            this.btnDeleteState.Text = "Delete";
            this.btnDeleteState.UseVisualStyleBackColor = true;
            this.btnDeleteState.Click += new System.EventHandler(this.btnDeleteState_Click);
            // 
            // btnEditState
            // 
            this.btnEditState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditState.Location = new System.Drawing.Point(330, 63);
            this.btnEditState.Name = "btnEditState";
            this.btnEditState.Size = new System.Drawing.Size(100, 23);
            this.btnEditState.TabIndex = 1;
            this.btnEditState.Tag = "Click to edit selected state;";
            this.btnEditState.Text = "Edit";
            this.btnEditState.UseVisualStyleBackColor = true;
            this.btnEditState.Click += new System.EventHandler(this.btnEditState_Click);
            // 
            // btnNewState
            // 
            this.btnNewState.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewState.Location = new System.Drawing.Point(330, 34);
            this.btnNewState.Name = "btnNewState";
            this.btnNewState.Size = new System.Drawing.Size(100, 23);
            this.btnNewState.TabIndex = 0;
            this.btnNewState.Tag = "Click to add state;";
            this.btnNewState.Text = "New";
            this.btnNewState.UseVisualStyleBackColor = true;
            this.btnNewState.Click += new System.EventHandler(this.btnNewState_Click);
            // 
            // lblTotRecState
            // 
            this.lblTotRecState.AutoSize = true;
            this.lblTotRecState.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTotRecState.Location = new System.Drawing.Point(2, 17);
            this.lblTotRecState.Name = "lblTotRecState";
            this.lblTotRecState.Size = new System.Drawing.Size(90, 13);
            this.lblTotRecState.TabIndex = 3;
            this.lblTotRecState.Text = "Total Records:";
            this.lblTotRecState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvState
            // 
            this.dgvState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StateName,
            this.StateID});
            this.dgvState.Location = new System.Drawing.Point(5, 34);
            this.dgvState.Name = "dgvState";
            this.dgvState.RowTemplate.Height = 24;
            this.dgvState.Size = new System.Drawing.Size(319, 224);
            this.dgvState.TabIndex = 4;
            this.dgvState.Tag = "List of state;";
            this.dgvState.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvState_CellPainting);
            this.dgvState.SelectionChanged += new System.EventHandler(this.dgvState_SelectionChanged);
            // 
            // StateName
            // 
            this.StateName.HeaderText = "State";
            this.StateName.Name = "StateName";
            // 
            // StateID
            // 
            this.StateID.HeaderText = "StateID";
            this.StateID.Name = "StateID";
            this.StateID.Visible = false;
            // 
            // grpCountry
            // 
            this.grpCountry.Controls.Add(this.btnDeleteCountry);
            this.grpCountry.Controls.Add(this.btnEditCountry);
            this.grpCountry.Controls.Add(this.btnNewCountry);
            this.grpCountry.Controls.Add(this.lblTotRecCountry);
            this.grpCountry.Controls.Add(this.dgvCountry);
            this.grpCountry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCountry.Location = new System.Drawing.Point(6, 18);
            this.grpCountry.Name = "grpCountry";
            this.grpCountry.Size = new System.Drawing.Size(430, 264);
            this.grpCountry.TabIndex = 0;
            this.grpCountry.TabStop = false;
            this.grpCountry.Text = "Country";
            // 
            // btnDeleteCountry
            // 
            this.btnDeleteCountry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCountry.Location = new System.Drawing.Point(324, 92);
            this.btnDeleteCountry.Name = "btnDeleteCountry";
            this.btnDeleteCountry.Size = new System.Drawing.Size(100, 23);
            this.btnDeleteCountry.TabIndex = 2;
            this.btnDeleteCountry.Tag = "Click to delete selected country;";
            this.btnDeleteCountry.Text = "Delete";
            this.btnDeleteCountry.UseVisualStyleBackColor = true;
            this.btnDeleteCountry.Click += new System.EventHandler(this.btnDeleteCountry_Click);
            // 
            // btnEditCountry
            // 
            this.btnEditCountry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditCountry.Location = new System.Drawing.Point(324, 63);
            this.btnEditCountry.Name = "btnEditCountry";
            this.btnEditCountry.Size = new System.Drawing.Size(100, 23);
            this.btnEditCountry.TabIndex = 1;
            this.btnEditCountry.Tag = "Click to edit selected country;";
            this.btnEditCountry.Text = "Edit";
            this.btnEditCountry.UseVisualStyleBackColor = true;
            this.btnEditCountry.Click += new System.EventHandler(this.btnEditCountry_Click);
            // 
            // btnNewCountry
            // 
            this.btnNewCountry.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCountry.Location = new System.Drawing.Point(324, 34);
            this.btnNewCountry.Name = "btnNewCountry";
            this.btnNewCountry.Size = new System.Drawing.Size(100, 23);
            this.btnNewCountry.TabIndex = 0;
            this.btnNewCountry.Tag = "Click to add country;";
            this.btnNewCountry.Text = "New";
            this.btnNewCountry.UseVisualStyleBackColor = true;
            this.btnNewCountry.Click += new System.EventHandler(this.btnNewCountry_Click);
            // 
            // lblTotRecCountry
            // 
            this.lblTotRecCountry.AutoSize = true;
            this.lblTotRecCountry.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblTotRecCountry.Location = new System.Drawing.Point(2, 17);
            this.lblTotRecCountry.Name = "lblTotRecCountry";
            this.lblTotRecCountry.Size = new System.Drawing.Size(90, 13);
            this.lblTotRecCountry.TabIndex = 3;
            this.lblTotRecCountry.Text = "Total Records:";
            this.lblTotRecCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCountry
            // 
            this.dgvCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCountry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountryName,
            this.CountryID});
            this.dgvCountry.Location = new System.Drawing.Point(5, 34);
            this.dgvCountry.Name = "dgvCountry";
            this.dgvCountry.RowTemplate.Height = 24;
            this.dgvCountry.Size = new System.Drawing.Size(313, 224);
            this.dgvCountry.TabIndex = 4;
            this.dgvCountry.Tag = "List of country;";
            this.dgvCountry.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCountry_CellPainting);
            this.dgvCountry.SelectionChanged += new System.EventHandler(this.dgvCountry_SelectionChanged);
            // 
            // CountryName
            // 
            this.CountryName.HeaderText = "Country";
            this.CountryName.Name = "CountryName";
            // 
            // CountryID
            // 
            this.CountryID.HeaderText = "CountryID";
            this.CountryID.Name = "CountryID";
            this.CountryID.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(58, 22);
            this.toolStripDropDownButton1.Tag = "View report;";
            this.toolStripDropDownButton1.Text = "Reports";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            this.toolStripMenuItem1.Text = "Location Report";
            // 
            // Menu
            // 
            this.Menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(56, 22);
            this.Menu.Text = "Report";
            // 
            // locationRegisterToolStripMenuItem
            // 
            this.locationRegisterToolStripMenuItem.Name = "locationRegisterToolStripMenuItem";
            this.locationRegisterToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.locationRegisterToolStripMenuItem.Text = "Location Register";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.btnHelp.Location = new System.Drawing.Point(996, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 33;
            this.btnHelp.Tag = "Click to Download Help File of  Customer;";
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // cmbreports
            // 
            this.cmbreports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbreports.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbreports.FormattingEnabled = true;
            this.cmbreports.Location = new System.Drawing.Point(0, 4);
            this.cmbreports.Name = "cmbreports";
            this.cmbreports.Size = new System.Drawing.Size(267, 21);
            this.cmbreports.TabIndex = 41;
            this.cmbreports.Tag = "Select city;@";
            this.cmbreports.SelectedIndexChanged += new System.EventHandler(this.cmbreports_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbreports);
            this.groupBox3.Location = new System.Drawing.Point(15, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(267, 28);
            this.groupBox3.TabIndex = 43;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpCountry);
            this.groupBox1.Controls.Add(this.grpState);
            this.groupBox1.Controls.Add(this.grpCity);
            this.groupBox1.Controls.Add(this.grpArea);
            this.groupBox1.Location = new System.Drawing.Point(15, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(882, 548);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            // 
            // frmCSCAList
            // 
            this.AutoScroll = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(806, 584);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCSCAList";
            this.Text = "Location";
            this.Load += new System.EventHandler(this.frmCSCAList_Load);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnHelp, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.grpArea.ResumeLayout(false);
            this.grpArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArea)).EndInit();
            this.grpCity.ResumeLayout(false);
            this.grpCity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).EndInit();
            this.grpState.ResumeLayout(false);
            this.grpState.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvState)).EndInit();
            this.grpCountry.ResumeLayout(false);
            this.grpCountry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCountry)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripDropDownButton toolsReports;
        private System.Windows.Forms.ToolStripMenuItem rptLocation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpArea;
        private System.Windows.Forms.Button btnDeleteArea;
        private System.Windows.Forms.Button btnEditArea;
        private System.Windows.Forms.Button btnNewArea;
        private System.Windows.Forms.Label lblTotRecArea;
        private System.Windows.Forms.DataGridView dgvArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaID;
        private System.Windows.Forms.GroupBox grpCity;
        private System.Windows.Forms.Button btnDeleteCity;
        private System.Windows.Forms.Button btnEditCity;
        private System.Windows.Forms.Button btnNewCity;
        private System.Windows.Forms.Label lblTotRecCity;
        private System.Windows.Forms.DataGridView dgvCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityID;
        private System.Windows.Forms.GroupBox grpState;
        private System.Windows.Forms.Button btnDeleteState;
        private System.Windows.Forms.Button btnEditState;
        private System.Windows.Forms.Button btnNewState;
        private System.Windows.Forms.Label lblTotRecState;
        private System.Windows.Forms.DataGridView dgvState;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateID;
        private System.Windows.Forms.GroupBox grpCountry;
        private System.Windows.Forms.Button btnDeleteCountry;
        private System.Windows.Forms.Button btnEditCountry;
        private System.Windows.Forms.Button btnNewCountry;
        private System.Windows.Forms.Label lblTotRecCountry;
        private System.Windows.Forms.DataGridView dgvCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryID;
        internal System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSplitButton Menu;
        private System.Windows.Forms.ToolStripMenuItem locationRegisterToolStripMenuItem;
        private System.Windows.Forms.Button btnHelp;
        internal System.Windows.Forms.ComboBox cmbreports;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}
