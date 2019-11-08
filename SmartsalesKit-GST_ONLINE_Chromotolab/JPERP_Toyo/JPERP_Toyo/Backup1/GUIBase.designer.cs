namespace Account
{
    partial class GUIBase
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
            this.MsgBar = new System.Windows.Forms.ToolStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripLabel();
            this.borderW = new System.Windows.Forms.PictureBox();
            this.borderE = new System.Windows.Forms.PictureBox();
            this.borderS = new System.Windows.Forms.PictureBox();
            this.BorderT = new System.Windows.Forms.PictureBox();
            this.MsgBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderT)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgBar
            // 
            this.MsgBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(236)))), ((int)(((byte)(225)))));
            this.MsgBar.BackgroundImage = global::Account.Properties.Resources.Button_Gray_Stripe_01_050;
            this.MsgBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MsgBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MsgBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MsgBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.MsgBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MsgBar.Location = new System.Drawing.Point(0, 376);
            this.MsgBar.Name = "MsgBar";
            this.MsgBar.Size = new System.Drawing.Size(587, 25);
            this.MsgBar.TabIndex = 19;
            this.MsgBar.Text = "ToolStrip1";
            // 
            // lblMsg
            // 
            this.lblMsg.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 22);
            // 
            // borderW
            // 
            this.borderW.BackColor = System.Drawing.Color.Black;
            this.borderW.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.borderW.Dock = System.Windows.Forms.DockStyle.Left;
            this.borderW.Location = new System.Drawing.Point(0, 1);
            this.borderW.Name = "borderW";
            this.borderW.Size = new System.Drawing.Size(1, 374);
            this.borderW.TabIndex = 21;
            this.borderW.TabStop = false;
            // 
            // borderE
            // 
            this.borderE.BackColor = System.Drawing.Color.Black;
            this.borderE.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.borderE.Dock = System.Windows.Forms.DockStyle.Right;
            this.borderE.Location = new System.Drawing.Point(586, 1);
            this.borderE.Name = "borderE";
            this.borderE.Size = new System.Drawing.Size(1, 374);
            this.borderE.TabIndex = 23;
            this.borderE.TabStop = false;
            // 
            // borderS
            // 
            this.borderS.BackColor = System.Drawing.Color.Black;
            this.borderS.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.borderS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.borderS.Location = new System.Drawing.Point(0, 375);
            this.borderS.Name = "borderS";
            this.borderS.Size = new System.Drawing.Size(587, 1);
            this.borderS.TabIndex = 25;
            this.borderS.TabStop = false;
            // 
            // BorderT
            // 
            this.BorderT.BackColor = System.Drawing.Color.Black;
            this.BorderT.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.BorderT.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderT.Location = new System.Drawing.Point(0, 0);
            this.BorderT.Name = "BorderT";
            this.BorderT.Size = new System.Drawing.Size(587, 1);
            this.BorderT.TabIndex = 26;
            this.BorderT.TabStop = false;
            // 
            // GUIBase
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 401);
            this.Controls.Add(this.borderW);
            this.Controls.Add(this.borderE);
            this.Controls.Add(this.BorderT);
            this.Controls.Add(this.borderS);
            this.Controls.Add(this.MsgBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUIBase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GUIBase_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GUIBase_KeyDown);
            this.MsgBar.ResumeLayout(false);
            this.MsgBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorderT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip MsgBar;
        internal System.Windows.Forms.ToolStripLabel lblMsg;
        private System.Windows.Forms.PictureBox borderW;
        private System.Windows.Forms.PictureBox borderE;
        private System.Windows.Forms.PictureBox borderS;
        private System.Windows.Forms.PictureBox BorderT;
    }
}