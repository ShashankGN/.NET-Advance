using Catalog.API.Data;
using Catalog.API.Features.Products.ProductDTO;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Features.Products.Query.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
    //public class GetProductByIdQueryResult
    //{
    //    public ProductDto result {  get; set; }
    //}
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly CatalogContext _context;

        public GetProductByIdQueryHandler(CatalogContext context)
        {
            _context = context;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
            var result = product.Adapt<ProductDto>();
            return result;


        }
    }
}
