﻿using Owin;
using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.Owin;

[assembly:OwinStartup(typeof(BrowserToWebApp.App_Start.Startup))]
namespace BrowserToWebApp.App_Start
{
    public class Startup
    {
        private static string clientId = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string aadInstance = ConfigurationManager.AppSettings["ida:AADInstance"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string postLogoutRedirectUri = ConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];

        string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }


        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                   ClientId = clientId,
                   Authority = authority,
                   PostLogoutRedirectUri = postLogoutRedirectUri,
                   Notifications = new OpenIdConnectAuthenticationNotifications
                   {
                       AuthenticationFailed = context =>
                       {
                           context.HandleResponse();
                           context.Response.Redirect("/Error/message=" + context.Exception.Message);
                           return Task.FromResult(0);
                       }
                   }
                });
        }
    }
}