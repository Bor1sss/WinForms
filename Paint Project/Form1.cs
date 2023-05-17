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
using System.Text.RegularExpressions;
using System.Drawing.Text;

namespace Paint_Project
{
    public partial class Form1 : Form
    {

        Controller controller= new Controller();
        Regex regex = new Regex(@"^.{1}$");
        Rectangle rect1;
        Rectangle rect2;
        Rectangle rect3;
        private float Zoom = 1.5f;
        float scaleDifference;
        int mouseX;
        int mouseY;

        PaintEventArgs cur;

        bool isComplete = false;
        bool isDraging = false;
        bool isTyping = false;
        bool onlyX=false;
        bool onlyY=false;
        int resizeX=0;
        int resizeY = 0;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
       
            Icon icon=new Icon("paint.ico");
            //Отображение иконок 
            ImageList imageList = new ImageList();
            imageList.Images.Add(new Bitmap("Rect.png"));
            imageList.Images.Add(new Bitmap("Line.png"));
            imageList.Images.Add(new Bitmap("Pencil.png"));
            imageList.Images.Add(new Bitmap("Elipse.png"));
            imageList.Images.Add(new Bitmap("Text.png"));
            int i = 0;
            listView1.SmallImageList = imageList;
            foreach (ListViewItem item in listView1.Items)
            {
                
               item.ImageIndex = i++;
               
            }



                this.Icon = icon;

            this.AllowDrop = true;

    

            this.FormClosing += SaveOnClose;


            listView2.Items[0].Selected = true;


            panel1.MouseWheel += ZoomIn;

            NewPaint();
            SetSizeBoxes();

            panel1.Paint += new PaintEventHandler(Paint1);



            InstalledFontCollection fontsCollection = new InstalledFontCollection();
            FontFamily[] fontFamilies = fontsCollection.Families;
      
            foreach (FontFamily font in fontFamilies)
            {
                comboBox4.Items.Add(font.Name);
            }

        }

        //Создание чистого холста
        public void NewPaint()
        {
            pictureBox1.Image = null; 
            controller = new Controller();
            pictureBox1.Width = 417;
            pictureBox1.Height = 270;
            controller.SetSize(pictureBox1);
            controller.figures = new Line(2);
            pictureBox1.Image = controller.map;
          

        }

        //Сохранить при закрытии
        private void SaveOnClose(object sender,CancelEventArgs e)
        {
          

            DialogResult result1 = MessageBox.Show("Do you want to save file? ", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if(result1 == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
                e.Cancel= false;
                

            }
            else if(result1 == DialogResult.No)
            {
                e.Cancel = false;
               
            }
            else
            {
                e.Cancel = true;

            }

            
          



        }

        //Выписывает размеры холста
            private void SetSizeBoxes()
            {

            label2.Text = pictureBox1.ClientSize.ToString();

             }

        // Подсчёт разницы между bitmap и pictureBox
        private void CalculateScaleDifference()
        {
            if (pictureBox1.Image != null)
            {
                SizeF imageSize = pictureBox1.Image.Size;
                SizeF clientSize = pictureBox1.ClientSize;

                float scaleX = imageSize.Width / clientSize.Width;
                float scaleY = imageSize.Height / clientSize.Height;

                scaleDifference = Math.Max(scaleX, scaleY);

               
                mouseX = Convert.ToInt32(pictureBox1.PointToClient(MousePosition).X * scaleDifference);
                mouseY = Convert.ToInt32(pictureBox1.PointToClient(MousePosition).Y * scaleDifference);

                

            }
        }

        //Метод для увеличения и отдаления холста
        public void ZoomIn(object sender, MouseEventArgs e)
        {
            
          
               
                

                if (e.Delta > 0&&scaleDifference>0.19)
                {

                    if ((ModifierKeys & Keys.Control) == Keys.Control)
                    {

                        pictureBox1.Size = new Size(Convert.ToInt32(pictureBox1.Width * Zoom), Convert.ToInt32(pictureBox1.Height * Zoom));
                        pictureBox1.Image = controller.ZoomIn();
                        CalculateScaleDifference();
                }

                }
                else if(e.Delta<0&&scaleDifference<2)
                {
                    if ((ModifierKeys & Keys.Control) == Keys.Control)
                    {

                        pictureBox1.Size = new Size(Convert.ToInt32(pictureBox1.Width / Zoom), Convert.ToInt32(pictureBox1.Height / Zoom));

                        pictureBox1.Image = controller.ZoomOut(pictureBox1);
                        pictureBox1.Invalidate();
                        CalculateScaleDifference();
                      }
                }
            
            panel1.Invalidate();
            
        }
        private bool isMouse = false;



        //Кисть опущена
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            isMouse = true;
            CalculateScaleDifference();
            controller.SetStart(mouseX, mouseY);
         
            controller.VirtualFigures.SetStartPoint(e.X, e.Y);


            isComplete = false;
        }

        //кисть двигаеться
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (!isMouse ) {return; }


            CalculateScaleDifference();
            pictureBox1.Image=controller.Draw(mouseX,mouseY);
            controller.VirtualFigures.SetPoint(e.X, e.Y);

          
           
           
        }

        //кисть поднята
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           
            isMouse = false;
            CalculateScaleDifference();
            if (controller.Type != 1)
            {
                pictureBox1.Image= controller.DrawFigure(mouseX, mouseY);
             
            }

           


            controller.Reset();
            isComplete = true;
        }


        //Размер кисти
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

        //выбор цветов
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(Color.White); listView2.Items[item].BackColor = Color.White; break;
                    case 1: if (comboBox2.SelectedIndex == 1) { controller.SetInColor(Color.White); listView2.Items[item].BackColor = Color.White; } break;
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
                    case 1: if (comboBox2.SelectedIndex == 1) { controller.SetInColor(Color.Red); listView2.Items[item].BackColor = Color.Red; } break;
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
                    case 1: if (comboBox2.SelectedIndex == 1) { controller.SetInColor(Color.Green); listView2.Items[item].BackColor = Color.Green; } break;
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
                    case 1: if (comboBox2.SelectedIndex == 1) { controller.SetInColor(Color.Blue); listView2.Items[item].BackColor = Color.Blue; } break;
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
                    case 1: if (comboBox2.SelectedIndex == 1) { controller.SetInColor(Color.Magenta); listView2.Items[item].BackColor = Color.Magenta; } break;
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
            foreach (int item in listView2.SelectedIndices)
            {
                switch (item)
                {

                    case 0: controller.SetColor(colorDialog.Color); listView2.Items[item].BackColor = colorDialog.Color; break;
                    case 1: if (comboBox2.SelectedIndex == 1) { controller.SetInColor(colorDialog.Color); listView2.Items[item].BackColor = colorDialog.Color; } break;
                    default: break;
                }
            }
          
        }

        //выбор фигур
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {


            foreach (int item in listView1.SelectedIndices)
            {
                if (item == 0)
                {
                    controller.Type = 2;
                    controller.figures = new Square(2);
                    controller.VirtualFigures = new VirtualSquare(2);
                }
                else if(item == 1)
                {
                    controller.Type = 3;
                    controller.figures = new Line(2);
                    controller.VirtualFigures = new VirtualLine(2);
                    groupBox2.Enabled = false;
                }
                else if(item == 2)
                {
                    controller.Type = 1;
                    controller.arrayPoints = new ArrayPoints(2);
                    groupBox2.Enabled = false;
                }
                else if (item == 3)
                {
                    controller.Type = 4;
                    controller.figures = new Elipse(2);
                    controller.VirtualFigures = new VirtualElipse(2);
                    groupBox2.Enabled = false;
                }
                else if(item == 4)
                {
                    controller.Type= 5;
                    controller.figures = new TextString(2);
                    controller.VirtualFigures = new VirtualTextString(2,pictureBox1);
                    controller.VirtualFigures.form = pictureBox1;
                    controller.VirtualFigures.textSet = controller.textSettings;
                    comboBox4.SelectedIndex = 7;
                    comboBox3.SelectedIndex = 4;
                    groupBox2.Enabled = true;
                    isTyping = true;
                }
                
            }

        }
       

     // Отображение Виртуальных фигур
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!isDraging)
            {
                if (controller.Type != 1)
                {
                    if (!isComplete)
                    {
                        controller.VirtualFigures.Draw(e, controller.pencils);
                    }
           
                }
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



        //Menu strip save
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
        //Загрузить
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != null)
            {
                controller?.Load(openFileDialog1.FileName);
                pictureBox1.Image = controller.map;
                ResizePictureBox(pictureBox1.Image);
               
            }
        }

        //Драг дроп
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
           
            controller.Load(files[0]);

            Image img = Image.FromFile(files[0]);
            ResizePictureBox(img);
            
        }

        //изменение картинки при вставке 
        public void ResizePictureBox(Image img)
        {
            pictureBox1.Image = img;
            pictureBox1.Size = new Size(img.Width, img.Height);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
         

           
        }


     //изменение размеров
                //Отоборажение квадратов для изменения размера холста
        protected void Paint1(object sender,PaintEventArgs e)
        {

            if (!isDraging)
            {
               
                    Graphics g = e.Graphics;
                    int squareSize = 5;

                    rect1 = new Rectangle(new Point(pictureBox1.Right, pictureBox1.Top + (pictureBox1.Bottom - pictureBox1.Top) / 2), new Size(squareSize, squareSize));
                    rect2 = new Rectangle(new Point(pictureBox1.Left + (pictureBox1.Right - pictureBox1.Left) / 2, pictureBox1.Bottom), new Size(squareSize, squareSize));
                    rect3 = new Rectangle(new Point(pictureBox1.Right, pictureBox1.Bottom - squareSize), new Size(squareSize, squareSize));

                    g.DrawRectangle(new Pen(Color.Red), rect1);
                    g.DrawRectangle(new Pen(Color.Red), rect2);
                    g.DrawRectangle(new Pen(Color.Red), rect3);
                
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {



            if (e.Location.X < rect1.Right && e.Location.X > rect1.Left && e.Location.Y < rect1.Bottom && e.Location.Y > rect1.Top)
            {
                Cursor.Current = Cursors.SizeWE;
            }
            else if (e.Location.X < rect2.Right && e.Location.X > rect2.Left && e.Location.Y < rect2.Bottom && e.Location.Y > rect2.Top)
            {
                Cursor.Current = Cursors.SizeNS;
            }
            else if (e.Location.X < rect3.Right && e.Location.X > rect3.Left && e.Location.Y < rect3.Bottom && e.Location.Y > rect3.Top)
            {
                Cursor.Current = Cursors.SizeNWSE;
            }



            if (onlyY && isDraging && onlyX)
            {
                resizeX= e.X - pictureBox1.Right;
                resizeY= e.Y - pictureBox1.Bottom; 
                pictureBox1.Width += resizeX;
                pictureBox1.Height += resizeY;
                pictureBox1.Image = null;
              
            }
            else if (onlyX&&isDraging)
            {
                resizeX = e.X - pictureBox1.Right;
                pictureBox1.Width += resizeX;
                pictureBox1.Image = null;
            }
            else if (onlyY && isDraging)
            {
                resizeY = e.Y - pictureBox1.Bottom;
                pictureBox1.Height += resizeY;
                pictureBox1.Image = null;
            }



            SetSizeBoxes();



        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Location.X < rect1.Right && e.Location.X > rect1.Left && e.Location.Y < rect1.Bottom && e.Location.Y > rect1.Top && e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.SizeWE;
                onlyX = true;
                isDraging = true;
            }
            else if (e.Location.X < rect2.Right && e.Location.X > rect2.Left && e.Location.Y < rect2.Bottom && e.Location.Y > rect2.Top && e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.SizeNS;
                onlyY = true;
                isDraging = true;
            }
            else if (e.Location.X < rect3.Right && e.Location.X > rect3.Left && e.Location.Y < rect3.Bottom && e.Location.Y > rect3.Top && e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.SizeNWSE;
                onlyX = true;
                onlyY = true;
                isDraging = true;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDraging = false;
            onlyY = false;
            onlyX = false;
            
            pictureBox1.Image=controller.ResizeMap(pictureBox1.Width,pictureBox1.Height);

            panel1.Invalidate();
        }



        //Ентер
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            if ((e.Control && e.KeyValue=='Z'))
            {
                controller.RestoreState(controller.history.memento.Pop());
            }


            if (isTyping && e.KeyData == Keys.Enter)
            {
                controller.figures.textSet = controller.textSettings;
                isTyping = false;
                controller.figures.Text = controller.VirtualFigures.Text;
                pictureBox1.Image = controller.DrawFigure(mouseX, mouseY);
                controller.figures.Text = null;
                listView1.Items[4].Selected = false;
                listView1.Items[4].Selected = true;

            }

        }
        //Работа с текстом 
        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
         
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.textSettings.Size =Convert.ToInt32(comboBox3.Items[comboBox3.SelectedIndex]);
            controller.textSettings.CreateNewFont();
            controller.VirtualFigures.textSet = controller.textSettings;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            controller.textSettings.name = comboBox4.Items[comboBox4.SelectedIndex].ToString();
            controller.textSettings.CreateNewFont();
            controller.VirtualFigures.textSet = controller.textSettings;
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int item in listView3.SelectedIndices)
            {
                if (item == 0)
                {
                    controller.textSettings.fontStyle[0]=FontStyle.Bold;
                }         
               else if(item == 1)
                {
                    controller.textSettings.fontStyle[1]=FontStyle.Italic;

                }
          
               else if(item == 2)
                {
                    controller.textSettings.fontStyle[2]=FontStyle.Underline;

                }
                controller.textSettings.CreateNewFont();
                controller.VirtualFigures.textSet = controller.textSettings;
            }
        }

       // Создать новый холст
        private void createNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

            DialogResult result1 = MessageBox.Show("Do you want to save file? ", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result1 == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click(sender, e);
                NewPaint();


            }
            else if (result1 == DialogResult.No)
            {

                NewPaint();

            }
            else
            {
                

            }
        }
    }
   
        


}
