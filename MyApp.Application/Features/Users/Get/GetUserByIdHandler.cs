using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.User;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Get
{
    public class GetUserByIdhandler : IRequestHandler<GetUserByIdCommand, GenericResponse<UserResponseDTO>>
    {
        private readonly IUserRepository _userRepo;

        public GetUserByIdhandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<GenericResponse<UserResponseDTO>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.GetUserByIdAsync(request.UserId);
                if(user == null)
                {
                    return new GenericResponse<UserResponseDTO>
                    {
                        isSuccess = false,
                        message = "User not found"
                    };
                }

                return new GenericResponse<UserResponseDTO>
                {
                    isSuccess = true,
                    message = "User information",
                    Data = new UserResponseDTO
                    {
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Role = user.UserRole.Name,
                        IsActive = user.IsActive
                    }
                };
            }
            catch (Exception ex)
            {
                return new GenericResponse<UserResponseDTO>
                {
                    isSuccess = false,
                    message = ex.Message
                };
            }
        }
    }
}
