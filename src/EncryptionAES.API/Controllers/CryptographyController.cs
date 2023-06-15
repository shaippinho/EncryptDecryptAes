using EncryptionAES.Domain.Commands.Decrypt;
using EncryptionAES.Domain.Commands.Encrypt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionAES.API.Controllers
{
    [Route("api/cryptography")]
    [ApiController]
    public class CryptographyController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public CryptographyController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Encrypt")]
        public async Task<IActionResult> Encrypt(EncryptCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        [Route("Decrypt")]
        public async Task<IActionResult> Decrypt(DecryptCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
