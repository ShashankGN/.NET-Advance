using System.ComponentModel.DataAnnotations;

namespace SQL_Advanced.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
