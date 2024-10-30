using FluentValidation;

namespace ECommerceMobile.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Price)
                .GreaterThanOrEqualTo(0).When(p => p.Price.HasValue)
                .WithMessage("{Precio} debe ser un valor positivo.");
        }
    }
}
