using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services.Communications;
using delivery_system_api.Resources;

namespace delivery_system_api.Domain.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<OrderResponse> AddOrderAsync(OrderResource order);
        Task<OrderResponse> UpdateOrderAsync(OrderResource order,int id);
        Task<OrderResponse> DeleteOrderAsync(int orderId);
    }
}
