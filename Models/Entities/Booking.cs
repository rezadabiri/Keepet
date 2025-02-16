using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.Entities
{
    // Booking.cs
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ServiceId { get; set; }
        public int PetId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Pending, Approved, Cancelled
        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ApplicationUser User { get; set; }
        public Service Service { get; set; }
        public Pet Pet { get; set; }
    }
}
