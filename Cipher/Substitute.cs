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