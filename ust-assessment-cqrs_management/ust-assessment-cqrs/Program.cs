using Carter;
using Microsoft.EntityFrameworkCore;
using ust_assessment_cqrs.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddCarter();
builder.Services.AddDbContext<MobileContext>(options =>
{
    options.UseInMemoryDatabase("MobileDB");
});
var app = builder.Build();

app.MapCarter();
app.MapGet("/", () => "Hello World!");

app.Run();
