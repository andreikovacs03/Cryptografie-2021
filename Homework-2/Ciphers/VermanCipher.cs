using System;

namespace Homework_2.Ciphers
{
    public class VermanCipher : ICipher
    {
        public string Key;

        public VermanCipher(string key)
        {
            Key = key;
        }

        public string Encrypt(string text)
        {
            if(text.Length != Key.Length)
                throw new Exception("Text and key have different lengths.");

            string result = "";

            for(int i=0; i<text.Length; i++)
                result += text[i] ^ Key[i];

            return result;
        }

        public string Decrypt(string text) => Encrypt(text);
    }
}
