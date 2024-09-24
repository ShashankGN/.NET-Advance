using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("ocelot.json", false, true).AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.

await app.UseOcelot();//maps the upstream and downstream paths specified in ocelot.json file

app.Run();


