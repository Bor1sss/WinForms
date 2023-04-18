using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace Thread12
{
    class Program
    {
       
      

     
        static void Main(string[] args)
        {
           
          //  Thread t = Thread.CurrentThread;


            /*  Thread th1 = new Thread(new ParameterizedThreadStart(ThreadParam));
              List<int>list=new List<int> { 1, 2, 3, 4, 5, 6 };

              th1.Start(list);*/

            Bank bank = new Bank();

                bank.SetMoney(1);


           Console.WriteLine("END");

        }
    }

   
    class Bank
    {
        public Thread bankThread = null;

        int money;
        int percent;
        string name;
        public static void WriteToFile(object obj)
        {
            Bank item = (Bank)obj;
            StreamWriter streamWriter = new StreamWriter("1.txt", true);

            streamWriter.Write(item);
            streamWriter.Close();
            Console.WriteLine("File info");

        }
        public void SetMoney(int m)
        {
            Bank bank1 = new Bank();
            bank1.money = m;
            bankThread = new Thread(new ParameterizedThreadStart(WriteToFile));
            bankThread.IsBackground = true;

            bankThread.Start(bank1);
        }
        public Bank()
        {



        }

        public override string ToString()
        {
            return $"Name {name} Money{money} Percent {percent} ";
        }

        public static void ThreadParam(object obj)
        {
            List<int> item = (List<int>)obj;

            foreach (var item2 in item)
            {
                Console.WriteLine(item2);
            }


        }


    }
}
