using ECommerceMobile.Application.Features.Products.Commands.CreateProduct;
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

        [HttpPost]
        public async Task<ActionResult<ProductVm>> CreateProduct([FromBody]CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
