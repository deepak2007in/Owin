using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUrl = "http://localhost:53687/";
            var container = new Default.Container(new Uri(serviceUrl));
            var product = new ODataClient.ODataWebAPI.Models.Product()
            {
                Id = 1,
                Name = "Yo-Yo",
                Category = "Toys",
                Prize = 5.95M
            };

            // AddProduct(container: container, product: product);
            ListAllProducts(container: container);
            Console.ReadLine();
        }

        static void ListAllProducts(Default.Container container)
        {
            foreach(var product in container.Products)
            {
                Console.WriteLine("{0} {1} {2}", product.Name, product.Prize, product.Category);
            }
        }

        static void AddProduct(Default.Container container, ODataClient.ODataWebAPI.Models.Product product)
        {
            container.AddToProducts(product: product);
            var serviceResponse = container.SaveChanges();
            foreach(var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
        }
    }
}
