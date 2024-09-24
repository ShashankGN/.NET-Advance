using Carter;
using Catalog.API.Features.Products.ProductDTO;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Query.GetProductById
{
    public class GetProductByIdQueryRequest
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products/{id}", async ([FromRoute] int id, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery { Id = id });
                var response = result.Adapt<ProductDto>();
                return Results.Created($"Products/{response}", response);
            });
        }
    }
}
