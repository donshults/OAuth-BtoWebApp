using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Host;
using Owin;

[assembly: OwinStartup(typeof(TestWebAPI.Startup))]
namespace TestWebAPI
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}