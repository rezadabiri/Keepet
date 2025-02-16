using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.ViewModels
{
    public class ReviewViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Range(1, 5, ErrorMessage = "{0} باید بین ۱ تا ۵ باشد")]
        public int Rating { get; set; }

        [Display(Name = "متن نظر")]
        public string Comment { get; set; }
    }
}
