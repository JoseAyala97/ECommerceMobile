using FluentValidation;

namespace ECommerceMobile.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("{Nombre} no puede estar en blanco");
            RuleFor(p => p.Description).NotEmpty()
                .WithMessage("{Descripcion} no puede estar en blanco");
            RuleFor(p => p.Price).NotEmpty()
                .WithMessage("{Precio} no puede estar en blanco");
        }
    }
}
