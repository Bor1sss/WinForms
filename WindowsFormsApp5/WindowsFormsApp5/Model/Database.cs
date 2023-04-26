using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace WindowsFormsApp5.Model
{
    class Database
    {
        List<Book> books = new List<Book>();
       

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Book>));

        
        public Database()
        {
           
        }

        public void CreateExample()
        {
            books.Add(new Book("CLR via C#", "Jefry Richter"));
            books.Add(new Book("Эмоциональный интеллект", "Дэниел Гоулман"));
            books.Add(new Book("С++", "Бьярне Страуструп"));
            books.Add(new Book("ТРИЗ", "Марк Меерович"));
            using (FileStream fs = new FileStream("1.xml", FileMode.OpenOrCreate))
            {
              
                   xmlSerializer.Serialize(fs, books);
                
             

               
            }
        }
        public Database(string BaseName)
        {
            //CreateExample();
            using (FileStream fs = new FileStream(BaseName, FileMode.OpenOrCreate))
            {

                List<Book> booksS= xmlSerializer.Deserialize(fs) as List<Book>;

                if (books != null)
                {
                        books= booksS;
                }




            }


        }
        public Book Find(string bookName)
        {


           foreach (var item in books)
            {
                if(item.Name.ToLower()==(bookName.ToLower()))
                {
                    return item;
                }
              
              
            }

            return null;

        }
        public Book FindByAuthor(string Author)
        {

            foreach (var item in books)
            {
                if (item.Author.ToLower()==(Author.ToLower()))
                {
                    return item;
                }
                
                   
                
            }
            return null;
        }
        

    }
}
