using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetServiceEnd.Models
{
    public class HomeViewModel
    {
        public List<ServiceToShowModel> Services { get; set; }
    }


    public class ServiceToShowModel
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
    }
}