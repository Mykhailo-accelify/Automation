namespace API.Startup.Extensions
{
    using API.Athentication;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Builder;

    internal static class Authenticate
    {
        internal static WebApplicationBuilder AddApplicationAuthentication(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<APIAuthenticationOptions>(
                    builder.Configuration.GetSection(APIAuthenticationOptions.Position));

            builder.Services.AddAuthentication()
                .AddScheme<AuthenticationSchemeOptions, ServiceAthenticationHandler>(AuthenticationHelper.ServiceScheme, options => { })
                .AddScheme<AuthenticationSchemeOptions, TeamCityAthenticationHandler>(AuthenticationHelper.TeamCityScheme, options => { });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthenticationHelper.ServiceScheme,
                    new AuthorizationPolicyBuilder(AuthenticationHelper.ServiceScheme)
                    .RequireAuthenticatedUser()
                    .Build());
                options.AddPolicy(AuthenticationHelper.TeamCityScheme,
                    new AuthorizationPolicyBuilder(AuthenticationHelper.TeamCityScheme)
                    .RequireAuthenticatedUser()
                    .Build());
            });

            return builder;
        }
    }
}