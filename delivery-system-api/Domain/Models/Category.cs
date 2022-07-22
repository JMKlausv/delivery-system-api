using delivery_system_api.Extensions;
using System.ComponentModel.DataAnnotations;

namespace delivery_system_api.Domain.Models
{
    public class Category: IIdentity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int OrderCount { get; set; } = 0;
    }
}
