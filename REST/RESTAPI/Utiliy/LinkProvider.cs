namespace RESTAPI.Utiliy
{
    using System;
    using RESTAPI.Models;

    public static class LinkProvider
    {
        const string baseAddress = "http://localhost:63776/api/";

        #region Task Collection Link
        public static void AddLinks(TaskCollectionResponse collection)
        {
            AddSelfLink(collection: collection);
            AddCreateNewTaskLink(collection: collection);
            AddLinksToChildObjects(collection: collection);
        }
        private static void AddCreateNewTaskLink(TaskCollectionResponse collection)
        {
            collection.Links.Add(new Link { Href = baseAddress + "tasks", Rel = "createTask", Method = "POST" });
        }
        private static void AddSelfLink(TaskCollectionResponse collection)
        {
            collection.Links.Add(new Link { Href = baseAddress + "tasks", Rel = "self", Method = "GET" });
        }
        private static void AddLinksToChildObjects(TaskCollectionResponse collection)
        {
            collection.Tasks.ForEach(x => 
                {
                    AddSelfLink(x);
                    AddLinksToChildObjects(x);
                });
        }
        #endregion

        #region Task Link

        public static void AddLinks(Task task)
        {
            AddSelfLink(task: task);
            AddLinksToChildObjects(task: task);
            AddReplaceUsersLink(task: task);
            AddDeleteUsersLink(task: task);
            AddUpdateTaskLink(task: task);
            AddPartialUpdateTaskLink(task: task);
            AddTaskUsersLink(task: task);
            AddAllTasksLink(task: task);
        }
        public static string CreateSelfLink(Task task)
        {
            return baseAddress + "tasks/" + task.Id;
        }
        private static void AddSelfLink(Task task)
        {
            task.Links.Add(new Link { Href = CreateSelfLink(task: task), Rel = "self", Method = "GET" });
        }
        private static void AddLinksToChildObjects(Task task)
        {
            task.Assignee.ForEach(x => AddSelfLink(x));
        }
        private static void AddReplaceUsersLink(Task task)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks/" + task.Id + "/users", Rel = "replaceUsers", Method = "PUT" });
        }
        private static void AddDeleteUsersLink(Task task)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks/" + task.Id + "/users", Rel = "deleteUsers", Method = "DELETE" });
        }
        private static void AddUpdateTaskLink(Task task)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks/"+task.Id, Rel = "updateTask", Method = "PUT" });
        }
        private static void AddPartialUpdateTaskLink(Task task)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks/" + task.Id, Rel = "partialUpdateTask", Method = "PATCH" });
        }
        private static void AddTaskUsersLink(Task task)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks/" + task.Id + "/users", Rel = "assignees", Method = "POST" });
        }
        private static void AddAllTasksLink(Task task)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks", Rel = "all", Method = "GET" });
        }

        #endregion

        #region Task User Link

        private static void AddDeleteUserLink(Task task, User user)
        {
            task.Links.Add(new Link { Href = baseAddress + "tasks/" + task.Id + "/users/" + user.Id, Rel = "removeAssignee", Method = "DELETE" });
        }

        #endregion

        #region User Links
        private static void AddSelfLink(User user)
        {
            user.Links.Add(new Link { Href = baseAddress + "users/" + user.Id, Rel = "self", Method = "GET" });
        }

        private static void AddAllUserLink(User user)
        {
            user.Links.Add(new Link { Href = baseAddress + "users", Rel = "all", Method = "GET" });
        }
        #endregion
    }
}