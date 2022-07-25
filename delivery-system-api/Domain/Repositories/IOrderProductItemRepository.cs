using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Repositories
{
    public interface IOrderProductItemRepository
    {
        Task<IEnumerable<OrderProductItem>> ListAsync();
        void Add(OrderProductItem orderProductItem);
        void Update(OrderProductItem orderProductItem);
        Task<OrderProductItem> GetByIdAsync(int id);
        void Delete(OrderProductItem orderProductItem);
    }
}
