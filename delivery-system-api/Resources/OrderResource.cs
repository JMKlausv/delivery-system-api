namespace delivery_system_api.Resources
{
    public class OrderResource
    {
        public int ViechleId { get; set; }

        public IEnumerable<OrderProductItemResource> Products { get; set; }

        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderAddressResource OrderAddress { get; set; }
    }
}
