using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Delete
{
    public class UpdateUserRoleStatusHandler : IRequestHandler<UpdateUserRoleStatusCommand, GenericResponse<string>>
    {
        private readonly IUserRoleRepository _userRoleRepo;

        public UpdateUserRoleStatusHandler(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepo = userRoleRepository;
        }

        public async Task<GenericResponse<string>> Handle(UpdateUserRoleStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userRole = await _userRoleRepo.GetUserRoleByIdAsync(request.UserRoleId);

                if(userRole == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "User role not found",
                        isSuccess = false
                    };
                }

                userRole.ToggleUserRoleStatus();
                await _userRoleRepo.SaveChangesAsync();

                return new GenericResponse<string>
                {
                    message = "User role status updated successfully",
                    isSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<string>
                {
                    message = ex.Message,
                    isSuccess = false
                };
            }
        }
    }
}
