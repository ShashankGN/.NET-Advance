using Catalog.API.Data;
using Catalog.API.Features.Products.ProductDTO;
using Catalog.API.Models;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Features.Products.Query.GetAllProduct
{
    public class GetProductQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
    //public class GetProductsResult
    //{
    //    public IEnumerable<ProductDto> Products { get; set; }
    //}


    public class GetAllProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductDto>>
    {
        private readonly CatalogContext _context;

        public GetAllProductQueryHandler(CatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductDto>> Handle([FromBody] GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ToListAsync(cancellationToken);
            var productsList = products.Adapt<IEnumerable<ProductDto>>();
            return productsList;
        }
    }

}

