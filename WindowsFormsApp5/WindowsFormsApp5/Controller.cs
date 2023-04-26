using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Model;

namespace WindowsFormsApp5
{
    class Controller
    {
       public int HowToFind { get; set; }
        public string GetBook(string bookname)
        {
            switch (HowToFind)
            {
                case 1:
                    {
                        Database db = new Database("1.xml");
                        Book rez = db.Find(bookname);

                        if (rez != null)
                        {
                            return rez.ToString();
                        }
                        return "Книга не найдена!"; 
                    }
                case 2:
                    {
                        Database db = new Database("1.xml");
                        Book rez = db.FindByAuthor(bookname);

                        if (rez != null)
                        {
                            return rez.ToString();
                        }
                        return "Книга не найдена!";
                    }
                    default:return "Error";
                   
            }
        
        }
    }
}
