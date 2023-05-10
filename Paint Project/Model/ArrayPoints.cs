using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Paint_Project
{
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


    class Line
    {
        private int index = 0;
        private Point points;
        private Point StartPoints;

        public Line(int size)
        {

            points = new Point();
            StartPoints=new Point();
        }
        public void SetPoint(int x, int y)
        {
           
            points = new Point(x, y);
            index++;
        }
        public void SetStartPoint(int x, int y)
        {
     
            StartPoints= new Point(x, y);
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
        public Point GetPoints()
        {
            return points;
        }
        public Point GetStartPoints()
        {
            return StartPoints;
        }
        Size size = new Size();

        public void PointsSwap()
        {
            Point buff = new Point();
            buff = points;
            points = StartPoints;
            StartPoints=buff; 
        }
        public Rectangle GetReact()
        {
            Rectangle rectangle = new Rectangle();
            size.Width = GetPoints().X - GetStartPoints().X;
            size.Height = GetPoints().Y - GetStartPoints().Y;
            rectangle.Y = GetStartPoints().Y;
            rectangle.X = GetStartPoints().X;
            if (size.Width < 0&& size.Height < 0)
            {
                rectangle.X = GetPoints().X;
                rectangle.Y = GetPoints().Y;
                size.Width *= -1;
                size.Height *= -1;
            }
            else if (size.Width < 0 )
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
    }

}
