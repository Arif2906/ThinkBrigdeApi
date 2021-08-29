using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace CodiNovaProductApi.Helper
{
    public static class LoggedInUserInfo
    {
        public static ClaimsIdentity identity { private get; set; }

        public static string GetLoggedInUserName()
        {
            return identity.Claims.FirstOrDefault(a => a.Type == "loggedInUser").Value;
        }

        public static string GetLoggedInUserRole()
        {
            return identity.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Role).Value;
        }
    }
}