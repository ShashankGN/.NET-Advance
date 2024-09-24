using System.ComponentModel.DataAnnotations;

namespace Student_Project_Daily.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public ICollection<Address> Addresses { get; set; }


    }
}
