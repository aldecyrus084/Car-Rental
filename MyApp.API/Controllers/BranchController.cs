using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Branch.Create;
using MyApp.Application.Features.Branch.GetAll;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/branch")]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranch()
        {
            var branches = await _mediator.Send(new GetAllBranchCommand());
            return Ok(branches);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBranchCommand command)
        {
            var branch = await _mediator.Send(command);
            return Ok(branch);
        }
    }
}
