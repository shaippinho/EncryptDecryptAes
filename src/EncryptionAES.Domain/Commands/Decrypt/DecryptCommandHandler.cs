using EncryptionAES.Domain.Contracts;
using EncryptionAES.Domain.Dtos;
using MediatR;

namespace EncryptionAES.Domain.Commands.Decrypt
{
    public class DecryptCommandHandler : IRequestHandler<DecryptCommand, Response>
    {
        private readonly IAesCryptographyService _aesCryptographyService;
        public DecryptCommandHandler(IAesCryptographyService aesCryptographyService) 
        {
            _aesCryptographyService = aesCryptographyService;
        }
        
        public async Task<Response> Handle(DecryptCommand request, CancellationToken cancellationToken)
        {
            var result = await _aesCryptographyService.DecryptAsync(request.Message, cancellationToken);

            return await Task.FromResult(new Response { Message = result });
        }
    }
}
