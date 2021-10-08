using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cipher
{
    public class nGram
    {
        Dictionary<string, double> nGrams = new();
        int Length;
        double Total;
        double Floor;

        public nGram(string ngramFilePath)
        {
            string key = "";
            foreach (string line in File.ReadAllLines(ngramFilePath))
            {
                string[] splitLine = line.Split(' ');
                key = splitLine[0];
                int count = int.Parse(splitLine[1]);

                nGrams.Add(key, count);
            }

            Length = key.Length;
            Total = nGrams.Values.Sum();
            Floor = Math.Log10(0.01 / Total);

            foreach (var item in nGrams)
                nGrams[item.Key] = Math.Log10(nGrams[item.Key] / Total);
        }

        public double CalculateScore(string text)
        {
            double score = 0;

            for (int i = 0; i < text.Length - Length + 1; i++)
            {
                int rightMost = i + Length;
                if (nGrams.GetValueOrDefault(text[i..rightMost]) != default)
                    score += nGrams[text[i..rightMost]];
                else
                    score += Floor;
            }

            return score;
        }
    }
}
