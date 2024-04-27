using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmallBusinessApp.Server.Model
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string HashedPassword { get; set; } = string.Empty;
    }
}
