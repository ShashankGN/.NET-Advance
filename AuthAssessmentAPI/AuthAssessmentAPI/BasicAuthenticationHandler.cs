using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace AuthAssessmentAPI
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            string authorizationHeader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            if (!authorizationHeader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var token = authorizationHeader.Substring(6);
            var credentialsAsString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialsAsString.Split(":");

            var username = credentials[0];
            var password = credentials[1];

            if (username == "shashank" && password == "shashank")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                };
                var identity = new ClaimsIdentity(claims, "Basic");
                var claimsPrinciple = new ClaimsPrincipal(identity);
                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrinciple, Scheme.Name));
            }

            return AuthenticateResult.Fail("Unauthorized");
        }
    }
}
