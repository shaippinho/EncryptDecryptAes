using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAES.Domain.Contracts
{
    public interface IAesCryptographyService
    {
        Task<string> EncryptAsync(string plaintext, CancellationToken cancellationToken);
        Task<string> DecryptAsync(string plaintext, CancellationToken cancellationToken);
    }
}
