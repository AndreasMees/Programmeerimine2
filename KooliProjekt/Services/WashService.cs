using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class WashService : IWashService
    {
        private readonly ApplicationDbContext _context;

        public WashService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Wash>> GetAllAsync()
        {
            return await _context.Washes.ToListAsync();
        }

        public async Task<Wash?> GetByIdAsync(int id)
        {
            return await _context.Washes.FindAsync(id);
        }

        public async Task AddAsync(Wash wash)
        {
            _context.Washes.Add(wash);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var wash = await _context.Washes.FindAsync(id);
            if (wash != null)
            {
                _context.Washes.Remove(wash);
                await _context.SaveChangesAsync();
            }
        }
    }
}
