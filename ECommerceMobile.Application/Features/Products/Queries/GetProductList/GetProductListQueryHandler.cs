using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.ExternalService.Cloudinary;
using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductVm>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public GetProductListQueryHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ICloudinaryService cloudinaryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<List<ProductVm>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllAsync();
            var productVmList = _mapper.Map<List<ProductVm>>(productList);

            foreach (var productVm in productVmList)
            {
                productVm.Image = await _cloudinaryService.GetImageUrl(productVm.Image);
            }

            return productVmList;
        }
    }
}
