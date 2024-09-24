using FluentValidation;

namespace Catalog.API.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
    {

        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x=>x.Category).NotEmpty().WithMessage("Category cannot be empty");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price cannot be empty")
                .GreaterThan(0).WithMessage("Price should be greater than zero");
        }
    }
}
