using Microsoft.EntityFrameworkCore;
using Product_API_Azure.Contracts;
using Product_API_Azure.Data;
using Product_API_Azure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IProductRepo,ProductRepository>();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ProductConnectionString");
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
