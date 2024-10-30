using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.ExternalService.Cloudinary;
using ECommerceMobile.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceMobile.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        private readonly ICloudinaryService _cloudinaryService;

        public CreateProductCommandHandler(
            IProductRepository productRepository,
            IMapper mapper,
            ILogger<CreateProductCommandHandler> logger,
            ICloudinaryService cloudinaryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            string? imageUrl = null;

            if (!string.IsNullOrEmpty(request.Image))
            {
                var imageBytes = Convert.FromBase64String(request.Image);
                using var imageStream = new MemoryStream(imageBytes);
                imageUrl = await _cloudinaryService.UploadImageAsync(imageStream, "product-image");
            }

            var productEntity = new Product
            {
                Name = request.Name ?? string.Empty,
                Description = request.Description ?? string.Empty,
                Category = request.Category ?? string.Empty,
                Image = imageUrl ?? string.Empty,
                Price = request.Price ?? 0
            };

            var newProduct = await _productRepository.AddAsync(productEntity);
            _logger.LogInformation($"El producto {productEntity.Name} fue creado exitosamente.");
            return _mapper.Map<ProductVm>(newProduct);
        }
    }
}
