using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmallBusinessApp.Server.Model
{
    public class CustomerDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;
    }
}
