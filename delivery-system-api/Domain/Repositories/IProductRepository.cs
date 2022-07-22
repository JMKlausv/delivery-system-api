using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
        Task<IEnumerable<Product>> ListFilteredAsync(string categoryId);
        Task AddAsync(Product category);
        Task Update(Product category);
        Task<Product> GetByIdAsync(int id);
        Task Delete(Product category);
    }
}
