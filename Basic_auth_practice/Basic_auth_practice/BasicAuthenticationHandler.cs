using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Basic_auth_practice
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            string authorizationheader = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationheader))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            if(!authorizationheader.StartsWith("basic ", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var token = authorizationheader.Substring(6);
            var credentialsAstring=Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialsAstring.Split(":");
            if (credentials?.Length != 2)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }
            var username=credentials[0];
            var password=credentials[1];

            if (username == "shashi" && password == "shashi1")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                };
                var identity=new ClaimsIdentity(claims,"Basic");
                var claimsPrincple=new ClaimsPrincipal(identity);
                return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincple, Scheme.Name));
            }


            return AuthenticateResult.Fail("Unauthorized");
            
        }
    }
}
