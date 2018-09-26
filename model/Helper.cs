using System;

namespace RegistryApp.model
{
    /// <summary>
    /// Contains general helper methods
    /// </summary>
    public class Helper
    {
        public string[] SplitBy(string toSplit, string delimiter)
        {
            return toSplit.Split(delimiter);
        }

        public int[] GetIntsFromStrings(string[] strings)
        {
            int[] ints = new int[strings.Length];
            
            for (int i = 0; i < strings.Length; i++)
            {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        }

        public string GetStringFromInt(int integer)
        {
            return $"{integer}";
        }

        public int GetSum(int a, int b) {
            return a + b;
        }
    }
}