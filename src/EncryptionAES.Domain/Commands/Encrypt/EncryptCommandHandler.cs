using EncryptionAES.Domain.Dtos;
using EncryptionAES.Domain.Services;
using MediatR;

namespace EncryptionAES.Domain.Commands.Encrypt
{
    public class EncryptCommandHandler : IRequestHandler<EncryptCommand, Response>
    {
        public async Task<Response> Handle(EncryptCommand request, CancellationToken cancellationToken)
        {
            var result = AesCryptographyService.Encrypt(request.Message);

            return await Task.FromResult(new Response { Message = result });
        }
    }
}
