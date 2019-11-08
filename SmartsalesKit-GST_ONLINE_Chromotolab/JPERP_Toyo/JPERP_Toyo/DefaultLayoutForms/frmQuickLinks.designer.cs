namespace Account.DefaultLayout
{
    partial class frmQuickLinks
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mr. Manoj Savalia");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Mr. Hardik Jani");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mr. Ankur Shah");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Mrs. Roshni Patel");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Purchase", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Ms. R. V.");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Mr. Rohit Patel");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Mr. Nirav Shah");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Sales", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Mr. Patel Krunal");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Customer Payment", new System.Windows.Forms.TreeNode[] {
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Mr.");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Vendor Payment", new System.Windows.Forms.TreeNode[] {
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Account");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageIndex = 10;
            treeNode1.Name = "Node5";
            treeNode1.Text = "Mr. Manoj Savalia";
            treeNode2.ImageIndex = 10;
            treeNode2.Name = "Node6";
            treeNode2.Text = "Mr. Hardik Jani";
            treeNode3.ImageIndex = 10;
            treeNode3.Name = "Node7";
            treeNode3.Text = "Mr. Ankur Shah";
            treeNode4.ImageIndex = 10;
            treeNode4.Name = "Node8";
            treeNode4.Text = "Mrs. Roshni Patel";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Purchase";
            treeNode6.ImageIndex = 8;
            treeNode6.Name = "Node10";
            treeNode6.Text = "Ms. R. V.";
            treeNode7.ImageIndex = 8;
            treeNode7.Name = "Node11";
            treeNode7.Text = "Mr. Rohit Patel";
            treeNode8.ImageIndex = 8;
            treeNode8.Name = "Node13";
            treeNode8.Text = "Mr. Nirav Shah";
            treeNode9.ImageIndex = 2;
            treeNode9.Name = "Node1";
            treeNode9.Text = "Sales";
            treeNode10.ImageIndex = 1;
            treeNode10.Name = "Node14";
            treeNode10.Text = "Mr. Patel Krunal";
            treeNode11.ImageIndex = 6;
            treeNode11.Name = "Node2";
            treeNode11.Text = "Customer Payment";
            treeNode12.Name = "Node1";
            treeNode12.Text = "Mr.";
            treeNode13.Name = "Node0";
            treeNode13.Text = "Vendor Payment";
            treeNode14.Name = "Node2";
            treeNode14.Text = "Account";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode9,
            treeNode11,
            treeNode13,
            treeNode14});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(284, 262);
            this.treeView1.TabIndex = 4;
            // 
            // frmQuickLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.treeView1);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmQuickLinks";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
            this.Text = "My Quick Links";
            this.Load += new System.EventHandler(this.frmQuickLinks_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}