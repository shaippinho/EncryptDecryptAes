using EncryptionAES.Domain.Contracts;
using EncryptionAES.Domain.Services;
using EncryptionAES.KeyVault.Contracts;
using EncryptionAES.KeyVault.Models;
using EncryptionAES.KeyVault.Services;

namespace EncryptionAES.API
{
    public static class Bootstrapper
    {
        public static void AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IKeyVaultService, KeyVaultService>();
            services.AddScoped<IAesCryptographyService, AesCryptographyService>();

            services.AddSingleton(configuration.GetSection(KeyVaultSettings.SessionName).Get<KeyVaultSettings>());
        }
    }
}
