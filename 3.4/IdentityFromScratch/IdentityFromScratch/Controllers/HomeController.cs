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
                var result = await SignInManager.PasswordSignInAsync(user.UserName, password, true, false);

                if (result == SignInStatus.Success)
                {
                    return Content("Hello, " + user.FirstName + " " + user.LastName);
                }
                //user.FirstName = "Super";
                //user.LastName = "Admin";

                //await manager.UpdateAsync(user);
            }


            return Content("Hello, Index");
        }
    }
}