using System;
using System.Web.Http;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/users/{id:long}", Name = "GetUserRoute")]
        public Task Get(long id)
        {
            throw new NotImplementedException();
        }

        [Route("api/users", Name = "AddUserRoute")]
        public IHttpActionResult Post(User user)
        {
            throw new NotImplementedException();
        }

        [Route("api/users/{id:long}", Name = "UpdateUserRoute")]
        public IHttpActionResult Put(long id, User user)
        {
            throw new NotImplementedException();
        }

        [Route("api/users/{id:long}", Name = "PartialUpdateUserRoute")]
        public IHttpActionResult Patch(long id, User user)
        {
            throw new NotImplementedException();
        }

        [Route("api/users/{id:long}", Name = "DeleteUserRoute")]
        public IHttpActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}