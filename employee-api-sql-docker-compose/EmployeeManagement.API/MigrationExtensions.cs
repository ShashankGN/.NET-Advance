using EmployeeManagement.API.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API
{
    public static class MigrationsApply
    {
       
            public static async Task ApplyMigrations(IServiceProvider serviceProvider)
            {
                using var scope = serviceProvider.CreateScope();
                await using EmployeeDbContext dbContext = scope.ServiceProvider.GetRequiredService<EmployeeDbContext>();

                await dbContext.Database.MigrateAsync();
            }
        
    }
}
