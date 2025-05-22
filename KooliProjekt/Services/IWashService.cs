using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IWashService
    {
        Task<List<Wash>> GetAllAsync();
        Task<Wash?> GetByIdAsync(int id);
        Task AddAsync(Wash wash);
        Task DeleteAsync(int id);
    }
}
