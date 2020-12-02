using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                for (int j = 0; j < text.Length; j++)
                {
                    if (Compare(min, text[i])) // min > text[i]
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
        /// <summary>
        /// (first >= second) => true
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static bool Compare(string first, string second)
        {
            int length = (first.Length <= second.Length) ? first.Length : second.Length;
            //bool result = Compare(length, first, second);
            for (int i = 0; i < length; i++)
            {
                if (first[i] == second.Length) continue; // буквы одинаковые - переход

                return (first[i] > second[i]) ? true : false; // второй меньше первого = true
            }
            return true;
        }

        /*
        private static bool Compare(int length, string first, string second)
        {
            for (int i = 0; i < length; i++)
            {
                if (first[i] == second.Length) continue; // буквы одинаковые - переход

                return (first[i] > second[i]) ? true : false; // второй меньше первого = true
            }
            return true;
        }
        */
    }
}
