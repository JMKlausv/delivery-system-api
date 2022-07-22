using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace delivery_system_api.Resources
{
    public class OrderAddressResource
    {
        [Required]
        [StringLength(200)]
        public string Region { get; set; }
        [Required]
        [StringLength(200)]
        public string City { get; set; }
        [StringLength(200)]
        public string? SpecificAddress { get; set; }
        [StringLength(200)]
        public string? CustomerEmail { get; set; }
        [StringLength(200)]
        public string? Phone { get; set; }

    }
}
