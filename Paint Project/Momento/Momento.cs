using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Paint_Project
{



    class Memento
    {
        public Bitmap bitmap { get; set; }

       
        public Memento(Bitmap bitmap)
        {
            this.bitmap = bitmap;
           
        }
    }

    class Caretaker
    {
        public Stack<Memento> memento { get; set; }
        MemoryStream memoryStream = new MemoryStream();
        public Caretaker()
        {
            memento = new Stack<Memento>();
        }
        public void Save(Memento mem)
        {
            memento.Push(mem);
        }
        public void SaveFile()
        {
            int a = 1;
            foreach (var item in memento)
            {
                item.bitmap.Save($"{a}.jpg");
                a++;
            }
        }
    }
  
}
