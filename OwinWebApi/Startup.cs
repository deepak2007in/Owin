using Owin;
using System.Net;
using System.Web.Http;

namespace OwinWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var listener = (HttpListener)app.Properties["System.Net.HttpListener"];
            listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }
}
