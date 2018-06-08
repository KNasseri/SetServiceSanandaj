using BLL.Repository.Companies;
using BLL.Repository.Services;
using BLL.Repository.Users;
using SetServiceEnd.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetServiceEnd.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IServicesService servicesService;
        private readonly IUsersService userService;
        private readonly ICompanyService companyService;


        public HomeController()
        {
            servicesService = new ServicesService();
            userService = new UsersService();
            companyService = new CompanyService();
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = new DashboardViewModel
            {
                UsersCount = userService.GetAllUsers().Count(),
                ComapniesCount = companyService.GetAllCompanies().Count(),
                ServicesCount = servicesService.GetAllServices().Count()
            };
            return View(model);
        }
    }
}