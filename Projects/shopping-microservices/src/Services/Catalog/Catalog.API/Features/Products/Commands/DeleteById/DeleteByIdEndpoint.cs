using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Commands.DeleteById
{

    public class DeleteByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("products/{id}", async ([FromRoute] int id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteById { Id = id });
                return Results.Created($"the {result}", result);
            });
        }
    }
}
