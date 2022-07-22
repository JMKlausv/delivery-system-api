using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Extensions;
using delivery_system_api.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace delivery_system_api.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DeliverySystemDbContext _context;

        public ProductRepository(DeliverySystemDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return    _context.products.Include(p => p.Category).ToList();
        }
        public async Task AddAsync(Product product)
        {
            await _context.products.AddAsync(product);

        }
        public async Task<Product> GetByIdAsync(int id)

        {
            return await _context.products.Include(p => p.Category).FirstOrDefaultAsync();
        }

        public async Task Update(Product product)
        {
            _context.DetachLocal<Product>(product, product.Id);
            _context.products.Update(product);
        }
        public async Task Delete(Product product)
        {
            _context.products.Remove(product);
        }

        public async Task<IEnumerable<Product>> ListFilteredAsync(string categoryId)

        {
           

            return _context.products.Where(p => p.CategoryId == int.Parse( categoryId)); 
        }
    }
}
