using delivery_system_api.Extensions;

namespace delivery_system_api.Domain.Models
{
    public class OrderProductItem: IIdentity
    {
        public int Id { get; set; } 
        public virtual Product Product { get; set; }  
        public int ProductId { get; set; }  
        public int quantity { get; set; }   
        public virtual Order Order { get; set; }   
        public int OrderId { get; set; }
    }
}
