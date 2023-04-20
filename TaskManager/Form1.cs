using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace TaskManager
{
    public partial class Form1 : Form
    {
        ContextMenuStrip contextMenuStrip;
        Process[] processes;
        public Form1()
        {
            InitializeComponent();
            contextMenuStrip=new ContextMenuStrip();
            contextMenuStrip.Items.Add("Close");
            contextMenuStrip.Items[contextMenuStrip.Items.Count - 1].Click += new EventHandler(subm1_Select);
            listView1.ContextMenuStrip = contextMenuStrip;
        }

        private void subm1_Select(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indices = listView1.SelectedIndices;
            MessageBox.Show($"{processes[indices[0]].ProcessName} {processes[indices[0]].Id}");

            processes[indices[0]].Kill();
            
            this.button1_Click(sender,e);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            processes = Process.GetProcesses();
            //выводим заголовок

            ListViewItem item;

            foreach (Process p in processes)
            {
                item = new ListViewItem(p.ProcessName);
                item.SubItems.Add(p.Id.ToString());
                listView1.Items.Add(item);
            }

            
        }



        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
