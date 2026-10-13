using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs.User;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task CreateUserAsync(Users user)
        {
            await _dbContext.Users.AddAsync(user);
        }



        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<Users?> GetActiveUserById(Guid id)
        {
            var user = await _dbContext.Users.Where(x => x.IsActive).FirstOrDefaultAsync(x => x.UserId == id);

            if(user == null)
            {
                return null;
            }

            return user;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Users?> GetUserByIdAsync(Guid id)
        {
            return await _dbContext.Users.Include(x => x.UserRole).FirstOrDefaultAsync(x => x.UserId == id);
                
        }
    }
}
