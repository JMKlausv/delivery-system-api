using delivery_system_api.Domain.Models;
using delivery_system_api.Extensions;

namespace delivery_system_api.Domain.Repositories
  
{
    public interface IViechleRepository
    {
        Task<IEnumerable<Viechle>> ListAsync();
        Task AddAsync(Viechle viechle);
        Task Update(Viechle viechle);
        Task<Viechle> GetByIdAsync(int id);
        Task Delete(Viechle viechle);
    }
}
