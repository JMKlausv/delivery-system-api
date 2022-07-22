namespace delivery_system_api.Resources
{
    public class SaveOrderResource
    {
        public int ViechleId { get; set; }
        public float TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
