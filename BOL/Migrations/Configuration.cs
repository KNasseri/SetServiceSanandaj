namespace BOL.Migrations
{
    using Domain;
    using Enums;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BOL.DBContext.SetServiceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BOL.DBContext.SetServiceDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<User>(new UserStore<User>(context));

            if (!roleManager.RoleExists(UserRoles.Admin.ToString()))
            {
                var adminRole = new IdentityRole
                {
                    Name = UserRoles.Admin.ToString()
                };

                roleManager.Create(adminRole);

                var adminUser = new User
                {
                    Email = "k.naseri96@gmail.com",
                    Name = "خانم",
                    Family = "ناصری",
                    Nationalcode = "3333333333",
                    PhoneNumber = "09182223333",
                    UserName = "k.naseri96@gmail.com",
                    EmailConfirmed = true,
                };

                var result = userManager.Create(adminUser, "@123abcABC");

                if (result.Succeeded)
                    userManager.AddToRole(adminUser.Id, UserRoles.Admin.ToString());
            }

            if (!roleManager.RoleExists(UserRoles.Customer.ToString()))
            {
                roleManager.Create(new IdentityRole { Name = UserRoles.Customer.ToString() });
            }

            context.SaveChanges();
        }
    }
}
