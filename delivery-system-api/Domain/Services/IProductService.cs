using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Services.Communications;

namespace delivery_system_api.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetFilteredProductsAsync(string categoryId);

        Task<Product> GetProductByIdAsync(int productId);
        Task<ProductResponse> AddProductAsync(Product product);
        Task<ProductResponse> UpdateProductAsync(Product product);
        Task<ProductResponse> DeleteProductAsync(int productId);
    }
}
