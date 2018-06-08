using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetServiceEnd.Areas.Admin.Models
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [Display(Name = "شماره موبایل")]
        public string Mobile { get; set; }
        [Display(Name = "شماره ملی")]
        public string NationalCode { get; set; }

    }


    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
    }
}