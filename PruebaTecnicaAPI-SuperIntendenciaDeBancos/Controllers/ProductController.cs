using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.Core.Application.Dtos;
using PruebaTecnicaAPI.Core.Application.Enums;
using PruebaTecnicaAPI.Core.Application.Interfaces.Services;

namespace PruebaTecnicaAPI_SuperIntendenciaDeBancos.Controllers
{
    [ApiController]
    [Route("api/products")]
    //[Authorize(Roles = "Basic")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            try
            {
                List<string> category = new List<string>() { "Category" };
                List<ProductDto> products = await productService.GetAllWithIncludeAsync(category);

                if (products.Count <= 0) return NoContent();
                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        } 
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
            try
            {
                ProductDto product = await productService.GetByIdAsync(id);

                if (product == null) return NoContent();
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductCreateDto product)
        {
            try
            {
                if (product == null) return BadRequest();

                await productService.AddAsync(product);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ProductCreateDto product, int id)
        {
            try
            {
                if (product == null) return BadRequest();

                await productService.UpdateAsync(product, id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();

                await productService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }  
    }
}
