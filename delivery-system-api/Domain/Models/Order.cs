using delivery_system_api.Extensions;

namespace delivery_system_api.Domain.Models
{
    public class Order: IIdentity
    {
        public int Id { get; set; }
        public  Viechle Viechle { get; set; } 
        public int ViechleId { get; set; }  

        public   IEnumerable<OrderProductItem> Products { get; set; }

        public float TotalPrice { get; set; }   
        public DateTime OrderDate { get; set; } 
        public DateTime DeliveryDate { get; set; }  
        public  OrderAddress OrderAddress { get; set; } 


    }
}
