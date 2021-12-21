using ECommerceAPI.Dto.Request;
using ECommerceAPI.Services.Interfaces;
using ECommercerAPI.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route(template: "api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        [SwaggerResponse(200, "OK", typeof(CategoryDtoCollectionResponse))]
        public async Task<IActionResult> GetCategories(string filter, int page = 1, int rows =10)
        {
            return Ok(await _service.ListAsync(filter, page, rows));
        }
        [HttpGet]
        [Route(template: "{id}")]
        [SwaggerResponse(200, "OK", typeof(BaseResponse<CategoryDto>))]
        [SwaggerResponse(404, "NOT FOUND", typeof(BaseResponse<CategoryDto>))]
        public async Task<IActionResult> GetCategories(string id)
        {
            var response = await _service.GetAsync(id);

            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost]
        [SwaggerResponse(201, "OK", typeof(BaseResponse<string>))]
        public async Task<IActionResult> PostCategories([FromBody] CategoryRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetCategories", new
            {
                id = response.result
            }, response);
        }
        [HttpPut]
        [Route(template: "{id}")]
        [SwaggerResponse(200, "OK", typeof(BaseResponse<string>))]
        public async Task<IActionResult> PutCategories(string id, [FromBody] CategoryRequest request)
        {
            return Ok(await _service.UpdateAsync(id, request));
        }
        [HttpDelete]
        [Route(template: "{id}")]
        [SwaggerResponse(200, "OK", typeof(BaseResponse<string>))]
        public async Task<IActionResult> DeleteCategories(string id)
        {

            return Ok(await _service.DeleteAsync(id));
        }

    }
}
