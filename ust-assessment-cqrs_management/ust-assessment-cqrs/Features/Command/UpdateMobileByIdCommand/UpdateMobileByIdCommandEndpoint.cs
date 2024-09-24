using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ust_assessment_cqrs.Features.Command.UpdateMobileByIdCommand
{
    public class UpdateMobileByIdCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/mobiles", async ([FromBody]UpdateMobileByIdCommand request,ISender sender) => { 
                var result=await sender.Send(request);
                if (result)
                {
                    return Results.Ok($"Mobile with id {request.Id} updated successfully");
                }
                return Results.NotFound($"Mobile with id {request.Id} is not found");
            
            });
        }
    }
}
