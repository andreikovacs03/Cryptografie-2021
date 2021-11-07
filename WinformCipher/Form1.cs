using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Security;

namespace WinformCipher
{
    public partial class Form1 : Form
    {
        const string DEFAULT_ALGORITHM = "AES";
        const string DEFAULT_CIPHER_MODE = "CBC";
        const string DEFAULT_PADDING_MODE = "None";

        static Dictionary<string, SymmetricAlgorithm> AlgorithmMap = new()
        {
            { "AES", Aes.Create() },
            { "DES", DES.Create() },
            { "RC2", RC2.Create() },
            { "Rijndael", Rijndael.Create() },
            { "TripleDES", TripleDES.Create() }
        };

        static Dictionary<string, CipherMode> CipherModeMap = new()
        {
            { "CBC", CipherMode.CBC },
            { "ECB", CipherMode.ECB },
            { "CTS", CipherMode.CTS },
        };

        static Dictionary<string, PaddingMode> PaddingModeMap = new()
        {
            { "None", PaddingMode.None },
            { "Zeros", PaddingMode.Zeros },
            { "PKCS7", PaddingMode.PKCS7 },
            { "ISO10126", PaddingMode.ISO10126 },
            { "ANSIX923", PaddingMode.ANSIX923 },
        };

        static SymmetricAlgorithm Algorithm = AlgorithmMap[DEFAULT_ALGORITHM];
        static CipherMode Mode = CipherModeMap[DEFAULT_CIPHER_MODE];
        static string Key = "";
        static string IV = "";
        static PaddingMode Padding = PaddingModeMap[DEFAULT_PADDING_MODE];
        static string InputFilePath = "";
        static string OutputFilePath = "";

        public Form1()
        {
            InitializeComponent();

            cipherComboBox.Items.AddRange(AlgorithmMap.Keys.ToArray());
            cipherComboBox.SelectedItem = DEFAULT_ALGORITHM;

            modeComboBox.Items.AddRange(CipherModeMap.Keys.ToArray());
            modeComboBox.SelectedItem = DEFAULT_CIPHER_MODE;

            paddingModeComboBox.Items.AddRange(PaddingModeMap.Keys.ToArray());
            paddingModeComboBox.SelectedItem = DEFAULT_PADDING_MODE;
        }

        private void cipherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Algorithm = AlgorithmMap[cipherComboBox.SelectedItem.ToString()];
        }

        private void modeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = CipherModeMap[modeComboBox.SelectedItem.ToString()];
        }

        private void keyTextBox_TextChanged(object sender, EventArgs e)
        {
            Key = keyTextBox.Text;
        }

        private void ivTextBox_TextChanged(object sender, EventArgs e)
        {
            IV = ivTextBox.Text;
        }
        
        private void paddingModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Padding = PaddingModeMap[paddingModeComboBox.SelectedItem.ToString()];
        }

        private string SelectFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;
            return null;
        }

        private void inputFileButton_Click(object sender, EventArgs e)
        {
            string filePath = SelectFile();
            if (filePath != null)
            {
                InputFilePath = filePath;
                inputFileTextBox.Text = filePath;
            }
        }

        private void outputFileButton_Click(object sender, EventArgs e)
        {
            string filePath = SelectFile();
            if (filePath != null)
            {
                OutputFilePath = filePath;
                outputFileTextBox.Text = filePath;
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            string plainText = File.ReadAllText(InputFilePath);

            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("Input file is empty");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key is empty");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV is empty");

            byte[] encrypted;

            Algorithm.Key = Encoding.UTF8.GetBytes(Key);
            Algorithm.IV = Encoding.UTF8.GetBytes(IV);
            Algorithm.Mode = Mode;
            Algorithm.Padding = Padding;

            ICryptoTransform encryptor = Algorithm.CreateEncryptor(Algorithm.Key, Algorithm.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            File.WriteAllBytes(OutputFilePath, encrypted);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            byte[] cipherText = File.ReadAllBytes(InputFilePath);

            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("Input file is empty");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key is empty");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV is empty");

            string plaintext = null;

            Algorithm.Key = Encoding.UTF8.GetBytes(Key);
            Algorithm.IV = Encoding.UTF8.GetBytes(IV);
            Algorithm.Mode = Mode;

            ICryptoTransform decryptor = Algorithm.CreateDecryptor(Algorithm.Key, Algorithm.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            File.WriteAllText(OutputFilePath, plaintext);
        }
    }
}
