using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class RepairService : IRepairService
    {
        private readonly ApplicationDbContext _context;

        public RepairService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Repair>> GetAllAsync()
        {
            return await _context.Repairs.ToListAsync();
        }

        public async Task<Repair?> GetByIdAsync(int id)
        {
            return await _context.Repairs.FindAsync(id);
        }

        public async Task AddAsync(Repair repair)
        {
            _context.Repairs.Add(repair);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repair = await _context.Repairs.FindAsync(id);
            if (repair != null)
            {
                _context.Repairs.Remove(repair);
                await _context.SaveChangesAsync();
            }
        }
    }
}
