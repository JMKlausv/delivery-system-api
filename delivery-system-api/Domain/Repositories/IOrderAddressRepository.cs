using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Repositories
{
    public interface IOrderAddressRepository
    {
        Task<IEnumerable<OrderAddress>> ListAsync();
        Task AddAsync(OrderAddress orderAddress);
        Task Update(OrderAddress orderAddress);
        Task<OrderAddress> GetByIdAsync(int id);
        Task Delete(OrderAddress orderAddress);
    }
}
