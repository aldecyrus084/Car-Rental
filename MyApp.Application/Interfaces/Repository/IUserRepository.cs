using MyApp.Application.DTOs.User;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task CreateUserAsync(Users user);
        Task<Users?> GetActiveUserById(Guid id);
        Task<Users?> GetUserByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
