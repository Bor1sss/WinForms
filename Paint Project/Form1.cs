using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Paint_Project
{
    public partial class Form1 : Form
    {

        Controller controller= new Controller();  
      


     
   
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            controller.SetSize(panel1);
           
            this.AllowDrop = true;


            ScrollBar VscrollBar=new VScrollBar();
            VscrollBar.Dock=DockStyle.Right;



            panel1.MouseWheel += ZoomIn;




        }

        public void ZoomIn(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {

                if((ModifierKeys & Keys.Control) == Keys.Control){
                   
                    panel1.Size = new Size(Convert.ToInt32(panel1.Width * 1.2), Convert.ToInt32(panel1.Height * 1.2));
                    pictureBox1.Image = controller.ZoomIn();
                }
                
            }
            else
            {
                if ((ModifierKeys & Keys.Control) == Keys.Control)
                {
                    panel1.Size = new Size(Convert.ToInt32(panel1.Width / 1.2), Convert.ToInt32(panel1.Height / 1.2));
                    pictureBox1.Image = controller.ZoomOut();
                }
            }
        }
        private bool isMouse = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouse = true;

            controller.SetStart(e.X, e.Y);
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouse) { return; }

             pictureBox1.Image=controller.Draw(e.X,e.Y);

           // this.Text = $"{controller.arrayPoints.GetPoints()[0].X}|{controller.arrayPoints.GetPoints()[0].Y}";


             //pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           
            isMouse = false;
            if (controller.Type == 3)
            {
                pictureBox1.Image = controller.DrawFigure(e.X, e.Y);
            }
            else if(controller.Type == 2)
            {
                pictureBox1.Image = controller.DrawFigure(e.X, e.Y);
            }
            controller.Reset();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            controller.SetSize(trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
              foreach (int item in listView2.SelectedIndices)
          {
              switch (item)
              {

                  case 0: controller.SetColor(Color.Black); listView2.Items[item].BackColor=Color.Black; break;
                  case 1: controller.SetInColor(Color.Black); listView2.Items[item].BackColor = Color.Black; break;
                  default:break;
              }
          }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(Color.White); listView2.Items[item].BackColor = Color.White; break;
                    case 1: controller.SetInColor(Color.White); listView2.Items[item].BackColor = Color.White; break;
                    default: break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(Color.Red); listView2.Items[item].BackColor = Color.Red; break;
                    case 1: controller.SetInColor(Color.Red); listView2.Items[item].BackColor = Color.Red; break;
                    default: break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(Color.Green); listView2.Items[item].BackColor = Color.Green; break;
                    case 1: controller.SetInColor(Color.Green); listView2.Items[item].BackColor = Color.Green; break;
                    default: break;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(Color.Blue); listView2.Items[item].BackColor = Color.Blue; break;
                    case 1: controller.SetInColor(Color.Blue); listView2.Items[item].BackColor = Color.Blue; break;
                    default: break;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(Color.Magenta); listView2.Items[item].BackColor = Color.Magenta; break;
                    case 1: controller.SetInColor(Color.Magenta); listView2.Items[item].BackColor = Color.Magenta; break;
                    default: break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         /*   DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);*/
        }

       
        private void button7_Click(object sender, EventArgs e)
        {
           ColorDialog colorDialog = new ColorDialog();
           colorDialog.ShowDialog();
            controller.SetColor(colorDialog.Color);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            foreach (int item in listView1.SelectedIndices)
            {
                if (item == 0)
                {
                    controller.Type = 2;
                }
                else if(item == 1)
                {
                    controller.Type = 3;
                }
                else if(item == 2)
                {
                    controller.Type = 1;
                }
                
            }

        }
       

     
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            if (controller.Type == 3)
            {
                e.Graphics.DrawLine(controller.pencils.pen, controller.line.GetStartPoints(), controller.line.GetPoints());
            }
            else if(controller.Type == 2)
            {
                e.Graphics.DrawRectangle(controller.pencils.pen, controller.line.GetReact()) ;
                e.Graphics.FillRectangle(controller.pencils.Brush, controller.line.GetReact());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.pencils.SetBrush(comboBox1.SelectedIndex);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.pencils.SetNoInColor(comboBox2.SelectedIndex);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = ".JPG file (*.jpg)|*.jpg|.PNG file (*.png)|*.png";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                controller.Save(saveFileDialog1.FileName);
            }

            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null)
            {
                controller?.Load(openFileDialog1.FileName);
                pictureBox1.Image = controller.map;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
           
            controller.Load(files[0]);
            pictureBox1.Image =Image.FromFile(files[0]);
            
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"{panel1.HorizontalScroll.SmallChange}||{panel1.Height}";

           
        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
         
        }
    }
   
        


}
