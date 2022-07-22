using System.ComponentModel.DataAnnotations;

namespace delivery_system_api.Domain.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]   
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Role { get; set; }    
    }
}
