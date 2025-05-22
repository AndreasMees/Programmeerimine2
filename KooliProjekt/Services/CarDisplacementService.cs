using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class CarDisplacementService : ICarDisplacementService
    {
        private readonly ApplicationDbContext _context;

        public CarDisplacementService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarDisplacement>> GetAllAsync()
        {
            return await _context.CarDisplacements.ToListAsync();
        }

        public async Task<CarDisplacement?> GetByIdAsync(int id)
        {
            return await _context.CarDisplacements.FindAsync(id);
        }

        public async Task AddAsync(CarDisplacement displacement)
        {
            _context.CarDisplacements.Add(displacement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var displacement = await _context.CarDisplacements.FindAsync(id);
            if (displacement != null)
            {
                _context.CarDisplacements.Remove(displacement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
