using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ust_assessment_cqrs.Features.Command.CreateMobileCommand
{
    public class CreateMobileCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/mobiles", async ([FromBody] CreateMobileCommand request,ISender sender) =>
            {
                var result = await sender.Send(request);
                return Results.Ok($"The Mobile with Id {result} is created.");
            });
        }
    }
}
