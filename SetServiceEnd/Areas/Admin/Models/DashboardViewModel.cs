using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetServiceEnd.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int UsersCount { get; set; }
        public int ServicesCount { get; set; }
        public int ComapniesCount { get; set; }
    }
}