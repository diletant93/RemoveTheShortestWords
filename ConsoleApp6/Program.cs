using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] str = { 'h', 'e', 'l', 'l', 'o', ' ', 'm', 'y','1', ' ', 'm', ' ', 'w', 'o', 'r', 'l', 'd' };
            ShowArray(str);
            ShowTwoSmallestWords(str);
        }
        static void ShowArray(char[] str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
            }
            Console.WriteLine();
        }
        static char[] GetWord(char[] array, int startPos , int endPos)
        {
            char[] firstWord = new char[endPos - startPos];
            for (int i = 0, k = 0; i < array.Length; i++)
            {
                if (i >= startPos && i < endPos)
                {
                    firstWord[k] = array[i];
                    k++;
                }
            }
            return firstWord;
        }
        static void ShowTwoSmallestWords(char[] array)
        {
            int startPos = FindIndexes(array, out int endPos, out int length);
            char[] tmpArray = array[..];
            char[] word1 = GetWord(tmpArray, startPos, endPos);
            RemoveWord(ref tmpArray);
            ShowArray(word1);
            startPos = FindIndexes(tmpArray, out endPos, out length);
            char[] word2 = GetWord(tmpArray, startPos, endPos);
            ShowArray(word2);
        }
        
        static int FindIndexes(char[] array ,out int endPos, out int length )
        {
            int startPos = 0;
            endPos = 0;
            length = 0;
            int tmpLength = 0;
            bool firstIteration = true;
            for (int i = 0, k = 0; i < array.Length; i++)
            {
                if (array[i] != ' ' && i <= array.Length - 1)
                {
                    k = i;
                    while (array[i] != ' ' && i < array.Length - 1)
                    {
                        length++;
                        i++;
                    }
                    if (firstIteration)
                    {
                        startPos = k;
                        endPos = i;
                        tmpLength = length;
                        firstIteration = false;
                    }
                    else if (length < tmpLength)
                    {
                        startPos = k;
                        endPos = i;
                        tmpLength = length;
                    }
                    length = 0;
                }
            }
            length = tmpLength;
            return startPos;
        }
        static void RemoveWord(ref char[] array )
        {
            int startPos = FindIndexes(array, out int endPos,out int length);
            char[] result = new char[array.Length - length];
            for (int i = 0,k = 0; i < array.Length; i++)
            {
                if(i < startPos || i > endPos)
                {
                    result[k] = array[i];
                    k++;
                }
            }
            array = result;
        }
    }
}
