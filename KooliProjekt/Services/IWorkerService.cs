using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IWorkerService
    {
        Task<List<Worker>> GetAllAsync();
        Task<Worker?> GetByIdAsync(int id);
        Task AddAsync(Worker worker);
        Task UpdateAsync(Worker worker);
        Task DeleteAsync(int id);
    }
}