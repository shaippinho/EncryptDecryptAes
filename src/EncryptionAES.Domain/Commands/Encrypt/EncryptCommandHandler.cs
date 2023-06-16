using EncryptionAES.Domain.Contracts;
using EncryptionAES.Domain.Dtos;
using MediatR;

namespace EncryptionAES.Domain.Commands.Encrypt
{
    public class EncryptCommandHandler : IRequestHandler<EncryptCommand, Response>
    {

        private readonly IAesCryptographyService _aesCryptographyService;
        public EncryptCommandHandler(IAesCryptographyService aesCryptographyService)
        {
            _aesCryptographyService = aesCryptographyService;
        }

        public async Task<Response> Handle(EncryptCommand request, CancellationToken cancellationToken)
        {
            var result = await _aesCryptographyService.EncryptAsync(request.Message, cancellationToken);

            return await Task.FromResult(new Response { Message = result });
        }
    }
}
