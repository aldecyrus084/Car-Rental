using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Customer.Create;
using MyApp.Application.Features.Customer.GetAll;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
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
        public async Task<IActionResult> GetListOfCustomers()
        {
            var result = await _mediator.Send(new GetCustomerListCommand());
            return Ok(result);
        }
    }
}
