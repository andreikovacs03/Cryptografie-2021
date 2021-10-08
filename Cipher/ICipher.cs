namespace Cipher
{
    interface ICipher
    {
        string Encrypt(string text);

        string Decrypt(string text);

        string Analyze(string text);
    }
}
