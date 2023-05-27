using System.ComponentModel.DataAnnotations;

namespace RostrosFelices.Models
{
    public class Registro
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<User>? Users { get; set; } = default!;
    }
}
