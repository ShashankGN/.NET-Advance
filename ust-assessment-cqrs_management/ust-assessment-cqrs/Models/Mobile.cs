using System.ComponentModel.DataAnnotations;

namespace ust_assessment_cqrs.Models
{
    public class Mobile
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name field is manadatory,it can't be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Manufacturer field is manadatory,it can't be empty!")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage ="Feature Field is manadatory,it can't be empty!")]
        public string Features { get; set; }

        [Required]
        [Range(1, Double.MaxValue,ErrorMessage ="Price should be greater than 0")]
        public double Price { get; set; }
    }
}
