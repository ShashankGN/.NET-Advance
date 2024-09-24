using Microsoft.EntityFrameworkCore;
using Products.API.Contracts;
using Products.API.Data;
using Products.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProduct, ProductInMemoryRepository>();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseInMemoryDatabase("ProductDB");
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapDefaultControllerRoute();
//in this the id will be optional in the route so now we can have get,post,put,delete in one block itself in the ocelot.json

//app.MapControllers();

app.Run();
