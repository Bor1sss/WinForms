using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Form1 : Form
    {

       

        static public int Minutes = 5;
        static public int Seconds = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

     
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                progressBar1.Value += 7;
           
                groupBox1.Enabled = false;
            }
           
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
            {
                progressBar1.PerformStep();
                groupBox2.Enabled = false;

            }
          
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked && !checkBox4.Checked && !checkBox5.Checked)
            {
                progressBar1.PerformStep();
                groupBox3.Enabled = false;
            }
           
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked && !checkBox8.Checked && !checkBox7.Checked)
            {
                progressBar1.PerformStep();

                groupBox4.Enabled = false;
            }
           
           
        }



        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton16.Checked)
            {
                progressBar1.PerformStep();
                groupBox5.Enabled = false;
            }
            
        }


        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                progressBar1.PerformStep();
                groupBox6.Enabled = false;
            }
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                progressBar1.PerformStep();
                groupBox7.Enabled = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked&& checkBox14.Checked&&checkBox15.Checked)
            {
                progressBar1.PerformStep();
                groupBox8.Enabled = false;
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton11.Checked)
            {
                progressBar1.PerformStep();
                groupBox9.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value == 20)
            {
                progressBar1.PerformStep();
                groupBox10.Enabled = false;
            }
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton13.Checked)
            {
                progressBar1.PerformStep();
                groupBox11.Enabled = false;
            }
        }

        private void textBox1_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (textBox1.Text == "А")
            {
                progressBar1.PerformStep();
                groupBox12.Enabled = false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "Менделеев")
            {
                progressBar1.PerformStep();
                groupBox13.Enabled = false;
            }
        }
        private void Timer(object sender, EventArgs e)
        {
           
        }
      
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            Timr.Text = $"{Minutes} :{Seconds}";
            if (Seconds <= 0)
            {
               Seconds = 60;
                if (Minutes <= 0)
                {
                    Seconds--;


                }
                else
                {
                   Seconds--;
                   Minutes--;
                }
            }

            else
            {
                Seconds--;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "электрофотополупроводниковый")
            {
                progressBar1.PerformStep();
                groupBox14.Enabled = false;
            }
        }

   
    }
}
