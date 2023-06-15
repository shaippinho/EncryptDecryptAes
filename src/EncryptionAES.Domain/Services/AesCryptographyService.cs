using System.Security.Cryptography;
using System.Text;

namespace EncryptionAES.Domain.Services
{
    public static class AesCryptographyService
    {

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("8UHjPgXZzXCGkhxV2QCnooyJexUzvJrO"); // Chave secreta para criptografia AES

        public static string Encrypt(string plaintext)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using Aes aes = Aes.Create();
            aes.IV = iv;
            aes.KeySize = 256;
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new())
            {
                using CryptoStream cryptoStream = new(memoryStream, encryptor, CryptoStreamMode.Write);
                using (StreamWriter streamWriter = new(cryptoStream))
                {
                    streamWriter.Write(plaintext);
                }

                array = memoryStream.ToArray();
            }

            return Convert.ToBase64String(array);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] iv = new byte[16];
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using Aes aes = Aes.Create();
            aes.IV = iv;
            aes.KeySize = 256;
            aes.Key = Key;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new(encryptedBytes);
            using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new(cryptoStream);
            return streamReader.ReadToEnd();
        }

    }
}
