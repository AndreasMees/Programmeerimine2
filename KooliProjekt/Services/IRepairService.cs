using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IRepairService
    {
        Task<List<Repair>> GetAllAsync();
        Task<Repair?> GetByIdAsync(int id);
        Task AddAsync(Repair repair);
        Task DeleteAsync(int id);
    }
}
