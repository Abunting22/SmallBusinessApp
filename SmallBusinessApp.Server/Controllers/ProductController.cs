using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SmallBusinessApp.Server.Interfaces;
using SmallBusinessApp.Server.Model;

namespace SmallBusinessApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController(IProductService service) : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Product>>> GetAllProdcuts()
        {
            var productList = await service.GetAllProductsRequest();
            return Ok(productList);
        }

        [HttpGet("GetById{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await service.GetProductByIdRequest(id);
            return Ok(product);
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddNewProduct([FromBody] Product product)
        {
            var result = await service.AddNewProductRequest(product);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> UpdateProductInfo([FromBody] Product product)
        {
            var result = await service.UpdateProductInfoRequest(product);
            return Ok(result);
        }

        [HttpDelete("Delete{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await service.DeleteProductRequest(id);
            return Ok(result);
        }
    }
}
