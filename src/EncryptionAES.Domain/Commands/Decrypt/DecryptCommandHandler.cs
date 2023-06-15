using EncryptionAES.Domain.Dtos;
using EncryptionAES.Domain.Services;
using MediatR;

namespace EncryptionAES.Domain.Commands.Decrypt
{
    public class DecryptCommandHandler : IRequestHandler<DecryptCommand, Response>
    {
        
        public async Task<Response> Handle(DecryptCommand request, CancellationToken cancellationToken)
        {
            var result = AesCryptographyService.Decrypt(request.Message);

            return await Task.FromResult(new Response { Message = result });
        }
    }
}
