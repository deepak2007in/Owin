using System;
using System.Collections.Generic;
namespace RESTAPI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Int64 Number { get; set; }
        public List<User> Assignee { get; set; }
        public List<Link> Links { get; set; }
    }
}