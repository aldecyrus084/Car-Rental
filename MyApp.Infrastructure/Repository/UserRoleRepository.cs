using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces.Repository;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRoleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateUserRoleAsync(UserRoles userRoles)
        {
            await _context.UserRoles.AddAsync(userRoles);
        }

        public Task<UserRoles?> GetActiveUserRoleByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserRoles>> GetAllActiveUserRolesAsync()
        {
            return await _context.UserRoles.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<UserRoles>> GetAllUserRolesAsync()
        {
            return await _context.UserRoles.ToListAsync();
        }

        public async Task<UserRoles?> GetUserRoleByIdAsync(Guid Id)
        {
            return await _context.UserRoles.FirstOrDefaultAsync(x => x.UserRoleId == Id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
