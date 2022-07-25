namespace delivery_system_api.Resources
{
    public class FetchOrdersResource
    {
        public int Id { get; set; } 
        public int ViechleId { get; set; }
        public string ViechleLicenceNumber { get; set; }

        public IEnumerable<FetchOrdersProductItemResource> Products { get; set; }

        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderAddressResource OrderAddress { get; set; }
    }
}
