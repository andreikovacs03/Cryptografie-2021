namespace Homework_2.Ciphers
{
    public class VigenereCipher : ICipher
    {
        public string Key;

        public VigenereCipher(string key)
        {
            Key = key;
        }

        public string Encrypt(string text)
        {
            string result = "";
            string key = GenerateKey(text, Key);

            for (int i = 0; i < text.Length; i++)
            {
                int index = (text[i] + key[i]) % 26;

                index += 'A';
                result += (char)(index);
            }

            return result;
        }

        public string Decrypt(string text)
        {
            string result = "";
            string key = GenerateKey(text, Key);

            for (int i = 0; i < text.Length && i < key.Length; i++)
            {
                int index = (text[i] - key[i] + 26) % 26;

                index += 'A';
                result += (char)(index);
            }

            return result;
        }

        private string GenerateKey(string text, string key)
        {
            int x = text.Length;

            for (int i = 0; ; i++)
            {
                if (x == i)
                    i = 0;
                if (key.Length == text.Length)
                    break;
                key += (key[i]);
            }
            return key;
        }
    }
}
