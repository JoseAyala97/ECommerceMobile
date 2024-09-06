using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductVm>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; } 
        public double? Price { get; set; } 
    }
}
