using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientWithSampleOData
{
    class Program
    {
        static void Main(string[] args)
        {
            CallCustomRest();
            Console.ReadLine();
        }

        async static void CallBuiltInRest()
        {
            var x = ODataDynamic.Expression;
            var client = new ODataClient("http://services.odata.org/v4/TripPinServiceRW/");
            var people = await client
                .For(x.People)
                .Filter(x.Trips.Any(x.Budget > 3000))
                .Top(2)
                .Select(x.FirstName, x.LastName)
                .FindEntriesAsync() as IEnumerable<dynamic>;

            foreach(var person in people)
            {
                Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
            }
        }
    }
}