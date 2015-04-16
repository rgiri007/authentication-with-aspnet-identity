using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace IdentityFromScratch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var context = new IdentityDbContext<IdentityUser>(); // DefaultConnection
            var store = new UserStore<IdentityUser>(context);
            var manager = new UserManager<IdentityUser>(store);

            var email = "foo@bar.com";
            var password = "Passw0rd";
            var user = await manager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = email,
                    Email = email
                };

                await manager.CreateAsync(user, password);
            }


            return Content("Hello, Index");
        }
    }
}