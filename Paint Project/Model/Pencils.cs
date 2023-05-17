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
    //Кисть отвечает за цвета заливку размер
    class Pencils
    {

        Color color = Color.Black;

        Color inColor= Color.Red;

       public float Size { get; set; } = 1.0f;
        public Pen pen { get; set; }
        
        public Brush Brush { get; set; }

        public bool NoInColor = true;
        public Pencils()
        {
            pen=new Pen(color,Size);
           

            Brush=new SolidBrush(Color.Transparent);
          
            //pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        }
        public void SetNoInColor(int index)
        {
            if (index == 0)
            {
                NoInColor = true;
            }
            else
            {
                NoInColor = false;
            }
        }
        public void SetBrush(int index)
        {
            switch (index)
            {
                case 0: pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid; break;
                case 1: pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash; break;
                case 2: pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot; break;
                case 3: pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot; break;
                default:
                    break;
            }
        }

        public void SetColor(Color color)
        {
            this.color= color;
            pen.Color= color;
        }
        public void SetInColor(Color color)
        {
            if (!NoInColor)
            {
                this.inColor = color;
                Brush = new SolidBrush(color);
            }
            
           
        }
        public void SetSize(float size)
        {
            Size=size;
            pen.Width = size;
        }
    }
}
