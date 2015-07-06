using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUrl = "http://services.odata.org/v4/(S(34wtn2c0hkuk5ekg0pjr513b))/TripPinServiceRW/";
            var container = new DefaultContainer(new Uri(serviceUrl));

            var deepak = new Person
            {
                UserName = "deepak.agnihotri1",
                FirstName = "Deepak1",
                LastName = "Agnihotri1",
                Emails = new ObservableCollection<string> { "deepak.agnihotri1@9lenses.com" },
                AddressInfo = new ObservableCollection<Location>
                {
                    new Location
                    {
                        Address = "204, Shapath",
                        City = new City {CountryRegion = "India", Name = "Ahmedabad", Region = "Gujarat"}
                    }
                },
                Gender = PersonGender.Male,
                Concurrency = 635519729375200400
            };

            AddPerson(container: container, person: deepak);
            ListAllProducts(container: container);
            Console.ReadLine();
        }

        static void ListAllProducts(DefaultContainer container)
        {
            foreach(var person in container.People)
            {
                Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
            }
        }

        static void AddPerson(DefaultContainer container, ODataClient.Person person)
        {
            container.AddObject("People", person);
            var serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: Status Code {0}", operationResponse.StatusCode);
            }
        }
    }
}
