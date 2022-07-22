using delivery_system_api.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace delivery_system_api.Domain.Models
{
    public class Product:IIdentity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public int quantity { get; set; }
        public string? imageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
  
    }
}
