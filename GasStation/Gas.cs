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
    public partial class Gas : Form
    {
        public Form ParentForm { get; set; }
        public Gas()
        {
            InitializeComponent();


        }

       
        public string GetText
        {
            get
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                    return textBox1.Text;
                return "0";
            }
        }
    }
}
