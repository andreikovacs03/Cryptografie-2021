using System.Collections.Generic;

namespace Cipher
{
    public class ROT13 : Substitute
    {
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
        
        public ROT13(int shift = 13) : base(ALPHABET, ALPHABET)
        {
            ShiftCipherText(shift);
        }

        void ShiftCipherText(int shift)
        {
            string upperCipherAlphabet = UPPER_ALPHABET.Shift(shift);
            string lowerCipherAlphabet = LOWER_ALPHABET.Shift(shift);

            CipherText = upperCipherAlphabet + lowerCipherAlphabet;
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
        /// Reference: https://medium.com/@momohakarish/caesar-cipher-and-frequency-analysis-with-python-635b04e0186f
        /// </summary>
        public override string Analyze(string text)
        {
            string decryptedPlainText = "";
            double highestScore = double.NegativeInfinity;

            for (int shift = 1; shift < ALPHABET.Length; shift++)
            {
                string currentPlainText = Encrypt(text);
                ShiftCipherText(shift);

                double score = CalculateScore(currentPlainText);

                if (score > highestScore)
                {
                    highestScore = score;
                    decryptedPlainText = currentPlainText;
                }
            }

            return decryptedPlainText;
        }
    }
}