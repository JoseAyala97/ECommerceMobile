using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.Exceptions;
using ECommerceMobile.Application.ExternalService.Cloudinary;
using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using ECommerceMobile.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceMobile.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductVm>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger, ICloudinaryService cloudinaryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<ProductVm> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id);
            if (productToUpdate == null)
            {
                _logger.LogError($"No se encuentra el producto con Id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }

            if (!string.IsNullOrEmpty(request.Name))
                productToUpdate.Name = request.Name;

            if (!string.IsNullOrEmpty(request.Description))
                productToUpdate.Description = request.Description;

            if (!string.IsNullOrEmpty(request.Category))
                productToUpdate.Category = request.Category;

            if (!string.IsNullOrEmpty(request.Image))
            {
                var imageBytes = Convert.FromBase64String(request.Image);
                using var imageStream = new MemoryStream(imageBytes);
                productToUpdate.Image = await _cloudinaryService.UploadImageAsync(imageStream, "product-image");
            }

            if (request.Price.HasValue)
                productToUpdate.Price = request.Price.Value;

            await _productRepository.UpdateAsync(productToUpdate);
            _logger.LogInformation($"El producto {productToUpdate.Name} fue actualizado exitosamente.");
            return _mapper.Map<ProductVm>(productToUpdate);
        }
    }
}
