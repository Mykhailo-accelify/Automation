namespace API.Athentication
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.Options;
    using System.Text.Encodings.Web;

    public class TeamCityAthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly APIAuthenticationOptions authenticationOptions;
        private readonly AuthenticationHelper helper;

        public TeamCityAthenticationHandler(
            AuthenticationHelper helper,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IOptions<APIAuthenticationOptions> authenticationOptions
            )
            : base(options, logger, encoder, clock)
        {
            this.authenticationOptions = authenticationOptions.Value;
            this.helper = helper;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            return helper.Handler(Request, Response, authenticationOptions.TeamCity, Scheme.Name);
        }
    }
}