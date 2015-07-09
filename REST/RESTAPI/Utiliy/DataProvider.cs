namespace RESTAPI.Utiliy
{
    using System.Collections.Generic;
    using RESTAPI.Models;

    public static class DataProvider
    {
        public static List<User> Users { get; private set; }
        public static List<Task> Tasks { get; private set; }

        static DataProvider()
        {
            Users = new List<User>(new[]
                {
                    new User {Id = 1, Name = "Deepak Agnihotri"},
                    new User {Id = 2, Name = "Hitesh Acharya"},
                    new User {Id = 3, Name = "Imran Khan"},
                    new User {Id = 4, Name = "Ajay Pandit"},
                    new User {Id = 5, Name = "Pranav Shah"},
                    new User {Id = 6, Name = "Ruchira Shah"},
                });

            Tasks = new List<Task>(new[]
            {
                    new Task {Id = 1, Name = "Design", Status = "Started", Assignee = new List<User>(new[] {Users[1], Users[3]})},
                    new Task {Id = 2, Name = "Coding", Status = "Pending", Assignee = new List<User>(new[] {Users[0], Users[2]})},
                    new Task {Id = 3, Name = "Testing", Status = "Pending", Assignee = new List<User>(new[] {Users[3], Users[6]})},
                    new Task {Id = 4, Name = "Deployment", Status = "Pending", Assignee = new List<User>(new[] {Users[4], Users[5]})},
            });
        }
    }
}