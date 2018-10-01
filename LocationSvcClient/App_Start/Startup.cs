using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.Cookies;
using System.Configuration;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Owin.Security;

[assembly: OwinStartup(typeof(LocationSvcClient.App_Start.Startup))]
namespace LocationSvcClient.App_Start
{
    public class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string appKey = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string tenant = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string postingLogoutRedirectUrl  = ConfigurationManager.AppSettings["ida:ClientId"];

        public void Configuration(IAppBuilder)
        {
            ConfigureAuth(app);
        }

        public void ConfigureAuth(IAppBuilder app)
        {

        }
    }
}