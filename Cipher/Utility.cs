using System;
using System.Collections.Generic;
using System.Linq;

namespace Cipher
{
    public static class Utility
    {
        public static string Shuffle(this string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        public static string Swap(this string text, int position1, int position2)
        {
            char[] array = text.ToCharArray();
            char temp = array[position1];

            array[position1] = array[position2];
            array[position2] = temp;

            return new string(array);
        }

        public static string Shift(this string text, int shift) => text.Remove(0, shift % text.Length) +
                                                                   text.Substring(0, shift % text.Length);

        public static Dictionary<char, int> CountFrequencies(this string text) => text.Where(c => char.IsLetter(c))
                                                                                      .GroupBy(c => char.ToUpper(c))
                                                                                      .ToDictionary(g => g.Key, g => g.Count());
    }
}
