using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmallBusinessApp.Server.Model
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
    }
}
