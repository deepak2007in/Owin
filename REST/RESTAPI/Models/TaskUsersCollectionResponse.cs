using System.Collections.Generic;

namespace RESTAPI.Models
{
    public class TaskUsersCollectionResponse
    {
        public List<User> Users { get; set; }
        public List<Link> Links { get; set; }
    }
}