using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace OwinWebApi
{
    public class MyHttpConfiguration : HttpConfiguration
    {
        public MyHttpConfiguration()
        {
            ConfigureRoutes();
        }

        private void ConfigureRoutes()
        {
            Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
        }

        private void ConfigureJsonSerialization()
        {
            var jsonSettings = Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
