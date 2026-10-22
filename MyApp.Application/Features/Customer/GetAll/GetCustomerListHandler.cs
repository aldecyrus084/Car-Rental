using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.Customer;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Customer.GetAll
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListCommand, GenericResponse<IEnumerable<CustomerListResponseDTO>>>
    {

        private readonly ICustomerRepository _customerRepo;

        public GetCustomerListHandler(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<GenericResponse<IEnumerable<CustomerListResponseDTO>>> Handle(GetCustomerListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _customerRepo.GetAllCustomerAsync();
                return new GenericResponse<IEnumerable<CustomerListResponseDTO>>
                {
                    isSuccess = true,
                    message = "List of customers",
                    Data = response
                };
            }
            catch(Exception ex)
            {
                return new GenericResponse<IEnumerable<CustomerListResponseDTO>>
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
    }
}
