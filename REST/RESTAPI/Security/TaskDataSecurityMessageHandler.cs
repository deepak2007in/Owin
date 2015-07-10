using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RESTAPI.Security
{
    public class TaskDataSecurityMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if(CanHandleResponse(response: response))
            {
                ApplySecurityToResponseData((ObjectContent)response.Content);
            }

            return response;
        }

        private void ApplySecurityToResponseData(ObjectContent responseObjectContent)
        {
            var removeSensitiveData = !IsInManagerRole();
            if(removeSensitiveData)
            {
                var task = responseObjectContent.Value as RESTAPI.Models.Task;
                task.SetShouldSerializeAssignee(shouldSerialize: !removeSensitiveData);
            }
        }

        private bool CanHandleResponse(HttpResponseMessage response)
        {
            var objectContent = response.Content as ObjectContent;
            var canHandleResponse = objectContent != null && objectContent.ObjectType == typeof(RESTAPI.Models.Task);
            return canHandleResponse;
        }

        private bool IsInManagerRole()
        {
            var principal = HttpContext.Current.User as ClaimsPrincipal;
            return principal.HasClaim(ClaimTypes.Role, "Director");
        }
    }
}