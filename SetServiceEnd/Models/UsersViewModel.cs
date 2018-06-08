using System.ComponentModel.DataAnnotations;

namespace SetServiceEnd.Models
{
    public class UsersViewModel
    {

    }

    public class CreateUsersViewModel
    {
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Display(Name = "شماره ملی")]
        [Required]
        [MaxLength(10, ErrorMessage = "شماره ملی بیشتر از 10 رقم نباشد")]
        [MinLength(10, ErrorMessage ="شماره ملی کمتر از 10 رقم نباشد")]
        //[ValidNationalCode(ErrorMessage = "خطا: آخرین حرف ستاره نیست")]
        public string NationalCode { get; set; }

        [Display(Name = "موبایل")]
        public string PhoneNumber { get; set; } = "0918";

        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبری وارد نمایید")]
        public string Email { get; set; }
    }
    
}