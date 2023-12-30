using Ecommerce.Application.DTOs.EntitiesDto.Product;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-product")]
        public async Task<IActionResult> Get()
        {
            var command = await _mediator.Send(new GetAllProductsRequest());
            return Ok(command);
        }
        [HttpGet("get-product-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var command = await _mediator.Send(new GetProductDetailsRequest { Id = id });
            return Ok(command);

        }
        [HttpPost("add-new-product")]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            var command = new CreateProductCommand { ProductDto = productDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            var command = new UpdateProductCommand { ProductDto = productDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("delete-product-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
