namespace AlgorithmsLab4
{
    public static class Sort
    {
        public static void SelectionSort(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                string minWord = text[i];
                int minWordIndex = i;
                for (int j = i; j < text.Length; j++)
                {
                    string currentWord = text[j];
                    int compareResult = minWord.CompareTo(currentWord);
                    if (compareResult > 0)
                    {
                        minWord = currentWord;
                        minWordIndex = j;
                    }
                }
                string t = text[i];
                text[i] = text[minWordIndex];
                text[minWordIndex] = t;
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
                int compareResult = currentWord.CompareTo(pivot);
                if (compareResult <= 0)
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
    }
}
