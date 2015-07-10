using RESTAPI.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RESTAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new BasicAuthenticationMessageHandler());
            config.MessageHandlers.Add(new TaskDataSecurityMessageHandler());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
