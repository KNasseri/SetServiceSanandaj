using BLL.Repository.Users;
using BOL.DBContext;
using BOL.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SetServiceEnd.Models;
using SetServiceEnd.Areas.Admin.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace SetServiceEnd.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly IUsersService usersService;

        public UserController()
        {
            usersService = new UsersService();
        }



        // GET: Admin/User
        public ActionResult Index()
        {
            var model = usersService.GetAllUsers().Select(x => new Models.UsersViewModel
            {
                Name = x.Name,
                Family = x.Family,
                Mobile = x.PhoneNumber,
                NationalCode = x.Nationalcode,
                Id = x.Id
            }).AsEnumerable();

            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = usersService.GetUserById(id);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Family = user.Family
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel model)
        {
            var user = usersService.GetUserById(model.Id);

            user.Name = model.Name;
            user.Family = model.Family;
            usersService.UpdateUser(user);

            return RedirectToAction("Index", "User", new { area = "Admin" });
        }
        /// <summary>
        /// وظیفه نمایش صفحه ورود اطلاعات را برعهده دارد
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateUsersViewModel();

            return View(model);
        }



        /// <summary>
        /// اطلاعات رسیده از طرف کاربر را بصورت پست  دریافت و پردازش میکند
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUsersViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("لطفا اطلاعات را درست وارد نمایید");

                using (var context = new SetServiceDbContext())
                {
                    var userManager = new UserManager<User>(new UserStore<User>(context));

                    var user = new User
                    {
                        Name = model.Name,
                        Family = model.Family,
                        Nationalcode = model.NationalCode,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        UserName = model.NationalCode,
                    };

                    var createUser = userManager.Create(user, "A123a12!");


                    context.SaveChanges();
                }

                return RedirectToAction("Sucssed", "User",new { area = "Admin" });

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Name", ex.Message);
            }

            return View();
        }
        public ActionResult Sucssed()
        {
            return View();
        }



    }
}