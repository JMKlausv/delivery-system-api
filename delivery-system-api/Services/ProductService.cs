using delivery_system_api.Domain.Models;
using delivery_system_api.Domain.Repositories;
using delivery_system_api.Domain.Services;
using delivery_system_api.Domain.Services.Communications;

namespace delivery_system_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> AddProductAsync(Product product)
        {

            try
            {
                await _productRepository.AddAsync(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);

            }
            catch (Exception ex)
            {
               var category= await _productRepository.GetByIdAsync(product.CategoryId);
                if(category == null)
                {
                    return new ProductResponse("could not add product : category not found");
                }

                return new ProductResponse($"could not add product : {ex.Message}");
            }
        }

        public async Task<ProductResponse> DeleteProductAsync(int productId)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productId);
            if (existingProduct == null)
            {
                return new ProductResponse("Product not found!");
            }
            try
            {
                await _productRepository.Delete(existingProduct);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(true, string.Empty, null);
            }
            catch (Exception ex)
            {
                return new ProductResponse(ex.Message);
            }
        }

        public Task<IEnumerable<Product>> GetFilteredProductsAsync(string categoryId)
        {
            return _productRepository.ListFilteredAsync(categoryId);
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product Not found");
            }
            return product;
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return _productRepository.ListAsync();
        }

        public async Task<ProductResponse> UpdateProductAsync(Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.Id);
            if (existingProduct == null)
            {
                return new ProductResponse("Product not found!");
            }
            try
            {
                await _productRepository.Update(product);
                await _unitOfWork.CompleteAsync();
                return new ProductResponse(product);

            }
            catch (Exception ex)
            {

                return new ProductResponse($"Could not update product : {ex.Message}");
            }
        }
    }
}
