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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private int xpos = 0, ypos = 0;
        public string mode = "Left-to-Right";

        private void button1_Click(object sender, EventArgs e)
        {
            xpos = label1.Location.X;
            ypos = label1.Location.Y;
            mode = "Left-to-Right";
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xpos = label1.Location.X;
            ypos = label1.Location.Y;
            mode = "Right-to-Left";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mode == "Left-to-Right")
            {
                if (this.Width == xpos)
                {
                    this.label1.Location = new System.Drawing.Point(0, ypos);
                    xpos = 0;

                }
                else
                {
                    this.label1.Location = new System.Drawing.Point(xpos, ypos);
                    xpos += 2;
                }
            }
            else if (mode == "Right-to-Left")
            {
                if (xpos == 0)
                {
                    this.label1.Location = new System.Drawing.Point(this.Width, ypos);
                    xpos = this.Width;
                }
                else
                {
                    this.label1.Location = new System.Drawing.Point(xpos, ypos);
                    xpos -= 2;
                }
            }
        }
    }
}
