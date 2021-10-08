namespace Cipher
{
    public class ROT13 : Substitute
    {
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