using System.Collections.Generic;
namespace RESTAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Link> Links { get; set; }
    }
}