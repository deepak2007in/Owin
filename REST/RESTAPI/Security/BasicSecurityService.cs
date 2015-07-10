using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;

namespace RESTAPI.Security
{
    public class User
    {
        public string UserName { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
    }
    public interface IBasicSecurityService
    {
        bool SetPrincipal(string username, string password);
    }

    public class BasicSecurityService: IBasicSecurityService
    {
        public bool SetPrincipal(string username, string password)
        {
            var user = GetUser(username: username);
            if(user == null)
            {
                return false;
            }
            IPrincipal principal = GetPrincipal(user: user);
            Thread.CurrentPrincipal = principal;
            if(HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
            return true;
        }

        private IPrincipal GetPrincipal(User user)
        {
            var identity = new GenericIdentity(user.UserName, "Basic");
            identity.AddClaim(new Claim(ClaimTypes.GivenName, user.GivenName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, user.Surname));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Manager"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Senior"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Director"));
            return new ClaimsPrincipal(identity: identity);
        }

        private User GetUser(string username)
        {
            if (username == "bhogg")
            {
                return new User { GivenName = "Deepak", UserName = "deepak2007in", Surname = "Agnihotri" };
            }
            return null;
        }
    }
}