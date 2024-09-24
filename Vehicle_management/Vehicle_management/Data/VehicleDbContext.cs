using Microsoft.EntityFrameworkCore;
using Vehicle_management.DTO;
using Vehicle_management.Models;

namespace Vehicle_management.Data
{
    public class VehicleDbContext:DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options):base(options)
        {
            
        }

        public DbSet<Vehicle> VehiclesMD { get; set; }
        
    }
}
