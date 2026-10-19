using MediatR;
using MyApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.UserRole.Delete
{
    public class UpdateUserRoleStatusCommand : IRequest<GenericResponse<string>>
    {
        public Guid UserRoleId { get; set; }
    }
}
