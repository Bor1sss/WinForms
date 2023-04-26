using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AsyncAwait
{
    public partial class Form1 : Form
    {
        List<Employers> employers;
        public int cur;
        public SynchronizationContext uiContext;
        List<Student> students = new List<Student>()
{
    new Student()
    {
        Name = "Иванов Иван Иванович",
        GroupNumber = "Группа 123",
        PhysicsGrade = 4,
        MathGrade = 5,
        ComputerScienceGrade = 5,
        LastExamDate = new DateTime(2023, 4, 20)
    },
    new Student()
    {
        Name = "Петров Петр Петрович",
        GroupNumber = "Группа 123",
        PhysicsGrade = 5,
        MathGrade = 4,
        ComputerScienceGrade = 4,
        LastExamDate = new DateTime(2023, 4, 20)
    },
    new Student()
    {
        Name = "Сидорова Анна Ивановна",
        GroupNumber = "Группа 124",
        PhysicsGrade = 3,
        MathGrade = 5,
        ComputerScienceGrade = 5,
        LastExamDate = new DateTime(2023, 4, 21)
    },
    new Student()
    {
        Name = "Иванова Ольга Петровна",
        GroupNumber = "Группа 124",
        PhysicsGrade = 4,
        MathGrade = 4,
        ComputerScienceGrade = 5,
        LastExamDate = new DateTime(2023, 4, 21)
    },
    new Student()
    {
        Name = "Петрова Екатерина Сергеевна",
        GroupNumber = "Группа 125",
        PhysicsGrade = 5,
        MathGrade = 5,
        ComputerScienceGrade = 4,
        LastExamDate = new DateTime(2023, 4, 22)
    },
    new Student()
    {
        Name = "Сидоров Иван Андреевич",
        GroupNumber = "Группа 125",
        PhysicsGrade = 4,
        MathGrade = 4,
        ComputerScienceGrade = 4,
        LastExamDate = new DateTime(2023, 4, 22)
    },
    new Student()
    {
        Name = "Кузнецов Павел Владимирович",
        GroupNumber = "Группа 126",
        PhysicsGrade = 3,
        MathGrade = 4,
        ComputerScienceGrade = 5,
        LastExamDate = new DateTime(2023, 4, 23)
    },
    new Student()
    {
        Name = "Никитина Анна Александровна",
        GroupNumber = "Группа 126",
        PhysicsGrade = 5,
        MathGrade = 5,
        ComputerScienceGrade = 5,
        LastExamDate = new DateTime(2023, 4, 23)
    },
    new Student()
    {
        Name = "Антонов Игорь Викторович",
        GroupNumber = "Группа 127",
        PhysicsGrade = 4,
        MathGrade = 5,
        ComputerScienceGrade = 3,
        LastExamDate = new DateTime(2023, 4, 24)
    } };
 
        public Form1()
        {
            InitializeComponent();
            uiContext = SynchronizationContext.Current;
            employers =new List<Employers>();

            Employers emp1 = new Employers("John", "Smith", "123 Main Street", new DateTime(1985, 3, 15));
            employers.Add(emp1);

            Employers emp2 = new Employers("Mary", "Johnson", "456 Oak Avenue", new DateTime(1990, 6, 28));
            employers.Add(emp2);

            Employers emp3 = new Employers("Peter", "Lee", "789 Pine Street", new DateTime(1982, 2, 10));
            employers.Add(emp3);

            Employers emp4 = new Employers("Sarah", "Kim", "321 Elm Street", new DateTime(1995, 4, 3));
            employers.Add(emp4);

            Employers emp5 = new Employers("Michael", "Chen", "654 Maple Avenue", new DateTime(1988, 11, 20));
            employers.Add(emp5);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                listBox1.Items.Clear();
                cur = 1;
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                foreach (var item in employers)
                {
                    listBox1.Items.Add(item);
                }
            }
            else if(radioButton2.Checked)
            {
                listBox1.Items.Clear();
                cur = 2;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                foreach (var item in employers)
                {
                    listBox1.Items.Add(item);
                }
            }
            else if (radioButton3.Checked)
            {
                listBox1.Items.Clear();
                cur = 3;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

                foreach (var item in students)
                {
                    listBox1.Items.Add(item);
                }
            }
            else if (radioButton4.Checked)
            {
                listBox1.Items.Clear();
                cur = 4;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
            }
            else if (radioButton5.Checked)
            {
                listBox1.Items.Clear();
                cur = 5;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = true;
            }


        }

    
        private async void button1_Click(object sender, EventArgs e)
        {
            switch (cur)
            {
                case 1:
                    await Task.Run(() =>
                    {

                        foreach (var item in employers)
                        {
                            if (item.Address.Contains(textBox1.Text))
                            {
                                uiContext.Send(d => listBox1.Items.Clear(), null);

                                uiContext.Send(d => listBox1.Items.Add(item), null);

                                // Подсчёт среднего возраста дополнительно

                            }

                        }

                    }); break;
                case 2:
                    await Task.Run(() =>
                    {

                        foreach (var item in employers)
                        {
                            if (item.DateBirthday.ToString().Contains(textBox2.Text))
                            {
                                uiContext.Send(d => listBox1.Items.Clear(), null);

                                uiContext.Send(d => listBox1.Items.Add(item), null);
                            }

                        }

                    }); break;
                case 3:
                    await Task.Run(() =>
                    {

                        foreach (var item in students)
                        {
                            if (item.LastExamDate.ToString().Contains(textBox3.Text))
                            {
                                uiContext.Send(d => listBox1.Items.Clear(), null);

                                uiContext.Send(d => listBox1.Items.Add(item), null);
                            }

                        }

                    }); break;
                case 4:
                    await Task.Run(() =>
                    {

                        foreach (var item in employers)
                        {
                            if (item.Address.Contains(textBox1.Text))
                            {
                                uiContext.Send(d => listBox1.Items.Clear(), null);

                                uiContext.Send(d => listBox1.Items.Add(item), null);
                            }

                        }

                    }); break;
                case 5:
                    await Task.Run(() =>
                    {

                        foreach (var item in employers)
                        {
                            if (item.Address.Contains(textBox1.Text))
                            {
                                uiContext.Send(d => listBox1.Items.Clear(), null);

                                uiContext.Send(d => listBox1.Items.Add(item), null);
                            }

                        }

                    }); break;


                default:
                    break;
            }
            
      
          
        }
    }

    public class Employers
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime DateBirthday { get; set; }

        public Employers(string name, string surname, string address, DateTime dateBirthday)
        {
            Name = name;
            Surname = surname;
            Address = address;
            DateBirthday = dateBirthday;
        }
        public string GetInitals()
        {
            return $"{Address}  Date {DateBirthday}";
           
        }
        public override string ToString()
        {
            return $"{Name} {Surname}  ||  {GetInitals()}";
        }

    }


    public class Student
    {
        public string Name { get; set; }
        public string GroupNumber { get; set; }
        public int PhysicsGrade { get; set; }
        public int MathGrade { get; set; }
        public int ComputerScienceGrade { get; set; }
        public DateTime LastExamDate { get; set; }
        public override string ToString()
        {
            return $"ФИО: {Name}\n" +
                   $"Номер группы: {GroupNumber}\n" +
                   $"Оценка по физике: {PhysicsGrade}\n" +
                   $"Оценка по математике: {MathGrade}\n" +
                   $"Оценка по информатике: {ComputerScienceGrade}\n" +
                   $"Дата сдачи последнего экзамена: {LastExamDate.ToShortDateString()}";
        }

    }

}
