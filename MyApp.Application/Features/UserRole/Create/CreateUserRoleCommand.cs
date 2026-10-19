using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Create
{
    public class CreateUserRoleCommand : IRequest<GenericResponse<UserRoleResponseDTO>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
