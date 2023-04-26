using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class View : Form
    {
        Controller controller;
        public View()
        {
            InitializeComponent();
            controller = new Controller();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (radioButton1.Checked)
            {
                controller.HowToFind = 1;


            }
            else
            {
                controller.HowToFind = 2;
            }
            textBox2.Text = controller.GetBook(textBox1.Text).ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            


        }
    }
}
