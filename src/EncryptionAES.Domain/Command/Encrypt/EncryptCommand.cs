using EncryptionAES.Domain.Dto;
using MediatR;

namespace EncryptionAES.Domain.Command.Encrypt
{
    public class EncryptCommand : Request, IRequest<Response>
    {

    }
}
