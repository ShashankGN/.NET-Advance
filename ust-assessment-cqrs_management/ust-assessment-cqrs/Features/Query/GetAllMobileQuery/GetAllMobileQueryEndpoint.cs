using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ust_assessment_cqrs.Features.Query.GetAllMobileQuery
{
    public class GetAllMobileQueryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/mobiles", async (ISender sender) =>
            {
                var mobiles = await sender.Send(new GetAllMobileQuery());
                if (mobiles.Count()==0)
                {
                    return Results.NotFound("No Mobiles in the database");
                }
                return Results.Ok(mobiles);
            });
        }
    }
}
