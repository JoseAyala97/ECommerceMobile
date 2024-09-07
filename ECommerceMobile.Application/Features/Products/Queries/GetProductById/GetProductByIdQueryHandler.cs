using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.Exceptions;
using ECommerceMobile.Application.ExternalService.Cloudinary;
using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using MediatR;

namespace ECommerceMobile.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,ProductVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;

        public GetProductByIdQueryHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ICloudinaryService cloudinaryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var productById = await _productRepository.GetByIdAsync(request.Id);
            if (productById == null)
            {
                throw new NotFoundException("Este producto no existe.", request.Id);
            }

            var imageUrl = await _cloudinaryService.GetImageUrl(productById.Image);
            var productVm = _mapper.Map<ProductVm>(productById);
            productVm.Image = imageUrl;

            return productVm;
        }
    }
}
