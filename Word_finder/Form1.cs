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
using System.Threading;
using System.Text.RegularExpressions;
namespace Word_finder
{
    public partial class Form1 : Form
    {
        string pathToFolder;
        Mutex mutex= new Mutex ();

        List<string> FilesFormat = new List<string> {".DOC", ".TXT", "HTML" };
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathToFolder = folderBrowserDialog1.SelectedPath;
                textBox2.Text = pathToFolder;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            mutex.WaitOne();
            await Task.Run(()=> {
                string[] astrFiles = Directory.GetFiles(pathToFolder);
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    textBox3.Text = "Empty fields";
                }
                else
                {
                    foreach (var file in astrFiles)
                    {

                        if (file.ToUpper().EndsWith(FilesFormat[comboBox1.SelectedIndex]))
                        {
                            using (StreamReader streamReader = new StreamReader(file))
                            {

                                string text = streamReader.ReadToEnd().ToLower();
                                Regex regex = new Regex($"{textBox1.Text.ToLower()}");
                                MatchCollection match = regex.Matches(text);
                                int count = 0;
                                foreach (var item in match)
                                {
                                    count++;
                                }
                                if (match.Count > 0)
                                {
                                    textBox3.Text += $"File name{file}\r\n Word: {textBox1.Text.ToLower()} \r\n Kol: {count}\r\n";
                                }

                            }
                        }
                    }

                }
            });
            mutex.ReleaseMutex();

        }
    }
}
