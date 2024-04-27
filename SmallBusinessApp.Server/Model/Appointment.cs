using System.ComponentModel.DataAnnotations;

namespace SmallBusinessApp.Server.Model
{
    public class Appointment
    {
        [Required]
        public Guid AppointmentId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public DateTime AppointmentDateTime { get; set; }
    }
}
