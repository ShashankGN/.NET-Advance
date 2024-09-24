using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Features.Commands.CreateBook
{
    public class CreateBookCommandEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/books", async ([FromBody]CreateBookCommand request, ISender sender) =>
            {
                var command = request.Adapt<CreateBookCommand>();
                var response= await sender.Send(command);
                return Results.Created($"{response}", response);
            });
        }
    }
}
