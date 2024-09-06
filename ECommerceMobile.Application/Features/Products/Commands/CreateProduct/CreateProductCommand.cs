using ECommerceMobile.Domain.Entities;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductVm>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
