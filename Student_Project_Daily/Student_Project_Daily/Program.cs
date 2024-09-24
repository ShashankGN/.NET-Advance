using Microsoft.EntityFrameworkCore;
using Student_Project_Daily.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("StudentDBConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
