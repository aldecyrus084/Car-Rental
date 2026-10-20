using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.Branch;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.GetAll
{
    public class GetAllBranchHandler : IRequestHandler<GetAllBranchCommand, GenericResponse<IEnumerable<BranchResponseDTO>>>
    {
        private readonly IBranchRepository _branchRepo;

        public GetAllBranchHandler(IBranchRepository branchRepo)
        {
            _branchRepo = branchRepo;
        }

        public async Task<GenericResponse<IEnumerable<BranchResponseDTO>>> Handle(GetAllBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _branchRepo.GetAllBranchesAsync();
                var branch = response.Select(x => new BranchResponseDTO
                {
                    BranchId = x.BranchId,
                    Name = x.Name,
                    Address = x.Address,
                    City = x.City,
                    Province = x.Province,
                    ContactNumber = x.ContactNumber,
                    IsActive = x.IsActive
                }).ToList();

                return new GenericResponse<IEnumerable<BranchResponseDTO>>
                {
                    isSuccess = true,
                    message = "Branch list.",
                    Data = branch
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<IEnumerable<BranchResponseDTO>>
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
    }
}
