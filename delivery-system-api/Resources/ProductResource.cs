using System.ComponentModel.DataAnnotations;

namespace delivery_system_api.Resources
{
    public class ProductResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public int quantity { get; set; }
        public string? imageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
