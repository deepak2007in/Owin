using Owin;

namespace OwinWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new MyHttpConfiguration();
            app.UseWebApi(config);
        }
    }
}
