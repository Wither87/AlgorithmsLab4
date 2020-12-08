using System;
using System.Diagnostics;
using System.IO;

namespace AlgorithmsLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileListFromDirectory = Directory.GetFiles(@"..\..\Texts");
            foreach (var item in fileListFromDirectory)
            {
                TestSelectionSort(item);
                Console.WriteLine("\n");
                TestHoareSort(item);
                Console.WriteLine("\n");
            }
        }

        private static Stopwatch sw = new Stopwatch();
        private static void TestHoareSort(string filePath)
        {
            string[] text = ReadFile(filePath);
            sw.Start();
            Sort.HoareSort(text, 0, text.Length - 1);
            sw.Stop();
            PrintSortResult(text);
            sw.Reset();
        }

        private static void TestSelectionSort(string filePath)
        {
            string[] text = ReadFile(filePath);
            sw.Start();
            Sort.SelectionSort(text);
            sw.Stop();
            PrintSortResult(text);
            sw.Reset();
        }

        private static string[] ReadFile(string filePath)
        {
            char[] charsForSplitting = new char[] { ' ', ',', '.', '«', '»', '”', '"', '\n', '\t', '—', '-', '(', ')' };
            string[] text = File.ReadAllText(filePath).Split(charsForSplitting, StringSplitOptions.RemoveEmptyEntries);
            return text;
        }
        private static void PrintSortResult(string[] text)
        {
            foreach (var item in text)
                Console.Write(item + " ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + sw.ElapsedTicks + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
