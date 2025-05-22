using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface ICarCareService
    {
        Task<List<CarCare>> GetAllAsync();
        Task<CarCare?> GetByIdAsync(int id);
        Task AddAsync(CarCare carCare);
        Task DeleteAsync(int id);
    }
}
