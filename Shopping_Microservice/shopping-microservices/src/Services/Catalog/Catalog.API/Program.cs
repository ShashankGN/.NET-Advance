
using Carter;
using Catalog.API.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

//for custom configuration 
//TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddCarter();
builder.Services.AddDbContext<CatalogContext>(options =>
{
    options.UseInMemoryDatabase("CatalogDB");
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
var app = builder.Build();

app.MapCarter();
app.MapGet("/", () => "Hello World!");


app.Run();
