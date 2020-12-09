using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace AlgorithmsLab4
{
    class Program
    {
        private static Stopwatch sw = new Stopwatch();
        private static Dictionary<string, int> uniqueWords = new Dictionary<string, int>();
        private static string[] text;
        private static string textsLocationPath = @"..\..\Texts";
        static void Main(string[] args)
        {
            string[] fileListFromDirectory = Directory.GetFiles(textsLocationPath);
            foreach (var file in fileListFromDirectory)
            {
                Console.Write($"File :\t");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Path.GetFileName(file));
                Console.ForegroundColor = ConsoleColor.Gray;

                TestSelectionSort(file);
                TestHoareSort(file);
                SortedTextWriteInFile(Path.GetFileName(file));
                UniqueWordsCounting();
                UniqueWordsWriteInFile(Path.GetFileName(file));
                uniqueWords.Clear();
                Console.WriteLine("\n");
            }
        }

        private static void TestSelectionSort(string filePath)
        {
            text = ReadFile(filePath);
            LowercaseConversion(text);
            sw.Start();
            Sort.SelectionSort(text);
            sw.Stop();
            Console.Write("SelectionSort working time :\t");
            PrintWorkingTime(sw.ElapsedTicks);
            sw.Reset();
        }
        private static void TestHoareSort(string filePath)
        {
            text = ReadFile(filePath);
            LowercaseConversion(text);
            sw.Start();
            Sort.HoareSort(text, 0, text.Length - 1);
            sw.Stop();
            Console.Write("HoareSort working time :\t");
            PrintWorkingTime(sw.ElapsedTicks);
            sw.Reset();
        }

        private static void PrintWorkingTime(long ticks)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(ticks);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string[] ReadFile(string filePath)
        {
            char[] charsForSplitting = new char[] { ' ', ',', '.', '«', '»', '”', '"', '\r', '\n', '\t', '—', '-', '(', ')' };
            string[] text = File.ReadAllText(filePath).Split(charsForSplitting, StringSplitOptions.RemoveEmptyEntries);
            return text;
        }
        
        private static void UniqueWordsCounting()
        {
            foreach (var word in text)
            {
                if (!uniqueWords.ContainsKey(word))
                {
                    uniqueWords.Add(word, 1);
                }
                else
                {
                    uniqueWords[word]++;
                }
            }
        }

        private static void UniqueWordsWriteInFile(string textFileName)
        {
            string directoryPath = $@"{textsLocationPath}\UniqueWords";
            string filePath = $@"{directoryPath}\Unique words from {textFileName}";

            CreateDirectory(directoryPath);
            CreateFile(filePath);

            using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8))
            {
                foreach (var word in uniqueWords)
                    sw.WriteLine($"{word.Key} : {word.Value}");
            }
        }

        private static void SortedTextWriteInFile(string textFileName)
        {
            string directoryPath = $@"{textsLocationPath}\SortedTexts";
            string filePath = $@"{directoryPath}\Sorted text from {textFileName}";

            CreateDirectory(directoryPath);
            CreateFile(filePath);

            using (StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8))
            {
                foreach(var word in text)
                    sw.Write(word + " ");
            }
        }

        private static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            else
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }
        }

        private static void LowercaseConversion(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
                text[i] = text[i].ToLower();
        }

        private static void PrintSortedText(string[] text)
        {
            foreach (var word in text)
                Console.Write(word + " ");
        }
        private static void PrintUniqueWords()
        {
            foreach (var word in uniqueWords)
                Console.WriteLine($"{word.Key} : {word.Value}");
        }
    }
}
