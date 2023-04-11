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

        List<double> Prices = new List<double>{ 56.5, 56.6, 60.6 };
       
        double TotalPrice2 = 0;
      

        double cafe = 0;
        
        MainMenu MyMenu;
        MenuItem m1, m2,m3, subm1;
        public bool Redacting = false;
        ContextMenuStrip context;
        ContextMenuStrip contextPrice;
        ContextMenuStrip contextMenu;
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


        public void RedactingGas()
        {
            if (Redacting)
            {
                contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("New Item Add");
                contextMenu.Items[contextMenu.Items.Count - 1].Click += new EventHandler(NewItem);
                comboBox1.ContextMenuStrip = contextMenu;


                contextPrice = new ContextMenuStrip();
                contextPrice.Items.Add("New Price");
                contextPrice.Items[contextPrice.Items.Count - 1].Click += new EventHandler(NewPrice);
                textBox1.ContextMenuStrip = contextPrice;
            }
        }
        private void NewPrice(object sender, EventArgs e)
        {
            TextBox clickedTextbox = ((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl as TextBox;



            Gas gas = new Gas();
            gas.ParentForm = this;
            gas.ShowDialog();

            clickedTextbox.Text = gas.GetText;
         




        }
        private void NewItem(object sender, EventArgs e)
        {
            ComboBox clickedTextbox = ((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl as ComboBox;



            Gas gas = new Gas();
            gas.ParentForm = this;
            gas.ShowDialog();


            clickedTextbox.Items.Add(gas.GetText);
            Prices.Add(0);



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
        
            textBox1.Clear();
            label6.Text = "0";
 

        }
        private void subm2_Select(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
      
            textBox1.Clear();
            label6.Text = "0";
      

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Prices[comboBox1.SelectedIndex] = Convert.ToDouble(textBox1.Text);
                maskedTextBox1.Clear();
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
                TotalPrice2 = (Convert.ToDouble(maskedTextBox2.Text));
                Price.Text = (Convert.ToDouble(maskedTextBox2.Text)).ToString() + " грн";
            }
        }



   
        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(TotalPrice2)+"грн";
        }
    }
}
