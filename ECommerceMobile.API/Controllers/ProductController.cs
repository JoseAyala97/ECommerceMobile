using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
using ECommerceMobile.Application.Features.Products.Commands.DeleteProduct;
using ECommerceMobile.Application.Features.Products.Commands.UpdateProduct;
using ECommerceMobile.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMobile.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name ="Create")]
        public async Task<ActionResult<ProductVm>> CreateProduct([FromBody]CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpPut("{id}",Name = "Update")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody]UpdateProductCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}",Name = "Delete")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = new DeleteProductCommand { Id = id };
            await _mediator.Send(product);
            return NoContent();
        }
    }
}
