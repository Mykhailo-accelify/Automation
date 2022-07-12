using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace API.Athentication
{
    public class AuthenticationHelper
    {
        public const string TeamCityScheme = "TeamCityAuthenticationScheme";

        public const string ServiceScheme = "ServiceAuthenticationScheme";

        public const string UserRole = "User";

        internal Task<AuthenticateResult> Handler(HttpRequest Request, HttpResponse Response, string token, string shemeName)
        {
            // Get authorization key
            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var authHeaderRegex = new Regex(@"Token (.*)");

            if (!authHeaderRegex.IsMatch(authorizationHeader))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization token not formatted properly."));
            }

            var authToken = authHeaderRegex.Replace(authorizationHeader, "$1");

            if (authToken != token)
            {
                return Task.FromResult(AuthenticateResult.Fail("The token is not correct."));
            }

            Response.Headers.Add("WWW-Authenticate", "Token");
            var authenticatedUser = new APIUser("TokenAuthentication", true, "tc");
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(authenticatedUser));

            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, shemeName)));
        }
    }
}