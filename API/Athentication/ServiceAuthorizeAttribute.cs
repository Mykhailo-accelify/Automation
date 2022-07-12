using Microsoft.AspNetCore.Authorization;

namespace API.Athentication
{
    public class ServiceAuthorizeAttribute : AuthorizeAttribute
    {
        public ServiceAuthorizeAttribute()
        {
            Policy = AuthenticationHelper.ServiceScheme;
        }
    }
}