using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_Project_Daily.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public string City { get; set; }

        public string State {  get; set; }

        public string Country { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }

    }
}
