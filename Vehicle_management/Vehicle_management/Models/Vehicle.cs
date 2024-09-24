using System;

namespace Vehicle_management.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string Model { get; set; }
        public DateTime ManufactureDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
