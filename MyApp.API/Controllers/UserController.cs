using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Users.Create;
using MyApp.Application.Features.Users.Get;
using MyApp.Application.Features.Users.GetAll;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.isSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersCommand());
            return Ok(users);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var command = new GetUserByIdCommand
            {
                UserId = id
            };

            var response = await _mediator.Send(command);
            if (!response.isSuccess)
                return NotFound(response.message);

            return Ok(response);
        }
    }
}
