using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<List<ProductVm>>
    {

    }
}
