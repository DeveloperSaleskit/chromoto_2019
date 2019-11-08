using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Account.DefaultLayout
{
    public partial class frmQuickLinks : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public frmQuickLinks()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }

        private void frmQuickLinks_Load(object sender, EventArgs e)
        {

        }
    }
}
