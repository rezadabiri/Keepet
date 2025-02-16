using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.ViewModels
{
    public class PetViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام حیوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Name { get; set; }

        [Display(Name = "نوع حیوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Type { get; set; }

        [Display(Name = "نژاد")]
        public string Breed { get; set; }

        [Display(Name = "سن")]
        public int Age { get; set; }

        [Display(Name = "وزن")]
        public double Weight { get; set; }

        [Display(Name = "نیازهای خاص")]
        public string SpecialNeeds { get; set; }
    }
}
