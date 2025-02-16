using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.Entities
{
    // Service.cs
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ServiceType { get; set; } // Boarding, Walking, etc.
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Availability { get; set; } // e.g., "Weekdays: 9 AM - 5 PM"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ApplicationUser User { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
