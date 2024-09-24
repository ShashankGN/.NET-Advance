using System.ComponentModel.DataAnnotations;

namespace Employees.API.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public double salary {  get; set; }
        public string Email { get; set; }

    }
}
