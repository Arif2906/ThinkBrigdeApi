using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CodiNovaProductApi.Helper
{
    public class CustomAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext filterContext)
        {
            if (filterContext.Request.RequestUri.AbsoluteUri.IndexOf("api_key")==-1)
            {   
                             
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                return;
            }
            else
            {
                var arr=filterContext.Request.GetQueryNameValuePairs();
                var goodreq = false;
                foreach(var obj in arr)
                {
                    if (obj.Key == "api_key" && obj.Value=="admin" )
                    {
                        goodreq = true;                 
                    }                   
                }
                if (!goodreq)
                {
                    filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    return;
                }

            }                       

            base.OnAuthorization(filterContext);
        }
    }
}