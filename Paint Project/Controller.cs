using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Project
{
    class Controller
    {


        public ArrayPoints arrayPoints = new ArrayPoints(2);
        public Line line = new Line(2);



        public Bitmap map = new Bitmap(100, 100);
        public Bitmap buff_map;


        public Graphics graphics;

        public Pencils pencils;
       



        public int Type { get; set; } = 1;

        

        public Controller()
        {
            pencils = new Pencils();
        }
        public Bitmap ZoomOut()
        {
            /*    Bitmap zoomMap = new Bitmap(map, Convert.ToInt32(map.Width / 1.2), Convert.ToInt32(map.Height / 1.2));
                map = zoomMap;*/
            
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics.DrawImage(map, 0, 0, Convert.ToInt32(map.Width / 1.2), Convert.ToInt32(map.Height / 1.2));
            return map;
        }
        public Bitmap ZoomIn()
        {
          /*  Bitmap zoomMap = new Bitmap(map, Convert.ToInt32(map.Width * 1.2), Convert.ToInt32(map.Height * 1.2));
            map = zoomMap;*/
            
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics.DrawImage(map, 0, 0, Convert.ToInt32(map.Width * 1.2), Convert.ToInt32(map.Height * 1.2));
            return map;
        }
        public void SetStart(int x, int y)
        {
            if (Type == 1)
            {
                arrayPoints.SetPoint(x, y);
            }
            else if (Type == 2)
            {
                line.SetStartPoint(x, y);
            }
            else if (Type == 3)
            {
                line.SetStartPoint(x, y);
            }
        }
        public void Reset()
        {
            if (Type == 1)
            {
                arrayPoints.ResetPoints();
            }
            else if (Type == 2)
            {
                line.ResetPoints();
            }
            else if (Type == 3)
            {
                line.ResetPoints();
            }
        }
        public void SetSize(Panel panel)
        {
            Rectangle rectangle = panel.ClientRectangle;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            
            graphics = Graphics.FromImage(map);
            Pen penbuff = new Pen(Color.Transparent);
            graphics.DrawRectangle(penbuff,rectangle);
            graphics.FillRectangle(Brushes.White, rectangle);
            
        }
        public Bitmap Draw(int X, int Y)
        {

            if (Type == 1)
            {

                arrayPoints.SetPoint(X, Y);
                graphics.DrawLine(pencils.pen, arrayPoints.GetPoints()[0], arrayPoints.GetPoints()[1]);
                    arrayPoints.SetPoint(X, Y);
                    return map;
                
             
            }
            else if (Type == 2)
            {
               
                line.SetPoint(X, Y);
                
                return map;
            }
            else if (Type == 3)
            {
                
                line.SetPoint(X, Y);
              
               return map;
                
            }

            return null;
        }
     
        public Bitmap DrawFigure(int X,int Y)
        {
            if (Type == 3)
            {
                line.SetPoint(X, Y);
                Parallel.Invoke(() =>
                {
                    graphics.DrawLine(pencils.pen, line.GetStartPoints(), line.GetPoints());
                   
                //
            });
                return map;
            }
            else if(Type == 2)
            {
                line.SetPoint(X, Y);
                Parallel.Invoke(() =>
                {

          
                    graphics.DrawRectangle(pencils.pen, line.GetReact());
                    graphics.FillRectangle(pencils.Brush, line.GetReact());
                    line.SetPoint(X, Y);

                });
                return map;
            }
            return map;
        }
        public void SetSize(float size)
        {
            pencils.SetSize(size);

        }
        public void SetColor(Color color)
        {
          pencils.SetColor(color);
           
        }

        public void SetInColor(Color color)
        {
            pencils.SetInColor(color);

        }


     public void Save(string f)
        {
            
            map.Save(f);
        }

        public void Load(string filename)
        {
            map = new Bitmap(filename);
            
            graphics = Graphics.FromImage(map);
        }
    }




}
