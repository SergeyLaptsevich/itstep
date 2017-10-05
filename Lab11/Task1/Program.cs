using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    //на скорую руку
    class Program
    {
        static int[,] RandomIntArray(int rows_count, int columns_count)
        {
            int[,] result = new int[rows_count, columns_count];
            Random rand = new Random();

            for (int i = 0; i < rows_count; i++)
                for (int j = 0; j < columns_count; j++)
                    result[i, j] = rand.Next(10);

            return result; 
        }

        static double[,] RandomDoubleArray(int rows_count, int columns_count)
        {
            double[,] result = new double[rows_count, columns_count];
            Random rand = new Random();

            for (int i = 0; i < rows_count; i++)
                for (int j = 0; j < columns_count; j++)
                    result[i, j] = Math.Round(rand.NextDouble(), 2);

            return result;
        }

        static void PrintArray<T>(T[,] arr, int rows_count, int col_count)
        {
            for (int i = 0; i < rows_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
        }

        static void WriteArray<T>(StreamWriter sw, T[,] arr, int rows_count, int col_count)
        {
            for (int i = 0; i < rows_count; i++)
            {
                for (int j = 0; j < col_count; j++)
                    sw.Write(arr[i, j] + " ");
                sw.WriteLine();
            }
        }

        static void DataInput(out string fio, out string birthday, out int ints_rows_count, out int ints_columns_count,
            out int[,] ints, out int doubles_rows_count, out int doubles_columns_count, out double[,] doubles)
        {
            Console.Write("Введите ФИО: ");
            fio = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            birthday = Console.ReadLine();

            Console.Write("Введите количество строк в массиве целых чисел: ");
            ints_rows_count = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество колонок в массиве целых чисел: ");
            ints_columns_count = Convert.ToInt32(Console.ReadLine());

            ints = RandomIntArray(ints_rows_count, ints_columns_count);
            Console.WriteLine("Сгенерированный массив целых чисел: ");
            PrintArray<int>(ints, ints_rows_count, ints_columns_count);

            Console.Write("Введите количество строк в массиве вещественных чисел: ");
            doubles_rows_count = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество колонок в массиве вещественных чисел: ");
            doubles_columns_count = Convert.ToInt32(Console.ReadLine());

            doubles = RandomDoubleArray(doubles_rows_count, doubles_columns_count);
            Console.WriteLine("Сгенерированный массив вещественных чисел: ");
            PrintArray<double>(doubles, doubles_rows_count, doubles_columns_count);
        }

        static void Write(String fileName)
        {
            Console.Clear();
            if (!File.Exists(fileName))
                Console.WriteLine($"Файл {fileName} не обнаружен, будет создан новый.");
            else
                Console.WriteLine($"Файл {fileName} обнаружен, будет перезаписан.");

            String fio, birthday;
            int ints_rows_count, ints_columns_count, doubles_rows_count, doubles_columns_count;
            int[,] ints;
            double[,] doubles;

            DataInput(out fio, out birthday, out ints_rows_count, out ints_columns_count, out ints, out doubles_rows_count, out doubles_columns_count, out doubles);

            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                sw.WriteLine(fio + " " + birthday);

                sw.WriteLine(doubles_rows_count + " " + doubles_columns_count);
                WriteArray<double>(sw, doubles, doubles_rows_count, doubles_columns_count);

                sw.WriteLine(ints_rows_count + " " + ints_columns_count);
                WriteArray<int>(sw, ints, ints_rows_count, ints_columns_count);

                sw.Write(DateTime.Now.ToShortDateString());
            }
        }


        static void ReadFioBirthday(StreamReader sr, out string fio, out string birth)
        {
            string line = sr.ReadLine();
            string[] splited = line.Split(' ');

            birth = splited.Last();
            fio = "";
            for (int i = 0; i < splited.Length - 1; i++)
                fio += splited[i];
        }

        static T[,] ReadArray<T>(StreamReader sr, out int rows_count, out int col_count)
        {
            String[] splited_line = sr.ReadLine().Split(' ');
            rows_count = int.Parse(splited_line[0]);
            col_count = int.Parse(splited_line[1]);

            T[,] result = new T[rows_count, col_count];

            for(int i = 0; i < rows_count; i++)
            {
                splited_line = sr.ReadLine().Split(' ').Where(o=>o != "").ToArray();
                for(int j = 0; j < splited_line.Length; j++)
                    result[i, j] = (T)Convert.ChangeType(splited_line[j], typeof(T));
            }

            return result;
        }

        static void ReadAndPrint(String fileName)
        {
            Console.Clear();
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Файл {fileName} не обнаружен.");
                return;
            }
                
            String fio, birthday;
            int ints_rows_count, ints_columns_count, doubles_rows_count, doubles_columns_count;

            using (StreamReader sr = new StreamReader(fileName))
            {
                ReadFioBirthday(sr, out fio, out birthday);
                Console.WriteLine($"ФИО: {fio}");
                Console.WriteLine($"Дата рождения: {birthday}");
                Console.WriteLine("Массив вещественных чисел:");
                PrintArray(ReadArray<double>(sr, out doubles_rows_count, out doubles_columns_count), doubles_rows_count, doubles_columns_count);
                PrintArray(ReadArray<int>(sr, out ints_rows_count, out ints_columns_count), ints_rows_count, ints_columns_count);

                Console.WriteLine("Дата сохранения:\n" + Convert.ToDateTime(sr.ReadLine()).ToLongDateString());
            }
        }

        static void Main(string[] args)
        {
            String fileName = "Day17.txt";
            String menu = "1. Записать в файл.\n2. Прочесть из файла.\n3. Выход.\nВыбор: ";
            int choice = 0;
            bool exit = false;

            while(!exit)
            {
                Console.Clear();
                Console.Write(menu);
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        Write(fileName);
                        break;
                    case 2:
                        ReadAndPrint(fileName);
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор");
                        break;
                }

                Console.Write("Для прожолжения нажмите любую клаишу...");
                Console.ReadKey();
            }
            
        }
    }
}
