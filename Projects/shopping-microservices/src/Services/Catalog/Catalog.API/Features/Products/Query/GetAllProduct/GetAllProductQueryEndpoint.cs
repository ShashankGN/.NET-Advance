using Carter;
using MediatR;

namespace Catalog.API.Features.Products.Query.GetAllProduct
{

    public class GetAllProductQueryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("products/", async (ISender sender) =>
            {

                var query = new GetProductQuery();
                var products = await sender.Send(query);
                return Results.Created($"/products/{products}", products);

            });
        }
    }
}
