using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace WinForms2Dz
{
    public partial class Form1 : Form
    {
        int w = 200;
        int h = 100;

        bool ctrl =false;
        public Form1()
        {
            InitializeComponent();
            

            groupBox1.Height= h;
            groupBox1.Width= w;
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            if(e.Button == MouseButtons.Left)
            {
                if (e.X > groupBox1.Left && e.X < groupBox1.Left + w&& e.Y > groupBox1.Top&&e.Y<groupBox1.Top+h)
                {
                    
                    MessageBox.Show($"In box");
                }
                else if (e.X > groupBox1.Left && e.X < groupBox1.Left + w && e.Y==groupBox1.Top || e.Y > groupBox1.Top && e.Y < groupBox1.Top + h&&e.X==groupBox1.Left)
                {
                    MessageBox.Show($"In edge");
                }
                else if (ctrl)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ctrl.ToString());
                }
               
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Text=$"X:{this.Top} Y:{this.Width}";
                Thread.Sleep(1000);
            }


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X:{e.X} Y:{e.Y}";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
     
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.ControlKey)
            {
               
                ctrl = true;
            }
            else
            {
                ctrl = false;
            }
           
        }
    }
}
