using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Commands.UpdateById
{
    public class UpdateProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async ([FromBody] UpdateProductById request, ISender sender) =>
            {
                var result = await sender.Send(request);
                return Results.Created($"{result}", result);
            });
        }
    }
}
