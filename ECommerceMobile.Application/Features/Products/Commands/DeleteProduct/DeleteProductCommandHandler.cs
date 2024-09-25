using AutoMapper;
using ECommerceMobile.Application.Contracts.Persistence;
using ECommerceMobile.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerceMobile.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IProductRepository productRepository,ILogger<DeleteProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);
            if (productToDelete == null) 
            { 
                _logger.LogError("El producto no existe");
                throw new NotFoundException("Error al en la busqueda", request.Id);
            }
            await _productRepository.DeleteAsync(productToDelete);
            _logger.LogInformation("Producto eliminado con exito.");
           
        }
    }
}
