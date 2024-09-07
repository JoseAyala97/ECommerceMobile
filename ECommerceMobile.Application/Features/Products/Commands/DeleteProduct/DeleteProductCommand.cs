using MediatR;

namespace ECommerceMobile.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
