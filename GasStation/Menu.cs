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
    public partial class Menu : Form
    {
        Form1 form2;
        Cafe cafe;
        public Menu()
        {
            InitializeComponent();
            form2 = new Form1();
            cafe = new Cafe();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            cafe.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cafe.Redacting = true;
            cafe.RedactingCafe();
            
            form2.Redacting = true;
            form2.RedactingGas();
            MessageBox.Show("Redacting Enable");
        }
    }
}
