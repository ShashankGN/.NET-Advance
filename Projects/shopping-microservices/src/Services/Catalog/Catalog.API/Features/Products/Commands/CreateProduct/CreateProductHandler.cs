using Catalog.API.Data;
using Catalog.API.Models;
using FluentValidation;
using Mapster;
using MediatR;

namespace Catalog.API.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResponse>//IRequest<Guid>
    {
        public string Name { get; set; }
        public List<string> Category { get; set; } = new();
        public string Description { get; set; }

        public string ImageFile { get; set; }

        public decimal Price { get; set; }
    }
    //this is a request`

    public class CreateProductResponse
    {
        public int Id { get; set; }
    }
    //if IRequest<Guid> is there then this class is not needed


    //the below class should be renamed as CreateProductCommandHandler
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>//instead of CreateProductResponse Guid must be given
    {

        private readonly CatalogContext _context;
        private readonly IValidator<CreateProductCommand> _validator;

        public CreateProductHandler(CatalogContext context,IValidator<CreateProductCommand> validator)
        {
            _context = context;
            _validator= validator;
        }
        //Inside task it should be Guid if CreateProductResponse class is not there
        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //var product = new Product
            //{
            //    Name = request.Name,
            //    Category = request.Category,
            //    Description = request.Description,
            //    ImageFile = request.ImageFile,
            //    Price = request.Price
            //};


            var validationResult=await _validator.ValidateAsync(request,cancellationToken);
            var errors = validationResult.Errors.ToList();
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            var product = request.Adapt<Product>();
            product.Id = _context.Products.Count() == 0 ? _context.Products.Count() + 1 : _context.Products.Max(x => x.Id) + 1;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            //saving to the DB



            //return Task.FromResult(new CreateProductResponse
            //{
            //    Id = Guid.NewGuid()
            //});


            return new CreateProductResponse { Id = product.Id };

            //either make the function async or return Task.FromResult(new CreateProductResponse{Id=1});
        }
    }
    //public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>//instead of CreateProductResponse Guid must be given
    //{
    //    //Inside task it should be Guid if CreateProductResponse class is not there
    //    public Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    //    {
    //        var product = new Product
    //        {
    //            Name = request.Name,
    //            Category = request.Category,
    //            Description = request.Description,
    //            ImageFile = request.ImageFile,
    //            Price = request.Price
    //        };


    //        //saving to the DB



    //        return Task.FromResult(Guid.NewGuid());

    //        //either make the function async or return Task.FromResult(new CreateProductResponse{Id=1});
    //    }
    //}
}
