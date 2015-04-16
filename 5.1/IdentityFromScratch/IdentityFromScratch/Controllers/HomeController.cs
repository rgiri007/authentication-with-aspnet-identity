using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using IdentityFromScratch.Models;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var email = "foo@bar.com";
            var password = "Passw0rd";
            var user = await UserManager.FindByEmailAsync(email);
            var roles = ApplicationRoleManager.Create(HttpContext.GetOwinContext());

            if (!await roles.RoleExistsAsync(SecurityRoles.Admin))
            {
                await roles.CreateAsync(new IdentityRole {Name = SecurityRoles.Admin});
            }

            if (!await roles.RoleExistsAsync(SecurityRoles.IT))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.IT });
            }

            if (!await roles.RoleExistsAsync(SecurityRoles.Accounting))
            {
                await roles.CreateAsync(new IdentityRole { Name = SecurityRoles.Accounting });
            }


            if (user == null)
            {
                user = new CustomUser
                {
                    UserName = email,
                    Email = email,
                    FirstName = "Super",
                    LastName = "Admin"
                };

                await UserManager.CreateAsync(user, password);
            }
            else
            {
                //await UserManager.AddToRoleAsync(user.Id, SecurityRoles.Admin);
            }


            return Content("Hello, Index");
        }
    }
}