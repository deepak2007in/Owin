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
        [Route("api/tasks/{id:int}", Name = "GetTaskByIdRoute")]
        public Task Get(int id)
        {
            return DataProvider.Tasks.FirstOrDefault(task => task.Id == id);
        }

        [Route("api/tasks/{name:alpha}", Name = "GetTaskByNameRoute")]
        public Task Get(string name)
        {
            return DataProvider.Tasks.FirstOrDefault(task => task.Name == name);
        }

        [Route("api/tasks", Name = "AddTaskRoute")]
        public IHttpActionResult Post(Task task)
        {
            task.Id = DataProvider.Tasks.Count + 1;
            DataProvider.Tasks.Add(item: task);
            return Created(location: LinkProvider.CreateSelfLink(task: task), content: task);
        }

        [Route("api/tasks/{id:int}", Name = "UpdateTaskRoute")]
        public IHttpActionResult Put(int id, Delta<Task> task)
        {
            var originalTask = this.Get(id: id);
            if (originalTask == null)
            {
                return NotFound();
            }

            task.Put(original: originalTask);
            return StatusCode(status: HttpStatusCode.NoContent);
        }

        [Route("api/tasks/{id:int}", Name = "PartialUpdateTaskRoute")]
        public IHttpActionResult Patch(int id, Delta<Task> task)
        {
            var originalTask = this.Get(id: id);
            if (originalTask == null)
            {
                return NotFound();
            }

            task.Patch(original: originalTask);
            return StatusCode(status: HttpStatusCode.NoContent);
        }

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