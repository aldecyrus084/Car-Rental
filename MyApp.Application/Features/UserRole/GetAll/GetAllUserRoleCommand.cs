using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.GetAll
{
    public class GetAllUserRoleCommand : IRequest<GenericResponse<IEnumerable<UserRoleResponseDTO>>>
    {
    }
}
