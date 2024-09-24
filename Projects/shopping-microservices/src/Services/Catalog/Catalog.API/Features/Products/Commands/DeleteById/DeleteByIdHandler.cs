using Catalog.API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Features.Products.Commands.DeleteById
{
    public class DeleteById : IRequest<string>
    {
        public int Id { get; set; }
    }
    public class DeleteByIdHandler : IRequestHandler<DeleteById, string>
    {
        private readonly CatalogContext _context;

        public DeleteByIdHandler(CatalogContext context)
        {
            _context = context;
        }
        public async Task<string> Handle(DeleteById request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return $"{request.Id} deleted";
            }
            return $"{request.Id} is not found";
        }
    }
}
