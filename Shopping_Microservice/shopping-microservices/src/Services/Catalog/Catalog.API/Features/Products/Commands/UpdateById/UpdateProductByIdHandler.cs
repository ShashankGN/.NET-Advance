using Catalog.API.Data;
using Catalog.API.Models;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Features.Products.Commands.UpdateById
{
    public class UpdateProductById : IRequest<string>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<string> Category { get; set; } = new();
        //new feature of .net12
        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
    public class UpdateProductByIdHandler : IRequestHandler<UpdateProductById, string>
    {
        private readonly CatalogContext _context;
        public UpdateProductByIdHandler(CatalogContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(UpdateProductById request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product != null)
            {
                product.Name = request.Name;
                product.Category = request.Category;
                product.Description = request.Description;
                product.ImageFile = request.ImageFile;
                product.Price = request.Price;
                await _context.SaveChangesAsync();
                return $"{request.Id} is found and updated";
            }
            return $"{request.Id} is not found";
        }
    }
}
