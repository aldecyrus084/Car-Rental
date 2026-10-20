using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Create
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, GenericResponse<string>>
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserRoleRepository _userRoleRepo;

        public CreateUserHandler(IUserRepository userRepo, IUserRoleRepository userRoleRepo)
        {
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
        }

        public async Task<GenericResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var userRole = await _userRoleRepo.GetUserRoleByIdAsync(request.UserRoleId);
                if(userRole == null)
                {
                    return new GenericResponse<string>
                    {
                        message = "User role id is invalid.",
                        isSuccess = false
                    };
                }

                var hashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
                var user = new Domain.Entities.Users(request.FirstName, request.MiddleName, request.LastName, request.Email, request.PhoneNumber, hashPassword, request.UserRoleId, request.IsActive);

                await _userRepo.CreateUserAsync(user);
                await _userRepo.SaveChangesAsync();


                return new GenericResponse<string>
                {
                    message = "User added succesfully.",
                    isSuccess = false,
                };
            }
            catch(Exception ex)
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
