using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace T9_Dz
{
    public partial class Form1 : Form
    {
        string current_text;
      
        int Kol = 0;
        int timer = 0;
        string cur_text;

        string New_word;
        Mutex mutex=new Mutex(true,"Mutex");
        List<string> Dictionary = new List<string>();

        List<string> Button1 = new List<string>() { "1" };
        List<string> Button2 = new List<string>() { "2","А","Б","В","Г","A","B","C" };
        List<string> Button3 = new List<string>() { "3","Д","Е","Ж,","Э","D","E","F" };
        List<string> Button4 = new List<string>() { "4", "З", "И", "Й", "К", "L", "M", "N" };
        List<string> Button5 = new List<string>() { "5", "Л", "М", "Н", "О", "O", "P", "Q" };
        List<string> Button6 = new List<string>() { "6", "П", "Р", "С", "Т", "U", "V", "W" };
        List<string> Button7 = new List<string>() { "7", "У", "Ф", "Х", "Ц", "X", "Y", "Z" };
        List<string> Button8 = new List<string>() { "8", "Ч", "Ш", "Щ", "Ъ", ".", ",", "?" };
        List<string> Button9 = new List<string>() { "9", "Ы", "Ь", "Э", "Ю", "-", "@", "!" };
        List<string> Button0 = new List<string>() { "0", ".", " ", "_", ":", ";", "(", ")" };

    


        public Form1()
        {
            
            
            Dictionary.Add("автомобиль");
            Dictionary.Add("книга");
            Dictionary.Add("музыка");
            Dictionary.Add("компьютер");
            Dictionary.Add("здание");
            Dictionary.Add("фильм");
            Dictionary.Add("стол");
            Dictionary.Add("ручка");
            Dictionary.Add("растение");
            Dictionary.Add("зеркало");
            InitializeComponent();
        }


        private void SelectNewText()
        {
            
            richTextBox1.Select(richTextBox1.Text.Count() - 1, 1);
         

        }
        private void Suggest(string word)
        {
            foreach (var item in Dictionary)
            {
                if (item.StartsWith(word.ToLower()))
                {
                    richTextBox2.Text = item;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            mutex.WaitOne(); 
           
            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            
            richTextBox1.Text += Button1[Kol];
            
            current_text = richTextBox1.Text;
           
            SelectNewText(); 
            mutex.ReleaseMutex();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();
            
            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }

            if (Kol >= Button2.Count - 1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button2[Kol];
           
            SelectNewText();

          

           
            mutex.ReleaseMutex(); 
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            timer2.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer++;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button3.Count-1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button3[Kol];
          

            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button4.Count-1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button4[Kol];
        
            
            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button5.Count-1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button5[Kol];
         

            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button6.Count - 1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button6[Kol];
       

            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button7.Count-1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button7[Kol];
        

            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button8.Count-1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button8[Kol];
        

            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();

            if (timer1.Enabled == true)
            {
                richTextBox1.Text = current_text;
            }
            else
            {
                Kol = 0;
            }
            if (Kol >= Button9.Count-1)
            {
                Kol = 0;
            }
            else
            {
                Kol++;

            }
            richTextBox1.Text += Button9[Kol];
        

            SelectNewText();
            mutex.ReleaseMutex();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer > 2) // если текст выделен
            {
                timer = 0;
                mutex.WaitOne();
                cur_text += richTextBox1.SelectedText;
                Suggest(cur_text);
                richTextBox1.Select(0, 0);
                Kol = 0;
                current_text = richTextBox1.Text;
                timer1.Stop();
              
                mutex.ReleaseMutex();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " ";
            cur_text = "";
            richTextBox2.Clear();
            New_word = richTextBox1.Text;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length != 0)
            {
                richTextBox1.Text = New_word;
                richTextBox1.Text += richTextBox2.Text;
               current_text+=richTextBox1.Text;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            New_word = " ";
            cur_text = " ";
            current_text = " ";
        }
    }

}





