using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Account
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!panel1.Focused)
                panel1.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("File type", 20, HorizontalAlignment.Left);
        }
    }
}
