using EmployeeManagement.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Extensions
{
    public static  class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<EmployeeDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
