
using EmployeeManagement.API;
using EmployeeManagement.API.Contracts;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Repository;
using Microsoft.EntityFrameworkCore;


           var builder = WebApplication.CreateBuilder(args);

     

            builder.Services.AddControllers();

            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddDbContext<EmployeeDbContext>(options =>
            {
                var dbHost =Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
                var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "EmployeeDB";
                var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "Password123";
                var connectionString = $"Server={dbHost};Database={dbName};User Id=sa;Password={dbPassword};TrustServerCertificate=true";
              
                options.UseSqlServer(connectionString);
            });


            var app = builder.Build();
            
            await MigrationsApply.ApplyMigrations(app.Services);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

            app.UseAuthorization();


 app.MapControllers();

app.Run();
