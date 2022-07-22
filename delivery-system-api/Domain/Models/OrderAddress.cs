using delivery_system_api.Extensions;
using System.ComponentModel.DataAnnotations;

namespace delivery_system_api.Domain.Models
{
    public class OrderAddress: IIdentity
    {
        public int Id { get; set; } 
        [Required]  
        [StringLength(200)]  
        public string Region { get; set; }
        [Required]
        [StringLength(200)]
        public string City { get; set; }
        [StringLength(200)]
        public string? SpecificAddress { get; set; }
        [StringLength(200)]
        [EmailAddress]
        public string? CustomerEmail { get; set; }
        [StringLength(200)]
        [Phone]
        public string? Phone { get; set; }  
       public virtual Order Order { get; set; }  
        public int OrderId { get; set; }    

    }
}
