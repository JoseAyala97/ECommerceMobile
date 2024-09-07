using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductVm>
    {
        public int Id { get; set; }
    }
}
