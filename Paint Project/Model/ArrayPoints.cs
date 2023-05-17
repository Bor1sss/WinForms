using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Paint_Project
{
    //Кисть
    class ArrayPoints
    {
        private int index = 0;
        private Point[] points;

        public ArrayPoints(int size)
        {
            if (size <= 0) { size = 2; }
            points = new Point[size];
        }
        public void SetPoint(int x, int y)
        {
            if (index >= points.Length)
            {
                index = 0;

            }
            points[index] = new Point(x, y);
            index++;
        }
        public void ResetPoints()
        {
            index = 0;
        }
        public int GetCountPoints()
        {
            return index;
        }
        public Point[] GetPoints()
        {
            return points;
        }
    }


    // Абстрактный класс фигур
    abstract class Figures
    {
        public TextSettings textSet { get; set; }
        public PictureBox form { get; set; }
        public string Text { get; set; }
        protected int index = 0;
        protected Point points;
        protected Point StartPoints;
        public  void SetPoint(int x, int y)
        {

            points = new Point(x, y);
            index++;
        }
        public  void SetStartPoint(int x, int y)
        {

            StartPoints = new Point(x, y);
            index++;
        }
        public  void ResetPoints()
        {
            index = 0;
        }
        public  int GetCountPoints()
        {
            return index;
        }
        public  Point GetPoints()
        {
            return points;
        }
        public  Point GetStartPoints()
        {
            return StartPoints;
        }
        Size size = new Size();

        //Высчитыает размер 
        public  Rectangle GetReact()
        {
            Rectangle rectangle = new Rectangle();
            size.Width = GetPoints().X - GetStartPoints().X;
            size.Height = GetPoints().Y - GetStartPoints().Y;
            rectangle.Y = GetStartPoints().Y;
            rectangle.X = GetStartPoints().X;
            if (size.Width < 0 && size.Height < 0)
            {
                rectangle.X = GetPoints().X;
                rectangle.Y = GetPoints().Y;
                size.Width *= -1;
                size.Height *= -1;
            }
            else if (size.Width < 0)
            {
                //PointsSwap();
                rectangle.X = GetPoints().X;
                rectangle.Y = GetStartPoints().Y;
                size.Width *= -1;
            }
            else if (size.Height < 0)
            {
                rectangle.X = GetStartPoints().X;
                rectangle.Y = GetPoints().Y;
                size.Height *= -1;
            }




            rectangle.Width = size.Width;
            rectangle.Height = size.Height;
            return rectangle;
        }
        abstract public void Draw(PaintEventArgs e,Pencils pencils);
        abstract public void Draw(Graphics g, Pencils pencils);
      

    }

    //Линия 
    class Line:Figures
    {
        public Line(int size)
        {

            points = new Point();
            StartPoints = new Point();
        }
    
        public override void Draw(PaintEventArgs e,Pencils pencils)
        {
            e.Graphics.DrawLine(pencils.pen,GetStartPoints(),GetPoints());

        }
        public override void Draw(Graphics g, Pencils pencils)
        {
            g.DrawLine(pencils.pen, GetStartPoints(), GetPoints());
        }

    }

    //Прямоугольник
    class Square : Figures
    {
        public Square(int size)
        {

            points = new Point();
            StartPoints = new Point();
        }

        public override void Draw(PaintEventArgs e, Pencils pencils)
        {
            e.Graphics.DrawRectangle(pencils.pen, GetReact());
            e.Graphics.FillRectangle(pencils.Brush, GetReact());
        }
        public override void Draw(Graphics g,Pencils pencils)
        {
            g.DrawRectangle(pencils.pen, GetReact());
            g.FillRectangle(pencils.Brush, GetReact());
        }



    }

    //Элипс
    class Elipse : Figures
    {
        public Elipse(int size)
        {
            points = new Point();
            StartPoints = new Point();
        }
        public override void Draw(PaintEventArgs e, Pencils pencils)
        {
            e.Graphics.DrawEllipse(pencils.pen,GetReact());
            e.Graphics.FillEllipse(pencils.Brush, GetReact());

        }
        public override void Draw(Graphics g, Pencils pencils)
        {
            g.DrawEllipse(pencils.pen, GetReact());
            g.FillEllipse(pencils.Brush, GetReact());
        }
    }


    //Виртуальные фигуры 

    //Виртуальный элипс 
    class VirtualElipse : Figures
    {


        public VirtualElipse(int size)
        {
            points = new Point();
            StartPoints = new Point();
        }
        public override void Draw(PaintEventArgs e, Pencils pencils)
        {
            e.Graphics.DrawEllipse(pencils.pen, GetReact());
            e.Graphics.FillEllipse(pencils.Brush, GetReact());

        }
        public override void Draw(Graphics g, Pencils pencils)
        {
            g.DrawEllipse(pencils.pen, GetReact());
            g.FillEllipse(pencils.Brush, GetReact());
        }
    }

    //Виртуальная линия
    class VirtualLine:Figures
    {
   

        public VirtualLine(int size)
        {
            points = new Point();
            StartPoints = new Point();
        }
        public override void Draw(PaintEventArgs e, Pencils pencils)
        {
            e.Graphics.DrawLine(pencils.pen, GetStartPoints(), GetPoints());

        }
        public override void Draw(Graphics g, Pencils pencils)
        {
            g.DrawLine(pencils.pen, GetStartPoints(), GetPoints());
        }
    }

    //виртуальный квадрат
    class VirtualSquare : Figures
    {


        public VirtualSquare(int size)
        {
            points = new Point();
            StartPoints = new Point();
        }
        public override void Draw(PaintEventArgs e, Pencils pencils)
        {
            e.Graphics.DrawRectangle(pencils.pen, GetReact());
            e.Graphics.FillRectangle(pencils.Brush, GetReact());
        }
        public override void Draw(Graphics g, Pencils pencils)
        {
            g.DrawRectangle(pencils.pen, GetReact());
            g.FillRectangle(pencils.Brush, GetReact());
        }
        public override string ToString()
        {
            return $"{GetStartPoints()}";
        }


    

      
    }



    //Класс текст относиться к фигурам
    class TextString : Figures
    {
        public TextString(int size)
        {
            points = new Point();
            StartPoints = new Point();
        }
        public override void Draw(PaintEventArgs e, Pencils pencils)
        {
            if (Text != null)
            {
               
                e.Graphics.DrawString(Text, textSet.font, new SolidBrush(pencils.pen.Color), GetStartPoints());
            }
        }

        public override void Draw(Graphics g, Pencils pencils)
        {
            if (Text != null)
            {
             
                g.DrawString(Text, textSet.font, new SolidBrush(pencils.pen.Color), GetStartPoints());
            }
        }
    }

    //Виртуальный текст
    class VirtualTextString : Figures
    {
        RichTextBox txtBox;
        bool isSet= false;
        public VirtualTextString(int size,PictureBox pic)
        {

            points = new Point();
            StartPoints = new Point();
            txtBox = new RichTextBox();
            txtBox.Multiline = false;
            txtBox.Height = 24;
            
            txtBox.Visible = false;
            txtBox.KeyDown += GetText;
            txtBox.TextChanged += SetText;
            form = pic;
            form.Controls.Add(txtBox);

            
        }
        public override void Draw(PaintEventArgs e, Pencils pencils)
        {


            txtBox.Height = textSet.Size*2;
            txtBox.Visible = true;
            txtBox.Font= textSet.font;
            txtBox.SelectAll();
            txtBox.SelectionColor = pencils.pen.Color;
            txtBox.Location = GetStartPoints();

        
        }

        public override void Draw(Graphics g, Pencils pencils)
        {

           

          
        }

        public void SetText(object sender,EventArgs e)
        {
            Text = txtBox.Text;
        }
        public void GetText(object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtBox.Text = null;
                txtBox.Visible = false;
            }
        }
    }
}
