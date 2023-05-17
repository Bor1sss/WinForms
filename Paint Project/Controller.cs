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

    // Контролер  в MVC
    class Controller
    {
       
        public TextSettings textSettings=new TextSettings();

        //Кисть
        public ArrayPoints arrayPoints = new ArrayPoints(2);

        //Фигуры и виртуальные фигуры
        public Figures figures;
        public Figures VirtualFigures=new VirtualLine(2);



        public Bitmap map = new Bitmap(100, 100);





        public Graphics graphics;

        public Pencils pencils;

        //в разработке
        public Caretaker history = new Caretaker();


        // Сохранить изображение
        public void Save()
        {
            Bitmap buff = map.Clone() as Bitmap;
            history.Save(new Memento(buff));
            history.SaveFile();
            MessageBox.Show("Save");
        }


        //В разработке
        public void RestoreState(Memento memento)
        {

            history.SaveFile();

            map = memento.bitmap;

            graphics = Graphics.FromImage(memento.bitmap);

            graphics.DrawImage(map, 0, 0);

          


        }
   

     
       


        
        public int Type { get; set; } = 1;

     

        public Controller()
        {
            pencils = new Pencils();

            


        }

       //Отдалить
        public Bitmap ZoomOut(PictureBox pic)
        {
           
            return map;
        }
        // Приблизить
        public Bitmap ZoomIn()
        {
          
            return map;
        }

        //Установить начальные координаты 
        public void SetStart(int x, int y)
        {
            if (Type == 1)
            {
                arrayPoints.SetPoint(x, y);
            }
            else
            {
                figures.SetStartPoint(x, y);
            }
        }

        //Обнулить
        public void Reset()
        {
            if (Type == 1)
            {
                arrayPoints.ResetPoints();
            }
            else
            {
                figures.ResetPoints();
            }
        }

        //Устанавливает размер холста по картинке 
        public void SetSize(PictureBox picture)
        {
            Rectangle rectangle =picture.ClientRectangle;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            
            graphics = Graphics.FromImage(map);
            Pen penbuff = new Pen(Color.Transparent);
            graphics.DrawRectangle(penbuff,rectangle);
            graphics.FillRectangle(Brushes.White, rectangle);
            
        }

        //Устанавлвает точки виртуальных фигур
        public void SetVirtualLine(int X,int Y)
        {
            VirtualFigures.SetPoint(X, Y);
        }
        public void SetStartVirtualLine(int X, int Y)
        {
            VirtualFigures.SetStartPoint(X, Y);
        }



        // Отвечает за отрисовку и передачу координат
        public Bitmap Draw(int X, int Y)
        {

            if (Type == 1)
            {

                arrayPoints.SetPoint(X, Y);
                graphics.DrawLine(pencils.pen, arrayPoints.GetPoints()[0], arrayPoints.GetPoints()[1]);
                    arrayPoints.SetPoint(X, Y);
                    return map;
                
             
            }
            else
            {
                figures.SetPoint(X, Y);
                return map;
            }

           
        }
     

        // Отвичает не посредственно за рисование на image
        public Bitmap DrawFigure(int X,int Y)
        {
       
            figures.SetPoint(X, Y);
            Parallel.Invoke(() =>
            {
                    //graphics.DrawLine(pencils.pen, figures.GetStartPoints(), figures.GetPoints());
                    figures.Draw(graphics, pencils);
            });

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


        //Изменяет Размер картинки
        public Bitmap ResizeMap(int W,int H)
        {
            Bitmap resizeMap=new Bitmap(map);
            map= new Bitmap(map,W,H);
            graphics = Graphics.FromImage(map);
            graphics.Clear(Color.White);
            graphics.DrawImageUnscaled(resizeMap,0,0);
           
            return map;
          
          
        }

        //Сохраняет картинку 
        public void Save(string f)
        {
            
            map.Save(f);
        }

        //Загружает картинку 
        public void Load(string filename)
        {
            map = new Bitmap(filename);
            
            graphics = Graphics.FromImage(map);
        }
    }

  


}
