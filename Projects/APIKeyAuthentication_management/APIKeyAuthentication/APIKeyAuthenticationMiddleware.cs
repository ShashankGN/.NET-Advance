using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace APIKeyAuthentication
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class APIKeyAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public APIKeyAuthenticationMiddleware(RequestDelegate next,IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(!httpContext.Request.Headers.TryGetValue("X-API-KEY",out var actualHeaderKeyValue))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsJsonAsync(new { error = "Invalid key" });
                return;
            }
            var apiSecret = _configuration["ApiKey"];
            if (!actualHeaderKeyValue.Equals(apiSecret))
            {
                httpContext.Response.StatusCode = 401;
                await httpContext.Response.WriteAsJsonAsync(new { error = "Invalid key" });
                return;
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class APIKeyAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIKeyAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIKeyAuthenticationMiddleware>();
        }
    }
}
