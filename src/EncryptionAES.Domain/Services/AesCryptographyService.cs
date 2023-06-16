using EncryptionAES.Domain.Contracts;
using EncryptionAES.KeyVault.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionAES.Domain.Services
{
    public class AesCryptographyService : IAesCryptographyService
    {
        private readonly IKeyVaultService _keyVaultService;

        public AesCryptographyService(IKeyVaultService keyVaultService) 
        { 
            _keyVaultService = keyVaultService;
        }


        // Encoding.UTF8.GetBytes("8UHjPgXZzXCGkhxV2QCnooyJexUzvJrO"); // Chave secreta para criptografia AES

        public async Task<string> EncryptAsync(string plaintext, CancellationToken cancellationToken)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using Aes aes = Aes.Create();
            aes.IV = iv;
            aes.KeySize = 256;
            aes.Key = Encoding.UTF8.GetBytes(await _keyVaultService.GetKeyVaultSecretAsync(cancellationToken));
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

        public async Task<string> DecryptAsync(string plaintext, CancellationToken cancellationToken)
        {
            byte[] iv = new byte[16];
            byte[] encryptedBytes = Convert.FromBase64String(plaintext);

            using Aes aes = Aes.Create();
            aes.IV = iv;
            aes.KeySize = 256;
            aes.Key = Encoding.UTF8.GetBytes(await _keyVaultService.GetKeyVaultSecretAsync(cancellationToken));
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
