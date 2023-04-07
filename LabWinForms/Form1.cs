using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace LabWinForms
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("1.txt");
            string f="No words";
            if (file != null)
            {
                 f= file.ReadToEnd();
            }
            
            textBox1.Text = f;

            progressBar1.Value = f.Count();
            if(textBox1.Text.Length > 1000)
            {
                progressBar1.Value = progressBar1.Maximum;
            }
            file.Close();
        }
    }
}
