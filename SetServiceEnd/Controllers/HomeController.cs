using BLL.Repository.Services;
using SetServiceEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetServiceEnd.Controllers
{
    public class HomeController : Controller
    {
        IServicesService servicesService = new ServicesService();

        public ActionResult Index()
        {
            var services = servicesService.GetAllServices().Select(x => new ServiceToShowModel
            {
                Id = x.Id,
                Icon = x.Icon,
                Intro = x.Intro,
                Name = x.Name,
                Url = x.Url
            }).ToList();

            var model = new HomeViewModel
            {
                Services = services
            };

            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}