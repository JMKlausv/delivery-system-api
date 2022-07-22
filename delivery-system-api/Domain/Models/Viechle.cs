using delivery_system_api.Extensions;
using System.ComponentModel.DataAnnotations;

namespace delivery_system_api.Domain.Models
{
    public class Viechle: IIdentity
    {
        [Key]
        public int Id { get; set; } 
        [Required]  
        [StringLength(255)] 
        public string Model { get; set; }
        [Required]
        [StringLength(255)]
        public string Type { get; set; }
        [Required]
        [StringLength(255)]
        public string  LicenceNumber { get; set; }
       
    }
}
