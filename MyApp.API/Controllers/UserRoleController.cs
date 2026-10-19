using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.UserRole.Create;
using MyApp.Application.Features.UserRole.Delete;
using MyApp.Application.Features.UserRole.GetAll;
using MyApp.Application.Features.Users.Delete;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/user-role")]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateUserRole([FromBody] CreateUserRoleCommand command)
        {
            var result = _mediator.Send(command).Result;
            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserRole()
        {
            var userRole = await _mediator.Send(new GetAllUserRoleCommand());
            return Ok(userRole);
        }


        [HttpPut("{id:guid}/toggleStatus")]
        public async Task<IActionResult> DeactivateUserRole(Guid id)
        {
            var userRole = await _mediator.Send(new UpdateUserRoleStatusCommand
            {
                UserRoleId = id
            });
            if (!userRole.isSuccess)
                return NotFound(userRole);

            return Ok(userRole);
        }
    }
}
