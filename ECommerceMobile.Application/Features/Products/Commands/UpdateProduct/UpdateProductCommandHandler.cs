using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.Exceptions;
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
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductVm> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id);
            if ( productToUpdate == null)
            {
                _logger.LogError($"No se encuentra el producto con Id {request.Id}");
                throw new NotFoundException(nameof(Product), request.Id);
            }
            if (request.Price.HasValue) { productToUpdate.Price = request.Price.Value; }

            _mapper.Map(request, productToUpdate);
            await _productRepository.UpdateAsync(productToUpdate);
            _logger.LogInformation($"La actualizacion se realizo exitosamente");
            return _mapper.Map<ProductVm>(productToUpdate);
        }
    }
}
