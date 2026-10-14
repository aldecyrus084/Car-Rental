using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.UserRole;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.GetAll
{
    public class GetAllUserRoleHandler : IRequestHandler<GetAllUserRoleCommand, GenericResponse<IEnumerable<UserRoleResponseDTO>>>
    {
        private readonly IUserRoleRepository _userRoleRepo;

        public GetAllUserRoleHandler(IUserRoleRepository userRoleRepo)
        {
            _userRoleRepo = userRoleRepo;
        }
        public async Task<GenericResponse<IEnumerable<UserRoleResponseDTO>>> Handle(GetAllUserRoleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userRoles = await _userRoleRepo.GetAllUserRolesAsync();
                var userRoleDTO = userRoles.Select(userRole => new UserRoleResponseDTO
                {
                    UserRoleId = userRole.UserRoleId,
                    Name = userRole.Name,
                    Description = userRole.Description,
                    IsActive = userRole.IsActive
                });

                return new GenericResponse<IEnumerable<UserRoleResponseDTO>>
                {
                    isSuccess = true,
                    message = "User role lists.",
                    Data = userRoleDTO
                };
            }
            catch(Exception ex)
            {
                return new GenericResponse<IEnumerable<UserRoleResponseDTO>>
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
    }
}
