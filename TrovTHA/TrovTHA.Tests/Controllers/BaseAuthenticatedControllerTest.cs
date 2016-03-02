using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http;

namespace TrovTHA.Tests.Controllers
{
    public abstract class BaseAuthenticatedControllerTest
    {
        protected void SetupUserIdInController(ApiController apiController)
        {
            var claims = new List<Claim>
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "user"),
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1")
            };
            var genericIdentity = new GenericIdentity("");
            genericIdentity.AddClaims(claims);
            var genericPrincipal = new GenericPrincipal(genericIdentity, new[] { "mock" });
            apiController.RequestContext.Principal = genericPrincipal;
        }

    }
}
