using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.ViewModels
{
    public class ServiceViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نوع خدمات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string ServiceType { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [Range(0, double.MaxValue, ErrorMessage = "{0} باید عددی معتبر باشد")]
        public decimal Price { get; set; }

        [Display(Name = "دسترسی")]
        public string Availability { get; set; }
    }
}
