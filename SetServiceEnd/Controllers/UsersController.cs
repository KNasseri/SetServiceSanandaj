using BOL.DBContext;
using BOL.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SetServiceEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SetServiceEnd.Controllers
{
    public class UsersController : Controller
    {

      

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
                if(!ModelState.IsValid)
                    throw new Exception("لطفا اطلاعات را درست وارد نمایید");

                using(var context = new SetServiceDbContext())
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

                return RedirectToAction("sucssed", "Users",new { area = "" });

            }catch(Exception ex)
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