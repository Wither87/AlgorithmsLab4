using System;

namespace AlgorithmsLab4
{
    public static class Sorter
    {
        public static void SelectionSort(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string min = text[i];
                int index = i;
                for (int j = i; j < text.Length; j++)
                {
                    string currentWord = text[j];
                    int compareResult = min.CompareTo(currentWord);
                    if (compareResult > 0)
                    {
                        min = text[j];
                        index = j;
                    }
                }
                string t = text[i];
                text[i] = text[index];
                text[index] = t;
            }
        }

        public static void HoareSort(string[] text, int start, int end)
        {
            if (end == start) return;
            string pivot = text[end];
            int startIndex = start;
            for (int i = start; i <= end - 1; i++)
            {
                string currentWord = text[i];
                if (currentWord.CompareTo(pivot) <= 0)
                {
                    string t = text[i];
                    text[i] = text[startIndex];
                    text[startIndex] = t;
                    startIndex++;
                }
            }
            string n = text[startIndex];
            text[startIndex] = text[end];
            text[end] = n;
            if (startIndex > start) HoareSort(text, start, startIndex - 1);
            if (startIndex < end) HoareSort(text, startIndex + 1, end);
        }

        /// <summary>
        /// Проверочный метод для чисел
        /// </summary>
        /// <param name="text"></param>
        public static void SelectionSort(int[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                int min = text[i];
                int index = i;
                for (int j = i; j < text.Length; j++)
                {
                    if (min > text[j])
                    {
                        min = text[j];
                        index = j;
                    }
                }
                int t = text[index];
                text[index] = text[i];
                text[i] = t;
            }
        }

        /// <summary>
        /// Проверочный метод для чисел
        /// </summary>
        /// <param name="text"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public static void HoareSort(int[] text, int start, int end)
        {
            if (end == start) return;
            int pivot = text[end];
            int startIndex = start;
            for (int i = start; i <= end - 1; i++)
            {
                int currentNumber = text[i];
                if (currentNumber <= pivot)
                {
                    int t = text[i];
                    text[i] = text[startIndex];
                    text[startIndex] = t;
                    startIndex++;
                }
            }
            int n = text[startIndex];
            text[startIndex] = text[end];
            text[end] = n;
            if (startIndex > start) HoareSort(text, start, startIndex - 1);
            if (startIndex < end) HoareSort(text, startIndex + 1, end);
        }
    }
}
