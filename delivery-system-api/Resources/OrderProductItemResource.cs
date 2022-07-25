using delivery_system_api.Domain.Models;

namespace delivery_system_api.Resources
{
    public class OrderProductItemResource
    {
        public int ProductId { get; set; }
        public int quantity { get; set; }
    }
}
