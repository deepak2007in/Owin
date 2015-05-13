using Microsoft.Owin.Hosting;
using OwinSample;
using System;

namespace CustomOwinHost
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseUrl = "http://localhost:5000/";

            using (WebApp.Start<Startup>(new StartOptions(url: baseUrl)))
            {
                Console.WriteLine("Press Enter to quit.");
                Console.ReadKey();
            }
        }
    }
}
