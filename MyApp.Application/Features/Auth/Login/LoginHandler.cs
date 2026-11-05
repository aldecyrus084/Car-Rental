using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.Auth;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Auth.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, GenericResponse<AuthResponseDTO>>
    {
        private readonly IUserRepository _userRepo;
        private readonly AppSettings _appSettings;


        public LoginHandler(IUserRepository userRepo, IOptions<AppSettings> appSettings)
        {
            _userRepo = userRepo;
            _appSettings = appSettings.Value;
        }

        public async Task<GenericResponse<AuthResponseDTO>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepo.GetUserByEmailAsync(request.Email);
                if (user == null)
                {
                    return new GenericResponse<AuthResponseDTO>
                    {
                        isSuccess = false,
                        message = "Invalid email or password.",
                    };
                }

                // Here you would typically verify the password
                var verifiedPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
                if (!verifiedPassword)
                {
                    return new GenericResponse<AuthResponseDTO>
                    {
                        isSuccess = false,
                        message = "Invalid email or password.",
                    };
                }

                var fullName = string.Join(" ", new[] { user.FirstName, user.MiddleName, user.LastName }.Where(name => !string.IsNullOrWhiteSpace(name)));

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Token);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", fullName) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var encrypterToken = tokenHandler.WriteToken(token);

                var authResponse = new AuthResponseDTO
                {
                    userId = user.UserId,
                    email = user.Email,
                    role = user.UserRole.Name,
                    fullName = fullName,
                    token = encrypterToken
                };

                return new GenericResponse<AuthResponseDTO>
                {
                    isSuccess = true,
                    message = "Login successful.",
                    Data = authResponse
                };
            
            }
            catch(Exception ex)
            {
                return new GenericResponse<AuthResponseDTO>
                {
                    isSuccess = false,
                    message = ex.Message,
                };
            }
            
        }

        
    }
}
