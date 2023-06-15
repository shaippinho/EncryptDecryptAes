using EncryptionAES.Domain.Dto;
using MediatR;

namespace EncryptionAES.Domain.Command.Encrypt
{
    public class EncryptCommandHandler : IRequestHandler<EncryptCommand, Response>
    {
        public async Task<Response> Handle(EncryptCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Response { Message = "Encrypt" });
        }
    }
}
