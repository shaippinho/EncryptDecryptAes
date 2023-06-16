namespace EncryptionAES.KeyVault.Models
{
    public sealed class KeyVaultSettings
    {
        public static string SessionName => "Core:KeyVault";

        public string? Endpoint { get; set; }
        public string? ClientId { get; set; }
        public string? TenantId { get; set; }
        public string? ClientSecretId { get; set; }
        public double? Delay { get; set; }
        public double? MaxDelay { get; set; }
        public int? MaxRetry { get; set; }
    }
}
