using BLL.Repository.Categories;
using BLL.Repository.Companies;
using BLL.Repository.Services;
using BOL.Domain;
using SetServiceEnd.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetServiceEnd.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServicesService servicesService;
        private readonly ICategoryService categoryService;
        private readonly ICompanyService companyService;

        public ServiceController()
        {
            servicesService = new ServicesService();
            categoryService = new CategoryService();
            companyService = new CompanyService();
        }


        // GET: Admin/Service
        public ActionResult Index()
        {
            var model = servicesService.GetAllServices().Select(x => new ServiceViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Intro = x.Intro,
                Category = categoryService.GetCategoryById(x.CategoryId).Name,
                Company = companyService.GetCompanyById(x.CompanyId).Name,
                Url = x.Url
            });

            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            var companies = companyService.GetAllCompanies().Select(x => new SelectListItem
            {
                 Text = x.Name,
                 Value = x.Id.ToString()
            }).ToList();

            var categories = categoryService.GetAllCategories().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            var model = new CreateServiceViewModel
            {
                Companies = companies,
                Categories = categories
            };

            return View(model);
        }



        [HttpPost]
        public ActionResult Create(CreateServiceViewModel model)
        {
            var service = new Service
            {
                Name = model.Name,
                Icon = model.Icon,
                Url = model.Url,
                Intro = model.Intro,
                Description = model.Description,
                CategoryId = model.CategoryId,
                CompanyId = model.CompanyId
            };

            servicesService.InsertService(service);

            return RedirectToAction("Index", "Service", new { area = "Admin" });
        }

    }
}