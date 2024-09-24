using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ust_assessment_cqrs.Features.Query.GetMobileByIdQuery
{
    public class GetMobileByIdQueryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/mobiles/{id}", async ([FromRoute]int id,ISender sender) =>
            {
                var result=await sender.Send(new GetMobileByIdQuery { Id = id });
                if (result != null)
                {
                    return Results.Ok(result);
                }
                return Results.NotFound($"Mobile with {id} is not found");

            });
        }
    }
}
