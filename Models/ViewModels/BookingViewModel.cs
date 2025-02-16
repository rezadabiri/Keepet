using System.ComponentModel.DataAnnotations;

namespace KeepetFinal.Models.ViewModels
{
    public class BookingViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public DateTime EndDate { get; set; }

        [Display(Name = "وضعیت")]
        public string Status { get; set; }

        [Display(Name = "هزینه کل")]
        public decimal TotalPrice { get; set; }
    }
}
