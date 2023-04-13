using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz2
{
    public partial class Form1 : Form
    {


        int page = 2;

        int correct = 0;
        public Form1()
        {
            InitializeComponent();

           int[] CorrectAnswers= new int[3]{ 1,2,0};
             
            RadioButton[]radioButtons=new RadioButton[3];
            CreateTab();
            CreateTab();




        }

        private void CreateTab()
        {
            RadioButton[] radioButtons = new RadioButton[3];
            Label label2 = new Label();
            label2.Location = new Point(106, 10);
            label2.Text = $"Question {page}:";


            TabPage tabPage1 = new TabPage($"{page}");
            radioButtons[0] = new RadioButton();
            radioButtons[1] = new RadioButton();
            radioButtons[2] = new RadioButton();


            tabPage1.Controls.Add(label2);

            int a = -77;
            int i = 0;
            foreach (var item in radioButtons)
            {
                tabPage1.Controls.Add(radioButtons[i]);
                i++;
                item.Location = new Point(a += 106, 106);

                item.Text = $"Answer {i}";
            }


            tabControl1.Controls.Add(tabPage1);
            page++;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex<tabControl1.TabPages.Count-1){
                tabControl1.SelectedTab = tabControl1.TabPages[++tabControl1.SelectedIndex];
                
            }
          
            if(tabControl1.SelectedIndex == tabControl1.TabPages.Count - 1)
            {
                button1.Enabled = false;
                button1.Visible = false;

                button3.Visible = true;
                
            }
         
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex >= 1)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[--tabControl1.SelectedIndex];
            }
            if (tabControl1.SelectedIndex != tabControl1.TabPages.Count - 1)
            {
                button1.Enabled = true;
                button1.Visible = true;

                button3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
               
                if (radioButton1.Checked == true)
                {
                    correct++;
                }
                int z = 0;
                foreach (var item in tabControl1.TabPages[1].Controls)
                {
                    if (item as RadioButton != null)
                    {

                        RadioButton radioButton = (RadioButton)item;
                        if (radioButton.Checked == true && z == 2)
                        {
                            correct++;
                        }
                        z++;
                    }
                }
            z = 0;
                foreach (var item in tabControl1.TabPages[2].Controls)
                {
                    if (item as RadioButton != null)
                    {

                        RadioButton radioButton = (RadioButton)item;
                        if (radioButton.Checked == true && z == 0)
                        {
                            correct++;
                        }
                        z++;
                    }
                }


                MessageBox.Show($"Correctness {correct}");
            correct = 0;
            }
        }
    
}
