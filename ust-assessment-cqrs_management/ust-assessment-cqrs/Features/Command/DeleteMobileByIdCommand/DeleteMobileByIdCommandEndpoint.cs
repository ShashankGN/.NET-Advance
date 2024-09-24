using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ust_assessment_cqrs.Features.Command.DeleteMobileByIdCommand
{
    public class DeleteMobileByIdCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/mobiles/{id}", async ([FromRoute]int id,ISender sender) => {

                var result = await sender.Send(new DeleterMobileByIdCommand { Id = id });
                if (result)
                {
                    return Results.Ok($"Mobile with Id {id} deleted successfully");
                }
                return Results.NotFound($"Mobile with Id {id} is not found");

            });
        }
    }
}
