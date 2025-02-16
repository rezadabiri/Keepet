using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.Entities
{
    // Review.cs
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ServiceId { get; set; }
        public int Rating { get; set; } // 1 to 5
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ApplicationUser User { get; set; }
        public Service Service { get; set; }
    }
}
