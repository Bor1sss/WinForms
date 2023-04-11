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
    public partial class Cafe : Form
    {


     
        double[] Prices2 = { 7.32, 5, 6.53, 5.44 };
        double TotalPrice = 0;
        double TotalPrice2 = 0;
        double[] MyPrices2 = { 0, 0, 0, 0 };
        public bool Redacting = false;
        ContextMenuStrip contextMenu;
        ContextMenuStrip contextMenuNewText;
        public Cafe()
        {
            InitializeComponent();

       

        }

        public void RedactingCafe()
        {
            if (Redacting)
            {
                contextMenu = new ContextMenuStrip();

                contextMenu.Items.Add("New Price");
                contextMenu.Items[contextMenu.Items.Count - 1].Click += new EventHandler(NewPrice);
                textBox4.ContextMenuStrip = contextMenu;
                textBox6.ContextMenuStrip = contextMenu;
                textBox7.ContextMenuStrip = contextMenu;
                textBox8.ContextMenuStrip = contextMenu;



                contextMenuNewText = new ContextMenuStrip();
                contextMenuNewText.Items.Add("New Text");
                contextMenuNewText.Items[contextMenuNewText.Items.Count - 1].Click += new EventHandler(NewText);

                checkBox1.ContextMenuStrip = contextMenuNewText;
                checkBox2.ContextMenuStrip = contextMenuNewText;
                checkBox3.ContextMenuStrip = contextMenuNewText;
                checkBox4.ContextMenuStrip = contextMenuNewText;
            }
        }
        private void NewText(object sender, EventArgs e)
        {
            CheckBox clickedTextbox = ((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl as CheckBox;



            Gas gas = new Gas();
            gas.ParentForm = this;
            gas.ShowDialog();


            clickedTextbox.Text = gas.GetText;




        }
        private void NewPrice(object sender, EventArgs e)
        {
            TextBox clickedTextbox = ((sender as ToolStripMenuItem).GetCurrentParent() as ContextMenuStrip).SourceControl as TextBox;
          


            Gas gas = new Gas();
            gas.ParentForm = this;
            gas.ShowDialog();

            
            clickedTextbox.Text=gas.GetText;
           
            


        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (maskedTextBox3.ReadOnly == false)
            {

                maskedTextBox3.Clear();
                maskedTextBox3.ReadOnly = true;
                TotalPrice -= MyPrices2[0];
                MyPrices2[0] = 0;
                label5.Text = TotalPrice.ToString();
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
                label5.Text = TotalPrice.ToString();
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
                label5.Text = TotalPrice.ToString();
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
               
                TotalPrice-= MyPrices2[0];
                Prices2[0] = (Convert.ToDouble(textBox4.Text));
                MyPrices2[0] = (Convert.ToDouble(maskedTextBox3.Text) * Prices2[0]);
                
                TotalPrice += MyPrices2[0];
                label5.Text = TotalPrice.ToString();
            }


        }

        private void maskedTextBox9_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox4.Text != "")
            {
                TotalPrice -= MyPrices2[1];
                Prices2[1] = (Convert.ToDouble(textBox6.Text));
                MyPrices2[1] = (Convert.ToDouble(maskedTextBox4.Text) * Prices2[1]);
                TotalPrice += MyPrices2[1];
                label5.Text = TotalPrice.ToString();
            }
        }



        private void maskedTextBox10_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text != "")
            {
                TotalPrice -= MyPrices2[2];
                Prices2[2] = (Convert.ToDouble(textBox7.Text));
                MyPrices2[2] = (Convert.ToDouble(maskedTextBox5.Text) * Prices2[2]);
                TotalPrice += MyPrices2[2];
                label5.Text = TotalPrice.ToString();
            }
        }

        private void maskedTextBox11_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox6.Text != "")
            {
                TotalPrice -= MyPrices2[3];
                Prices2[3] = (Convert.ToDouble(textBox8.Text));
                MyPrices2[3] = (Convert.ToDouble(maskedTextBox6.Text) * Prices2[3]);
                TotalPrice += MyPrices2[3];
                label5.Text = TotalPrice.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(TotalPrice) + "грн";
        }
    }
}
