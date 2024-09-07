using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllAsync();
           return _mapper.Map<List<ProductVm>>(productList);
        }
    }
}
