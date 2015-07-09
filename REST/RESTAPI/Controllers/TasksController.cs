using System;
using System.Web.Http;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    public class TasksController : ApiController
    {
        [Route("{id:long}", Name = "GetTaskRoute")]
        public Task Get(long id)
        {
            throw new NotImplementedException();
        }

        [Route("", Name = "AddTaskRoute")]
        public IHttpActionResult Post(Task task)
        {
            throw new NotImplementedException();
        }

        [Route("{id:long}", Name = "UpdateTaskRoute")]
        public IHttpActionResult Put(long id, Task task)
        {
            throw new NotImplementedException();
        }

        [Route("{id:long}", Name = "UpdateTaskRoute")]
        public IHttpActionResult Patch(long id, Task task)
        {
            throw new NotImplementedException();
        }

        [Route("{id:long}", Name = "DeleteTaskRoute")]
        public IHttpActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}