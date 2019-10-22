using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System;

namespace Explore.Api.Token
{
    public class TokenAuthorization : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string authorizedToken = string.Empty;
            string authHeaderValue = null;
            var authRequest = actionContext.Request.Headers.Authorization;

            if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "CustomAuth")
            {
                authHeaderValue = authRequest.Parameter;
            }

            if (authHeaderValue != null)
            {
                if (!TokenManager.ValidateToken(authHeaderValue))
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    //actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized");
                    return;
                }
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                //actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Forbidden");
                return;
            }
        }
    }
}