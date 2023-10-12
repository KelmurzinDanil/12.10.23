using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace _12._10._2023
{
    static class MatrixExt
    {
        // метод расширения для получения количества строк матрицы
        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(0) + 1; // GetUpperBound возвращает индекс последнего элемента
        }

        // метод расширения для получения количества столбцов матрицы
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetUpperBound(1) + 1;
        }
    }
    internal class Program
    {
        static int EnterNumber() // Проверка на число
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
        static int[,] EnterMatrix(out int NumberСolumns, out int NumberRows) // Ввод матрицы
        {
            Console.WriteLine("Введите кол-во строк матрицы: ");
            NumberRows = EnterNumber();
            Console.WriteLine("Введите кол-во столбцов матрицы: ");
            NumberСolumns = EnterNumber();
            int[,] matrix = new int[NumberRows, NumberСolumns];
            for (var i = 0; i < NumberRows; i++)
            {
                for (var j = 0; j < NumberСolumns; j++)
                {
                    matrix[i, j] = EnterNumber();
                    Console.WriteLine($"Элемент:{i + 1} {j + 1}, считается с лева на право для каждой строки\t", matrix[i, j]);
                }
            }
            return matrix;
        }
        static void PrintMatrix(int[,] matrix) // Вывод матрицы на консоль
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4)); // PadLeft - метод выравнивания символов в строке по правому краю путем заполнения их пробелами
                }

                Console.WriteLine();
            }
        }
        static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2) // Умножение матриц
        {
            int[,] matrix3 = new int[matrix1.RowsCount(), matrix2.ColumnsCount()];
            try
            {
                for (int i = 0; i < matrix1.RowsCount(); i++)
                {
                    for (int j = 0; j < matrix2.ColumnsCount(); j++)
                    {
                        matrix3[i, j] = 0;

                        for (int k = 0; k < matrix1.ColumnsCount(); k++)
                        {
                            matrix3[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\"Умножение не возможно! Кол-во столбцов первой матрицы не равно кол-ву строк второй матрицы.\"");
            }

            return matrix3;
        }
        static void VowelsAndConsonants(params char[] chars) //Кол-во согласных и несогласных букв
        {
            int vowels = 0;
            int consonants = 0;
            for (int i = 0; i < chars.Length; i++)
            {

                if (chars[i] == 'a' || chars[i] == 'у' ||
                    chars[i] == 'о' || chars[i] == 'ы' ||
                    chars[i] == 'и' || chars[i] == 'э' ||
                    chars[i] == 'я' || chars[i] == 'ю' ||
                    chars[i] == 'ё' || chars[i] == 'е' ||
                    chars[i] == 'й')
                {
                    vowels++;
                }
                else if (chars[i] >= 'а' && chars[i] <= 'я')
                {
                    consonants++;
                }

            }
            Console.WriteLine("Гласных: " + vowels);
            Console.WriteLine("Согласных: " + consonants);

        }
        static double[] AvargeTemp(int[,] temperature) // Средняя температура
        {

            double[] avargeArr = new double[temperature.GetLength(0)];
            for (int i = 0; i < temperature.GetLength(0); i++)
            {
                double sum = 0;
                for (int j = 0; j < temperature.GetLength(1); j++)
                {
                    sum += temperature[i, j];
                }
                avargeArr[i] = Math.Round(sum / temperature.GetLength(0), 3);
            }
            return avargeArr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("1. Написать программу, которая вычисляет число гласных и согласных букв в\r\nфайле.");
            string path = @"E:\ОченьВажныйФайл\ОченьВажныйДокумент.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
                string textLower = text.ToLower();
                char[] chars = textLower.ToCharArray();
                VowelsAndConsonants(chars);
            }

            Console.WriteLine();

            Console.WriteLine("2. Умножение матрицы, ее ввод и вывод");

            Console.WriteLine("Ввод первой матрицы:");
            int[,] matrix1 = EnterMatrix(out int NumberСolumns1, out int NumberRows1);
            PrintMatrix(matrix1);
            Console.WriteLine("Ввод второй матрицы:");
            int[,] matrix2 = EnterMatrix(out int NumberСolumns2, out int NumberRows2);
            PrintMatrix(matrix2);
            Console.WriteLine("Ответ: ");
            PrintMatrix(MatrixMultiplication(matrix1, matrix2));

            Console.WriteLine();

            Console.WriteLine("3.Написать программу, вычисляющую среднюю температуру за год. Создать\r\nдвумерный рандомный массив temperature[12,30] ");
            int[,] temperature = new int[12, 30];
            Random ran = new Random();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    temperature[i, j] = ran.Next(-30, 30);
                }
            }
            double[] avargeArr = AvargeTemp(temperature);
            Array.Sort(avargeArr); // Array.Sort сортирует элементы одномерного массива
            Console.WriteLine("Массив средних температур по месяцам, отсортированный по возрастанию");
            Console.WriteLine(String.Join(" ", avargeArr));

            Console.WriteLine();

            Console.WriteLine("4. Упражнение 1 выполнить с помощью коллекции List<T>.");
            string path2 = @"E:\ОченьВажныйФайл\ОченьВажныйДокумент.txt";
            using (StreamReader reader = new StreamReader(path2))
            {
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
                string textLower = text.ToLower();
                char[] letter = textLower.ToCharArray();
                List<char> ListText = new List<char>();
                // Закидываем массив символов в List<>
                ListText.AddRange(letter);
                int vowels = 0;
                int consonants = 0;
                for (int i = 0; i < ListText.Count; i++)
                {
                    if (ListText[i] == 'а' || ListText[i] == 'о' ||
                    ListText[i] == 'у' || ListText[i] == 'ы' ||
                    ListText[i] == 'и' || ListText[i] == 'й' ||
                    ListText[i] == 'е' || ListText[i] == 'ё' ||
                    ListText[i] == 'я' || ListText[i] == 'ю' ||
                    ListText[i] == 'э')
                    {
                        vowels++;
                    }
                    else if (ListText[i] >= 'а' && ListText[i] <= 'я')
                    {
                        consonants++;
                    }
                }
                Console.WriteLine("Гласных: " + vowels);
                Console.WriteLine("Согласных: " + consonants);
            }

            Console.WriteLine();

            Console.WriteLine("6.Написать программу для упражнения 6.3, использовав класс\r\nDictionary<TKey, TValue>. ");
            Dictionary<string, int[]> keyValuePairs = new Dictionary<string, int[]>();
            string[] monthNames = DateTimeFormatInfo.CurrentInfo.MonthNames;
            Random random = new Random();
            for (int i = 0; i < monthNames.Length - 1; i++)
            {
                int[] arr = new int[30];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = random.Next(-30, 30);
                }
                keyValuePairs.Add(monthNames[i], arr);
            }
            foreach (var row in keyValuePairs)
            {
                Console.WriteLine($"{row.Key}: {String.Join(" ", row.Value)}");
            }

            Console.ReadKey();
        }

    }
}
