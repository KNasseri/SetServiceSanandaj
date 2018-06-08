using BLL.Repository.Services;
using SetServiceEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetServiceEnd.Controllers
{

    public class ServicesController : Controller
    {
        IServicesService servicesService = new ServicesService();

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Create()
        {
            return View();
        }


        public ActionResult View(int id)
        {
            var service = servicesService.GetServiceById(id);
            var model = new ServiceDetailsModel
            {
                Name = service.Name,
                Description = service.Description
            };

            return View(model);
        }
    }
}