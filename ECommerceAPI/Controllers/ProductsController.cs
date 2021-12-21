using ECommerceAPI.Entities;
using ECommerceAPI.Services.Interfaces;
using ECommercerAPI.Dto.Request;
using ECommercerAPI.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerResponse(200, "Ok", typeof(ProductDtoCollectionResponse))]
        public async Task<ActionResult<ProductDtoCollectionResponse>> Get(string filter, int page = 1, int rows = 10)
        {
            return Ok(await _service.ListAsync(filter, page, rows));
        }

        [HttpGet("{id}")]
        [SwaggerResponse(200, "Ok", typeof(BaseResponse<ProductSingleDto>))]
        [SwaggerResponse(404, "Ok", typeof(BaseResponse<ProductSingleDto>))]
        public async Task<ActionResult<BaseResponse<ProductSingleDto>>> GetProduct(string id)
        {
            var response = await _service.GetAsync(id);

            if (response.result == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}")]
        [SwaggerResponse(200, "Ok", typeof(BaseResponse<string>))]
        public async Task<IActionResult> PutProduct(string id, ProductDtoRequest request)
        {
            var response = await _service.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpPost]
        [SwaggerResponse(201, "Ok", typeof(BaseResponse<string>))]
        public async Task<ActionResult<Category>> PostProduct([FromBody] ProductDtoRequest request)
        {
            var response = await _service.CreateAsync(request);

            return CreatedAtAction("GetProduct", new { id = response.result }, response);
        }

        [HttpDelete("{id}")]
        [SwaggerResponse(200, "Ok", typeof(BaseResponse<string>))]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var response = await _service.DeleteAsync(id);

            return Ok(response);
        }
    }
}