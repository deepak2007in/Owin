using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RESTAPI.Security
{
    public class BasicAuthenticationMessageHandler : DelegatingHandler
    {
        private readonly IBasicSecurityService basicSecurityService;
        public BasicAuthenticationMessageHandler()
        {
            basicSecurityService = new BasicSecurityService();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                return await base.SendAsync(request, cancellationToken);
            }
            
            if(!CanHandleAuthentication(request: request))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            bool isAuthenticated;

            try
            {
                isAuthenticated = Authenticate(request: request);
            }
            catch(Exception e)
            {
                return CreateUnauthorizedResponse();
            }

            if(isAuthenticated)
            {
                var response = await base.SendAsync(request: request, cancellationToken: cancellationToken);
                return response.StatusCode == HttpStatusCode.Unauthorized ? CreateUnauthorizedResponse() : response;
            }

            return CreateUnauthorizedResponse();
        }

        private HttpResponseMessage CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue("Basic"));
            return response;
        }

        private bool Authenticate(HttpRequestMessage request)
        {
            var authHeader = request.Headers.Authorization;
            if(authHeader == null)
            {
                return false;
            }
            var credentialParts = GetCredentialParts(authHeader: authHeader);
            if(credentialParts.Length != 2)
            {
                return false;
            }
            return basicSecurityService.SetPrincipal(username: credentialParts[0], password: credentialParts[1]);
        }

        private string[] GetCredentialParts(System.Net.Http.Headers.AuthenticationHeaderValue authHeader)
        {
            var encodedCredentials = authHeader.Parameter;
            var credentialBytes = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.ASCII.GetString(bytes: credentialBytes);
            var credentialParts = credentials.Split(':');
            return credentialParts;
        }

        private bool CanHandleAuthentication(HttpRequestMessage request)
        {
            return (request.Headers != null)
                    &&
                    request.Headers.Authorization != null
                    &&
                    request.Headers.Authorization.Scheme.ToLower() == "basic";
        }
    }
}