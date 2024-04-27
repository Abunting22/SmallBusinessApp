using System.ComponentModel.DataAnnotations;

namespace SmallBusinessApp.Server.Model
{
    public class Payment
    {
        [Required]
        public Guid TransactionId { get; set; }
        [Required] 
        public int CustomerId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public int TotalAmount { get; set; }
    }
}
