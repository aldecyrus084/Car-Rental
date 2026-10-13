using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.Get
{
    public class GetUserByIdCommand : IRequest<GenericResponse<UserResponseDTO>>
    {
        public Guid UserId { get; set; }
    }
}
