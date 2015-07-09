namespace RESTAPI.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.OData;
    using RESTAPI.Models;
    using RESTAPI.Utiliy;

    public class TasksController : ApiController
    {
        /*
        GET http://localhost:63776/api/tasks HTTP/1.1
        Host: localhost:63776
        */
        [Route("api/tasks", Name = "GetTaskCollectionRoute")]
        public TaskCollectionResponse Get()
        {
            return new TaskCollectionResponse { Tasks = DataProvider.Tasks };
        }

        /*
        GET http://localhost:63776/api/tasks/2 HTTP/1.1
        Host: localhost:63776
        */
        [Route("api/tasks/{id:int}", Name = "GetTaskByIdRoute")]
        public Task Get(int id)
        {
            return DataProvider.Tasks.FirstOrDefault(task => task.Id == id);
        }

        /*
        GET http://localhost:63776/api/tasks/Deployment HTTP/1.1
        Host: localhost:63776
        */
        [Route("api/tasks/{name:alpha}", Name = "GetTaskByNameRoute")]
        public Task Get(string name)
        {
            return DataProvider.Tasks.FirstOrDefault(task => task.Name == name);
        }

        /*
        POST http://localhost:63776/api/tasks HTTP/1.1
        Host: localhost:63776
        Content-Type: text/json
        Content-Length: 24

        {"Name":"Documentation"}
        */
        [Route("api/tasks", Name = "AddTaskRoute")]
        public IHttpActionResult Post(Task task)
        {
            task.Id = DataProvider.Tasks.Count + 1;
            DataProvider.Tasks.Add(item: task);
            return Created(location: LinkProvider.CreateSelfLink(task: task), content: task);
        }

        /*
        POST http://localhost:63776/api/tasks/4 HTTP/1.1
        Host: localhost:63776
        Content-Type: text/json
        Content-Length: 24
        
        {"Status":"Completed", "Name":"Documentation"}
        */
        [Route("api/tasks/{id:int}", Name = "UpdateTaskRoute")]
        public IHttpActionResult Put(int id, Delta<Task> task)
        {
            var originalTask = this.Get(id: id);
            if (originalTask != null)
            {
                task.Put(original: originalTask);
            }

            return StatusCode(status: HttpStatusCode.NoContent);
        }

        /*
        PATCH http://localhost:63776/api/tasks/4 HTTP/1.1
        Host: localhost:63776
        Content-Type: text/json
        Content-Length: 24
        
        {"Status":"Completed", "Name":"Documentation"}
        */
        [Route("api/tasks/{id:int}", Name = "PartialUpdateTaskRoute")]
        public IHttpActionResult Patch(int id, Delta<Task> task)
        {
            var originalTask = this.Get(id: id);
            if (originalTask != null)
            {
                task.Patch(original: originalTask);
            }

            return StatusCode(status: HttpStatusCode.NoContent);
        }

        /*
        DELETE http://localhost:63776/api/tasks/4 HTTP/1.1
        Host: localhost:63776
        Content-Type: text/json
        Content-Length: 24



        */
        [Route("api/tasks/{id:int}", Name = "DeleteTaskRoute")]
        public IHttpActionResult Delete(int id)
        {
            var originalTask = this.Get(id: id);
            if (originalTask == null)
            {
                return NotFound();
            }

            DataProvider.Tasks.Remove(item: originalTask);
            return Ok(content: originalTask);
        }
    }
}