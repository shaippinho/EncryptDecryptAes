using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using EncryptionAES.KeyVault.Contracts;
using EncryptionAES.KeyVault.Models;

namespace EncryptionAES.KeyVault.Services
{
    public class KeyVaultService : IKeyVaultService
    {
        private readonly KeyVaultSettings _keyVaultSettings;


        public KeyVaultService(KeyVaultSettings keyVaultSettings)
        {
            _keyVaultSettings = keyVaultSettings;
        }

        public async Task<string> GetKeyVaultSecretAsync(CancellationToken cancellationToken)
        {

            var credentials = new ClientSecretCredential(_keyVaultSettings.TenantId, _keyVaultSettings.ClientId, _keyVaultSettings.ClientSecretId);

            var options = new SecretClientOptions()
            {
                Retry =
                    {
                        Delay= TimeSpan.FromSeconds(_keyVaultSettings.Delay!.Value),
                        MaxDelay = TimeSpan.FromSeconds(_keyVaultSettings.MaxDelay!.Value),
                        MaxRetries = _keyVaultSettings.MaxRetry!.Value,
                        Mode = RetryMode.Exponential
                     }
            };

            var client = new SecretClient(new Uri(_keyVaultSettings.Endpoint!), credentials, options);

            KeyVaultSecret secret = await client.GetSecretAsync("SecretCrypt", null, cancellationToken);

            return secret.Value;
        }
    }
}
