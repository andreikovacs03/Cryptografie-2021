using System;
using System.Collections.Generic;
using System.Text;

namespace Cipher
{
    public class Substitute : ICipher
    {
        protected const string UPPER_ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        protected const string LOWER_ALPHABET = "abcdefghijklmnopqrstuvwxyz";
        protected const string ALPHABET = UPPER_ALPHABET + LOWER_ALPHABET;

        readonly Dictionary<char, double> LetterFrequencies = new()
        {
            ['e'] = 12.7,
            ['t'] = 9.06,
            ['a'] = 8.17,
            ['o'] = 7.51,
            ['i'] = 6.97,
            ['n'] = 6.75,
            ['s'] = 6.33,
            ['h'] = 6.09,
            ['r'] = 5.99,
            ['d'] = 4.25,
            ['l'] = 4.03,
            ['c'] = 2.78,
            ['u'] = 2.76,
            ['m'] = 2.41,
            ['w'] = 2.36,
            ['f'] = 2.23,
            ['g'] = 2.02,
            ['y'] = 1.97,
            ['p'] = 1.93,
            ['b'] = 1.29,
            ['v'] = 0.98,
            ['k'] = 0.77,
            ['j'] = 0.15,
            ['x'] = 0.15,
            ['q'] = 0.10,
            ['z'] = 0.07
        };

        protected string PlainText;
        protected string CipherText;

        public Substitute(string ciphertext, string plaintext = LOWER_ALPHABET)
        {
            if (plaintext.Length != ciphertext.Length)
                throw new Exception("PlainText and CipherText lengths differ");

            PlainText = plaintext.ToLower();
            CipherText = ciphertext.ToLower();
        }

        public string Encrypt(string text) => Encrypt(text, CipherText, PlainText);

        public string Decrypt(string text) => Encrypt(text, PlainText, CipherText);

        static string Encrypt(string text, string ciphertext, string plaintext)
        {
            StringBuilder result = new();

            foreach (char letter in text)
            {
                int index = plaintext.IndexOf(char.ToLower(letter));

                if (index != -1)
                    result.Append(char.IsUpper(letter) ? char.ToUpper(ciphertext[index]) : ciphertext[index]);
                else
                    result.Append(letter);
            }

            return result.ToString();
        }

        protected double CalculateScore(string text)
        {
            var counter = text.CountFrequencies();
            double sum = 0;

            foreach (char letter in LOWER_ALPHABET)
                sum += counter.GetValueOrDefault(letter, 0) * 100 / text.Length - LetterFrequencies[letter];

            return sum / LOWER_ALPHABET.Length;
        }

        /// <summary>
        /// Reference: http://practicalcryptography.com/cryptanalysis/stochastic-searching/cryptanalysis-simple-substitution-cipher/
        /// </summary>
        public virtual string Analyze(string text)
        {
            Random rnd = new();
            nGram ngram = new("english_quadgrams.txt");

            string decryptedPlainText = "";
            double highestScore = double.NegativeInfinity;
            string bestCipherText = LOWER_ALPHABET;

            int i = 0;
            while(true)
            {
                i++;
                string cipherText = bestCipherText.Shuffle();

                string parentPlainText = Encrypt(text, PlainText, cipherText);
                double parentScore = ngram.CalculateScore(parentPlainText);

                int iterations = 0;
                while (iterations < 1000)
                {
                    char randomLetterA = LOWER_ALPHABET[rnd.Next(LOWER_ALPHABET.Length)];
                    char randomLetterB = LOWER_ALPHABET[rnd.Next(LOWER_ALPHABET.Length)];

                    string similarCipherText = cipherText.Swap(cipherText.IndexOf(randomLetterA),
                                                               cipherText.IndexOf(randomLetterB));

                    string similarDecryptedPlainText = Encrypt(text, PlainText, similarCipherText);
                    double childScore = ngram.CalculateScore(similarDecryptedPlainText);

                    if (childScore > parentScore)
                    {
                        parentPlainText = similarDecryptedPlainText;
                        parentScore = childScore;
                        iterations = 0;
                    }

                    iterations += 1;
                }

                if(parentScore > highestScore)
                {
                    highestScore = parentScore;
                    decryptedPlainText = parentPlainText;
                    bestCipherText = cipherText;

                    Console.WriteLine($"Best score so far: {highestScore} on iteration {i}");
                    Console.WriteLine(decryptedPlainText);
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }

            return decryptedPlainText;
        }
    }
}