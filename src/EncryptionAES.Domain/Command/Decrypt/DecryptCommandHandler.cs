using EncryptionAES.Domain.Dto;
using MediatR;

namespace EncryptionAES.Domain.Command.Decrypt
{
    public class DecryptCommandHandler : IRequestHandler<DecryptCommand, Response>
    {
        
        public async Task<Response> Handle(DecryptCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response { Message = "Decrypt" });
        }
    }
}
