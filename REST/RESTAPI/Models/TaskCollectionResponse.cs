using System.Collections.Generic;

namespace RESTAPI.Models
{
    public class TaskCollectionResponse
    {
        public TaskCollectionResponse()
        {
            this.Links = new List<Link>();
        }
        public List<Task> Tasks { get; set; }
        public List<Link> Links { get; set; }
    }
}