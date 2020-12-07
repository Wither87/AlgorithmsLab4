using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgorithmsLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            ////string[] text = File.ReadAllText(@"..\..\Texts\Text 1.txt").Split(new char[] { ' ', ',', '.', '«', '»' }, StringSplitOptions.RemoveEmptyEntries);
            ////string[] text = File.ReadAllText(@"..\..\Texts\Text 2.txt").Split(new char[] { ' ', ',', '.', '«', '»' }, StringSplitOptions.RemoveEmptyEntries);

            ////int[] arr = new int[text.Length];
            ////for (int i = 0; i < text.Length; i++)
            ////{
            ////    arr[i] = int.Parse(text[i]);
            ////}

            ////foreach (var item in arr)
            //foreach (var item in text)
            //{
            //    Console.Write(item + " ");
            //}

            //Console.WriteLine("\n\n\n\n");

            ////Sorter.SelectionSort(text);

            //Sorter.HoareSort(text, 0, text.Length - 1);
            ////Sorter.SelectionSort(arr);
            ////foreach (var item in arr)
            //foreach (var item in text)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine("\n\n\n\n");
            //Console.ReadLine();
            #endregion

            TestNumberArray();
            Console.WriteLine("\n\n\n");
            TextStringArray();
            Console.ReadLine();
        }

        private static void TestNumberArray()
        {
            string[] text = File.ReadAllText(@"..\..\Texts\Numbers.txt").Split(new char[] { ' ', ',', '.', '«', '»' }, StringSplitOptions.RemoveEmptyEntries);

            int[] arr = new int[text.Length];
            for (int i = 0; i < text.Length; i++)
                arr[i] = int.Parse(text[i]);
            
            foreach (var item in arr) 
                Console.Write(item + " ");            
            Console.WriteLine("\n\n");

            //Sorter.SelectionSort(arr);

            Sorter.HoareSort(arr, 0, text.Length - 1);

            foreach (var item in arr)
                Console.Write(item + " ");
            Console.WriteLine("\n\n");
        }

        private static void TextStringArray()
        {
            string[] text = File.ReadAllText(@"..\..\Texts\Text 1.txt").Split(new char[] { ' ', ',', '.', '«', '»' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in text)
                Console.Write(item + " ");
            Console.WriteLine("\n\n");

            //Sorter.SelectionSort(text);

            Sorter.HoareSort(text, 0, text.Length - 1);

            foreach (var item in text)
                Console.Write(item + " ");
            Console.WriteLine("\n\n");
        }
    }
}
