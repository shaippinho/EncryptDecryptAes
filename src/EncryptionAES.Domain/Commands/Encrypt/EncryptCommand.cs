using EncryptionAES.Domain.Dtos;
using MediatR;

namespace EncryptionAES.Domain.Commands.Encrypt
{
    public class EncryptCommand : Request, IRequest<Response>
    {

    }
}
