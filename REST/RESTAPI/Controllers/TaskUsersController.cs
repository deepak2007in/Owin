﻿namespace RESTAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using RESTAPI.Models;

    public class TaskUsersController
    {
        [Route("api/tasks/{taskId:long}/users", Name = "GetTaskUsersRoute")]
        public TaskUsersCollectionResponse Get(long taskId)
        {
            throw new NotImplementedException();
        }

        [Route("api/tasks/{taskId:long}/users", Name = "ReplaceTaskUsersRoute")]
        public IHttpActionResult Put(long id, IEnumerable<long> userIds)
        {
            throw new NotImplementedException();
        }

        [Route("api/tasks/{taskId:long}/users/{userId:long}", Name = "AddTaskUserRoute")]
        public IHttpActionResult Put(long taskId, long userId)
        {
            throw new NotImplementedException();
        }

        [Route("api/tasks/{taskId:long}/users", Name = "DeleteTaskUsersRoute")]
        public IHttpActionResult Delete(long id, IEnumerable<long> userIds)
        {
            throw new NotImplementedException();
        }

        [Route("api/tasks/{taskId:long}/users/{userId:long}", Name = "DeleteTaskUserRoute")]
        public IHttpActionResult Delete(long taskId, long userId)
        {
            throw new NotImplementedException();
        }
    }
}