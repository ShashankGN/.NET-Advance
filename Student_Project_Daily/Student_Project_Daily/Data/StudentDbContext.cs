using Microsoft.EntityFrameworkCore;
using Student_Project_Daily.Models;

namespace Student_Project_Daily.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasData(
                new Student
                {
                    StudentId = 1,
                    Firstname = "Achuth",
                    Lastname = "Kumar",
                    Age = 21
                },
                new Student
                {
                    StudentId = 2,
                    Firstname = "Bipin",
                    Lastname = "Prasad",
                    Age = 24
                },
                new Student
                {
                    StudentId = 3,
                    Firstname = "Pavan",
                    Lastname = "Krishnan",
                    Age = 25
                }
                );
            modelBuilder.Entity<Address>()
                .HasData(
                new Address
                {
                    AddressId = 1,
                    City="Shivamogga",
                    State="Karnataka",
                    Country="India",
                    StudentId=1
                },
                new Address
                {
                    AddressId= 2,
                    City="Thiruvananthapuram",
                    State="Kerala",
                    Country="India",
                    StudentId=3
                },
                new Address
                {
                    AddressId=3,
                    City= "Toronto",
                    State= "Ontario",
                    Country= "Canada",
                    StudentId=2
                }
                );
        }
    }
}
