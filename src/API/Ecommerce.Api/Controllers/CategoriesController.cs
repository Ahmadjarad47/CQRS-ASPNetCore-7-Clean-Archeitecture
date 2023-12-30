using Ecommerce.Application.DTOs.EntitiesDto.Category;
using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Features.Categories.Requests.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("get-all-categories")]
        public async Task<IActionResult> Get()
        {
            var categories = await _mediator.Send(new GetAllCategoriesRequest());
            return Ok(categories);
        }
        [HttpGet("get-catgory-by-id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var catgory = await _mediator.Send(new GetCatgoryDetailsRequest { Id = id });
            if (catgory is null)
                return NotFound();
            return Ok(catgory);
        }
        [HttpPost("add-new-catgory")]
        public async Task<IActionResult> Post([FromBody] CategoryDto categoryDto)
        {
            var command = new CreateCategoryCommand { CategoryDto = categoryDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        [HttpPut("update-current-category")]
        public async Task<IActionResult> Put([FromBody] CategoryDto categoryDto)
        {
            var command = new UpdateCategoryCommand { CategoryDto = categoryDto };
            var response = await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("delete-category-by-id/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var response = await _mediator.Send(command);
            return NoContent();
        }
    }
}
