using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstWinFormProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Text = "Ok";
            this.Text = "hello world";
            
            
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.Text = "aboba";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> resume = new List<string>{"Boris", "Soltanovsky", "19"};
            MessageBox.Show("Resume Name");

            int kol = 0;
            foreach (var item in resume)
            {
                kol+=item.Count();
                if (resume.Last()==item)
                {
                    MessageBox.Show(item,Convert.ToString(kol));
                }
                else
                {
                    MessageBox.Show(item);
                }

            }

           
           

            
        
        }
        int i = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            this.BackColor= Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int min = 1;
            int max = 2000;
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                int z=random.Next(min, max);
                DialogResult dialogResult = MessageBox.Show($"Your Num is {z}","Window",MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Abort)
                {
                    max = z;
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    min = z;
                }
                else
                {
                    MessageBox.Show("Ez peasy lemon squezy");
                    break;
                }


            }
           



        }
    }
}
