using Basic_Authentication;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

//"BasicAuthentication" is the name of the AuthenticationScheme


builder.Services.AddControllers();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(o =>
{
    o.AllowAnyHeader();
    o.AllowAnyOrigin();
});
app.UseAuthorization();

app.MapControllers();

app.Run();
