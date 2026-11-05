using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Auth.Login
{
    public class LoginCommand : IRequest<GenericResponse<AuthResponseDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
