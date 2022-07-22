using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> ListAsync();
        Task<int> AddAsync(Order order);
        Task Update(Order order);
        Task<Order> GetByIdAsync(int id);
        Task Delete(Order order);
    }
}
