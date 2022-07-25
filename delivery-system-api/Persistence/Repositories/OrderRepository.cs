using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Extensions;
using delivery_system_api.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace delivery_system_api.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DeliverySystemDbContext _context;

        public OrderRepository(DeliverySystemDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order.Id;
          
        }

        public async Task Delete(Order order)
        {
          _context.Orders.Remove(order);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Orders
                .Include(o => o.OrderAddress)
                .Include(o => o.Viechle)
                .Include(o => o.Products).ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(o=>o.Id == id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Order>> ListAsync()
        {
 
 
            return await _context.Orders.Include(o => o.OrderAddress)
                .Include(o => o.Viechle)
                .Include(o => o.Products).ThenInclude(p => p.Product).ToListAsync();
        }

        public async Task Update(Order order)
        {
            _context.DetachLocal<Order>(order, order.Id);
            _context.Orders.Update(order);
        }
    }
}
