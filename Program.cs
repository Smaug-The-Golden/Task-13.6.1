//Данная программа сравнивает производительность вставки строк в коллекции List<T> и LinkedList<T>
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Task_13._6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = FileSelection();
            int num_iterations = IterationSelection();
            EstimateList(num_iterations, file_path);
            EstimateLinkedList(num_iterations, file_path);
        }
        static string FileSelection()
        {
            ColourPrintBlue("\nУкажите полный путь до тестируемого текстового файла:");
            ///string file_path = Console.ReadLine();
            string file_path = @"C:\Users\Professional\Desktop\Text1.txt";

            if (File.Exists(file_path))
            {
                ColourPrintGreen("\nФайл найден и принят программой.");
                return file_path;
            }
            else
            {
                do
                {
                    ColourPrintRed("\nФайл не найден или не существует.");
                    ColourPrintBlue("\nУкажите полный путь до тестируемого текстового файла еще раз:");
                    file_path = Console.ReadLine();
                }
                while (!File.Exists(file_path));
                {
                    ColourPrintGreen("Файл найден и принят программой.");
                    return file_path;
                }
            }
        }

        static int IterationSelection()
        {
            ColourPrintBlue("\nВведите цифрой количество запусков каждого метода:");
            int num_iterations;
            do
            {
                if (int.TryParse(Console.ReadLine(), out num_iterations) && num_iterations >= 1 && num_iterations <= int.MaxValue)
                {
                    break;
                }
                ColourPrintRed("Вы ввели некорректное значение.\nПожалуйста, введите целое положительное число: ");
            }
            while (true);
            return num_iterations;
        }

        static List<string> WriteToList(string file_path)
        {
            var collection_list = new List<string>();

            foreach (string line in File.ReadLines(file_path))
            {
                collection_list.Add(line);
            }
            //Console.WriteLine($"\nВ коллекцию List<T> добавлено {collection_list.Count} строк.");
            return collection_list;
        }

        static LinkedList<string> WriteToLinkedList(string file_path)
        {
            var collection_linked_list = new LinkedList<string>();

            foreach (string line in File.ReadLines(file_path))
            {
                collection_linked_list.AddLast(line);
            }
            //Console.WriteLine($"\nВ коллекцию LinkedList<T> добавлено {collection_linked_list.Count} строк.");
            return collection_linked_list;
        }

        static void EstimateList(int num_iterations, string file_path)
        {
            var timer = new Stopwatch();
            long[] run_time = new long[num_iterations];
            long avg = 0;
            ColourPrintYellow("\nВычисляю время в мс, затраченное на вставку строки в коллекцию List<T>:");
            timer.Start();

            for (int i = 0; i < run_time.Length; i++)
            {
                Thread.Sleep(500);
                timer.Restart();
                WriteToList(file_path);
                timer.Stop();
                run_time[i] = timer.ElapsedMilliseconds;
                avg = avg + run_time[i];

                ColourPrintYellow(timer.ElapsedMilliseconds.ToString());
            }
            avg = avg / run_time.Length;
            ColourPrintGreen($"\nСреднее арифметическое время вставки строки в коллекцию List<T> составило {avg} мс");
        }

        static void EstimateLinkedList(int num_iterations, string file_path)
        {
            var timer = new Stopwatch();
            long[] run_time = new long[num_iterations];
            long avg = 0;
            ColourPrintYellow("\nВычисляю время в мс, затраченное на вставку строки в коллекцию LinkedList<T>:");
            timer.Start();

            for (int i = 0; i < run_time.Length; i++)
            {
                Thread.Sleep(500);
                timer.Restart();
                WriteToLinkedList(file_path);
                timer.Stop();
                run_time[i] = timer.ElapsedMilliseconds;
                avg = avg + run_time[i];

                ColourPrintYellow(timer.ElapsedMilliseconds.ToString());
            }
            avg = avg / run_time.Length;
            ColourPrintGreen($"\nСреднее арифметическое время вставки строки в коллекцию LinkedList<T> составило {avg} мс");
        }
        static void ColourPrintGreen (string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void ColourPrintRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void ColourPrintYellow(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void ColourPrintBlue(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
