using delivery_system_api.Domain.Models;

namespace delivery_system_api.Domain.Services.Communications
{
    public class ProductResponse:BaseResponse
    {
        public Product Product { get; set; }
        public ProductResponse(bool success, string message, Product product) : base(success, message)
        {
            Product = product;
        }
        public ProductResponse(Product product) : this(true, string.Empty, product)
        {

        }
        public ProductResponse(string message) : this(false, message, null)
        {

        }
    }

}