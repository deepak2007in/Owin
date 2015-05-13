using Microsoft.Owin;
using System;
using System.Threading.Tasks;

namespace OwinSample
{
    public class LoggerMiddleWare : OwinMiddleware
    {
        public LoggerMiddleWare(OwinMiddleware next) : base(next)
        {

        }

        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("Middleware Begin");
            await this.Next.Invoke(context);
            Console.WriteLine("Middleware End");
        }
    }
}