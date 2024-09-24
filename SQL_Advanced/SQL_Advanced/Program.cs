using Microsoft.EntityFrameworkCore;
using SQL_Advanced.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CustomerDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("CustomerConnection");
    options.UseSqlServer(connectionString);
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
