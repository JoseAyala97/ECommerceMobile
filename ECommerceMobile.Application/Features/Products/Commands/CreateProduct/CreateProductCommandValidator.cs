using FluentValidation;

namespace ECommerceMobile.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).When(p => p.Price.HasValue)
                .WithMessage("{Precio} debe ser un valor positivo.");
        }
    }
}
