using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public class OperationService : IOperationService
    {
        private readonly ApplicationDbContext _context;

        public OperationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Operation>> GetAllAsync(int page, int pageSize)
        {
            return await _context.Operations
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Operation> GetByIdAsync(int id)
        {
            return await _context.Operations.FindAsync(id);
        }

        public async Task AddAsync(Operation operation)
        {
            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Operation operation)
        {
            _context.Operations.Update(operation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation != null)
            {
                _context.Operations.Remove(operation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
