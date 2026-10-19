using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.UserRole;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserRoleCommand, GenericResponse<UserRoleResponseDTO>>
    {
        private readonly IUserRoleRepository _userRoleRepo;

        public CreateUserHandler(IUserRoleRepository userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }

        public async Task<GenericResponse<UserRoleResponseDTO>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = new UserRoles(request.Name, request.Description, request.IsActive);
                await _userRoleRepo.CreateUserRoleAsync(userRole);
                await _userRoleRepo.SaveChangesAsync();

                return new GenericResponse<UserRoleResponseDTO>
                {
                    message = "User role added successfully.",
                    isSuccess = true,
                    Data = new UserRoleResponseDTO
                    {
                        UserRoleId = userRole.UserRoleId,
                        Name = userRole.Name,
                        Description = userRole.Description,
                        IsActive = userRole.IsActive
                    }
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<UserRoleResponseDTO>
                {
                    message = ex.Message,
                    isSuccess = false
                };
            }
        }
    }
}
