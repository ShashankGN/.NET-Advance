namespace Catalog.API.Models
{
    public class Product
    {
        //public Guid Id { get; set; }
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<string> Category { get; set; } = new();
        //new feature of .net12
        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }

}