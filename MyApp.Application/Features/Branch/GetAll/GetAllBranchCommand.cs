using MediatR;
using MyApp.Application.DTOs;
using MyApp.Application.DTOs.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Branch.GetAll
{
    public class GetAllBranchCommand : IRequest<GenericResponse<IEnumerable<BranchResponseDTO>>>
    {

    }
}
