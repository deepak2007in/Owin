using System.Collections.Generic;

namespace RESTAPI.Models
{
    public class TaskCollectionResponse
    {
        public List<Task> Tasks { get; set; }
        public List<Link> Links { get; set; }
    }
}