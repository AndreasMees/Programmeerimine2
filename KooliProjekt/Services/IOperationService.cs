using KooliProjekt.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IOperationService
    {
        Task<IEnumerable<Operation>> GetAllAsync(int page, int pageSize);
        Task<Operation> GetByIdAsync(int id);
        Task AddAsync(Operation operation);
        Task UpdateAsync(Operation operation);
        Task DeleteAsync(int id);
    }
}
