using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Auth.Login;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.isSuccess)
            {
                return BadRequest(result.message);
            }
            
            return Ok(result);

        }
    }
}
