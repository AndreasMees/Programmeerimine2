using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class CarCareService : ICarCareService
    {
        private readonly ApplicationDbContext _context;

        public CarCareService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarCare>> GetAllAsync()
        {
            return await _context.CarCares.ToListAsync();
        }

        public async Task<CarCare?> GetByIdAsync(int id)
        {
            return await _context.CarCares.FindAsync(id);
        }

        public async Task AddAsync(CarCare carCare)
        {
            _context.CarCares.Add(carCare);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carCare = await _context.CarCares.FindAsync(id);
            if (carCare != null)
            {
                _context.CarCares.Remove(carCare);
                await _context.SaveChangesAsync();
            }
        }
    }
}
