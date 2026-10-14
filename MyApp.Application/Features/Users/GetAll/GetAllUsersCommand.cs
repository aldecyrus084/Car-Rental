using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Users.GetAll
{
    public class GetAllUsersCommand : IRequest<GenericResponse<IEnumerable<UserResponseDTO>>>
    {
    }
}
