using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.User;
using MyApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersCommand, GenericResponse<IEnumerable<UserResponseDTO>>>
    {
        private readonly IUserRepository _userRepo;
        public GetAllUsersHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<GenericResponse<IEnumerable<UserResponseDTO>>> Handle(GetAllUsersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepo.GetAllUsersAsync();
                var userDTO = users.Select(user => new UserResponseDTO
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    MiddleName = user.MiddleName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.UserRole.Name,
                    IsActive = user.IsActive
                }).ToList();
                return new GenericResponse<IEnumerable<UserResponseDTO>>
                {
                    isSuccess = true,
                    message = "Users lists.",
                    Data = userDTO
                };
            }
            catch(Exception ex)
            {
                return new GenericResponse<IEnumerable<UserResponseDTO>>
                {
                    isSuccess = true,
                    message = ex.Message
                };
            }
        }
    }
}
