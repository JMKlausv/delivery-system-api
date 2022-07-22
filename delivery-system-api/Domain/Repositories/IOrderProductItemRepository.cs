using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Repositories
{
    public interface IOrderProductItemRepository
    {
        Task<IEnumerable<OrderProductItem>> ListAsync();
        Task AddAsync(OrderProductItem orderProductItem);
        Task Update(OrderProductItem orderProductItem);
        Task<OrderProductItem> GetByIdAsync(int id);
        Task Delete(OrderProductItem orderProductItem);
    }
}
