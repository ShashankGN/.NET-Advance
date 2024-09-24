using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.Commands.CreateProduct
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public List<string> Category { get; set; } = new();
        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
        //only necessary data is passed or visible,so this class is created
    }


    public class CreateProductEndpoint : ICarterModule
    {

        //minimal API
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async ([FromBody] CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();//mapping of the data using mapster library or package
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/products/{response.Id}", response);
            });
        }

        //public void AddRoutes(IEndpointRouteBuilder app)
        //{
        //    app.MapPost("/products", async ([FromBody] CreateProductRequest request, ISender sender) =>
        //    {
        //        var command = request.Adapt<CreateProductCommand>();//mapping of the data using mapster library or package
        //        var result = await sender.Send(command);
        //        return Results.Created($"/products/{result}", result);
        //    });
        //}
    }

    //this is the code written in controller like as we did in online training
    //public class ProductController
    //{
    //    [HttpPost]
    //    public void Create([FromBody] CreateProductRequest request)
    //    {

    //    }
    //}
}
