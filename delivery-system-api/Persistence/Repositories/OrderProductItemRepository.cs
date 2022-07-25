using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Extensions;
using delivery_system_api.Persistence.Contexts;

namespace delivery_system_api.Persistence.Repositories
{
    public class OrderProductItemRepository : IOrderProductItemRepository
    {
        private readonly DeliverySystemDbContext _context;

        public OrderProductItemRepository(DeliverySystemDbContext context)
        {
          _context = context;
        }
        public void  Add(OrderProductItem orderProductItem)
        {
            _context.DetachLocal<OrderProductItem>(orderProductItem, orderProductItem.Id);

             _context.OrderProductItems.Add(orderProductItem); 
        }

        public   void Delete(OrderProductItem orderProductItem)
        {
            _context.DetachLocal<OrderProductItem>(orderProductItem, orderProductItem.Id);

             _context.OrderProductItems.Remove(orderProductItem);

        }

        public async Task<OrderProductItem> GetByIdAsync(int id)
        {
            return await _context.OrderProductItems.FindAsync(id);
        }

        public async Task<IEnumerable<OrderProductItem>> ListAsync()
        {
            return  _context.OrderProductItems.ToList();
        }

        public void Update(OrderProductItem orderProductItem)
        {
            _context.DetachLocal<OrderProductItem>(orderProductItem, orderProductItem.Id);
            _context.OrderProductItems.Update(orderProductItem);
        }
    }
}
