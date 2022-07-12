using Microsoft.AspNetCore.Authorization;

namespace API.Athentication
{
    public class TeamCityAuthorizeAttribute : AuthorizeAttribute
    {
        public TeamCityAuthorizeAttribute()
        {
            Policy = AuthenticationHelper.TeamCityScheme;
        }
    }
}