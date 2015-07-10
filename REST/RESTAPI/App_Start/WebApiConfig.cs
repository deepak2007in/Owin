using System.Web.Http;

namespace RESTAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MessageHandlers.Add(new BasicAuthenticationMessageHandler());
            //config.MessageHandlers.Add(new TaskDataSecurityMessageHandler());
            
            //var builder = new SecurityTokenBuilder();
            //var reader = new ConfigurationReader();
            //config.MessageHandlers.Add(new JwtAuthenticationMessageHandler
            //{
            //    AllowedAudience = reader.AllowedAudience,
            //    Issuer = reader.Issuer,
            //    SigningToken = builder.CreateFromKey(reader.SymmetricKey)
            //});

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}
