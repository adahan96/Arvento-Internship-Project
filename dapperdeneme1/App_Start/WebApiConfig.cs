using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace dapperdeneme1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "",
                routeTemplate: ""
                //defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
