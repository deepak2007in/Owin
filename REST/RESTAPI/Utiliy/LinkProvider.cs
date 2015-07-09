namespace RESTAPI.Utiliy
{
    using System;
    using RESTAPI.Models;

    public static class LinkProvider
    {
        public static string CreateSelfLink(Task task)
        {
            return string.Empty;
        }

        public static string CreateSelfLink(User task)
        {
            throw new NotImplementedException();
        }
    }
}