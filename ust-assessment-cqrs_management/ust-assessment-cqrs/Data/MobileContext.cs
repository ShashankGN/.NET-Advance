using Microsoft.EntityFrameworkCore;
using ust_assessment_cqrs.Models;

namespace ust_assessment_cqrs.Data
{
    public class MobileContext:DbContext
    {
        public MobileContext(DbContextOptions<MobileContext> options):base(options)
        {
            
        }

        public DbSet<Mobile> Mobiles { get; set; }
    }
}
