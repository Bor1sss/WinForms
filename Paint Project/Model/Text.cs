using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint_Project
{

    //Настройки текста 
    class TextSettings
    {
        public int Size { get; set ; }
        public Font font { get; set; }

        public string name { get; set; }
        public FontFamily FontFamily { get; set; }
        public List<FontStyle> fontStyle { get; set; }
        public TextSettings()
        {

            Size = 12;
            FontFamily= new FontFamily("Arial");
           
            fontStyle=new List<FontStyle>();
            fontStyle.Add(FontStyle.Regular);
            fontStyle.Add(FontStyle.Regular);
            fontStyle.Add(FontStyle.Regular);
            font = new Font(FontFamily, Size, fontStyle[0]);

        }

       
        public void CreateNewFont()
        {
            font = new Font(name, Size, fontStyle[0] | fontStyle[1] | fontStyle[2]);
        }

    }
}
