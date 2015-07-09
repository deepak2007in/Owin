using System;
using System.Web.Http;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    public class UsersController : ApiController
    {
        [Route("{id:long}", Name = "GetUserRoute")]
        public Task Get(long id)
        {
            throw new NotImplementedException();
        }

        [Route("", Name = "AddUserRoute")]
        public IHttpActionResult Post(User user)
        {
            throw new NotImplementedException();
        }

        [Route("{id:long}", Name = "UpdateUserRoute")]
        public IHttpActionResult Put(long id, User user)
        {
            throw new NotImplementedException();
        }

        [Route("{id:long}", Name = "PartialUpdateUserRoute")]
        public IHttpActionResult Patch(long id, User user)
        {
            throw new NotImplementedException();
        }

        [Route("{id:long}", Name = "DeleteUserRoute")]
        public IHttpActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}