using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GasStation
{
    public partial class Form1 : Form
    {

        double[] Prices = { 56.5, 56.6, 60.6 };
        double[] Prices2 = { 7.32, 5, 6.53, 5.44 };
        double TotalPrice = 0;
        double TotalPrice2 = 0;
        double cafe = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox1.Text =Prices[comboBox1.SelectedIndex].ToString();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox2.ReadOnly = false;
                textBox3.Clear();
                textBox3.ReadOnly = true;
            }
            else
            {
                textBox2.Clear();
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            TotalPrice2 = (Prices[comboBox1.SelectedIndex] * Convert.ToDouble(textBox2.Text));
            Price.Text = (Prices[comboBox1.SelectedIndex] * Convert.ToDouble(textBox2.Text)).ToString()+" грн";
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            TotalPrice2 = Convert.ToDouble(textBox3.Text);
            Price.Text =  Convert.ToDouble(textBox3.Text).ToString() + " грн";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(textBox5.ReadOnly == false)
            {
                textBox5.ReadOnly = true;
            }
            else
            {
                textBox5.ReadOnly = false;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox9.ReadOnly == false)
            {
                textBox9.ReadOnly = true;
            }
            else
            {
                textBox9.ReadOnly = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox10.ReadOnly == false)
            {
                textBox10.ReadOnly = true;
            }
            else
            {
                textBox10.ReadOnly = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox11.ReadOnly == false)
            {
                textBox11.ReadOnly = true;
            }
            else
            {
                textBox11.ReadOnly = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TotalPrice += (Convert.ToDouble(textBox5.Text) * Prices2[0]);

            label5.Text = TotalPrice.ToString();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            TotalPrice += (Convert.ToDouble(textBox5.Text) * Prices2[1]);

            label5.Text = TotalPrice.ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            TotalPrice += (Convert.ToDouble(textBox5.Text) * Prices2[2]);

            label5.Text = TotalPrice.ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            TotalPrice += (Convert.ToDouble(textBox5.Text) * Prices2[3]);

            label5.Text = TotalPrice.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(TotalPrice + TotalPrice2);
        }
    }
}
