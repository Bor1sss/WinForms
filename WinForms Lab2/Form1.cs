using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace WinForms_Lab2
{
   


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           User user=new User(textBox1.Text,textBox2.Text,maskedTextBox1.Text,maskedTextBox2.Text);


            if (!String.IsNullOrEmpty(this.textBox1.Text))
            {
                if (!this.listBox1.Items.Contains(user))

                    this.listBox1.Items.Add(user);
                else
                    MessageBox.Show("CheckedListBox already contains this item");
            }
            else
                MessageBox.Show("Empty string");

            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count != 0)
            {

                User user = (User)listBox1.SelectedItem;

                textBox1.Text = user.name;
                textBox2.Text = user.surname;
                maskedTextBox1.Text = user.email;
                maskedTextBox2.Text = user.phone;


                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
           StreamWriter stream= new StreamWriter("1.txt");

            foreach (var item in listBox1.Items)
            {
                stream.WriteLine(item);
            }
           
            stream.Close();

        }
    }

    class User
    {
      public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public User(string n,string s,string e,string p)
        {
            name = n;
            surname = s;
            email = e;
            phone = p;
        }
        public override string ToString()
        {
            return $"{name}+ {surname}";
        }
    }
}
