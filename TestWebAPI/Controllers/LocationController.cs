using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace TestWebAPI.Controllers
{
    [Authorize]
    public class LocationController : ApiController
    {
        private static string trustedCallerClientId = ConfigurationManager.AppSettings["ida:trustedCallerClientId"];
        public Models.Location GetLocation(string cityName)
        {
            string currentCallerClientId = ClaimsPrincipal.Current.FindFirst("appid").Value;
            if(currentCallerClientId == trustedCallerClientId)
            {
                return new Models.Location() { Latitude = 10, Longitude = 20 };

            }
            else
            {
                throw new HttpResponseException(
                    new HttpResponseMessage {  StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Only Trusted callers are allowed. Your identity: " +currentCallerClientId}
                    );
            }

        }
    }
}
