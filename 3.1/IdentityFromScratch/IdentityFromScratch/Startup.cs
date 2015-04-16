using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityFromScratch.Startup))]
namespace IdentityFromScratch
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}