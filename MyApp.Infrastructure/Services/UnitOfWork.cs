using MyApp.Application.Interfaces;
using MyApp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync(CancellationToken cToken = default)
        {
            await _context.Database.BeginTransactionAsync(cToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cToken = default)
        {
            var transaction = _context.Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.CommitAsync(cToken);
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cToken = default)
        {
            var transaction = _context.Database.CurrentTransaction;
            if (transaction != null)
            {
                await transaction.RollbackAsync(cToken);
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cToken = default)
        {
            return await _context.SaveChangesAsync(cToken);
        }
    }
}
