using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetServiceEnd.Areas.Admin.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }      
        [Display(Name = "نام")]
        public string Name { get; set; }
        [Display(Name = "توضیح مختصر")]
        public string Intro { get; set; }
        [Display(Name = "شرکت")]
        public string Company { get; set; }
        [Display(Name = "دسته")]
        public string Category { get; set; }
        public string Url { get; set; }
    }

    public class CreateServiceViewModel
    {
        [Display(Name = "نام")]
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Intro { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }

        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Companies { get; set; }
    }
}