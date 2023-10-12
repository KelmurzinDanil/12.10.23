using System;
using System.Collections.Generic;

namespace HomeWork_5_
{
    internal class Program
    {
        class Student
        {
            public string Family { get; set; }
            public string Name { get; set; }
            public DateTime DOB { get; set; }
            public string Exam { get; set; }
            public uint Scores { get; set; }


            public Student(string f, string n, string d, string e, uint s = 0)
            {
                Family = f;
                Name = n;
                DOB = DateTime.Parse(d);
                Exam = e;
                Scores = s;
            }
        }
       


        static int EnterNumber() // Проверка на целое число
        {
            bool flag = true;
            int number;
            do
            {
                Console.WriteLine("Введите целое число:");
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести целое число");
                }
            }
            while (flag);

            return number;
        }       
        static uint NaturalNumber() // Проверка на натуральность
        {
            bool flag = true;
            uint number;
            do
            {
                Console.WriteLine("Введите натуральное число:");
                bool isNumber = uint.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести натуральное число");
                }
            }
            while (flag);

            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1.Необходимо перемешать List с картинками.");
            string path = "C:\\Прога\\05.10.2023\\HomeWork_5_\\images\\";

            Random random = new Random();
            List<string> list = new List<string>(64);
            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }

            Console.WriteLine();

            Console.WriteLine("");

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                { 1, new Student( "Петров", "Петр", "10.10.2000", "Физика", 250) },
                { 2, new Student( "Иванов", "Иван", "12.09.2003", "Английский", 280) },
                { 3, new Student( "Сидоров", "Сидор", "14.05.2001", "Информатика", 210) },
                { 4, new Student( "Пятаков", "Петя", "24.08.2001", "Физика", 200)},
                { 5, new Student( "Олегов", "Олег", "22.10.2005", "Английский", 291)},
                { 6, new Student( "Орлов", "Лев", "09.10.2005", "Информатика", 191)},
                { 7, new Student( "Данов", "Данил", "02.04.2004", "Английский", 231)},
                { 8, new Student( "Толстой", "Лев", "22.11.2005", "Информатику", 245)},
                { 9, new Student( "Пушкин", "Сергей", "12.06.2005", "Английский", 202)},
                { 10, new Student( "Казакова", "Ольга", "22.01.2003", "Физику", 189)},
            };
          
            Console.WriteLine("Введите свое действие:");
            string measure = Console.ReadLine();
            if ( measure == "Новый студент" )
            {
                Console.WriteLine("Введите информацию о новом студенте:");
                Console.WriteLine("Образец:  \"Пушкин\", \"Сергей\", \"12.06.2005\", \"Английский\", 202 ");
                string f = Console.ReadLine();
                string n = Console.ReadLine();
                string d = Console.ReadLine();
                string e = Console.ReadLine();               
                uint s = NaturalNumber();
                int i = students.Count;
                students.Add(i + 1, new Student(f, n, d, e, s));
               

            }
            else if ( measure == "Удалить")
            {
                Console.WriteLine("Введите студента");
                int deleteId = EnterNumber();
                students.Remove(deleteId);
                
            }
            else if (measure == "Отсортировать")
            {
                
            }
            foreach (KeyValuePair<int, Student> p in students)
                {
                    Console.WriteLine($"Студент Id: {p.Key} " +
                                        $"\n   Фамилия: {p.Value.Family} " +
                                        $"\n   Имя: {p.Value.Name} " +
                                        $"\n   Год рождения: {p.Value.DOB.ToShortDateString()} " +
                                        $"\n   Входной балл: {p.Value.Exam} " +
                                        $"\n   Баллы: {p.Value.Scores}");
                }
            





            Console.ReadKey();
        }
    }
}
