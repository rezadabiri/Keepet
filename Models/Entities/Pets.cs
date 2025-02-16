using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.Entities
{
    // Pet.cs
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Dog, Cat, etc.
        public string Breed { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public string SpecialNeeds { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ApplicationUser User { get; set; }
    }
}
