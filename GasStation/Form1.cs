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
        double[] MyPrices2= { 0,0,0,0};

        double cafe = 0;

        MainMenu MyMenu;
        MenuItem m1, m2,m3, subm1;

        ContextMenuStrip context;
        public Form1()
        {
            InitializeComponent();


            context=new ContextMenuStrip();

            context.Items.Add("Next Client");
            context.Items[context.Items.Count-1].Click += new EventHandler(subm1_Select);
            context.Items.Add("Exit");
            context.Items[context.Items.Count - 1].Click += new EventHandler(Exit);
            context.Items.Add("Сброс");
            context.Items[context.Items.Count - 1].Click += new EventHandler(subm2_Select);

            ContextMenuStrip = context;
            radioButton1.Checked = true;
            MyMenu = new MainMenu();
            m1 = new MenuItem("Игра");
           
            MyMenu.MenuItems.Add(m1);
            m2 = new MenuItem("Exit");
            m2.Click += new EventHandler(Exit);
            MyMenu.MenuItems.Add(m2);

            m3 = new MenuItem("Сброс");
            m3.Click+=new EventHandler(subm2_Select);
            MyMenu.MenuItems.Add(m3);

            subm1 = new MenuItem("Next client");
            subm1.Click += new EventHandler(subm1_Select);
            m1.MenuItems.Add(subm1);
            Menu = MyMenu;

        }
        private void Exit(object sender, EventArgs e)
        {
            Close();
        }
        private void subm1_Select(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox5.Clear();
            textBox1.Clear();
            label6.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

        }
        private void subm2_Select(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox5.Clear();
            textBox1.Clear();
            label6.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

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
                maskedTextBox1.ReadOnly = false;
                maskedTextBox2.Clear();
                maskedTextBox2.ReadOnly = true;
            }
            else
            {
                maskedTextBox1.Clear();
                maskedTextBox1.ReadOnly = true;
                maskedTextBox2.ReadOnly = false;
            }
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (maskedTextBox1.Text == "")
            {
                Price.Text = "0 грн";
            }
            else
            {
                TotalPrice2 = (Prices[comboBox1.SelectedIndex] * Convert.ToDouble(maskedTextBox1.Text));
                Price.Text = (Prices[comboBox1.SelectedIndex] * Convert.ToDouble(maskedTextBox1.Text)).ToString() + " грн";
            }

        }
        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "")
            {
                Price.Text = "0 грн";
            }
            else
            {
               
                Price.Text = (Convert.ToDouble(maskedTextBox2.Text)).ToString() + " грн";
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(maskedTextBox3.ReadOnly == false)
            {

                maskedTextBox3.Clear();
                maskedTextBox3.ReadOnly = true;
                TotalPrice -= MyPrices2[0];
                MyPrices2[0] = 0;
            }
            else
            {
                maskedTextBox3.ReadOnly = false;
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (maskedTextBox4.ReadOnly == false)
            {
                maskedTextBox4.ReadOnly = true;
                maskedTextBox4.Clear();
                TotalPrice -= MyPrices2[1];
                MyPrices2[1] = 0;
                label5.Text = TotalPrice.ToString();
            }
            else
            {
                maskedTextBox4.ReadOnly = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (maskedTextBox5.ReadOnly == false)
            {
                maskedTextBox5.Clear();
                maskedTextBox5.ReadOnly = true;
                TotalPrice -= MyPrices2[2];
                MyPrices2[2] = 0;
            }
            else
            {
                maskedTextBox5.ReadOnly = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (maskedTextBox6.ReadOnly == false)
            {
                maskedTextBox6.Clear();
                maskedTextBox6.ReadOnly = true;
                TotalPrice -= MyPrices2[3];
                MyPrices2[3] = 0;
            }
            else
            {
                maskedTextBox6.ReadOnly = false;
            }
        }

        private void maskedTextBox5_TextChanged(object sender, EventArgs e)
        {

            if (maskedTextBox3.Text != "")
            {
                MyPrices2[0] = (Convert.ToDouble(maskedTextBox3.Text) * Prices2[0]);
                TotalPrice += MyPrices2[0];
                label5.Text = TotalPrice.ToString();
            }


        }

        private void maskedTextBox9_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox4.Text != "")
            {
                MyPrices2[1] = (Convert.ToDouble(maskedTextBox4.Text) * Prices2[1]);
                TotalPrice += MyPrices2[1];
                label5.Text = TotalPrice.ToString();
            }
        }

     
       
        private void maskedTextBox10_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text != "")
            {
                MyPrices2[2] = (Convert.ToDouble(maskedTextBox5.Text) * Prices2[2]);
                TotalPrice += MyPrices2[2];
                label5.Text = TotalPrice.ToString();
            }
        }

        private void maskedTextBox11_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text != "")
            {
                MyPrices2[3] = (Convert.ToDouble(maskedTextBox6.Text) * Prices2[3]);
                TotalPrice += MyPrices2[3];
                label5.Text = TotalPrice.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(TotalPrice + TotalPrice2);
        }
    }
}
