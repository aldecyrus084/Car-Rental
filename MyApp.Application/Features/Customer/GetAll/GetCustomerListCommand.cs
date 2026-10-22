using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.GetAll
{
    public class GetCustomerListCommand : IRequest<GenericResponse<IEnumerable<CustomerListResponseDTO>>>
    {
    }
}
