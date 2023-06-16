namespace EncryptionAES.KeyVault.Contracts
{
    public interface IKeyVaultService
    {
        Task<string> GetKeyVaultSecretAsync(CancellationToken cancellationToken);
    }
}
