using System.ComponentModel.DataAnnotations;

namespace BaiTap.Models
{
    public class SignIn
    {
        [Required, EmailAddress]
        [Key]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
