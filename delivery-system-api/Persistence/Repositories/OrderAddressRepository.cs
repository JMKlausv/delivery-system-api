using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Extensions;
using delivery_system_api.Persistence.Contexts;

namespace delivery_system_api.Persistence.Repositories
{
    public class OrderAddressRepository : IOrderAddressRepository
    {
        private readonly DeliverySystemDbContext _context;

        public OrderAddressRepository(DeliverySystemDbContext context)
        {
            _context = context;

        }
        public async Task AddAsync(OrderAddress orderAddress)
        {
            await _context.OrderAddresses.AddAsync(orderAddress);
           
        }

        public async Task Delete(OrderAddress orderAddress)
        {
             _context.OrderAddresses.Remove(orderAddress);
        }

        public async Task<OrderAddress> GetByIdAsync(int id)
        {
           return await _context.OrderAddresses.FindAsync(id);
        }

        public async Task<IEnumerable<OrderAddress>> ListAsync()
        {
            return  _context.OrderAddresses.ToList();
        }

        public async Task Update(OrderAddress orderAddress)
        {
            _context.DetachLocal<OrderAddress>(orderAddress, orderAddress.Id);
              _context.OrderAddresses.Update(orderAddress);
        }
    }
}
