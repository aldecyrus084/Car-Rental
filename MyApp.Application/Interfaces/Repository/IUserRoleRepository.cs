using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IUserRoleRepository
    {
        Task<UserRoles?> GetActiveUserRoleByIdAsync(Guid Id);
        Task<IEnumerable<UserRoles>> GetAllActiveUserRolesAsync();
        Task<IEnumerable<UserRoles>> GetAllUserRolesAsync();
        Task<UserRoles?> GetUserRoleByIdAsync(Guid Id);
        Task CreateUserRoleAsync(UserRoles userRoles);
        Task SaveChangesAsync();
    }
}
