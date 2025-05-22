using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface ICarDisplacementService
    {
        Task<List<CarDisplacement>> GetAllAsync();
        Task<CarDisplacement?> GetByIdAsync(int id);
        Task AddAsync(CarDisplacement displacement);
        Task DeleteAsync(int id);
    }
}
