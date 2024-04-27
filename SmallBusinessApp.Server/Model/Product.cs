using System.ComponentModel.DataAnnotations;

namespace SmallBusinessApp.Server.Model
{
    public class Product
    {
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public decimal ProductPrice { get; set; }
    }
}
