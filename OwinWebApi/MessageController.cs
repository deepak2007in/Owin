using System.Web.Http;

namespace OwinWebApi
{
    public class Greeting
    {
        public string Text { get; set; }
    }
    public class MessageController : ApiController
    {
        public Greeting Get()
        {
            return new Greeting
            {
                Text = "Hello World"
            };
        }
    }
}
