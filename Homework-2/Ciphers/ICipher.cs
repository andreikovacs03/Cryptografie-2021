namespace Homework_2.Ciphers
{
    public interface ICipher
    {
        string Encrypt(string text);

        string Decrypt(string text);
    }
}
