using Microsoft.EntityFrameworkCore;
using MyApp.Application.DTOs.Customer;
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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CustomerRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateCustomerAsync(Customers customer)
        {
            await _dbContext.Customers.AddAsync(customer);
        }

        public async Task<IEnumerable<Customers>> GetAllActivateCustomerAsync()
        {
            return await _dbContext.Customers.Where(x => x.Status == "Active").ToListAsync();
        }

        public async Task<IEnumerable<CustomerListResponseDTO>> GetAllCustomerAsync()
        {
            return await _dbContext.Customers.AsNoTracking().Select(x => new CustomerListResponseDTO
            {
                CustomerId = x.CustomerId,
                FullName = x.MiddleName != null ? x.FirstName + " " + x.MiddleName + " " + x.LastName : x.FirstName + " " + x.LastName,
                Email = x.Email,
                ContactNumber = x.PhoneNumber,
                Rentals = x.RentalAgreements.Count(),
                Status = x.Status
            }).ToListAsync();
        }

        public async Task<Customers?> GetCustomerByIdAsync(Guid id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
